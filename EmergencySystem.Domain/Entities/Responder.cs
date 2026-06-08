using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class Responder : BaseEntity
{
    public required string BadgeNumber { get; set; }
    public required string Specialization { get; set; }
    public required ResponderStatus Status { get; set; }
    public required double CurrentLatitude { get; set; }
    public required double CurrentLongitude { get; set; }
    public DateTime LocationUpdatedAt { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<LocationPoint> LocationPoints { get; set; } = new HashSet<LocationPoint>();
    public ICollection<VehicleAssignment> VehicleAssignments { get; set; } = new HashSet<VehicleAssignment>();
    public ICollection<IncidentAssignment> IncidentAssignments { get; set; } = new HashSet<IncidentAssignment>();
    public ICollection<Incident> ReportedIncidents { get; set; } = new HashSet<Incident>();
}
