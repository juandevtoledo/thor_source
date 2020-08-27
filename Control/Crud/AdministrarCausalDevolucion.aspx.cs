using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarCausalDevolucion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarCausalesDevoluciones();
            formCausalDevolucion.Visible = false;
            botonAtras.Visible = false;
            DataTable dtTiposDevoluciones = new DataTable();
            dtTiposDevoluciones = AdministrarTipoDevolucion.ListarTiposDevoluciones();
            ddlTipoDevolucion.DataTextField = "NOMBRE";
            ddlTipoDevolucion.DataValueField = "ID";
            ddlTipoDevolucion.DataSource = dtTiposDevoluciones;
            ddlTipoDevolucion.DataBind();
            ddlTipoDevolucion.Items.Insert(0, new ListItem("Seleccione", ""));
        }
        titleAdicionar.Visible = false;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;
    }

    /// <summary>
    /// Lista todas las causales de devolución en el gridview de administración
    /// </summary>
    protected void ListarCausalesDevoluciones()
    {
        DataTable dt = new DataTable();
        dt = AdministrarCausalDevolucion.ListarCausalesDevoluciones();
        grvAdminCausalDevolucion.DataSource = dt;
        grvAdminCausalDevolucion.DataBind();
    }

    protected void grvAdminCausalDevolucion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminCausalDevolucion.PageIndex = e.NewPageIndex;
        ListarCausalesDevoluciones();
    }

    protected void grvAdminCausalDevolucion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminCausalDevolucion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminCausalDevolucion.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long causalDevolucionIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarCausalDevolucion.ConsultarCausalDevolucion(causalDevolucionIdentificador);
                grvConsultarCausalDevolucion.DataSource = dt;
                grvConsultarCausalDevolucion.DataBind();

                //Muestra y oculta los controles necesarios
                titleConsultar.Visible = true;
                titleAcciones.Visible = false;
                tablaCausalesDevoluciones.Visible = false;
                tablaCausalDevolucion.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long causalDevolucionIdentificador = long.Parse(row.Cells[1].Text);
                txtCausalDevolucionIdentificador.Text = causalDevolucionIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarCausalDevolucion.ConsultarCausalDevolucionModificar(causalDevolucionIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtCausalDevolucionNombre.Text = dt.Rows[0]["caudev_Nombre"].ToString();
                    ddlTipoDevolucion.SelectedValue = dt.Rows[0]["tipdev_Id"].ToString();
                }
                grvConsultarCausalDevolucion.DataSource = dt;
                grvConsultarCausalDevolucion.DataBind();

                //Muestra y oculta los controles necesarios
                titleModificar.Visible = true;
                titleAcciones.Visible = false;
                formCausalDevolucion.Visible = true;
                tablaCausalesDevoluciones.Visible = false;
                tablaCausalDevolucion.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long causalDevolucionIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarCausalDevolucion.EliminarCausalDevolucion(causalDevolucionIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarCausalesDevoluciones();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        //Muestra y oculta los controles necesarios
        formCausalDevolucion.Visible = true;
        tablaCausalesDevoluciones.Visible = false;
        tablaCausalDevolucion.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string causalDevolucionNombre = null;
            long? tipoDevolucionIdentificador = null;
            if (txtCausalDevolucionNombre.Text != "")
                causalDevolucionNombre = txtCausalDevolucionNombre.Text;
            if (ddlTipoDevolucion.SelectedValue != "")
                tipoDevolucionIdentificador = long.Parse(ddlTipoDevolucion.SelectedValue);

            AdministrarCausalDevolucion.InsertarCausalDevolucion(causalDevolucionNombre, tipoDevolucionIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            titleAcciones.Visible = true;
            formCausalDevolucion.Visible = false;
            tablaCausalesDevoluciones.Visible = true;

            LimpiarFormulario();
            ListarCausalesDevoluciones();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            string causalDevolucionNombre = null;
            long? tipoDevolucionIdentificador = null;
            if (txtCausalDevolucionNombre.Text != "")
                causalDevolucionNombre = txtCausalDevolucionNombre.Text;
            if (ddlTipoDevolucion.SelectedValue != "")
                tipoDevolucionIdentificador = long.Parse(ddlTipoDevolucion.SelectedValue);

            AdministrarCausalDevolucion.ModificarCausalDevolucion(long.Parse(txtCausalDevolucionIdentificador.Text), causalDevolucionNombre, tipoDevolucionIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            titleAcciones.Visible = true;
            formCausalDevolucion.Visible = false;
            tablaCausalesDevoluciones.Visible = true;

            LimpiarFormulario();
            ListarCausalesDevoluciones();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    /// <summary>
    /// Limpia el formulario de adición/modificación
    /// </summary>
    private void LimpiarFormulario()
    {
        txtCausalDevolucionNombre.Text = string.Empty;
        ddlTipoDevolucion.SelectedValue = string.Empty;
        txtCausalDevolucionIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarCausalDevolucion.aspx");
        Response.RedirectToRoute("gestionCasualDevolucion");
    }
}
