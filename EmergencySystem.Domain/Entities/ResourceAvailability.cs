namespace EmergencySystem.Domain.Entities;

public class ResourceAvailability : BaseEntity
{
    public int TotalBeds { get; set; }
    public int AvailableBeds { get; set; }
    public int EmergencyCapacity { get; set; } 
    public int AvailableEmergencyCapacity { get; set; } 
    public Guid HospitalId { get; set; }
    public Hospital Hospital { get; set; }
}
