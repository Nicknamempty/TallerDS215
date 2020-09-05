using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDS215.Models
{
    public class Automovil
    {
        [Key]
        [StringLength(10,MinimumLength =6,ErrorMessage ="la placa debe medir al menos 6 digitos y menos de 10 ")]
        public string placa { get; set; }
        [Required (ErrorMessage ="Campo requerido")]
        public string marca { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string modelo { get; set; }
       // [StringLength(4,ErrorMessage ="El año debe ser de cuatro digitos",MinimumLength =4)]
        public int año { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Procedimiento { get; set; }
        public string comentario { get; set; }
        public Imagen img { get; set; }
        [ForeignKey("DUI")]
        [Display(Name ="Dueño")]
        public string cliente { get; set; }





    }
}
