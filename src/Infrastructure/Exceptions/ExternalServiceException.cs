namespace ChoiceSmash.Infrastructure.Exceptions;

public class ExternalServiceException : Exception
{
    public ExternalServiceException(string message) : this(message, [])
    {
    }

    public ExternalServiceException(string message, IEnumerable<AppError> errors) : base(message)
    {
        Errors = errors;
    }

    public ExternalServiceException(IEnumerable<AppError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<AppError> Errors { get; private set; }
}