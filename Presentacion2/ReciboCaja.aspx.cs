using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion2_ReciboCaja : System.Web.UI.Page
{
    public Pagos objPago = new Pagos();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        
        Pagos objPagos = new Pagos();
        if (!IsPostBack)
        {

            //Session["rec_IdImprimirRecibo"] = 177654; //177654
            if (Session["IdRecibo"].ToString() != null)
            {
                // Dt para consultar la informacion del recibo a ser impreso con el rec_Id capturado en una variable de session
                DataTable dt = objPago.ConsultarReciboImprimir(int.Parse(Session["IdRecibo"].ToString()));

                // Dt para consultar las aplicaciones asociadas a un recibo para imprimir que sean de clientes con pago por oficina
                DataTable dt2 = objPago.ConsultarAplicacionesReciboImprimir(int.Parse(Session["IdRecibo"].ToString()));


                GenerarReporte(dt, dt2);

                Session.Contents.Remove("IdRecibo");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione UN RECIBO" + "');", true);
            }

        }
    }

    protected void GenerarReporte(DataTable dsReporte, DataTable dsReporte2)
    {
        //string convenios = Utils.ObtenerIdsSeleccionados(lbxConvenio);
        //DataTable dsReporte = Reporte.ListarConveniosImprimir(Session["idConvPaga"]+",");

        //Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "Excel", "WORD", "WORDOPENXML" });
        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/ReciboCaja3.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("DataSet1", dsReporte);
        ReportDataSource datasourceResultado2 = new ReportDataSource("DataSet2", dsReporte2);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
        rvReporte.LocalReport.DataSources.Add(datasourceResultado2);
    }
}