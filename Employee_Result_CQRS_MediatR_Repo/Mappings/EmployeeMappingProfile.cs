namespace Employee_Result_CQRS_MediatR_Repo.Mappings;

public class EmployeeMappingProfile:Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<EmployeeCreateCommand, Employees>().ReverseMap();
        CreateMap<EmployeeUpdateCommand, Employees>().ReverseMap();
        CreateMap<EmployeeDTO,Employees>();
        CreateMap<Employees, EmployeeDTO>().ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.DeptName));
    }
}
