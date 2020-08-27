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
using System.IO;

public partial class Presentacion3_DevolucionDePrima2 : System.Web.UI.Page
{
    #region Consulta de Usuario
    //Permite consultar el usuario para posteriormente asignarle sus permisos
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }
    #endregion

    #region Variables globales y funciones iniciales
    public static DataTable dtConsultarDevolucionPrima = new DataTable();
    DataTable dt, dtTemp;
    string url, jScript;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if(!IsPostBack)
        {
            //Bloquear y ocultar campos que no deben aparecer en primer momento
            txtIdDevolucion.Enabled = false;
            txtIdDevolucion.Visible = false;
            txtNumeroCuenta.Visible = false;
            ddlBanco.Visible = false;
            ddlTipoCuenta.Visible = false;
            lblIdDevolucion.Visible = false;
            rbtlMarca.Visible = false;
            lblBanco.Visible = false;
            lblNumeroCuenta.Visible = false;
            lblTipoCuenta.Visible = false;
            ddlLocalidad.Enabled = false;
            btnGuardarDevolucion.Visible = false;
            lblCedulaTitular.Visible = false;
            lblNombreTitular.Visible = false;
            txtCedulaTitular.Visible = false;
            ddlCausalDevolucion.Visible = false;
            lblCausalDevolucion.Visible = false;
            txtNombreTitular.Visible = false;
            btnConsultarAplicaciones.Visible = false;
            btnExportarExcelDp2.Visible = false;
            panSoporte.Visible = false;
            btnAdicionar.Visible = false;

            //Listar localidades
            DataTable dtConsultarLocalidad = new DataTable();
            dtConsultarLocalidad = AdministrarDevolucionDePrima.ConsultarLocalidad();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtConsultarLocalidad;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));

            //Listar bancos
            DataTable dtConsultarNewBanco = new DataTable();
            dtConsultarNewBanco = AdministrarDevolucionDePrima.ConsultarNewBanco();
            ddlBanco.DataTextField = "ban_Nombre";
            ddlBanco.DataValueField = "ban_Id";
            ddlBanco.DataSource = dtConsultarNewBanco;
            ddlBanco.DataBind();
            ddlBanco.Items.Insert(0, new ListItem("", ""));

            //Listar tipo cuentas
            DataTable dtConsultarTipoCuenta = new DataTable();
            dtConsultarTipoCuenta = AdministrarDevolucionDePrima.ConsultarTipoCuenta();
            ddlTipoCuenta.DataTextField = "tipcue_Nombre";
            ddlTipoCuenta.DataValueField = "tipcue_Id";
            ddlTipoCuenta.DataSource = dtConsultarTipoCuenta;
            ddlTipoCuenta.DataBind();
            ddlTipoCuenta.Items.Insert(0, new ListItem("", ""));

            //Listar departamentos
            DataTable dtDepartamento = new DataTable();
            dtDepartamento = AdministrarTercero.asegurado.sp_MostrarDepartamento();
            ddlDepartamento.DataTextField = "dep_Nombre";
            ddlDepartamento.DataValueField = "dep_Id";
            ddlDepartamento.DataSource = dtDepartamento;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("", ""));

            //Listar causal devolcuión
            DataTable dtCausalDevolucion = new DataTable();
            dtCausalDevolucion = AdministrarDevolucionDePrima.ConsultarCausalDevolucionPrima();
            ddlCausalDevolucion.DataTextField = "caudev_Nombre";
            ddlCausalDevolucion.DataValueField = "caudev_Id";
            ddlCausalDevolucion.DataSource = dtCausalDevolucion;
            ddlCausalDevolucion.DataBind();
            ddlCausalDevolucion.Items.Insert(0, new ListItem("", ""));

            #region Cargue de devolución y soportes por Session
            try
            {
                //Para el caso de que regrese del modal se valida la informacion que estaba cargada y se consulta nuevamente, para que el usuario no pierda la seleccion
                if (Session["CedulaDevolucion"] != null && Session["IdDevolucion"] != null)
                {
                    if (Session["LocalidadDevolucion"] != null)
                    {
                        //Consulta la información del cliente
                        ConsultarDevolucionesClienteLocalidad(double.Parse(Session["CedulaDevolucion"].ToString()), double.Parse(Session["LocalidadDevolucion"].ToString()));
                        //Carga la localidad seleccionada
                        ddlLocalidad.SelectedIndex = int.Parse(Session["LocalidadDevolucion"].ToString());
                        ddlLocalidad.Enabled = true;
                    }
                    else
                    {
                        //Si no se ha seleccionado la localidad cargara el registro solo por cedula
                        ConsultarDevolucionesCliente(double.Parse(Session["CedulaDevolucion"].ToString()));
                    }
                    txtIdDevolucion.Text = Session["IdDevolucion"].ToString();
                    //Carga el soporte por el id de la devolución
                    CargarArchivosSoporteDevolucion(null, null, int.Parse(Session["IdDevolucion"].ToString()));
                    txtCedula.Text = Session["CedulaDevolucion"].ToString();

                    foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
                    {
                        RadioButton check = row.FindControl("chkSeleccionar") as RadioButton;

                        // Obtener el Id de Label fila seleccionada
                        if (row.Cells[1].Text == Session["IdDevolucion"].ToString())
                        {
                            check.Checked = true;
                            /*Variable de Session para almacenar la id de Devolucion seleccionada para
                             el caso de que requiera ir al modal de Aplicaciones asociadas a esta
                             09/12/2016*/
                            btnConsultarAplicaciones.Visible = true;
                            btnExportarExcelDp2.Visible = true;
                            btnGuardarDevolucion.Visible = true;
                            btnAdicionar.Visible = true;
                            rbtlMarca.Visible = true;
                            panSoporte.Visible = true;

                        }
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Intente nuevamente" + "');", true);
            }
            #endregion
        }  
    }
    #endregion

    #region Eventos
        #region Eventos de botones
            #region Buscar devolución
            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                Session["idDevolucion"] = null;
                Session["LocalidadDevolucion"] = null;
                Session["CedulaDevolucion"] = null;

                //Entrar a esta funcionalidad si en el campo ya hay un numero
                if (txtCedula.Text != "")
                {
                    ConsultarDevolucionesCliente(double.Parse(txtCedula.Text));
                }
                else
                //Si el campo documento esta vacio 
                {
                    Session["CedulaDevolucion"] = null;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Ingrese un número de documento" + "');", true);
                }
                btnConsultarAplicaciones.Visible = false;
                btnExportarExcelDp2.Visible = false;
                btnGuardarDevolucion.Visible = false;
                btnAdicionar.Visible = false;
                rbtlMarca.Visible = false;
                panSoporte.Visible = false;
                
            }
    #endregion

            #region Guardar devolución
            protected void btnGuardarDevolucion_Click(object sender, System.EventArgs e)
            {
                if (rbtlMarca.SelectedValue.ToString() != "")
                {
                    if (rbtlMarca.SelectedValue.ToString() == "3")
                    {
                        // Realizar esta funcion solo si todos los campos como banco, tipo cuenta, titular... estan diferentes de vacio 
                        if (txtIdDevolucion.Text != "" && ddlBanco.SelectedValue.ToString() != "" && ddlTipoCuenta.SelectedValue.ToString()
                            != "" && txtNumeroCuenta.Text != "" && txtNombreTitular.Text != "" && txtCedulaTitular.Text != "" &&
                            ddlCausalDevolucion.SelectedValue.ToString() != "")
                        {
                            // Insertar estos campos para completar la devolucion de prima
                            DataTable dtInsertarDevolucionMomento2 = new DataTable();
                            dtInsertarDevolucionMomento2 = AdministrarDevolucionDePrima.InsertarDevolucionMomento2(int.Parse(txtIdDevolucion.Text),
                            int.Parse(ddlBanco.SelectedValue.ToString()), int.Parse(ddlTipoCuenta.SelectedValue.ToString()), int.Parse(txtNumeroCuenta.Text), 2,
                            txtNombreTitular.Text, int.Parse(txtCedulaTitular.Text), int.Parse(ddlCausalDevolucion.SelectedValue.ToString()), 0, 1);

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "La información se ha guardado correctamente" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Complete todos los campos solicitados" + "');", true);
                        }
                    }
                    if (rbtlMarca.SelectedValue.ToString() == "2")
                    {
                        // Insertar estos campos para completar la devolucion de prima
                        DataTable dtInsertarDevolucionMomento2 = new DataTable();
                        dtInsertarDevolucionMomento2 = AdministrarDevolucionDePrima.InsertarDevolucionMomento2(int.Parse(Session["IdDevolucion"].ToString()), 1, 1, 1, 2,
                        "", 1, 1, 2, 0);

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "La información se ha guardado correctamente" + "');", true);
                    }
                    if (rbtlMarca.SelectedValue.ToString() == "1")
                    {
                        // Insertar estos campos para completar la devolucion de prima
                        DataTable dtInsertarDevolucionMomento2 = new DataTable();
                        dtInsertarDevolucionMomento2 = AdministrarDevolucionDePrima.InsertarDevolucionMomento2(int.Parse(Session["IdDevolucion"].ToString()), 1, 1, 1, 2,
                        "", 1, 1, 1, 0);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "La información se ha guardado correctamente" + "');", true);
                    }

                    // listar de nuevo los registros en la tabla, excluyendo los que ya se completaron
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidad(double.Parse(txtCedula.Text), 0, 1);
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrima.DataBind();

                    Session["dtExportarDp2"] = dtConsultarDevolucionPrima;

                    txtIdDevolucion.Text = "";

                    //Se ocultan y se bloquean los campos si el Grid ya no tiene registros para mostrar
                    txtIdDevolucion.Visible = false;
                    txtIdDevolucion.Text = "";
                    txtNumeroCuenta.Visible = false;
                    txtNumeroCuenta.Text = "";
                    ddlBanco.Visible = false;
                    ddlTipoCuenta.Visible = false;
                    lblIdDevolucion.Visible = false;
                    rbtlMarca.Visible = false;
                    ddlCausalDevolucion.Visible = false;
                    lblCausalDevolucion.Visible = false;
                    lblBanco.Visible = false;
                    lblNumeroCuenta.Visible = false;
                    lblTipoCuenta.Visible = false;
                    lblCedulaTitular.Visible = false;
                    lblNombreTitular.Visible = false;
                    txtCedulaTitular.Visible = false;
                    txtCedulaTitular.Text = "";
                    txtNombreTitular.Visible = false;
                    txtNombreTitular.Text = "";
                    btnGuardarDevolucion.Visible = false;
                    btnConsultarAplicaciones.Visible = false;
                    btnExportarExcelDp2.Visible = false;
                    panSoporte.Visible = false;
                    btnAdicionar.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione una de las opciones de pago para la devolución" + "');", true);
                }
            }
            #endregion

            #region Insertar tercero
            protected void btnInsertar_Click(object sender, EventArgs e)
            {
                AdministrarTercero.InsertarTercero(txtIdentificacion.Text, DBNull.Value.ToString(), txtNombre.Text, txtApellido.Text, DateTime.Today, txtCorreo.Text, DBNull.Value.ToString(), ddlDepartamento.SelectedValue, DBNull.Value.ToString(), txtCelular.Text, txtTelefono1.Text, txtDireccion.Text, txtTelefono2.Text, DBNull.Value.ToString(), DBNull.Value.ToString(), 0);
                //Response.Redirect("DevolucionDePrima2.aspx");
                Response.RedirectToRoute("devolucionPrimaTramitar");
            }
            #endregion

            #region Adicionar archivos
            protected void btnAddArchivos_Click(object sender, System.EventArgs e)
            {
                //Se llama el metodo con el nombre de la funcion javascript que indica el formulario modal
                MostrarModal("OpenCenterWindowCallBack2();");
            }
            #endregion

            #region Consultar aplicaciones
            protected void btnConsultarAplicaciones_Click(object sender, System.EventArgs e)
            {
                MostrarModal("OpenCenterWindowCallBack();");
            }
    #endregion

            #region Exportar a excel
            protected void btnExportarExcelDp2_Click(object sender, System.EventArgs e)
            {
                //Evento para exportar a excel
                DataTable dtConsultarDevolucionDePrima = (DataTable)Session["dtExportarDp2"];
                if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                {
                    Funciones.generarExcel(Page, dtConsultarDevolucionDePrima, "Devoluciones de prima en espera de trámite");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No hay información en la planilla" + "');", true);
                }
            }
    #endregion
    #endregion

        #region Seleccionables
        protected void ddlLocalidad_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Se lista la tabla por medio del documento y la localidad solo cuando la localidad es diferente de vacio
            if (ddlLocalidad.SelectedValue.ToString() != "")
            {
                ConsultarDevolucionesClienteLocalidad(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()));
            }
            else
            {
                Session["LocalidadDevolucion"] = null;
            }
            btnConsultarAplicaciones.Visible = false;
            btnExportarExcelDp2.Visible = false;
            btnGuardarDevolucion.Visible = false;
            panSoporte.Visible = false;
            btnAdicionar.Visible = false;
        }
    #endregion

        #region Eventos de tablas
        protected void chkSeleccionar_OnCheckedChanged(object sender, EventArgs e)
        {
            int id = 0;
            Session["IdDevolucion"] = null;
            // Recorrer el Grid para identificar cual fue la fila que se selecciono
            foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
            {
                RadioButton check = row.FindControl("chkSeleccionar") as RadioButton;
                id = int.Parse(row.Cells[1].Text);
                // Obtener el Id de Label fila seleccionada
                if (check.Checked)
                {
                    if (Session["IdDevolucionAnterior"] == null || Session["IdDevolucion"] == null)
                    {

                        //Variable de Session para almacenar la id de Devolucion seleccionada para el caso de que requiera ir al modal de Aplicaciones asociadas a esta
                        Session["IdDevolucion"] = id;
                    }
                    else if (row.Cells[1].Text != Session["IdDevolucionAnterior"].ToString())
                    {
                        Session["IdDevolucion"] = id;
                    }

                    //Cargar los soportes asociados actualizados
                    CargarArchivosSoporteDevolucion(null, null, int.Parse(Session["IdDevolucion"].ToString()));
                    btnConsultarAplicaciones.Visible = true;
                    btnExportarExcelDp2.Visible = true;
                    btnGuardarDevolucion.Visible = true;
                    btnAdicionar.Visible = true;
                    panSoporte.Visible = true;

                }

            }
            Session["IdDevolucionAnterior"] = Session["IdDevolucion"];

            foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
            {
                RadioButton check = row.FindControl("chkSeleccionar") as RadioButton;

                // Obtener el Id de Label fila seleccionada
                if (row.Cells[1].Text != Session["IdDevolucion"].ToString())
                {
                    check.Checked = false;
                    //Variable de Session para almacenar la id de Devolucion seleccionada para el caso de que requiera ir al modal de Aplicaciones asociadas a esta
                    btnConsultarAplicaciones.Visible = true;
                    btnExportarExcelDp2.Visible = true;
                    btnGuardarDevolucion.Visible = true;
                    btnAdicionar.Visible = true;
                }
                else
                {
                    check.Checked = true;
                }
            }

            //Activar los campos solo si la localidad es diferente de vacio y las filas del Grid sea mayor a 0
            if (ddlLocalidad.SelectedValue.ToString() != "" && dtConsultarDevolucionPrima.Rows.Count > 0)
            {
                rbtlMarca.Visible = true;
            }

            if (Session["idDevolucion"] != null)
            {
                Session["Bandera"] = 1;
                //Si hay una devolucion de prima seleccionada en la variable de session, se llena el Grid con las Aplicaciones que encuentre asociada
                grvdAplicacionesPagosDevolucion.DataSource = AdministrarDevolucionDePrima.ConsultarAplicacionesDevolucion(Convert.ToInt32(Session["idDevolucion"].ToString()));
                grvdAplicacionesPagosDevolucion.DataBind();

                DataTable dtTemp = new DataTable();
                dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                grvArchivosSoporteM.DataSource = dtTemp;
                grvArchivosSoporteM.DataBind();
            }
        }



        protected void grvArchivosSoporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Cargue de soportes segun el id de la devolución
            try
            {
                if (Session["idDevolucion"].ToString() != null)
                {
                    grvArchivosSoporte.PageIndex = e.NewPageIndex;
                    CargarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                }
                else
                {
                    MensajeForm("No se ha podido identificar la Devolucion", "~/devolucion/prima/tramitar#irDevolucion");
                }

            }
            catch (Exception ex)
            {
                MensajeForm("Ha ocurrido un problema con su petición", null);
            }
        }



        protected void grvArchivosSoporte_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                //Consulta la ruta del archivo
                string rutaArchivo = Server.MapPath(grvArchivosSoporte.SelectedRow.Cells[2].Text);
                string msjDel = "";

                //Pregunta si la ruta existe
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }
                else
                {
                    msjDel = "Archivo no Encontrado.";
                }
                //Elimina el soporte 
                string resDel = AdministrarDevolucionDePrima.EliminarArchivoSoporteDevolucion(Convert.ToInt32(grvArchivosSoporte.SelectedValue));
                MensajeForm(msjDel + " " + resDel, "~/devolucion/prima/tramitar#archSopDev");
            }
            catch (Exception ex)
            {
                MensajeForm("Ha ocurrido un problema con su petición", null);
            }
        }
    #endregion

        #region Forma de pago
        protected void rbtlMarca_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            //aca solo se activaran los campos solo si esta tabla viene diferente de vacio
            if (ddlLocalidad.SelectedValue.ToString() != "" && dtConsultarDevolucionPrima.Rows.Count > 0)
            {
                txtIdDevolucion.Text = Session["IdDevolucion"].ToString();
                rbtlMarca.Visible = true;
                if (rbtlMarca.SelectedValue.ToString() == "3")
                {
                    txtIdDevolucion.Visible = true;
                    txtNumeroCuenta.Visible = true;
                    ddlBanco.Visible = true;
                    ddlTipoCuenta.Visible = true;
                    lblIdDevolucion.Visible = true;
                    lblBanco.Visible = true;
                    lblNumeroCuenta.Visible = true;
                    lblTipoCuenta.Visible = true;
                    lblCedulaTitular.Visible = true;
                    lblNombreTitular.Visible = true;
                    txtCedulaTitular.Visible = true;
                    ddlCausalDevolucion.Visible = true;
                    lblCausalDevolucion.Visible = true;
                    txtNombreTitular.Visible = true;
                }
                else
                {
                    txtIdDevolucion.Visible = false;
                    txtNumeroCuenta.Visible = false;
                    ddlBanco.Visible = false;
                    ddlTipoCuenta.Visible = false;
                    lblIdDevolucion.Visible = false;
                    lblBanco.Visible = false;
                    lblNumeroCuenta.Visible = false;
                    lblTipoCuenta.Visible = false;
                    lblCedulaTitular.Visible = false;
                    lblNombreTitular.Visible = false;
                    txtCedulaTitular.Visible = false;
                    lblCausalDevolucion.Visible = false;
                    ddlCausalDevolucion.Visible = false;
                    txtNombreTitular.Visible = false;
                    txtIdDevolucion.Text = "";
                }
            }
            else
            //De lo contrario estos campos seguiran ocultos o bloqueados
            {
                txtIdDevolucion.Visible = false;
                txtNumeroCuenta.Visible = false;
                ddlBanco.Visible = false;
                ddlTipoCuenta.Visible = false;
                lblIdDevolucion.Visible = false;
                lblBanco.Visible = false;
                lblNumeroCuenta.Visible = false;
                lblTipoCuenta.Visible = false;
                lblCedulaTitular.Visible = false;
                lblNombreTitular.Visible = false;
                txtCedulaTitular.Visible = false;
                lblCausalDevolucion.Visible = false;
                ddlCausalDevolucion.Visible = false;
                txtNombreTitular.Visible = false;
                txtIdDevolucion.Text = "";
            }
        }
        #endregion
    #endregion

    #region Metodos
    //Metodo que consulta las devoluciones de prima que existan asociadas a la cedula del cliente
    public void ConsultarDevolucionesCliente(double cedula)
    {
        //Variable que permite guardar la cedula digitada y consultadas las Devoluciones de Prima, esto se usa para cuando va al modal y poder recuperar la informacion consultada previamente
        Session["CedulaDevolucion"] = cedula;
        dtConsultarDevolucionPrima.Clear();
        //Consultar las posibles devoluciones que existen con el documento ingresado
        dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidad(cedula, 0, 1);
        grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
        grvDevolucionesDePrima.DataBind();

        Session["dtExportarDp2"] = dtConsultarDevolucionPrima;

        txtIdDevolucion.Text = "";

        //si efectivamente existen posibles devoluciones con este documento
        if (dtConsultarDevolucionPrima.Rows.Count > 0)
        {

            ddlLocalidad.Enabled = true;
        }
        else
        //Si no existen posibles devoluciones con el documento ingresado
        {
            txtIdDevolucion.Visible = false;
            txtNumeroCuenta.Visible = false;
            ddlBanco.Visible = false;
            ddlTipoCuenta.Visible = false;
            lblIdDevolucion.Visible = false;
            rbtlMarca.Visible = false;
            lblBanco.Visible = false;
            lblNumeroCuenta.Visible = false;
            lblTipoCuenta.Visible = false;
            lblCedulaTitular.Visible = false;
            lblNombreTitular.Visible = false;
            txtCedulaTitular.Visible = false;
            lblCausalDevolucion.Visible = false;
            ddlCausalDevolucion.Visible = false;
            txtNombreTitular.Visible = false;
            txtIdDevolucion.Text = "";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Este cliente no tiene posibles devoluciones o no existe en el sistema, registrelo en el botón Insertar" + "');", true);
        }
    }

    public void ConsultarDevolucionesClienteLocalidad(double cedula, double localidad)
    {
        //Consulta las devoluciones asociadas a una cedula y una localidad
        dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidad(cedula, localidad, 1);
        grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
        grvDevolucionesDePrima.DataBind();
        Session["LocalidadDevolucion"] = localidad;

        Session["dtExportarDp2"] = dtConsultarDevolucionPrima;

    }

    private void limpiar()
    {
        //Metodo para limpiar campos
        txtIdentificacion.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtCorreo.Text = "";
        txtCelular.Text = "";
        txtTelefono1.Text = "";
        txtDireccion.Text = "";
        txtTelefono2.Text = "";
    }

    //Metodo que usa un codigo javascript para generar una ventana modal; para este caso en particuar muestra las aplicaciones de pago asociadas a una devolucion de prima
    public void MostrarModal(String jScript)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
    }

    public void MensajeForm(string msg, string url)
    {
        //Metodo para mostrar un mensaje de alerta
        if (url != null)
        {
            jScript = "alert('" + msg + "');location.href='" + url + "';";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
        else
        {
            jScript = "alert('" + msg + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
    }

    public void CargarArchivosSoporteDevolucion(int? idSopDev, string nomSopDev, int? idDev)
    {
        //Se cargan los soportes segun los parametros enviados
        try
        {
            dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(idSopDev, nomSopDev, idDev);
            grvArchivosSoporte.DataSource = dtTemp;
            grvArchivosSoporte.DataBind();
        }
        catch (Exception ex)
        {
            MensajeForm("Ha ocurrido un problema con su petición", null);
        }
    }
    #endregion
}