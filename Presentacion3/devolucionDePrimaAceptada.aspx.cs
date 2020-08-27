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

public partial class Presentacion3_devolucionDePrimaAceptada : System.Web.UI.Page
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

    #region Variables globales y funciones iniciales.
    public static DataTable dtConsultarDevolucionConfirmacion = new DataTable();
    public static DataTable dtConsultarDevolucionPrima = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if(!IsPostBack)
        {
            //Listar las devoluciones que se encuentran en el estado de aceptadas
            dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionAceptada(4);
            grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionConfirmacion;
            grvDevolucionesDePrimaAceptada.DataBind();
            if (dtConsultarDevolucionConfirmacion.Rows.Count > 0)
            {
                btnExportarExcelDp.Visible = true;
            }
            else
            {
                btnExportarExcelDp.Visible = false;
            }
            Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;

            //Listar devoluciones en el ddl
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
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(int.Parse(Session["txtCedula"].ToString()), int.Parse(Session["ddLocalidad"].ToString()), 4);
                    grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrimaAceptada.DataBind();

                    //Guarda en session la información 
                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;

                    txtCedula.Text = Session["txtCedulaAceptada"].ToString();
                    ddlLocalidad.Enabled = true;
                    Session["Bandera"] = null;
                }
            }
            catch { }
            #endregion
        }
    }
    #endregion

    #region Eventos.
        #region Eventos de botones.
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Consultar las posibles devoluciones que existen con el documento ingresado
            double cedula = (txtCedula.Text == "") ? 0 : double.Parse(txtCedula.Text);
            int localidad = (ddlLocalidad.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlLocalidad.SelectedValue.ToString());
            dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(cedula, localidad, 4);
            grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionPrima;
            grvDevolucionesDePrimaAceptada.DataBind();

            if (dtConsultarDevolucionPrima.Rows.Count > 0)
            {
                btnExportarExcelDp.Visible = true;
            }
            Session["dtExportarDp"] = dtConsultarDevolucionPrima;
            Session["txtCedulaAceptada"] = txtCedula.Text;
            Session["ddLocalidadAceptada"] = localidad;

        }
        #endregion

        #region Seleccionables.
        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Consultar las posibles devoluciones que existen con la localidad seleccionada
            double cedula = (txtCedula.Text == "") ? 0 : double.Parse(txtCedula.Text);
            int localidad = (ddlLocalidad.SelectedValue.ToString() == "") ? 0 : int.Parse(ddlLocalidad.SelectedValue.ToString());
            dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(cedula, localidad, 4);
            grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionPrima;
            grvDevolucionesDePrimaAceptada.DataBind();

            Session["dtExportarDp"] = dtConsultarDevolucionPrima;
            Session["txtCedulaAceptada"] = txtCedula.Text;
            Session["ddLocalidadAceptada"] = ddlLocalidad.SelectedValue.ToString();
        }
    #endregion

        #region Eventos de tablas.
        protected void grvDevolucionesDePrimaAceptada_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvDevolucionesDePrimaAceptada.Rows[(index)];


            if (e.CommandName == "Consultar_Click")
            {
                Session["IdDevolucion"] = int.Parse(row.Cells[1].Text);

                if (Session["idDevolucion"] != null)
                {
                    Session["Bandera"] = 1;
                    //Si hay una devolucion de prima seleccionada en la variable de session, se llena el Grid con las Aplicaciones que encuentre asociada
                    grdAplicacionesPagosDevolucion.DataSource = AdministrarDevolucionDePrima.ConsultarAplicacionesDevolucion(Convert.ToInt32(Session["idDevolucion"].ToString()));
                    grdAplicacionesPagosDevolucion.DataBind();

                    //Se llenan los soportes por id de devolución
                    DataTable dtTemp = new DataTable();
                    dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                    grvArchivosSoporteM.DataSource = dtTemp;
                    grvArchivosSoporteM.DataBind();
                }
            }
        }

        protected void grvDevolucionesDePrimaAceptada_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDevolucionesDePrimaAceptada.PageIndex = e.NewPageIndex;
            //Si documento esta vacio se listan todas las devoluciones tramitadas
            if (txtCedula.Text == "")
            {
                dtConsultarDevolucionConfirmacion = AdministrarDevolucionDePrima.ConsultarDevolucionAceptada(4);
                grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionConfirmacion;
                grvDevolucionesDePrimaAceptada.DataBind();
                Session["dtExportarDp"] = dtConsultarDevolucionConfirmacion;
            }
            else
            {
                //Si ya hay un numero de documento y una localidad seleccionada
                if (ddlLocalidad.SelectedValue.ToString() != "")
                {
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(double.Parse(txtCedula.Text), int.Parse(ddlLocalidad.SelectedValue.ToString()), 4);
                    grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrimaAceptada.DataBind();
                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                }
                else
                {
                    //Consultar las posibles devoluciones que existen con el documento ingresado
                    dtConsultarDevolucionPrima = AdministrarDevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(double.Parse(txtCedula.Text), 0, 4);
                    grvDevolucionesDePrimaAceptada.DataSource = dtConsultarDevolucionPrima;
                    grvDevolucionesDePrimaAceptada.DataBind();
                    Session["dtExportarDp"] = dtConsultarDevolucionPrima;
                }
            }
        }
    #endregion

        #region Exportar a excel.
        protected void btnExportarExcelDp_Click(object sender, System.EventArgs e)
        {
            //Exportar a excel
            DataTable dtConsultarDevolucionDePrima = (DataTable)Session["dtExportarDp"];
            if (dtConsultarDevolucionDePrima.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtConsultarDevolucionDePrima, "Devoluciones aceptadas");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE DEVOLUCIONES ACEPTADAS" + "');", true);
            }
        }
    #endregion
    #endregion

    #region Metodos.
    /*Metodo que usa un codigo javascript para generar una ventana modal; 
    para este caso en particuar muestra las aplicaciones de pago asociadas a una devolucion de prima*/
    public void MostrarModal(String jScript)
    {
        //String jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
    }
    #endregion
}