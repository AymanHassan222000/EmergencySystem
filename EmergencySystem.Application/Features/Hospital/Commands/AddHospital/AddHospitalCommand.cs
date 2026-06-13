using EmergencySystem.Application.DTOs;
using EmergencySystem.Domain.Enums;
using MediatR;

namespace EmergencySystem.Application.Features.Hospital.Commands.AddHospital;

public sealed record AddHospitalCommand(
    string Name,
    string Country, 
    string Governorate ,
    string City, 
    string PhoneNumber, 
    double Latitude, 
    double Longitude, 
    int TotalBeds,
    int AvailableBeds,
    int EmergencyCapacity,
    int AvailableEmergencyCapacity,
    HospitalStatus Status, 
    bool IsGovernmental = true
) : IRequest<Response<bool>>;
