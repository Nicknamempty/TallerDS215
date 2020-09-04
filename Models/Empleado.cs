using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDS215.Models
{
    public class Empleado
    {
        [Key]
        public string DUI { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public double salario { get; set; }
        [Required]
        [ForeignKey("modoPagoID")]
        public int modPago { get; set; }
        [Required]
        [ForeignKey("AreaID")]
        public int Area { get; set; }
        [Required]
        [ForeignKey("rolID")]
        public int rol { get; set; }


    }
}
