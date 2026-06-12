namespace EmergencySystem.Application.DTOs;

public sealed record GetUserInfoDto(
    Guid Id,
    string UserName,
    string Email,
    string Role
);
