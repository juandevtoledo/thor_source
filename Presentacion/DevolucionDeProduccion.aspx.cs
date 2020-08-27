using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_DevolucionDeProduccion : System.Web.UI.Page
{
    DigitarProduccion objDigitarProduccion = new DigitarProduccion();
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }

    protected void cargarDigitacion()
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.ConsultarCertificadoDevoluciones();
        grvDevolucionDeProduccion.DataSource = dt;
        grvDevolucionDeProduccion.DataBind();
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
            try
            {
                if (Session["devolucion"].ToString() == "DEVOLUCION")
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "ESTE CERTIFICADO SE ENVIARA FINALMENTE A DEVOLUCIÓN SEGUN EL DIRECTOR TECNICO" + "');", true);
                    Session["devolucion"] = "";
                }
            }
            catch { }
            CargarAgencias();
            cargarDigitacion();
        }
    }
    protected void CargarAgencias()
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        try
        {
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
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR SELECCIIONE UNA AGENCIA" + "');", true);
        }
    }

    protected void CargarBusquedaAgencia(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.CargarBusquedaAgenciaDevolucion(int.Parse(ddlagenciaProduccion.SelectedValue.ToString()));
        grvDevolucionDeProduccion.DataSource = dt;
        grvDevolucionDeProduccion.DataBind();
        dt = new DataTable();
    }

    protected void CargarBusquedaTerceroDevolucion(object sender, EventArgs e)
    {
        if (txtcedulaProduccion.Text == "")
        {
            cargarDigitacion();
        }

        else
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaTerceroDevolucion(int.Parse(txtcedulaProduccion.Text));
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();
            dt = new DataTable();
        }
    }

    protected void CargarBusquedaFechaDevolucion(object sender, EventArgs e)
    {
        if (txtDesde.Text == "" || txtHasta.Text == "")
        {
            cargarDigitacion();
        }
        else
        {

            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaFechaDevolucion(DateTime.Parse(txtDesde.Text), DateTime.Parse(txtHasta.Text));
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();
            dt = new DataTable();
        }
    }

    protected void CargarBusquedaPolizaDevolucion(object sender, EventArgs e)
    {
        if (txtnumeroCertificadoProduccion.Text == "")
        {
            cargarDigitacion();
        }

        else
        {
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPolizaDevolucion(int.Parse(txtnumeroCertificadoProduccion.Text));
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();
            dt = new DataTable();
        }
    }

    protected void grvDevolucionDeProduccion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = grvDevolucionDeProduccion.Rows[(index)];
        if(e.CommandName=="recuperar_Click")
        {
            
            Session["id_CertificadoDevolucion"] = null;
            string Actualizar = row.Cells[16].Text;
            string ActualizarRecuperable = row.Cells[17].Text;

            if (Actualizar == "Recuperable" && ActualizarRecuperable == "Devolucion")
            {
                objDigitarProduccion.ActualizarTidevRecuperable(int.Parse(row.Cells[2].Text), 1);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "ESTE CERTIFICADO FUE RECUPERADO Y SE ENCUENTRA EN LA PLANILLA DE PRE CARGUE" + "');", true);
            }
            if (Actualizar == "No recuperable" && ActualizarRecuperable == "Devolucion por confirmar")
            {
                objDigitarProduccion.ActualizarTidevRecuperable(int.Parse(row.Cells[2].Text), 5);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "ESTE CERTIFICADO FUE RECUPERADO SEGUN EL DIRECTOR TECNICO Y SE ENCUENTRA EN LA PLANILLA DE PRE CARGUE" + "');", true);
            }
            if (Actualizar == "No recuperable" && ActualizarRecuperable == "Devolucion")
            {
               
                Session["recuperable"] = "NORECUPERABLE";
                Session["id_CertificadoDevolucion"] = row.Cells[2].Text;
                //Response.Redirect("ProduccionNueva.aspx");
                Response.RedirectToRoute("produccionNueva");
                
            }
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.ConsultarCertificadoDevoluciones();
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();
        }
        if (e.CommandName == "devolver_Click")
        {
            Session["devolucion"] = "DEVOLUCION";

            objDigitarProduccion.ActualizarEstcarDevolucion(int.Parse(row.Cells[2].Text), 2);
            DataTable dt = new DataTable();
            dt = objDigitarProduccion.ConsultarCertificadoDevoluciones();
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();

            DataTable dtAnularCertificadoPlus = new DataTable();
            AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            dtAnularCertificadoPlus = objAdministrarCertificados.ActualizarEstadoNegocioDevolucion("ANULADO", int.Parse(row.Cells[2].Text));

            //Response.Redirect("DevolucionDeProduccion.aspx");
            Response.RedirectToRoute("devolucionProduccion");

        }
    }
    protected void grvDevolucionDeProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDevolucionDeProduccion.PageIndex = e.NewPageIndex;
        cargarDigitacion();
    }
    protected void btnBusquedaPlanilla_Click(object sender, EventArgs e)
    {
        if (txtcedulaProduccion.Text != "")
        {
            CargarBusquedaTerceroDevolucion(sender, e);
        }
        if (txtnumeroCertificadoProduccion.Text != "")
        {

            DataTable dt = new DataTable();
            dt = objDigitarProduccion.CargarBusquedaPolizaDevolucion(int.Parse(txtnumeroCertificadoProduccion.Text));
            grvDevolucionDeProduccion.DataSource = dt;
            grvDevolucionDeProduccion.DataBind();
            dt = new DataTable();
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("DevolucionDeProduccion.aspx");
        Response.RedirectToRoute("devolucionProduccion");
    }
}