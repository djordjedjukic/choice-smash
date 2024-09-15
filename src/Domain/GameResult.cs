namespace ChoiceSmash.Domain;

// for simplicity, I will use this domain also for response in methods  
public record GameResult(int Player, int Computer, string Results);