﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_Reportes_ReporteGeneralPagos : System.Web.UI.Page
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

            DataTable dtConvenios = new DataTable();
            dtConvenios = Reporte.ListarNombreConvenios();
            lbxConvenio.DataTextField = "con_Nombre";
            lbxConvenio.DataValueField = "con_Nombre";
            lbxConvenio.DataSource = dtConvenios;
            lbxConvenio.DataBind();
            lbxConvenio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

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

        if (txtFechaInicioVigencia.Text != "")
            fechaInicio = DateTime.ParseExact(txtFechaInicioVigencia.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        if (txtFechaFinVigencia.Text != "")
            fechaFin = DateTime.ParseExact(txtFechaFinVigencia.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
        DataTable dsReporte = Reporte.GenerarReporteGeneralPagos(Utils.ObtenerIdsSeleccionados(lbxCompania), Utils.ObtenerIdsSeleccionados(lbxProducto),
             Utils.ObtenerIdsSeleccionados(lbxPagadurias), Utils.ObtenerIdsSeleccionados(lbxEstadoNegocio), Utils.ObtenerIdsSeleccionados(lbxLocalidad),
              Utils.ObtenerIdsSeleccionados(lbxConvenio), Utils.ObtenerIdsSeleccionados(lbxDepartamento),
               Utils.ObtenerIdsSeleccionados(lbxCiudad), fechaInicio, fechaFin);

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "PDF", "WORD", "WORDOPENXML" });

        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/ReporteGeneralPagos.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
}