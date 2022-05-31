using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _07_MVC_IDENTITY.Controllers
{
    public class FLTController : Controller
    {
        [Authorize(Roles = "Guest,Employer")]
        public IActionResult Index() => View();

        [Authorize(Roles = "Employer")]
        public IActionResult FLT_LV() => View();

        [Authorize(Roles = "Employer")]
        public IActionResult FLT_LU() => View();

        [Authorize(Roles = "Employer")]
        public IActionResult FLT_LZ() => View();
    }
}
