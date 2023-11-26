using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class clsPersona
    {
        #region atributos

        private int id;
        private string nombre;
        private string apellidos;
        private DateTime fechaNac;
        private string direccion;
        private long telefono;

        #endregion

        #region constructores

        public clsPersona() { }

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, long telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        #endregion

        #region propiedades

        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required (ErrorMessage ="Campo obligatorio")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength (40, ErrorMessage = "El apellido no pude tener más de 40 caracteres")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(200, ErrorMessage = "La dirección no debe tener más de 200 caracteres")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType (DataType.PhoneNumber, ErrorMessage = "El número de teléfono es un campo numérico")]

        //En esta validacion (^\W(34)\s\+?\d*$) indicamos que el numero de telefono tiene que tener este formaro +34 123456789
        [RegularExpression("^/W(34)/s/+?/d*$", ErrorMessage = "Número de teléfono no válido")]
        [MaxLength(13, ErrorMessage = "Este numero de teléfono es demasiado largo")]
        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        #endregion
    }

}