using ChoiceSmash.Enums;
using ChoiceSmash.Models.Responses;

namespace ChoiceSmash.Services;

public class Scoreboard
{
    private const int MaxResults = 10;
    private readonly Queue<GameResult> _recentResults = new();

    public void AddResult(GameResult result)
    {
        if (_recentResults.Count == MaxResults)
        {
            _recentResults.Dequeue();
        }
        _recentResults.Enqueue(result);
    }

    public (int PlayerWins, int ComputerWins, int Ties) GetRecentScoreboard()
    {
        // alternative is to use loop-based approach if collection is too large to avoid multiple iterations
        int recentPlayerWins = _recentResults.Count(r => r.Results == Result.Win);
        int recentComputerWins = _recentResults.Count(r => r.Results == Result.Lose);
        int recentTies = _recentResults.Count(r => r.Results == Result.Tie);

        return (recentPlayerWins, recentComputerWins, recentTies);
    }

    public void Reset()
    {
        _recentResults.Clear();
    }
}