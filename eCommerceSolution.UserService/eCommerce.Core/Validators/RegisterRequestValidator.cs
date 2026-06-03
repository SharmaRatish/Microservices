using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required").MinimumLength(3).WithMessage("Minimum 3 characters").Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|\'~\\-]").WithMessage("{PropertyName} must contain at least one special character.");
        RuleFor(request => request.PersonName).NotEmpty().WithMessage("Pesrson name is required").Length(1, 50).WithMessage("Person name should be 1 to 50 charactors long");
        RuleFor(request => request.Gender).NotNull().WithMessage("Gender is required").IsInEnum().WithMessage("Invalid gender option");

    }
}
