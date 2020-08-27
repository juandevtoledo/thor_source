using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Routing;

public partial class login : System.Web.UI.Page
{
    private static Dictionary<string, int> Intentos;

    protected void Page_Load(object sender, EventArgs e)
    {
        RouteTable.Routes.Clear();
        RegisterRoutes(RouteTable.Routes); 

        if (Session["Usuario"] != null)
        {
            //Response.Redirect("Presentacion/IndexPrincipal.aspx");
            Response.RedirectToRoute("thorlogueado");
        }
        //Session.Timeout = 30; //en esta linea se puede definir el tiempo de session en minutos

        
    }


    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        string clave = Control.Encriptar(txtContrasena.Text);
        DataTable dt = FrameworkEntidades.ConsultarUsuarioLogin(txtIngresar.Text, clave);

        if (dt.Rows.Count == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "EL USUARIO O LA CONTRASEÑA NO SON VALIDOS" + "');", true);
        }
        else
        {
            int estado = int.Parse(dt.Rows[0]["est_Id"].ToString());
            if (estado == 8)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "EL USUARIO SE ENCUENTRA SUSPENDIDO, COMUNIQUESE CON EL ADMINISTRADOR DEL SISTEMA" + "');", true);
            }
            else
            {
                Session["Cedula"] = dt.Rows[0]["con_Id"];
                Session["Usuario"] = dt.Rows[0]["con_usuario"];
                Session["Nombre1"] = dt.Rows[0]["Nombre1"];
                Session["Nombre2"] = dt.Rows[0]["Nombre2"];
                Session["Apellido1"] = dt.Rows[0]["Apellido1"];
                Session["Apellido2"] = dt.Rows[0]["Apellido2"];
                Session["Agencia"] = dt.Rows[0]["Agencia"];
                Session["age_Id"] = dt.Rows[0]["age_Id"];
                Session["Cargo"] = dt.Rows[0]["Cargo"];
                Session["car_Id"] = dt.Rows[0]["car_Id"];
                Session["Ciudad"] = dt.Rows[0]["ciu_Id"];
                Session["Departamento"] = dt.Rows[0]["dep_Id"];
                Session["Perfil"] = dt.Rows[0]["per_Id"];
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + dt.Rows[0]["con_usuario"] + "');", true);

				//Response.Redirect("~/Presentacion/IndexPrincipal.aspx");
                Response.RedirectToRoute("thorlogueado");
             


            }
        }
    }
    protected void RegisterRoutes(RouteCollection routes)
    {
        DataTable dtRutas = Control.ConsultarRutas();

        for (int i = 0; i < dtRutas.Rows.Count; i++)
        {
            if (dtRutas.Rows[i]["men_Alias"].ToString() != "")
            {
                routes.MapPageRoute(dtRutas.Rows[i]["men_Alias"].ToString(),
                dtRutas.Rows[i]["men_Ruta"].ToString(), dtRutas.Rows[i]["men_Directorio"].ToString());
            }
        }

        
    }
}