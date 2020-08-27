using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_AdministrarMenu : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarMenu();
            ListarListas();
            
            divFormulario.Visible = false;
            divAsignar.Visible = false;
        }
    }

    #region Muestra los menús, carga las listas, crea pginación, buscador

    // Permite listar los menu del sistema
    public void ListarMenu()
    {
        DataTable dt = new DataTable();
        dt = Control.ListarMenu();
        grvAdminMenu.DataSource = dt;
        grvAdminMenu.DataBind();
    }

    // Carga las listas desplegables
    public void ListarListas()
    {
        DataTable dt = new DataTable();
        dt = Control.MostrarDependencia();
        ddlDependencia.DataTextField = "men_Nombre"; 
        ddlDependencia.DataValueField = "men_Id";
        ddlDependencia.DataSource = dt;
        ddlDependencia.DataBind();
        ddlDependencia.Items.Insert(0, new ListItem("", ""));
    }

    // Paginacion
    protected void grvAdminMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminMenu.PageIndex = e.NewPageIndex;
        ListarMenu();
    }

    // Paginación
    protected void grvAdminMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvAdminMenu.Rows.Count < grvAdminMenu.PageSize) && (grvAdminMenu.Rows.Count + grvAdminMenu.PageSize * grvAdminMenu.PageIndex < ((DataTable)(grvAdminMenu.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }

    // Permite buscar el menu según filtros seleccionados
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtBuscarMenu.Text != "")
        {
            DataTable dt = new DataTable();
            dt = DAOControl.BuscarPorMenu(txtBuscarMenu.Text);
            grvAdminMenu.DataSource = dt;
            grvAdminMenu.DataBind();
        }
        else if (txtBuscarDependencia.Text != "")
        {
            DataTable dt = new DataTable();
            dt = DAOControl.BuscarPordependencia(txtBuscarDependencia.Text);
            grvAdminMenu.DataSource = dt;
            grvAdminMenu.DataBind();  
        }
        else
        {
            ListarMenu();
            Response.RedirectToRoute("gestionMenus");
        }
    }

    // Limpia los campos para hacer una nueva busqueda
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtBuscarMenu.Text = "";
        txtBuscarDependencia.Text = "";
        ListarMenu();
    }

    #endregion Muestra los menús, carga las listas, crea pginación, buscador

    #region Acciones del menú

    protected void grvAdminMenu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ListarListas(); 
        int index = int.Parse(e.CommandArgument.ToString());

        GridViewRow row = grvAdminMenu.Rows[(index)];

        // Permite modificar los datos del menú
        if (e.CommandName == "Modificar_Click")
        {
            int menu = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            dt = Control.ConsultarMenu(menu);

            if (dt.Rows.Count > 0)
            {
                txtmen_Id.Text = dt.Rows[0]["men_Id"].ToString();
                txtNombre.Text = dt.Rows[0]["men_Nombre"].ToString();
                ddlDependencia.Items.FindByValue(dt.Rows[0]["men_dependencia"].ToString()).Selected = true;
                txtEnlace.Text = dt.Rows[0]["men_Enlace"].ToString();
                txtAlias.Text = dt.Rows[0]["men_Alias"].ToString();
                txtRuta.Text = dt.Rows[0]["men_Ruta"].ToString();
            }

            divFormulario.Visible = true;
            titleAdicionar.Visible = false;
            btnInsertar.Visible = false;
            divAsignar.Visible = false;
            divAcciones.Visible = false;
        }

        // Permite asignar los botones a cada uno de los formulario del menú
        if (e.CommandName == "Asignar_Click")
        {
            Session["men_Id"] = 0;
            int men_Id = int.Parse(row.Cells[1].Text);
            Session["men_Id"] = men_Id;
            lblMenu.Text = "Formulario: " + row.Cells[2].Text;

            DataTable dt = new DataTable();
            dt = Control.ConsultarBtnMenu(men_Id);

            ltv.DataSource = dt;
            ltv.DataBind();

            divAsignar.Visible = true;
            divFormulario.Visible = false;
            divAcciones.Visible = false;
        }

        // Permite eliminar cada uno de los menús del sistema
        if (e.CommandName == "Eliminar_Click")
        {
            int men_Id = int.Parse(row.Cells[1].Text);
            DataTable dt = new DataTable();
            dt = Control.EliminarMenu(men_Id);
        }
    }

    // Permite asignar botones a cada uno de los menu
    public void btnAsignarBtn_Click(object sender, EventArgs e)
    {
        if (txtNombreBtn.Text != "" && txtIdBtn.Text != "")
        {
            int registros = Control.AsignarBtnMenu(int.Parse(Session["men_Id"].ToString()),txtNombreBtn.Text, txtIdBtn.Text, txtIdPadre.Text);
            
            if(registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Botón asignado" + "'); window.location.replace('/control/menus')", true);
                Control.ConsultarBtnMenu(int.Parse(Session["men_Id"].ToString()));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El botón no pudo ser asignado.');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    // Permite listar los botones asignados a cada menú
    protected void listView_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarBtn_Click")
        {
            int btn_Id = int.Parse(e.CommandArgument.ToString());
            Control.EliminarBoton(btn_Id);
            Response.RedirectToRoute("gestionMenus");
        }
    }
    
    // Permite guardar la asignación de botones
    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        divFormulario.Visible = true;
        titleModificar.Visible = false;
        divAcciones.Visible = false;
        divAsignar.Visible = false;
        btnGuardar.Visible = false;
    }

    // Permite crear nuevos menus en el sistema
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        if (txtNombre.Text != "" & ddlDependencia.Text != "" & txtEnlace.Text != "" & txtAlias.Text != "" & txtRuta.Text != "")
        {
            Control.InsertarMenu(txtNombre.Text, ddlDependencia.Text, txtEnlace.Text, txtAlias.Text, txtRuta.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Menú guardado.');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    // Permite Guardar las modificaciones que se le aplican a cada menú
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (txtNombre.Text != "" & ddlDependencia.Text != "" & txtEnlace.Text != "" & txtAlias.Text != "" & txtRuta.Text != "")
        {
            Control.ModificarMenu(txtmen_Id.Text, txtNombre.Text, ddlDependencia.Text, txtEnlace.Text, txtAlias.Text, txtRuta.Text);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Menú modificado.');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    // Permite devolverse aun formulario anterior
    public void btnSalir_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("gestionMenus");
    }

    #endregion Acciones del menú

}