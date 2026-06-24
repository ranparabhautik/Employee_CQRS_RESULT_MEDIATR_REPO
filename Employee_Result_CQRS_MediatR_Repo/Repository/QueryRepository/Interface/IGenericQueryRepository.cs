namespace Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Interface;

public interface IGenericQueryRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);

}
