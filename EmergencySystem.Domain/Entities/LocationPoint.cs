namespace EmergencySystem.Domain.Entities;

public class LocationPoint : BaseEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Guid ResponderId { get; set; }
    public Responder Responder { get; set; }
}
