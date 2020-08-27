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
using System.Threading;
using System.Threading.Tasks;
using System;

public partial class Presentacion2_FrmConciliacion : System.Web.UI.Page
{
    #region Consulta de Usuario
    //Permite consultar el usuario para posteriormente asignarle sus permisos
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];

        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);

        if (grvTablaHistorialPagosPorOficina.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos idCartaRetiro y cer_Id de la tabla que se muestra al usuario 
            grvTablaHistorialPagosPorOficina.HeaderRow.Cells[2].Visible = false;


            int cont = 0;
            foreach (GridViewRow rows in grvTablaHistorialPagosPorOficina.Rows)
            {
                grvTablaHistorialPagosPorOficina.Rows[cont].Cells[2].Visible = false;
                cont++;
            }
        }
    }
    #endregion

    #region Variables, objetos globales y Cargue de operaciones iniciales
    public PrecargueProduccion precargue = new PrecargueProduccion();
    public Pagos objPago = new Pagos();
    public DAOPagos objPagos = new DAOPagos();

    DataTable dtAgencia = new DataTable(), dtCompañia = new DataTable(), dtProducto = new DataTable(), dtRecibo = new DataTable(), dtPagaduria = new DataTable(), dtConvenio = new DataTable();
    int idConciliacion = 0;
    int _sopdetId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        //Codigo para redireccionar al caducar la session*****************************//
        /**/
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 3));//
        /**/
        if (Session["usuario"] == null)                                             //
            /**/
            Response.RedirectToRoute("thor");                                       //
        //******************************************************************************//

        if (!IsPostBack)
        {
            legend.Visible = false;
            ChkConciliarCedulasNoConcidentes.Visible = false;
            txtSaldoConciliar.Enabled = false;
            btnConciliarPagoOficina.Enabled = false;
            
            Session["dtExcel"] = new DataTable();
            DataTable dtExcel = (DataTable)Session["dtExcel"];
            dtExcel.Clear();

            dtProducto.Clear();

            bool modifico = false;
            Session["modifico"] = modifico;

            //Carga las agencias, trayendo el Id y el nombre de ellas
            dtAgencia = objAdministrarCertificados.ConsultarAgencia();
            ddlAgencia.DataValueField = "age_Id";
            ddlAgencia.DataTextField = "age_Nombre";
            ddlAgencia.DataSource = dtAgencia;
            ddlAgencia.DataBind();
            ddlAgencia.Items.Insert(0, new ListItem("", ""));

            Pagos objPago = new Pagos();
            DataTable dtConsultarRecibos = new DataTable();
            //dtConsultarRecibos = objPago.ConsultarRecibos();
            //grvConsultarRecibos.DataSource = dtConsultarRecibos;
            //grvConsultarRecibos.DataBind();

            Session["dtConsultarRecibos"] = dtConsultarRecibos;
            Session["banderaResponse"] = 0;

            DataTable dtNombreCreador = new DataTable();
            dtNombreCreador = objPago.ConsultarNombreUsuarioPorCedula(double.Parse(Session["Cedula"].ToString()));
            string nombreCreador = dtNombreCreador.Rows[0]["Nombre"].ToString();

            Session["nombreCreador"] = nombreCreador;
            //Carga la compañia, trayendo el com_Id y com_Nombre
            DataTable dtCompaniasGenerales = new DataTable();
            dtCompaniasGenerales = objPago.ConsultarCompaniasGenerales();
            ddlCompañia.DataValueField = "Com_Id";
            ddlCompañia.DataTextField = "Com_Nombre";
            ddlCompañia.DataSource = dtCompaniasGenerales;
            ddlCompañia.DataBind();
            ddlCompañia.Items.Insert(0, new ListItem("", ""));

            ddlCompaniaOficina.DataValueField = "Com_Id";
            ddlCompaniaOficina.DataTextField = "Com_Nombre";
            ddlCompaniaOficina.DataSource = dtCompaniasGenerales;
            ddlCompaniaOficina.DataBind();
            ddlCompaniaOficina.Items.Insert(0, new ListItem("", ""));

            //Carga los los recibos, trayendo el rec_Numero
            dtRecibo = (DataTable)Session["dtConsultarRecibos"];
            ddlRecibo.DataTextField = "Recibo";
            ddlRecibo.DataValueField = "Recibo";
            ddlRecibo.DataSource = dtRecibo;
            ddlRecibo.DataBind();
            ddlRecibo.Items.Insert(0, new ListItem("", ""));

            btnConciliar.Enabled = false;//false
            //btnConciliarPagoOficina.Visible = false;
            lblObservacionesDevolcion.Visible = false;
            txtObservacionesDevolcion.Visible = false;
            ddlEstadoDevolucion.Visible = false;
            lblValorDevolución.Visible = false;
            txtValorDevolucion.Visible = false;
            rbtlMarca.Visible = false;
            lblEstadoDevolucion.Visible = false;
            btnGuardarAplicacionesDevolucion.Visible = false;
            contPagos.Visible = false;
            titCerti.Visible = false;
            titHistorial.Visible = false;
            Session["bandera"] = 0;
        }
    }
    #endregion

    #region Eventos

    #region Cargue de seleccionables y recibos
    #region Carga de localidades y de recibos por agencia
    protected void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLocalidad.Enabled = true;
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtConsultarReciboSeleccionable = new DataTable();
        //Pregunta si la agencia es diferente de vacio para continuar
        if (ddlAgencia.SelectedValue.ToString() != "")
        {
            //Se llena un dt con las localidades segun la agencia solicitada y posteriormente se carga un ddl con dicha información
            DataTable dtLocalidadesPorAgencia = new DataTable();
            dtLocalidadesPorAgencia = objAdministrarCertificados.ConsultarLocalidadPorAgencia(int.Parse(ddlAgencia.SelectedValue.ToString()));
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidadesPorAgencia;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlLocalidad.Items.Clear();
            ddlLocalidad.SelectedIndex = -1;
        }

        // Se consultan los recibos con los respectivos parametros 
        int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
        int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
        int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
        int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
        int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
        string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
        string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();

        //Se realiza la consulta con los respectivos parametros y se llena la tabla con dicha consulta
        dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
        grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
        grvConsultarRecibos.DataBind();

        //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
        Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

        if (ddlRecibo.SelectedValue.ToString() == "")
        {
            //Se carga un ddl con la informacion de los recibos ya listados en la tabla anterior
            dtRecibo = (DataTable)Session["dtConsultarRecibos"];
            ddlRecibo.DataTextField = "Recibo";
            ddlRecibo.DataValueField = "Recibo";
            ddlRecibo.DataSource = dtRecibo;
            ddlRecibo.DataBind();
            ddlRecibo.Items.Insert(0, new ListItem("", ""));
        }
    }
    #endregion

    #region Carga de Pagadurias y recibos por la localidad seleccionada
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlLocalidad.SelectedValue.ToString() != "")
        {
            //Carga el ddlPagaduria según la localidad seleccionada
            dtPagaduria = objAdministrarCertificados.ConsultarPagaduriaPorLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            ddlPagaduria.Items.Insert(0, new ListItem("", ""));

            //Parametros que se enviaran para la consulta de recibos
            DataTable dtConsultarReciboSeleccionable = new DataTable();
            int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
            int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
            int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
            int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
            int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
            string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
            string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();

            //Se filtra la tabla de recibos con los parametros seleccionados
            dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
            grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
            grvConsultarRecibos.DataBind();

            //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
            Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

            if (ddlRecibo.SelectedValue.ToString() == "")
            {
                //Se llena el ddl de recibos con los recibos ya listados en la tabla anterior
                dtRecibo = (DataTable)Session["dtConsultarRecibos"];
                ddlRecibo.DataTextField = "Recibo";
                ddlRecibo.DataValueField = "Recibo";
                ddlRecibo.DataSource = dtRecibo;
                ddlRecibo.DataBind();
                ddlRecibo.Items.Insert(0, new ListItem("", ""));
            }
        }
        else
        {
            ddlPagaduria.Items.Clear();
            ddlPagaduria.SelectedIndex = -1;
            ddlAgencia_SelectedIndexChanged(sender, e);
        }
    }
    #endregion

    #region Carga de Productos y recibos segun la compañia seleccionada
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompañia.SelectedValue.ToString() != "")
        {
            //Se carga la el ddl de productos segun la compañia seleccionada
            dtProducto = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompañia.SelectedValue.ToString()));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));

            //Parametros que se enviaran para la consulta de recibos
            DataTable dtConsultarReciboSeleccionable = new DataTable();
            int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
            int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
            int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
            int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
            int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
            string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
            string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();

            //Se filtra la tabla de recibos con los parametros seleccionados
            dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
            grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
            grvConsultarRecibos.DataBind();

            //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
            Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

            if (ddlRecibo.SelectedValue.ToString() == "")
            {
                //Se llena el ddl de recibos con los recibos ya listados en la tabla anterior
                dtRecibo = (DataTable)Session["dtConsultarRecibos"];
                ddlRecibo.DataTextField = "Recibo";
                ddlRecibo.DataValueField = "Recibo";
                ddlRecibo.DataSource = dtRecibo;
                ddlRecibo.DataBind();
                ddlRecibo.Items.Insert(0, new ListItem("", ""));
            }
        }
        else
        {
            ddlProducto.Items.Clear();
            ddlProducto.SelectedIndex = -1;
            ddlConvenio_SelectedIndexChanged(sender, e);
        }
    }
    #endregion

    #region Carga de Convenios y recibos segun la pagaduria seleccionada
    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();
        if (ddlPagaduria.SelectedValue.ToString() != "")
        {
            //Se carga el ddl de convenios segun la pagaduria seleccionada
            dtConvenio = objPago.ConsultarConveniosConciliacion(int.Parse(ddlPagaduria.SelectedValue.ToString()));
            ddlConvenio.DataTextField = "con_Nombre";
            ddlConvenio.DataValueField = "con_Id";
            ddlConvenio.DataSource = dtConvenio;
            ddlConvenio.DataBind();
            ddlConvenio.Items.Insert(0, new ListItem("", ""));

            //Parametros que se enviaran para la consulta de recibos
            DataTable dtConsultarReciboSeleccionable = new DataTable();
            int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
            int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
            int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
            int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
            int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
            string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
            string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();
            dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
            grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
            grvConsultarRecibos.DataBind();

            //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
            Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

            // Se carga en una variable el porcentaje de participación que posee la pagaduria
            double porcentajeParticipacion = objPago.ConsularPorcentajeParticipacion(int.Parse(ddlPagaduria.SelectedValue.ToString()));

            //Se va en una session el porcentaje de participación para ser llamado al momento de cargar el listado
            Session["porcentajeParticipacion"] = porcentajeParticipacion;

            if (ddlRecibo.SelectedValue.ToString() == "")
            {
                //Se llena el ddl de recibos con los recibos ya listados en la tabla anterior
                dtRecibo = (DataTable)Session["dtConsultarRecibos"];
                ddlRecibo.DataTextField = "Recibo";
                ddlRecibo.DataValueField = "Recibo";
                ddlRecibo.DataSource = dtRecibo;
                ddlRecibo.DataBind();
                ddlRecibo.Items.Insert(0, new ListItem("", ""));
            }
        }
        else
        {
            ddlConvenio.Items.Clear();
            ddlConvenio.SelectedIndex = -1;
            ddlLocalidad_SelectedIndexChanged(sender, e);
        }
    }
    #endregion

    #region Cargue de recibos segun el producto selecionado
    protected void ddlProducto_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlProducto.SelectedValue.ToString() != "")
            {
                //Parametros que se enviaran para la consulta de recibos
                DataTable dtConsultarReciboSeleccionable = new DataTable();
                int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
                int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
                int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
                int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
                int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
                string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
                string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();
                dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
                grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
                grvConsultarRecibos.DataBind();

                //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
                Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

                if (ddlRecibo.SelectedValue.ToString() == "")
                {
                    //Se llena el ddl de recibos con los recibos ya listados en la tabla anterior
                    dtRecibo = (DataTable)Session["dtConsultarRecibos"];
                    ddlRecibo.DataTextField = "Recibo";
                    ddlRecibo.DataValueField = "Recibo";
                    ddlRecibo.DataSource = dtRecibo;
                    ddlRecibo.DataBind();
                    ddlRecibo.Items.Insert(0, new ListItem("", ""));
                }
            }
            else
            {
                ddlCompañia_SelectedIndexChanged(sender, e);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR Seleccione PRODUCTO" + "');", true);
        }
    }
    #endregion

    #region Carga el recibo segun el numero seleccionado
    protected void ddlRecibo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlRecibo.SelectedValue.ToString() != "")
            {
                //Parametros que se enviaran para la consulta de recibos
                DataTable dtConsultarReciboSeleccionable = new DataTable();
                int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
                int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
                int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
                int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
                int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
                string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
                string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();
                recibo = recibo.Substring(5);
                dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
                grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
                grvConsultarRecibos.DataBind();

                //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
                Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;
            }
            else
            {
                ddlProducto_SelectedIndexChanged1(sender, e);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR Seleccione RECIBO" + "');", true);
        }
    }
    #endregion

    #region Cargue de soportes y recibos segun el convenio seleccionado
    protected void ddlConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();

        if (ddlConvenio.SelectedValue.ToString() != "")
        {
            //Se cargan los soportes bancarios que aun no han sido aplicados para este convenio
            DataTable dtConsultarSoporteBancarioParaPago = new DataTable();
            dtConsultarSoporteBancarioParaPago = objPago.ConsultarSoporteBancarioParaPago(int.Parse(ddlConvenio.SelectedValue.ToString()));
            grvSoportesPagaduria.DataSource = dtConsultarSoporteBancarioParaPago;
            grvSoportesPagaduria.DataBind();

            //Parametros que se enviaran para la consulta de recibos
            DataTable dtConsultarReciboSeleccionable = new DataTable();
            int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
            int agencia = (ddlAgencia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlAgencia.SelectedValue.ToString());
            int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());
            int compañia = (ddlCompañia.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlCompañia.SelectedValue.ToString());
            int producto = (ddlProducto.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlProducto.SelectedValue.ToString());
            string recibo = (ddlRecibo.SelectedValue.ToString() == string.Empty) ? "0" : ddlRecibo.SelectedValue.ToString();
            string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();
            dtConsultarReciboSeleccionable = objPagos.ConsultarRecibosConSeleccionables(pagaduria, agencia, convenio, compañia, producto, recibo, cedula);
            grvConsultarRecibos.DataSource = dtConsultarReciboSeleccionable;
            grvConsultarRecibos.DataBind();

            //Se guarda la información en un dt con el fin de ir filtrando el paginador en caso de que sea utilizado
            Session["dtConsultarRecibos"] = dtConsultarReciboSeleccionable;

            if (ddlRecibo.SelectedValue.ToString() == "")
            {
                //Se llena el ddl de recibos con los recibos ya listados en la tabla anterior
                dtRecibo = (DataTable)Session["dtConsultarRecibos"];
                ddlRecibo.DataTextField = "Recibo";
                ddlRecibo.DataValueField = "Recibo";
                ddlRecibo.DataSource = dtRecibo;
                ddlRecibo.DataBind();
                ddlRecibo.Items.Insert(0, new ListItem("", ""));
            }
        }
        else
        {
            ddlPagaduria_SelectedIndexChanged(sender, e);
        }

        DataTable dtCompaniasGeneralesInforme = new DataTable();
        dtCompaniasGeneralesInforme = objPago.ConsultarCompaniasGenerales();
        ddlCompaniaPago.DataValueField = "Com_Id";
        ddlCompaniaPago.DataTextField = "Com_Nombre";
        ddlCompaniaPago.DataSource = dtCompaniasGeneralesInforme;
        ddlCompaniaPago.DataBind();
        ddlCompaniaPago.Items.Insert(0, new ListItem("", ""));
    }
    #endregion
    #endregion

    #region Conciliación
    #region Cargue de listados para la posterior conciliación
    protected void btnCargarDatos_Click(object sender, EventArgs e)
    {
        DataTable dtExcel = new DataTable();
        DataTable dtExcelInconsistencias = new DataTable();
        OleDbConnection OleDbcon;
        //Condicional al cual entrara solo si ya adjunto un archivo
        if (fupCargarClientes.HasFile)
        {
            //Varible a la cual se le asigna el tipo de archivo
            string ext = Path.GetExtension(fupCargarClientes.FileName);

            //Condicional para solo permitir el cargue archivos excel en la versión 2007
            //if (ext.ToLower() == ".xlsx")
            //{
            //Condicional para solo permitir el cargue de archivos .txt
            string ruta = string.Concat((Server.MapPath("~/temp/" + fupCargarClientes.FileName)));
            fupCargarClientes.PostedFile.SaveAs(ruta);

            //Control de excepciones cuando se suba un archivo de excel en diferentes versiones
            try
            {
                OleDbcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;");
                //OleDbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=Excel 8.0;");
            }
            catch
            {
                OleDbcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;");
                //OleDbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=Excel 8.0;");
            }
            OleDbCommand cmd = new OleDbCommand("Select * from [Hoja1$]", OleDbcon);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);

            OleDbcon.Open();
            DbDataReader dr = cmd.ExecuteReader();

            //Se carga en un dt la información del listado subido
            dtExcel.Load(dr);

            //Se crea un dt identico al cargado anteriormente para posteriormente dejarlo solo con las inconsistencias
            dtExcelInconsistencias = dtExcel;
            OleDbcon.Close();


            //Condicional para verificar que la estructura cargada es la solicitada
            if (verificarExcel(dtExcel))
            {
                //Ruta en la que se encuentra el archivo cargado
                Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
                lblRespuesta.ForeColor = Color.Green;
                lblRespuesta.Text = "Los datos fueron cargados correctamente";

                double valorTotal = 0;

                //Recorre el dt de clientes con el fin de obtener el valor total por el que viene el listado
                foreach (DataRow drExcel in dtExcel.Rows)
                {
                    double valor = 0;
                    valor = double.Parse(drExcel["VALOR"].ToString());
                    valorTotal += valor;
                }

                //Asigna el valor anterior a un campo txt con el fin de ser mostrado al usuario//
                txtTotalListado.Text = valorTotal.ToString();

                /*Se asigna a una variable el valor de porcentaje participacion traido en una session con el fin de saber el valor
                 que le corresponde a la pagaduria y por ende cual deberia ser el valor del soporte bancario*/
                double valorPorcentaje = double.Parse(Session["porcentajeParticipacion"].ToString());
                double totalValorPorcentaje = valorPorcentaje / 100;
                double totalValorParticipo = valorTotal * totalValorPorcentaje;

                //Se muestra en un campo el porcentaje del total del listado que le corresponde a la pagaduria
                txtParticipo.Text = totalValorParticipo.ToString();
                Session["totalValorParticipo"] = totalValorParticipo;
            }
            else
            {
                lblRespuesta.ForeColor = Color.Red;
                lblRespuesta.Text = "Ajuste la estructura del archivo";
            }
            //}
            //else
            //{
            //    lblRespuesta.ForeColor = Color.Red;
            //    lblRespuesta.Text = "Solo archivos Excel 2007 o superior";
            //}
        }
        else
        {
            lblRespuesta.ForeColor = Color.Red;
            lblRespuesta.Text = "Por favor seleccione un archivo";
        }

        Session["dtExcel"] = dtExcel;
        Session["dtExcelInconsistencias"] = dtExcelInconsistencias;
    }
    #endregion

    #region Validaciones previas como envio a cedulas no coincidentes
    protected void btnConciliar_Click(object sender, EventArgs e)
    {
        DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
        bool modifico = (bool)Session["modifico"];

        //Valida si ya se realizo una validación se las cedulas no coincidentes
        if (modifico == true)
        {
            //Pregunta si ya selecciono enviar cedulas no coincidentes
            if (ChkConciliarCedulasNoConcidentes.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione la opción de enviar cédulas no coincidentes" + "');", true);
            }

            //Si ya selecciono enviar cedulas no condicentes y ya no hay inconsistencia permite pasar al metodo de conciliar
            if (ChkConciliarCedulasNoConcidentes.Checked == true || dtInconsistencias.Rows.Count == 0)
            {
                Conciliar();
            }
            else
            {
                //Si no cumple la validación anterior ira al sigueinte metodo a validar las cedulas no coincidentes
                ConsultarCedulasNoCoincidentes();
                dtInconsistencias = (DataTable)Session["dtInconsistencias"];
                modifico = (bool)Session["modifico"];
            }
        }
        else
        {
            //Si aun no a validado las posibles cedulas no conincidentes ira al siguiente metodo para realizar dicha operación 
            ConsultarCedulasNoCoincidentes();
            dtInconsistencias = (DataTable)Session["dtInconsistencias"];
            modifico = (bool)Session["modifico"];
        }

        //Si existen cedulas no coincidentes en el listado cargado mostrara ciertos campos requeridos para continuar con la conciliación
        if (dtInconsistencias.Rows.Count != 0)
        {
            legend.Visible = true;
            ChkConciliarCedulasNoConcidentes.Visible = true;
        }
        Session["modifico"] = modifico;
        Session["dtInconsistencias"] = dtInconsistencias;
    }
    #endregion
    #endregion

    #region Pagos por oficina

    #region Conciliar pagos por oficina
    protected void btnBuscarPagoOficina_Click(object sender, EventArgs e)
    {
        contPagos.Visible = true;
        titCerti.Visible = true;
        titHistorial.Visible = true;
        panPagosPorOficina.Visible = true;
        panInforme.Visible = true;
        panRecibos.Visible = true;
        Pagos objPago = new Pagos();

        //Consulta para traer y mostrar el historial de certificados del cliente
        DataTable dtPagosOficina = new DataTable();
        dtPagosOficina = objPago.ConsultarPagoPorOficina(double.Parse(txtConsultarPagoOficina.Text));
        grvTablaPagosOficina.DataSource = dtPagosOficina;
        grvTablaPagosOficina.DataBind();

        //Carga y muestra el historial de pagos del cliente 
        DataTable dtHistorialPago = new DataTable();
        dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, double.Parse(txtConsultarPagoOficina.Text), 0, 0);
        grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
        grvTablaHistorialPagosPorOficina.DataBind();

        /*Carga el ddl de convenio en pagos por oficina con el fin de que el 
         * usuario seleccione el convenio por el cual el cliente realizara el pago*/
        DataTable dtConvenioPago = new DataTable();
        dtConvenioPago = objPago.ConsultarConvenioPagoOficina(double.Parse(txtConsultarPagoOficina.Text));
        ddlConvenioPago.DataTextField = "con_Nombre";
        ddlConvenioPago.DataValueField = "cer_Convenio";
        ddlConvenioPago.DataSource = dtConvenioPago;
        ddlConvenioPago.DataBind();

        //Se listan los soportes asignados al cliente en consulta
        DataTable dtSoporteBancarioPagosPorOficina = new DataTable();
        dtSoporteBancarioPagosPorOficina = objPago.ConsultarSoportePagosPorOficina(double.Parse(txtConsultarPagoOficina.Text));
        grvSoporteBancarioPagoOficina.DataSource = dtSoporteBancarioPagosPorOficina;
        grvSoporteBancarioPagoOficina.DataBind();

        int banderaCertificado = 0;
        //Foreach para verificar que el cliente posee un certificado vigente 
        foreach (DataRow dt in dtPagosOficina.Rows)
        {
            //Si cumple la condicion mostrara un mensaje el cual informara al usuario que debe seleccionar el convenio para realizar la aplicación del dinero
            if (dt["Estado"].ToString() == "VIGENTE")
            {
                btnConciliarPagoOficina.Visible = true;
                banderaCertificado = 1;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Recuerde seleccionar el convenio y el soporte bancario para la aplicación de pagos" + "');", true);
            }

        }

        //Si bandera es diferente de uno quiere decir que esta persona no posee certificados vigentes
        if (banderaCertificado != 1)
        {
            //Condicional para identificar si la persona posee registro de certificados en la compañia
            if (dtPagosOficina.Rows.Count > 0)
            {
                //Si solo tiene un registro quiere decir que la persona cuenta con un certificado en el sistema pero no esta vigente
                if (dtPagosOficina.Rows.Count == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El cliente solo tiene un certificado y no está vigente" + "');", true);
                    btnConciliarPagoOficina.Visible = false;
                }
                //Si cuenta con mas de 1 registro quiere decir que esta persona tiene varios certificados pero ninguno de ellos esta vigente
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El cliente no tiene certificados vigentes en la compañía" + "');", true);
                    btnConciliarPagoOficina.Visible = false;
                }
            }
            //Si no se encontraron registros quiere decir que esta persona no cuenta con certificados en la compañia
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El cliente no tiene ningún certificado en la compañía" + "');", true);
                btnConciliarPagoOficina.Visible = false;
            }
        }
        Session["dtPagosOficina"] = dtPagosOficina;
    }

    protected void btnConciliarPagoOficina_Click(object sender, EventArgs e)
    {
        //Si no ha seleccionado la agencia no podra aplicar los pagos
        if (ddlAgencia.SelectedValue.ToString() != "")
        {
            //Evento para aplicar los pagos por oficina 
            ConciliarPagoOficina();
            Response.RedirectToRoute("conciliacion");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione la agencia" + "');", true);
        }
    }
    #endregion

    #region Realizar devolución
    //Evento para seleccionar los pagos a devolver 
    protected void chkSeleccionarDevolucion_OnCheckedChanged(object sender, EventArgs e)
    {
        double aplPagoId = 0;
        double valorDevolucion = 0;
        double valorTotalDevolucionMom1 = 0;
        DateTime fechaVigencia;
        List<double> ltaplPagoId = new List<double>();
        List<DateTime> ltaFechaVigencia = new List<DateTime>();
        rbtlMarca.Visible = false;
        btnGuardarAplicacionesDevolucion.Visible = true;
        try
        {
            //Recorre la tabla de los pagos por oficina 
            foreach (GridViewRow row in grvTablaHistorialPagosPorOficina.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccionarDevolucion") as CheckBox;

                //Entra solo si el pago que se esta recorriendo esta seleccionado
                if (check.Checked)
                {
                    //muestra las opciones de devolución parcial o completa
                    rbtlMarca.Visible = true;
                    //Id de pago seleccionado para posteriormente agregarlo en una lista
                    aplPagoId = double.Parse(row.Cells[2].Text);
                    //Valor del pago seleccionado
                    valorDevolucion = double.Parse(row.Cells[4].Text);
                    //Vigencia del pago
                    fechaVigencia = DateTime.Parse(row.Cells[7].Text);
                    //Suma el valor de todos los pagos seleccionados
                    valorTotalDevolucionMom1 += valorDevolucion;
                    //lista que almacena el id de los pagos
                    ltaplPagoId.Add(aplPagoId);
                    //Lista para almacenar las vigencias
                    ltaFechaVigencia.Add(fechaVigencia);
                }
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Lo sentimos, se ha producido un error al seleccionar el pago" + "');", true);
        }
        // Se envian por session las listas y el valor de todos los pagos seleccionados
        Session["ltaplPagoId"] = ltaplPagoId;
        Session["valorTotalDevolucionMom1"] = valorTotalDevolucionMom1;
        Session["ltaFechaVigencia"] = ltaFechaVigencia;
    }

    protected void btnGuardarAplicacionesDevolucion_Click(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();
        List<double> ltaplPagoId = (List<double>)Session["ltaplPagoId"];
        List<DateTime> ltaFechaVigencia = (List<DateTime>)Session["ltaFechaVigencia"];
        double valorTotalDevolucionMom1 = (double)Session["valorTotalDevolucionMom1"];
        DateTime fechaVigencia = new DateTime();
        DataTable dtConsultarInsertarDevolucionPrimaMomento1 = new DataTable();
        try
        {
            //Pregunta si la devolución es parcial
            if (rbtlMarca.SelectedValue.ToString() == "1")
            {
                //Pregunta si el valor, las observaciones y el tipo de devolución son diferentes de vacios
                if (txtValorDevolucion.Text != "" && txtObservacionesDevolcion.Text != "" && ddlEstadoDevolucion.SelectedValue.ToString() != "")
                {
                    int count = 0;
                    try
                    {
                        //Recorre la tabla de plagos por oficina para identificar cuantos pagos fueron seleccionados
                        foreach (GridViewRow row in grvTablaHistorialPagosPorOficina.Rows)
                        {
                            CheckBox check = row.FindControl("chkSeleccionarDevolucion") as CheckBox;
                            if (check.Checked)
                            {
                                count++;
                            }
                        }
                        //Consultar la localidad del tercero
                        int dep_Id = AdministrarDevolucionDePrima.ConsultarLocalidadPorCedula(int.Parse(txtConsultarPagoOficina.Text));
                        //Asigna en una variable el valor ingresado como devolución
                        double valorDevolucion = double.Parse(txtValorDevolucion.Text);
                        //Multiplica el valor de la devolución por la cantidad de pagos a los que se les va a realizar dicha devolcuón
                        double valorTotalDevolucion = valorDevolucion * count;

                        /*Insertar la devolucion en su primer momento, unificando las aplicaciones que se encontraban como devolucion de prima
                         *y pregunta si esta devolución la tramitara Torres guarin o la compañia */
                        if (int.Parse(ddlEstadoDevolucion.SelectedValue.ToString()) == 1)
                        {
                            dtConsultarInsertarDevolucionPrimaMomento1 = AdministrarDevolucionDePrima.InsertarDevolucionDePrimaMomento1(int.Parse(txtConsultarPagoOficina.Text), int.Parse(ddlProductoOficina.SelectedValue.ToString()), dep_Id, valorTotalDevolucion, 1, 0);
                        }
                        else
                        {
                            dtConsultarInsertarDevolucionPrimaMomento1 = AdministrarDevolucionDePrima.InsertarDevolucionDePrimaMomento1(int.Parse(txtConsultarPagoOficina.Text), int.Parse(ddlProductoOficina.SelectedValue.ToString()), dep_Id, valorTotalDevolucion, 4, 2);
                        }

                        //Recorre la lista con los id de los pagos
                        foreach (int Id in ltaplPagoId)
                        {
                            //Insertar el id del pago de cada una de las filas que fueron seleccionadas con el id de la devolucion ingresada anteriormente
                            DataTable dtspInsetarAplicacionPagoDevolucion = new DataTable();
                            dtspInsetarAplicacionPagoDevolucion = AdministrarDevolucionDePrima.InsetarAplicacionPagoDevolucion(Id, int.Parse(dtConsultarInsertarDevolucionPrimaMomento1.Rows[0]["dev_Id"].ToString()));

                            //le asigna el valor y la observación ingresada a cada uno de los pagos seleccionados
                            DataTable dtGuardarAplicacionDevolucion = new DataTable();
                            dtGuardarAplicacionDevolucion = objPago.ActualizarValorYObservacionDevolucion(Id, double.Parse(txtValorDevolucion.Text), txtObservacionesDevolcion.Text, int.Parse(ddlEstadoDevolucion.SelectedValue.ToString()), 0);
                        }
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Lo sentimos, se ha producido un error, por favor asegurese de haber seleccionado el producto" + "');", true);
                    }

                    //Lista de nuevos los certificados del cliente
                    DataTable dtPagosOficina = new DataTable();
                    dtPagosOficina = objPago.ConsultarPagoPorOficina(double.Parse(txtConsultarPagoOficina.Text));
                    grvTablaPagosOficina.DataSource = dtPagosOficina;
                    grvTablaPagosOficina.DataBind();

                    //Lista de nuevo todos los pagos con los nuevos cambios
                    DataTable dtHistorialPago = new DataTable();
                    dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, double.Parse(txtConsultarPagoOficina.Text), 0, 0);
                    grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
                    grvTablaHistorialPagosPorOficina.DataBind();

                    lblValorDevolución.Visible = false;
                    lblObservacionesDevolcion.Visible = false;
                    txtValorDevolucion.Text = "";
                    txtObservacionesDevolcion.Text = "";
                    txtValorDevolucion.Visible = false;
                    lblEstadoDevolucion.Visible = false;
                    txtObservacionesDevolcion.Visible = false;
                    btnGuardarAplicacionesDevolucion.Visible = false;

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Los datos se guardaron correctamente" + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Los datos no están completos" + "');", true);
                }
            }
            //Pregunta si la devolución es completa
            if (rbtlMarca.SelectedValue.ToString() == "2")
            {
                //Lista de nuevos los certificados del cliente
                DataTable dtPagosOficina = new DataTable();
                dtPagosOficina = objPago.ConsultarPagoPorOficina(double.Parse(txtConsultarPagoOficina.Text));
                grvTablaPagosOficina.DataSource = dtPagosOficina;
                grvTablaPagosOficina.DataBind();
                int bandera = 0;
                //Recorre los certificados del cliente
                foreach (DataRow dtCertificado in dtPagosOficina.Rows)
                {
                    //Pregunta si alguno de ellos es vigente
                    if (dtCertificado["Estado"].ToString() == "VIGENTE")
                    {
                        //Asigna un valor a la bandera para informar que si posee certificados vigentes
                        bandera = 1;
                        //Pregunta si hay un numero de cedula, un producto y un convenio seleccionado
                        if (txtConsultarPagoOficina.Text != "" && ddlProductoOficina.SelectedValue.ToString() != "" && ddlConvenioPago.SelectedValue.ToString() != "")
                        {
                            //Consulta la localidad del cliente
                            int dep_Id = AdministrarDevolucionDePrima.ConsultarLocalidadPorCedula(int.Parse(txtConsultarPagoOficina.Text));
                            //Crea un devolución ya tramitada por el valor total de todos los pagos
                            dtConsultarInsertarDevolucionPrimaMomento1 = AdministrarDevolucionDePrima.InsertarDevolucionDePrimaMomento1(int.Parse(txtConsultarPagoOficina.Text), int.Parse(ddlProductoOficina.SelectedValue.ToString()), dep_Id, valorTotalDevolucionMom1, 4, 2);
                            foreach (int Id in ltaplPagoId)
                            {
                                //Insertar el id del pago de cada una de las filas que fueron seleccionadas con el id de la devolucion ingresada anteriormente
                                DataTable dtspInsetarAplicacionPagoDevolucion = new DataTable();
                                dtspInsetarAplicacionPagoDevolucion = AdministrarDevolucionDePrima.InsetarAplicacionPagoDevolucion(Id, int.Parse(dtConsultarInsertarDevolucionPrimaMomento1.Rows[0]["dev_Id"].ToString()));
                            }

                            //Recorre la lista de fechas para identificar desde que fecha en adelante se realizara la reestructuración
                            foreach (DateTime fecha in ltaFechaVigencia)
                            {
                                int count = 0;
                                if (count == 0 || fecha < fechaVigencia)
                                {
                                    fechaVigencia = fecha;
                                    count++;
                                }
                            }

                            //Trae la información de los pagos ordenada en forma descendente
                            DataTable dtIdPagosMayorAFecha = new DataTable();
                            dtIdPagosMayorAFecha = objPago.ConsultarAplicacionesMayoresFechaVigencia(fechaVigencia, double.Parse(txtConsultarPagoOficina.Text));

                            foreach (DataRow dt in dtIdPagosMayorAFecha.Rows)
                            {
                                //Actualiza las aplicaciones necesarias al estado reversión
                                objPagos.ActualizarReversionYBorradoDeAplicacion(double.Parse(dt["aplPago_Id"].ToString()), 0);
                            }

                            try
                            {
                                /*Agrupa los valores de los pagos por pago_Id y numero de recibo con el fin de asignar 
                                los mismos valores a los registros ya reestructurados*/
                                DataTable dtConsultarValorAgrupadoDePago = new DataTable();
                                dtConsultarValorAgrupadoDePago = objPago.ConsultarValorAgrupadoDePago(fechaVigencia, double.Parse(txtConsultarPagoOficina.Text), double.Parse(ddlProductoOficina.SelectedValue.ToString()));

                                //Recorre los pagos agrupados para reestructurar las aplicaciones
                                foreach (DataRow dt in dtConsultarValorAgrupadoDePago.Rows)
                                {
                                    double pagos = 0;
                                    pagos = double.Parse(dt["pagoMes"].ToString());
                                    //Recorre el while siempre y cuando el pago aun tenga un valor mayor a 0
                                    while (pagos > 0)
                                    {
                                        DataTable dtProductoARealizarPago = new DataTable();
                                        double valorAplicar = 0;
                                        //Consulta el producto al cual se le debe hacer la reversión y se le envia el producto de su certificado actual
                                        dtProductoARealizarPago = objPagos.ConsultarProductoParaPagoReversion(double.Parse(txtConsultarPagoOficina.Text), int.Parse(ddlConvenioPago.SelectedValue.ToString()), double.Parse(ddlProductoOficina.SelectedValue.ToString()));
                                        if (double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()) > 0)
                                        {
                                            //Asigna en una variable el valor que se debe aplicar, traido desde dtProductoARealizarPago
                                            valorAplicar = double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                                            //pregunta si el pago es menor a lo que se le debe pagar, en caso de ser asi el valor a aplicar es igual a la variable pago
                                            if (pagos < double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()))
                                            {
                                                valorAplicar = pagos;
                                            }
                                            //Ingresa la aplicacion y le asigna a esta el rec_Id calculado por el sistema
                                            objPago.IngresarAplicacionPagoCliente(double.Parse(txtConsultarPagoOficina.Text), int.Parse(dt["pago_Id"].ToString()), int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()),
                                            Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar, int.Parse(ddlConvenioPago.SelectedValue.ToString()), 0, double.Parse(dt["pago_Recibo"].ToString()), double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString()));

                                            //Le resta a la variable pago, el valor que se aplico anteriormente
                                            pagos -= double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                                        }
                                    }
                                }
                            }
                            catch
                            {

                            }

                            foreach (DataRow dt in dtIdPagosMayorAFecha.Rows)
                            {
                                //Borra los pagos posteriores a la devolución ya que estos fueron reestructurados
                                objPagos.ActualizarReversionYBorradoDeAplicacion(double.Parse(dt["aplPago_Id"].ToString()), 1);
                            }

                            //Lista de nuevo los certificados de cliente
                            dtPagosOficina = objPago.ConsultarPagoPorOficina(double.Parse(txtConsultarPagoOficina.Text));
                            grvTablaPagosOficina.DataSource = dtPagosOficina;
                            grvTablaPagosOficina.DataBind();

                            //Lista de nuevos el historial de pagos del cliente
                            DataTable dtHistorialPago = new DataTable();
                            dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, double.Parse(txtConsultarPagoOficina.Text), 0, 0);
                            grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
                            grvTablaHistorialPagosPorOficina.DataBind();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Los datos se han guardado correctamente" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Asegurese de seleccionar el producto, el convenio y tener un documento valido" + "');", true);
                        }
                    }
                }
                //Sin variable esta en 0 quiere decir que no tiene certificados vigentes
                if (bandera == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El cliente no tiene un certificado vigente por el producto seleccionado, por lo que no puede realizar esta devolución" + "');", true);
                }
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Se ha producido un error al tratar de guardar la devolución" + "');", true);
        }
    }

    protected void ddlCompaniaOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Si co´mpañia difernete de vacio se listaran los productos y el historial de pagos del cliente
        if (ddlCompaniaOficina.SelectedValue.ToString() != "")
        {
            DataTable dtProductoOficina = new DataTable();
            dtProductoOficina = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompaniaOficina.SelectedValue.ToString()));
            ddlProductoOficina.DataTextField = "pro_Nombre";
            ddlProductoOficina.DataValueField = "pro_Id";
            ddlProductoOficina.DataSource = dtProductoOficina;
            ddlProductoOficina.DataBind();
            ddlProductoOficina.Items.Insert(0, new ListItem("", ""));

            DataTable dtHistorialPago = new DataTable();
            dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, double.Parse(txtConsultarPagoOficina.Text), 0, int.Parse(ddlCompaniaOficina.SelectedValue.ToString()));
            grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
            grvTablaHistorialPagosPorOficina.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione la compañía" + "');", true);
        }
    }
    protected void ddlProductoOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Pregunta si la compañia y el producto ya fueron seleccionados
        if (ddlCompaniaOficina.SelectedValue.ToString() != "" && ddlProductoOficina.SelectedValue.ToString() != "")
        {
            DataTable dtHistorialPago = new DataTable();
            dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, double.Parse(txtConsultarPagoOficina.Text), int.Parse(ddlProductoOficina.SelectedValue.ToString()), int.Parse(ddlCompaniaOficina.SelectedValue.ToString()));
            grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
            grvTablaHistorialPagosPorOficina.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione el producto" + "');", true);
        }
    }

    //Evento para identificar si se va a realizar una devolución parcial o completa
    protected void rbtlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtlMarca.SelectedValue.ToString() == "1")
        {
            lblObservacionesDevolcion.Visible = true;
            txtObservacionesDevolcion.Visible = true;
            ddlEstadoDevolucion.Visible = true;
            lblValorDevolución.Visible = true;
            txtValorDevolucion.Visible = true;
            lblEstadoDevolucion.Visible = true;
            btnGuardarAplicacionesDevolucion.Visible = true;
        }
        if (rbtlMarca.SelectedValue.ToString() == "2")
        {
            lblObservacionesDevolcion.Visible = false;
            txtObservacionesDevolcion.Visible = false;
            ddlEstadoDevolucion.Visible = false;
            lblValorDevolución.Visible = false;
            txtValorDevolucion.Visible = false;
            lblEstadoDevolucion.Visible = false;
            btnGuardarAplicacionesDevolucion.Visible = true;
        }
    }
    #endregion

    #endregion

    #region Informes
    protected void txtMesDescuento_TextChanged(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();
        if (txtAnioDescuento.Text == "" || txtMesDescuento.Text == "")
        {
            //Si el mes y el año esta vacio trae todo el informe por convenio
            DataTable dtInformeAplicacionPagos = new DataTable();
            dtInformeAplicacionPagos = objPago.InformeAplicacionPagos(int.Parse(ddlConvenio.SelectedValue.ToString()));
            grvInformePagos.DataSource = dtInformeAplicacionPagos;
            grvInformePagos.DataBind();
            OcultarColumnasInformePagos();

            Session["dtConsultarHistorialPagos"] = dtInformeAplicacionPagos;
        }
        else
        {
            //Trae el informe por convenio y fechas
            DataTable dt = new DataTable();
            dt = objPago.InformeAplicacionPagosBusqueda(int.Parse(ddlConvenio.SelectedValue.ToString()), DateTime.Parse(txtAnioDescuento.Text).Date, DateTime.Parse(txtMesDescuento.Text).Date, 0, 0);
            grvInformePagos.DataSource = dt;
            grvInformePagos.DataBind();
            Session["dtConsultarHistorialPagos"] = dt;
            dt = new DataTable();
            OcultarColumnasInformePagos();
        }
    }
    protected void ddlCompaniaPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();
        DataTable dtProductoPago = new DataTable();
        if (ddlCompaniaPago.SelectedValue.ToString() != "")
        {
            //Carga el ddl dep roductos segun la compañia seleccionada
            dtProductoPago = objPago.ConsultarCompaniaEnConciliacion(int.Parse(ddlCompaniaPago.SelectedValue.ToString()));
            ddlProductoPago.DataTextField = "pro_Nombre";
            ddlProductoPago.DataValueField = "pro_Id";
            ddlProductoPago.DataSource = dtProductoPago;
            ddlProductoPago.DataBind();
            ddlProductoPago.Items.Insert(0, new ListItem("", ""));

            //Trae el informe por convenio, fechas y compañia
            DataTable dtHistorialCompania = new DataTable();
            dtHistorialCompania = objPago.InformeAplicacionPagosBusqueda(int.Parse(ddlConvenio.SelectedValue.ToString()), DateTime.Parse(txtAnioDescuento.Text), DateTime.Parse(txtMesDescuento.Text), int.Parse(ddlCompaniaPago.SelectedValue.ToString()), 0);
            grvInformePagos.DataSource = dtHistorialCompania;
            grvInformePagos.DataBind();
            Session["dtConsultarHistorialPagos"] = dtHistorialCompania;
            dtHistorialCompania = new DataTable();
            OcultarColumnasInformePagos();

        }
        else
        {
            txtMesDescuento_TextChanged(sender, e);
        }

        Session["dtProductoPago"] = dtProductoPago;
    }

    protected void ddlProductoPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pagos objPago = new Pagos();
        if (ddlProductoPago.SelectedValue.ToString() != "")
        {
            //Trae el informe por convenio, fechas, compañia y producto
            DataTable dtHistorialProducto = new DataTable();
            dtHistorialProducto = objPago.InformeAplicacionPagosBusqueda(int.Parse(ddlConvenio.SelectedValue.ToString()), DateTime.Parse(txtAnioDescuento.Text), DateTime.Parse(txtMesDescuento.Text), int.Parse(ddlCompaniaPago.SelectedValue.ToString()), int.Parse(ddlProductoPago.SelectedValue.ToString()));
            grvInformePagos.DataSource = dtHistorialProducto;
            grvInformePagos.DataBind();
            Session["dtConsultarHistorialPagos"] = dtHistorialProducto;
            dtHistorialProducto = new DataTable();
            OcultarColumnasInformePagos();

        }
        else
        {
            ddlCompaniaPago_SelectedIndexChanged(sender, e);
        }
    }
    protected void btnExportarInformePagos_Click(object sender, System.EventArgs e)
    {
        //Genera un excel con la información cargada segun los parametros
        DataTable dt = (DataTable)Session["dtConsultarHistorialPagos"];
        DataTable dtConsultarHistorialPagos = (DataTable)Session["dtConsultarHistorialPagos"];
        if (dtConsultarHistorialPagos.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtConsultarHistorialPagos, "CONCILIACIÓN " + dt.Rows[0]["Convenio"].ToString());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "No hay Informe de Conciliación para exportar" + "');", true);
        }
    }
    #endregion

    #region Seleccion y busqueda de soportes bancarios y recibo

    #region Soporte bacario para conciliación por pagaduria
    protected void chkSeleccionar_OnCheckedChanged(object sender, EventArgs e)
    {
        double valorTotal = 0;
        List<long> ltSoportes = new List<long>();
        //Recorre la tabla de soportes
        foreach (GridViewRow row in grvSoportesPagaduria.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

            if (check.Checked)
            {
                double valor = 0;
                valor = double.Parse(row.Cells[3].Text);
                //Valor total de los soportes selccionados
                valorTotal += valor;

                //Agrega en una lista los id de los soportes seleccionados
                idConciliacion = int.Parse(row.Cells[1].Text);
                ltSoportes.Add(idConciliacion);
            }
        }

        //Asgina a un txt el valor total de los soportes 
        txtSoportes.Text = valorTotal.ToString();

        //Asigna en una variable el valor de participación
        double totalValorParticipo = double.Parse(Session["totalValorParticipo"].ToString());

        //Suma el valor de participación mas el total del soporte 
        double totalValorSoporte = valorTotal + totalValorParticipo;
        // en variable asigna el valor total del listado subido
        double totalListado = double.Parse(txtTotalListado.Text);
        //Resta el total del listado contra la suma del participación mas total de los soportes
        double valorFinalListado = totalListado - totalValorSoporte;

        /*Pregunta si el resultado es menor a 1 pero mayor a -1, esto con el fin de 
         permitir la conciliación si la diferencia es menor a 1 peso*/
        if (valorFinalListado <= 1 && valorFinalListado >= -1)
        {
            btnConciliar.Enabled = true;
        }
        else
        {
            btnConciliar.Enabled = false; //false
        }
        Session["ltSoportes"] = ltSoportes;
    }
    #endregion

    #region Soporte Bancario por oficina
    protected void chkSeleccionarPagosOficina_OnCheckedChanged(object sender, EventArgs e)
    {
        double valorSoportePagoOficina = 0;
        double valorSoportePagoOficinaTotal = 0;
        double valorSoportePagoAplicado = 0;

        //Evento para obtener el valor total a conciliar
        foreach (GridViewRow row in grvSoporteBancarioPagoOficina.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

            if (check.Checked == true)
            {
                valorSoportePagoOficina = double.Parse(row.Cells[2].Text);
                valorSoportePagoAplicado = double.Parse(row.Cells[8].Text);

                    //valorSoportePagoOficinaTotal += valorSoportePagoOficina;

                    valorSoportePagoOficinaTotal += valorSoportePagoOficina - valorSoportePagoAplicado;

                btnConciliarPagoOficina.Enabled = true;
            }
        }
        txtSaldoConciliar.Text = valorSoportePagoOficinaTotal.ToString();
    }
    #endregion

    #region Selección, impresión y busqueda de recibo
    protected void chkSeleccionarRecibos_OnCheckedChanged(object sender, EventArgs e)
    {
        int Id = 0;
        Session["IdRecibo"] = null;
        // Recorrer el Grid para identificar cual fue la fila que se selecciono
        foreach (GridViewRow row in grvConsultarRecibos.Rows)
        {
            RadioButton check = row.FindControl("chkSeleccionarRecibos") as RadioButton;
            Id = int.Parse(row.Cells[1].Text);
            // Obtener el Id de Label fila seleccionada
            if (check.Checked)// row.Cells[1].Text != Session["IdDevolucion"].ToString() )
            {
                if (Session["IdReciboAnterior"] == null || Session["IdRecibo"] == null)
                {
                    /*Variable de Session para almacenar la id de Devolucion seleccionada 
                    para el caso de que requiera ir al modal de Aplicaciones asociadas a esta*/
                    Session["IdRecibo"] = Id;
                }
                else if (row.Cells[1].Text != Session["IdReciboAnterior"].ToString())
                {
                    Session["IdRecibo"] = Id;
                }
            }
        }
        Session["IdReciboAnterior"] = Session["IdRecibo"];

        foreach (GridViewRow row in grvConsultarRecibos.Rows)
        {
            RadioButton check = row.FindControl("chkSeleccionarRecibos") as RadioButton;

            // Obtener el Id de Label fila seleccionada
            if (row.Cells[1].Text != Session["IdRecibo"].ToString())
            {
                check.Checked = false;
            }
            else
            {
                check.Checked = true;
            }
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //Entrara solo si hay un numero de cedula o de recibo
        if (txtRecibo.Text.ToString() != string.Empty || txtCedula.Text.ToString() != string.Empty)
        {
            DataTable dtConsultarReciboCedula = new DataTable();
            string recibo = (txtRecibo.Text.ToString() == string.Empty) ? "0" : txtRecibo.Text.ToString();
            string cedula = (txtCedula.Text.ToString() == string.Empty) ? "0" : txtCedula.Text.ToString();
            cedula = cedula.ToUpper();
            //Trae información de recibos segun los parametros enviados
            dtConsultarReciboCedula = objPagos.ConsultarRecibosConSeleccionables(0, 0, 0, 0, 0, recibo, cedula);
            grvConsultarRecibos.DataSource = dtConsultarReciboCedula;
            grvConsultarRecibos.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Ingrese un número de identificación o un recibo" + "');", true);
        }

    }


    protected void btnImprimirRecibo_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("reciboCaja");
    }
    #endregion

    #endregion

    #region Eventos de la tabla cedulas no coincidentes
    protected void rowCancelEditEvent(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
        grvCedulasNoCoincidentes.EditIndex = -1;
        grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
        grvCedulasNoCoincidentes.DataBind();
        Session["dtInconsistencias"] = dtInconsistencias;
    }

    protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtExcelInconsistencias = (DataTable)Session["dtExcelInconsistencias"];
        DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
        int indexSeleccionado = e.RowIndex;
        dtExcelInconsistencias.Rows.RemoveAt(indexSeleccionado);
        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "el index eliminado fue el" + indexSeleccionado + "');", true);
        grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
        grvCedulasNoCoincidentes.DataBind();

        Session["dtExcelInconsistencias"] = dtExcelInconsistencias;
        Session["dtInconsistencias"] = dtInconsistencias;
    }

    protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
            grvCedulasNoCoincidentes.EditIndex = e.NewEditIndex;
            grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
            grvCedulasNoCoincidentes.DataBind();
            Session["dtInconsistencias"] = dtInconsistencias;
        }
        else
        {
            DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
            grvCedulasNoCoincidentes.EditIndex = e.NewEditIndex;
            grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
            grvCedulasNoCoincidentes.DataBind();
            Session["dtInconsistencias"] = dtInconsistencias;
        }
    }

    protected void rowUpdatetingEvent(object sender, GridViewUpdateEventArgs e)
    {
        bool modifico = (bool)Session["modifico"];
        DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
        modifico = true;
        dtInconsistencias.Rows[e.RowIndex]["TER_ID"] = ((TextBox)this.grvCedulasNoCoincidentes.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        dtInconsistencias.Rows[e.RowIndex]["NOMBRE"] = ((TextBox)this.grvCedulasNoCoincidentes.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        dtInconsistencias.Rows[e.RowIndex]["APELLIDOS"] = ((TextBox)this.grvCedulasNoCoincidentes.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        dtInconsistencias.Rows[e.RowIndex]["VALOR"] = ((TextBox)this.grvCedulasNoCoincidentes.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        grvCedulasNoCoincidentes.EditIndex = -1;
        grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
        grvCedulasNoCoincidentes.DataBind();

        Session["modifico"] = modifico;
        Session["dtInconsistencias"] = dtInconsistencias;
    }
    #endregion

    #region Paginadores
    /*Eventos de paginadores con el fin de cambiar de pagina sin perder los filtros ya seleccionados*/
    protected void grvConsultarRecibos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvConsultarRecibos.PageIndex = e.NewPageIndex;

        DataTable dtConsultarRecibos = new DataTable();
        dtConsultarRecibos = (DataTable)Session["dtConsultarRecibos"];
        grvConsultarRecibos.DataSource = dtConsultarRecibos;
        grvConsultarRecibos.DataBind();
    }


    protected void grvTablaHistorialPagosPorOficina_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Pagos objPago = new Pagos();
        grvTablaHistorialPagosPorOficina.PageIndex = e.NewPageIndex;

        DataTable dtHistorialPago = new DataTable();
        dtHistorialPago = objPago.InformeAplicacionPagosPorOficina(0, int.Parse(txtConsultarPagoOficina.Text), 0, 0);
        grvTablaHistorialPagosPorOficina.DataSource = dtHistorialPago;
        grvTablaHistorialPagosPorOficina.DataBind();
    }



    protected void grvInformePagos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvInformePagos.PageIndex = e.NewPageIndex;

        DataTable dtConsultarHistorialPagos = new DataTable();
        dtConsultarHistorialPagos = (DataTable)Session["dtConsultarHistorialPagos"];
        grvInformePagos.DataSource = dtConsultarHistorialPagos;
        grvInformePagos.DataBind();
    }
    #endregion

    #endregion

    #region Metodos

    #region Función para ocultas columnas en la sección de informes
    protected void OcultarColumnasInformePagos()
    {
        //Captura el encabezado de la columna
        grvInformePagos.HeaderRow.Cells[3].Visible = false;
        //Recorre las filas de la columna y las oculta una a una
        foreach (GridViewRow row in grvInformePagos.Rows)
        {
            row.Cells[3].Visible = false;
        }

        grvInformePagos.HeaderRow.Cells[5].Visible = false;
        foreach (GridViewRow row in grvInformePagos.Rows)
        {
            row.Cells[5].Visible = false;
        }
    }
    #endregion

    #region Conciliación

    #region Verificar si existen cedulas no condidentes
    protected void ConsultarCedulasNoCoincidentes()
    {
        Pagos objPago = new Pagos();
        DataTable dtExcel = (DataTable)Session["dtExcel"];
        DataTable dtInconsistencias = new DataTable();
        bool modifico = (bool)Session["modifico"];
        DataTable dtCertificadosConciliacion = new DataTable();
        DataTable dtCausa = new DataTable();

        //Se cargan los certificados segun el convenio en el dt
        dtCertificadosConciliacion = objPago.ConsultarCertificadosConciliacion(int.Parse(ddlConvenio.SelectedValue.ToString()));

        //Se copia el dtExcel en el dtExcelInconsistencias
        DataTable dtExcelInconsistencias = dtExcel.Copy();

        if (modifico == false)
        {
            //Se clona la estructura del dtExcel al dtInconsistencias
            dtInconsistencias = dtExcel.Clone();
            dtInconsistencias.Columns.Add("CAUSA", typeof(String));
            //Foreach para recorrer el dtExcel
            foreach (DataRow fila in dtExcel.Rows)
            {
                //Variable cedula de tipo string para almacenar el TER_ID de la fila recorrida
                string cedula = fila["TER_ID"].ToString();
                //Guarda en el DataRow test el registro que contenga la cedula enviada
                DataRow[] test = dtCertificadosConciliacion.Select("TER_ID = " + cedula);
                //Si test no trae nada
                if (test.Length == 0)
                {
                    //Guarda en el dtInconsistencias la fila (fila no encontrada en base de datos)
                    dtInconsistencias.ImportRow(fila);

                    //Establece la causa de una cedula no coincidente
                    dtCausa = objPago.spConsultarCausasCedulasNoCoincidentes(cedula, int.Parse(ddlConvenio.SelectedValue.ToString()), 1);
                    if (dtCausa.Rows.Count != 0)
                    {
                        dtCausa = objPago.spConsultarCausasCedulasNoCoincidentes(cedula, int.Parse(ddlConvenio.SelectedValue.ToString()), 2);
                        if (dtCausa.Rows.Count != 0)
                        {
                            dtCausa = objPago.spConsultarCausasCedulasNoCoincidentes(cedula, int.Parse(ddlConvenio.SelectedValue.ToString()), 3);
                            if (dtCausa.Rows.Count != 0)
                            {
                                dtCausa = objPago.spConsultarCausasCedulasNoCoincidentes(cedula, int.Parse(ddlConvenio.SelectedValue.ToString()), 4);
                                if (dtCausa.Rows.Count == 0)
                                {
                                    dtInconsistencias.Rows[dtInconsistencias.Rows.Count - 1]["CAUSA"] = "El convenio no permite certificados por el producto vigente del cliente";
                                }
                            }
                            else
                            {
                                dtInconsistencias.Rows[dtInconsistencias.Rows.Count - 1]["CAUSA"] = "El cliente no tiene certificados vigentes por este convenio";
                            }
                        }
                        else
                        {
                            dtInconsistencias.Rows[dtInconsistencias.Rows.Count - 1]["CAUSA"] = "El cliente no tiene certificados vigentes";
                        }
                    }
                    else
                    {
                        dtInconsistencias.Rows[dtInconsistencias.Rows.Count - 1]["CAUSA"] = "El cliente no existe";
                    }

                    //Guarda en el DataRow erase el registro no encontrado
                    DataRow[] erase = dtExcelInconsistencias.Select("TER_ID = " + fila["TER_ID"]);
                    //Borra del dtExcelInconsistencias la fila
                    dtExcelInconsistencias.Rows.Remove(erase[0]);
                }
            }
            Session["dtInconsistencias"] = dtInconsistencias;
        }

        if (dtInconsistencias.Rows.Count != 0)
        {
            modifico = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Existen " + +dtInconsistencias.Rows.Count + " cedulas No Concidentes" + "');", true);
            //Carga el grvCedulasNoCoincidentes con los datos del dtInconsistencias
            grvCedulasNoCoincidentes.DataSource = dtInconsistencias;
            grvCedulasNoCoincidentes.DataBind();
            ChkConciliarCedulasNoConcidentes.Visible = true;
            legend.Visible = true;
        }
        else
        {
            RealizarAplicacionPagos();
        }

        Session["dtExcel"] = dtExcel;
        Session["dtExcelInconsistencias"] = dtExcelInconsistencias;
        Session["modifico"] = modifico;
        Session["dtInconsistencias"] = dtInconsistencias;
        Session["dtCertificadosConciliacion"] = dtCertificadosConciliacion;
    }
    #endregion

    #region Redirecciona a devoluciones y aplicaciones
    protected void Conciliar()
    {
        Pagos objPago = new Pagos();
        //Session con los pagos a conciliar
        DataTable dtExcelInconsistencias = (DataTable)Session["dtExcelInconsistencias"];
        //Session con incosistencias
        DataTable dtInconsistencias = (DataTable)Session["dtInconsistencias"];
        DataTable dtCertificadosConciliacion = (DataTable)Session["dtCertificadosConciliacion"];
        DataTable dtDevolucionPrima = dtInconsistencias.Clone();
        DataRow drTemp = dtExcelInconsistencias.NewRow();

        //Se recorren las inconsistencias para detectar que cedulas se corrigierón
        foreach (DataRow dr in dtInconsistencias.Rows)
        {
            DataRow[] test = dtCertificadosConciliacion.Select("TER_ID = " + dr["TER_ID"].ToString());
            /*Si no trae nada la consulta llevara el regist´ro a un dt para posteriormente ser 
            enviado a devolución de prima*/
            if (test.Length == 0)
            {
                dtDevolucionPrima.ImportRow(dr);
            }
            else
            // Se corrigio el registro y se almacena en un dt para ser posterior mente aplicado
            {
                drTemp = dtExcelInconsistencias.NewRow();
                drTemp.ItemArray = dr.ItemArray;
                dtExcelInconsistencias.Rows.Add(drTemp);
            }
        }
        grvCedulasNoCoincidentes.Dispose();
        grvCedulasNoCoincidentes.DataBind();

        //Metodo para aplicar devoluciones
        RealizarAplicacionDeDevoluciones(dtDevolucionPrima);
        //Metodo para aplicar pagos
        RealizarAplicacionPagos();

        Session["dtExcelInconsistencias"] = dtExcelInconsistencias;
        Session["dtInconsistencias"] = dtInconsistencias;
        AplicarNovedadesRetiro();
    }
    #endregion

    #region Verificar si el excel cumple con la estructura solicitada
    protected bool verificarExcel(DataTable dt)
    {
        //Variables del archio
        int columnas = 4;
        int i = 0;
        //Arreglo con estructura solicitada
        string[] cabeza = new string[] { "TER_ID", "NOMBRE", "APELLIDOS", "VALOR" };

        bool respuesta = true;
        //Pregunta si el dt tiene el numero de columnas solicitadas
        if (dt.Columns.Count == columnas)
        {
            //Recorre cada una de las columnas del dt enviado
            foreach (DataColumn column in dt.Columns)
            {
                //si el nombre de la columna es diferente a la del arreglo
                if (column.ColumnName != cabeza[i++])
                {
                    respuesta = false;
                }
            }
        }
        else
        {
            respuesta = false;
        }

        return respuesta;
    }
    #endregion

    #endregion

    #region Pagos por oficina
    protected void ConciliarPagoOficina()
    {
        Pagos objPago = new Pagos();
        int consecutivoPago = 0;
        List<double> ltSoportes = new List<double>();
        List<double> ltSopDetId = new List<double>();
        DataTable dtSopDetId = new DataTable();

        DataTable dtPagosOficina = (DataTable)Session["dtPagosOficina"];
        DataTable dtProductoARealizarPago = new DataTable();
        //Valor a conciliar
        double pago = int.Parse(txtValorAplicar.Text);
        DataTable dtIdPago = new DataTable();
        //Inserta el pago y trae su id
        dtIdPago = objPago.IngresarPagoCliente(int.Parse(dtPagosOficina.Rows[0]["Cedula"].ToString()), pago, DateTime.Now, int.Parse(ddlConvenioPago.SelectedValue.ToString()), 0, 1);
        //try
        //{
        //Recorre el while siempre y cuando el pago aun tenga un valor mayor a 0
        while (pago > 0)
        {
            //Consulta el producto para pago 
            dtProductoARealizarPago = objPago.ConsultarProductoParaPago(int.Parse(dtPagosOficina.Rows[0]["Cedula"].ToString()), int.Parse(ddlConvenioPago.SelectedValue));
            //Id del pago  insertado anteriormente                                                                                                                                                      
            consecutivoPago = int.Parse(dtIdPago.Rows[0]["pago_Id"].ToString());
            //El valor que se debe aplicar segun la vigencia
            double valorAplicar = double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
            //pregunta si el pago es menor a lo que se le debe pagar, en caso de ser asi el valor a aplicar es igual a la variable pago
            if (pago < double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()))
            {
                valorAplicar = pago;
            }
            //Se inserta la aplicación
            objPago.IngresarAplicacionPagoCliente(int.Parse(dtPagosOficina.Rows[0]["Cedula"].ToString()), consecutivoPago, int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()), Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar, int.Parse(ddlConvenioPago.SelectedValue), 0, 0, double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString())); //Inserta el pago en tabla NewAplicacionPago
            pago -= double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());

            //Busca si el cliente tiene noveades y la aplica en caso de cumplir su valor solicitado
            ActualizarNovedadesAplicadasPagos(int.Parse(dtPagosOficina.Rows[0]["Cedula"].ToString()), int.Parse(ddlConvenioPago.SelectedValue), int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()));
        }

        double valorTotalDetalle = 0;
        double idSoporteOficina = 0;
        double idSoporte = 0;
        double valorAplicado = int.Parse(txtValorAplicar.Text);
        foreach (GridViewRow row in grvSoporteBancarioPagoOficina.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

            if (check.Checked)
            {
                valorTotalDetalle = double.Parse(row.Cells[2].Text);
                idSoporte = double.Parse(row.Cells[6].Text);
                idSoporteOficina = double.Parse(row.Cells[7].Text);
                ltSoportes.Add(idSoporte);

                if (valorAplicado > 0)
                {
                    if(valorTotalDetalle >= valorAplicado)
                    {
                        objPago.ActualizarValorAplicadoSoporteBancario(idSoporte, valorAplicado);
                        //Crea un detalle por cada uno de los soportes seleccionados
                        dtSopDetId = objPago.CrearDetalleSoporteBancario(idSoporte, valorAplicado, idSoporteOficina, 1);
                    }
                    else
                    {
                        objPago.ActualizarValorAplicadoSoporteBancario(idSoporte, valorTotalDetalle);
                        //Crea un detalle por cada uno de los soportes seleccionados
                        dtSopDetId = objPago.CrearDetalleSoporteBancario(idSoporte, valorTotalDetalle, idSoporteOficina, 1);
                    }
                    valorAplicado = valorAplicado - valorTotalDetalle;
                }

                
                //Actualiza el estado del soporte bancario
                objPago.ActualizarEstadoSoporteBancario(idSoporte, 4);
                //Inserta en una lista el id del detalle
                ltSopDetId.Add(double.Parse(dtSopDetId.Rows[0]["sopdet_Id"].ToString()));
            }
        }

        //Crea el recibo de caja
        objPago.CrearRecibosCaja(int.Parse(ddlAgencia.SelectedValue.ToString()), int.Parse(ddlConvenioPago.SelectedValue), 1, int.Parse(dtPagosOficina.Rows[0]["Cedula"].ToString()), Session["nombreCreador"].ToString());

        DataTable dtConsultarSoporte = new DataTable();
        /*Recorre la lista con el fin de identificar que detalles se aplican a cada recibo 
        y si este es pagado a torres guarin o a la compañia*/
        foreach (int IdDetalle in ltSopDetId)
        {
            dtConsultarSoporte = objPago.ConsultarSopIdSoporteBancario(IdDetalle, 0);

            DataTable ConsultarReciboParaSoporte = new DataTable();
            ConsultarReciboParaSoporte = objPago.ConsultarReciboParaSoporte(int.Parse(ddlConvenioPago.SelectedValue.ToString()));
            foreach (DataRow dt in ConsultarReciboParaSoporte.Rows)
            {
                if (int.Parse(dtConsultarSoporte.Rows[0]["sop_TipoSoporteBancario"].ToString()) == 1)
                {
                    if (int.Parse(dtConsultarSoporte.Rows[0]["com_Id"].ToString()) == int.Parse(dt["com_Id"].ToString()))
                    {
                        objPago.InsertarNewSoportePorRecibo(int.Parse(dt["rec_Id"].ToString()), IdDetalle);
                    }
                }
                if (int.Parse(dtConsultarSoporte.Rows[0]["sop_TipoSoporteBancario"].ToString()) == 2)
                {
                    objPago.InsertarNewSoportePorRecibo(int.Parse(dt["rec_Id"].ToString()), IdDetalle);
                }
            }

        }
        //}
        //catch { };

        ChkConciliarCedulasNoConcidentes.Visible = false;
        legend.Visible = false;
        Session["ltSoportes"] = ltSoportes;
    }
    protected void ActualizarNovedadesAplicadasPagos(int Cedula, int Convenio, int porId)
    {
        //Metodo llamado en Realizar pagos con el fin de identificar y aplicar novedades
        Pagos objPago = new Pagos();
        DataTable dtActualizarNovedadesAplicadas = new DataTable();
        dtActualizarNovedadesAplicadas = objPago.ActualizarNovedadesAplicadas(Cedula, Convenio, porId);
    }
    #endregion

    #region Aplicar devoluciones
    protected void RealizarAplicacionDeDevoluciones(DataTable dtDevoluciones)
    {
        string proId;
        int consecutivoPago = 0;
        Pagos objPago = new Pagos();
        DataTable dtProductoARealizarPago = new DataTable();
        //Variable iniocializada en 1(PMI)
        string proIdCertificado = "1";

        //Trae los productos que el convenio posee
        DataTable dtConsultarProductosConvenio = new DataTable();
        dtConsultarProductosConvenio = objPago.ConsultarProductosConvenio(double.Parse(ddlConvenio.SelectedValue.ToString()));
        /*Si el convenio posee varios productos diferentes a Bolivar quiere decir que 
         * el dinero a devolver ira a producto devolución de prima*/
        if (dtConsultarProductosConvenio.Rows.Count > 0)
        {
            proIdCertificado = "100";
        }
        //Recorre las incinsistencias
        foreach (DataRow fila in dtDevoluciones.Rows)
        {
            //Valor a devolver
            double pago = double.Parse(fila["VALOR"].ToString());
            DataTable dtIdPago = new DataTable();
            //Inserta el pago y trae el id mas alto
            dtIdPago = objPago.IngresarPagoCliente(double.Parse(fila["TER_ID"].ToString()), pago, DateTime.Now, int.Parse(ddlConvenio.SelectedValue), 0, 0);
            //Consulta el producto al cual se le realizara la devolución
            proId = objPago.ConsultarProductoParaDevolucionDePrima(double.Parse(fila["TER_ID"].ToString()), int.Parse(ddlConvenio.SelectedValue));
            consecutivoPago = int.Parse(dtIdPago.Rows[0]["pago_Id"].ToString());

            //Si cuenta con certificados en el convenio asignara el dinero al producto traido por prioridad
            if (proId != null)
            {
                objPago.InsertarAplicacionPagoParaDevolucion(double.Parse(fila["TER_ID"].ToString()), consecutivoPago, proId, pago, 1, int.Parse(ddlConvenio.SelectedValue), 0);
            }
            //En caso de no ser asi enviara esta devolución al producto calculado inicialmente
            else
            {
                objPago.InsertarAplicacionPagoParaDevolucion(double.Parse(fila["TER_ID"].ToString()), consecutivoPago, proIdCertificado, pago, 1, int.Parse(ddlConvenio.SelectedValue), 0);
            }
        }
    }
    #endregion

    #region Realizar aplicaciones
    #region Aplicar Pagos
    public void RealizarAplicacionPagos()
    {
        Pagos objPago = new Pagos();
        List<long> ltSoportes = (List<long>)Session["ltSoportes"];
        List<long> detalleSoporte = new List<long>();
        double pago = 0;
        int consecutivoPago = 0;

        double valorAplicar = 0;
        DataTable ConsultarIdPagos = new DataTable();
        //Se almacena en listas el id del soporte  su detalle
        foreach (GridViewRow row in grvSoportesPagaduria.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

            if (check.Checked)
            {
                idConciliacion = int.Parse(row.Cells[2].Text);
                ltSoportes.Add(idConciliacion);
                _sopdetId = int.Parse(row.Cells[1].Text);
                detalleSoporte.Add(_sopdetId);
            }
        }
        //Dt con las cedulas que se entraran a conciliar
        DataTable dtExcelInconsistencias = (DataTable)Session["dtExcelInconsistencias"];

        foreach (DataRow fila in dtExcelInconsistencias.Rows)
        {
            //Valor que paga el cliente recorrido
            pago = double.Parse(fila["VALOR"].ToString());
            DataTable dtIdPago = new DataTable();
            //Inserta en tabla NewPago y trae su Id
            dtIdPago = objPago.IngresarPagoCliente(double.Parse(fila["TER_ID"].ToString()), pago, DateTime.Now, int.Parse(ddlConvenio.SelectedValue), 0, 0);

            try
            {
                DataTable dtProductoARealizarPago = new DataTable();
                while (pago > 0)
                {
                    //Consulta el producto para pago 
                    dtProductoARealizarPago = objPago.ConsultarProductoParaPago(double.Parse(fila["TER_ID"].ToString()), int.Parse(ddlConvenio.SelectedValue));
                    //Asigna en una variable el id del pago
                    consecutivoPago = int.Parse(dtIdPago.Rows[0]["pago_Id"].ToString());
                    //Valor a pagar segun la vigencia
                    valorAplicar = double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                    //pregunta si el pago es menor a lo que se le debe pagar, en caso de ser asi el valor a aplicar es igual a la variable pago
                    if (pago < double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()))
                    {
                        valorAplicar = pago;
                    }
                    //Se inserta la aplicacion del pago
                    objPago.IngresarAplicacionPagoCliente(double.Parse(fila["TER_ID"].ToString()), consecutivoPago, int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()),
                    Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar, int.Parse(ddlConvenio.SelectedValue), 0, 0,
                    double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString()));
                    //Se resta el valor aplicado al valor pagado por el cliente
                    pago -= double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                    //Busca si el cliente tiene noveades y la aplica en caso de cumplir su valor solicitado
                    ActualizarNovedadesAplicadas(double.Parse(fila["TER_ID"].ToString()), int.Parse(ddlConvenio.SelectedValue), int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()));
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Existen cedulas No Concidentes" + "');", true);
            }
        }
        //Recorre los soportes seleccionados con el fin de pasarlos a aplicados
        foreach (long idSoporte in ltSoportes)
        {
            objPago.ActualizarEstadoSoporteBancario(int.Parse(idSoporte.ToString()), 4);
        }
        //Crea el recibo de caja
        objPago.CrearRecibosCaja(int.Parse(ddlAgencia.SelectedValue.ToString()), int.Parse(ddlConvenio.SelectedValue), 0, int.Parse(ddlPagaduria.SelectedValue.ToString()), Session["nombreCreador"].ToString());

        DataTable dtConsultarSoporte = new DataTable();
        /*Recorre la lista con el fin de identificar que detalles se aplican a cada recibo 
        y si este es pagado a torres guarin o a la compañia*/
        foreach (int IdDetalle in ltSoportes)
        {
            dtConsultarSoporte = objPago.ConsultarSopIdSoporteBancario(IdDetalle, 1);

            DataTable ConsultarReciboParaSoporte = new DataTable();
            ConsultarReciboParaSoporte = objPago.ConsultarReciboParaSoporte(int.Parse(ddlConvenio.SelectedValue.ToString()));

            if (dtConsultarSoporte.Rows.Count > 0)
            {
                foreach (DataRow dt in ConsultarReciboParaSoporte.Rows)
                {
                    if (int.Parse(dtConsultarSoporte.Rows[0]["sop_TipoSoporteBancario"].ToString()) == 2)
                    {
                        foreach (int IdDetalle2 in detalleSoporte)
                        {
                            objPago.InsertarNewSoportePorRecibo(int.Parse(dt["rec_Id"].ToString()), IdDetalle2);
                        }
                    }
                    if (int.Parse(dtConsultarSoporte.Rows[0]["sop_TipoSoporteBancario"].ToString()) == 1)
                    {
                        if (int.Parse(dtConsultarSoporte.Rows[0]["com_Id"].ToString()) == int.Parse(dt["com_Id"].ToString()))
                        {
                            foreach (int IdDetalle2 in detalleSoporte)
                            {

                                objPago.InsertarNewSoportePorRecibo(int.Parse(dt["rec_Id"].ToString()), IdDetalle2);
                            }
                        }
                    }
                }
            }
        }

        Session["dtExcelInconsistencias"] = dtExcelInconsistencias;
        Session["ltSoportes"] = ltSoportes;
        Session["detalleSoporte"] = detalleSoporte;
        Session["bandera"] = 0;
        Response.RedirectToRoute("conciliacion");
    }
    #endregion

    #region Aplicar novedades
    protected void ActualizarNovedadesAplicadas(double Cedula, int Convenio, int proId)
    {
        //Metodo llamado en Realizar pagos con el fin de identificar y aplicar novedades
        Pagos objPago = new Pagos();
        DataTable dtActualizarNovedadesAplicadas = new DataTable();
        dtActualizarNovedadesAplicadas = objPago.ActualizarNovedadesAplicadas(Cedula, Convenio, proId);
    }
    #endregion

    #region Aplicar novedades de retiro
    protected void AplicarNovedadesRetiro()
    {
        int pagaduria = (ddlPagaduria.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlPagaduria.SelectedValue.ToString());
        int convenio = (ddlConvenio.SelectedValue.ToString() == string.Empty) ? 0 : int.Parse(ddlConvenio.SelectedValue.ToString());

        DataTable dtPagos = (DataTable)Session["dtExcelInconsistencias"];
        DataTable dtNovedadesRetiro = objPagos.ConsultarNovedadesRetiro(pagaduria, convenio);

        string terId;
        bool ban = true;

        foreach (DataRow filaNovedad in dtNovedadesRetiro.Rows)
        {
            terId = filaNovedad["ter_Id"].ToString();
            ban = true;
            foreach (DataRow filaPago in dtPagos.Rows)
            {
                if (filaPago["TER_ID"].ToString() == terId)
                {
                    ban = false;
                }
            }
            if (ban)
            {
                AdministrarNovedades.ActualizarDePendienteASinAplicar(int.Parse(filaNovedad["nov_Id"].ToString()), 2, "");
            }
        }
    }
    #endregion
    #endregion

    #endregion

    protected void grvCedulasNoCoincidentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow rowG = grvCedulasNoCoincidentes.Rows[(index)];

        int ter_Id = int.Parse(rowG.Cells[2].Text);

        if (e.CommandName == "ConsultarCertificado_Click")
        {
            AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            // Líneas para cargar el resumen
            DataTable dt = new DataTable();
            dt = objAdministrarCertificados.consultarResumenCertificado(ter_Id);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Parentesco"].ToString() == "")
                        if (row["ter_Id"].ToString() == ter_Id.ToString())
                        {
                            row["Parentesco"] = "PRINCIPAL";
                        }
                        else
                        {
                            row["Parentesco"] = "CONYUGE";
                        }

                    else
                    {
                        if (row["ter_Id"].ToString() == ter_Id.ToString())
                        {
                            row["Parentesco"] = "PRINCIPAL";
                        }
                    }
                }
            }
            grvCertifacados.DataSource = dt;
            grvCertifacados.DataBind();
            //grvCertifacados.HeaderRow.Cells[10].Visible = false;
            //foreach (GridViewRow row in grvCertifacados.Rows)
            //row.Cells[10].Visible = false;
        }
    }

    protected void txtValorAplicar_TextChanged(object sender, EventArgs e)
    {
        if (txtSaldoConciliar.Text != "")
        {
            if (double.Parse(txtValorAplicar.Text) > double.Parse(txtSaldoConciliar.Text))
            {
                btnConciliarPagoOficina.Enabled = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El valor a aplicar no puede ser mayor al del soporte seleccionado" + "');", true);
            }
            else
            { 
                btnConciliarPagoOficina.Enabled = true;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Recuerde seleccionar el soporte bancario" + "');", true);
        }
    }
}
