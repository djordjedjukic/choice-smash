namespace ChoiceSmash;

public static class Utils
{
    public static int NormalizeToRange1To5(int number)
    {
        if (number <= 5) return number;
        int numberBetween1And5 = ((number - 1) % 5) + 1;

        return numberBetween1And5;
    }
}