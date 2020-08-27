using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Presentacion_AdicionarConveniosArchivosNovedades : System.Web.UI.Page
{
    //protected void Page_LoadComplete(object sender, EventArgs e)
    //{
    //    int perfil = int.Parse(Session["Perfil"].ToString());
    //    int cedula = int.Parse(Session["Cedula"].ToString());

    //    DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


    //    ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
    //    Funciones objFunciones = new Funciones();
    //    objFunciones.ocultarBotones(Master, dtlistPermisos);
    //}

    
    string url, jScript;
    DataTable dt;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        try
        {

            if (Session["idArchNov"] == null)
            {
                MensajeFormV2("No se ha podido identificar la Configuración de Archivo de Novedades a la que se le quiere asociar" +
                                " los convenios y productos. Por favor Intentelo Nuevamente", "gestion/pagadurias/detalle");
            }

            if (!IsPostBack)
            {
                CargarConvenios();

            }
        
        }
        catch(Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }



    public void CargarConvenios()
    {

        try
        {

            if (Session["idPaga"] != null)
            {

                dt = AdministrarPagadurias.ConsultarConvenios(null, null, null, Convert.ToInt32(Session["idPaga"].ToString()));
                ddlConvenios.DataTextField = "con_Nombre";
                ddlConvenios.DataValueField = "con_Id";
                ddlConvenios.DataSource = dt;
                ddlConvenios.DataBind();
                ddlConvenios.Items.Insert(0, new ListItem("Seleccione un Convenio", "0"));
            }
            else
                MensajeFormV2("No se ha podido identificar la pagaduria Por favor Intentelo Nuevamente", "DetallePagaduria");

        
        }
        catch(Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }


    protected void ddlConvenios_SelectedIndexChanged(object sender, EventArgs e)
    {

        CargarProductosConvenios(Convert.ToInt32(ddlConvenios.SelectedValue));

    }

    public void CargarProductosConvenios(int idConv)
    {

        try
        {

            dt = AdministrarPagadurias.ConsultarProductosConfigArchivosNovedades(null, null, null, idConv,
                                                                Convert.ToInt32(Session["idArchNov"].ToString()));
            grvProductosConvenios.DataSource = dt;
            grvProductosConvenios.DataBind();
        
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }


    public bool DeterminarSeleccion(object var)
    {
        try
        {

            string sel = var.ToString();

            if (sel.Equals("True"))
                return true;
            else
                return false;

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

        return false;
    }


    protected void GuardarProductosConvenios_Click(object sender, EventArgs e)
    {

        try
        {

            CheckBox chk = new CheckBox();
            Label lbl = new Label();
            bool okTmp = true;
            int resTrans;


            if (Session["idArchNov"] != null)
            {

                int idArchNov = Int32.Parse(Session["idArchNov"].ToString());
                resTrans = AdministrarPagadurias.EliminarProductosConfigArchivosNovedades(Convert.ToInt32(ddlConvenios.SelectedValue),
                                                                                            idArchNov);
                //lblMsj.Text += chkLocalidadesPagaduria.Items[i].Value + " - " + chkLocalidadesPagaduria.Items[i].Text + ";";

                if (resTrans > 0)
                {

                    resTrans = 0;

                    foreach (GridViewRow gvr in grvProductosConvenios.Rows)
                    {

                        chk = (CheckBox)gvr.FindControl("chkEstSol");

                        if (chk.Checked)
                        {

                            lbl = (Label)gvr.FindControl("lblIdProd");

                            resTrans = AdministrarPagadurias.RegistrarProductosConfigArchivosNovedades(Session["idArchNov"].ToString(),
                                ddlConvenios.SelectedValue, lbl.Text);

                            if (resTrans <= 0)
                                okTmp = false;

                        }


                    }


                    if (okTmp)
                    {
                        MensajeForm("Todos los productos del convenio se han almacenado correctamente", null);
                        CargarProductosConvenios(Convert.ToInt32(ddlConvenios.SelectedValue));
                    }
                    else
                    {
                        MensajeForm("Solo se han agregado parcialmente los productos. Favor revise e intentelo nuevamente", null);
                        CargarProductosConvenios(Convert.ToInt32(ddlConvenios.SelectedValue));
                    }

                }
                else
                    MensajeForm("No ha sido posible limpiar los productos. Por favor intentelo nuevamente", null);


            }
            else
                MensajeFormV2("No ha sido posible Identificar el Convenio. Por favor intentelo nuevamente", "gestion/pagadurias/detalle");


        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }


    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        jScript = "VerConfigArchivosNovedades();";
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



    public void MensajeFormV2(string msg, string tipo)
    {

        switch (tipo)
        {

            case "DetallePagaduria":
                jScript = "alert('" + msg + "'); VerDetallePagaduria();";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
                break;
            case "Pagadurias":
                jScript = "alert('" + msg + "'); VerPagadurias();";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
                break;
            default:
                jScript = "alert('" + msg + "'); VerConfigArchivosNovedades();";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
                break;
        }

    }


}