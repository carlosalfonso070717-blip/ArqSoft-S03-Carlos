using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Catalogo.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ItemService _service;
        private readonly ReviewService _reviewService;

        // El servicio llega por inyección de dependencias
        public CatalogoController(ItemService service, ReviewService reviewService)
        {
            _service = service;
            _reviewService = reviewService;
        }

        // Lista con filtro opcional por género
        public IActionResult Index(string? genero)
        {
            var items = string.IsNullOrEmpty(genero)
                ? _service.ObtenerTodos()
                : _service.ObtenerPorGenero(genero);

            ViewBag.Generos = _service.ObtenerGeneros();
            ViewBag.GeneroActual = genero;

            return View(items);
        }

        // Detalle de un item
        public IActionResult Detalle(int id)
        {
            var item = _service.ObtenerPorId(id);
            if (item == null) 
                return NotFound();

            // Verificar si el usuario está logueado
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.IsLoggedIn = userId.HasValue;
            ViewBag.UserId = userId ?? 0;
            ViewBag.Username = HttpContext.Session.GetString("Username") ?? "";

            return View(item);
        }

        // Formulario — GET
        public IActionResult Agregar()
        {
            return View();
        }

        // Formulario — POST
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            _service.Agregar(item);
            return RedirectToAction("Index");
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction("Index");
        }

        // Agregar Review - GET
        [HttpGet]
        public IActionResult AgregarReview(int itemId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Debes iniciar sesión para dejar una reseña";
                return RedirectToAction("Login", "Account");
            }

            var item = _service.ObtenerPorId(itemId);
            if (item == null)
                return NotFound();

            var model = new ReviewViewModel
            {
                ItemId = itemId,
                ItemTitulo = item.Titulo
            };

            return View(model);
        }

        // Agregar Review - POST
        [HttpPost]
        public IActionResult AgregarReview(ReviewViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Debes iniciar sesión para dejar una reseña";
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                var item = _service.ObtenerPorId(model.ItemId);
                if (item != null)
                    model.ItemTitulo = item.Titulo;
                return View(model);
            }

            var success = _reviewService.AddReview(
                model.ItemId, 
                userId.Value, 
                model.Estrellas, 
                model.Comentario
            );

            if (success)
            {
                TempData["SuccessMessage"] = "¡Reseña agregada exitosamente!";
                return RedirectToAction("Detalle", new { id = model.ItemId });
            }

            ModelState.AddModelError("", "Error al agregar la reseña");
            return View(model);
        }
    }
}