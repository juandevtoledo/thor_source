using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarCuentaBancoTipoCuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarCuentasBancosTiposCuentas();
            formCuentaBancoTipoCuenta.Visible = false;
            botonAtras.Visible = false;

            DataTable dtBancos = new DataTable();
            dtBancos = AdministrarBanco.ListarBancos();
            ddlBanco.DataTextField = "NOMBRE";
            ddlBanco.DataValueField = "ID";
            ddlBanco.DataSource = dtBancos;
            ddlBanco.DataBind();
            ddlBanco.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtTiposCuentas = new DataTable();
            dtTiposCuentas = AdministrarTipoCuenta.ListarTiposCuentas();
            ddlTipoCuenta.DataTextField = "NOMBRE";
            ddlTipoCuenta.DataValueField = "ID";
            ddlTipoCuenta.DataSource = dtTiposCuentas;
            ddlTipoCuenta.DataBind();
            ddlTipoCuenta.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtCuentas = new DataTable();
            dtCuentas = AdministrarCuentaBancaria.ListarCuentasBancarias();
            ddlCuenta.DataTextField = "NOMBRE";
            ddlCuenta.DataValueField = "ID";
            ddlCuenta.DataSource = dtCuentas;
            ddlCuenta.DataBind();
            ddlCuenta.Items.Insert(0, new ListItem("Seleccione", ""));
        }
    }

    /// <summary>
    /// Lista todas las cuentas bancarias por bancos por tipos de cuentas en el gridview de administración
    /// </summary>
    protected void ListarCuentasBancosTiposCuentas()
    {
        DataTable dt = new DataTable();
        dt = AdministrarCuentaBancoTipoCuenta.ListarCuentasBancosTiposCuentas();
        grvAdminCuentaBancoTipoCuenta.DataSource = dt;
        grvAdminCuentaBancoTipoCuenta.DataBind();
    }

    protected void grvAdminCuentaBancoTipoCuenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminCuentaBancoTipoCuenta.PageIndex = e.NewPageIndex;
        ListarCuentasBancosTiposCuentas();
    }

    protected void grvAdminCuentaBancoTipoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminCuentaBancoTipoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminCuentaBancoTipoCuenta.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long cuentaBancoTipoIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarCuentaBancoTipoCuenta.ConsultarCuentaBancoTipoCuenta(cuentaBancoTipoIdentificador);
                grvConsultarCuentaBancoTipoCuenta.DataSource = dt;
                grvConsultarCuentaBancoTipoCuenta.DataBind();

                //Muestra y oculta los controles necesarios
                tablaCuentasBancosTiposCuentas.Visible = false;
                tablaCuentaBancoTipoCuenta.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long cuentaBancoTipoIdentificador = long.Parse(row.Cells[1].Text);
                txtCuentaBancoTipoIdentificador.Text = cuentaBancoTipoIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarCuentaBancoTipoCuenta.ConsultarCuentaBancoTipoCuentaModificar(cuentaBancoTipoIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlBanco.SelectedValue = dt.Rows[0]["ban_Id"].ToString();
                    ddlTipoCuenta.SelectedValue = dt.Rows[0]["tipCue_Id"].ToString();
                    ddlCuenta.SelectedValue = dt.Rows[0]["cueBan_Id"].ToString();
                }
                grvConsultarCuentaBancoTipoCuenta.DataSource = dt;
                grvConsultarCuentaBancoTipoCuenta.DataBind();

                //Muestra y oculta los controles necesarios
                formCuentaBancoTipoCuenta.Visible = true;
                tablaCuentasBancosTiposCuentas.Visible = false;
                tablaCuentaBancoTipoCuenta.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long cuentaBancoTipoIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarCuentaBancoTipoCuenta.EliminarCuentaBancoTipoCuenta(cuentaBancoTipoIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarCuentasBancosTiposCuentas();
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
        formCuentaBancoTipoCuenta.Visible = true;
        tablaCuentasBancosTiposCuentas.Visible = false;
        tablaCuentaBancoTipoCuenta.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long bancoIdentifcador;
            long tipoCuentaIdentificador;
            long cuentaBancariaIdentificador;
            bancoIdentifcador = long.Parse(ddlBanco.SelectedValue);
            tipoCuentaIdentificador = long.Parse(ddlTipoCuenta.SelectedValue);
            cuentaBancariaIdentificador = long.Parse(ddlCuenta.SelectedValue);

            AdministrarCuentaBancoTipoCuenta.InsertarCuentaBancoTipoCuenta(bancoIdentifcador, tipoCuentaIdentificador, cuentaBancariaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formCuentaBancoTipoCuenta.Visible = false;
            tablaCuentasBancosTiposCuentas.Visible = true;

            LimpiarFormulario();
            ListarCuentasBancosTiposCuentas();
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
            long bancoIdentifcador;
            long tipoCuentaIdentificador;
            long cuentaBancariaIdentificador;
            bancoIdentifcador = long.Parse(ddlBanco.SelectedValue);
            tipoCuentaIdentificador = long.Parse(ddlTipoCuenta.SelectedValue);
            cuentaBancariaIdentificador = long.Parse(ddlCuenta.SelectedValue);

            AdministrarCuentaBancoTipoCuenta.ModificarCuentaBancoTipoCuenta(long.Parse(txtCuentaBancoTipoIdentificador.Text), bancoIdentifcador, tipoCuentaIdentificador, cuentaBancariaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formCuentaBancoTipoCuenta.Visible = false;
            tablaCuentasBancosTiposCuentas.Visible = true;

            LimpiarFormulario();
            ListarCuentasBancosTiposCuentas();
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
        ddlBanco.SelectedValue = string.Empty;
        ddlTipoCuenta.SelectedValue = string.Empty;
        ddlCuenta.SelectedValue = string.Empty;
        txtCuentaBancoTipoIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaCuentasBancosTiposCuentas.Visible = true;
        tablaCuentaBancoTipoCuenta.Visible = false;
        formCuentaBancoTipoCuenta.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarCuentasBancosTiposCuentas();
    }
}
