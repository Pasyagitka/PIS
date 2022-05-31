using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _07_MVC_IDENTITY.Controllers
{
    public class FLEController : Controller
    {
        [Authorize(Roles = "Guest,Employer")]
        public IActionResult Index() => View();
    
        [Authorize(Roles = "Employer")]
        public IActionResult FLE_TM() => View();

        [Authorize(Roles = "Employer")]
        public IActionResult FLE_UR() => View();

        [Authorize(Roles = "Employer")]
        public IActionResult FLE_UP() => View();
    }
}
