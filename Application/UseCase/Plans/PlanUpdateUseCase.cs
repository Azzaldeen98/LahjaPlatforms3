using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class PlanUpdateUseCase
    {
        private readonly IPlansRepository repository;
        public PlanUpdateUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanResponse>> ExecuteAsync(PlanUpdate request)
        {

            return await repository.updatePlanAsync(request);

        }
    }

}
