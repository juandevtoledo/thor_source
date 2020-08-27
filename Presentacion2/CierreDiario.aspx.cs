using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion2_CierreDiario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
            
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        Pagos objPago = new Pagos();
        DataTable dtAgencia = new DataTable();
        if (!IsPostBack)
        {
            //Carga las agencias, trayendo el Id y el nombre de ellas
            dtAgencia = objPago.ConsultarAgenciasUsuario(Session["usuario"].ToString());
            ddlAgencia.DataValueField = "age_Id";
            ddlAgencia.DataTextField = "age_Nombre";
            ddlAgencia.DataSource = dtAgencia;
            ddlAgencia.DataBind();
            //ddlAgencia.Items.Insert(0, new ListItem("TODOS", "0"));

            DataTable dtCompania = objPrecargueProduccion.CargarCompanias();
            ddlCompañia.DataTextField = "com_Nombre";
            ddlCompañia.DataValueField = "com_Id";
            ddlCompañia.DataSource = dtCompania;
            ddlCompañia.DataBind();
            ddlCompañia.Items.Insert(0, new ListItem("TODOS", "0"));

            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            //ddlProducto.DataSource = dtProducto;
            //ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("TODOS", "0"));

            Session["dtRecibosCaja"] = null;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (grvRecibosCaja.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos idCartaRetiro y cer_Id de la tabla que se muestra al usuario 
            grvRecibosCaja.HeaderRow.Cells[0].Visible = false;


            int cont = 0;
            foreach (GridViewRow rows in grvRecibosCaja.Rows)
            {
                grvRecibosCaja.Rows[cont].Cells[0].Visible = false;
                cont++;
            }
        }

    }
    protected void btnConsultarRecibos_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        DataTable dtRecibosCaja;


        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = DateTime.Now;
        int agencia = 0, producto = 0, compañia = 0;

        if (txtFechaInicioRecibos.Text != "")
        {
            fechaInicio = Convert.ToDateTime(txtFechaInicioRecibos.Text);
        }
        if (txtFechaFinRecibos.Text != "")
        {
            fechaFin = Convert.ToDateTime(txtFechaFinRecibos.Text);
        }
        agencia = int.Parse(ddlAgencia.SelectedValue.ToString());
        producto = int.Parse(ddlProducto.SelectedValue.ToString());
        compañia = int.Parse(ddlCompañia.SelectedValue.ToString());

       
            //DateTime fechaCorte = DateTime.Parse("01/01/1900");
            dtRecibosCaja = objAdminPagosBol.ConsultarRecibosCaja(fechaInicio, fechaFin, agencia, producto, compañia);


            if (dtRecibosCaja != null && dtRecibosCaja.Rows.Count > 0)
            {
                grvRecibosCaja.DataSource = dtRecibosCaja;
                grvRecibosCaja.DataBind();
                Session["dtRecibosCaja"] = dtRecibosCaja;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay recibos para esta búsqueda');", true);
            }

        //DateTime fechaCorte = DateTime.Parse("01/01/1900");
        dtRecibosCaja = objAdminPagosBol.ConsultarRecibosCaja(fechaInicio, fechaFin,agencia,producto,compañia);

        grvRecibosCaja.DataSource = dtRecibosCaja;
        grvRecibosCaja.DataBind();
        Session["dtRecibosCaja"] = dtRecibosCaja;

    }
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        string compania = ddlCompañia.SelectedValue.ToString();
        DataTable dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(int.Parse(compania));

        ddlProducto.DataTextField = "pro_Nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataSource = dtProducto;
        ddlProducto.DataBind();
        ddlProducto.Items.Insert(0, new ListItem("TODOS", "0"));
    }

     protected void btnExportarExcelCierre_Click(object sender, EventArgs e)
    {
        DataTable dtRecibosCaja = (DataTable)Session["dtRecibosCaja"];
        if (dtRecibosCaja != null && dtRecibosCaja.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtRecibosCaja, "CierreDiario");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No hay registros para exportar a excel');", true);
        }
    }
    #region Paginador

    protected void grvRecibosCaja_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRecibosCaja.PageIndex = e.NewPageIndex;
        DataTable dtRecibosCaja = (DataTable)Session["dtRecibosCaja"];
        grvRecibosCaja.DataSource = dtRecibosCaja;
        grvRecibosCaja.DataBind();
    }


    protected void grvRecibosCaja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvRecibosCaja.Rows.Count < grvRecibosCaja.PageSize) && (grvRecibosCaja.Rows.Count + grvRecibosCaja.PageSize * grvRecibosCaja.PageIndex < ((DataTable)(grvRecibosCaja.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }
    #endregion

}