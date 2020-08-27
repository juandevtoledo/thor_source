using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pagadurias : System.Web.UI.Page
{

    string url, jScript;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
    
        if(!IsPostBack)
        {
            Session["idPaga"] = null;            
            CargarPagadurias(null, "", "");
        }
    
    }

    public void CargarPagadurias(int? idPaga, string numIdPaga, string nombrePaga)
    {

        try
        {
            DataTable dt = AdministrarPagadurias.ConsultarPagadurias(idPaga, numIdPaga, nombrePaga);
            grvAdminPagaduria.DataSource = dt;
            grvAdminPagaduria.DataBind();
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición Actual", "/gestion/pagadurias");
        }
    
    }


    protected void lnkBtnBuscar_Click(object sender, EventArgs e)
    {
        
        CargarPagadurias(null, txtIdentificadorFiltro.Text, txtNombreFiltro.Text);

    }


    protected void grvAdminPagaduria_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            grvAdminPagaduria.PageIndex = e.NewPageIndex;
            CargarPagadurias(null, txtIdentificadorFiltro.Text, txtNombreFiltro.Text);
        }
        catch(Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición actual", null);
        }

    }
    

    protected void grvAdminPagaduria_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            
            int index;
            GridViewRow row;

            if (e.CommandName == "Eliminar_Click")
            {
                index = int.Parse(e.CommandArgument.ToString());
                row = grvAdminPagaduria.Rows[(index)];

                string resDelPag = "";
                resDelPag = AdministrarPagadurias.EliminarPagaduria(Int32.Parse(row.Cells[1].Text));
                Response.RedirectToRoute("gestion/pagadurias");

            }
            else if (e.CommandName == "Consultar_Click")
            {

                index = int.Parse(e.CommandArgument.ToString());
                row = grvAdminPagaduria.Rows[(index)];

                Session["idPaga"] = row.Cells[1].Text;
                //Response.Redirect("ConsultarPagaduria.aspx", false);
                Response.RedirectToRoute("consultarPagaduria");

            }


        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un problema con su petición actual. Por favor intentelo Nuevamente","/gestion/pagadurias");
        }

    }


    protected void grvAdminPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {

        
        Session["idPaga"] = grvAdminPagaduria.SelectedValue;
        //Response.Redirect("DetallePagaduria.aspx",false);
        Response.RedirectToRoute("detallePagaduria");
        //Response.Write("valor: " + grvAdminPagaduria.SelectedValue);
    }



    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        Session["idPaga"] = null;        
       
        //Response.RedirectToRoute("adicionarPagaduria");
        Response.RedirectToRoute("adicionarPagaduria", new { tab = "tab-1" });
    }




    public void MensajeForm(string msg, string url)
    {
        if (url != null)
        {
            jScript = "alert('" + msg + "');location.href='" + url + "';";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
        else
        {
            jScript = "alert('" + msg + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }


    }
}