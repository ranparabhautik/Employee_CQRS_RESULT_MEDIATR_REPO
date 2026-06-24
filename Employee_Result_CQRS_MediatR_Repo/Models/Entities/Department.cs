namespace Employee_Result_CQRS_MediatR_Repo.Models.Entities;

public class Department:BaseEntity
{
    public required string DeptName { get; set; }
    public ICollection<Employees> Employees = new List<Employees>();
}
