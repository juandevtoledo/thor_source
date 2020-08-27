using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarParentesco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ListarParentescos();
            formParentesco.Visible = false;
        }

        buscador.Visible = true;
        titleAcciones.Visible = true;
        titleModificar.Visible = false;
        titleAdicionar.Visible = false;
    }

    protected void ListarParentescos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarParentesco.ListarParentescos();
        grvAdminParentesco.DataSource = dt;
        grvAdminParentesco.DataBind();
    }

    protected void grvAdminParentesco_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminParentesco.PageIndex = e.NewPageIndex;
        ListarParentescos();
    }

    protected void grvAdminParentesco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((grvAdminParentesco.Rows.Count < grvAdminParentesco.PageSize) && (grvAdminParentesco.Rows.Count + grvAdminParentesco.PageSize * grvAdminParentesco.PageIndex < ((DataTable)(grvAdminParentesco.DataSource)).Rows.Count))

        //    e.Row.Cells[2].Visible = true;
    }


    protected void grvAdminParentesco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;

        if (e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminParentesco.Rows[(index)];


        if (e.CommandName == "Modificar_Click")
        {
            int parentescoID = int.Parse(row.Cells[1].Text);
            txtParentescoID.Text = parentescoID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarParentesco.ConsultarParentescoModificar(parentescoID);
            if (dt.Rows.Count > 0)
            {
                txtParentescoNombre.Text = dt.Rows[0]["par_Nombre"].ToString();

            }
            titleModificar.Visible = true;
            buscador.Visible = false;
            titleAcciones.Visible = false;
            titleAdicionar.Visible = false;
            formParentesco.Visible = true;
            tablaParentescos.Visible = false;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int parentescoID = int.Parse(row.Cells[1].Text);
            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarParentesco.EliminarParentesco(parentescoID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarParentescos();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
            }
        }


    }


    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        titleModificar.Visible = false;
        buscador.Visible = false;
        titleAcciones.Visible = false;
        titleAdicionar.Visible = true;

        formParentesco.Visible = true;
        tablaParentescos.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {

            AdministrarParentesco.InsertarParentesco(txtParentescoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formParentesco.Visible = false;
            tablaParentescos.Visible = true;
            LimpiarFormulario();
            ListarParentescos();
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
            AdministrarParentesco.ModificarParentesco(Convert.ToInt32(txtParentescoID.Text), txtParentescoNombre.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formParentesco.Visible = false;
            tablaParentescos.Visible = true;
            LimpiarFormulario();
            ListarParentescos();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }

    }

    private void LimpiarFormulario()
    {
        txtParentescoID.Text = string.Empty;
        txtParentescoNombre.Text = string.Empty;
    }


    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaParentescos.Visible = true;
        formParentesco.Visible = false;

        LimpiarFormulario();
        ListarParentescos();
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int id = 0;
        string nombre = "";

        if (txtBuscarId.Text != "")
        {
            id = int.Parse(txtBuscarId.Text);
        }

        if (txtBuscarNombre.Text != "")
        {
            nombre = txtBuscarNombre.Text;
        }

        DataTable dt = AdministrarParentesco.BuscarParentesco(id, nombre);
        grvAdminParentesco.DataSource = dt;
        grvAdminParentesco.DataBind();

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarParentesco.aspx");
        Response.RedirectToRoute("gestionParentescos");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

}