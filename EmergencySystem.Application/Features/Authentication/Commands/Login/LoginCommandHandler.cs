using EmergencySystem.Application.DTOs;
using EmergencySystem.Application.DTOs.Authentication;
using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmergencySystem.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Response<LoginResponseDto>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;
    private readonly IHashingService _hashingService;
    private readonly ILogger<LoginCommandHandler> _logger;
    public LoginCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepo,
        IHashingService hashingService,
        ILogger<LoginCommandHandler> logger
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
        _hashingService = hashingService;
        _logger = logger;
    }

    public async Task<Response<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start handle {CommandName} for user {user}", nameof(LoginCommand), request.UserName ?? request.Email);

        var user = request.Email is null ?
                        await _userRepo.GetByUserNameAsync(request.UserName, cancellationToken) :
                        await _userRepo.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null || !_hashingService.Verify(request.Password, user.PasswordHash))
            return Response<LoginResponseDto>.Failure(ErrorCodes.Unauthorized, "Invalid username or password.");

        var token = _jwtTokenGenerator.GenerateToken(user);

        var response = new LoginResponseDto(
            token.Token,
            token.ExpiresAt,
            new GetUserInfoDto(
                user.Id,
                user.UserName,
                user.Email,
                user.Role.ToString()
            )
        );

        _logger.LogInformation("User {UserName} is login successfuly with ID {UserId}", user.UserName, user.Id);

        return Response<LoginResponseDto>.Success(response, "Login is success.");
    }
}
