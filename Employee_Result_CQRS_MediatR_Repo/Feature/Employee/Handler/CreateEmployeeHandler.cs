namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Handler
{
    public class CreateEmployeeHandler(IEmployeeQueryRepository emprepo, IGenericCommandRepository<Employees> cmdrepo,IMapper mapper) : IRequestHandler<EmployeeCreateCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.EmpName)){
                return Result<int>.Failure("Name must be filled");
            }

            var emailexist = await emprepo.EmailExistAsync(request.Email);
            if (!emailexist)
            {
                var emp = mapper.Map<Employees>(request);
                await cmdrepo.CreateAsync(emp);
                return Result<int>.Success(emp.Id);
            }
            else
            {
                return Result<int>.Failure("Email already Exists");
            }
        }
    }
}
