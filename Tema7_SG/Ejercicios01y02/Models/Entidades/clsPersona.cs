namespace Ejercicios01y02.Models.Entidades
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;

        #endregion

        #region constructore
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(String nombre, String apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
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

        #endregion
    }
}
