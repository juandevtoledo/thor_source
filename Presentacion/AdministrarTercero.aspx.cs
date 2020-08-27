using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_frmAdministrarTercero : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {

        //ContentPlaceHolder mpContentPlaceHolder;
        //Button btn;
        //mpContentPlaceHolder = (ContentPlaceHolder)Page.FindControl("ContentPlaceHolder1");

        //if (mpContentPlaceHolder != null)
        //{
        //    btn = (Button)mpContentPlaceHolder.FindControl("botonNuevoRegistro");
        //    btn.Enabled = false;
        //}


        //ContentPlaceHolder mpContentPlaceHolder;
        //Button btn;
        //mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

        //if (mpContentPlaceHolder != null)
        //{
        //    String perfil = Session["Perfil"].ToString();
        //    String cedula = Session["Cedula"].ToString();
        //    //DataTable dtBtn = Control.ConsultarBotones(perfil);
        //    //Session["btnNombre"] =  dtBtn.Rows[0]["btn_Nombre"];
        //    btn = (Button)mpContentPlaceHolder.FindControl(Session["btnNombre"].ToString());
        //    btn.Enabled = false;
        //}

        //LinkButton lbtn = sender as LinkButton;
        //Button btn = (Button) Page.Controls.FindControl("botonNuevoRegistro");
        //btn.Enabled = false;

        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.objUsuarioSistema.NombreUsuario = Session["Usuario"].ToString();

        //if (!IsPostBack)
        //{
        //    Mene1
        //}

        Session["edad"] = txtEdad.Text;
        //Recibe variable de sesion para ocultar o mostrar botones
        if ((string)Session["flag"] == "1")
        {
            if (!IsPostBack)
            {
                ocultarControles();
            }
            
        }
        else
        {
            
            txtDocumento.Text = Convert.ToString(Session["ter_Id"]); //jc
            txtDocumento.Enabled = true; //jc
            botonBuscarTercero.Enabled = true; //jc
            botonNuevoRegistro.Visible = false;
        }
       
        
        if (!IsPostBack)
        {
            AdministrarTercero.asegurado = new Asegurado();

            DataTable dt = new DataTable();
            dt = AdministrarTercero.asegurado.sp_MostrarTipoDocumento();
            ddlTipoDocumentoTercero.DataTextField = "tipDoc_Nombre"; // Cargamos lo que aparece en el ddl
            ddlTipoDocumentoTercero.DataValueField = "tipDoc_Id"; // Cargamos lo que vale por debajo
            ddlTipoDocumentoTercero.DataSource = dt;
            ddlTipoDocumentoTercero.DataBind();
            // Cargue
            ddlTipoDocumentoTercero.Items.Insert(0, new ListItem("", ""));

            divObservaciones.Visible = false;
            ddlHabeasData.Items.Insert(0, new ListItem("", ""));
        }


        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = AdministrarTercero.asegurado.sp_MostrarDepartamento();
            ddlDepartamento.DataTextField = "dep_Nombre"; // Cargamos lo que aparece en el ddl
            ddlDepartamento.DataValueField = "dep_Id"; // Cargamos lo que vale por debajo
            ddlDepartamento.DataSource = dt;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("", ""));
        }


        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = AdministrarTercero.asegurado.sp_MostrarOcupacion();
            ddlOcupacionTercero.DataTextField = "ocu_Nombre"; // Cargamos lo que aparece en el ddl
            ddlOcupacionTercero.DataValueField = "ocu_Id"; // Cargamos lo que vale por debajo
            ddlOcupacionTercero.DataSource = dt;
            ddlOcupacionTercero.DataBind();
            ddlOcupacionTercero.Items.Insert(0, new ListItem("", ""));
        }


        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = AdministrarTercero.asegurado.sp_ConsultarEstadoCivil();
            ddlEstadoCivilTercero.DataTextField = "estCiv_Nombre"; // Cargamos lo que aparece en el ddl
            ddlEstadoCivilTercero.DataValueField = "estCiv_Id"; // Cargamos lo que vale por debajo
            ddlEstadoCivilTercero.DataSource = dt;
            ddlEstadoCivilTercero.DataBind();
            ddlEstadoCivilTercero.Items.Insert(0, new ListItem("", ""));
        }

        if (!IsPostBack)
        {
            string valor = Request.QueryString["Valor"]; //recibe el valor enviado desde entrega produccion boton digitar
            if (valor != null)
            {
                txtDocumento.Text = valor; //muestra el valor en el txt
            }
        }

                
    }

    //Botón para registrar un nuevo tercero
    protected void botonRegistrarTercero_Click(object sender, EventArgs e)
    {
        if (txtNombre.Text != "" & txtApellido.Text != "" & txtNacimiento.Text != "" & ddlTipoDocumentoTercero.Text != "" & txtIdentificacion.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "")
        {
            if (txtCelular.Text != "" | txtTelefono1.Text != "" | txtTelefono2.Text != "")
            {
                if (txtDireccion.Text != "" & ddlGeneroTercero.Text != "" & ddlEstadoCivilTercero.Text != "" & ddlOcupacionTercero.Text != "")
                {
                    string mensaje = AdministrarTercero.InsertarTercero(txtIdentificacion.Text, ddlTipoDocumentoTercero.SelectedValue, txtNombre.Text, txtApellido.Text, DateTime.Parse(txtNacimiento.Text), txtCorreo.Text, ddlGeneroTercero.SelectedValue, ddlDepartamento.SelectedValue, ddlCiudad.SelectedValue, txtCelular.Text, txtTelefono1.Text, txtDireccion.Text, txtTelefono2.Text, ddlOcupacionTercero.SelectedValue, ddlEstadoCivilTercero.SelectedValue,int.Parse(ddlHabeasData.SelectedValue));
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + mensaje + "');", true);
                    bloquearCampos();
                    //ocultarBotones();
                    txtDocumento.Text = txtIdentificacion.Text;
                    buscarTercero(); //-
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
        }
    }


    protected void botonEditarTercero_Click(object sender, EventArgs e)
    {
        mostrarControles();
        activarCampos();
        botonEditarTercero.Visible = false;
        botonRegistrarTercero.Visible = false;
        botonEliminarTercero.Visible = false;
        botonGuardarTercero.Visible = true;
        botonCancelarTercero.Visible = true;

        //?????????????????????????
        //???????????????????????????
        if ((string)Session["flagTemp"] == "2")
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtNacimiento.Enabled = true;
            ddlTipoDocumentoTercero.Enabled = false;
            txtIdentificacion.Enabled = false;
        }
    }


    protected void botonEliminarTercero_Click(object sender, EventArgs e)
    {
        string mensaje = AdministrarTercero.EliminarTercero(txtDocumento.Text); //Se envia parámetro
        limpiar();

        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + mensaje + "');", true);
    }


    //Juan Camilo
    protected void botonBuscarTercero_Click(object sender, EventArgs e)
    {
        buscarTercero(); //llama el método buscarTercero jc
    }


    //Método buscarTercero - JC
    private void buscarTercero()
    {
        AdministrarTercero.asegurado = new Asegurado();
        //string mensaje = Funciones.validarCampoVacio(txtDocumento.Text); //Se envía dato a la función y valida si el campo está vacio
        //if (mensaje != "")
        if (txtDocumento.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "POR FAVOR INGRESE UN NÚMERO DE DOCUMENTO" + "');", true);
            limpiar();
            ocultarBotones();
            ocultarControles();
        }
        else
        {
            AdministrarTercero.MostrarTercero(txtDocumento.Text);

            if (AdministrarTercero.asegurado.Mensaje == "Busqueda exitosa!")
            {
                mostrarControles();
                DataTable dt = new DataTable();
                dt = AdministrarTercero.asegurado.sp_MostrarDepartamento();
                ddlDepartamento.DataTextField = "dep_Nombre"; // Cargamos lo que aparece en el ddl
                ddlDepartamento.DataValueField = "dep_Id"; // Cargamos lo que vale por debajo
                ddlDepartamento.DataSource = dt;
                ddlDepartamento.DataBind();

                //ddlDepartamento.Items.FindByText(AdministrarTercero.asegurado.DepartamentoNombre);
                ddlDepartamento.SelectedIndex = ddlDepartamento.Items.IndexOf(ddlDepartamento.Items.FindByText(AdministrarTercero.asegurado.DepartamentoNombre));
                //ddlDepartamento.SelectedItem.Text = AdministrarTercero.asegurado.DepartamentoNombre;

                dt = AdministrarTercero.asegurado.sp_ConsultarCiudad();
                ddlCiudad.DataTextField = "ciu_Nombre"; // Cargamos lo que aparece en el ddl
                ddlCiudad.DataValueField = "ciu_Id"; // Cargamos lo que vale por debajo
                ddlCiudad.DataSource = dt;
                ddlCiudad.DataBind();

                ddlTipoDocumentoTercero.SelectedIndex = ddlTipoDocumentoTercero.Items.IndexOf(ddlTipoDocumentoTercero.Items.FindByText(AdministrarTercero.asegurado.TipoDocumentoNombre));
                txtIdentificacion.Text = AdministrarTercero.asegurado.NumeroDocumento;
                txtNombre.Text = AdministrarTercero.asegurado.Nombres.ToUpper();
                txtApellido.Text = AdministrarTercero.asegurado.Apellidos;
                txtEdad.Text = Funciones.Edad(AdministrarTercero.asegurado.FechaNacimiento).ToString(); //Envía fecha y devuelve la edad
                if (AdministrarTercero.asegurado.FechaNacimiento.Year != 1)
                {
                    txtNacimiento.Text = AdministrarTercero.asegurado.FechaNacimiento.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtEdad.Text = "";
                    txtNacimiento.Text = "";
                }


                txtCorreo.Text = AdministrarTercero.asegurado.CorreoElectronico;

                ddlGeneroTercero.SelectedIndex = ddlGeneroTercero.Items.IndexOf(ddlGeneroTercero.Items.FindByText(AdministrarTercero.asegurado.Sexo));
                int hd = 0;
                if (AdministrarTercero.asegurado.HabeasData.ToString() == "1")
                    hd = 1;
                ddlHabeasData.SelectedValue = hd.ToString();  
                //ddlDepartamento.SelectedItem.Text = AdministrarTercero.asegurado.DepartamentoNombre;
                //ddlCiudad.Items.FindByText(AdministrarTercero.asegurado.CiudadNombre);
                //ddlCiudad.SelectedIndex = 2;
                ddlCiudad.SelectedIndex = ddlCiudad.Items.IndexOf(ddlCiudad.Items.FindByText(AdministrarTercero.asegurado.CiudadNombre));
                //ddlCiudad.SelectedItem.Text = AdministrarTercero.asegurado.CiudadNombre;
                txtCelular.Text = AdministrarTercero.asegurado.Celular;
                txtTelefono1.Text = AdministrarTercero.asegurado.Telefono1;
                txtDireccion.Text = AdministrarTercero.asegurado.Direccion;
                txtTelefono2.Text = AdministrarTercero.asegurado.Telefono2;
                ddlOcupacionTercero.SelectedIndex = ddlOcupacionTercero.Items.IndexOf(ddlOcupacionTercero.Items.FindByText(AdministrarTercero.asegurado.OcupacionNombre));
                ddlEstadoCivilTercero.SelectedIndex = ddlEstadoCivilTercero.Items.IndexOf(ddlEstadoCivilTercero.Items.FindByText(AdministrarTercero.asegurado.EstadoCivilNombre));
                mostrarBotones();
                bloquearCampos();
                botonRegistrarTercero.Visible = false;
                botonGuardarTercero.Visible = false;
                botonCancelarTercero.Visible = false;

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + AdministrarTercero.asegurado.Mensaje + "');", true);
                limpiarObjetosClaseAdministrarTercero(); //llama el método
                if ((string)Session["flag"] == "2")
                {
                    botonProductosTercero.Visible = false;
                    if (txtNombre.Text != "" & txtApellido.Text != "" & txtNacimiento.Text != "" & ddlTipoDocumentoTercero.Text != "" & txtIdentificacion.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "")
                    {
                        if (txtCelular.Text != "" | txtTelefono1.Text != "" | txtTelefono2.Text != "")
                        {
                            if (txtDireccion.Text != "" & ddlGeneroTercero.Text != "" & ddlEstadoCivilTercero.Text != "" & ddlOcupacionTercero.Text != "")
                            {
                                PasarCertificado.Visible = true;
                                botonProductosTercero.Visible = false;
                            }
                        }
                    }
                    Session["flagTemp"] = "2";
                   // Session["flag"] = "1";
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + AdministrarTercero.asegurado.Mensaje + "');", true);
                //ocultarControles();
                ocultarBotones();
                ocultarControles();
                limpiar();
            }
        }        
    }


    //Método para vaciar los objetos de la clase administrarTercero
    protected void limpiarObjetosClaseAdministrarTercero()
    {
        AdministrarTercero.asegurado.TipoDocumentoNombre = "";
        AdministrarTercero.asegurado.NumeroDocumento = "";
        AdministrarTercero.asegurado.Nombres = "";
        AdministrarTercero.asegurado.Apellidos = "";
        Convert.ToDateTime(AdministrarTercero.asegurado.FechaNacimiento).ToString("dd/MM/yyyy");
        Funciones.Edad(AdministrarTercero.asegurado.FechaNacimiento).ToString(); //Envía fecha y devuelve la edad
        AdministrarTercero.asegurado.CorreoElectronico = "";
        AdministrarTercero.asegurado.Sexo = "";
        AdministrarTercero.asegurado.DepartamentoNombre = "";
        ddlCiudad.Items.Add(AdministrarTercero.asegurado.CiudadNombre);
        AdministrarTercero.asegurado.Celular = "";
        AdministrarTercero.asegurado.Telefono1 = "";
        AdministrarTercero.asegurado.Direccion = "";
        AdministrarTercero.asegurado.Telefono2 = "";
        AdministrarTercero.asegurado.OcupacionNombre = "";
        AdministrarTercero.asegurado.EstadoCivilNombre = "";
        
    }


    //JC 
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarTercero.ConsultarCiudad(ddlDepartamento.SelectedValue);

        DataTable dt = new DataTable();
        dt = AdministrarTercero.asegurado.sp_ConsultarCiudad();
        ddlCiudad.DataTextField = "ciu_Nombre"; // Cargamos lo que aparece en el ddl
        ddlCiudad.DataValueField = "ciu_Id"; // Cargamos lo que vale por debajo
        ddlCiudad.DataSource = dt;
        ddlCiudad.DataBind();
    }


    //Método para activar los campos
    protected void activarCampos()
    {
        txtNombre.Enabled=true;
        txtApellido.Enabled = true;
        txtNacimiento.Enabled = true;
        ddlTipoDocumentoTercero.Enabled=true;
        txtIdentificacion.Enabled=true;
        //ddlTipoDocumentoTercero.Text = "";
        txtCorreo.Enabled = true;
        ddlGeneroTercero.Enabled = true;
        ddlDepartamento.Enabled = true;
        ddlCiudad.Enabled = true;
        txtCelular.Enabled = true;
        txtTelefono1.Enabled = true;
        txtDireccion.Enabled = true;
        txtTelefono2.Enabled = true;
        ddlEstadoCivilTercero.Enabled = true;
        ddlOcupacionTercero.Enabled = true;
        ddlHabeasData.Enabled = true;
    }


    //Método para bloquear los campos
    protected void bloquearCampos()
    {
        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        txtNacimiento.Enabled = false;
        ddlTipoDocumentoTercero.Enabled = false;
        txtIdentificacion.Enabled = false;
        //ddlTipoDocumentoTercero.Text = "";
        txtCorreo.Enabled = false;
        ddlGeneroTercero.Enabled = false;
        ddlDepartamento.Enabled = false;
        ddlCiudad.Enabled = false;
        txtCelular.Enabled = false;
        txtTelefono1.Enabled = false;
        txtDireccion.Enabled = false;
        txtTelefono2.Enabled = false;
        ddlEstadoCivilTercero.Enabled = false;
        ddlOcupacionTercero.Enabled = false;
        ddlHabeasData.Enabled = false;
    }


    //Método para ocultar los campos
    protected void ocultarControles()
    {
        lblNombres.Visible = false;
        txtNombre.Visible = false;
        lblApellidos.Visible = false;
        txtApellido.Visible = false;
        lblFechaNacimiento.Visible = false;
        txtNacimiento.Visible = false;
        lblEdad.Visible = false;
        txtEdad.Visible = false;
        lblTipoDocumento.Visible = false;
        ddlTipoDocumentoTercero.Visible = false;
        lblNumeroIdentificacion.Visible = false;
        txtIdentificacion.Visible = false;
        //ddlTipoDocumentoTercero.Text = "";
        lblEmail.Visible = false;
        txtCorreo.Visible = false;
        lblSexo.Visible = false;
        ddlGeneroTercero.Visible = false;
        lblDepartamento.Visible = false;
        ddlDepartamento.Visible = false;
        lblCiudad.Visible = false;
        ddlCiudad.Visible = false;
        lblCelular.Visible = false;
        txtCelular.Visible = false;
        lblTelefono1.Visible = false;
        txtTelefono1.Visible = false;
        lblDireccion.Visible = false;
        txtDireccion.Visible = false;
        lblTelefono2.Visible = false;
        txtTelefono2.Visible = false;
        lblEstadoCivil.Visible = false;
        ddlEstadoCivilTercero.Visible = false;
        lblOcupacion.Visible = false;
        ddlOcupacionTercero.Visible = false;
        lblHabeas.Visible = false;
        ddlHabeasData.Visible = false;
    }


    //Método para mostrar los campos
    protected void mostrarControles()
    {
        lblNombres.Visible = true;
        txtNombre.Visible = true;
        lblApellidos.Visible = true;
        txtApellido.Visible = true;
        lblFechaNacimiento.Visible = true;
        txtNacimiento.Visible = true;
        lblEdad.Visible = true;
        txtEdad.Visible = true;
        lblTipoDocumento.Visible = true;
        ddlTipoDocumentoTercero.Visible = true;
        lblNumeroIdentificacion.Visible = true;
        txtIdentificacion.Visible = true;
        //ddlTipoDocumentoTercero.Text = "";
        lblEmail.Visible = true;
        txtCorreo.Visible = true;
        lblSexo.Visible = true;
        ddlGeneroTercero.Visible = true;
        lblDepartamento.Visible = true;
        ddlDepartamento.Visible = true;
        lblCiudad.Visible = true;
        ddlCiudad.Visible = true;
        lblCelular.Visible = true;
        txtCelular.Visible = true;
        lblTelefono1.Visible = true;
        txtTelefono1.Visible = true;
        lblDireccion.Visible = true;
        txtDireccion.Visible = true;
        lblTelefono2.Visible = true;
        txtTelefono2.Visible = true;
        lblEstadoCivil.Visible = true;
        ddlEstadoCivilTercero.Visible = true;
        lblOcupacion.Visible = true;
        ddlOcupacionTercero.Visible = true;
        btnObservacion.Visible = true;
        lblHabeas.Visible = true;
        ddlHabeasData.Visible = true;
    }


    private void mostrarBotones()
    {
        botonBuscarTercero.Visible = true;
        botonProductosTercero.Visible = true;
        botonRegistrarTercero.Visible = true;
        botonEliminarTercero.Visible = true;
        botonGuardarTercero.Visible = true;
        botonCancelarTercero.Visible = true;
        botonEditarTercero.Visible = true;
    }


    private void ocultarBotones()
    {
        botonProductosTercero.Visible = false;
        botonRegistrarTercero.Visible = false;
        botonEliminarTercero.Visible = false;
        botonGuardarTercero.Visible = false;
        botonCancelarTercero.Visible = false;
        botonEditarTercero.Visible = false;
    }

    //Metodo para limpiar campos - Juan Camilo 05/08/2015
    private void limpiar()
    {
        //txtDocumento.Text = "";
        txtIdentificacion.Text = "";
        //ddlTipoDocumentoTercero.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtNacimiento.Text = "";
        txtEdad.Text = "";
        txtCorreo.Text = "";
        //ddlGeneroTercero.Text = "";
        //ddlDepartamento.Text = "";
        //ddlCiudad.Text = "";
        txtCelular.Text = "";
        txtTelefono1.Text = "";
        txtDireccion.Text = "";
        txtTelefono2.Text = "";
    }

        
    //Método que obtiene variable de sesión - Juan Camilo /27/07/2015
    protected void PasarCertificado_Click(object sender, EventArgs e)
    {
        //if ((string)Session["operacionCertificado"] == "modificar")
        //{
        //    Response.Redirect("ModificarCertificado.aspx");
        //}
        //else
        //{
        //    Response.Redirect("DigitarCertificado.aspx");
        //}

        //Response.Redirect("DigitarCertificado.aspx");
        //Response.RedirectToRoute("digitarCertificado");
        Response.Redirect(url: "/Presentacion/DigitarCertificado.aspx");
    }


    //Boton cancelar para bloquear los campos
    protected void botonCancelarTercero_Click(object sender, EventArgs e)
    {
        limpiar();
        bloquearCampos();
        botonGuardarTercero.Visible = false;
        botonEditarTercero.Visible = true;
        botonCancelarTercero.Visible = false;
    }


    //Boton para modificar los cambios al seleccionar el botón guardar
    protected void botonGuardarTercero_Click(object sender, EventArgs e)
    {
        if (txtNombre.Text != "" & txtApellido.Text != "" & txtNacimiento.Text != "" & ddlTipoDocumentoTercero.Text != "" & txtIdentificacion.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "" & ddlHabeasData.Text != "")
        {
            if (txtCelular.Text != "" | txtTelefono1.Text != "" | txtTelefono2.Text != "")
            {
                if (txtDireccion.Text != "" & ddlGeneroTercero.Text != "" & ddlEstadoCivilTercero.Text != "" & ddlOcupacionTercero.Text != "")
                {
                    AdministrarTercero.ModificarTercero(txtDocumento.Text, ddlTipoDocumentoTercero.SelectedValue, txtNombre.Text, txtApellido.Text, DateTime.Parse(txtNacimiento.Text), txtCorreo.Text, ddlGeneroTercero.SelectedValue, ddlDepartamento.SelectedValue, ddlCiudad.SelectedValue, txtCelular.Text, txtTelefono1.Text, txtDireccion.Text, txtTelefono2.Text, ddlOcupacionTercero.SelectedValue, ddlEstadoCivilTercero.SelectedValue,int.Parse(ddlHabeasData.SelectedValue));
                    //limpiar();
                    mostrarControles();
                    buscarTercero(); //-
                    bloquearCampos();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "FALTAN DATOS POR INGRESAR" + "');", true);
        }
    }


    //29/08/2015 - Juan Camilo
    protected void botonProductosTercero_Click(object sender, EventArgs e)
    {
        if (txtDocumento.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "DEBE INGRESAR UN NÚMERO DE DOCUMENTO" + "');", true);
        }
        else
        {
            
            Session["ssDocumento"] = txtDocumento.Text;
            Session["Nombre"] = txtNombre.Text;
            Session["Apellido"] = txtApellido.Text;
            //Response.Redirect("consultarCertificados.aspx");
            Response.RedirectToRoute("resumen");
        }
    }

    
    //JC
    protected void botonNuevoRegistro_Click(object sender, EventArgs e)
    {
        activarCampos();
        mostrarControles();
        botonRegistrarTercero.Visible = true;
        limpiar();
        ocultarBotones();
        botonRegistrarTercero.Visible = true;
        ddlTipoDocumentoTercero.SelectedIndex = ddlTipoDocumentoTercero.Items.IndexOf(ddlTipoDocumentoTercero.Items.FindByText(" "));
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));
        ddlDepartamento.SelectedIndex = ddlDepartamento.Items.IndexOf(ddlDepartamento.Items.FindByText(" "));
        ddlCiudad.Items.Insert(0, new ListItem("", ""));
        ddlCiudad.SelectedIndex = ddlCiudad.Items.IndexOf(ddlCiudad.Items.FindByText(" "));
        //ddlGeneroTercero.Items.Insert(0, new ListItem("", ""));
        ddlGeneroTercero.SelectedIndex = ddlGeneroTercero.Items.IndexOf(ddlGeneroTercero.Items.FindByText(" "));
        ddlEstadoCivilTercero.SelectedIndex = ddlEstadoCivilTercero.Items.IndexOf(ddlEstadoCivilTercero.Items.FindByText(" "));
        ddlOcupacionTercero.SelectedIndex = ddlOcupacionTercero.Items.IndexOf(ddlOcupacionTercero.Items.FindByText(" "));
        ddlHabeasData.SelectedIndex = ddlHabeasData.Items.IndexOf(ddlHabeasData.Items.FindByText(" "));
    }
    protected void btnObservacion_Click(object sender, EventArgs e)
    {
        if (txtDocumento.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "DEBE INGRESAR UN NÚMERO DE DOCUMENTO" + "');", true);
        }
        else
        {
            divObservaciones.Visible = true;
            string ter_IdO = txtIdentificacion.Text;
            Session["ter_IdO"] = ter_IdO;

            DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_IdO.ToString(), "0");
            grvObservaciones.DataSource = observaciones;
            grvObservaciones.DataBind();
        }
    }
    protected void btnGuardarObservacion_Click(object sender, EventArgs e)
    {
        if (txtDocumento.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "DEBE INGRESAR UN NÚMERO DE DOCUMENTO" + "');", true);
        }
        else
        {
            int ter_Id = (int)int.Parse(Session["ter_IdO"].ToString());
            string usuarioObs = (string)Session["usuario"];
            DataTable dtMenu = (DataTable)Session["menuSistema"];
            string menu = dtMenu.Rows[5]["men_id"].ToString();

            if (txtObservacion.Text != "")
                AdministrarCartaRetiro.GuardarObservacion(txtObservacion.Text, usuarioObs, int.Parse(menu), ter_Id, ter_Id);
            else
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese una observacion" + "');", true);

            DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_Id.ToString(), "0");
            grvObservaciones.DataSource = observaciones;
            grvObservaciones.DataBind();
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        divObservaciones.Visible = false;
    }
}