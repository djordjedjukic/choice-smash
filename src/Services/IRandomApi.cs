using System.Text.Json.Serialization;
using Refit;

namespace ChoiceSmash.Services;

public interface IRandomApi
{
    [Get("/random")]
    Task<RandomResponse> GetRandomNumber();
    
    public class RandomResponse
    {
        [JsonPropertyName("random_number")]
        public int RandomNumber { get; set; }
    }
}

