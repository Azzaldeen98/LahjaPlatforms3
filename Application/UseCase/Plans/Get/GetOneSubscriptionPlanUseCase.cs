using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetOneSubscriptionPlanUseCase
    {
        private readonly IPlansRepository repository;
        public GetOneSubscriptionPlanUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<SubscriptionPlan>> ExecuteAsync(string planId)
        {

            return await repository.getOneSubscriptionsPlanAsync(planId);

        }
    }
}
