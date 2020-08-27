using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Presentacion_PolizasArchivadas : System.Web.UI.Page
{
    public DigitarProduccion objDigitarProduccion = new DigitarProduccion();
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }

    protected void CargarDigitacion()
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.ConsultarCertificadoActaTransferencial(4, 1, 5);
        grvPolizasArchivadas.DataSource = dt;
        grvPolizasArchivadas.DataBind();

       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();

        if (!IsPostBack)
        {
            CargarDigitacion();
            CargarAgencias();
        }
    }
    protected void CargarAgencias()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        try
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.cargarAgenciaDdl();
            ddlagenciaProduccion.DataTextField = "age_Nombre";
            ddlagenciaProduccion.DataValueField = "age_Id";
            ddlagenciaProduccion.DataSource = dt;
            ddlagenciaProduccion.DataBind();
            ddlagenciaProduccion.Items.Insert(0, new ListItem("Seleccione...", ""));
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR SELECCIIONE UNA AGENCIA" + "');", true);
        }

    }

    protected void CargarBusquedaAgencia(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.CargarBusquedaAgencia(int.Parse(ddlagenciaProduccion.SelectedValue.ToString()), 4);
        grvPolizasArchivadas.DataSource = dt;
        grvPolizasArchivadas.DataBind();
        dt = new DataTable();
    }

    protected void CargarBusquedaTercero(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtcedulaProduccion.Text == "")
        {
            CargarDigitacion();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaTercero(int.Parse(txtcedulaProduccion.Text), 4);
            grvPolizasArchivadas.DataSource = dt;
            grvPolizasArchivadas.DataBind();
            dt = new DataTable();
        }
    }

    protected void CargarBusquedaFecha(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtcedulaProduccion.Text == "")
        {
            CargarDigitacion();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaFecha(DateTime.Parse(txtDesde.Text), DateTime.Parse(txtHasta.Text), 4);
            grvPolizasArchivadas.DataSource = dt;
            grvPolizasArchivadas.DataBind();
            dt = new DataTable();
        }
    }

    protected void CargarBusquedaPoliza(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if(txtnumeroCertificadoProduccion.Text == "")
        {
            CargarDigitacion();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPoliza(int.Parse(txtnumeroCertificadoProduccion.Text), 4);
            grvPolizasArchivadas.DataSource = dt;
            grvPolizasArchivadas.DataBind();
            dt = new DataTable();
        }
    }
    protected void grvPolizasArchivadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPolizasArchivadas.PageIndex = e.NewPageIndex;
        CargarDigitacion();
    }
    protected void btnBusquedaPlanilla_Click(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtcedulaProduccion.Text != "")
        {
            CargarBusquedaTercero(sender, e);
        }

        if (txtnumeroCertificadoProduccion.Text != "")
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPoliza(int.Parse(txtnumeroCertificadoProduccion.Text), 4);
            grvPolizasArchivadas.DataSource = dt;
            grvPolizasArchivadas.DataBind();
            dt = new DataTable();
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("PolizasArchivadas.aspx");
        Response.RedirectToRoute("polizasArchivadas");
    }
}