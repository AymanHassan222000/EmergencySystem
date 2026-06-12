using System.ComponentModel.DataAnnotations;

namespace EmergencySystem.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    [Key]
    public Guid Id { get; init; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } 
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
