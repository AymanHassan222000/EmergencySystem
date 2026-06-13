using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class Hospital : BaseEntity
{
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string Governorate { get; set; }
    public required string City { get; set; }
    public required string PhoneNumber { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required HospitalStatus Status { get; set; }
    public bool IsGovernmental { get; set; }
    public ResourceAvailability ResourceAvailability { get; set; } 
    public ICollection<TransferRequest> TransferRequests { get; set; } = new HashSet<TransferRequest>();
}
