using EmergencySystem.Domain.Enums;

namespace EmergencySystem.Domain.Entities;

public class TransferRequest : BaseEntity
{
    public Guid IncidentId { get; set; }

    public Guid HospitalId { get; set; }
    public Guid UserId { get; set; }

    public TransferRequestStatus Status { get; set; }

    public string? Notes { get; set; }

    public Incident Incident { get; set; }
    public Hospital Hospital { get; set; }
    public User User { get; set; }
}
