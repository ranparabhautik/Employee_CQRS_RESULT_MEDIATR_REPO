using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Query;
using Microsoft.Extensions.Caching.Memory;

namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Handler;

public class GetAllEmployeeHandler(IEmployeeQueryRepository emprepo, IMapper mapper,IMemoryCache cache) : IRequestHandler<GetAllEmployeeQuery, Result<IEnumerable<EmployeeDTO>>>
{
    public async Task<Result<IEnumerable<EmployeeDTO>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {

        const string cachekey = "AllEmployee";

        if (cache.TryGetValue(cachekey, out IEnumerable<EmployeeDTO?> cachedallemployee))
        {
            Console.WriteLine("Fetching from cacheee");
            return Result<IEnumerable<EmployeeDTO>>.Success(cachedallemployee);
        }
        else
        {
            var employees = await emprepo.GetAllAsync();
            if (employees == null)
            {
                return Result<IEnumerable<EmployeeDTO>>.Failure("No Employee Exists");
            }
            var empresult = mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            Console.WriteLine("Fetching from Database");
            cache.Set(cachekey,empresult,TimeSpan.FromMinutes(1));
            return Result<IEnumerable<EmployeeDTO>>.Success(empresult);
        }

    }
}
