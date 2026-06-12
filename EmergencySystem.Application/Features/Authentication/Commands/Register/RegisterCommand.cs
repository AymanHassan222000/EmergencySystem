using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Authentication;
using MediatR;

namespace EmergencySystem.Application.Features.Authentication.Commands.Register;

public sealed record RegisterCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string? MiddleName,
    string LastName,
    string PhoneNumber,
    string Country,
    string Governorate,
    string City,
    double DefaultLatitude = 0.0,
    double DefaultLongitude = 0.0,  
    bool IsMale = true
) : IRequest<Response<RegisterResponseDto>>;
