using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_AsignacionCertificado : System.Web.UI.Page
{

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        formMostrar.Visible = false;

    }

    public void btnBuscar_Click(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
         if (txtDocumento.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Ingresar número de documento" + "');", true);
        
        }
        else
        {
            String ter_Id = txtDocumento.Text;
            DataTable dt = new DataTable();
            dt = objAdministrarCertificados.ConsultarCertificadoLiberty(ter_Id);

            if (dt.Rows.Count > 0)
            {
                txtCerId.Text = dt.Rows[0]["cer_Id"].ToString();
                txtCompania.Text = dt.Rows[0]["com_Nombre"].ToString();
                txtProducto.Text = dt.Rows[0]["pro_Nombre"].ToString();
                txtFechaExpedicionCertificado.Text = dt.Rows[0]["cer_FechaExpedicion"].ToString();
                txtFechaVigenciaCertificado.Text = dt.Rows[0]["cer_VigenciaDesde"].ToString();
                txtFechaDigitacionCertificado.Text = dt.Rows[0]["cer_FechaDigitacion"].ToString();
                txtCertificado.Text = dt.Rows[0]["cer_Certificado"].ToString();
                txtNombreAsesor.Text = dt.Rows[0]["ase_Nombres"].ToString();
                //txtPeriodoPagoCertificado.Text = dt.Rows[0]["con_Password"].ToString();
                txtLocalidadCertificado.Text = dt.Rows[0]["dep_nombre"].ToString();
                txtPoliza.Text = dt.Rows[0]["pol_Id"].ToString();
                txtAgencia.Text = dt.Rows[0]["age_nombre"].ToString();
                txtMesProduccion.Text = dt.Rows[0]["MesProduccionLetras"].ToString();
                txtEstadoNegocio.Text = dt.Rows[0]["cer_EstadoNegocio"].ToString();
                txtDeclaracionAsegurado.Text = dt.Rows[0]["cer_Declaracion"].ToString();
                //txtDeclaracionEG.Text = dt.Rows[0]["con_Vencimiento"].ToString();
                txtPrima.Text = dt.Rows[0]["cer_PrimaTotal"].ToString();
                txtTipoMovimiento.Text = dt.Rows[0]["tipMov_Nombre"].ToString();


                formMostrar.Visible = true;
                bucador.Visible = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No tiene certificados vigentes." + "');", true);
            }

                

            }
    }

    public void btnGuardar_Click(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (txtCertificado.Text != "")
        {
            objAdministrarCertificados.AsignarCertificado(int.Parse(txtCerId.Text), int.Parse(txtCertificado.Text));

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Número de certificado modificado');", true);
            formMostrar.Visible = true;
            txtCertificado.Enabled = false;
            botonAsignar.Visible = false;            
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Digitar número de certificado');", true);
            formMostrar.Visible = true;
        }
    }

    public void btnAtras_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion/AsignacionCertificado.aspx");
        Response.RedirectToRoute("asignacionCertificado");
    }
    
}