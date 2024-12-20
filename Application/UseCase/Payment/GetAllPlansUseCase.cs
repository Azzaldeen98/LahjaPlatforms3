using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Repository.Payment;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPaymentCheckOutUseCase
    {
        private readonly IPaymentRepository repository;
        public GetPaymentCheckOutUseCase(IPaymentRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PaymentCheckoutResponse>> ExecuteAsync(PaymentCheckoutRequest request)
        {

            return await repository.getPaymentCheckoutPage(request);

        }
    }  

}
