using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Authentication;
using EmergencySystem.Application.Features.Authentication.Commands.Login;
using EmergencySystem.Application.Features.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmergencySystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<Response<RegisterResponseDto>> Register(RegisterCommand command) 
    {
        _logger.LogInformation("Received registration request for user: {UserName}", command.UserName);
        var result = await _mediator.Send(command);
        _logger.LogInformation("Registration request for user: {UserName} processed successfully", command.UserName); 
        return result;
    }

    [HttpPost]
    public async Task<Response<LoginResponseDto>> Login(LoginCommand command)
    {
        _logger.LogInformation("Received login request for user: {UserName}", command.UserName ?? command.Email);
        var result = await _mediator.Send(command);
        _logger.LogInformation("Login request for user: {UserName} processed successfully", command.UserName);
        return result;
    }
}
