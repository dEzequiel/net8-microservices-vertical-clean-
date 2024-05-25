using Microsoft.AspNetCore.Identity;

namespace Auth.Service.Data
{
    public class ApplicationUser 
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public ApplicationUser(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}
