namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Query;

public record GetByIDEmployeeQuery (int Id): IRequest<Result<EmployeeDTO>>;
