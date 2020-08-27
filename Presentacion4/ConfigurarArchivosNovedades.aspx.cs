using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentacion_ConfigurarArchivosNovedades : System.Web.UI.Page
{
    string host;
    DataTable dt, dtTemp, dtCuentaBancaria;
    string url, jScript;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        try
        {
            if (!IsPostBack)
            {

                btnEliminar.Visible = false;
                //pnlProductosConvenio.Visible = false;

                cargarListas();

                if (Session["idArchNov"] != null)
                    CargarConfiguracionArchNov(Convert.ToInt32(Session["idArchNov"].ToString()));
                else
                {
                    lblAccion.Text = "Registrar Nuevo Convenio";
                    getPagaduria();
                }
            }
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

        Uri uri = HttpContext.Current.Request.Url;
       host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
        //host = uri.Host + ":" + uri.Port;
    }
    protected void cargarListas() {
        DataTable dtCompanias = new DataTable();
        dtCompanias = CuentasBancarias.ConsultarCompanias();

        ddlCompania.DataTextField = "com_Nombre";
        ddlCompania.DataValueField = "com_Id";
        ddlCompania.DataSource = dtCompanias;
        ddlCompania.DataBind();
        ddlCompania.Items.Insert(0, new ListItem("Seleccione compañia", ""));
    }

    public void getPagaduria()
    {

        if (Session["idPaga"] != null)
        {
            dt = AdministrarPagadurias.ConsultarPagadurias(Convert.ToInt32(Session["idPaga"].ToString()), null, null);

            if (dt.Rows.Count > 0)
                lblAccion.Text = "Registrar Nuevo Convenio <br> " +
                    "&nbsp; Pagaduria Id. " + dt.Rows[0]["paga_Id"].ToString() + ": " + dt.Rows[0]["paga_Nombre"].ToString()
                    + " [ " + dt.Rows[0]["paga_Identificacion"].ToString() + " ]";
        }
        else
        {
            MensajeForm("No se ha podido Identificar la pagaduria", "~/gestion/pagadurias");
        }
    }

    public void CargarConfiguracionArchNov(int idArchNov)
    {
        cargarListas();
        try
        {
            if (Session["idPaga"] != null)
            {
                dt = AdministrarPagadurias.ConsultarArchivoNovedades(idArchNov, null, null, null, null);
                int cuentaBancaria = int.Parse(dt.Rows[0]["cueBan_Id"].ToString());
                //dtCuentaBancaria = AdministrarCuentaBancaria.ConsultarCuentaBancaria(cuentaBancaria);

                if (dt.Rows.Count > 0)
                {
                    lblAccion.Text = "<strong>Configuración Id</strong>. " + dt.Rows[0]["arcpag_Id"].ToString() + ": "
                        + dt.Rows[0]["arcpag_Nombre"].ToString()
                        + "<br><strong>Pagaduria No </strong>" + Session["idPaga"].ToString() + ": " + dt.Rows[0]["paga_Nombre"].ToString()
                        + " [ " + dt.Rows[0]["paga_Identificacion"].ToString() + " ]";


                    txtNombreArch.Text = dt.Rows[0]["arcpag_Nombre"].ToString();

                    ddlTipoArchivo.ClearSelection();
                    ddlTipoArchivo.Items.FindByValue(dt.Rows[0]["arcpag_TipoArchivo"].ToString()).Selected = true;

                    ddlTipoReporte.ClearSelection();
                    ddlTipoReporte.Items.FindByValue(dt.Rows[0]["arcpag_TipoReporte"].ToString()).Selected = true;

                    ddlRetiro.ClearSelection();
                    ddlRetiro.Items.FindByValue(dt.Rows[0]["arcpag_Retiros"].ToString()).Selected = true;

                    ddlValor.ClearSelection();
                    ddlValor.Items.FindByValue(dt.Rows[0]["arcpag_Valor"].ToString()).Selected = true;
                    

                    btnEliminar.Visible = true;
                    CargarConveniosArchivosNovedades(null, null, null, null, null, null, idArchNov);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No se ha podido identificar la pagaduria sobre la cual se quiere consultar la configuración de Archivo de Novedades. Intentelo de nuevo.');window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-5')", true);
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }
    
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            int resIdArchNov = -1;
            string keyIdArchNov = null;

            if (Session["idArchNov"] != null)
            {
                keyIdArchNov = Session["idArchNov"].ToString();
            }
            if (Session["idPaga"] != null)
            {
                int cuentaBancaria = int.Parse(ddlCuentaBancaria.SelectedValue);

                resIdArchNov = Math.Abs(AdministrarPagadurias.RegistrarArchivoNovedades(keyIdArchNov, Session["idPaga"].ToString(),
                                txtNombreArch.Text, ddlTipoArchivo.SelectedValue, ddlTipoReporte.SelectedValue,
                                ddlValor.SelectedValue, ddlRetiro.SelectedValue, cuentaBancaria));
                if (resIdArchNov >= 0)
                {
                    Session["idArchNov"] = resIdArchNov;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Configuración de Archivo de Novedades almacenada correctamente.');window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-5')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No se ha podido identificar la pagaduria sobre la cual se quiere registrar la configuración de Archivo de Novedades. " +
                            " Por favor intentelo nuevamente.');window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-5')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No se ha podido identificar la pagaduria sobre la cual se quiere registrar la configuración de Archivo de Novedades. " +
                            " Por favor intentelo nuevamente.');window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-5')", true);
            }
                
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["idArchNov"] != null)
            {
                string resDelArch = "";
                resDelArch = AdministrarPagadurias.EliminarArchivoNovedades(Int32.Parse(Session["idArchNov"].ToString()));
                //MensajeForm(resDelArch, "DetallePagaduria.aspx#irConfigArchNov");
                MensajeForm(resDelArch, "/gestion/pagadurias/archivosnovedades/configurar");
            }
            else
                //MensajeForm("No se ha podido identificar la Configuración.", "DetallePagaduria.aspx#irConfigArchNov");
                MensajeForm("No se ha podido identificar la Configuración.", "/gestion/pagadurias/archivosnovedades/configurar");
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }
    
    protected void btnAddConveniosProductos_Click(object sender, EventArgs e)
    {
        MostrarModalConveniosProductos();
    }

    public void MostrarModalConveniosProductos()
    {
        jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
    } 
                                                                
    public void CargarConveniosArchivosNovedades(
        int? idProd, string nomProd, string nomComp, int? idConv, 
        string codConv, string nomConv, int? idArchNov
    )
    {
        try
        {
            //pnlProductosConvenio.Visible = true;
            dt = AdministrarPagadurias.ConsultarConveniosArchivosNovedades(
                idProd, nomProd, nomComp, idConv, codConv,
                nomConv, idArchNov
            );
            grvProductosConveniosArchNov.DataSource = dt;
            grvProductosConveniosArchNov.DataBind();
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }


    protected void lnkBtnBuscarConvArchNov_Click(object sender, EventArgs e)
    {
        if (Session["idArchNov"] != null)
        {
            BuscarConveniosArchivosNovedades();
        }
        else
        {
            MensajeForm("No se ha podido identificar la Configuración de Archivos de Novedades. Por favor intentelo nuevamente",
                "/gestion/pagadurias/archivosnovedades/configurar");
        }
    }


    protected void grvProductosConvenioArchNov_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["idArchNov"] != null)
            {
                grvProductosConveniosArchNov.PageIndex = e.NewPageIndex;
                BuscarConveniosArchivosNovedades();
            }
            else
                MensajeForm("No se ha podido identificar la Configuración de Archivos de Novedades. Por favor intentelo nuevamente",
                    "/gestion/pagadurias/archivosnovedades/configurar");
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }

    
    public void BuscarConveniosArchivosNovedades()
    {
        try
        {
            int? idProd = null;
            int? idConv = null;

            if (!String.IsNullOrEmpty(txtFiltroIdProd.Text))
                idProd = Convert.ToInt32(txtFiltroIdProd.Text);

            /*if (!String.IsNullOrEmpty(txtFiltroIdConv.Text))
                idConv = Convert.ToInt32(txtFiltroIdConv.Text);*/

            CargarConveniosArchivosNovedades(idProd, txtFiltroNombreProd.Text, txtFiltroNombreComp.Text,
                idConv, txtFiltroCodConv.Text, txtFiltroNomConv.Text, Convert.ToInt32(Session["idArchNov"].ToString()));
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }
    }
    
    public void MensajeForm(string msg, string url)
    {
        if (url != null)
        {
            jScript = "alert('" + msg + "');location.href='" + url + "';";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
        else
        {
            jScript = "alert('" + msg + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
    }

    // Desarrollador 1
    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["companiaId"] = ddlCompania.SelectedValue.ToString();

        int intCompania = (Session["companiaId"].ToString() == "") ? 0 : int.Parse(Session["companiaId"].ToString());

        DataTable dtBancos = new DataTable();
        dtBancos = CuentasBancarias.ConsultarBancosPorCompania(intCompania, 1);

        ddlBanco.DataTextField = "ban_Nombre";
        ddlBanco.DataValueField = "ban_Id";
        ddlBanco.DataSource = dtBancos;
        ddlBanco.DataBind();
        ddlBanco.Items.Insert(0, new ListItem("Seleccione banco", ""));
    }

    protected void ddlBanco_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["banId"] = ddlBanco.SelectedValue.ToString();

        int intBanco = (Session["banId"].ToString() == "") ? 0 : int.Parse(Session["banId"].ToString());
        int intCompania = (Session["companiaId"].ToString() == "") ? 0 : int.Parse(Session["companiaId"].ToString());

        DataTable dtCuentas = new DataTable();
        dtCuentas = CuentasBancarias.ConsultarCuentasPorBancoCompania(intBanco, intCompania, 1);

        ddlCuentaBancaria.DataTextField = "cuenta_bancaria";
        ddlCuentaBancaria.DataValueField = "cueBan_Id";
        ddlCuentaBancaria.DataSource = dtCuentas;
        ddlCuentaBancaria.DataBind();
        ddlCuentaBancaria.Items.Insert(0, new ListItem("Seleccione cuenta bancaria", ""));
    }

    protected void ddlCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}