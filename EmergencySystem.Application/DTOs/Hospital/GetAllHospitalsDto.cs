namespace EmergencySystem.Application.DTOs.Hospital;

public sealed record GetAllHospitalsDto(
    string Name,
    string Country,
    string Governorate,
    string City,
    string PhoneNumber,
    double Latitude,
    double Longitude,
    string Status,
    bool IsGovernmental
);
