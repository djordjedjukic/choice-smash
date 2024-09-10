using Ardalis.SmartEnum;

namespace ChoiceSmash.Enums;

public sealed class Choice : SmartEnum<Choice>
{
    public static readonly Choice Rock = new Choice("rock", 1);
    public static readonly Choice Paper = new Choice("paper", 2);
    public static readonly Choice Scissors = new Choice("scissors", 3);
    public static readonly Choice Lizard = new Choice("lizard", 4);
    public static readonly Choice Spock = new Choice("spock", 5);

    public Choice(string name, int value) : base(name, value)
    {
    }
}