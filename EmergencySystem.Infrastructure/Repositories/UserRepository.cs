using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Entities;
using EmergencySystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmergencySystem.Infrastructure.Repositories;

public class UserRepository : GeneralRepository<User>, IUserRepository
{
    public UserRepository(EmergencySystemDbContext context) : base(context) { }

    public async Task<bool> EmailExists(string email, CancellationToken ct) => await _dbSet.AnyAsync(x => x.Email == email, ct);

    public async Task<bool> UserNameExists(string userName, CancellationToken ct) => await _dbSet.AnyAsync(x => x.UserName == userName, ct);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct) => await _dbSet.FirstOrDefaultAsync(x => x.Email == email, ct);

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken ct) => await _dbSet.FirstOrDefaultAsync(x => x.UserName == userName, ct);
}
