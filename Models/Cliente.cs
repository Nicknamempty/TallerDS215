using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDS215.Models
{
    public class Cliente
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

    }
}
