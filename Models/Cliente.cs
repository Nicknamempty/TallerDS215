using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TallerDS215.Models
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10,MinimumLength =10, ErrorMessage ="El DUI debe contener al menos 10 caracteres")]
        public string DUI { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(3, ErrorMessage = "Un nombre debe contener al menos 3 digitos")]
        
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(3, ErrorMessage = "Un apellido debe contener al menos 3 digitos")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string telefono { get; set; }
        
        public Imagen Img { get; set; }

    }
}
