using AutoMapper;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class PaymentApiClient
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PaymentApiClient(
            ClientFactory clientFactory,
            IMapper mapper,
            IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        private async Task<CheckoutClient> GetApiClient()
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<CheckoutClient>("ApiClient");
            return client;
        }

        public async Task<Result<PaymentCheckoutResponseModel>> getPaymentCheckOutPageUrl(PaymentCheckoutRequestModel request)
        {
            try
            {
                var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.CheckoutAsync(model);


                var resModel = _mapper.Map<PaymentCheckoutResponseModel>(response);
                return Result<PaymentCheckoutResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PaymentCheckoutResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
