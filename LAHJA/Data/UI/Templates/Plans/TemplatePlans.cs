using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Templates.Plans
{




    public interface IBuilderPlansComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitContainerPlans { get; set; }
        public Func<T, Task> SubmitCreatePlan { get; set; }
        public Func<T, Task> SubmitUpdatePlan { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }

     
    }

    public interface IBuilderPlansApi<T> : IBuilderApi<T>
    {

        Task<Result<List<CategoryComponent>>> GetAllCategories();
        Task<Result<List<SubscriptionPlanInfo>>> getSubscriptionsPlansAsync(T data);
        Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync();
        Task<Result<SubscriptionPlanInfo>> getOneSubscriptionPlanAsync(T data);
        Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(T data);

        Task<Result<PlanResponse>> UpdatePlan(DataBuildPlansBase data);
        Task<Result<PlanResponse>> CreatePlan(DataBuildPlansBase data);
 

    }

    public abstract class BuilderPlansApi<T, E> : BuilderApi<T, E>, IBuilderPlansApi<E>
    {

        public BuilderPlansApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        public abstract Task<Result<List<CategoryComponent>>> GetAllCategories();

        public abstract Task<Result<List<SubscriptionPlanInfo>>> getSubscriptionsPlansAsync(E data);  
        
        public abstract Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync();
        public abstract Task<Result<SubscriptionPlanInfo>> getOneSubscriptionPlanAsync(E data);

        public abstract Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(E data);

        public abstract Task<Result<PlanResponse>> UpdatePlan(DataBuildPlansBase data);
        public abstract Task<Result<PlanResponse>> CreatePlan(DataBuildPlansBase data);


    }
    public class BuilderPlansComponent<T> : IBuilderPlansComponent<T>
    {
        public Func<T, Task> SubmitContainerPlans { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }
        public Func<T, Task> SubmitCreatePlan { get; set ; }
        public Func<T, Task> SubmitUpdatePlan { get ; set ; }


    }


    public class TemplatePlansShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderPlansApi<E> builderApi;
        private readonly IBuilderPlansComponent<E> builderComponents;
        public IBuilderPlansComponent<E> BuilderComponents { get => builderComponents; }
        public TemplatePlansShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderPlansComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client){



            builderComponents = new BuilderPlansComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }


    public class BuilderPlansApiClient : BuilderPlansApi<PlansClientService, DataBuildPlansBase>, IBuilderPlansApi<DataBuildPlansBase>
    {
        public BuilderPlansApiClient(IMapper mapper, PlansClientService service) : base(mapper, service)
        {
        }
        public override async Task<Result<PlanResponse>> UpdatePlan(DataBuildPlansBase data)
        {
            var model = Mapper.Map<PlanUpdate>(data);
            var res = await Service.planUpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<PlanResponse>(res.Data);
                    return Result<PlanResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<PlanResponse>.Fail();
                }
            }
            else
            {
                return Result<PlanResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<PlanResponse>> CreatePlan(DataBuildPlansBase data)
        {
            var model = Mapper.Map<PlanCreate>(data);
            var res = await Service.planCreateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<PlanResponse>(res.Data);
                    return Result<PlanResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<PlanResponse>.Fail();
                }
            }
            else
            {
                return Result<PlanResponse>.Fail(res.Messages);
            }
        }
        public override async Task<Result<List<CategoryComponent>>> GetAllCategories()
        {
           
            var res= await Service.getAllContainersAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<CategoryComponent>>(res.Data);
                    return Result<List<CategoryComponent>>.Success(map);

                }catch(Exception e)
                {
                    return Result<List<CategoryComponent>>.Fail();
                }
            }
            else
            {
                return Result<List<CategoryComponent>>.Fail(res.Messages);
            }
        }

 
        public override async Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync()
        {
           
            var res = await Service.getAllSubscriptionPlansAsync();
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<SubscriptionPlan>>(res.Data);
                return Result<List<SubscriptionPlan>>.Success(map);
            }
            else
            {
                return Result<List<SubscriptionPlan>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<SubscriptionPlanInfo>>> getSubscriptionsPlansAsync(DataBuildPlansBase data)
        {
            //return await Service.getSubscriptionsPlansAsync(data.CategoryId);

            var res = await Service.getSubscriptionsPlansAsync(data.CategoryId);
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<SubscriptionPlanInfo>>(res.Data);
                return Result<List<SubscriptionPlanInfo>>.Success(map);
            }
            else
            {
                return Result<List<SubscriptionPlanInfo>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(DataBuildPlansBase data)
        {
            //return await Service.getSubscriptionPlanFeaturesAsync(data.PlanId);


            var res = await Service.getSubscriptionPlanFeaturesAsync(data.PlanId);
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<PlanFeature>>(res.Data);
                return Result<List<PlanFeature>>.Success(map);
            }
            else
            {
                return Result<List<PlanFeature>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<SubscriptionPlanInfo>> getOneSubscriptionPlanAsync(DataBuildPlansBase data)
        {
            var res = await Service.getOneSubscriptionPlanAsync(data.PlanId);
            if (res.Succeeded)
            {
                var map = Mapper.Map<SubscriptionPlanInfo>(res.Data);
            
                return Result<SubscriptionPlanInfo>.Success(map);
            }
            else
            {
                return Result<SubscriptionPlanInfo>.Fail(res.Messages);
            }
        }
    }


    public class TemplatePlans: TemplatePlansShare<PlansClientService, DataBuildPlansBase>
    {
        public List<CategoryComponent> Categories { get=> _categories; }
        public List<SubscriptionPlanInfo> SubscriptionPlans { get => _plans; }
        public SubscriptionPlanInfo SubscriptionPlan { get => _plan; }
        public List<string> Errors { get => _errors; }

     


        public TemplatePlans(
            IMapper mapper,
            AuthService AuthService,
            PlansClientService client,
            IBuilderPlansComponent<DataBuildPlansBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitContainerPlans = OnSubmitContainerPlans;
            this.BuilderComponents.SubmitSubscriptionPlan = OnSubmitSubscriptionPlan;
            this.BuilderComponents.SubmitUpdatePlan = OnSubmitUpdatePlans;
            this.BuilderComponents.SubmitCreatePlan = OnSubmitCreatePlans;
           

            this.builderApi = new BuilderPlansApiClient(mapper, client);

            Task.FromResult(OnInitialize());

        }

 
      
        private List<CategoryComponent> _categories = new List<CategoryComponent>();
        private List<SubscriptionPlanInfo> _plans = new List<SubscriptionPlanInfo>();
        private SubscriptionPlanInfo _plan = new SubscriptionPlanInfo();

        //public  IBuilderPlansComponent<DataBuildPlansBase, DataBuildPlansBase> BuilderPlansComponent { get => builderPlansComponents; }
        private async Task OnInitialize()
        {
                var response = await builderApi.GetAllCategories();
                if (response.Succeeded)
                {
                   _categories = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            

        }

        private async Task OnSubmitCreatePlans(DataBuildPlansBase dataBuildPlansBase)
        {

            if (dataBuildPlansBase != null)
            {
                var response = await builderApi.CreatePlan(dataBuildPlansBase);
                if (response.Succeeded)
                {
                 
                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }

        private async Task OnSubmitUpdatePlans(DataBuildPlansBase dataBuildPlansBase)
        {

            if (dataBuildPlansBase != null)
            {
                var response = await builderApi.UpdatePlan(dataBuildPlansBase);
                if (response.Succeeded)
                {
                    
                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }
        private async Task OnSubmitContainerPlans(DataBuildPlansBase dataBuildPlansBase)
        {

            if (dataBuildPlansBase != null)
            {
                var response = await builderApi.getSubscriptionsPlansAsync(dataBuildPlansBase);
                if (response.Succeeded)
                {
                    _plans = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }

        public async Task<Result<SubscriptionPlanInfo>> OnSubmitSubscriptionPlan(DataBuildPlansBase dataBuildPlansBase)
        {
            
            
                var response = await builderApi.getOneSubscriptionPlanAsync(dataBuildPlansBase);

                return response;
           
            

        }  
       

    }

}
