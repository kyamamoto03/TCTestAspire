using System.Text.Json.Serialization;

namespace TCTest.DTO;

public class PostUserRequest
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("age")]
    public int Age { get; set; } = default!;
}