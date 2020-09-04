using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDS215.Models
{
    public class Area
    {
        [Key]
        public int AreaID { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "el nombre del area debe estar entre 20 y 3 digitos")]
        public string  AreaNombre {get;set;}
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }



    }
}
