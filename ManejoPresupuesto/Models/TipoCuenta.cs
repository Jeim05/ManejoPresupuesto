using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta
    {
        public int IdTipoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] // Esto se utiliza para validar que el campo no este vacio
        [StringLength(maximumLength:50,MinimumLength =3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1}")]
        [Display(Name = "Nombre del tipo de cuenta")]
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }

        public int Orden { get; set; }

        /* PRUEBAS DE OTRAS VALIDACIONES POR DEFECTO */
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electrónico valido")]
        public string Email { get; set; }

        [Range(minimum:18, maximum:130, ErrorMessage ="El valor de la {0} debe estar entre {1} y {2}")]
        public int Edad { get; set; }

        [Url(ErrorMessage = "El campo debe ser una url valida")]
        public string URL { get; set; }

        [CreditCard(ErrorMessage ="La tarjeta de crédito no es valida")]
        [Display(Name = "Tarjeta de crédito") ]
        public string TarjetaDeCredito { get; set; }
    }
}