namespace EmergencySystem.Domain.Entities;

public class CitizenProfile : BaseEntity
{
    public required string FirstName { get; set; } 
    public string? MiddleName { get; set; } 
    public required string LastName { get; set; }
    public required string Country { get; set; }
    public required string Governorate { get; set; }
    public required string City { get; set; }
    public required string PhoneNumber { get; set; }
    public double DefaultLatitude { get; set; }
    public double DefaultLongitude { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; } 
}
