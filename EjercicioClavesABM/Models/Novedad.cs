using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EjercicioClavesABM.Models
{
    public class Novedad
    {
        [Key]
        public int NovedadId { get; set; }

        [Required(ErrorMessage = "* El campo {0} es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* Por favor, introduzca un {0} entre {2} y {1} caracteres de longitud")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Por favor ingrese un {0} compuesto solamente por letras y números.")]
        [Display(Name = "Titulo")]
        [Index("Novedad_Titulo_Index", IsUnique = true)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "* El campo {0} es obligatorio")]
        [StringLength(600, MinimumLength = 10, ErrorMessage = "* Por favor, introduzca una {0} de entre {2} y {1} caracteres de longitud")]
        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        [NotMapped]//para que no se guarde en db
        /*la propiedad Imagen es la ruta y ImagenFile es el archivo*/
        public HttpPostedFileBase ImagenFile { get; set; }

        
    }
}