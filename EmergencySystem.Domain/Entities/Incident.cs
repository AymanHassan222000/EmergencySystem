using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class Incident : BaseEntity
{

    public IncidentCategory Category { get; set; }

    public string Description { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public IncidentStatus Status { get; set; }

    public IncidentPriority Priority { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public Guid ReporterId { get; set; }
    public Responder Reporter { get; set; } = null!;

    public ICollection<IncidentAssignment> Assignments { get; set; } = new HashSet<IncidentAssignment>();
    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public ICollection<TransferRequest> TransferRequests { get; set; } = new HashSet<TransferRequest>();
    public ICollection<IncidentLog> IncidentLogs { get; set; } = new HashSet<IncidentLog>();    
}
