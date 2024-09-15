namespace ChoiceSmash.Infrastructure.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : this(message, [])
    {
    }

    public ValidationException(string message, IEnumerable<string> errors) : base(message)
    {
        Errors = errors;
    }

    public ValidationException(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; private set; }
}

