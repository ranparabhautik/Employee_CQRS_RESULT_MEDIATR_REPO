namespace Employee_Result_CQRS_MediatR_Repo.Repository.CommandRepository.Interface;

public interface IGenericCommandRepository<T> where T : BaseEntity
{
  
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
