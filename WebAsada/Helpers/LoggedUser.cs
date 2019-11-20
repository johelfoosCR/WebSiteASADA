using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WebAsada.Interfaces;

namespace WebAsada.Helpers
{
    public class LoggedUser: ILoggedUserReader
    {
        private readonly IHttpContextAccessor _httpContextAccessor; 

        public LoggedUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLoggedUser()
        { 
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
        }
    }
}
