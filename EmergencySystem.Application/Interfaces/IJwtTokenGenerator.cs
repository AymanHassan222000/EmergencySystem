using EmergencySystem.Domain.Entities;

namespace EmergencySystem.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateTokenAsync(User user);
}
