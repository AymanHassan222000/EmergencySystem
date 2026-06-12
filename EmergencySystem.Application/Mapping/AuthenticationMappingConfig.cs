using EmergencySystem.Application.Features.Authentication.Commands.Register;
using EmergencySystem.Domain.Entities;
using EmergencySystem.Domain.Enums;
using Mapster;

namespace EmergencySystem.Application.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterCommand, User>()
              .Map(
                dest => dest.CitizenProfile,
                src => new CitizenProfile() 
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    MiddleName = src.MiddleName,
                    Country = src.Country,
                    Governorate = src.Governorate,
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    DefaultLatitude = src.DefaultLatitude,
                    DefaultLongitude = src.DefaultLongitude,
                    IsMale = src.IsMale,
                }
              )
              .Map(dest => dest.Role, _ => UserRole.Citizen);

    }
}
