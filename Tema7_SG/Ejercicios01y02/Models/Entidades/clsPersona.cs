namespace Ejercicios01y02.Models.Entidades
{
    public class clsPersona
    {
        #region atributos
        private int id;
        private string nombre;
        private string apellidos;
        private int idDepartamento;

        #endregion

        #region constructores
        public clsPersona()
        {
            id = 0;
            nombre = "";
            apellidos = "";
            idDepartamento = 0;
        }

        //Constructor solo con nombre y apellido
        public clsPersona(String nombre, String apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        //Constructor con nombre, apellido e idDepartamento
        public clsPersona(int id, String nombre, String apellidos, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region propiedades

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
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string NombreCompleto
        {
            get { return nombre + " " + apellidos;}
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }

        #endregion
    }
}
