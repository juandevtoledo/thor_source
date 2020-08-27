using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_EstadisticasProduccionCompanias : System.Web.UI.Page
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

            DataTable dtProductos = new DataTable();
            dtProductos = Reporte.ListarProductosPorFiltros("ALL");
            lbxProducto.DataTextField = "pro_Nombre";
            lbxProducto.DataValueField = "pro_Nombre";
            lbxProducto.DataSource = dtProductos;
            lbxProducto.DataBind();
            lbxProducto.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtAgencias = new DataTable();
            dtAgencias = Reporte.ConsultarAgenciaDdl();
            lbxAgencia.DataTextField = "age_Nombre";
            lbxAgencia.DataValueField = "age_Id";
            lbxAgencia.DataSource = dtAgencias;
            lbxAgencia.DataBind();
            lbxAgencia.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            lbxConsolidar.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
            lbxConsolidar.Items.Insert(1, new ListItem("DEPARTAMENTO", "DEPARTAMENTO"));
            lbxConsolidar.Items.Insert(2, new ListItem("AGENCIA", "AGENCIA"));
            lbxConsolidar.Items.Insert(3, new ListItem("COMPAÑIA", "COMPAÑIA"));
            lbxConsolidar.Items.Insert(4, new ListItem("PRODUCTO", "PRODUCTO"));
        }
    }
    protected void lbxCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtProductos = new DataTable();
        dtProductos = Reporte.ListarProductosPorFiltros(Utils.ObtenerIdsSeleccionados(lbxCompania));
        lbxProducto.DataTextField = "pro_Nombre";
        lbxProducto.DataValueField = "pro_Nombre";
        lbxProducto.DataSource = dtProductos;
        lbxProducto.DataBind();
        lbxProducto.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime? mesProduccion = null;
        string companias = Utils.ObtenerIdsSeleccionados(lbxCompania);
        string productos = Utils.ObtenerIdsSeleccionados(lbxProducto);
        string agencias = Utils.ObtenerIdsSeleccionados(lbxAgencia);
        string consolidarPor = Utils.ObtenerIdsSeleccionados(lbxConsolidar);
        string configuracionReporte = "";
        string filtros = "";

        if (txtMesProduccion.Text != "")
        {
            mesProduccion = DateTime.ParseExact(txtMesProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            filtros += "Mes Producción: " + mesProduccion.Value.ToString("yyyy-MM") + "; ";
        }
        if (!("," + companias + ",").Contains(",ALL,"))
            filtros += "Compañías: " + Utils.ObtenerTextosSeleccionados(lbxCompania) + "; ";
        if (!("," + productos + ",").Contains(",ALL,"))
            filtros += "Productos: " + Utils.ObtenerTextosSeleccionados(lbxProducto) + "; ";
        if (!("," + agencias + ",").Contains(",ALL,"))
            filtros += "Agencias: " + Utils.ObtenerTextosSeleccionados(lbxAgencia) + "; ";
        filtros = filtros.TrimEnd(new char[] { ';', ' ' });
        if (!String.IsNullOrEmpty(filtros))
            filtros = "FILTROS - " + filtros;

        if (("," + companias + ",").Contains(",ALL,") || lbxCompania.GetSelectedIndices().Length > 1)
            configuracionReporte += "MOSTRAR_GRAFICA_COMPAÑIA=1,";
        if (("," + productos + ",").Contains(",ALL,") || lbxProducto.GetSelectedIndices().Length > 1)
            configuracionReporte += "MOSTRAR_GRAFICA_PRODUCTO=1,";
        if (("," + agencias + ",").Contains(",ALL,") || lbxAgencia.GetSelectedIndices().Length > 1)
            configuracionReporte += "MOSTRAR_GRAFICA_AGENCIA=1,";
        if (("," + consolidarPor + ",").Contains(",ALL,"))
            configuracionReporte += "MOSTRAR_COLUMNA_DEPARTAMENTO=1,MOSTRAR_COLUMNA_AGENCIA=1,MOSTRAR_COLUMNA_COMPAÑIA=1,MOSTRAR_COLUMNA_PRODUCTO=1,";
        else
        {
            if (("," + consolidarPor + ",").Contains(",DEPARTAMENTO,"))
                configuracionReporte += "MOSTRAR_COLUMNA_DEPARTAMENTO=1,";
            if (("," + consolidarPor + ",").Contains(",AGENCIA,"))
                configuracionReporte += "MOSTRAR_COLUMNA_AGENCIA=1,";
            if (("," + consolidarPor + ",").Contains(",COMPAÑIA,"))
                configuracionReporte += "MOSTRAR_COLUMNA_COMPAÑIA=1,";
            if (("," + consolidarPor + ",").Contains(",PRODUCTO,"))
                configuracionReporte += "MOSTRAR_COLUMNA_PRODUCTO=1,";
        }
        DataTable dsReporte = Reporte.GenerarEstadisticasProduccionCompañias(companias, productos, agencias, mesProduccion);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/EstadisticasProduccionCompañias.rdlc");

        ReportParameter configuracionParameter = new ReportParameter("Configuraciones", configuracionReporte);
        rvReporte.LocalReport.SetParameters(new ReportParameter[] { configuracionParameter });
        ReportParameter filtrosParameter = new ReportParameter("Filtros", filtros);
        rvReporte.LocalReport.SetParameters(new ReportParameter[] { filtrosParameter });

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}