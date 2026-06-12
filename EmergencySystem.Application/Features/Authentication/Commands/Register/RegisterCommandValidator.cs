using EmergencySystem.Application.Interfaces;
using FluentValidation;

namespace EmergencySystem.Application.Features.Authentication.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(IUserRepository userRepo)
    {

        // Username Validation
        RuleFor(rc => rc.UserName)
            .NotEmpty()
            .WithMessage("Username is required.")
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters long.")
            .MaximumLength(50)
            .WithMessage("Username cannot exceed 50 characters.");

        // Email Validtion
        RuleFor(rc => rc.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(200)
            .WithMessage("Email cannot exceed 200 characters.");

        // Check if email or username is not exist before.
        RuleFor(x => x)
            .CustomAsync(async (request, context, ct) =>
            {
                var emailExists = await userRepo.EmailExists(request.Email,ct);
                var userNameExists = await userRepo.UserNameExists(request.UserName, ct);

                if (emailExists)
                {
                    context.AddFailure(
                        nameof(RegisterCommand.Email),
                        "Email already exists");
                }

                if (userNameExists)
                {
                    context.AddFailure(
                        nameof(RegisterCommand.UserName),
                        "Username already exists");
                }

            });

        // Password Validation
        RuleFor(rc => rc.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");

        RuleFor(rc => rc.ConfirmPassword)
            .Equal(rc => rc.Password)
            .WithMessage("Passwords do not match.");

        // First Name Validation
        RuleFor(rc => rc.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(100)
            .WithMessage("First name cannot exceed 100 characters.");

        // Middle Name Validation (Optional)
        RuleFor(rc => rc.MiddleName)
            .MaximumLength(100)
            .WithMessage("Middle name cannot exceed 100 characters.");

        // Last Name Validation
        RuleFor(rc => rc.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(100)
            .WithMessage("Last name cannot exceed 100 characters.");

        // Phone Number Validation
        RuleFor(rc => rc.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^01[0125][0-9]{8}$")
            .WithMessage("Invalid phone number format.");

        // Country Validation
        RuleFor(rc => rc.Country)
            .NotEmpty()
            .WithMessage("Country is required.")
            .MaximumLength(100)
            .WithMessage("Country cannot exceed 100 characters.");

        // Governorate Validation
        RuleFor(rc => rc.Governorate)
            .NotEmpty()
            .WithMessage("Governorate is required.")
            .MaximumLength(100)
            .WithMessage("Governorate cannot exceed 100 characters.");

        // City Validation
        RuleFor(rc => rc.City)
            .NotEmpty()
            .WithMessage("City is required.")
            .MaximumLength(100)
            .WithMessage("City cannot exceed 100 characters.");

    }
}
