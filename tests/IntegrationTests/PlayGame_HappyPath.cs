using System.Net;
using FluentAssertions;
using IntegrationTests.Infrastructure;

namespace IntegrationTests;

public class PlayGame_HappyPath : IClassFixture<PlayGameFixture>
{
    private readonly PlayGameFixture _fixture;

    public PlayGame_HappyPath(PlayGameFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact(DisplayName = "1. Status 200 is returned")]
    public void StatusReturned()
    {
        _fixture.Response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact(DisplayName = "2. Result has expected content")]
    public void ExpctedContent()
    {
        var gameResult = _fixture.GameResult;
        
        gameResult.Should().NotBeNull();
        gameResult!.Player.Should().Be(1);

        switch (gameResult.Computer)
        {
            case 1:
                gameResult.Results.Should().Be("tie");
                break;
            case 3 or 4:
                gameResult.Results.Should().Be("win");
                break;
            case 2 or 5:
                gameResult.Results.Should().Be("lose");
                break;
        }
    }
}