using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta
    {
        public int IdTipoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] // Esto se utiliza para validar que el campo no este vacio
        [StringLength(maximumLength:50,MinimumLength =3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1}")]
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }

        public int Orden { get; set; }
    }
}