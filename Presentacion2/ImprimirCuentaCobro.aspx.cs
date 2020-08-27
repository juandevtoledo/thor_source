using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;

public partial class Presentacion2_ImprimirCuentaCobro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            DataTable dtNovedadCuentaCobro = (DataTable)Session["dtNovedadCuentaCobro"];
            DataTable dtNovedadCuentaCobroDatos = (DataTable)Session["dtNovedadCuentaDatos"];

            // Asignar datos pagaduria
            lblConsecutivo.Text = Session["cueCob_Id"].ToString();
            lblAgencia.Text = Session["agencia"].ToString();
            lblFechaInicial.Text = System.DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy");
            lblPagaduriaCarta.Text = Session["nombrePagaduria"].ToString();
            lblPagaduriaCarta2.Text = Session["nombrePagaduria"].ToString();

            totalCuentaCobro.Text = Session["totalCuentaCobro"].ToString();
            lblDireccion.Text = Session["direccionPagaduria"].ToString();
            lblTelefono.Text = Session["telefonoPagaduria"].ToString();
            lblNombreDirector.Text = Session["nombreDirector"].ToString();
            //Vivi y Daniela
            lblCargo.Text = Session["cargo"].ToString();


            // Fecha mes de descuento
            lblMesDescuento.Text = Session["mesCuentaCobro"].ToString();
            lblAnioDescuento.Text = Session["anioCuentaCobro"].ToString();

            int mesDescuento = int.Parse(Session["mesCuentaCobroNum"].ToString());
            int anioDescuento = int.Parse(Session["anioCuentaCobro"].ToString());
            int mes = mesDescuento + 1;
            int anio = anioDescuento;

            if (mes > 12)
            {
                mes = 1;
                anio = anio + 1;
            }
            string nombreMes = new DateTime(2015, mes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

            lblMesVigencia.Text = nombreMes;
            lblAnioVigencia.Text = anio.ToString();

            lblNombreAgencia.Text = Session["nombreAgencia"].ToString();
            lblDireccionAgencia.Text = Session["direccionAgencia"].ToString();
            lblEmailAgencia.Text = Session["emailAgencia"].ToString();
            lblTelefonAgencia.Text = Session["telefonoAgencia"].ToString();

            grvMesCuentaDeCobro.DataSource = dtNovedadCuentaCobroDatos;
            grvMesCuentaDeCobro.DataBind();

            // Consultar cuenta bancaria realcionada a la cuenta de cobro
            int archivoId = int.Parse(Session["archivoId"].ToString());

            DataTable dtCuentaBancaria = new DataTable();
            dtCuentaBancaria = CuentasBancarias.ConsultarCuentasPorArchivo(archivoId);

            if (dtCuentaBancaria.Rows.Count > 0)
            {
                //lblCuentaBancariaCompania.Text = dtCuentaBancaria.Rows[0]["com_Nombre"].ToString();
                lblCuentaBancariaNumero.Text = dtCuentaBancaria.Rows[0]["cueBan_Numero"].ToString();
                lblCuentaBancariaTipo.Text = dtCuentaBancaria.Rows[0]["tipCue_Nombre"].ToString();
                lblCuentaBancariaBanco.Text = dtCuentaBancaria.Rows[0]["ban_Nombre"].ToString();
                if (dtCuentaBancaria.Rows[0]["com_Nombre"].ToString() == "TORRES GUARIN")
                {
                    lblCuentaBancariaPertenece.Text = "a nuestro nombre, ya que como intermediarios de seguros, nos corresponde recaudar los dineros ante la empresa, para proceder a hacer los pagos a la compañía aseguradora respectiva. A continuación la ";
                }
                else
                {
                    lblCuentaBancariaPertenece.Text = "a nombre de " + dtCuentaBancaria.Rows[0]["com_Nombre"].ToString() + ", A continuación la ";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('No hay cuenta bancaria asociada a esta cuenta de cobro');", true);
                Response.RedirectToRoute("cuentasCobro");
            }
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["cueCob_Id"] = "0";
        Response.RedirectToRoute("cuentasCobro");
    }
}