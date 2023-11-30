using System;

namespace Entidades;
public class clsModelos
{

    #region atributos

    private int idModelo;
    private int idMarca;
    private string nombreModelo;
    private double precio;

    #endregion

    #region constructores
    public clsModelos()
	{
        this.idModelo = 0;
        this.idMarca = 0;
        this.nombreModelo = "";
        this.precio = 0;
    }

    public clsModelos(int idModelo, int idMarca, string nombreModelo, double precio)
    {
        this.idModelo = idModelo;
        this.idMarca = idMarca;  
        this.nombreModelo = nombreModelo;
        this.precio = precio; 
    }
    #endregion

    #region propiedades

    public int IdModelo
    {
        get { return this.idModelo; }
    }

    public int IdMarca
    {
        get { return this.idMarca;}
    }

    public string NombreModelo
    {
        get { return this.nombreModelo;}
        set { this.nombreModelo = value;}
    }

    public double Precio
    {
        get { return this.precio; }
        set { this.precio = value;}
    }

    #endregion
}
