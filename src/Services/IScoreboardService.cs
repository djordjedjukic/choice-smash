using ChoiceSmash.Domain;
using ChoiceSmash.Models.Responses;

namespace ChoiceSmash.Services;

public interface IScoreboardService
{
    void AddResult(GameResult result);
    ScoreboardResponse GetRecentScoreboard();
    void Reset();
}