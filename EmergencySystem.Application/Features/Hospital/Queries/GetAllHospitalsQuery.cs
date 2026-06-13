using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Hospital;
using EmergencySystem.Application.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencySystem.Application.Features.Hospital.Queries;

public sealed record GetAllHospitalsQuery:IRequest<Response<IEnumerable<GetAllHospitalsDto>>>;

public sealed class GetAllHospitalsQueryHandler : 
    IRequestHandler<GetAllHospitalsQuery, Response<IEnumerable<GetAllHospitalsDto>>>
{
    private readonly IGeneralRepository<Domain.Entities.Hospital> _hospitalRepo;

    public GetAllHospitalsQueryHandler(IGeneralRepository<Domain.Entities.Hospital> hospitalRepo)
    {
        _hospitalRepo = hospitalRepo;
    }

    public async Task<Response<IEnumerable<GetAllHospitalsDto>>> Handle(GetAllHospitalsQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepo.Get().ProjectToType<GetAllHospitalsDto>().ToListAsync();

        return Response<IEnumerable<GetAllHospitalsDto>>.Success(hospitals,"Get all hospitals is success.");
    }
}
