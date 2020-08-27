using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Presentacion_AdicionarProductosConvenio : System.Web.UI.Page
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

            if (Session["idConvPaga"] == null)
            {
                MensajeFormV2("No se ha podido identificar el Convenio al cual se le quiere adjuntar los productos. " +
                                "Por favor Intentelo Nuevamente", "gestion/pagadurias/convenios/productos/adicionar");
            }

            if (!IsPostBack)
            {
                CargarCompañias();

            }


        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición",null);
        }

    }





    public void CargarCompañias()
    {
        try
        {

            dt = AdministrarPagadurias.ConsultarCompañias(null, null);
            ddlCompañias.DataTextField = "com_Nombre";
            ddlCompañias.DataValueField = "com_Id"; // Cargamos lo que vale por debajo
            ddlCompañias.DataSource = dt;
            ddlCompañias.DataBind();
            ddlCompañias.Items.Insert(0, new ListItem("Seleccione Compañia", "0"));
        
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición",null);
        }


    }


    protected void ddlCompañias_SelectedIndexChanged(object sender, EventArgs e)
    {

        CargarProductosCompañia(Convert.ToInt32(ddlCompañias.SelectedValue));

    }

    protected void grvProductosCompañia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvProductosCompañia.PageIndex = e.NewPageIndex;

        try
        {
            dt = AdministrarPagadurias.ConsultarProductosPorCompañia(null, null, null, int.Parse(ddlCompañias.SelectedValue.ToString()), null,
                            Convert.ToInt32(Session["idConvPaga"].ToString()));
            grvProductosCompañia.DataSource = dt;
            grvProductosCompañia.DataBind();

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }

    public void CargarProductosCompañia(int idComp)
    {

        try
        {
            dt = AdministrarPagadurias.ConsultarProductosPorCompañia(null, null, null, idComp, null,
                            Convert.ToInt32(Session["idConvPaga"].ToString()));
            grvProductosCompañia.DataSource = dt;
            grvProductosCompañia.DataBind();

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


    protected void GuardarProductosCompañia_Click(object sender, EventArgs e)
    {

        try
        {

            CheckBox chk = new CheckBox();
            Label lbl = new Label();
            bool okTmp = true;
            int resTrans;


            if (Session["idConvPaga"] != null)
            {

                int idConv = Int32.Parse(Session["idConvPaga"].ToString());
                resTrans = AdministrarPagadurias.EliminarProductosConvenio(idConv, Convert.ToInt32(ddlCompañias.SelectedValue));
                //lblMsj.Text += chkLocalidadesPagaduria.Items[i].Value + " - " + chkLocalidadesPagaduria.Items[i].Text + ";";

                if (resTrans > 0)
                {

                    resTrans = 0;

                    foreach (GridViewRow gvr in grvProductosCompañia.Rows)
                    {

                        chk = (CheckBox)gvr.FindControl("chkEstSol");

                        if (chk.Checked)
                        {

                            lbl = (Label)gvr.FindControl("lblIdProd");

                            resTrans = AdministrarPagadurias.RegistrarProductosConvenio(Session["idConvPaga"].ToString(),
                                ddlCompañias.SelectedValue, lbl.Text);

                            if (resTrans <= 0)
                                okTmp = false;

                        }


                    }


                    if (okTmp)
                    {
                        MensajeForm("Todos los productos del convenio se han almacenado correctamente", null);
                        CargarProductosCompañia(Convert.ToInt32(ddlCompañias.SelectedValue));
                    }
                    else
                        //MensajeForm("Solo se han agregado parcialmente los productos. Favor revise e intentelo nuevamente", "AdicionarProductosConvenio.aspx");
                        MensajeForm("Solo se han agregado parcialmente los productos. Favor revise e intentelo nuevamente", "~/gestion/pagadurias/convenios/productos/adicionar");


                }
                else
                    MensajeForm("No ha sido posible limpiar los productos. Por favor intentelo nuevamente", null);


            }
            else
                MensajeFormV2("No ha sido posible Identificar el Convenio. Por favor intentelo nuevamente", "DetallePagaduria");


        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }


    }


    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        jScript = "VerConvenio();";
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

        if (tipo.Equals("DetallePagaduria"))
        {
            jScript = "alert('" + msg + "'); VerDetallePagaduria();";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
        else
        {
            jScript = "alert('" + msg + "'); VerConvenio();";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }

    }



}