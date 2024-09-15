using ChoiceSmash.Models.Responses;
using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class GetScoreboard
{
    public record Query : IRequest<ScoreboardResponse>;

    internal sealed class Handler : IRequestHandler<Query, ScoreboardResponse>
    {
        private readonly InMemoryScoreboard _inMemoryScoreboard;

        public Handler(InMemoryScoreboard inMemoryScoreboard)
        {
            _inMemoryScoreboard = inMemoryScoreboard;
        }

        public Task<ScoreboardResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = _inMemoryScoreboard.GetRecentScoreboard();

            return Task.FromResult(result);
        }
    }
}