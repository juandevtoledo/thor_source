using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;

public partial class Presentacion_InformeProduccionAsesores : System.Web.UI.Page
{

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            DataTable dtAgencias = DAOCierreSistema.spListarAgencias();
            ddlAgencia.DataSource = dtAgencias;
            ddlAgencia.DataTextField = "age_Nombre";
            ddlAgencia.DataValueField = "age_Id";
            ddlAgencia.DataBind();
            ddlAgencia.Items.Insert(0, new ListItem("Seleccione", ""));
            string agencia = ddlAgencia.SelectedValue;
        }
        
    }

    protected void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string agencia = ddlAgencia.SelectedValue;
        DataTable dtLocalidad = InformeProduccion.ConsultarLocalidadPorAgencia(ddlAgencia.SelectedValue);
        ddlLocalidad.DataTextField = "dep_nombre";
        ddlLocalidad.DataValueField = "dep_Id";
        ddlLocalidad.DataSource = dtLocalidad;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));
    }


    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        if (txtFechaProduccion.Text != "" && ddlAgencia.Text != "" && ddlLocalidad.Text != "")
        {
            DateTime fecha = DateTime.Parse(txtFechaProduccion.Text);
            if (chkPorAsesor.Checked == true)
            {
                DataTable dtInforme = InformeProduccionAsesor.ConsultarInformeProduccionAsesor(fecha, int.Parse(ddlLocalidad.SelectedValue.ToString()));
                Funciones.generarExcel(Page, dtInforme, "Informe de produccion por asesor");
              
            }
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect(url: "/Presentacion/InformeProduccionAsesores.aspx");
        Response.RedirectToRoute("informeProduccionAsesores");
    }
}