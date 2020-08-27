using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_InformeAseguradosExtraprimaPrevisora : System.Web.UI.Page
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

            DataTable dtPagadurias = new DataTable();
            dtPagadurias = Reporte.ListarPagaduriasPorFiltros("ALL", "ALL");
            lbxPagadurias.DataTextField = "paga_Nombre";
            lbxPagadurias.DataValueField = "paga_Nombre";
            lbxPagadurias.DataSource = dtPagadurias;
            lbxPagadurias.DataBind();
            lbxPagadurias.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtEstadoNegocios = new DataTable();
            dtEstadoNegocios = Reporte.ListarEstadosNegocioCertificados();
            lbxEstadoNegocio.DataTextField = "cer_EstadoNegocio";
            lbxEstadoNegocio.DataValueField = "cer_EstadoNegocio";
            lbxEstadoNegocio.DataSource = dtEstadoNegocios;
            lbxEstadoNegocio.DataBind();
            lbxEstadoNegocio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
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

        DataTable dtPagadurias = new DataTable();
        dtPagadurias = Reporte.ListarPagaduriasPorFiltros(Utils.ObtenerIdsSeleccionados(lbxCompania), "ALL");
        lbxPagadurias.DataTextField = "paga_Nombre";
        lbxPagadurias.DataValueField = "paga_Nombre";
        lbxPagadurias.DataSource = dtPagadurias;
        lbxPagadurias.DataBind();
        lbxPagadurias.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }

    protected void lbxProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtPagadurias = new DataTable();
        dtPagadurias = Reporte.ListarPagaduriasPorFiltros(Utils.ObtenerIdsSeleccionados(lbxCompania), Utils.ObtenerIdsSeleccionados(lbxProducto));
        lbxPagadurias.DataTextField = "paga_Nombre";
        lbxPagadurias.DataValueField = "paga_Nombre";
        lbxPagadurias.DataSource = dtPagadurias;
        lbxPagadurias.DataBind();
        lbxPagadurias.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime? fechaInicioVigenciaRetiroPrincipal = null;
        DateTime? fechaFinVigenciaRetiroPrincipal = null;
        DateTime? fechaInicioVigenciaRetiroConyuge = null;
        DateTime? fechaFinVigenciaRetiroConyuge = null;
        long? anoInicioProduccion = null;
        long? anoFinProduccion = null;

        if (txtFechaInicioVigenciaRetiroPrincipal.Text != "")
            fechaInicioVigenciaRetiroPrincipal = DateTime.ParseExact(txtFechaInicioVigenciaRetiroPrincipal.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinVigenciaRetiroPrincipal.Text != "")
            fechaFinVigenciaRetiroPrincipal = DateTime.ParseExact(txtFechaFinVigenciaRetiroPrincipal.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaInicioVigenciaRetiroConyuge.Text != "")
            fechaInicioVigenciaRetiroConyuge = DateTime.ParseExact(txtFechaInicioVigenciaRetiroConyuge.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinVigenciaRetiroConyuge.Text != "")
            fechaFinVigenciaRetiroConyuge = DateTime.ParseExact(txtFechaFinVigenciaRetiroConyuge.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtAnoInicioProduccion.Text != "")
            anoInicioProduccion = Convert.ToInt64(txtAnoInicioProduccion.Text);
        if (txtAnoFinProduccion.Text != "")
            anoFinProduccion = Convert.ToInt64(txtAnoFinProduccion.Text);
        DataTable dsReporte = Reporte.GenerarInformeAseguradosExtraprimaPrevisora(Utils.ObtenerIdsSeleccionados(lbxCompania), Utils.ObtenerIdsSeleccionados(lbxProducto),
            Utils.ObtenerIdsSeleccionados(lbxPagadurias), Utils.ObtenerIdsSeleccionados(lbxEstadoNegocio), anoInicioProduccion, anoFinProduccion,
            fechaInicioVigenciaRetiroPrincipal, fechaFinVigenciaRetiroPrincipal, fechaInicioVigenciaRetiroConyuge, fechaFinVigenciaRetiroConyuge);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/InformeAseguradosExtraprimaPrevisora.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}