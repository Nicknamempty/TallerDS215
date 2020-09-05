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
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "El DUI debe contener al menos 10 caracteres")]
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
        [Required(ErrorMessage = "Campo requerido")]
        public double salario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [ForeignKey("modoPagoID")]
        [Display(Name ="Pago")]
        public int modPago { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [ForeignKey("AreaID")]
        [Display(Name ="Area")]
        public int Area { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [ForeignKey("rolID")]
        [Display(Name ="Rol")]
        public int rol { get; set; }

        public Imagen Img { get; set; }


    }
}
