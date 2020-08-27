﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion3_PagosCompanias : System.Web.UI.Page
{
    public PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    // Método de inicio del formulario
    protected void Page_Load(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (!IsPostBack)
        {
            DataTable dtLocalidad = objAdministrarCertificados.ConsultarLocalidades();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidad;
            ddlLocalidad.DataBind();

            DataTable dtCompania = objPrecargueProduccion.CargarCompanias();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dtCompania;
            ddlCompania.DataBind();

            DataTable dtSolicitudesCheques = AdministrarPagosCompanias.dtSolicitudesChequesSinTalon();
            grvTalones.DataSource = dtSolicitudesCheques;
            grvTalones.DataBind();
            Session["dtSolicitudesCheques"] = dtSolicitudesCheques;

            DataTable dtFacturacion = AdministrarPagosBolivar.ConsultarFacturacion();
            grvtronador.DataSource = dtFacturacion;
            grvtronador.DataBind();
            Session["dtFacturacion"] = dtFacturacion;
        }
    }

    // Creación de las cartas de pago
    protected void btnRealizarPagoCompania_Click(object sender, EventArgs e)
    {
        // Se deben cargar los recibos cuyo dinero se encuentre en las cuentas de Torres para esas fechas y para esa compañía
        DataTable dtCarta = new DataTable();
        DataSet dsSoportes = new DataSet();
        if (int.Parse(ddlCompania.SelectedValue.ToString()) != 1)
            dtCarta = AdministrarPagosCompanias.RecibosCuentasTorresGuarin(DateTime.Parse(txtFechaFinPago.Text), int.Parse(ddlCompania.SelectedValue.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
        else
        {
            dtCarta = AdministrarPagosCompanias.RecibosCuentasTorresGuarinSegurosBolivar(DateTime.Parse(txtFechaFinPago.Text), int.Parse(ddlCompania.SelectedValue.ToString()), int.Parse(ddlLocalidad.SelectedValue.ToString()), ddlProceso.SelectedValue.ToString());
            if (int.Parse(ddlProceso.SelectedValue.ToString()) == 3)
                dsSoportes = AdministrarPagosCompanias.ConsultarSoportesBancarios(dtCarta);
        }
        
        if (dtCarta.Rows.Count > 0)
        {
            Session["Facturacion"] = dtCarta;
            grvFacturacion.DataSource = dtCarta;
            grvFacturacion.DataBind();
            grvFacturacion.Visible = true;
            //Funciones.generarExcel(Page, dtCarta, "Novedad Mes");
            if (int.Parse(ddlProceso.SelectedValue.ToString()) == 3)
            {
                foreach (DataTable dtSoportes in dsSoportes.Tables)
                {
                    GridView grvSoportes = new GridView();
                    grvSoportes.CssClass = "table table-bordered table-hover table-striped";
                    grvSoportes.DataSource = dtSoportes;
                    grvSoportes.DataBind();
                    panSoportes.Controls.Add(grvSoportes);
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA" + "');", true);            
        }
        Session["dtCarta"] = dtCarta;
        Session["fechaPago"] = txtFechaFinPago.Text;
    }

    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompania.SelectedValue == "1")
        {
            localidad.Visible = true;
            proceso.Visible = true;
        }
        else
        {
            localidad.Visible = false;
            DataTable dtProducto = new DataTable();
            string compania = ddlCompania.SelectedValue.ToString();
            dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));
        }
    }

    protected void grvTalones_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
        grvTalones.EditIndex = e.NewEditIndex;
        grvTalones.DataSource = dtSolicitudesCheques;
        grvTalones.DataBind();
        Session["dtEliminarConyuge"] = dtSolicitudesCheques;
    }
    protected void grvTalones_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataTable dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
        if (((TextBox)this.grvTalones.Rows[e.RowIndex].Cells[4].Controls[0]).Text != "")
        {
            dtSolicitudesCheques.Rows[e.RowIndex]["solcheTalon"] = ((TextBox)this.grvTalones.Rows[e.RowIndex].Cells[4].Controls[0]).Text;            
            grvTalones.EditIndex = -1;
            grvTalones.DataSource = dtSolicitudesCheques;
            grvTalones.DataBind();
        }
        Session["dtEliminarConyuge"] = dtSolicitudesCheques;
    }

    protected void grvTalones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
        grvTalones.EditIndex = -1;
        grvTalones.DataSource = dtSolicitudesCheques;
        grvTalones.DataBind();
        Session["dtEliminarConyuge"] = dtSolicitudesCheques;
    }

    protected void btnGuardarTalones_Click(object sender, EventArgs e)
    {
        DataTable dtSolicitudesCheques = (DataTable)Session["dtSolicitudesCheques"];
        AdministrarPagosCompanias.ActualizarTalonSolicitudCheque(dtSolicitudesCheques);
    }

    protected void grvtronador_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dtFacturacion = (DataTable)Session["dtFacturacion"];
        grvtronador.EditIndex = e.NewEditIndex;
        grvtronador.DataSource = dtFacturacion;
        grvtronador.DataBind();
        Session["dtFacturacion"] = dtFacturacion;
    }

    protected void grvtronador_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataTable dtFacturacion = (DataTable)Session["dtFacturacion"];
        if (((TextBox)this.grvtronador.Rows[e.RowIndex].Cells[4].Controls[0]).Text != "")
        {
            dtFacturacion.Rows[e.RowIndex]["polizaTronador"] = ((TextBox)this.grvtronador.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
            dtFacturacion.Rows[e.RowIndex]["numeroFactura"] = ((TextBox)this.grvtronador.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
            grvtronador.EditIndex = -1;
            grvtronador.DataSource = dtFacturacion;
            grvtronador.DataBind();
        }
        Session["dtFacturacion"] = dtFacturacion;
    }

    protected void grvtronador_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dtFacturacion = (DataTable)Session["dtFacturacion"];
        grvtronador.EditIndex = -1;
        grvtronador.DataSource = dtFacturacion;
        grvtronador.DataBind();
        Session["dtFacturacion"] = dtFacturacion;
    }

    protected void btnGuardarTronador_Click(object sender, EventArgs e)
    {
        DataTable dtFacturacion = (DataTable)Session["dtFacturacion"];        
        AdministrarPagosBolivar.GuardarTronadorNumeroFacturacion(dtFacturacion);
    }

    protected void grvFacturacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["recibosUtilizados"] = AdministrarPagosBolivar.recibosUtilizados;
        Session["idFacturacion"] = e.CommandArgument.ToString();
        Session["idProceso"] = ddlProceso.SelectedValue.ToString();
        //Response.Redirect("PagosCompaniasDetalle.aspx");
        Response.RedirectToRoute("pagosCompaniasDetalle");
    }

    protected void btnExportarFacturacion_Click(object sender, EventArgs e)
    {
        DataTable dtCarta = (DataTable)Session["dtCarta"];
        Funciones.generarExcel(Page, dtCarta, "Facturacion");
    }
}