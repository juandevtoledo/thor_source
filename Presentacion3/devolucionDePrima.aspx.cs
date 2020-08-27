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

public partial class Presentacion3_devolucionDePrima : System.Web.UI.Page
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
    public static DataTable dtConsultarDevolucionDePrima = new DataTable();
    public static List<long> listInsertarPagoDevolucion = new List<long>();
    public static List<long> listConvenio = new List<long>();
    public static List<long> listBandera = new List<long>();
    int _aplPagoId = 0;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
                
        if (!IsPostBack)
        {
            //Bloquear y ocultar campos que no deben aparecer en primer momento
            lblValorDevolucion.Visible = false;
            txtValorDevolucion.Visible = false;
            btnExportarExcelDp.Visible = false;
            txtValorDevolucion.Enabled = false;
            btnGuardarDevolucion.Visible = false;
            btnRealizarAplicacion.Visible = false;
            btnRealizarAplicacion.Enabled = true;
            ddlCompania.Enabled = false;
            ddlProducto.Enabled = false;
            ddlConvenio.Enabled = false;
            Session["boolDevolucion"] = "0";
        }
    }
    #endregion

    #region Eventos
        #region Lista de devoluciones segun seleccionables
            #region Compañia
            protected void ddlCompania_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                ddlProducto.Enabled = true;

                //se listan los productos solo cuando la compañia ya fue seleccionada
                if (ddlCompania.SelectedValue.ToString() != "")
                {
                    DataTable dtConsultarProducto = new DataTable();
                    dtConsultarProducto = AdministrarDevolucionDePrima.ConsultarProductoPorCompania(int.Parse(ddlCompania.SelectedValue.ToString()));
                    ddlProducto.DataTextField = "pro_Nombre";
                    ddlProducto.DataValueField = "pro_Id";
                    ddlProducto.DataSource = dtConsultarProducto;
                    ddlProducto.DataBind();
                    ddlProducto.Items.Insert(0, new ListItem("", ""));

                }
                /*Si no esta seleccionada la pagaduria se borra el convenio y el producto ya seleccionado, 
                ademas de pagar de nuevos las devoluciones solo por cedula*/
                else
                {
                    ddlConvenio.Items.Clear();
                    ddlConvenio_SelectedIndexChanged(sender, e);
                    ddlProducto.Items.Clear();
                    if (txtCedula.Text != "")
                    {
                        dtConsultarDevolucionDePrima = AdministrarDevolucionDePrima.ConsultarDevolucionDePrimaDocumento(double.Parse(txtCedula.Text), 0);
                        grvDevolucionesDePrima.DataSource = dtConsultarDevolucionDePrima;
                        grvDevolucionesDePrima.DataBind();
                    }
                }
            }
            #endregion

            #region Producto
            protected void ddlProducto_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                //Listar en el GridView segun el documento y el id de producto solo si estos 2 campos son diferentes de vacio
                if (ddlProducto.SelectedValue.ToString() != "" && txtCedula.Text != "")
                {
                    DataTable dtConvenio = AdministrarDevolucionDePrima.ConsultarConvenioProducto(double.Parse(txtCedula.Text), int.Parse(ddlProducto.SelectedValue.ToString()));
                    ddlConvenio.DataTextField = "con_Nombre";
                    ddlConvenio.DataValueField = "con_Id";
                    ddlConvenio.DataSource = dtConvenio;
                    ddlConvenio.DataBind();

                    dtConsultarDevolucionDePrima = AdministrarDevolucionDePrima.ConsultarDevolucionDePrimaDocumento(double.Parse(txtCedula.Text), int.Parse(ddlProducto.SelectedValue.ToString()));
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionDePrima;
                    grvDevolucionesDePrima.DataBind();

                    Session["dtExportarDp"] = dtConsultarDevolucionDePrima;

                    if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                    {
                        //Activar y mostrar campos cuando el producto ya fue seleccionado
                        ddlCompania.Enabled = true;
                        ddlProducto.Enabled = true;
                        lblValorDevolucion.Visible = true;
                        txtValorDevolucion.Visible = true;
                        btnExportarExcelDp.Visible = true;
                        btnGuardarDevolucion.Visible = true;
                        if (ddlConvenio.SelectedValue != "" || Session["boolDevolucion"].ToString() == "1")
                        {
                            btnRealizarAplicacion.Visible = true;
                        }
                    }
                    else
                    {
                        //no  mostrar campos cuando tabla esta vacia
                        ddlCompania.Enabled = true;
                        ddlProducto.Enabled = true;
                        lblValorDevolucion.Visible = false;
                        txtValorDevolucion.Visible = false;
                        btnExportarExcelDp.Visible = false;
                        btnGuardarDevolucion.Visible = false;
                        btnRealizarAplicacion.Visible = false;
                    }
                }
                else
                {
                    ddlConvenio.Items.Clear();
                    ddlConvenio_SelectedIndexChanged(sender, e);
                }
            }
            #endregion

            #region Convenio
            protected void ddlConvenio_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                //muestra u oculta el boton de devolver dependiendo del valor de la session
                if (ddlConvenio.SelectedValue.ToString() != "" || Session["boolDevolucion"].ToString() == "1")
                {
                    btnRealizarAplicacion.Visible = true;
                }
                else
                {
                    btnRealizarAplicacion.Visible = false;
                }
            }
    #endregion
    #endregion

        #region Eventos de botones
            #region Buscar
            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                //Entrar a esta funcionalidad si en el campo ya hay un numero
                if (txtCedula.Text != "")
                {
                    //Consultar las posibles devoluciones que existen con el documento ingresado
                    dtConsultarDevolucionDePrima = AdministrarDevolucionDePrima.ConsultarDevolucionDePrimaDocumento(double.Parse(txtCedula.Text), 0);
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionDePrima;
                    grvDevolucionesDePrima.DataBind();

                    Session["dtExportarDp"] = dtConsultarDevolucionDePrima;

                    //si efectivamente existen posibles devoluciones con este documento
                    if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                    {
                        //Habilitar el campo de compañia y listar todas ellas   
                        ddlCompania.Enabled = true;

                        DataTable dtConsultarCompania = new DataTable();
                        dtConsultarCompania = AdministrarDevolucionDePrima.ConsultarCompaniaGeneral();
                        ddlCompania.DataTextField = "com_Nombre";
                        ddlCompania.DataValueField = "com_Id";
                        ddlCompania.DataSource = dtConsultarCompania;
                        ddlCompania.DataBind();
                        ddlCompania.Items.Insert(0, new ListItem("", ""));

                        ddlConvenio.Items.Clear();
                        btnRealizarAplicacion.Visible = false;

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Seleccione la compañía y el producto del asegurado" + "');", true);
                    }
                    //Si no existen posibles devoluciones con el documento ingresado
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Este cliente no tiene posibles devoluciones" + "');", true);
                    }
                }

                //Si el campo documento esta vacio 
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Ingrese un número de documento" + "');", true);
                }
            }
            #endregion

            #region Guardar devolución
            protected void btnGuardarDevolucion_Click(object sender, System.EventArgs e)
            {
                //Realizar la operacion de guardar solo si hay datos en el GridView
                if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                {
                    //Consultar la localidad del tercero
                    int depId = AdministrarDevolucionDePrima.ConsultarLocalidadPorCedula(double.Parse(txtCedula.Text));

                    //Insertar la devolucion en su primer momento, unificando las aplicaciones que se encontraban como devolucion de prima
                    DataTable dtConsultarInsertarDevolucionPrimaMomento1 = new DataTable();
                    dtConsultarInsertarDevolucionPrimaMomento1 = AdministrarDevolucionDePrima.InsertarDevolucionDePrimaMomento1(double.Parse(txtCedula.Text), int.Parse(ddlProducto.SelectedValue.ToString()), depId, double.Parse(txtValorDevolucion.Text), 1, 0);

                    //Recorrer el GridView para identificar las filas que fueron seleccionadas
                    foreach (int Id in listInsertarPagoDevolucion)
                    {
                        //Insertar el id del pago de cada una de las filas que fueron seleccionadas con el id de la devolucion ingresada anteriormente
                        DataTable dtspInsetarAplicacionPagoDevolucion = new DataTable();
                        dtspInsetarAplicacionPagoDevolucion = AdministrarDevolucionDePrima.InsetarAplicacionPagoDevolucion(Id, int.Parse(dtConsultarInsertarDevolucionPrimaMomento1.Rows[0]["dev_Id"].ToString()));
                    }

                    //Se vuelven a listar estas posibles devoluciones excluyendo las que se unificaron
                    dtConsultarDevolucionDePrima = AdministrarDevolucionDePrima.ConsultarDevolucionDePrimaDocumento(double.Parse(txtCedula.Text), int.Parse(ddlProducto.SelectedValue.ToString()));
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionDePrima;
                    grvDevolucionesDePrima.DataBind();

                    Session["dtExportarDp"] = dtConsultarDevolucionDePrima;

                    if (dtConsultarDevolucionDePrima.Rows.Count == 0)
                    {
                        txtValorDevolucion.Visible = false;
                        btnExportarExcelDp.Visible = false;
                        btnGuardarDevolucion.Visible = false;
                        lblValorDevolucion.Visible = false;
                        btnRealizarAplicacion.Visible = false;
                    }
                    //Response.Redirect("DevolucionDePrima2.aspx");
                    Response.RedirectToRoute("devolucionPrimaTramitar");
                }
            }
            #endregion

            #region Pasar de una devolución a una aplicación
            protected void btnRealizarAplicacion_Click(object sender, System.EventArgs e)
            {
                Pagos objPago = new Pagos();
                DataTable dtProductoARealizarPago = new DataTable();
                DataTable ConsultarIdPagos = new DataTable();
                double pago = 0;
                double valorAplicar = 0;

                if (dtConsultarDevolucionDePrima.Rows.Count > 0)
                {
                    //Cambio de de campo reversion
                    foreach (int id in listInsertarPagoDevolucion)
                    {
                        AdministrarDevolucionDePrima.ActualizarReversionYBorradoDeAplicacion(id, 0);
                    }

                    //Recorrer el GridView para identificar las filas que fueron seleccionadas
                    for (int i = 0; i < listInsertarPagoDevolucion.Count; i++)
                    {
                        int id = int.Parse(listInsertarPagoDevolucion.ElementAt(i).ToString());

                        DataTable dtAplicacionADevolver = new DataTable();
                        dtAplicacionADevolver = AdministrarDevolucionDePrima.ConsultarAplicacionPagoPorId(id);

                        if (dtAplicacionADevolver.Rows.Count > 0)
                        {
                            int eliminados = AdministrarDevolucionDePrima.EliminarAplicacionPagoPorId(id);

                            pago = double.Parse(dtAplicacionADevolver.Rows[0]["aplPago_Valor"].ToString());

                            while (pago > 0)
                            {
                                if (listBandera.ElementAt(i).ToString() == "1")
                                {
                                    dtProductoARealizarPago = objPago.ConsultarProductoParaPago(int.Parse(dtAplicacionADevolver.Rows[0]["ter_Id"].ToString()), int.Parse(listConvenio.ElementAt(i).ToString())); //Consulta el producto para pago (script Mauro)
                                }
                                else
                                {
                                    dtProductoARealizarPago = AdministrarDevolucionDePrima.ConsultarProductoParaPagoPorProducto(double.Parse(dtAplicacionADevolver.Rows[0]["ter_Id"].ToString()), int.Parse(ddlConvenio.SelectedValue), int.Parse(ddlProducto.SelectedValue)); //Consulta el producto para pago (script Mauro)
                                }
                                // Se debe realizar la aplicacion de los pagos
                                valorAplicar = double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                                if (pago < double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()))
                                {
                                    valorAplicar = pago;
                                }
                                objPago.IngresarAplicacionPagoCliente(double.Parse(dtAplicacionADevolver.Rows[0]["ter_Id"].ToString()),
                                    int.Parse(dtAplicacionADevolver.Rows[0]["pago_Id"].ToString()),
                                    int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()),
                                    Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar,
                                    int.Parse(ddlConvenio.SelectedValue), 0, double.Parse(dtAplicacionADevolver.Rows[0]["pago_Recibo"].ToString()), double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString())); //Inserta el pago en tabla NewAplicacionPago
                                pago -= double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                            }
                        }
                    }
                    //Se vuelven a listar estas posibles devoluciones excluyendo las que se unificaron
                    dtConsultarDevolucionDePrima = AdministrarDevolucionDePrima.ConsultarDevolucionDePrimaDocumento(double.Parse(txtCedula.Text), int.Parse(ddlProducto.SelectedValue.ToString()));
                    grvDevolucionesDePrima.DataSource = dtConsultarDevolucionDePrima;
                    grvDevolucionesDePrima.DataBind();

                    if (dtConsultarDevolucionDePrima.Rows.Count == 0)
                    {
                        txtValorDevolucion.Visible = false;
                        btnGuardarDevolucion.Visible = false;
                        lblValorDevolucion.Visible = false;
                        btnRealizarAplicacion.Visible = false;
                    }
                }
            }
    #endregion
    #endregion

        #region Eventos de la tabla
        protected void chkSeleccionar_OnCheckedChanged(object sender, EventArgs e)
        {
            double valorTotal = 0;
            listInsertarPagoDevolucion = new List<long>();
            listConvenio = new List<long>();
            listBandera = new List<long>();
            bool banderaBotonDevolver = false;
            DataTable dtAplicacion = new DataTable();

            //Recorrer por medio de un foreach la tabla devoliciones de primar para observar cuantas de ellas estan seleccionadas para unificarlas
            foreach (GridViewRow row in grvDevolucionesDePrima.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;

                //Solo se ingresa aca cuando la fila que se recorre esta seleccionada
                if (check.Checked)
                {
                    // Almacenar en una variable el valor de cada una de las filas seleccionadas
                    double valor = 0;
                    valor = double.Parse(row.Cells[6].Text);
                    valorTotal += valor;

                    //Almacenar el id del pago de las filas seleccionadas
                    _aplPagoId = int.Parse(row.Cells[1].Text);
                    listInsertarPagoDevolucion.Add(_aplPagoId);

                    //Almacenar el id del pago de las filas seleccionadas
                    DataTable dtConvenio = AdministrarDevolucionDePrima.ConsultarConvenioNombre(row.Cells[7].Text);
                    int conId = int.Parse(dtConvenio.Rows[0]["con_Id"].ToString());
                    listConvenio.Add(conId);

                    //Consulta la información de la aplicación por id
                    dtAplicacion = AdministrarDevolucionDePrima.ConsultarAplicacionPagoPorId(_aplPagoId);
                    //Cosulta certificado por cedula y convenio
                    DataTable dtCertificado = AdministrarDevolucionDePrima.ConsultarCertificadoPorConvenio(row.Cells[2].Text, row.Cells[7].Text);

                    if (dtAplicacion.Rows[0]["dev_Id"].ToString() != "1" )
                    {
                        banderaBotonDevolver = true;
                        listBandera.Add(0);
                    }
                    else
                    {
                        if (ddlConvenio.SelectedValue.ToString() != "")
                        {
                            if (row.Cells[7].Text != ddlConvenio.SelectedItem.ToString())
                            {
                                banderaBotonDevolver = true;
                                Session["boolDevolucion"] = "0";
                            }
                            listBandera.Add(0);
                        }
                        else
                        {
                            if (row.Cells[4].Text != "DEVOLUCION DE PRIMA")
                            {
                                banderaBotonDevolver = true;
                                Session["boolDevolucion"] = "0";
                                listBandera.Add(0);
                            }
                            else
                            {
                                if (dtCertificado.Rows.Count > 0)
                                {
                                    Session["boolDevolucion"] = "1";
                                    listBandera.Add(1);
                                    btnRealizarAplicacion.Visible = true;
                                }
                                else
                                {
                                    listBandera.Add(0);
                                    banderaBotonDevolver = true;
                                }
                            }
                        }
                    }
                }
            }

            if(banderaBotonDevolver)
            {
                btnRealizarAplicacion.Enabled = false;
            }
            else
            {
                btnRealizarAplicacion.Enabled = true;
            }

            //Almacenar en el campo de texto la variable que almacena el valor de las devoluciones unicamente cuando el dd
            //producto esta diferente de vacio
            if (ddlProducto.SelectedValue.ToString() != "")
            {
                txtValorDevolucion.Text = valorTotal.ToString();
            }
        }
    #endregion

        #region Exportar a excel
        protected void btnExportarExcelDp_Click(object sender, System.EventArgs e)
        {
            //Evento para exportar a excel
            DataTable dtConsultarDevolucionDePrima = (DataTable)Session["dtExportarDp"];
            if (dtConsultarDevolucionDePrima.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtConsultarDevolucionDePrima, "Posibles devoluciones");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No hay información en la planilla de posibles devoluciones" + "');", true);
            }
        }
        #endregion
    #endregion
}


