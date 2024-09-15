using ChoiceSmash.Enums;
using ChoiceSmash.Services;

namespace UnitTests;

public class GameServiceTest
{
    public static IEnumerable<object[]> RockWinningCases =>
        new List<object[]>
        {
            new object[] { Choice.Rock, Choice.Scissors },
            new object[] { Choice.Rock, Choice.Lizard }
        };
    
    public static IEnumerable<object[]> ScissorsWinningCases =>
        new List<object[]>
        {
            new object[] { Choice.Scissors, Choice.Paper },
            new object[] { Choice.Scissors, Choice.Lizard }
        };
    
    public static IEnumerable<object[]> TieCases =>
        new List<object[]>
        {
            new object[] { Choice.Rock, Choice.Rock },
            new object[] { Choice.Paper, Choice.Paper },
            new object[] { Choice.Scissors, Choice.Scissors },
            new object[] { Choice.Lizard, Choice.Lizard },
            new object[] { Choice.Spock, Choice.Spock }
        };
    
    public static IEnumerable<object[]> PaperWinningCases =>
        new List<object[]>
        {
            new object[] { Choice.Paper, Choice.Rock },
            new object[] { Choice.Paper, Choice.Spock }
        };
    
    public static IEnumerable<object[]> LizardWinningCases =>
        new List<object[]>
        {
            new object[] { Choice.Lizard, Choice.Paper },
            new object[] { Choice.Lizard, Choice.Spock }
        };
    
    public static IEnumerable<object[]> SpockWinningCases =>
        new List<object[]>
        {
            new object[] { Choice.Spock, Choice.Rock },
            new object[] { Choice.Spock, Choice.Scissors }
        };

    [Theory]
    [MemberData(nameof(RockWinningCases))]
    public void Rock_ShouldWin_AgainstScissorsAndLizard(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Win, result);
    }

    [Theory]
    [MemberData(nameof(ScissorsWinningCases))]
    public void Scissors_ShouldWin_AgainstPaperAndLizard(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Win, result);
    }
    
    [Theory]
    [MemberData(nameof(TieCases))]
    public void Tie_ShouldResult_WhenChoicesAreTheSame(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Tie, result);
    }

    [Theory]
    [MemberData(nameof(PaperWinningCases))]
    public void Paper_ShouldWin_AgainstRockAndSpock(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Win, result);
    }
    
    [Theory]
    [MemberData(nameof(LizardWinningCases))]
    public void Lizard_ShouldWin_AgainstPaperAndSpock(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Win, result);
    }
    
    [Theory]
    [MemberData(nameof(SpockWinningCases))]
    public void Spock_ShouldWin_AgainstRockAndScissors(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Win, result);
    }
    
    public static IEnumerable<object[]> LosingCases =>
        new List<object[]>
        {
            new object[] { Choice.Scissors, Choice.Rock },
            new object[] { Choice.Paper, Choice.Scissors },
            new object[] { Choice.Lizard, Choice.Rock },
            new object[] { Choice.Spock, Choice.Lizard },
            new object[] { Choice.Rock, Choice.Paper },
            new object[] { Choice.Paper, Choice.Lizard },
        };

    [Theory]
    [MemberData(nameof(LosingCases))]
    public void ShouldLose_WhenOpponentWins(Choice playerChoice, Choice computerChoice)
    {
        string result = GameService.DetermineWinner(playerChoice, computerChoice);
        Assert.Equal(Result.Lose, result);
    }
}