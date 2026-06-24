using Employee_Result_CQRS_MediatR_Repo.Data;

namespace Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Implementation;

public class EmployeeQueryRepository(AppDbContext context) : GenericQueryRepository<Employees>(context), IEmployeeQueryRepository
{

    public async Task<bool> EmailExistAsync(string email)
    {
        return await _context.Employees.AnyAsync(x=> x.Email == email && ! x.IsDeleted);
    }

    public async Task<Employees?> GetByEmailAsync(string email)
    {
        return await _context.Employees.FirstOrDefaultAsync(x=> x.Email == email);
    }

    public override async Task<IEnumerable<Employees>> GetAllAsync()
    {
        return await _context.Employees.Include(x => x.Department).Where(x => x.IsDeleted == false).ToListAsync();
    }
    public override async Task<Employees?> GetByIdAsync(int id)
    {
        return await _context.Employees.Include(x => x.Department).Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x=> x.Id == id);
    }   
}
