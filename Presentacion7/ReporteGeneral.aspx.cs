using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_ReporteGeneral : System.Web.UI.Page
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

            DataTable dtLocalidades = new DataTable();
            dtLocalidades = Reporte.mostrarDepartamento();
            lbxLocalidad.DataTextField = "dep_Nombre";
            lbxLocalidad.DataValueField = "dep_Id";
            lbxLocalidad.DataSource = dtLocalidades;
            lbxLocalidad.DataBind();
            lbxLocalidad.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtAgencias = new DataTable();
            dtAgencias = Reporte.ListarAgenciasPorFiltros("ALL");
            lbxAgencia.DataTextField = "age_Nombre";
            lbxAgencia.DataValueField = "age_Id";
            lbxAgencia.DataSource = dtAgencias;
            lbxAgencia.DataBind();
            lbxAgencia.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtConvenios = new DataTable();
            dtConvenios = Reporte.ListarNombreConvenios();
            lbxConvenio.DataTextField = "con_Nombre";
            lbxConvenio.DataValueField = "con_Nombre";
            lbxConvenio.DataSource = dtConvenios;
            lbxConvenio.DataBind();
            lbxConvenio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtAsesores = new DataTable();
            dtAsesores = Reporte.ConsultarAsesorDdl();
            lbxAsesor.DataTextField = "asesor";
            lbxAsesor.DataValueField = "ase_Id";
            lbxAsesor.DataSource = dtAsesores;
            lbxAsesor.DataBind();
            lbxAsesor.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            lbxCertificadoRecuperado.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
            lbxCertificadoRecuperado.Items.Insert(1, new ListItem("SI", "1"));
            lbxCertificadoRecuperado.Items.Insert(2, new ListItem("NO", "0"));
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
    protected void lbxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtAgencias = new DataTable();
        dtAgencias = Reporte.ListarAgenciasPorFiltros(Utils.ObtenerIdsSeleccionados(lbxLocalidad));
        lbxAgencia.DataTextField = "age_Nombre";
        lbxAgencia.DataValueField = "age_Id";
        lbxAgencia.DataSource = dtAgencias;
        lbxAgencia.DataBind();
        lbxAgencia.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime? fechaInicio = null;
        DateTime? fechaFin = null;

        if (txtFechaInicioProduccion.Text != "")
            fechaInicio = DateTime.ParseExact(txtFechaInicioProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinProduccion.Text != "")
            fechaFin = DateTime.ParseExact(txtFechaFinProduccion.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        DataTable dsReporte = Reporte.GenerarReporteGeneral(Utils.ObtenerIdsSeleccionados(lbxCompania), Utils.ObtenerIdsSeleccionados(lbxProducto),
             Utils.ObtenerIdsSeleccionados(lbxPagadurias), Utils.ObtenerIdsSeleccionados(lbxEstadoNegocio), Utils.ObtenerIdsSeleccionados(lbxLocalidad),
              Utils.ObtenerIdsSeleccionados(lbxAgencia), Utils.ObtenerIdsSeleccionados(lbxConvenio), Utils.ObtenerIdsSeleccionados(lbxAsesor),
               Utils.ObtenerIdsSeleccionados(lbxCertificadoRecuperado), fechaInicio, fechaFin);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/ReporteGeneral.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}