namespace Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Interface;

public interface IEmployeeQueryRepository:IGenericQueryRepository<Employees>
{
    Task<Employees?> GetByEmailAsync(string email);
    Task<bool> EmailExistAsync(string email);
    
}
