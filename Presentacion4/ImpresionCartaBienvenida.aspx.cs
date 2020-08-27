using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion4_ImpresionCartaBienvenida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            
           /* DataTable dtPagadurias = new DataTable();
            dtPagadurias = Reporte.ListarPagadurias(null);
            lbxPagadurias.DataTextField = "paga_Nombre";
            lbxPagadurias.DataValueField = "paga_Id";
            lbxPagadurias.DataSource = dtPagadurias;
            lbxPagadurias.DataBind();
            lbxPagadurias.Items.Insert(0, new ListItem("(TODOS)", "ALL"));

            DataTable dtConvenios = new DataTable();
            dtConvenios = Reporte.ListarConveniosLocalidad(null);
            lbxConvenio.DataTextField = "con_Nombre";
            lbxConvenio.DataValueField = "con_Id";
            lbxConvenio.DataSource = dtConvenios;
            lbxConvenio.DataBind();
            lbxConvenio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));*/
            lbxConvenio.Visible = false;
            lbxPagadurias.Visible = false;
            btnGenerarReporte.Visible = false;
            DataTable dt = Reporte.ListarConveniosImprimir(Session["idConvPaga"] + ",");
            //lblAccion.Text = "Convenio Id. " + dt.Rows[0]["con_Id"].ToString() + ": "
            //            + dt.Rows[0]["con_Nombre"].ToString() + " [ " + dt.Rows[0]["con_Id"].ToString() + " ]"
            //            + "<br> &nbsp;&nbsp; Pagaduria Id. " + Session["idPaga"].ToString() + ": " + dt.Rows[0]["paga_Nombre"].ToString()
            //            + " [ " + dt.Rows[0]["paga_Identificacion"].ToString() + " ]";
            GenerarReporte(dt);
        }
    }
    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        /*string convenios = Utils.ObtenerIdsSeleccionados(lbxConvenio);
        DataTable dsReporte = Reporte.ListarConveniosImprimir(Session["idConvPaga"]+",");

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "Excel", "WORD", "WORDOPENXML" });
        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/ImpresionConvenio.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);*/
        //GenerarReporte();
    }

     protected  void GenerarReporte(DataTable dsReporte)
    {
        string convenios = Utils.ObtenerIdsSeleccionados(lbxConvenio);
        //DataTable dsReporte = Reporte.ListarConveniosImprimir(Session["idConvPaga"]+",");

        Utils.DeshabilitarFormatoExportacion(rvReporte, new string[] { "Excel", "WORD", "WORDOPENXML" });
        rvReporte.ProcessingMode = ProcessingMode.Local;
        rvReporte.LocalReport.ReportPath = Server.MapPath("~/App_Code/Reportes/InformeCartaBienvenida.rdlc");

        ReportDataSource datasourceResultado1 = new ReportDataSource("dsReporte", dsReporte);
        rvReporte.LocalReport.DataSources.Clear();
        rvReporte.LocalReport.DataSources.Add(datasourceResultado1);
    }
    protected void lbxPagadurias_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtConvenios = new DataTable();
        dtConvenios = Reporte.ListarConveniosLocalidad(Utils.ObtenerIdsSeleccionados(lbxPagadurias));
        lbxConvenio.DataTextField = "con_Nombre";
        lbxConvenio.DataValueField = "con_Id";
        lbxConvenio.DataSource = dtConvenios;
        lbxConvenio.DataBind();
        lbxConvenio.Items.Insert(0, new ListItem("(TODOS)", "ALL"));
    }
}