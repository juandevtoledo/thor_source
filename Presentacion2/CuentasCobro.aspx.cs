using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;


public partial class Presentacion2_FrmCuentasCobro : System.Web.UI.Page
{
    int diaLimiteEliminacion = 30;
    public static DataTable dtNovedad = new DataTable();
    public static DataTable dtNovedadArchivo = new DataTable();
    public static DataTable dtNovedadArchivoPendiente = new DataTable();
    public static DataTable dtNovedadArchivoAplicadas = new DataTable();
    public static DataTable dtNovedadArchivoSinAplicar = new DataTable();
    public static DataTable dtNovedadArchivoCuentaCobro = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        
        if(!IsPostBack)
        {
            // Inicializar las variables
            Session["mes"] = "";
            Session["anio"] = "";
            Session["cueCob_Id"] = "";

            // Deshabilitar los ddl
            ddlMes.Enabled = false;
            ddlAnio.Enabled = false;
            txtConsultarCuentaCobro.Enabled = false;
            btnExportarExcel.Visible = false;

            datosCuentaCobro.Visible = false;
            nocuentacobrodatos.Visible = true;

            listaCuentasCobro.Visible = false;
            nocuentascobro.Visible = false;
            
            listaCuentasCobroDatos.Visible = false;
          

            dtNovedad.Clear();
            dtNovedadArchivo.Clear();
            dtNovedadArchivoCuentaCobro.Clear();
            dtNovedadArchivoPendiente.Clear();
            DataTable dtUsuario = PrecargueProduccion.ConsultarUsuario(Session["usuario"].ToString());

            DataTable dtLocalidadeasAgencia = new DataTable();
            dtLocalidadeasAgencia = AdministrarNovedades.LocalidadesAgencia(int.Parse(dtUsuario.Rows[0]["age_Id"].ToString()));
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidadeasAgencia;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));

            DataTable dtMes = new DataTable();
            dtMes = AdministrarNovedades.ConsultarMes();
            ddlMes.DataTextField = "mes_Nombre";
            ddlMes.DataValueField = "mes_Id";
            ddlMes.DataSource = dtMes;
            ddlMes.DataBind();
            ddlMes.Items.Insert(0, new ListItem("", ""));

            DataTable dtAnio = new DataTable();
            dtAnio = AdministrarNovedades.ConsultarAnio();
            ddlAnio.DataTextField = "anio_Numero";
            ddlAnio.DataValueField = "anio_Numero";
            ddlAnio.DataSource = dtAnio;
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new ListItem("", ""));

            btnImprimirCuentaDeCobro.Visible = false;
            btnGuardarCuentasCobro.Visible = false;
            btnExportarExcelAnt.Visible = false;
        }
    }

    protected void ddlLocalidad_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlLocalidad.SelectedItem.ToString() != "")
        {
            DataTable dtPagaduria = new DataTable();
            dtPagaduria = AdministrarNovedades.ConsultarPagaduriaLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            ddlPagaduria.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlPagaduria.Items.Clear();
            ddlPagaduria.SelectedIndex = -1;
        }
    }

    protected void ddlPagaduria_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlPagaduria.SelectedItem.ToString() != "")
        {
            DataTable dtArchivoPagaduria = new DataTable();
            dtArchivoPagaduria = AdministrarNovedades.ConsultarArchivoPagaduria(int.Parse(ddlPagaduria.SelectedValue.ToString()), "1");
            ddlArchivo.DataTextField = "arcpag_Nombre";
            ddlArchivo.DataValueField = "arcpag_Id";
            ddlArchivo.DataSource = dtArchivoPagaduria;
            ddlArchivo.DataBind();
            ddlArchivo.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddlArchivo.Items.Clear();
            ddlArchivo.SelectedIndex = -1;
        }
    }

    protected void ddlArchivo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Habilitar los ddl
        ddlMes.Enabled = true;
        ddlAnio.Enabled = true;
        txtConsultarCuentaCobro.Enabled = true;


        datosCuentaCobro.Visible = false;
        listaCuentasCobro.Visible = false;
        listaCuentasCobroDatos.Visible = false;

        Session["archivoId"] = ddlArchivo.SelectedValue.ToString();
        
        if (ddlArchivo.SelectedItem.ToString() != "")
        {
            DataTable dtTipoArchivo = new DataTable();
            dtTipoArchivo = AdministrarNovedades.ConsultarTipoArchivoNovedades(int.Parse(Session["archivoId"].ToString()));

            if(dtTipoArchivo.Rows.Count > 0)
            {
                if (dtTipoArchivo.Rows[0]["arcpag_TipoArchivo"].ToString() == "1")
                {
                    ddlAnio_SelectedIndexChanged(sender, e);
                }
            }

            dtNovedadArchivoCuentaCobro = AdministrarNovedades.ConsultarRegistroCuentaDeCobro(int.Parse(ddlArchivo.SelectedValue.ToString()), int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlPagaduria.SelectedValue.ToString()), 1, 0);
            grvMesCuentaDeCobroDatos.DataSource = dtNovedadArchivoCuentaCobro;
            grvMesCuentaDeCobroDatos.DataBind();

            if (dtNovedadArchivoCuentaCobro.Rows.Count > 0)
            {
                DataTable dtInformacionPagaduria = new DataTable();
                dtInformacionPagaduria = AdministrarNovedades.ConsultarInformacionPagaduria(int.Parse(ddlPagaduria.SelectedValue.ToString()));
                DataTable dtInformacionPieCarta = new DataTable();
                dtInformacionPieCarta = AdministrarNovedades.ConsultarInformacionAgenciaNovedades(int.Parse(ddlLocalidad.SelectedValue.ToString()),int.Parse(ddlPagaduria.SelectedValue.ToString()));

                // DATOS PARA INFORME CUENTA DE COBRO
                Session["agencia"] = dtInformacionPieCarta.Rows[0]["age_Nombre"].ToString(); ;
                Session["nombrePagaduria"] = ddlPagaduria.SelectedItem.ToString();

                Session["direccionPagaduria"] = dtInformacionPagaduria.Rows[0]["paga_Direccion"].ToString();
                Session["telefonoPagaduria"] = dtInformacionPagaduria.Rows[0]["paga_Telefono"].ToString();

                Session["nombreAgencia"] = dtInformacionPieCarta.Rows[0]["age_Nombre"].ToString();
                Session["nombreDirector"] = dtInformacionPieCarta.Rows[0]["age_Director"].ToString();
                Session["direccionAgencia"] = dtInformacionPieCarta.Rows[0]["age_Direccion"].ToString();
                Session["emailAgencia"] = dtInformacionPieCarta.Rows[0]["age_Email"].ToString();
                Session["telefonoAgencia"] = dtInformacionPieCarta.Rows[0]["age_Telefono"].ToString();
                Session["cargo"] = dtInformacionPieCarta.Rows[0]["car_Nombre"].ToString();

            }
            datosCuentaCobro.Visible = true;
            btnGuardarCuentasCobro.Visible = true;
            btnImprimirCuentaDeCobro.Visible = true;
            btnExportarExcelAnt.Visible = true;

            nocuentacobrodatos.Visible = false;
        }
        else
        {
            datosCuentaCobro.Visible = false;
            btnGuardarCuentasCobro.Visible = false;
            btnImprimirCuentaDeCobro.Visible = false;
            btnExportarExcelAnt.Visible = false;

            nocuentacobrodatos.Visible = true;
        }
    }

    // Limpia grid view especifica
    private void limpiarGridView(GridView gridView)
    {
        DataTable ds = new DataTable();
        ds = null;
        gridView.DataSource = ds;
        gridView.DataBind();
    }

    protected void btnExportarExcel_Click(object sender, System.EventArgs e)
    {
        DataTable dtNovedadMes = (DataTable)Session["dtNovedadMes"];
        DataTable dtNovedadCuentaCobro = (DataTable)Session["dtNovedadCuentaCobro"];
        DataTable dtNovedadCuentaCobroDatos = (DataTable)Session["dtNovedadCuentaDatos"];
        
        if (ddlArchivo.SelectedValue != "")
        {
            DataTable dtTipoArchivo = new DataTable();
            dtTipoArchivo = AdministrarNovedades.ConsultarTipoArchivoNovedades(int.Parse(ddlArchivo.SelectedValue));

            if (dtTipoArchivo.Rows[0]["arcpag_TipoArchivo"].ToString() == "1")
            {
                //if (grvListaCuentaCobro.Rows.Count > 0)
                if (grvMesCuentaDeCobroDatos.Rows.Count > 0)
                {
                    Funciones.generarExcelCuentaCobro(Page, dtNovedadCuentaCobro, dtNovedadCuentaCobroDatos, "Cuenta de cobro");
                }
            }
        }
    }

    // Permite guardar las cuentas de cobro con fecha del mes actual
    protected void btnGuardarCuentasCobro_Click(object sender, System.EventArgs e)
    {
        //dtNovedadArchivoCuentaCobro
        int cuenta = AdministrarNovedades.VerificarCuentasCobro(Session["archivoId"].ToString());
        if (cuenta <= 0)
        {
            int reg = AdministrarNovedades.GuardarCuentasCobro(dtNovedadArchivoCuentaCobro, Session["archivoId"].ToString());
            if (reg > 0)
            {
                ddlAnio_SelectedIndexChanged(sender, e);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Cuenta de cobro generada" + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Cuenta de cobro no generada" + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "La cuenta de cobro para este mes ya se encuentra generada" + "');", true);
        }
    }

    // Obtener lista de cuentas de cobro desde la base de datos
    protected void grvListaCuentaCobro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvListaCuentaCobro.Rows[(index)];

        int cueCob_Id = int.Parse(row.Cells[1].Text);
        string cueCob_MesNum = row.Cells[2].Text;
        string cueCob_Mes = row.Cells[3].Text;
        string cueCob_Anio = row.Cells[4].Text;
        string cueCob_Gen = row.Cells[5].Text;
        string cueCob_Total = row.Cells[6].Text;

        // 
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Cuenta de cobro", typeof(int)),
                            new DataColumn("Mes", typeof(string)),
                            new DataColumn("Mes Nombre", typeof(string)),
                            new DataColumn("Año",typeof(string)), 
                            new DataColumn("Fecha de Generación", typeof(string)), 
                            new DataColumn("Total", typeof(string)) 
        });

        dt.Rows.Add(cueCob_Id, cueCob_MesNum, cueCob_Mes, cueCob_Anio, cueCob_Gen, cueCob_Total);

        Session["mesCuentaCobroNum"] = cueCob_MesNum;
        Session["mesCuentaCobro"] = cueCob_Mes;
        Session["anioCuentaCobro"] = cueCob_Anio;
        Session["totalCuentaCobro"] = cueCob_Total;

        cargarInformacionCuentaCobro(sender, e, cueCob_Id);

        Session["dtNovedadCuentaCobro"] = dt;

        if (e.CommandName == "ConsultarCuentaCobro_Click")
        {
            lblCuentaCobroId.Text = cueCob_Id.ToString();
            listaCuentasCobroDatos.Visible = true;
            btnExportarExcel.Visible = true;

            grvCuentaCobro.DataSource = dt;
            grvCuentaCobro.DataBind();
            listaCuentasCobroDatos.Visible = true;
        }
        if (e.CommandName == "ImprimirCuentaCobro_Click")
        {
            Session["cueCob_Id"] = cueCob_Id;
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.location.replace('ImprimirCuentaCobro.aspx');", true);
            

            // Consultar cuenta bancaria realcionada a la cuenta de cobro
            int archivoId = int.Parse(Session["archivoId"].ToString());

            DataTable dtCuentaBancaria = new DataTable();
            dtCuentaBancaria = CuentasBancarias.ConsultarCuentasPorArchivo(archivoId);

            if (dtCuentaBancaria.Rows.Count > 0)
            {
                Response.RedirectToRoute("imprimirCuentaCobro");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('No hay cuenta bancaria asociada a esta cuenta de cobro');", true);
            }
        }
        if (e.CommandName == "EliminarCuentaCobro_Click")
        {
            int eliMes = int.Parse(DateTime.Now.ToString("MM"));
            int eliDia = int.Parse(DateTime.Now.ToString("dd"));
            if (int.Parse(cueCob_MesNum) >= eliMes && eliDia <= diaLimiteEliminacion)
            {
                int reg = AdministrarNovedades.EliminarCuentasCobro(cueCob_Id, int.Parse(ddlArchivo.SelectedValue));
                if (reg > 0)
                {
                    ddlAnio_SelectedIndexChanged(sender, e);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Cuenta de cobro eliminada" + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "No se puede eliminar la cuenta de cobro ya la fecha limite de eliminación ya caducó" + "');", true);
            }
        }
    }

    // Consultamos en la base de datos los datos de la cuenta de cobro
    private void cargarInformacionCuentaCobro(object sender, GridViewCommandEventArgs e, int cueCob_Id)
    {
        DataTable dt = new DataTable();
        dt = AdministrarNovedades.ConsultarCuentaCobro(cueCob_Id);
        cargarListaCuentasCobroDatos(dt);
    }

    // Carga los datos de determinada cuenta de cobro
    private void cargarListaCuentasCobroDatos(DataTable dt)
    {
        grvListaCuentaCobroDatos.DataSource = dt;
        grvListaCuentaCobroDatos.DataBind();

        Session["dtNovedadCuentaDatos"] = dt;
    }

    // Funcion de la paginación de la lista de cuentas de cobro 
    protected void grvListaCuentaCobro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvListaCuentaCobro.PageIndex = e.NewPageIndex;
        DataTable dt = new DataTable();
        dt = AdministrarNovedades.ConsultarCuentasCobro(ddlMes.SelectedValue, ddlAnio.SelectedValue, 0, Session["archivoId"].ToString());
        cargarListaCuentasCobro(dt);
    }


    // Sirve para cargar la lista desde el datatable
    private void cargarListaCuentasCobro(DataTable dt)
    {
        listaCuentasCobro.Visible = true;
        grvListaCuentaCobro.DataSource = dt;
        grvListaCuentaCobro.DataBind();
    }

    // Cargar los datos de la cuenta de cobro segun la página seleccionada
    protected void grvListaCuentaCobroDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvListaCuentaCobroDatos.PageIndex = e.NewPageIndex;
        DataTable dt = new DataTable();
        dt = AdministrarNovedades.ConsultarCuentaCobro(int.Parse(Session["cueCob_Id"].ToString()));
        cargarListaCuentasCobroDatos(dt);
    }

    // Consultar cuenta de cobro por id
    protected void btnConsultarCuentaCobro_Click(object sender, System.EventArgs e)
    {
        Session["cueCob_Id"] = txtConsultarCuentaCobro.Text;
        ddlAnio_SelectedIndexChanged(sender, e);
    }
    protected void ddlMes_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Session["mes"] = ddlMes.SelectedValue.ToString();
        ddlAnio_SelectedIndexChanged(sender, e);
    }

    protected void ddlAnio_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //datosCuentaCobro.Visible = false;
        listaCuentasCobroDatos.Visible = false;
        btnExportarExcel.Visible = false;
        Session["anio"] = ddlAnio.SelectedValue.ToString();

        if (ddlAnio.SelectedValue.ToString() != "" || ddlMes.SelectedValue.ToString() != "" || ddlArchivo.SelectedValue.ToString() != "")
        {
            DataTable dt = new DataTable();
            dt = AdministrarNovedades.ConsultarCuentasCobro(
                (Session["mes"].ToString() == "") ? "0" : Session["mes"].ToString(),
                (Session["anio"].ToString() == "") ? "0" : Session["anio"].ToString(),
                (Session["cueCob_Id"].ToString() == "") ? 0 : int.Parse(Session["cueCob_Id"].ToString()),
                Session["archivoId"].ToString()
            );
            if (dt.Rows.Count > 0){
                nocuentascobro.Visible = false;
                listaCuentasCobro.Visible = true;
                cargarListaCuentasCobro(dt);
            }
            else
            {
                nocuentascobro.Visible = true;
                listaCuentasCobro.Visible = false;
            }
            //Session["dtNovedadMes"] = dt;
            Session["dtListaCuentasCobro"] = dt;
        }
        else
        {
            //listaCuentasCobro.Visible = false;
            limpiarGridView(grvListaCuentaCobro);
        }
    }

    // 
    protected void btnExportarExcelAnt_Click(object sender, System.EventArgs e)
    {
        Funciones.generarExcel(Page, dtNovedadArchivoCuentaCobro, "Cuenta de cobro para generar");
    }
}