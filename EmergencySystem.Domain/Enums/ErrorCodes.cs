namespace EmergencySystem.Domain.Enums;

public enum ErrorCodes
{
    NoError,
    ValidationErrors,
    Unauthorized,

    // User
    EmailIsExistBefore = 100,
    UserNameIsExistBefore = 101,

    // Hospital
    HospitalNotExist = 200,
}
