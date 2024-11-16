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

    private static async Task DeleteUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task PutUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task PostUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetUserAtAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<GetUserResponse[]> GetUserAsync(
        HttpContext context,
        IUserRepository _userRepository)
    {
        List<GetUserResponse> getUserResponses = new();

        var users = await _userRepository.GetUsersAsync();
        foreach (var user in users)
        {
            getUserResponses.Add(new GetUserResponse(user.UserId, user.Name, user.Age));
        }
        return getUserResponses.ToArray();
    }
}