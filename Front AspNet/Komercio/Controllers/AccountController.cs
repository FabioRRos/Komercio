using Komercio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace Komercio.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Se o usuário já tiver o clogado, joga ele pra home
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string senha)
        {
            var retorno = await _authService.AutenticarAsync(usuario, senha);

            if (retorno)
            {

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario),
            new Claim("Role", "Admin") 
        };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
            }

            return View();
        }


        // Metodo para sair
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}
