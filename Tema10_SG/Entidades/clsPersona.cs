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
        private string apellido;
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
            apellido = string.Empty;
            telefono = string.Empty;
            direccion = string.Empty;
            foto = string.Empty;
            fechaNacimiento = new DateTime();
            idDepartamento = 0;
        }
        public clsPersona(int id, string nombre, string apellido, 
            string telefono, string direccion, string foto, 
            DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
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


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }

        #endregion
    }
}
