using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_EstadisticasProduccionSegurosBolivar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            DataTable dtCompanias = new DataTable();
            dtCompanias = Reporte.ListarCompanias();
            lbxCompania.DataTextField = "com_Nombre";
            lbxCompania.DataValueField = "com_Id";
            lbxCompania.DataSource = dtCompanias;
            lbxCompania.DataBind();
            lbxCompania.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            lbxConsolidar.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
            lbxConsolidar.Items.Insert(1, new ListItem("MESES", "MESES"));
            lbxConsolidar.Items.Insert(2, new ListItem("DEPARTAMENTO", "DEPARTAMENTO"));
            lbxConsolidar.Items.Insert(3, new ListItem("AGENCIA", "AGENCIA"));
            lbxConsolidar.Items.Insert(4, new ListItem("COMPAÑIA", "COMPAÑIA"));
            lbxConsolidar.Items.Insert(5, new ListItem("PRODUCTO", "PRODUCTO"));
        }
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime? fechaInicioProduccion = null;
        DateTime? fechaFinProduccion = null;
        string companias = Utils.ObtenerIdsSeleccionados(lbxCompania);
        string consolidarPor = Utils.ObtenerIdsSeleccionados(lbxConsolidar);
        string configuracionReporte = "";
        string filtros = "";

        if (txtFechaInicioProduccion.Text != "")
        {
            fechaInicioProduccion = DateTime.ParseExact(txtFechaInicioProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            filtros += "Fecha Inicio: " + fechaInicioProduccion.Value.ToString("yyyy-MM") + "; ";
        }
        if (txtFechaFinProduccion.Text != "")
        {
            fechaFinProduccion = DateTime.ParseExact(txtFechaFinProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            filtros += "Fecha Fin: " + fechaFinProduccion.Value.ToString("yyyy-MM") + "; ";
        }
        if (!("," + companias + ",").Contains(",ALL,"))
            filtros += "Compañías: " + Utils.ObtenerTextosSeleccionados(lbxCompania) + "; ";
        filtros = filtros.TrimEnd(new char[] { ';', ' ' });
        if(!String.IsNullOrEmpty(filtros))
            filtros = "FILTROS - " + filtros;

        if (("," + consolidarPor + ",").Contains(",ALL,"))
            configuracionReporte += "MOSTRAR_COLUMNA_MESES=1,MOSTRAR_COLUMNA_DEPARTAMENTO=1,MOSTRAR_COLUMNA_AGENCIA=1,MOSTRAR_COLUMNA_COMPAÑIA=1,MOSTRAR_COLUMNA_PRODUCTO=1,";
        else
        {
            if (("," + consolidarPor + ",").Contains(",MESES,"))
                configuracionReporte += "MOSTRAR_COLUMNA_MESES=1,";
            if (("," + consolidarPor + ",").Contains(",DEPARTAMENTO,"))
                configuracionReporte += "MOSTRAR_COLUMNA_DEPARTAMENTO=1,";
            if (("," + consolidarPor + ",").Contains(",AGENCIA,"))
                configuracionReporte += "MOSTRAR_COLUMNA_AGENCIA=1,";
            if (("," + consolidarPor + ",").Contains(",COMPAÑIA,"))
                configuracionReporte += "MOSTRAR_COLUMNA_COMPAÑIA=1,";
            if (("," + consolidarPor + ",").Contains(",PRODUCTO,"))
                configuracionReporte += "MOSTRAR_COLUMNA_PRODUCTO=1,";
        }
        DataTable dsReporte = Reporte.GenerarEstadisticasProduccionSegurosBolivar(companias, fechaInicioProduccion, fechaFinProduccion);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/EstadisticasProduccionSegurosBolivar.rdlc");

        ReportParameter configuracionParameter = new ReportParameter("Configuraciones", configuracionReporte);
        rvReporte.LocalReport.SetParameters(new ReportParameter[] { configuracionParameter });
        ReportParameter filtrosParameter = new ReportParameter("Filtros", filtros);
        rvReporte.LocalReport.SetParameters(new ReportParameter[] { filtrosParameter });

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}