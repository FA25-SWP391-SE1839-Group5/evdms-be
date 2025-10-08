using Stripe;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IStripeService
    {
        Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, string currency);
        Task<PaymentIntent> CancelPaymentIntentAsync(string paymentIntentId);
    }
}
