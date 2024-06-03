namespace Crosscuting.Base.Exceptions.Auth
{
    public class UserUnauthorizedAccessException : UnauthorizedException
    {

        public UserUnauthorizedAccessException(string message)
        : base(message)
        {
        }
    }

}
