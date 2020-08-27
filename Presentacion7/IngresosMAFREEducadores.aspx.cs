using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_IngresosMAFREEducadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        string cedulas = null;
        DateTime? fechaInicio = null;
        DateTime? fechaFin = null;

        if (txtCedulas.Text != "")
            cedulas = txtCedulas.Text.Replace("\r", ",").Replace("\n", ",").Replace(" ", "");
        if (txtFechaInicioProduccion.Text != "")
            fechaInicio = DateTime.ParseExact(txtFechaInicioProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinProduccion.Text != "")
            fechaFin = DateTime.ParseExact(txtFechaFinProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        DataTable dsReporte = Reporte.GenerarIngresosMAFREEducadores(fechaInicio, fechaFin, cedulas);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/IngresosMAFREEducadores.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}