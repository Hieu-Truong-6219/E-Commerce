using Grpc.Core;
using User_service.Application;

namespace User_service.Presentation;

public class UserGrpcController(ILogger<UserGrpcController> logger, IUserService userService)
    : UserCrud.UserCrudBase
{
    private readonly ILogger<UserGrpcController> _logger = logger;
    private readonly IUserService _userService = userService;

    public override async Task<InfoReply> CreateUser(
        CreateRequest request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var parsedUserInfo = new UserInfoDto()
        {
            Role = request.Role,
            Email = request.Email,
            Username = request.Username,
            Password = request.Password,
        };
        var createdUser = await _userService.CreateUserAsync(parsedUserInfo);
        var parsedCreatedUser = ToInfoReply(createdUser);

        _logger.LogInformation("Sending response: {@Response}", parsedCreatedUser);

        return parsedCreatedUser;
    }

    public override async Task<InfoReplies> GetAllUser(
        Google.Protobuf.WellKnownTypes.Empty request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var foundUsers = await _userService.GetAllUsersAsync();
        var parsedFoundUsers = new InfoReplies();
        parsedFoundUsers.Replies.Add(foundUsers.ConvertAll(user => ToInfoReply(user)));

        _logger.LogInformation("Sending response: {@Response}", parsedFoundUsers);

        return parsedFoundUsers;
    }

    public override async Task<InfoReply> GetUser(GetRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var foundUser = await _userService.GetUserInfoDtoAsync(request.Uuid);
        if (foundUser == null)
            return new InfoReply();
        var parsedFoundUser = ToInfoReply(foundUser);

        _logger.LogInformation("Sending response: {@Response}", parsedFoundUser);

        return parsedFoundUser;
    }

    public override async Task<InfoReply> UpdateUser(
        UpdateRequest request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var parsedUserInfo = new UserInfoDto()
        {
            Uuid = request.Uuid,
            Role = request.Role,
            Email = request.Email,
            Username = request.Username,
            Password = request.Password,
        };
        var updatedUser = await _userService.UpdateUserAsync(parsedUserInfo.Uuid, parsedUserInfo);
        if (updatedUser == null)
            return new InfoReply();
        var parsedUpdatedUser = ToInfoReply(updatedUser);

        _logger.LogInformation("Sending response: {@Response}", parsedUpdatedUser);

        return parsedUpdatedUser;
    }

    public override async Task<InfoReply> DeleteUser(
        DeleteRequest request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("Received request: {@Request}", request);

        var deletedUser = await _userService.DeleteUserAsync(request.Uuid);
        if (deletedUser == null)
            return new InfoReply();
        var parsedDeletedUser = ToInfoReply(deletedUser);

        _logger.LogInformation("Sending response: {@Response}", parsedDeletedUser);

        return parsedDeletedUser;
    }

    private InfoReply ToInfoReply(UserInfoDto info)
    {
        return new InfoReply()
        {
            Uuid = info.Uuid,
            Role = info.Role,
            Email = info.Email,
            Username = info.Username,
            Password = info.Password,
        };
        ;
    }
}
