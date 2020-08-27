using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarParentescoProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarParentescosProductos();
            formParentescoProducto.Visible = false;
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
    /// Lista todos los parentescos por productos en el gridview de administración
    /// </summary>
    protected void ListarParentescosProductos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarParentescoProducto.ListarParentescosProductos();
        grvAdminParentescoProducto.DataSource = dt;
        grvAdminParentescoProducto.DataBind();
    }

    protected void grvAdminParentescoProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminParentescoProducto.PageIndex = e.NewPageIndex;
        ListarParentescosProductos();
    }

    protected void grvAdminParentescoProducto_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminParentescoProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminParentescoProducto.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarParentescoProducto.ConsultarParentescoProducto(parentescoProductoIdentificador);
                grvConsultarParentescoProducto.DataSource = dt;
                grvConsultarParentescoProducto.DataBind();

                //Muestra y oculta los controles necesarios
                tablaParentescosProductos.Visible = false;
                tablaParentescoProducto.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);
                txtParentescoProductoIdentificador.Text = parentescoProductoIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarParentescoProducto.ConsultarParentescoProductoModificar(parentescoProductoIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlParentesco.SelectedValue = dt.Rows[0]["par_Id"].ToString();
                    ddlProducto.SelectedValue = dt.Rows[0]["pro_Id"].ToString();
                }
                grvConsultarParentescoProducto.DataSource = dt;
                grvConsultarParentescoProducto.DataBind();

                //Muestra y oculta los controles necesarios
                formParentescoProducto.Visible = true;
                tablaParentescosProductos.Visible = false;
                tablaParentescoProducto.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long parentescoProductoIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarParentescoProducto.EliminarParentescoProducto(parentescoProductoIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarParentescosProductos();
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
        formParentescoProducto.Visible = true;
        tablaParentescosProductos.Visible = false;
        tablaParentescoProducto.Visible = false;
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

            AdministrarParentescoProducto.InsertarParentescoProducto(parentescoIdentificador, productorIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formParentescoProducto.Visible = false;
            tablaParentescosProductos.Visible = true;

            LimpiarFormulario();
            ListarParentescosProductos();
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

            AdministrarParentescoProducto.ModificarParentescoProducto(long.Parse(txtParentescoProductoIdentificador.Text), parentescoIdentificador, productorIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formParentescoProducto.Visible = false;
            tablaParentescosProductos.Visible = true;

            LimpiarFormulario();
            ListarParentescosProductos();
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
        tablaParentescosProductos.Visible = true;
        tablaParentescoProducto.Visible = false;
        formParentescoProducto.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarParentescosProductos();
    }
}
