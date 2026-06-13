using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Application.DTOs.Hospital;

public sealed record GetHospitalByIdResponseDto(
    string Name,
    string Country,
    string Governorate,
    string City,
    string PhoneNumber,
    double Latitude,
    double Longitude,
    string Status,
    bool IsGovernmental,
    GetHospitalResourcesInfo Resources
);
