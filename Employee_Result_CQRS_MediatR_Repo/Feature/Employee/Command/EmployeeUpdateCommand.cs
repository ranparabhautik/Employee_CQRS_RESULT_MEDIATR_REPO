namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Command;

public record EmployeeUpdateCommand(
    int Id,
    string EmpName,
    int salary,int DeptId,
    string Email) : IRequest<Result<string>>;
