using System;

namespace Entidades;
public class clsMarcas
{
    #region atributos

    private int idMarca;
    private string nombreMarca;

    #endregion

    #region constructores
    public clsMarcas()
	{
		this.idMarca = 0;
        this.nombreMarca = "";
	}

    public clsMarcas(int idMarca, string nombreMarca)
    {
        this.idMarca = idMarca;
        this.nombreMarca = nombreMarca;
    }
    #endregion

    #region Propiedades

    public int IdMarca 
    {
        get { return this.idMarca; }
    }

    public string NombreMarca
    {
        get { return this.nombreMarca; }
        set { this.nombreMarca = value;}
    }

    #endregion
}
