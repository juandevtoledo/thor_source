using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_ProduccionNueva : System.Web.UI.Page
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

    public PrecargueProduccion precargue = new PrecargueProduccion();
    public Certificado digitarCertificado = new Certificado();
    public RegistrarProduccion objRegistrarProduccion = new RegistrarProduccion();
   
    Asegurado objAsegurado = new Asegurado();
    protected void Page_Load(object sender, EventArgs e){

        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();      

        reqtxtPrimaTotal.Enabled = false;
        reqtxtObservaciones.Enabled = false;
        reqddlCausal.Enabled = false;
        ddlNombreAsesor.Enabled = false;
        if (!IsPostBack)
        {
            try
            {
                if (Session["recuperable"].ToString() == "NORECUPERABLE")
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CAUSAL DE DEVOLUCION NO ES RECUPERABLE, POR ENDE SE RECUPERARA CON UN NUEVO CERTIFICADO" + "');", true);
                    Session["recuperable"] = "";
                }
            }
            catch { }

            ddlLocalidad.Enabled = false;
        }
        ddlCedulaAsesor.Enabled = false;
        
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();

        DataTable dt = new DataTable(), dTable = new DataTable(), dtEstadoCargue = new DataTable(), dtPagaduria = new DataTable(), dtTipoDevolucion = new DataTable(), dtCausalDevolucion = new DataTable(), dtEstado = new DataTable(), dtLocalidades = new DataTable();
        string tempUsuario = Session["usuario"].ToString();
        precargue.CargarAgencia(tempUsuario);


        if (!IsPostBack)
        {
            Session["EsMigracion"] = false;
            Session["DesignacionBeneficiarios"] = false;

            try
            {
                dtLocalidades = objAdministrarCertificados.ConsultarLocalidadesAgencia(tempUsuario);
                ddlLocalidad.DataValueField = "dep_Id";
                ddlLocalidad.DataTextField = "dep_Nombre";
                ddlLocalidad.DataSource = dtLocalidades;
                ddlLocalidad.DataBind();
                ddlLocalidad.Items.Insert(0, new ListItem("", ""));
            }
            catch { }
          
            //dtPagaduria = precargue.CargarPagadurias();
            //ddlPagaduria.DataTextField = "paga_Nombre";
            //ddlPagaduria.DataValueField = "paga_Id";
            //ddlPagaduria.DataSource = dtPagaduria;
            //ddlPagaduria.DataBind();
            //ddlPagaduria.Items.Insert(0, new ListItem("", ""));

            dt = precargue.CargarCompania();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dt;
            ddlCompania.DataBind();


            //int com_Id = int.Parse(ddlCompania.SelectedValue.ToString());
            //dt = precargue.CargarAsesor(int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
            //dTable = dt.Clone();
            //foreach (DataRow row in dt.Rows)
            //{
            //    row["ase_Nombres"] = row["ase_Nombres"].ToString() + " " + row["ase_Apellidos"].ToString();
            //    dTable.ImportRow(row);
            //}

            //ddlNombreAsesor.DataTextField = "ase_Nombres";
            //ddlNombreAsesor.DataValueField = "ase_Id";
            //ddlNombreAsesor.DataSource = dTable;
            //ddlNombreAsesor.DataBind();
            //ddlNombreAsesor.Items.Insert(0, new ListItem("", ""));

            //ddlCedulaAsesor.DataTextField = "ase_Codigo";
            //ddlCedulaAsesor.DataValueField = "ase_Id";
            //ddlCedulaAsesor.DataSource = dTable;
            //ddlCedulaAsesor.DataBind();
            //ddlCedulaAsesor.Items.Insert(0, new ListItem("", ""));

            //dtTipoDevolucion = precargue.CargarTipoDevolucion();
            //ddlGrupoDevolucion.DataTextField = "tipdev_Nombre";
            //ddlGrupoDevolucion.DataValueField = "tipdev_Id";
            //ddlGrupoDevolucion.DataSource = dtTipoDevolucion;
            //ddlGrupoDevolucion.DataBind();

            DataTable dtProducto = new DataTable();
            string compania = ddlCompania.SelectedValue.ToString();
            dtProducto = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompania.SelectedValue.ToString()));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));

            rbtNuevoCertificado.Visible = false;
        }

        if(txtFechaExpedicionProduccion.Text == "")
        {
            ddlCompania.Enabled = false;
            ddlProducto.Enabled = false;
        }
        else
        {
            ddlCompania.Enabled = true;
            ddlProducto.Enabled = true;
        }

        txtAgenciaProduccion.Text = Session["Agencia"].ToString(); 
        if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR")
        {
            txtPlanillaBolivar.Visible = true;
            planillaBolivar.Visible = true;
            labPlanillaBolivar.Visible = true;
        }
    }
  

    protected void ConsultarClienteExiste(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        btnPrecargue.Enabled = true;
        if (txtCedulaProduccion.Text != "")
        {
            DataTable dtTerceroPreCargue = new DataTable();
            dtTerceroPreCargue = objDigitarProduccion.consultarTerceroPreCargue(int.Parse(txtCedulaProduccion.Text));
            if (IsPostBack)
            {
                if (dtTerceroPreCargue.Rows.Count > 0)
                {
                    txtNombreProduccion.Text = dtTerceroPreCargue.Rows[0]["ter_Nombres"].ToString();
                    txtApellidoProduccion.Text = dtTerceroPreCargue.Rows[0]["ter_Apellidos"].ToString();
                    txtNombreProduccion.Enabled = false;
                    txtApellidoProduccion.Enabled = false;
                    //Como el tercero no existe se inserta en la tabla terceros
                }
                else
                {
                    txtNombreProduccion.Enabled = true;
                    txtApellidoProduccion.Enabled = true;
                    txtNombreProduccion.Text = "";
                    txtApellidoProduccion.Text = "";
                }
            }
        }
        else
        {
            txtNombreProduccion.Text = "";
            txtApellidoProduccion.Text = "";
        }

        if (ddlProducto.SelectedValue.ToString() != "")
        {
            if (int.Parse(ddlProducto.SelectedValue.ToString()) == 1)
            {
                DataTable ConsultarCertificadoAnteriorPMI = new DataTable();
                ConsultarCertificadoAnteriorPMI = objAdministrarCertificados.ConsultarCertificadoAnteriorPMI(int.Parse(txtCedulaProduccion.Text.ToString()), 1);

                if (ConsultarCertificadoAnteriorPMI.Rows.Count == 0)
                {
                    btnPrecargue.Enabled = false;
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "PARA ESTE PRODUCTO NO SE PERMITEN INGRESOS" + "');", true);
                }
            }
        }
    }

    protected void RecalcularNombreAsesor(object sender, EventArgs e)
    {
        ddlNombreAsesor.SelectedValue = ddlCedulaAsesor.SelectedValue;
        ddlNombreAsesor.Enabled = true;
        ddlCedulaAsesor.Enabled = true;

        // Se debe solicitar al sistema Apolo que devuelva los números de certificados disponibles para esa localidad y para ese asesor
        //ConectorKardexPapeleria.ActualizarPolizaUtilizada(5);
    }

    protected void RecalcularCedulaAsesor(object sender, EventArgs e)
    {
        ddlCedulaAsesor.SelectedValue = ddlNombreAsesor.SelectedValue;
        ddlNombreAsesor.Enabled = true;
        ddlCedulaAsesor.Enabled = true;

        // Se debe solicitar al sistema Apolo que devuelva los números de certificados disponibles para esa localidad y para ese asesor
        //ConectorKardexPapeleria.ActualizarPolizaUtilizada(5);
    }

    protected void CargarProducto(object sender, EventArgs e)
    {
        ValidarCompania(sender, e);

        rbtNuevoCertificado.Visible = false;

        DataTable dt, dTable = new DataTable();
        int com_Id = int.Parse(ddlCompania.SelectedValue.ToString());
        dt = precargue.CargarProducto(com_Id);
        ddlProducto.DataTextField = "pro_Nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataSource = dt;
        ddlProducto.DataBind();

        ValidarProducto(sender, e);
    }

    protected void ValidarCompania(object sender, EventArgs e)
    {
        if (ddlCompania.SelectedItem.ToString() == "MAPFRE")
        {
            rblBeneficiarosMapfre.Visible = false;//true
        }
        else
        {
            rblBeneficiarosMapfre.Visible = false;
        }

        if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR")
        {
            txtPlanillaBolivar.Visible = true;
            labPlanillaBolivar.Visible = true;
            planillaBolivar.Visible = true;
            reqtxtPlanillaBolivar.Enabled = true;
        
        }
        else
        {
            txtPlanillaBolivar.Visible = false;
            labPlanillaBolivar.Visible = false;
            planillaBolivar.Visible = false;
            reqtxtPlanillaBolivar.Enabled = false;
        }        
    }

    protected void ValidarProducto(object sender, EventArgs e)
    {
        DigitarProduccion objDigitarProduccion = new DigitarProduccion();
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        btnPrecargue.Enabled = true;
        ddlLocalidad.Enabled = true;
        DataTable dtEstadoCargue = new DataTable();
        dtEstadoCargue = precargue.CargarEstadoCargue();
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        int fila = 0;
        int flag = 0;
        labHojaServicioPrincipal.Visible = false;
        txtHojaServicioPrincipal.Visible = false;
        labHojaServicioConyuge.Visible = false;
        txtHojaServicioConyuge.Visible = false;
        labHojaServicioOtrosAsegurados.Visible = false;
        txtHojaServicioOtrosAsegurados.Visible = false;
        legInformacionHojaServicio.Visible = false;
        foreach (DataRow row in dtEstadoCargue.Rows)
        {
            if (row["estcar_Nombre"].ToString() == "Expedido Aprobado")
            {
                dtEstadoCargue.Rows.Remove(row);
                break;
            }
        }
        foreach (DataRow row in dtEstadoCargue.Rows)
        {
            
            if (ddlProducto.SelectedItem.ToString() == "EDUCADORES PLUS" && row["estcar_Nombre"].ToString() == "Devolucion")
            {
                flag = fila;
            }
            else
            {
                if (ddlProducto.SelectedItem.ToString() != "EDUCADORES PLUS" && row["estcar_Nombre"].ToString() == "Devolucion por confirmar")
                {
                    flag = fila;
                }
            }
            fila++;
        }

        dtEstadoCargue.Rows.RemoveAt(flag);

        ddlEstado.DataTextField = "estcar_Nombre";
        ddlEstado.DataValueField = "estcar_Id";
        ddlEstado.DataSource = dtEstadoCargue;
        ddlEstado.DataBind();


        if (ddlCompania.SelectedItem.ToString() == "MAPFRE")
        {
            rblBeneficiarosMapfre.Visible = false;//true
        }
        else
        {
            rblBeneficiarosMapfre.Visible = false;
        }

        if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR")
        {
            txtPlanillaBolivar.Visible = true;
            labPlanillaBolivar.Visible = true;
            planillaBolivar.Visible = true;
            reqtxtPlanillaBolivar.Enabled = true;
        }
        else
        {
            txtPlanillaBolivar.Visible = false;
            labPlanillaBolivar.Visible = false;
            planillaBolivar.Visible = false;
            reqtxtPlanillaBolivar.Enabled = false;
        }

        
            //if (ddlProducto.SelectedItem.ToString() == "EDUCADORES PLUS")
            //{           
            //    DataTable dt = new DataTable();
            //    dt = DigitarProduccion.ConsultarTipoDevolucionPlus();
            //    ddlGrupoDevolucion.DataTextField = "tipdev_Nombre";
            //    ddlGrupoDevolucion.DataValueField = "tipdev_Id";
            //    ddlGrupoDevolucion.DataSource = dt;
            //    ddlGrupoDevolucion.DataBind();
            //}
            //else
            //{
                //rbtNuevoCertificado.Visible = true;
                txtAnexoConversionProduccion.Visible = true;
                labAnexoConversionProduccion.Visible = true;
                reqAnexoConversion.Enabled = true;
                DataTable dt = new DataTable();
                dt = objDigitarProduccion.cargarTipoDevolucion();
                ddlGrupoDevolucion.DataTextField = "tipdev_Nombre";
                ddlGrupoDevolucion.DataValueField = "tipdev_Id";
                ddlGrupoDevolucion.DataSource = dt;
                ddlGrupoDevolucion.DataBind();
            //}
            DataTable dtCausalDevolucion = new DataTable();
            dtCausalDevolucion = precargue.CargarCausalDevolucion(int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()));
            ddlCausalDevolucion.DataTextField = "caudev_Nombre";
            ddlCausalDevolucion.DataValueField = "caudev_Id";
            ddlCausalDevolucion.DataSource = dtCausalDevolucion;
            ddlCausalDevolucion.DataBind();
        
            if (ddlCompania.SelectedItem.ToString() == "SURAMERICANA" && ddlProducto.SelectedItem.ToString() == "EMPRESARIOS")
            {                
                reqAnexoConversion.Enabled = false;
                reqtxtPlanillaBolivar.Enabled = false;
                reqtxtHojaServicioPrincipal.Enabled = false;
                reqtxtHojaServicioOtrosAsegurados.Enabled = false;
                reqtxtHojaServicioConyuge.Enabled = false;                
            }
            else
            {                
                //chkAjusteDePrimaProduccion.Visible = false;
                //chkDesignacionBeneficiarios.Visible = false;                
                reqAnexoConversion.Enabled = false;
                reqtxtPlanillaBolivar.Enabled = false;
                reqtxtHojaServicioPrincipal.Enabled = false;
                reqtxtHojaServicioOtrosAsegurados.Enabled = false;
                reqtxtHojaServicioConyuge.Enabled = false;                
            }
            //rbtNuevoCertificado.Visible = false;
            txtAnexoConversionProduccion.Visible = false;
            labAnexoConversionProduccion.Visible = false;
        


        // Calcular la vigencia
        DataTable dtVigencia = new DataTable();
        dtVigencia = PrecargueProduccion.CalcularVigencia((int.Parse(ddlProducto.SelectedValue.ToString())));
        int diaFrontera = int.Parse(dtVigencia.Rows[0]["dia_Frontera"].ToString());
        int mesVigencia = int.Parse(dtVigencia.Rows[0]["mes_Vigencia"].ToString());
        DateTime date = DateTime.Parse(txtFechaExpedicionProduccion.Text);
        if (date.Day < diaFrontera)
        {
            date = date.AddMonths(mesVigencia);
        }
        else
        {

            date = date.AddMonths(mesVigencia + 1);
        }
        DateTime vigencia = date;
        vigencia = (vigencia.AddDays(-date.Day)).AddDays(1);
        int mesProduccion = vigencia.Month - mesVigencia;
        Session["mesProduccion"] = mesProduccion;
        txtVigencia.Text = vigencia.ToString();

        txtNumeroCertificado.Text = "";

        if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR" && ddlProducto.SelectedItem.ToString() == "EDUCADORES")
        {
            // Revisar si ya existe un certificado vigente para aumentar el consecutivo
            DataTable dtConCert = new DataTable();
            dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 1);
            try
            {
                if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                {
                    digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                    txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                    txtNumeroCertificado.Enabled = false;
                    rbtNuevoCertificado.Visible = false;
                    conversion.Visible = false;
                    labAnexoConversionProduccion.Visible = false;
                    txtAnexoConversionProduccion.Visible = false;
                    labHojaServicioPrincipal.Visible = true;
                    txtHojaServicioPrincipal.Visible = true;
                    labHojaServicioConyuge.Visible = true;
                    txtHojaServicioConyuge.Visible = true;
                    labHojaServicioOtrosAsegurados.Visible = true;
                    txtHojaServicioOtrosAsegurados.Visible = true;
                    legInformacionHojaServicio.Visible = true;
                }
                else
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                    txtNumeroCertificado.Text = "";
                    rbtNuevoCertificado.Visible = false;
                    legInformacionHojaServicio.Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                }
            }
            catch (Exception ex)
            {
                digitarCertificado.Consecutivo = -1;
                txtNumeroCertificado.Enabled = true;
            }

        }

        if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR" && ddlProducto.SelectedItem.ToString() == "EDUCADORES PLUS")
        {
            // Revisar si ya existe un certificado vigente para aumentar el consecutivo
            DataTable dtConCert = new DataTable();
            dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 1);
            try
            {
                if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                {
                    digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                    txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                    txtNumeroCertificado.Enabled = false;
                    rbtNuevoCertificado.Visible = false;
                    conversion.Visible = true;
                    labAnexoConversionProduccion.Visible = true;
                    txtAnexoConversionProduccion.Visible = true;
                    legInformacionHojaServicio.Visible = false;                    
                }
                else
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                    txtNumeroCertificado.Text = "";
                    rbtNuevoCertificado.Visible = false;                    
                    legInformacionHojaServicio.Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                }
            }
            catch (Exception ex)
            {
                digitarCertificado.Consecutivo = -1;
                txtNumeroCertificado.Enabled = true;
            }
        }
        
            if (ddlCompania.SelectedItem.ToString() == "SEGUROS BOLIVAR" && ddlProducto.SelectedItem.ToString() == "EDUCADORES PLUS")
            {
                // Revisar si ya existe un certificado vigente para aumentar el consecutivo
                DataTable dtConCert = new DataTable();
                dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 99);
                try
                {
                    if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                    {
                        digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                        txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                        txtNumeroCertificado.Enabled = false;
                        rbtNuevoCertificado.Visible = false;
                        conversion.Visible = false;
                        labAnexoConversionProduccion.Visible = false;
                        txtAnexoConversionProduccion.Visible = false;
                        labHojaServicioPrincipal.Visible = true;
                        txtHojaServicioPrincipal.Visible = true;
                        labHojaServicioConyuge.Visible = true;
                        txtHojaServicioConyuge.Visible = true;
                        labHojaServicioOtrosAsegurados.Visible = true;
                        txtHojaServicioOtrosAsegurados.Visible = true;                        
                        legInformacionHojaServicio.Visible = true;
                    }
                    else
                    {
                        digitarCertificado.Consecutivo = -1;
                        txtNumeroCertificado.Enabled = true;
                        txtNumeroCertificado.Text = "";
                        rbtNuevoCertificado.Visible = false;                        
                        legInformacionHojaServicio.Visible = false;
                        //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                        //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                    }
                }
                catch (Exception ex)
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                }
            
        }
        rblSura.Visible = false;


        // Migración SURA Y Mapfre
        if ((ddlCompania.SelectedItem.ToString() == "SURAMERICANA" && ddlProducto.SelectedItem.ToString() == "EMPRESARIOS") || (ddlCompania.SelectedItem.ToString() == "MAPFRE" && ddlProducto.SelectedItem.ToString() == "CAMARAS DE COMERCIO"))
        {
            // Revisar si ya existe un certificado vigente para aumentar el consecutivo
            DataTable dtConCert = new DataTable();
            dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), int.Parse(ddlProducto.SelectedValue.ToString()));
            try
            {
                if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                {
                    digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                    txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                    txtNumeroCertificado.Enabled = false;                    
                    conversion.Visible = false;
                    labAnexoConversionProduccion.Visible = false;
                    txtAnexoConversionProduccion.Visible = false;
                    rblSura.Visible = false;// true
                    if (rblSura.SelectedValue == "Ajuste de Prima")
                        Session["EsMigracion"] = true;
                    else
                        if (rblSura.SelectedValue == "Designación de Beneficiarios")
                        {
                            Session["DesignacionBeneficiarios"] = true;                            
                        }
                }
                else
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                    txtNumeroCertificado.Text = "";
                    rbtNuevoCertificado.Visible = false;                    
                    //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                }
            }
            catch (Exception ex)
            {
                digitarCertificado.Consecutivo = -1;
                txtNumeroCertificado.Enabled = true;                
            }
        }
        if (int.Parse(ddlProducto.SelectedValue.ToString()) == 1)
        {
            DataTable ConsultarCertificadoAnteriorPMI = new DataTable();
            ConsultarCertificadoAnteriorPMI = objAdministrarCertificados.ConsultarCertificadoAnteriorPMI(int.Parse(txtCedulaProduccion.Text.ToString()), 1);

            if (ConsultarCertificadoAnteriorPMI.Rows.Count == 0)
            {

                //if (chkCambioInter.Checked == false)
                //{
                   // btnPrecargue.Enabled = true;
                //}

                
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "PARA ESTE PRODUCTO NO SE PERMITEN INGRESOS" + "');", true);
                //habilitar boton para caso especial cambio de intermediario
                if (chkCambioInter.Checked == true)
                {
                    btnPrecargue.Enabled = true;
                }
                else
                {
                    btnPrecargue.Enabled = true;
                }
                
            }
        }

        // SE CARGA EL DDL DE VIGENTES
        DataTable dtCertificadosVigentes = objAdministrarCertificados.ConsultarCertificadosVigentes(int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(txtCedulaProduccion.Text));
        ddlCertificadosVigentes.DataSource = dtCertificadosVigentes;
        ddlCertificadosVigentes.DataValueField = "cer_Id";
        ddlCertificadosVigentes.DataTextField = "cer_Certificado";
        ddlCertificadosVigentes.DataBind();

        // SE ACTIVA LA MODIFICACIÓN DEL NÚMERO DE CERTIFICADO PARA CUANDO SE PUEDEN VARIOS VIGENTES
        if (chkVariosVigentes.Checked == true)
            txtNumeroCertificado.Enabled = true;

        Session["Consecutivo"] = digitarCertificado.Consecutivo;
      }


    protected void CargarCausalDevolucion(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = precargue.CargarCausalDevolucion(int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()));
        ddlCausalDevolucion.DataTextField = "caudev_Nombre";
        ddlCausalDevolucion.DataValueField = "caudev_Id";
        ddlCausalDevolucion.DataSource = dt;
        ddlCausalDevolucion.DataBind();
    }

    protected void pagaduriaPorLocalidad(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        try
        {
            DataTable dt = new DataTable();
            dt = objAdministrarCertificados.ConsultarPagaduriaPorLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dt;
            ddlPagaduria.DataBind();

            if (ddlLocalidad.SelectedValue.ToString() != "")
            {
                ddlNombreAsesor.Enabled = true;
                ddlCedulaAsesor.Enabled = true;
            }
            DataTable dTable = new DataTable();
            dt = precargue.CargarAsesor(int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
            dTable = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                row["ase_Nombres"] = row["ase_Nombres"].ToString() + " " + row["ase_Apellidos"].ToString();
                dTable.ImportRow(row);
            }

            ddlNombreAsesor.DataTextField = "ase_Nombres";
            ddlNombreAsesor.DataValueField = "ase_Id";
            ddlNombreAsesor.DataSource = dTable;
            ddlNombreAsesor.DataBind();

            ddlCedulaAsesor.DataTextField = "ase_Codigo";
            ddlCedulaAsesor.DataValueField = "ase_Id";
            ddlCedulaAsesor.DataSource = dTable;
            ddlCedulaAsesor.DataBind();
        }
        catch { ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR Seleccione LA LOCALIDAD" + "');", true); }
    }

    protected void HojasServicio(object sender, EventArgs e)
    {
        if (rbtNuevoCertificado.Visible == true)
        {
            if (rbtNuevoCertificado.SelectedItem.ToString() != "Hoja de Servicio")
            {
                txtHojaServicioPrincipal.Visible = false;
                txtHojaServicioConyuge.Visible = false;
                txtHojaServicioOtrosAsegurados.Visible = false;
                labHojaServicioPrincipal.Visible = false;
                labHojaServicioConyuge.Visible = false;
                labHojaServicioOtrosAsegurados.Visible = false;
                //legInformacionHojaServicio.Visible = false;
                conversion.Visible = true;                
                reqtxtHojaServicioPrincipal.Enabled = false;
                reqtxtHojaServicioOtrosAsegurados.Enabled = false;
                reqtxtHojaServicioConyuge.Enabled = false;
            }
            else
            {
                txtHojaServicioPrincipal.Visible = true;
                txtHojaServicioConyuge.Visible = true;
                txtHojaServicioOtrosAsegurados.Visible = true;
                labHojaServicioPrincipal.Visible = true;
                labHojaServicioConyuge.Visible = true;
                labHojaServicioOtrosAsegurados.Visible = true;
                //legInformacionHojaServicio.Visible = true;
                conversion.Visible = false;                
                reqtxtHojaServicioPrincipal.Enabled = true;
                reqtxtHojaServicioOtrosAsegurados.Enabled = true;
                reqtxtHojaServicioConyuge.Enabled = true;
                reqAnexoConversion.Enabled = false;
                reqtxtPlanillaBolivar.Enabled = true;
            }

        }
    }


    protected void ConfirmarMigracionDesignacion()
    {
        // Migración SURA Y Mapfre
        if ((ddlCompania.SelectedItem.ToString() == "SURAMERICANA" && ddlProducto.SelectedItem.ToString() == "EMPRESARIOS") || (ddlCompania.SelectedItem.ToString() == "MAPFRE" && ddlProducto.SelectedItem.ToString() == "CAMARAS DE COMERCIO"))
        {   
            
                if (rblSura.SelectedValue == "Ajuste de Prima")
                        Session["EsMigracion"] = true;
                else
                    if (rblSura.SelectedValue == "Designación de Beneficiarios")
                    {
                        Session["DesignacionBeneficiarios"] = true;
                    } 
        }
    }


    protected void CrearCertificado(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
        digitarCertificado.Consecutivo = int.Parse(Session["Consecutivo"].ToString());
        // Determinar si tiene certificado vigente anterior
        int cerAnterior = 0;
        try
        {
            cerAnterior = int.Parse(ddlCertificadosVigentes.SelectedValue.ToString());
        }
        catch { };

        ConfirmarMigracionDesignacion();
        // Determinar si es migración
        int migracion = 1;
        if ((bool)Session["EsMigracion"] == true)
        {
            migracion = 2;
            // Revisar si ya existe un certificado vigente para aumentar el consecutivo
            DataTable dtConCert = new DataTable();
            if ((ddlCompania.SelectedItem.ToString() == "SURAMERICANA" && ddlProducto.SelectedItem.ToString() == "EMPRESARIOS"))
            {
                dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 4);
            }

            if ((ddlCompania.SelectedItem.ToString() == "MAPFRE" && ddlProducto.SelectedItem.ToString() == "CAMARAS DE COMERCIO"))
            {
                dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 9);
            }
            
            try
            {
                if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                {
                    digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                    txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                    txtNumeroCertificado.Enabled = false;
                    rbtNuevoCertificado.Visible = false;
                    conversion.Visible = true;
                    labAnexoConversionProduccion.Visible = true;
                    txtAnexoConversionProduccion.Visible = true;
                    legInformacionHojaServicio.Visible = false;
                }
                else
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                    txtNumeroCertificado.Text = "";
                    rbtNuevoCertificado.Visible = false;
                    legInformacionHojaServicio.Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                }
            }
            catch (Exception ex)
            {
                digitarCertificado.Consecutivo = -1;
                txtNumeroCertificado.Enabled = true;
            }
        }
        if (rblSura.SelectedValue == "Designación de Beneficiarios")
        {
            migracion = 3;
            DataTable dtConCert = new DataTable();
            dtConCert = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(txtCedulaProduccion.Text), 4);
            try
            {
                if (dtConCert.Rows[0]["cer_Consecutivo"].ToString() != "")
                {
                    digitarCertificado.Consecutivo = int.Parse(dtConCert.Rows[0]["cer_Consecutivo"].ToString()) + 1;
                    txtNumeroCertificado.Text = dtConCert.Rows[0]["cer_Certificado"].ToString();
                    txtNumeroCertificado.Enabled = false;
                    rbtNuevoCertificado.Visible = false;
                    conversion.Visible = true;
                    labAnexoConversionProduccion.Visible = true;
                    txtAnexoConversionProduccion.Visible = true;
                    legInformacionHojaServicio.Visible = false;
                }
                else
                {
                    digitarCertificado.Consecutivo = -1;
                    txtNumeroCertificado.Enabled = true;
                    txtNumeroCertificado.Text = "";
                    rbtNuevoCertificado.Visible = false;
                    legInformacionHojaServicio.Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Anexo Conversion").Visible = false;
                    //rbtNuevoCertificado.Items.FindByText("Hoja de Servicio"). = false;
                }
            }
            catch (Exception ex)
            {
                digitarCertificado.Consecutivo = -1;
                txtNumeroCertificado.Enabled = true;
            }
        }

        // Determinar si permite varios vigentes
        if (chkVariosVigentes.Checked == true)
            migracion = 8;


        //try
        //{
        if (txtApellidoProduccion.Enabled == true)
            PrecargueProduccion.InsertarTerceroNombreApellidoPrecargue(txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text);

        if (int.Parse(ddlEstado.SelectedValue.ToString()) == 2 || int.Parse(ddlEstado.SelectedValue.ToString()) == 3)
        {
            //if (rbtNuevoCertificado.SelectedItem.ToString() == "Hoja de Servicio")
            if (labHojaServicioPrincipal.Visible == true)
            {
                if (txtPlanillaBolivar.Enabled == true)
                {
                    //Certificado digitarCertificado = new Certificado();
                    //digitarCertificado.Agencia = txtAgenciaProduccion.Text;
                    digitarCertificado.Agencia = Session["age_Id"].ToString();
                    digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                    digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                    digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                    digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                    digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                    digitarCertificado.Nombre = txtNombreProduccion.Text;
                    digitarCertificado.Cedula = txtCedulaProduccion.Text;
                    digitarCertificado.Apellido = txtApellidoProduccion.Text;
                    digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                    digitarCertificado.Producto = ddlProducto.SelectedValue;
                    digitarCertificado.Compania = ddlCompania.SelectedValue;
                    digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                    Session["precargueCertificado"] = digitarCertificado;
                    //precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, txtAgenciaProduccion.Text, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedItem.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, txtAnexoConversionProduccion.Text);        
                    precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, null, DateTime.Parse(txtVigencia.Text), 4, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);                    
                }
                else
                {
                    
                    //digitarCertificado.Agencia = txtAgenciaProduccion.Text;
                    digitarCertificado.Agencia = Session["age_Id"].ToString();
                    digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                    digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                    digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                    digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                    digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                    digitarCertificado.Nombre = txtNombreProduccion.Text;
                    digitarCertificado.Cedula = txtCedulaProduccion.Text;
                    digitarCertificado.Apellido = txtApellidoProduccion.Text;
                    digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                    digitarCertificado.Producto = ddlProducto.SelectedValue;
                    digitarCertificado.Compania = ddlCompania.SelectedValue;
                    digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                    Session["precargueCertificado"] = digitarCertificado;
                    precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, null, DateTime.Parse(txtVigencia.Text), 4, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                    
                }
            }
            else
                //if (rbtNuevoCertificado.SelectedItem.ToString() == "Anexo Conversion")
                if (conversion.Visible == true)
                {
                    if (txtPlanillaBolivar.Enabled == true)
                    {
                        //Certificado digitarCertificado = new Certificado();
                        digitarCertificado.Agencia = Session["age_Id"].ToString();
                        digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                        digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                        digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                        digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                        digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                        digitarCertificado.Nombre = txtNombreProduccion.Text;
                        digitarCertificado.Cedula = txtCedulaProduccion.Text;
                        digitarCertificado.Apellido = txtApellidoProduccion.Text;
                        digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                        digitarCertificado.Producto = ddlProducto.SelectedValue;
                        digitarCertificado.Compania = ddlCompania.SelectedValue;
                        digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                        Session["precargueCertificado"] = digitarCertificado;
                        precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, txtAnexoConversionProduccion.Text, DateTime.Parse(txtVigencia.Text), 5, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                        
                    }
                    else
                    {
                        //Certificado digitarCertificado = new Certificado();
                        digitarCertificado.Agencia = Session["age_Id"].ToString();
                        digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                        digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                        digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                        digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                        digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                        digitarCertificado.Nombre = txtNombreProduccion.Text;
                        digitarCertificado.Cedula = txtCedulaProduccion.Text;
                        digitarCertificado.Apellido = txtApellidoProduccion.Text;
                        digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                        digitarCertificado.Producto = ddlProducto.SelectedValue;
                        digitarCertificado.Compania = ddlCompania.SelectedValue;
                        digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                        Session["precargueCertificado"] = digitarCertificado;
                        precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, txtAnexoConversionProduccion.Text, DateTime.Parse(txtVigencia.Text), 5, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                    }
                }
                else
                {
                    digitarCertificado.Agencia = Session["age_Id"].ToString();
                    digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                    digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                    digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                    digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                    digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                    digitarCertificado.Nombre = txtNombreProduccion.Text;
                    digitarCertificado.Cedula = txtCedulaProduccion.Text;
                    digitarCertificado.Apellido = txtApellidoProduccion.Text;
                    digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                    digitarCertificado.Producto = ddlProducto.SelectedValue;
                    digitarCertificado.Compania = ddlCompania.SelectedValue;
                    digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                    Session["precargueCertificado"] = digitarCertificado;
                    precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, txtAnexoConversionProduccion.Text, DateTime.Parse(txtVigencia.Text), 5, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                }
        }
        else
        {
            //if (rbtNuevoCertificado.SelectedItem.ToString() == "Hoja de Servicio")
            if (labHojaServicioPrincipal.Visible == true)
            {
                if (txtPlanillaBolivar.Visible == true)
                {
                    //Certificado digitarCertificado = new Certificado();
                    //digitarCertificado.Agencia = txtAgenciaProduccion.Text;
                    digitarCertificado.Agencia = Session["age_Id"].ToString();
                    digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                    digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                    digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                    digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                    digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                    digitarCertificado.Nombre = txtNombreProduccion.Text;
                    digitarCertificado.Cedula = txtCedulaProduccion.Text;
                    digitarCertificado.Apellido = txtApellidoProduccion.Text;
                    digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                    digitarCertificado.Producto = ddlProducto.SelectedValue;
                    digitarCertificado.Compania = ddlCompania.SelectedValue;
                    digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                    Session["precargueCertificado"] = digitarCertificado;
                    //precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, txtAgenciaProduccion.Text, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedItem.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), int.Parse(ddlGrupoDevolucion.SelectedValue.ToString()), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), int.Parse(txtPrimaTotal.Text), txtObservaciones.Text, txtAnexoConversionProduccion.Text);        
                    precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 4, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);                                        
                }
                else
                {
                    //Certificado digitarCertificado = new Certificado();
                    //digitarCertificado.Agencia = txtAgenciaProduccion.Text;
                    digitarCertificado.Agencia = Session["age_Id"].ToString();
                    digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                    digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                    digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                    digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                    digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                    digitarCertificado.Nombre = txtNombreProduccion.Text;
                    digitarCertificado.Cedula = txtCedulaProduccion.Text;
                    digitarCertificado.Apellido = txtApellidoProduccion.Text;
                    digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                    digitarCertificado.Producto = ddlProducto.SelectedValue;
                    digitarCertificado.Compania = ddlCompania.SelectedValue;
                    digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                    Session["precargueCertificado"] = digitarCertificado;
                    precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), txtHojaServicioPrincipal.Text, txtHojaServicioConyuge.Text, txtHojaServicioOtrosAsegurados.Text, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 4, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                    
                }
            }
            else
                //if (rbtNuevoCertificado.SelectedItem.ToString() == "Anexo Conversion")
                if (conversion.Visible == true)
                {
                    if (planillaBolivar.Visible == true)
                    {
                        //Certificado digitarCertificado = new Certificado();
                        digitarCertificado.Agencia = Session["age_Id"].ToString();
                        digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                        digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                        digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                        digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                        digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                        digitarCertificado.Nombre = txtNombreProduccion.Text;
                        digitarCertificado.Cedula = txtCedulaProduccion.Text;
                        digitarCertificado.Apellido = txtApellidoProduccion.Text;
                        digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                        digitarCertificado.Producto = ddlProducto.SelectedValue;
                        digitarCertificado.Compania = ddlCompania.SelectedValue;
                        digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                        Session["precargueCertificado"] = digitarCertificado;
                        precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), txtPlanillaBolivar.Text, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, txtAnexoConversionProduccion.Text, DateTime.Parse(txtVigencia.Text), 5, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                        
                    }
                    else
                    {                        
                        //Certificado digitarCertificado = new Certificado();
                        digitarCertificado.Agencia = Session["age_Id"].ToString();
                        digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                        digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                        digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                        digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                        digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                        digitarCertificado.Nombre = txtNombreProduccion.Text;
                        digitarCertificado.Cedula = txtCedulaProduccion.Text;
                        digitarCertificado.Apellido = txtApellidoProduccion.Text;
                        digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                        digitarCertificado.Producto = ddlProducto.SelectedValue;
                        digitarCertificado.Compania = ddlCompania.SelectedValue;
                        digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                        Session["precargueCertificado"] = digitarCertificado;
                        precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, txtAnexoConversionProduccion.Text, DateTime.Parse(txtVigencia.Text), 5, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                        
                    }
                }
                else
                {
                    if (rblSura.Visible == true)
                    {
                        if (rblSura.SelectedItem.Value == "Ajuste de Prima")
                        {
                            digitarCertificado.Agencia = Session["age_Id"].ToString();
                            digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                            digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                            digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                            digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                            digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                            digitarCertificado.Nombre = txtNombreProduccion.Text;
                            digitarCertificado.Cedula = txtCedulaProduccion.Text;
                            digitarCertificado.Apellido = txtApellidoProduccion.Text;
                            digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                            digitarCertificado.Producto = ddlProducto.SelectedValue;
                            digitarCertificado.Compania = ddlCompania.SelectedValue;
                            digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                            Session["precargueCertificado"] = digitarCertificado;
                            precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 2, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);

                        }
                        else
                        {
                            if (rblSura.SelectedItem.Value == "Designación de Beneficiarios")
                            {
                                digitarCertificado.Agencia = Session["age_Id"].ToString();
                                digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                                digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                                digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                                digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                                digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                                digitarCertificado.Nombre = txtNombreProduccion.Text;
                                digitarCertificado.Cedula = txtCedulaProduccion.Text;
                                digitarCertificado.Apellido = txtApellidoProduccion.Text;
                                digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                                digitarCertificado.Producto = ddlProducto.SelectedValue;
                                digitarCertificado.Compania = ddlCompania.SelectedValue;
                                digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                                Session["precargueCertificado"] = digitarCertificado;
                                precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 3, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);

                            }
                            else
                            {
                                digitarCertificado.Agencia = Session["age_Id"].ToString();
                                digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                                digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                                digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                                digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                                digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                                digitarCertificado.Nombre = txtNombreProduccion.Text;
                                digitarCertificado.Cedula = txtCedulaProduccion.Text;
                                digitarCertificado.Apellido = txtApellidoProduccion.Text;
                                digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                                digitarCertificado.Producto = ddlProducto.SelectedValue;
                                digitarCertificado.Compania = ddlCompania.SelectedValue;
                                digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                                Session["precargueCertificado"] = digitarCertificado;
                                precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 1, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                            }
                        }
                    }
                    else
                    {
                        digitarCertificado.Agencia = Session["age_Id"].ToString();
                        digitarCertificado.FechaExpedicion = DateTime.Parse(txtFechaExpedicionProduccion.Text);
                        digitarCertificado.Vigencia = DateTime.Parse(txtVigencia.Text);
                        digitarCertificado.FechaDigitacion = DateTime.Parse(txtFechaRecibido.Text);
                        digitarCertificado.NumeroCertificado = txtNumeroCertificado.Text;
                        digitarCertificado.NombreAsesor = ddlNombreAsesor.SelectedValue;
                        digitarCertificado.Nombre = txtNombreProduccion.Text;
                        digitarCertificado.Cedula = txtCedulaProduccion.Text;
                        digitarCertificado.Apellido = txtApellidoProduccion.Text;
                        digitarCertificado.Pagaduria = ddlPagaduria.SelectedValue;
                        digitarCertificado.Producto = ddlProducto.SelectedValue;
                        digitarCertificado.Compania = ddlCompania.SelectedValue;
                        digitarCertificado.Localidad = ddlLocalidad.SelectedValue;
                        Session["precargueCertificado"] = digitarCertificado;
                        precargue.CrearNuevoCertificado(txtNumeroCertificado.Text, txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text, digitarCertificado.Agencia, DateTime.Parse(txtFechaExpedicionProduccion.Text), ddlNombreAsesor.SelectedValue.ToString(), ddlPagaduria.SelectedValue.ToString(), DateTime.Parse(txtFechaRecibido.Text), null, ddlEstado.SelectedValue.ToString(), txtFolio.Text, ddlCompania.SelectedValue.ToString(), ddlLocalidad.SelectedValue.ToString(), ddlProducto.SelectedValue.ToString(), null, null, null, int.Parse(Session["age_Id"].ToString()), 0, 0, 0, null, null, DateTime.Parse(txtVigencia.Text), 1, (int)Session["mesProduccion"], migracion, digitarCertificado.Consecutivo, cerAnterior);
                    }
                }
        }
        if (chkCambioInter.Checked == true || chkSiniestroP.Checked == true || chkSiniestroC.Checked == true)
        {
            if (chkCambioInter.Checked == true)
            {
                objAdministrarCertificados.spInsertarCasoEspecialPreCargue(7, int.Parse(txtCedulaProduccion.Text.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
            }
            if (chkSiniestroP.Checked == true || chkSiniestroC.Checked == true)
            {
                if (chkSiniestroP.Checked == true && chkSiniestroC.Checked == false)
                {
                    objAdministrarCertificados.spInsertarCasoEspecialPreCargue(4, int.Parse(txtCedulaProduccion.Text.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
                }
                if (chkSiniestroP.Checked == false && chkSiniestroC.Checked == true)
                {
                    objAdministrarCertificados.spInsertarCasoEspecialPreCargue(5, int.Parse(txtCedulaProduccion.Text.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
                }
                if (chkSiniestroP.Checked == true && chkSiniestroC.Checked == true)
                {
                    objAdministrarCertificados.spInsertarCasoEspecialPreCargue(6, int.Parse(txtCedulaProduccion.Text.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
                }
            }
        }
        else
        {
            DataTable dtCasesp_IdPreCargue = new DataTable();
            dtCasesp_IdPreCargue = objAdministrarCertificados.ConsultarCasoEspecialPreCargue(int.Parse(txtNumeroCertificado.Text), int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(txtCedulaProduccion.Text));

            if (dtCasesp_IdPreCargue.Rows[0]["casesp_Id"].ToString() == "")
            {
                objAdministrarCertificados.spInsertarCasoEspecialPreCargue(0, int.Parse(txtCedulaProduccion.Text.ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));
            }
        }
        //Response.Redirect("ProduccionNueva.aspx");
        Response.RedirectToRoute("precargue");
    }

    protected void Devolucion(object sender, EventArgs e)
    {
        if (int.Parse(ddlEstado.SelectedValue.ToString()) == 2 || int.Parse(ddlEstado.SelectedValue.ToString()) == 3)
        {
            prima.Visible = true;
            devolucion.Visible = true;
            devolucionCausal.Visible = true;
            observaciones.Visible = true;
            reqtxtPrimaTotal.Enabled = true;
            reqtxtObservaciones.Enabled = true;
            reqddlCausal.Enabled = true;
        }
        else
        {
            prima.Visible = false;
            devolucion.Visible = false;
            devolucionCausal.Visible = false;
            observaciones.Visible = false;
            reqtxtPrimaTotal.Enabled = false;
            reqtxtObservaciones.Enabled = false;
            reqddlCausal.Enabled = false;
        }
    }

    protected void InsertarApellidoTercero(object sender, EventArgs e)
    {
        PrecargueProduccion.InsertarTerceroNombreApellidoPrecargue(txtCedulaProduccion.Text, txtNombreProduccion.Text, txtApellidoProduccion.Text);
    }

    protected void chkVariosVigentes_CheckedChanged(object sender, EventArgs e)
    {
        if (chkVariosVigentes.Checked == true)
            txtNumeroCertificado.Enabled = true;
        else
            txtNumeroCertificado.Enabled = false;
    }


    //Viviana 
    //Cambio de intermediario ########## habilitar boton para digitar certificados
    protected void Check_Clicked(Object sender, EventArgs e)
    {
        if (chkCambioInter.Checked == true)
        {
            btnPrecargue.Enabled = true;
        }
        else if (chkCambioInter.Checked == false)
        {
            btnPrecargue.Enabled = false;
        }
    }

    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dtPagaduria = new DataTable();
        dtPagaduria = objAdministrarCertificados.consultarConvenios(int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlPagaduria.SelectedValue.ToString()));
        if (dtPagaduria.Rows.Count == 0)
        {
            btnPrecargue.Enabled = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE PRE CARGUE NO PUEDE SER GUARDADO PORQUE POR ESTA LOCALIDAD, PRODUCTO Y PAGADURIA NO EXISTE CONVENIO " + "');", true);
        }
        else
        {
            btnPrecargue.Enabled = true;
        }
    }
}