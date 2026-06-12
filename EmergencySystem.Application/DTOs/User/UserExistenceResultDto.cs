namespace EmergencySystem.Application.DTOs.User;

public sealed record UserExistenceResultDto(
    bool EmailIsExist,
    bool UserNameIsExist
);

