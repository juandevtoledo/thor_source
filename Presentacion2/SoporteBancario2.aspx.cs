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

public partial class Presentacion2_SoporteBancario2 : System.Web.UI.Page
{
    // Llama la funcion que permite cargar los permisos del usuario que inicia la sesion
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());
        

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];

        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);

        //Ocultar campos de tablas 
        if (grvListSop.Rows.Count == 0)
        {

        }
        else
        {
            grvListSop.HeaderRow.Cells[1].Visible = false;
            int cont = 0;
            foreach (GridViewRow rows in grvListSop.Rows)
            {
                grvListSop.Rows[cont].Cells[1].Visible = false;
                cont++;
            }
        }
       
    }

    // Se cargan los datos que llenan los ddl
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {            
            //Controles
            tablaSoporte.Visible= false;
            distribucion.Visible = false;
            txtIdentificacion.Enabled = false;
            ddlLocalidadUno.Enabled = false;
            ddlPagaduriaUno.Enabled = false;
            formEditarSoporte.Visible = false;
            formEditarEncabezado.Visible = false;  

            ListarSoportes();
            CargarListas();
        }       
    }

    // Se listan los soportes bancarios que se han guardado en la base de datos 
    protected void ListarSoportes()
    {
        string usuario = Session["Usuario"].ToString();
        DataTable dtListarSop = new DataTable();
        dtListarSop = new DataTable();
        dtListarSop = AdministrarSoportesBancarios.ListarSoportes(usuario);

        grvListSop.DataSource = dtListarSop;
        grvListSop.DataBind();
    }

    #region Cargar listas

    protected void CargarListas()
    {
        int cargo = int.Parse(Session["car_Id"].ToString());

        // Listar tipos de documento
        DataTable dtTipDocumeto = AdministrarSoportesBancarios.ListarTipoDocumento(cargo);
        ddlTipoDoc.DataSource = dtTipDocumeto;
        ddlTipoDoc.DataTextField = "tipDoc_Nombre";
        ddlTipoDoc.DataValueField = "tipDoc_Id";
        ddlTipoDoc.DataBind();
        ddlTipoDoc.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar tipos de documento para editar
        DataTable dtTipDocumetoEdit = AdministrarSoportesBancarios.ListarTipoDocumento(cargo);
        ddlTipoDocEdit.DataSource = dtTipDocumetoEdit;
        ddlTipoDocEdit.DataTextField = "tipDoc_Nombre";
        ddlTipoDocEdit.DataValueField = "tipDoc_Id";
        ddlTipoDocEdit.DataBind();
        ddlTipoDocEdit.Items.Insert(0, new ListItem("Seleccione", ""));
        

        // Listar forma de pago
        DataTable dtFormaPago = AdministrarSoportesBancarios.ListarFormaPago(cargo);
        ddlFormaDePago.DataSource = dtFormaPago;
        ddlFormaDePago.DataTextField = "forpag_Nombre";
        ddlFormaDePago.DataValueField = "forpag_Id";
        ddlFormaDePago.DataBind();
        ddlFormaDePago.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar localidades uno a uno 
        DataTable dtLocalidadesUno = AdministrarSoportesBancarios.ListarLocalidades();
        ddlLocalidadUno.DataSource = dtLocalidadesUno;
        ddlLocalidadUno.DataTextField = "dep_Nombre";
        ddlLocalidadUno.DataValueField = "dep_Id";
        ddlLocalidadUno.DataBind();
        ddlLocalidadUno.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar localidades distribucion
        DataTable dtLocalidades = AdministrarSoportesBancarios.ListarLocalidades();
        ddlLocalidad.DataSource = dtLocalidades;
        ddlLocalidad.DataTextField = "dep_Nombre";
        ddlLocalidad.DataValueField = "dep_Id";
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));

       // Lista compañias para filtar los bancos en el formulario de modificar encabezado
        DataTable dtCompania = new DataTable();
        dtCompania = AdministrarSoportesBancarios.ConsultarCompanias();
        ddlCompaniaEdit.DataTextField = "com_Nombre";
        ddlCompaniaEdit.DataValueField = "com_Id";
        ddlCompaniaEdit.DataSource = dtCompania;
        ddlCompaniaEdit.DataBind();
        ddlCompaniaEdit.Items.Insert(0, new ListItem("Seleccione", "0"));

        // Lista bancos para filtar los bancos en el formulario de modificar encabezado
        DataTable dtBancos = new DataTable();
        dtBancos = AdministrarSoportesBancarios.ListarBancos();
        ddlBancoInforme.DataTextField = "NOMBRE";
        ddlBancoInforme.DataValueField = "ID";
        ddlBancoInforme.DataSource = dtBancos;
        ddlBancoInforme.DataBind();
        ddlBancoInforme.Items.Insert(0, new ListItem("Seleccione banco", ""));

        // Listar tipos de soporte para informe
        DataTable dtRecibidoPorInforme = AdministrarSoportesBancarios.ListarTipoSoporteBancario(cargo);
        ddlRecibidoInforme.DataSource = dtRecibidoPorInforme;
        ddlRecibidoInforme.DataTextField = "TipSopNombre";
        ddlRecibidoInforme.DataValueField = "tipSopId";
        ddlRecibidoInforme.DataBind();
        ddlRecibidoInforme.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar Estados
        DataTable dtEstados = AdministrarSoportesBancarios.ListarEstados();
        ddlEstado.DataSource = dtEstados;
        ddlEstado.DataTextField = "est_nombre";
        ddlEstado.DataValueField = "est_Id";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione", ""));

        // Listar tipo docuemnto para el informe 
        DataTable dtTipoDocumento = AdministrarSoportesBancarios.ListarTipoDocumento(cargo);
        ddlTipoDocumentoInforme.DataSource = dtTipoDocumento;
        ddlTipoDocumentoInforme.DataTextField = "tipDoc_Nombre";
        ddlTipoDocumentoInforme.DataValueField = "tipDoc_Id";
        ddlTipoDocumentoInforme.DataBind();
        ddlTipoDocumentoInforme.Items.Insert(0, new ListItem("Seleccione", ""));  
    }
    #endregion

    #region Cargar archivo excel, modificacion, eliminacion, aprobación, aplicación y rechazo de soportes bancarios

    // Cargar datos del archivo
    protected void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (fupSoportes.HasFile)
        {
            DataTable dtSoportes = LeerExcel();
            foreach (DataRow row in dtSoportes.Rows)
            {
                string identificacion = row["Identificacion"].ToString();
                string tipoDocumento  = row["TipoDocumento"].ToString();

                if (identificacion != "" && (tipoDocumento != "7" || tipoDocumento != "8"))
                {
                    AdministrarSoportesBancarios.InsertarSoporteBancario(row["InformacionBanco"].ToString(), row["FormaPago"].ToString(), DateTime.Parse(row["FechaMovimiento"].ToString()), row["TipoDocumento"].ToString(), long.Parse(row["Identificacion"].ToString()), double.Parse(row["Valor"].ToString()), row["Referencia"].ToString(), row["Localidad"].ToString(), txtNomSoporte.Text);
                }
                else if (identificacion == "" && (tipoDocumento == "7" || tipoDocumento == "8"))
                {
                    identificacion = "0";
                    AdministrarSoportesBancarios.InsertarSoporteBancario(row["InformacionBanco"].ToString(), row["FormaPago"].ToString(), DateTime.Parse(row["FechaMovimiento"].ToString()), row["TipoDocumento"].ToString(), long.Parse(identificacion), double.Parse(row["Valor"].ToString()), row["Referencia"].ToString(), row["Localidad"].ToString(), txtNomSoporte.Text);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Archivo cargado." + "');window.location.replace('/gestion/recaudoypago/soportebancario')", true);
                    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Archivo cargado.');", true);
                    CargarListas();
                }
            }

            int soportes = AdministrarSoportesBancarios.ConsutarTempSoporteBancario();
            if (soportes == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Los soportes que intenta cargar ya existen por favor validar.');", true);
                CargarListas();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Archivo cargado.');", true);
                CargarListas();
                ListarSoportes();
            }
        }
    }

    // Método lee el archivo excel
    protected DataTable LeerExcel()
    {
        DataTable dtExcel = new DataTable();
        if (fupSoportes.HasFile)
        {
            string ruta = string.Concat((Server.MapPath("~/temp/" + fupSoportes.FileName)));
            fupSoportes.PostedFile.SaveAs(ruta);
            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string conexion;
            //conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=Excel 8.0;";
            conexion = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;";
            OleDbConnection OleDbcon = new OleDbConnection(conexion);
            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("Select * from [Hoja1$]", OleDbcon);

            OleDbcon.Open();
            DbDataReader dr = consulta.ExecuteReader();
            dtExcel.Load(dr);

            OleDbcon.Close();
            Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
        }
        else
        {
            lbl1.ForeColor = Color.Red;
            lbl1.Text = "Por favor seleccione un archivo";
        }
        return dtExcel;
    }

    // Paginación
    protected void grvListSop_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvListSop.PageIndex = e.NewPageIndex;
        ListarSoportes();
    }

    // Paginación
    protected void grvListSop_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvListSop.Rows.Count < grvListSop.PageSize) && (grvListSop.Rows.Count + grvListSop.PageSize * grvListSop.PageIndex < ((DataTable)(grvListSop.DataSource)).Rows.Count))
        {
            e.Row.Cells[3].Visible = true;
        }       
    }

    

    // Tabla lista soportes, oculta o muestra los botones
    protected void grvListSop_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());

        GridViewRow row = grvListSop.Rows[(index)];

        if (e.CommandName == "Consultar_Click")
        {
            int encSop_Id = int.Parse(row.Cells[1].Text);
            Session["encSop_Id"] = encSop_Id;
            lblTituloBanco.Text = "Banco: " + row.Cells[2].Text;
            lblTituloCuenta.Text = "Cuenta: " + row.Cells[3].Text;
            lblTituloTipoCuenta.Text = "Tipo cuenta: " + row.Cells[4].Text;
            lblFechaCongnacion.Text = "Fecha Movimiento: " + row.Cells[5].Text;
            lblValorToral.Text = "Valor total: " + row.Cells[6].Text;
            string recibido = HttpUtility.HtmlDecode(row.Cells[8].Text);
            Session["recibido"] = recibido;
            DataTable dt = new DataTable();
            dt = AdministrarSoportesBancarios.ConsultarDetalleSoportes(encSop_Id);

            // Variable para validar si es nit no puede aplicar
            string tipDoc = dt.Rows[0]["Tipo Documento"].ToString();
            long cedula = long.Parse(dt.Rows[0]["Identificación"].ToString());
           
            Session["identificacion"] = cedula;
            
            grvConsutarSop.DataSource = dt;
            grvConsutarSop.DataBind();
            lblValorToral.Text = "Valor Total: " + row.Cells[6].Text;

            //ocultar campos de tabla 
            grvConsutarSop.HeaderRow.Cells[1].Visible = false;
            grvConsutarSop.HeaderRow.Cells[2].Visible = false;
            int cont = 0;
            foreach (DataRow rows in dt.Rows)
            {
                grvConsutarSop.Rows[cont].Cells[1].Visible = false;
                grvConsutarSop.Rows[cont].Cells[2].Visible = false;
                cont++;
            }

            // Controles
            buscador.Visible=false;
            tablaSoporte.Visible = true;
            tablaEncabezado.Visible = false;
            formMotivo.Visible = false;
            titleAcciones.Visible = false;
        }

        if (e.CommandName == "Modificar_Click")
        {
            string encSop_Id = row.Cells[1].Text;
            txtEncSop_Id.Text = encSop_Id;
            DataTable dt = new DataTable();

            lblTituloBancoEdit.Text = "Banco: " + row.Cells[2].Text;
            lblTituloCuentaEdit.Text = "Cuenta: " + row.Cells[3].Text;
            lblTituloTipoCuentaEdit.Text = "Tipo Cuenta: " + row.Cells[4].Text;

            formEditarEncabezado.Visible = true;
            acciones.Visible = false;
        }

        if (e.CommandName == "Eliminar_Click")
        {

            string directo = row.Cells[8].Text;
            string estado = row.Cells[7].Text;

            if (directo == "Compania")
            {
                if (estado != "APLICADO" && estado != "DISTRIBUCION")
                {
                    int encSop_Id = int.Parse(row.Cells[1].Text);
                    int registros = AdministrarSoportesBancarios.EliminarSoporteBancario(encSop_Id);
                    if(registros > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte se ha eliminado con éxito');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte no se eliminó. por favor validar.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte no puede ser eliminado cuando esta en estado distribución o aplicado.');", true);
                }
                ListarSoportes();
            }
            else
            {
                if (estado != "APLICADO" && estado != "DISTRIBUCION" && estado != "APROBADO")
                {
                    int encSop_Id = int.Parse(row.Cells[1].Text);
                    int registros = AdministrarSoportesBancarios.EliminarSoporteBancario(encSop_Id);
                    if (registros > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte se ha eliminado con éxito');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte no se eliminó. por favor validar.');", true);
                    }
                    ListarSoportes();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte no puede ser eliminado cuando esta en estado aprobado, distribución o aplicado.');", true);
                } 
            }
            
        }
    }

    // Evento para devolver al formulario anterior
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        tablaSoporte.Visible = false;
        tablaEncabezado.Visible = true;
        titleAcciones.Visible = true;
        Response.RedirectToRoute("soporteBancario");
    }

    // Evento para la aprobación de soportes
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        int encSop_Id = int.Parse(Session["encSop_Id"].ToString());
        int registros = AdministrarSoportesBancarios.AprobarSoporteBancario(encSop_Id);
        if(registros > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El soporte se aprobó con éxito');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No se aprobo el soporte');", true);
        }
        ConsultarDetalleSoportes();
    }

    // Evento para rechazar los soportes
    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        string identificacion = Session["identificacion"].ToString();
        formMotivo.Visible = true;
        divBtns.Visible = false;
    }

    // Guardar la observacion al momento de rechazar un soporte bancario
    protected void btnGuardarMotivo_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rows in grvConsutarSop.Rows)
        {
            string recibido = Session["recibido"].ToString();
            int encSop_Id = int.Parse(rows.Cells[1].Text);
            long identificacion = long.Parse(rows.Cells[4].Text);

            if (recibido != "Compañia")
            {
                if (textAreaMotivo.Text != "")
                {
                    int registros = AdministrarSoportesBancarios.RechazarSoporteBancario(encSop_Id, textAreaMotivo.Text, identificacion);
                    if(registros > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Motivo de rechazo guardado.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No puede ser rechazado porque esta en proceso de aplicación de pagos.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Faltan campos por llenar.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Los soportes directos a companía no pueden ser rechazados.');", true);
            }
            ConsultarDetalleSoportes();
        }
        
        
    }

    // Evento para la aplicacion automatica de pagos 
    protected void btnAplicarPagos_Click(object sender, EventArgs e)
    {
        string usuario =  Session["Usuario"].ToString();
        //long ter_Id = 0;
        
        foreach (GridViewRow rows in grvConsutarSop.Rows)
        {
           long sop_Identificacion = long.Parse(rows.Cells[4].Text);
           if (sop_Identificacion > 0)
           {

            string estAplicado = rows.Cells[11].Text;
            if (estAplicado != "APLICADO" && estAplicado != "RECHAZADO" && estAplicado != "PENDIENTE") 
            {
                //if (sop_Identificacion != ter_Id)
                //{
                    int registros = AdministrarSoportesBancarios.AplicarPagosSoporteBancario(int.Parse(rows.Cells[1].Text),int.Parse(rows.Cells[2].Text), sop_Identificacion, usuario);
                    //ter_Id = sop_Identificacion;
                    if (registros > 0)
                    {
                        AdministrarSoportesBancarios.CambiarEstadoSoporteBancario(int.Parse(rows.Cells[1].Text), int.Parse(rows.Cells[2].Text), sop_Identificacion);

                        // Consultar convenio y si tiene mas de un convenio 
                        DataTable dt = new DataTable();
                        dt = AdministrarSoportesBancarios.ConsultarCovenioCedula(sop_Identificacion);

                        if(dt.Rows.Count > 0)
                        {
                            int con_Id = int.Parse(dt.Rows[0]["con_Id"].ToString());
                            int pro_Id = int.Parse(dt.Rows[0]["pro_Id"].ToString());
                            // Llamada funcion aplicacion novedades
                            ActualizarNovedadesAplicadas(sop_Identificacion, con_Id, pro_Id);
                        }
                        
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ha terminado el proceso de aplicación de pagos');", true);
                    }
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El número de identificación no es un dato válido');", true);
                //}
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El soporte no pudo ser aplicado');", true);
            }
        }
        ConsultarDetalleSoportes();
        }
        //Response.RedirectToRoute("soporteBancario"); 
    }

    private void ActualizarNovedadesAplicadas(long sop_Identificacion, int con_Id, int pro_Id)
    {
        Pagos objPago = new Pagos();
        DataTable dtActualizarNovedadesAplicadas = new DataTable();
        dtActualizarNovedadesAplicadas = objPago.ActualizarNovedadesAplicadas(sop_Identificacion, con_Id, pro_Id);
    }

    //Consulta los soportes banarios de un encabezado
    protected void ConsultarDetalleSoportes()
    {

        int encSop_Id = int.Parse(Session["encSop_Id"].ToString());
        DataTable dt = new DataTable();
        dt = AdministrarSoportesBancarios.ConsultarDetalleSoportes(encSop_Id);
        grvConsutarSop.DataSource = dt;
        grvConsutarSop.DataBind();

        //ocultar campos de tabla 
        grvConsutarSop.HeaderRow.Cells[1].Visible = false;
        grvConsutarSop.HeaderRow.Cells[2].Visible = false;
        int cont = 0;
        foreach (DataRow rows in dt.Rows)
        {
            grvConsutarSop.Rows[cont].Cells[1].Visible = false;
            grvConsutarSop.Rows[cont].Cells[2].Visible = false;
            cont++;
        }

    }

    protected void grvConsutarSop_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());

        GridViewRow row = grvConsutarSop.Rows[(index)];

        if (e.CommandName == "Modificar_Click")
        {
            string sop_Id = row.Cells[2].Text;

            DataTable dt = new DataTable();
            dt = AdministrarSoportesBancarios.ConsultarSoporteBancarioEditar(sop_Id);
            txtSop_Id.Text = sop_Id;
            txtIdentificacionEdit.Text = dt.Rows[0]["identificacion"].ToString();
            txtReferenciaEdit.Text = dt.Rows[0]["referencia"].ToString();
            txtTalonEdit.Text = dt.Rows[0]["talon"].ToString();
            txtValorEdit.Text = dt.Rows[0]["valor"].ToString();
            //txtValorNumEdit.Text = dt.Rows[0]["valorNum"].ToString();

            int estadoSop = int.Parse(dt.Rows[0]["estado"].ToString());
            int  recibido = int.Parse(dt.Rows[0]["recibido"].ToString());

            if (recibido == 1 && (estadoSop == 2 || estadoSop == 4 || estadoSop == 7))
            {
                txtValorEdit.Enabled = true;
            }
            else if(recibido == 2 && (estadoSop == 2 || estadoSop == 4 || estadoSop == 7) )
            {
                txtValorEdit.Enabled = false;
            }

            if (estadoSop == 4 || estadoSop == 7)
            {
                txtIdentificacionEdit.Enabled = false;
                txtValorEdit.Enabled = false;
            }
            else
            {
                txtIdentificacionEdit.Enabled = true;
            }
            
            formEditarSoporte.Visible = true;
            tablaSoporte.Visible = false;
        }
    }

    // Modificar encabezado  de soportes 
    protected void btnModificarEnc_Click(object sender, EventArgs e)
    {
        if (ddlBancoEdit.Text != "" & ddlTipoCuentaEdit.Text != "" & ddlCuentaEdit.Text != "")
        {
            int registros = AdministrarSoportesBancarios.ModificarEncabezadoSoporteBancario(int.Parse(ddlBancoEdit.SelectedValue.ToString()), int.Parse(ddlTipoCuentaEdit.SelectedValue.ToString()), int.Parse(ddlCuentaEdit.SelectedValue.ToString()), int.Parse(txtEncSop_Id.Text));
            
            if(registros > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Se ha modificado con éxito');", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Faltan campos por llenar');", true);
        }
        
    }

    //Modificar soportes bancarios
    protected void btnModificarSop_Click(object sender, EventArgs e)
    {
        int talon = 0;
        int tipDoc = 0;

        if (ddlTipoDocEdit.Text != "")
        {
            tipDoc = int.Parse(ddlTipoDocEdit.Text);
        }
        if (txtTalonEdit.Text != "")
        {
            talon = int.Parse(txtTalonEdit.Text);
        }

        if (txtValorEdit.Text != "")
        {
            int registros = AdministrarSoportesBancarios.ModificarSoporteBancario(tipDoc, txtIdentificacionEdit.Text, txtReferenciaEdit.Text, talon, txtValorEdit.Text, int.Parse(txtSop_Id.Text));

            if (registros > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "alert", "localStorage.setItem('tab', '#tab-2'); alert('" + "Se modificó el soporte exitosamente" + "');window.location.replace('/gestion/recaudoypago/soportebancario')", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Se modificó el soporte exitosamente');", true);
                formEditarSoporte.Visible = false;
                tablaSoporte.Visible = true;
            }
            ConsultarDetalleSoportes();
        }

        
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Faltan campos por llenar');", true);
        }
    }
    #endregion

    #region Formulario uno a uno 
    // ============== INGRESAR UNO A UNO ============

    // Inhabilita los campos de identificacion o pagaduria dependiendo el tipo documento
    protected void ddlTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoDoc.SelectedValue != "")
        {
            int tipoDoc = int.Parse(ddlTipoDoc.SelectedValue);
            if (tipoDoc == 1)
            {
                txtIdentificacion.Enabled = true;
                ddlLocalidadUno.Enabled = false;
                ddlPagaduriaUno.Enabled = false;
            }
            if (tipoDoc == 4)
            {
                txtIdentificacion.Enabled = false;
                ddlLocalidadUno.Enabled = true;
                ddlPagaduriaUno.Enabled = true;
            }
            if (tipoDoc == 7)
            {
                txtIdentificacion.Enabled = true;
                ddlLocalidadUno.Enabled = false;
                ddlPagaduriaUno.Enabled = false;
            }
        }
        else
        {
            txtIdentificacion.Enabled = false;
            ddlLocalidadUno.Enabled = false;
            ddlPagaduriaUno.Enabled = false;
        }
    }

    // Inhabilita algunos campos depediendola forma de pago
    protected void ddlFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["formaPago"] = ddlFormaDePago.SelectedValue;
        int formaPago_Id = int.Parse(Session["formaPago"].ToString());

        if (formaPago_Id == 5)
        {
            txtNoCheque.Enabled = false;
        }

        // Listar tipos de soporte bancario 1. compañia, 2. Torres guarin 
        DataTable dtRecibidoPor = AdministrarSoportesBancarios.ListarTipoSoporteBancario(formaPago_Id);
        ddlRecibido.DataSource = dtRecibidoPor;
        ddlRecibido.DataTextField = "TipSopNombre";
        ddlRecibido.DataValueField = "tipSopId";
        ddlRecibido.DataBind();
        ddlRecibido.Items.Insert(0, new ListItem("Seleccione", ""));

        
    }

    // Se filtran las compañias dependiendo quien recibio el dinero
    protected void ddlRecibido_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCompania.Items.Clear();
        int recibido = int.Parse(ddlRecibido.SelectedValue);

        if (recibido == 2)
        {
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", "")); 
            ddlCompania.Items.Insert(1, new ListItem("TORRES GUARIN", "5"));
        }
        else
        {
            DataTable dtCompania = new DataTable();
            dtCompania = AdministrarSoportesBancarios.ConsultarCompanias();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dtCompania;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", "0")); 
        }
    }

    // Se filtran los numeros de cuenta dependiendo el banco selecionado 
    protected void ddlBanco_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["banId"] = ddlBanco.SelectedValue.ToString();
        Session["bancoEdit"] = ddlBancoEdit.SelectedValue.ToString();

        int intBanco = (Session["banId"].ToString() == "") ? 0 : int.Parse(Session["banId"].ToString());
        int intCompania = (Session["companiaId"].ToString() == "") ? 0 : int.Parse(Session["companiaId"].ToString());

        DataTable dtCuentas = new DataTable();
        dtCuentas = CuentasBancarias.ConsultarCuentasPorBancoCompania(intBanco, intCompania, 0);

        ddlNoCuenta.DataTextField = "cuenta_bancaria";
        ddlNoCuenta.DataValueField = "cueBan_Id";
        ddlNoCuenta.DataSource = dtCuentas;
        ddlNoCuenta.DataBind();
        ddlNoCuenta.Items.Insert(0, new ListItem("Seleccione cuenta bancaria", "0"));

        int bancoEdit = (Session["bancoEdit"].ToString() == "") ? 0 : int.Parse(Session["bancoEdit"].ToString());
        int compañiaEdit = (Session["companiaEdit"].ToString() == "") ? 0 : int.Parse(Session["companiaEdit"].ToString());

        DataTable dtTipoCuentasEdit = new DataTable();
        dtTipoCuentasEdit = CuentasBancarias.consultarTipoCuentaParaEditar(bancoEdit, compañiaEdit, 0);

        ddlTipoCuentaEdit.DataTextField = "tipCue_Nombre";
        ddlTipoCuentaEdit.DataValueField = "tipCue_Id";
        ddlTipoCuentaEdit.DataSource = dtTipoCuentasEdit;
        ddlTipoCuentaEdit.DataBind();
        ddlTipoCuentaEdit.Items.Insert(0, new ListItem("Seleccione un tipo de cuenta", "0"));
    }

    // se filtra tipo de cuentas dependiendo del banco y la compañia seleccionada
    protected void ddlTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["bancoEdit"] = ddlBancoEdit.SelectedValue.ToString();
        Session["tipoCuentaEdit"] = ddlTipoCuentaEdit.SelectedValue.ToString();

        int bancoEdit = (Session["bancoEdit"].ToString() == "") ? 0 : int.Parse(Session["bancoEdit"].ToString());
        int compañiaEdit = (Session["companiaEdit"].ToString() == "") ? 0 : int.Parse(Session["companiaEdit"].ToString());
        int tipoCuentaEdit = (Session["tipoCuentaEdit"].ToString() == "") ? 0 : int.Parse(Session["tipoCuentaEdit"].ToString());

        DataTable dtCuentasEdit = new DataTable();
        dtCuentasEdit = CuentasBancarias.consultarCuentasParaEditar(bancoEdit, compañiaEdit, 0, tipoCuentaEdit);

        ddlCuentaEdit.DataTextField = "cueBan_Numero";
        ddlCuentaEdit.DataValueField = "cueBan_Id";
        ddlCuentaEdit.DataSource = dtCuentasEdit;
        ddlCuentaEdit.DataBind();
        ddlCuentaEdit.Items.Insert(0, new ListItem("Seleccione una cuenta", "0"));
    }

  // Guarda el soporte bancario creado por el formulario uno a uno 
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string usuario = Session["Usuario"].ToString();
        int identificador = 0;
        int pagaduria = 0;
        string NoCheque = "No tiene";
        int talon = 0;
        string sucursal= "No tiene";
     
        if (ddlPagaduriaUno.Text != "")
        {
            pagaduria = int.Parse(ddlPagaduriaUno.Text);
        }

        if (txtNoTalon.Text != "")
        {
            talon = int.Parse(txtNoTalon.Text);
        }

        if (txtIdentificacion.Text != "")
        {
            identificador = int.Parse(txtIdentificacion.Text);
        }

        if (txtNoCheque.Text != "")
        {
            NoCheque = txtNoCheque.Text;
        }

        if (txtSucursal.Text != "")
        {
            sucursal = txtSucursal.Text;
        }

        if (ddlFormaDePago.Text != "" & ddlRecibido.Text != "" & ddlCompania.Text != "" & ddlBanco.Text != "" & ddlNoCuenta.Text != "" & txtFecha.Text != "" & txtValor.Text != "")
        {
            DataTable dtTipoCuenta = new DataTable();
            dtTipoCuenta = CuentasBancarias.ConsultarTipoCuentaBancaria(int.Parse(ddlNoCuenta.SelectedValue.ToString()));
            int tipoCuenta = int.Parse(dtTipoCuenta.Rows[0]["tipCue_Id"].ToString());

            int registros = AdministrarSoportesBancarios.InsertarSoporteBancarioUno(int.Parse(ddlTipoDoc.SelectedValue.ToString()), identificador, pagaduria, int.Parse(ddlFormaDePago.SelectedValue.ToString()),
            NoCheque, int.Parse(ddlRecibido.SelectedValue.ToString()), int.Parse(ddlCompania.SelectedValue.ToString()), int.Parse(ddlBanco.SelectedValue.ToString()), tipoCuenta,
            int.Parse(ddlNoCuenta.SelectedValue.ToString()), DateTime.Parse(txtFecha.Text), talon, int.Parse(txtValor.Text), sucursal, usuario);

            if (registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Soporte Guardado." + "');window.location.replace('/gestion/recaudoypago/soportebancario')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "El soporte no fue guardado." + "'))", true);
            } 
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cargo = int.Parse(Session["car_Id"].ToString());
        int formaPago = int.Parse(Session["formaPago"].ToString());
        Session["companiaId"] = ddlCompania.SelectedValue.ToString();
        Session["companiaEdit"] = ddlCompaniaEdit.SelectedValue.ToString();

        int intCompania = (Session["companiaId"].ToString() == "") ? 0 : int.Parse(Session["companiaId"].ToString());

        int tipoBanco = 1;
        if (intCompania == 5)
        {
            tipoBanco = 0;
        }
        DataTable dtBancos = new DataTable();
        dtBancos = AdministrarSoportesBancarios.ConsultarBancosSoporteBancario(intCompania, tipoBanco, formaPago);

        ddlBanco.DataTextField = "ban_Nombre";
        ddlBanco.DataValueField = "ban_Id";
        ddlBanco.DataSource = dtBancos;
        ddlBanco.DataBind();
        ddlBanco.Items.Insert(0, new ListItem("Seleccione banco", ""));

        int companiaEdit = (Session["companiaEdit"].ToString() == "") ? 0 : int.Parse(Session["companiaEdit"].ToString());

        DataTable dtBancosEdit = new DataTable();
        dtBancosEdit = CuentasBancarias.ConsultarBancosPorCompania(companiaEdit, 1);

        ddlBancoEdit.DataTextField = "ban_Nombre";
        ddlBancoEdit.DataValueField = "ban_Id";
        ddlBancoEdit.DataSource = dtBancosEdit;
        ddlBancoEdit.DataBind();
        ddlBancoEdit.Items.Insert(0, new ListItem("Seleccione banco", ""));
        
        if (intCompania != 1)
        {
            txtNoTalon.Enabled = false;
        }
        else
        {
            txtNoTalon.Enabled = true;
        }
    }

    protected void ddlCompaniaEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cargo = int.Parse(Session["car_Id"].ToString());
        Session["companiaId"] = ddlCompania.SelectedValue.ToString();
        Session["companiaEdit"] = ddlCompaniaEdit.SelectedValue.ToString();

        int intCompania = (Session["companiaId"].ToString() == "") ? 0 : int.Parse(Session["companiaId"].ToString());

        int tipoBanco = 1;
        if (intCompania == 5)
        {
            tipoBanco = 0;
        }
        DataTable dtBancos = new DataTable();
        dtBancos = AdministrarSoportesBancarios.ConsultarBancosSoporteBancarioEditar(intCompania, tipoBanco);

        ddlBanco.DataTextField = "ban_Nombre";
        ddlBanco.DataValueField = "ban_Id";
        ddlBanco.DataSource = dtBancos;
        ddlBanco.DataBind();
        ddlBanco.Items.Insert(0, new ListItem("Seleccione banco", ""));

        int companiaEdit = (Session["companiaEdit"].ToString() == "") ? 0 : int.Parse(Session["companiaEdit"].ToString());

        DataTable dtBancosEdit = new DataTable();
        dtBancosEdit = CuentasBancarias.ConsultarBancosPorCompania(companiaEdit, 1);

        ddlBancoEdit.DataTextField = "ban_Nombre";
        ddlBancoEdit.DataValueField = "ban_Id";
        ddlBancoEdit.DataSource = dtBancosEdit;
        ddlBancoEdit.DataBind();
        ddlBancoEdit.Items.Insert(0, new ListItem("Seleccione banco", ""));

        if (intCompania != 1)
        {
            txtNoTalon.Enabled = false;
        }
        else
        {
            txtNoTalon.Enabled = true;
        }
    }

    // Se filtran las pagadurias dependiendo de la localidad seleccionada
    protected void ddlPagaduriaUnoAUno_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtPagadurias = new DataTable();
        dtPagadurias = AdministrarSoportesBancarios.ConsultarPagadurias(int.Parse(ddlLocalidadUno.SelectedValue));
        ddlPagaduriaUno.DataTextField = "paga_Nombre";
        ddlPagaduriaUno.DataValueField = "paga_Id";
        ddlPagaduriaUno.DataSource = dtPagadurias;
        ddlPagaduriaUno.DataBind();
        ddlPagaduriaUno.Items.Insert(0, new ListItem("", ""));
    }

    #endregion

    #region Distribución de soportes

    // Filtra las pagadurias dependiendo de la localidad seleccionada 
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtPagadurias = new DataTable();
        dtPagadurias = AdministrarSoportesBancarios.ConsultarPagadurias(int.Parse(ddlLocalidad.SelectedValue));
        ddlPagaduria.DataTextField = "paga_Nombre";
        ddlPagaduria.DataValueField = "paga_Id";
        ddlPagaduria.DataSource = dtPagadurias;
        ddlPagaduria.DataBind();
        ddlPagaduria.Items.Insert(0, new ListItem("", ""));

        // Controles
        tblDistri.Visible = false;
        distribucion.Visible = false;
    }

    // Filtra los convenios depediendo la pagaduria seleccionada
    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        tblDistri.Visible = true;

        string ddlPagSel = ddlPagaduria.SelectedValue;
        Session["ddlPagSel"] = ddlPagSel;

        if (ddlPagSel != "")
        {
            DataTable dtConvenios = new DataTable();
            dtConvenios = AdministrarSoportesBancarios.ConsultarConvenios(int.Parse(ddlPagaduria.SelectedValue));
            ddlConvenios.DataTextField = "con_Nombre";
            ddlConvenios.DataValueField = "con_Id";
            ddlConvenios.DataSource = dtConvenios;
            ddlConvenios.DataBind();
            ddlConvenios.Items.Insert(0, new ListItem("Seleccione", ""));
            cargarSoportesAsignados(int.Parse(Session["ddlPagSel"].ToString()));
        }

    }

    // Consulta los soportes creados por pagaduria seleccionada
    private void cargarSoportesAsignados(int ddlPagSel)
    {
        DataTable dtSopPaga = new DataTable();
        dtSopPaga = AdministrarSoportesBancarios.ConsultarSoportesPagaduria(ddlPagSel);

        grvSopPaga.DataSource = dtSopPaga;
        grvSopPaga.DataBind();

        //Consulta los detalles por convenio de las distribuiones de esa pagaduria totalizando el valor por convenio y estado
        DataTable dtlistadetalle = new DataTable();
        dtlistadetalle = AdministrarSoportesBancarios.ListarDetalleTotal(ddlPagSel);

        grvlistaDetalle.DataSource = dtlistadetalle;
        grvlistaDetalle.DataBind();
    }

    // Permite seleccionar el soporte bancario que se va a distribuir 
    protected void grvSopPaga_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnDistribuir_Click")
        {
            Session["vlrDisponible"] = 0;
            int index = int.Parse(e.CommandArgument.ToString());

            GridViewRow row = grvSopPaga.Rows[(index)];

            lblNumeroSop.Text = "Número soporte: " + row.Cells[1].Text;
            txtSop.Text = row.Cells[1].Text;
            int valorDisponible = int.Parse(row.Cells[9].Text);

            Session["vlrDisponible"] = valorDisponible;
            distribucion.Visible = true;

            int sop_Id = int.Parse(row.Cells[1].Text);
            Session["sop_Id"] = sop_Id;
            CargarDetalleDistribucion();

            

            //Capturar sop_Id para consultar la distribucion del soporte seleccionado 
        }    
    }

    // Se lista el detalle de la distribucion realizada a los convenios de la pagaduria seleccionada
    protected void CargarDetalleDistribucion()
    {
        DataTable dtListarDistribucion = new DataTable();
        dtListarDistribucion = AdministrarSoportesBancarios.ConsultarDistribucionSoporte(int.Parse(Session["sop_Id"].ToString()));

        grvDetallesSop.DataSource = dtListarDistribucion;
        grvDetallesSop.DataBind();

        txtValorDistri.Text= "";
    }
    
    // Guarda el detalle de la distrucion en la base de datos
    protected void btnGuardarDetalle_Click(object sender, EventArgs e)
    {
        if (ddlConvenios.Text != "" & txtValorDistri.Text != "" & txtSop.Text != "")
        {
            int valorDisponible = int.Parse(Session["vlrDisponible"].ToString());
            
            if (valorDisponible >= int.Parse(txtValorDistri.Text))
            {
                if(int.Parse(txtValorDistri.Text) > 0)
                {
                    int registros = AdministrarSoportesBancarios.InsertarDetalleSoporte(ddlConvenios.Text, txtValorDistri.Text, txtSop.Text);

                    if (registros <= 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El soporte no puede ser distribuido si no esta aprobado.');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Detalle asignado.');", true);
                    }
                    if (Session["ddlPagSel"] != null)
                    {
                        cargarSoportesAsignados(int.Parse(Session["ddlPagSel"].ToString()));
                        CargarDetalleDistribucion();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El valor ingresado debe ser mayor que cero');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El valor ingresado supera el valor disponible.');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    // Lista el detalle de la distribucion por convenio
    protected void grvDetallesSop_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());

        GridViewRow row = grvDetallesSop.Rows[(index)];

        if (e.CommandName == "Eliminar_Click")
        {
            int detDistri = int.Parse(row.Cells[1].Text);
            int registros = AdministrarSoportesBancarios.EliminarDetalleDistribucion(detDistri);

            if(registros >= 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Distribución eliminado.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('La distribución no puede eliminarse porque ya se aplico.');", true);
            }
            if (Session["ddlPagSel"] != null)
            {
                cargarSoportesAsignados(int.Parse(Session["ddlPagSel"].ToString()));
                CargarDetalleDistribucion();
            }
            
        }
            
    }
    #endregion

    #region Informe gerneral de soporte bancario

    // Permite descargar el informe de soporte bancario en archivo excel
    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        int tipDoc = 0;
        int banco = 0;
        int recibido = 0;
        int estado = 0;

        DateTime fechaDesde = Convert.ToDateTime("01/01/1900");
        DateTime fechaHasta = Convert.ToDateTime("01/01/1900");

        if (txtFechaMovDesde.Text != "" && txtFechaMovHasta.Text != "")
        {
            if (ddlTipoDocumentoInforme.Text != "")
            {
                tipDoc = int.Parse(ddlTipoDocumentoInforme.Text);
            }

            if (ddlBancoInforme.Text != "")
            {
                banco = int.Parse(ddlBancoInforme.Text);
            }

            if (ddlRecibidoInforme.Text != "")
            {
                recibido = int.Parse(ddlRecibidoInforme.Text);
            }

            if (ddlEstado.Text != "")
            {
                estado = int.Parse(ddlEstado.Text);
            }

            if (txtFechaMovDesde.Text != "")
            {
                fechaDesde = DateTime.Parse(txtFechaMovDesde.Text);
            }

            if (txtFechaMovHasta.Text != "")
            {
                fechaHasta = DateTime.Parse(txtFechaMovHasta.Text);
            }

            DataTable dtInforme = AdministrarSoportesBancarios.ConsultarInformeSoporteBancario(tipDoc, banco, recibido, estado, fechaDesde, fechaHasta);
            Funciones.generarExcel(Page, dtInforme, "Informe general soporte bancario");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Debe seleccionar un rango de fecha');", true);
        } 
    }

    protected void btnLimpiarInforme_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("soporteBancario");
    }

   

    #endregion

    #region Buscadores

    // Permite filtrar la información de soportes bancario dependiendo de los filtros que se ingresan
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string banco = "";
        string cuenta = "";
        DateTime fecha = Convert.ToDateTime("01/01/1900");
        string recibido = "";
        string estado = "";

        if (txtBuscarBanco.Text != "")
        {
            banco = txtBuscarBanco.Text;
        }

        if (txtBuscarCuenta.Text != "")
        {
            cuenta = txtBuscarCuenta.Text;
        }

        if (txtBuscarFecha.Text != "")
        {
            fecha = DateTime.Parse(txtBuscarFecha.Text);
        }

        if (txtBuscarRecibido.Text != "")
        {
            recibido = txtBuscarRecibido.Text;
        }

        if (txtBuscarEstado.Text != "")
        {
            estado = txtBuscarEstado.Text;
        }

        DataTable dt = AdministrarSoportesBancarios.BuscarEncabezadoSoporteBancario(banco, cuenta, fecha, recibido, estado);
        grvListSop.DataSource = dt;
        grvListSop.DataBind();

    }

    // Permite limpiar los campos para hacer nuevas busquedas
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtBuscarBanco.Text = "";
        txtBuscarCuenta.Text = "";
        txtBuscarFecha.Text = "";
        txtBuscarRecibido.Text = "";
        txtBuscarEstado.Text = "";
        ListarSoportes();
        Response.RedirectToRoute("soporteBancario");
    }


    protected void btnBuscarDetalle_Click(object sender, EventArgs e)
    {
        string formaPago = "";
        string identificacion = "";
        string referencia = "";
        string estado = "";
        int encSop_Id = int.Parse(Session["encSop_Id"].ToString());

        if (txtBuscarFormaPago.Text != "")
        {
            formaPago = txtBuscarFormaPago.Text;
        }

        if (txtBuscarIdentificacion.Text != "")
        {
            identificacion = txtBuscarIdentificacion.Text;
        }
        
        if (txtBuscarReferencia.Text != "")
        {
            referencia = txtBuscarReferencia.Text;
        }

        if (txtBuscarEstDetalle.Text != "")
        {
            estado = txtBuscarEstDetalle.Text;
        }

        DataTable dt = AdministrarSoportesBancarios.BuscarSoporteBancario(formaPago, identificacion, referencia, estado, encSop_Id);
        grvConsutarSop.DataSource = dt;
        grvConsutarSop.DataBind();

    }

    // Permite limpiar los campos para hacer nuevas busquedas
    protected void btnLimpiarCampos_Click(object sender, EventArgs e)
    {
        txtBuscarFormaPago.Text = "";
        txtBuscarReferencia.Text = "";
        txtBuscarIdentificacion.Text = "";
        txtBuscarEstado.Text = "";
        ListarSoportes();
        Response.RedirectToRoute("soporteBancario");
    }

    #endregion 

   
}

