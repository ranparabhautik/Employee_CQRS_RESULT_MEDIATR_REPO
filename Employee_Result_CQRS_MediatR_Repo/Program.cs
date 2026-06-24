using Employee_Result_CQRS_MediatR_Repo.Behavior;
using Employee_Result_CQRS_MediatR_Repo.Data;
using Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Validator;
using Employee_Result_CQRS_MediatR_Repo.Mappings;
using Employee_Result_CQRS_MediatR_Repo.Repository.CommandRepository.Implementation;
using Employee_Result_CQRS_MediatR_Repo.Repository.CommandRepository.Interface;
using Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Implementation;
using Employee_Result_CQRS_MediatR_Repo.Repository.QueryRepository.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConn"));
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeValidator>();
builder.Services.AddScoped(typeof(IGenericQueryRepository<>),typeof(GenericQueryRepository<>));
builder.Services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericCommandRepository<>));
builder.Services.AddScoped<IEmployeeQueryRepository,EmployeeQueryRepository>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<EmployeeMappingProfile>();
});

builder.Services.AddMemoryCache();


builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));  

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
