using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class IncidentLog : BaseEntity
{
    public IncidentStatus OldStatus { get; set; }
    public IncidentStatus NewStatus { get; set; }
    public string Notes { get; set; }

    public Guid IncidentId { get; set; }
    public Guid ChangedBy { get; set; }
    public Incident Incident { get; set; }
    public User User { get; set; }
}
