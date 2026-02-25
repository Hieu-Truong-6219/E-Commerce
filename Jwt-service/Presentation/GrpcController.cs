using Grpc.Core;
using Jwt_service.Application;
using Jwt_service.Domain;

namespace Jwt_service.Presentation;

public class GrpcController(ILogger<GrpcController> logger, IAccessTokenService accessTokenService)
    : AccessToken.AccessTokenBase
{
    private readonly ILogger<GrpcController> _logger = logger;
    private readonly IAccessTokenService _accessTokenService = accessTokenService;

    public override Task<SignedTokenReply> SignAccessToken(
        TokenRequest request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var tokenInfo = new AccessTokenInfo(audience: request.Aud, subject: request.Sub);
        var signedToken = new SignedTokenReply { Token = _accessTokenService.SignToken(tokenInfo) };

        _logger.LogInformation("Sending response: {@Response}", tokenInfo);

        return Task.FromResult(signedToken);
    }
}
