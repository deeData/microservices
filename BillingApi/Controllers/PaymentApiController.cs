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
                Console.WriteLine("======*************************===================GET ALL LEDGER DATA");
                return ledgerItemDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR. Cannot get ledger items from DB. " + e);
                throw;
            }
        }

        //ajax call from client sending debit charge and remark
        [HttpPost("charge")]
        //public IActionResult Charge([FromBody]LedgerItemDto ledgerItem)
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
                bool isApplied = await _billingTransactionsRepository.DebitChargeApply(newCharge);
                if (isApplied)
                {
                    await _hubContext.Clients.All.SendAsync("systemMessageMethod", "This is a test message from SignalR ");
                    return Ok(newCharge);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERORR CANNOT SAVE: "+e);
                return BadRequest();
            }
        }

        //webhook connection with Stripe - get response from Stripe after web client sends payment data with a client secret to proccess a payment
        //user stripe CLI for localhost
        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                //set throwOnApiVersionMismatch as "true" when in production
                var stripeEvent = EventUtility.ParseEvent(json, throwOnApiVersionMismatch: false);

                // Handle the event
                if (stripeEvent.Type == Events.ChargeSucceeded)
                {
                    var charge = stripeEvent.Data.Object as Charge;
                    var last4 = charge.PaymentMethodDetails.Card.Last4;
                    //var jObject = JObject.Parse(json);
                    //var last4 = jObject["data"]["object"]["payment_method_details"]["card"]["last4"].Value<string>();
                    Console.WriteLine($"Charge was successful! Last 4 of the card is { last4 }");
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

        //server generates client secret (required by Stripe) and sends to Stripe to initialize
        [HttpPost("secret")]
        public ActionResult GetSecret([FromBody]PaymentIntentCreateRequest request)
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client

            //LINQ iterating through IEnumerable of items
            int cents = (int)(items.Sum(item => item.Amount * 100));
            return cents;
        }
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

