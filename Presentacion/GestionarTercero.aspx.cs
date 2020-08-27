using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_GestionarTercero : System.Web.UI.Page
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

    // Obtener todos los datos necesarios al momento de cargar la pagina
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        
        listaTerceros.Visible = false;
        formTercero.Visible = false;
        btnActualizar.Visible = false;
        divObservaciones.Visible = false;
        

        if (Session["cedulaTemp"] != null)
        {
            Session["evento"] = "ModificarTercero_Click";
            cargarInformacionTerceroCarta(sender, null, int.Parse(Session["cedulaTemp"].ToString()), Session["evento"].ToString());
            Session["cedulaTemp"] = null;

        }
        if(!IsPostBack)
        {
            divObservaciones.Visible = false;
            ddlHabeasData.Items.Insert(0, new ListItem("", ""));
        }
        
    }

    private void cargarInformacionTerceroCarta(object sender, GridViewCommandEventArgs e, int ter_Id, string evento)
    {
        InformacionTercero(sender, e, ter_Id, evento);
    }

    //
    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        ddlCargarDatos();
        btnGuardar.Visible = true;
        btnActualizar.Visible = false;
        btnResume.Visible = false;
        //btnEditar.Visible = false;

        listaTerceros.Visible = false;
        formTercero.Visible = true;
        limpiarCampos();
        habilitarCampos();
    }

    // Funcion del boton buscar tercero
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        double documento = 0;
        if (txtDocumento.Text != "")
        {
            documento = double.Parse(txtDocumento.Text);
        }
        dt = GestionarTercero.BuscarTercero(documento, txtNombres.Text, txtApellidos.Text);
        cargarListaTerceros(dt);
    }

    // Funcion paginador de la lista de terceros
    protected void grvListaTercero_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvListaTerceros.PageIndex = e.NewPageIndex;
        DataTable dt = new DataTable();
        dt = GestionarTercero.BuscarTercero(double.Parse(txtDocumento.Text), txtNombres.Text, txtApellidos.Text);
        cargarListaTerceros(dt);
    }

    // Sirve para cargar la lista desde el datatable
    private void cargarListaTerceros(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            listaTerceros.Visible = true;
            grvListaTerceros.DataSource = dt;
            grvListaTerceros.DataBind();
        }
        else
        {
            listaTerceros.Visible = false;
        }
    }

    // Sirve para cargar los datos de cada tercero
    protected void grvListTercero_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvListaTerceros.Rows[(index)];

        int ter_Id = int.Parse(row.Cells[2].Text);
        Session["tercero"] = ter_Id;

        if (e.CommandName == "ConsultarTercero_Click")
        {
            Session["evento"] = "ConsultarTercero_Click";
            btnGuardar.Visible = false;
            btnActualizar.Visible = false;
            btnResume.Visible = true;
            //btnEditar.Visible = true;

            deshabilitarCampos();
            cargarInformacionTercero(sender, e, ter_Id);
        }
        if (e.CommandName == "ModificarTercero_Click")
        {
         Session["evento"] = "ModificarTercero_Click";

         
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnResume.Visible = false;
            //btnEditar.Visible = false;

            habilitarCampos();
            ddlTipoDocumentoTercero.Enabled = false;
            txtIdentificacion.Enabled = false;
            cargarInformacionTercero(sender, e, ter_Id);
        }
        if(e.CommandName == "Observacion_Click")
        {
            divObservaciones.Visible = true;
            txtDocumento.Text = ter_Id.ToString();
            //txtNombres.Text = row.Cells[3].Text.ToString();
            //txtApellidos.Text = row.Cells[4].Text.ToString();

            btnBuscar_Click(sender, e);

            DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_Id.ToString(), "0");
            grvObservaciones.DataSource = observaciones;
            grvObservaciones.DataBind();
        }
    }

    protected void btnGuardarObservacion_Click(object sender, EventArgs e)
    {
        int ter_Id = (int)Session["tercero"];
        string usuarioObs = (string)Session["usuario"];
        DataTable dtMenu = (DataTable)Session["menuSistema"];
        string menu = dtMenu.Rows[5]["men_id"].ToString();

        if(txtObservacion.Text != "")
            AdministrarCartaRetiro.GuardarObservacion(txtObservacion.Text, usuarioObs, int.Parse(menu), ter_Id, ter_Id);
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese una observacion" + "');", true);

        DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_Id.ToString(), "0");
        grvObservaciones.DataSource = observaciones;
        grvObservaciones.DataBind();

        btnBuscar_Click(sender, e);
    }

    //
    private void cargarInformacionTercero(object sender, GridViewCommandEventArgs e, int ter_Id)
    {
        InformacionTercero(sender , e, ter_Id, null);
    }

    private void InformacionTercero(object sender, GridViewCommandEventArgs e, int ter_Id, string evento)
    {
        listaTerceros.Visible = false;
        formTercero.Visible = true;

        ddlCargarDatos();
        DataTable dt = new DataTable();
        dt = GestionarTercero.ConsultarTercero(ter_Id);
        txtIdentificacion.Text = dt.Rows[0]["ter_Id"].ToString();
        txtNombre.Text = dt.Rows[0]["ter_Nombres"].ToString();
        txtApellido.Text = dt.Rows[0]["ter_Apellidos"].ToString();
        txtNacimiento.Text = covertirFechas(dt.Rows[0]["ter_FechaNacimiento"].ToString());
        txtCorreo.Text = dt.Rows[0]["ter_Correo"].ToString();
        txtCelular.Text = dt.Rows[0]["ter_Celular"].ToString();
        txtDireccion.Text = dt.Rows[0]["ter_Direccion"].ToString();
        txtTelefono1.Text = dt.Rows[0]["ter_TelefonoResidencia"].ToString();
        txtTelefono2.Text = dt.Rows[0]["ter_TelefonoOficina"].ToString();
        txtEdad.Text = calcularEdad(dt.Rows[0]["ter_FechaNacimiento"].ToString()).ToString();
        Session["edad"] = txtEdad.Text;
        ddlDepartamento.Items.FindByValue(dt.Rows[0]["dep_Id"].ToString()).Selected = true;
        //Session["departamento_Id"] = dt.Rows[0]["dep_Id"].ToString();
        ddlDepartamento_SelectedIndexChanged(sender, e);
        ddlCiudad.Items.FindByValue(dt.Rows[0]["ciu_Id"].ToString()).Selected = true;
        ddlTipoDocumentoTercero.Items.FindByValue(dt.Rows[0]["tipDoc_Id"].ToString()).Selected = true;
        ddlEstadoCivilTercero.Items.FindByValue(dt.Rows[0]["estCiv_Id"].ToString()).Selected = true;
        ddlGeneroTercero.Items.FindByText(dt.Rows[0]["ter_Sexo"].ToString()).Selected = true;
        ddlOcupacionTercero.Items.FindByValue(dt.Rows[0]["ocu_Id"].ToString()).Selected = true;
        int hd = 0;
        if (dt.Rows[0]["ter_HabeasData"].ToString() == "1")
            hd = 1;
        ddlHabeasData.SelectedValue = hd.ToString();       
        
    }



    private void ddlCargarDatos()
    {
        // Obtener los departamentos
        DataTable dtDepartamentos = new DataTable();
        dtDepartamentos = GestionarTercero.ConsultarLocalidades();
        ddlDepartamento.DataValueField = "dep_Id";
        ddlDepartamento.DataTextField = "dep_Nombre";
        ddlDepartamento.DataSource = dtDepartamentos;
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));

        // Obtener los tipos de documentos
        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento = GestionarTercero.ConsultarTiposDocumentos();
        ddlTipoDocumentoTercero.DataValueField = "tipDoc_Id";
        ddlTipoDocumentoTercero.DataTextField = "tipDoc_Nombre";
        ddlTipoDocumentoTercero.DataSource = dtTipoDocumento;
        ddlTipoDocumentoTercero.DataBind();
        ddlTipoDocumentoTercero.Items.Insert(0, new ListItem("", ""));

        // Obtener los estados civiles
        DataTable dtEstadoCivil = new DataTable();
        dtEstadoCivil = GestionarTercero.ConsultarEstadosCiviles();
        ddlEstadoCivilTercero.DataValueField = "estCiv_Id";
        ddlEstadoCivilTercero.DataTextField = "estCiv_Nombre";
        ddlEstadoCivilTercero.DataSource = dtEstadoCivil;
        ddlEstadoCivilTercero.DataBind();
        ddlEstadoCivilTercero.Items.Insert(0, new ListItem("", ""));

        // Obtener los estados civiles
        DataTable dtOcupacion = new DataTable();
        dtOcupacion = GestionarTercero.ConsultarOcupaciones();
        ddlOcupacionTercero.DataValueField = "ocu_Id";
        ddlOcupacionTercero.DataTextField = "ocu_Nombre";
        ddlOcupacionTercero.DataSource = dtOcupacion;
        ddlOcupacionTercero.DataBind();
        ddlOcupacionTercero.Items.Insert(0, new ListItem("", ""));

        DataTable dtGenero = new DataTable();
        dtGenero = GestionarTercero.ConsultarGeneros();
        ddlGeneroTercero.DataValueField = "generoNombre";
        ddlGeneroTercero.DataTextField = "generoNombre";
        ddlGeneroTercero.DataSource = dtGenero;
        ddlGeneroTercero.DataBind();
        ddlGeneroTercero.Items.Insert(0, new ListItem("", ""));
        //}
    }

    // Convierte las fechas en el formato correcto
    private string covertirFechas(string p)
    {
        return Convert.ToDateTime(p).ToString("yyyy-MM-dd");
    }

    // Calcula la edad por medio de una fecha
    private int calcularEdad(string fechaNacimiento)
    {
        int edad = DateTime.Today.AddTicks(-Convert.ToDateTime(fechaNacimiento).Ticks).Year - 1;
        return edad;
    }

    // Evento que permite cargar las ciudades por medio del cambio del departamento
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlDepSelected = ddlDepartamento.SelectedValue.ToString();

        // Obtener las ciudades por el codigo del departamento
        DataTable dtCiudades = new DataTable();
        dtCiudades = GestionarTercero.ConsultarCiudadesPorDepartamento(ddlDepSelected);
        //dtCiudades = GestionarTercero.ConsultarCiudadesPorDepartamento(Session["departamento_Id"].ToString());
        ddlCiudad.DataValueField = "ciu_Id";
        ddlCiudad.DataTextField = "ciu_Nombre";
        ddlCiudad.DataSource = dtCiudades;
        ddlCiudad.DataBind();
        ddlCiudad.Items.Insert(0, new ListItem("", ""));

        listaTerceros.Visible = false;
        formTercero.Visible = true;

        if (Session["evento"] != null)
        {
            if (Session["evento"].ToString() == "ModificarTercero_Click")
            {
                btnGuardar.Visible = false;
                btnActualizar.Visible = true;
                btnResume.Visible = false;
                //btnEditar.Visible = false;

                habilitarCampos();
                ddlTipoDocumentoTercero.Enabled = false;
                txtIdentificacion.Enabled = false;
            }
        }
        
    }

    //
    protected void btnResume_Click(object sender, EventArgs e)
    {
        Session["ssDocumento"] = txtIdentificacion.Text;
        Session["Nombre"] = txtNombre.Text;
        Session["Apellido"] = txtApellido.Text;
        //Response.Redirect("consultarCertificados.aspx");
        Response.RedirectToRoute("resumen");
    }

    //<!--<asp:Button ID="btnEditar" cssClass="btn btn-success" runat="server" Text="Modificar" OnClick="btnEditar_Click"  />-->
    //protected void btnEditar_Click(object sender, EventArgs e)
    //{
    //    listaTerceros.Visible = false;
    //    formTercero.Visible = true;

    //    btnGuardar.Visible = false;
    //    btnActualizar.Visible = true;
    //    btnResume.Visible = false;
    //    btnEditar.Visible = false;
    //    habilitarCampos();

    //    ddlTipoDocumentoTercero.Enabled = false;
    //    txtIdentificacion.Enabled = false;
    //}

    //
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        listaTerceros.Visible = false;
        formTercero.Visible = true;

        btnGuardar.Visible = true;
        btnActualizar.Visible = false;
        btnResume.Visible = false;
        //btnEditar.Visible = false;

        if (txtNombre.Text != "" & txtApellido.Text != "" & txtNacimiento.Text != "" & ddlTipoDocumentoTercero.Text != "" &
            txtIdentificacion.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "" & txtDireccion.Text != "" &
            ddlGeneroTercero.Text != "" & ddlEstadoCivilTercero.Text != "" & ddlOcupacionTercero.Text != "" & ddlHabeasData.Text != "")
        {
            if (txtCelular.Text != "" | txtTelefono1.Text != "" | txtTelefono2.Text != "")
            {
                int reg = GestionarTercero.InsertarTercero(int.Parse(txtIdentificacion.Text), int.Parse(ddlTipoDocumentoTercero.SelectedValue),
                                                    txtNombre.Text, txtApellido.Text, DateTime.Parse(txtNacimiento.Text), txtCorreo.Text,
                                                    ddlGeneroTercero.SelectedValue, int.Parse(ddlDepartamento.SelectedValue),
                                                    int.Parse(ddlCiudad.SelectedValue), txtCelular.Text, txtTelefono1.Text,
                                                    txtDireccion.Text, txtTelefono2.Text, int.Parse(ddlOcupacionTercero.SelectedValue),
                                                    int.Parse(ddlEstadoCivilTercero.SelectedValue), Session["usuario"].ToString(),
                                                    int.Parse(ddlHabeasData.SelectedValue));
                if (reg > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Tercero adicionado con exito" + "');", true);

                    btnGuardar.Visible = false;
                    btnActualizar.Visible = false;
                    btnResume.Visible = true;
                    //btnEditar.Visible = true;

                    deshabilitarCampos();
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese un telefono" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese los campos requeridos" + "');", true);
        }
    }

    //
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        listaTerceros.Visible = true;
        formTercero.Visible = false;
    }

    //
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        listaTerceros.Visible = false;
        formTercero.Visible = true;

        btnGuardar.Visible = false;
        btnActualizar.Visible = true;
        btnResume.Visible = false;
        //btnEditar.Visible = false;

        if (txtNombre.Text != "" & txtApellido.Text != "" & txtNacimiento.Text != "" & ddlTipoDocumentoTercero.Text != "" & 
            txtIdentificacion.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "" & txtDireccion.Text != "" &
            ddlGeneroTercero.Text != "" & ddlEstadoCivilTercero.Text != "" & ddlOcupacionTercero.Text != "" & ddlHabeasData.Text != "")
        {
            if (txtCelular.Text != "" | txtTelefono1.Text != "" | txtTelefono2.Text != "")
            {
                int reg = GestionarTercero.ModificarTercero(int.Parse(txtIdentificacion.Text), int.Parse(ddlTipoDocumentoTercero.SelectedValue), 
                                                    txtNombre.Text, txtApellido.Text, DateTime.Parse(txtNacimiento.Text), txtCorreo.Text, 
                                                    ddlGeneroTercero.SelectedValue, int.Parse(ddlDepartamento.SelectedValue), 
                                                    int.Parse(ddlCiudad.SelectedValue), txtCelular.Text, txtTelefono1.Text,
                                                    txtDireccion.Text, txtTelefono2.Text, int.Parse(ddlOcupacionTercero.SelectedValue),
                                                    int.Parse(ddlEstadoCivilTercero.SelectedValue), Session["usuario"].ToString(),
                                                    int.Parse(ddlHabeasData.SelectedValue));
                if (reg > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Tercero actualizado con exito" + "');", true);

                    btnGuardar.Visible = false;
                    btnActualizar.Visible = false;
                    btnResume.Visible = true;
                    //btnEditar.Visible = true;

                    deshabilitarCampos();

                    Session["evento"] = null;
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese un telefono" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese los campos requeridos" + "');", true);
        }
    }

    //
    private void habilitarCampos()
    {
        bool enabled = true;
        ddlTipoDocumentoTercero.Enabled = enabled;
        txtIdentificacion.Enabled = enabled;
        txtNombre.Enabled = enabled;
        txtApellido.Enabled = enabled;
        txtNacimiento.Enabled = enabled;
        ddlEstadoCivilTercero.Enabled = enabled;
        ddlDepartamento.Enabled = enabled;
        ddlCiudad.Enabled = enabled;
        txtDireccion.Enabled = enabled;
        txtCorreo.Enabled = enabled;
        txtCelular.Enabled = enabled;
        txtTelefono1.Enabled = enabled;
        txtTelefono2.Enabled = enabled;
        ddlGeneroTercero.Enabled = enabled;
        ddlOcupacionTercero.Enabled = enabled;
        ddlHabeasData.Enabled = enabled;
    }

    //
    private void deshabilitarCampos()
    {
        bool enabled = false;
        ddlTipoDocumentoTercero.Enabled = enabled;
        txtIdentificacion.Enabled = enabled;
        txtNombre.Enabled = enabled;
        txtApellido.Enabled = enabled;
        txtNacimiento.Enabled = enabled;
        ddlEstadoCivilTercero.Enabled = enabled;
        ddlDepartamento.Enabled = enabled;
        ddlCiudad.Enabled = enabled;
        txtDireccion.Enabled = enabled;
        txtCorreo.Enabled = enabled;
        txtCelular.Enabled = enabled;
        txtTelefono1.Enabled = enabled;
        txtTelefono2.Enabled = enabled;
        ddlGeneroTercero.Enabled = enabled;
        ddlOcupacionTercero.Enabled = enabled;
        ddlHabeasData.Enabled = enabled;
    }

    //
    private void limpiarCampos()
    {
        string enabled = "";
        ddlTipoDocumentoTercero.Text = enabled;
        txtIdentificacion.Text = enabled;
        txtNombre.Text = enabled;
        txtApellido.Text = enabled;
        txtNacimiento.Text = enabled;
        txtEdad.Text = enabled;
        ddlEstadoCivilTercero.Text = enabled;
        ddlDepartamento.Text = enabled;
        ddlCiudad.Text = enabled;
        txtDireccion.Text = enabled;
        txtCorreo.Text = enabled;
        txtCelular.Text = enabled;
        txtTelefono1.Text = enabled;
        txtTelefono2.Text = enabled;
        ddlGeneroTercero.Text = enabled;
        ddlOcupacionTercero.Text = enabled;
        ddlHabeasData.Text = enabled;
    }
    
}