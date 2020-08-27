using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion3_InformeRecibo : System.Web.UI.Page
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

    DataTable dtLocalidades = new DataTable();
    DataTable dtCompaniasGenerales = new DataTable();
    DataTable dt = new DataTable();
    DataTable dtPagaduria = new DataTable();
    DataTable dtConvenio = new DataTable();
    DataTable dtProducto = new DataTable();
    DataTable dtAplicaciones = new DataTable();
    DataTable dtReciboResumen = new DataTable();

    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    PrecargueProduccion precargue = new PrecargueProduccion();
    Pagos objPago = new Pagos();

    int localidad = 0;
    int pagaduria = 0;
    int convenio = 0;
    string recibo = "0";
    int compania = 0;
    int producto = 0;
    DateTime fechaDesde;
    DateTime fechaHasta;

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

            //dt = AdministrarDevolucionDePrima.ConsultarRecibosSeleccionable(0, 0, 0, "0", 0, 0, Convert.ToDateTime("01/01/1800"), Convert.ToDateTime("01/01/1800"));
            //grvRecibo.DataSource = dt;
            //grvRecibo.DataBind();

            //Restringir fechas
            txtDesde.Attributes["min"] = "1801-01-01";
            txtDesde.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");

            txtHasta.Attributes["min"] = "1801-01-01";
            txtHasta.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }

    //Carga los recibos de pago dependiendo de los filtros que seleccione
    protected void cargarRecibos()
    {
        localidad = (ddlLocalidad.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlLocalidad.SelectedValue.ToString());
        pagaduria = (ddlPagaduria.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
        convenio = (ddlConvenio.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
        recibo = (txtRecibo.Text == "") ? "0" : txtRecibo.Text;
        compania = (ddlCompania.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlCompania.SelectedValue.ToString());
        producto = (ddlProducto.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
        fechaDesde = (txtDesde.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtDesde.Text);
        fechaHasta = (txtHasta.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtHasta.Text);

        if (localidad != 0)
        {
            dt = AdministrarDevolucionDePrima.ConsultarRecibosSeleccionable(localidad, pagaduria, convenio, recibo, compania, producto, fechaDesde, fechaHasta);
            grvRecibo.DataSource = dt;
            grvRecibo.DataBind();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Debe seleccionar la localidad" + "');", true);
        }
    }

    //Carga las pagaduria de la localidad seleccionada
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
        cargarRecibos();
    }

    //Carga los convenios de la pagaduria que seleccione
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
        cargarRecibos();
    }

    //Carga los recibos de pago
    protected void ddlConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarRecibos();
    }

    //Carga los recibos de pago
    protected void txtRecibo_TextChanged(object sender, EventArgs e)
    {
        cargarRecibos();
    }

    //Carga los productos de la compañia seleccionada
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
        cargarRecibos();
    }

    //Carga los recibos de pago
    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarRecibos();
    }

    //Carga los recibos de pago
    protected void txtDesde_TextChanged(object sender, EventArgs e)
    {
        cargarRecibos();
        txtHasta.Attributes["min"] = txtDesde.Text;
    }

    //Carga los recibos de pago
    protected void txtHasta_TextChanged(object sender, EventArgs e)
    {
        cargarRecibos();
    }

    //Consulta las aplicaciones de pago de un recibo
    protected void grvRecibo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvRecibo.Rows[(index)];
        

        if (e.CommandName == "consultar_Click")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('ALERTA');", true);

            string Id = row.Cells[1].Text;
            string rec_Numero = row.Cells[2].Text;
            double total = 0;

            dtReciboResumen = AdministrarDevolucionDePrima.ConsultarRecibosSeleccionable(0, 0, 0, rec_Numero, 0, 0, Convert.ToDateTime("01/01/1800"), Convert.ToDateTime("01/01/1800"));
            grvReciboResumen.DataSource = dtReciboResumen;
            grvReciboResumen.DataBind();

            dtAplicaciones = AdministrarDevolucionDePrima.ConsultarReciboResumen(int.Parse(Id));

            foreach (DataRow dtRow in dtAplicaciones.Rows)
            {
                total += double.Parse(dtRow["Valor"].ToString());
            }

            DataRow rowTotal = dtAplicaciones.NewRow();
            rowTotal["Nombre"] = "Total";
            rowTotal["Valor"] = total.ToString();
            dtAplicaciones.Rows.Add(rowTotal);

            grvAplicaciones.DataSource = dtAplicaciones;
            grvAplicaciones.DataBind();

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#miVentana').modal('show');</script>", false);
    }
}