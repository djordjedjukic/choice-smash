using ChoiceSmash.Enums;
using ChoiceSmash.Models.Responses;
using ChoiceSmash.Services;
using FluentValidation;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class PlayGame
{
    public record Command(int Player) : IRequest<GameResult>;
    
    internal sealed class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Player)
                .Must(c => Choice.TryFromValue(c, out _))
                .WithMessage("Provided choice is invalid");
        }
    }

    internal sealed class Handler : IRequestHandler<Command, GameResult>
    {
        private readonly IRandomApi _randomApi;

        public Handler(IRandomApi randomApi)
        {
            _randomApi = randomApi;
        }

        public async Task<GameResult> Handle(Command request, CancellationToken cancellationToken)
        {
            int playerChoiceId = request.Player;
            int computerChoiceId = Utils.NormalizeToRange1To5((await _randomApi.GetRandomNumber()).RandomNumber);
            
            var result = GameService.DetermineWinner(Choice.FromValue(playerChoiceId), Choice.FromValue(computerChoiceId));
            
            return new GameResult(playerChoiceId, computerChoiceId, result);
        }
    }
}