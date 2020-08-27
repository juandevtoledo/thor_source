using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;


public partial class Cuenta_FrmCambioClave : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("/");
        }

        if (!IsPostBack)
        {
         
        }
    }

    protected void btnCambiarClave_Click(object sender, System.EventArgs e)
    {
        var usuario = Session["usuario"].ToString();
        var claveAnt = txtClaveAnterior.Text;
        var claveNue = txtClaveNueva.Text;
        var claveNueC = txtClaveNuevaConfirmacion.Text;

        string claveEncripAnt = Control.Encriptar(claveAnt);
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + claveEncripAnt + "');", true);

        int registros = Math.Abs(Control.VerificarClave(usuario, claveEncripAnt));
        if (registros != 0)
        {
            if (claveNue != "")
            {
                if (claveNue == claveNueC)
                {
                    string claveEncripNue = Control.Encriptar(claveNue);
                    int cambio = Control.CambiarClave(usuario, claveEncripNue);
                    txtClaveAnterior.Text = "";
                    txtClaveNueva.Text = "";
                    txtClaveNuevaConfirmacion.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Clave cambiada con éxito" + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Las claves no coinciden" + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "No se ha ingresado una nueva clave" + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Clave anterior no coincide" + "');", true);
        }
    }
}