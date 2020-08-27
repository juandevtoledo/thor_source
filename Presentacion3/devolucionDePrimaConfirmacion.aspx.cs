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
using System.Drawing;

public partial class Presentacion3_devolucionDePrimaConfirmacion : System.Web.UI.Page
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
    public static DataTable dtConsultarDevolucionConfirmacion = new DataTable();
    public static int idDevolucion = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if(!IsPostBack)
        {
            divMovimiento.Visible = false;
            //Bloquear y ocultar campos que no deben aparecer en primer momento
            ddlLocalidad.Enabled = false;
            btnEnviarDevolucion.Visible = false;
            ddlCausalRechazoDevolucionPrima.Visible = false;
            lblCausalRechazo.Visible = false;

            //Listar las devoluciones con el estado 2 que significa epndiente para aceptacion o rechazo
            dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionConfirmacion(3);
            grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionConfirmacion;
            grvDevolucionDePrimaConfirmacion.DataBind();

            if (dtConsultarDevolucionConfirmacion.Rows.Count > 0)
            {
                btnExportarExcelDp.Visible = true;
            }
            else
            {
                btnExportarExcelDp.Visible = false;
            }

            Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;

            //Listar las localidades en el ddl
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
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(double.Parse(Session["txtCedulaConfirmacion"].ToString()), int.Parse(Session["ddLocalidadConfirmacion"].ToString()), 3);
                    grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionDePrimaConfirmacion.DataBind();

                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                    txtCedula.Text = Session["txtCedulaConfirmacion"].ToString();
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
            #region Buscar devolución
            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                //Entrar a esta funcionalidad si en el campo ya hay un numero
                if (txtCedula.Text != "")
                {
                    //Consultar las posibles devoluciones que existen con el documento ingresado
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(double.Parse(txtCedula.Text), 0, 3);
                    grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionDePrimaConfirmacion.DataBind();
                    if (dtConsultarDevolucionPrima.Rows.Count > 0)
                    {
                        btnExportarExcelDp.Visible = true;
                    }
                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                    Session["txtCedulaConfirmacion"] = txtCedula.Text;
                    Session["ddLocalidadConfirmacion"] = 0;

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

            #region Confirmar envio de devolución
            protected void btnEnviarDevolucion_Click(object sender, System.EventArgs e)
            {
                //En caso de presionar devolucion se procede a actualizar esta a estado rechazado con su respectiva causal
                DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(idDevolucion, 1, int.Parse(ddlCausalRechazoDevolucionPrima.SelectedValue.ToString()));

                // lista de nuevo el Grid, excluyendo el registro ya actualizado
                dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionConfirmacion(3);
                grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionConfirmacion;
                grvDevolucionDePrimaConfirmacion.DataBind();
                Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;
                txtCedula.Text = "";

                // se ocultan los campos despues de realizar la operación
                btnEnviarDevolucion.Visible = false;
                ddlCausalRechazoDevolucionPrima.Visible = false;
                lblCausalRechazo.Visible = false;
            }
    #endregion

            #region Exportar a excel
            protected void btnExportarExcelDp_Click(object sender, System.EventArgs e)
            {
                //Exportar a excel
                DataTable dtConsultarDevolucionDePrima = (DataTable)Session["dtExportarDp"];
                if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                {
                    Funciones.generarExcel(Page, dtConsultarDevolucionDePrima, "Devoluciones de prima pendientes por confirmación");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE DEVOLUCIONES PENDIENTES POR CONFIRMACIÓN" + "');", true);
                }
            }
    #endregion
    #endregion

        #region Seleccionable
        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se lista la tabla por medio del documento y la localidad solo cuando la localidad es diferente de vacio
            if (ddlLocalidad.SelectedValue.ToString() != "")
            {
                dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()), 3);
                grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionPrima;
                grvDevolucionDePrimaConfirmacion.DataBind();

                Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                Session["txtCedulaConfirmacion"] = txtCedula.Text;
                Session["ddLocalidadConfirmacion"] = ddlLocalidad.SelectedValue.ToString();
            }
        }
    #endregion

        #region Eventos de tablas
        protected void grvDevolucionDePrimaConfirmacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              int index = Convert.ToInt32(e.CommandArgument);
              if (index < grvDevolucionDePrimaConfirmacion.Rows.Count)
              {
                  GridViewRow row = grvDevolucionDePrimaConfirmacion.Rows[(index)];

                  int Id = 0;
                  Id = int.Parse(row.Cells[3].Text);
                //Si se desean consultar los pagos y soportes del cliente
                  if (e.CommandName == "Consultar_Click")
                  {
                      Session["IdDevolucion"] = int.Parse(row.Cells[3].Text);

                      if (Session["idDevolucion"] != null)
                      {
                          Session["Bandera"] = 1;
                          //Si hay una devolucion de prima seleccionada en la variable de session, se llena el Grid con las Aplicaciones que encuentre asociada
                          grdAplicacionesPagosDevolucion.DataSource = AdministrarDevolucionDePrima.ConsultarAplicacionesDevolucion(Convert.ToInt32(Session["idDevolucion"].ToString()));
                          grdAplicacionesPagosDevolucion.DataBind();
                          //Session["idDevolucion"] = null;

                          DataTable dtTemp = new DataTable();
                          dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                          grvArchivosSoporteM.DataSource = dtTemp;
                          grvArchivosSoporteM.DataBind();
                      }
                  }
                //Si se presiona el boton de confirmar devolucion entrara en esta operacion
                  if (e.CommandName == "ConfirmarDevolucion_Click")
                 {
                      string cuentaBancaria = row.Cells[20].Text;

                      //si es cuenta bancaria no solicita numero de movimiento y fecha de transferencia
                      if (cuentaBancaria == "Pago por cuenta bancaria")
                      {
                          divMovimiento.Visible = true;
                          if (txtNumeroMovimiento.Text != "" && txtFechaTransferencia.Text != "")
                          {
                              int numeroMovimiento = int.Parse(txtNumeroMovimiento.Text);
                              DateTime fechaTransferencia = Convert.ToDateTime(txtFechaTransferencia.Text);

                              // actualiza la devolucion seleccionada, dando respuesta a devolucion aceptada
                              DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                              dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(Id, 4, 0);
                              AdministrarDevolucionDePrima.ActualizarDevolucionNumeroFechaTransferencia(Id, numeroMovimiento, fechaTransferencia);

                              // lista de nuevo el Grid, excluyendo el registro ya actualizado
                              dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionConfirmacion(3);
                              grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionConfirmacion;
                              grvDevolucionDePrimaConfirmacion.DataBind();
                              Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;
                              txtCedula.Text = "";
                              ddlLocalidad.Enabled = true;
                          }
                          else
                          {
                              lblError.ForeColor = Color.Red;
                              lblError.Text = "Debe llenar los campos del movimiento";
                          }
                      }
                      else
                      {
                          divMovimiento.Visible = false;
                          // actualiza la devolucion seleccionada, dando respuesta a devolucion aceptada
                          DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
                          dtActualizarEstadoDevolucionRechazadaAceptada = AdministrarDevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(Id, 4, 0);
                     
                          // lista de nuevo el Grid, excluyendo el registro ya actualizado
                          dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionConfirmacion(3);
                          grvDevolucionDePrimaConfirmacion.DataSource = dtConsultarDevolucionConfirmacion;
                          grvDevolucionDePrimaConfirmacion.DataBind();
                          Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;
                          txtCedula.Text = "";
                          ddlLocalidad.Enabled = true;
                      }               
                 }
                  //Si se presiona el boton de rechazar devolucion entrara en esta operacion
                  if (e.CommandName == "RechazarDevolucion_Click")
                 {
                     //Activa los campos necesarios paraq realizar el rechazo de la devolución
                     btnEnviarDevolucion.Visible = true;
                     ddlCausalRechazoDevolucionPrima.Visible = true;
                     lblCausalRechazo.Visible = true;

                    // Lista los causales de rechazo de devolución para que se seleccione la mas indicada
                     DataTable dtConsultarCausalDevolucionPrima = new DataTable();
                     dtConsultarCausalDevolucionPrima = AdministrarDevolucionDePrima.ConsultarCausalRechazoDevolucionPrima();
                     ddlCausalRechazoDevolucionPrima.DataTextField = "rech_Nombre";
                     ddlCausalRechazoDevolucionPrima.DataValueField = "rech_Id";
                     ddlCausalRechazoDevolucionPrima.DataSource = dtConsultarCausalDevolucionPrima;
                     ddlCausalRechazoDevolucionPrima.DataBind();

                      // se almacena en una variable el id de la fila seleccionada
                     idDevolucion = int.Parse(row.Cells[3].Text);
                 }
            }
        }

        protected void grvDevolucionDePrimaConfirmacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDevolucionDePrimaConfirmacion.PageIndex = e.NewPageIndex;
            grvDevolucionDePrimaConfirmacion.DataSource = (DataTable)Session["dtExportarDp"];
            grvDevolucionDePrimaConfirmacion.DataBind();
        
        }
        #endregion
    #endregion
}