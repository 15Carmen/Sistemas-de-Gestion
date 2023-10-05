using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld_WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombre = TextBox1.Text;
            if (String.IsNullOrEmpty(nombre))
            {
                lblError.Text = "Debes introducir un nombre de usuario";
            }
            else
            {
                lblError.Text = "";
                lblSaludo.Text = "Hola " + nombre;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}