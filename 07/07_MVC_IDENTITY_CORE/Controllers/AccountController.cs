using _07_MVC_IDENTITY.Models;
using _07_MVC_IDENTITY.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _07_MVC_IDENTITY.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Register() => View();
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = model.Email, UserName = model.Email, Year = model.Year };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) => View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //if (ModelState.IsValid) return View(model);
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (!result.Succeeded) ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            if (string.IsNullOrEmpty(model.ReturnUrl) && !Url.IsLocalUrl(model.ReturnUrl)) return RedirectToAction("Index", "Home");
            return Redirect(model.ReturnUrl); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginG()
        {
            var provider = "Google";
            var redirectUrl = Url.Action("GoogleResponse", "Account", new { ReturnUrl = "/" });
            var authProperties = new AuthenticationProperties 
                { RedirectUri = redirectUrl, Items = { new KeyValuePair<string, string>("LoginProvider", provider) } };
            return new ChallengeResult(provider, authProperties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            var request = HttpContext.Request;
            var result = await HttpContext.AuthenticateAsync("Identity.External");
            if (result.Succeeded != true) throw new Exception("External authentication error");
            
            var externalUser = result.Principal;
            if (externalUser == null) throw new Exception("External authentication error");
            
            var claims = externalUser.Claims.ToList();
            var userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null) throw new Exception("Unknown userid");

            var externalUserId = userIdClaim.Value;
            var externalProvider = userIdClaim.Issuer;
            var loginViewModel = new LoginViewModel 
                { ReturnUrl = "/", ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList() };
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded) return LocalRedirect("/");
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (email == null) return RedirectToAction("Privacy", "Home");
                
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new User     
                    { UserName = info.Principal.FindFirstValue(ClaimTypes.Email), Email = info.Principal.FindFirstValue(ClaimTypes.Email) };

                await _userManager.CreateAsync(user);
            }

            await _userManager.AddLoginAsync(user, info);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect("/");
        }
    }
}
