using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;

public partial class Presentacion2_ReestructurarConciliacion : System.Web.UI.Page
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

    public Pagos objPago = new Pagos();
    DataTable dtAgencia = new DataTable(), dtProducto = new DataTable(), dtPagaduria = new DataTable(), dtConvenio = new DataTable(); //Se declaran los dt
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            //Carga las agencias, trayendo el Id y el nombre de ellas
            dtAgencia = objAdministrarCertificados.ConsultarAgencia();
            ddlAgencia.DataValueField = "age_Id";
            ddlAgencia.DataTextField = "age_Nombre";
            ddlAgencia.DataSource = dtAgencia;
            ddlAgencia.DataBind();
            ddlAgencia.Items.Insert(0, new ListItem("", ""));

            h4Convenios.Visible = false;
            h5CertificadosConvenios.Visible = false;

            DataTable dtConveniosReversion = objPago.ConsultarConveniosReversionManual();
            if (dtConveniosReversion.Rows.Count > 0)
            {
                grvConveniosReestructuracion.DataSource = dtConveniosReversion;
                grvConveniosReestructuracion.DataBind();

                h4Convenios.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "NO HAY CONVENIOS PENDIENTES POR REVERSIÓN" + "');", true);
            }
        }
    }
    protected void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLocalidad.Enabled = true;
        //el fin de este metodo es traer las localidades a las que pertenece esta agencia
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlAgencia.SelectedValue.ToString() != "")
        {
            DataTable dtLocalidadesPorAgencia = new DataTable();
            dtLocalidadesPorAgencia = objAdministrarCertificados.ConsultarLocalidadPorAgencia(int.Parse(ddlAgencia.SelectedValue.ToString()));
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidadesPorAgencia;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));
        
        }
    }

    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlLocalidad.SelectedValue.ToString() != "")
        {
            //Carga el ddlPagaduria según seleccion del ddlAgencia
            dtPagaduria = objAdministrarCertificados.ConsultarPagaduriaPorLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            ddlPagaduria.Items.Insert(0, new ListItem("", ""));
        }
    }
    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Carga el ddlConvenio según seleccion del ddlAgencia ddlProducto ddlPagaduria            

        if (ddlPagaduria.SelectedValue.ToString() != "")
        {
            dtConvenio = objPago.ConsultarConveniosConciliacion(int.Parse(ddlPagaduria.SelectedValue.ToString()));
            ddlConvenio.DataTextField = "con_Nombre";
            ddlConvenio.DataValueField = "con_Id";
            ddlConvenio.DataSource = dtConvenio;
            ddlConvenio.DataBind();
            ddlConvenio.Items.Insert(0, new ListItem("", ""));

        }
        else
        {
            ddlLocalidad_SelectedIndexChanged(sender, e);
        }
    }

    protected void ddlConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
    protected void btnReestructurar_Click(object sender, EventArgs e)
    {
        //Si el convenio es diferente de vacio, de lo contrario mostrara un mensaje que dira seleccionar convenio.
        if (ddlConvenio.SelectedValue.ToString() != "")
        {
            AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
                        
            DataTable dtEnviarInformacion = new DataTable();

            //ConsultarCertificados con posibles devoluciones
            DataTable dtConsultarCertificadoReversion = new DataTable();
            dtConsultarCertificadoReversion = objPago.ConsultarCertificadoReversion(int.Parse(ddlConvenio.SelectedValue.ToString()));

            // Pregunta si hay posibles certificados para reversión
            if (dtConsultarCertificadoReversion.Rows.Count > 0)
            {
                //Recorre el dt con las posibles reversiones
                foreach (DataRow dt in dtConsultarCertificadoReversion.Rows)
                {
                    ////Consulta archivo pagaduria
                    //DataTable dtArchivo = new DataTable();
                    //dtArchivo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtConsultarCertificadoReversion.Rows[0]["Producto"].ToString()), int.Parse(ddlConvenio.SelectedValue.ToString()));

                    //Consulta las aplicaciones que fueron mayores o iguales al inicio de vigencia del certificado y las trae agrupadas por valor
                    DataTable dtConsultarUltimoPagoParaReversion = new DataTable();
                    dtConsultarUltimoPagoParaReversion = objPago.ConsultarUltimoPagoParaReversion(double.Parse(dt["Cedula"].ToString()), DateTime.Parse(dt["cer_VigenciaDesde"].ToString()), double.Parse(dt["Producto"].ToString()));

                    //Pregunta si el cliente tuvo algun pago luego o igual al inicio del certificado
                    if (dtConsultarUltimoPagoParaReversion.Rows.Count > 0)
                    {

                        //Crea una marca para saber si ya no es necesario seguir recorriendo el foreach, ya que ya se encontro lo necesario para realizar una devolución
                        int reversion = 0;

                        //Recorre el dt con los pagos agrupados
                        foreach (DataRow dt2 in dtConsultarUltimoPagoParaReversion.Rows)
                        {
                            /*Pregunta si la totalidad de los pagos traidos en cada una de las filas es igual a la prima del certificado 
                             y si la bandera aun esta en 0, si es igual o mayor la totalidad de los pagos quiere decir que no es una reversión*/
                            if (double.Parse(dt2["pagoMes"].ToString()) < double.Parse(dt["Prima"].ToString()) && reversion == 0)
                            {
                                //Clona el dt que se esta recorriendo, todo esto con el fin de importar a un nuevo dt la fila requerida
                                dtEnviarInformacion = dtConsultarCertificadoReversion.Clone();
                                dtEnviarInformacion.ImportRow(dt);

                                //envia la información necesaria para realizar una reversión
                                objPago.RealizarReversion(dtEnviarInformacion);
                                //marca la bandera para no realizar este proceso por un mismo certificado
                                reversion = 1;
                            }
                        }
                    }
                    else
                    {
                        //Clona la final la cual no tiene pago pero igual seguira siendo una reversión
                        dtEnviarInformacion = dtConsultarCertificadoReversion.Clone();
                        dtEnviarInformacion.ImportRow(dt);

                        //envia la información necesaria para realizar una reversión
                        objPago.RealizarReversion(dtEnviarInformacion);
                    }
                    //Actualiza la fecha de reestructuración y marca, con el fin de saber si este proceso se realizo manual o automaticamente
                    DataTable dtActualizarFechaYMarcarReestructuracion = new DataTable();
                    dtActualizarFechaYMarcarReestructuracion = objPago.ActualizarFechaYMarcarReestructuracion(double.Parse(dt["Convenio"].ToString()), 0);
                }          
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE CONVENIO NO TIENE CERTIFICADOS PENDIENTES PARA REVERSIÓN" + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione EL CONVENIO POR FAVOR" + "');", true);
        }
       
    }
 
    protected void grvConveniosReestructuracion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // obtener el id de la fila seleccionada
        int index = int.Parse(e.CommandArgument.ToString());
        DataTable dtEnviarInformacion = new DataTable();
        GridViewRow row = grvConveniosReestructuracion.Rows[(index)];

        if (e.CommandName == "Consultar_Click")
        {
            //Asigna a una variable el codigo solicitado
            int id = int.Parse(row.Cells[1].Text);

            //ConsultarCertificados con posibles reestructuraciones
            DataTable dtConsultarCertificadoReversion = new DataTable();
            dtConsultarCertificadoReversion = objPago.ConsultarCertificadoReversionConsulta(int.Parse(id.ToString()));
            
            //Clona el dt que se esta recorriendo, todo esto con el fin de importar a un nuevo dt la fila requerida
            dtEnviarInformacion = dtConsultarCertificadoReversion.Clone();

            //Pregunta si hay posibles devoluciones
            if (dtConsultarCertificadoReversion.Rows.Count > 0)
            {
                foreach(DataRow dt in dtConsultarCertificadoReversion.Rows)
                {
                    //Consulta las aplicaciones que fueron mayores o iguales al inicio de vigencia del certificado y las trae agrupadas por valor
                    DataTable dtConsultarUltimoPagoParaReversion = new DataTable();
                    dtConsultarUltimoPagoParaReversion = objPago.ConsultarUltimoPagoParaReversion(double.Parse(dt["Cedula"].ToString()), DateTime.Parse(dt["Inicio de vigencia"].ToString()), double.Parse(dt["pro_Id"].ToString()));
                       
                    //Pregunta si el cliente tuvo algun pago luego o igual al inicio del certificado
                    if (dtConsultarUltimoPagoParaReversion.Rows.Count > 0)
                    {
                        //Crea una marca para saber si ya no es necesario seguir recorriendo el foreach, ya que ya se encontro lo necesario para realizar una devolución
                        int reversion = 0;

                        //Recorre el dt con los pagos agrupados
                        foreach (DataRow dt2 in dtConsultarUltimoPagoParaReversion.Rows)
                        {
                            /*Pregunta si la totalidad de los pagos traidos en cada una de las filas es igual a la prima del certificado 
                             y si la bandera aun esta en 0, si es igual o mayor la totalidad de los pagos quiere decir que no es una reversión*/
                            if (double.Parse(dt2["pagoMes"].ToString()) < double.Parse(dt["Prima"].ToString()) && reversion == 0)
                            {
                                
                                dtEnviarInformacion.ImportRow(dt);

                                //marca la bandera para no realizar este proceso por un mismo certificado
                                reversion = 1;
                            }
                        }
                    }
                    else
                    {
                        dtEnviarInformacion.ImportRow(dt);
                    }
                }
                //Asigna a un Grv la información con posibles reestructuraciones
                grvAplicacionesPorConvenio.DataSource = dtEnviarInformacion;
                grvAplicacionesPorConvenio.DataBind();
                lblNombreConvenio.Text = row.Cells[2].Text;
                h5CertificadosConvenios.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "ESTE CONVENIO NO TIENE CERTIFICADOS PENDIENTES PARA REVERSIÓN" + "');", true);
            }
        }
    }
}