using Catalogo.Presentation.Models;
using CatalogoApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userService.Login(model.Username, model.Password);
            if (user != null)
            {
                // Guardar usuario en sesión
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);

                TempData["SuccessMessage"] = $"¡Bienvenido {user.Username}!";
                return RedirectToAction("Index", "Catalogo");
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = _userService.Register(model.Username, model.Email, model.Password);
            if (success)
            {
                TempData["SuccessMessage"] = "Registro exitoso. Por favor inicia sesión.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "El usuario o email ya existe");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "Has cerrado sesión correctamente";
            return RedirectToAction("Index", "Catalogo");
        }
    }
}
