﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_ReporteDatosCelularRetiros : System.Web.UI.Page
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
        DateTime? fechaInicioRetiro = null;
        DateTime? fechaFinRetiro = null;

        if (txtFechaInicioRetiro.Text != "")
            fechaInicioRetiro = DateTime.ParseExact(txtFechaInicioRetiro.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinRetiro.Text != "")
            fechaFinRetiro = DateTime.ParseExact(txtFechaFinRetiro.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        DataTable dsReporte = Reporte.GenerarReporteDatosCelularRetiros(Utils.ObtenerIdsSeleccionados(lbxCompania), Utils.ObtenerIdsSeleccionados(lbxProducto),
            Utils.ObtenerIdsSeleccionados(lbxEstadoNegocio), fechaInicioRetiro, fechaFinRetiro, null, null);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/ReporteDatosCelularRetiros.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}