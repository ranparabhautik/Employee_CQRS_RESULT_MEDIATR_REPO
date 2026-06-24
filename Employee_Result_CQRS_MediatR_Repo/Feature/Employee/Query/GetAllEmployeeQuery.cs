namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Query;

public record GetAllEmployeeQuery() : IRequest<Result<IEnumerable<EmployeeDTO>>>;
