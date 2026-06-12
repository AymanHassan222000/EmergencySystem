using EmergencySystem.Application.DTOs.Authentication;
using EmergencySystem.Domain.Entities;

namespace EmergencySystem.Application.Interfaces;

public interface IJwtTokenGenerator
{
    GenerateTokenResult GenerateTokenAsync(User user);
}
