using FluentValidation;

namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Validator
{
    public class CreateEmployeeValidator:AbstractValidator<EmployeeCreateCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.EmpName).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Provide Valid Email");
            RuleFor(x=> x.salary).GreaterThan(0).NotEmpty().WithMessage("Salary is Required and must be > 0");
            RuleFor(x => x.DeptId).NotEmpty().GreaterThan(0).WithMessage("Dept Id must be greater than 0");
        }
    }
}
