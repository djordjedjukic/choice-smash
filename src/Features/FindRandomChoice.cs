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
        private readonly RandomService _randomService;

        public Handler(RandomService randomService)
        {
            _randomService = randomService;
        }

        public async Task<ChoiceResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            int randomNumber = await _randomService.GetRandomNumberAsync(cancellationToken);
            Choice randomChoice = Choice.FromValue(Utils.NormalizeToRange1To5(randomNumber));

            return new ChoiceResponse(randomChoice.Value, randomChoice.Name);
        }
    }
}