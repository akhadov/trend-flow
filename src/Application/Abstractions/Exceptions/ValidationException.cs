using SharedKernel;

namespace Application.Abstractions.Exceptions;
public sealed class ValidationException : Exception
{
    public ValidationException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
