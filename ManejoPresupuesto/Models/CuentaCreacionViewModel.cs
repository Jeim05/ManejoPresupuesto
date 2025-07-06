using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Models
{
    public class CuentaCreacionViewModel
    {
        //SelectListItem es una opción de asp net core que permite crear select de una manera muy sencilla
        public IEnumerable<SelectListItem> TiposCuentas { get; set; }
    }
}
