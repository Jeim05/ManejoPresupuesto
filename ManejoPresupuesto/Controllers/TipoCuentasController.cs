using Microsoft.AspNetCore.Mvc;

namespace ManejoPresupuesto.Controllers
{
    public class TipoCuentasController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
