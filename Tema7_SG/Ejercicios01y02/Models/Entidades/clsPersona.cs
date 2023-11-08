namespace Ejercicios01y02.Models.Entidades
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private int idDepartamento;

        #endregion

        #region constructores
        public clsPersona()
        {
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
        public clsPersona(String nombre, String apellidos, int idDepartamento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region propiedades
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

        public int IdDepartamento
        {
            get { return idDepartamento; }
        }

        #endregion
    }
}
