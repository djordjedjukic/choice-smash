using Ardalis.SmartEnum;

namespace ChoiceSmash.Enums;

public sealed class Result : SmartEnum<Result, string>
{
    public static readonly Result Win = new Result("win", "win");
    public static readonly Result Lose = new Result("lose", "lose");
    public static readonly Result Tie = new Result("tie", "tie");

    public Result(string name, string value) : base(name, value)
    {
    }
}