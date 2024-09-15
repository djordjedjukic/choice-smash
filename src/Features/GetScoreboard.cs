using ChoiceSmash.Services;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class GetScoreboard
{
    public record Query : IRequest<Response>;

    public record Response(int PlayerWins, int ComputerWins, int Ties);

    internal sealed class Handler : IRequestHandler<Query, Response>
    {
        private readonly Scoreboard _scoreboard;

        public Handler(Scoreboard scoreboard)
        {
            _scoreboard = scoreboard;
        }

        public Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = _scoreboard.GetRecentScoreboard();

            return Task.FromResult(new Response(result.PlayerWins, result.ComputerWins, result.Ties));
        }
    }
}