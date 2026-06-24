namespace Employee_Result_CQRS_MediatR_Repo.Models.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string EmpName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal salary { get; set; } 
    public int DeptId { get; set; }
    public string DeptName { get; set; }
}
