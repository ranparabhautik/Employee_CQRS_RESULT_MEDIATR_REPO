namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Command
{
    public record EmployeeDeleteCommand(int Id):IRequest<Result<string>>;
    
}
