using BillingApi.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        //ajax call from client sending debit charge and remark
        [HttpPost("charge")]
        public IActionResult Charge([FromBody]LedgerItemDto ledgerItem)
        {
            LedgerItemDto newCharge = new LedgerItemDto();
            newCharge.Posted = DateTime.Now;
            newCharge.Description = "Charge";
            newCharge.Debit = ledgerItem.Debit * -1;
            newCharge.Remarks = ledgerItem.Remarks;
            newCharge.User = ledgerItem.User;
            
            //get ledger item and post to backend
            //at success of updated db, return the new item to the client, else return error
            
            if (ledgerItem == null)
            {
                return NotFound();
            }

            return Ok(newCharge);
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
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    Console.WriteLine("PaymentIntent was successful!");
                    Console.WriteLine(paymentIntent);
                }
                else if (stripeEvent.Type == Events.PaymentMethodAttached)
                {
                    var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                    Console.WriteLine("PaymentMethod was attached to a Customer!");
                    Console.WriteLine(paymentMethod);
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
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

