using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _07_MVC_IDENTITY.Controllers
{
    public class BSTUController : Controller
    {
        [Authorize]
        public IActionResult Index() => View();

        [Authorize(Roles = "Administrator")]
        public IActionResult Config() => View();
    }
}
