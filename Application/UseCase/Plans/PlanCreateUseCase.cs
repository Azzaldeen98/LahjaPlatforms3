using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class PlanCreateUseCase
    {
        private readonly IPlansRepository repository;
        public PlanCreateUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanResponse>> ExecuteAsync(PlanCreate request)
        {

            return await repository.createPlanAsync(request);

        }
    }

}
