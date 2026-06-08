namespace EmergencySystem.Domain.Entities;

public class VehicleAssignment : BaseEntity
{
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    public Guid ResponderId { get; set; } 
    public Responder Responder { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? UnassignedAt { get; set; }

    public bool IsActive { get; set; }
}
