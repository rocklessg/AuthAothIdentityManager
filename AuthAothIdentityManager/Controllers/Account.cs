using AuthAothIdentityManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthAothIdentityManager.Controllers
{
    public class Account : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel registerViewModel = new();
            return View(registerViewModel);
        }
    }
}
