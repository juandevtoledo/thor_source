using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion3_InformeDevolucion : System.Web.UI.Page
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

    PrecargueProduccion precargue = new PrecargueProduccion();
    DataTable dt = new DataTable(); 
    DataTable dtAgencia = new DataTable();
    DataTable dtLocalidades = new DataTable();
    DataTable dtProducto = new DataTable();
    DataTable dtCompaniasGenerales = new DataTable();
    DataTable dtCausaDevolucion = new DataTable();
    DataTable dtFormaPago = new DataTable();
    DataTable dtRechazo = new DataTable();
    DataTable dtEstado = new DataTable();

    int localidad = 0;
    int mes = 0;
    DateTime fechaDesde;
    DateTime fechaHasta;
    int compania = 0;
    int producto = 0;
    int formaPago = 0;
    int causaDevolucion = 0;
    int estado = 0;
    int rechazo = 0;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Codigo para redireccionar al caducar la session*****************************JC//
        /**/
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 3));//
        /**/
        if (Session["usuario"] == null)                                             //
            /**/
            Response.Redirect("~/login.aspx");                                          //
        //******************************************************************************//

        if (!IsPostBack)
        {
            dtLocalidades = AdministrarDevolucionDePrima.consultarLocalidades();
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

            //Carga las causales de devolucion de prima
            dtCausaDevolucion = AdministrarDevolucionDePrima.ConsultarCausalDevolucionPrima();
            ddlCausaDevolucion.DataValueField = "caudev_Id";
            ddlCausaDevolucion.DataTextField = "caudev_Nombre";
            ddlCausaDevolucion.DataSource = dtCausaDevolucion;
            ddlCausaDevolucion.DataBind();
            ddlCausaDevolucion.Items.Insert(0, new ListItem("", ""));

            //Carga las formas de pago
            dtFormaPago.Columns.Add("esp_Id");
            dtFormaPago.Columns.Add("esp_Nombre");
            DataRow filaF = dtFormaPago.NewRow();
            filaF["esp_Id"] = 1;
            filaF["esp_Nombre"] = "TORRES GUARIN - CUENTA BANCARIA";
            dtFormaPago.Rows.Add(filaF);
            DataRow filaF1 = dtFormaPago.NewRow();
            filaF1["esp_Id"] = 2;
            filaF1["esp_Nombre"] = "TORRES GUARIN - EFECTIVO ";
            dtFormaPago.Rows.Add(filaF1);
            DataRow filaF2 = dtFormaPago.NewRow();
            filaF2["esp_Id"] = 3;
            filaF2["esp_Nombre"] = "COMPAÑIA";
            dtFormaPago.Rows.Add(filaF2);
            ddlFormaPago.DataValueField = "esp_Id";
            ddlFormaPago.DataTextField = "esp_Nombre";
            ddlFormaPago.DataSource = dtFormaPago;
            ddlFormaPago.DataBind();
            ddlFormaPago.Items.Insert(0, new ListItem("", ""));

            //Carga las causales de rechazo de devolucion de prima
            dtRechazo = AdministrarDevolucionDePrima.ConsultarCausalRechazoDevolucionPrima();
            ddlRechazo.DataValueField = "rech_Id";
            ddlRechazo.DataTextField = "rech_Nombre";
            ddlRechazo.DataSource = dtRechazo;
            ddlRechazo.DataBind();
            ddlRechazo.Items.Insert(0, new ListItem("", ""));

            //Cargar los estados de la devolucion
            dtEstado.Columns.Add("estado_Id");
            dtEstado.Columns.Add("estado_Nombre");
            DataRow fila = dtEstado.NewRow();
            fila["estado_Id"] = 1;
            fila["estado_Nombre"] = "PENDIENTE POR DOCUMENTOS";
            dtEstado.Rows.Add(fila);
            DataRow fila1 = dtEstado.NewRow();
            fila1["estado_Id"] = 2;
            fila1["estado_Nombre"] = "ESPERA VALOR TECNICO";
            dtEstado.Rows.Add(fila1);
            DataRow fila2 = dtEstado.NewRow();
            fila2["estado_Id"] = 3;
            fila2["estado_Nombre"] = "PENDIENTE CONFIRMAR";
            dtEstado.Rows.Add(fila2);
            DataRow fila3 = dtEstado.NewRow();
            fila3["estado_Id"] = 4;
            fila3["estado_Nombre"] = "EFECTIVA";
            dtEstado.Rows.Add(fila3);
            ddlEstado.DataValueField = "estado_Id";
            ddlEstado.DataTextField = "estado_Nombre";
            ddlEstado.DataSource = dtEstado;
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("", ""));

            //Carga los meses del año
            ddlMes.Items.Insert(0, new ListItem("", ""));

            //Restringir fechas
            txtDesde.Attributes["min"] = "1801-01-01";
            txtDesde.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");

            txtHasta.Attributes["min"] = "1801-01-01";
            txtHasta.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");

            dt = AdministrarDevolucionDePrima.ConsultarDevolucionPrimaSeleccionable(0, 0, Convert.ToDateTime("01/01/1800"), Convert.ToDateTime("01/01/1800"), 0, 0, 0, 0, 0, 0);
            grvDevoluciones.DataSource = dt;
            grvDevoluciones.DataBind();
        }

    }

    protected void cargarDevoluciones()
    {
        localidad = (ddlLocalidad.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlLocalidad.SelectedValue.ToString());
        mes = (ddlMes.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlMes.SelectedValue.ToString());
        fechaDesde = (txtDesde.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtDesde.Text);
        fechaHasta = (txtHasta.Text == "") ? Convert.ToDateTime("01/01/1800") : Convert.ToDateTime(txtHasta.Text);
        compania = (ddlCompania.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlCompania.SelectedValue.ToString());
        producto = (ddlProducto.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
        formaPago = (ddlFormaPago.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlFormaPago.SelectedValue.ToString());
        causaDevolucion = (ddlCausaDevolucion.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlCausaDevolucion.SelectedValue.ToString());
        estado = (ddlEstado.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlEstado.SelectedValue.ToString());
        rechazo = (ddlRechazo.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlRechazo.SelectedValue.ToString()); ;

        dt = AdministrarDevolucionDePrima.ConsultarDevolucionPrimaSeleccionable(localidad, mes, fechaDesde, fechaHasta, compania, producto, formaPago, causaDevolucion, estado, rechazo);
        grvDevoluciones.DataSource = dt;
        grvDevoluciones.DataBind();
    }

    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }

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
        cargarDevoluciones();
    }

    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }

    protected void ddlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }

    protected void ddlCausaDevolucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }
    protected void ddlRechazo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }
    protected void txtDesde_TextChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
        txtHasta.Attributes["min"] = txtDesde.Text;
    }
    protected void txtHasta_TextChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }
    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDevoluciones();
    }
}
