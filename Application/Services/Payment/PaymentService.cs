using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class PaymentService
    {
        private readonly GetPaymentCheckOutUseCase getPaymentCheckOutUseCase;


        public PaymentService(GetPaymentCheckOutUseCase getPaymentCheckOutUseCase)
        {
            this.getPaymentCheckOutUseCase = getPaymentCheckOutUseCase;
        }

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOutPage(PaymentCheckoutRequest  request)
        {
            return await getPaymentCheckOutUseCase.ExecuteAsync(request);

        }
      


    
    } 
}
