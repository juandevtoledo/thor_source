using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarAmparo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ListarAmparos();
            formAmparo.Visible = false;
            botonAtras.Visible = false;

        }
        titleAdicionar.Visible = false;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;



    }

    protected void ListarAmparos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarAmparo.ListarAmparos();
        grvAdminAmparo.DataSource = dt;
        grvAdminAmparo.DataBind();
    }

    protected void grvAdminAmparo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminAmparo.PageIndex = e.NewPageIndex;
        ListarAmparos();
    }

    protected void grvAdminAmparo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((grvAdminAmparo.Rows.Count < grvAdminAmparo.PageSize) && (grvAdminAmparo.Rows.Count + grvAdminAmparo.PageSize * grvAdminAmparo.PageIndex < ((DataTable)(grvAdminAmparo.DataSource)).Rows.Count))

        //    e.Row.Cells[2].Visible = true;
    }


    protected void grvAdminAmparo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;

        if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminAmparo.Rows[(index)];

      
        if (e.CommandName == "Consultar_Click")
        {
            //DB: Comentado
            int amparoID = int.Parse(row.Cells[1].Text);


            DataTable dt = new DataTable();
            dt = AdministrarAmparo.ConsultarAmparo(amparoID);

            titleConsultar.Visible = true;
            titleAcciones.Visible = false;
            tablaAmparos.Visible = false;
            tablaAmparo.Visible = true;
            botonAtras.Visible = true;
            grvConsultarAmparo.DataSource = dt;
            grvConsultarAmparo.DataBind();
        }

        if (e.CommandName == "Modificar_Click")
        {
            int amparoID = int.Parse(row.Cells[1].Text);
            txtAmparoID.Text = amparoID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarAmparo.ConsultarAmparoModificar(amparoID);
            if (dt.Rows.Count > 0)
            {
                txtAmparoNombre.Text = dt.Rows[0]["amp_Nombre"].ToString();

            }

            titleModificar.Visible = true;
            titleAcciones.Visible = false;
            formAmparo.Visible = true;
            tablaAmparos.Visible = false;
            tablaAmparo.Visible = false;
            botonAtras.Visible = true;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            grvConsultarAmparo.DataSource = dt;
            grvConsultarAmparo.DataBind();
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int amparoID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarAmparo.EliminarAmparo(amparoID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarAmparos();
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
        formAmparo.Visible = true;
        tablaAmparos.Visible = false;
        tablaAmparo.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {

            AdministrarAmparo.InsertarAmparo(txtAmparoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formAmparo.Visible = false;
            tablaAmparos.Visible = true;
            LimpiarFormulario();
            ListarAmparos();
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
            AdministrarAmparo.ModificarAmparo(Convert.ToInt32(txtAmparoID.Text), txtAmparoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formAmparo.Visible = false;
            tablaAmparos.Visible = true;
            LimpiarFormulario();
            ListarAmparos();
            titleAcciones.Visible = true;
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }

    }
    private void LimpiarFormulario() {
        txtAmparoNombre.Text = string.Empty;
        txtAmparoID.Text = string.Empty;

    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarAmparo.aspx");
        Response.RedirectToRoute("gestionAmparos");
    }
}