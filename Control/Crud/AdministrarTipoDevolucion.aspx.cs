using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarTipoDevolucion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTiposDevoluciones();
            formTipoDevolucion.Visible = false;
            botonAtras.Visible = false;
        }
    }

    /// <summary>
    /// Lista todos los tipos de devoluciones en el gridview de administración
    /// </summary>
    protected void ListarTiposDevoluciones()
    {
        DataTable dt = new DataTable();
        dt = AdministrarTipoDevolucion.ListarTiposDevoluciones();
        grvAdminTipoDevolucion.DataSource = dt;
        grvAdminTipoDevolucion.DataBind();
    }

    protected void grvAdminTipoDevolucion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminTipoDevolucion.PageIndex = e.NewPageIndex;
        ListarTiposDevoluciones();
    }

    protected void grvAdminTipoDevolucion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminTipoDevolucion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminTipoDevolucion.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long tipoDevolucionIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoDevolucion.ConsultarTipoDevolucion(tipoDevolucionIdentificador);
                grvConsultarTipoDevolucion.DataSource = dt;
                grvConsultarTipoDevolucion.DataBind();

                //Muestra y oculta los controles necesarios
                tablaTiposDevoluciones.Visible = false;
                tablaTipoDevolucion.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long tipoDevolucionIdentificador = long.Parse(row.Cells[1].Text);
                txtTipoDevolucionIdentificador.Text = tipoDevolucionIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoDevolucion.ConsultarTipoDevolucionModificar(tipoDevolucionIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtTipoDevolucionNombre.Text = dt.Rows[0]["Tipdev_Nombre"].ToString();
                    ddlTipoDevolucionRecuperable.SelectedValue = dt.Rows[0]["Tipdev_Recuperable"].ToString();
                }
                grvConsultarTipoDevolucion.DataSource = dt;
                grvConsultarTipoDevolucion.DataBind();

                //Muestra y oculta los controles necesarios
                formTipoDevolucion.Visible = true;
                tablaTiposDevoluciones.Visible = false;
                tablaTipoDevolucion.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long tipoDevolucionIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarTipoDevolucion.EliminarTipoDevolucion(tipoDevolucionIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarTiposDevoluciones();
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
        formTipoDevolucion.Visible = true;
        tablaTiposDevoluciones.Visible = false;
        tablaTipoDevolucion.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string tipoDevolucionNombre = null;
            int? tipoDevolucionRecuperable = null;
            if (txtTipoDevolucionNombre.Text != "")
                tipoDevolucionNombre = txtTipoDevolucionNombre.Text;
            if (ddlTipoDevolucionRecuperable.SelectedValue != "")
                tipoDevolucionRecuperable = int.Parse(ddlTipoDevolucionRecuperable.SelectedValue);

            AdministrarTipoDevolucion.InsertarTipoDevolucion(tipoDevolucionNombre, tipoDevolucionRecuperable);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoDevolucion.Visible = false;
            tablaTiposDevoluciones.Visible = true;

            LimpiarFormulario();
            ListarTiposDevoluciones();
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
            string tipoDevolucionNombre = null;
            int? tipoDevolucionRecuperable = null;
            if (txtTipoDevolucionNombre.Text != "")
                tipoDevolucionNombre = txtTipoDevolucionNombre.Text;
            if (ddlTipoDevolucionRecuperable.SelectedValue != "")
                tipoDevolucionRecuperable = int.Parse(ddlTipoDevolucionRecuperable.SelectedValue);

            AdministrarTipoDevolucion.ModificarTipoDevolucion(long.Parse(txtTipoDevolucionIdentificador.Text), tipoDevolucionNombre, tipoDevolucionRecuperable);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoDevolucion.Visible = false;
            tablaTiposDevoluciones.Visible = true;

            LimpiarFormulario();
            ListarTiposDevoluciones();
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
        txtTipoDevolucionNombre.Text = string.Empty;
        ddlTipoDevolucionRecuperable.SelectedIndex = 0;
        txtTipoDevolucionIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaTiposDevoluciones.Visible = true;
        tablaTipoDevolucion.Visible = false;
        formTipoDevolucion.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarTiposDevoluciones();
    }
}
