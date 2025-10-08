using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace EVDMS.API.Controllers
{
    [ApiController]
    [Route("api/webhooks/stripe")]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IDealerPaymentService _dealerPaymentService;
        private readonly StripeSettings _stripeSettings;

        public StripeWebhookController(
            IDealerPaymentService dealerPaymentService,
            IOptions<StripeSettings> stripeOptions
        )
        {
            _dealerPaymentService = dealerPaymentService;
            _stripeSettings = stripeOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var signatureHeader = Request.Headers["Stripe-Signature"];
            Event stripeEvent;

            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    signatureHeader,
                    _stripeSettings.WebhookSecret
                );
            }
            catch (StripeException ex)
            {
                Console.WriteLine($"StripeException: {ex.Message}");
                return BadRequest();
            }

            switch (stripeEvent.Type)
            {
                case "payment_intent.created":
                    if (stripeEvent.Data.Object is PaymentIntent createdIntent)
                    {
                        await _dealerPaymentService.MarkAsPendingAsync(createdIntent.Id);
                    }
                    break;
                case "payment_intent.canceled":
                case "payment_intent.payment_failed":
                    if (stripeEvent.Data.Object is PaymentIntent failedIntent)
                    {
                        await _dealerPaymentService.MarkAsFailedAsync(failedIntent.Id);
                    }
                    break;
                case "payment_intent.succeeded":
                    if (stripeEvent.Data.Object is PaymentIntent succeededIntent)
                    {
                        await _dealerPaymentService.MarkAsPaidAsync(succeededIntent.Id);
                    }
                    break;
                default:
                    break;
            }

            return Ok();
        }
    }
}
