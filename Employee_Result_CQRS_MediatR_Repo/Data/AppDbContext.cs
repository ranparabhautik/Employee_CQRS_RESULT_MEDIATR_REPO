namespace Employee_Result_CQRS_MediatR_Repo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{

    public DbSet<Employees> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>().HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(x => x.DeptId);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(new Department {Id=1,DeptName="IT",CreatedAt=new DateTime(2026,2,2) },new Department { Id=2,DeptName="HR",CreatedAt= new DateTime(2026,4,20)},new Department { Id=3,DeptName="Sales",CreatedAt=new DateTime(2026,3,12)});
    }
}
    