using TCTest.Domain.UserModel;
using TCTest.DTO;

namespace TCTest.WebApi.Apis;

public static class UserApi
{
    public static RouteGroupBuilder MapUserApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/users");
        api.MapGet("/", GetUserAsync);
        api.MapGet("/{userId}", GetUserAtAsync);
        api.MapPost("/", PostUserAsync);
        api.MapPut("/{userId}", PutUserAsync);
        api.MapDelete("/{userId}", DeleteUserAsync);
        return api;
    }

    public static async Task DeleteUserAsync(
        string userId,
        IUserRepository userRepository)
    {
        await userRepository.DeleteUserAsync(userId);
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    public static async Task PutUserAsync(
        string UserId,
        PutUserRequest putUserRequest,
        IUserRepository userRepository)
    {
        await userRepository.UpdateUserAsync(UserId, putUserRequest.Name, putUserRequest.Age);
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    public static async Task PostUserAsync(
        PostUserRequest postUserRequest,
        IUserRepository userRepository)
    {
        await userRepository.AddUserAsync(new User(postUserRequest.UserId, postUserRequest.Name, postUserRequest.Age));
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    public static async Task<GetUserResponse> GetUserAtAsync(
        string userId,
        IUserRepository _userRepository)
    {
        var user = await _userRepository.GetUserAsync(userId);
        return new GetUserResponse(user.UserId, user.Name, user.Age);
    }

    public static async Task<GetUserResponse[]> GetUserAsync(
        IUserRepository userRepository)
    {
        List<GetUserResponse> getUserResponses = new();

        var users = await userRepository.GetUsersAsync();
        foreach (var user in users)
        {
            getUserResponses.Add(new GetUserResponse(user.UserId, user.Name, user.Age));
        }
        return getUserResponses.ToArray();
    }
}