using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Hospital;
using EmergencySystem.Application.Features.Hospital.Commands.AddHospital;
using EmergencySystem.Application.Features.Hospital.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmergencySystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class HospitalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HospitalsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<Response<bool>> AddHospital(AddHospitalCommand command) 
    {
        var response = await _mediator.Send(command);

        return response;
    }

    [HttpGet("{id}")]
    public async Task<Response<GetHospitalByIdResponseDto>> GetHospitalById(Guid id) 
    {
        var hospital = await _mediator.Send(new GetHospitalByIdQuery(id));

        return hospital;
    }

}
