using EmergencySystem.Application.Interfaces;

namespace EmergencySystem.Infrastructure.Services;

public sealed class HashingService : IHashingService
{
    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
