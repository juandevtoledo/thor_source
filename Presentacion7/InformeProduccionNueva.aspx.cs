using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_InformeProduccionNueva : System.Web.UI.Page
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

            DataTable dtEstadoNegocios = new DataTable();
            dtEstadoNegocios = Reporte.ListarEstadosNegocioCertificados();
            lbxEstadoNegocio.DataTextField = "cer_EstadoNegocio";
            lbxEstadoNegocio.DataValueField = "cer_EstadoNegocio";
            lbxEstadoNegocio.DataSource = dtEstadoNegocios;
            lbxEstadoNegocio.DataBind();
            lbxEstadoNegocio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtDepartamentos = new DataTable();
            dtDepartamentos = Reporte.mostrarDepartamento();
            lbxDepartamento.DataTextField = "dep_Nombre";
            lbxDepartamento.DataValueField = "dep_Id";
            lbxDepartamento.DataSource = dtDepartamentos;
            lbxDepartamento.DataBind();
            lbxDepartamento.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtCiudades = new DataTable();
            dtCiudades = Reporte.ConsultarCiudadDdl();
            lbxCiudad.DataTextField = "ciu_Nombre";
            lbxCiudad.DataValueField = "ciu_Id";
            lbxCiudad.DataSource = dtCiudades;
            lbxCiudad.DataBind();
            lbxCiudad.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
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

    protected void lbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtCiudades = new DataTable();
        dtCiudades = Reporte.ListarCiudadesPorFiltros(Utils.ObtenerIdsSeleccionados(lbxDepartamento));
        lbxCiudad.DataTextField = "ciu_Nombre";
        lbxCiudad.DataValueField = "ciu_Id";
        lbxCiudad.DataSource = dtCiudades;
        lbxCiudad.DataBind();
        lbxCiudad.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime? fechaInicio = null;
        DateTime? fechaFin = null;
        string productos = Utils.ObtenerIdsSeleccionados(lbxProducto);
        string configuracionReporte = "";

        if (txtFechaInicioVigencia.Text != "")
            fechaInicio = DateTime.ParseExact(txtFechaInicioVigencia.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinVigencia.Text != "")
            fechaFin = DateTime.ParseExact(txtFechaFinVigencia.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

        if (("," + productos + ",").Contains(",ALL,"))
            configuracionReporte += "MOSTRAR_COLUMNA_DEPARTAMENTO=1,MOSTRAR_COLUMNA_CIUDAD=1,MOSTRAR_COLUMNA_PRODUCTO=1";

        DataTable dsReporte = Reporte.GenerarInformeProduccionNueva(Utils.ObtenerIdsSeleccionados(lbxCompania), productos,
             Utils.ObtenerIdsSeleccionados(lbxEstadoNegocio), Utils.ObtenerIdsSeleccionados(lbxDepartamento), Utils.ObtenerIdsSeleccionados(lbxCiudad), fechaInicio, fechaFin);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/InformeProduccionNueva.rdlc");

        ReportParameter configuracionParameter = new ReportParameter("Configuraciones", configuracionReporte);
        rvReporte.LocalReport.SetParameters(new ReportParameter[] { configuracionParameter });

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}