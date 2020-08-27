using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_EntregaProduccion : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);


        if (grvEntregaProduccion.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos idCartaRetiro y cer_Id de la tabla que se muestra al usuario 
            grvEntregaProduccion.HeaderRow.Cells[1].Visible = false;

            int cont = 0;
            foreach (GridViewRow rows in grvEntregaProduccion.Rows)
            {
                grvEntregaProduccion.Rows[cont].Cells[1].Visible = false;
                cont++;
            }
        }

    }

    protected void cargarDigitacion()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.TraerCertificado();
        grvEntregaProduccion.DataSource = dt;
        grvEntregaProduccion.DataBind();
    }

    protected void cargarCompañia()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        DataTable dtCompania = objDigitarProduccion.ListarCompania();
        ddlCompa.DataSource = dtCompania;
        ddlCompa.DataTextField = "com_Nombre";
        ddlCompa.DataValueField = "com_Id";
        ddlCompa.DataBind();
        ddlCompa.Items.Insert(0, new ListItem("NO APLICA", "0"));
    }

    protected void cargarProducto()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        DataTable dtProducto = objDigitarProduccion.ListarProducto(int.Parse(ddlCompa.SelectedValue));
        ddlProducto.DataSource = dtProducto;
        ddlProducto.DataTextField = "pro_Nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataBind();
        ddlProducto.Items.Insert(0, new ListItem("NO APLICA", "0"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();

        if (!IsPostBack)
        {
            cargarDigitacion();
            CargarAgencias();
            cargarCompañia();
        }

        txtNumeroPolizaDevolucion.Enabled = false;
        txtCedulaDevolucion.Enabled = false;
        txtNumeroPolizaDevolucion.Visible = false;
        txtCedulaDevolucion.Visible = false;
        txtPrima.Visible = false;
        txtObservaciones.Visible = false;
        ddlCausalDevolucion.Visible = false;
        ddlTipoDevolucion.Visible = false;
        btnRecetear.Visible = false;
        btnConfirmar.Visible = false;
        lblCedulaProduccion.Visible = false;
        lblObservaciones.Visible = false;
        lblPolizaDevolucion.Visible = false;
        lblPrima.Visible = false;
        lblTipoDevolucion.Visible = false;
        lblCausalDevolucion.Visible = false;
        btnImprimir.Visible = false;

    }

    protected void cargarCausales(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        try
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.cargarCausalDevolucion(int.Parse(ddlTipoDevolucion.SelectedValue.ToString()));
            ddlCausalDevolucion.DataTextField = "caudev_Nombre";
            ddlCausalDevolucion.DataValueField = "caudev_Id";
            ddlCausalDevolucion.DataSource = dt;
            ddlCausalDevolucion.DataBind();
            ddlCausalDevolucion.Items.Insert(0, new ListItem("Seleccione...", ""));
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Seleccione una causal" + "');", true);
        }
        txtNumeroPolizaDevolucion.Enabled = true;
        txtCedulaDevolucion.Enabled = true;
        txtNumeroPolizaDevolucion.Visible = true;
        txtCedulaDevolucion.Visible = true;
        txtPrima.Visible = true;
        txtObservaciones.Visible = true;
        ddlCausalDevolucion.Visible = true;
        ddlTipoDevolucion.Visible = true;
        btnRecetear.Visible = true;
        btnConfirmar.Visible = true;
        lblCedulaProduccion.Visible = true;
        lblObservaciones.Visible = true;
        lblPolizaDevolucion.Visible = true;
        lblPrima.Visible = true;
        lblTipoDevolucion.Visible = true;
        lblCausalDevolucion.Visible = true;

    }

    protected void CargarAgencias()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        try
        {
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.cargarAgenciaDdl();
            ddlagenciaProduccion.DataTextField = "age_Nombre";
            ddlagenciaProduccion.DataValueField = "age_Id";
            ddlagenciaProduccion.DataSource = dt;
            ddlagenciaProduccion.DataBind();
            ddlagenciaProduccion.Items.Insert(0, new ListItem("Seleccione...", ""));
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Seleccione una agencia" + "');", true);
        }
    }

    protected void CargarBusquedaAgencia(object sender, EventArgs e)
    {
        btnImprimir.Visible = true;
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.CargarBusquedaAgencia(int.Parse(ddlagenciaProduccion.SelectedValue.ToString()), 2);
        grvEntregaProduccion.DataSource = dt;
        grvEntregaProduccion.DataBind();
        Session["InformeFinal"] = dt;
    }

    protected void CargarBusquedaTercero(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtcedulaProduccion.Text == "")
        {
            cargarDigitacion();
        }
        else
        {
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaTercero(int.Parse(txtcedulaProduccion.Text), 2);
            grvEntregaProduccion.DataSource = dt;
            grvEntregaProduccion.DataBind();
            Session["InformeFinal"] = dt;
        }
    }

   
    protected void CargarBusquedaPoliza(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (txtnumeroCertificadoProduccion.Text == "")
        {
            cargarDigitacion();
        }
        else
        {
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPoliza(int.Parse(txtnumeroCertificadoProduccion.Text), 2);
            grvEntregaProduccion.DataSource = dt;
            grvEntregaProduccion.DataBind();
        }
    }

    protected void CargarBusquedaCompañia(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (ddlCompa.SelectedValue == "")
        {
            cargarDigitacion();
            
        }
        else
        {
            cargarProducto();
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaCompañia(int.Parse(ddlCompa.SelectedValue),2);
            grvEntregaProduccion.DataSource = dt;
            grvEntregaProduccion.DataBind();
            Session["InformeFinal"] = dt;
        }
    }

    protected void CargarBusquedaProducto(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        if (ddlProducto.SelectedValue == "")
        {
            cargarDigitacion();

        }
        else
        {
            btnImprimir.Visible = true;
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaProducto(int.Parse(ddlProducto.SelectedValue), 2);
            grvEntregaProduccion.DataSource = dt;
            grvEntregaProduccion.DataBind();
            Session["InformeFinal"] = dt;
        }
    }
   

    protected void EnviarDevolucion_Click(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        GridViewRow row = grvEntregaProduccion.SelectedRow;
        string id = Session["id"].ToString();
        int valUno = int.Parse(objDigitarProduccion.CargarProductoPorCertificado(int.Parse(id)).Rows[0]["pro_Id"].ToString());
        int valDos = 2;
        if (valUno == 99)
        {
            valDos = 3;
        }

        objDigitarProduccion.ActualizarEstado(int.Parse(id), valDos, 1, int.Parse(txtPrima.Text), int.Parse(ddlTipoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), txtObservaciones.Text);
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.TraerCertificado();
        grvEntregaProduccion.DataSource = dt;
        grvEntregaProduccion.DataBind();
       
        if((int.Parse(ddlTipoDevolucion.SelectedValue.ToString()) == 1 || int.Parse(ddlTipoDevolucion.SelectedValue.ToString()) 
        == 2 || int.Parse(ddlTipoDevolucion.SelectedValue.ToString()) == 7 ) && (valDos != 3))
        {
            DataTable dtActualizarEstadoNegocio = new DataTable();
            dtActualizarEstadoNegocio = objAdministrarCertificados.ActualizarEstadoNegocioDevolucion("ANULADO", int.Parse(id));
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "El registro se anuló" + "');", true);
        }
    }
     protected void grvEntregaProduccion_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         int index = Convert.ToInt32(e.CommandArgument);
         DigitarProduccion objDigitarProduccion = new DigitarProduccion();
         PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
         AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
         GridViewRow row = grvEntregaProduccion.Rows[(index)];
         if (e.CommandName == "Devolucion_Click")
         {
             txtNumeroPolizaDevolucion.Enabled = true;
             txtCedulaDevolucion.Enabled = true;
             txtNumeroPolizaDevolucion.Visible = true;
             txtCedulaDevolucion.Visible = true;
             txtPrima.Visible = true;
             txtObservaciones.Visible = true;
             ddlCausalDevolucion.Visible = true;
             ddlTipoDevolucion.Visible = true;
             btnRecetear.Visible = true;
             btnConfirmar.Visible = true;
             lblCedulaProduccion.Visible = true;
             lblObservaciones.Visible = true;
             lblPolizaDevolucion.Visible = true;
             lblPrima.Visible = true;
             lblTipoDevolucion.Visible = true;
             lblCausalDevolucion.Visible = true;
            

             Session["id"] = row.Cells[1].Text;//ID
             string Campo = row.Cells[7].Text;//proudcto
             txtNumeroPolizaDevolucion.Text = row.Cells[3].Text;//poliza
             txtCedulaDevolucion.Text = row.Cells[6].Text;//tercero
             
             txtNumeroPolizaDevolucion.Enabled = false;
             txtCedulaDevolucion.Enabled = false;

             if (IsPostBack)
             {

                 //if (Campo == "EDUCADORES PLUS")
                 //{
                     
                 //    try
                 //    {
                 //        DataTable dt = new DataTable();
                 //        dt = DigitarProduccion.ConsultarTipoDevolucionPlus();
                 //        ddlTipoDevolucion.DataTextField = "tipdev_Nombre";
                 //        ddlTipoDevolucion.DataValueField = "tipdev_Id";
                 //        ddlTipoDevolucion.DataSource = dt;
                 //        ddlTipoDevolucion.DataBind();
                 //        CargarAgencias();
                 //        ddlTipoDevolucion.Items.Insert(0, new ListItem("Seleccione...", ""));
                 //    }
                 //    catch
                 //    {
                 //        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR SELECCIIONE TIPO DE DEVOLUCION O DE LO CONTRARIO PRESIONE EL BOTON LIMPIAR" + "');", true);
                 //    }
                     

                 //}
                 //else
                 //{
                     try
                     {
                         DataTable dt = new DataTable();
                         dt = objDigitarProduccion.cargarTipoDevolucion();
                         ddlTipoDevolucion.DataTextField = "tipdev_Nombre";
                         ddlTipoDevolucion.DataValueField = "tipdev_Id";
                         ddlTipoDevolucion.DataSource = dt;
                         ddlTipoDevolucion.DataBind();
                         CargarAgencias();
                         ddlTipoDevolucion.Items.Insert(0, new ListItem("Seleccione...", ""));
                     }
                     catch
                     {
                         ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Seleccione un tipo de devolución" + "');", true);
                     }
                 //}
             }
         }
         if (e.CommandName == "Digitar_Click")
         {
             int cer_IdInformacion = int.Parse(row.Cells[1].Text);
             DataTable dtInformacionFrontera = new DataTable();
             dtInformacionFrontera = objAdministrarCertificados.ConsultarInformacionFechaFrontera(cer_IdInformacion);

             DataTable dtFrontera = new DataTable ();
             dtFrontera = objAdministrarCertificados.ConsultarFechaFrontera(int.Parse(dtInformacionFrontera.Rows[0]["age_Id"].ToString()), int.Parse(dtInformacionFrontera.Rows[0]["pro_Id"].ToString()), DateTime.Parse(dtInformacionFrontera.Rows[0]["cer_FechaExpedicion"].ToString()));
             try
             {
                 if (int.Parse(dtFrontera.Rows[0]["estado"].ToString()) == 0 && (int.Parse(dtInformacionFrontera.Rows[0]["casoEspecial"].ToString()) != 7))
                 {
                     //if (dtInformacionFrontera.Rows[0]["casoEspecial"] == null)
                     // {
                     ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "El sistema se encuentra cerrado para esta producción" + "');", true);

                 }
                 else
                 {
                     DataTable dtPro_Id = new DataTable();
                     dtPro_Id = objAdministrarCertificados.consultarProIdPorNombre(row.Cells[8].Text, row.Cells[7].Text);

                     DataTable dt = new DataTable();
                     //dt = AdministrarCertificados.consultarCertificadoExistente(int.Parse(row.Cells[7].Text), int.Parse(dtPro_Id.Rows[0]["pro_Id"].ToString()));
                     dt = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(row.Cells[2].Text), int.Parse(dtPro_Id.Rows[0]["pro_Id"].ToString()));

                     if (dt.Rows.Count > 0 )
                     {
                         Session["operacionCertificado"] = "modificar";
                     }
                     else
                     {
                         Session["operacionCertificado"] = "ingresar";
                     }
                     Session["ter_Id"] = row.Cells[2].Text;//tercero
                     Session["Producto"] = row.Cells[7].Text;
                     Session["cer_Id"] = row.Cells[1].Text;
                     Session["pro_Id"] = dtPro_Id.Rows[0]["pro_Id"].ToString();
                     Session["numeroCertificado"] = row.Cells[3].Text;//poliza
                     string poliza = Session["numeroCertificado"].ToString();
                     string valor = Session["ter_Id"].ToString();
                     
                     Session["Siguiente"] = false;
                     Session["flag"] = "2";
                     Response.RedirectToRoute("administrarTercero");
                }
             }
             catch
             {
                 ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Por favor cree un registro en cierre sistema" + "');", true);
             }
         }
     }
     protected void grvEntregaProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         grvEntregaProduccion.PageIndex = e.NewPageIndex;
         cargarDigitacion();
         
     }
     protected void btnBusquedaPlanilla_Click(object sender, EventArgs e)
     {
         btnImprimir.Visible = true;
         DigitarProduccion objDigitarProduccion = new DigitarProduccion();
         if (txtcedulaProduccion.Text != "")
         {
             CargarBusquedaTercero(sender, e);
         }

         if (txtnumeroCertificadoProduccion.Text != "")
         {
             DataTable dt = new DataTable();
             dt = objDigitarProduccion.CargarBusquedaPoliza(int.Parse(txtnumeroCertificadoProduccion.Text), 2);
             grvEntregaProduccion.DataSource = dt;
             grvEntregaProduccion.DataBind();
             dt = new DataTable();
         }
     }
    protected void LimpiarDevolucion_Click(object sender,EventArgs e)
     {
         txtNumeroPolizaDevolucion.Text = "";
         txtCedulaDevolucion.Text = "";
         txtPrima.Text = "";
         txtObservaciones.Text = "";
         txtNumeroPolizaDevolucion.Enabled = false;
         txtCedulaDevolucion.Enabled = false;
         txtNumeroPolizaDevolucion.Visible = false;
         txtCedulaDevolucion.Visible = false;
         txtPrima.Visible = false;
         txtObservaciones.Visible = false;
         ddlCausalDevolucion.Visible = false;
         ddlTipoDevolucion.Visible = false;
         btnRecetear.Visible = false;
         btnConfirmar.Visible = false;
         lblCedulaProduccion.Visible = false;
         lblObservaciones.Visible = false;
         lblPolizaDevolucion.Visible = false;
         lblPrima.Visible = false;
         lblTipoDevolucion.Visible = false;
         lblCausalDevolucion.Visible = false;
         
     }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("EntregaProduccion.aspx");
        Response.RedirectToRoute("entregaProduccion");
    }

    protected void btnDescargarExcel_Click(object sender, System.EventArgs e)
    {
        DataTable dtInforme = (DataTable)Session["InformeFinal"];

        if (grvEntregaProduccion.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtInforme, "Planilla digitación");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No hay información para descargar" + "');", true);

        }
    }

}