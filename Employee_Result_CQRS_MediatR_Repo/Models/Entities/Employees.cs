namespace Employee_Result_CQRS_MediatR_Repo.Models.Entities;

public class Employees : BaseEntity
{
    public string EmpName { get; set; }
    public int salary { get; set; }
    public string Email { get; set; }
    public int DeptId { get; set; }
    public Department Department { get; set; }
}
