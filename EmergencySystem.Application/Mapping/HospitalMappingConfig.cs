using EmergencySystem.Application.Features.Hospital.Commands.AddHospital;
using EmergencySystem.Domain.Entities;
using Mapster;

namespace EmergencySystem.Application.Mapping
{
    public class HospitalMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddHospitalCommand, Hospital>()
                .Map(
                    dest => dest.ResourceAvailability,
                    src => new ResourceAvailability
                    {
                        TotalBeds = src.TotalBeds,
                        AvailableBeds = src.AvailableBeds,
                        EmergencyCapacity = src.EmergencyCapacity,
                        AvailableEmergencyCapacity = src.AvailableEmergencyCapacity,
                    }
                );
        }
    }
}
