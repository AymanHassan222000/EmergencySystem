using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class Notification : BaseEntity
{
    public NotificationTypes Type { get; set; }
    public string Message { get; set; } 
    public string Channel { get; set; }
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }

    public Guid? IncidentId { get; set; }
    public Guid UserId { get; set; }

    public Incident Incident { get; set; }
    public User User { get; set; }
}
