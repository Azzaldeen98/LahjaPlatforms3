﻿using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Plans
{
    public class PlansApiClient
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PlansApiClient(
            ClientFactory clientFactory, 
            IMapper mapper, 
            IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        private async Task<PlansClient> GetApiClient()
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<PlansClient>("ApiClient");
            return client;
        }

        public async Task<Result<IEnumerable<ContainerPlansModel>>> getAllContainersPlansAsync(int skip = 0, int take = 0)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GroupAsync();


                var resModel = _mapper.Map<IEnumerable<ContainerPlansModel>>(response);
                return Result<IEnumerable<ContainerPlansModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<ContainerPlansModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<IEnumerable<PlanResponseModel>>> getAllPlansAsync()
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.PlansGetAsync();


                var resModel = _mapper.Map<IEnumerable<PlanResponseModel>>(response);
                return Result<IEnumerable<PlanResponseModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<PlanResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<PlanResponseModel>> createPlanAsync(PlanCreateModel request)
        {
            try
            {
                var model = _mapper.Map<PlanCreate>(request);
                var client = await GetApiClient();
                var response = await client.PlansPostAsync(model);


                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }    
        
        public async Task<Result<PlanResponseModel>> updatePlanAsync(PlanUpdateModel request)
        {
            try
            {
                var model = _mapper.Map<PlanUpdate>(request);
                var client = await GetApiClient();
                var response = await client.PlansPutAsync(request.Id,model);


                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<IEnumerable<PlansGroupModel>>> getPlansGroupAsync(int skip=0,int take=0)
        {
            try
            {

                var client = await GetApiClient();
                var response =  await client.GroupAsync();


                var resModel = _mapper.Map<IEnumerable<PlansGroupModel>>(response);
                return Result<IEnumerable<PlansGroupModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<PlansGroupModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

 
        
        public async Task<Result<IEnumerable<SubscriptionPlanModel>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.PlansGetAsync();
                if(response == null)
                    return Result<IEnumerable<SubscriptionPlanModel>>.Success();


                var resModel = _mapper.Map<IEnumerable<SubscriptionPlanModel>>(response);
                return Result<IEnumerable<SubscriptionPlanModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<SubscriptionPlanModel>>.Fail(e.Response,httpCode:e.StatusCode);

            }



        }

        public async Task<Result<PlanResponseModel>> getPlanByIdAsync(string id)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.PlansGetAsync(id);
                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
    }
}
