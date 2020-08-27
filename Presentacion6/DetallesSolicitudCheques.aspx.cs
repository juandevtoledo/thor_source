using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion6_DetallesSolicitudCheques : System.Web.UI.Page
{
    string url, jScript;
    protected void Page_Load(object sender, EventArgs e)
    {


        //Validacion de postback para cargar el grid del formulario donde valida que informacion debe cargar; se usa la variable ta

        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            AdministrarPagosBolivar objAdminPagosBol ;
            AdministrarPagosCompanias objAdminPagosCia;
            int tab = int.Parse(Session["tab"].ToString());
            //El tab 2 indica que se debe cargar los detalles asociados a la solictud de cheques; 
            if (tab == 2)
            {
                
                objAdminPagosBol = new AdministrarPagosBolivar();
                int localidad = 0;//int.Parse(Session["localidadSolicitud"].ToString());
                int idSolicitud = int.Parse(Session["idSolicitud"].ToString());
                lblId.Text = "Solicitud de Cheque: " + idSolicitud.ToString();
                DataTable dtDetallesSolicitudCheque = objAdminPagosBol.ConsultarDetallesSolicitudCheques(localidad, idSolicitud);
                Session["DetallesSolicitudCheque"] = dtDetallesSolicitudCheque;
                grvDetallesSolicitudCheque.DataSource = dtDetallesSolicitudCheque;
                grvDetallesSolicitudCheque.DataBind();
                grvDetallesSolicitudCheque.Visible = true;
            }

            //El tab 3 indica que se deben consultar las aplicaciones asociadas a la facturacion indicada
            if (tab == 3)
            {
                objAdminPagosBol = new AdministrarPagosBolivar();
                int idFacturacion = int.Parse(Session["idFacturacion"].ToString());
                lblId.Text = "Facturacion: " + idFacturacion.ToString();
                DataTable dtDetallesFacturacion = objAdminPagosBol.ConsultarDetallesFacturacion(idFacturacion);
                Session["DetallesFacturacion"] = dtDetallesFacturacion;
                grvDetallesFacturacion.DataSource = dtDetallesFacturacion;
                grvDetallesFacturacion.DataBind();
                grvDetallesFacturacion.Visible = true;
            }

            // El tab 4 indicad que el grid view se debe llenar a las aplicaciones asociadas  por prodcuto, fecha de corte y vigencia
            if (tab == 4)
            {
                objAdminPagosCia = new AdministrarPagosCompanias();
                int producto = int.Parse(Session["productoPago"].ToString());
                DateTime fecha = DateTime.Parse(Session["fechaPago"].ToString());
                DateTime vigencia = DateTime.Parse(Session["vigencia"].ToString());
                lblId.Text = "Detralles Pago: " + producto.ToString();
                DataTable dtDetallesPagosCias = objAdminPagosCia.ConsultarDetallesPagosCias(fecha, producto,vigencia);
                Session["DetallesPagosCias"] = dtDetallesPagosCias;
                grvDetallesPagosCias.DataSource = dtDetallesPagosCias;
                grvDetallesPagosCias.DataBind();
                grvDetallesPagosCias.Visible = true;
            }

            // El tab 5 indica que el gridview se debe llenar con las aplicaciones asociadas a un pago enviado a la compañia
            if (tab == 5)
            {
                objAdminPagosCia = new AdministrarPagosCompanias();
                int pagoId = int.Parse(Session["pagoId"].ToString());

                lblId.Text = "Detralles Pago: " + Session["pagoId"].ToString();
                DataTable dtDetallesPagosCias = objAdminPagosCia.ConsultarDetallesPagosCiasEnviado(pagoId);
                Session["DetallesPagosCiasEnviado"] = dtDetallesPagosCias;
                grvDetallesPagosCias.DataSource = dtDetallesPagosCias;
                grvDetallesPagosCias.DataBind();
                grvDetallesPagosCias.Visible = true;
            }
        }
    }

    //Evento que exporta a excel el Datatable correspondiente a la informacion segun el valor de la variable de session tab, que indica el origen de la informacion
    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {
        int tab = int.Parse(Session["tab"].ToString());
        if (tab == 2)
        {
            DataTable dtDetallesSolicitudCheque = (DataTable)Session["DetallesSolicitudCheque"];
            Funciones.generarExcel(Page, dtDetallesSolicitudCheque, "Detalles Solicitud de Cheques");
        }
        if (tab == 3)
        {
            DataTable dtDetallesFacturacion = (DataTable)Session["DetallesFacturacion"];
            Funciones.generarExcel(Page, dtDetallesFacturacion, "Detalles Facturacion");
        }
        if (tab == 4)
        {
            DataTable dtDetallesPagosCias = (DataTable)Session["DetallesPagosCias"];
            Funciones.generarExcel(Page, dtDetallesPagosCias, "Detalles Pago Compañia");
        }
    }

    //Evento para la paginacion del gridview
    protected void grvDetallesSolicitudCheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetallesSolicitudCheque.PageIndex = e.NewPageIndex;
        DataTable dtDetallesSolicitudCheque = (DataTable)Session["DetallesSolicitudCheque"];
        grvDetallesSolicitudCheque.DataSource = dtDetallesSolicitudCheque;
        grvDetallesSolicitudCheque.DataBind();
    }
  
}