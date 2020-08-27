using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion3_InformeAplicacion : System.Web.UI.Page
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

    DataTable dt = new DataTable();
    DataTable dtLocalidades = new DataTable();
    DataTable dtProducto = new DataTable();
    DataTable dtCompaniasGenerales = new DataTable();
    DataTable dtPagaduria = new DataTable();
    DataTable dtConvenio = new DataTable();

    int localidad = 0;
    int pagaduria = 0;
    int convenio = 0;
    int recibo = 0;
    int compania = 0;
    int producto = 0;
    DateTime fechaDesde;
    DateTime fechaHasta;
   
    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    PrecargueProduccion precargue = new PrecargueProduccion();
    Pagos objPago = new Pagos();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            dtLocalidades = AdministrarDevolucionDePrima.ConsultarLocalidades();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidades;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));

            //Carga la compañia, trayendo el com_Id y com_Nombre
            Pagos objPago = new Pagos();
            dtCompaniasGenerales = objPago.ConsultarCompaniasGenerales();
            ddlCompania.DataValueField = "Com_Id";
            ddlCompania.DataTextField = "Com_Nombre";
            ddlCompania.DataSource = dtCompaniasGenerales;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("", ""));

            //dt = AdministrarDevolucionDePrima.ConsultarAplicacionSeleccionable(0,0,0,0,0,0,Convert.ToDateTime("01/01/1800"), Convert.ToDateTime("01/01/1800"));
            //grvAplicacion.DataSource = dt;
            //grvAplicacion.DataBind();

            //Restringir fechas
            txtDesde.Attributes["min"] = "1801-01-01";
            txtDesde.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");

            txtHasta.Attributes["min"] = "1801-01-01";
            txtHasta.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }

    //Carga las aplicaciones de pago dependiendo de los filtros seleccionados
    protected void cargarAplicaciones()
    {
        localidad = (ddlLocalidad.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlLocalidad.SelectedValue.ToString());
        pagaduria = (ddlPagaduria.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
        convenio = (ddlConvenio.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
        recibo = (txtRecibo.Text == "") ? 0 : int.Parse(txtRecibo.Text);
        compania = (ddlCompania.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlCompania.SelectedValue.ToString());
        producto = (ddlProducto.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
        fechaDesde = (txtDesde.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtDesde.Text);
        fechaHasta = (txtHasta.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtHasta.Text);

        if(localidad == 0 )
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Debe seleccionar la localidad" + "');", true);
        }
        else
        {
            dt = AdministrarDevolucionDePrima.ConsultarAplicacionSeleccionable(localidad,pagaduria,convenio,recibo,compania,producto, fechaDesde, fechaHasta);
            grvAplicacion.DataSource = dt;
            grvAplicacion.DataBind();
        }
    }

    //Carga las pagadurias cuando se selecciona una localidad
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocalidad.SelectedValue.ToString() != "")
        {
            //Carga el ddlPagaduria según seleccion del ddlAgencia
            dtPagaduria = objAdministrarCertificados.ConsultarPagaduriaPorLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            ddlPagaduria.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlPagaduria.Items.Clear();
            ddlPagaduria.SelectedIndex = -1;
            ddlPagaduria_SelectedIndexChanged(sender, e);
        }
        cargarAplicaciones();
    }

    //Carga los convenios cuando se selecciona  una pagaduria
    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPagaduria.SelectedValue.ToString() != "")
        {
            dtConvenio = objPago.ConsultarConveniosConciliacion(int.Parse(ddlPagaduria.SelectedValue.ToString()));
            ddlConvenio.DataTextField = "con_Nombre";
            ddlConvenio.DataValueField = "con_Id";
            ddlConvenio.DataSource = dtConvenio;
            ddlConvenio.DataBind();
            ddlConvenio.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlConvenio.Items.Clear();
            ddlConvenio.SelectedIndex = -1;
        }
        cargarAplicaciones();

    }

    //Carga las aplicaciones y pone un minimo de fecha para el campo de fecha final
    protected void txtDesde_TextChanged(object sender, EventArgs e)
    {
        cargarAplicaciones();
        txtHasta.Attributes["min"] = txtDesde.Text;
    }

    //Carga las aplicaciones
    protected void txtHasta_TextChanged(object sender, EventArgs e)
    {
        cargarAplicaciones();
    }

    //Carga los productos cuando se selecciona una compañia
    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompania.SelectedValue.ToString() != "")
        {
            dtProducto = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompania.SelectedValue.ToString()));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlProducto.Items.Clear();
            ddlProducto.SelectedIndex = -1;
        }
        cargarAplicaciones();
    }

    //Carga las aplicaciones
    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarAplicaciones();
    }

    //Carga las aplicaciones
    protected void ddlConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarAplicaciones();
    }

    //Carga las aplicaciones
    protected void txtRecibo_TextChanged(object sender, EventArgs e)
    {
        cargarAplicaciones();
    }
}