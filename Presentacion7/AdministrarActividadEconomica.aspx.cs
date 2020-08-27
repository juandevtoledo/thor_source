using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarActividadEconomica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        titleAdicionar.Visible = false;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;

        if (!IsPostBack)
        {

            ListarActividadesEcnomicas();
            formActividadEconomica.Visible = false;
            botonAtras.Visible = false;

            DataTable dt = new DataTable();   
        }  
               
    }

    protected void ListarActividadesEcnomicas()
    {
        DataTable dt = new DataTable();
        dt = AdministrarActividadEconomica.ListarActividadesEconomicas();

        grvAdminActividadEconomica.DataSource = dt;
        grvAdminActividadEconomica.DataBind();
    }

    protected void grvAdminActividadEconomica_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminActividadEconomica.PageIndex = e.NewPageIndex;
        ListarActividadesEcnomicas();
    }

    protected void grvAdminActividadEconomica_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((grvAdminActividadEconomica.Rows.Count < grvAdminActividadEconomica.PageSize) && (grvAdminActividadEconomica.Rows.Count + grvAdminActividadEconomica.PageSize * grvAdminActividadEconomica.PageIndex < ((DataTable)(grvAdminActividadEconomica.DataSource)).Rows.Count))

        //    e.Row.Cells[3].Visible = true;
    }


    protected void grvAdminActividadEconomica_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;

        if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminActividadEconomica.Rows[(index)];

        if (e.CommandName == "Consultar_Click")
        {
            //DB: Comentado
            int actividadEconomicaID = int.Parse(row.Cells[1].Text);


            DataTable dt = new DataTable();
            dt = AdministrarActividadEconomica.ConsultarActividadEconomica(actividadEconomicaID);

            titleConsultar.Visible = true;
            titleAcciones.Visible = false;
            tablaActividadesEconomicas.Visible = false;
            tablaActividadEconomica.Visible = true;
            botonAtras.Visible = true;
            grvConsultarActividadEconomica.DataSource = dt;
            grvConsultarActividadEconomica.DataBind();
        }

        if (e.CommandName == "Modificar_Click")
        {
             int actividadEconomicaID = int.Parse(row.Cells[1].Text);
             txtActividadEconomicaID.Text = actividadEconomicaID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarActividadEconomica.ConsultarActividadEconomicaModificar(actividadEconomicaID);
            if (dt.Rows.Count > 0)
            {

                txtActividadEconomicaNombre.Text = dt.Rows[0]["act_Nombre"].ToString();

            }

            titleModificar.Visible = true;
            titleAcciones.Visible = false;
            formActividadEconomica.Visible = true;
            tablaActividadesEconomicas.Visible = false;
            tablaActividadEconomica.Visible = false;
            botonAtras.Visible = true;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            grvAdminActividadEconomica.DataSource = dt;
            grvAdminActividadEconomica.DataBind();
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int actividadEconomicaID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarActividadEconomica.EliminarActividadEconomica(actividadEconomicaID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarActividadesEcnomicas();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
            }
            

        }


    }


    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        titleAdicionar.Visible = true;
        titleAcciones.Visible = false;
        formActividadEconomica.Visible = true;
        tablaActividadesEconomicas.Visible = false;
        tablaActividadEconomica.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {

            AdministrarActividadEconomica.InsertarActividadEconomica(txtActividadEconomicaNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formActividadEconomica.Visible = false;
            tablaActividadesEconomicas.Visible = true;
            LimpiarFormulario();
            ListarActividadesEcnomicas();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }
  
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            AdministrarActividadEconomica.ModificarActividadEconomica(Convert.ToInt32(txtActividadEconomicaID.Text), txtActividadEconomicaNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formActividadEconomica.Visible = false;
            tablaActividadesEconomicas.Visible = true;
            LimpiarFormulario();
            ListarActividadesEcnomicas();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }
      
    }

    private void LimpiarFormulario()
    {
        txtActividadEconomicaNombre.Text = string.Empty;
        txtActividadEconomicaID.Text = string.Empty;
 
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Presentacion7/AdministrarActividadEconomica.aspx");
    }
}