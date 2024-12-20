namespace Infrastructure.Models.Payment.Request
{
    public class PaymentCheckoutRequestModel
    {
        public string? planId { get; set; }
        public string? successUrl { get; set; }
        public string? cancelUrl { get; set; }

    }





}
