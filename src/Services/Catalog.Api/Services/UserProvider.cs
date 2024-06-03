
using Crosscuting.Base.Exceptions.Auth;
using System.Security.Claims;

namespace Catalog.Api.Services
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid GetUserId()
        {
            var isUserAuthenticated = _context.HttpContext!.User.Identity?.IsAuthenticated;
            
            if(isUserAuthenticated is null || !isUserAuthenticated.Value) 
                throw new UserUnauthorizedAccessException("User Unauthorized.");

            var userIdClaim = _context.HttpContext!.User.Claims.First(i => i.Type == ClaimTypes.Sid);
            Guid userId;
            var canParse = Guid.TryParse(userIdClaim.Value, out userId);

            if (canParse)
                return userId;

            return Guid.Empty;
        }
    }
}
