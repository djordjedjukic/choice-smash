using ChoiceSmash.Models.Responses;
using ChoiceSmash.Services.Scoreboard;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class GetScoreboard
{
    public record Query : IRequest<ScoreboardResponse>;

    internal sealed class Handler : IRequestHandler<Query, ScoreboardResponse>
    {
        private readonly IScoreboardService _scoreboardService;

        public Handler(IScoreboardService scoreboardService)
        {
            _scoreboardService = scoreboardService;
        }

        public Task<ScoreboardResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = _scoreboardService.GetRecentScoreboard();

            return Task.FromResult(result);
        }
    }
}