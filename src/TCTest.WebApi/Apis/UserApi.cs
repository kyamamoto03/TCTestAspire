using Microsoft.AspNetCore.Mvc;
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
        [FromServices] IDeleteUserDS deleteUserDS)
    {
        // 認証やらバリデーション

        await deleteUserDS.ExecuteAsync(userId);
    }

    public static async Task PutUserAsync(
        string UserId,
        [FromBody] PutUserRequest putUserRequest,
        [FromServices] IUpdateUserDS updateUserDS)
    {
        // 認証やらバリデーション

        await updateUserDS.ExecuteAsync(UserId, putUserRequest.Name, putUserRequest.Age);
    }

    public static async Task PostUserAsync(
        [FromBody] PostUserRequest postUserRequest,
        [FromServices] IAddUserDS addUserDS)
    {
        // 認証やらバリデーション

        await addUserDS.ExecuteAsync(postUserRequest.UserId, postUserRequest.Name, postUserRequest.Age);
    }

    public static async Task<GetUserResponse> GetUserAtAsync(
        string userId,
        [FromServices] IGetUserAtDS getUserAtDS)
    {
        // 認証やらバリデーション

        var user = await getUserAtDS.ExecuteAsync(userId);
        // DTO mapping
        return new GetUserResponse(user.UserId, user.Name, user.Age);
    }

    public static async Task<GetUserResponse[]> GetUserAsync(
        [FromServices] IGetUserDS getUserDS)
    {
        List<GetUserResponse> getUserResponses = new();

        // 認証やらバリデーション

        var users = await getUserDS.ExecuteAsync();

        // DTO mapping
        foreach (var user in users)
        {
            getUserResponses.Add(new GetUserResponse(user.UserId, user.Name, user.Age));
        }
        return getUserResponses.ToArray();
    }
}