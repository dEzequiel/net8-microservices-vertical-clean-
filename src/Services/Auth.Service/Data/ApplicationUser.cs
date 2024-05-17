using Microsoft.AspNetCore.Identity;

namespace Auth.Service.Data
{
    public class ApplicationUser 
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

    }
}
