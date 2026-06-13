using EmergencySystem.Application.Interfaces;
using FluentValidation;

namespace EmergencySystem.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IUserRepository userRepo) 
    {

        RuleFor(x => x)
            .Must(x => 
                !string.IsNullOrWhiteSpace(x.UserName) ||
                !string.IsNullOrEmpty(x.Email)
            )
            .WithMessage("Please enter either Email or UserName.");

        RuleFor(x => x.UserName)
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters long.")
            .MaximumLength(50)
            .WithMessage("Username cannot exceed 50 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.UserName));


        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(200)
            .WithMessage("Email cannot exceed 200 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
    }
}
