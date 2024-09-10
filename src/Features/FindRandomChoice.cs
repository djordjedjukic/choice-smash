using ChoiceSmash.Enums;
using ChoiceSmash.Models.Responses;
using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class FindRandomChoices
{
    public record Query : IRequest<ChoiceResponse>;

    internal sealed class Handler : IRequestHandler<Query, ChoiceResponse>
    {
        private readonly IRandomApi _randomApi;

        public Handler(IRandomApi randomApi)
        {
            _randomApi = randomApi;
        }

        public async Task<ChoiceResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            IRandomApi.RandomResponse result = await _randomApi.GetRandomNumber();
            Choice randomChoice = Choice.FromValue(Utils.NormalizeToRange1To5(result.RandomNumber));

            return new ChoiceResponse(randomChoice.Value, randomChoice.Name);
        }
    }
}