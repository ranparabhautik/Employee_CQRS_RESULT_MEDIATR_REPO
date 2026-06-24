namespace Employee_Result_CQRS_MediatR_Repo.Models.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }  = DateTime.Now;
    public DateTime UpdatedAt {  get; set; }
    public bool IsDeleted { get; set; } = false;
}
