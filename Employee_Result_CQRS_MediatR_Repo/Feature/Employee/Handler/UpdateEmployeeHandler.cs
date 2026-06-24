namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Handler
{
    public class UpdateEmployeeHandler(IGenericQueryRepository<Employees> qryrepo, IGenericCommandRepository<Employees> cmdrepo, IMapper mapper) : IRequestHandler<EmployeeUpdateCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var emp = await qryrepo.GetByIdAsync(request.Id);
            if(emp != null) {
                var employee = mapper.Map(request,emp);
                employee.UpdatedAt = DateTime.UtcNow;
                await cmdrepo.UpdateAsync(employee);
                return Result<string>.Success("Employee Updated");
            }
            else
            {
                return Result<string>.Failure("Employee doesnot exist");
            }
        }
    }
}
