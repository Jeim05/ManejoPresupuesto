using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta
    {
        public int IdTipoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] // Esto se utiliza para validar que el campo no este vacio
        [PrimeraLetraMayuscula]
        [Remote(action:"VerificarExisteTipoCuenta",controller:"TipoCuentas")]
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }

        public int Orden { get; set; }

       //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       // {
       //     if(Nombre !=null && Nombre.Length > 0)
       //     {
       //         var primeraLetra = Nombre[0].ToString();

       //         if (primeraLetra != primeraLetra.ToUpper())
       //         {
       //             yield return new ValidationResult("La primera letra debe ser mayuscula", new[] { nameof(Nombre) });
       //         }
       //     }
       // }
    }
}