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

public partial class Presentacion3_DevolucionDePrima3 : System.Web.UI.Page
{
    #region Consulta de Usuario.
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            //Bloquear y ocultar campos que no deben aparecer en primer momento
            ddlLocalidad.Enabled = false;
            lblCausalrechazo.Visible = false;
            ddlCausalRechazo.Visible = false;
            btnDevolver.Visible = false;
            btnExportarExcelDp.Visible = false;
            btnEnviar.Visible = false;
            btnConfirmarCausal.Visible = false;

            //Listar localidades
            DataTable dtConsultarLocalidad = new DataTable();
            dtConsultarLocalidad = AdministrarDevolucionDePrima.ConsultarLocalidad();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtConsultarLocalidad;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));

            #region Cargue de devolución y soportes por Session.
            try
            {
                //En caso de que ya tenga una sessión activa y una cedula ya consultada
                if (Session["Bandera"].ToString() != null)
                {
                    //Carga la tabla
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double.Parse(Session["txtCedula"].ToString()), int.Parse(Session["ddLocalidad"].ToString()), 2);
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrima.DataBind();

                    //Guarda en session la información 
                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;

                    txtCedula.Text = Session["txtCedula"].ToString();
                    ddlLocalidad.Enabled = true;
                    Session["Bandera"] = null;
                }
            }
            catch { }
            #endregion
        }
    }
    #endregion

    #region Eventos
        #region Eventos de botones
            #region Buscar devolución por cedula.
            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                //Entrar a esta funcionalidad si en el campo ya hay un numero
                if (txtCedula.Text != "")
                {
                    //Consultar las posibles devoluciones que existen con el documento ingresado
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double.Parse(txtCedula.Text), 0, 2);
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrima.DataBind();

                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;

                    Session["txtCedula"] = txtCedula.Text;
                    Session["ddLocalidad"] = 0;
                    //si efectivamente existen posibles devoluciones con este documento
                    if (dtConsultarDevolucionPrima.Rows.Count > 0)
                    {
                        ddlLocalidad.Enabled = true;
                    }
                    else
                    //Si no existen posibles devoluciones con el documento ingresado
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE DOCUMENTO NO TIENE DEVOLUCIONES EN ESTA PLANILLA" + "');", true);
                    }
                }
                else
                //Si el campo documento esta vacio 
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "INGRESE UN NUMERO DE DOCUMENTO" + "');", true);
                }
            }
    #endregion

            #region Listar causal rechazo devolución.
            protected void btnDevolver_Click(object sender, System.EventArgs e)
            {
                lblCausalrechazo.Visible = true;
                ddlCausalRechazo.Visible = true;
                btnConfirmarCausal.Visible = true;
                // Lista los causales de rechazo de devolución para que se seleccione la mas indicada
                DataTable dtConsultarCausalDevolucionPrima = new DataTable();
                dtConsultarCausalDevolucionPrima = AdministrarDevolucionDePrima.ConsultarCausalRechazoDevolucionPrima();
                ddlCausalRechazo.DataTextField = "rech_Nombre";
                ddlCausalRechazo.DataValueField = "rech_Id";
                ddlCausalRechazo.DataSource = dtConsultarCausalDevolucionPrima;
                ddlCausalRechazo.DataBind();
            }
    #endregion

            #region Enviar devolución.
            protected void btnEnviar_Click(object sender, System.EventArgs e)
            {
                string pago;
                foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

                    if (check.Checked)
                    {
                        //Si la devolución es tramitada por la compañia pasara al instante a devolución tramitada
                        pago = HttpUtility.HtmlDecode(row.Cells[19].Text.ToString());
                        if (pago == "Tramitado por compañia")
                        {
                            DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                            dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(int.Parse(row.Cells[2].Text), 4, 0);
                        }
                        else
                        {
                            //En caso de presionar devolucion se procede a actualizar esta a estado rechazado con su respectiva causal
                            DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                            dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(int.Parse(row.Cells[2].Text), 3, 0);
                        }
                    }
                }
                //Se lista la tabla por medio del documento y la localidad 
                dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()), 2);
                grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                grvDevolucionesDePrima.DataBind();

                Session["dtExportarDp"] = dtConsultarDevolucionPrima;

                lblCausalrechazo.Visible = false;
                ddlCausalRechazo.Visible = false;
                btnDevolver.Visible = false;
                btnExportarExcelDp.Visible = false;
                btnEnviar.Visible = false;
                btnConfirmarCausal.Visible = false;
            }
    #endregion

            #region Confirmar el rechazo de la devolución
            protected void btnConfirmarCausal_Click(object sender, System.EventArgs e)
            {
                foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
                {
                    CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

                    if (check.Checked)
                    {
                        //En caso de presionar devolucion se procede a actualizar esta a estado rechazado con su respectiva causal
                        DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                        dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(int.Parse(row.Cells[2].Text), 1, int.Parse(ddlCausalRechazo.SelectedValue.ToString()));
                    }
                }
                //Se lista la tabla por medio del documento y la localidad 

                dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()), 2);
                grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                grvDevolucionesDePrima.DataBind();

                Session["dtExportarDp"] = dtConsultarDevolucionPrima;

                lblCausalrechazo.Visible = false;
                ddlCausalRechazo.Visible = false;
                btnDevolver.Visible = false;
                btnExportarExcelDp.Visible = false;
                btnEnviar.Visible = false;
                btnConfirmarCausal.Visible = false;
            }
            #endregion

            #region Exportar a excel.
            protected void btnExportarExcelDp_Click(object sender, System.EventArgs e)
            {
                //Expotar a excel 
                DataTable dtConsultarDevolucionDePrima = (DataTable)Session["dtExportarDp"];
                if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                {
                    Funciones.generarExcel(Page, dtConsultarDevolucionDePrima, "Devoluciones de prima");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE DEVOLUCIONES" + "');", true);
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
                dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()), 2);
                grvDevolucionesDePrima.DataSource = dtConsultarDevolucionPrima;
                grvDevolucionesDePrima.DataBind();

                Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                Session["txtCedula"] = txtCedula.Text;
                Session["ddLocalidad"] = ddlLocalidad.SelectedValue.ToString();

            }
        }
    #endregion

        #region Eventos de tablas
        protected void chkSeleccionar_CheckedChanged(object sender, System.EventArgs e)
        {
            //Activar los campos solo si la localidad es diferente de vacio y las filas del Grid sea mayor a 0
            if (ddlLocalidad.SelectedValue.ToString() != "" && dtConsultarDevolucionPrima.Rows.Count > 0)
            {
                btnDevolver.Visible = true;
                btnExportarExcelDp.Visible = true;
                btnEnviar.Visible = true;
            }

            bool bandera = false;
            //Recorre devoluciones seleccionadas
            foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;
                if (check.Checked)
                {
                    string pago = HttpUtility.HtmlDecode(row.Cells[19].Text.ToString());
                    if (pago == "Tramitado por compañia")
                    {
                        bandera = true;
                    }
                }
            }
            //Informa al usuario que esta devolución es tramitada por la compañia
            if (bandera)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTAS DEVOLUCIONES PASARAN DIRECTAMENTE A TRAMITADA " + "');", true);
            }
        }

        protected void grvDevolucionesDePrima_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDevolucionesDePrima.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                Session["IdDevolucion"] = int.Parse(row.Cells[2].Text);

                if (Session["idDevolucion"] != null)
                {
                    Session["Bandera"] = 1;
                    //Si hay una devolucion de prima seleccionada en la variable de session, se llena el Grid con las Aplicaciones que encuentre asociada
                    grdAplicacionesPagosDevolucion.DataSource = AdministrarDevolucionDePrima.ConsultarAplicacionesDevolucion(Convert.ToInt32(Session["idDevolucion"].ToString()));
                    grdAplicacionesPagosDevolucion.DataBind();

                    //Carga los soportes de esta devolución
                    DataTable dtTemp = new DataTable();
                    dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                    grvArchivosSoporteM.DataSource = dtTemp;
                    grvArchivosSoporteM.DataBind();
                }
            }
        }
        #endregion
    #endregion

    #region Metodos
    /*Metodo que usa un codigo javascript para generar una ventana modal; para este caso en
    particuar muestra las aplicaciones de pago asociadas a una devolucion de prima*/
    public void MostrarModal(String jScript)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }
    #endregion
}