using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentacion_ConsultarConfigArchivosNovedades : System.Web.UI.Page
{

    DataTable dt, dtTemp;
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
            MensajeForm("No se ha podido Identificar la pagaduria", "~/gestion/pagadurias");

    }
   

    public void CargarConfiguracionArchNov(int idArchNov)
    {

        try
        {

            if (Session["idPaga"] != null)
            {

                dt = AdministrarPagadurias.ConsultarArchivoNovedades(idArchNov, null, null, null, null);

                if (dt.Rows.Count > 0)
                {

                    lblAccion.Text = "Configuración Id. " + dt.Rows[0]["arcpag_Id"].ToString() + ": "
                        + dt.Rows[0]["arcpag_Nombre"].ToString()
                        + "<br> &nbsp;Pagaduria No " + Session["idPaga"].ToString() + ": " + dt.Rows[0]["paga_Nombre"].ToString()
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

                    
                    CargarConveniosArchivosNovedades(null, null, null, null, null, null, idArchNov);


                }

            }
            else
                MensajeForm("No se ha podido identificar la pagaduria sobre la cual se quiere consultar la configuración de Archivo de Novedades. " +
                                " Por favor intentelo nuevamente", "~/gestion/pagadurias/");


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

                resIdArchNov = AdministrarPagadurias.RegistrarArchivoNovedades(keyIdArchNov, Session["idPaga"].ToString(),
                                txtNombreArch.Text, ddlTipoArchivo.SelectedValue, ddlTipoReporte.SelectedValue,
                                ddlValor.SelectedValue, ddlRetiro.SelectedValue, 0);

                if (resIdArchNov >= 0)
                {
                    Session["idArchNov"] = resIdArchNov;
                    //MensajeForm("Configuración de Archivo de Novedades almacenada correctamente.", "ConfigurarArchivosNovedades.aspx");
                    MensajeForm("Configuración de Archivo de Novedades almacenada correctamente.", "/gestion/pagadurias/archivosnovedades/configurar");
                }
                else
                    MensajeForm("No se ha podido registrar la configuración de Archivo de Novedades. Por favor intentelo nuevamente", null);

            }
            else
                MensajeForm("No se ha podido identificar la pagaduria sobre la cual se quiere registrar la configuración de Archivo de Novedades. " +
                            " Por favor intentelo nuevamente", "~/gestion/pagadurias/");

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
                MensajeForm(resDelArch, "/gestion/pagadurias/archivosnovedades/configurar");
            }
            else
                MensajeForm("No se ha podido identificar la Configuración.", "gestion/pagadurias/archivosnovedades/configurar");
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

        
                                                                
    public void CargarConveniosArchivosNovedades(int? idProd, string nomProd, string nomComp, int? idConv, 
                                                string codConv, string nomConv, int? idArchNov)
    {

        try
        {

            pnlProductosConvenio.Visible = true;
            dt = AdministrarPagadurias.ConsultarConveniosArchivosNovedades(idProd, nomProd, nomComp, idConv, codConv,
                                                                            nomConv, idArchNov);
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





}