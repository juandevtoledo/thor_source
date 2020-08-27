using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

public partial class Presentacion_ResumenProduccionNueva : System.Web.UI.Page
    
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        ddlAgencia.Enabled = false;
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();

        string nombreUsuario = Session["usuario"].ToString();
        DataTable dt = new DataTable();
        dt = objPrecargueProduccion.ConsultarAgencia(nombreUsuario);
        ddlAgencia.DataTextField = "age_Nombre";
        ddlAgencia.DataValueField = "age_Id";
        ddlAgencia.DataSource = dt;
        ddlAgencia.DataBind();
        
        if (! IsPostBack)
        ConsultarCertificado();


        if (grvPreCargue.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos y cer_Id de la tabla que se muestra al usuario 
            grvPreCargue.HeaderRow.Cells[2].Visible = false;

            int cont = 0;
            foreach (GridViewRow rows in grvPreCargue.Rows)
            {
                grvPreCargue.Rows[cont].Cells[2].Visible = false;
                cont++;
            }
        }

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (grvPreCargue.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos y cer_Id de la tabla que se muestra al usuario 
            grvPreCargue.HeaderRow.Cells[2].Visible = false;

            int cont = 0;
            foreach (GridViewRow rows in grvPreCargue.Rows)
            {
                grvPreCargue.Rows[cont].Cells[2].Visible = false;
                cont++;
            }
        }
    }

  
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public PrecargueProduccion certificado = new PrecargueProduccion();

    public void ConsultarCertificado()
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        DataTable dt = new DataTable();
        dt = objPrecargueProduccion.TraerCertificado(int.Parse(ddlAgencia.SelectedValue));
        grvPreCargue.DataSource = dt;          
        grvPreCargue.DataBind();
        Session["InformeFinal"] = dt;

        if(dt.Rows.Count == 0)
        {
            btnEnviar.Visible = false;
            btnImprimir.Visible = false;
        }
    }


    
    protected void grvPreCargue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPreCargue.PageIndex = e.NewPageIndex;
        ConsultarCertificado();
    }
    protected void grvPreCargue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvPreCargue.Rows.Count < grvPreCargue.PageSize) && (grvPreCargue.Rows.Count + grvPreCargue.PageSize * grvPreCargue.PageIndex < ((DataTable)(grvPreCargue.DataSource)).Rows.Count))
        e.Row.Cells[9].Visible = true;
    }
   

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        LinkButton lnkBorrar = (LinkButton)sender;
        objPrecargueProduccion.EliminarRegistroPrecargue(int.Parse(lnkBorrar.CommandArgument.ToString()));
        ConsultarCertificado();

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        foreach (GridViewRow row in grvPreCargue.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;
            
            if (check.Checked)
            {
                objPrecargueProduccion.ActualizarMomento(int.Parse(row.Cells[2].Text), 2);
                
            }
        }
        ConsultarCertificado();
    }

    protected void btnDescargarExcel_Click(object sender, System.EventArgs e)
    {
        DataTable dt = (DataTable)Session["InformeFinal"];

        if (grvPreCargue.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dt, "Planilla Precargue");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No hay información para descargar" + "');", true);

        }
    }

    protected void CargarTercero(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtcedula1.Text == "")
        {
            ConsultarCertificado();
        }
        else
        {
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarTercero(int.Parse(txtcedula1.Text), 2);
            grvPreCargue.DataSource = dt;
            grvPreCargue.DataBind();
            Session["InformeFinal"] = dt;
        }
    }

    protected void btnBusquedaPlanilla_Click(object sender, EventArgs e)
    {
        btnImprimir.Visible = true;
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();

        if (txtcedula1.Text != "")
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaTercero(int.Parse(txtcedula1.Text), 1);
            grvPreCargue.DataSource = dt;
            grvPreCargue.DataBind();
            btnBusquedaPlanilla.Visible = false;
            Session["InformeFinal"] = dt;
        }

        else if (txtCerti1.Text != "")
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPoliza(int.Parse(txtCerti1.Text), 1);
            grvPreCargue.DataSource = dt;
            grvPreCargue.DataBind();
            btnBusquedaPlanilla.Visible = false;
            Session["InformeFinal"] = dt;
            btnImprimir.Visible = true;
        }  
        else
            ConsultarCertificado();
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("EntregaProduccion.aspx");
        Response.RedirectToRoute("planillaprecargue");
    }

}
