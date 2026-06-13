using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Entities;
using EmergencySystem.Infrastructure.Context;

namespace EmergencySystem.Infrastructure.Repositories;

public sealed class HospitalRepository : GeneralRepository<Hospital>, IHospitalRepository
{
    public HospitalRepository(EmergencySystemDbContext context) : base(context) { }



}
