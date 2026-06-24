using Employee_Result_CQRS_MediatR_Repo.Data;

namespace Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Implementation;

public class GenericQueryRepository<T>(AppDbContext context) : IGenericQueryRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;

    private readonly DbSet<T> _dbset = context.Set<T>();

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbset.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbset.FirstOrDefaultAsync(x => x.Id == id);
    }
}
