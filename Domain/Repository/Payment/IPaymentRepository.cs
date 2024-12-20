using Domain.Entities.Payment.Response;
using Domain.Entities.Payment;
using Domain.Wrapper;

namespace Domain.Repository.Payment
{
    public interface IPaymentRepository
    {
        Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutPage(PaymentCheckoutRequest request);
    }

}
