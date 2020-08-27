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


public partial class Presentacion2_FrmNovedades : System.Web.UI.Page
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

    #region Variable global y cargue de seleccionables iniciales
    public static DataTable _dtNovedad = new DataTable();
    public static DataTable _dtNovedadArchivo = new DataTable();
    public static DataTable _dtNovedadArchivoPendiente = new DataTable();
    public static DataTable _dtNovedadArchivoAplicadas = new DataTable();
    public static DataTable _dtNovedadArchivoSinAplicar = new DataTable();
    public static DataTable _dtNovedadArchivoCuentaCobro = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        //Mensaje informatico al momento de entrar al modulo
        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "RECUERDE QUE SOLO SE ENVIARAN COMO NOVEDADES DEFINITIVAS LAS QUE SEAN IGUALES O INFERIORES AL MES Y EL AÑO ACTUAL" + "');", true);
        }
        if (!IsPostBack)
        {
            btnExportarMes.Enabled = true;

            _dtNovedad.Clear();
            _dtNovedadArchivo.Clear();
            _dtNovedadArchivoCuentaCobro.Clear();
            _dtNovedadArchivoPendiente.Clear();

            DataTable dtUsuario = PrecargueProduccion.ConsultarUsuario(Session["usuario"].ToString());


            // Añadir datos al ddl localidad
            DataTable dtLocalidadeasAgencia = new DataTable();
            dtLocalidadeasAgencia = AdministrarNovedades.LocalidadesAgencia(int.Parse(dtUsuario.Rows[0]["age_Id"].ToString()));
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidadeasAgencia;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));


            // Añadir datos al ddl mes
            DataTable dtMes = new DataTable();
            dtMes = AdministrarNovedades.ConsultarMes();
            ddlMes.DataTextField = "mes_Nombre";
            ddlMes.DataValueField = "mes_Id";
            ddlMes.DataSource = dtMes;
            ddlMes.DataBind();
            ddlMes.Items.Insert(0, new ListItem("", ""));


            // Añadir datos al ddl anio
            DataTable dtAnio = new DataTable();
            dtAnio = AdministrarNovedades.ConsultarAnio();
            ddlAnio.DataTextField = "anio_Numero";
            ddlAnio.DataValueField = "anio_Numero";
            ddlAnio.DataSource = dtAnio;
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new ListItem("", ""));

            // Añade datos al ddl de causal para enviar a sin aplicar
            DataTable dtSinAplicar = new DataTable();
            dtSinAplicar = AdministrarNovedades.ConsultarCausales();
            ddlSinAplicar.DataTextField = "noAplNov_Nombre";
            ddlSinAplicar.DataValueField = "noAplNov_Id";
            ddlSinAplicar.DataSource = dtSinAplicar;
            ddlSinAplicar.DataBind();
            ddlSinAplicar.Items.Insert(0, new ListItem("", ""));


            // Añadir datos al ddl estados de la novedad
            DataTable dtEstadoNovedad = new DataTable();
            dtEstadoNovedad = AdministrarNovedades.ConsultarEstadoNovedades();
            ddlEstadoHistorico.DataTextField = "Estado";
            ddlEstadoHistorico.DataValueField = "nov_Estado";
            ddlEstadoHistorico.DataSource = dtEstadoNovedad;
            ddlEstadoHistorico.DataBind();
            ddlEstadoHistorico.Items.Insert(0, new ListItem("", ""));

            btnEnviarNovedades.Enabled = false;
            chkEnviarNovedad.Visible = false;

            //Tab de Mes
            noNovedadesMes.Visible = true;
            listaNovedadesMes.Visible = false;

            //Tab de Pendientes
            pendientesPorAplicar.Visible = false;
            noPendientesPorAplicar.Visible = true;
            formPendientesPorAplicar.Visible = false;

            //Tab de Novedades sin aplicar
            novadadesSinAplicar.Visible = false;
            noNovadadesSinAplicar.Visible = true;

            //Tab de Novedades aplicadas
            novadadesAplicadas.Visible = false;
            noNovadadesAplicadas.Visible = true;

            //Tab de Novedades historico
            ddlEstadoHistorico.Enabled = false;
            novadadesHistorico.Visible = false;
            noNovadadesHistorico.Visible = true;
        }
    }
    #endregion

    #region Eventos
        #region listar tablas segun sus seleccionables
            #region Localidad 
            protected void ddlLocalidad_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                // Variables para consultas
                Session["localidad"] = ddlLocalidad.SelectedValue.ToString();

                int localidad = (Session["localidad"].ToString() == "") ? 0 : int.Parse(Session["localidad"].ToString());


                // Limpiamos ddlPagaduria
                ddlPagaduria.Items.Clear();
                ddlPagaduria.SelectedIndex = -1;


                // Se cargan la lista de la pagaguria
                DataTable dtPagaduria = new DataTable();
                dtPagaduria = AdministrarNovedades.ConsultarPagaduriaLocalidad(localidad);
                ddlPagaduria.DataTextField = "paga_Nombre";
                ddlPagaduria.DataValueField = "paga_Id";
                ddlPagaduria.DataSource = dtPagaduria;
                ddlPagaduria.DataBind();
                ddlPagaduria.Items.Insert(0, new ListItem("", ""));


                //LLama al evento de pagaduria
                ddlPagaduria_SelectedIndexChanged(sender, e);
            }
    #endregion

            #region Pagaduria
            protected void ddlPagaduria_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                Session["pagaduria"] = ddlPagaduria.SelectedValue.ToString();

                // Variables para consultas
                int localidad = (Session["localidad"].ToString() == "") ? 0 : int.Parse(Session["localidad"].ToString());
                int pagaduria = (Session["pagaduria"].ToString() == "") ? 0 : int.Parse(Session["pagaduria"].ToString());


                // Limpiamos ddlArchivo
                ddlArchivo.Items.Clear();
                ddlArchivo.SelectedIndex = -1;

                // Se cargan la lista de los archivos que pertenecen a esa pagaduria
                DataTable dtArchivoPagaduria = new DataTable();
                dtArchivoPagaduria = AdministrarNovedades.ConsultarArchivoPagaduria(pagaduria, "0");
                ddlArchivo.DataTextField = "arcpag_Nombre";
                ddlArchivo.DataValueField = "arcpag_Id";
                ddlArchivo.DataSource = dtArchivoPagaduria;
                ddlArchivo.DataBind();
                ddlArchivo.Items.Insert(0, new ListItem("", ""));

                //LLama al evento de archivo
                ddlArchivo_SelectedIndexChanged(sender, e);
            }
    #endregion

            #region Archivo
            protected void ddlArchivo_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                Session["archivoId"] = ddlArchivo.SelectedValue.ToString();

                // Variables para consultas
                int localidad = (Session["localidad"].ToString() == "") ? 0 : int.Parse(Session["localidad"].ToString());
                int pagaduria = (Session["pagaduria"].ToString() == "") ? 0 : int.Parse(Session["pagaduria"].ToString());
                int archivo   = (Session["archivoId"].ToString() == "") ? 0 : int.Parse(Session["archivoId"].ToString());

                //LLama al evento de mes
                ddlMes_SelectedIndexChanged(sender, e);
            }
    #endregion

            #region Mes
            protected void ddlMes_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                Session["mes"] = ddlMes.SelectedValue.ToString();
                //LLama al evento de estado
                ddlEstadoHistorico_SelectedIndexChanged(sender, e);
            }
            #endregion

            #region Año
            protected void ddlAnio_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                Session["anio"] = ddlAnio.SelectedValue.ToString();

                // Variables para consultas
                int localidad = (Session["localidad"].ToString() == "") ? 0 : int.Parse(Session["localidad"].ToString());
                int pagaduria = (Session["pagaduria"].ToString() == "") ? 0 : int.Parse(Session["pagaduria"].ToString());
                int archivo = (Session["archivoId"].ToString() == "") ? 0 : int.Parse(Session["archivoId"].ToString());
                int mes = (Session["mes"].ToString() == "") ? 0 : int.Parse(Session["mes"].ToString());
                int anio = (Session["anio"].ToString() == "") ? 0 : int.Parse(Session["anio"].ToString());
                int estado = (Session["estadoPag"].ToString() == "") ? 0 : int.Parse(Session["estadoPag"].ToString());

                //Novedades del mes
                DataTable dtCargarNovedades = new DataTable();
                dtCargarNovedades = AdministrarNovedades.ConsultarNovedades(localidad, pagaduria, archivo, 1, 0, mes, anio);
                grvMes.DataSource = dtCargarNovedades;
                grvMes.DataBind();

                _dtNovedadArchivo = dtCargarNovedades;
                Session["dtNovedadMes"] = dtCargarNovedades;
                try
                {
                    //Se oculta cabecera y final de la pocision numero 10
                    grvMes.HeaderRow.Cells[10].Visible = false;
                    foreach (GridViewRow row in grvMes.Rows)
                    {
                        row.Cells[10].Visible = false;
                    }
                }
                catch
                { }
                //Si la variable de archivo tiene valor diferente de 0 muestra el check de lo contrario lo mantendra oculto
                if (archivo != 0)
                {
                    //Si el dt viene con información muestra el check
                    if (_dtNovedadArchivo.Rows.Count > 0)
                    {
                        chkEnviarNovedad.Visible = true;
                    }
                    else
                    {
                        chkEnviarNovedad.Visible = false;
                    }
                }
                else
                {
                    chkEnviarNovedad.Visible = false;
                }

                //Si se cargan novedades se muestra la tabla de lo contrario el mensaje
                if (dtCargarNovedades.Rows.Count > 0)
                {
                    listaNovedadesMes.Visible = true;
                    noNovedadesMes.Visible = false;
                }
                else
                {
                    listaNovedadesMes.Visible = false;
                    noNovedadesMes.Visible = true;
                }

                // Cargar novedades pendientes por aplicar
                _dtNovedadArchivoPendiente = AdministrarNovedades.ConsultarNovedadesArchivoEnviada(localidad, pagaduria, archivo, 1, 1);
                grvPendientePorAplicar.DataSource = _dtNovedadArchivoPendiente;
                grvPendientePorAplicar.DataBind();

                //Se carga en session la tabla para su posterior impresión
                Session["dtNovedadPendienteAplicar"] = _dtNovedadArchivoPendiente;

                //Si se cargan novedades se muestra la tabla de lo contrario el mensaje
                if (_dtNovedadArchivoPendiente.Rows.Count > 0)
                {
                    pendientesPorAplicar.Visible = true;
                    noPendientesPorAplicar.Visible = false;
                }
                else
                {
                    pendientesPorAplicar.Visible = false;
                    noPendientesPorAplicar.Visible = true;
                }


                // cargar novedades sin aplicar
                DataTable dtFechaSinAplicar = new DataTable();
                dtFechaSinAplicar = AdministrarNovedades.ConsultarFechaAplicacionNovedades();
                // Cargar novedades aplicadas
                DataTable dtFechaAplicacion = new DataTable();
                dtFechaAplicacion = AdministrarNovedades.ConsultarFechaAplicacionNovedades();

                DateTime fecha2;
                DateTime fecha3;

                DataTable dtCargarNovedadesMesYAnioAplicadas = new DataTable();
                DataTable dtCargarNovedadesMesYAnioSinAplicar = new DataTable();
                DataTable dtCargarNovedadesMesYAnioHistorico = new DataTable();

                //Pregunta si ya fue seleccionado el mes y el año para realizar el filtro por fechas
                if (mes != 0 && anio != 0)
                {
                    //Convierte el valor de los ddl seleccionados en fecha
                    int diasMes = DateTime.DaysInMonth(anio, mes);
                    fecha2 = DateTime.Parse("01/" + mes + "/" + anio);
                    fecha3 = DateTime.Parse(diasMes + "/" + mes + "/" + anio);

                    //Novedades por mes y año sin aplicar
                    dtCargarNovedadesMesYAnioSinAplicar = AdministrarNovedades.ConsultarNovedadesPorMesYAnioAplicadas(localidad, pagaduria,
                    archivo, 0, fecha2, fecha3);

                    //Novedades por mes y año aplicadas
                    dtCargarNovedadesMesYAnioAplicadas = AdministrarNovedades.ConsultarNovedadesPorMesYAnioAplicadas(localidad,
                    pagaduria, archivo, 2, fecha2, fecha3);

                    //Pregunta si ya se selecciono el estado para la busqueda del historico
                    if (estado != 0)
                    {
                        //Historico de novedades por mes, año y estado 
                        dtCargarNovedadesMesYAnioHistorico = AdministrarNovedades.ConsultarNovedadesPorEstadoHistorico(localidad,
                        pagaduria, archivo, fecha2, fecha3, estado);
                    }
                    else
                    {
                        //Historico de novedades por mes, año
                        dtCargarNovedadesMesYAnioHistorico = AdministrarNovedades.ConsultarNovedadesPorMesYAnioHistorico(localidad,
                        pagaduria, archivo, fecha2, fecha3);
                    }
                }
                else
                {
                    dtCargarNovedadesMesYAnioSinAplicar = AdministrarNovedades.ConsultarNovedadesArchivo(localidad, pagaduria,
                    archivo, 0);

                    dtCargarNovedadesMesYAnioAplicadas = AdministrarNovedades.ConsultarNovedadesArchivo(localidad, pagaduria,
                    archivo, 2);

                    ddlEstadoHistorico.Enabled = false;
                    dtCargarNovedadesMesYAnioHistorico = AdministrarNovedades.ConsultarNovedadesHistoricoArchivo(localidad,
                    pagaduria, archivo);
                }
                //Se carga a los GridView los resultados anteriores
                grvSinAplicar.DataSource = dtCargarNovedadesMesYAnioSinAplicar;
                grvSinAplicar.DataBind();
                grvAplicadas.DataSource = dtCargarNovedadesMesYAnioAplicadas;
                grvAplicadas.DataBind();
                grvHistorico.DataSource = dtCargarNovedadesMesYAnioHistorico;
                grvHistorico.DataBind();

                //Se envia los dt con la información en sessión para su exportación a excel
                Session["dtNovedadHistorico"] = dtCargarNovedadesMesYAnioHistorico;
                Session["dtNovedadAplicada"] = dtCargarNovedadesMesYAnioAplicadas;
                Session["dtNovedadSinAplicar"] = dtCargarNovedadesMesYAnioSinAplicar;

                //Si se cargan novedades se muestra la tabla de lo contrario el mensaje
                if (dtCargarNovedadesMesYAnioSinAplicar.Rows.Count > 0)
                {
                    novadadesSinAplicar.Visible = true;
                    noNovadadesSinAplicar.Visible = false;
                }
                else
                {
                    novadadesSinAplicar.Visible = false;
                    noNovadadesSinAplicar.Visible = true;
                }

                //Si se cargan novedades se muestra la tabla de lo contrario el mensaje
                if (dtCargarNovedadesMesYAnioAplicadas.Rows.Count > 0)
                {
                    novadadesAplicadas.Visible = true;
                    noNovadadesAplicadas.Visible = false;
                }
                else
                {
                    novadadesAplicadas.Visible = false;
                    noNovadadesAplicadas.Visible = true;
                }

                //Si se cargan novedades se muestra la tabla de lo contrario el mensaje
                if (dtCargarNovedadesMesYAnioHistorico.Rows.Count > 0)
                {
                    novadadesHistorico.Visible = true;
                    noNovadadesHistorico.Visible = false;
                }
                else
                {
                    novadadesHistorico.Visible = false;
                    noNovadadesHistorico.Visible = true;
                }
            }
    #endregion

            #region Estado historico
            protected void ddlEstadoHistorico_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                // Guarda en session el valor del estado
                Session["estadoPag"] = ddlEstadoHistorico.SelectedValue.ToString();
                ddlAnio_SelectedIndexChanged(sender, e);
            }
    #endregion
    #endregion

        #region Tab pendiente por aplicar
        protected void grvPendientePorAplicar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*Evento para identificar si se esta tratando de enviar a sin aplicar una novedad de retiro, en caso de
            * ser asi mostrara un alerta diciendo que no puede continuar con la operación, de lo contrario podra
            continuar con la operación*/
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = grvPendientePorAplicar.Rows[index];
            if (e.CommandName == "SinAplicar_Click")
            {
                string tipoNovedad = row.Cells[3].Text;

                if(tipoNovedad == "RETIRO")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "No se puede enviar una novedad de retiro a sin aplicar" + "');", true);
                    formPendientesPorAplicar.Visible = false;
                }
                else
                {
                    txtIdNovedad.Text = row.Cells[4].Text;
                    formPendientesPorAplicar.Visible = true;
                    txtIdNovedad.Enabled = false;
                }
            }
        }

        protected void btnEnviarSinAplicar_Click(object sender, System.EventArgs e)
        {
            AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtCertificados = new DataTable();
            DataTable dtNovedad = new DataTable();
            DataTable dtNovedades = new DataTable();
            double valor = 0;
            string cedulaNovedad = "";
            try
            {
                //Pregunta si ya se encuentra un id y un causal seleccionado
                if (txtIdNovedad.Text != "" && ddlSinAplicar.SelectedValue.ToString() != "")
                {
                    //se pasa la novedad de retiro del mismo tercero a sin aplicar
                    int localidad = (Session["localidad"].ToString() == "") ? 0 : int.Parse(Session["localidad"].ToString());
                    //Lista las novedades pendientes segun los parametros enviados
                    DataTable dt = AdministrarNovedades.ConsultarNovedadesArchivoEnviada(localidad, 0, 0, 1, 1);
                    //Recorre el dt con las novedades pendientes 
                    foreach (DataRow row in dt.Rows)
                    {
                        //entra solo si el id que se esta recorriendo es igual al cargado en el txt
                        if (row["Id"].ToString() == txtIdNovedad.Text)
                        {
                            //asigna en una variable la cedula 
                            cedulaNovedad = row["Documento"].ToString();
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        /*Pregunta si el documento que se esta recorriendo es igual a la cedula del registro pendiente por
                            por enviar a sin aplicar y si el tipo de novedad es retiro */
                        if (row["Documento"].ToString() == cedulaNovedad && row["Tipo Novedad"].ToString() == "RETIRO")
                        {
                            //Se ammarra este retiro y se envia a sin aplicar al igual que el anterior
                            AdministrarNovedades.ActualizarDePendienteASinAplicar(int.Parse(row["Id"].ToString()), 0, ddlSinAplicar.SelectedValue.ToString());
                        }
                    }

                    //Se envia novedad a sin aplicar
                    AdministrarNovedades.ActualizarDePendienteASinAplicar(int.Parse(txtIdNovedad.Text), 0, ddlSinAplicar.SelectedValue.ToString());

                    //Se consulta la novedad enviada a sin aplicar
                    dtNovedad = AdministrarNovedades.ConsultarNovedadPorTercero("0", "0", "0", txtIdNovedad.Text);
                    if (dtNovedad.Rows.Count != 0)
                    {
                        //Se asigna a variable el valor de la novedad
                        valor = double.Parse(dtNovedad.Rows[0]["nov_Valor"].ToString());
                        //Consulta certificados por los cuales posiblemente se genero la novedad enviada a sin aplicar
                        dtCertificados = AdministrarNovedades.ConsultarCertificadoPorPagaduriaArchivo(dtNovedad.Rows[0]["ter_Id"].ToString(), dtNovedad.Rows[0]["arcpag_Id"].ToString(), txtIdNovedad.Text);
                        //Se consulta la novedad enviada a sin aplicar
                        dtNovedades = AdministrarNovedades.ConsultarNovedadPorTercero(dtNovedad.Rows[0]["ter_Id"].ToString(), dtNovedad.Rows[0]["arcpag_Id"].ToString(), "2", "0");
                        if (dtNovedades.Rows.Count != 0)
                        {
                            valor -= double.Parse(dtNovedades.Rows[0]["nov_Valor"].ToString());
                        }

                        int i = 0;
                        //Envia los certificados consultados a no aplicar hasta que el valor se reduzca a 0
                        while (valor > 0 && i < dtCertificados.Rows.Count)
                        {
                            valor -= double.Parse(dtCertificados.Rows[i]["cer_PrimaTotal"].ToString());
                            objAdministrarCertificados.ActualizarEstadoNegocioDevolucion("NO APLICO", int.Parse(dtCertificados.Rows[i]["cer_Id"].ToString()));
                            i++;
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Novedades pendiente enviada a sin aplicar" + "');", true);
                    ddlAnio_SelectedIndexChanged(sender, e);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "HA OCURRIDO UN ERROR AL TRATA DE ENVIAR LA NOVEDAD A SIN APLICAR" + "');", true);
            }
        }
    #endregion

        #region Tab mes
        protected void chkEnviarNovedad_CheckedChanged(object sender, System.EventArgs e)
        {
            // Checkea si el checkbox enviar novedad ya fue seleccionado para activar el boton
            if (chkEnviarNovedad.Checked == true)
            {
                btnEnviarNovedades.Enabled = true;
            }
            else
            {
                btnEnviarNovedades.Enabled = false;
            }
        }

        // Sirve para enviar las novedades
        protected void btnEnviarNovedad_Click(object sender, System.EventArgs e)
        {
            // Pregunta si el dt que carga las noveades por archivo ya se encuentra lleno
            if (_dtNovedadArchivo.Rows.Count > 0)
            {
                //Pregunta si ya selecciono enviar novedades definitivas
                if (chkEnviarNovedad.Checked == true)
                {
                    //Recorre cada final y actualiza su estado a 1 para posteriormente dejarlas en pendientes por aplicar 
                    foreach (DataRow row in _dtNovedadArchivo.Rows)
                    {
                        row["Enviada"] = 1;
                    }

                    //Actualiza novedades
                    AdministrarNovedades.ActualizarNovedadAEnviar(_dtNovedadArchivo);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Novedades enviadas correctamente" + "');", true);
                    ddlAnio_SelectedIndexChanged(sender, e);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "Asegurese de seleccionar la opcion de enviar novedades definitivas" + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "No hay información para enviar o imprimir, verifique haber seleccionado el archivo" + "');", true);
            }
        }
    #endregion

        #region Exportar a excel
        // Sirve para imprimir pendientes por aplicar
        protected void btnExportarPendientes_Click(object sender, System.EventArgs e)
        {
            DataTable dtNovedadPendienteAplicar = (DataTable)Session["dtNovedadPendienteAplicar"];
            if (dtNovedadPendienteAplicar.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtNovedadPendienteAplicar, "Novedades Pendientes");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE PENDIENTES" + "');", true);
            }
        }

        // Sirve para exportar excel las novedades de mes
        protected void btnExportarMes_Click(object sender, System.EventArgs e)
        {
            DataTable dtNovedadMes = (DataTable)Session["dtNovedadMes"];
            if (dtNovedadMes.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtNovedadMes, "Novedad Mes");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No  hay información de novedades en la planilla" + "');", true);
            }
        }

        // Sirve para exportar excel las novedades aplicadas
        protected void btnExportarAplicadas_Click(object sender, System.EventArgs e)
        {
            DataTable dtNovedadAplicada = (DataTable)Session["dtNovedadAplicada"];

            if (dtNovedadAplicada.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtNovedadAplicada, "Novedades Aplicadas");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE APLICADAS" + "');", true);
            }
        }

        // Sirve para exportar excel el historico de novedades
        protected void btnExportarHistorico_Click(object sender, System.EventArgs e)
        {
            DataTable dtNovedadHistorico = (DataTable)Session["dtNovedadHistorico"];

            if (dtNovedadHistorico.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtNovedadHistorico, "Historico de novedades");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "NO HAY INFORMACIÓN EN LA PLANILLA DE APLICADAS" + "');", true);
            }
        }

        // Sirve para exportar excel las novedades sin aplicar
        protected void btnExportarSinAplicar_Click(object sender, System.EventArgs e)
        {
            DataTable dtNovedadSinAplicar = (DataTable)Session["dtNovedadSinAplicar"];
            if (dtNovedadSinAplicar.Rows.Count > 0)
            {
                Funciones.generarExcel(Page, dtNovedadSinAplicar, "Novedades no Aplicadas");
            }
        }
    #endregion
    #endregion
}