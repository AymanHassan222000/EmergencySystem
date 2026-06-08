namespace EmergencySystem.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public required string Token { get; set; }

    public DateTime ExpiresOn { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public DateTime? RevokedOn { get; set; }
    public bool IsActive => RevokedOn == null && !IsExpired;

    public Guid UserId { get; set; }
    public User User { get; set; }
}
