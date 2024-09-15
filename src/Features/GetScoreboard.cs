using ChoiceSmash.Models.Responses;
using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class GetScoreboard
{
    public record Query : IRequest<ScoreboardResponse>;

    internal sealed class Handler : IRequestHandler<Query, ScoreboardResponse>
    {
        private readonly IScoreboard _scoreboard;

        public Handler(IScoreboard scoreboard)
        {
            _scoreboard = scoreboard;
        }

        public Task<ScoreboardResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = _scoreboard.GetRecentScoreboard();

            return Task.FromResult(result);
        }
    }
}