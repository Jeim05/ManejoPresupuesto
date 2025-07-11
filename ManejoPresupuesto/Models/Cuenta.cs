﻿using ManejoPresupuesto.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class Cuenta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Display(Name = "TipoCuenta")]
        public int TipoCuentaId { get; set; }

        public decimal Balance { get; set; }

        public string Descripcion { get; set; }
    }
}
