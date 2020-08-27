using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class Presentacion5_CartaRetiro : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());
        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];
        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);

        if (grvGestionRetiro.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos idCartaRetiro y cer_Id de la tabla que se muestra al usuario 
            grvGestionRetiro.HeaderRow.Cells[1].Visible = false;
            grvGestionRetiro.HeaderRow.Cells[2].Visible = false;
            grvGestionRetiro.HeaderRow.Cells[4].Visible = false;

            int cont = 0;
            foreach (GridViewRow rows in grvGestionRetiro.Rows)
            {
                grvGestionRetiro.Rows[cont].Cells[1].Visible = false;
                grvGestionRetiro.Rows[cont].Cells[2].Visible = false;
                grvGestionRetiro.Rows[cont].Cells[4].Visible = false;
                cont++;
            }
        }
        if (grvInformeRetiros.Rows.Count == 0)
        {
            //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');$('#tab-1').addClass('in active'); $('a[href=#tab-1]').parent().addClass('active');", true);
        }
        else
        {
            //Ocultar los campos idCartaRetiro y cer_Id de la tabla que se muestra al usuario 
            grvInformeRetiros.HeaderRow.Cells[0].Visible = false;
            grvInformeRetiros.HeaderRow.Cells[1].Visible = false;

            int cont = 0;
            foreach (GridViewRow rows in grvInformeRetiros.Rows)
            {
                grvInformeRetiros.Rows[cont].Cells[0].Visible = false;
                grvInformeRetiros.Rows[cont].Cells[1].Visible = false;
                cont++;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            ListarRetiros();
            CargarListas();
        }
    }

    #region Cargar Listas

    //Método para cargar todas las listas iniciales del módulo, para llenar los seleccionables de la interfaz
    protected void CargarListas()
    {
        DataTable dt = AdministrarCartaRetiro.ListarOrigenOficio();
        ddlOrigen.DataSource = dt;
        ddlOrigen.DataTextField = "ori_Nombre";
        ddlOrigen.DataValueField = "ori_Id";
        ddlOrigen.DataBind();
        ddlOrigen.Items.Insert(0, new ListItem("Seleccione", ""));
        ddlOrigenOficio.DataSource = dt;
        ddlOrigenOficio.DataTextField = "ori_Nombre";
        ddlOrigenOficio.DataValueField = "ori_Id";
        ddlOrigenOficio.DataBind();
        ddlOrigenOficio.Items.Insert(0, new ListItem("Seleccione", ""));

        DataTable dtCompania = AdministrarCartaRetiro.ListarCompania();
        ddlCompania.DataSource = dtCompania;
        ddlCompania.DataTextField = "com_Nombre";
        ddlCompania.DataValueField = "com_Id";
        ddlCompania.DataBind();
        ddlCompania.Items.Insert(0, new ListItem("NO APLICA", "0"));

        ddlCompañia.DataSource = dtCompania;
        ddlCompañia.DataTextField = "com_Nombre";
        ddlCompañia.DataValueField = "com_Id";
        ddlCompañia.DataBind();
        ddlCompañia.Items.Insert(0, new ListItem("NO APLICA", "0"));

        DataTable dtTipoInforme = AdministrarCartaRetiro.ListarTipoInforme();
        ddlTipoInforme.DataTextField = "tip_Nombre";
        ddlTipoInforme.DataValueField = "tip_Id";
        ddlTipoInforme.DataSource = dtTipoInforme;
        ddlTipoInforme.DataBind();
        ddlTipoInforme.Items.Insert(0, new ListItem("Seleccione", ""));

        DataTable dtCausalRetiro = AdministrarCartaRetiro.ListarCausal();
        ddlCausalRetiro.DataSource = dtCausalRetiro;
        ddlCausalRetiro.DataTextField = "cau_Nombre";
        ddlCausalRetiro.DataValueField = "cau_Id";
        ddlCausalRetiro.DataBind();

        DataTable dtTipoGestion = AdministrarCartaRetiro.ListarTipoGestion();
        ddlTipoGestion.DataSource = dtTipoGestion;
        ddlTipoGestion.DataTextField = "tipGes_Nombre";
        ddlTipoGestion.DataValueField = "tipGes_Id";
        ddlTipoGestion.DataBind();
        ddlTipoGestion.Items.Insert(0, new ListItem("Seleccione", ""));
        ddlGestion.DataSource = dtTipoGestion;
        ddlGestion.DataTextField = "tipGes_Nombre";
        ddlGestion.DataValueField = "tipGes_Id";
        ddlGestion.DataBind();
        ddlGestion.Items.Insert(0, new ListItem("Seleccione", ""));

        DataTable dtProducto = AdministrarCartaRetiro.ListarProductosCompania(int.Parse(ddlCompañia.Text));
        ddlProducto.DataSource = dtProducto;
        ddlProducto.DataTextField = "pro_Nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataBind();
        ddlProducto.Items.Insert(0, new ListItem("NO APLICA", "0"));

        DataTable dtLocalidad = AdministrarCartaRetiro.ListarLocalidad();
        ddlLocalidad.DataSource = dtLocalidad;
        ddlLocalidad.DataTextField = "dep_Nombre";
        ddlLocalidad.DataValueField = "dep_Id";
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));

        btnGuardar.Visible = true;
        btnActualizar.Visible = false;
        btnCancelar.Visible = true;
        btnRecuperar.Visible = false;
        btnGuardarGestion.Visible = false;
        btnRegresar.Visible = false;
        btnGuardarObs.Visible = false;
        btnDescargar.Visible = false;
        grvCertificados.Visible = false;
        grvTercero.Visible = false;
        txtSeguimiento.Visible = false;
        lblSeguimiento.Visible = false;
        txtIdCartaObs.Visible = false;
        txtCedulaObs.Visible = false;
        txtUsuarioObs.Visible = false;
        txtMenuObs.Visible = false;
        lblDocumento.Visible = false;
        lblLocalidad1.Visible = false;
        lblCompañía.Visible = false;
        lblProducto.Visible = false;
        lblTipoGestion.Visible = false;
        lblOrigenOficio.Visible = false;
        lblFechaDesde.Visible = false;
        lblFechaHasta.Visible = false;
        txtDocumento2.Visible = false;
        ddlLocalidad.Visible = false;
        ddlCompañia.Visible = false;
        ddlProducto.Visible = false;
        ddlGestion.Visible = false;
        ddlOrigenOficio.Visible = false;
        txtFechaDesde.Visible = false;
        txtFechaHasta.Visible = false;
        btnBuscarInforme.Visible = false;
        btnLimpiarInforme.Visible = false;
        grvInformeRetiros.Visible = false;
    }

    //Muestra los retiros que se digitaron ese día y la gestión realizada
    protected void ListarRetiros()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarRetiro();
        grvGestionRetiro.DataSource = dt;
        grvGestionRetiro.DataBind();
    }
    #endregion

    #region Paginadores

    protected void grvGestionRetiro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGestionRetiro.PageIndex = e.NewPageIndex;
        ListarRetiros();
    }

    protected void grvGestionRetiro_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvGestionRetiro.Rows.Count < grvGestionRetiro.PageSize) && (grvGestionRetiro.Rows.Count + grvGestionRetiro.PageSize * grvGestionRetiro.PageIndex < ((DataTable)(grvGestionRetiro.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }

    protected void grvInformeRetiros_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvInformeRetiros.PageIndex = e.NewPageIndex;
        ListarRetiros();
    }

    protected void grvInformeRetiros_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvInformeRetiros.Rows.Count < grvInformeRetiros.PageSize) && (grvInformeRetiros.Rows.Count + grvInformeRetiros.PageSize * grvInformeRetiros.PageIndex < ((DataTable)(grvInformeRetiros.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }
    #endregion

    #region Digitar Carta

    //Muestra la información básica del asegurado que se va a retirar de la compañía
    protected void btnBuscarTercero_Click(object sender, EventArgs e)
    {
        if (txtDocumento.Text != "")
        {
            DataTable dt = new DataTable();
            dt = AdministrarCartaRetiro.MostrarTercero(int.Parse(txtDocumento.Text));
            grvListTercero.DataSource = dt;
            grvListTercero.DataBind();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('No existe el documento');", true);
        }

        grvTercero.Visible = true;
        grvCertificados.Visible = false;
    }

    //Muestra el resultado del asegurado consultado 
    protected void grvListTercero_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvListTercero.Rows[(index)];

        //Botón para consultar los certificados que tenga el asegurado en la compañía y sus estados
        if (e.CommandName == "Consultar_Click")
        {
            grvCertificados.Visible = true;
            int ter_Id = int.Parse(row.Cells[1].Text);
            AdministrarCartaRetiro.MostrarCertificado(ter_Id);

            DataTable dt = new DataTable();
            dt = DAOAdministrarCartaRetiro.MostrarCertificado(ter_Id);
            grvDigitarRetiro.DataSource = dt;
            grvDigitarRetiro.DataBind();

            if (dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El cliente no tiene certificados en la compañía');", true);
            }
            else
            {
                //Ocultar los campos de cer_Id y pro_Id de la tabla que no son necesarios para el usuario
                grvDigitarRetiro.HeaderRow.Cells[1].Visible = false;
                grvDigitarRetiro.HeaderRow.Cells[9].Visible = false;
                int cont = 0;

                foreach (DataRow rows in dt.Rows)
                {
                    grvDigitarRetiro.Rows[cont].Cells[1].Visible = false;
                    grvDigitarRetiro.Rows[cont].Cells[9].Visible = false;
                    cont++;
                }
            }
        }

        //Redirecciona al usuario al formulario de gestion de terceros, para permitirle editar la información básica del asegurado.
        if (e.CommandName == "EditarTercero_Click")
        {
            Session["cedulaTemp"] = txtDocumento.Text;
            Response.RedirectToRoute("gestionTerceros");
        }
    }

    //Muestra la opción de digitar retiro al asegurado seleccionado
    protected void grvDigitarRetiro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvDigitarRetiro.Rows[(index)];

        if (e.CommandName == "Digitar_Click")
        {
            int cer_Id = int.Parse(row.Cells[1].Text);
            DataTable dt = new DataTable();
            dt = DAOAdministrarCartaRetiro.ListarCertificado(cer_Id);

            //Valida si el cliente tiene un retiro pendiente por aplicar para no permitir que se digite otro retiro
            DataTable dtExistente = new DataTable();
            dtExistente = AdministrarCartaRetiro.ValidarExistente(int.Parse(row.Cells[2].Text), (row.Cells[3].Text));

            int gestionRec = 0;

            if (dtExistente.Rows.Count > 0)
            {
                if (dtExistente.Rows[0]["gesret_GestionRec"].ToString() != "")
                {
                    gestionRec = int.Parse(dtExistente.Rows[0]["gesret_GestionRec"].ToString());
                }
            }

            //Valida si el cliente tiene un certificado con estado Producción nueva para digitar el retiro
            DataTable dtProduccionNueva = new DataTable();
            dtProduccionNueva = AdministrarCartaRetiro.ValidarProduccionNueva(int.Parse(row.Cells[2].Text), int.Parse(row.Cells[9].Text));

            //Si el asegurado no tiene cartas de retiro o si tiene gestiones de recuperación o desistimiento, permite digitar un retiro de lo contrario no
            if (((dtExistente.Rows.Count == 0) && (dtProduccionNueva.Rows.Count == 0)) || gestionRec == 3 || gestionRec == 2)
            {
                if (row.Cells[7].Text == "VIGENTE")
                {
                    grvDigitarRetiro.DataSource = dt;

                    try
                    {
                        txtIdCertificado.Text = dt.Rows[0]["Id"].ToString();
                        txtCedulaCertificado.Text = dt.Rows[0]["Cedula"].ToString();
                        txtCertificado.Text = dt.Rows[0]["Certificado"].ToString();
                        txtValorPpal.Text = dt.Rows[0]["Valor Asegurado P"].ToString();
                        txtValorConyuge.Text = dt.Rows[0]["Valor Asegurado C"].ToString();
                        txtPrima.Text = dt.Rows[0]["Prima"].ToString();
                        txtDepartamento.Text = dt.Rows[0]["Departamento"].ToString();
                        txtPagaduria.Text = dt.Rows[0]["Pagaduría"].ToString();
                        txtProducto.Text = dt.Rows[0]["Producto"].ToString();
                        txtProId.Text = dt.Rows[0]["pro_Id"].ToString();
                        txtPagaId.Text = dt.Rows[0]["paga_Id"].ToString();
                        string usuario = Session["usuario"].ToString();
                        txtUsuario.Text = usuario;

                        ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-2');$('#tab-2').addClass('in active'); $('a[href=#tab-2]').parent().addClass('active');", true);
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Valide los amparos del certificado');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El certificado no se encuentra vigente o existe un retiro digitado');", true);
                }
            }
            else if ((dtExistente.Rows.Count == 0) && (dtProduccionNueva.Rows.Count > 0))
            {
                if (row.Cells[7].Text == "PRODUCCION NUEVA")
                {
                    grvDigitarRetiro.DataSource = dt;

                    txtIdCertificado.Text = dt.Rows[0]["Id"].ToString();
                    txtCedulaCertificado.Text = dt.Rows[0]["Cedula"].ToString();
                    txtCertificado.Text = dt.Rows[0]["Certificado"].ToString();
                    txtValorPpal.Text = dt.Rows[0]["Valor Asegurado P"].ToString();
                    txtValorConyuge.Text = dt.Rows[0]["Valor Asegurado C"].ToString();
                    txtPrima.Text = dt.Rows[0]["Prima"].ToString();
                    txtDepartamento.Text = dt.Rows[0]["Departamento"].ToString();
                    txtPagaduria.Text = dt.Rows[0]["Pagaduría"].ToString();
                    txtProducto.Text = dt.Rows[0]["Producto"].ToString();
                    txtProId.Text = dt.Rows[0]["pro_Id"].ToString();
                    txtPagaId.Text = dt.Rows[0]["paga_Id"].ToString();
                    string usuario = Session["usuario"].ToString();
                    txtUsuario.Text = usuario;

                    ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-2');$('#tab-2').addClass('in active'); $('a[href=#tab-2]').parent().addClass('active');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Se debe digitar el retiro al certificado en PRODUCCIÓN NUEVA o existe un retiro digitado');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El certificado no se encuentra vigente o existe un retiro digitado');", true);
            }
        }
    }

    //Inserta en la base de datos la información de la carta de retiro digitada por el usuario
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        btnGuardar.Visible = true;
        btnActualizar.Visible = false;

        if (txtCedulaCertificado.Text != "" & txtCertificado.Text != "" & txtValorPpal.Text != "" & txtValorConyuge.Text != "" & txtPrima.Text != "" & txtDepartamento.Text != "" & txtPagaduria.Text != "" & txtFechaCompania.Text != "" & txtProducto.Text != "" & txtFechaTg.Text != "" & txtFechaCasaMatriz.Text != "" & ddlCompania.Text != "" & ddlOrigen.Text != "")
        {
            //Validar si el cliente tiene cónyuge u otros asegurados para calcular el tipo de movimiento correcto
            DataTable dtExistente = new DataTable();
            dtExistente = AdministrarCartaRetiro.ConsultarConyuge(int.Parse(txtIdCertificado.Text));
            {
                if (((DateTime.Parse(txtFechaTg.Text)) > (DateTime.Now.Date)) || ((DateTime.Parse(txtFechaCasaMatriz.Text)) > (DateTime.Now.Date)) || ((DateTime.Parse(txtFechaCompania.Text))) > (DateTime.Now.Date))
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Las fechas no pueden ser mayores a la actual');", true);
                }
                else
                {
                    //Insertar carta de retiro del asegurado
                    AdministrarCartaRetiro.InsertarCartaRetiro(int.Parse(txtCedulaCertificado.Text), double.Parse(txtCertificado.Text), int.Parse(txtPagaId.Text), int.Parse(ddlCompania.Text), int.Parse(txtProId.Text), DateTime.Parse(txtFechaTg.Text), DateTime.Parse(txtFechaCasaMatriz.Text), DateTime.Parse(txtFechaCompania.Text), ddlOrigen.Text, txtObservacion.Text, txtUsuario.Text);

                    //Actualiza los tipos de movimiento del certificado, validando la existencia de cónyuge y otros asegurados
                    AdministrarCartaRetiro.ActualizarMovimiento(int.Parse(txtIdCertificado.Text));

                    //Insertar novedad de retiro de cada certificado
                    AdministrarCartaRetiro.InsertarNovedad(int.Parse(txtCedulaCertificado.Text), (int.Parse(txtIdCertificado.Text)));
                    ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-3'); alert('" + "Se guardó el retiro exitosamente" + "');window.location.replace('/gestion/retiros')", true);
                }
            }

            //Se actualiza el certificado del asegurado a retirar, en los campos de vigencia retiro principal-cónyuge y causal de retiro
            DataTable dt = new DataTable();
            dt = AdministrarCartaRetiro.ConsultarIdCarta(int.Parse(txtCedulaCertificado.Text), (double.Parse(txtCertificado.Text)));
            int idCarta = int.Parse(dt.Rows[0]["IdCarta"].ToString());
            int idCertificado = int.Parse(dt.Rows[0]["IdCertificado"].ToString());
            AdministrarCartaRetiro.ActualizarVigenciaCer(idCarta, idCertificado);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por diligenciar');", true);
        }
    }
    #endregion Digitar Retiro

    #region Gestionar Retiro

    //Muestra las opciones posibles para cada carta de retiro del asegurado que se encuentra en el sistema
    protected void grvGestionarRetiro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvGestionRetiro.Rows[(index)];

        //Habilita los campos de la pestaña de gestionar retiros, para cargar los datos pertinentes a la gestión realizada por el usuario.
        if (e.CommandName == "Gestionar_Click")
        {
            try
            {
                int idCarta = int.Parse(row.Cells[1].Text);
                int cer_Id = int.Parse(row.Cells[2].Text);
                DataTable dt = new DataTable();
                dt = DAOAdministrarCartaRetiro.GestionarRetiro(idCarta, cer_Id);

                btnGuardarGestion.Visible = true;
                btnRecuperar.Visible = false;

                //Valida si el retiro ya fue gestionado por el auxiliar para no duplicar registros
                DataTable dtExistente = new DataTable();
                dtExistente = AdministrarCartaRetiro.ValidarGestionExistente(int.Parse(row.Cells[3].Text), double.Parse(row.Cells[5].Text), int.Parse(row.Cells[1].Text));

                if ((dtExistente.Rows.Count == 0))
                {
                    grvGestionRetiro.DataSource = dt;

                    txtCedulaGes.Text = dt.Rows[0]["Cédula"].ToString();
                    txtCertificadoGes.Text = dt.Rows[0]["Certificado"].ToString();
                    txtPrincipal.Text = dt.Rows[0]["Valor Asegurado Principal"].ToString();
                    txtConyuge.Text = dt.Rows[0]["Valor Asegurado Cónyuge"].ToString();
                    txtPrimaGes.Text = dt.Rows[0]["Prima"].ToString();
                    txtProGes.Text = dt.Rows[0]["Producto"].ToString();
                    txtProId.Text = dt.Rows[0]["pro_Id"].ToString();
                    txtDepAsesor.Text = dt.Rows[0]["localidad"].ToString();
                    txtFechaCarta.Text = Convert.ToDateTime(dt.Rows[0]["fecha Tg"].ToString()).ToString("yyyy-MM-dd");
                    txtIdCarta.Text = dt.Rows[0]["Id Carta"].ToString();

                    ListarAsesoresLocalidad();

                    ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-5');$('#tab-5').addClass('in active'); $('a[href=#tab-5]').parent().addClass('active');", true);
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El retiro ya fue gestionado');", true);
                }

                //Calcular la vigencia del retiro de acuerdo al producto y con la menor fecha en que se recibió la carta de retiro
                DataTable dtVigencia = new DataTable();
                dtVigencia = AdministrarCartaRetiro.CalcularVigencia(int.Parse(dt.Rows[0]["Id"].ToString()));

                int diaCarta = int.Parse(dtVigencia.Rows[0]["dia_Carta"].ToString());
                int mesVigenciaRetiro = int.Parse(dtVigencia.Rows[0]["mes_VigenciaRetiro"].ToString());
                string fechaCarta = Convert.ToDateTime(dtVigencia.Rows[0]["car_fechaAgencia"].ToString()).ToString("yyyy-MM-dd");
                string fechaCompañia = Convert.ToDateTime(dtVigencia.Rows[0]["car_fechaCompañia"].ToString()).ToString("yyyy-MM-dd");
                string fechaCasaMatriz = Convert.ToDateTime(dtVigencia.Rows[0]["car_fechaCasamatriz"].ToString()).ToString("yyyy-MM-dd");
                DateTime fechaTg = DateTime.Parse(fechaCarta);
                DateTime fechaCia = DateTime.Parse(fechaCompañia);
                DateTime fechaMatriz = DateTime.Parse(fechaCasaMatriz);
                DateTime fechaCalculo = Convert.ToDateTime("01/01/1900");

                //Valida cual es la menor fecha registrada por cada carta de retiro para calcular el inicio de vigencia del retiro
                if (fechaTg < fechaCia)
                {
                    if (fechaTg < fechaMatriz)
                    {
                        fechaCalculo = fechaTg;
                    }
                    else
                    {
                        fechaCalculo = fechaMatriz;
                    }
                }
                else if (fechaCia < fechaTg)
                {
                    if (fechaCia < fechaMatriz)
                    {
                        fechaCalculo = fechaCia;
                    }
                    else
                    {
                        fechaCalculo = fechaMatriz;
                    }
                }
                else if (fechaMatriz < fechaTg)
                {
                    if (fechaMatriz < fechaCia)
                    {
                        fechaCalculo = fechaMatriz;
                    }
                    else
                    {
                        fechaCalculo = fechaCia;
                    }
                }
                else
                {
                    fechaCalculo = fechaTg;
                }

                //Adiciona a la menor fecha la cantidad de meses de acuerdo al producto y reinicia el día al primero de cada mes
                fechaCalculo = fechaCalculo.AddMonths(mesVigenciaRetiro);
                DateTime vigencia = fechaCalculo;
                vigencia = (vigencia.AddDays(-fechaCalculo.Day)).AddDays(1);
                txtFechaVigencia.Text = Convert.ToDateTime(vigencia.ToString()).ToString("dd/MM/yyyy");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Valide que el certificado tenga amparos');", true);
            }
        }

        //Permite una segunda gestión de recuperacion o desistimiento cuando una carta de retiro se cerró como RETIRO DEFINITIVO
        if (e.CommandName == "Recuperar_Click")
        {
            try
            {
                int idCarta = int.Parse(row.Cells[1].Text);
                int cer_Id = int.Parse(row.Cells[2].Text);
                DataTable dt = new DataTable();
                dt = DAOAdministrarCartaRetiro.RecuperarRetiro(idCarta, cer_Id);
                btnRecuperar.Visible = true;
                btnGuardarGestion.Visible = false;

                foreach (GridViewRow rows in grvGestionRetiro.Rows)
                {
                    //Valida si el retiro ya fue recuperado por el auxiliar para no insertar un doble registro
                    DataTable dtExistente = new DataTable();
                    dtExistente = AdministrarCartaRetiro.ValidarRecuperacionExistente(int.Parse(row.Cells[3].Text), double.Parse(row.Cells[5].Text));

                    if ((dtExistente.Rows.Count == 0))
                    {
                        if (row.Cells[10].Text == "RETIRO DEFINITIVO")
                        {
                            grvGestionRetiro.DataSource = dt;

                            txtCedulaGes.Text = dt.Rows[0]["Cédula"].ToString();
                            txtCertificadoGes.Text = dt.Rows[0]["Certificado"].ToString();
                            txtPrincipal.Text = dt.Rows[0]["Valor Asegurado Principal"].ToString();
                            txtConyuge.Text = dt.Rows[0]["Valor Asegurado Cónyuge"].ToString();
                            txtPrimaGes.Text = dt.Rows[0]["Prima"].ToString();
                            txtProGes.Text = dt.Rows[0]["Producto"].ToString();
                            txtProId.Text = dt.Rows[0]["pro_Id"].ToString();
                            txtDepAsesor.Text = dt.Rows[0]["dep_Id"].ToString();
                            txtFechaCarta.Text = Convert.ToDateTime(dt.Rows[0]["fecha Tg"].ToString()).ToString("yyyy-MM-dd");
                            txtFechaGestion.Text = dt.Rows[0]["Fecha Contacto"].ToString();
                            txtFechaVigencia.Text = ("dd/mm/aaaa");
                            ddlCausalRetiro.Enabled = false;

                            ListarAsesoresLocalidad();

                            ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-5');$('#tab-5').addClass('in active'); $('a[href=#tab-5]').parent().addClass('active');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Solo se recuperaran certificados con estado: RETIRO DEFINITIVO');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El cliente ya se recuperó');", true);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Valide los amparos del certificado');", true);
            }
        }

        //Habilita los campos de carta de retiro cargando la información digitada anteriormente para editarla en caso de necesitarlo
        if (e.CommandName == "Editar_Click")
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnCancelar.Visible = true;
            int cer_Id = int.Parse(row.Cells[2].Text);
            int idCartaRetiro = int.Parse(row.Cells[1].Text);
            DateTime fechaCarta = DateTime.Parse(row.Cells[9].Text);
            DataTable dt = new DataTable();
            dt = DAOAdministrarCartaRetiro.EditarRetiro(cer_Id, idCartaRetiro);

            //Valida la fecha en la que se recibio la carta de retiro, para que solo se editen aquellas cartas del mes actual
            if (fechaCarta.Month < DateTime.Now.Month)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Solo se pueden editar retiros del mes actual');", true);
            }
            else
            {
                grvDigitarRetiro.DataSource = dt;

                txtIdCartaRetiro.Text = dt.Rows[0]["IdCarta"].ToString();
                txtIdCertificado.Text = dt.Rows[0]["Id"].ToString();
                txtCedulaCertificado.Text = dt.Rows[0]["Cedula"].ToString();
                txtCertificado.Text = dt.Rows[0]["Certificado"].ToString();
                txtValorPpal.Text = dt.Rows[0]["Valor Asegurado P"].ToString();
                txtValorConyuge.Text = dt.Rows[0]["Valor Asegurado C"].ToString();
                txtPrima.Text = dt.Rows[0]["Prima"].ToString();
                txtDepartamento.Text = dt.Rows[0]["Departamento"].ToString();
                txtPagaduria.Text = dt.Rows[0]["Pagaduría"].ToString();
                txtProducto.Text = dt.Rows[0]["Producto"].ToString();
                txtProId.Text = dt.Rows[0]["pro_Id"].ToString();
                txtPagaId.Text = dt.Rows[0]["paga_Id"].ToString();
                string usuario = Session["usuario"].ToString();
                txtFechaTg.Text = Convert.ToDateTime(dt.Rows[0]["FechaTg"].ToString()).ToString("yyyy-MM-dd");
                txtFechaCasaMatriz.Text = Convert.ToDateTime(dt.Rows[0]["FechaCasaMatriz"].ToString()).ToString("yyyy-MM-dd");
                txtFechaCompania.Text = Convert.ToDateTime(dt.Rows[0]["FechaCompañia"].ToString()).ToString("yyyy-MM-dd");
                txtObservacion.Text = dt.Rows[0]["Observacion"].ToString();
                ddlCompania.Text = dt.Rows[0]["Compañia"].ToString();
                ddlOrigen.Text = dt.Rows[0]["OrigenOficio"].ToString();

                ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-2');$('#tab-2').addClass('in active'); $('a[href=#tab-2]').parent().addClass('active');", true);
            }
        }

        //Permite eliminar de la base de datos una carta retiro y a su vez la gestión realizada y la novedad que se haya generado para la misma
        if (e.CommandName == "Eliminar_Click")
        {
            int idCarta = int.Parse(row.Cells[1].Text);
            int ter_Id = int.Parse(row.Cells[3].Text);
            double cer_Certificado = double.Parse(row.Cells[5].Text);

            AdministrarCartaRetiro.EliminarRetiro(idCarta, ter_Id, cer_Certificado);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El retiro se ha eliminado con éxito');", true);

            ListarRetiros();
            Response.RedirectToRoute("gestionRetiros");
        }

        //Permite ingresar observaciones a cada una de las cartas, con el fin de llevar un control sobre las gestiones hechas por casa usuario.
        if (e.CommandName == "Ver_Click")
        {
            int idCarta = int.Parse(row.Cells[1].Text);
            int ter_Id = int.Parse(row.Cells[3].Text);
            string nombre = (row.Cells[4].Text);
            string certificado = (row.Cells[5].Text);
            lblNombreAsegurado.Text = "Nombre: " + nombre;
            lblCedula.Text = "Cédula: " + ter_Id;
            lblPoliza.Text = "Certificado: " + certificado;
            ListarObservacion(idCarta);
            btnRegresar.Visible = true;
            lblSeguimiento.Visible = true;
            txtSeguimiento.Visible = true;
            txtIdCartaObs.Text = int.Parse(row.Cells[1].Text).ToString();
            txtCedulaObs.Text = int.Parse(row.Cells[3].Text).ToString();
            txtUsuarioObs.Text = (string)Session["usuario"];
            DataTable dtMenu = (DataTable)Session["menuSistema"];
            string menu = dtMenu.Rows[5]["men_id"].ToString();
            txtMenuObs.Text = menu;
            btnGuardarObs.Visible = true;

            ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-4');$('#tab-4').addClass('in active'); $('a[href=#tab-4]').parent().addClass('active');", true);
        }
    }

    //Inserta en la base de datos los datos digitados por los usuarios cuando se realiza una segunda gestión de recuperación
    protected void btnGuardarRecuperacion_Click(object sender, EventArgs e)
    {
        if (txtCedulaGes.Text != "" & txtCertificadoGes.Text != "" & ddlTipoGestion.Text != "" & ddlAsesor.SelectedValue.ToString() != "" & txtFechaGestion.Text != "" & txtHora.Text != "")
        {
            if ((DateTime.Parse(txtFechaGestion.Text)) > (DateTime.Now.Date))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Las fechas no pueden ser mayores a la actual');", true);
            }
            else
            {
                //Actualiza la gestión del asegurado de un retiro definitivo a una recuperación o desistimiento
                AdministrarCartaRetiro.ActualizarRecuperacionRetiro(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text), DateTime.Parse(txtFechaGestion.Text), txtHora.Text, int.Parse(ddlAsesor.SelectedValue.ToString()), txtObservacionGes.Text, int.Parse(ddlTipoGestion.SelectedValue.ToString()));

                //Inserta o actualiza la novedad de recuperación del asegurado
                AdministrarCartaRetiro.InsertarNovedadRecuperacion(int.Parse(txtCedulaGes.Text), (double.Parse(txtCertificadoGes.Text)));

                //Actualiza los tipos de movimientos a recuperaciones
                AdministrarCartaRetiro.ActualizarMovimientoRecuperacion(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text));
                ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-3'); alert('" + "Se guardó la recuperación exitosamente" + "');window.location.replace('/gestion/retiros')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Faltan campos por diligenciar');", true);
        }
    }

    //Retorna al usuario a la pestaña donde se listan todos los retiros
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-1');window.location.replace('/gestion/retiros')", true);
    }

    //Inserta en la base de datos los datos digitados por los usuarios cuando se realiza la gestión de la carta de retiro
    protected void btnGuardarGestion_Click(object sender, EventArgs e)
    {
        if (txtCedulaGes.Text != "" & txtCertificadoGes.Text != "" & txtProId.Text != "" & txtPrimaGes.Text != "" & txtPrincipal.Text != "" & txtConyuge.Text != "" & ddlTipoGestion.Text != "" & ddlAsesor.SelectedValue.ToString() != "" & txtFechaGestion.Text != "" & txtHora.Text != "" & txtFechaCarta.Text != "" & txtFechaVigencia.Text != "" & ddlCausalRetiro.Text != "")
        {
            if ((DateTime.Parse(txtFechaGestion.Text)) > (DateTime.Now.Date))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Las fechas no pueden ser mayores a la actual');", true);
            }
            else
            {
                //Inserta la gestion del retiro, teniendo en cuenta si hubo llamada efectiva o no
                if (chkLlamada.Checked == true)
                {
                    AdministrarCartaRetiro.InsertarGestionRetiro(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text), int.Parse(txtProId.Text), DateTime.Parse(txtFechaGestion.Text), txtHora.Text, int.Parse(ddlAsesor.SelectedValue.ToString()), txtObservacionGes.Text, DateTime.Parse(txtFechaCarta.Text), int.Parse(ddlTipoGestion.SelectedValue.ToString()), DateTime.Parse(txtFechaVigencia.Text), int.Parse(ddlCausalRetiro.SelectedValue.ToString()), int.Parse(txtIdCarta.Text), 1);
                }
                else
                {
                    AdministrarCartaRetiro.InsertarGestionRetiro(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text), int.Parse(txtProId.Text), DateTime.Parse(txtFechaGestion.Text), txtHora.Text, int.Parse(ddlAsesor.SelectedValue.ToString()), txtObservacionGes.Text, DateTime.Parse(txtFechaCarta.Text), int.Parse(ddlTipoGestion.SelectedValue.ToString()), DateTime.Parse(txtFechaVigencia.Text), int.Parse(ddlCausalRetiro.Text), int.Parse(txtIdCarta.Text), 0);
                }
                try
                {
                    //Actualiza el mes de producción, la fecha de inicio de vigencia y la causal de retiro en el certificado al momento de digitar una carta a un asegurado
                    AdministrarCartaRetiro.ActualizarMesProduccion(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text), int.Parse(txtIdCarta.Text));
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Valide la información digitada');", true);
                }
                if ((int.Parse(ddlTipoGestion.SelectedValue.ToString()) == 2) || (int.Parse(ddlTipoGestion.SelectedValue.ToString()) == 3))
                {
                    //Inserta o actualiza la novedad de recuperación del asegurado
                    AdministrarCartaRetiro.InsertarNovedadRecuperacion(int.Parse(txtCedulaGes.Text), (double.Parse(txtCertificadoGes.Text)));
                    //Actualiza los tipos de movimientos a recuperaciones en la base de datos
                    AdministrarCartaRetiro.ActualizarMovimientoRecuperacion(int.Parse(txtCedulaGes.Text), double.Parse(txtCertificadoGes.Text));
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-3'); alert('" + "Se guardó la gestión exitosamente" + "');window.location.replace('/gestion/retiros')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Faltan campos por diligenciar');", true);
        }
    }

    //Lista los productos asoaciados a cada compañía 
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompañia.SelectedValue.ToString() != "")
        {
            DataTable dt = new DataTable();
            dt = AdministrarCartaRetiro.ListarProductosCompania(int.Parse(ddlCompañia.SelectedValue.ToString()));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dt;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("NO APLICA", "0"));
        }
    }

    //Lista los asesores por localidad de acuerdo al departamento que tenga asociado el certificado a retirar
    protected void ListarAsesoresLocalidad()
    {
        DataTable dtAsesor = AdministrarCartaRetiro.ListarAsesor(int.Parse(txtDepAsesor.Text));
        ddlAsesor.DataSource = dtAsesor;
        ddlAsesor.DataTextField = "Asesor";
        ddlAsesor.DataValueField = "Id";
        ddlAsesor.DataBind();
        ddlAsesor.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    #endregion Gestionar Retiro

    #region Observaciones

    //Lista todas las observaciones que tenga un asegurado, mostrando la fecha, la observación y el usuario que la realizó
    protected void ListarObservacion(int idCarta)
    {
        DataTable dt = new DataTable();
        dt = AdministrarCartaRetiro.ListarObservaciones(idCarta);
        grvObservaciones.DataSource = dt;
        grvObservaciones.DataBind();
    }

    //Guarda en la base de datos las observaciones registradas por cada carta de retiro
    protected void GuardarObs_Click(object sender, EventArgs e)
    {
        if (txtSeguimiento.Text != "")
        {
            AdministrarCartaRetiro.GuardarObservacion(txtSeguimiento.Text, txtUsuarioObs.Text, int.Parse(txtMenuObs.Text), int.Parse(txtCedulaObs.Text), int.Parse(txtIdCartaObs.Text));

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Se guardó la observación correctamente');", true);
            lblSeguimiento.Visible = true;
            txtSeguimiento.Visible = true;
            btnGuardarObs.Visible = true;
            txtSeguimiento.Text = "";

            ListarObservacion(int.Parse(txtIdCartaObs.Text));
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('No tiene observaciones para guardar');", true);
        }
    }

    //Retorna al usuario a la pestaña donde se listan todos los retiros
    protected void Regresar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-3');window.location.replace('/gestion/retiros')", true);
    }

    #endregion Observaciones

    #region Editar Retiro

    //Actualiza en la base de datos los campos que se modifiquen al momento de editar una carta de retiro
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        btnGuardar.Visible = false;
        btnActualizar.Visible = true;

        if (txtIdCartaRetiro.Text != "" & txtCedulaCertificado.Text != "" & txtCertificado.Text != "" & txtValorPpal.Text != "" & txtValorConyuge.Text != "" & txtPrima.Text != "" & txtDepartamento.Text != "" & txtPagaduria.Text != "" & txtFechaCompania.Text != ""
        & txtProducto.Text != "" & txtFechaTg.Text != "" & txtFechaCasaMatriz.Text != "" & ddlCompania.Text != "" & ddlOrigen.Text != "")
        {
            if (((DateTime.Parse(txtFechaTg.Text)) > (DateTime.Now.Date)) || ((DateTime.Parse(txtFechaCasaMatriz.Text)) > (DateTime.Now.Date)) || ((DateTime.Parse(txtFechaCompania.Text))) > (DateTime.Now.Date))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Las fechas no pueden ser mayores a la actual');", true);
            }
            else
            {
                //Actualiza los campos de la carta de retiro del asegurado en la base de datos  
                AdministrarCartaRetiro.ActualizarCartaRetiro(int.Parse(txtIdCartaRetiro.Text), int.Parse(ddlCompania.Text), DateTime.Parse(txtFechaTg.Text), DateTime.Parse(txtFechaCasaMatriz.Text), DateTime.Parse(txtFechaCompania.Text), ddlOrigen.Text, txtObservacion.Text);

                //Actualiza la fecha de vigencia del retiro cuando en la edición se cambian las fechas de recibio de las cartas 
                AdministrarCartaRetiro.ActualizarVigenciaRetiro(int.Parse(txtIdCartaRetiro.Text));

                ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-3'); alert('" + "Se guardó el retiro exitosamente" + "');window.location.replace('/gestion/retiros')", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por diligenciar');", true);
        }
    }
    #endregion Editar Retiro

    #region Informe

    //Realiza una búsqueda especifica de información que puede ser por cédula del asegurado, fecha de digitación de la carta de retiro o número de certificado
    protected void botonBuscarRetiro_Click(object sender, EventArgs e)
    {
        int cedula = 0;
        double certificado = 0;
        DateTime fecha = Convert.ToDateTime("01/01/1900");

        if (txtCedulaRetiro.Text != "")
        {
            cedula = int.Parse(txtCedulaRetiro.Text);
        }
        if (txtCertificadoRetiro.Text != "")
        {
            certificado = int.Parse(txtCertificadoRetiro.Text);
        }
        if (txtFechaRetiro.Text != "")
        {
            fecha = DateTime.Parse(txtFechaRetiro.Text);
        }

        DataTable dt = new DataTable();
        dt = AdministrarCartaRetiro.BuscarRetiro(cedula, certificado, fecha);
        grvGestionRetiro.DataSource = dt;
        grvGestionRetiro.DataBind();
    }

    //Oculta y vacía los campos de búsqueda para realizar una nueva consulta segun el informe que se desee
    protected void btnLimpiarInforme_Click(object sender, EventArgs e)
    {
        LimpiarCamposRetiro();

        lblDocumento.Visible = false;
        lblLocalidad1.Visible = false;
        lblCompañía.Visible = false;
        lblProducto.Visible = false;
        lblTipoGestion.Visible = false;
        lblOrigenOficio.Visible = false;
        lblFechaDesde.Visible = false;
        lblFechaHasta.Visible = false;
        txtDocumento2.Visible = false;
        ddlLocalidad.Visible = false;
        ddlCompañia.Visible = false;
        ddlProducto.Visible = false;
        ddlGestion.Visible = false;
        ddlOrigenOficio.Visible = false;
        txtFechaDesde.Visible = false;
        txtFechaHasta.Visible = false;
        btnBuscarInforme.Visible = false;
        btnLimpiarInforme.Visible = false;
        btnDescargar.Visible = false;
        grvInformeRetiros.Visible = false;
    }

    //Oculta y vacía los campos de búsqueda para realizar una nueva consulta
    protected void botonLimpiarRetiro_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    //Generar archivo de excel para descargar el informe general de retiros
    protected void btnDescargarExcel_Click(object sender, System.EventArgs e)
    {
        DataTable dtInformeRetiros = (DataTable)Session["InformeFinal"];

        if (grvInformeRetiros.Rows.Count > 0)
        {
            Funciones.generarExcel(Page, dtInformeRetiros, "Informe General de retiros");
        }
    }

    //Genera información de acuerdo a los parámetros escogidos por el usuario 
    protected void btnBuscarInforme_Click(object sender, EventArgs e)
    {
        int cedula = 0;
        int localidad = 0;
        int com_Id = 0;
        int pro_Id = 0;
        int tipoGestion = 0;
        int origen = 0;
        int informe = 0;

        DateTime fechaInicio = Convert.ToDateTime("01/01/1900");
        DateTime fechaFin = Convert.ToDateTime("01/01/1900");

        if (txtFechaHasta.Text != "" && txtFechaDesde.Text != "")
        {
            if (txtDocumento2.Text != "")
            {
                cedula = int.Parse(txtDocumento2.Text);
            }
            if (ddlLocalidad.SelectedValue != "")
            {
                localidad = int.Parse(ddlLocalidad.SelectedValue);
            }
            if (ddlCompañia.SelectedValue != "")
            {
                com_Id = int.Parse(ddlCompañia.SelectedValue);
            }
            if (ddlProducto.SelectedValue != "")
            {
                pro_Id = int.Parse(ddlProducto.SelectedValue);
            }
            if (ddlGestion.SelectedValue != "")
            {
                tipoGestion = int.Parse(ddlGestion.SelectedValue);
            }
            if (ddlOrigenOficio.SelectedValue != "")
            {
                origen = int.Parse(ddlOrigenOficio.SelectedValue);
            }
            if (txtFechaDesde.Text != "")
            {
                fechaInicio = DateTime.Parse(txtFechaDesde.Text);
            }
            if (txtFechaHasta.Text != "")
            {
                fechaFin = DateTime.Parse(txtFechaHasta.Text);
            }
            if (ddlTipoInforme.SelectedValue != "")
            {
                informe = int.Parse(ddlTipoInforme.SelectedValue);
            }

            DataTable dt = new DataTable();
            dt = AdministrarCartaRetiro.InformeRetiros(cedula, localidad, com_Id, pro_Id, tipoGestion, origen, fechaInicio, fechaFin, informe);
            Session["InformeFinal"] = dt;

            grvInformeRetiros.Visible = true;
            grvInformeRetiros.DataSource = dt;
            grvInformeRetiros.DataBind();

            if (dt.Rows.Count > 0)
            {
                btnDescargar.Visible = true;
            }
        }
    }

    //Recarga la página para permitir otra búsqueda
    private void LimpiarCampos()
    {
        ListarRetiros();
        Response.RedirectToRoute("gestionRetiros");
    }

    //Limpia los campos de búsqueda para permitir otra consulta
    private void LimpiarCamposRetiro()
    {
        txtDocumento2.Text = "";
        txtFechaDesde.Text = "";
        txtFechaHasta.Text = "";
        ddlLocalidad.SelectedIndex = 0;
        ddlCompañia.SelectedIndex = 0;
        ddlProducto.SelectedIndex = 0;
        ddlGestion.SelectedIndex = 0;
        ddlOrigenOficio.SelectedIndex = 0;
        ddlTipoInforme.SelectedIndex = 0;
    }

    //De acuerdo al tipo de informe que seleccione el usuario se muestran o no ciertos campos
    protected void ddlTipoInforme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlTipoInforme.SelectedValue) == 1)
        {
            lblDocumento.Visible = true;
            lblLocalidad1.Visible = true;
            lblCompañía.Visible = true;
            lblProducto.Visible = true;
            lblTipoGestion.Visible = true;
            lblOrigenOficio.Visible = true;
            lblFechaDesde.Visible = true;
            lblFechaHasta.Visible = true;
            txtDocumento2.Visible = true;
            ddlLocalidad.Visible = true;
            ddlCompañia.Visible = true;
            ddlProducto.Visible = true;
            ddlGestion.Visible = true;
            ddlOrigenOficio.Visible = true;
            txtFechaDesde.Visible = true;
            txtFechaHasta.Visible = true;
            btnBuscarInforme.Visible = true;
            btnLimpiarInforme.Visible = true;
            txtDocumento2.Enabled = true;
            ddlLocalidad.Enabled = true;
            ddlCompañia.Enabled = true;
            ddlProducto.Enabled = true;
            ddlGestion.Enabled = true;
            ddlOrigenOficio.Enabled = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
        }
        else if (int.Parse(ddlTipoInforme.SelectedValue) == 2)
        {
            lblDocumento.Visible = true;
            lblLocalidad1.Visible = true;
            lblCompañía.Visible = true;
            lblProducto.Visible = true;
            lblTipoGestion.Visible = true;
            lblOrigenOficio.Visible = true;
            lblFechaDesde.Visible = true;
            lblFechaHasta.Visible = true;
            txtDocumento2.Visible = true;
            ddlLocalidad.Visible = true;
            ddlCompañia.Visible = true;
            ddlProducto.Visible = true;
            ddlGestion.Visible = true;
            ddlOrigenOficio.Visible = true;
            txtFechaDesde.Visible = true;
            txtFechaHasta.Visible = true;
            btnBuscarInforme.Visible = true;
            btnLimpiarInforme.Visible = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
            txtDocumento2.Enabled = true;
            ddlLocalidad.Enabled = true;
            ddlCompañia.Enabled = true;
            ddlProducto.Enabled = true;
            ddlGestion.Enabled = false;
            ddlOrigenOficio.Enabled = true;
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-6'); alert('" + "Por favor seleccione el tipo de Informe" + "');window.location.replace('/gestion/retiros')", true);
        }
    }
#endregion Informe
}


