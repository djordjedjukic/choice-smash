using ChoiceSmash.Enums;

namespace ChoiceSmash.Services;

public static class GameService
{
    private static readonly Dictionary<(Choice, Choice), (Choice winner, string verb)> ChoiceRules = new()
    {
        { (Choice.Rock, Choice.Scissors), (Choice.Rock, "crushes") },
        { (Choice.Rock, Choice.Lizard), (Choice.Rock, "crushes") },
        { (Choice.Paper, Choice.Rock), (Choice.Paper, "covers") },
        { (Choice.Paper, Choice.Spock), (Choice.Paper, "disproves") },
        { (Choice.Scissors, Choice.Paper), (Choice.Scissors, "cuts") },
        { (Choice.Scissors, Choice.Lizard), (Choice.Scissors, "decapitates") },
        { (Choice.Lizard, Choice.Spock), (Choice.Lizard, "poisons") },
        { (Choice.Lizard, Choice.Paper), (Choice.Lizard, "eats") },
        { (Choice.Spock, Choice.Scissors), (Choice.Spock, "smashes") },
        { (Choice.Spock, Choice.Rock), (Choice.Spock, "vaporizes") }
    };

    public static string DetermineWinner(Choice playerChoice, Choice computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return Result.Tie;
        }

        if (ChoiceRules.TryGetValue((playerChoice, computerChoice), out (Choice winner, string verb) _))
        {
            return Result.Win;
        }

        if (ChoiceRules.TryGetValue((computerChoice, playerChoice), out (Choice winner, string verb) _))
        {
            return Result.Lose;
        }

        return Result.Lose;
    }
}