using ChoiceSmash.Models.Requests;
using ChoiceSmash.Models.Responses;

namespace IntegrationTests.Infrastructure;

public class ScoreboardFixture : BaseFixture
{
    public HttpResponseMessage Response { get; }

    public GameResult GameResult { get; }
    public ScoreboardResponse Scoreboard { get; }


    public ScoreboardFixture()
    {
        var playRequest = new PlayRequest(1);
        GameResult = Deserialize<GameResult>(Client.PostAsync("/play", Serialize(playRequest)).Result);
        Response = Client.GetAsync("/scoreboard").Result;
        Scoreboard = Deserialize<ScoreboardResponse>(Response);
    }
}