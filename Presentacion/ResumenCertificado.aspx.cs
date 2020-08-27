using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_ResumenCertificado : System.Web.UI.Page
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


    public  string poliza;
    public  DataTable dt = new DataTable();
    public  DataTable otrosAsegurados = new DataTable();
    public  DataTable dtConyuge = new DataTable();
    public  DataTable dtTemp;
    public  DataTable dtTempOtrosAsegurados;
    public  List<Asegurado> beneficiario = new List<Asegurado>();
    public  List<Asegurado> beneficiarioConyuge = new List<Asegurado>();
    public  int extraPrima = 0;
    public  int extraPrimaConyuge = 0;
    public  DataTable dtBeneficiario = new DataTable();
    public  DataTable dtBeneficiarioConyuge = new DataTable();
    public  DataTable dtEliminarPrincipal = new DataTable();
    public  DataTable dtEliminarConyuge = new DataTable();
    public  int cer_Id;
    public  int primaOtroAsegurado = 0;
    DataTable dtCertificadoFull = new DataTable();
    DataTable dtOtroAsegurado = new DataTable();
    DataTable dtEncabezadoCertificado = new DataTable(); //JC 22-09-2015
    DataTable dtTodos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();
   
        
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
        txtCedulaConyuge.Enabled = false;
        txtNombreConyuge.Enabled = false;
        txtApellidoConyuge.Enabled = false;
        txtEdadConyuge.Enabled = false;
        txtPrimaConyuge.Enabled = false;
        txtPrima.Enabled = false;
        txtPrimaConyuge.Enabled = false;
        txtPrimaPrincipal.Enabled = false;
        txtFechaDigitacionCertificado.Enabled = false;
        ddlperiodoPagoCertificado.Enabled = false;
        ddlLocalidadCertificado.Enabled = false;
        ddlPoliza.Enabled = false;
        txtDeclaracionAsegurado.Enabled = false;
        txtDeclaracionEG.Enabled = false;
        ddlConvenioPrincipal.Enabled = false;
        ddlPlanPrincipal.Enabled = false;
        ddlPlanConyuge.Enabled = false;
        txtPlanPrincipal.Enabled = false;
        txtPlanConyuge.Enabled = false;
        txtPeso.Enabled = false;
        txtpesoPrincipal.Enabled = false;
        txtEstatura.Enabled = false;
        txtestaturaPrincipal.Enabled = false;
        ddlPlantel.Enabled = false;

        //Campos extra prima
        txtExtraPrimaPrincipal.Enabled = false;
        txtExtraPrimaConyuge.Enabled = false;
        txtPrimaPrincipalExtraprima.Enabled = false;
        txtPrincipalExtraprimaConyuge.Enabled = false;
        txtPrimaPrincipalExtraprimaConyuge.Enabled = false;
        txtPrincipalExtraprima.Enabled = false;
        chkExtraprimadoPrincipal.Enabled = false;
        chkExtraprimadoPrincipal.Checked = false;
        chkExtraprimadoConyuge.Enabled = false;
        chkExtraprimadoConyuge.Checked = false;
        
        grvAmparoOtro.Visible = false;

        if (!IsPostBack)
        {

            reqtxtPlanPrincipal.Enabled = false;
            txtPlanPrincipal.Visible = false;
            reqtxtPlanConyuge.Enabled = false;
            txtPlanConyuge.Visible = false;
            lblPlan.Visible = false;
            labPlan.Visible = false;
            txtHServicio1.Enabled = false;
            txtHServicio2.Enabled = false;
            txtHServicio3.Enabled = false;
            txtAnexoConversion.Enabled = false;
        }

        if (!IsPostBack)
        {
            dtBeneficiario = new DataTable();
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

            grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
            grvBeneficiarioPrincipal.DataBind();
            grvBeneficiarioPrincipal.Enabled = true;

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

            grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
            grvBeneficiarioConyuge.DataBind();
            grvBeneficiarioConyuge.Enabled = true;


            otrosAsegurados = new DataTable();
            if (!IsPostBack)
            {
                dtTemp = new DataTable();

                dtCertificadoFull = objAdministrarCertificados.consultarCertificadoResumen(int.Parse(Session["cer_Id"].ToString()));

                if(dtCertificadoFull.Rows.Count != 0)
                {
                    if(dtCertificadoFull.Rows[0]["cer_Extr"].ToString() == "SI")
                        chkExtraprimadoPrincipal.Checked = true;
                }

            }
            if (int.Parse(dtCertificadoFull.Rows[0]["com_Id"].ToString()) == 6 || int.Parse(dtCertificadoFull.Rows[0]["com_Id"].ToString()) == 4)
            {
                Session["banderaExtraPrima"] = 1;
            }
            else
            {
                Session["banderaExtraPrima"] = 0;
            }
            int Edad = 0;

            if (!IsPostBack)
            {
                //// Todos
                objAdministrarCertificados.certificadoPrecargadoResumen(int.Parse(Session["cer_Id"].ToString()));

                txtAgencia.Text = objAdministrarCertificados.objCertificadoPre.Agencia;
                txtFechaExpedicionCertificado.Text = objAdministrarCertificados.objCertificadoPre.FechaExpedicion.ToString("yyyy-MM-dd");
                txtFechaVigenciaCertificado.Text = objAdministrarCertificados.objCertificadoPre.Vigencia.ToString("yyyy-MM-dd");
                txtCertificado.Text = objAdministrarCertificados.objCertificadoPre.NumeroCertificado;
                txtNombreAsesor.Text = objAdministrarCertificados.objCertificadoPre.NombreAsesor;
                ddlperiodoPagoCertificado.Items.Add(objAdministrarCertificados.objCertificadoPre.PeriodoPagoNombre);
                ddlConvenioPrincipal.Items.Add(objAdministrarCertificados.objCertificadoPre.ConvenioNombre);
                txtNombrePrincipal.Text = objAdministrarCertificados.objAseguradoPre.Nombres;
                txtApellidoPrincipal.Text = objAdministrarCertificados.objAseguradoPre.Apellidos;
                txtCedulaPrincipal.Text = objAdministrarCertificados.objAseguradoPre.NumeroDocumento;
                txtPagaduriaPrincipal.Text = objAdministrarCertificados.objCertificadoPre.Pagaduria;
                txtFechaDigitacionCertificado.Text = objAdministrarCertificados.objCertificadoPre.FechaDigitacion.ToString("yyyy-MM-dd");
                ddlLocalidadCertificado.Items.Add(objAdministrarCertificados.objCertificadoPre.Localidad);
                ddlPoliza.Items.Add(objAdministrarCertificados.objCertificadoPre.NumeroPoliza);
                txtDeclaracionAsegurado.Text = objAdministrarCertificados.objCertificadoPre.Declaracion;
                txtDeclaracionEG.Text = objAdministrarCertificados.objCertificadoPre.DeclaracionEnfe;
                txtPrima.Text = objAdministrarCertificados.objCertificadoPre.Prima.ToString();
                txtpesoPrincipal.Text = objAdministrarCertificados.objCertificadoPre.PesoPrincipal.ToString();
                txtestaturaPrincipal.Text = objAdministrarCertificados.objCertificadoPre.EstaturaPrincipal.ToString();
                txtPeso.Text = objAdministrarCertificados.objCertificadoPre.Peso.ToString();
                txtEstatura.Text = objAdministrarCertificados.objCertificadoPre.Estatura.ToString();
                txtDeclaracionAsegurado.Text = objAdministrarCertificados.objCertificadoPre.Declaracion;
                txtDeclaracionEG.Text = objAdministrarCertificados.objCertificadoPre.DeclaracionEnfe;
                txtHServicio1.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio1;
                txtHServicio2.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio2;
                txtHServicio3.Text = objAdministrarCertificados.objCertificadoPre.HojaServicio3;
                txtAnexoConversion.Text = objAdministrarCertificados.objCertificadoPre.AnexoConversion;
                ddlPlantel.Items.Add(objAdministrarCertificados.objCertificadoPre.Plantel);

                Edad = Convert.ToInt32(Session["edad"]);
                txtEdadPrincipal.Text = Edad.ToString();

                DataTable dt = new DataTable(), dtAgencia = new DataTable(), dtPeriodoPago = new DataTable(), dtLocalidades = new DataTable(), dtOcupacionPrincipal = new DataTable();


                dtEncabezadoCertificado = objAdministrarCertificados.spConsultarEncabezadoCertificadoResumen(int.Parse(Session["cer_Id"].ToString()));
                txtCompania.Text = dtEncabezadoCertificado.Rows[0]["com_Nombre"].ToString();
                txtProducto.Text = dtEncabezadoCertificado.Rows[0]["pro_Nombre"].ToString();
                txtEstadoNegocio.Text = dtEncabezadoCertificado.Rows[0]["cer_EstadoNegocio"].ToString();
                txtTipoMovimiento.Text = dtEncabezadoCertificado.Rows[0]["CasoEspecial"].ToString() + " " + dtEncabezadoCertificado.Rows[0]["Principal"].ToString() + " " + dtEncabezadoCertificado.Rows[0]["Conyuge"].ToString() + "  " + dtEncabezadoCertificado.Rows[0]["OtroAsegurado"].ToString();
                txtmesProduccion.Text = dtEncabezadoCertificado.Rows[0]["MesProduccion"].ToString();
                dtOcupacionPrincipal = objAdministrarCertificados.ConsultarOcupacionCertificado(int.Parse(txtCedulaPrincipal.Text));
                ddlOcupacionPrincipal.DataValueField = "ocu_Id"; 
                ddlOcupacionPrincipal.DataTextField = "ocu_Nombre";
                ddlOcupacionPrincipal.DataSource = dtOcupacionPrincipal;
                ddlOcupacionPrincipal.DataBind();

                dtBeneficiario = objAdministrarCertificados.ConsultarBeneficiarioModificacion(int.Parse(Session["cer_Id"].ToString()), int.Parse(txtCedulaPrincipal.Text), 1);
                grvBeneficiarioPrincipal.DataSource = dtBeneficiario;
                grvBeneficiarioPrincipal.DataBind();

                dtEliminarPrincipal = objAdministrarCertificados.consultarAmparosPorPlanModificacion(int.Parse(Session["cer_Id"].ToString()), 1);
                grvAmparoPrincipal.DataSource = dtEliminarPrincipal;
                grvAmparoPrincipal.DataBind();

                double total = 0;
                foreach(DataRow row in dtEliminarPrincipal.Rows)
                {
                    total = total + int.Parse(row["prima"].ToString());
                }

                txtPrimaPrincipal.Text = total.ToString();

                //BG
                Session["cer_IdAnteriorExtraPrima"] = 0;
                int cer_Id = int.Parse(Session["cer_Id"].ToString());
                //Trae el valor de extraprima del principal y el conyuge
                DataTable dtConsultarHistorialExtraPrima = new DataTable();
                dtConsultarHistorialExtraPrima = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_Id"].ToString()), 1, int.Parse(Session["banderaExtraPrima"].ToString()));
                grvHistorialExtraPrima.DataSource = dtConsultarHistorialExtraPrima;
                grvHistorialExtraPrima.DataBind();
                if (dtConsultarHistorialExtraPrima.Rows.Count > 0)
                {
                    Session["cer_IdAnteriorExtraPrima"] = cer_Id;
                }
                double consultarHistorialExtraPrima = 0;
                double valorExtraPrima = 0;

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
                txtPrimaPrincipal.Text = consultarHistorialExtraPrima.ToString();
                //Session["TotalExtraPrimaP"] = consultarHistorialExtraPrima.ToString();
                txtExtraPrimaPrincipal.Text = valorExtraPrima.ToString();

                if (double.Parse(txtExtraPrimaPrincipal.Text) > 0)
                    chkExtraprimadoPrincipal.Checked = true;

                DataTable dtConsultarHistorialExtraPrimaConyuge = new DataTable();
                dtConsultarHistorialExtraPrimaConyuge = objAdministrarCertificados.ConsultarHistorialExtraPrima(int.Parse(Session["cer_Id"].ToString()), 2, int.Parse(Session["banderaExtraPrima"].ToString()));
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
                txtPrimaConyuge.Text = consultarHistorialExtraPrimaConyuge.ToString();
                //Session["TotalExtraPrimaC"] = consultarHistorialExtraPrimaConyuge.ToString();
                txtExtraPrimaConyuge.Text = valorExtraPrimaConyuge.ToString();
                if (double.Parse(txtExtraPrimaConyuge.Text) > 0)
                    chkExtraprimadoConyuge.Checked = true;


                // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial
                DataSet dsConsultarHistirialPorcentajeExtraPrimado = new DataSet();
                dsConsultarHistirialPorcentajeExtraPrimado = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 1);
                
                DataTable dtConsultarHistirialPorcentajeExtraPrimado = new DataTable();
                foreach (DataTable dt1 in dsConsultarHistirialPorcentajeExtraPrimado.Tables)
                {
                    dtConsultarHistirialPorcentajeExtraPrimado.Merge(dt1);
                }
                grvConsultarHistirialPorcentajeExtraPrimado.DataSource = dtConsultarHistirialPorcentajeExtraPrimado;
                grvConsultarHistirialPorcentajeExtraPrimado.DataBind();

                // crea dt el cual contiene la informacion del historial del cliente en todos los amparos y se lo asigna a la tabla de historial

                DataSet dsConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataSet();
                dsConsultarHistirialPorcentajeExtraPrimadoConyuge = objAdministrarCertificados.ConsultarHistirialPorcentajeExtraPrimado(int.Parse(Session["cer_IdAnteriorExtraPrima"].ToString()), 2);

                DataTable dtConsultarHistirialPorcentajeExtraPrimadoConyuge = new DataTable();
                foreach (DataTable dt2 in dsConsultarHistirialPorcentajeExtraPrimadoConyuge.Tables)
                {
                    dtConsultarHistirialPorcentajeExtraPrimadoConyuge.Merge(dt2);
                }

                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataSource = dtConsultarHistirialPorcentajeExtraPrimadoConyuge;
                grvConsultarHistirialPorcentajeExtraPrimadoConyuge.DataBind();



                //double primaConyuge = 0;
                //if(txtPrimaConyuge.Text != "")
                //{
                //    primaConyuge = double.Parse(txtPrimaConyuge.Text);
                //}
                //double sumatoriaPrimaPrincipal = 0;
                //double primaOtroAsegurado = 0;
                //foreach (DataRow dr in otrosAsegurados.Rows)
                //{
                //    primaOtroAsegurado += double.Parse(dr["Prima"].ToString());
                //}
                //sumatoriaPrimaPrincipal = double.Parse(txtPrima.Text) - double.Parse(primaConyuge.ToString());
                //txtPrimaPrincipal.Text = (double.Parse(sumatoriaPrimaPrincipal.ToString()) - double.Parse(primaOtroAsegurado.ToString())).ToString();
                

                DataTable dtConyuge = new DataTable();
                dtConyuge = objAdministrarCertificados.consultarNewTerceroPorCedulaResumen(int.Parse(txtCedulaPrincipal.Text), int.Parse(objAdministrarCertificados.objCertificadoPre.Producto), int.Parse(Session["cer_Id"].ToString()));
                if (dtConyuge.Rows.Count > 0)
                {
                    txtCedulaConyuge.Text = dtConyuge.Rows[0]["ter_Id"].ToString();
                    txtNombreConyuge.Text = dtConyuge.Rows[0]["ter_Nombres"].ToString();
                    txtApellidoConyuge.Text = dtConyuge.Rows[0]["ter_Apellidos"].ToString();
                    txtEdadConyuge.Text = Funciones.Edad(DateTime.Parse(dtConyuge.Rows[0]["ter_FechaNacimiento"].ToString())).ToString(); //Envía fecha y devuelve la edad
                }

                if (txtCedulaConyuge.Text != "")
                {
                    dtEliminarConyuge = objAdministrarCertificados.consultarAmparosPorPlanModificacion(int.Parse(Session["cer_Id"].ToString()), 2);
                    grvAmparoConyuge.DataSource = dtEliminarConyuge;
                    grvAmparoConyuge.DataBind();

                    double totalC = 0;
                    foreach (DataRow row in dtEliminarConyuge.Rows)
                    {
                        totalC = totalC + int.Parse(row["prima"].ToString());
                    }

                    txtPrimaConyuge.Text = totalC.ToString();

                    //double primaPrincipal = 0;
                    //if (txtPrimaConyuge.Text != "")
                    //{
                    //    primaPrincipal = double.Parse(txtPrimaPrincipal.Text);
                    //}
                    //double sumatoriaPrimaConyuge = 0;
                    //double primaOtroAseguradoC = 0;
                    //foreach (DataRow dr in otrosAsegurados.Rows)
                    //{
                    //    primaOtroAseguradoC += double.Parse(dr["Prima"].ToString());
                    //}
                    //sumatoriaPrimaConyuge = double.Parse(txtPrima.Text) - double.Parse(primaPrincipal.ToString());
                    //txtPrimaConyuge.Text = (double.Parse(sumatoriaPrimaConyuge.ToString()) - double.Parse(primaOtroAseguradoC.ToString())).ToString();

                   
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

                    grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                    grvBeneficiarioConyuge.DataBind();
                    grvBeneficiarioConyuge.Enabled = true;

                    dtBeneficiarioConyuge = objAdministrarCertificados.ConsultarBeneficiarioModificacion(int.Parse(Session["cer_Id"].ToString()), int.Parse(txtCedulaConyuge.Text), 2);
                    grvBeneficiarioConyuge.DataSource = dtBeneficiarioConyuge;
                    grvBeneficiarioConyuge.DataBind();


                }

                if(txtCedulaConyuge.Text != "")
                {
                    amparosConyuge.Visible = true;
                    beneficiariosConyuge.Visible = true;
                    btnExtraPrima2.Visible = true;
                }
                else
                {
                    amparosConyuge.Visible = false;
                    beneficiariosConyuge.Visible = false;
                    btnExtraPrima2.Visible = false;
                    txtPrimaConyuge.Text = "0";
                    txtExtraPrimaConyuge.Text = "0";
                }

                otrosAsegurados = objAdministrarCertificados.consultarOtroAsegurado(int.Parse(Session["cer_Id"].ToString()));
                dtTemp = objAdministrarCertificados.consultarOtroAseguradoIndex(int.Parse(Session["cer_Id"].ToString()));
                grvOtrosAsegurados.DataSource = otrosAsegurados;
                grvOtrosAsegurados.DataBind();



                if (objAdministrarCertificados.objCertificadoPre.Producto == "1")
                {
                    reqtxtPlanPrincipal.Enabled = true;
                    txtPlanPrincipal.Visible = true;

                    reqtxtPlanConyuge.Enabled = true;
                    txtPlanConyuge.Visible = true;

                    lblPlan.Visible = true;
                    labPlan.Visible = true;

                    ReqddlPlanPrincipal.Enabled = false;
                    ddlPlanPrincipal.Visible = false;

                    reqddlPlanConyuge.Enabled = false;
                    ddlPlanConyuge.Visible = false;

                    labPlan1.Visible = false;
                    lblPlan2.Visible = false;

                }
                if (objAdministrarCertificados.objCertificadoPre.Producto == "99" || objAdministrarCertificados.objCertificadoPre.Producto == "4"
                    || objAdministrarCertificados.objCertificadoPre.Producto == "98" || objAdministrarCertificados.objCertificadoPre.Producto == "2" ||
                     objAdministrarCertificados.objCertificadoPre.Producto == "21" || objAdministrarCertificados.objCertificadoPre.Producto == "111"
                    || objAdministrarCertificados.objCertificadoPre.Producto == "15")
                {
                    if (objAdministrarCertificados.objCertificadoPre.Producto == "21" || objAdministrarCertificados.objCertificadoPre.Producto == "3"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "9" || objAdministrarCertificados.objCertificadoPre.Producto == "98"
                        || objAdministrarCertificados.objCertificadoPre.Producto == "4")
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

                if (objAdministrarCertificados.objCertificadoPre.Producto == "3" || objAdministrarCertificados.objCertificadoPre.Producto == "9")
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

        }
        if (!IsPostBack)
        {
            int bandera = 1;
            if(txtEstadoNegocio.Text == "PRODUCCION NUEVA")
            {
                btnCorregir.Enabled = true;
            }
            else
            {
                if (txtEstadoNegocio.Text == "VIGENTE")
                {
                    dtTodos = objAdministrarCertificados.ConsultarCertificadosVigentes(int.Parse(objAdministrarCertificados.objCertificadoPre.Producto), int.Parse(txtCedulaPrincipal.Text));
                    if(dtTodos.Rows.Count == 0)
                    {
                        btnCorregir.Enabled = true;
                    }
                    else
                    {
                        foreach (DataRow row in dtTodos.Rows)
                        {
                            if (row["cer_Id"].ToString() != Session["cer_Id"].ToString())
                            {
                                if(row["cer_EstadoNegocio"].ToString() == "PRODUCCION NUEVA")
                                {
                                    bandera = 0;
                                }
                            }
                        }
                        btnCorregir.Enabled = (bandera == 1) ? true : false;
                    }
                }
                else
                {
                    btnCorregir.Enabled = false;
                }
            }
        }

    }

    protected void btnCorregir_Click(object sender, EventArgs e)
    {
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.certificadoPrecargadoResumen(int.Parse(Session["cer_Id"].ToString()));
        DataTable dtPro_Id = new DataTable();
        dtPro_Id = objAdministrarCertificados.consultarProIdPorNombre(txtProducto.Text, txtCompania.Text);

        Session["numeroCertificado"] = Session["cer_Id"];
        DataTable dt = new DataTable();
        //dt = AdministrarCertificados.consultarCertificadoExistente(int.Parse(row.Cells[7].Text), int.Parse(dtPro_Id.Rows[0]["pro_Id"].ToString()));
        dt = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaPrincipal.Text), int.Parse(dtPro_Id.Rows[0]["pro_Id"].ToString()));

        if (dt.Rows.Count > 0 && (dt.Rows[0]["cer_IdAnterior"]) != "")
        {
            // Si permite varios vigentes
            //if (dt.Rows[0]["casesp_Id"].ToString() == "8")
            Session["operacionCertificado"] = "modificar";
            //else
            //    Session["operacionCertificado"] = "ingresar";
        }
        else
        {
            Session["operacionCertificado"] = "ingresar";
        }
        Session["pro_Id"] = objAdministrarCertificados.objCertificadoPre.Producto;
        Session["ter_Id"] = txtCedulaPrincipal.Text;
        //Response.Redirect("ModificacionesCertificadoDigitado.aspx");
        Response.RedirectToRoute("modificarCertificado");
        //("modificarCertificado");
        btnCorregir.Attributes.Add("onclick", "localStorage.setItem('accIndex', 0);");
    }
}