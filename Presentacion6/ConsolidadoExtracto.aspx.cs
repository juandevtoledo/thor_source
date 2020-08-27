using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion6_ConsolidadoExtracto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            ddlProducto.Items.Clear();
            ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlProducto.Items.Insert(1, new ListItem("710", "710"));
            ddlProducto.Items.Insert(2, new ListItem("724", "724"));
            ddlProducto.Items.Insert(3, new ListItem("799", "799"));
            ddlProducto.Items.Insert(4, new ListItem("700", "700"));
            ddlProducto.Items.Insert(5, new ListItem("701", "701"));
            ddlProducto.Items.Insert(6, new ListItem("702", "701"));
            ddlProducto.Items.Insert(7, new ListItem("711", "711"));
            ddlProducto.Items.Insert(8, new ListItem("712", "712"));
            ddlProducto.Items.Insert(9, new ListItem("713", "713"));

            AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
            DataTable dtConsultarPolizasBolivar = new DataTable();
            dtConsultarPolizasBolivar = objAdminPagosBol.ConsultarPolizasBolivar();
            ddlGr.DataValueField = "pol_Id";
            ddlGr.DataTextField = "pol_Numero";
            ddlGr.DataSource = dtConsultarPolizasBolivar;
            ddlGr.DataBind();
            ddlGr.Items.Insert(0, new ListItem("TODOS", "0"));

            AdministrarCertificados objAdminCertificado = new AdministrarCertificados();
            DataTable dtLocalidad = objAdminCertificado.ConsultarLocalidades();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidad;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlLocalidad.Items.Insert(34, new ListItem("FIDUCIAS", "34"));
        }
    }

    //Evento que consulta las comisiones pagadas por la compañia segun los extractos cargados por los filtros respectivos y carga el gridview
    protected void btnConsultarConsolidado_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DataTable dtConsultarExtractoSegurosBolivar = new DataTable();
        int producto = 0;
        string localidad = "";
        DateTime fechaPago = Convert.ToDateTime("01/01/0001");
        int poliza = 0;

        if (ddlProducto.SelectedValue.ToString() != "")
        {
            producto = int.Parse(ddlProducto.SelectedValue.ToString());
        }

        if (ddlLocalidad.SelectedValue.ToString() != "")
        {
            localidad = (ddlLocalidad.SelectedItem.ToString());
        }

        if (txtFechaEnvio.Text != "")
        {
            fechaPago = Convert.ToDateTime(txtFechaEnvio.Text);
        }
        if (ddlGr.SelectedValue.ToString() != "")
        {
            poliza = int.Parse(ddlGr.SelectedValue.ToString());
        }



        dtConsultarExtractoSegurosBolivar = objAdminPagosBol.ConsultarConsolidadoExtractoBolivar(producto, localidad, fechaPago, poliza);
        grvExtractoSegurosBolivar.DataSource = dtConsultarExtractoSegurosBolivar;
        grvExtractoSegurosBolivar.DataBind();
    }
}