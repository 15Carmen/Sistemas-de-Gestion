using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersona
    {

        #region Atributos
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNacimiento;
        private int idDepartamento;
    
        #endregion

        #region Constructores

        public clsPersona()
        {
            id = 1;
            nombre = string.Empty;
            apellidos = string.Empty;
            telefono = string.Empty;
            direccion = string.Empty;
            foto = string.Empty;
            fechaNacimiento = new DateTime();
            idDepartamento = 0;
        }
        public clsPersona(int id, string nombre, string apellidos, 
            string telefono, string direccion, string foto, 
            DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            this.idDepartamento= idDepartamento;
           
        }

        #endregion

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }

        #endregion
    }
}
