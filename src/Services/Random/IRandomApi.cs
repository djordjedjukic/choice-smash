using System.Text.Json.Serialization;
using Refit;

namespace ChoiceSmash.Services.Random;

public interface IRandomApi
{
    [Get("/random")]
    Task<RandomResponse> GetRandomNumberAsync(CancellationToken cancellationToken);
    
    public class RandomResponse
    {
        [JsonPropertyName("random_number")]
        public int RandomNumber { get; set; }
    }
}

