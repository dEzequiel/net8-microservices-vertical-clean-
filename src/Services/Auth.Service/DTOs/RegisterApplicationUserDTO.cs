namespace Auth.Service.DTOs
{
    public class RegisterApplicationUserDTO
    {
        public string Email { get; private set; }

        public RegisterApplicationUserDTO(string email) =>
            Email = email;

    }

    public record RegisterApplicationUserResponse(bool Status, string? Message);
}


