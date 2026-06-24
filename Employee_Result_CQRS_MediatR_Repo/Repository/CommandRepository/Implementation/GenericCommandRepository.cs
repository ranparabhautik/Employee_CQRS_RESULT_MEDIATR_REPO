using Employee_Result_CQRS_MediatR_Repo.Data;

namespace Employee_Result_CQRS_MediatR_Repo.Repository.CommandRepository.Implementation;

public class GenericCommandRepository<T>(AppDbContext context) : IGenericCommandRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbset = context.Set<T>();
    public async Task CreateAsync(T entity)
    {
        await _dbset.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var exising =await _dbset.FirstOrDefaultAsync(x=> x.Id == id);
        if(exising != null)
        {
            exising.IsDeleted = true;
            await context.SaveChangesAsync();
        }
        else
        {
            throw new System.Exception("Employee not found");
        }
        
    }

    public async Task UpdateAsync(T entity)
    {
         _dbset.Update(entity);
        await context.SaveChangesAsync();
    }
}