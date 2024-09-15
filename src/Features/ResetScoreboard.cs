using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class ResetScoreboard
{
    public record Command : IRequest<Unit>;
    
    internal sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly Scoreboard _scoreboard;

        public Handler(Scoreboard scoreboard)
        {
            _scoreboard = scoreboard;
        }

        public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            _scoreboard.Reset();
            return Task.FromResult(Unit.Value);
        }
    }
}