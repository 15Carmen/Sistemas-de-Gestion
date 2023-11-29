using System.ComponentModel.DataAnnotations;

namespace Ejercicio3.Models.ViewModels
{
    public class PersonaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Introduzca el apellido")]
        public string Apellido {  get; set; }
        [Required(ErrorMessage = "Introduzca el telefono")]
        public string Telefono {  get; set; }
        [Required(ErrorMessage = "Introduzca la dirección")]
        public string Direccion {  get; set; }
        [Required(ErrorMessage = "Introduzca la url de una foto")]
        public string Foto { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Introduzca la fecha de nacimiento")]
        public DateTime FechaNacimiento {  get; set; }
        [Required(ErrorMessage = "Introduzca el id de un departamento")]
        public int IdDepartamento {  get; set; }

    }
}
