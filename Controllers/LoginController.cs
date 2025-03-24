using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appuser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if (p.Password==p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appuser,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSigninViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Profile",new {area="Member"});
                }
                else
                {
                    return RedirectToAction("SignIn","Login");
                }
            }
            return View();
        }
    }
}
