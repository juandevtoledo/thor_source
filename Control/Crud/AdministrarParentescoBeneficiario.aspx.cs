using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarParentescoBeneficiario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarParentescoBeneficiarios();
            formParentescoBeneficiario.Visible = false;
            botonAtras.Visible = false;

            DataTable dtParentescos = new DataTable();
            dtParentescos = AdministrarParentesco.ListarParentescos();
            ddlParentesco.DataTextField = "NOMBRE";
            ddlParentesco.DataValueField = "ID";
            ddlParentesco.DataSource = dtParentescos;
            ddlParentesco.DataBind();
            ddlParentesco.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtProductos = new DataTable();
            dtProductos = AdministrarProducto.ListarProductos();
            ddlProducto.DataTextField = "NOMBRE";
            ddlProducto.DataValueField = "ID";
            ddlProducto.DataSource = dtProductos;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
        }
    }

    /// <summary>
    /// Lista todos los parentescos beneficiarios en el gridview de administración
    /// </summary>
    protected void ListarParentescoBeneficiarios()
    {
        DataTable dt = new DataTable();
        dt = AdministrarParentescoBeneficiario.ListarParentescoBeneficiarios();
        grvAdminParentescoBeneficiario.DataSource = dt;
        grvAdminParentescoBeneficiario.DataBind();
    }

    protected void grvAdminParentescoBeneficiario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminParentescoBeneficiario.PageIndex = e.NewPageIndex;
        ListarParentescoBeneficiarios();
    }

    protected void grvAdminParentescoBeneficiario_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminParentescoBeneficiario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminParentescoBeneficiario.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarParentescoBeneficiario.ConsultarParentescoBeneficiario(parentescoProductoIdentificador);
                grvConsultarParentescoBeneficiario.DataSource = dt;
                grvConsultarParentescoBeneficiario.DataBind();

                //Muestra y oculta los controles necesarios
                tablaParentescoBeneficiarios.Visible = false;
                tablaParentescoBeneficiario.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);
                txtParentescoProductoIdentificador.Text = parentescoProductoIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarParentescoBeneficiario.ConsultarParentescoBeneficiarioModificar(parentescoProductoIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlParentesco.SelectedValue = dt.Rows[0]["par_Id"].ToString();
                    ddlProducto.SelectedValue = dt.Rows[0]["pro_Id"].ToString();
                }
                grvConsultarParentescoBeneficiario.DataSource = dt;
                grvConsultarParentescoBeneficiario.DataBind();

                //Muestra y oculta los controles necesarios
                formParentescoBeneficiario.Visible = true;
                tablaParentescoBeneficiarios.Visible = false;
                tablaParentescoBeneficiario.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarParentescoBeneficiario.EliminarParentescoBeneficiario(parentescoProductoIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarParentescoBeneficiarios();
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
        formParentescoBeneficiario.Visible = true;
        tablaParentescoBeneficiarios.Visible = false;
        tablaParentescoBeneficiario.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long parentescoIdentificador;
            long productorIdentificador;
            parentescoIdentificador = long.Parse(ddlParentesco.SelectedValue);
            productorIdentificador = long.Parse(ddlProducto.SelectedValue);

            AdministrarParentescoBeneficiario.InsertarParentescoBeneficiario(parentescoIdentificador, productorIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formParentescoBeneficiario.Visible = false;
            tablaParentescoBeneficiarios.Visible = true;

            LimpiarFormulario();
            ListarParentescoBeneficiarios();
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
            long parentescoIdentificador;
            long productorIdentificador;
            parentescoIdentificador = long.Parse(ddlParentesco.SelectedValue);
            productorIdentificador = long.Parse(ddlProducto.SelectedValue);

            AdministrarParentescoBeneficiario.ModificarParentescoBeneficiario(long.Parse(txtParentescoProductoIdentificador.Text), parentescoIdentificador, productorIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formParentescoBeneficiario.Visible = false;
            tablaParentescoBeneficiarios.Visible = true;

            LimpiarFormulario();
            ListarParentescoBeneficiarios();
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
        ddlParentesco.SelectedValue = string.Empty;
        ddlProducto.SelectedValue = string.Empty;
        txtParentescoProductoIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaParentescoBeneficiarios.Visible = true;
        tablaParentescoBeneficiario.Visible = false;
        formParentescoBeneficiario.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarParentescoBeneficiarios();
    }
}
