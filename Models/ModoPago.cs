using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDS215.Models
{
    public class ModoPago
    {[Key]
     public string ModoPagoID { get; set; }
    [Required]
    [StringLength(10,MinimumLength =4,ErrorMessage ="el nombre del modo de pago debe estar entre 10 y 4 digitos")]
    public string ModoPagoNom { get; set; }
    }
}
