using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion6_PagosCompañiasAseguradoras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        //Definicion de Objetos de clases en capa de negocio
        AdministrarCertificados objAdminCertificado = new AdministrarCertificados();
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        if (!IsPostBack)
        {
            
            //Variable tab se usa para identificar de que pestaña viene cuando se hace la consulta a un modal
            // En esta parte segun la variable tab se redirecciona al tab en el que estaba el usuario
            int tab = 0;
            if (Session["tab"] != null)
            {
                tab = int.Parse(Session["tab"].ToString());
            }
            if (tab == 2)
            {
                Session["tab"] = null;
                Response.Redirect(url: "/Presentacion6/PagosCompañiasAseguradoras.aspx#tabs2");

            }
            if (tab == 3)
            {
                Session["tab"] = null;
                Response.Redirect(url: "/Presentacion6/PagosCompañiasAseguradoras.aspx#tabs3");
            }

            #region DDLS
            // Se cargan todos los ddls basicos en el formulario en los diferentes tabs
            DataTable dtLocalidad = objAdminCertificado.ConsultarLocalidades();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidad;
            ddlLocalidad.DataBind();


            DataTable dtLocalidadHistorico = objAdminCertificado.ConsultarLocalidades();
            ddlLocalidadesHistorico.DataTextField = "dep_Nombre";
            ddlLocalidadesHistorico.DataValueField = "dep_Id";
            ddlLocalidadesHistorico.DataSource = dtLocalidad;
            ddlLocalidadesHistorico.DataBind();
            ddlLocalidadesHistorico.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlLocalidadesHistorico.Items.Insert(34, new ListItem("FIDUCIAS", "34"));

            ddlLocalidadFacturacion.DataTextField = "dep_Nombre";
            ddlLocalidadFacturacion.DataValueField = "dep_Id";
            ddlLocalidadFacturacion.DataSource = dtLocalidad;
            ddlLocalidadFacturacion.DataBind();
            ddlLocalidadFacturacion.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlLocalidadFacturacion.Items.Insert(34, new ListItem("FIDUCIAS", "34"));

            DataTable dtLocalidadesPago = objAdminPagosBol.ConsultarLocalidadesPago();
            ddlLocalidadPago.DataTextField = "dep_Nombre";
            ddlLocalidadPago.DataValueField = "dep_Id";
            ddlLocalidadPago.DataSource = dtLocalidadesPago;
            ddlLocalidadPago.DataBind();
            ddlLocalidadPago.Items.Insert(0, new ListItem("Seleccione", ""));
            //ddlLocalidadPago.Items.Insert(34, new ListItem("FIDUCIAS", "34"));

            DataTable dtCompania = objPrecargueProduccion.CargarCompanias();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dtCompania;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", ""));

            ddlProductoFacturacion.Items.Clear();
            ddlProductoFacturacion.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlProductoFacturacion.Items.Insert(1, new ListItem("710", "710"));
            ddlProductoFacturacion.Items.Insert(2, new ListItem("724", "724"));
            ddlProductoFacturacion.Items.Insert(3, new ListItem("799", "799"));
            ddlProductoFacturacion.Items.Insert(4, new ListItem("700", "700"));
            ddlProductoFacturacion.Items.Insert(5, new ListItem("701", "701"));

            #endregion



            #region VALIDACION DE FILTROS EN POSTBACK
            //Se validan en el postaback de la pagina si ya habia un filtro en la solicitu de cheques que esta guardado en la variable de session o se carga por defecto los de facha de hoy
            DataTable dtSolicitudesCheques;
            if (Session["dtSolicitudesCheques"] == null)
            {
                dtSolicitudesCheques = objAdminPagosBol.ConsultarSolicitudesCheques(DateTime.Now, 0);
            }
            else
            {
                dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
            }
            grvSolicitudesCheques.DataSource = dtSolicitudesCheques;
            grvSolicitudesCheques.DataBind();
            Session["dtSolicitudesCheques"] = dtSolicitudesCheques;

            //Se validan en el postaback de la pagina si ya habia un filtro en la facturacion que esta guardado en la variable de session o se carga por defecto los de facha de hoy            
            objAdminPagosBol = new AdministrarPagosBolivar();
            DataTable dtFacturaciones;
            
            if (Session["dtFacturaciones"] == null)
            {
                DateTime fechaCorte = DateTime.Parse("01/01/1900");
                dtFacturaciones = objAdminPagosBol.ConsultarFacturaciones(fechaCorte, DateTime.Now, 0,0,0);
            }
            else
            {
                dtFacturaciones = (DataTable)Session["dtFacturaciones"];
            }
            grvFacturacion.DataSource = dtFacturaciones;
            grvFacturacion.DataBind();
            Session["dtFacturaciones"] = dtFacturaciones;


            //Se validan en el postaback de la pagina si ya habia un filtro en el historico de pagos que esta guardado en la variable de session o se carga por defecto los de facha de hoy            
           
            objAdminPagosBol = new AdministrarPagosBolivar();
            DataTable dtPagos;

            if (Session["dtPagos"] == null)
            {
                //DateTime fechaCorte = DateTime.Parse("01/01/1900");
                dtPagos = objAdminPagosBol.ConsultarHistoricoPagos(0, DateTime.Now, DateTime.Now);
            }
            else
            {
                dtPagos = (DataTable)Session["dtPagos"];
            }
            grvHistoricoPagos.DataSource = dtPagos;
            grvHistoricoPagos.DataBind();
            Session["dtPagos"] = dtPagos;



            //Se validan en el postaback de la pagina si ya habia un filtro en los recibos de caja que esta guardado en la variable de session o se carga por defecto los de facha de hoy            
           
            objAdminPagosBol = new AdministrarPagosBolivar();
            DataTable dtRecibosCaja;

            if (Session["dtRecibosCaja"] == null)
            {
                //DateTime fechaCorte = DateTime.Parse("01/01/1900");
                dtRecibosCaja = objAdminPagosBol.ConsultarRecibosCaja(DateTime.Now, DateTime.Now,0,0,0);
            }
            else
            {
                dtRecibosCaja = (DataTable)Session["dtRecibosCaja"];
            }
            grvRecibosCaja.DataSource = dtRecibosCaja;
            grvRecibosCaja.DataBind();
            Session["dtRecibosCaja"] = dtRecibosCaja;

            #endregion
            //historicoPagos.Visible = false;
            talon.Visible = false;
            solche.Visible = false;
            tronadorFacturacion.Visible = false;
            pagoLocalidad.Visible = false;
            pagoLocalidadConsulta.Visible = false;


            
            //btnExportarExcel2.Visible = false;
            //t1.EnableViewState = false;
            
            
            //DataTable dtSolicitudChequeGuardada = (DataTable)Session["SolicitudChequeCreada"];
            //grvSolicitudChequeCreada.DataSource = dtSolicitudChequeGuardada;
            //grvSolicitudChequeCreada.DataBind();
            //grvSolicitudChequeCreada.Visible = true;


            
            /*DataTable dtFacturacion = AdministrarPagosBolivar.ConsultarFacturacion();
            grvFacturacion.DataSource = dtFacturacion;
            grvFacturacion.DataBind();
            Session["dtFacturacion"] = dtFacturacion;*/
        }
       
        //else
        //{
        //    DataTable dtSolicitudChequeGuardada = (DataTable)Session["SolicitudChequeCreada"];
        //    grvSolicitudChequeCreada.DataSource = dtSolicitudChequeGuardada;
        //    grvSolicitudChequeCreada.DataBind();
        //    grvSolicitudChequeCreada.Visible = true;
        //   //btnExportarExcel2.Visible = false;
        //    //solche.Visible = true;
        //    //Response.Redirect(url: "/Presentacion6/PagosCompañiasAseguradoras.aspx#tabs3");
        //    /*DataTable dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
        //    grvSolicitudesCheques.DataSource = dtSolicitudesCheques;
        //    grvSolicitudesCheques.DataBind();*/
            
        //    //solche.Visible = false;
        //    //talon.Visible = false;
        //}
    }

    //protected void Page_LoadComplete(object sender, EventArgs e)
    //{
    //    AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
    //    DataTable dtFacturaciones;

    //    if (Session["dtFacturaciones"] == null)
    //    {
    //        DateTime fechaCorte = DateTime.Parse("01/01/1900");
    //        dtFacturaciones = objAdminPagosBol.ConsultarFacturaciones(fechaCorte, DateTime.Now, 0,0,0);
    //    }
    //    else
    //    {
    //        dtFacturaciones = (DataTable)Session["dtFacturaciones"];
    //    }
    //    grvFacturacion.DataSource = dtFacturaciones;
    //    grvFacturacion.DataBind();
    //    Session["dtFacturaciones"] = dtFacturaciones;
    //}

    #region PROCESOS

    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        if (ddlCompania.SelectedValue == "1")
        {
            localidad.Visible = false;
            proceso.Visible = true;
            producto.Visible = false;
        }
        else
        {
            localidad.Visible = false;
            proceso.Visible = false;
            DataTable dtProducto = new DataTable();
            string compania = ddlCompania.SelectedValue.ToString();
            producto.Visible = true;
            dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));
        }
    }

    //Evento que segun el proceso selecconado llena el grid con la informacion respectiva
    protected void btnRealizarPagoCompania_Click(object sender, EventArgs e)
    {
        int proceso = ddlProceso.SelectedIndex;
        DateTime fecha = DateTime.Parse(txtFechaFinPago.Text);

        //Solicitud de Cheques
        if (proceso == 1)
        {
            DataTable dtSolicitudCheque;
            AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            dtSolicitudCheque = objAdminPagosBol.CrearSolicitudCheques(fecha);
            if (dtSolicitudCheque.Rows.Count > 0)
            {
                grvProcesos.DataSource = dtSolicitudCheque;
                grvProcesos.DataBind();
                grvProcesos.Visible = true;
                Session["SolicitudCheques"] = dtSolicitudCheque;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay Solicitudes de Cheque para el corte seleccionado');", true);
            }
        }
        //Facturaciones
        if (proceso == 2)
        {
            DataTable dtFacturaciones;
            AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            dtFacturaciones = objAdminPagosBol.CrearFacturacionesPMI724(fecha);
            if (dtFacturaciones.Rows.Count > 0)
            {
                grvProcesos.DataSource = dtFacturaciones;
                grvProcesos.DataBind();
                grvProcesos.Visible = true;
                Session["Facturaciones"] = dtFacturaciones;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay Facturaciones para el corte seleccionado');", true);
            }

        }
        //Pago
        if (proceso == 3)
        {
            DataTable dtFacturacionesPago;
            AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            dtFacturacionesPago = objAdminPagosBol.CrearFacturacionesPago(fecha);
            grvProcesos.DataSource = dtFacturacionesPago;
            grvProcesos.DataBind();
            grvProcesos.Visible = true;
            Session["FacturacionesPago"] = dtFacturacionesPago;

        }


    }

    #endregion

    
    #region FACTURACION

    #endregion
    
    
    //protected void grvProcesos_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
    //    DateTime fecha = DateTime.Parse(txtFechaFinPago.Text);
    //    DataTable dtSolicitudCheque = objAdminPagosBol.ConsultarSolicitudCheque(fecha);
    //    int index = int.Parse(e.CommandArgument.ToString());
    //    GridViewRow row = grvProcesos.Rows[(index)];
    //    int localidad = int.Parse( row.Cells[3].Text);
    //    int idSolicitud =  int.Parse(dtSolicitudCheque.Rows[0]["solche_Id"].ToString());
    //    Session["localidadSolicitud"] = localidad;
    //    Session["idSolicitud"] = idSolicitud;
    //    //Response.Redirect("DetallesSolicitudCheques.aspx");
    //    MostrarModal("OpenCenterWindowCallBack();");
    //}
    
    //Metodo que a traves de un javascript muestra como modal otro formulario; variable jcript se envia como parametro el metodo definido en el formulario
    public void MostrarModal(String jScript)
    {

        //String jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

    }
    protected void btnExportarFacturacion_Click(object sender, EventArgs e)
    {

    }


    #region SOLICITUD DE CHEQUES

    //Eventos del grid de Solicitudes de Cheque
    protected void grvSolicitudesCheques_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvSolicitudesCheques.Rows[(index)];
        DataTable dtSolicitudes = (DataTable)Session["dtSolicitudesCheques"];
        int valorSolicitud=0;
        int idSolicitud=0;
        string localidad="";
        if (dtSolicitudes.Rows.Count>0)
        {
            //int localidad = int.Parse(row.Cells[3].Text);
            valorSolicitud = int.Parse(dtSolicitudes.Rows[index]["Valor"].ToString());
            idSolicitud = int.Parse(dtSolicitudes.Rows[index]["idSolicitud"].ToString());
            localidad = dtSolicitudes.Rows[index]["Localidad"].ToString();
            Session["localidadSolicitud"] = localidad;
            Session["idSolicitud"] = idSolicitud;
            //Session["valorSolicitud"] = valorSolicitud;
        }
      
        //Muestra en un modal todos los recibos asociados a la solicitud seleccionada
        if (e.CommandName == "Consultar_Click")
        {
            talon.Visible = false;
            solche.Visible = true;
            btnExportarExcel2.Visible = true;
            /*
            int idSolicitud = int.Parse(row.Cells[1].Text);
            Session["idSolicitud"] = idSolicitud;
            lblIdSolicitudCreada.Text = "Id Solicitud:" + Convert.ToString(idSolicitud);
            DataTable dtSolicitudChequeGuardada = objAdminPagosBol.ConsultarSolicitudChequeCreada(idSolicitud);
            Session["SolicitudChequeCreada"] = dtSolicitudChequeGuardada;
            grvSolicitudChequeCreada.DataSource = dtSolicitudChequeGuardada;
            grvSolicitudChequeCreada.DataBind();
            grvSolicitudChequeCreada.Visible = true;*/           
            //Response.Redirect("DetallesSolicitudCheques.aspx");
            MostrarModal("OpenCenterWindowCallBack();");
            Session["tab"] = 2;

        }

        //Muestra el formulario para asignar el numero de talon de la solicitud respectiva
        if (e.CommandName == "Select")
        {
            talon.Visible = true;
            solche.Visible = false;
            btnExportarExcel2.Visible = false;
            solicitudes.Visible = false;
            //int idSolicitud = int.Parse(row.Cells[1].Text);
            txtFechaTalonSimasol.Text = "";
            txtTalonSimasol.Text = "";
            txtValorTalonSimasol.Text = "";
            //Session["idSolicitud"] = idSolicitud;
            lblIdSolicitud.Text = "Id Solicitud:" + Convert.ToString(idSolicitud)+" - Valor Solicitud:"+Convert.ToString(valorSolicitud)+" - Localidad:"+Convert.ToString(localidad);
                        
            DataTable dtTalonesSolicitudeCheque = objAdminPagosBol.ConsultarTalonesSolicitudCheque(idSolicitud);
            grvTalonesSolicitudCheque.DataSource = dtTalonesSolicitudeCheque;
            grvTalonesSolicitudCheque.DataBind();
            Session["dtTalonesSolicitudeCheque"] = dtTalonesSolicitudeCheque;

        }
    }

    
    //Evento de boton que exporta a excel la tabla de solicitud de cheques con su filtro respectivo
    protected void btnExportarExcel2_Click(object sender, EventArgs e)
    {
        DataTable dtSolicitudCheque;
        DateTime fecha = DateTime.Now;
        if (txtFechaSolicitudCheque.Text != "")
        {
            fecha = Convert.ToDateTime(txtFechaSolicitudCheque.Text);
        }
        dtSolicitudCheque = (DataTable)Session["dtSolicitudesCheques"];
        Funciones.generarExcelSolicitudCheque(Page, dtSolicitudCheque, "SOLICITUD DE CHEQUES", fecha);
    }
   
    //Evento que carga el gridview de solicitudes con los filtros respectivos
    protected void btnConsultarSolicitudes_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DateTime fecha = Convert.ToDateTime("01/01/0001");

        if (txtFechaSolicitudCheque.Text != "")
        {
            fecha = Convert.ToDateTime(txtFechaSolicitudCheque.Text);
            Session["FechaSolicitudes"] = fecha;
        }
        int numeroTalonSimasol = 0;
        if (txtNumeroTalonSolicitud.Text!="")
        {
            numeroTalonSimasol = int.Parse(txtNumeroTalonSolicitud.Text);
            Session["TalonSolicitudes"] = numeroTalonSimasol;
        }               
                
        DataTable dtSolicitudesCheques = objAdminPagosBol.ConsultarSolicitudesCheques(fecha, numeroTalonSimasol); 
        grvSolicitudesCheques.DataSource = dtSolicitudesCheques;
        grvSolicitudesCheques.DataBind();
        Session["dtSolicitudesCheques"] = dtSolicitudesCheques;
    }

    //Evento que guarda el valor, fecha y numero de Talon o Simasol para una solicitud de cheques
    protected void btnGuardarTalonSimasol_Click(object sender, EventArgs e)
    {
        DateTime fecha = Convert.ToDateTime(txtFechaTalonSimasol.Text);
        int numeroTalonSimasol = int.Parse(txtTalonSimasol.Text);
        int valorTalonSimasol = int.Parse(txtValorTalonSimasol.Text);
        int idSolicitud = int.Parse(Session["idSolicitud"].ToString());
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        int registros = objAdminPagosBol.InsertarTalonSolicitudCheque(idSolicitud, numeroTalonSimasol, fecha, valorTalonSimasol);
        if (registros > 0) 
        {
            talon.Visible = false;
            solicitudes.Visible = true;
            
            
            DateTime fechaFiltro = Convert.ToDateTime("01/01/0001");

            if (Session["FechaSolicitudes"] != null)
            {
                fechaFiltro = Convert.ToDateTime(Session["FechaSolicitudes"].ToString());
            }
            int numeroTalonSimasolFiltro = 0;
            if (Session["TalonSolicitudes"] != null)
            {
                numeroTalonSimasolFiltro = int.Parse(Session["TalonSolicitudes"].ToString());
            }

            DataTable dtSolicitudesCheques = objAdminPagosBol.ConsultarSolicitudesCheques(fechaFiltro, numeroTalonSimasolFiltro);
            grvSolicitudesCheques.DataSource = dtSolicitudesCheques;
            grvSolicitudesCheques.DataBind();
            Session["dtSolicitudesCheques"] = dtSolicitudesCheques;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Valide que el valor de los Talones no supere el valor de la Solicitud');", true);
        }

    }

    #endregion

    //Evento que llena el gridview de facturaciones con el filtro respectivo
    protected void btnBuscarFacturacion_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DateTime fechaCorte = Convert.ToDateTime("01/01/1900");
        DateTime fechaCreacion = Convert.ToDateTime("01/01/1900");
        int localidad = 0;
        int producto = 0;
        int numeroTronador = 0;

        if (ddlLocalidadFacturacion.SelectedValue.ToString() != "")
        {
            localidad = int.Parse(ddlLocalidadFacturacion.SelectedValue.ToString());
        }

        if (ddlProductoFacturacion.SelectedValue.ToString() != "")
        {
            producto = int.Parse(ddlProductoFacturacion.SelectedValue.ToString());
        }

        if (txtFechaFacturacion.Text != "")
        {
            fechaCorte = Convert.ToDateTime(txtFechaFacturacion.Text);
        }
        if (txtFechaCreacionFacturacion.Text != "")
        {
            fechaCreacion = Convert.ToDateTime(txtFechaCreacionFacturacion.Text);
        }
        
        if (txtTronador.Text != "")
        {
            numeroTronador = int.Parse(txtTronador.Text);
        }

        DataTable dtFacturaciones = objAdminPagosBol.ConsultarFacturaciones(fechaCorte, fechaCreacion, numeroTronador,localidad,producto);
        grvFacturacion.DataSource = dtFacturaciones;
        grvFacturacion.DataBind();
        Session["dtFacturaciones"] = dtFacturaciones;
    }

    #region FACTURACIONES

    //Eventos del grid de Facturaciones
    protected void grvFacturacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvFacturacion.Rows[(index)];

        //Muestra en un modal las aplicaciones asociadas a la facturacion seleccionada
        if (e.CommandName == "Consultar_Click")
        {
            talon.Visible = false;
            solche.Visible = true;
            btnExportarExcel2.Visible = true;
            int idFacturacion = int.Parse(row.Cells[1].Text);
            Session["idFacturacion"] = idFacturacion;
            MostrarModal("OpenCenterWindowCallBack();");
            Session["tab"] = 3;
            //lblIdSolicitudCreada.Text = "Id Solicitud:" + Convert.ToString(idSolicitud);
            /*DataTable dtDetallesFacturacion = objAdminPagosBol.ConsultarDetallesFacturacion(idFacturacion);
            Session["DetallesFacturacion"] = dtDetallesFacturacion;
            grvSolicitudChequeCreada.DataSource = dtDetallesFacturacion;
            grvSolicitudChequeCreada.DataBind();
            grvSolicitudChequeCreada.Visible = true;*/


        }

        //Permite asiganr el numero de tronador a la facturacion seleccionada; solo aplica para 724
        if (e.CommandName == "Select")
        {
            int producto = int.Parse(row.Cells[10].Text);
            if (producto == 724)
            {
                tronadorFacturacion.Visible = true;
                //btnExportarExcel2.Visible = false;
                int idFacturacion = int.Parse(row.Cells[1].Text);
                string polizaFacturacion = row.Cells[3].Text;
                int valorFacturacion = int.Parse(row.Cells[4].Text);
                txtTronador.Text = "";
                txtNumeroFactura.Text = "";
                Session["idFacturacion"] = idFacturacion;
                lblFacturacion.Text = "Id Facturacion:" + Convert.ToString(idFacturacion) + " - Poliza:" + Convert.ToString(polizaFacturacion) + " - Valor:" + Convert.ToString(valorFacturacion);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Solo se puede asignar valores de Factura, Tronador y Fecha a 724');", true);
            }
        }
    }

    //Evento que guarda el numero de tronador para la facturacin seleccionada
    protected void btnGuardarTronadorFacturacion_Click(object sender, EventArgs e)
    {
        int numeroTronador = int.Parse(txtNumeroTronador.Text);
        int numeroFactura = int.Parse(txtNumeroFactura.Text);
        DateTime fechaFactura = Convert.ToDateTime(txtFechaFactura.Text);
        int idFacturacion = int.Parse(Session["idFacturacion"].ToString());
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        int registros = objAdminPagosBol.ActualizarTronadorFacturaFacturacion(idFacturacion, numeroTronador, numeroFactura,fechaFactura);
        tronadorFacturacion.Visible = false;
        objAdminPagosBol = new AdministrarPagosBolivar();
        DataTable dtFacturaciones = (DataTable)Session["dtFacturaciones"];//objAdminPagosBol.ConsultarFacturaciones(DateTime.Now, 0);
        grvFacturacion.DataSource = dtFacturaciones;
        grvFacturacion.DataBind();
        Session["dtFacturaciones"] = dtFacturaciones;
    }
    #endregion

    #region PAGO COMPAÑIA

    //Evento que al seleccionar una localidad carga el pago respectivo para la misma
    protected void ddlLocalidadPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        chkEnvioDefinitivo.Checked = false;
        int idLocalidad=0;
        //Valida localidad especial que es fiducias
        if (ddlLocalidadPago.SelectedItem.Text == "FIDUCIAS")
        {
            idLocalidad = 34;
        }
        else
        {
            if (ddlLocalidadPago.SelectedValue.ToString() != "")
            {
                idLocalidad = int.Parse(ddlLocalidadPago.SelectedValue.ToString());
            }
        }

        //Consulta un DataSet con 5 tablas correspondientes a los item del pago
        DataSet dsPago = objAdminPagosBol.CalcularPagoLocalidad(idLocalidad);
        dsPago.Tables[0].TableName = "FacturacionesPago";
        dsPago.Tables[1].TableName = "DetallesPago";
        dsPago.Tables[2].TableName = "SoportesPago";
        dsPago.Tables[3].TableName = "NovedadesPago";
        dsPago.Tables[4].TableName = "LibranzasPago";
        Session["dsPago"] = dsPago;

        //Si exitste datos para el pago se llenan los gridview con la tabla respectiva
        if (dsPago.Tables["FacturacionesPago"].Rows.Count > 0)
        {
        grvFacturacionesPagos.DataSource = dsPago.Tables["FacturacionesPago"];
        grvDetallesPago.DataSource = dsPago.Tables["DetallesPago"];
        grvSoportesPago.DataSource = dsPago.Tables["SoportesPago"];
        grvNovedades.DataSource = dsPago.Tables["NovedadesPago"];
        grvLibranzasPago.DataSource = dsPago.Tables["LibranzasPago"];
        grvFacturacionesPagos.DataBind();
        grvDetallesPago.DataBind();
        grvSoportesPago.DataBind();
        grvNovedades.DataBind();
        grvLibranzasPago.DataBind();
        pagoLocalidad.Visible = true;
        btnExportarPago.Enabled = true;
        btnExportarDetalles.Enabled = true;
        }
        else
        {
            grvFacturacionesPagos.DataSource = null;
            grvDetallesPago.DataSource = null;
            grvSoportesPago.DataSource = null;
            grvNovedades.DataSource = null;
            grvLibranzasPago.DataSource = null;
            grvFacturacionesPagos.DataBind();
            grvDetallesPago.DataBind();
            grvSoportesPago.DataBind();
            grvNovedades.DataBind();
            grvLibranzasPago.DataBind();
            pagoLocalidad.Visible=false;
            //btnExportarPago.Enabled = false;
            //btnExportarDetalles.Enabled = false;
            
        }
        ddlLocalidadPago.Enabled = false;
        
    }

    //Evento que generan en excel el pago de la localidad respectiva, envia un DataSet con 3 tablas, los items Facturaciones, Libranzas y Soportes
    protected void btnExportarPago_Click(object sender, EventArgs e)
    {
        int idLocalidad=0;
        //try
        if ((ddlLocalidadPago.SelectedValue.ToString())!="")
        {
            idLocalidad = int.Parse(ddlLocalidadPago.SelectedValue.ToString());

            //int idLocalidad = int.Parse(ddlLocalidadPago.SelectedValue.ToString());

            AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            if (chkEnvioDefinitivo.Checked)
            {

                int registros = objAdminPagosBol.CrearPagoLocalidad(idLocalidad, 1);

            }

            DataSet dsPago = (DataSet)Session["dsPago"];
            String nombre = "Pago " + ddlLocalidadPago.SelectedItem;

            Funciones.generarExcelPago(Page, dsPago, nombre);
        }
        //catch
            else
        {
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Debe seleccionar una localidad para pago');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "SU PETICION NO PUDO SER EJECUTADA; INTENTE NUEVAMENTE" + "');", true);
            ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tabs', '#tabs4');$('#tabs4').addClass('in active'); $('a[href=#tabs4]').parent().addClass('active');", true);
        }
        //nombre = "Detalles - Novedades" + ddlLocalidadPago.SelectedValue;
        //Funciones.generarDetallesPago(Page, dsPago, nombre);
        Response.Redirect(url: "/Presentacion6/PagosCompañiasAseguradoras.aspx#tabs4");
        
        
        
    }

    //Evento que generan en excel el pago de la localidad respectiva, envia un DataSet con 2 tablas, los items Detalles y Novedades
    protected void btnExportarDetalles_Click(object sender, EventArgs e)
    {
        DataSet dsPago = (DataSet)Session["dsPago"];
        String  nombre = "Detalles - Novedades " + ddlLocalidadPago.SelectedItem;
        Funciones.generarDetallesPago(Page, dsPago, nombre);
    }

    //Evento para la paginacion del grid de Detalles de Pago
    protected void grvDetallesPago_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetallesPago.PageIndex = e.NewPageIndex;
        DataSet dsPago = (DataSet)Session["dsPago"];
        DataTable dtDetallesPago = dsPago.Tables["DetallesPago"];       
        grvDetallesPago.DataSource = dtDetallesPago;
        grvDetallesPago.DataBind();
    }

    //Evento para la paginacion del grid de Novedades del pago
    protected void grvNovedades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvNovedades.PageIndex = e.NewPageIndex;
        DataSet dsPago = (DataSet)Session["dsPago"];
        DataTable dtNovedadesPago = dsPago.Tables["NovedadesPago"];
        grvNovedades.DataSource = dtNovedadesPago;
        grvNovedades.DataBind();
    }


    protected void btnVoverSolicitudes_Click(object sender, EventArgs e)
    {
        solicitudes.Visible = true;
        talon.Visible = false;
    }

    //Evento que consulta las localidades que tienen pago pendiente por enviar y llenan el dropdownlist de localidades
    protected void btnValidarPagos_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DataTable dtLocalidadesPago = objAdminPagosBol.ConsultarLocalidadesPago();
        ddlLocalidadPago.DataTextField = "dep_Nombre";
        ddlLocalidadPago.DataValueField = "dep_Id";
        ddlLocalidadPago.DataSource = dtLocalidadesPago;
        ddlLocalidadPago.DataBind();
        ddlLocalidadPago.Items.Insert(0, new ListItem("Seleccione", ""));
        ddlLocalidadPago.Enabled = true;
        pagoLocalidad.Visible = false;
        chkEnvioDefinitivo.Checked = false;
        //btnExportarPago.Enabled = false;
        //btnExportarDetalles.Enabled = false;
    }

    //Evento que consulta los pagos historicos por el filtro respectivo de fechas y localidad
    protected void btnConsultarPagos_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = DateTime.Now;

        if (txtFechaInicio.Text != "")
        {
            fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
        }
        if (txtFechaFin.Text != "")
        {
            fechaFin = Convert.ToDateTime(txtFechaFin.Text);
        }
        int idLocalidad = 0;
        if (ddlLocalidadesHistorico.SelectedValue.ToString() != "")
        {
            idLocalidad = int.Parse(ddlLocalidadesHistorico.SelectedValue.ToString());
        }

        DataTable dtPagos = objAdminPagosBol.ConsultarHistoricoPagos(idLocalidad,fechaInicio, fechaFin);
        grvHistoricoPagos.DataSource = dtPagos;
        grvHistoricoPagos.DataBind();
        pagoLocalidadConsulta.Visible = false;
        Session["dtPagos"] = dtPagos;
    }

    //Eventos del grid de Hostorico de Pagos
    protected void grvHistoricoPagos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvHistoricoPagos.Rows[(index)];
        DataTable dtPagos = (DataTable)Session["dtPagos"];
        int pagoId = 0;

        if (dtPagos.Rows.Count > 0)
        {
            //int localidad = int.Parse(row.Cells[3].Text);
            pagoId = int.Parse(dtPagos.Rows[index]["Id Pago"].ToString());
            
                       //Session["valorSolicitud"] = valorSolicitud;
        }

        //Me genera el pago seleccionado
        if (e.CommandName == "Consultar_Click")
        {
            //AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            //chkEnvioDefinitivo.Checked = false;
            //int idLocalidad = 0;
            //if (ddlLocalidadPago.SelectedItem.Text == "FIDUCIAS")
            //{
            //    idLocalidad = 34;
            //}
            //else
            //{
            //    if (ddlLocalidadPago.SelectedValue.ToString() != "")
            //    {
            //        idLocalidad = int.Parse(ddlLocalidadPago.SelectedValue.ToString());
            //    }
            //}
            DataSet dsPago = objAdminPagosBol.ConsultarPagoLocalidad(pagoId);
            dsPago.Tables[0].TableName = "FacturacionesPago";
            dsPago.Tables[1].TableName = "DetallesPago";
            dsPago.Tables[2].TableName = "SoportesPago";
            dsPago.Tables[3].TableName = "NovedadesPago";
            dsPago.Tables[4].TableName = "LibranzasPago";
            Session["dsPago"] = dsPago;
            if (dsPago.Tables["FacturacionesPago"].Rows.Count > 0)
            {
                grvFacturacionesPagoConsulta.DataSource = dsPago.Tables["FacturacionesPago"];
                grvDetallesPagoConsulta.DataSource = dsPago.Tables["DetallesPago"];
                grvSoportesPagoConsulta.DataSource = dsPago.Tables["SoportesPago"];
                grvNovedadesPagoConsulta.DataSource = dsPago.Tables["NovedadesPago"];
                grvLibranzasPagoConsulta.DataSource = dsPago.Tables["LibranzasPago"];
                grvFacturacionesPagoConsulta.DataBind();
                grvDetallesPagoConsulta.DataBind();
                grvSoportesPagoConsulta.DataBind();
                grvNovedadesPagoConsulta.DataBind();
                grvLibranzasPagoConsulta.DataBind();
                pagoLocalidadConsulta.Visible = true;
                btnExportarPago.Enabled = true;
                btnExportarDetalles.Enabled = true;
            }
            else
            {
                grvFacturacionesPagoConsulta.DataSource = null;
                grvDetallesPagoConsulta.DataSource = null;
                grvSoportesPagoConsulta.DataSource = null;
                grvNovedadesPagoConsulta.DataSource = null;
                grvLibranzasPagoConsulta.DataSource = null;
                grvFacturacionesPagoConsulta.DataBind();
                grvDetallesPagoConsulta.DataBind();
                grvSoportesPagoConsulta.DataBind();
                grvNovedadesPagoConsulta.DataBind();
                grvLibranzasPagoConsulta.DataBind();
                pagoLocalidadConsulta.Visible = false;
                //btnExportarPago.Enabled = false;
                //btnExportarDetalles.Enabled = false;

            }

        }
    }
    protected void btnConsultarRecibos_Click(object sender, EventArgs e)
    {

        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DataTable dtRecibosCaja;


        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = DateTime.Now;

        if (txtFechaInicioRecibos.Text != "")
        {
            fechaInicio = Convert.ToDateTime(txtFechaInicioRecibos.Text);
        }
        if (txtFechaFinRecibos.Text != "")
        {
            fechaFin = Convert.ToDateTime(txtFechaFinRecibos.Text);
        }

        
            //DateTime fechaCorte = DateTime.Parse("01/01/1900");
        dtRecibosCaja = objAdminPagosBol.ConsultarRecibosCaja(fechaInicio, fechaFin,0,0,0);
        
        grvRecibosCaja.DataSource = dtRecibosCaja;
        grvRecibosCaja.DataBind();
        Session["dtRecibosCaja"] = dtRecibosCaja;


    }

    //Evento que exporta a excel la tabla de facturaciones con su respectivo filtro
    protected void btnExportarExcelFacturaciones_Click(object sender, EventArgs e)
    {
        DataTable dtFacturaciones;
        DateTime fecha = DateTime.Now;
        if (txtFechaSolicitudCheque.Text != "")
        {
            fecha = Convert.ToDateTime(txtFechaSolicitudCheque.Text);
        }
        dtFacturaciones = (DataTable)Session["dtFacturaciones"];
        Funciones.generarExcel(Page, dtFacturaciones, "FACTURACIONES");
    }

    //Evento que exporta a excel el pago historico seleccionado
    protected void btnExportarEcelPagoHiastorico_Click(object sender, EventArgs e)
    {
        DataSet dsPago = (DataSet)Session["dsPago"];
        String nombre = "Pago "; // +ddlLocalidadPago.SelectedItem;

        Funciones.generarExcelPago(Page, dsPago, nombre);
    }

    //Evento que exporta a excel el detalle y novedades del pago historico
    protected void btnExportarDetallesHsitorico_Click(object sender, EventArgs e)
    {
        DataSet dsPago = (DataSet)Session["dsPago"];
        String nombre = "Detalles - Novedades "; // +ddlLocalidadPago.SelectedItem;
        Funciones.generarDetallesPago(Page, dsPago, nombre);
    }

    #endregion
}