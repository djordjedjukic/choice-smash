using ChoiceSmash.Models.Responses;

namespace ChoiceSmash.Services;

public static class GameHistory
{
    private static readonly Queue<GameResult> _recentResults = new Queue<GameResult>();
    public static Scoreboard Scoreboard = new Scoreboard();
    
    public static void AddResult(GameResult result)
    {
        if (_recentResults.Count == 10)
        {
            _recentResults.Dequeue();
        }
        _recentResults.Enqueue(result);
    }
    
    public static void Reset()
    {
        _recentResults.Clear();
    }
}