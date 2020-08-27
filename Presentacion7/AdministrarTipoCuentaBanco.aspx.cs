using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarTipoCuentaBanco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTiposCuentasBancos();
            formTipoCuentaBanco.Visible = false;
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
        }
    }

    /// <summary>
    /// Lista todas las tipos cuentas por bancos en el gridview de administración
    /// </summary>
    protected void ListarTiposCuentasBancos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarTipoCuentaBanco.ListarTiposCuentasBancos();
        grvAdminTipoCuentaBanco.DataSource = dt;
        grvAdminTipoCuentaBanco.DataBind();
    }

    protected void grvAdminTipoCuentaBanco_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminTipoCuentaBanco.PageIndex = e.NewPageIndex;
        ListarTiposCuentasBancos();
    }

    protected void grvAdminTipoCuentaBanco_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminTipoCuentaBanco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminTipoCuentaBanco.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long TipoCuentaBancoIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoCuentaBanco.ConsultarTipoCuentaBanco(TipoCuentaBancoIdentificador);
                grvConsultarTipoCuentaBanco.DataSource = dt;
                grvConsultarTipoCuentaBanco.DataBind();

                //Muestra y oculta los controles necesarios
                tablaTiposCuentasBancos.Visible = false;
                tablaTipoCuentaBanco.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long TipoCuentaBancoIdentificador = long.Parse(row.Cells[1].Text);
                txtTipoCuentaBancoIdentificador.Text = TipoCuentaBancoIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTipoCuentaBanco.ConsultarTipoCuentaBancoModificar(TipoCuentaBancoIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlBanco.SelectedValue = dt.Rows[0]["ban_Id"].ToString();
                    ddlTipoCuenta.SelectedValue = dt.Rows[0]["TipCue_Id"].ToString();
                }
                grvConsultarTipoCuentaBanco.DataSource = dt;
                grvConsultarTipoCuentaBanco.DataBind();

                //Muestra y oculta los controles necesarios
                formTipoCuentaBanco.Visible = true;
                tablaTiposCuentasBancos.Visible = false;
                tablaTipoCuentaBanco.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long TipoCuentaBancoIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarTipoCuentaBanco.EliminarTipoCuentaBanco(TipoCuentaBancoIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarTiposCuentasBancos();
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
        formTipoCuentaBanco.Visible = true;
        tablaTiposCuentasBancos.Visible = false;
        tablaTipoCuentaBanco.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long? bancoIdentificador = null;
            long? tipoCuentaIdentificador = null;
            if (ddlBanco.SelectedValue != "")
                bancoIdentificador = long.Parse(ddlBanco.SelectedValue);
            if (ddlTipoCuenta.SelectedValue != "")
                tipoCuentaIdentificador = long.Parse(ddlTipoCuenta.SelectedValue);

            AdministrarTipoCuentaBanco.InsertarTipoCuentaBanco(bancoIdentificador, tipoCuentaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoCuentaBanco.Visible = false;
            tablaTiposCuentasBancos.Visible = true;

            LimpiarFormulario();
            ListarTiposCuentasBancos();
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
            long? bancoIdentificador = null;
            long? tipoCuentaIdentificador = null;
            if (ddlBanco.SelectedValue != "")
                bancoIdentificador = long.Parse(ddlBanco.SelectedValue);
            if (ddlTipoCuenta.SelectedValue != "")
                tipoCuentaIdentificador = long.Parse(ddlTipoCuenta.SelectedValue);

            AdministrarTipoCuentaBanco.ModificarTipoCuentaBanco(long.Parse(txtTipoCuentaBancoIdentificador.Text), bancoIdentificador, tipoCuentaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTipoCuentaBanco.Visible = false;
            tablaTiposCuentasBancos.Visible = true;

            LimpiarFormulario();
            ListarTiposCuentasBancos();
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
        txtTipoCuentaBancoIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaTiposCuentasBancos.Visible = true;
        tablaTipoCuentaBanco.Visible = false;
        formTipoCuentaBanco.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarTiposCuentasBancos();
    }
}
