using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarTipoDocumento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTiposDocumentos();
            formTipoDocumento.Visible = false;
            botonAtras.Visible = false;
        }
    }

    /// <summary>
    /// Lista todos los tipos de documentos en el gridview de administración
    /// </summary>
    protected void ListarTiposDocumentos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarTipoDocumento.ListarTiposDocumentos();
        grvAdminTipoDocumento.DataSource = dt;
        grvAdminTipoDocumento.DataBind();
    }

    protected void grvAdminTipoDocumento_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminTipoDocumento.PageIndex = e.NewPageIndex;
        ListarTiposDocumentos();
    }

    protected void grvAdminTipoDocumento_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminTipoDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminTipoDocumento.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long tipoDocumentoIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoDocumento.ConsultarTipoDocumento(tipoDocumentoIdentificador);
                grvConsultarTipoDocumento.DataSource = dt;
                grvConsultarTipoDocumento.DataBind();

                //Muestra y oculta los controles necesarios
                tablaTiposDocumentos.Visible = false;
                tablaTipoDocumento.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long tipoDocumentoIdentificador = long.Parse(row.Cells[1].Text);
                txtTipoDocumentoIdentificador.Text = tipoDocumentoIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoDocumento.ConsultarTipoDocumentoModificar(tipoDocumentoIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtTipoDocumentoNombre.Text = dt.Rows[0]["tipDoc_Nombre"].ToString();
                }
                grvConsultarTipoDocumento.DataSource = dt;
                grvConsultarTipoDocumento.DataBind();

                //Muestra y oculta los controles necesarios
                formTipoDocumento.Visible = true;
                tablaTiposDocumentos.Visible = false;
                tablaTipoDocumento.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long tipoDocumentoIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarTipoDocumento.EliminarTipoDocumento(tipoDocumentoIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarTiposDocumentos();
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
        formTipoDocumento.Visible = true;
        tablaTiposDocumentos.Visible = false;
        tablaTipoDocumento.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string tipoDocumentoNombre = null;
            if (txtTipoDocumentoNombre.Text != "")
                tipoDocumentoNombre = txtTipoDocumentoNombre.Text;

            AdministrarTipoDocumento.InsertarTipoDocumento(tipoDocumentoNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoDocumento.Visible = false;
            tablaTiposDocumentos.Visible = true;

            LimpiarFormulario();
            ListarTiposDocumentos();
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
            string tipoDocumentoNombre = null;
            if (txtTipoDocumentoNombre.Text != "")
                tipoDocumentoNombre = txtTipoDocumentoNombre.Text;

            AdministrarTipoDocumento.ModificarTipoDocumento(long.Parse(txtTipoDocumentoIdentificador.Text), tipoDocumentoNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoDocumento.Visible = false;
            tablaTiposDocumentos.Visible = true;

            LimpiarFormulario();
            ListarTiposDocumentos();
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
        txtTipoDocumentoNombre.Text = string.Empty;
        txtTipoDocumentoIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaTiposDocumentos.Visible = true;
        tablaTipoDocumento.Visible = false;
        formTipoDocumento.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarTiposDocumentos();
    }
}
