using Microsoft.AspNetCore.Mvc;
using APP_PRUEBA.Models;
using APP_PRUEBA.Services;
namespace APP_PRUEBA.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly DogWcfClientService _dogService;
        public AccountController(
            AuthService authService,
            DogWcfClientService dogService)
        {
            _authService = authService;
            _dogService = dogService;
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

            bool valido =
                _authService.ValidarUsuario(
                    model.Usuario,
                    model.Password);

            if (valido)
            {
                TempData["Usuario"] = model.Usuario;
                return RedirectToAction("Welcome");
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Welcome()
        {
            ViewBag.Usuario = TempData["Usuario"];

            var dogModel = await _dogService.ObtenerPerritoDelDia();

            ViewBag.ImagenPerrito = dogModel.ImagenUrl;
            ViewBag.MensajePerrito = dogModel.Mensaje;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

}
