using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Hospital;
using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencySystem.Application.Features.Hospital.Queries;

public sealed record GetHospitalByIdQuery(Guid Id) : IRequest<Response<GetHospitalByIdResponseDto>>;

public sealed class GetHospitalByIdHandler : IRequestHandler<GetHospitalByIdQuery, Response<GetHospitalByIdResponseDto>>
{
    private readonly IGeneralRepository<Domain.Entities.Hospital> _hospitalRepo;
    public GetHospitalByIdHandler(IGeneralRepository<Domain.Entities.Hospital> hospitalRepository)
    {
        _hospitalRepo = hospitalRepository;
    }

    public async Task<Response<GetHospitalByIdResponseDto>> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
    {

        var hospital = await _hospitalRepo.Get(m => m.Id == request.Id)
                                          .ProjectToType<GetHospitalByIdResponseDto>()
                                          .FirstOrDefaultAsync();

        if (hospital is null)
            return Response<GetHospitalByIdResponseDto>.Failure(ErrorCodes.HospitalNotExist, $"Not found hospital with ID {request.Id}");

        return Response<GetHospitalByIdResponseDto>.Success(hospital, "Get hospital is success.");
    }
}
