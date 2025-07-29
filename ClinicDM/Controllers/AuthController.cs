using ClinicDM.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDM.Controllers {
    public class AuthController : Controller {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Index() {
            return View();
        }

        public IActionResult Login(string? returnUrl) {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string? returnUrl, LoginVM model) {
            ViewData["ReturnUrl"] = returnUrl;

            if(!ModelState.IsValid) {
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(
                model.Email, 
                model.Password, 
                false, 
                false);

            if (result.Succeeded) {
                return Redirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
