using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion6_PagosOtrasCompañias : System.Web.UI.Page
{
    PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {

            //Se cargan todos los ddls del formulario
            DataTable dtCompania = objPrecargueProduccion.CargarCompanias();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dtCompania;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", ""));
        
            ddlCompañiaHistorico.DataTextField = "com_Nombre";
            ddlCompañiaHistorico.DataValueField = "com_Id";
            ddlCompañiaHistorico.DataSource = dtCompania;
            ddlCompañiaHistorico.DataBind();
            ddlCompañiaHistorico.Items.Insert(0, new ListItem("Seleccione", ""));

            ddlCompañiaCargue.DataTextField = "com_Nombre";
            ddlCompañiaCargue.DataValueField = "com_Id";
            ddlCompañiaCargue.DataSource = dtCompania;
            ddlCompañiaCargue.DataBind();
            ddlCompañiaCargue.Items.Insert(0, new ListItem("Seleccione", ""));

            ddlCompañiaCarguePago.DataTextField = "com_Nombre";
            ddlCompañiaCarguePago.DataValueField = "com_Id";
            ddlCompañiaCarguePago.DataSource = dtCompania;
            ddlCompañiaCarguePago.DataBind();
            ddlCompañiaCarguePago.Items.Insert(0, new ListItem("Seleccione", ""));


            pagoCompañia.Visible = false;
            exportar.Visible = true;
            pagoProductoConsulta.Visible = false;
            botonExcelCargue.Visible = true;
            if (Session["dsPagoCompañia"] != null && Session["compañiaPago"] != null && Session["productoPago"] != null)
            {
                DataSet dsPagoOtrasCias = (DataSet)Session["dsPagoCompañia"];
                if (dsPagoOtrasCias.Tables.Count > 0)
                {
                    llenarGridsPago(dsPagoOtrasCias);
                    ddlCompania.SelectedValue = Session["compañiaPago"].ToString();
                    llenarDropProductosCompañia(ddlProducto,(int)Session["compañiaPago"]);
                    ddlProducto.SelectedValue = Session["productoPago"].ToString();
                }
                
            }
            
        }
      
        

    }

    //Evento que calcula y realiza el pago para el producto, vigencia y corte de recibos seleccionados
    protected void btnRealizarPagoCompania_Click(object sender, EventArgs e)
    {
        AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();

        int producto = int.Parse(ddlProducto.SelectedValue.ToString());
        DateTime fecha = DateTime.Parse(txtFechaFinPago.Text);
        int compañia = int.Parse(ddlCompania.SelectedValue.ToString());
        DateTime vigencia = DateTime.Parse(txtVigencia.Text);
        Session["productoPago"] = producto;
        Session["fechaPago"] = fecha;
        Session["vigencia"] = vigencia;
        Session["compañiaPago"] = compañia;
        //Session["habilitarExportar"] = 0;

        //Se retorna un DataSet con 5 tablas con los items respectivos del pago para llenar el gridview respectivo
        DataSet dsPagoOtrasCia = objAminPagoCia.CalcularPagoProducto(fecha, producto, vigencia);
        Session["dsPagoCompañia"] = dsPagoOtrasCia;
        if (dsPagoOtrasCia.Tables[0].Rows.Count > 0)
        {
            llenarGridsPago(dsPagoOtrasCia);
            //grvPagoProducto.DataSource = dsPagoOtrasCia.Tables[0];
            //grvPagoProducto.DataBind();
            //grvPagoProducto.Visible = true;

            //grvRecibosPago.DataSource = dsPagoOtrasCia.Tables[3];
            //grvRecibosPago.DataBind();
            //grvRecibosPago.Visible = true;

            //grvTransferencias.DataSource = dsPagoOtrasCia.Tables[4];
            //grvTransferencias.DataBind();
            //grvTransferencias.Visible = true;

            //grvTotalGr.DataSource = dsPagoOtrasCia.Tables[1];
            //grvTotalGr.DataBind();
            //grvTotalGr.Visible = true;

            //grvComision.DataSource = dsPagoOtrasCia.Tables[2];
            //grvComision.DataBind();
            //grvComision.Visible = true;

            ///*grvComision2.DataSource = dsPagoOtrasCia.Tables[3];
            //grvComision2.DataBind();
            //grvComision2.Visible = true;*/


            //btnDetallesPago.Enabled = true;
            //Session["habilitarExportar"] = 1;
            //pagoCompañia.Visible = true;
            ////btnExportarExcel.Enabled = true;
            ////btnPagoDefinitivo.Enabled = true;
            ////exportar.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El pago se ha generado');", true);
         }
        else
        {
            pagoCompañia.Visible = false;
            //btnExportarExcel.Enabled = true;
            //btnPagoDefinitivo.Enabled = true;
            btnDetallesPago.Enabled = false;
            //exportar.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay pagos para generar del producto seleccionado');", true);
            Session["habilitarExportar"] = 0;
        }

    }


    //Evento al seleccionar una compañia en el ddl de compañia, lo cual carga el ddl de productos con los asociados a la seleccion
    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompania.SelectedValue == "1")
        {
            localidad.Visible = false;
            //proceso.Visible = true;
            producto.Visible = false;
        }
        else
        {
            localidad.Visible = false;
            proceso.Visible = false;
            DataTable dtProducto = new DataTable();
            string compania = ddlCompania.SelectedValue.ToString();
            producto.Visible = true;

            llenarDropProductosCompañia(ddlProducto, int.Parse(compania));
            //dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));

            //ddlProducto.DataTextField = "pro_Nombre";
            //ddlProducto.DataValueField = "pro_Id";
            //ddlProducto.DataSource = dtProducto;
            //ddlProducto.DataBind();
            //ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
        }

    }

    //Evento que genera un modal de un formulario con las aplicaciones asociadas al pago respectivo
    protected void btnDetallesPago_Click(object sender, EventArgs e)
    {
        Session["tab"] = 4;
        MostrarModal("OpenCenterWindowCallBack();");
        
    }

    public void MostrarModal(String jScript)
    {

        //String jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

    }

    //Evento que exporta a excel el pago generado
    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {
        //DataSet dsPagoCompañia = (DataSet)Session["dsPagoCompañia"];
        //String nombre = "Pago "; // +ddlLocalidadPago.SelectedItem;
        //Funciones.generarExcelPagoCompañia(Page, dsPagoCompañia, nombre);
        exportarPagoExcel();
    }

    //Evento que crea como definitiovo el pago a la compañia, marcando todas las aplicaciones para no volver a ser tenidas en cuenta
    protected void btnPagoDefinitivo_Click(object sender, EventArgs e)
    {
        AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();
        int producto = int.Parse(Session["productoPago"].ToString());
        DateTime fecha = DateTime.Parse(Session["fechaPago"].ToString());
        DateTime vigencia = DateTime.Parse(Session["vigencia"].ToString());
        DataTable dtRegistros  = objAminPagoCia.CrearPagoOtrasCias(fecha, producto, vigencia);
        if (int.Parse(dtRegistros.Rows[0]["registro"].ToString()) > 0)
        {
            pagoCompañia.Visible = false;
            exportarPagoExcel();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ya existe un pago para la vigencia del producto seleccionado');", true);
        }
    }

    //Metodo que genera a excel el pago que se genero
    public void exportarPagoExcel()
    {
        DataSet dsPagoCompañia = (DataSet)Session["dsPagoCompañia"];
         // +ddlLocalidadPago.SelectedItem;
        if (dsPagoCompañia != null && dsPagoCompañia.Tables[0].Rows.Count > 0 )
        {
            String nombre = "Pago " + ddlCompania.SelectedItem.ToString()+"_"+ddlProducto.SelectedItem.ToString();
            Funciones.generarExcelPagoCompañia(Page, dsPagoCompañia, nombre);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay pagos para exportar a excel');", true);
        }

    }

    //Metodo que genera a excel el pago que se genero
    public void exportarPagoExcelHistorico()
    {
        DataSet dsPagoCompañia = (DataSet)Session["dsPagoOtrasCia"];
        String nombre = "Pago "; // +ddlLocalidadPago.SelectedItem;
        if (dsPagoCompañia != null && dsPagoCompañia.Tables[0].Rows.Count > 0 )
        {
            Funciones.generarExcelPagoCompañia(Page, dsPagoCompañia, nombre);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay pagos para exportar a excel');", true);
        }

    }

    //Evento que carga el ddl de producto en historico con los productos asociados a la compañia seleccionada
    protected void ddlCompañiaHistorico_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtProducto = new DataTable();
        string compania = ddlCompañiaHistorico.SelectedValue.ToString();
        producto.Visible = true;
        llenarDropProductosCompañia(ddlProductoHistorico, int.Parse(compania));
        //dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));
        //ddlProductoHistorico.DataTextField = "pro_Nombre";
        //ddlProductoHistorico.DataValueField = "pro_Id";
        //ddlProductoHistorico.DataSource = dtProducto;
        //ddlProductoHistorico.DataBind();
        //ddlProductoHistorico.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    //Evento que consulta los pagos de un prodcuto para el rango de fechas seleccionado
    protected void btnConsultarPagos_Click(object sender, EventArgs e)
    {
        Session["dtHistoricoPagoCia"] = null;
        AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();
        int producto = int.Parse(ddlProductoHistorico.SelectedValue.ToString());
        DateTime fechaInicio = DateTime.Parse(txtFechaInicioHistorico.Text);
        DateTime fechaFin = DateTime.Parse(txtFechaFinHistorico.Text);
        DataTable dtHistoricoPagoProducto = objAminPagoCia.ConsultarHistoricoProductoPagosCias(fechaInicio, fechaFin,producto);
        grvHistoricoPagosCias.DataSource = dtHistoricoPagoProducto;
        grvHistoricoPagosCias.DataBind();
        grvHistoricoPagosCias.Visible = true;
        pagoProductoConsulta.Visible = false;
        
        Session["dtHistoricoPagoCia"] = dtHistoricoPagoProducto;
    }

    //Evento que permite seleccionar el pago en el historico respectivo para ser mostrado; consulta un Dataset con 5 tablas con los items respectivos del pago
    protected void grvHistoricoPagosCias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdministrarPagosCompanias objAdminPagosCias = new AdministrarPagosCompanias();
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvHistoricoPagosCias.Rows[(index)];
        DataTable dtHistoricoPagoProducto = (DataTable)Session["dtHistoricoPagoCia"];
        int pagoId = 0;
        Session["dsPagoOtrasCia"] = null;

        if (dtHistoricoPagoProducto.Rows.Count > 0)
        {
            //int localidad = int.Parse(row.Cells[3].Text);
            pagoId = int.Parse(dtHistoricoPagoProducto.Rows[index]["Id Pago"].ToString());
           
            
                       //Session["valorSolicitud"] = valorSolicitud;
        }

        //Al seleccionar un pago, carga los gridview con las tablas respectivas del DataSet
        if (e.CommandName == "Consultar_Click")
        {
            AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();
            
            //Session["habilitarExportar"] = 0;
            // Si hay un pago seleccionado se carga los gridview con las tablas del Dataset respectivo
            DataSet dsPagoOtrasCia = objAminPagoCia.ConsultarPagoProducto(pagoId);
            if (dsPagoOtrasCia.Tables[0].Rows.Count > 0)
            {
                llenarGridsPago(dsPagoOtrasCia);
                //grvHistoricoPagoProducto.DataSource = dsPagoOtrasCia.Tables[0];
                //grvHistoricoPagoProducto.DataBind();
                //grvHistoricoPagoProducto.Visible = true;

                //grvHistoricoRecibosPago.DataSource = dsPagoOtrasCia.Tables[3];
                //grvHistoricoRecibosPago.DataBind();
                //grvHistoricoRecibosPago.Visible = true;                            

          

                //grvHistoricoTransferencias.DataSource = dsPagoOtrasCia.Tables[4];
                //grvHistoricoTransferencias.DataBind();
                //grvHistoricoTransferencias.Visible = true;

                //grvHistoricoTotalGr.DataSource = dsPagoOtrasCia.Tables[1];
                //grvHistoricoTotalGr.DataBind();
                //grvHistoricoTotalGr.Visible = true;

                //grvHistoricoComision.DataSource = dsPagoOtrasCia.Tables[2];
                //grvHistoricoComision.DataBind();
                //grvHistoricoComision.Visible = true;

                ///*grvHistoricoComision2.DataSource = dsPagoOtrasCia.Tables[3];
                //grvHistoricoComision2.DataBind();
                //grvHistoricoComision2.Visible = true;*/





                //btnDetallesPago.Enabled = true;
                //Session["pagoId"] = pagoId;
                //Session["habilitarExportar"] = 1;
                //pagoProductoConsulta.Visible = true;
                //Session["dsPagoOtrasCia"] = dsPagoOtrasCia;
                ////btnExportarExcel.Enabled = true;
                ////btnPagoDefinitivo.Enabled = true;
                ////exportar.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El pago se ha generado');", true);
            }

        }

    }

    //Eento que llena el ddl de producto en el cargue con los productos asociados de la compañia seleccionada
    protected void ddlCompañiaCargue_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtProducto = new DataTable();
        string compania = ddlCompañiaCargue.SelectedValue.ToString();
        producto.Visible = true;
        llenarDropProductosCompañia(ddlProductoCargue, int.Parse(compania));
        //dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));
        //ddlProductoCargue.DataTextField = "pro_Nombre";
        //ddlProductoCargue.DataValueField = "pro_Id";
        //ddlProductoCargue.DataSource = dtProducto;
        //ddlProductoCargue.DataBind();
        //ddlProductoCargue.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    //Evento que genera el cargue en el gridview con los clientes produccion nueva del producto y vigencia seleccionada con referencia al pago de la misma vigencia; el resultado se almacena en una variable de session
    protected void btnGenerarArchivoCargue_Click(object sender, EventArgs e)
    {
        botonExcelCargue.Visible = false;
        Session["dtArchivoCargueClientes"] = null;
        grvArchivoCargue.Visible = false;
        AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();
        int producto = int.Parse(ddlProductoCargue.SelectedValue.ToString());
        DateTime vigencia = DateTime.Parse(txtVigenciaCargue.Text);

        DataTable dtArchivoCargueClientes = objAminPagoCia.ConsultarProduccionAplicada(producto, vigencia);
        if (dtArchivoCargueClientes.Rows.Count>0)
        {
            grvArchivoCargue.DataSource = dtArchivoCargueClientes;
            grvArchivoCargue.DataBind();
            grvArchivoCargue.Visible = true;
            Session["dtArchivoCargueClientes"] = dtArchivoCargueClientes;
            botonExcelCargue.Visible = true;
        }
        
    }

    //Evento q expporta a excel el cargue de clientes aplicados produccion nueva para la compañia seleccionada, informacion cargada en la variable de Session
    protected void btnExportarArchivoCargue_Click(object sender, EventArgs e)
    {
        DataTable dtArchivoCargueClientes = (DataTable)Session["dtArchivoCargueClientes"];
        if (dtArchivoCargueClientes != null && dtArchivoCargueClientes.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtArchivoCargueClientes, "Cargue");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay cargue para exportar a excel');", true);
        }
    }

    //Evento de que abre en un modal de otro formulario los detalles asociados al pago generado del producto seleccionado
    protected void btnDetallesHistorico_Click(object sender, EventArgs e)
    {
        Session["tab"] = 5;
        MostrarModal("OpenCenterWindowCallBack();");
    }

    //Evento que llamaal metodo para exportar a excel un pago generado en el sistema
    protected void btnExportarExcelPagoHiastorico_Click(object sender, EventArgs e)
    {
        exportarPagoExcelHistorico();
    }

    //Evento que al seleccionar la compañia en la pestaña del cargue del ddl de Compañia, llena el ddl de producto con los productos asociados a la compañia seleccionada
    protected void ddlCompañiaCarguePago_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtProducto = new DataTable();
        string compania = ddlCompañiaCarguePago.SelectedValue.ToString();
        producto.Visible = true;
        dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));
        ddlProductoCarguePago.DataTextField = "pro_Nombre";
        ddlProductoCarguePago.DataValueField = "pro_Id";
        ddlProductoCarguePago.DataSource = dtProducto;
        ddlProductoCarguePago.DataBind();
        ddlProductoCarguePago.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    //Evento que genera el cargue asociado al pago, del producto y vigencia seleccionado
    protected void btnGenerarCarguePago_Click(object sender, EventArgs e)
    {
                    
        Session["dtArchivoCarguePagoCompañia"] = null;
        grvArchivoCargue.Visible = false;
        AdministrarPagosCompanias objAminPagoCia = new AdministrarPagosCompanias();
        int producto = int.Parse(ddlProductoCarguePago.SelectedValue.ToString());
        DateTime vigencia = DateTime.Parse(txtVigenciaCarguePago.Text);

        DataTable dtArchivoCarguePagoCompañia = objAminPagoCia.ConsultarArchivoCarguePagoCompañia(producto, vigencia);
        if (dtArchivoCarguePagoCompañia.Rows.Count>0)
        {
            grvCarguePago.DataSource = dtArchivoCarguePagoCompañia;
            grvCarguePago.DataBind();
            grvCarguePago.Visible = true;
            Session["dtArchivoCarguePagoCompañia"] = dtArchivoCarguePagoCompañia;
            
        }
    }

    //Evento que exporta a excel el cargue de clientes para el pago a la compañia, se encuentra por porducto y vigencia en la variable de session
    protected void btnExportarExcelCarguePago_Click(object sender, EventArgs e)
    {
        DataTable dtArchivoCarguePagoCompañia = (DataTable)Session["dtArchivoCarguePagoCompañia"];
        if (dtArchivoCarguePagoCompañia != null && dtArchivoCarguePagoCompañia.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtArchivoCarguePagoCompañia, "Cargue");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay cargue para exportar a excel');", true);
        }
    }

    //Metodo que llena los grid con los valores del dataset correspondientes al pago
    private void llenarGridsPago(DataSet dsPagoCompañia)
    {
        grvPagoProducto.DataSource = dsPagoCompañia.Tables[0];
        grvPagoProducto.DataBind();
        grvPagoProducto.Visible = true;

        grvRecibosPago.DataSource = dsPagoCompañia.Tables[3];
        grvRecibosPago.DataBind();
        grvRecibosPago.Visible = true;

        grvTransferencias.DataSource = dsPagoCompañia.Tables[4];
        grvTransferencias.DataBind();
        grvTransferencias.Visible = true;

        grvTotalGr.DataSource = dsPagoCompañia.Tables[1];
        grvTotalGr.DataBind();
        grvTotalGr.Visible = true;

        grvComision.DataSource = dsPagoCompañia.Tables[2];
        grvComision.DataBind();
        grvComision.Visible = true;

        /*grvComision2.DataSource = dsPagoOtrasCia.Tables[3];
        grvComision2.DataBind();
        grvComision2.Visible = true;*/


        btnDetallesPago.Enabled = true;
        Session["habilitarExportar"] = 1;
        pagoCompañia.Visible = true;
    }

    //Metodo que llena un drop de productos para la compañia seleccionada
    private void llenarDropProductosCompañia (DropDownList ddl, int compañia)
    {
       DataTable dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(compañia);

            ddl.DataTextField = "pro_Nombre";
            ddl.DataValueField = "pro_Id";
            ddl.DataSource = dtProducto;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Seleccione", ""));
    }
}