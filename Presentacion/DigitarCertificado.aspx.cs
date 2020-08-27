using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_DigitarCertificado : System.Web.UI.Page
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
   AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    //public static string poliza;
    //public static DataTable dt = new DataTable();
    //public static DataTable otrosAsegurados = new DataTable();
    //public static DataTable dtArchivo = new DataTable();
    //public static DataTable dtNovedades = new DataTable();
    //public static DataTable dtConyuge = new DataTable();
    //public static DataTable dtTemp;
    //public static DataTable dtTempOtrosAsegurados;
    //public static List<Asegurado> beneficiario = new List<Asegurado>();
    //public static List<Asegurado> beneficiarioConyuge = new List<Asegurado>();
    //public static int extraPrima = 0;
    //public static int extraPrimaConyuge = 0;
    //public static DataTable dtBeneficiario = new DataTable();
    //public static DataTable dtBeneficiarioConyuge = new DataTable();
    //public static DataTable dtEliminarPrincipal = new DataTable();
    //public static DataTable dtEliminarConyuge = new DataTable();
    //public static DataTable dtMesYAnio = new DataTable();
    //public static int cer_Id;
    //public static int primaOtroAsegurado = 0;
    //DataTable dtCertificadoFull = new DataTable();
    //DataTable dtOtroAsegurado = new DataTable();
    //DataTable dtEncabezadoCertificado = new DataTable(); //JC 22-09-2015
    //public static bool sePuedenHijosPMI = true;
    //public static string movimientoPrincipal;
    //public static string movimientoConyuge;
    //public static string movimientoOtrosAsegurados = "";
    //public static int tipoMovimientoDefinitivo = 0;
    //public static bool teniaConyuge;
    //public static bool teniaOtrosAsegurados = false;
    //public static int cer_Antiguo;
    //public static DataTable dtPeriodicidad = new DataTable();
    //public static DataTable dtArchivoPagaduria = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        //******************************************************************************
        
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();
        
        if(txtCedulaConyuge.Text != "")
        {
            btnValidarConyuge.Visible = true;
        }

        txtFechaExpedicionCertificado.Enabled = false;
        txtFechaVigenciaCertificado.Enabled = false;
        txtCertificado.Enabled = false;
        txtNombreAsesor.Enabled = false;
        txtAgencia.Enabled = false;
        txtPrima.Enabled = false;
        txtCedulaPrincipal.Enabled = false;
        txtNombrePrincipal.Enabled = false;
        txtApellidoPrincipal.Enabled = false;
        txtEdadPrincipal.Enabled = false;
        txtPagaduriaPrincipal.Enabled = false;
        txtPrimaPrincipal.Enabled = false;
        txtExtraPrimaPrincipal.Enabled = false;
        txtCedulaConyuge.Enabled = false;
        txtNombreConyuge.Enabled = false;
        txtApellidoConyuge.Enabled = false;
        txtEdadConyuge.Enabled = false;
        txtExtraPrimaConyuge.Enabled = false;
        txtPrimaConyuge.Enabled = false;
        //txtPrima.Enabled = false;
        //txtPrimaConyuge.Enabled = false;
        //txtPrimaOtros.Enabled = true;
        //txtPrimaPrincipal.Enabled = false;
        txtCedulaOtro.Enabled = false;
        txtNombreOtro.Enabled = false;
        txtApellidoOtro.Enabled = false;
        txtEdadOtro.Enabled = false;
        txtFechaNacimiento.Enabled = false;
        btnAdicionarOtrosAsegurados.Enabled = false;
        grvAmparoOtro.Visible = false;
        btnGuardarCambios.Enabled = false;
        txtPrimaPrincipalExtraprima.Enabled = false;
        txtPrincipalExtraprimaConyuge.Enabled = false;
        txtPrimaPrincipalExtraprimaConyuge.Enabled = false;
        txtPrincipalExtraprima.Enabled = false;

        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();
        
        //bloqueo prima
        //AdministrarCertificados.HabilitarCampoPrima(txtCedulaPrincipal.Text, txtCertificado.Text);
        txtFechaExpedicionCertificado.Enabled = false;
        txtFechaVigenciaCertificado.Enabled = false;
        txtCertificado.Enabled = false;
        txtNombreAsesor.Enabled = false;
        txtAgencia.Enabled = false;
        txtPrima.Enabled = false;
        txtCedulaPrincipal.Enabled = false;
        txtNombrePrincipal.Enabled = false;
        txtApellidoPrincipal.Enabled = false;
        txtEdadPrincipal.Enabled = false;
        txtPagaduriaPrincipal.Enabled = false;
        txtPrimaPrincipal.Enabled = false;
        txtExtraPrimaPrincipal.Enabled = false;
        txtCedulaConyuge.Enabled = false;
        txtNombreConyuge.Enabled = false;
        txtApellidoConyuge.Enabled = false;
        txtEdadConyuge.Enabled = false;
        txtPrimaConyuge.Enabled = false;
        txtExtraPrimaConyuge.Enabled = false;
        txtPrima.Enabled = false;
        //txtPrimaConyuge.Enabled = false;
        txtPrimaOtros.Enabled = false;
       // txtPrimaPrincipal.Enabled = false;
        txtCedulaOtro.Enabled = false;
        txtNombreOtro.Enabled = false;
        txtApellidoOtro.Enabled = false;
        txtEdadOtro.Enabled = false;
        txtFechaNacimiento.Enabled = false;
        btnAdicionarOtrosAsegurados.Enabled = false;
        grvAmparoOtro.Visible = false;
        txtHServicio1.Enabled = false;
        txtHServicio2.Enabled = false;
        txtHServicio3.Enabled = false;
        txtAnexoConversion.Enabled = false;

        if (!IsPostBack)
        {   
            //double cer_IdAnteriorExtraPrima = 0;
            Session["cer_IdAnteriorExtraPrima"] = 0;
            double valorAseguradoPrincipalResta = 0;
            Session["valorAseguradoPrincipalResta"] = valorAseguradoPrincipalResta;
            double valorAseguradoPrincipalRestaConyuge = 0;
            Session["valorAseguradoPrincipalRestaConyuge"] = valorAseguradoPrincipalRestaConyuge;


            double dtExtraprimaPrincipalRestaurar3 = 0;
            Session["dtExtraprimaPrincipalRestaurar3"] = dtExtraprimaPrincipalRestaurar3;

            double dtExtraprimaConyugeRestaurar3 = 0;
            Session["dtExtraprimaConyugeRestaurar3"] = dtExtraprimaConyugeRestaurar3;
            string movimientoOtrosAsegurados = "";
            Session["movimientoOtrosAsegurados"] = movimientoOtrosAsegurados;

            bool teniaOtrosAsegurados = false;
            Session["teniaOtrosAsegurados"] = teniaOtrosAsegurados;

            Session["LimpiarConyuge"] = 0;

            //int tipoMovimientoDefinitivo = 0;
            //Session["tipoMovimientoDefinitivo"] = tipoMovimientoDefinitivo;

            //Borrar Hijos
            txtPrimaOtros.Text = "";
            int primaOtroAsegurado = 0;
            Session["primaOtroAsegurado"] = primaOtroAsegurado;

            btnSiguienteCertificado.Enabled = false;
            reqtxtPlanPrincipal.Enabled = false;
            txtPlanPrincipal.Visible = false;
            reqtxtPlanConyuge.Enabled = false;
            txtPlanConyuge.Visible = false;
            lblPlan.Visible = false;
            labPlan.Visible = false;
            btnCertificadoModal.Enabled = false;
        }
      

        if (!IsPostBack)
        {
            if (ddlPoliza.Text != "")
            {
                txtDocumentoConyugue.Enabled = true;
                txtDocumentoOtros.Enabled = true;
            }
            else
            {
                txtDocumentoConyugue.Enabled = false;
                txtDocumentoOtros.Enabled = false;
            }

            DataTable dtCertificadoFull = new DataTable();
            bool sePuedenHijosPMI = true;
            Session["sePuedenHijosPMI"] = sePuedenHijosPMI;
            bool teniaConyuge = false;
            Session["teniaConyuge"] = teniaConyuge;

            DataTable dtBeneficiario = new DataTable();                        
            DataColumn columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "NumeroDocumento";
            columns.ColumnName = "NumeroDocumento";
            dtBeneficiario.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "Apellidos";
            columns.ColumnName = "Apellidos";
            dtBeneficiario.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "Nombres";
            columns.ColumnName = "Nombres";
            dtBeneficiario.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "Edad";
            columns.ColumnName = "Edad";
            dtBeneficiario.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "Porcentaje";
            columns.ColumnName = "Porcentaje";
            dtBeneficiario.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.Caption = "Parentesco";
            columns.ColumnName = "Parentesco";
            dtBeneficiario.Columns.Add(columns);

            

            //LlENAR PRIMERA FILA DE LA TABLA BENEFIACIARIOS  
            DataTable dtBeneficiarioPrueba = new DataTable();
            dtBeneficiarioPrueba = objAdministrarCertificados.ConsultarBeneficiarioUnico();
            grvBeneficiarioPrincipal.DataSource = dtBeneficiarioPrueba;
            grvBeneficiarioPrincipal.DataBind();
            

            grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
            grvBeneficiarioPrincipal.DataBind();
            grvBeneficiarioPrincipal.Enabled = true;
            
            
            // Crear Tabla de Beneficiarios
            DataTable dtBeneficiarioConyuge = new DataTable();
            dtBeneficiarioConyuge = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "NumeroDocumento";
            column.ColumnName = "NumeroDocumento";
            dtBeneficiarioConyuge.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "Apellidos";
            column.ColumnName = "Apellidos";
            dtBeneficiarioConyuge.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "Nombres";
            column.ColumnName = "Nombres";
            dtBeneficiarioConyuge.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "Edad";
            column.ColumnName = "Edad";
            dtBeneficiarioConyuge.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "Porcentaje";
            column.ColumnName = "Porcentaje";
            dtBeneficiarioConyuge.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.Caption = "Parentesco";
            column.ColumnName = "Parentesco";
            dtBeneficiarioConyuge.Columns.Add(column);

            //lLENAR PRIMERA FILA DE LA TABLA BENEFIACIARIOS  
            DataTable dtBeneficiarioPruebaConyuge = new DataTable();
            dtBeneficiarioPruebaConyuge = objAdministrarCertificados.ConsultarBeneficiarioUnico();
            grvBeneficiarioConyuge.DataSource = dtBeneficiarioPruebaConyuge;
            grvBeneficiarioConyuge.DataBind();

            grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
            grvBeneficiarioConyuge.DataBind();
            grvBeneficiarioConyuge.Enabled = true;

            Session["dtBeneficiario"] = dtBeneficiario;
            Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;

            DataTable otrosAsegurados = new DataTable();
            DataTable dtEliminarPrincipal = new DataTable();
            DataTable dtEliminarConyuge = new DataTable();
            DataTable dtTemp = new DataTable();
            DataTable dtExtraprimaPrincipal = new DataTable();
            DataTable dtExtraprimaConyuge = new DataTable();
            int rowExtraPrima = 0;

            if (!IsPostBack)
            {              
                string poliza = Session["numeroCertificado"].ToString();
                if (poliza != null)
                {
                    txtCertificado.Text = poliza;
                }
                //dtCertificadoFull = AdministrarCertificados.consultarCertificadoFull(int.Parse(poliza));

                DataTable dt = PrecargueProduccion.ConsultarConsecutivoCert(int.Parse(Session["cer_Id"].ToString()));
                Session["cerIdPagaduria"] = Session["cer_Id"].ToString();
                // Si permite varios vigentes
                //if (dt.Rows[0]["casesp_Id"].ToString() == "8")
                //{
                    if (int.Parse(Session["pro_Id"].ToString()) == 99)
                        dtCertificadoFull = objAdministrarCertificados.consultarCertificadoFullCedula(double.Parse(Session["ter_Id"].ToString()), 1);
                        //dtConsultarCompaniaPorCertificado = objAdministrarCertificados.ConsultarCompaniaPorCertificado
                    if (dtCertificadoFull.Rows.Count == 0)
                        dtCertificadoFull = objAdministrarCertificados.consultarCertificadoFullCedula(double.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
                //}

                    if (int.Parse(dt.Rows[0]["com_Id"].ToString()) == 6 || int.Parse(dt.Rows[0]["com_Id"].ToString()) == 4)
                {
                    Session["banderaExtraPrima"] = 1;
                }
                else
                {
                    Session["banderaExtraPrima"] = 0;
                }
            }
            int Edad = 0;

            if (!IsPostBack)
            {
                // Todos
                objAdministrarCertificados.certificadoPrecargado(int.Parse(Session["cer_Id"].ToString()));
                txtAgencia.Text = objAdministrarCertificados.objCertificadoPre.Agencia;
                txtFechaExpedicionCertificado.Text = objAdministrarCertificados.objCertificadoPre.FechaExpedicion.ToString("yyyy-MM-dd");
                txtFechaVigenciaCertificado.Text = objAdministrarCertificados.objCertificadoPre.Vigencia.ToString("yyyy-MM-dd");
                txtCertificado.Text = objAdministrarCertificados.objCertificadoPre.NumeroCertificado;
                txtNombreAsesor.Text = objAdministrarCertificados.objCertificadoPre.NombreAsesor;
                txtNombrePrincipal.Text = objAdministrarCertificados.objAseguradoPre.Nombres;
                txtApellidoPrincipal.Text = objAdministrarCertificados.objAseguradoPre.Apellidos;
                txtCedulaPrincipal.Text = objAdministrarCertificados.objAseguradoPre.NumeroDocumento;
                txtPagaduriaPrincipal.Text = objAdministrarCertificados.objCertificadoPre.Pagaduria;
                txtHServicio1.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio1;
                txtHServicio2.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio2;
                txtHServicio3.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio3;
                txtAnexoConversion.Text = objAdministrarCertificados.objCertificadoPre.AnexoConversion;
                
                  Edad = Convert.ToInt32(Session["edad"]);
                txtEdadPrincipal.Text = Edad.ToString();

                DataTable dt = new DataTable(), dtAgencia = new DataTable(), dtPeriodoPago = new DataTable(), dtLocalidades = new DataTable(), dtOcupacionPrincipal = new DataTable(), dtconsultarParentescoBeneficiarioPrincipal = new DataTable(), dtPlantel = new DataTable(), dtPlantelCertificado = new DataTable();

                dtPeriodoPago = objAdministrarCertificados.ConsultarPeriodosPago();
                ddlperiodoPagoCertificado.DataValueField = "perpago_Id";
                ddlperiodoPagoCertificado.DataTextField = "perpago_Nombre";
                ddlperiodoPagoCertificado.DataSource = dtPeriodoPago;
                ddlperiodoPagoCertificado.DataBind();
                ddlperiodoPagoCertificado.Items.Insert(0, new ListItem("", ""));

                dtLocalidades = objAdministrarCertificados.ConsultarLocalidadesCertificado(int.Parse(Session["cer_Id"].ToString()));
                ddlLocalidadCertificado.DataValueField = "dep_Id";
                ddlLocalidadCertificado.DataTextField = "dep_Nombre";
                ddlLocalidadCertificado.DataSource = dtLocalidades;
                ddlLocalidadCertificado.DataBind();
                ddlLocalidadCertificado.Items.Insert(0, new ListItem("", ""));
                ddlLocalidadCertificado.Attributes.Add("onclick", "localStorage.setItem('accIndex', 0);");

                if (dtLocalidades.Rows.Count > 0 )
                {
                    try
                    {
                        dtPlantel = objAdministrarCertificados.ConsultarPlantel(int.Parse(dtLocalidades.Rows[0]["dep_Id"].ToString()));
                        ddlPlantel.DataValueField = "pla_Id";
                        ddlPlantel.DataTextField = "pla_Nombre";
                        ddlPlantel.DataSource = dtPlantel;
                        ddlPlantel.DataBind();
                        ddlPlantel.Items.Insert(0, new ListItem("", ""));
                        ddlPlantel.Attributes.Add("onclick", "localStorage.setItem('accIndex', 1);");
                    }
                    catch { }
                }

                int cer_Id = int.Parse(Session["cer_id"].ToString());
                DataTable dtEncabezadoCertificado = new DataTable();
                dtEncabezadoCertificado = objAdministrarCertificados.spConsultarEncabezadoCertificado(cer_Id);
                dtconsultarParentescoBeneficiarioPrincipal = objAdministrarCertificados.consultarParentescoBeneficiario(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));


                dtOcupacionPrincipal = objAdministrarCertificados.ConsultarOcupacionCertificado(int.Parse(txtCedulaPrincipal.Text));
                ddlOcupacionPrincipal.DataValueField = "ocu_Id";
                ddlOcupacionPrincipal.DataTextField = "ocu_Nombre";
                ddlOcupacionPrincipal.DataSource = dtOcupacionPrincipal;
                ddlOcupacionPrincipal.DataBind();

              
                //cer_Id = AdministrarCertificados.ConsultarIdCertificado(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()), "VIGENTE");
                //int cer_Id = int.Parse(Session["cer_id"].ToString());


                //Migracion
                if (objAdministrarCertificados.objCertificadoPre.Migracion == "2")
                {
                    txtPrima.Enabled = true;
                    txtCompania.Enabled = false;
                    ddlProducto.Enabled = false;
                    txtFechaExpedicionCertificado.Enabled = false;
                    txtFechaVigenciaCertificado.Enabled = false;
                    txtFechaDigitacionCertificado.Enabled = false;
                    txtCertificado.Enabled = false;
                    txtNombreAsesor.Enabled = false;
                    ddlperiodoPagoCertificado.Enabled = false;
                    ddlLocalidadCertificado.Enabled = false;
                    ddlPoliza.Enabled = false;
                    txtAgencia.Enabled = false;
                    txtmesProduccion.Enabled = false;
                    txtEstadoNegocio.Enabled = false;
                    txtDeclaracionAsegurado.Enabled = false;
                    txtDeclaracionEG.Enabled = false;
                    txtHServicio1.Enabled = false;
                    txtHServicio2.Enabled = false;
                    txtHServicio3.Enabled = false;
                    txtAnexoConversion.Enabled = false;
                    txtTipoMovimiento.Enabled = false;
                    btnCambiosPreCargue.Enabled = false;
                    btnGuardarCambios.Enabled = false;
                    ddlConvenioPrincipal.Enabled = false;
                    ddlPlanPrincipal.Enabled = false;
                    ddlPlanConyuge.Enabled = false;
                    grvAmparoPrincipal.Enabled = false;
                    grvBeneficiarioPrincipal.Enabled = false;
                    txtDocumentoConyugue.Enabled = false;
                    boton1.Enabled = false;
                    Button1.Enabled = false;
                    btnAdicionarOtrosAsegurados.Enabled = false;
                    txtTelefono2Otros.Enabled = false;
                    txtTelefono1Otros.Enabled = false;
                    txtPrimaOtros.Enabled = false;
                    txtNombreOtros.Enabled = false;
                    txtNombreOtro.Enabled = false;
                    txtNacimientoOtros.Enabled = false;
                    txtIdentificacionOtros.Enabled = false;
                    txtEdadOtros.Enabled = false;
                    txtEdadOtro.Enabled = false;
                    txtDocumentoOtros.Enabled = false;
                    txtDireccionOtros.Enabled = false;
                    txtCorreoOtros.Enabled = false;
                    txtCelularOtros.Enabled = false;
                    txtCedulaOtro.Enabled = false;
                    txtApellidoOtros.Enabled = false;
                    txtApellidoOtro.Enabled = false;
                    txtpesoPrincipal.Enabled = false;
                    txtestaturaPrincipal.Enabled = false;
                    ddlPlanPrincipal.Enabled = false;

                    if (dtCertificadoFull.Rows.Count > 0)
                    {
                        txtEstadoNegocio.Text = dtCertificadoFull.Rows[0]["cer_EstadoNegocio"].ToString();
                        txtDeclaracionAsegurado.Text = dtCertificadoFull.Rows[0]["cer_Declaracion"].ToString();
                        txtDeclaracionEG.Text = dtCertificadoFull.Rows[0]["cer_DeclaracionEnfe"].ToString();
                        DataTable dtPlan = objAdministrarCertificados.ConsultarPlanPrincipal(int.Parse(dtCertificadoFull.Rows[0]["cer_Id"].ToString()));
                        ddlPlanPrincipal.DataSource = dtPlan;
                        ddlPlanPrincipal.DataTextField = "plan_ValAsegurado";
                        ddlPlanPrincipal.DataValueField = "pla_Id";
                        ddlPlanPrincipal.DataBind();
                    }                   
                }

                //Designación de Beneficiarios
                if (objAdministrarCertificados.objCertificadoPre.Migracion == "3")
                {
                    txtPrima.Enabled = false;
                    txtCompania.Enabled = false;
                    ddlProducto.Enabled = false;
                    txtFechaExpedicionCertificado.Enabled = false;
                    txtFechaVigenciaCertificado.Enabled = false;
                    txtFechaDigitacionCertificado.Enabled = false;
                    txtCertificado.Enabled = false;
                    txtNombreAsesor.Enabled = false;
                    ddlperiodoPagoCertificado.Enabled = false;
                    ddlLocalidadCertificado.Enabled = false;
                    ddlPoliza.Enabled = false;
                    txtAgencia.Enabled = false;
                    txtmesProduccion.Enabled = false;
                    txtEstadoNegocio.Enabled = false;
                    txtDeclaracionAsegurado.Enabled = false;
                    txtDeclaracionEG.Enabled = false;
                    txtHServicio1.Enabled = false;
                    txtHServicio2.Enabled = false;
                    txtHServicio3.Enabled = false;
                    txtAnexoConversion.Enabled = false;
                    txtTipoMovimiento.Enabled = false;
                    btnCambiosPreCargue.Enabled = false;
                    btnGuardarCambios.Enabled = false;
                    ddlConvenioPrincipal.Enabled = false;
                    ddlPlanPrincipal.Enabled = false;
                    ddlPlanConyuge.Enabled = false;
                    grvAmparoPrincipal.Enabled = false;
                    grvBeneficiarioPrincipal.Enabled = true;
                    txtDocumentoConyugue.Enabled = false;
                    boton1.Enabled = false;
                    Button1.Enabled = false;
                    btnAdicionarOtrosAsegurados.Enabled = false;
                    txtTelefono2Otros.Enabled = false;
                    txtTelefono1Otros.Enabled = false;
                    txtPrimaOtros.Enabled = false;
                    txtNombreOtros.Enabled = false;
                    txtNombreOtro.Enabled = false;
                    txtNacimientoOtros.Enabled = false;
                    txtIdentificacionOtros.Enabled = false;
                    txtEdadOtros.Enabled = false;
                    txtEdadOtro.Enabled = false;
                    txtDocumentoOtros.Enabled = false;
                    txtDireccionOtros.Enabled = false;
                    txtCorreoOtros.Enabled = false;
                    txtCelularOtros.Enabled = false;
                    txtCedulaOtro.Enabled = false;
                    txtApellidoOtros.Enabled = false;
                    txtApellidoOtro.Enabled = false;
                    txtpesoPrincipal.Enabled = false;
                    txtestaturaPrincipal.Enabled = false;
                    ddlPlanPrincipal.Enabled = false;

                    if (dtCertificadoFull.Rows.Count > 0)
                    {
                        txtEstadoNegocio.Text = dtCertificadoFull.Rows[0]["cer_EstadoNegocio"].ToString();
                        txtDeclaracionAsegurado.Text = dtCertificadoFull.Rows[0]["cer_Declaracion"].ToString();
                        txtDeclaracionEG.Text = dtCertificadoFull.Rows[0]["cer_DeclaracionEnfe"].ToString();
                        DataTable dtPlan = objAdministrarCertificados.ConsultarPlanPrincipal(int.Parse(dtCertificadoFull.Rows[0]["cer_Id"].ToString()));
                        ddlPlanPrincipal.DataSource = dtPlan;
                        ddlPlanPrincipal.DataTextField = "plan_ValAsegurado";
                        ddlPlanPrincipal.DataValueField = "pla_Id";
                        ddlPlanPrincipal.DataBind();
                    }
                }

                // Cargar todo lo relacionado con modificar
                if (dtCertificadoFull.Rows.Count > 0)
                {
                    //if (dtCertificadoFull.Rows[0]["cer_Migracion"].ToString() == "2")
                    if ((string)Session["operacionCertificado"] == "modificar" || int.Parse(Session["pro_Id"].ToString()) == 99)
                    {
                        ReqddlPlanPrincipal.Enabled = false;
                        reqddlPlanConyuge.Enabled = false;
                        reqtxtPlanConyuge.Enabled = false;
                        reqtxtPlanPrincipal.Enabled = false;

                        ddlLocalidadCertificado.SelectedValue = dtLocalidades.Rows[0]["dep_Id"].ToString();
                        DataTable dtPolizaInicio = new DataTable();
                        dtPolizaInicio = objAdministrarCertificados.spConsultarPolizaPorProudcto(int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), int.Parse(Session["pro_Id"].ToString()));
                        ddlPoliza.DataSource = dtPolizaInicio;
                        ddlPoliza.DataTextField = "pol_Numero"; 
                        ddlPoliza.DataValueField = "pol_Id";
                        ddlPoliza.SelectedValue = dtPolizaInicio.Rows[0]["pol_Id"].ToString();
                        ddlPoliza.DataBind();

                       

                        txtFechaDigitacionCertificado.Text = DateTime.Parse(dtCertificadoFull.Rows[0]["cer_FechaRecibido"].ToString()).ToString("yyyy-MM-dd");
                        ddlperiodoPagoCertificado.SelectedIndex = ddlperiodoPagoCertificado.Items.IndexOf(ddlperiodoPagoCertificado.Items.FindByText(dtCertificadoFull.Rows[0]["perpago_Nombre"].ToString())); //jc
                        txtPrima.Text = dtCertificadoFull.Rows[0]["cer_PrimaTotal"].ToString();
                        //txtPlanPrincipal.Text = dtCertificadoFull.Rows[0]["pla_Id"].ToString();                        
                        txtpesoPrincipal.Text = dtCertificadoFull.Rows[0]["PesoPrincipal"].ToString();
                        txtestaturaPrincipal.Text = dtCertificadoFull.Rows[0]["cer_EstaturaPrincipal"].ToString();
                        txtPeso.Text = dtCertificadoFull.Rows[0]["PesoConyuge"].ToString();
                        txtEstatura.Text = dtCertificadoFull.Rows[0]["cer_EstaturaConyuge"].ToString();
                        txtEdadPrincipal.Text = Funciones.Edad(DateTime.Parse(dtCertificadoFull.Rows[0]["ter_FechaNacimiento"].ToString())).ToString(); //Envía fecha y devuelve la edad
                        txtDeclaracionAsegurado.Text = dtCertificadoFull.Rows[0]["cer_declaracion"].ToString();
                        txtDeclaracionEG.Text = dtCertificadoFull.Rows[0]["cer_declaracionEnfe"].ToString();
                        ddlPlantel.SelectedIndex = ddlPlantel.Items.IndexOf(ddlPlantel.Items.FindByText(dtCertificadoFull.Rows[0]["pla_Nombre"].ToString()));
                        ddlPlantel.SelectedValue = dtCertificadoFull.Rows[0]["pla_Id"].ToString();

                        
                        //DataTable que trae info de tercero por ter_Id para llenar compos de conyuge
                        DataTable dtConyuge = new DataTable();
                        //bool teniaConyuge;
                        dtConyuge = objAdministrarCertificados.consultarNewTerceroPorCedula(int.Parse(txtCedulaPrincipal.Text), int.Parse(objAdministrarCertificados.objCertificadoPre.Producto));
                        if (dtConyuge.Rows.Count > 0)
                        {
                            teniaConyuge = true;
                            txtCedulaConyuge.Text = dtConyuge.Rows[0]["ter_Id"].ToString();
                            txtNombreConyuge.Text = dtConyuge.Rows[0]["ter_Nombres"].ToString();
                            txtApellidoConyuge.Text = dtConyuge.Rows[0]["ter_Apellidos"].ToString();
                            txtEdadConyuge.Text = Funciones.Edad(DateTime.Parse(dtConyuge.Rows[0]["ter_FechaNacimiento"].ToString())).ToString(); //Envía fecha y devuelve la edad
                        }
                        else
                            teniaConyuge = false;
                        Session["teniaConyuge"] = teniaConyuge;

                        txtFechaDigitacionCertificado.Text = DateTime.Parse(dtCertificadoFull.Rows[0]["cer_FechaRecibido"].ToString()).ToString("yyyy-MM-dd");
                        ddlPoliza.Text = dtCertificadoFull.Rows[0]["pol_Numero"].ToString();
                        txtPrima.Text = dtCertificadoFull.Rows[0]["cer_PrimaTotal"].ToString();
                        //txtPlanPrincipal.Text = dtCertificadoFull.Rows[0]["pla_Id"].ToString();
                        txtpesoPrincipal.Text = dtCertificadoFull.Rows[0]["PesoPrincipal"].ToString();
                        txtestaturaPrincipal.Text = dtCertificadoFull.Rows[0]["cer_EstaturaPrincipal"].ToString();
                        txtPeso.Text = dtCertificadoFull.Rows[0]["PesoConyuge"].ToString();
                        txtEstatura.Text = dtCertificadoFull.Rows[0]["cer_EstaturaConyuge"].ToString();

                        cer_Id = objAdministrarCertificados.ConsultarIdCertificado(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()), "VIGENTE", "PRODUCCION NUEVA");
                        //cer_Id = int.Parse(Session["cer_id"].ToString());

                        DataTable dtConsultarHistorialExtraPrima = new DataTable();
                        dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(cer_Id, 1,int.Parse(Session["banderaExtraPrima"].ToString()));
                        grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
                        grvHistorialExtraPrima.DataBind();
                        if(dtConsultarHistorialExtraPrima.Rows.Count > 0)
                        {
                            Session["cer_IdAnteriorExtraPrima"] = cer_Id;
                        }
                        double consultarHistorialExtraPrima = 0;
                        double valorExtraPrima = 0;

                       
                        dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Id, 1);
                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();

                        dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Id, 2);///////////////////////////////////////////////////////////////////////////////////
                        grvAmparoConyuge.DataSource = dtEliminarConyuge;
                        grvAmparoConyuge.DataBind();

                    
                        if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
                        {
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                            {
                                consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                                valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
                            }
                        }

                        txtPrimaPrincipalExtraprima.Text = consultarHistorialExtraPrima.ToString();
                        txtPrincipalExtraprima.Text = valorExtraPrima.ToString();
                        txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
                        txtPrimaPrincipal.Text = consultarHistorialExtraPrima.ToString();
                        Session["TotalExtraPrimaP"] = consultarHistorialExtraPrima.ToString();
                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;

                        DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                        dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(cer_Id, 2, int.Parse(Session["banderaExtraPrima"].ToString()));
                        grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
                        grvHistorialExtraPrimaConyuge.DataBind();

                        if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                        {
                            Session["cer_IdAnteriorExtraPrima"] = cer_Id;
                        }
                        double consultarHistorialExtraPrimaConyuge = 0;
                        double valorExtraPrimaConyuge = 0;

                        if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                        {
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                            {
                                consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                                valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
                            }
                        }
                        txtPrimaPrincipalExtraprimaConyuge.Text = consultarHistorialExtraPrimaConyuge.ToString();
                        txtPrincipalExtraprimaConyuge.Text = valorExtraPrimaConyuge.ToString();
                        txtPrincipalExtraprimaConyuge.Text = Math.Round(double.Parse(txtPrincipalExtraprimaConyuge.Text)).ToString();
                        txtPrimaConyuge.Text = consultarHistorialExtraPrimaConyuge.ToString();
                        Session["TotalExtraPrimaC"] = consultarHistorialExtraPrimaConyuge.ToString();
                        txtExtraPrimaConyuge.Text = valorExtraPrimaConyuge.ToString();
                        txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();

                        sumarPrima(0);

                        dtBeneficiario = objAdministrarCertificados.ConsultarBeneficiarioModificacion(cer_Id, int.Parse(txtCedulaPrincipal.Text), 1);
                        grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                        grvBeneficiarioPrincipal.DataBind();
                        
                        int cer_Antiguo = 0;
                        if (int.Parse(Session["pro_Id"].ToString()) == 99 && dtBeneficiario.Rows.Count == 0)
                        {                            
                            try
                            {
                                cer_Antiguo = int.Parse(dtCertificadoFull.Rows[0]["cer_Id"].ToString());
                            }
                            catch { }

                            dtBeneficiario = objAdministrarCertificados.ConsultarBeneficiarioModificacion(cer_Antiguo, int.Parse(txtCedulaPrincipal.Text), 1);
                            grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                            grvBeneficiarioPrincipal.DataBind();
                        }

                        dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Id, 1);
                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();

                       
                        if (int.Parse(Session["pro_Id"].ToString()) == 99 && dtEliminarPrincipal.Rows.Count == 0)
                        {
                            dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Antiguo, 1);
                            grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                            grvAmparoPrincipal.DataBind();
                        }
                        //Variables que se utilizan para la captura del valor asegurado de vida en la seccion del Principal
                        string capturarValorAseguradoResta;
                        int celdaCapturada = 0;
                        
                        //
                        // for que recorre el Dt que llena la grilla de los amparos del Principal 
                        for (int j = 0; j < dtEliminarPrincipal.Rows.Count; j++)
                        {
                            // se captura toda la columna que contiene los Amparos
                            capturarValorAseguradoResta = dtEliminarPrincipal.Rows[j]["Amparo"].ToString();
                            //
                            // se crea el condicional para que me diga en que momento pasa por el amparo VIDA
                            if (capturarValorAseguradoResta == "VIDA")
                            {
                                // se captura en una variable el numero de fila en la que se encuentra el Amparo VIDA
                                celdaCapturada = j;
                                //
                                // se captura el valor del valor asegurado que le corrsponde a la misma fila en la que se encuentra VIDA
                                Session["valorAseguradoPrincipalResta"] = double.Parse(dtEliminarPrincipal.Rows[celdaCapturada]["Valor Asegurado"].ToString());
                                //
                            }
                            //
                        }
                        //
                        double totales = 0;
                        foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                        {
                            totales += Convert.ToDouble(row.Cells[4].Text);
                        }
                        //txtPrimaPrincipal.Text = Convert.ToString(totales);

                        if (txtCedulaConyuge.Text != "")
                        {
                            DataTable dtPlanPrin = new DataTable();
                            dtPlanPrin = objAdministrarCertificados.consultarPlanPorPolizaPermanencia(int.Parse(ddlPoliza.SelectedValue.ToString()), 2, int.Parse(txtEdadConyuge.Text));
                            ddlPlanConyuge.DataSource = dtPlanPrin;
                            ddlPlanConyuge.DataValueField = "plapol_Id";
                            ddlPlanConyuge.DataTextField = "plan_ValAsegurado";
                            ddlPlanConyuge.DataBind();
                            Session["plapol_IdConyuge"] = dtPlanPrin.Rows[0]["plapol_Id"].ToString();

                            if (objAdministrarCertificados.objCertificadoPre.Migracion != "2")
                            {
                                try
                                {
                                    dtPlanPrin = objAdministrarCertificados.consultarPlanPorPolizaPermanencia(int.Parse(ddlPoliza.SelectedValue.ToString()), 1, int.Parse(txtEdadPrincipal.Text));
                                    ddlPlanPrincipal.DataSource = dtPlanPrin;
                                    ddlPlanPrincipal.DataValueField = "plapol_Id";
                                    ddlPlanPrincipal.DataTextField = "plan_ValAsegurado";
                                    ddlPlanPrincipal.DataBind();
                                }
                                catch { }

                            }

                            dtBeneficiarioConyuge = objAdministrarCertificados.ConsultarBeneficiarioModificacion(cer_Id, double.Parse(txtCedulaConyuge.Text), 2);
                            grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                            grvBeneficiarioConyuge.DataBind();

                            int cer_AntiguoConyuge = 0;
                            if (int.Parse(Session["pro_Id"].ToString()) == 99 && dtBeneficiarioConyuge.Rows.Count == 0)
                            {
                                try
                                {
                                    cer_AntiguoConyuge = int.Parse(dtCertificadoFull.Rows[0]["cer_Id"].ToString());
                                }
                                catch { }

                                dtBeneficiarioConyuge = objAdministrarCertificados.ConsultarBeneficiarioModificacion(cer_Antiguo, double.Parse(txtCedulaConyuge.Text), 2);
                                grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                                grvBeneficiarioConyuge.DataBind();
                            }
                           
                            if (dtBeneficiarioConyuge.Rows.Count == 0)
                            {
                                dtBeneficiarioConyuge = new DataTable();
                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "NumeroDocumento";
                                column.ColumnName = "NumeroDocumento";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "Apellidos";
                                column.ColumnName = "Apellidos";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "Nombres";
                                column.ColumnName = "Nombres";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "Edad";
                                column.ColumnName = "Edad";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "Porcentaje";
                                column.ColumnName = "Porcentaje";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.String");
                                column.AllowDBNull = true;
                                column.Caption = "Parentesco";
                                column.ColumnName = "Parentesco";
                                dtBeneficiarioConyuge.Columns.Add(column);

                                DataRow row1 = dtBeneficiarioConyuge.NewRow();
                                row1["NumeroDocumento"] = "";
                                row1["Apellidos"] = "";
                                row1["Nombres"] = "";
                                row1["Edad"] = "";
                                row1["Porcentaje"] = "";
                                row1["Parentesco"] = "";
                                dtBeneficiarioConyuge.Rows.Add(row1);

                                //lLENAR PRIMERA FILA DE LA TABLA BENEFIACIARIOS  
                                DataTable dtBeneficiarioPruebaConyuge2 = new DataTable();
                                dtBeneficiarioPruebaConyuge2 = objAdministrarCertificados.ConsultarBeneficiarioUnico();
                                grvBeneficiarioConyuge.DataSource = dtBeneficiarioPruebaConyuge2;
                                grvBeneficiarioConyuge.DataBind();

                                grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                                grvBeneficiarioConyuge.DataBind();
                                grvBeneficiarioConyuge.Enabled = true;
                            }
                        }

                        otrosAsegurados = objAdministrarCertificados.consultarOtroAsegurado(cer_Id);
                        dtTemp = objAdministrarCertificados.consultarOtroAseguradoIndex(cer_Id);
                        grvOtrosAsegurados.DataSource = otrosAsegurados;
                        grvOtrosAsegurados.DataBind();

                        if (int.Parse(Session["pro_Id"].ToString()) == 99 && otrosAsegurados.Rows.Count == 0)
                        {
                            otrosAsegurados = objAdministrarCertificados.consultarOtroAsegurado(cer_Antiguo);
                            dtTemp = objAdministrarCertificados.consultarOtroAseguradoIndex(cer_Antiguo);
                            grvOtrosAsegurados.DataSource = otrosAsegurados;
                            grvOtrosAsegurados.DataBind();
                        }

                        if (dtTemp.Rows.Count > 0)
                        {
                            double totalPrimaOtroAsegurado = 0;
                            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                            {
                                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                            }
                            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                            sumarPrima(int.Parse(txtPrimaOtros.Text));
                        }

                        bool teniaOtrosAsegurados = true;
                        Session["teniaOtrosAsegurados"] = teniaOtrosAsegurados;

                        if (txtCedulaConyuge.Text != "")
                        {
                            string capturarValorAseguradoRestaConyuge;
                            int celdaCapturadaConyuge = 0;


                            dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Id, 2);///////////////////////////////////////////////////////////////////////////////////
                            grvAmparoConyuge.DataSource = dtEliminarConyuge;
                            grvAmparoConyuge.DataBind();

                            double ValorCampoPrimaTxtConyuge = 0;

                            foreach (DataRow dtValorCampoPrimaTxtConyuge in dtEliminarConyuge.Rows)
                            {
                                if (dtValorCampoPrimaTxtConyuge["Amparo"].ToString() == "VIDA")
                                {
                                    ValorCampoPrimaTxtConyuge = double.Parse(dtValorCampoPrimaTxtConyuge["Valor Asegurado"].ToString());
                                    txtPlanConyuge.Text = ValorCampoPrimaTxtConyuge.ToString();
                                    //ddlPlanConyuge.SelectedItem.Text = ValorCampoPrimaTxtConyuge.ToString();
                                    ddlPlanConyuge.SelectedIndex = ddlPlanConyuge.Items.IndexOf(ddlPlanConyuge.Items.FindByText(ValorCampoPrimaTxtConyuge.ToString()));
                                   
                                }
                            }

                            if (int.Parse(Session["pro_Id"].ToString()) == 99 && dtEliminarConyuge.Rows.Count == 0)
                            {
                                dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Antiguo, 2);
                                grvAmparoConyuge.DataSource = dtEliminarConyuge;
                                grvAmparoConyuge.DataBind();
                            }

                            for (int j = 0; j < dtEliminarConyuge.Rows.Count; j++)
                            {
                                capturarValorAseguradoRestaConyuge = dtEliminarConyuge.Rows[j]["Amparo"].ToString();
                                if (capturarValorAseguradoRestaConyuge == "VIDA")
                                {
                                    celdaCapturadaConyuge = j;
                                    Session["valorAseguradoPrincipalRestaConyuge"] = double.Parse(dtEliminarConyuge.Rows[celdaCapturadaConyuge]["Valor Asegurado"].ToString());
                                }
                            }

                            totales = 0;
                            foreach (GridViewRow row in grvAmparoConyuge.Rows)
                            {
                                totales += Convert.ToDouble(row.Cells[4].Text);
                            }
                            //txtPrimaConyuge.Text = Convert.ToString(totales);
                        }
                    }
                }

                // Carga Plan Conyuge en Migración
                //if (AdministrarCertificados.certificadoPre.Migracion == "2")
                //{
                //    DataTable dtPlanPrin = new DataTable();
                //    dtPlanPrin = AdministrarCertificados.consultarPlanPorPoliza(int.Parse(ddlPoliza.SelectedValue.ToString()), 2, int.Parse(txtEdadConyuge.Text));
                //    ddlPlanConyuge.DataSource = dtPlanPrin;
                //    ddlPlanConyuge.DataValueField = "plapol_Id";
                //    ddlPlanConyuge.DataTextField = "plan_ValAsegurado";
                //    ddlPlanConyuge.DataBind();
                //}

                Session["dtTemp"] = dtTemp;
                Session["dtBeneficiario"] = dtBeneficiario;
                Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;
                if(!IsPostBack)
                {
                    Session["dtBeneficiarioConyugeConsultaTercero"] = dtBeneficiarioConyuge;
                }
                Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
                Session["dtEliminarConyuge"] = dtEliminarConyuge;
                Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
                Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
                Session["rowExtraPrima"] = rowExtraPrima;
                Session["valorExtraPrimado"] = 0;
                Session["valorExtraPrimadoC"] = 0;
                Session["diferenciaValorAseguradoP"] = 0;
                Session["diferenciaValorAseguradoC"] = 0;

                if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                {
                    if ((string)Session["operacionCertificado"] == "modificar")
                    {
                        reqtxtPlanPrincipal.Enabled = false;
                        reqtxtPlanConyuge.Enabled = false;
                    }
                    else
                    {
                        reqtxtPlanPrincipal.Enabled = true;
                        reqtxtPlanConyuge.Enabled = true;
                    }
                   
                    txtPlanPrincipal.Visible = true;
                    txtPlanConyuge.Visible = true;

                    lblPlan.Visible = true;
                    labPlan.Visible = true;

                    ReqddlPlanPrincipal.Enabled = false;
                    ddlPlanPrincipal.Visible = false;

                    reqddlPlanConyuge.Enabled = false;
                    ddlPlanConyuge.Visible = false;

                    labPlan1.Visible = false;
                    lblPlan2.Visible = false;

                    reqtxtPeso.Enabled = false;
                    txtPeso.Visible = false;

                    reqtxtPesoPrincipal.Enabled = false;
                    txtpesoPrincipal.Visible = false;

                    reqtxtestaturaPrincipal.Enabled = false;
                    txtestaturaPrincipal.Visible = false;

                    reqtxtEstatura.Enabled = false;
                    txtEstatura.Visible = false;

                    lblPesoConyuge.Visible = false;
                    lblEstaturaConyuge.Visible = false;
                    labPeso.Visible = false;
                    labEstatura.Visible = false;
                }

                if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "53"
                 || objAdministrarCertificados.objCertificadoPre.Producto == "54" || objAdministrarCertificados.objCertificadoPre.Producto == "55"
                   || objAdministrarCertificados.objCertificadoPre.Producto == "98" || objAdministrarCertificados.objCertificadoPre.Producto == "2" ||
                    objAdministrarCertificados.objCertificadoPre.Producto == "21" || objAdministrarCertificados.objCertificadoPre.Producto == "56"
                    || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                    || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                {
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "21" || objAdministrarCertificados.objCertificadoPre.Producto == "3"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56"
                      )
                    {
                        reqtxtPeso.Enabled = true;
                        txtPeso.Visible = true;

                        reqtxtPesoPrincipal.Enabled = true;
                        txtpesoPrincipal.Visible = true;

                        reqtxtestaturaPrincipal.Enabled = true;
                        txtestaturaPrincipal.Visible = true;

                        reqtxtEstatura.Enabled = true;
                        txtEstatura.Visible = true;

                        lblPesoConyuge.Visible = true;
                        lblEstaturaConyuge.Visible = true;
                        labPeso.Visible = true;
                        labEstatura.Visible = true;
                    }
                    else
                    {
                        reqtxtPeso.Enabled = false;
                        txtPeso.Visible = false;

                        reqtxtPesoPrincipal.Enabled = false;
                        txtpesoPrincipal.Visible = false;

                        reqtxtestaturaPrincipal.Enabled = false;
                        txtestaturaPrincipal.Visible = false;

                        reqtxtEstatura.Enabled = false;
                        txtEstatura.Visible = false;

                        lblPesoConyuge.Visible = false;
                        lblEstaturaConyuge.Visible = false;
                        labPeso.Visible = false;
                        labEstatura.Visible = false;
                    }
                }

                if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                {
                    if ((string)Session["operacionCertificado"] == "modificar")
                    {
                        reqtxtPlanPrincipal.Enabled = false;
                        reqtxtPlanConyuge.Enabled = false;
                    }
                    else
                    {
                        reqtxtPlanPrincipal.Enabled = true;
                        reqtxtPlanConyuge.Enabled = true;
                    }
                    
                    txtPlanPrincipal.Visible = true;
                    txtPlanConyuge.Visible = true;

                    lblPlan.Visible = true;
                    labPlan.Visible = true;

                    ReqddlPlanPrincipal.Enabled = false;
                    ddlPlanPrincipal.Visible = false;

                    reqddlPlanConyuge.Enabled = false;
                    ddlPlanConyuge.Visible = false;

                    labPlan1.Visible = false;
                    lblPlan2.Visible = false;

                    reqtxtPeso.Enabled = true;
                    txtPeso.Visible = true;

                    reqtxtPesoPrincipal.Enabled = true;
                    txtpesoPrincipal.Visible = true;

                    reqtxtestaturaPrincipal.Enabled = true;
                    txtestaturaPrincipal.Visible = true;

                    reqtxtEstatura.Enabled = true;
                    txtEstatura.Visible = true;

                    lblPesoConyuge.Visible = true;
                    lblEstaturaConyuge.Visible = true;
                    labPeso.Visible = true;
                    labEstatura.Visible = true;
                }
            }

            if (!IsPostBack)
            {
                if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                    || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                {
                    txtAnexoConversion.Visible = true;
                    txtHServicio1.Visible = true;
                    txtHServicio2.Visible = true;
                    txtHServicio3.Visible = true;
                    btnGuardarCambios.Visible = true;
                    btnCambiosPreCargue.Visible = true;
                    lblAnexoConversion.Visible = true;
                    lblHServicio1.Visible = true;
                    lblHServicio2.Visible = true;
                    lblHServicio3.Visible = true;
                }
                else
                {
                    txtAnexoConversion.Visible = false;
                    txtHServicio1.Visible = false;
                    txtHServicio2.Visible = false;
                    txtHServicio3.Visible = false;
                    btnGuardarCambios.Visible = false;
                    btnCambiosPreCargue.Visible = false;
                    lblAnexoConversion.Visible = false;
                    lblHServicio1.Visible = false;
                    lblHServicio2.Visible = false;
                    lblHServicio3.Visible = false;
                }

                if (otrosAsegurados.Rows.Count == 0)
                {
                    otrosAsegurados = new DataTable();
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Cedula";
                    column.ColumnName = "Cedula";

                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Nombre";
                    column.ColumnName = "Nombre";
                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Apellidos";
                    column.ColumnName = "Apellidos";
                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Fecha Nacimiento";
                    column.ColumnName = "Fecha Nacimiento";
                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Parentesco";
                    column.ColumnName = "Parentesco";
                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Plan";
                    column.ColumnName = "Plan";
                    otrosAsegurados.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.Caption = "Prima";
                    column.ColumnName = "Prima";
                    otrosAsegurados.Columns.Add(column);
                }
            }

            Session["otrosAsegurados"] = otrosAsegurados;

            if (!IsPostBack)
            {
                if (dtCertificadoFull.Rows.Count > 0)
                {
                    if ((string)Session["operacionCertificado"] == "modificar" || int.Parse(Session["pro_Id"].ToString()) == 99)
                    {
                        grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                        grvBeneficiarioPrincipal.DataBind();

                    }
                    else
                    {
                        grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                        grvBeneficiarioPrincipal.DataBind();
                        //GridViewRow rowPrincipales = grvBeneficiarioPrincipal.Rows[0];
                        //rowPrincipales.Visible = false;
                    }
                }
                else
                {
                    //grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                    //grvBeneficiarioPrincipal.DataBind();
                    //GridViewRow rowPrincipales2 = grvBeneficiarioPrincipal.Rows[0];
                    //rowPrincipales2.Visible = false;
                    DataTable dtBeneficiarioVacio = dtBeneficiario.Clone();
                    DataRow drBeneficiarioVacio = dtBeneficiarioVacio.NewRow();
                    dtBeneficiarioVacio.Rows.Add(drBeneficiarioVacio);
                    grvBeneficiarioPrincipal.DataSource = dtBeneficiarioVacio;
                    grvBeneficiarioPrincipal.DataBind();
                    //grvBeneficiarioPrincipal.Rows[0].Visible = false;
                    grvBeneficiarioPrincipal.Rows[0].Controls.Clear();
                }
            }
            if (!IsPostBack)
            {
                if (dtCertificadoFull.Rows.Count > 0)
                {
                    if ((string)Session["operacionCertificado"] == "modificar" || int.Parse(Session["pro_Id"].ToString()) == 99)
                    {
                        grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                        grvBeneficiarioConyuge.DataBind();
                    }
                    else
                    {
                        grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                        grvBeneficiarioConyuge.DataBind();
                        GridViewRow rowConyuge = grvBeneficiarioConyuge.Rows[0];
                        rowConyuge.Visible = false;
                    }
                }
                else
                {
                    //grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                    //grvBeneficiarioConyuge.DataBind();
                    //GridViewRow rowConyuges = grvBeneficiarioConyuge.Rows[0];
                    //rowConyuges.Visible = false;
                    DataTable dtBeneficiarioConyugeVacio = dtBeneficiarioConyuge.Clone();
                    DataRow drBeneficiarioConyugeVacio = dtBeneficiarioConyugeVacio.NewRow();
                    dtBeneficiarioConyugeVacio.Rows.Add(drBeneficiarioConyugeVacio);
                    grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyugeVacio;
                    grvBeneficiarioConyuge.DataBind();
                    //grvBeneficiarioConyuge.Rows[0].Visible = false;
                    grvBeneficiarioConyuge.Rows[0].Controls.Clear();
                }

                //JC 22-09-2015
                try
                {
                    int cer_Id = int.Parse(Session["cer_id"].ToString());
                    //dtEncabezadoCertificado = AdministrarCertificados.spConsultarEncabezadoCertificado(int.Parse(Session["cer_Id"].ToString()));
                    DataTable dtEncabezadoCertificado = new DataTable();
                    dtEncabezadoCertificado = objAdministrarCertificados.spConsultarEncabezadoCertificado(cer_Id);
                    txtCompania.Text = dtEncabezadoCertificado.Rows[0]["com_Nombre"].ToString();
                    ddlProducto.DataTextField = "pro_Nombre"; // Cargamos lo que aparece en el ddl
                    ddlProducto.DataValueField = "pro_Id"; // Cargamos lo que vale por debajo
                    ddlProducto.DataSource = dtEncabezadoCertificado;
                    ddlProducto.DataBind();
                    if (objAdministrarCertificados.objCertificadoPre.Migracion != "2")
                        txtEstadoNegocio.Text = dtEncabezadoCertificado.Rows[0]["cer_EstadoNegocio"].ToString();
                    //txtTipoMovimiento.Text = dtEncabezadoCertificado.Rows[0]["Principal"].ToString() + ", " + dtEncabezadoCertificado.Rows[0]["Conyuge"].ToString() + " Y " + dtEncabezadoCertificado.Rows[0]["Conyuge"].ToString();
                    txtmesProduccion.Text = dtEncabezadoCertificado.Rows[0]["MesProduccion"].ToString();
                    Session["dtEncabezadoCertificado"] = dtEncabezadoCertificado;
                }
                catch { }

                if ((string)Session["operacionCertificado"] == "modificar" || (int.Parse(Session["pro_Id"].ToString()) == 99 && dtCertificadoFull.Rows.Count > 0))
                {
                    int pagaduria = int.Parse(objAdministrarCertificados.consultarConvenioPorPagaduria(double.Parse(Session["cerIdPagaduria"].ToString())).Rows[0]["paga_Id"].ToString());
                    DataTable dt = new DataTable();
                    dt = objAdministrarCertificados.consultarConvenios(int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), pagaduria);
                    ddlConvenioPrincipal.DataTextField = "con_Nombre";
                    ddlConvenioPrincipal.DataValueField = "con_Id";
                    ddlConvenioPrincipal.DataSource = dt;
                    ddlConvenioPrincipal.DataBind();
                    ddlConvenioPrincipal.Items.Insert(0, new ListItem("", ""));
                    ddlConvenioPrincipal.SelectedIndex = ddlConvenioPrincipal.Items.IndexOf(ddlConvenioPrincipal.Items.FindByValue(dtCertificadoFull.Rows[0]["cer_Convenio"].ToString()));
                }

                Session["dtCertificadoFull"] = dtCertificadoFull;
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = objAdministrarCertificados.consultarParentesco(int.Parse(objAdministrarCertificados.objCertificadoPre.Producto));
                ddlParentesoOtro.DataTextField = "par_Nombre";
                ddlParentesoOtro.DataValueField = "par_Id";
                ddlParentesoOtro.DataSource = dt;
                ddlParentesoOtro.DataBind();
                ddlParentesoOtro.Items.Insert(0, new ListItem("", ""));
            }

            /*------------------------------------------------*/
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarTipoDocumento();
                ddlTipoDocumentoTercero.DataTextField = "tipDoc_Nombre"; // Cargamos lo que aparece en el ddl
                ddlTipoDocumentoTercero.DataValueField = "tipDoc_Id"; // Cargamos lo que vale por debajo
                ddlTipoDocumentoTercero.DataSource = dt;
                ddlTipoDocumentoTercero.DataBind();
                ddlTipoDocumentoTercero.Items.Insert(0, new ListItem("", ""));
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarDepartamento();
                ddlDepartamento.DataTextField = "dep_Nombre"; // Cargamos lo que aparece en el ddl
                ddlDepartamento.DataValueField = "dep_Id"; // Cargamos lo que vale por debajo
                ddlDepartamento.DataSource = dt;
                ddlDepartamento.DataBind();
                ddlDepartamento.Items.Insert(0, new ListItem("", ""));
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarOcupacion();
                ddlOcupacionTercero.DataTextField = "ocu_Nombre"; // Cargamos lo que aparece en el ddl
                ddlOcupacionTercero.DataValueField = "ocu_Id"; // Cargamos lo que vale por debajo
                ddlOcupacionTercero.DataSource = dt;
                ddlOcupacionTercero.DataBind();
                ddlOcupacionTercero.Items.Insert(0, new ListItem("", ""));
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_ConsultarEstadoCivil();
                ddlEstadoCivilTercero.DataTextField = "estCiv_Nombre"; // Cargamos lo que aparece en el ddl
                ddlEstadoCivilTercero.DataValueField = "estCiv_Id"; // Cargamos lo que vale por debajo
                ddlEstadoCivilTercero.DataSource = dt;
                ddlEstadoCivilTercero.DataBind();
                ddlEstadoCivilTercero.Items.Insert(0, new ListItem("", ""));
            }

            /*-----------------------------------------------------*/
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarTipoDocumento();
                ddlTipoDocumentoOtros.DataTextField = "tipDoc_Nombre"; // Cargamos lo que aparece en el ddl
                ddlTipoDocumentoOtros.DataValueField = "tipDoc_Id"; // Cargamos lo que vale por debajo
                ddlTipoDocumentoOtros.DataSource = dt;
                ddlTipoDocumentoOtros.DataBind();
                ddlTipoDocumentoOtros.Items.Insert(0, new ListItem("", ""));
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarDepartamento();
                ddlDepartamentoOtros.DataTextField = "dep_Nombre"; // Cargamos lo que aparece en el ddl
                ddlDepartamentoOtros.DataValueField = "dep_Id"; // Cargamos lo que vale por debajo
                ddlDepartamentoOtros.DataSource = dt;
                ddlDepartamentoOtros.DataBind();
                ddlDepartamentoOtros.Items.Insert(0, new ListItem("", ""));
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarOcupacion();
                ddlOcupacionOtros.DataTextField = "ocu_Nombre"; // Cargamos lo que aparece en el ddl
                ddlOcupacionOtros.DataValueField = "ocu_Id"; // Cargamos lo que vale por debajo
                ddlOcupacionOtros.DataSource = dt;
                ddlOcupacionOtros.DataBind();
                ddlOcupacionOtros.Items.Insert(0, new ListItem("", ""));
            }

            if (txtCedulaConyuge.Text == "")
            {
                ddlPlanConyuge.Enabled = false;
                grvAmparoConyuge.Visible = false;
                btnExtraPrima2.Visible = false;
                btnLimpiar.Visible = false;
            }
            else
            {
                ddlPlanConyuge.Enabled = true;
                grvAmparoConyuge.Visible = true;
                grvBeneficiarioConyuge.Visible = true;
                beneficiariosConyuge.Visible = true;
                btnExtraPrima2.Visible = true;
                btnLimpiar.Visible = true;
            }

            if (ddlPlanConyuge.SelectedValue != "")
            {
                amparosConyuge.Visible = true;
            }
            else
            {
                amparosConyuge.Visible = false;
            }

            if (ddlPlanPrincipal.SelectedValue != "")
            {
                amparosPrincipal.Visible = true;
            }
            else
            {
                amparosPrincipal.Visible = false;
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_ConsultarEstadoCivil();
                ddlEstadoCivilOtros.DataTextField = "estCiv_Nombre"; // Cargamos lo que aparece en el ddl
                ddlEstadoCivilOtros.DataValueField = "estCiv_Id"; // Cargamos lo que vale por debajo
                ddlEstadoCivilOtros.DataSource = dt;
                ddlEstadoCivilOtros.DataBind();
                ddlEstadoCivilOtros.Items.Insert(0, new ListItem("", ""));

                if (txtCedulaOtro.Text != "" && ddlPoliza.Text != "")
                {
                    ddlParentesoOtro.Enabled = true;
                }
                else
                {
                    ddlParentesoOtro.Enabled = false;
                }

                if (ddlPoliza.Text != "" && txtCedulaOtro.Text != "" && ddlParentesoOtro.Text != "")
                {
                    ddlPlanOtros.Enabled = true;
                }
                else
                {
                    ddlPlanOtros.Enabled = false;
                }

                if (ddlPoliza.Text == "")
                {
                    ddlPlanPrincipal.Enabled = false;
                }
                else
                {
                    if (objAdministrarCertificados.objCertificadoPre.Migracion != "2" && objAdministrarCertificados.objCertificadoPre.Migracion != "3")
                        ddlPlanPrincipal.Enabled = true;
                }

                if (ddlPoliza.Text != "" && txtCedulaConyuge.Text != "")
                {
                    ddlPlanConyuge.Enabled = true;
                }
                else
                {
                    ddlPlanConyuge.Enabled = false;
                }

                if (ddlLocalidadCertificado.Text == "")
                {
                    ddlPoliza.Enabled = false;
                }
                else
                {
                    if (objAdministrarCertificados.objCertificadoPre.Migracion != "2" && objAdministrarCertificados.objCertificadoPre.Migracion != "3")
                        ddlPoliza.Enabled = true;
                }

                //txtPlanPrincipal.Text = "";
                //txtPlanConyuge.Text = "";

                if (ddlPoliza.Text != "")
                {
                    txtPlanPrincipal.Enabled = true;
                }
                else
                {
                    txtPlanPrincipal.Enabled = false;
                }
                if (ddlPoliza.Text != "" && txtCedulaConyuge.Text != "")
                {
                    txtPlanConyuge.Enabled = true;
                }
                else
                {
                    txtPlanConyuge.Enabled = false;
                }
                txtFechaDigitacionCertificado.Text = DateTime.Now.ToString("dd/MM/yyyy");


                if (ddlPoliza.SelectedValue != "")
                {
                    txtDocumentoOtros.Enabled = true;
                    txtDocumentoConyugue.Enabled = true;

                   

                    DataTable dtPoliza = new DataTable();
                    if ((string)Session["operacionCertificado"] == "modificar")
                    {
                        DataTable permaneciaAsegurado = new DataTable();
                        int permaneciaAseguradoCertificado = 0;

                        permaneciaAsegurado = objAdministrarCertificados.ConsultarFechaExpedicionCertificadoAnterior(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
                        permaneciaAseguradoCertificado = Funciones.FechaIngresoAsegurado(DateTime.Parse(permaneciaAsegurado.Rows[0]["cer_FechaExpedicion"].ToString()), DateTime.Parse(dtCertificadoFull.Rows[0]["ter_FechaNacimiento"].ToString()));

                        dtPoliza = objAdministrarCertificados.consultarPlanPorPolizaPermanencia(int.Parse(ddlPoliza.SelectedValue.ToString()), 1, permaneciaAseguradoCertificado);

                    }
                    else
                    {
                        dtPoliza = objAdministrarCertificados.consultarPlanPorPoliza(int.Parse(ddlPoliza.SelectedValue.ToString()), 1, int.Parse(txtEdadPrincipal.Text));

                    }

                    if (objAdministrarCertificados.objCertificadoPre.Migracion != "2")
                    {
                        try
                        {
                            ddlPlanPrincipal.DataSource = dtPoliza;
                            ddlPlanPrincipal.DataValueField = "plapol_Id";
                            ddlPlanPrincipal.DataTextField = "plan_ValAsegurado";
                            ddlPlanPrincipal.DataBind();
                            //ddlPlanPrincipal.Items.Insert(0, new ListItem("", ""));
                        }
                        catch { }

                        int cer_Id = objAdministrarCertificados.ConsultarIdCertificado(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()), "VIGENTE", "PRODUCCION NUEVA");
                        dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_Id, 1);
                        double ValorCampoPrimaTxt = 0;

                        foreach (DataRow dtValorCampoPrimaTxt in dtEliminarPrincipal.Rows)
                        {
                            if (dtValorCampoPrimaTxt["Amparo"].ToString() == "VIDA")
                            {
                                ValorCampoPrimaTxt = double.Parse(dtValorCampoPrimaTxt["Valor Asegurado"].ToString());
                                txtPlanPrincipal.Text = ValorCampoPrimaTxt.ToString();
                                 
                                foreach(DataRow dtCertificadoFullValor in  dtCertificadoFull.Rows)
                                {
                                    if (int.Parse(dtCertificadoFullValor["ampcer_ValAsegurado"].ToString()) == ValorCampoPrimaTxt)
                                    {
                                        ddlPlanPrincipal.SelectedIndex = ddlPlanPrincipal.Items.IndexOf(ddlPlanPrincipal.Items.FindByText(dtCertificadoFullValor["ampcer_ValAsegurado"].ToString()));
                                        ddlPlanPrincipal.SelectedValue = ddlPlanPrincipal.Items.IndexOf(ddlPlanPrincipal.Items.FindByValue(dtCertificadoFullValor["pla_Id"].ToString())).ToString();
                                    }
                                }
                            }
                        }
                    }

                    if (dtPoliza.Rows.Count > 0)
                    {
                        Session["plapol_Id"] = dtPoliza.Rows[0]["plapol_Id"].ToString();
                        if (txtCedulaOtro.Text != "" && ddlPoliza.Text != "")
                        {
                            ddlParentesoOtro.Enabled = true;
                        }
                        else
                        {
                            ddlParentesoOtro.Enabled = false;

                        }

                        if (ddlPoliza.Text != "")
                        {
                            txtPlanPrincipal.Enabled = true;
                        }
                        else
                        {
                            txtPlanPrincipal.Enabled = false;
                        }

                        if (ddlPoliza.Text == "")
                        {
                            ddlPlanPrincipal.Enabled = false;
                        }
                        else
                        {
                            if (objAdministrarCertificados.objCertificadoPre.Migracion != "2")
                                ddlPlanPrincipal.Enabled = true;
                        }

                        if (ddlPoliza.Text != "" && txtCedulaConyuge.Text != "")
                        {
                            ddlPlanConyuge.Enabled = true;
                        }
                        else
                        {
                            ddlPlanConyuge.Enabled = false;
                        }
                    }
                    if (ddlPlanPrincipal.Enabled == true)
                    {
                        // ddlPlanPrincipal.SelectedIndex = ddlPlanPrincipal.Items.IndexOf(ddlPlanPrincipal.Items.FindByValue(dtCertificadoFull.Rows[0]["pla_Id"].ToString()));
                    }
                }
               
            }
        }
        

        if (txtCedulaConyuge.Text != "")
        {
            grvBeneficiarioConyuge.Visible = true;
            beneficiariosConyuge.Visible = true;
        }
        else
        {
            grvBeneficiarioConyuge.Visible = false;
            beneficiariosConyuge.Visible = false;
        }

        if(!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "RECUERDE VALIDAR SECUENCIALMENTE LOS FORMULARIOS" + "');", true);

        }

        if (!IsPostBack)
        {
            DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
            if (dtCertificadoFull.Rows.Count > 0)
            {
                if ((string)Session["operacionCertificado"] == "modificar" || (int.Parse(dtCertificadoFull.Rows[0]["pro_Id"].ToString()) == 1 && int.Parse(ddlProducto.SelectedValue.ToString()) == 99))
                {
                    if (grvBeneficiarioConyuge.Rows.Count == 1)
                    {
                        //grvBeneficiarioConyuge.Rows[0].Visible = true;
                    }
                }
            }
            else
            {
               
                DataTable dtCasesp_IdPreCargue = new DataTable();
                dtCasesp_IdPreCargue = objAdministrarCertificados.ConsultarCasoEspecialPreCargue(int.Parse(txtCertificado.Text), int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(txtCedulaPrincipal.Text));
                if (int.Parse(dtCasesp_IdPreCargue.Rows[0]["casesp_Id"].ToString()) != 2)
                {
                    grvBeneficiarioPrincipal.Rows[0].Visible = false;
                }
                if (grvBeneficiarioConyuge.Rows.Count > 0)
                {
                    grvBeneficiarioConyuge.Rows[0].Visible = false;
                }
            }
        }

        if (!IsPostBack)
        {
            ReestructurarExtraPrimaPrincipal();
        }

        if(!IsPostBack)
        {
            ReestructurarExtraPrimaConyuge();  
        }

    }

    public void ReestructurarExtraPrimaPrincipal()
    {
        try
        {
            if ((string)Session["operacionCertificado"] == "modificar")
            {
                //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
                DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
                DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
                DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];
                DataTable dtExtraprimaPrincipalRestaurar = new DataTable();
                DataTable dtPlanTieneTasa = new DataTable();
                Session["totalPrimaGeneralEliminar"] = 0;
                Session["totalValorPrimaEliminar"] = 0;
                double totalExtraPrimaP = 0;
                double diferenciaValorAsegurado = 0;
                double totalExtraPrimaP3 = 0;
                double primaDt = 0;
                double totalPrimaEdad = 0;
                double primaDtGeneral = 0;
                txtDocumentoConyugue.Enabled = true;
                int cer_IdNuevo = 0;
                int valorAseguradoPrincipal = 0;

                if (txtPlanPrincipal.Text != "")
                {
                    valorAseguradoPrincipal = int.Parse(txtPlanPrincipal.Text);
                }

                cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
                Session["cerId_ValorNuevo"] = cer_IdNuevo;

                int cer_IdAnterior = 0;
                DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
                if (dtCer_IdExtraPrima.Rows.Count > 0)
                {
                    cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
                }

                if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                {
                    try
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                    }
                    catch
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                    }

                    int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                    dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);

                    totalPrimaEdad = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarPrincipal);

                    //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                    dtExtraprimaPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);


                    DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                    dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(cer_IdAnterior, 1);

                    double valorAseguradoExtraPrima = 0;
                    double valorAseguradoDt = 0;
                    double TasaDt = 0;

                    //Pregunta si el plan seleccionado se maneja con tasa y diferencia
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                    {
                        //Recorrer el dt con el que se lleno la tabla extra prima
                        foreach (DataRow dt in dtExtraprimaPrincipal.Rows)
                        {
                            //recorrer el dt con los valores del certificado anterior 
                            foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                            {
                                //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
                                if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                                {
                                    //asigna el valor asegurado del primer dt a esta variable
                                    valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                    //asignala tasa del primer dt a esta variable
                                    TasaDt = double.Parse(dt["Tasa"].ToString());
                                    //Asigna esta varible al valor asegurado del segundo dt
                                    valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                    //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                    diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                    //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                    if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                    {
                                        // asigna un valor a una session
                                        if (diferenciaValorAsegurado != 0)
                                        {
                                            Session["diferenciaValorAseguradoP"] = diferenciaValorAsegurado;
                                        }
                                        else
                                        {
                                            Session["diferenciaValorAseguradoP"] = 0;
                                        }
                                    }
                                    // asigna una variable a un campo del primer dt
                                    dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                    //realiza una operacion para saber el valor de la prima
                                    primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                    //asigna la vartiable de prima a un campo del dt
                                    dt["Prima"] = primaDt;
                                }
                            }
                            //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                            dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                            foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                            {
                                DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                row2.ItemArray = row.ItemArray;
                                dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                            }
                            // asigna este dt a la session 
                            Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                        }
                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                    {
                        foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                        {
                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                            }
                        }
                        foreach (DataRow dt2 in dtExtraprimaPrincipal.Rows)
                        {
                            if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                TasaDt = double.Parse(dt2["Tasa"].ToString());
                            }
                        }
                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                    {
                        //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                        dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                        foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                        {
                            DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                            row2.ItemArray = row.ItemArray;
                            dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                        }
                        // asigna este dt a la session 

                        Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                    }
                    double totales = 0;
                    foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                    {
                        totales += Convert.ToDouble(row.Cells[4].Text);
                    }

                    //txtPrimaPrincipal.Text = Convert.ToString(totales);

                    grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                    grvAmparoPrincipal.DataBind();

                    // Cargar tabla de amparos para ingresar la extraprima
                    grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
                    grvAmparoExtraPrima.DataBind();

                    // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial
                    DataSet dsConsultarHistirialPorcentajeExtraPrimado = new DataSet();
                    dsConsultarHistirialPorcentajeExtraPrimado = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1);

                    DataTable dtConsultarHistirialPorcentajeExtraPrimado = new DataTable();
                    foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimado.Tables)
                    {
                        dtConsultarHistirialPorcentajeExtraPrimado.Merge(dt);
                    }
                    grvConsultarHistirialPorcentajeExtraPrimado.DataSource = dtConsultarHistirialPorcentajeExtraPrimado;
                    grvConsultarHistirialPorcentajeExtraPrimado.DataBind();

                    //Consulta el historial del cliente pero general
                    DataTable dtConsultarHistorialExtraPrima = new DataTable();
                    dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
                    grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
                    grvHistorialExtraPrima.DataBind();

                    double consultarHistorialExtraPrima = 0;
                    double valorExtraPrima = 0;


                    //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                    if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
                    {
                        // Recorre el dt para consultar los valores de prima y extra prima
                        foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                        {
                            consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                            valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
                            
                        }

                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                    {
                        primaDt = primaDtGeneral - consultarHistorialExtraPrima;
                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                    {
                        //recorre tabla de extra prima para la suma de primas 
                        foreach (GridViewRow row in grvAmparoExtraPrima.Rows)
                        {
                            totalExtraPrimaP += Convert.ToDouble(row.Cells[4].Text);
                        }

                        if (totalExtraPrimaP != totalPrimaEdad && (totalPrimaEdad != 0))
                        {
                            totalExtraPrimaP = totalPrimaEdad - consultarHistorialExtraPrima;
                        }

                        // Asignar variables con valores a los campos de prima y extra prima 
                        totalExtraPrimaP3 = totalExtraPrimaP;
                        totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                        txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                        txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                        txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                    }
                    else
                    {
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                totalExtraPrimaP3 = primaDt;
                                totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                                txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                            }
                            else
                            {
                                totalExtraPrimaP3 = primaDtGeneral;
                                txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                totalExtraPrimaP = totalExtraPrimaP3;
                            }
                        }
                        else
                        {

                            foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                            {
                                primaDt += Convert.ToDouble(row.Cells[4].Text);
                            }
                            totalExtraPrimaP3 = primaDt;
                            totalExtraPrimaP = totalExtraPrimaP3;
                            txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                            txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                            txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                            txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                        }
                    }

                    int primaPrincipal = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipal.Text)).ToString());
                    txtPrimaPrincipal.Text = primaPrincipal.ToString();
                    int PrimaPrincipalExtraprima = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprima.Text)).ToString());
                    txtPrimaPrincipalExtraprima.Text = PrimaPrincipalExtraprima.ToString();
                    if (txtExtraPrimaPrincipal.Text != "")
                    {
                        int ExtraPrimaPrincipal = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaPrincipal.Text)).ToString());
                        txtExtraPrimaPrincipal.Text = ExtraPrimaPrincipal.ToString();
                    }


                }
                else
                {
                    dtEliminarPrincipal.Clear();
                    grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                    grvAmparoPrincipal.DataBind();
                }

                double totalPrimaOtroAsegurado = 0;
                sumarPrima(0);

                if (grvOtrosAsegurados.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                    {
                        totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                    }
                    txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                    sumarPrima(int.Parse(txtPrimaOtros.Text));
                }
                Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
                Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
                Session["TotalExtraPrimaP"] = totalExtraPrimaP;
                Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS SE HA PRODUCIDO UN ERROR" + "');", true);
        }
    }

    public void ReestructurarExtraPrimaConyuge()
    {
        try
        {
            DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
            //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtExtraprimaConyugeRestaurar = new DataTable();
            DataTable dtPlanTieneTasa = new DataTable();
            Session["totalPrimaGeneralEliminarConyuge"] = 0;
            Session["totalValorPrimaEliminarConyuge"] = 0;
            double totalExtraPrimaC = 0;
            DataTable dtCumuloValorConyuge = new DataTable();
            double diferenciaValorAsegurado = 0;
            double totalPrimaEdadConyuge = 0;
            double totalExtraPrimaC3 = 0;
            double primaDt = 0;
            double primaDtGeneral = 0;

            int valorAseguradoConyuge = 0;

            if (txtPlanPrincipal.Text != "")
            {
                valorAseguradoConyuge = int.Parse(txtPlanConyuge.Text);
            }
            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
            Session["cerId_ValorNuevo"] = cer_IdNuevo;

            int cer_IdAnterior = 0;
            DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
            if (dtCer_IdExtraPrima.Rows.Count > 0)
            {
                cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
            }

            if ((string)Session["operacionCertificado"] == "modificar" && dtCer_IdExtraPrima.Rows[0]["idConyuge"].ToString() != "")
            {

                if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                {
                    try
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                    }
                    catch
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                    }

                    int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                    try
                    {
                        dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                        totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);
                        //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                        dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                    }
                    catch
                    {
                        dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_Id"].ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                        totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);
                        //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                        dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_Id"].ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                    }
                    //grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    //grvAmparoConyuge.DataBind(); 

                    DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                    dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                    double valorAseguradoExtraPrima = 0;
                    double valorAseguradoDt = 0;
                    double TasaDt = 0;

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                    {
                        //Recorrer el dt con el que se lleno la tabla extra prima
                        foreach (DataRow dt in dtExtraprimaConyuge.Rows)
                        {
                            //recorrer el dt con los valores del certificado anterior 
                            foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                            {
                                //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
                                if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                                {
                                    //asigna el valor asegurado del primer dt a esta variable 
                                    valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                    //asignala tasa del primer dt a esta variable
                                    TasaDt = double.Parse(dt["Tasa"].ToString());
                                    //Asigna esta varible al valor asegurado del segundo dt
                                    valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                    //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                    diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                    //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                    if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                    {
                                        // asigna un valor a una session
                                        if (diferenciaValorAsegurado != 0)
                                        {
                                            Session["diferenciaValorAseguradoC"] = diferenciaValorAsegurado;
                                        }
                                        else
                                        {
                                            Session["diferenciaValorAseguradoC"] = 0;
                                        }
                                    }
                                    // asigna una variable a un campo del primer dt
                                    dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                    //realiza una operacion para saber el valor de la prima
                                    primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                    //asigna la vartiable de prima a un campo del dt
                                    dt["Prima"] = primaDt;
                                }
                            }
                            //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                            dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                            foreach (DataRow row in dtExtraprimaConyuge.Rows)
                            {
                                DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                                row2.ItemArray = row.ItemArray;
                                dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                            }
                            // asigna este dt a la session 
                            Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                        }
                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                    {
                        foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                        {
                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                            }
                        }
                        foreach (DataRow dt2 in dtExtraprimaConyuge.Rows)
                        {
                            if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                TasaDt = double.Parse(dt2["Tasa"].ToString());
                            }
                        }
                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                    {
                        //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                        dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                        foreach (DataRow row in dtExtraprimaConyuge.Rows)
                        {
                            DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                            row2.ItemArray = row.ItemArray;
                            dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                        }
                        // asigna este dt a la session 

                        Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                    }
                    double totales = 0;
                    foreach (GridViewRow row in grvAmparoConyuge.Rows)
                    {
                        totales += Convert.ToDouble(row.Cells[4].Text);
                    }
                    //txtPrimaConyuge.Text = Convert.ToString(totales);

                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();
                    // Extra Prima
                    grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
                    grvExtraPrimaConyuge.DataBind();

                    // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial

                    DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
                    dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                    DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
                    foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
                    {
                        dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt);
                    }
                    grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
                    grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();

                    //Consulta el historial del cliente pero general
                    DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                    dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
                    grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
                    grvHistorialExtraPrimaConyuge.DataBind();


                    double consultarHistorialExtraPrimaConyuge = 0;
                    double valorExtraPrimaConyuge = 0;

                    //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                    if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                    {
                        // Recorre el dt para consultar los valores de prima y extra prima
                        foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                        {
                            consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                            valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
                        }

                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                    {
                        primaDt = primaDtGeneral - consultarHistorialExtraPrimaConyuge;
                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                    {
                        //recorre tabla de extra prima para la suma de primas 
                        foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
                        {
                            totalExtraPrimaC += Convert.ToDouble(row.Cells[4].Text);
                        }

                        if (totalExtraPrimaC != totalPrimaEdadConyuge && (totalPrimaEdadConyuge != 0))
                        {
                            totalExtraPrimaC = totalPrimaEdadConyuge - consultarHistorialExtraPrimaConyuge;
                        }
                        // Asignar variables con valores a los campos de prima y extra prima 
                        totalExtraPrimaC3 = totalExtraPrimaC;
                        totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                        txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                    }
                    else
                    {
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                totalExtraPrimaC3 = primaDt;
                                totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                            }
                            else
                            {
                                totalExtraPrimaC3 = primaDtGeneral;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                totalExtraPrimaC = totalExtraPrimaC3;
                            }
                        }
                        else
                        {
                            foreach (GridViewRow row in grvAmparoConyuge.Rows)
                            {
                                primaDt += Convert.ToDouble(row.Cells[4].Text);
                            }
                            totalExtraPrimaC3 = primaDt;
                            totalExtraPrimaC = totalExtraPrimaC3;
                            txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                            txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                            txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                            txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                        }
                    }

                    int PrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
                    txtPrimaConyuge.Text = PrimaConyuge.ToString();
                    int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
                    txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
                    if (txtExtraPrimaConyuge.Text != "")
                    {
                        int ExtraPrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());
                        txtExtraPrimaConyuge.Text = ExtraPrimaConyuge.ToString();
                    }

                }
                else
                {
                    dtEliminarConyuge.Clear();
                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();
                }

                double totalPrimaOtroAsegurado = 0;
                sumarPrima(0);

                if (grvOtrosAsegurados.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                    {
                        totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                    }
                    txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                    sumarPrima(int.Parse(txtPrimaOtros.Text));
                }
            }
            Session["dtEliminarConyuge"] = dtEliminarConyuge;
            Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
            Session["TotalExtraPrimaC"] = totalExtraPrimaC;
            Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS SE HA PRODUCIDO UN ERROR" + "');", true);
        }
    }

    public void ConsultarPrimaConyuge()
    {
        try
        {
            DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
            //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtExtraprimaConyugeRestaurar = new DataTable();
            DataTable dtPlanTieneTasa = new DataTable();
            Session["totalPrimaGeneralEliminarConyuge"] = 0;
            Session["totalValorPrimaEliminarConyuge"] = 0;
            double totalExtraPrimaC = 0;
            DataTable dtCumuloValorConyuge = new DataTable();
            double totalPrimaEdadConyuge = 0;
            double totalExtraPrimaC3 = 0;
            double primaDt = 0;

            if(ddlPlanConyuge.SelectedValue.ToString() != "")
            {
                try
                {
                    dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                }
                catch
                {
                    dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                }

                totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);

                DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
                dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
                foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
                {
                    dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt);
                }
                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();

                //Consulta el historial del cliente pero general
                DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
                grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
                grvHistorialExtraPrimaConyuge.DataBind();


                double consultarHistorialExtraPrimaConyuge = 0;
                double valorExtraPrimaConyuge = 0;

                //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                {
                    // Recorre el dt para consultar los valores de prima y extra prima
                    foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                    {
                        consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                        valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
                    }

                }

                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                {
                    primaDt = totalPrimaEdadConyuge;
                }

                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                {
                    //recorre tabla de extra prima para la suma de primas 
                    //foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
                    //{
                    totalExtraPrimaC = totalPrimaEdadConyuge;
                    //}

                    //if (totalExtraPrimaC != totalPrimaEdadConyuge && (totalPrimaEdadConyuge != 0))
                    //{
                    //    totalExtraPrimaC = totalPrimaEdadConyuge - consultarHistorialExtraPrimaConyuge;
                    //}
                    // Asignar variables con valores a los campos de prima y extra prima 
                    totalExtraPrimaC3 = totalExtraPrimaC;
                    totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge;
                    txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                    txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                    txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                }
                else
                {
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                    {
                        totalExtraPrimaC3 = primaDt;
                        totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprimaConyuge.Text;
                        txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                    }
                    else
                    {
                        foreach (GridViewRow row in grvAmparoConyuge.Rows)
                        {
                            primaDt += Convert.ToDouble(row.Cells[4].Text);
                        }
                        totalExtraPrimaC3 = primaDt;
                        totalExtraPrimaC = totalExtraPrimaC3;
                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                        txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                    }
                }

                int PrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
                txtPrimaConyuge.Text = PrimaConyuge.ToString();
                int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
                txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
                if (txtExtraPrimaConyuge.Text != "")
                {
                    int ExtraPrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());
                    txtExtraPrimaConyuge.Text = ExtraPrimaConyuge.ToString();
                }
             }
             else
             {
                  dtEliminarConyuge.Clear();
                  grvAmparoConyuge.DataSource = dtEliminarConyuge;
                  grvAmparoConyuge.DataBind();
             }
            double totalPrimaOtroAsegurado = 0;
            sumarPrima(0);

            if (grvOtrosAsegurados.Rows.Count > 0)
            {
                foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                {
                    totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                }
                txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                sumarPrima(int.Parse(txtPrimaOtros.Text));
            }

           Session["dtEliminarConyuge"] = dtEliminarConyuge;
           Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
           Session["TotalExtraPrimaC"] = totalExtraPrimaC;
           Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS SE HA PRODUCIDO UN ERROR" + "');", true);
        }
    }

    protected void ConsultarAmparosPlan(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        //Session["PolizaPrincipalSession"] = dtPlanPrin.Rows[0]["plan_TieneTasa"];
        try
        {
            DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];
            DataTable dtExtraprimaPrincipalRestaurar = new DataTable();
            DataTable dtPlanTieneTasa = new DataTable();
            Session["totalPrimaGeneralEliminar"] = 0;
            Session["totalValorPrimaEliminar"] = 0;
            double totalExtraPrimaP = 0;
            double diferenciaValorAsegurado = 0;
            double totalExtraPrimaP3 = 0;
            double primaDt = 0;
            double totalPrimaEdad = 0;
            double primaDtGeneral = 0;
            txtDocumentoConyugue.Enabled = true;

            int valorAseguradoPrincipal = 0;

            if (txtPlanPrincipal.Text != "")
            {
                valorAseguradoPrincipal = int.Parse(txtPlanPrincipal.Text);
            }
            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
            Session["cerId_ValorNuevo"] = cer_IdNuevo;

            int cer_IdAnterior = 0;
            DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
            if (dtCer_IdExtraPrima.Rows.Count > 0)
            {
                cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
            }

            //DataTable dtCer_Id = new DataTable();
            //dtCer_Id = AdministrarCertificados.sp_ConsultarIdCertificadoValorAsegurado(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()), "VIGENTE", "PRODUCCION NUEVA");
            // Validar que el plan escogido pueda ser seleccionado por los cúmulos
            DataTable dtCumuloValor = new DataTable();
            double valorAsegurado = 0;
            //dtCumuloValor = AdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()));
            dtCumuloValor = objAdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));
            //valorAsegurado = AdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()), int.Parse(txtCedulaPrincipal.Text));
            valorAsegurado = objAdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()), int.Parse(txtCedulaPrincipal.Text));
            //DataTable dtValorVigente = new DataTable()consultarPlanPorPoliza;
            //dtValorVigente = AdministrarCertificados.ConsultarEstadoNegocioPorCerId(int.Parse(Session["cer_Id"].ToString()));
            valorAsegurado = valorAsegurado - double.Parse(Session["valorAseguradoPrincipalResta"].ToString());


            if ((valorAsegurado + double.Parse(ddlPlanPrincipal.SelectedItem.ToString())) <= double.Parse(dtCumuloValor.Rows[0]["cum_Nombre"].ToString()))
            {
                if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                {
                    try
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                    }
                    catch
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                    }
                    if ((string)Session["operacionCertificado"] == "modificar")
                    {
                        int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                        dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);
                        totalPrimaEdad = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarPrincipal);
                        //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                        dtExtraprimaPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);


                        DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                        dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(cer_IdAnterior, 1);

                        double valorAseguradoExtraPrima = 0;
                        double valorAseguradoDt = 0;
                        double TasaDt = 0;

                        //Pregunta si el plan seleccionado se maneja con tasa y diferencia
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                        {
                            //Recorrer el dt con el que se lleno la tabla extra prima
                            foreach (DataRow dt in dtExtraprimaPrincipal.Rows)
                            {
                                //recorrer el dt con los valores del certificado anterior 
                                foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                                {
                                    //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
                                    if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                                    {
                                        //asigna el valor asegurado del primer dt a esta variable
                                        valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                        //asignala tasa del primer dt a esta variable
                                        TasaDt = double.Parse(dt["Tasa"].ToString());
                                        //Asigna esta varible al valor asegurado del segundo dt
                                        valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                        //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                        diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                        //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                        if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                        {
                                            // asigna un valor a una session
                                            if (diferenciaValorAsegurado != 0)
                                            {
                                                Session["diferenciaValorAseguradoP"] = diferenciaValorAsegurado;
                                            }
                                            else
                                            {
                                                Session["diferenciaValorAseguradoP"] = 0;
                                            }
                                        }
                                        // asigna una variable a un campo del primer dt
                                        dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                        //realiza una operacion para saber el valor de la prima
                                        primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                        //asigna la vartiable de prima a un campo del dt
                                        dt["Prima"] = primaDt;
                                    }
                                }
                                //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                                dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                                foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                                {
                                    DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                    row2.ItemArray = row.ItemArray;
                                    dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                                }
                                // asigna este dt a la session 
                                //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                            }
                        }
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                        {
                            foreach(DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                            {
                                if(int.Parse(dt["amp_Id"].ToString()) == 1)
                                {

                                    valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                                }
                            }
                            foreach (DataRow dt2 in dtExtraprimaPrincipal.Rows)
                            {
                                if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                                {

                                    valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                    primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                    TasaDt = double.Parse(dt2["Tasa"].ToString());
                                }
                            }      
                        }
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                        {
                            

                            //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                            dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                            foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                            {
                                DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                row2.ItemArray = row.ItemArray;
                                dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                            }
                            // asigna este dt a la session 

                            //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                        }
                    }
                    else
                    {
                        int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                        dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), 0, ocupacion);
                        dtExtraprimaPrincipal = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()), int.Parse(txtEdadPrincipal.Text), 0, ocupacion);
                        dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                        foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                        {
                            DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                            row2.ItemArray = row.ItemArray;
                            dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                        }
                        // asigna este dt a la session 
                        //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();

                    }

                    double totales = 0;
                    foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                    {
                        totales += Convert.ToDouble(row.Cells[4].Text);
                    }

                    //txtPrimaPrincipal.Text = Convert.ToString(totales);

                    grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                    grvAmparoPrincipal.DataBind();

                    // Cargar tabla de amparos para ingresar la extraprima
                    grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
                    grvAmparoExtraPrima.DataBind();

                    // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial
                    DataSet dsConsultarHistirialPorcentajeExtraPrimado = new DataSet();
                    dsConsultarHistirialPorcentajeExtraPrimado = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1);

                    DataTable dtConsultarHistirialPorcentajeExtraPrimado = new DataTable();
                    foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimado.Tables)
                    {
                        dtConsultarHistirialPorcentajeExtraPrimado.Merge(dt);
                    }
                    grvConsultarHistirialPorcentajeExtraPrimado.DataSource = dtConsultarHistirialPorcentajeExtraPrimado;
                    grvConsultarHistirialPorcentajeExtraPrimado.DataBind();

                    //Consulta el historial del cliente pero general
                    DataTable dtConsultarHistorialExtraPrima = new DataTable();
                    dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
                    grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
                    grvHistorialExtraPrima.DataBind();

                    double consultarHistorialExtraPrima = 0;
                    double valorExtraPrima = 0;


                    //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                    if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
                    {
                        // Recorre el dt para consultar los valores de prima y extra prima
                        foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                        {
                            consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                            valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
                        }
                        
                    }
                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                    {
                        primaDt = primaDtGeneral - consultarHistorialExtraPrima;
                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                    {
                        //recorre tabla de extra prima para la suma de primas 
                        foreach (GridViewRow row in grvAmparoExtraPrima.Rows)
                        {
                            totalExtraPrimaP += Convert.ToDouble(row.Cells[4].Text);
                        }

                        if (totalExtraPrimaP != totalPrimaEdad && (totalPrimaEdad != 0))
                        {
                            totalExtraPrimaP = totalPrimaEdad - consultarHistorialExtraPrima;
                        }
                        // Asignar variables con valores a los campos de prima y extra prima 
                        totalExtraPrimaP3 = totalExtraPrimaP;
                        totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                        txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                        txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                        }
                        else
                        {
                             foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                             {
                                 if (ddlPlanPrincipal.SelectedItem.ToString() == dtConsultarHistorialExtraPrimaForeach["Valor Asegurado"].ToString())
                                  {
                                      txtPrincipalExtraprima.Text = valorExtraPrima.ToString();
                                      txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
                                      txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                  }
                                 else
                                 {
                                     txtPrincipalExtraprima.Text = "0";
                                     txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                 }
                             }
                        }  
                    }
                    else
                    {
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                totalExtraPrimaP3 = primaDt;
                                totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                                txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                            }
                            else
                            {
                                totalExtraPrimaP3 = primaDtGeneral;
                                txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                totalExtraPrimaP = totalExtraPrimaP3;
                            }
                           
                        }
                        else
                        {
                           
                            foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                            {
                                primaDt += Convert.ToDouble(row.Cells[4].Text);
                            }
                            totalExtraPrimaP3 = primaDt;
                            totalExtraPrimaP = totalExtraPrimaP3;
                            txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                            txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                            {
                                if (ddlPlanPrincipal.SelectedItem.ToString() == dtConsultarHistorialExtraPrimaForeach["Valor Asegurado"].ToString())
                                {
                                    txtPrincipalExtraprima.Text = valorExtraPrima.ToString();
                                    txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
                                    txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                }
                                else
                                {
                                    txtPrincipalExtraprima.Text = "0";
                                    txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                }
                            }
                        }
                    }

                    int primaPrincipal = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipal.Text)).ToString());
                    txtPrimaPrincipal.Text = primaPrincipal.ToString();
                    int PrimaPrincipalExtraprima = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprima.Text)).ToString());
                    txtPrimaPrincipalExtraprima.Text = PrimaPrincipalExtraprima.ToString();
                    if (txtExtraPrimaPrincipal.Text != "")
                    {
                        int ExtraPrimaPrincipal = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaPrincipal.Text)).ToString());
                        txtExtraPrimaPrincipal.Text = ExtraPrimaPrincipal.ToString();
                    }

                }
                else
                {
                    dtEliminarPrincipal.Clear();
                    grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                    grvAmparoPrincipal.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL VALOR DEL PLAN SUPERA EL ACEPTADO POR LA COMPAÑÍA PARA SUS LOS PRODUCTOS" + "');", true);
            }

            double totalPrimaOtroAsegurado = 0;
            sumarPrima(0);

            if (grvOtrosAsegurados.Rows.Count > 0)
            {
                foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                {
                    totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                }
                txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                sumarPrima(int.Parse(txtPrimaOtros.Text));
            }
            Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
            Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
            Session["TotalExtraPrimaP"] = totalExtraPrimaP;
            Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;
        }
        catch 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione UN PLAN" + "');", true);
        }
    }

    //metodo para buscar un tercero con su cedula desde conyuge "SEBASTIAN"
    protected void ConsultarTerceroCertificado(object sender, EventArgs e)
    {

        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyugeConsultaTercero"];
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        int cer_IdNuevo = 0;
        cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
        Session["cerId_ValorNuevo"] = cer_IdNuevo;

        int cer_IdAnterior = 0;
        DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
       if(dtCer_IdExtraPrima.Rows.Count > 0)
       {
           cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
       }

        string mensaje = objAdministrarCertificados.ConsultarTerceroCertificado(int.Parse(txtDocumentoConyugue.Text));

        if (mensaje == "ESTA CEDULA NO EXISTE")
        {
            limpiarConyuge_Click(sender, e);
        }
        txtNombreConyuge.Text = objAdministrarCertificados.objAseguradoBusqueda.Nombres;
        txtApellidoConyuge.Text = objAdministrarCertificados.objAseguradoBusqueda.Apellidos;
        txtCedulaConyuge.Text = objAdministrarCertificados.objAseguradoBusqueda.NumeroDocumento;
        txtEdadConyuge.Text = Funciones.Edad(objAdministrarCertificados.objAseguradoBusqueda.FechaNacimiento).ToString();

        if (ddlPoliza.Text != "" && txtCedulaConyuge.Text != "")
        {
            txtPlanConyuge.Enabled = true;
        }
        else
        {
            txtPlanConyuge.Enabled = false;
        }

        if(ddlPlanConyuge.SelectedValue != "")
        {
            amparosConyuge.Visible = true;
        }
        else
        {
            amparosConyuge.Visible = false;
        }

        if (ddlPlanPrincipal.SelectedValue != "")
        {
            amparosPrincipal.Visible = true;
        }
        else
        {
            amparosPrincipal.Visible = false;
        }

        if (txtCedulaConyuge.Text != "")
        {
            btnSiguienteConyuge.Enabled = false;
            ddlPlanConyuge.Enabled = true;
            grvAmparoConyuge.Visible = true;
            grvBeneficiarioConyuge.Visible = true;
            beneficiariosConyuge.Visible = true;
            btnExtraPrima2.Visible = true;
            btnLimpiar.Visible = true;
            txtPeso.Enabled = true;
            txtEstatura.Enabled = true;
            btnValidarConyuge.Visible = true;
            btnCertificadoModal.Enabled = false;

            DataTable dt = new DataTable();
            dt = objAdministrarCertificados.consultarPlanPorPoliza(int.Parse(ddlPoliza.SelectedValue.ToString()), 2, int.Parse(txtEdadConyuge.Text));
            ddlPlanConyuge.DataSource = dt;
            ddlPlanConyuge.DataValueField = "plapol_Id";
            ddlPlanConyuge.DataTextField = "plan_ValAsegurado";
            ddlPlanConyuge.DataBind();
            ddlPlanConyuge.Items.Insert(0, new ListItem("", ""));
            ddlPlanConyuge.Attributes.Add("onclick", "localStorage.setItem('accIndex', 2);");
            Session["plapol_IdConyuge"] = dt.Rows[0]["plapol_Id"].ToString();
            
            //// Crear Tabla de Beneficiarios
            //DataTable dtBeneficiarioConyuge = new DataTable();
            //dtBeneficiarioConyuge = new DataTable();
            //DataColumn column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "NumeroDocumento";
            //column.ColumnName = "NumeroDocumento";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "Apellidos";
            //column.ColumnName = "Apellidos";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "Nombres";
            //column.ColumnName = "Nombres";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "Edad";
            //column.ColumnName = "Edad";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "Porcentaje";
            //column.ColumnName = "Porcentaje";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.AllowDBNull = true;
            //column.Caption = "Parentesco";
            //column.ColumnName = "Parentesco";
            //dtBeneficiarioConyuge.Columns.Add(column);

            //lLENAR PRIMERA FILA DE LA TABLA BENEFIACIARIOS  
            DataTable dtBeneficiarioPruebaConyuge = new DataTable();
            dtBeneficiarioPruebaConyuge = objAdministrarCertificados.ConsultarBeneficiarioUnico();
            grvBeneficiarioConyuge.DataSource = dtBeneficiarioPruebaConyuge;
            grvBeneficiarioConyuge.DataBind();
            GridViewRow rowConyuge = grvBeneficiarioConyuge.Rows[0];
            rowConyuge.Visible = false;

            //grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
            //grvBeneficiarioConyuge.DataBind();
            //grvBeneficiarioConyuge.Enabled = true;
        }
        else
        {
            btnSiguienteConyuge.Enabled = true;
            ddlPlanConyuge.Enabled = false;
            grvAmparoConyuge.Visible = false;
            grvBeneficiarioConyuge.Visible = false;
            beneficiariosConyuge.Visible = false;
            btnExtraPrima2.Visible = false;
            btnLimpiar.Visible = false;
            txtPeso.Enabled = false;
            txtEstatura.Enabled = false;
            btnValidarConyuge.Visible = false;
        }

        int cer_Id = int.Parse(Session["cer_id"].ToString());

        if ((string)Session["operacionCertificado"] == "modificar")
        {
            dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacionBusqueda(cer_IdAnterior, 2, double.Parse(txtCedulaConyuge.Text));///////////////////////////////////////////////////////////////////////////////////
            grvAmparoConyuge.DataSource = dtEliminarConyuge;
            grvAmparoConyuge.DataBind();

            double ValorCampoPrimaTxtConyugeTercero = 0;

            foreach (DataRow dtValorCampoPrimaTxtConyuge in dtEliminarConyuge.Rows)
            {
                if (dtValorCampoPrimaTxtConyuge["Amparo"].ToString() == "VIDA")
                {
                    ValorCampoPrimaTxtConyugeTercero = double.Parse(dtValorCampoPrimaTxtConyuge["Valor Asegurado"].ToString());
                    txtPlanConyuge.Text = ValorCampoPrimaTxtConyugeTercero.ToString();
                    //ddlPlanConyuge.SelectedItem.Text = ValorCampoPrimaTxtConyuge.ToString();
                    ddlPlanConyuge.SelectedIndex = ddlPlanConyuge.Items.IndexOf(ddlPlanConyuge.Items.FindByText(ValorCampoPrimaTxtConyugeTercero.ToString()));

                }
            }

            if ( dtBeneficiarioConyuge.Rows.Count > 0 )
            {
                dtBeneficiarioConyuge = objAdministrarCertificados.ConsultarBeneficiarioModificacion(cer_IdAnterior, int.Parse(txtCedulaConyuge.Text), 2);
                grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                grvBeneficiarioConyuge.DataBind();

                if (dtBeneficiarioConyuge.Rows.Count == 0)
                {
                    DataTable dtBeneficiarioVacio = dtBeneficiarioConyuge.Clone();
                    DataRow drBeneficiarioVacio = dtBeneficiarioVacio.NewRow();
                    dtBeneficiarioVacio.Rows.Add(drBeneficiarioVacio);
                    grvBeneficiarioConyuge.DataSource = dtBeneficiarioVacio;
                    grvBeneficiarioConyuge.DataBind();
                    grvBeneficiarioConyuge.Rows[0].Visible = false;
                    grvBeneficiarioConyuge.Rows[0].Controls.Clear();
                }

                if (ddlPlanConyuge.SelectedValue != "")
                {
                    dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_IdAnterior, 2);
                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();

                    double ValorCampoPrimaTxtConyuge = 0;

                    foreach (DataRow dtValorCampoPrimaTxtConyuge in dtEliminarConyuge.Rows)
                    {
                        if (dtValorCampoPrimaTxtConyuge["Amparo"].ToString() == "VIDA")
                        {
                            ValorCampoPrimaTxtConyuge = double.Parse(dtValorCampoPrimaTxtConyuge["Valor Asegurado"].ToString());
                            txtPlanConyuge.Text = ValorCampoPrimaTxtConyuge.ToString();
                            ddlPlanConyuge.SelectedItem.Text = ValorCampoPrimaTxtConyuge.ToString();////////////////////////////////////////
                        }
                    }
                    ReestructurarExtraPrimaConyuge();
                   // ConsultarPrimaConyuge2();

                }

                if (txtPlanConyuge.Text != "")
                {
                    dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(cer_IdAnterior, 2);
                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();

                    double ValorCampoPrimaTxtConyuge = 0;

                    foreach (DataRow dtValorCampoPrimaTxtConyuge in dtEliminarConyuge.Rows)
                    {
                        if (dtValorCampoPrimaTxtConyuge["Amparo"].ToString() == "VIDA")
                        {
                            ValorCampoPrimaTxtConyuge = double.Parse(dtValorCampoPrimaTxtConyuge["Valor Asegurado"].ToString());
                            txtPlanConyuge.Text = ValorCampoPrimaTxtConyuge.ToString();
                            ddlPlanConyuge.SelectedItem.Text = ValorCampoPrimaTxtConyuge.ToString();
                        }
                    }
                    ReestructurarExtraPrimaConyuge();
                    //ConsultarPrimaConyuge2();
                }
            }
            // Para que se vea la tabla de beneficiario en modificacion sin registros
            else 
            {
                DataTable dtBeneficiarioVacio = dtBeneficiarioConyuge.Clone();
                DataRow drBeneficiarioVacio = dtBeneficiarioVacio.NewRow();
                dtBeneficiarioVacio.Rows.Add(drBeneficiarioVacio);
                grvBeneficiarioConyuge.DataSource = dtBeneficiarioVacio;
                grvBeneficiarioConyuge.DataBind();
                grvBeneficiarioConyuge.Rows[0].Visible = false;
                grvBeneficiarioConyuge.Rows[0].Controls.Clear();

            }
            Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;
        }
        if (mensaje == "ESTA CEDULA NO EXISTE")
        {
            txtNombreConyuge.Text = "";
            txtApellidoConyuge.Text = "";
            txtCedulaConyuge.Text = "";
            txtEdadConyuge.Text = "";
        }
        btnValidarConyuge.Enabled = true;
        btnCertificadoModal.Enabled = true;
        Session["dtEliminarConyuge"] = dtEliminarConyuge;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + mensaje + "');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + mensaje + "');", true);
    }

    //metodo para buscar un tercero con su cedula desde otros Asegurados "SEBASTIAN"
    protected void ConsultarTerceroCertificadoOtroAsegurado(object sender, EventArgs e)
    {
        string mensaje;
        DataTable dtTerceroOtroAsegurado = new DataTable();
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        dtTerceroOtroAsegurado = objdministrarCertificado.ConsultarTerceroCertificado(double.Parse(txtDocumentoOtros.Text));
        if (dtTerceroOtroAsegurado.Rows.Count > 0)
        {
            btnAdicionarOtrosAsegurados.Enabled = false;
            grvOtrosAsegurados.Visible = false;
            grvAmparoOtro.Visible = false;
            
             //objAdministrarCertificados.ConsultarTerceroCertificado(double.Parse(txtDocumentoOtros.Text));
            txtNombreOtro.Text = dtTerceroOtroAsegurado.Rows[0]["ter_Nombres"].ToString();
            txtApellidoOtro.Text = dtTerceroOtroAsegurado.Rows[0]["ter_Apellidos"].ToString();
            txtCedulaOtro.Text = dtTerceroOtroAsegurado.Rows[0]["ter_Id"].ToString();
            txtEdadOtro.Text = Funciones.Edad(DateTime.Parse(dtTerceroOtroAsegurado.Rows[0]["ter_FechaNacimiento"].ToString())).ToString();
            txtFechaNacimiento.Text = DateTime.Parse(dtTerceroOtroAsegurado.Rows[0]["ter_FechaNacimiento"].ToString()).ToString("yyyy-MM-dd");



            if (txtCedulaOtro.Text != "" && ddlPoliza.Text != "")
            {
                ddlParentesoOtro.Enabled = true;
            }
            else
            {
                ddlParentesoOtro.Enabled = false;
            }

            if (ddlPoliza.Text != "" && txtCedulaOtro.Text != "" && ddlParentesoOtro.Text != "")
            {
                ddlPlanOtros.Enabled = true;
            }
            else
            {
                ddlPlanOtros.Enabled = false;
            }

            mensaje = "REGISTRO ENCONTRADO EXITOSAMENTE";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + mensaje + "');", true);
        }
        else
        {
            mensaje = "ESTA CEDULA NO EXISTE";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + mensaje + "');", true);
        }
    }

    protected void ConsultarAmparosPlanConyuge(object sender, EventArgs e)
    {
        try
        {
            DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
           //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtExtraprimaConyugeRestaurar = new DataTable();
            DataTable dtPlanTieneTasa = new DataTable();
            Session["totalPrimaGeneralEliminarConyuge"] = 0;
            Session["totalValorPrimaEliminarConyuge"] = 0;
            double totalExtraPrimaC = 0;
            DataTable dtCumuloValorConyuge = new DataTable();
            double valorAsegurado = 0;
            double totalPrimaEdadConyuge = 0;
            double diferenciaValorAsegurado = 0;
            double totalExtraPrimaC3 = 0;
            double primaDt = 0;
            double primaDtGeneral = 0;

            int valorAseguradoConyuge = 0;

            if (txtPlanConyuge.Text != "")
            {
                valorAseguradoConyuge = int.Parse(txtPlanConyuge.Text);
            }

            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
            Session["cerId_ValorNuevo"] = cer_IdNuevo;

            int cer_IdAnterior = 0;
            DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
            if (dtCer_IdExtraPrima.Rows.Count > 0)
            {
                cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
            }


            //dtCumuloValorConyuge = AdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()));
            dtCumuloValorConyuge = objAdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));
            //valorAsegurado = AdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()), int.Parse(txtCedulaConyuge.Text));
            valorAsegurado = objAdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()), int.Parse(txtCedulaConyuge.Text));
            valorAsegurado = valorAsegurado - double.Parse(Session["valorAseguradoPrincipalResta"].ToString());

            if ((valorAsegurado + double.Parse(ddlPlanConyuge.SelectedItem.ToString())) <= double.Parse(dtCumuloValorConyuge.Rows[0]["cum_Nombre"].ToString()))
            {
                if (ddlPlanConyuge.SelectedItem.ToString() != "")
                {
                    try
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                    }
                    catch
                    {
                        dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                    }
                    if ((string)Session["operacionCertificado"] == "modificar" && dtCer_IdExtraPrima.Rows[0]["idConyuge"].ToString() != "")
                    {
                        int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                        dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                        totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);
                        //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                        dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                        //grvAmparoConyuge.DataSource = dtEliminarConyuge;
                        //grvAmparoConyuge.DataBind(); 

                        DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                        dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                        double valorAseguradoExtraPrima = 0;
                        double valorAseguradoDt = 0;
                        double TasaDt = 0;

                          if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                //Recorrer el dt con el que se lleno la tabla extra prima
                                foreach (DataRow dt in dtExtraprimaConyuge.Rows)
                                {
                                    //recorrer el dt con los valores del certificado anterior 
                                    foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                                    {
                                        //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
                                        if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                                        {
                                            //asigna el valor asegurado del primer dt a esta variable 
                                            valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                            //asignala tasa del primer dt a esta variable
                                            TasaDt = double.Parse(dt["Tasa"].ToString());
                                            //Asigna esta varible al valor asegurado del segundo dt
                                            valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                            //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                            diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                            //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                            {
                                                // asigna un valor a una session
                                                if (diferenciaValorAsegurado != 0)
                                                {
                                                    Session["diferenciaValorAseguradoC"] = diferenciaValorAsegurado;
                                                }
                                                else
                                                {
                                                    Session["diferenciaValorAseguradoC"] = 0;
                                                }
                                            }
                                            // asigna una variable a un campo del primer dt
                                            dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                            //realiza una operacion para saber el valor de la prima
                                            primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                            //asigna la vartiable de prima a un campo del dt
                                            dt["Prima"] = primaDt;
                                        }
                                    }
                                    //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                                    dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                                    foreach (DataRow row in dtExtraprimaConyuge.Rows)
                                    {
                                        DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                                        row2.ItemArray = row.ItemArray;
                                        dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                                    }
                                    // asigna este dt a la session 
                                    //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                                }
                            }
                          if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                          {
                              foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                              {
                                  if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                  {

                                      valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                                  }
                              }
                              foreach (DataRow dt2 in dtExtraprimaConyuge.Rows)
                              {
                                  if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                                  {

                                      valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                      primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                      TasaDt = double.Parse(dt2["Tasa"].ToString());
                                  }
                              }
                          }
                          if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                          {
                            
                              //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                              dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                              foreach (DataRow row in dtExtraprimaConyuge.Rows)
                              {
                                  DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                                  row2.ItemArray = row.ItemArray;
                                  dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                              }
                              // asigna este dt a la session 

                              //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                          }
                    }
                    else
                    {

                        int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                        dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), 0, ocupacion);
                        //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                        dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), 0, ocupacion);
                        dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                        foreach (DataRow row in dtExtraprimaConyuge.Rows)
                        {
                            DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                            row2.ItemArray = row.ItemArray;
                            dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                        }
                      
                        //// asigna este dt a la session 
                        //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                        grvAmparoConyuge.DataSource = dtEliminarConyuge;
                        grvAmparoConyuge.DataBind();
                    }
                   
                    double totales = 0;
                    foreach (GridViewRow row in grvAmparoConyuge.Rows)
                    {
                        totales += Convert.ToDouble(row.Cells[4].Text);
                    }
                    //txtPrimaConyuge.Text = Convert.ToString(totales);

                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();
                    // Extra Prima
                    grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
                    grvExtraPrimaConyuge.DataBind();

                    // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial

                    DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
                    dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                    DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
                    foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
                    {
                        dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt);
                    }
                    grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
                    grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();

                    //Consulta el historial del cliente pero general
                    DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                    dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
                    grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
                    grvHistorialExtraPrimaConyuge.DataBind();


                    double consultarHistorialExtraPrimaConyuge = 0;
                    double valorExtraPrimaConyuge = 0;

                    //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                    if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                    {
                        // Recorre el dt para consultar los valores de prima y extra prima
                        foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                        {
                            consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                            valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
                        }
                      
                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                    {
                        primaDt = primaDtGeneral - consultarHistorialExtraPrimaConyuge;
                    }

                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                    {
                        //recorre tabla de extra prima para la suma de primas 
                        foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
                        {
                            totalExtraPrimaC += Convert.ToDouble(row.Cells[4].Text);
                        }

                        if (totalExtraPrimaC != totalPrimaEdadConyuge && (totalPrimaEdadConyuge != 0))
                        {
                            totalExtraPrimaC = totalPrimaEdadConyuge - consultarHistorialExtraPrimaConyuge;
                        }
                        // Asignar variables con valores a los campos de prima y extra prima 
                        totalExtraPrimaC3 = totalExtraPrimaC;
                        totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (txtPrincipalExtraprimaConyuge.Text == "")
                            {
                                txtPrincipalExtraprimaConyuge.Text = "0";
                            }
                            txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                            txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                        }
                        else
                        {
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                            {
                                if (ddlPlanConyuge.SelectedIndex.ToString() == dtConsultarHistorialExtraPrimaForeachConyuge["Valor Asegurado"].ToString())
                                {
                                    txtPrincipalExtraprimaConyuge.Text = valorExtraPrimaConyuge.ToString();
                                    txtPrincipalExtraprimaConyuge.Text = Math.Round(double.Parse(txtPrincipalExtraprimaConyuge.Text)).ToString();
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                    txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                                }
                                else
                                {
                                    txtPrincipalExtraprimaConyuge.Text = "0";
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                }
                            }
                        }  
                    }
                    else
                    {
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                totalExtraPrimaC3 = primaDt;
                                totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                            }
                            else
                            {
                                totalExtraPrimaC3 = primaDtGeneral;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                totalExtraPrimaC = totalExtraPrimaC3;
                            }
                        }
                        else
                        {
                            foreach (GridViewRow row in grvAmparoConyuge.Rows)
                            {
                                primaDt += Convert.ToDouble(row.Cells[4].Text);
                            }
                            totalExtraPrimaC3 = primaDt;
                            totalExtraPrimaC = totalExtraPrimaC3;
                            txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                            txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                            {
                                if (ddlPlanConyuge.SelectedIndex.ToString() == dtConsultarHistorialExtraPrimaForeachConyuge["Valor Asegurado"].ToString())
                                {
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                    txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                                }
                                else
                                {
                                    txtPrincipalExtraprimaConyuge.Text = "0";
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                }
                            }
                        }
                    }

                    int PrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
                    txtPrimaConyuge.Text = PrimaConyuge.ToString();
                    int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
                    txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
                    if (txtExtraPrimaConyuge.Text != "")
                    {
                        int ExtraPrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());
                        txtExtraPrimaConyuge.Text = ExtraPrimaConyuge.ToString();
                    }
                }
                else
                {
                    dtEliminarConyuge.Clear();
                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL VALOR DEL PLAN SUPERA EL ACEPTADO POR LA COMPAÑÍA PARA SUS LOS PRODUCTOS" + "');", true);
            }

            sumarPrima(0);


            if (grvOtrosAsegurados.Rows.Count > 0)
            {
                double totalPrimaOtroAsegurado = 0;
                foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                {
                    totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                }
                txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                sumarPrima(int.Parse(txtPrimaOtros.Text));
            }
            Session["dtEliminarConyuge"] = dtEliminarConyuge;
            Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
            Session["TotalExtraPrimaC"] = totalExtraPrimaC;
            Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione UN PLAN" + "');", true);
        }
        
    }

    //sebastian
    protected void consultarPolizaPorProducto(object sender, EventArgs e)
    {
        DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
        DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlLocalidadCertificado.SelectedItem.ToString() != "")
        {
            if(dtCertificadoFull.Rows.Count > 0)
            {
                ddlPoliza.DataSource = objAdministrarCertificados.spConsultarPolizaPorProudcto(int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), int.Parse(dtCertificadoFull.Rows[0]["pro_Id"].ToString()));
            }
            else
            {
                ddlPoliza.DataSource = objAdministrarCertificados.spConsultarPolizaPorProudcto(int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), int.Parse(Session["pro_Id"].ToString()));
            }
               
                ddlPoliza.DataValueField = "pol_Id";
                ddlPoliza.DataTextField = "pol_numero";
                ddlPoliza.DataBind();
                ddlPoliza.Items.Insert(0, new ListItem("", ""));
                ddlPoliza.Attributes.Add("onclick", "localStorage.setItem('accIndex', 0);");
           
            if (ddlLocalidadCertificado.Text == "")
            {
                ddlPoliza.Enabled = false;
            }
            else
            {
                ddlPoliza.Enabled = true;
            }
            if (ddlPoliza.Text != "")
            {
                txtDocumentoConyugue.Enabled = true;
                txtDocumentoOtros.Enabled = true;
            }
            else
            {
                txtDocumentoConyugue.Enabled = false;
                txtDocumentoOtros.Enabled = false;
            }
        }

        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        amparosConyuge.Visible = false;
        dtEliminarConyuge.Clear();
        grvAmparoConyuge.DataSource = dtEliminarConyuge;
        Session["dtEliminarConyuge"] = dtEliminarConyuge;
        grvAmparoConyuge.DataBind();

        DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
        amparosPrincipal.Visible = false;
        dtEliminarPrincipal.Clear();
        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
        Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
        grvAmparoPrincipal.DataBind();

            //int departamento = int.Parse(AdministrarCertificados.consultarDepartamentoPorCiudad(txtAgencia.Text).Rows[0]["dep_Id"].ToString());
        int pagaduria = int.Parse(objAdministrarCertificados.consultarConvenioPorPagaduria(double.Parse(Session["cerIdPagaduria"].ToString())).Rows[0]["paga_Id"].ToString());
        try
        {
            DataTable dt = new DataTable();
            dt = objAdministrarCertificados.consultarConvenios(int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), pagaduria);
            ddlConvenioPrincipal.DataTextField = "con_Nombre";
            ddlConvenioPrincipal.DataValueField = "con_Id";
            ddlConvenioPrincipal.DataSource = dt;
            ddlConvenioPrincipal.DataBind();
            ddlConvenioPrincipal.Items.Insert(0, new ListItem("", ""));
            if ((string)Session["operacionCertificado"] == "modificar")
                ddlConvenioPrincipal.SelectedIndex = ddlConvenioPrincipal.Items.IndexOf(ddlConvenioPrincipal.Items.FindByText(dtCertificadoFull.Rows[0]["con_Nombre"].ToString())); //jc
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione UNA LOCALIDAD" + "');", true);

        }
    }

    protected void consultarPlaPorParentesco(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlPoliza.SelectedItem.ToString() != "" && ddlParentesoOtro.SelectedItem.ToString() != "")
        {
            DataTable planotrosAsegurados = objAdministrarCertificados.consultarPlanPorPoliza(int.Parse(ddlPoliza.SelectedValue.ToString()), int.Parse(ddlParentesoOtro.SelectedValue.ToString()), int.Parse(txtEdadOtro.Text));
            ddlPlanOtros.DataSource = planotrosAsegurados;
            ddlPlanOtros.DataValueField = "plapol_Id";
            ddlPlanOtros.DataTextField = "plan_ValAsegurado";
            ddlPlanOtros.DataBind();
            ddlPoliza.Items.Insert(0, new ListItem("", ""));
            ddlPoliza.Attributes.Add("onclick", "localStorage.setItem('accIndex', 3);");

            if (ddlPoliza.Text != "" && txtCedulaOtro.Text != "" && ddlParentesoOtro.Text != "")
            {
                ddlPlanOtros.Enabled = true;
            }
            else
            {
                ddlPlanOtros.Enabled = false;
            }
        }
    }

    protected void consultarPlanPorPoliza(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlPoliza.SelectedItem.ToString() != "")
        {
            DataTable dt = new DataTable();
            if ((string)Session["operacionCertificado"] == "modificar")
            {
                DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
                DataTable permaneciaAsegurado = new DataTable();
                int permaneciaAseguradoCertificado = 0;

                permaneciaAsegurado = objAdministrarCertificados.ConsultarFechaExpedicionCertificadoAnterior(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
                permaneciaAseguradoCertificado = Funciones.FechaIngresoAsegurado(DateTime.Parse(permaneciaAsegurado.Rows[0]["cer_FechaExpedicion"].ToString()), DateTime.Parse(dtCertificadoFull.Rows[0]["ter_FechaNacimiento"].ToString()));

                dt = objAdministrarCertificados.consultarPlanPorPolizaPermanencia(int.Parse(ddlPoliza.SelectedValue.ToString()), 1, permaneciaAseguradoCertificado);

            }
            else
            {
                dt = objAdministrarCertificados.consultarPlanPorPoliza(int.Parse(ddlPoliza.SelectedValue.ToString()), 1, int.Parse(txtEdadPrincipal.Text));
                Session["idPlapolId"] = dt.Rows[0]["plapol_Id"].ToString();
            }
            ddlPlanPrincipal.DataSource = dt;
            ddlPlanPrincipal.DataValueField = "plapol_Id";
            ddlPlanPrincipal.DataTextField = "plan_ValAsegurado";
            ddlPlanPrincipal.DataBind();
            ddlPlanPrincipal.Items.Insert(0, new ListItem("", ""));
            ddlPlanPrincipal.Attributes.Add("onclick", "localStorage.setItem('accIndex', 1);");

            if (dt.Rows.Count > 0)
            {
                Session["plapol_Id"] = dt.Rows[0]["plapol_Id"].ToString();
                if (txtCedulaOtro.Text != "" && ddlPoliza.Text != "")
                {
                    ddlParentesoOtro.Enabled = true;
                }
                else
                {
                    ddlParentesoOtro.Enabled = false;
                }

                if (ddlPoliza.Text != "")
                {
                    txtPlanPrincipal.Enabled = true;
                    txtDocumentoOtros.Enabled = true;
                }
                else
                {
                    txtPlanPrincipal.Enabled = false;
                    txtDocumentoOtros.Enabled = false;
                }

                if (ddlPoliza.Text == "")
                {
                    ddlPlanPrincipal.Enabled = false;
                }
                else
                {
                    ddlPlanPrincipal.Enabled = true;
                }

                if (ddlPoliza.Text != "" && txtCedulaConyuge.Text != "")
                {
                    ddlPlanConyuge.Enabled = true;
                }
                else
                {
                    ddlPlanConyuge.Enabled = false;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTA PERSONA NO CUMPLE LOS REQUISITOS PARA SER ASEGURADA " + "');", true);
            }
        }
    }

    protected void sumarPrima(double totales)
    {
        double total = totales;
        int primaOtroAsegurado = (int)Session["primaOtroAsegurado"];
        if (txtPrimaPrincipal.Text == "")
        {
            txtPrimaPrincipal.Text = "0";
        }

        if (txtPrimaConyuge.Text == "")
        {
            txtPrimaConyuge.Text = "0";
        }

        if (txtPrimaOtros.Text == "")
        {
            txtPrimaOtros.Text = "0";
        }
        if (txtExtraPrimaPrincipal.Text == "")
        {
            txtExtraPrimaPrincipal.Text = "0";
        }
        if (txtExtraPrimaConyuge.Text == "")
        {
            txtExtraPrimaConyuge.Text = "0";
        }
        //double primaPrincipal = double.Parse(Math.Round(decimal.Parse(txtPrimaPrincipal.Text)).ToString());
        //double primaConyuge = double.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
        //double primaPrincipalExtra = double.Parse(Math.Round(decimal.Parse(txtExtraPrimaPrincipal.Text)).ToString());
        //double primaConyugeExtra = double.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());

        double primaPrincipal = double.Parse(decimal.Parse(txtPrimaPrincipal.Text).ToString());
        double primaConyuge = double.Parse(decimal.Parse(txtPrimaConyuge.Text).ToString());
        double primaPrincipalExtra = double.Parse(decimal.Parse(txtExtraPrimaPrincipal.Text).ToString());
        double primaConyugeExtra = double.Parse(decimal.Parse(txtExtraPrimaConyuge.Text).ToString());
        //primaOtroAsegurado += total;
        double primaTotal = primaPrincipal + primaConyuge + primaPrincipalExtra + primaConyugeExtra + total;
        txtPrima.Text = primaTotal.ToString();


        Session["primaOtroAsegurado"] = primaOtroAsegurado;
    }

    protected  double CalcularValorNovedadCertificado( double primaCertificado, int periodicidad)
    {
        double valorTotal = 0;
        double valor = 0;
        if (periodicidad == 10)
        {
           valor = primaCertificado * 12;
            valorTotal =valor/ 10;
        }
        if (periodicidad == 14)
        {
            valor = primaCertificado * 12;
            valorTotal = valor / 26;
        }
        if (periodicidad != 14 && periodicidad != 10)
        {
           valorTotal = primaCertificado;
        }
        return valorTotal;
    }

    protected DataTable CalcularMesYAnio()
    {
        int mesNovedad = 0;
        int anioNovedad = 0;

        DataTable dtNovedades = (DataTable)Session["dtNovedades"];

        mesNovedad = int.Parse(dtNovedades.Rows[0]["mes"].ToString()) + 1;
        anioNovedad = int.Parse(dtNovedades.Rows[0]["anio"].ToString());

        if (mesNovedad == 13)
        {
           anioNovedad = anioNovedad + 1;
           mesNovedad = 1;
        }

        DataTable dtArchivo = (DataTable)Session["dtArchivo"];
      
        DataTable dtMesYAnioNovedades = new DataTable();
        dtMesYAnioNovedades = AdministrarNovedades.ConsultarMesYAnioNovedad(mesNovedad, anioNovedad, int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()));

        if(dtMesYAnioNovedades.Rows.Count > 0)
        {
           if(dtMesYAnioNovedades.Rows[0]["enviada"].ToString() == "1")
           {
               mesNovedad = mesNovedad + 1;
               if (mesNovedad == 13)
               {
                 anioNovedad = anioNovedad + 1;
                 mesNovedad = 1;
               }
            }
        }

        DataTable dtMesYAnio = new DataTable();

        DataColumn columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "mes";
        dtMesYAnio.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "anio";
        dtMesYAnio.Columns.Add(columns);

        DataRow fecha = dtMesYAnio.NewRow();

        fecha["mes"] = mesNovedad;
        fecha["anio"] = anioNovedad;
        dtMesYAnio.Rows.Add(fecha);

        return dtMesYAnio;
    }

    protected void ActualizarCertificadoPreCargado()
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        int cer_IdNuevo = 0;
        cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));

        int hojaServicio1 = 0;
        int hojaServicio2 = 0;
        int hojaServicio3 = 0;
        int anexoConversion = 0;

        if (txtHServicio1.Text != "")
        {
            hojaServicio1 = int.Parse(txtHServicio1.Text);
        }
        if (txtHServicio2.Text != "")
        {
            hojaServicio2 = int.Parse(txtHServicio2.Text);
        }
        if (txtHServicio3.Text != "")
        {
            hojaServicio3 = int.Parse(txtHServicio3.Text);
        }
        if (txtAnexoConversion.Text != "")
        {
            anexoConversion = int.Parse(txtAnexoConversion.Text);
        }

        objAdministrarCertificados.ActualizarNewCertificadoPreCargado(cer_IdNuevo, hojaServicio1, hojaServicio2, hojaServicio3, anexoConversion);
    }

    protected void CalcularNovedades(DataTable dtPeriodicidad, DataTable dtArchivoPagaduria)
    {
        try
        {
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtArchivo = (DataTable)Session["dtArchivo"];
            DataTable dtNovedades = (DataTable)Session["dtNovedades"];
            //////////////////////////////Inicia operaciones para novedades///////////////////////////////////////////// 
            DataTable dtNovedadActual = new DataTable();
            dtNovedadActual = objAdministrarCertificados.ConsultarNovedadActual(int.Parse(dtNovedades.Rows[0]["tercero"].ToString()), int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()), 0);

            if (dtNovedadActual.Rows.Count > 0)
            {
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                {
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R")
                    {
                        dtNovedadActual.Clear();
                    }
                }
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                {
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() != "R")
                    {
                        dtNovedadActual.Rows.RemoveAt(0);
                    }
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() == "R")
                    {
                        dtNovedadActual.Clear();
                    }
                }
            }
            int cedula = 0;
            string tipoNovedad = "";
            string tipoNovedad2 = "";
            double valor2 = 0;
            double valor = 0;
            int estado = 0;
            int pagaduria = 0;
            int convenio = 0;
            int archivo = 0;
            int enviada = 0;
            double novedadAnterior = 0;

            cedula = int.Parse(dtNovedades.Rows[0]["tercero"].ToString());
            convenio = int.Parse(dtNovedades.Rows[0]["convenio"].ToString());
            pagaduria = int.Parse(objAdministrarCertificados.consultarConvenioPorPagaduria(double.Parse(Session["cerIdPagaduria"].ToString())).Rows[0]["paga_Id"].ToString());
            archivo = int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString());
            estado = 1;
            enviada = 0;

            /////////////////////////////// Variables para calcular el valor que se debe enviar a la novedad ///////////////
            double primaCertificado = 0;
            primaCertificado = int.Parse(dtNovedades.Rows[0]["prima"].ToString());

            int periodicidad = 0;
            periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

            double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);
            ///////////////////////////////FINALIZA Variables para calcular el valor que se debe enviar a la novedad ///////////////

            if (dtNovedadActual.Rows.Count == 0)
            {
                tipoNovedad = "I";
                ///////////////////////Cuando esta persona no tiene novedad anterior /////////////////////
                if (tipoNovedad == "I")
                {
                    tipoNovedad = "I";

                    valor = valorTotal;
                }
                /////////////////////  FINALIZA Cuando esta persona no tiene novedad anterior/////////////////////////
            }
            else
            {
                
                DataTable dtProducto = new DataTable();
                dtProducto = objAdministrarCertificados.ConsultarProductoParaNovedad(double.Parse(dtNovedades.Rows[0]["tercero"].ToString()), int.Parse(dtNovedades.Rows[0]["producto"].ToString()));
                if (int.Parse(dtProducto.Rows.Count.ToString()) == 0)
                {
                    novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString());
                    //valorTotal = valorTotal + novedadAnterior;
                    //////////////////////// cuando es ingreso, modificacion y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////

                        //////////////////////// cuando la novedad actual ya esta enviada ////////////////////////////////

                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "M";

                            //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
                            {
                                valor = valorTotal;
                            }
                            ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

                            ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
                            {
                                
                                valor = valorTotal;
                            }
                            /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
                        }
                        ////////////////////////FINALIZA cuando la novedad actual ya esta enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////

                    //////////////////////// cuando es ingreso y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "I";
                            valor = valorTotal + novedadAnterior;

                            tipoNovedad2 = "R";
                            valor2 = 0;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso y retiro ////////////////////////////////
                }
                else
                {
                    novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString()) - int.Parse(dtProducto.Rows[0]["Prima"].ToString());
                    //valorTotal = valorTotal + novedadAnterior;
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////

                        //////////////////////// cuando la novedad actual ya esta enviada ////////////////////////////////

                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "M";

                            //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
                            {
                                valor = valorTotal;
                            }
                            ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

                            ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
                            {
                                valor = valorTotal - novedadAnterior;
                            }
                            /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
                        }
                        ////////////////////////FINALIZA cuando la novedad actual ya esta enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////

                    //////////////////////// cuando es ingreso y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "I";
                            valor = valorTotal + novedadAnterior;

                            tipoNovedad2 = "R";
                            valor2 = 0;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                    }
                }
            }
            //////////////////////////////Finaliza operaciones para novedades/////////////////////////////////////////////
            DataTable dtMesYAnio = CalcularMesYAnio();

            if (dtNovedadActual.Rows.Count > 0)
            {
                if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0" || (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1" && dtNovedadActual.Rows[0]["Estado"].ToString() == "1"))
                {
                    AdministrarNovedades.ActualizarNovedades(int.Parse(dtNovedadActual.Rows[0]["nov_Id"].ToString()), dtNovedadActual.Rows[0]["TipoNovedad"].ToString(), int.Parse(valor.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                }
                else
                {
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1" && dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                    {
                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));

                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad2, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor2.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                    }
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                    }
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "2")
                    {

                    }
                }
            }
            else
            {
                AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "SURGIO UN ERROR AL CALCULAR LA NOVEDAD" + "');", true);
        }
    }

    protected void CalcularNovedadesRetiroRetiro(DataTable dtPeriodicidad, DataTable dtArchivoPagaduria)
    {
        try
        {


            //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificadoAntiguo"];
            DataTable dtArchivo = (DataTable)Session["dtArchivoAntiguo"];
            DataTable dtNovedades = (DataTable)Session["dtEncabezadoCertificadoAntiguo"];
            //////////////////////////////Inicia operaciones para novedades///////////////////////////////////////////// 
            DataTable dtNovedadActual = new DataTable();
            dtNovedadActual = objAdministrarCertificados.ConsultarNovedadActual(int.Parse(dtNovedades.Rows[0]["ter_Id"].ToString()), int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()), 1);

            int cedula = 0;
            string tipoNovedad = "";
            string tipoNovedad2 = "";
            double valor2 = 0;
            double valor = 0;
            int estado = 0;
            int pagaduria = 0;
            int convenio = 0;
            int archivo = 0;
            int enviada = 0;
            double novedadAnterior = 0;

            cedula = int.Parse(dtNovedades.Rows[0]["ter_Id"].ToString());
            convenio = int.Parse(dtNovedades.Rows[0]["con_Id"].ToString());
            pagaduria = int.Parse(dtNovedades.Rows[0]["paga_Id"].ToString());
            archivo = int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString());
            estado = 1;
            enviada = 0;

            /////////////////////////////// Variables para calcular el valor que se debe enviar a la novedad ///////////////
            double primaCertificado = 0;
            primaCertificado = int.Parse(dtNovedades.Rows[0]["cer_PrimaTotal"].ToString());

            int periodicidad = 0;
            periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

            double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);
            ///////////////////////////////FINALIZA Variables para calcular el valor que se debe enviar a la novedad ///////////////

            //valor = novedadAnterior - valorTotal;
            novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString());
            if (novedadAnterior - valorTotal <= 0)
            {
                tipoNovedad = "R";
            }
            else
            {
                tipoNovedad = "M";
            }

            //////////////////////// cuando es ingreso, modificacion y retiro ////////////////////////////////

            if (tipoNovedad == "M")
            {
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                {

                    //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
                    {
                        valor = novedadAnterior - valorTotal;
                    }
                    ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

                    ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
                    {
                        valor = -valorTotal;
                    }
                    /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
                }
                ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////
                //////////////////////// cuando es ingreso y retiro ////////////////////////////////
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                {


                    tipoNovedad = "I";
                    valor = novedadAnterior - valorTotal;

                    tipoNovedad2 = "R";
                    valor2 = novedadAnterior;

                }
                ////////////////////////FINALIZA cuando es ingreso y retiro ////////////////////////////////
            }
            if (tipoNovedad == "R")
            {
                if (dtArchivoPagaduria.Rows[0]["arcpag_Retiros"].ToString() == "0")
                {
                    valor = 0;
                }
                if (dtArchivoPagaduria.Rows[0]["arcpag_Retiros"].ToString() == "1")
                {
                    valor = valorTotal;
                }
            }
            //////////////////////////////Finaliza operaciones para novedades/////////////////////////////////////////////
            DataTable dtMesYAnio = CalcularMesYAnio();


            if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0" || (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1" && dtNovedadActual.Rows[0]["Estado"].ToString() == "1"))
            {
                AdministrarNovedades.ActualizarNovedades(int.Parse(dtNovedadActual.Rows[0]["nov_Id"].ToString()), tipoNovedad, int.Parse(valor.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
            }
            else
            {
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1" && dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                {
                    AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));

                    AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad2, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor2.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                }
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                {
                    AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                }
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "OCURRIO UN ERROR AL REALIZAR UN CAMBIO DE PAGADIRA EN NOVEDADES, VALIDE QUE YA POSEE UNA NOVEDAD ANTERIOR" + "');", true);
        }
    }

    protected void bntGuardarCertificado_Click(object sender, EventArgs e)
    {

        DataTable otrosAsegurados = (DataTable)Session["otrosAsegurados"];
        DataTable dtTemp = (DataTable)Session["dtTemp"];
        DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        DataTable dtExtraPrimaConyuge = (DataTable)Session["dtExtraPrimaConyugeGuardarFinal"];
        DataTable dtExtraPrimaPrincipal = (DataTable)Session["dtExtraPrimaPrincipalGuardarFinal"];
        DataTable dtArchivo = new DataTable();
        DataTable dtArchivoPagaduria = new DataTable();
        DataTable dtPeriodicidad = new DataTable();
        DataTable dtPlanTieneTasa = new DataTable();
        //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        // DataTable dtCrearExtraPrima = (DataTable)Session["dtCrearExtraPrima"];
        //string movimientoPrincipal = "NOTIENE";
        //string movimientoConyuge = "NOTIENE";
        string movimientoOtrosAsegurados = (string)Session["movimientoOtrosAsegurados"];

        // Comprobar que no tenga carta de retiro
        int estado = CanceladoPorFechaRetiro();
        string estadoCertificado = "PRODUCCION NUEVA";
        if (estado == 1)
            estadoCertificado = "CANCELADO";

        int recuperado = CertificadoRecuperado();

        try
        {
            ///////////////////////////////////////////////////////////////-- Novedades Sebastian //////////////////////////////////////////////////////

            DataTable dtNovedades = new DataTable();

            DataColumn columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "producto";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "tercero";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "certificado";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "convenio";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "mes";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "anio";
            dtNovedades.Columns.Add(columns);

            columns = new DataColumn();
            columns.DataType = System.Type.GetType("System.String");
            columns.AllowDBNull = true;
            columns.ColumnName = "prima";
            dtNovedades.Columns.Add(columns);

            DataRow producto = dtNovedades.NewRow();
            producto["producto"] = ddlProducto.SelectedValue.ToString();
            producto["tercero"] = txtCedulaPrincipal.Text;
            producto["certificado"] = int.Parse(Session["cer_Id"].ToString());
            producto["convenio"] = ddlConvenioPrincipal.SelectedValue.ToString();
            producto["mes"] = txtmesProduccion.Text;
            producto["anio"] = DateTime.Now.Year;
            producto["prima"] = txtPrima.Text;
            dtNovedades.Rows.Add(producto);
            dtArchivo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtNovedades.Rows[0]["producto"].ToString()), int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));
            dtArchivoPagaduria = objAdministrarCertificados.ConsultarArchivoPagaduriaPorId(int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()));
            Session["dtArchivo"] = dtArchivo;
            dtPeriodicidad = objAdministrarCertificados.ConsultarPeriodicidadPorConvenio(int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));
            double primaCertificado = 0;
            primaCertificado = double.Parse(dtNovedades.Rows[0]["prima"].ToString());
            Session["dtNovedades"] = dtNovedades;

            int periodicidad = 0;
            periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

            double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);

            ///////////////////////////////////////////////////////////////-- Novedades Sebastian //////////////////////////////////////////////////////
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS, A SURGIDO UN ERROR EN LA ESTRUCTURA DE NOVEDADES, POR SUERTE EL CERTIFICADO AUN NO HA SIDO GUARDADO, POR FAVOR INFORFE AL EQUIPO DE INFORMATICA" + "');", true);
        }
        
            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
            Session["cerId_ValorNuevo"] = cer_IdNuevo;

            int cer_Id = 0;
            if ((string)Session["operacionCertificado"] == "modificar")
            {
                // Se cambia para que coja el anterior guardado en pre cargue
                //cer_Id = AdministrarCertificados.ConsultarIdCertificado(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()), "VIGENTE", "PRODUCCION NUEVA");
                DataTable dtCer_Id = objAdministrarCertificados.ConsultarCertificadosAnteriores(cer_IdNuevo);
                cer_Id = int.Parse(dtCer_Id.Rows[0]["cer_IdAnterior"].ToString());
            }

            Session["cerId_ValorAnterior"] = cer_Id;
            Session["cer_Id"] = cer_Id;
            Session["cer_IdNuevo"] = cer_IdNuevo;

            try
            {
                dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
            }
            catch
            {
                dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
            }

            if (txtCedulaConyuge.Text != "")
            {
                Page.Validate("grpValidacionConyuge");
            }
            if (Page.IsValid)
            {
                //VALIDACION BENEFICIARIO PRINCIPAL
                DataTable dtBeneficiario = (DataTable)Session["dtBeneficiario"];
                DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyuge"];
                if ((string)Session["operacionCertificado"] == "modificar")
                {
                    // CALCULO DEL MOVIMIENTO DEL PRINCIPAL
                    // Movimiento Principal
                    //INSERTAR CERTIFICADO
                    // Consultar Amparo Basico Anterior
                    int idFila = 0;
                    int cont = 0;
                    foreach (DataRow row in dtEliminarPrincipal.Rows)
                    {
                        if (row["Amparo"].ToString() == "Amparo Básico")
                            idFila = cont;
                        cont++;
                    }
                    DataTable dtAmparoAnterior = new DataTable();
                    dtAmparoAnterior = objAdministrarCertificados.ConsultarAmparoBasicoAnterior(cer_Id, int.Parse(txtCedulaPrincipal.Text));


                    int total = 0;
                    foreach (DataRow row in dtBeneficiario.Rows)
                    {
                        total = total + int.Parse(row["Porcentaje"].ToString());
                    }

                    if (total == 100)
                    {
                        string idConyuge = txtCedulaConyuge.Text;
                        if (idConyuge == "")
                        {
                            idConyuge = "0";
                        }
                        objAdministrarCertificados.insertarBeneficiario(dtBeneficiario, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);

                        int plaPrincipal;
                        if (ddlPlantel.Text != "")
                        {
                            plaPrincipal = int.Parse(ddlPlantel.SelectedValue.ToString());
                        }
                        else
                        {
                            plaPrincipal = 0;
                        }
                        btnCertificadoModal.Enabled = true;

                        //int tipoMovimientoDefinitivo = DeterminarTipoMovimiento(movimientoPrincipal, movimientoConyuge, movimientoOtrosAsegurados);
                        objAdministrarCertificados.ActualizarNewCertificado(cer_IdNuevo, int.Parse(txtPrima.Text), objAdministrarCertificados.objCertificadoPre.Consecutivo.ToString(), ddlConvenioPrincipal.SelectedValue.ToString(),
                       txtDeclaracionAsegurado.Text, txtDeclaracionEG.Text, estadoCertificado, txtEstatura.Text, txtestaturaPrincipal.Text, "0", double.Parse(idConyuge),
                       "0", txtPeso.Text, txtpesoPrincipal.Text, 50, 50, 50, int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), plaPrincipal, int.Parse(ddlPoliza.SelectedValue.ToString()),
                       3, recuperado, Convert.ToDateTime(txtFechaDigitacionCertificado.Text), int.Parse(ddlperiodoPagoCertificado.SelectedValue.ToString()));
                        //ActualizarCertificadoPreCargado();
                        //INSERTAR AMPAROS PRINCIPAL
                        objAdministrarCertificados.insertarAmparos(dtEliminarPrincipal, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);

                        if (dtExtraPrimaPrincipal == null)
                        {
                            dtExtraPrimaPrincipal = dtEliminarPrincipal;

                            DataColumn columnsDigitar = new DataColumn();
                            columnsDigitar.DataType = System.Type.GetType("System.String");
                            columnsDigitar.AllowDBNull = true;
                            columnsDigitar.Caption = "Porcentaje";
                            columnsDigitar.ColumnName = "Porcentaje";
                            columnsDigitar.DefaultValue = 0;
                            dtExtraPrimaPrincipal.Columns.Add(columnsDigitar);


                        }
                        objAdministrarCertificados.InsertarAmparosExtraPrima(dtExtraPrimaPrincipal, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);
                        //INSERTAR OTROS ASEGURADOS
                        if (otrosAsegurados.Rows.Count > 0)
                        {
                            objAdministrarCertificados.IngresarOtrosAsegurados(dtTemp, cer_IdNuevo);
                        }
                        //VALIDACION BENEFICIARIO CONYUGE
                        if (idConyuge != "0")
                        {
                            // CALCULO DEL MOVIMIENTO DEL CÓNYUGE
                            // Movimiento Cónyuge
                            //INSERTAR CÓNYUGE
                            // Consultar Amparo Basico Anterior del cónyuge
                            idFila = 0;
                            cont = 0;
                            foreach (DataRow row in dtEliminarConyuge.Rows)
                            {
                                if (row["Amparo"].ToString() == "Amparo Básico")
                                    idFila = cont;
                                cont++;
                            }
                            // Preguntar si aumento, rebajó o siguió igual
                            DataTable dtAmparoAnteriorCony = new DataTable();
                            dtAmparoAnteriorCony = objAdministrarCertificados.ConsultarAmparoBasicoAnterior(cer_Id, int.Parse(txtCedulaConyuge.Text));

                            // Cúmulos
                            int totalBeneficiarioConyuge = 0;
                            foreach (DataRow row in dtBeneficiarioConyuge.Rows)
                            {
                                if (row["Porcentaje"].ToString() != "")
                                    totalBeneficiarioConyuge = totalBeneficiarioConyuge + int.Parse(row["Porcentaje"].ToString());
                            }

                            if (totalBeneficiarioConyuge == 100)
                            {
                                //INSERTAR AMPAROS CONYUGE
                                if (idConyuge != "0")
                                {
                                    objAdministrarCertificados.insertarAmparos(dtEliminarConyuge, cer_IdNuevo, int.Parse(txtCedulaConyuge.Text), 2);
                                    if (dtExtraPrimaConyuge == null)
                                    {
                                        dtExtraPrimaConyuge = dtEliminarConyuge;

                                        DataColumn columnsDigitar = new DataColumn();
                                        columnsDigitar.DataType = System.Type.GetType("System.String");
                                        columnsDigitar.AllowDBNull = true;
                                        columnsDigitar.Caption = "Porcentaje";
                                        columnsDigitar.ColumnName = "Porcentaje";
                                        columnsDigitar.DefaultValue = 0;
                                        dtExtraPrimaConyuge.Columns.Add(columnsDigitar);
                                    }
                                    objAdministrarCertificados.InsertarAmparosExtraPrima(dtExtraPrimaConyuge, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 2);
                                }

                                objAdministrarCertificados.insertarBeneficiario(dtBeneficiarioConyuge, cer_IdNuevo, int.Parse(txtCedulaConyuge.Text), 2);

                                /// Crear tabla para el almacenamiento de la extra prima
                                DataTable dtCrearExtraPrima = new DataTable();

                                DataColumn columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "cer_IdNuevo";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "cer_IdAntiguo";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "extValorPrimaP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "extValorPrimaC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "par_IdP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "par_IdC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "bandera";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                double valorAseguradoP = 0;
                                double valorAseguradoC = 0;
                                double totalP = 0;
                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                                {
                                    if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                    {
                                        totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                    }
                                }
                                else
                                {
                                    if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                    {
                                        totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                    }
                                    else
                                    {
                                        if (txtPrincipalExtraprima.Text == "")
                                        {
                                            txtPrincipalExtraprima.Text = "0";
                                        }
                                        totalP = double.Parse(txtPrincipalExtraprima.Text);
                                    }
                                }
                                double totalC = 0;
                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                                {
                                    if (double.Parse(Session["valorExtraPrimadoC"].ToString()) != 0)
                                    {
                                        totalC = double.Parse(Session["valorExtraPrimadoC"].ToString()) - double.Parse(Session["totalExtraPrimaC"].ToString());
                                    }
                                }
                                else
                                {
                                    if (double.Parse(Session["valorExtraPrimadoC"].ToString()) != 0)
                                    {
                                        totalC = double.Parse(Session["valorExtraPrimadoC"].ToString()) - double.Parse(Session["totalExtraPrimaC"].ToString());
                                    }
                                    else
                                    {
                                        if (txtPrincipalExtraprimaConyuge.Text == "")
                                        {
                                            txtPrincipalExtraprimaConyuge.Text = "0";
                                        }
                                        totalC = double.Parse(txtPrincipalExtraprimaConyuge.Text);
                                    }
                                }
                                DataRow ExtraPrima = dtCrearExtraPrima.NewRow();
                                ExtraPrima["cer_IdNuevo"] = cer_IdNuevo;
                                ExtraPrima["cer_IdAntiguo"] = cer_Id;
                                if (int.Parse(Session["diferenciaValorAseguradoP"].ToString()) != 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoP"] = Session["diferenciaValorAseguradoP"].ToString();//Diferencia
                                }
                                else
                                {

                                    if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                                    {
                                        valorAseguradoP = double.Parse(ddlPlanPrincipal.SelectedItem.ToString());
                                    }
                                    else
                                    {
                                        valorAseguradoP = double.Parse(txtPlanPrincipal.Text);
                                    }

                                    ExtraPrima["ext_ValorAseguradoP"] = valorAseguradoP;
                                }

                                if (int.Parse(Session["diferenciaValorAseguradoC"].ToString()) != 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoC"] = Session["diferenciaValorAseguradoC"].ToString();
                                }
                                else
                                {
                                    if (ddlPlanConyuge.SelectedItem.ToString() != "")
                                    {
                                        valorAseguradoC = double.Parse(ddlPlanConyuge.SelectedItem.ToString());
                                    }
                                    else
                                    {
                                        valorAseguradoC = double.Parse(txtPlanConyuge.Text);
                                    }

                                    ExtraPrima["ext_ValorAseguradoC"] = valorAseguradoC;
                                }

                                ExtraPrima["extValorPrimaP"] = Session["TotalExtraPrimaP"].ToString();// valor de la prima del Grid sin ser aun extraprimado
                                ExtraPrima["extValorPrimaC"] = Session["TotalExtraPrimaC"].ToString();
                                ExtraPrima["ext_ValorExtraPrimaP"] = totalP;// Variables antes y despues de editar
                                ExtraPrima["ext_ValorExtraPrimaC"] = totalC;
                                ExtraPrima["par_IdP"] = 1;
                                ExtraPrima["par_IdC"] = 2;
                                ExtraPrima["bandera"] = 1;
                                dtCrearExtraPrima.Rows.Add(ExtraPrima);

                                Session["dtCrearExtraPrima"] = dtCrearExtraPrima;

                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                                {
                                    if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaP"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaP"].ToString()) == 0)
                                    {
                                        ExtraPrima["ext_ValorAseguradoP"] = 0;
                                    }
                                    if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaC"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaC"].ToString()) == 0)
                                    {
                                        ExtraPrima["ext_ValorAseguradoC"] = 0;
                                    }
                                }

                                objAdministrarCertificados.ConsultaYAlmacenarExtraPrima(dtCrearExtraPrima);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL PORCENTAJE DE LOS BENEFICIARIOS DE EL ASEGURADO CONYUGE NO SUMAN EL 100%" + "');", true);
                                btnCertificadoModal.Enabled = true;
                            }
                        }
                        else
                        {
                            DataTable dtCrearExtraPrima = new DataTable();

                            DataColumn columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "cer_IdNuevo";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "cer_IdAntiguo";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);


                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "extValorPrimaP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);


                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "par_IdP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "bandera";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            double valorAseguradoP = 0;
                            double totalP = 0;
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                            {
                                if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                {
                                    totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                }
                            }
                            else
                            {
                                if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                {
                                    totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                }
                                else
                                {
                                    if (txtPrincipalExtraprima.Text == "")
                                    {
                                        txtPrincipalExtraprima.Text = "0";
                                    }
                                    totalP = double.Parse(txtPrincipalExtraprima.Text);
                                }
                            }
                            DataRow ExtraPrima = dtCrearExtraPrima.NewRow();
                            ExtraPrima["cer_IdNuevo"] = cer_IdNuevo;
                            ExtraPrima["cer_IdAntiguo"] = cer_Id;

                            if (int.Parse(Session["diferenciaValorAseguradoP"].ToString()) != 0)
                            {
                                ExtraPrima["ext_ValorAseguradoP"] = Session["diferenciaValorAseguradoP"].ToString();//Diferencia
                            }
                            else
                            {
                                if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                                {
                                    valorAseguradoP = double.Parse(ddlPlanPrincipal.SelectedItem.ToString());
                                }
                                else
                                {
                                    valorAseguradoP = double.Parse(txtPlanPrincipal.Text);
                                }

                                ExtraPrima["ext_ValorAseguradoP"] = valorAseguradoP;
                            }
                            ExtraPrima["extValorPrimaP"] = Session["TotalExtraPrimaP"].ToString();
                            ExtraPrima["ext_ValorExtraPrimaP"] = totalP;
                            ExtraPrima["par_IdP"] = 1;
                            ExtraPrima["bandera"] = 0;
                            dtCrearExtraPrima.Rows.Add(ExtraPrima);

                            Session["dtCrearExtraPrima"] = dtCrearExtraPrima;


                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaP"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaP"].ToString()) == 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoP"] = 0;
                                }
                            }
                            objAdministrarCertificados.ConsultaYAlmacenarExtraPrima(dtCrearExtraPrima);
                        }

                        objAdministrarCertificados.ActualizarCertificadoAnterior(cer_Id);
                        if ((string)Session["operacionCertificado"] == "modificar")
                        {
                            Session["cer_Id"] = cer_IdNuevo;

                            CalcularNovedades(dtPeriodicidad, dtArchivoPagaduria);
                            DataTable dtEncabezadoCertificadoNuevo = new DataTable();
                            DataTable dtEncabezadoCertificadoAntiguo = new DataTable();
                            dtEncabezadoCertificadoNuevo = objAdministrarCertificados.spConsultarEncabezadoCertificado(int.Parse(Session["cer_IdNuevo"].ToString()));
                            dtEncabezadoCertificadoAntiguo = objAdministrarCertificados.spConsultarEncabezadoCertificado(int.Parse(Session["cerId_ValorAnterior"].ToString()));
                            Session["dtEncabezadoCertificadoAntiguo"] = dtEncabezadoCertificadoAntiguo;
                            if (dtEncabezadoCertificadoAntiguo.Rows.Count > 0)
                            {
                                if (int.Parse(dtEncabezadoCertificadoNuevo.Rows[0]["Paga_Id"].ToString()) != int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["Paga_Id"].ToString()))
                                {
                                    DataTable dtArchivoAntiguo = new DataTable();
                                    dtArchivoAntiguo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["pro_Id"].ToString()), int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["con_Id"].ToString()));

                                    DataTable dtArchivoPagaduriaAntiguo = new DataTable();
                                    dtArchivoPagaduriaAntiguo = objAdministrarCertificados.ConsultarArchivoPagaduriaPorId(int.Parse(dtArchivoAntiguo.Rows[0]["arcpag_Id"].ToString()));

                                    Session["dtArchivoAntiguo"] = dtArchivoAntiguo;

                                    DataTable dtPeriodicidadAntiguo = new DataTable();
                                    dtPeriodicidadAntiguo = objAdministrarCertificados.ConsultarPeriodicidadPorConvenio(int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["con_Id"].ToString()));

                                    CalcularNovedadesRetiroRetiro(dtPeriodicidadAntiguo, dtArchivoPagaduriaAntiguo);
                                }
                            }
                            List<int> listaTipoMovimiento = new List<int>();
                            List<int> listaPlapolId = objAdministrarCertificados.ConsultarPlapolIdCertificado(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()));
                            if (listaPlapolId[0] != 0 && listaPlapolId[1] != 0)
                            {
                                listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), listaPlapolId[0], listaPlapolId[1]);

                            }
                            else
                            {
                                if (listaPlapolId[0] == 0 && listaPlapolId[1] != 0)
                                {
                                    listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), 0, listaPlapolId[1]);
                                }

                                if (listaPlapolId[0] != 0 && listaPlapolId[1] == 0)
                                {
                                    listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), listaPlapolId[0], 0);
                                }

                                if (listaPlapolId[0] == 0 && listaPlapolId[1] == 0)
                                {
                                    listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), 0, 0);
                                }
                            }

                            // Si es reexpedición se debe actualizar la fecha de vigencia
                            DateTime fechaVigencia = new DateTime();
                            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
                            if (listaTipoMovimiento[3] == 0)
                            {
                                fechaVigencia = objAdministrarCertificados.CalcularFechaVigencia(txtmesProduccion.Text, dtEncabezadoCertificado.Rows[0]["cer_AnoProduccion"].ToString());
                                objAdministrarCertificados.ActualizarFechaVigencia(int.Parse(Session["cerId_ValorNuevo"].ToString()), fechaVigencia);
                            }

                            objAdministrarCertificados.ActualizarTipoMovimientoCertificado(int.Parse(Session["cerId_ValorNuevo"].ToString()), listaTipoMovimiento[0], listaTipoMovimiento[1], listaTipoMovimiento[2]);


                            //Response.Redirect("ResumenCertificado.aspx");
                            Response.RedirectToRoute("resumenCertificado");
                        }
                    }
                    else
                    {
                        btnCertificadoModal.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL PORCENTAJE DE LOS BENEFICIARIOS DE EL ASEGURADO PRINCIPAL NO SUMAN EL 100%" + "');", true);
                    }
                }
                // Si es un ingreso nuevo
                else
                {
                    //VALIDACION BENEFICIARIO PRINCIPAL
                    int total = 0;
                    foreach (DataRow row in dtBeneficiario.Rows)
                    {
                        total = total + int.Parse(row["Porcentaje"].ToString());
                    }

                    if (total == 100)
                    {
                        objAdministrarCertificados.insertarBeneficiario(dtBeneficiario, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);


                        string idConyuge = txtCedulaConyuge.Text;
                        if (idConyuge == "")
                        {
                            idConyuge = "0";
                        }

                        //INSERTAR CERTIFICADO
                        int plaPrincipal;
                        if (ddlPlantel.Text != "")
                        {
                            plaPrincipal = int.Parse(ddlPlantel.SelectedValue.ToString());
                        }
                        else
                        {
                            plaPrincipal = 0;
                        }
                        btnCertificadoModal.Enabled = true;
                        //int tipoMovimientoDefinitivo = DeterminarTipoMovimiento(movimientoPrincipal, movimientoConyuge, movimientoOtrosAsegurados);
                        objAdministrarCertificados.ActualizarNewCertificado(cer_IdNuevo, double.Parse(txtPrima.Text), objAdministrarCertificados.objCertificadoPre.Consecutivo.ToString(), ddlConvenioPrincipal.SelectedValue.ToString(),
                       txtDeclaracionAsegurado.Text, txtDeclaracionEG.Text, estadoCertificado, txtEstatura.Text, txtestaturaPrincipal.Text, "0", double.Parse(idConyuge),
                       "0", txtPeso.Text, txtpesoPrincipal.Text, 50, 50, 50, int.Parse(ddlLocalidadCertificado.SelectedValue.ToString()), plaPrincipal, int.Parse(ddlPoliza.SelectedValue.ToString()),
                       3, recuperado, Convert.ToDateTime(txtFechaDigitacionCertificado.Text), int.Parse(ddlperiodoPagoCertificado.SelectedValue.ToString()));

                        //INSERTAR AMPAROS PRINCIPAL
                        objAdministrarCertificados.insertarAmparos(dtEliminarPrincipal, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);
                        //VALIDACION BENEFICIARIO CONYUGE

                        if (dtExtraPrimaPrincipal == null)
                        {
                            dtExtraPrimaPrincipal = dtEliminarPrincipal;

                            DataColumn columnsDigitar = new DataColumn();
                            columnsDigitar.DataType = System.Type.GetType("System.String");
                            columnsDigitar.AllowDBNull = true;
                            columnsDigitar.Caption = "Porcentaje";
                            columnsDigitar.ColumnName = "Porcentaje";
                            columnsDigitar.DefaultValue = 0;
                            dtExtraPrimaPrincipal.Columns.Add(columnsDigitar);
                        }
                        objAdministrarCertificados.InsertarAmparosExtraPrima(dtExtraPrimaPrincipal, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 1);

                        //INSERTAR OTROS ASEGURADOS
                        if (otrosAsegurados.Rows.Count > 0)
                        {
                            objAdministrarCertificados.IngresarOtrosAsegurados(dtTemp, cer_IdNuevo);
                        }

                        if (idConyuge != "0")
                        {
                            int totalBeneficiarioConyuge = 0;
                            //foreach (Asegurado row in beneficiarioConyuge)
                            foreach (DataRow row in dtBeneficiarioConyuge.Rows)
                            {
                                if (row["Porcentaje"].ToString() != "")
                                    totalBeneficiarioConyuge = totalBeneficiarioConyuge + int.Parse(row["Porcentaje"].ToString());
                            }

                            if (totalBeneficiarioConyuge == 100)
                            {
                                //INSERTAR AMPAROS CONYUGE

                                objAdministrarCertificados.insertarAmparos(dtEliminarConyuge, cer_IdNuevo, int.Parse(txtCedulaConyuge.Text), 2);
                                if (dtExtraPrimaConyuge == null)
                                {
                                    dtExtraPrimaConyuge = dtEliminarConyuge;

                                    DataColumn columnsDigitar = new DataColumn();
                                    columnsDigitar.DataType = System.Type.GetType("System.String");
                                    columnsDigitar.AllowDBNull = true;
                                    columnsDigitar.Caption = "Porcentaje";
                                    columnsDigitar.ColumnName = "Porcentaje";
                                    columnsDigitar.DefaultValue = 0;
                                    dtExtraPrimaConyuge.Columns.Add(columnsDigitar);
                                }
                                objAdministrarCertificados.InsertarAmparosExtraPrima(dtExtraPrimaConyuge, cer_IdNuevo, int.Parse(txtCedulaPrincipal.Text), 2);


                                objAdministrarCertificados.insertarBeneficiario(dtBeneficiarioConyuge, cer_IdNuevo, int.Parse(txtCedulaConyuge.Text), 2);

                                /// Crear tabla para el almacenamiento de la extra prima
                                DataTable dtCrearExtraPrima = new DataTable();

                                DataColumn columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "cer_IdNuevo";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "cer_IdAntiguo";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "extValorPrimaP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "extValorPrimaC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "par_IdP";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "par_IdC";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                columnsCrearExtraPrima = new DataColumn();
                                columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                                columnsCrearExtraPrima.AllowDBNull = true;
                                columnsCrearExtraPrima.ColumnName = "bandera";
                                dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                                //double totalesP = 0;
                                double valorAseguradoP = 0;
                                double valorAseguradoC = 0;
                                double totalP = 0;
                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                                {
                                    if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                    {
                                        totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                    }
                                }
                                else
                                {
                                    if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                    {
                                        totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                    }
                                    else
                                    {
                                        if (txtPrincipalExtraprima.Text == "")
                                        {
                                            txtPrincipalExtraprima.Text = "0";
                                        }
                                        totalP = double.Parse(txtPrincipalExtraprima.Text);
                                    }
                                }
                                double totalC = 0;

                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                                {
                                    if (double.Parse(Session["valorExtraPrimadoC"].ToString()) != 0)
                                    {
                                        totalC = double.Parse(Session["valorExtraPrimadoC"].ToString()) - double.Parse(Session["totalExtraPrimaC"].ToString());
                                    }
                                }
                                else
                                {
                                    if (double.Parse(Session["valorExtraPrimadoC"].ToString()) != 0)
                                    {
                                        totalC = double.Parse(Session["valorExtraPrimadoC"].ToString()) - double.Parse(Session["totalExtraPrimaC"].ToString());
                                    }
                                    else
                                    {
                                        if (txtPrincipalExtraprimaConyuge.Text == "")
                                        {
                                            txtPrincipalExtraprimaConyuge.Text = "0";
                                        }
                                        totalC = double.Parse(txtPrincipalExtraprimaConyuge.Text);
                                    }
                                }
                                DataRow ExtraPrima = dtCrearExtraPrima.NewRow();
                                ExtraPrima["cer_IdNuevo"] = cer_IdNuevo;
                                ExtraPrima["cer_IdAntiguo"] = cer_IdNuevo;

                                if (int.Parse(Session["diferenciaValorAseguradoP"].ToString()) != 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoP"] = Session["diferenciaValorAseguradoP"].ToString();//Diferencia
                                }
                                else
                                {
                                    if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                                    {
                                        valorAseguradoP = double.Parse(ddlPlanPrincipal.SelectedItem.ToString());
                                    }
                                    else
                                    {
                                        valorAseguradoP = double.Parse(txtPlanPrincipal.Text);
                                    }

                                    ExtraPrima["ext_ValorAseguradoP"] = valorAseguradoP;
                                }

                                if (int.Parse(Session["diferenciaValorAseguradoC"].ToString()) != 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoC"] = Session["diferenciaValorAseguradoC"].ToString();
                                }
                                else
                                {
                                    if (ddlPlanConyuge.SelectedItem.ToString() != "")
                                    {
                                        valorAseguradoC = double.Parse(ddlPlanConyuge.SelectedItem.ToString());
                                    }
                                    else
                                    {
                                        valorAseguradoC = double.Parse(txtPlanConyuge.Text);
                                    }
                                    ExtraPrima["ext_ValorAseguradoC"] = valorAseguradoC;
                                }
                                ExtraPrima["extValorPrimaP"] = Session["TotalExtraPrimaP"].ToString();
                                ExtraPrima["extValorPrimaC"] = Session["TotalExtraPrimaC"].ToString();
                                ExtraPrima["ext_ValorExtraPrimaP"] = totalP;
                                ExtraPrima["ext_ValorExtraPrimaC"] = totalC;
                                ExtraPrima["par_IdP"] = 1;
                                ExtraPrima["par_IdC"] = 2;
                                ExtraPrima["bandera"] = 1;
                                dtCrearExtraPrima.Rows.Add(ExtraPrima);

                                Session["dtCrearExtraPrima"] = dtCrearExtraPrima;

                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                                {
                                    if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaP"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaP"].ToString()) == 0)
                                    {
                                        ExtraPrima["ext_ValorAseguradoP"] = 0;
                                    }
                                    if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaC"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaC"].ToString()) == 0)
                                    {
                                        ExtraPrima["ext_ValorAseguradoC"] = 0;
                                    }
                                }

                                objAdministrarCertificados.ConsultaYAlmacenarExtraPrima(dtCrearExtraPrima);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL PORCENTAJE DE LOS BENEFICIARIOS DE EL ASEGURADO CONYUGE NO SUMAN EL 100%" + "');", true);
                            }
                        }
                        else
                        {
                            DataTable dtCrearExtraPrima = new DataTable();

                            DataColumn columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "cer_IdNuevo";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "cer_IdAntiguo";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "ext_ValorAseguradoP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "ext_ValorExtraPrimaP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);


                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "extValorPrimaP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);


                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "par_IdP";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            columnsCrearExtraPrima = new DataColumn();
                            columnsCrearExtraPrima.DataType = System.Type.GetType("System.String");
                            columnsCrearExtraPrima.AllowDBNull = true;
                            columnsCrearExtraPrima.ColumnName = "bandera";
                            dtCrearExtraPrima.Columns.Add(columnsCrearExtraPrima);

                            double valorAseguradoP = 0;
                            double totalP = 0;
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                            {
                                if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                {
                                    totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                }
                            }
                            else
                            {
                                if (double.Parse(Session["valorExtraPrimado"].ToString()) != 0)
                                {
                                    totalP = double.Parse(Session["valorExtraPrimado"].ToString()) - double.Parse(Session["totalExtraPrimaP"].ToString());
                                }
                                else
                                {
                                    if (txtPrincipalExtraprima.Text == "")
                                    {
                                        txtPrincipalExtraprima.Text = "0";
                                    }
                                    totalP = double.Parse(txtPrincipalExtraprima.Text);
                                }
                            }
                            DataRow ExtraPrima = dtCrearExtraPrima.NewRow();
                            ExtraPrima["cer_IdNuevo"] = cer_IdNuevo;
                            ExtraPrima["cer_IdAntiguo"] = cer_IdNuevo;

                            if (int.Parse(Session["diferenciaValorAseguradoP"].ToString()) != 0)
                            {
                                ExtraPrima["ext_ValorAseguradoP"] = Session["diferenciaValorAseguradoP"].ToString();//Diferencia
                            }
                            else
                            {
                                if (ddlPlanPrincipal.SelectedItem.ToString() != "")
                                {
                                    valorAseguradoP = double.Parse(ddlPlanPrincipal.SelectedItem.ToString());
                                }
                                else
                                {
                                    valorAseguradoP = double.Parse(txtPlanPrincipal.Text);
                                }

                                ExtraPrima["ext_ValorAseguradoP"] = valorAseguradoP;
                            }
                            ExtraPrima["extValorPrimaP"] = Session["TotalExtraPrimaP"].ToString();
                            ExtraPrima["ext_ValorExtraPrimaP"] = totalP;
                            ExtraPrima["par_IdP"] = 1;
                            ExtraPrima["bandera"] = 0;
                            dtCrearExtraPrima.Rows.Add(ExtraPrima);

                            Session["dtCrearExtraPrima"] = dtCrearExtraPrima;

                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                if (double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaP"].ToString()) == 0 && double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaP"].ToString()) == 0)
                                {
                                    ExtraPrima["ext_ValorAseguradoP"] = 0;
                                }
                            }

                            objAdministrarCertificados.ConsultaYAlmacenarExtraPrima(dtCrearExtraPrima);
                        }
                        Session["cer_Id"] = cer_IdNuevo;
                        CalcularNovedades(dtPeriodicidad, dtArchivoPagaduria);

                        // Se crea el dt para almacenar en el la informacion del certificado nuevo
                        DataTable dtEncabezadoCertificadoNuevo = new DataTable();
                        // Se crea el dt para almacenar en el la informacion del certificado Antiguo
                        DataTable dtEncabezadoCertificadoAntiguo = new DataTable();

                        // Se Alacena la informacion que debe ir en el dtEncabezadoCertificadoNuevo
                        dtEncabezadoCertificadoNuevo = objAdministrarCertificados.spConsultarEncabezadoCertificado(int.Parse(Session["cer_IdNuevo"].ToString()));

                        // Se Alacena la informacion que debe ir en el dtEncabezadoCertificadoAntiguo
                        dtEncabezadoCertificadoAntiguo = objAdministrarCertificados.spConsultarEncabezadoCertificado(int.Parse(Session["cerId_ValorAnterior"].ToString()));
                        //Session para almacenar el dtEncabezadoCertificadoAntiguo
                        Session["dtEncabezadoCertificadoAntiguo"] = dtEncabezadoCertificadoAntiguo;

                        if (dtEncabezadoCertificadoAntiguo.Rows.Count > 0)
                        {
                            //Consdicional para identificar si la pagaduria anterior y la nueva no son iguales.
                            if (int.Parse(dtEncabezadoCertificadoNuevo.Rows[0]["Paga_Id"].ToString()) != int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["Paga_Id"].ToString()))
                            {

                                // se consulta el archivo dependiendo del producto y el convenio
                                DataTable dtArchivoAntiguo = new DataTable();
                                dtArchivoAntiguo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["pro_Id"].ToString()), int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["con_Id"].ToString()));

                                // Consultar la estructura del archivo con el id capturado anteriormente
                                DataTable dtArchivoPagaduriaAntiguo = new DataTable();
                                dtArchivoPagaduriaAntiguo = objAdministrarCertificados.ConsultarArchivoPagaduriaPorId(int.Parse(dtArchivoAntiguo.Rows[0]["arcpag_Id"].ToString()));

                                Session["dtArchivoAntiguo"] = dtArchivoAntiguo;

                                // se consulta la periodicidad de pago dependiendo del convenio
                                DataTable dtPeriodicidadAntiguo = new DataTable();
                                dtPeriodicidadAntiguo = objAdministrarCertificados.ConsultarPeriodicidadPorConvenio(int.Parse(dtEncabezadoCertificadoAntiguo.Rows[0]["con_Id"].ToString()));

                                // se crea la funcion para calculas las novedades cuando la anterior y la nueva no son las mismas 
                                CalcularNovedadesRetiroRetiro(dtPeriodicidadAntiguo, dtArchivoPagaduriaAntiguo);
                            }
                        }
                        List<int> listaTipoMovimiento = new List<int>();
                        List<int> listaPlapolId = objAdministrarCertificados.ConsultarPlapolIdCertificado(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()));
                        if (listaPlapolId[0] != 0 && listaPlapolId[1] != 0)
                        {
                            listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), listaPlapolId[0], listaPlapolId[1]);
                        }
                        else
                        {
                            if (listaPlapolId[0] == 0 && listaPlapolId[1] != 0)
                            {
                                listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), 0, listaPlapolId[1]);
                            }

                            if (listaPlapolId[0] != 0 && listaPlapolId[1] == 0)
                            {
                                listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), listaPlapolId[0], 0);
                            }

                            if (listaPlapolId[0] == 0 && listaPlapolId[1] == 0)
                            {
                                listaTipoMovimiento = objAdministrarCertificados.CalcularTipoMovimiento(int.Parse(Session["cerId_ValorAnterior"].ToString()), int.Parse(Session["cerId_ValorNuevo"].ToString()), 0, 0);
                            }
                        }

                        // Si es reexpedición se debe actualizar la fecha de vigencia
                        DateTime fechaVigencia = new DateTime();
                        DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
                        if (listaTipoMovimiento[3] == 0)
                        {
                            fechaVigencia = objAdministrarCertificados.CalcularFechaVigencia(txtmesProduccion.Text, dtEncabezadoCertificado.Rows[0]["cer_AnoProduccion"].ToString());
                            objAdministrarCertificados.ActualizarFechaVigencia(int.Parse(Session["cerId_ValorNuevo"].ToString()), fechaVigencia);
                        }

                        objAdministrarCertificados.ActualizarTipoMovimientoCertificado(int.Parse(Session["cerId_ValorNuevo"].ToString()), listaTipoMovimiento[0], listaTipoMovimiento[1], listaTipoMovimiento[2]);
                        //Response.Redirect("ResumenCertificado.aspx");
                        Response.RedirectToRoute("resumenCertificado");
                        Session["dtBeneficiario"] = dtBeneficiario;
                        Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;
                    }
                    else
                    {
                        btnCertificadoModal.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL PORCENTAJE DE LOS BENEFICIARIOS DE EL ASEGURADO PRINCIPAL NO SUMAN EL 100%" + "');", true);
                    }
                }
            }
        }
        //catch 
        //{
        //    Exception ex;
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS, A SURGIDO UN ERROR AL INTENTAR GUARDAR EL CERITIFCADO. POR FAVOR SALGA Y VERIFIQUE QUE EL CERITIFICADO NO HAYA QUEDADO INCOMPLETO, EN CASO DE SER ASI, INFORME AL EQUIPO DE INFORMATICA" + "');", true);
        //}
    
    //sebastian
    protected void grvBeneficiarioPrincipal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("addNew"))
        {
            if (((TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewNombre")).Text != "")
            {
                TextBox txtNewNombre = (TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewNombre");
                TextBox txtNewApellido = (TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewApellido");
                TextBox txtNewCedula = (TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewCedula");
                TextBox txtNewEdad = (TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewEdad");
                TextBox txtNewPorcentaje = (TextBox)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewPorcentaje");
                DropDownList txtNewParentesco = (DropDownList)grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewParentesco");

                Asegurado p = new Asegurado();
                p.Nombres = txtNewNombre.Text;
                p.Apellidos = txtNewApellido.Text;
                p.NumeroDocumento = txtNewCedula.Text;
                p.Edad = int.Parse(txtNewEdad.Text);
                p.Porcentaje = int.Parse(txtNewPorcentaje.Text);
                p.Parentesco = txtNewParentesco.SelectedItem.ToString();

                DataTable dtBeneficiario = (DataTable)Session["dtBeneficiario"];
                DataRow row = dtBeneficiario.NewRow();
                row["NumeroDocumento"] = p.NumeroDocumento;
                row["Apellidos"] = p.Apellidos;
                row["Nombres"] = p.Nombres;
                row["Edad"] = p.Edad;
                row["Porcentaje"] = p.Porcentaje;
                row["Parentesco"] = p.Parentesco;
                dtBeneficiario.Rows.Add(row);

                grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                grvBeneficiarioPrincipal.DataBind();

                if (dtBeneficiario.Rows.Count == 0)
                {
                    grvBeneficiarioPrincipal.FooterRow.Visible = true;
                }
                Session["dtBeneficiario"] = dtBeneficiario;

                //grvBeneficiarioPrincipal.Rows[0].Visible = false;

            }
        }
    }

    //sebastian
    protected void grvBeneficiarioPrincipal_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtBeneficiario = (DataTable)Session["dtBeneficiario"];
        dtBeneficiario.Rows.RemoveAt(e.RowIndex);
        grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
        grvBeneficiarioPrincipal.DataBind();
        grvBeneficiarioPrincipal.Attributes.Add("onclick", "localStorage.setItem('accIndex', 1);");
        if (dtBeneficiario.Rows.Count == 0)
        {
            DataTable dtBeneficiarioVacio = dtBeneficiario.Clone();
            DataRow drBeneficiarioVacio = dtBeneficiarioVacio.NewRow();
            dtBeneficiarioVacio.Rows.Add(drBeneficiarioVacio);
            grvBeneficiarioPrincipal.DataSource = dtBeneficiarioVacio;
            grvBeneficiarioPrincipal.DataBind();
            grvBeneficiarioPrincipal.Rows[0].Visible = false;
            grvBeneficiarioPrincipal.Rows[0].Controls.Clear();
        }

        //grvBeneficiarioPrincipal.Rows[0].Visible = false;
        Session["dtBeneficiario"] = dtBeneficiario;
    }
    /*-------------------------------------------------Tabla beneficiario conyuge---------------------------------------------------*/


    protected void grvBeneficiarioConyuge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("addNew"))
        {
            TextBox txtNewNombre = (TextBox)grvBeneficiarioConyuge.FooterRow.FindControl("txtNewNombre");
            TextBox txtNewApellido = (TextBox)grvBeneficiarioConyuge.FooterRow.FindControl("txtNewApellido");
            TextBox txtNewCedula = (TextBox)grvBeneficiarioConyuge.FooterRow.FindControl("txtNewCedula");
            TextBox txtNewEdad = (TextBox)grvBeneficiarioConyuge.FooterRow.FindControl("txtNewEdad");
            TextBox txtNewPorcentaje = (TextBox)grvBeneficiarioConyuge.FooterRow.FindControl("txtNewPorcentaje");
            DropDownList ddlNewParentesco = (DropDownList)grvBeneficiarioConyuge.FooterRow.FindControl("ddlNewParentesco");

            Asegurado p = new Asegurado();
            p.Nombres = txtNewNombre.Text;
            p.Apellidos = txtNewApellido.Text;
            p.NumeroDocumento = txtNewCedula.Text;
            p.Edad = int.Parse(txtNewEdad.Text);
            p.Porcentaje = int.Parse(txtNewPorcentaje.Text);
            p.Parentesco = ddlNewParentesco.SelectedItem.ToString();

            DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyuge"];
            DataRow row = dtBeneficiarioConyuge.NewRow();
            row["NumeroDocumento"] = p.NumeroDocumento;
            row["Apellidos"] = p.Apellidos;
            row["Nombres"] = p.Nombres;
            row["Edad"] = p.Edad;
            row["Porcentaje"] = p.Porcentaje;
            row["Parentesco"] = p.Parentesco;
            dtBeneficiarioConyuge.Rows.Add(row);

            grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
            grvBeneficiarioConyuge.DataBind();

            if (dtBeneficiarioConyuge.Rows.Count == 0)
            {
                grvBeneficiarioConyuge.FooterRow.Visible = true;
            }
            Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;
            if ((string)Session["operacionCertificado"] == "modificar")
            {

                    //grvBeneficiarioConyuge.Rows[0].Visible = false;
            }

        }
    }
    protected void grvBeneficiarioConyuge_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyuge"];
        dtBeneficiarioConyuge.Rows.RemoveAt(e.RowIndex);
        grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
        grvBeneficiarioConyuge.DataBind();
        grvBeneficiarioConyuge.Attributes.Add("onclick", "localStorage.setItem('accIndex', 2);");
        if (dtBeneficiarioConyuge.Rows.Count == 0)
        {
            DataTable dtBeneficiarioConyugeVacio = dtBeneficiarioConyuge.Clone();
            DataRow drBeneficiarioConyugeVacio = dtBeneficiarioConyugeVacio.NewRow();
            dtBeneficiarioConyugeVacio.Rows.Add(drBeneficiarioConyugeVacio);
            grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyugeVacio;
            grvBeneficiarioConyuge.DataBind();
            grvBeneficiarioConyuge.Rows[0].Visible = false;
            grvBeneficiarioConyuge.Rows[0].Controls.Clear();
        }
       
        if ((string)Session["operacionCertificado"] == "modificar")
        {
          //  grvBeneficiarioConyuge.Rows[0].Visible = false;
        }
        Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;
    }

    protected void grvAmparoConyuge_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        double totalExtraPrimaC3 = 0;
        double valorExtraPrimado = 0;
        double totalC = 0;
        double totalExtraPrimaC = 0;
        double totalPrimaGeneralEliminar2 = 0;
        double totalPrimaGeneralEliminar = 0;
        double valorAseguradoGeneralConyuge = 0;
        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtPlanTieneTasa = new DataTable();
        DataTable dtExtraprimaConyugeRestaurar2 = new DataTable();
        dtExtraprimaConyugeRestaurar2 = (DataTable)Session["dtExtraPrimaConyugeGuardarFinal"];

        try
        {
            totalPrimaGeneralEliminar = (double)Session["totalPrimaGeneralEliminarConyuge"];
        }
        catch
        {
            totalPrimaGeneralEliminar = 0;
        }
        try
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
        }
        catch
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
        }
        if (dtExtraprimaConyugeRestaurar2 != null)
        {
            // se elimina el amparo en extraprima automaticamente cuando ya se elimino en amparos

            double primaGeneralEliminar = double.Parse(dtExtraprimaConyugeRestaurar2.Rows[e.RowIndex]["Prima"].ToString());

            totalPrimaGeneralEliminar += primaGeneralEliminar;
            foreach (DataRow dr in dtExtraprimaConyugeRestaurar2.Rows)
            {
                if (int.Parse(dr["amp_Id"].ToString()) == 1)
                {
                    valorAseguradoGeneralConyuge = double.Parse(dr["Valor Asegurado"].ToString());
                }
            }
            Session["totalPrimaGeneralEliminarConyuge"] = totalPrimaGeneralEliminar;
            totalPrimaGeneralEliminar2 = double.Parse(Session["totalPrimaGeneralEliminarConyuge"].ToString());
            
            dtExtraprimaConyugeRestaurar2.Rows.RemoveAt(e.RowIndex);
            grvExtraPrimaConyuge.DataSource = dtExtraprimaConyugeRestaurar2;
            grvExtraPrimaConyuge.DataBind();
        }

        //historial de ceritificados antetiones generales
        DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
        dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
        grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
        grvHistorialExtraPrimaConyuge.DataBind();

        double totalValorPrimaEliminar = 0;
        try
        {
            totalValorPrimaEliminar = double.Parse(Session["totalValorPrimaEliminarConyuge"].ToString());
        }
        catch
        {
            totalValorPrimaEliminar = 0;
        }

        double valorPrimaEliminar = double.Parse(dtEliminarConyuge.Rows[e.RowIndex]["prima"].ToString());

        totalValorPrimaEliminar += valorPrimaEliminar;

        Session["totalValorPrimaEliminarConyuge"] = totalValorPrimaEliminar;
        double totalValorPrimaEliminar2 = double.Parse(Session["totalValorPrimaEliminarConyuge"].ToString());

        double consultarHistorialExtraPrimaConyuge = 0;
        double valorExtraPrimaConyuge = 0;

        //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
        if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
        {
            // Recorre el dt para consultar los valores de prima y extra prima
            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
            {
                consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
            }
        }

        if (dtExtraprimaConyugeRestaurar2 != null)
        {

            //recorre tabla de extra prima para la suma de primas
            foreach (DataRow dt in dtExtraprimaConyugeRestaurar2.Rows)
            {
                valorExtraPrimado += Convert.ToDouble(dt[3].ToString());
            }
            //recorre tabla de extra prima para la suma de primas 
            foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
            {
                totalExtraPrimaC += Convert.ToDouble(row.Cells[4].Text);
            }
            totalExtraPrimaC = (totalExtraPrimaC + totalPrimaGeneralEliminar2) - totalValorPrimaEliminar2;
            if (valorExtraPrimado != 0)
            {
                totalC = valorExtraPrimado + totalPrimaGeneralEliminar2;
            }

            // Asignar variables con valores a los campos de prima y extra prima
            double primaConyugeExtraprima = 0;
            if (totalC != 0)
            {
                totalExtraPrimaC3 = totalC;
                //totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalC;
                primaConyugeExtraprima = totalExtraPrimaC3 - totalValorPrimaEliminar2;
            }
            else
            {
                if (valorAseguradoGeneralConyuge != 0)
                {
                    primaConyugeExtraprima = 0;
                }
                else
                {
                    totalExtraPrimaC3 = totalC;
                    totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalC;
                    primaConyugeExtraprima = totalExtraPrimaC3 - totalValorPrimaEliminar2;
                }
            }
            txtPrimaPrincipalExtraprimaConyuge.Text = primaConyugeExtraprima.ToString();

            if (txtPrimaPrincipalExtraprimaConyuge.Text != "")
            {
                int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
                txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
            }
        }

        txtPrimaConyuge.Text = txtPrimaPrincipalExtraprimaConyuge.Text;

        //sumar primas
        sumarPrima(0);

        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }

        dtEliminarConyuge.Rows.RemoveAt(e.RowIndex);
        grvAmparoConyuge.DataSource = dtEliminarConyuge;
        grvAmparoConyuge.DataBind();

        double totales = 0;
        foreach (GridViewRow row in grvAmparoConyuge.Rows)
        {
            totales += Convert.ToDouble(row.Cells[4].Text);
        }

        
        Session["dtEliminarConyuge"] = dtEliminarConyuge;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyugeRestaurar2;
        Session["TotalExtraPrimaC"] = totalExtraPrimaC;
    }


    /*-------------------------------------------------Fin beneficiario---------------------------------------------------*/

    protected void grvAmparoPrincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
        DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
        DataTable dtPlanTieneTasa = new DataTable();
        bool sePuedenHijosPMI = (bool)Session["sePuedenHijosPMI"];
        double valorExtraPrimado = 0;
        double totalP = 0;
        double totalP3 = 0;
        double totalExtraPrimaP = 0;
        double totalPrimaGeneralEliminar2 = 0;
        double totalPrimaGeneralEliminar = 0;
        double valorAseguradoGeneral = 0;
        try
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
        }
        catch
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
        }
        // Para Plan Maestro Integral se debe verificar que el asegurado principal tenga todos los amparos para poder asegurar hijos
        if (int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()) == 1 && dtEncabezadoCertificado.Rows[0]["pro_Nombre"].ToString() == "EDUCADORES")
        {
            if (sePuedenHijosPMI == true)
            {
                DataTable dtParentesco, dtParentescoEspejo = new DataTable();
                dtParentesco = objAdministrarCertificados.consultarParentesco(int.Parse(objAdministrarCertificados.objCertificadoPre.Producto));
                dtParentesco.Rows.RemoveAt(0);
                dtParentesco.Rows.RemoveAt(0);
                ddlParentesoOtro.DataTextField = "par_Nombre";
                ddlParentesoOtro.DataValueField = "par_Id";
                ddlParentesoOtro.DataSource = dtParentesco;
                ddlParentesoOtro.DataBind();
                ddlParentesoOtro.Items.Insert(0, new ListItem("", ""));
            }
            sePuedenHijosPMI = false;

        }
        //en esta session viene la tabla de extra primas
        DataTable dtExtraprimaPrincipalRestaurar2 = new DataTable();
        dtExtraprimaPrincipalRestaurar2 = (DataTable)Session["dtExtraPrimaPrincipalGuardarFinal"];

        try
        {
            totalPrimaGeneralEliminar = (double)Session["totalPrimaGeneralEliminar"];
        }
        catch
        {
            totalPrimaGeneralEliminar = 0;
        }
        if (dtExtraprimaPrincipalRestaurar2 != null)
        {
            // se elimina el amparo en extraprima automaticamente cuando ya se elimino en amparos
            
            double primaGeneralEliminar = double.Parse(dtExtraprimaPrincipalRestaurar2.Rows[e.RowIndex]["Prima"].ToString());

            totalPrimaGeneralEliminar += primaGeneralEliminar;
            foreach(DataRow dr in dtExtraprimaPrincipalRestaurar2.Rows)
            {
                if(int.Parse(dr["amp_Id"].ToString()) == 1)
                {
                    valorAseguradoGeneral = double.Parse(dr["Valor Asegurado"].ToString());
                }
            }
            Session["totalPrimaGeneralEliminar"] = totalPrimaGeneralEliminar;
            totalPrimaGeneralEliminar2 = double.Parse(Session["totalPrimaGeneralEliminar"].ToString());

            dtExtraprimaPrincipalRestaurar2.Rows.RemoveAt(e.RowIndex);
            grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipalRestaurar2;
            grvAmparoExtraPrima.DataBind();
        }
        
        //historial de ceritificados antetiones generales
        DataTable dtConsultarHistorialExtraPrima = new DataTable();
        dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
        grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
        grvHistorialExtraPrima.DataBind();

        if (int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()) == 0)
        {
            txtDocumentoConyugue.Enabled = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "RECUERDE QUE NO PODRA INGRESAR CONYUGE SI EL PRICIPAL NO POSEE TODOS LOS AMPAROS" + "');", true);
        }
         double totalValorPrimaEliminar = 0;
        try
        {
            totalValorPrimaEliminar = double.Parse(Session["totalValorPrimaEliminar"].ToString());
        }
        catch
        {
            totalValorPrimaEliminar = 0;
        }

        double valorPrimaEliminar = double.Parse(dtEliminarPrincipal.Rows[e.RowIndex]["prima"].ToString());

        totalValorPrimaEliminar += valorPrimaEliminar;

        Session["totalValorPrimaEliminar"] = totalValorPrimaEliminar;
        double totalValorPrimaEliminar2 = double.Parse(Session["totalValorPrimaEliminar"].ToString());

        double consultarHistorialExtraPrima = 0;
        double valorExtraPrima = 0;

        //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
        if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
        {
            // Recorre el dt para consultar los valores de prima y extra prima
            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
            {
                consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
            }
        }

        if (dtExtraprimaPrincipalRestaurar2 != null)
        {
            //recorre tabla de extra prima para la suma de primas
            foreach (DataRow dt in dtExtraprimaPrincipalRestaurar2.Rows)
            {
                valorExtraPrimado += double.Parse(dt[3].ToString());
               
            }

            //recorre tabla de extra prima para la suma de primas 
            foreach (GridViewRow row in grvAmparoExtraPrima.Rows)
            {
                totalExtraPrimaP += Convert.ToDouble(row.Cells[4].Text);
            }
            totalExtraPrimaP = (totalExtraPrimaP + totalPrimaGeneralEliminar2) - totalValorPrimaEliminar2;

            if (valorExtraPrimado != 0)
            {
                totalP = valorExtraPrimado + totalPrimaGeneralEliminar2;
            }

            // Asignar variables con valores a los campos de prima y extra prima
            double primaPrincipalExtraprima = 0;
            if (totalP != 0)
            {
                totalP3 = totalP;
                //totalP3 = consultarHistorialExtraPrima + totalP3;
                primaPrincipalExtraprima = totalP3 - totalValorPrimaEliminar2;

            }
            else
            {
                if (valorAseguradoGeneral != 0)
                {
                    primaPrincipalExtraprima = 0;
                }
                else
                {
                    totalP3 = totalP;
                    totalP3 = consultarHistorialExtraPrima + totalP3;
                    primaPrincipalExtraprima = totalP3 - totalValorPrimaEliminar2;
                }
            }
            txtPrimaPrincipalExtraprima.Text = primaPrincipalExtraprima.ToString();

            if (txtPrimaPrincipalExtraprima.Text != "")
            {
                int PrimaPrincipalExtraprima = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprima.Text)).ToString());
                txtPrimaPrincipalExtraprima.Text = PrimaPrincipalExtraprima.ToString();
            }
        }
        txtPrimaPrincipal.Text = txtPrimaPrincipalExtraprima.Text;

        //sumar primas
        sumarPrima(0);

        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        //dtExtraprimaPrincipalRestaurar2.Rows.RemoveAt(e.RowIndex);
        //grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipalRestaurar2;
        //grvAmparoExtraPrima.DataBind();

        dtEliminarPrincipal.Rows.RemoveAt(e.RowIndex);
        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
        grvAmparoPrincipal.DataBind();

        double totales = 0;
        foreach (GridViewRow row in grvAmparoPrincipal.Rows)
        {
            totales += Convert.ToDouble(row.Cells[4].Text);
        }

        Session["TotalExtraPrimaP"] = totalExtraPrimaP;
        Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
        Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipalRestaurar2;
    }


   
    protected void limpiarConyuge_Click(object sender, EventArgs e)
    {

        int primaGeneral = 0;
        int primaConyuge = 0;
        if (txtPrimaConyuge.Text == "")
        {
            txtPrimaConyuge.Text = "0";
        }

        if (txtPrincipalExtraprimaConyuge.Text == "")
        {
            txtPrincipalExtraprimaConyuge.Text = "0";
        }

        primaConyuge = int.Parse(txtPrincipalExtraprimaConyuge.Text) + int.Parse(txtPrimaConyuge.Text);
        primaGeneral = int.Parse(txtPrima.Text) - primaConyuge;
        txtPrima.Text = primaGeneral.ToString();

        txtCedulaConyuge.Text = "";
        txtNombreConyuge.Text = "";
        txtApellidoConyuge.Text = "";
        txtEdadConyuge.Text = "";
        txtPrimaConyuge.Text = "";
        txtDocumentoConyugue.Text = "";
        txtPrincipalExtraprimaConyuge.Text = "";
        txtExtraPrimaConyuge.Text = "";
        txtExtraPrimaConyuge.Text = "";
        txtPrincipalExtraprimaConyuge.Text = "";
        btnCertificadoModal.Enabled = true;
        
        ddlPlanConyuge.Items.Insert(0, new ListItem("", ""));
        ddlPlanConyuge.SelectedIndex = ddlPlanConyuge.Items.IndexOf(ddlPlanConyuge.Items.FindByText(" "));
        ddlPlanConyuge.Enabled = false;

        DataTable dtEliminarConyuge = new DataTable();
        amparosConyuge.Visible = false;
        grvAmparoConyuge.DataSource = dtEliminarConyuge;
        grvAmparoConyuge.DataBind();
        Session["dtEliminarConyuge"] = dtEliminarConyuge;

        DataTable dtBeneficiarioConyuge = new DataTable();
        beneficiariosConyuge.Visible = false;
        grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
        grvBeneficiarioConyuge.DataBind();
        //Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;

        txtPlanConyuge.Text = "";
        txtEstatura.Text = "";
        txtPeso.Text = "";
        txtPlanConyuge.Enabled = false;

        btnExtraPrima2.Visible = false;
        btnLimpiar.Visible = false;
        btnSiguienteConyuge.Enabled = true;
        btnValidarConyuge.Enabled = false;

        Session["LimpiarConyuge"] = 1;
        if (txtPrincipalExtraprimaConyuge.Text == "")
        {
            txtPrincipalExtraprimaConyuge.Text = "0";
        }
        Session["valorExtraPrimadoC"] = txtPrincipalExtraprimaConyuge.Text;
    }

    protected void btnAdicionarOtrosAsegurados_Click(object sender, EventArgs e)
    {
        DataTable otrosAsegurados = (DataTable)Session["otrosAsegurados"];
        DataTable dtTemp = (DataTable)Session["dtTemp"];
        string movimientoOtrosAsegurados = (string)Session["movimientoOtrosAsegurados"];

        movimientoOtrosAsegurados = "MODIFICA";
      
        grvOtrosAsegurados.Visible = true;
        btnAdicionarOtrosAsegurados.Enabled = false;        


        ConsultarAmparosPlanOtros(sender, e);

        double totales = 0;

        foreach (GridViewRow row1 in grvAmparoOtro.Rows)
        {
            totales += Convert.ToDouble(row1.Cells[3].Text);

        }

        if (dtTemp.Rows.Count == 0)
            dtTemp = otrosAsegurados.Clone();

        DataRow row = otrosAsegurados.NewRow();
        DataRow rowTemp = dtTemp.NewRow();
        row["Cedula"] = txtDocumentoOtros.Text;
        row["Nombre"] = txtNombreOtro.Text;
        row["Apellidos"] = txtApellidoOtro.Text;
        row["Fecha Nacimiento"] = txtFechaNacimiento.Text;
        row["Parentesco"] = ddlParentesoOtro.SelectedItem.ToString();
        row["Plan"] = ddlPlanOtros.SelectedItem.ToString();
        row["Prima"] = totales.ToString();

        rowTemp["Cedula"] = txtDocumentoOtros.Text;
        rowTemp["Nombre"] = txtNombreOtro.Text;
        rowTemp["Apellidos"] = txtApellidoOtro.Text;
        rowTemp["Fecha Nacimiento"] = txtFechaNacimiento.Text;
        rowTemp["Parentesco"] = ddlParentesoOtro.SelectedValue.ToString();
        rowTemp["Plan"] = ddlPlanOtros.SelectedValue.ToString();
        rowTemp["Prima"] = totales.ToString();

        otrosAsegurados.Rows.Add(row);
        dtTemp.Rows.Add(rowTemp);
        grvOtrosAsegurados.DataSource = otrosAsegurados;
        grvOtrosAsegurados.DataBind();
       
        if (txtPrimaOtros.Text != "")
            totales += double.Parse(txtPrimaOtros.Text);
        txtPrimaOtros.Text = totales.ToString();

        sumarPrima(totales);

        //Viviana
        //int sumaPrimasOtros = 0;
        //sumaPrimasOtros += int.Parse(txtPrimaOtros.Text);
        //Viviana


        txtDocumentoOtros.Text = "";
        txtCedulaOtro.Text = "";
        txtNombreOtro.Text = "";
        txtApellidoOtro.Text = "";
        txtEdadOtro.Text = "";
        txtFechaNacimiento.Text = "";
        grvAmparoOtro.Visible = false;
        btnAdicionarOtrosAsegurados.Enabled = false;

        Session["otrosAsegurados"] = otrosAsegurados;
        Session["dtTemp"] = dtTemp;
        Session["movimientoOtrosAsegurados"] = movimientoOtrosAsegurados;

        //txtPrimaOtros.Enabled=true;
    }
    protected void grvOtrosAsegurados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string movimientoOtrosAsegurados = (string)Session["movimientoOtrosAsegurados"];
        DataTable dtTemp = (DataTable)Session["dtTemp"];
        DataTable otrosAsegurados = (DataTable)Session["otrosAsegurados"];
        movimientoOtrosAsegurados = "MODIFICA";

        dtTemp.Rows.RemoveAt(e.RowIndex);
        otrosAsegurados.Rows.RemoveAt(e.RowIndex);
        grvOtrosAsegurados.DataSource = otrosAsegurados;
        grvOtrosAsegurados.DataBind();

        double primaOtro = double.Parse(txtPrimaOtros.Text);
        primaOtro -= double.Parse(e.Values[6].ToString());
        txtPrimaOtros.Text = primaOtro.ToString();


        sumarPrima(primaOtro);

        Session["otrosAsegurados"] = otrosAsegurados;
        Session["dtTemp"] = dtTemp;
        Session["movimientoOtrosAsegurados"] = movimientoOtrosAsegurados;
    }
    /*---------------------------------------------------------------*/
    protected void botonRegistrarTercero_Click(object sender, EventArgs e)
    {
        AdministrarTercero.InsertarTercero(txtIdentificacion.Text, ddlTipoDocumentoTercero.SelectedValue, txtNombre.Text, txtApellido.Text, DateTime.Parse(txtNacimiento.Text), txtCorreo.Text, ddlGeneroTercero.SelectedValue, ddlDepartamento.SelectedValue, ddlCiudad.SelectedValue, txtCelular.Text, txtTelefono1.Text, txtDireccion.Text, txtTelefono2.Text, ddlOcupacionTercero.SelectedValue, ddlEstadoCivilTercero.SelectedValue,0);
        //limpiar();
    }

    //JC 
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarTercero.ConsultarCiudad(ddlDepartamento.SelectedValue);

        DataTable dt = new DataTable();
        dt = AdministrarTercero.asegurado.sp_ConsultarCiudad();
        ddlCiudad.DataTextField = "ciu_Nombre"; // Cargamos lo que aparece en el ddl
        ddlCiudad.DataValueField = "ciu_Id"; // Cargamos lo que vale por debajo
        ddlCiudad.DataSource = dt;
        ddlCiudad.DataBind();
    }

    //Metodo limpiar. JC
    private void limpiar()
    {
        txtIdentificacion.Text = "";
        //ddlTipoDocumentoTercero.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtNacimiento.Text = "";
        txtEdad.Text = "";
        txtCorreo.Text = "";
        ddlGeneroTercero.Text = "";
        //ddlDepartamento.Text = "";
        //ddlCiudad.Text = "";
        txtCelular.Text = "";
        txtTelefono1.Text = "";
        txtDireccion.Text = "";
        txtTelefono2.Text = "";
    }

    //Método que obtiene variable de sesión /Juan Camilo /27_07_2015
    protected void PasarCertificado_Click(object sender, EventArgs e)
    {
        if ((string)Session["operacionCertificado"] == "modificar")
        {
           //Response.Redirect("ModificarCertificado.aspx");
          Response.RedirectToRoute("modificarCertificado");
        }
        else
        {
            //Response.Redirect("DigitarCertificado.aspx");
            Response.RedirectToRoute("digitarCertificado");
        }
    }

    /*-----------------------------------------------------------------*/

    protected void botonRegistrarTerceroOtros_Click(object sender, EventArgs e)
    {
        AdministrarTercero.InsertarTercero(txtIdentificacionOtros.Text, ddlTipoDocumentoOtros.SelectedValue, txtNombreOtros.Text, txtApellidoOtros.Text, DateTime.Parse(txtNacimientoOtros.Text), txtCorreoOtros.Text, ddlGeneroTerceroOtros.SelectedValue, ddlDepartamentoOtros.SelectedValue, ddlCiudadOtros.SelectedValue, txtCelularOtros.Text, txtTelefono1Otros.Text, txtDireccionOtros.Text, txtTelefono2Otros.Text, ddlOcupacionOtros.SelectedValue, ddlEstadoCivilOtros.SelectedValue,0);
        limpiarOtros();
    }

    //JC 
    protected void ddlDepartamentoOtros_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarTercero.ConsultarCiudad(ddlDepartamentoOtros.SelectedValue);

        DataTable dt = new DataTable();
        dt = AdministrarTercero.asegurado.sp_ConsultarCiudad();
        ddlCiudadOtros.DataTextField = "ciu_Nombre"; // Cargamos lo que aparece en el ddl
        ddlCiudadOtros.DataValueField = "ciu_Id"; // Cargamos lo que vale por debajo
        ddlCiudadOtros.DataSource = dt;
        ddlCiudadOtros.DataBind();
    }

    //Metodo limpiar. JC
    private void limpiarOtros()
    {
        txtIdentificacionOtros.Text = "";
        //ddlTipoDocumentoTercero.Text = "";
        txtNombreOtros.Text = "";
        txtApellidoOtros.Text = "";
        txtNacimientoOtros.Text = "";
        txtEdadOtros.Text = "";
        txtCorreoOtros.Text = "";
        ddlGeneroTerceroOtros.Text = "";
        //ddlDepartamento.Text = "";
        //ddlCiudad.Text = "";
        txtCelularOtros.Text = "";
        txtTelefono1Otros.Text = "";
        txtDireccionOtros.Text = "";
        txtTelefono2Otros.Text = "";
    }

    protected void ConsultarAmparosPlanOtros(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlParentesoOtro.SelectedValue.ToString() != "")
        {
            DataTable dt = new DataTable();
            if ((string)Session["operacionCertificado"] == "modificar")
            {

                int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                dt = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanOtros.SelectedValue.ToString()), int.Parse(txtEdadOtro.Text), 0, ocupacion);
                grvAmparoOtro.DataSource = dt;
                grvAmparoOtro.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btnAdicionarOtrosAsegurados.Enabled = true;
                    grvAmparoOtro.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "RECUERDE QUE SOLO A CONSULTADO EL OTRO ASEGURADO, POR FAVOR PRECIOSE ADICIONAR SI DESEA GUARDAR ESTE REGISTRO" + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE PLAN NO TIENE AMPAROS" + "');", true);
                }
             }
            else
            {
                if (ddlPlanOtros.Text != "" && txtCedulaOtro.Text != "") 
                {
                    grvAmparoOtro.Visible = true;

                    int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                    dt = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(ddlPlanOtros.SelectedValue.ToString()), int.Parse(txtEdadOtro.Text), 0, ocupacion);
                    grvAmparoOtro.DataSource = dt;
                    grvAmparoOtro.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        btnAdicionarOtrosAsegurados.Enabled = true;
                        grvAmparoOtro.Visible = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "RECUERDE QUE SOLO A CONSULTADO EL OTRO ASEGURADO, POR FAVOR PRECIOSE ADICIONAR SI DESEA GUARDAR ESTE REGISTRO" + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE PLAN NO TIENE AMPAROS" + "');", true);
                    }
                 }
              }
            
            grvAmparoOtro.DataSource = dt;
            grvAmparoOtro.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione PARENTESCO" + "');", true);
        }
    }

    protected void grvAmparoExtraPrima_RowEditing(object sender, GridViewEditEventArgs e)
    {

            DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];

            //if (int.Parse(Session["dtExtraprimaPrincipalRestaurar3"].ToString()) != 0)
            //{
            //    //DataTable dtExtraprimaPrincipalRestaurar2 = new DataTable();
            //    dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipalRestaurar2"];
            //    grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
            //    grvAmparoExtraPrima.DataBind();
            //    //Session["dtExtraprimaPrincipalRestaurar2"] = dtExtraprimaPrincipalRestaurar2;

            //}

            grvAmparoExtraPrima.EditIndex = e.NewEditIndex;
            grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
            grvAmparoExtraPrima.DataBind();

            Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
            Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;
        //}
       
      
    }

    protected void grvAmparoExtraPrima_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      
        DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];

        //if (int.Parse(Session["dtExtraprimaPrincipalRestaurar3"].ToString()) != 0)
        //{
        //    Session["dtExtraprimaPrincipalRestaurar3"] = 0;
        //    //DataTable dtExtraprimaPrincipalRestaurar2 = new DataTable();
        //    dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipalRestaurar2"];
        //    grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
        //    grvAmparoExtraPrima.DataBind();
        //    //Session["dtExtraprimaPrincipalRestaurar2"] = dtExtraprimaPrincipalRestaurar2;

        //}

        grvAmparoExtraPrima.EditIndex = -1;
        grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
        grvAmparoExtraPrima.DataBind();



        Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
        Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;
    }

    protected void grvAmparoExtraPrima_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
        DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];
        DataTable dtPlanTieneTasa = new DataTable();
        int rowExtraPrima = int.Parse(Session["rowExtraPrima"].ToString());
        Session["dtExtraprimaPrincipalRestaurar3"] = 0;
        double valorExtraPrimado = 0;
        double totalExtraPrimaP = 0;
        double totalP = 0;
        double totalP3 = 0;
        double valorAmparoExtraPrima = 0;

        int cer_IdNuevo = 0;
        cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
        Session["cerId_ValorNuevo"] = cer_IdNuevo;

        int cer_IdAnterior = 0;
        try
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
        }
        catch
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
        }
        DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
        if (dtCer_IdExtraPrima.Rows.Count > 0)
        {
            cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
        }
     
            int count = 0;
            double valor = 0;
            double tasaAmparoPrincipal = 0;
            double valorAsegurado = 0;

            // foreach que recorre la tabla extra primas
            foreach (GridViewRow row in grvAmparoExtraPrima.Rows)
            {
                //pregunta si la columna de tasa es diferente de vacio
                if (row.Cells[3].Text == "")
                {
                    //pregunta si el campo en el que sew ingresa el porcentaje ya es diferente de vacio
                    if (double.Parse(((TextBox)row.Cells[3].Controls[0]).Text) != 0)
                    {
                        //Valor es la variable que contiene el porcentaje ingresado
                        valor = double.Parse(((TextBox)row.Cells[5].Controls[0]).Text);
                        //Asigna a una variable el valor asegurado
                        valorAsegurado = double.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
                        //contador
                        rowExtraPrima = count;
                    } 
                }
                count++;
            }
            // pregunta cual es la tabla del amparo
            tasaAmparoPrincipal = double.Parse(dtEliminarPrincipal.Rows[rowExtraPrima]["Tasa"].ToString());
            //asigna a una variable tasa una operacion
            double tasa = (tasaAmparoPrincipal * valor) / 100;
            //asigna a una variable tasa una operacion
            valorAmparoExtraPrima = (tasa * valorAsegurado) / 1000000;
            //asiga un campo de el dt que carga la extra prima a una operacion 
            dtExtraprimaPrincipal.Rows[rowExtraPrima]["Prima"] = double.Parse(dtExtraprimaPrincipal.Rows[rowExtraPrima]["Prima"].ToString()) + valorAmparoExtraPrima;
            // variable con operacion para saber cuan es la tasa final
            double valortasaEsperada = (tasaAmparoPrincipal * valor) / 100;
            //asigna campo de el dt a una operacion
            dtExtraprimaPrincipal.Rows[rowExtraPrima]["Tasa"] = valortasaEsperada  + tasaAmparoPrincipal;
            //plasma en la columna porcentaje el porcentaje ingresado por el usuario
            dtExtraprimaPrincipal.Rows[rowExtraPrima]["Porcentaje"] = valor;
          
            grvAmparoExtraPrima.EditIndex = -1;
            grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
            grvAmparoExtraPrima.DataBind();

            //Consulta el historial del cliente pero general
            DataTable dtConsultarHistorialExtraPrima = new DataTable();
            dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
            grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
            grvHistorialExtraPrima.DataBind();

        double consultarHistorialExtraPrima = 0;
        double valorExtraPrima = 0;

        //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
        if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
        {
            // Recorre el dt para consultar los valores de prima y extra prima
            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
            {
                consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
            }
        }

        //recorre tabla de extra prima para la suma de primas
        foreach (DataRow dt in dtExtraprimaPrincipal.Rows)
        {
            valorExtraPrimado += double.Parse(dt[3].ToString());
        }

        totalExtraPrimaP = double.Parse(Session["TotalExtraPrimaP"].ToString());
        if (valorExtraPrimado != 0)
        {
            totalP =  valorAmparoExtraPrima;
        }
        // Asignar variables con valores a los campos de prima y extra prima
        totalP3 = totalP;
       // totalP3 = valorExtraPrima + totalP3;
        if (txtPrincipalExtraprima.Text != "")
        {
           totalP3 = totalP3 + double.Parse(txtPrincipalExtraprima.Text);
        }

        txtPrincipalExtraprima.Text = totalP3.ToString();
        txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text ;
        txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();

        sumarPrima(0);
        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        Session["valorExtraPrimado"] = valorExtraPrimado;
        Session["rowExtraPrima"] = rowExtraPrima;
        Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
        Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
        Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;

    }

    protected void grvExtraPrimaConyuge_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
        DataTable dtPlanTieneTasa = new DataTable();
        Session["dtExtraprimaConyugeRestaurar3"] = 0;
        double valorExtraPrimadoC = 0;
        double totalExtraPrimaC = 0;
        double totalC = 0;
        double totalC3 = 0;
        double valorAmparoExtraPrima = 0;

        int cer_IdNuevo = 0;
        cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
        Session["cerId_ValorNuevo"] = cer_IdNuevo;

        int cer_IdAnterior = 0;

        try
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
        }
        catch
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
        }
        DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
        if (dtCer_IdExtraPrima.Rows.Count > 0)
        {
            cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
        }

        int count = 0;
        double valor = 0;
        double tasaAmparoPrincipal = 0;
        double valorAsegurado = 0;
        int rowExtraPrima = 0;
        // foreach que recorre la tabla extra primas
        foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
        {
            //pregunta si la columna de tasa es diferente de vacio
            if (row.Cells[3].Text == "")
            {
                //pregunta si el campo en el que sew ingresa el porcentaje ya es diferente de vacio
                if (double.Parse(((TextBox)row.Cells[5].Controls[0]).Text) != 0)
                {
                    //Valor es la variable que contiene el porcentaje ingresado
                    valor = double.Parse(((TextBox)row.Cells[5].Controls[0]).Text);
                    //Asigna a una variable el valor asegurado
                    valorAsegurado = double.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
                    //contador
                    rowExtraPrima = count;
                }
            }
            count++;
        }
        // pregunta cual es la tabla del amparo
        tasaAmparoPrincipal = double.Parse(dtEliminarConyuge.Rows[rowExtraPrima]["Tasa"].ToString());
        //asigna a una variable tasa una operacion
        double tasa = (tasaAmparoPrincipal * valor) / 100;
        //asigna a una variable tasa una operacion
        valorAmparoExtraPrima = (tasa * valorAsegurado) / 1000000;
        //asiga un campo de el dt que carga la extra prima a una operacion 
        dtExtraprimaConyuge.Rows[rowExtraPrima]["Prima"] = double.Parse(dtExtraprimaConyuge.Rows[rowExtraPrima]["Prima"].ToString()) + valorAmparoExtraPrima;
        // variable con operacion para saber cuan es la tasa final
        double valortasaEsperada = (tasaAmparoPrincipal * valor) / 100;
        //asigna campo de el dt a una operacion
        dtExtraprimaConyuge.Rows[rowExtraPrima]["Tasa"] = valortasaEsperada + tasaAmparoPrincipal;
        //plasma en la columna porcentaje el porcentaje ingresado por el usuario
        dtExtraprimaConyuge.Rows[rowExtraPrima]["Porcentaje"] = valor;
      
        grvExtraPrimaConyuge.EditIndex = -1;
        grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
        grvExtraPrimaConyuge.DataBind();

        //Consulta el historial del cliente pero general
        DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
        dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
        grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
        grvHistorialExtraPrimaConyuge.DataBind();

        double consultarHistorialExtraPrimaConyuge = 0;
        double valorExtraPrimaConyuge = 0;
        //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
        if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
        {
            // Recorre el dt para consultar los valores de prima y extra prima
            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
            {
                consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
            }
        }

        //recorre tabla de extra prima para la suma de primas
        foreach (DataRow dt in dtExtraprimaConyuge.Rows)
        {
            valorExtraPrimadoC += double.Parse(dt[3].ToString());
        }

        totalExtraPrimaC = double.Parse(Session["TotalExtraPrimaC"].ToString());
        if (valorExtraPrimadoC != 0)
        {
            totalC = valorAmparoExtraPrima;
        }
        // Asignar variables con valores a los campos de prima y extra prima
        totalC3 = totalC;
        //totalC3 = valorExtraPrimaConyuge + totalC3;
        if (txtPrincipalExtraprimaConyuge.Text != "")
        {
            totalC3 = totalC3 + double.Parse(txtPrincipalExtraprimaConyuge.Text);
        }
        txtPrincipalExtraprimaConyuge.Text = totalC3.ToString();
        txtPrincipalExtraprimaConyuge.Text = Math.Round(double.Parse(txtPrincipalExtraprimaConyuge.Text)).ToString();
        txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
        txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();

        sumarPrima(0);

        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        Session["valorExtraPrimadoC"] = valorExtraPrimadoC;
        Session["dtEliminarConyuge"] = dtEliminarConyuge;
        Session["dtExtraprimaPrincipal"] = dtExtraprimaConyuge;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
      
    }

    protected void grvExtraPrimaConyuge_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];

        //if (int.Parse(Session["dtExtraprimaConyugeRestaurar3"].ToString()) != 0)
        //{
        //    Session["dtExtraprimaConyugeRestaurar3"] = 0;

        //    dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyugeRestaurar"];
        //    grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
        //    grvExtraPrimaConyuge.DataBind();

        //}

        grvExtraPrimaConyuge.EditIndex = -1;
        grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
        grvExtraPrimaConyuge.DataBind();
        Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
    }

    protected void grvExtraPrimaConyuge_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];

        
        //if (int.Parse(Session["dtExtraprimaConyugeRestaurar3"].ToString()) != 0)
        //{
        //    //dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyugeRestaurar"];
        //    grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
        //    grvExtraPrimaConyuge.DataBind();
        //}

        grvExtraPrimaConyuge.EditIndex = e.NewEditIndex;
        grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
        grvExtraPrimaConyuge.DataBind();
        Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
    }

    protected void txtPlanPrincipal_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtExtraprimaPrincipalRestaurar = new DataTable();
            DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
           //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            DataTable dtExtraprimaPrincipal = (DataTable)Session["dtExtraprimaPrincipal"];
            DataTable dtPlanTieneTasa = new DataTable();
            Session["totalPrimaGeneralEliminar"] = 0;
            Session["totalValorPrimaEliminar"] = 0;
            double totalPrimaEdad = 0;
            double totalExtraPrimaP = 0;
            double diferenciaValorAsegurado = 0;
            double totalExtraPrimaP3 = 0;
            double primaDt = 0;
            double primaDtGeneral = 0;

            int valorAseguradoPrincipal = 0;
          
            if (txtPlanPrincipal.Text != "")
            {
                valorAseguradoPrincipal = int.Parse(txtPlanPrincipal.Text);
            }
            txtDocumentoConyugue.Enabled = true;
            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
            Session["cerId_ValorNuevo"] = cer_IdNuevo;

            int cer_IdAnterior = 0;
            DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
            if (dtCer_IdExtraPrima.Rows.Count > 0)
            {
                cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
            }

        if (txtPlanPrincipal.Text != "")
        {
            DataTable dtCumuloValor = new DataTable();
            double valorAsegurado = 0;
            //dtCumuloValor = AdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()));
            dtCumuloValor = objAdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));
            //valorAsegurado = AdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()), int.Parse(txtCedulaPrincipal.Text));
            valorAsegurado = objAdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()), int.Parse(txtCedulaPrincipal.Text));
            valorAsegurado = valorAsegurado - double.Parse(Session["valorAseguradoPrincipalResta"].ToString());
            if ((valorAsegurado + double.Parse(txtPlanPrincipal.Text)) <= double.Parse(dtCumuloValor.Rows[0]["cum_Nombre"].ToString()))
            {
               
                    if (txtPlanPrincipal.Text != "")
                    {
                        try
                        {
                             dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
                        }
                        catch
                        {
                              dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
                        }
                        if ((string)Session["operacionCertificado"] == "modificar")
                        {
                            DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
                            DataTable permaneciaAsegurado = new DataTable();
                            int permaneciaAseguradoCertificado = 0;

                            permaneciaAsegurado = objAdministrarCertificados.ConsultarFechaExpedicionCertificadoAnterior(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
                            permaneciaAseguradoCertificado = Funciones.FechaIngresoAsegurado(DateTime.Parse(permaneciaAsegurado.Rows[0]["cer_FechaExpedicion"].ToString()), DateTime.Parse(dtCertificadoFull.Rows[0]["ter_FechaNacimiento"].ToString()));


                            int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                            dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_Id"].ToString()), permaneciaAseguradoCertificado, valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);
                            totalPrimaEdad = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarPrincipal);
                            //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                            dtExtraprimaPrincipal = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_Id"].ToString()), permaneciaAseguradoCertificado, valorAseguradoPrincipal, int.Parse(Session["cer_id"].ToString()), 1, ocupacion, cer_IdAnterior, 1);
                        
                    
                            DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                            dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1);

                            double valorAseguradoExtraPrima = 0;
                            double valorAseguradoDt = 0;
                            double TasaDt = 0;

                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                //Recorrer el dt con el que se lleno la tabla extra prima
                                foreach (DataRow dt in dtExtraprimaPrincipal.Rows)
                                {
                                    //recorrer el dt con los valores del certificado anterior 
                                    foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                                    {
                                        if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                                        {
                                            //asigna el valor asegurado del primer dt a esta variable 
                                            valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                            //asignala tasa del primer dt a esta variable
                                            TasaDt = double.Parse(dt["Tasa"].ToString());
                                            //Asigna esta varible al valor asegurado del segundo dt
                                            valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                            //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                            diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                            //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                            {
                                                // asigna un valor a una session
                                                if (diferenciaValorAsegurado != 0)
                                                {
                                                    Session["diferenciaValorAseguradoP"] = diferenciaValorAsegurado;
                                                }
                                                else
                                                {
                                                    Session["diferenciaValorAseguradoP"] = 0;
                                                }
                                            }
                                            // asigna una variable a un campo del primer dt
                                            dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                            primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                            //asigna la vartiable de prima a un campo del dt
                                            dt["Prima"] = primaDt;
                                        }

                                    }

                                    //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                                    dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                                    foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                                    {
                                        DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                        row2.ItemArray = row.ItemArray;
                                        dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                                    }
                                    // asigna este dt a la session 
                                    //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                                }
                            }
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                            {
                                foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                                {
                                    if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                    {

                                        valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                                    }
                                }
                                foreach (DataRow dt2 in dtExtraprimaPrincipal.Rows)
                                {
                                    if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                                    {

                                        valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                        primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                        TasaDt = double.Parse(dt2["Tasa"].ToString());
                                    }
                                }
                            }
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                            {
                               
                                //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                                dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                                foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                                {
                                    DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                    row2.ItemArray = row.ItemArray;
                                    dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                                }
                                // asigna este dt a la session 

                                //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                            }
                        }
                        else
                        {
                            int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                            //#################################
                            dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(Session["plapol_Id"].ToString()), int.Parse(txtEdadPrincipal.Text), int.Parse(txtPlanPrincipal.Text), ocupacion);
                            dtExtraprimaPrincipal = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(Session["plapol_Id"].ToString()), int.Parse(txtEdadPrincipal.Text), int.Parse(txtPlanPrincipal.Text), ocupacion);
                            dtExtraprimaPrincipalRestaurar = dtExtraprimaPrincipal.Clone();
                            foreach (DataRow row in dtExtraprimaPrincipal.Rows)
                            {
                                DataRow row2 = dtExtraprimaPrincipalRestaurar.NewRow();
                                row2.ItemArray = row.ItemArray;
                                dtExtraprimaPrincipalRestaurar.Rows.Add(row2);
                            }
                            // asigna este dt a la session 
                            //Session["dtExtraprimaPrincipalRestaurar"] = dtExtraprimaPrincipalRestaurar;
                            //la prima que llega de dtEliminarPrincipal se resta con la nueva prima
                        }

                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();

                        double totales = 0;
                        foreach (GridViewRow row in grvAmparoPrincipal.Rows)

                        {
                            totales += Convert.ToDouble(row.Cells[4].Text);
                        }

                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();

                        // Cargar tabla de amparos para ingresar la extraprima
                        grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipal;
                        grvAmparoExtraPrima.DataBind();

                        // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial
                        DataSet dsConsultarHistirialPorcentajeExtraPrimado = new DataSet();
                        dsConsultarHistirialPorcentajeExtraPrimado = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1);

                        DataTable dtConsultarHistirialPorcentajeExtraPrimado = new DataTable();
                        foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimado.Tables)
                        {
                            dtConsultarHistirialPorcentajeExtraPrimado.Merge(dt);
                        }
                        grvConsultarHistirialPorcentajeExtraPrimado.DataSource = dtConsultarHistirialPorcentajeExtraPrimado;
                        grvConsultarHistirialPorcentajeExtraPrimado.DataBind();

                        //Consulta el historial del cliente pero general
                        DataTable dtConsultarHistorialExtraPrima = new DataTable();
                        dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
                        grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
                        grvHistorialExtraPrima.DataBind();

                        double consultarHistorialExtraPrima = 0;
                        double valorExtraPrima = 0;

                        //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                        if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
                        {
                            // Recorre el dt para consultar los valores de prima y extra prima
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                            {
                                consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                                valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
                            }
                          
                        }

                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            primaDt = primaDtGeneral - consultarHistorialExtraPrima;
                        }

                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                        {
                            //recorre tabla de extra prima para la suma de primas 
                            foreach (GridViewRow row in grvAmparoExtraPrima.Rows)
                            {
                                totalExtraPrimaP += Convert.ToDouble(row.Cells[4].Text);
                            }

                            if (totalExtraPrimaP != totalPrimaEdad && (totalPrimaEdad != 0))
                            {
                                totalExtraPrimaP = totalPrimaEdad - consultarHistorialExtraPrima;
                            }
                            // Asignar variables con valores a los campos de prima y extra prima 
                            totalExtraPrimaP3 = totalExtraPrimaP;
                            totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                            txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                            txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                            {
                                txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                if (txtExtraPrimaPrincipal.Text == "")
                                {
                                    txtExtraPrimaPrincipal.Text = "0";
                                }
                                txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                            }
                            else
                            {
                                foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                                {
                                    if (ddlPlanPrincipal.SelectedItem.ToString() == dtConsultarHistorialExtraPrimaForeach["Valor Asegurado"].ToString())
                                    {
                                        txtPrincipalExtraprima.Text = valorExtraPrima.ToString();
                                        txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
                                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                        txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                                    }
                                    else
                                    {
                                        txtPrincipalExtraprima.Text = "0";
                                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                        txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                            {
                                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                                {
                                    totalExtraPrimaP3 = primaDt;
                                    totalExtraPrimaP3 = consultarHistorialExtraPrima + totalExtraPrimaP3;
                                    txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                    txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                    txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                    txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                                }
                                else
                                {
                                    totalExtraPrimaP3 = primaDtGeneral;
                                    txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                    txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                    totalExtraPrimaP = totalExtraPrimaP3;
                                }
                            }
                            else
                            {

                                foreach (GridViewRow row in grvAmparoPrincipal.Rows)
                                {
                                    primaDt += Convert.ToDouble(row.Cells[4].Text);
                                }
                                totalExtraPrimaP3 = primaDt;
                                totalExtraPrimaP = totalExtraPrimaP3;
                                txtPrimaPrincipalExtraprima.Text = totalExtraPrimaP3.ToString();
                                txtPrimaPrincipal.Text = totalExtraPrimaP3.ToString();
                                foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
                                {
                                    if (ddlPlanPrincipal.SelectedItem.ToString() == dtConsultarHistorialExtraPrimaForeach["Valor Asegurado"].ToString())
                                    {
                                        txtPrincipalExtraprima.Text = valorExtraPrima.ToString();
                                        txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
                                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                    }
                                    else
                                    {
                                        txtPrincipalExtraprima.Text = "0";
                                        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;
                                    }
                                }
                            }
                        }

                        int primaPrincipal = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipal.Text)).ToString());
                        txtPrimaPrincipal.Text = primaPrincipal.ToString();
                        int PrimaPrincipalExtraprima = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprima.Text)).ToString());
                        txtPrimaPrincipalExtraprima.Text = PrimaPrincipalExtraprima.ToString();
                        if (txtExtraPrimaPrincipal.Text != "")
                        {
                            int ExtraPrimaPrincipal = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaPrincipal.Text)).ToString());
                            txtExtraPrimaPrincipal.Text = ExtraPrimaPrincipal.ToString();
                            txtExtraPrimaPrincipal.Text = Math.Round(double.Parse(txtExtraPrimaPrincipal.Text)).ToString();
                        }

                    }
                    else
                    {
                        dtEliminarPrincipal.Clear();
                        grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                        grvAmparoPrincipal.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL VALOR DEL PLAN SUPERA EL ACEPTADO POR LA COMPAÑÍA PARA SUS LOS PRODUCTOS" + "');", true);
                }
            }
            else
            {
                dtEliminarPrincipal.Clear();
                grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                grvAmparoPrincipal.DataBind();
            }
            sumarPrima(0);
            if (grvOtrosAsegurados.Rows.Count > 0)
            {
                double totalPrimaOtroAsegurado = 0;
                foreach (GridViewRow row in grvOtrosAsegurados.Rows)
                {
                    totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
                }
                txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

                sumarPrima(int.Parse(txtPrimaOtros.Text));
            }
            Session["dtExtraprimaPrincipal"] = dtExtraprimaPrincipal;
            Session["dtEliminarPrincipal"] = dtEliminarPrincipal;
            Session["TotalExtraPrimaP"] = totalExtraPrimaP;
            Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipal;
            //txtPrimaPrincipal.Enabled = true;
         }
        catch 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione UN PLAN" + "');", true);
        }
    }
    protected void txtPlanConyuge_TextChanged(object sender, EventArgs e)
    {
        try
        {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
        DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        DataTable dtExtraprimaConyugeRestaurar = new DataTable();
        DataTable dtPlanTieneTasa = new DataTable();
        //Session["dtExtraPrimaConyugeGuardarFinal"] = 0;
        Session["totalPrimaGeneralEliminarConyuge"] = 0;
        Session["totalValorPrimaEliminarConyuge"] = 0;
        double totalExtraPrimaC = 0;
        double diferenciaValorAsegurado = 0;
        double totalExtraPrimaC3 = 0;
        double primaDt = 0;
        double primaDtGeneral = 0;
        double totalPrimaEdadConyuge = 0;

        int valorAseguradoConyuge = 0;
       
        if (txtPlanConyuge.Text != "")
        {
            valorAseguradoConyuge = int.Parse(txtPlanConyuge.Text);
        }
        int cer_IdNuevo = 0;
        cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));
        Session["cerId_ValorNuevo"] = cer_IdNuevo;

        int cer_IdAnterior = 0;
        DataTable dtCer_IdExtraPrima = objAdministrarCertificados.ConsultarCertificadosAnteriores(int.Parse(Session["cerId_ValorNuevo"].ToString()));
        if (dtCer_IdExtraPrima.Rows.Count > 0)
        {
            cer_IdAnterior = int.Parse(dtCer_IdExtraPrima.Rows[0]["cer_IdAnterior"].ToString());
        }

        if (txtPlanConyuge.Text != "")
        {
            try
            {
                dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
            }
            catch
            {
                dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
            }
            DataTable dtCumuloValor = new DataTable();
            double valorAsegurado = 0;
            // Cambiar consulta de cúmulos por producto en vez de por compañía
            dtCumuloValor = objAdministrarCertificados.spConsultarCumulo(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));
            //valorAsegurado = AdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["com_Id"].ToString()), int.Parse(txtCedulaConyuge.Text));
            valorAsegurado = objAdministrarCertificados.spConsultarValoresAsegurado(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()), int.Parse(txtCedulaConyuge.Text));
            valorAsegurado = valorAsegurado - double.Parse(Session["valorAseguradoPrincipalResta"].ToString());
            if ((valorAsegurado + double.Parse(txtPlanConyuge.Text)) <= double.Parse(dtCumuloValor.Rows[0]["cum_Nombre"].ToString()))
            {
                if ((string)Session["operacionCertificado"] == "modificar" && dtCer_IdExtraPrima.Rows[0]["idConyuge"].ToString() != "")
                {
                    int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                    dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_IdConyuge"].ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
                    totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);
                    //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
                    dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(Session["plapol_IdConyuge"].ToString()), int.Parse(txtEdadConyuge.Text), valorAseguradoConyuge, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
  

                   DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
                   dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                   double valorAseguradoExtraPrima = 0;
                   double valorAseguradoDt = 0;
                   double TasaDt = 0;

                   if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                   {
                       //Recorrer el dt con el que se lleno la tabla extra prima
                       foreach (DataRow dt in dtExtraprimaConyuge.Rows)
                       {
                           //recorrer el dt con los valores del certificado anterior 
                           foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
                           {
                               //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
                               if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
                               {
                                   //asigna el valor asegurado del primer dt a esta variable 
                                   valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
                                   //asignala tasa del primer dt a esta variable
                                   TasaDt = double.Parse(dt["Tasa"].ToString());
                                   //Asigna esta varible al valor asegurado del segundo dt
                                   valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
                                   //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
                                   diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
                                   //Condicional en el que entra cuando el primer dt este pasando por la final de vida
                                   if (int.Parse(dt["amp_Id"].ToString()) == 1)
                                   {
                                       // asigna un valor a una session
                                       if (diferenciaValorAsegurado != 0)
                                       {
                                           Session["diferenciaValorAseguradoC"] = diferenciaValorAsegurado;
                                       }
                                       else
                                       {
                                           Session["diferenciaValorAseguradoC"] = 0;
                                       }
                                   }
                                   // asigna una variable a un campo del primer dt
                                   dt["Valor Asegurado"] = diferenciaValorAsegurado;
                                   //realiza una operacion para saber el valor de la prima
                                   primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
                                   //asigna la vartiable de prima a un campo del dt
                                   dt["Prima"] = primaDt;

                               }
                           }

                           //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 
                           dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                           foreach (DataRow row in dtExtraprimaConyuge.Rows)
                           {
                               DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                               row2.ItemArray = row.ItemArray;
                               dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                           }

                           // asigna este dt a la session 
                           //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                       }
                   }
                   if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
                   {
                        foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
                        {
                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
                            }
                        }
                        foreach (DataRow dt2 in dtExtraprimaConyuge.Rows)
                        {
                            if (int.Parse(dt2["amp_Id"].ToString()) == 1)
                            {

                                valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
                                primaDtGeneral = double.Parse(dt2["Prima"].ToString());
                                TasaDt = double.Parse(dt2["Tasa"].ToString());
                            }
                        }
                    }
                   if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
                   {
                       //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

                       dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                       foreach (DataRow row in dtExtraprimaConyuge.Rows)
                       {
                           DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                           row2.ItemArray = row.ItemArray;
                           dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                       }
                       // asigna este dt a la session 

                       //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                   }
                }
                else
                {
                    int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
                    dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(Session["plapol_IdConyuge"].ToString()), int.Parse(txtEdadConyuge.Text), int.Parse(txtPlanConyuge.Text), ocupacion);
                    dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlan(int.Parse(Session["plapol_IdConyuge"].ToString()), int.Parse(txtEdadConyuge.Text), int.Parse(txtPlanConyuge.Text), ocupacion);
                    dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
                    foreach (DataRow row in dtExtraprimaConyuge.Rows)
                    {
                        DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
                        row2.ItemArray = row.ItemArray;
                        dtExtraprimaConyugeRestaurar.Rows.Add(row2);
                    }

                    // asigna este dt a la session 
                    //Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
                }

                grvAmparoConyuge.DataSource = dtEliminarConyuge;
                grvAmparoConyuge.DataBind();

                foreach (GridViewRow row in grvAmparoConyuge.Rows)
                {
                }
                double totales = 0;
                foreach (GridViewRow row in grvAmparoConyuge.Rows)
                {
                    totales += Convert.ToDouble(row.Cells[4].Text);
                }

                grvAmparoConyuge.DataSource = dtEliminarConyuge;
                grvAmparoConyuge.DataBind();
                // llena la tabla Extra Prima
                grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
                grvExtraPrimaConyuge.DataBind();


                // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial

                DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
                dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
                foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
                {
                    dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt);
                }
                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();


                //Consulta el historial del cliente pero general
                DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
                grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
                grvHistorialExtraPrimaConyuge.DataBind();

                double consultarHistorialExtraPrimaConyuge = 0;
                double valorExtraPrimaConyuge = 0;

                //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
                if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
                {
                    // Recorre el dt para consultar los valores de prima y extra prima
                    foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                    {
                        consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                        valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
                    }
                }

                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                {
                    primaDt = primaDtGeneral - consultarHistorialExtraPrimaConyuge;
                }

                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
                    {
                        //recorre tabla de extra prima para la suma de primas 
                        foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
                        {
                            totalExtraPrimaC += Convert.ToDouble(row.Cells[4].Text);
                        }

                        if (totalExtraPrimaC != totalPrimaEdadConyuge && (totalPrimaEdadConyuge != 0))
                        {
                            totalExtraPrimaC = totalPrimaEdadConyuge - consultarHistorialExtraPrimaConyuge;
                        }
                        // Asignar variables con valores a los campos de prima y extra prima 
                        totalExtraPrimaC3 = totalExtraPrimaC;
                        totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                            if (txtExtraPrimaConyuge.Text == "")
                            {
                                txtExtraPrimaConyuge.Text = "0";
                            }
                            txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                        }
                        else
                        {
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                            {
                                if (ddlPlanConyuge.SelectedIndex.ToString() == dtConsultarHistorialExtraPrimaForeachConyuge["Valor Asegurado"].ToString())
                                {
                                    txtPrincipalExtraprimaConyuge.Text = valorExtraPrimaConyuge.ToString();
                                    txtPrincipalExtraprimaConyuge.Text = Math.Round(double.Parse(txtPrincipalExtraprimaConyuge.Text)).ToString();
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                }
                                else
                                {
                                    txtPrincipalExtraprimaConyuge.Text = "0";
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                }
                            }
                        }  
                    }
                    else
                    {
                        if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
                        {
                            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
                            {
                                totalExtraPrimaC3 = primaDt;
                                totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                                //txtExtraPrimaPrincipal.Text = txtPrincipalExtraprimaConyuge.Text;
                            }
                            else
                            {
                                totalExtraPrimaC3 = primaDtGeneral;
                                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                                totalExtraPrimaC = totalExtraPrimaC3;
                            }
                        }
                        else
                        {
                            foreach (GridViewRow row in grvAmparoConyuge.Rows)
                            {
                                primaDt += Convert.ToDouble(row.Cells[4].Text);
                            }
                            totalExtraPrimaC3 = primaDt;
                            totalExtraPrimaC = totalExtraPrimaC3;
                            txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
                            txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
                            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
                            {
                                if (ddlPlanConyuge.SelectedIndex.ToString() == dtConsultarHistorialExtraPrimaForeachConyuge["Valor Asegurado"].ToString())
                                {
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                    txtExtraPrimaConyuge.Text = Math.Round(double.Parse(txtExtraPrimaConyuge.Text)).ToString();
                                }
                                else
                                {
                                    txtPrincipalExtraprimaConyuge.Text = "0";
                                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
                                }
                            }
                        }
                    }


                int PrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
                txtPrimaConyuge.Text = PrimaConyuge.ToString();
                int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
                txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
                if (txtExtraPrimaConyuge.Text != "")
                {
                    int ExtraPrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());
                    txtExtraPrimaConyuge.Text = ExtraPrimaConyuge.ToString();
                }
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL VALOR DEL PLAN SUPERA EL ACEPTADO POR LA COMPAÑÍA PARA SUS LOS PRODUCTOS" + "');", true);
            }
        }
        else
        {
            dtEliminarConyuge.Clear();
            grvAmparoConyuge.DataSource = dtEliminarConyuge;
            grvAmparoConyuge.DataBind();
        }
        sumarPrima(0);

        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        Session["dtEliminarConyuge"] = dtEliminarConyuge;
        Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
        Session["TotalExtraPrimaC"] = totalExtraPrimaC;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;

        //Viviana
        //txtPrimaConyuge.Enabled = true;
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "POR FAVOR Seleccione UN PLAN" + "');", true);
        }
    }

    protected void btnSiguienteCertificado_Click(object sender, EventArgs e)
    {

    }
    protected void btnAtrasPrincipal_Click(object sender, EventArgs e)
    {
        btnSiguienteCertificado.Enabled = false;
        ddlLocalidadCertificado.Enabled = true;
        ddlPoliza.Enabled = true;
        txtDeclaracionEG.Enabled = true;
        txtDeclaracionAsegurado.Enabled = true;
        ddlperiodoPagoCertificado.Enabled = true;
    }
    protected void btnSiguientePrincipal_Click(object sender, EventArgs e)
    {
        btnExtraPrima2.Visible = false;
        btnLimpiar.Visible = false;
        btnValidarConyuge.Visible = false;

        if(txtCedulaConyuge.Text != "")
        {
            btnExtraPrima2.Visible = true;
            btnLimpiar.Visible = true;
            btnValidarConyuge.Visible = true;

            btnLimpiar.Visible = true;
        }

    }
    protected void btnAtrasConyuge_Click(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.certificadoPrecargado(int.Parse(Session["cer_Id"].ToString()));
        DataTable otrosAsegurados = (DataTable)Session["otrosAsegurados"];

        txtCedulaConyuge.Text = "";
        txtNombreConyuge.Text = "";
        txtApellidoConyuge.Text = "";
        txtEdadConyuge.Text = "";
        txtPrimaConyuge.Text = "";
        txtExtraPrimaConyuge.Text = "";
        btnCertificadoModal.Enabled = true;
        
        ddlPlanConyuge.Items.Insert(0, new ListItem("", ""));
        ddlPlanConyuge.SelectedIndex = ddlPlanConyuge.Items.IndexOf(ddlPlanConyuge.Items.FindByText(" "));
        ddlPlanConyuge.Enabled = false;

        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
        amparosConyuge.Visible = false;
        dtEliminarConyuge.Clear();
        grvAmparoConyuge.DataSource = dtEliminarConyuge;
        grvAmparoConyuge.DataBind();
        Session["dtEliminarConyuge"] = dtEliminarConyuge;

        DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyuge"];
        beneficiariosConyuge.Visible = false;
        dtBeneficiarioConyuge.Clear();
        grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
        grvBeneficiarioConyuge.DataBind();
        Session["dtBeneficiarioConyuge"] = dtBeneficiarioConyuge;

        otrosAsegurados.Clear();
        DataTable dtTemp = (DataTable)Session["dtTemp"];
        dtTemp.Clear();
        Session["dtTemp"] = dtTemp;

        grvOtrosAsegurados.DataSource = otrosAsegurados;
        grvOtrosAsegurados.DataBind();

        btnSiguientePrincipal.Enabled = false;
        ddlPlanConyuge.Enabled = true;

        if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
        {
            ddlConvenioPrincipal.Enabled = true;
            txtPlanPrincipal.Enabled = true;
            ddlPlantel.Enabled = true;
        }

        if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "8" ||
            objAdministrarCertificados.objCertificadoPre.Producto == "98" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
            || objAdministrarCertificados.objCertificadoPre.Producto == "111" || objAdministrarCertificados.objCertificadoPre.Producto == "15")
        {
            ddlConvenioPrincipal.Enabled = true;
            ddlPlanPrincipal.Enabled = true;
            ddlPlantel.Enabled = true;
        }
        if (objAdministrarCertificados.objCertificadoPre.Producto == "3" || objAdministrarCertificados.objCertificadoPre.Producto == "53"
            || objAdministrarCertificados.objCertificadoPre.Producto == "54" || objAdministrarCertificados.objCertificadoPre.Producto == "55"
                || objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "21"
            || objAdministrarCertificados.objCertificadoPre.Producto == "56")
        {
            ddlConvenioPrincipal.Enabled = true;
            ddlPlanPrincipal.Enabled = true;
            txtpesoPrincipal.Enabled = true;
            txtestaturaPrincipal.Enabled = true;
            ddlPlantel.Enabled = true;
        }

        txtPrimaOtros.Text = "";
        sumarPrima(0);
        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        Session["otrosAsegurados"] = otrosAsegurados;
    }
    protected void btnSiguienteConyuge_Click(object sender, EventArgs e)
    {
 
    }
    protected void btnAtrasOtroAsegurado_Click(object sender, EventArgs e)
    {
        objAdministrarCertificados.certificadoPrecargado(int.Parse(Session["cer_Id"].ToString()));
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
        {
            if (txtCedulaConyuge.Text != "")
            {
                txtPlanConyuge.Enabled = true;
            }
        }

        if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "8" ||
         objAdministrarCertificados.objCertificadoPre.Producto == "98" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
            || objAdministrarCertificados.objCertificadoPre.Producto == "111" || objAdministrarCertificados.objCertificadoPre.Producto == "15")
        {
            if (txtCedulaConyuge.Text != "")
            {
                ddlPlanConyuge.Enabled = true;
            }
        }
        if (objAdministrarCertificados.objCertificadoPre.Producto == "3" || objAdministrarCertificados.objCertificadoPre.Producto == "53"
            || objAdministrarCertificados.objCertificadoPre.Producto == "54" || objAdministrarCertificados.objCertificadoPre.Producto == "55"
                || objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "21"
            || objAdministrarCertificados.objCertificadoPre.Producto == "56")
        {
            ddlPlanConyuge.Enabled = true;
            txtPeso.Enabled = true;
            txtEstatura.Enabled = true;
        }  
    }
    protected void btnValidarCertificado_Click(object sender, EventArgs e)
    {
        if(ddlLocalidadCertificado.SelectedValue != "" && ddlperiodoPagoCertificado.SelectedValue != "" && txtDeclaracionAsegurado.Text 
           != "" && txtDeclaracionEG.Text != "")
        {
            btnSiguienteCertificado.Enabled = true;
            ddlLocalidadCertificado.Enabled = false;
            ddlPoliza.Enabled = false;
            txtDeclaracionEG.Enabled = false;
            txtDeclaracionAsegurado.Enabled = false;
            ddlperiodoPagoCertificado.Enabled = false;
            btnSiguientePrincipal.Enabled = false;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
        }
    }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnValidarPrincipal_Click(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.certificadoPrecargado(int.Parse(Session["cer_Id"].ToString()));
        DataTable dtBeneficiario = (DataTable)Session["dtBeneficiario"];

         int total = 0;
            foreach (DataRow row in dtBeneficiario.Rows)
            {
                total = total + int.Parse(row["Porcentaje"].ToString());
            }
            if (total == 100)
            {
                if (objAdministrarCertificados.objCertificadoPre.Migracion != "3" && objAdministrarCertificados.objCertificadoPre.Migracion != "2")
                {
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                    {

                        if (ddlConvenioPrincipal.SelectedValue != "" && txtPlanPrincipal.Text != "")
                        {
                            btnSiguientePrincipal.Enabled = true;
                            ddlConvenioPrincipal.Enabled = false;
                            txtPlanPrincipal.Enabled = false;
                            btnCertificadoModal.Enabled = true;
                            ddlPlantel.Enabled = false;

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                        }
                    }

                    if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
                         || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                    {
                        if (ddlConvenioPrincipal.SelectedValue != "" && ddlPlanPrincipal.SelectedValue != "")
                        {
                            btnSiguientePrincipal.Enabled = true;
                            ddlConvenioPrincipal.Enabled = false;
                            ddlPlanPrincipal.Enabled = false;
                            ddlPlantel.Enabled = false;
                            btnCertificadoModal.Enabled = true;

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                        }
                    }

                    if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                    {
                        if (ddlConvenioPrincipal.SelectedValue != "" && txtPlanPrincipal.Text != "" && txtpesoPrincipal.Text != ""
                            && txtestaturaPrincipal.Text != "")
                        {
                            double indiceMasaCorporal = 0;
                            indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtpesoPrincipal.Text.ToString()), double.Parse(txtestaturaPrincipal.Text.ToString()));
                            if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                            }
                            else
                            {
                                btnSiguientePrincipal.Enabled = true;
                                ddlConvenioPrincipal.Enabled = false;
                                txtPlanPrincipal.Enabled = false;
                                txtpesoPrincipal.Enabled = false;
                                txtestaturaPrincipal.Enabled = false;
                                ddlPlantel.Enabled = false;
                                btnCertificadoModal.Enabled = true;

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                        }
                    }

                    if (objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "21"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "54" || objAdministrarCertificados.objCertificadoPre.Producto == "55"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "56")
                    {
                        if (ddlConvenioPrincipal.SelectedValue != "" && ddlPlanPrincipal.SelectedValue != "" && txtpesoPrincipal.Text != ""
                            && txtestaturaPrincipal.Text != "")
                        {
                            double indiceMasaCorporal = 0;
                            indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtpesoPrincipal.Text.ToString()), double.Parse(txtestaturaPrincipal.Text.ToString()));
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "9")
                            {
                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                }
                                else
                                {
                                    btnSiguientePrincipal.Enabled = true;
                                    ddlConvenioPrincipal.Enabled = false;
                                    ddlPlanPrincipal.Enabled = false;
                                    txtpesoPrincipal.Enabled = false;
                                    txtestaturaPrincipal.Enabled = false;
                                    ddlPlantel.Enabled = false;
                                    btnCertificadoModal.Enabled = true;

                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                }
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "98")
                            {
                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                }
                                else
                                {
                                    btnSiguientePrincipal.Enabled = true;
                                    ddlConvenioPrincipal.Enabled = false;
                                    ddlPlanPrincipal.Enabled = false;
                                    txtpesoPrincipal.Enabled = false;
                                    txtestaturaPrincipal.Enabled = false;
                                    ddlPlantel.Enabled = false;
                                    btnCertificadoModal.Enabled = true;

                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                }
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56")
                            {
                                
                                if (indiceMasaCorporal < 20 || indiceMasaCorporal > 30)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                }
                                else
                                {
                                    btnSiguientePrincipal.Enabled = true;
                                    ddlConvenioPrincipal.Enabled = false;
                                    ddlPlanPrincipal.Enabled = false;
                                    txtpesoPrincipal.Enabled = false;
                                    txtestaturaPrincipal.Enabled = false;
                                    ddlPlantel.Enabled = false;
                                    btnCertificadoModal.Enabled = true;

                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                }
                                
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "21")
                            {
                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                }
                                else
                                {
                                    btnSiguientePrincipal.Enabled = true;
                                    ddlConvenioPrincipal.Enabled = false;
                                    ddlPlanPrincipal.Enabled = false;
                                    ddlPlantel.Enabled = false;
                                    txtpesoPrincipal.Enabled = false;
                                    txtestaturaPrincipal.Enabled = false;
                                    btnCertificadoModal.Enabled = true;

                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                        }
                    }
                }
                else
                {
                    btnSiguientePrincipal.Enabled = true;
                    btnCertificadoModal.Enabled = true;

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LOS BENEFICIARIOS DEL ASEGURADO PRINCIPAL NO SUMAN EL 100%" + "');", true);
            }
    }

    protected void btnValidarConyuge_Click(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.certificadoPrecargado(int.Parse(Session["cer_Id"].ToString()));
        if(int.Parse(Session["LimpiarConyuge"].ToString()) != 1)
        {
            btnCertificadoModal.Enabled = true;
            int cer_IdNuevo = 0;
            cer_IdNuevo = objAdministrarCertificados.ConsultarIdCertificadoNuevo(int.Parse(Session["ter_Id"].ToString()), int.Parse(Session["pro_Id"].ToString()));


            DataTable dTcasespId = new DataTable();
            dTcasespId = objAdministrarCertificados.ConsultarCasespIdNewCertificado(cer_IdNuevo);
            DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
            DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
            DataTable dtBeneficiarioConyuge = (DataTable)Session["dtBeneficiarioConyuge"];
            int totalBeneficiarioConyuge = 0;
            foreach (DataRow row in dtBeneficiarioConyuge.Rows)
            {
                if (row["Porcentaje"].ToString() != "")
                    totalBeneficiarioConyuge = totalBeneficiarioConyuge + int.Parse(row["Porcentaje"].ToString());
            }

            if (totalBeneficiarioConyuge == 100)
            {

                if (int.Parse(dTcasespId.Rows[0]["casesp_Id"].ToString()) == 4 || int.Parse(dTcasespId.Rows[0]["casesp_Id"].ToString()) == 5 ||
                    int.Parse(dTcasespId.Rows[0]["casesp_Id"].ToString()) == 6)
                {
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                    {

                        if (txtCedulaConyuge.Text != "")
                        {
                            if (txtPlanConyuge.Text != "")
                            {
                                btnSiguienteConyuge.Enabled = true;
                                txtPlanConyuge.Enabled = false;
                                ddlPlantel.Enabled = false;
                                btnCertificadoModal.Enabled = true;

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                            }
                        }
                    }
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
                         || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                    {
                        if (txtCedulaConyuge.Text != "")
                        {
                            if (ddlPlanConyuge.SelectedValue != "")
                            {
                                btnSiguienteConyuge.Enabled = true;
                                ddlPlanConyuge.Enabled = false;
                                ddlPlantel.Enabled = false;
                                btnCertificadoModal.Enabled = true;

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                            }
                        }
                    }
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                    {
                        if (txtCedulaConyuge.Text != "")
                        {
                            if (txtPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                            {
                                double indiceMasaCorporal = 0;
                                indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                }
                                else
                                {
                                    btnSiguienteConyuge.Enabled = true;
                                    txtPlanConyuge.Enabled = false;
                                    txtPeso.Enabled = false;
                                    txtEstatura.Enabled = false;
                                    btnCertificadoModal.Enabled = true;
                                    ddlPlantel.Enabled = false;

                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                            }
                        }
                    }
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                            || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56"
                         || objAdministrarCertificados.objCertificadoPre.Producto == "21")
                    {
                        if (txtCedulaConyuge.Text != "")
                        {
                            if (ddlPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                            {
                                double indiceMasaCorporal = 0;
                                indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "9")
                                {
                                    if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                    }
                                    else
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        ddlPlanConyuge.Enabled = false;
                                        txtPeso.Enabled = false;
                                        btnCertificadoModal.Enabled = true;
                                        txtEstatura.Enabled = false;
                                        ddlPlantel.Enabled = false;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "98")
                                {
                                    if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                    }
                                    else
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        ddlPlanConyuge.Enabled = false;
                                        txtPeso.Enabled = false;
                                        txtEstatura.Enabled = false;
                                        ddlPlantel.Enabled = false;
                                        btnCertificadoModal.Enabled = true;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                            || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56")
                                {
                                    if (indiceMasaCorporal < 20 || indiceMasaCorporal > 30)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                    }
                                    else
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        ddlPlanConyuge.Enabled = false;
                                        txtPeso.Enabled = false;
                                        txtEstatura.Enabled = false;
                                        ddlPlantel.Enabled = false;
                                        btnCertificadoModal.Enabled = true;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "21")
                                {
                                    if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                    }
                                    else
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        ddlPlanConyuge.Enabled = false;
                                        txtPeso.Enabled = false;
                                        txtEstatura.Enabled = false;
                                        ddlPlantel.Enabled = false;
                                        btnCertificadoModal.Enabled = true;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                            }
                        }
                    }
                }

                else
                {
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "1" || objAdministrarCertificados.objCertificadoPre.Producto == "3")
                    {
                        try
                        {

                            if (int.Parse(txtPlanPrincipal.Text) >= int.Parse(txtPlanConyuge.Text))
                            {

                                if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                                {

                                    if (txtCedulaConyuge.Text != "")
                                    {
                                        if (txtPlanConyuge.Text != "")
                                        {
                                            btnSiguienteConyuge.Enabled = true;
                                            txtPlanConyuge.Enabled = false;
                                            ddlPlantel.Enabled = false;
                                            btnCertificadoModal.Enabled = true;

                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                        }
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
                                     || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                                    || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                                {
                                    if (txtCedulaConyuge.Text != "")
                                    {
                                        if (ddlPlanConyuge.SelectedValue != "")
                                        {
                                            btnSiguienteConyuge.Enabled = true;
                                            ddlPlanConyuge.Enabled = false;
                                            ddlPlantel.Enabled = false;
                                            btnCertificadoModal.Enabled = true;

                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                        }
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                                {
                                    if (txtCedulaConyuge.Text != "")
                                    {
                                        if (txtPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                                        {
                                            double indiceMasaCorporal = 0;
                                            indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                            if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                            }
                                            else
                                            {
                                                btnSiguienteConyuge.Enabled = true;
                                                txtPlanConyuge.Enabled = false;
                                                txtPeso.Enabled = false;
                                                ddlPlantel.Enabled = false;
                                                txtEstatura.Enabled = false;
                                                btnCertificadoModal.Enabled = true;

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                        }
                                    }
                                }
                                if (objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                                    || objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56"
                                    || objAdministrarCertificados.objCertificadoPre.Producto == "21")
                                {
                                    if (txtCedulaConyuge.Text != "")
                                    {
                                        if (ddlPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                                        {
                                            double indiceMasaCorporal = 0;
                                            indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                            if (objAdministrarCertificados.objCertificadoPre.Producto == "9")
                                            {
                                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                                {
                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                                }
                                                else
                                                {
                                                    btnSiguienteConyuge.Enabled = true;
                                                    ddlPlanConyuge.Enabled = false;
                                                    txtPeso.Enabled = false;
                                                    txtEstatura.Enabled = false;
                                                    ddlPlantel.Enabled = false;
                                                    btnCertificadoModal.Enabled = true;

                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                                }
                                            }
                                            if (objAdministrarCertificados.objCertificadoPre.Producto == "98")
                                            {
                                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                                {
                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                                }
                                                else
                                                {
                                                    btnSiguienteConyuge.Enabled = true;
                                                    ddlPlanConyuge.Enabled = false;
                                                    txtPeso.Enabled = false;
                                                    txtEstatura.Enabled = false;
                                                    ddlPlantel.Enabled = false;
                                                    btnCertificadoModal.Enabled = true;

                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                                }
                                            }
                                            if (objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                                                || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56")
                                            {
                                                if (indiceMasaCorporal < 20 || indiceMasaCorporal > 30)
                                                {
                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                                }
                                                else
                                                {
                                                    btnSiguienteConyuge.Enabled = true;
                                                    ddlPlanConyuge.Enabled = false;
                                                    txtPeso.Enabled = false;
                                                    txtEstatura.Enabled = false;
                                                    ddlPlantel.Enabled = false;
                                                    btnCertificadoModal.Enabled = true;

                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                                }
                                            }
                                            if (objAdministrarCertificados.objCertificadoPre.Producto == "21")
                                            {
                                                if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                                {
                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                                }
                                                else
                                                {
                                                    btnSiguienteConyuge.Enabled = true;
                                                    ddlPlanConyuge.Enabled = false;
                                                    txtPeso.Enabled = false;
                                                    ddlPlantel.Enabled = false;
                                                    txtEstatura.Enabled = false;
                                                    btnCertificadoModal.Enabled = true;

                                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                        }
                                    }
                                }
                            }

                            else
                            {
                                btnCertificadoModal.Enabled = false;
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL CONYUGE NO PUEDE TENER  UN VALOR ASEGURADO MAYOR AL DEL PRINCIPAL" + "');", true);
                            }
                        }
                        catch 
                        { 
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "INGRESE EL PLAN DEL CONYUGE" + "');", true);
                        }
                    }
                    else
                    {
                        if (int.Parse(ddlPlanPrincipal.SelectedItem.ToString()) >= int.Parse(ddlPlanConyuge.SelectedItem.ToString()))
                        {

                            if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                            {

                                if (txtCedulaConyuge.Text != "")
                                {
                                    if (txtPlanConyuge.Text != "")
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        txtPlanConyuge.Enabled = false;
                                        ddlPlantel.Enabled = false;
                                        btnCertificadoModal.Enabled = true;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                    }
                                }
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "2"
                                 || objAdministrarCertificados.objCertificadoPre.Producto == "8" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                            {
                                if (txtCedulaConyuge.Text != "")
                                {
                                    if (ddlPlanConyuge.SelectedValue != "")
                                    {
                                        btnSiguienteConyuge.Enabled = true;
                                        ddlPlanConyuge.Enabled = false;
                                        ddlPlantel.Enabled = false;
                                        btnCertificadoModal.Enabled = true;

                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                    }
                                }
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "3")
                            {
                                if (txtCedulaConyuge.Text != "")
                                {
                                    if (txtPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                                    {
                                        double indiceMasaCorporal = 0;
                                        indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                        if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                        }
                                        else
                                        {
                                            btnSiguienteConyuge.Enabled = true;
                                            txtPlanConyuge.Enabled = false;
                                            ddlPlantel.Enabled = false;
                                            txtPeso.Enabled = false;
                                            txtEstatura.Enabled = false;
                                            btnCertificadoModal.Enabled = true;

                                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                    }
                                }
                            }
                            if (objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56"
                                || objAdministrarCertificados.objCertificadoPre.Producto == "21")
                            {
                                if (txtCedulaConyuge.Text != "")
                                {
                                    if (ddlPlanConyuge.Text != "" && txtPeso.Text != "" && txtEstatura.Text != "")
                                    {
                                        double indiceMasaCorporal = 0;
                                        indiceMasaCorporal = objAdministrarCertificados.CalcularIndiceDeMasaCorporal(double.Parse(txtPeso.Text.ToString()), double.Parse(txtEstatura.Text.ToString()));
                                        if (objAdministrarCertificados.objCertificadoPre.Producto == "9")
                                        {
                                            if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                            }
                                            else
                                            {
                                                btnSiguienteConyuge.Enabled = true;
                                                ddlPlanConyuge.Enabled = false;
                                                txtPeso.Enabled = false;
                                                btnCertificadoModal.Enabled = true;
                                                txtEstatura.Enabled = false;
                                                ddlPlantel.Enabled = false;

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                            }
                                        }
                                        if (objAdministrarCertificados.objCertificadoPre.Producto == "98")
                                        {
                                            if (indiceMasaCorporal < 18 || indiceMasaCorporal > 37)
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                            }
                                            else
                                            {
                                                btnSiguienteConyuge.Enabled = true;
                                                ddlPlanConyuge.Enabled = false;
                                                txtPeso.Enabled = false;
                                                btnCertificadoModal.Enabled = true;
                                                txtEstatura.Enabled = false;
                                                ddlPlantel.Enabled = false;

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                            }
                                        }
                                        if (objAdministrarCertificados.objCertificadoPre.Producto == "53" || objAdministrarCertificados.objCertificadoPre.Producto == "54"
                                       || objAdministrarCertificados.objCertificadoPre.Producto == "55" || objAdministrarCertificados.objCertificadoPre.Producto == "56")
                                        {
                                            if (indiceMasaCorporal < 20 || indiceMasaCorporal > 30)
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                            }
                                            else
                                            {
                                                btnSiguienteConyuge.Enabled = true;
                                                ddlPlanConyuge.Enabled = false;
                                                txtPeso.Enabled = false;
                                                txtEstatura.Enabled = false;
                                                btnCertificadoModal.Enabled = true;
                                                ddlPlantel.Enabled = false;

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                            }
                                        }
                                        if (objAdministrarCertificados.objCertificadoPre.Producto == "21")
                                        {
                                            if (indiceMasaCorporal < 18 || indiceMasaCorporal > 31)
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL INDICE DE MASA CORPORAL DE ESTA PERSONA NO ES ASEGURABLE" + "');", true);
                                            }
                                            else
                                            {
                                                btnSiguienteConyuge.Enabled = true;
                                                ddlPlanConyuge.Enabled = false;
                                                txtPeso.Enabled = false;
                                                txtEstatura.Enabled = false;
                                                ddlPlantel.Enabled = false;
                                                btnCertificadoModal.Enabled = true;

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                                    }
                                }
                            }
                        }

                        else
                        {
                            btnCertificadoModal.Enabled = false;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "EL CONYUGE NO PUEDE TENER  UN VALOR ASEGURADO MAYOR AL DEL PRINCIPAL" + "');", true);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LOS BENEFICIARIOS DEL ASEGURADO CONYUGE NO SUMAN EL 100%" + "');", true);
            }
        }
        else 
        {
            btnLimpiar.Visible = false;
            btnSiguienteConyuge.Enabled = true;
        }

    }
    protected void btnValidarOtroAsegurado_Click(object sender, EventArgs e)
    {
        if ((string)Session["operacionCertificado"] != "modificar")
        {
            if (txtCedulaOtro.Text != "")
            {
                if (ddlPlanOtros.SelectedValue != "" && ddlParentesoOtro.SelectedValue != "")
                {
                    ddlPlanOtros.Enabled = false;
                    ddlParentesoOtro.Enabled = true;

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LA INFORMACIÓN ESTA CORRECTA Y COMPLETA" + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "FALTAN CAMPOS POR LLENAR" + "');", true);
                }
            }
        }
    }
    protected void btnCambiosPreCargue_Click(object sender, EventArgs e)
    {
        if(txtAnexoConversion.Text != "")
           txtAnexoConversion.Enabled = true;

        if (txtHServicio1.Text != "")
            txtHServicio1.Enabled = true;

        if (txtHServicio2.Text != "")
            txtHServicio2.Enabled = true;

        if (txtHServicio3.Text != "")
            txtHServicio3.Enabled = true;

        if (txtAnexoConversion.Text != "" || txtHServicio1.Text != "" || txtHServicio2.Text != "" || txtHServicio3.Text != "")
            btnGuardarCambios.Enabled = true;

        ////////////////////////////////////////////////////////Validacion de campos pre cargue/////////////////////////////////

        if (btnGuardarCambios.Enabled == true)
            btnValidarCertificado.Enabled = false;


        if (txtHServicio1.Text == "")
            ReqtxtHServicio1.Enabled = false;

        if (txtHServicio2.Text == "")
            reqtxtHServicio2.Enabled = false;

        if (txtHServicio3.Text == "")
            reqtxtHServicio3.Enabled = false;

        if (txtAnexoConversion.Text == "")
            reqtxtAnexoConversion.Enabled = false;

        if (btnGuardarCambios.Enabled == false)
            btnValidarCertificado.Enabled = true;
    }
    protected void btnGuardarCambios_Click(object sender, EventArgs e)
    {
        txtAnexoConversion.Enabled = false;
        txtHServicio1.Enabled = false;
        txtHServicio2.Enabled = false;
        txtHServicio3.Enabled = false;
        btnGuardarCambios.Enabled = false;
        btnValidarCertificado.Enabled = true;
        ActualizarCertificadoPreCargado();

    }

    protected int CanceladoPorFechaRetiro()
    {
        DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
        //DateTime fechaRecuperacion = AdministrarCertificados.CertificadoRecuperado(dtCertificadoFull, int.Parse(Session["pro_Id"].ToString()));        
        bool existeFechaRetiro = true;
        DateTime vigenciaFechaRetiro = new DateTime();
        try 
        {
            vigenciaFechaRetiro = DateTime.Parse(dtCertificadoFull.Rows[0]["FechaCartaRetiro"].ToString());
        }
        catch { existeFechaRetiro = false; }
        
        int estado = 0;
        if (existeFechaRetiro == true)
        {
            if (DateTime.Parse(txtFechaExpedicionCertificado.Text) < vigenciaFechaRetiro)
            {
                // Está Cancelado
                estado = 1;
            }
        }
        return estado;
    }

    protected int CertificadoRecuperado()
    {
        DataTable dtCertificadoFull = (DataTable)Session["dtCertificadoFull"];
        bool existeFechaMaxRec = true;
        DateTime fechaMaximaRecuperacion = new DateTime();
        try
        {
            fechaMaximaRecuperacion = DateTime.Parse(dtCertificadoFull.Rows[0]["FechaMaximaRecuperacion"].ToString());
        }
        catch
        {
            existeFechaMaxRec = false;
        }
        int estado = 0;
        if (existeFechaMaxRec == true)
        {
            if (DateTime.Parse(txtFechaExpedicionCertificado.Text) < fechaMaximaRecuperacion)
            {
                //Certificado Recuperado
                estado = 1;
            }
        }
        return estado;
    }
    
    //Viviana evento para cambio de prima del principal por caso especial cambio de intermediario
    protected void txtPrimaPrincipal_TextChanged(object sender, EventArgs e)
    
    {
        //String primaNuevaPrpl;
        //primaNuevaPrpl = txtPrimaPrincipal.Text;
        //DataTable dtEliminarPrincipal = (DataTable)Session["dtEliminarPrincipal"];
        //for (int j = 0; j < dtEliminarPrincipal.Rows.Count; j++)
        //    {
        //        dtEliminarPrincipal.Rows[j]["Prima"] = 0;
        //        dtEliminarPrincipal.Rows[j]["Tasa"] = 0;
        //    }

        //dtEliminarPrincipal.Rows[1]["Prima"] = primaNuevaPrpl;

        //txtPrima.Text = primaNuevaPrpl;
        //Session["dtEliminarPrincipal"] = dtEliminarPrincipal;

    }

    //Viviana evento para cambio de prima conyuge por caso especial cambio de intermediario
    protected void txtPrimaConyuge_TextChanged(object sender, EventArgs e)
    {
        //String primaNuevaCon;
        //primaNuevaCon = txtPrimaConyuge.Text;
        //DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarPrincipal"];
        //for (int j = 0; j < dtEliminarConyuge.Rows.Count; j++)
        //{
        //    dtEliminarConyuge.Rows[j]["Prima"] = 0;
        //    dtEliminarConyuge.Rows[j]["Tasa"] = 0;
        //}

        //dtEliminarConyuge.Rows[1]["Prima"] = primaNuevaCon;

        //sumarPrima();
        //Session["dtEliminarConyuge"] = dtEliminarConyuge;


    }
    //Viviana evento para cambio de prima otros asegurados por caso especial cambio de intermediario
    protected void txtPrimaOtros_TextChanged(object sender, EventArgs e){
      int primaNuevaOtros;
      int primaFinal;
      int primaOtrosAnterior = 0;
        primaNuevaOtros = int.Parse(txtPrimaOtros.Text);
        DataTable dtTemp = (DataTable)Session["dtTemp"];
        dtTemp.Rows[0]["Prima"] = primaNuevaOtros;

       
        sumarPrima(0);
        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }
        primaFinal = (int.Parse(txtPrima.Text)) - (primaOtrosAnterior);
        txtPrima.Text = (primaFinal).ToString();
        Session["dtTemp"] = dtTemp;
}

    // GRACIAS A ESTE METODO SE PUEDE LLENAR EL DROPDOWNLIST QUE SE ENCUENTRA EN EL GRID DE BENEFICIARIOS PRINCIPAL 
    protected void grvBeneficiarioPrincipal_OnDataBound(object sender, EventArgs e)
    {
        //DropDownList ddlNewParentesco = ((DropDownList)grvBeneficiarioPrincipal.FindControl("txtNewParentesco"));
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DropDownList ddl = grvBeneficiarioPrincipal.FooterRow.FindControl("txtNewParentesco") as DropDownList;
        //DropDownList ddl = (DropDownList)e.Row.TemplateControl.FindControl("txtNewParentesco");
        // SE CONSULTAN EN ESTAS LINEAS DE CODIGO EL PRODUCTO QUE POSEE EL CERTIFICADO
        int cer_Id = int.Parse(Session["cer_id"].ToString());
        DataTable dtEncabezadoCertificado = new DataTable();
        dtEncabezadoCertificado = objAdministrarCertificados.spConsultarEncabezadoCertificado(cer_Id);

        //SE CONSULTAN LOS PARENTESCOS QUE PERMITE TENER ESTE PRODUCTO
        DataTable dtconsultarParentescoBeneficiarioPrincipal = new DataTable();
        dtconsultarParentescoBeneficiarioPrincipal = objAdministrarCertificados.consultarParentescoBeneficiario(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));

        // SE LLENA DROPDAWNLIST CON SU RESPECTIVA INFORMACIÓN
        ddl.DataSource = dtconsultarParentescoBeneficiarioPrincipal;
        ddl.DataValueField = dtconsultarParentescoBeneficiarioPrincipal.Columns["par_Id"].ToString();
        ddl.DataTextField = dtconsultarParentescoBeneficiarioPrincipal.Columns["par_Nombre"].ToString();
        ddl.DataBind();
        
        ddl.Attributes.Add("onclick", "localStorage.setItem('accIndex', 0);");

    }

    protected void grvBeneficiarioConyuge_OnDataBound(object sender, EventArgs e)
    {
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        try
        {
            //DropDownList ddlNewParentesco = ((DropDownList)grvBeneficiarioPrincipal.FindControl("txtNewParentesco"));

            DropDownList ddl = grvBeneficiarioConyuge.FooterRow.FindControl("ddlNewParentesco") as DropDownList;

            //DropDownList ddl = (DropDownList)e.Row.TemplateControl.FindControl("txtNewParentesco");


            // SE CONSULTAN EN ESTAS LINEAS DE CODIGO EL PRODUCTO QUE POSEE EL CERTIFICADO
            int cer_Id = int.Parse(Session["cer_id"].ToString());
            DataTable dtEncabezadoCertificado = new DataTable();
            dtEncabezadoCertificado = objAdministrarCertificados.spConsultarEncabezadoCertificado(cer_Id);

            //SE CONSULTAN LOS PARENTESCOS QUE PERMITE TENER ESTE PRODUCTO
            DataTable dtconsultarParentescoBeneficiarioPrincipal = new DataTable();
            dtconsultarParentescoBeneficiarioPrincipal = objAdministrarCertificados.consultarParentescoBeneficiario(int.Parse(dtEncabezadoCertificado.Rows[0]["pro_Id"].ToString()));

            // SE LLENA DROPDAWNLIST CON SU RESPECTIVA INFORMACIÓN
            ddl.DataSource = dtconsultarParentescoBeneficiarioPrincipal;
            ddl.DataValueField = dtconsultarParentescoBeneficiarioPrincipal.Columns["par_Id"].ToString();
            ddl.DataTextField = dtconsultarParentescoBeneficiarioPrincipal.Columns["par_Nombre"].ToString();
            ddl.DataBind();
            
            ddl.Attributes.Add("onclick", "localStorage.setItem('accIndex', 0);");
        }
        catch { }
    }

    // este boton tiene la funcion de restaurar la tabla de extra prima conyuge cuando se observe algun error cometido
    protected void btnX_Click(object sender, EventArgs e)
    {
        double valorExtraPrimado = 0;
        double totalExtraPrimaP = 0;
        double totalP = 0;
        double totalP3 = 0;
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        // Session que funciona como una bandera para realizar una operación posterior a esta 
        Session["dtExtraprimaPrincipalRestaurar3"] = 1;

        // En este dt se almacena la información incicial para la restauración
        DataTable dtExtraprimaPrincipalRestaurar2 = new DataTable();
        dtExtraprimaPrincipalRestaurar2 = (DataTable)Session["dtExtraprimaPrincipalRestaurar"];
        grvAmparoExtraPrima.DataSource = dtExtraprimaPrincipalRestaurar2;
        grvAmparoExtraPrima.DataBind();

        Session["dtExtraprimaPrincipalRestaurar2"] = dtExtraprimaPrincipalRestaurar2;
        Session["dtExtraPrimaPrincipalGuardarFinal"] = dtExtraprimaPrincipalRestaurar2;

        //Consultar el historial del cliente en los certificados anteriores
        DataTable dtConsultarHistorialExtraPrima = new DataTable();
        dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
        grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
        grvHistorialExtraPrima.DataBind();

        double consultarHistorialExtraPrima = 0;
        double valorExtraPrima = 0;

        // foreach para recorrer el dt con la informacion almacenada anteriormente
        //e ir sumando las primas que se encuentran dentro de ellas en una variable
        if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
        {
            foreach (DataRow dtConsultarHistorialExtraPrimaForeach in dtConsultarHistorialExtraPrima.Rows)
            {
                consultarHistorialExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Prima"].ToString());
                valorExtraPrima += double.Parse(dtConsultarHistorialExtraPrimaForeach["Extra Prima"].ToString());
            }
        }

        //foreach que reccorre la tabla de extra primas con la diferencia para ir sumando las primas 
        if (dtExtraprimaPrincipalRestaurar2 != null)
        {
            foreach (DataRow dt in dtExtraprimaPrincipalRestaurar2.Rows)
            {
                valorExtraPrimado += double.Parse(dt[3].ToString());
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione DE NUEVO EL PLAN SI DESEA EXTRA PRIMAR A ESTA PERSONA" + "');", true);
        }

        //encontra el aumento por extra prima
        totalExtraPrimaP = double.Parse(Session["TotalExtraPrimaP"].ToString());
        if (valorExtraPrimado != 0)
        {
            totalP = 0;
        }

        // asignar valores
        totalP3 = totalP;
        totalP3 = valorExtraPrima + totalP3;
        txtPrincipalExtraprima.Text = totalP3.ToString();
        txtPrincipalExtraprima.Text = Math.Round(double.Parse(txtPrincipalExtraprima.Text)).ToString();
        txtExtraPrimaPrincipal.Text = txtPrincipalExtraprima.Text;

        sumarPrima(0);
        if (grvOtrosAsegurados.Rows.Count > 0)
        {
            double totalPrimaOtroAsegurado = 0;
            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
            {
                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
            }
            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

            sumarPrima(int.Parse(txtPrimaOtros.Text));
        }

        Session["valorExtraPrimado"] = 0;
  
    }

    // este boton tiene la funcion de restaurar la tabla de extra prima conyuge cuando se observe algun error cometido
    protected void btnX2_Click(object sender, EventArgs e)
    {

        double totalExtraPrimaC = 0;
        double totalExtraPrimaC3 = 0;
        double valorExtraPrimado = 0;
        double totalC = 0;
        DataTable dtPlanTieneTasa = new DataTable();
       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        // Session que funciona como una bandera para realizar una operación posterior a esta 
        Session["dtExtraprimaConyugeRestaurar3"] = 1;
        try
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanPrincipal.SelectedValue.ToString()));
        }
        catch
        {
            dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(Session["plapol_Id"].ToString()));
        }
        // En este dt se almacena la información incicial para la restauración
        DataTable dtExtraprimaConyugeRestaurar2 = new DataTable();
        dtExtraprimaConyugeRestaurar2 = (DataTable)Session["dtExtraprimaConyugeRestaurar"];
        grvExtraPrimaConyuge.DataSource = dtExtraprimaConyugeRestaurar2;
        grvExtraPrimaConyuge.DataBind();

        Session["dtExtraprimaPrincipalRestaurar2"] = dtExtraprimaConyugeRestaurar2;
        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyugeRestaurar2;


        //Consultar el historial del cliente en los certificados anteriores
        DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
        dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
        grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
        grvHistorialExtraPrimaConyuge.DataBind();

        double consultarHistorialExtraPrimaConyuge = 0;
        double valorExtraPrimaConyuge = 0;

        // foreach para recorrer el dt con la informacion almacenada anteriormente
        //e ir sumando las primas que se encuentran dentro de ellas en una variable
        if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
        {
            foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
            {
                consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
                valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
            }
        }

        //foreach que reccorre la tabla de extra primas con la diferencia para ir sumando las primas 
        if (dtExtraprimaConyugeRestaurar2 != null)
        {
            foreach (DataRow dt in dtExtraprimaConyugeRestaurar2.Rows)
            {
                valorExtraPrimado += Convert.ToDouble(dt[3].ToString());
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione DE NUEVO EL PLAN SI DESEA EXTRA PRIMAR A ESTA PERSONA" + "');", true);
        }

        //encontra el aumento por extra prima
        totalExtraPrimaC = double.Parse(Session["TotalExtraPrimaC"].ToString());
        if (totalExtraPrimaC != 0)
        {
            totalC = 0;
        }

        // asignar valores
        totalExtraPrimaC3 = totalC;
        totalExtraPrimaC3 = valorExtraPrimaConyuge + totalC;
        txtPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
        txtPrincipalExtraprimaConyuge.Text = Math.Round(double.Parse(txtPrincipalExtraprimaConyuge.Text)).ToString();
        txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
        Session["valorExtraPrimadoC"] = 0;
      
    }
   // ReestructurarExtraPrimaConyuge()
    //public void ConsultarPrimaConyuge2()
    //{
    //    try
    //    {
    //        DataTable dtEliminarConyuge = (DataTable)Session["dtEliminarConyuge"];
    //        DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
    //        DataTable dtExtraprimaConyuge = (DataTable)Session["dtExtraprimaConyuge"];
    //       //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    //        DataTable dtExtraprimaConyugeRestaurar = new DataTable();
    //        Session["totalPrimaGeneralEliminarConyuge"] = 0;
    //        Session["totalValorPrimaEliminarConyuge"] = 0;
    //        double totalExtraPrimaC = 0;
    //        DataTable dtCumuloValorConyuge = new DataTable();
    //        double totalPrimaEdadConyuge = 0;
    //        double totalExtraPrimaC3 = 0;
    //        double primaDt = 0;
    //        double primaDtGeneral = 0;
    //        double diferenciaValorAsegurado = 0;

    //        if (ddlPlanConyuge.SelectedValue.ToString() != "")
    //        {
    //            DataTable dtPlanTieneTasa = objAdministrarCertificados.ConsultarTasaPlanesPoliza(int.Parse(ddlPlanConyuge.SelectedValue.ToString()));

    //            int ocupacion = int.Parse(ddlOcupacionPrincipal.SelectedValue.ToString());
    //            dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), 0, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
    //            totalPrimaEdadConyuge = objAdministrarCertificados.ReestructurarPrimasPorEdad(dtEliminarConyuge);
    //            //Cargar un dt con la informacion que posteriormente iria a la tabla extra prima
    //            dtExtraprimaConyuge = objAdministrarCertificados.consultarAmparosPorPlanPermanencia(int.Parse(ddlPlanConyuge.SelectedValue.ToString()), int.Parse(txtEdadConyuge.Text), 0, int.Parse(Session["cer_id"].ToString()), 2, ocupacion, cer_IdAnterior, 2);
    //            //grvAmparoConyuge.DataSource = dtEliminarConyuge;
    //            //grvAmparoConyuge.DataBind(); 

    //            DataTable dtConsultarValorAseguradoExtraPrima = new DataTable();
    //            dtConsultarValorAseguradoExtraPrima = objAdministrarCertificados.ConsultarValorAseguradoExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

    //            double valorAseguradoExtraPrima = 0;
    //            double valorAseguradoDt = 0;
    //            double TasaDt = 0;

    //            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
    //            {
    //                //Recorrer el dt con el que se lleno la tabla extra prima
    //                foreach (DataRow dt in dtExtraprimaConyuge.Rows)
    //                {
    //                    //recorrer el dt con los valores del certificado anterior 
    //                    foreach (DataRow dt2 in dtConsultarValorAseguradoExtraPrima.Rows)
    //                    {
    //                        //condicional que pregunta cuando los nombres de los dos dt coinciden en el nombre
    //                        if (dt["amp_Id"].ToString() == dt2["amp_Id"].ToString())
    //                        {
    //                            //asigna el valor asegurado del primer dt a esta variable 
    //                            valorAseguradoDt = double.Parse(dt["Valor Asegurado"].ToString());
    //                            //asignala tasa del primer dt a esta variable
    //                            TasaDt = double.Parse(dt["Tasa"].ToString());
    //                            //Asigna esta varible al valor asegurado del segundo dt
    //                            valorAseguradoExtraPrima = double.Parse(dt2["ampcer_ValAsegurado"].ToString());
    //                            //Resta el valor de la primera variable contra valorAseguradoExtraPrima y se la asigna a una variable
    //                            diferenciaValorAsegurado = valorAseguradoDt - valorAseguradoExtraPrima;
    //                            //Condicional en el que entra cuando el primer dt este pasando por la final de vida
    //                            if (int.Parse(dt["amp_Id"].ToString()) == 1)
    //                            {
    //                                // asigna un valor a una session
    //                                if (diferenciaValorAsegurado != 0)
    //                                {
    //                                    Session["diferenciaValorAseguradoC"] = diferenciaValorAsegurado;
    //                                }
    //                                else
    //                                {
    //                                    Session["diferenciaValorAseguradoC"] = 0;
    //                                }
    //                            }
    //                            // asigna una variable a un campo del primer dt
    //                            dt["Valor Asegurado"] = diferenciaValorAsegurado;
    //                            //realiza una operacion para saber el valor de la prima
    //                            primaDt = (TasaDt * diferenciaValorAsegurado) / 1000000;
    //                            //asigna la vartiable de prima a un campo del dt
    //                            dt["Prima"] = primaDt;
    //                        }
    //                    }
    //                    //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

    //                    dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
    //                    foreach (DataRow row in dtExtraprimaConyuge.Rows)
    //                    {
    //                        DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
    //                        row2.ItemArray = row.ItemArray;
    //                        dtExtraprimaConyugeRestaurar.Rows.Add(row2);
    //                    }
    //                    // asigna este dt a la session 
    //                    Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
    //                }
    //            }
    //            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "0")
    //            {
    //                foreach (DataRow dt in dtConsultarValorAseguradoExtraPrima.Rows)
    //                {
    //                    if (int.Parse(dt["amp_Id"].ToString()) == 1)
    //                    {

    //                        valorAseguradoExtraPrima = double.Parse(dt["ampcer_ValAsegurado"].ToString());
    //                    }
    //                }
    //                foreach (DataRow dt2 in dtExtraprimaConyuge.Rows)
    //                {
    //                    if (int.Parse(dt2["amp_Id"].ToString()) == 1)
    //                    {

    //                        valorAseguradoDt = double.Parse(dt2["Valor Asegurado"].ToString());
    //                        primaDtGeneral = double.Parse(dt2["Prima"].ToString());
    //                        TasaDt = double.Parse(dt2["Tasa"].ToString());
    //                    }
    //                }
    //            }
    //            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "2")
    //            {
    //                //Crea un dt nuevo el cual sera un clon de la tabla extra prima fila por fila 

    //                dtExtraprimaConyugeRestaurar = dtExtraprimaConyuge.Clone();
    //                foreach (DataRow row in dtExtraprimaConyuge.Rows)
    //                {
    //                    DataRow row2 = dtExtraprimaConyugeRestaurar.NewRow();
    //                    row2.ItemArray = row.ItemArray;
    //                    dtExtraprimaConyugeRestaurar.Rows.Add(row2);
    //                }
    //                // asigna este dt a la session 

    //                Session["dtExtraprimaConyugeRestaurar"] = dtExtraprimaConyugeRestaurar;
    //            }
    //            double totales = 0;
    //            foreach (GridViewRow row in grvAmparoConyuge.Rows)
    //            {
    //                totales += Convert.ToDouble(row.Cells[4].Text);
    //            }
    //            //txtPrimaConyuge.Text = Convert.ToString(totales);

    //            grvAmparoConyuge.DataSource = dtEliminarConyuge;
    //            grvAmparoConyuge.DataBind();
    //            // Extra Prima
    //            grvExtraPrimaConyuge.DataSource = dtExtraprimaConyuge;
    //            grvExtraPrimaConyuge.DataBind();

    //            // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial

    //            DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
    //            dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

    //            DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
    //            foreach (DataTable dt in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
    //            {
    //                dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt);
    //            }
    //            grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
    //            grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();

    //            //Consulta el historial del cliente pero general
    //            DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
    //            dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
    //            grvHistorialExtraPrimaConyuge.DataSource = dtConsultarHistorialExtraPrimaConyuge;
    //            grvHistorialExtraPrimaConyuge.DataBind();


    //            double consultarHistorialExtraPrimaConyuge = 0;
    //            double valorExtraPrimaConyuge = 0;

    //            //Condicional en el cual entra si el cliente ya tiene un historial damparos  para asignar valores
    //            if (dtConsultarHistorialExtraPrimaConyuge.Rows.Count > 0)
    //            {
    //                // Recorre el dt para consultar los valores de prima y extra prima
    //                foreach (DataRow dtConsultarHistorialExtraPrimaForeachConyuge in dtConsultarHistorialExtraPrimaConyuge.Rows)
    //                {
    //                    consultarHistorialExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Prima"].ToString());
    //                    valorExtraPrimaConyuge += double.Parse(dtConsultarHistorialExtraPrimaForeachConyuge["Extra Prima"].ToString());
    //                }

    //            }

    //            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
    //            {
    //                primaDt = primaDtGeneral - consultarHistorialExtraPrimaConyuge;
    //            }

    //            if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1" || (string)Session["operacionCertificado"] != "modificar")
    //            {
    //                //recorre tabla de extra prima para la suma de primas 
    //                foreach (GridViewRow row in grvExtraPrimaConyuge.Rows)
    //                {
    //                    totalExtraPrimaC += Convert.ToDouble(row.Cells[4].Text);
    //                }

    //                if (totalExtraPrimaC != totalPrimaEdadConyuge && (totalPrimaEdadConyuge != 0))
    //                {
    //                    totalExtraPrimaC = totalPrimaEdadConyuge - consultarHistorialExtraPrimaConyuge;
    //                }
    //                // Asignar variables con valores a los campos de prima y extra prima 
    //                totalExtraPrimaC3 = totalExtraPrimaC;
    //                totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
    //                txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
    //            }
    //            else
    //            {
    //                if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() != "2")
    //                {
    //                    if (dtPlanTieneTasa.Rows[0]["plan_TieneTasa"].ToString() == "1")
    //                    {
    //                        totalExtraPrimaC3 = primaDt;
    //                        totalExtraPrimaC3 = consultarHistorialExtraPrimaConyuge + totalExtraPrimaC3;
    //                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                        txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
    //                    }
    //                    else
    //                    {
    //                        totalExtraPrimaC3 = primaDtGeneral;
    //                        txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                        txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                        totalExtraPrimaC = totalExtraPrimaC3;
    //                    }
    //                }
    //                else
    //                {
    //                    foreach (GridViewRow row in grvAmparoConyuge.Rows)
    //                    {
    //                        primaDt += Convert.ToDouble(row.Cells[4].Text);
    //                    }
    //                    totalExtraPrimaC3 = primaDt;
    //                    totalExtraPrimaC = totalExtraPrimaC3;
    //                    txtPrimaPrincipalExtraprimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                    txtPrimaConyuge.Text = totalExtraPrimaC3.ToString();
    //                    txtExtraPrimaConyuge.Text = txtPrincipalExtraprimaConyuge.Text;
    //                }
    //            }

    //            int PrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaConyuge.Text)).ToString());
    //            txtPrimaConyuge.Text = PrimaConyuge.ToString();
    //            int PrimaPrincipalExtraprimaConyuge = int.Parse(Math.Round(decimal.Parse(txtPrimaPrincipalExtraprimaConyuge.Text)).ToString());
    //            txtPrimaPrincipalExtraprimaConyuge.Text = PrimaPrincipalExtraprimaConyuge.ToString();
    //            if (txtExtraPrimaConyuge.Text != "")
    //            {
    //                int ExtraPrimaConyuge = int.Parse(Math.Round(decimal.Parse(txtExtraPrimaConyuge.Text)).ToString());
    //                txtExtraPrimaConyuge.Text = ExtraPrimaConyuge.ToString();
    //            }
    //        }
    //        else
    //        {
    //            dtEliminarConyuge.Clear();
    //            grvAmparoConyuge.DataSource = dtEliminarConyuge;
    //            grvAmparoConyuge.DataBind();
    //        }
    //        double totalPrimaOtroAsegurado = 0;
    //        sumarPrima(0);

    //        if (grvOtrosAsegurados.Rows.Count > 0)
    //        {
    //            foreach (GridViewRow row in grvOtrosAsegurados.Rows)
    //            {
    //                totalPrimaOtroAsegurado += Convert.ToDouble(row.Cells[7].Text);
    //            }
    //            txtPrimaOtros.Text = totalPrimaOtroAsegurado.ToString();

    //            sumarPrima(int.Parse(txtPrimaOtros.Text));
    //        }

    //        Session["dtEliminarConyuge"] = dtEliminarConyuge;
    //        Session["dtExtraprimaConyuge"] = dtExtraprimaConyuge;
    //        Session["TotalExtraPrimaC"] = totalExtraPrimaC;
    //        Session["dtExtraPrimaConyugeGuardarFinal"] = dtExtraprimaConyuge;
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "LO SENTIMOS SE HA PRODUCIDO UN ERROR" + "');", true);
    //    }
    //}
}//totalExtraPrimaC = totalExtraPrimaC3;
