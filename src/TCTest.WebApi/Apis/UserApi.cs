using TCTest.DomainService;
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
        DeleteUserDS deleteUserDS)
    {
        await deleteUserDS.ExecuteAsync(userId);
    }

    public static async Task PutUserAsync(
        string UserId,
        PutUserRequest putUserRequest,
        IUpdateUserDS updateUserDS)
    {
        await updateUserDS.ExecuteAsync(UserId, putUserRequest.Name, putUserRequest.Age);
    }

    public static async Task PostUserAsync(
        PostUserRequest postUserRequest,
        IAddUserDS addUserDS)
    {
        await addUserDS.ExecuteAsync(postUserRequest.UserId, postUserRequest.Name, postUserRequest.Age);
    }

    public static async Task<GetUserResponse> GetUserAtAsync(
        string userId,
        IGetUserAtDS getUserAtDS)
    {
        var user = await getUserAtDS.ExecuteAsync(userId);

        // DTO mapping
        return new GetUserResponse(user.UserId, user.Name, user.Age);
    }

    public static async Task<GetUserResponse[]> GetUserAsync(
        IGetUserDS getUserDS)
    {
        List<GetUserResponse> getUserResponses = new();

        var users = await getUserDS.ExecuteAsync();

        // DTO mapping
        foreach (var user in users)
        {
            getUserResponses.Add(new GetUserResponse(user.UserId, user.Name, user.Age));
        }
        return getUserResponses.ToArray();
    }
}