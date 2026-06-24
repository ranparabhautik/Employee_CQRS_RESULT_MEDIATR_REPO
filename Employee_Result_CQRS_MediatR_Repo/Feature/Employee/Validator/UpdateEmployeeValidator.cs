using FluentValidation;

namespace Employee_Result_CQRS_MediatR_Repo.Feature.Employee.Validator;

public class UpdateEmployeeValidator : AbstractValidator<EmployeeUpdateCommand>
{
    public UpdateEmployeeValidator()
    {

        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.EmpName).NotEmpty();

        RuleFor(x => x.Email).NotEmpty().EmailAddress();

        RuleFor(x => x.salary).GreaterThan(0);

        RuleFor(x => x.DeptId).GreaterThan(0);
    }
}
