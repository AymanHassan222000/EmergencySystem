namespace EmergencySystem.Domain.Entities;

public class IncidentAssignment : BaseEntity
{
    public DateTime? AcceptedAt { get; set; }
    public DateTime? ArrivedAt { get; set; }

    public Guid IncidentId { get; set; }
    public Guid ResponderId { get; set; }
    public Incident Incident { get; set; }
    public Responder Responder { get; set; }
}
