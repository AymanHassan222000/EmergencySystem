using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.Interfaces;
using Mapster;
using MediatR;

namespace EmergencySystem.Application.Features.Hospital.Commands.AddHospital;

public sealed class AddHospitalCommandHandler : IRequestHandler<AddHospitalCommand, Response<bool>>
{
    private readonly IHospitalRepository _hospitalRepo;

    public AddHospitalCommandHandler(IHospitalRepository hospitalRepo)
    {
        _hospitalRepo = hospitalRepo;
    }

    public async Task<Response<bool>> Handle(AddHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = request.Adapt<Domain.Entities.Hospital>();

        await _hospitalRepo.AddAsync(hospital);
        await _hospitalRepo.SaveChangesAsync();

        return Response<bool>.Success(true, "Add hospital is success.");
    }
}
