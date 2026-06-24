namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Command;

public record EmployeeCreateCommand(
    string EmpName,
    string Email,
    int salary,
    int DeptId) : IRequest<Result<int>>;
