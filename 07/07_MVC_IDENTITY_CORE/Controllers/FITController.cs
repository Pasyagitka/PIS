using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _07_MVC_IDENTITY.Controllers
{
    public class FITController : Controller
    {
        [Authorize(Roles = "Guest,Employer")]
        public IActionResult Index() => View();
        [Authorize(Roles = "Employer")]
        public IActionResult FIT_IS() => View();
        [Authorize(Roles = "Employer")]
        public IActionResult FIT_PI() => View();
        [Authorize(Roles = "Employer")]
        public IActionResult FIT_ID() => View();
    }
}
