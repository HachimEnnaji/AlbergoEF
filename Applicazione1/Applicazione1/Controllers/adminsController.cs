using Applicazione1.Data;
using Applicazione1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Applicazione1.Controllers
{
    public class adminsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthenticationSchemeProvider _schemeProvider;


        public adminsController(ApplicationDbContext context, IAuthenticationSchemeProvider schemeProvider)
        {
            _db = context;
            _schemeProvider = schemeProvider;
        }

        // GET: admins
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(admin admin)
        {
            var user = _db.admins.SingleOrDefault(x => x.Username == admin.Username);

            if (user != null)
            {
                if (user.Username == admin.Username && user.Password == admin.Password)
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, admin.Username),
                            new Claim(ClaimTypes.Role, "admin")
                        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    TempData["Message"] = "Login effettuato con successo";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Username o password inseriti male.";

                }
            }
            else
            {
                TempData["Error"] = "Lo User non esiste.";

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["message"] = "Logout effettuato";
            return RedirectToAction("Index", "Home");
        }

    }


}

