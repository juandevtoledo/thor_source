using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CierreSistema : System.Web.UI.Page
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

    public DAOPagos objPagos = new DAOPagos();

    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {

            ListarCierres();
            divAdicionar.Visible = false;
           
            DataTable dt = new DataTable();

            //Listar Compañias
            dt = objPagos.ConsultarCompaniasGenerales();
            ddlCompania.DataTextField = "com_Nombre"; 
            ddlCompania.DataValueField = "com_Id"; 
            ddlCompania.DataSource = dt;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", ""));

            //Listar Compañias para filtar
            dt = objPagos.ConsultarCompaniasGenerales();
            ddlBuscarCompañia.DataTextField = "com_Nombre";
            ddlBuscarCompañia.DataValueField = "com_Id";
            ddlBuscarCompañia.DataSource = dt;
            ddlBuscarCompañia.DataBind();
            ddlBuscarCompañia.Items.Insert(0, new ListItem("Seleccione", ""));

            //Listar Meses
            dt = DAOAdministrarNovedades.ConsultarMesNovedadesSinEnviar();
            ddlMes.DataTextField = "mes_Nombre"; 
            ddlMes.DataValueField = "mes_Id"; 
            ddlMes.DataSource = dt;
            ddlMes.DataBind();
            ddlMes.Items.Insert(0, new ListItem("Seleccione", ""));

            //Listar Año
            dt = DAOAdministrarNovedades.ConsultarAnioNovedadesSinEnviar();
            ddlAnio.DataTextField = "anio_Numero"; 
            ddlAnio.DataValueField = "anio_Numero"; 
            ddlAnio.DataSource = dt;
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new ListItem("Seleccione", ""));

            // Listar Estado
            dt = DAOCierreSistema.spConsultarEstadoCierreSistema();
            ddlEstado.DataTextField = "estCie_Nombre";
            ddlEstado.DataValueField = "estCie_Id";
            ddlEstado.DataSource = dt;
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Seleccione", ""));

            // Listar Agencias
            dt = DAOCierreSistema.ListarAgencias();
            ddlBuscarAgencia.DataTextField = "age_Nombre";
            ddlBuscarAgencia.DataValueField = "age_Id";
            ddlBuscarAgencia.DataSource = dt;
            ddlBuscarAgencia.DataBind();
            ddlBuscarAgencia.Items.Insert(0, new ListItem("Seleccione", ""));
        }   
    }

    protected void ddlCompania_SelectedIndexChanged(object sender, EventArgs e)
    {        
        DataTable dt = new DataTable();
        dt = DAOCierreSistema.ConsultarProductoPorCompania(int.Parse(ddlCompania.SelectedValue));
        ddlProducto.DataTextField = "pro_Nombre"; // Cargamos lo que aparece en el ddl
        ddlProducto.DataValueField = "pro_Id"; // Cargamos lo que vale por debajo
        ddlProducto.DataSource = dt;
        ddlProducto.DataBind();
        ddlProducto.Items.Insert(0, new ListItem("SELECCIONAR", ""));
    }

    protected void ddlBuscarCompania_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        dt = DAOCierreSistema.ConsultarProductoPorCompania(int.Parse(ddlBuscarCompañia.SelectedValue));
        ddlBuscarProducto.DataTextField = "pro_Nombre"; // Cargamos lo que aparece en el ddl
        ddlBuscarProducto.DataValueField = "pro_Id"; // Cargamos lo que vale por debajo
        ddlBuscarProducto.DataSource = dt;
        ddlBuscarProducto.DataBind();
        ddlBuscarProducto.Items.Insert(0, new ListItem("SELECCIONAR", ""));
    }

    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //para consultar la agencia por el producto se relacionan las tablas NewProducto, NewPoliza, NewPolizasLocalidad, NewAgencia
        dt = DAOCierreSistema.spListarAgencias();
        ddlAgencia.DataTextField = "age_Nombre"; // Cargamos lo que aparece en el ddl
        ddlAgencia.DataValueField = "age_Id"; // Cargamos lo que vale por debajo
        ddlAgencia.DataSource = dt;
        ddlAgencia.DataBind();
        ddlAgencia.Items.Insert(0, new ListItem("TODOS LAS AGENCIAS", "todo"));
    }


    ////buscador
    //protected void TxtBuscar_TextChanged(System.EventArgs e)
    //{

    //}

    protected void ListarCierres()
    {
        DataTable dt = new DataTable();
        dt = AdministrarCierreSistema.ListarCierres();
        
        

        //DataTable dtMostrar = new DataTable();
        //dtMostrar = dt.Clone();
        //dtMostrar = dt.Copy();

        //dtMostrar.Columns.RemoveAt(3);
        //dtMostrar.Columns.RemoveAt(4);
        //dtMostrar.Columns.RemoveAt(5);

        grvCierreSistema.DataSource = dt;
        grvCierreSistema.DataBind();


        foreach (GridViewRow row in grvCierreSistema.Rows)
        {
            if (row.Cells[10].Text == "ABIERTO")
            {
                ((LinkButton)row.FindControl("botonCerrar")).Visible = true;
                ((LinkButton)row.FindControl("botonAbrir")).Visible = false;
            }
            else
            {
                ((LinkButton)row.FindControl("botonCerrar")).Visible = false;
                ((LinkButton)row.FindControl("botonAbrir")).Visible = true;
            }         
        }      
    }

    protected void grvCierreSistema_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCierreSistema.PageIndex = e.NewPageIndex;
        ListarCierres();

    }

    protected void grvCierreSistema_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvCierreSistema.Rows.Count < grvCierreSistema.PageSize) && (grvCierreSistema.Rows.Count + grvCierreSistema.PageSize * grvCierreSistema.PageIndex < ((DataTable)(grvCierreSistema.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }



    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        divAdicionar.Visible = true;
        divAcciones.Visible = false;

    }
      

    public void btnCerrar_Click(object sender, EventArgs e)
    {

        divAdicionar.Visible = true;
        divAcciones.Visible = true;
    }

    public void btnInsertar_Click(object sender, EventArgs e)
    {
      
        if (ddlCompania.Text != "" & ddlProducto.Text != "" & ddlAgencia.Text != "" & ddlMes.Text != "" & ddlAnio.Text != "" & ddlEstado.Text != "")
        {
            AdministrarCierreSistema.InsertarCierreSistema(ddlCompania.Text, ddlProducto.Text, ddlAgencia.Text, ddlMes.Text, ddlAnio.Text, ddlEstado.Text);

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El cierre se adicionado con éxito');", true);
            //Response.Redirect("../Presentacion/CierreSistema.aspx");
            Response.RedirectToRoute("cierreSistema");
            
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
            

        }

    }

    public void btnAtras_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion/CierreSistema.aspx");
        Response.RedirectToRoute("cierreSistema");
    }

    protected void grvCierreSistema_RowCommand(object sender, GridViewCommandEventArgs e)

    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());

            GridViewRow row = grvCierreSistema.Rows[(index)];
        

                if (e.CommandName == "Cerrar_Click")
                {

                    int cierre = int.Parse(row.Cells[1].Text);
         
                    AdministrarCierreSistema.CerrarCierreSistema(cierre);

                    Response.RedirectToRoute("cierreSistema");
            
                }

                if (e.CommandName == "Abrir_Click")
                {
                    int cierre = int.Parse(row.Cells[1].Text);
                    int producto = int.Parse(row.Cells[4].Text);
                    int agencia = int.Parse(row.Cells[6].Text);
                    int mes = int.Parse(row.Cells[8].Text);
                    int anio = int.Parse(row.Cells[9].Text);

                    AdministrarCierreSistema.AbrirCierreSistema(cierre, producto, agencia, mes, anio);
                    Response.RedirectToRoute("cierreSistema");
                 }
        }
        catch { }

    }


    

}