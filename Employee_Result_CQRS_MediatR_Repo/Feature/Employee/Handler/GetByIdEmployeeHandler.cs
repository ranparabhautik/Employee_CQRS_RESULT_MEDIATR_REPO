using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Query;

namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Handler
{
    public class GetByIdEmployeeHandler(IEmployeeQueryRepository emprepo,IMapper mapper) : IRequestHandler<GetByIDEmployeeQuery, Result<EmployeeDTO>>
    {
        public async Task<Result<EmployeeDTO>> Handle(GetByIDEmployeeQuery request, CancellationToken cancellationToken)
        {
            var emp = await emprepo.GetByIdAsync(request.Id);
            if(emp  == null)
            {
                return Result<EmployeeDTO>.Failure($"Employee with Id : {request.Id} not found");
            }
            var empresult = mapper.Map<EmployeeDTO>(emp);
            return Result<EmployeeDTO>.Success(empresult);
        }
    }
}
