using BillingApi.Hubs;
using BillingApi.Model.Dtos;
using BillingApi.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PaymentApi.Controllers
{
    [Route("api/payment")]
    public class PaymentApiController : Controller
    {
        private IBillingTransactionsRepository _billingTransactionsRepository;
        private readonly IHubContext<PaidHub> _hubContext;
        public PaymentApiController(IBillingTransactionsRepository billingTransactionsRepository, IHubContext<PaidHub> hubContext)
        {
            _billingTransactionsRepository = billingTransactionsRepository;
            _hubContext = hubContext;
        }

            [HttpGet]
        public async Task<List<LedgerItemDto>> Get()
        {
            try
            {
                List<LedgerItemDto> ledgerItemDtos = await _billingTransactionsRepository.GetAllTransactions();
                return ledgerItemDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR. Cannot get ledger items from DB. " + e);
                throw;
            }
        }


        [HttpGet("delete")]
        public async Task<IActionResult> Delete()
        {
            bool areDeleted = await _billingTransactionsRepository.DeleteAllInLedger();
            if (areDeleted)
            {
                return Ok(new LedgerItemDto());
            }
            return BadRequest();
        }


        //ajax call from client sending debit charge, remark, userName
        [HttpPost("charge")]
        public async Task<IActionResult> Charge([FromBody] LedgerItemDto ledgerItem)
        {
            LedgerItemDto newCharge = new LedgerItemDto();
            newCharge.Posted = DateTime.Now;
            newCharge.Description = "Charge";
            newCharge.Debit = ledgerItem.Debit;
            newCharge.Remarks = ledgerItem.Remarks;
            newCharge.User = ledgerItem.User;

            //get ledger item and post to backend db
            try
            {
                bool isApplied = await _billingTransactionsRepository.ApplyToLedger(newCharge);
                if (isApplied)
                {
                    return Ok(newCharge);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERORR CANNOT SAVE: " + e);
                return BadRequest();
            }
        }

        //server generates client secret (required by Stripe) and sends to Stripe to initialize
        [HttpPost("secret")]
        public ActionResult GetSecret([FromBody] PaymentIntentCreateRequest request)
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                //in cents
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        //webhook connection with Stripe - get response from Stripe after web client sends payment data with a client secret to proccess a payment
        //use stripe CLI for webhook communications from localhost testing
        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            LedgerItemDto ledgerItemDto = new LedgerItemDto();
            var signalRmessage = "";
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            
            try
            {
                //set throwOnApiVersionMismatch as "true" when in production
                var stripeEvent = EventUtility.ParseEvent(json, throwOnApiVersionMismatch: false);

                //handle event
                if (stripeEvent.Type == Events.ChargeSucceeded)
                {
                    var charge = stripeEvent.Data.Object as Charge;
                    var last4 = charge.PaymentMethodDetails.Card.Last4;
                    var remark = $"Payment from Card# {last4}";
                    //in cents convert to dollars
                    var credit = ((double)charge.Amount/(double)100);
                    ledgerItemDto.Credit = credit;
                    ledgerItemDto.Remarks = remark;
                    //var jObject = JObject.Parse(json);
                    //var last4 = jObject["data"]["object"]["payment_method_details"]["card"]["last4"].Value<string>();
                    
                    bool isPaymentPosted = await PostPayment(ledgerItemDto);

                    if (isPaymentPosted)
                    {
                        signalRmessage = $"Stripe confirmed payment of ${credit} was posted to the ledger. Card is 'x{ last4 }'";
                    }
                    else
                    {
                        signalRmessage = $"Unable to post confirmed Stripe payment of ${credit} to the ledger. Last 4 digits of the card is '{ last4 }'";
                    }
                    await _hubContext.Clients.All.SendAsync("systemMessageMethod", signalRmessage);

                }
                // ... handle other event types
                else
                {
                    Console.WriteLine($"Unhandled event type: {stripeEvent.Type}, json {json}");
                }

                return Ok();
            }
            catch (StripeException ex)
            {
                return BadRequest(ex);
            }
        }

        //Pretend reponse from Stripe server to this Webhook with payment processing details-----FOR PORTFOLIO USE ONLY
        //ajax call from client sending credit amount and userid
        [HttpPost("mock-webhook")]
        public async Task<IActionResult> MockWebhook([FromBody] LedgerItemDto ledgerItem)
        {
            LedgerItemDto newPayment = new LedgerItemDto();
            newPayment.Posted = DateTime.Now;
            newPayment.Description = "Payment";
            newPayment.Credit = ledgerItem.Credit;
            newPayment.Remarks = "Visa Card# [N/A]";
            newPayment.User = ledgerItem.User;

            //get ledger item and post to backend db
            try
            {
                bool isApplied = await _billingTransactionsRepository.ApplyToLedger(newPayment);
                if (isApplied)
                {
                    return Ok(newPayment);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERORR CANNOT SAVE: " + e);
                return BadRequest();
            }
        }

        //to be used with real webhook with Stripe
        private async Task<bool> PostPayment(LedgerItemDto ledgerItem)
        {
            LedgerItemDto newPayment = new LedgerItemDto();
            newPayment.Posted = DateTime.Now;
            newPayment.Description = "Payment";
            newPayment.Credit = ledgerItem.Credit;
            newPayment.Remarks = ledgerItem.Remarks;
            //grab userId from URL
            newPayment.User = ledgerItem.User;

            try
            {
                bool isApplied = await _billingTransactionsRepository.ApplyToLedger(newPayment);
                if (isApplied)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client

            //LINQ iterating through IEnumerable of items
            int cents = (int)(items.Sum(item => item.Amount * 100 ));
            return cents;
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("amount")]
            public double Amount { get; set; }
        }

        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }
    }
}
