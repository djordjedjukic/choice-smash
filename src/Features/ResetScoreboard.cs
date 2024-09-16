using ChoiceSmash.Services.Scoreboard;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class ResetScoreboard
{
    public record Command : IRequest<Unit>;
    
    internal sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IScoreboardService _scoreboardService;

        public Handler(IScoreboardService scoreboardService)
        {
            _scoreboardService = scoreboardService;
        }

        public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            _scoreboardService.Reset();
            return Task.FromResult(Unit.Value);
        }
    }
}