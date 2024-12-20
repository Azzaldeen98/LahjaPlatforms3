using LAHJA.Mappings;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.ApplicationLayer.Profile;
using LAHJA.Data.UI.Templates.Auth;
using LAHJA.Data.UI.Templates.Plans;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Templates.Payment;
using LAHJA.ApplicationLayer.Payment;

namespace Infrastructure
{
    public static class BlazorAppConfigServices
    {
        public static void InstallBlazorAppConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallServices(serviceCollection);
            InstallHelperServices(serviceCollection);
            InstallTemplates(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddAutoMapper(typeof(BlazorAppMappingConfig));
        }


        private static void InstallHelperServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<RecaptchaService>();
        

        }  
        
        private static void InstallTemplates(this IServiceCollection serviceCollection)
        {



            //serviceCollection.AddScoped < TemplateBase<IBuilderAuthApi<>, IBuilderAuthComponent<DataBuildAuthBase>>();


            //serviceCollection.AddScoped<TemplateBase<IBuilderAuthApi<DataBuildAuthBase>, IBuilderAuthComponent<DataBuildAuthBase>>();

            //serviceCollection.AddScoped<BuilderAuthApiClient>();

            ////  Auth
            serviceCollection.AddScoped<IBuilderAuthApi<DataBuildAuthBase>, BuilderAuthApiClient>();
            serviceCollection.AddScoped<IBuilderAuthComponent<DataBuildAuthBase>,BuilderAuthComponent<DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuthShare<ClientAuthService,DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuth>();

            //// Plans
            serviceCollection.AddScoped<IBuilderPlansApi<DataBuildPlansBase>, BuilderPlansApiClient>();
            serviceCollection.AddScoped<IBuilderPlansComponent<DataBuildPlansBase>, BuilderPlansComponent<DataBuildPlansBase>>();
            serviceCollection.AddScoped<TemplatePlansShare<PlansClientService, DataBuildPlansBase>>();
            serviceCollection.AddScoped<TemplatePlans>();

            //// Payment
            serviceCollection.AddScoped<IBuilderPaymentApi<DataBuildPaymentBase>, BuilderPaymentApiClient>();
            serviceCollection.AddScoped<IBuilderPaymentComponent<DataBuildPaymentBase>, BuilderPaymentComponent<DataBuildPaymentBase>>();
            serviceCollection.AddScoped<TemplatePaymentShare<PaymentClientService, DataBuildPaymentBase>>();
            serviceCollection.AddScoped<TemplatePayment>();
            serviceCollection.AddScoped<TemplatePlans>();

        }
        private static void InstallServices(this IServiceCollection serviceCollection)
        {
     
            serviceCollection.AddScoped<ClientAuthService>();
            serviceCollection.AddTransient<LAHJA.Helpers.Services.AuthService>();
            serviceCollection.AddScoped<PlansClientService>();
            serviceCollection.AddScoped<ClientProfileService>();
            serviceCollection.AddScoped<PaymentClientService>();
           
           
        }
       
    }
}
