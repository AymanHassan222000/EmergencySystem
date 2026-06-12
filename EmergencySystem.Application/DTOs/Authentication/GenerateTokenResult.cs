namespace EmergencySystem.Application.DTOs.Authentication;

public sealed record GenerateTokenResult(
    string Token,
    DateTime ExpiresAt
);
