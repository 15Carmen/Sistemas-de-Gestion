namespace Mandaloriano.Entidades
{
    public class clsMision
    {
        #region Atributos
        private int id;
        private string nombreMision;
        private string detalles;
        private int creditos;

        #endregion

        #region Constructores

        public clsMision() { }

        public clsMision(int id, string nombreMision, string detalles, int creditos)
        {
            this.id = id;
            this.nombreMision = nombreMision;
            this.detalles = detalles;
            this.creditos = creditos;
        }
        #endregion

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NombreMision
        {
            get { return nombreMision; }
            set { nombreMision = value; }
        }
        public string Detalles
        {

            get { return detalles; }
            set { detalles = value; }
        }
        public int Creditos
        {
            get { return creditos; }
            set { Creditos = value; }
        }

        #endregion
    }
}
