using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarBanco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ListarBancos();
            formBanco.Visible = false;
            botonAtras.Visible = false;

            DataTable dt = new DataTable();
        }

        titleAdicionar.Visible = false;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;

    }

    protected void ListarBancos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarBanco.ListarBancos();
        grvAdminBanco.DataSource = dt;
        grvAdminBanco.DataBind();
    }

    protected void grvAdminBanco_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminBanco.PageIndex = e.NewPageIndex;
        ListarBancos();
    }

    protected void grvAdminBanco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((grvAdminBanco.Rows.Count < grvAdminBanco.PageSize) && (grvAdminBanco.Rows.Count + grvAdminBanco.PageSize * grvAdminBanco.PageIndex < ((DataTable)(grvAdminBanco.DataSource)).Rows.Count))

        //    e.Row.Cells[2].Visible = true;
    }


    protected void grvAdminBanco_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;

        if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminBanco.Rows[(index)];
       

        if (e.CommandName == "Consultar_Click")
        {
            //DB: Comentado
            int bancoID = int.Parse(row.Cells[1].Text);


            DataTable dt = new DataTable();
            dt = AdministrarBanco.ConsultarBanco(bancoID);

            titleConsultar.Visible = true;
            titleAcciones.Visible = false;
            tablaBancos.Visible = false;
            tablaBanco.Visible = true;
            botonAtras.Visible = true;
            grvConsultarBanco.DataSource = dt;
            grvConsultarBanco.DataBind();
        }

        if (e.CommandName == "Modificar_Click")
        {
            int bancoID = int.Parse(row.Cells[1].Text);
            txtBancoID.Text = bancoID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarBanco.ConsultarBancoModificar(bancoID);
            if (dt.Rows.Count > 0)
            {
                txtBancoNombre.Text = dt.Rows[0]["ban_Nombre"].ToString();

            }

            titleModificar.Visible = true;
            titleAcciones.Visible = false;
            formBanco.Visible = true;
            tablaBancos.Visible = false;
            tablaBanco.Visible = false;
            botonAtras.Visible = true;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            grvConsultarBanco.DataSource = dt;
            grvConsultarBanco.DataBind();
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int bancoID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarBanco.EliminarBanco(bancoID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarBancos();
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
        formBanco.Visible = true;
        tablaBancos.Visible = false;
        tablaBanco.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {

            AdministrarBanco.InsertarBanco(txtBancoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formBanco.Visible = false;
            tablaBancos.Visible = true;
            LimpiarFormulario();
            ListarBancos();
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
            AdministrarBanco.ModificarBanco(Convert.ToInt32(txtBancoID.Text), txtBancoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formBanco.Visible = false;
            tablaBancos.Visible = true;
            LimpiarFormulario();
            ListarBancos();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }


    }

    private void LimpiarFormulario()
    {
        txtBancoNombre.Text = string.Empty;
        txtBancoID.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarBanco.aspx");
        Response.RedirectToRoute("gestionBancos");
    }
}