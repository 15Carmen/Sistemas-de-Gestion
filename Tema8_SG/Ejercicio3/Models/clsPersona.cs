using System.ComponentModel.DataAnnotations;

namespace Ejercicio3.Models
{
    public class clsPersona
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private int edad;
        #endregion

        #region Constructores

        public clsPersona()
        {
            nombre = "Carmen";
            apellido = "Martin";
            edad = 20;
        }
        public clsPersona(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        #endregion

        #region Propiedades

        [Required (ErrorMessage = "Campo obligatorio")]
        [MaxLength (50, ErrorMessage = "El nombre no puede ser mayor que 50 caracteres") ]
        [MinLength (2, ErrorMessage = "El nombre debe tener como mínimo 2 caracteres")]
        public string Nombre
        {
            get { return nombre; }
            set{ nombre = value; }
        }


        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "El apellido no puede ser mayor que 50 caracteres")]
        [MinLength(2, ErrorMessage = "El apellido debe tener como mínimo 2 caracteres")]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0,120, ErrorMessage = "La edad de estar entre los 0 y los 120 años")]
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        #endregion
    }
}
