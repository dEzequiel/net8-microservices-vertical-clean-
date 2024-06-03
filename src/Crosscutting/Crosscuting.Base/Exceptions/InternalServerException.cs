namespace Crosscuting.Base.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string? message) : base(message) { }
        public InternalServerException(string? message, string? details) : base(message) { }

        public string? Details { get; }
    }

}
