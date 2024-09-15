using Polly;
using Refit;

namespace ChoiceSmash.Services;

public sealed class RandomService
{
    private readonly IRandomApi _randomApi;
    private readonly IAsyncPolicy<int> _retryPolicy;

    public RandomService(IRandomApi randomApi)
    {
        _randomApi = randomApi;

        _retryPolicy = Policy<int>
            .Handle<ApiException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public async Task<int> GetRandomNumberAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                var response = await _randomApi.GetRandomNumber(cancellationToken);
                return response.RandomNumber;
            });
        }
        catch (ApiException apiEx)
        {
            Console.WriteLine($"API error: {apiEx.StatusCode}");
            throw;
        }
    }
}