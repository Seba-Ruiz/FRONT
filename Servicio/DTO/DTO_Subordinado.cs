using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Servicio.DTO
{
    public class DTO_Subordinado
    {
        [Required(ErrorMessage ="Por favor ingrese un nombre valido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un apellido valido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un mail valido")]
        [Remote("ExisteMail", "Subordinado", HttpMethod = "POST")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string mail { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un dni valido")]
        [Remote("ExisteDni", "Subordinado",  HttpMethod = "POST")]
        [Range(10000000, 99999999, ErrorMessage = "El dni debe contener 8 digitos")]
        public int? dni { get; set; }
        public int servicio { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un telefono valido")]
        public string telefono { get; set; }
    }
}
