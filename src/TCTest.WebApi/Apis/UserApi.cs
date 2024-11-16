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

    private static async Task DeleteUserAsync(
        HttpContext context,
        string userId,
        IUserRepository userRepository)
    {
        await userRepository.DeleteUserAsync(userId);
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    private static async Task PutUserAsync(
        HttpContext context,
        string UserId,
        PutUserRequest putUserRequest,
        IUserRepository userRepository)
    {
        await userRepository.UpdateUserAsync(UserId, putUserRequest.Name, putUserRequest.Age);
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    private static async Task PostUserAsync(
        HttpContext context,
        PostUserRequest postUserRequest,
        IUserRepository userRepository)
    {
        await userRepository.AddUserAsync(new User(postUserRequest.UserId, postUserRequest.Name, postUserRequest.Age));
        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }

    private static async Task<GetUserResponse> GetUserAtAsync(
        HttpContext context,
        string userId,
        IUserRepository _userRepository)
    {
        var user = await _userRepository.GetUserAsync(userId);
        return new GetUserResponse(user.UserId, user.Name, user.Age);
    }

    private static async Task<GetUserResponse[]> GetUserAsync(
        HttpContext context,
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