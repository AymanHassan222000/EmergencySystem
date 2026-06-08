using EmergencySystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmergencySystem.Domain.Entities;

public class User : BaseEntity
{
    [MinLength(3)]
    public required string UserName { get; set; }

    [MinLength(5)]
    public required string Email { get; set; } 
    public required string PasswordHash { get; set; } 
    public required UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    public CitizenProfile? CitizenProfile { get; set; }
    public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public ICollection<IncidentLog> IncidentLogs { get; set; } = new HashSet<IncidentLog>();
    public ICollection<Responder> Responders { get; set; } = new HashSet<Responder>();
    public ICollection<TransferRequest> TransferRequests { get; set; } = new HashSet<TransferRequest>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}
