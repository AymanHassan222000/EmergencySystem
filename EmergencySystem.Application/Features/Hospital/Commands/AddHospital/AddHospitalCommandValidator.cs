using FluentValidation;

namespace EmergencySystem.Application.Features.Hospital.Commands.AddHospital;

public sealed class AddHospitalCommandValidator : AbstractValidator<AddHospitalCommand>
{
    public AddHospitalCommandValidator()
    {
        //Name Validaitons
        RuleFor(h => h.Name)
            .NotEmpty()
            .WithMessage("Hospital is required.")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters log.")
            .MaximumLength(100)
            .WithMessage("Name connot exceed 100 characters.");

        //Countery Validations
        RuleFor(h => h.Country)
            .NotEmpty()
            .WithMessage("Country is required.")
            .MinimumLength(2)
            .WithMessage("Country must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("Country cannot exceed 100 characters.");

        //Governorate Validaiton
        RuleFor(h => h.Governorate)
            .NotEmpty()
            .WithMessage("Governorate is required.")
            .MinimumLength(2)
            .WithMessage("Governorate must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("Governorate cannot exceed 100 characters.");

        //City Validations
        RuleFor(h => h.City)
            .NotEmpty()
            .WithMessage("City is required.")
            .MinimumLength(2)
            .WithMessage("City must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("City cannot exceed 100 characters.");

        //Phone Number Validation
        RuleFor(h => h.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^01[0125][0-9]{8}$")
            .WithMessage("Invalid phone number format.");

        //Hospaital Status Validations
        RuleFor(h => h.Status)
            .IsInEnum()
            .WithMessage("Invalid hospital status.");

        //Total Beds Validaitons
        RuleFor(h => h.TotalBeds)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Hospital must have at least one bed.");

        // Available Beds Validations
        RuleFor(h => h.AvailableBeds)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Available beds cannot be negative.")
            .LessThanOrEqualTo(h => h.TotalBeds)
            .WithMessage("Available beds cannot exceed total beds.");

        //Emergency Capacity Validations
        RuleFor(h => h.EmergencyCapacity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Hospital must have at least one emergency capacity.");

        RuleFor(h => h.AvailableEmergencyCapacity)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Available emergency capacity cannot be negative.")
             .LessThanOrEqualTo(h => h.EmergencyCapacity)
             .WithMessage("Available emergency capacity cannot exceed emergency capacity.");

    }
}
    