using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarUsuario : System.Web.UI.Page
{
    // Llama la funcion que permite cargar las restricciones del usuario que inicia la sesion
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];

        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        string s = this.Page.AppRelativeVirtualPath;
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarUsuarios();
            divPermisos.Visible = false;
            divConsultar.Visible = false;
            divAdicionar.Visible = false;

            listas();          
        }     
    }

    #region Cargar ddl, lista usuarios y crea paginación

    // Carga todos los datos de las listas desplegables
    protected void listas()
    {
        DataTable dt = new DataTable();

        // LLenar ddl con todos los departamentos
        dt = AdministrarTercero.asegurado.sp_MostrarDepartamento();
        ddlDepartamento.DataTextField = "dep_Nombre";
        ddlDepartamento.DataValueField = "dep_Id";
        ddlDepartamento.DataSource = dt;
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));

        // Llenar ddl con los cargos
        dt = Control.ListarCargos();
        ddlCargo.DataTextField = "car_nombre";
        ddlCargo.DataValueField = "car_Id";
        ddlCargo.DataSource = dt;
        ddlCargo.DataBind();
        ddlCargo.Items.Insert(0, new ListItem("", ""));

        // Llenar ddl con los niveles
        dt = Control.ListarNieles();
        ddlNivel.DataTextField = "niv_Nombre";
        ddlNivel.DataValueField = "niv_Id";
        ddlNivel.DataSource = dt;
        ddlNivel.DataBind();
        ddlNivel.Items.Insert(0, new ListItem("", ""));

        // Llenar ddl con los estados correspondientes al modulo control de usuarios
        dt = Control.ListarEstados();
        ddlEstado.DataTextField = "est_Nombre";
        ddlEstado.DataValueField = "est_Id";
        ddlEstado.DataSource = dt;
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("", ""));

        // Llenar ddl con los formularios o menus que ya tienen botones asignados
        dt = Control.ListarFormularioAsignados();
        ddlFormulario.DataTextField = "men_Nombre";
        ddlFormulario.DataValueField = "men_Id";
        ddlFormulario.DataSource = dt;
        ddlFormulario.DataBind();
        ddlFormulario.Items.Insert(0, new ListItem("", ""));
    }
    
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Cargar ddl Ciudad por departamento
        DataTable dt = new DataTable();
        double usuario = double.Parse(Session["Cedula"].ToString());
        dt = Control.ConsultarUsuarioModificar(int.Parse(usuario.ToString()));
        DataTable dtCiu = new DataTable();
        dtCiu = Control.ConsultarCiudad(double.Parse(ddlDepartamento.SelectedValue));
        ddlCiudad.DataTextField = "ciu_Nombre"; 
        ddlCiudad.DataValueField = "ciu_Id";
        ddlCiudad.DataSource = dtCiu;
        ddlCiudad.DataBind();
        ddlCiudad.Items.Insert(0, new ListItem("", ""));

        // Cargar ddl Agencia por departamento
        DataTable dtAge = Control.MostrarAgencia(int.Parse(ddlDepartamento.SelectedValue));
        ddlAgencia.DataTextField = "age_Nombre"; 
        ddlAgencia.DataValueField = "age_Id";
        ddlAgencia.DataSource = dtAge;
        ddlAgencia.DataBind();
        ddlAgencia.Items.Insert(0, new ListItem("", ""));
    }

    // Lista todos los usuarios del sistema 
    protected void ListarUsuarios()
    {
        DataTable dt = new DataTable();
        dt = Control.ListarUsuarios();

        grvAdminUsuario.DataSource = dt;
        grvAdminUsuario.DataBind();
    }

    // Paginación
    protected void grvAdminUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminUsuario.PageIndex = e.NewPageIndex;
        ListarUsuarios();
    }

    // Paginación
    protected void grvAdminUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvAdminUsuario.Rows.Count < grvAdminUsuario.PageSize) && (grvAdminUsuario.Rows.Count + grvAdminUsuario.PageSize * grvAdminUsuario.PageIndex < ((DataTable)(grvAdminUsuario.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }

    #endregion Cargar ddl, lista usuarios y crea paginación

    #region Buscador

    // Filtra por cédula 
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtBuscarCedula.Text != "")
        {
            DataTable dt = new DataTable();
            dt = DAOControl.BuscarPorCedula(int.Parse(txtBuscarCedula.Text));
            grvAdminUsuario.DataSource = dt;
            grvAdminUsuario.DataBind();
        }

        else if (txtBuscarNombre.Text != "")
        {
            DataTable dt = new DataTable();
            dt = DAOControl.BuscarPorNombre(txtBuscarNombre.Text);
            grvAdminUsuario.DataSource = dt;
            grvAdminUsuario.DataBind(); 
        }

        else if (txtBuscarUsuario.Text != "")
        {
            DataTable dt = new DataTable();
            dt = DAOControl.BuscarPorUsuario(txtBuscarUsuario.Text);
            grvAdminUsuario.DataSource = dt;
            grvAdminUsuario.DataBind();
        }

        else
        {
            ListarUsuarios();
            Response.RedirectToRoute("gestionUsuarios");
        }
    }

    // Limpia los campos del fromulario para una nueva busqueda
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtBuscarCedula.Text = "";
        txtBuscarNombre.Text = "";
        txtBuscarUsuario.Text = "";
        ListarUsuarios();
    }

    #endregion Buscador

    #region Acciones tabla principal

    // Permite visualizar todos los usuarios y realizar acciones con cada registro
    protected void grvAdminUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        listas(); 

        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvAdminUsuario.Rows[(index)];

        // Permite consultar los datos de un usuario
        if (e.CommandName == "Consultar_Click")
        {
            int usuario = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            dt =Control.ConsultarUsuario(usuario);

            divConsultar.Visible = true;
            divAcciones.Visible = false;
            divAdicionar.Visible = false;
            divPermisos.Visible = false;

            grvConsultarUsuario.DataSource = dt;
            grvConsultarUsuario.DataBind();
        }

        // Permite modificar los datos de un usuario 
        if (e.CommandName == "Modificar_Click")
        {
            int usuario = int.Parse(row.Cells[1].Text);
            DataTable dt = new DataTable();
            dt =Control.ConsultarUsuarioModificar(usuario);
            if (dt.Rows.Count > 0)
            {
                txtCedula.Text = dt.Rows[0]["con_Id"].ToString();
                txtPrimerNombre.Text = dt.Rows[0]["con_PrimerNombre"].ToString();
                txtSegundoNombre.Text = dt.Rows[0]["con_SegundoNombre"].ToString();
                txtPrimerApellido.Text = dt.Rows[0]["con_PrimerApellido"].ToString();
                txtSegundoApellido.Text = dt.Rows[0]["con_SegundoApellido"].ToString();
                ddlDepartamento.Items.FindByText(dt.Rows[0]["dep_Nombre"].ToString()).Selected = true;
                ddlDepartamento_SelectedIndexChanged(sender, e);
                ddlCiudad.Items.FindByText(dt.Rows[0]["ciu_Nombre"].ToString()).Selected = true;
                ddlAgencia.Items.FindByText(dt.Rows[0]["age_Nombre"].ToString()).Selected = true;
                ddlCargo.Items.FindByText(dt.Rows[0]["car_Nombre"].ToString()).Selected = true;
                ddlNivel.Items.FindByText(dt.Rows[0]["niv_Nombre"].ToString()).Selected = true;
                txtUsuario.Text = dt.Rows[0]["con_Usuario"].ToString();
                txtContrasena.Text = dt.Rows[0]["con_Password"].ToString();
                ddlEstado.Items.FindByText(dt.Rows[0]["est_Nombre"].ToString()).Selected = true;
            }

            divAdicionar.Visible = true;
            titleAdicionar.Visible = false;
            btnGuardar.Visible = false;
            divAcciones.Visible = false;
            divConsultar.Visible = false;
            divPermisos.Visible = false;
            grvConsultarUsuario.DataSource = dt;
            grvConsultarUsuario.DataBind();
        }

        // Permite asignar las restricciones del sistema para un usuario
        if (e.CommandName == "Asignar_Click")
        {
            int con_Id = int.Parse(row.Cells[1].Text);
            Session["con_Id"] = con_Id;
            lblConUsuario.Text = "Nombre: " + row.Cells[2].Text;
            lblNombre.Text = "Usuario: "+row.Cells[3].Text;
            txtPerId.Text = row.Cells[7].Text;

            DataTable dt = new DataTable();
            dt = Control.ListarFormularioAsignados();

            divPermisos.Visible = true;
            divAcciones.Visible = false;
            divAdicionar.Visible = false;
            divConsultar.Visible = false;
        }

        // Permite eliminar un usuario 
        if (e.CommandName == "Eliminar_Click")
        {
            int usuario = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            dt = Control.EliminarUsuario(usuario);
            Response.RedirectToRoute("gestionUsuarios");
        }
    }

    #endregion Acciones tabla principal

    #region Asignación de restricciones de usuario

    // Permite cargar la lista de menus en un ddl
    protected void ddlFormulario_SelectedIndexChanged(object sender, EventArgs e)
    {
        int con_Id = int.Parse(Session["con_Id"].ToString());
        string ddlFormSel = ddlFormulario.SelectedValue;
        Session["ddlFormSel"] = ddlFormSel;

        if (ddlFormSel != "")
        {
            DataTable dt = new DataTable();
            dt = Control.ListarBotonesFormulario(ddlFormulario.SelectedValue);
            ddlBotones.DataTextField = "btn_Nombre";
            ddlBotones.DataValueField = "btn_Id"; 
            ddlBotones.DataSource = dt;
            ddlBotones.DataBind();
            ddlBotones.Items.Insert(0, new ListItem("", ""));
            cargarBotonesAsignados(int.Parse(Session["con_Id"].ToString()), Session["ddlFormSel"].ToString());
        }
        else
        {
            ddlBotones.Items.Clear();
        }
    }
   
    // Permite cargar la lista de botonoes que fueron asignados al menu seleccionado
    private void cargarBotonesAsignados(int con_Id, string ddlFormSel)
    {
        DataTable dtBtn = new DataTable();
        dtBtn = Control.ListarBotonesUsuario(con_Id, ddlFormSel);
        ltv.DataSource = dtBtn;
        ltv.DataBind();
    }

    // Permite visualizar cada una de las restricciones que se van guardando 
    protected void listView_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int con_Id = int.Parse(Session["con_Id"].ToString());

        if (e.CommandName == "btnEliminar_Click")
        {
            int menBtn_Id = int.Parse(e.CommandArgument.ToString());
            int registros = Control.EliminarBotonUsuario(con_Id, menBtn_Id);
            if(registros <= 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El permiso no pudo ser eliminado.');", true); 
            }
            else 
            { 
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Permiso Eliminado.');", true);
            
            }
            if (Session["con_Id"] != null && Session["ddlFormSel"] != null)
            {
                cargarBotonesAsignados(int.Parse(Session["con_Id"].ToString()), Session["ddlFormSel"].ToString());
            }
        }
    }

    // Permite guardar la restricción en la base datos
    public void btnAsignar_Click(object sender, EventArgs e)
    {
        if (ddlFormulario.Text != "" && ddlBotones.Text != "")
        {
            int per_Id = int.Parse(txtPerId.Text);
            int registros = Control.AsignarPermisoUsuario(per_Id, ddlFormulario.SelectedValue , ddlBotones.SelectedValue);
            if (registros <= 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El permiso ya existe para este perfil.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Permiso asignado.');", true);
            }
            if (Session["con_Id"] != null && Session["ddlFormSel"] != null)
            {
                cargarBotonesAsignados(int.Parse(Session["con_Id"].ToString()), Session["ddlFormSel"].ToString());
            }
        }
    }

    #endregion Asignación de restricciones de usuario

    #region Adicionar y modificar usuario

    // Permite abrir el formulario para adicionar un usuario nuevo
    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        divAdicionar.Visible = true;
        titleModificar.Visible = false;
        btnModificar.Visible = false;
        divAcciones.Visible = false;
        divConsultar.Visible = false;
        divPermisos.Visible = false;
    }

    // Guarda el usuario en ula base de datos
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (txtCedula.Text != "" & txtPrimerNombre.Text != "" & txtPrimerApellido.Text != "" & txtSegundoApellido.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "" & ddlAgencia.Text != ""
            & ddlCargo.Text != "" & ddlNivel.Text != "" & txtUsuario.Text != "" & txtContrasena.Text != "" & ddlEstado.Text != "")
        {
            int registros = Control.InsertarUsuario(txtCedula.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, 
                int.Parse(ddlDepartamento.SelectedValue.ToString()), int.Parse(ddlCiudad.SelectedValue.ToString()), int.Parse(ddlAgencia.SelectedValue.ToString()),
                int.Parse(ddlCargo.SelectedValue.ToString()), int.Parse(ddlNivel.SelectedValue.ToString()), txtUsuario.Text, txtContrasena.Text, int.Parse(ddlEstado.SelectedValue.ToString()));

            if(registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Usuario guardado." + "');window.location.replace('/control/usuarios')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El usuario ya existe, por favor validar" + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "faltan campos por llenar" + "');", true);
        }
    }

    // Permite modificar los datos de usuario
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (txtCedula.Text != "" & txtPrimerNombre.Text != "" & txtPrimerApellido.Text != "" & txtSegundoApellido.Text != "" & ddlDepartamento.Text != "" & ddlCiudad.Text != "" 
            & ddlAgencia.Text != "" & ddlCargo.Text != "" & ddlNivel.Text != "" & txtUsuario.Text != "" & txtContrasena.Text != "" & ddlEstado.Text != "")
        {
            int registros = Control.ModificarUsuario(txtCedula.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, int.Parse(ddlDepartamento.SelectedValue.ToString()),
                int.Parse(ddlCiudad.SelectedValue.ToString()), int.Parse(ddlAgencia.SelectedValue.ToString()), int.Parse(ddlCargo.SelectedValue.ToString()), int.Parse(ddlNivel.SelectedValue.ToString()),
                txtUsuario.Text, txtContrasena.Text, int.Parse(ddlEstado.SelectedValue.ToString()));
            
            if (registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Usuario modificado." + "');window.location.replace('/control/usuarios')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "El usuario no fue modificado" + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "faltan campos por llenar" + "');", true);
        }
    }

    // Permite devolverse a el formulario anterior
    public void btnSalir_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("gestionUsuarios");
    }

    #endregion Adicionar y modificar usuario

}