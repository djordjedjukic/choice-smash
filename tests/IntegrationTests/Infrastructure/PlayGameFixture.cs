using ChoiceSmash.Domain;
using ChoiceSmash.Models.Requests;
using ChoiceSmash.Models.Responses;

namespace IntegrationTests.Infrastructure;

public class PlayGameFixture : BaseFixture
{
    public HttpResponseMessage Response { get; }
    public GameResult? GameResult { get; }
    

    public PlayGameFixture()
    {
        var playRequest = new PlayRequest(1);
        Response = Client.PostAsync("/play", Serialize(playRequest)).Result;
        GameResult = Deserialize<GameResult>(Response);
    }
}