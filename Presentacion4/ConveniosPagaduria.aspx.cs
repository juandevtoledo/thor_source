using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Presentacion_ConveniosPagaduria : System.Web.UI.Page
{
    string host;
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

                btnEliminar.Visible = false;
                btnImprimirConvenio.Visible = false;
                btnImprimirCartaBienvenida.Visible = false;
                pnlArchivosSoporteConvenio.Visible = false;
                pnlLocalidadesConvenio.Visible = false;
                pnlProductosConvenio.Visible = false;

                if (Session["idConvPaga"] != null)
                    CargarConvenioPagaduria(Convert.ToInt32(Session["idConvPaga"].ToString()));
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
            //MensajeForm("No se ha podido Identificar la pagaduria", "Pagadurias.aspx");
            MensajeForm("No se ha podido Identificar la pagaduria", "~/gestion/pagadurias");
        }

    }
    

    public void CargarConvenioPagaduria(int idConv)
    {

        try
        {



            if (Session["idPaga"] != null)
            {

                dt = AdministrarPagadurias.ConsultarConvenios(idConv, null, null, null);

                if (dt.Rows.Count > 0)
                {

                    lblAccion.Text = "Convenio Id. " + dt.Rows[0]["con_Id"].ToString() + ": "
                        + dt.Rows[0]["con_Nombre"].ToString() + " [ " + dt.Rows[0]["con_Codigo"].ToString() + " ]"
                        + "<br> &nbsp;&nbsp; Pagaduria Id. " + Session["idPaga"].ToString() + ": " + dt.Rows[0]["paga_Nombre"].ToString()
                        + " [ " + dt.Rows[0]["paga_Identificacion"].ToString() + " ]";

                    txtConvCodigo.Text = dt.Rows[0]["con_Codigo"].ToString();
                    txtConvNombre.Text = dt.Rows[0]["con_Nombre"].ToString();
                    txtConvRespAprob.Text = dt.Rows[0]["con_ResponsableAprobacion"].ToString();


                    if (!String.IsNullOrEmpty(dt.Rows[0]["con_FechaAprobacion"].ToString()))
                    {
                        DateTime fechaCumpleRespPago = Convert.ToDateTime(dt.Rows[0]["con_FechaAprobacion"].ToString());
                        txtFecAprob.Text = fechaCumpleRespPago.ToString("yyyy-MM-dd");
                    }

                    ddlPeriodicidad.ClearSelection();
                    ddlPeriodicidad.Items.FindByValue(dt.Rows[0]["con_PeriodicidadPago"].ToString()).Selected = true;

                    ddlEstado.ClearSelection();
                    ddlEstado.Items.FindByValue(dt.Rows[0]["con_Estado"].ToString()).Selected = true;

                    txtObservaciones.Text = dt.Rows[0]["con_Observaciones"].ToString();


                    btnEliminar.Visible = true;
                    btnImprimirConvenio.Visible = true;
                    btnImprimirCartaBienvenida.Visible = true;
                    CargarLocalidadesPorConvenio(null, idConv);
                    CargarArchivosSoporteConvenio(null, null, idConv);
                    CargarProductosConvenio(null, null, null, null, null, idConv);


                }

            }
            else
                MensajeForm("No se ha podido identificar la pagaduria sobre la cual se quiere consultar el convenio. Por favor intentelo nuevamente",
                    "~/gestion/pagadurias");

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición",null);
        }




    }


    
    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        try
        {

            int resIdConv = -1;
            string keyIdConv = null;

            if (Session["idConvPaga"] != null)
            {
                keyIdConv = Session["idConvPaga"].ToString();
            }

            if (Session["idPaga"] != null)
            {

                resIdConv = AdministrarPagadurias.RegistrarConvenio(keyIdConv, Session["idPaga"].ToString(), txtConvCodigo.Text,
                    txtConvNombre.Text, txtConvRespAprob.Text, txtFecAprob.Text, ddlPeriodicidad.SelectedValue, txtObservaciones.Text,
                    ddlEstado.SelectedValue);


                if (resIdConv >= 0)
                {
                    Session["idConvPaga"] = resIdConv;
                    //MensajeForm("Convenio almacenado correctamente.", "~/gestion/pagadurias/convenios");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Convenio almacenado correctamente.');window.location.replace('" + host + "/gestion/pagadurias/convenios')", true);
                }
                else
                    MensajeForm("No se ha podido registrar el Convenio. Por favor intentelo nuevamente", null);

            }
            else
                MensajeForm("No se ha podido identificar la pagaduria sobre la cual se quiere registrar el convenio. Por favor intentelo nuevamente",
                    "~/gestion/pagadurias");


        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        try
        {

            if (Session["idConvPaga"] != null)
            {
                string resDelPag = "";
                resDelPag = AdministrarPagadurias.EliminarConvenios(Int32.Parse(Session["idConvPaga"].ToString()));
                //MensajeForm(resDelPag, "~/gestion/pagadurias/detalle#irConvenios");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Convenio eliminado correctamente.');window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-4')", true);
            }
            else
                MensajeForm("No se ha podido identificar la pagaduria", "/gestion/pagadurias/convenios");
        
        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición",null);
        }

    }



    public void CargarArchivosSoporteConvenio(int? idSopConv, string nomSopConv, int? idConv)
    {

        try
        {

            pnlArchivosSoporteConvenio.Visible = true;

            dtTemp = AdministrarPagadurias.ConsultarArchivosSoporteConvenio(idSopConv, nomSopConv, idConv);
            grvArchivosSoporte.DataSource = dtTemp;
            grvArchivosSoporte.DataBind();

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }

    protected void btnAddArchivos_Click(object sender, EventArgs e)
    {

        MostrarModalSoportes();

    }

    public void MostrarModalSoportes()
    {
        jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

    }


    protected void grvArchivosSoporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            if (Session["idConvPaga"].ToString() != null)
            {
                grvArchivosSoporte.PageIndex = e.NewPageIndex;
                CargarArchivosSoporteConvenio(null, null, Convert.ToInt32(Session["idConvPaga"].ToString()));
            }
            else
                MensajeForm("No se ha podido identificar el Convenio", "/gestion/pagadurias/convenios");

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }


    protected void grvArchivosSoporte_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            string rutaArchivo = Server.MapPath(grvArchivosSoporte.SelectedRow.Cells[2].Text);
            string msjDel = "";

            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
            else
            {
                //MensajeForm("El archivo no existe", "DetallePagaduria.aspx");
                msjDel = "Archivo no Encontrado.";
            }

            string resDel = AdministrarPagadurias.EliminarArchivoSoporteConvenio(Convert.ToInt32(grvArchivosSoporte.SelectedValue));
           // MensajeForm(msjDel + " " + resDel, "~/gestion/pagadurias/convenios#archSopConv");
            MensajeForm("Archivo eliminado", "/gestion/pagadurias/convenios");

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }


    }




    public void CargarLocalidadesPorConvenio(int? idDepto, int? idConv)
    {

        try
        {

            pnlLocalidadesConvenio.Visible = true;

            dtTemp = AdministrarPagadurias.mostrarDepartamento(null, null);
            chkLocalidadesConvenio.DataValueField = "dep_Id";
            chkLocalidadesConvenio.DataTextField = "dep_nombre";
            chkLocalidadesConvenio.DataSource = dtTemp;
            chkLocalidadesConvenio.DataBind();

            dtTemp = AdministrarPagadurias.consultarLocalidadesPorConvenio(idDepto, idConv);

            int i = 0;
            foreach (ListItem li in chkLocalidadesConvenio.Items)
            {

                foreach (DataRow drLoc in dtTemp.Rows)
                {

                    if (drLoc["dep_Id"].ToString().Equals(li.Value))
                        chkLocalidadesConvenio.Items[i].Selected = true;
                }

                i++;
            }

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }



    }


    protected void GuardarLocalidadesConvenio_Click(object sender, EventArgs e)
    {

        try
        {

            int resDel = -1, resAdd = 1;
            bool ok = true;


            if (Session["idConvPaga"] != null)
            {

                int idConv = Int32.Parse(Session["idConvPaga"].ToString());
                resDel = AdministrarPagadurias.EliminarLocalidadesPorConvenio(null, idConv, 0);
                //lblMsj.Text += chkLocalidadesPagaduria.Items[i].Value + " - " + chkLocalidadesPagaduria.Items[i].Text + ";";

                if (resDel > 0)
                {

                    for (int i = 0; i < chkLocalidadesConvenio.Items.Count; i++)
                    {

                        if (chkLocalidadesConvenio.Items[i].Selected)
                        {
                            resAdd = AdministrarPagadurias.RegistrarLocalidadesPorConvenio(chkLocalidadesConvenio.Items[i].Value,
                                                                                            idConv.ToString());

                            if (resAdd < 0)
                                ok = false;

                        }
                    }


                    if (ok)
                    {
                        MensajeForm("Todas las localidades se han agregado exitosamente", null);
                        CargarLocalidadesPorConvenio(null, idConv);
                    }
                    else
                        MensajeForm("Solo se han agregado parcialmente las localidades. Favor revise e intentelo nuevamente", "/gestion/pagadurias/convenios");


                }
                else
                    MensajeForm("Error al limpiar las localidades. Favor Intentelo Nuevamente ", null);
            }
            else
                MensajeForm("No se ha podido identificar el convenio al que se le quiere agregar las localidades ", "/gestion/pagadurias/convenios");

        
        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición",null);
        }

    }


    
    public void CargarProductosConvenio(int? idProd, string nomProd, int? estProd, int? idComp, string nomComp, int? idConv)
    {

        try
        {

            pnlProductosConvenio.Visible = true;
            dt = AdministrarPagadurias.ConsultarProductosPorConvenio(idProd, nomProd, estProd, idComp, nomComp, idConv);
            grvProductosConvenio.DataSource = dt;
            grvProductosConvenio.DataBind();

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }


    protected void lnkBtnBuscarProd_Click(object sender, EventArgs e)
    {

        try
        {

            if (Session["idConvPaga"] != null)
            {
                BuscarProductosConvenio();
            }
            else
            {
                MensajeForm("No se ha podido identificar el Convenio. Por favor intentelo nuevamente", "/gestion/pagadurias/convenios");
            }

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }


    protected void grvProductosConvenio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            if (Session["idConvPaga"].ToString() != null)
            {
                grvProductosConvenio.PageIndex = e.NewPageIndex;
                BuscarProductosConvenio();
            }
            else
                MensajeForm("No se ha podido identificar el Convenio", "/gestion/pagadurias/convenios");

        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }

    }

    
    public void BuscarProductosConvenio()
    {

        try
        {

            int? idProd = null;
            int? idComp = null;

            if (!String.IsNullOrEmpty(txtFiltroIdProd.Text))
                idProd = Convert.ToInt32(txtFiltroIdProd.Text);

            if (!String.IsNullOrEmpty(txtFiltroIdComp.Text))
                idComp = Convert.ToInt32(txtFiltroIdComp.Text);


            CargarProductosConvenio(idProd,
                                    txtFiltroNombreProd.Text, null,
                                    idComp, txtFiltroNombreComp.Text,
                                    Convert.ToInt32(Session["idConvPaga"].ToString()));
        
        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición",null);
        }


    }



    protected void btnAddProductos_Click(object sender, EventArgs e)
    {
        MostrarModalProductos();
    }


    public void MostrarModalProductos()
    {
        jScript = "OpenCenterWindowCallBackV2();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

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





    protected void btnImprimirConvenio_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ImpresionConvenio.aspx", false);
        Response.RedirectToRoute("impresionConvenio");
    }

    protected void btnImprimirCartaBienvenida_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ImpresionCartaBienvenida.aspx", false);
        Response.RedirectToRoute("impresionCartaBienvenida");
    }
}