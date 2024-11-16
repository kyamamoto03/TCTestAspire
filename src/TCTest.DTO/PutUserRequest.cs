using System.Text.Json.Serialization;

namespace TCTest.DTO;

public class PutUserRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("age")]
    public int Age { get; set; } = default!;
}