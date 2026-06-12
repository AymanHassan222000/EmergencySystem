using EmergencySystem.Application.DTOs.User;
using EmergencySystem.Domain.Entities;

namespace EmergencySystem.Application.Interfaces;

public interface IUserRepository : IGeneralRepository<User>
{
    Task<bool> EmailExists(string email,CancellationToken ct);
    Task<bool> UserNameExists(string userName, CancellationToken ct);
}
