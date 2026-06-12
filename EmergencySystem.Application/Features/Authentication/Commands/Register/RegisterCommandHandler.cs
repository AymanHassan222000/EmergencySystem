using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Authentication;
using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmergencySystem.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<RegisterResponseDto>>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IHashingService _hashingService;
    private readonly ILogger<RegisterCommandHandler> _logger;
    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepo,
        IHashingService hashingService,
        ILogger<RegisterCommandHandler> logger)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
        _hashingService = hashingService;
        _logger = logger;
    }

    public async Task<Response<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {CommandName} for user {UserName}", nameof(RegisterCommand), request.UserName);

        var user = request.Adapt<User>();
        user.PasswordHash = _hashingService.Hash(request.Password);

        await _userRepo.AddAsync(user);
        //await _userRepo.SaveChangesAsync();

        var result = _jwtTokenGenerator.GenerateTokenAsync(user);

        var registerResponseDto = new RegisterResponseDto(
            result.Token,
            result.ExpiresAt,
            new GetUserInfoDto(
                user.Id,
                user.UserName,
                user.Email,
                user.Role.ToString()
            )
        );

        _logger.LogInformation("User {UserName} registered successfully with ID {UserId}", user.UserName, user.Id);

        return Response<RegisterResponseDto>.Success(registerResponseDto, "Registration is success.");
    }
}
