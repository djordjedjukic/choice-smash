using System.Net;
using FluentAssertions;
using IntegrationTests.Infrastructure;

namespace IntegrationTests;

public class Scoreboard_HappyPath : IClassFixture<ScoreboardFixture>
{
    private readonly ScoreboardFixture _fixture;

    public Scoreboard_HappyPath(ScoreboardFixture fixture)
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
        var scoreboard = _fixture.Scoreboard;
        
        switch (gameResult.Computer)
        {
            case 1:
                scoreboard.PlayerWins.Should().Be(0);
                scoreboard.ComputerWins.Should().Be(0);
                scoreboard.Ties.Should().Be(1);
                break;
            case 3 or 4:
                scoreboard.PlayerWins.Should().Be(1);
                scoreboard.ComputerWins.Should().Be(0);
                scoreboard.Ties.Should().Be(0);
                break;
            case 2 or 5:
                scoreboard.PlayerWins.Should().Be(0);
                scoreboard.ComputerWins.Should().Be(1);
                scoreboard.Ties.Should().Be(0);
                break;
        }
    }
}