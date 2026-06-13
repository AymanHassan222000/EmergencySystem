namespace EmergencySystem.Application.DTOs.Authentication;

public sealed record LoginResponseDto(
    string Token,
    DateTime ExpiresAt,
    GetUserInfoDto User
);
