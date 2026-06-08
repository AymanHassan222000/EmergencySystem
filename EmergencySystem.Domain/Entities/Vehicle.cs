using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class Vehicle : BaseEntity
{
    public VehicleType Type { get; set; }
    public string PlateNumber { get; set; }
    public VehicleStatus Status { get; set; }
    public Guid ResponderId { get; set; }
    public Responder Responder { get; set; }

    public ICollection<VehicleAssignment> VehicleAssignments { get; set; } = new HashSet<VehicleAssignment>();
}
