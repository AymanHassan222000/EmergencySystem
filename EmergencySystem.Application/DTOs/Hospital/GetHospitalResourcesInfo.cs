namespace EmergencySystem.Application.DTOs.Hospital;

public sealed record GetHospitalResourcesInfo(
    int TotalBeds,
    int AvailableBeds,
    int EmergencyCapacity,
    int AvailableEmergencyCapacity
);
