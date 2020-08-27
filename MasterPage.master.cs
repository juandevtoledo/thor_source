using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Routing;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Code Snippet
        //Request.Url.Segments{Request.Url.Segments.Length-1};

         //Request.Url.Segments{Request.Url.Segments.Length-1};

        if (Session["Usuario"] == null)
        {
            Response.Redirect("/");
            //Response.RedirectTo"thor");
        }

        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());
        int bandera = 0;
        DataTable dtlistPermisos = new DataTable();
        dtlistPermisos = Control.ListarRestriccionesUsuario(perfil, cedula);
        Session["dtPermisos"] = dtlistPermisos;
        Menu mnuPpal = new Menu();
        if (!IsPostBack)
        {
            
            //Viviana
            //Session["Rol"].ToString();
            
            DataTable dtSubmenu = Control.ConsultarSubmenu(Session["Perfil"].ToString(), Session["Cedula"].ToString());
            Session["menuSistema"] = dtSubmenu;
            DataTable dtMenu = Control.ConsultarMenu();


            //Viviana
            //int valorMenu = 0; 
            //int general = 0;
            for (int i = 0; i < dtMenu.Rows.Count; i++)
            {
                //MenuItem mnuItem = new MenuItem(dtMenu.Rows[i]["men_Nombre"].ToString(), "itemN", "", dtMenu.Rows[i]["men_Enlace"].ToString());
                MenuItem mnuItem = new MenuItem(dtMenu.Rows[i]["men_Nombre"].ToString(), "itemN", "", "javascript:;");
                int cont = 0;


                for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                {
                    string titulo = dtSubmenu.Rows[j]["men_Dependencia"].ToString();
                    string subti = dtMenu.Rows[i]["men_Id"].ToString();
                    if (titulo == subti)
                    {
                        cont++;

                        //int  valorLlocal = 0;
                        mnuItem.ChildItems.Add(new MenuItem(dtSubmenu.Rows[j]["men_Nombre"].ToString(), "", "", dtSubmenu.Rows[j]["men_Ruta"].ToString()));
                        //mnuItem.ChildItems.Add(new MenuItem(dtSubmenu.Rows[j]["men_Nombre"].ToString(), "", "", dtSubmenu.Rows[j]["men_enlace"].ToString()));
                        //valorLlocal = j;

                        //valorMenu = valorLlocal;
                    }


                }

                if (cont > 0)
                {
                    Menu1.Items.Add(mnuItem);

                }

                bandera = 1;
            }

            mnuPpal.DataBind();

            nombreUsuario.Text = Session["usuario"].ToString();

            nombreUsuario.Text = Session["Nombre1"] + " " + Session["Nombre2"] + " " + Session["Apellido1"] + " " + Session["Apellido2"];
            agenciaUsuario.Text = Session["Agencia"].ToString();
            cargoUsuario.Text = Session["Cargo"].ToString();
            usuario.Text = Session["usuario"].ToString();
        } 
    }

    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
       

        string menu = Menu1.SelectedItem.Selected.ToString();
        switch (e.Item.Value)
        {
            case "Buscar Tercero":
                Session["flag"] = "2";


                break;

            case "Entrega Produccion":
                Session["flag"] = "1";
                break;
        }
    }


    // Cerrar sesión
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        string index = Menu1.SelectedValue;
        Session.Remove("Usuario");
        Session.Remove("Departamento");
        //Session.Remove("Perfil");
        Session.Remove("Cedula");
        Session.Remove("Rol");
        Session.Remove("Usuario");
        Session.Remove("Usuario");

        Response.Redirect("/");
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (Menu1.Items.ToString() != "")
        {
            
        }

    }
    protected void btnCambioClave_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("cambioClave");
    }
}