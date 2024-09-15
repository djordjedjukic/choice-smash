using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class ResetScoreboard
{
    public record Command : IRequest<Unit>;
    
    internal sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly InMemoryScoreboard _inMemoryScoreboard;

        public Handler(InMemoryScoreboard inMemoryScoreboard)
        {
            _inMemoryScoreboard = inMemoryScoreboard;
        }

        public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            _inMemoryScoreboard.Reset();
            return Task.FromResult(Unit.Value);
        }
    }
}