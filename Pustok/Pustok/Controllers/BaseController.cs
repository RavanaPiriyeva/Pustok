using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Pustok.Controllers
{
    public class BaseController : Controller
    {
        public string UserId => User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
