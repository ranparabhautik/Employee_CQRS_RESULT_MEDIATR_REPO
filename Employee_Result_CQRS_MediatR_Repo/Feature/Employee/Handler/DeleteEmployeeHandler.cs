namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Handler
{
    public class DeleteEmployeeHandler(IGenericQueryRepository<Employees> qryrepo, IGenericCommandRepository<Employees> cmdrepo) : IRequestHandler<EmployeeDeleteCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var emp = await qryrepo.GetByIdAsync(request.Id);
            if(emp == null)
            {
                return Result<string>.Failure("Employee with this id does not exist");
            }
            await cmdrepo.DeleteAsync(request.Id);
            return Result<string>.Success("Employee Deleted Succesfully");
    }
}}
