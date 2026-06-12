namespace EmergencySystem.Application.DTOs.Authentication;

public sealed record RegisterResponseDto(
    string Token,
    DateTime ExpiresAt,
    GetUserInfoDto User
);
