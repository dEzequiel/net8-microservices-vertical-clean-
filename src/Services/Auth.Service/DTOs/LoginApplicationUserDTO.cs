namespace Auth.Service.DTOs
{
    public class LoginApplicationUserDTO
    {
        public string Email { get; private set; }

        public LoginApplicationUserDTO(string email) =>
            Email = email;
        
    }

    public record LoginApplicationUserResponse(bool Status, string Message);
}
