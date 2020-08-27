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

public partial class Presentacion_InformeProduccion : System.Web.UI.Page
{
    public DAOPagos objPagos = new DAOPagos();

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
            CargarListas();
        }
    }

    protected void CargarListas()
    {
        // Listar Agencias
        DataTable dtAgencias = DAOCierreSistema.spListarAgencias();
        ddlAgencia.DataSource = dtAgencias;
        ddlAgencia.DataTextField = "age_Nombre";
        ddlAgencia.DataValueField = "age_Id";
        ddlAgencia.DataBind();
        ddlAgencia.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar Compañias
        DataTable dtCompanias = objPagos.ConsultarCompaniasGenerales();
        ddlCompania.DataSource = dtCompanias;
        ddlCompania.DataTextField = "com_Nombre";
        ddlCompania.DataValueField = "com_Id";
        ddlCompania.DataBind();
        ddlCompania.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar meses
        DataTable dtMes = InformeProduccion.ConsultarAnio();
        ddlAnioProduccion.DataSource = dtMes;
        ddlAnioProduccion.DataTextField = "anio_Numero";
        ddlAnioProduccion.DataValueField = "anio_Numero";
        ddlAnioProduccion.DataBind();
        ddlAnioProduccion.Items.Insert(0, new ListItem("Seleccione", ""));


        // Listar Compañias
        DataTable dtEstadosNegocio = InformeProduccion.ConsularEstadoNegocio();
        ddlEstadoNegocio.DataSource = dtEstadosNegocio;
        ddlEstadoNegocio.DataTextField = "estNeg_Nombre";
        ddlEstadoNegocio.DataValueField = "estNeg_Id";
        ddlEstadoNegocio.DataBind();
        ddlEstadoNegocio.Items.Insert(0, new ListItem("Seleccione", ""));

        ddlMesProduccion.Enabled = false;


    }
    //protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dtProducto = DAOCierreSistema.ConsultarProductoPorCompania(ddlCompania.SelectedValue);
    //    ddlProducto.DataTextField = "pro_Nombre"; 
    //    ddlProducto.DataValueField = "pro_Id"; 
    //    ddlProducto.DataSource = dtProducto;
    //    ddlProducto.DataBind();
    //    ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
    //}

    protected void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtLocalidad = InformeProduccion.ConsultarLocalidadPorAgencia(ddlAgencia.SelectedValue);
        ddlLocalidad.DataTextField = "dep_nombre"; 
        ddlLocalidad.DataValueField = "dep_Id";
        ddlLocalidad.DataSource = dtLocalidad;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));
    }


    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtAsesor = InformeProduccion.ConsultarAsesorPorLocalidad(ddlLocalidad.SelectedValue);
        ddlAsesor.DataTextField = "ase_nombre"; 
        ddlAsesor.DataValueField = "ase_Id"; 
        ddlAsesor.DataSource = dtAsesor;
        ddlAsesor.DataBind();
        ddlAsesor.Items.Insert(0, new ListItem("Seleccione", ""));

        DataTable dtPagaduria = InformeProduccion.ConsultarPagaduriaPorLocalidad(ddlLocalidad.SelectedValue);
        ddlPagaduria.DataTextField = "paga_Nombre";
        ddlPagaduria.DataValueField = "paga_Id";
        ddlPagaduria.DataSource = dtPagaduria;
        ddlPagaduria.DataBind();
        ddlPagaduria.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    protected void ddlAnioProduccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtMes = InformeProduccion.ConsultarMes();
        ddlMesProduccion.DataSource = dtMes;
        ddlMesProduccion.DataTextField = "mes_nombre";
        ddlMesProduccion.DataValueField = "mes_Id";
        ddlMesProduccion.DataBind();
        ddlMesProduccion.Items.Insert(0, new ListItem("Seleccione", ""));

        ddlMesProduccion.Enabled = true;
    }

    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtConvenio = InformeProduccion.ConsultarConvenioPorPagaduria(ddlPagaduria.SelectedValue);
        ddlConvenio.DataTextField = "con_Nombre";
        ddlConvenio.DataValueField = "con_Id";
        ddlConvenio.DataSource = dtConvenio;
        ddlConvenio.DataBind();
        ddlConvenio.Items.Insert(0, new ListItem("Seleccione", ""));

    }
    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        int agencia = 0;
        int localidad = 0;
        int asesor = 0;
        int estadoNegocio = 0;
        int anio = 0;
        int mes = 0;
        int compania = 0;
        int producto = 0;
        int pagaduria = 0;
        int convenio = 0;

        DateTime fechaDesde = Convert.ToDateTime("01/01/1900");
        DateTime fechaHasta = Convert.ToDateTime("01/01/1900");

        if (txtFechaExpedicionDesde.Text != "" && txtFechaExpedicionHasta.Text != "")
        {
            if (ddlAgencia.Text != "")
            {
                agencia = int.Parse(ddlAgencia.Text);
            }

            if (ddlLocalidad.Text != "")
            {
                localidad = int.Parse(ddlLocalidad.Text);
            }

            if (ddlAsesor.Text != "")
            {
                asesor = int.Parse(ddlAsesor.Text);
            }

            if (ddlEstadoNegocio.Text != "")
            {
                estadoNegocio = int.Parse(ddlEstadoNegocio.Text);
            }

            if (ddlAnioProduccion.Text != "")
            {
                anio = int.Parse(ddlAnioProduccion.Text);
            }

            if (ddlMesProduccion.Text != "")
            {
                mes = int.Parse(ddlMesProduccion.Text);
            }

            if (ddlCompania.Text != "")
            {
                compania = int.Parse(ddlCompania.Text);
            }

            if (ddlProducto.Text != "")
            {
                producto = int.Parse(ddlProducto.Text);
            }

            if (ddlPagaduria.Text != "")
            {
                pagaduria = int.Parse(ddlPagaduria.Text);
            }

            if (ddlConvenio.Text != "")
            {
                convenio = int.Parse(ddlConvenio.Text);
            }

            if (txtFechaExpedicionDesde.Text != "")
            {
                fechaDesde = DateTime.Parse(txtFechaExpedicionDesde.Text);
            }

            if (txtFechaExpedicionHasta.Text != "")
            {
                fechaHasta = DateTime.Parse(txtFechaExpedicionHasta.Text);
            }

            DataTable dtInforme = InformeProduccion.ConsultarInformeProduccion(agencia, localidad, asesor, estadoNegocio, anio, mes, compania, producto, pagaduria, convenio, fechaDesde, fechaHasta);
            Funciones.generarExcel(Page, dtInforme, "Informe de produccion");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Debe seleccionar un rango de fecha');", true);
        } 
        
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect(url: "/Presentacion/InformeProduccion.aspx");
        Response.RedirectToRoute("informeProduccion");
    }
   
}