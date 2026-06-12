namespace EmergencySystem.Domain.Enums;

public enum ErrorCodes
{
    NoError,
    ValidationErrors,

    // User
    EmailIsExistBefore = 100,
    UserNameIsExistBefore = 101,
}
