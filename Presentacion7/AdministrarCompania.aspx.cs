using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarCompania : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarCompanias();
            formCompania.Visible = false;
            botonAtras.Visible = false;
            DataTable dt = new DataTable();
        }
        titleAdicionar.Visible = false;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;
    }

    protected void ListarCompanias()
    {
        DataTable dt = new DataTable();
        dt = AdministrarCompania.ListarCompanias();
        grvAdminCompania.DataSource = dt;
        grvAdminCompania.DataBind();
    }

    protected void grvAdminCompania_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminCompania.PageIndex = e.NewPageIndex;
        ListarCompanias();
    }

    protected void grvAdminCompania_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvAdminCompania.Rows.Count < grvAdminCompania.PageSize) && (grvAdminCompania.Rows.Count + grvAdminCompania.PageSize * grvAdminCompania.PageIndex < ((DataTable)(grvAdminCompania.DataSource)).Rows.Count))

            e.Row.Cells[2].Visible = true;
    }


    protected void grvAdminCompania_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;
        

        if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminCompania.Rows[(index)];
      

        if (e.CommandName == "Consultar_Click")
        {
            //DB: Comentado
            int companiaID = int.Parse(row.Cells[1].Text);


            DataTable dt = new DataTable();
            dt = AdministrarCompania.ConsultarCompania(companiaID);

            titleConsultar.Visible = true;
            titleAcciones.Visible = false;
            tablaCompanias.Visible = false;
            tablaCompania.Visible = true;
            botonAtras.Visible = true;
            grvConsultarCompania.DataSource = dt;
            grvConsultarCompania.DataBind();
        }

        if (e.CommandName == "Modificar_Click")
        {
            int companiaID = int.Parse(row.Cells[1].Text);
            txtCompaniaID.Text = companiaID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarCompania.ConsultarCompaniaModificar(companiaID);
            if (dt.Rows.Count > 0)
            {
                txtCompaniaNombre.Text = dt.Rows[0]["com_Nombre"].ToString();

            }

            titleModificar.Visible = true;
            titleAcciones.Visible = false;
            formCompania.Visible = true;
            tablaCompanias.Visible = false;
            tablaCompania.Visible = false;
            botonAtras.Visible = true;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            grvConsultarCompania.DataSource = dt;
            grvConsultarCompania.DataBind();
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int companiaID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarCompania.EliminarCompania(companiaID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarCompanias();
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
        formCompania.Visible = true;
        tablaCompanias.Visible = false;
        tablaCompania.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try { 
        
            AdministrarCompania.InsertarCompania(txtCompaniaNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            titleAcciones.Visible = true;
            formCompania.Visible = false;
            tablaCompanias.Visible = true;
            LimpiarFormulario();
            ListarCompanias();
        }
        catch(Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }
  
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            AdministrarCompania.ModificarCompania(Convert.ToInt32(txtCompaniaID.Text), txtCompaniaNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            titleAcciones.Visible = true;
            formCompania.Visible = false;
            tablaCompanias.Visible = true;
            LimpiarFormulario();
            ListarCompanias();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }
        
    }

    private void LimpiarFormulario()
    { 
        txtCompaniaID.Text = string.Empty;
        txtCompaniaNombre.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Presentacion7/AdministrarCompania.aspx");
    }
}