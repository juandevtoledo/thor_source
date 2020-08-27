using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarPoliza : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarPolizas();
            formPoliza.Visible = false;
            botonAtras.Visible = false;

            DataTable dtProductos = new DataTable();
            dtProductos = AdministrarProducto.ListarProductos();
            ddlProducto.DataTextField = "NOMBRE";
            ddlProducto.DataValueField = "ID";
            ddlProducto.DataSource = dtProductos;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtTomadores = new DataTable();
            dtTomadores = AdministrarTomador.ListarTomadores();
            ddlTomador.DataTextField = "NOMBRE";
            ddlTomador.DataValueField = "ID";
            ddlTomador.DataSource = dtTomadores;
            ddlTomador.DataBind();
            ddlTomador.Items.Insert(0, new ListItem("Seleccione", ""));
        }
    }

    /// <summary>
    /// Lista todas las polizas en el gridview de administración
    /// </summary>
    protected void ListarPolizas()
    {
        DataTable dt = new DataTable();
        dt = AdministrarPoliza.ListarPolizas();
        grvAdminPoliza.DataSource = dt;
        grvAdminPoliza.DataBind();
    }

    protected void grvAdminPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminPoliza.PageIndex = e.NewPageIndex;
        ListarPolizas();
    }

    protected void grvAdminPoliza_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminPoliza_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminPoliza.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long polizaIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPoliza.ConsultarPoliza(polizaIdentificador);
                grvConsultarPoliza.DataSource = dt;
                grvConsultarPoliza.DataBind();

                //Muestra y oculta los controles necesarios
                tablaPolizas.Visible = false;
                tablaPoliza.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long polizaIdentificador = long.Parse(row.Cells[1].Text);
                txtPolizaIdentificador.Text = polizaIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPoliza.ConsultarPolizaModificar(polizaIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtPolizaNumero.Text = dt.Rows[0]["pol_Numero"].ToString();
                    ddlProducto.SelectedValue = dt.Rows[0]["pro_Id"].ToString();
                    ddlTomador.SelectedValue = dt.Rows[0]["tom_Id"].ToString();
                    txtPolizaTipo.Text = dt.Rows[0]["pol_Tipo"].ToString();
                }
                grvConsultarPoliza.DataSource = dt;
                grvConsultarPoliza.DataBind();

                //Muestra y oculta los controles necesarios
                formPoliza.Visible = true;
                tablaPolizas.Visible = false;
                tablaPoliza.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long polizaIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarPoliza.EliminarPoliza(polizaIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarPolizas();
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
        formPoliza.Visible = true;
        tablaPolizas.Visible = false;
        tablaPoliza.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long polizaNumero;
            long? ProductoIdentificador = null;
            long? TomadorIdentificador = null;
            long? PolizaTipo = null;
            polizaNumero = long.Parse(txtPolizaNumero.Text);
            if (ddlProducto.SelectedValue != "")
                ProductoIdentificador = long.Parse(ddlProducto.SelectedValue);
            if (ddlTomador.SelectedValue != "")
                TomadorIdentificador = long.Parse(ddlTomador.SelectedValue);
            if (txtPolizaTipo.Text != "")
                PolizaTipo = long.Parse(txtPolizaTipo.Text);

            AdministrarPoliza.InsertarPoliza(polizaNumero, ProductoIdentificador, TomadorIdentificador, PolizaTipo);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPoliza.Visible = false;
            tablaPolizas.Visible = true;

            LimpiarFormulario();
            ListarPolizas();
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
            long polizaNumero;
            long? ProductoIdentificador = null;
            long? TomadorIdentificador = null;
            long? PolizaTipo = null;
            polizaNumero = long.Parse(txtPolizaNumero.Text);
            if (ddlProducto.SelectedValue != "")
                ProductoIdentificador = long.Parse(ddlProducto.SelectedValue);
            if (ddlTomador.SelectedValue != "")
                TomadorIdentificador = long.Parse(ddlTomador.SelectedValue);
            if (txtPolizaTipo.Text != "")
                PolizaTipo = long.Parse(txtPolizaTipo.Text);

            AdministrarPoliza.ModificarPoliza(long.Parse(txtPolizaIdentificador.Text), polizaNumero, ProductoIdentificador, TomadorIdentificador, PolizaTipo);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPoliza.Visible = false;
            tablaPolizas.Visible = true;

            LimpiarFormulario();
            ListarPolizas();
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
        txtPolizaNumero.Text = string.Empty;
        ddlProducto.SelectedValue = string.Empty;
        ddlTomador.SelectedValue = string.Empty;
        txtPolizaTipo.Text = string.Empty;
        txtPolizaNumero.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaPolizas.Visible = true;
        tablaPoliza.Visible = false;
        formPoliza.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarPolizas();
    }
}
