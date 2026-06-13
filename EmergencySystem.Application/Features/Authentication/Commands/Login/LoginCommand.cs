using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Authentication;
using MediatR;

namespace EmergencySystem.Application.Features.Authentication.Commands.Login;

public sealed record LoginCommand(
    string? UserName,
    string? Email,
    string Password
) : IRequest<Response<LoginResponseDto>>;
