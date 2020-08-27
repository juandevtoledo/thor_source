using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarTipoCuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTiposCuentas();
            formTipoCuenta.Visible = false;
            botonAtras.Visible = false;
        }
    }

    /// <summary>
    /// Lista todos los tipos de cuentas en el gridview de administración
    /// </summary>
    protected void ListarTiposCuentas()
    {
        DataTable dt = new DataTable();
        dt = AdministrarTipoCuenta.ListarTiposCuentas();
        grvAdminTipoCuenta.DataSource = dt;
        grvAdminTipoCuenta.DataBind();
    }

    protected void grvAdminTipoCuenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminTipoCuenta.PageIndex = e.NewPageIndex;
        ListarTiposCuentas();
    }

    protected void grvAdminTipoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminTipoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminTipoCuenta.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long tipoCuentaIdentificacion = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoCuenta.ConsultarTipoCuenta(tipoCuentaIdentificacion);
                grvConsultarTipoCuenta.DataSource = dt;
                grvConsultarTipoCuenta.DataBind();

                //Muestra y oculta los controles necesarios
                tablaTiposCuentas.Visible = false;
                tablaTipoCuenta.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long tipoCuentaIdentificacion = long.Parse(row.Cells[1].Text);
                txtTipoCuentaIdentificacion.Text = tipoCuentaIdentificacion.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoCuenta.ConsultarTipoCuentaModificar(tipoCuentaIdentificacion);
                if (dt.Rows.Count > 0)
                {
                    txtTipoCuentaNombre.Text = dt.Rows[0]["TipCue_Nombre"].ToString();
                }
                grvConsultarTipoCuenta.DataSource = dt;
                grvConsultarTipoCuenta.DataBind();

                //Muestra y oculta los controles necesarios
                formTipoCuenta.Visible = true;
                tablaTiposCuentas.Visible = false;
                tablaTipoCuenta.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long tipoCuentaIdentificacion = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarTipoCuenta.EliminarTipoCuenta(tipoCuentaIdentificacion);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarTiposCuentas();
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
        formTipoCuenta.Visible = true;
        tablaTiposCuentas.Visible = false;
        tablaTipoCuenta.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string tipoCuentaNombre = null;
            if (txtTipoCuentaNombre.Text != "")
                tipoCuentaNombre = txtTipoCuentaNombre.Text;

            AdministrarTipoCuenta.InsertarTipoCuenta(tipoCuentaNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoCuenta.Visible = false;
            tablaTiposCuentas.Visible = true;

            LimpiarFormulario();
            ListarTiposCuentas();
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
            string tipoCuentaNombre = null;
            if (txtTipoCuentaNombre.Text != "")
                tipoCuentaNombre = txtTipoCuentaNombre.Text;

            AdministrarTipoCuenta.ModificarTipoCuenta(long.Parse(txtTipoCuentaIdentificacion.Text), tipoCuentaNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoCuenta.Visible = false;
            tablaTiposCuentas.Visible = true;

            LimpiarFormulario();
            ListarTiposCuentas();
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
        txtTipoCuentaNombre.Text = string.Empty;
        txtTipoCuentaIdentificacion.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaTiposCuentas.Visible = true;
        tablaTipoCuenta.Visible = false;
        formTipoCuenta.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarTiposCuentas();
    }
}
