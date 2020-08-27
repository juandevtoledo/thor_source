using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        buscador.Visible = true;
        titleAcciones.Visible = true;   
        titleModificar.Visible = false;
        titleAdicionar.Visible = false;
            

        if (!IsPostBack)
        {
            ListarProductos();
            formProducto.Visible = false;
            


            DataTable dtCompanias = new DataTable();
            dtCompanias = AdministrarCompania.ListarCompanias();
            ddlCompania.DataTextField = "com_Nombre"; 
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dtCompanias;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("Seleccione", ""));
        }
        
    }

    protected void ListarProductos()
    {
        DataTable dt = new DataTable();
        dt = AdministrarProducto.ListarProductos();
        grvAdminProducto.DataSource = dt;
        grvAdminProducto.DataBind();
    }

    protected void grvAdminProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminProducto.PageIndex = e.NewPageIndex;
        ListarProductos();
    }

    protected void grvAdminProducto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((grvAdminProducto.Rows.Count < grvAdminProducto.PageSize) && (grvAdminProducto.Rows.Count + grvAdminProducto.PageSize * grvAdminProducto.PageIndex < ((DataTable)(grvAdminProducto.DataSource)).Rows.Count))

            e.Row.Cells[3].Visible = true;
    }


    protected void grvAdminProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;


        if (e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminProducto.Rows[(index)];
        

        if (e.CommandName == "Modificar_Click")
        {
            int productoID = int.Parse(row.Cells[1].Text);
            txtProductoID.Text = productoID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarProducto.ConsultarProductoModificar(productoID);
            if (dt.Rows.Count > 0)
            {
                ddlCompania.SelectedValue = dt.Rows[0]["com_Id"].ToString();
                txtProductoNombre.Text = dt.Rows[0]["Producto"].ToString();
                txtMesesGraciaProducto.Text = dt.Rows[0]["Meses gracia"].ToString();
                txtCumulo.Text = dt.Rows[0]["Cumulo"].ToString();
                txtMesesRecuperacion.Text = dt.Rows[0]["Meses de recuperación"].ToString();
                txtPrioridadPago.Text = dt.Rows[0]["Prioridad pago"].ToString();
                txtPrioridadDevolucion.Text = dt.Rows[0]["Prioridad devolución"].ToString();
                ddlEstadoProducto.SelectedValue = dt.Rows[0]["pro_Estado"].ToString();


            }
            buscador.Visible = false;
            formProducto.Visible = true;
            tablaProductos.Visible = false;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            titleModificar.Visible = true;
            titleAcciones.Visible = false;
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int productoID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarProducto.EliminarProducto(productoID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarProductos();
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Valide la información ingresada');", true);
            }
            
        }


    }


    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        buscador.Visible = false;
        formProducto.Visible = true;
        tablaProductos.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
        titleAcciones.Visible = false;
        titleAdicionar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
       
        int ? mesesGracia = 0 ;
        int ? estado = 0;

        if (txtMesesGraciaProducto.Text == string.Empty)
            mesesGracia = null;
        else
            mesesGracia = Convert.ToInt32(txtMesesGraciaProducto.Text);
        if (ddlEstadoProducto.SelectedValue == string.Empty)
            estado = null;
        else
            estado = Convert.ToInt32(ddlEstadoProducto.SelectedValue);

        try {
            AdministrarProducto.InsertarProducto(Convert.ToInt32(ddlCompania.SelectedValue), txtProductoNombre.Text, mesesGracia, int.Parse(txtCumulo.Text), int.Parse(txtMesesRecuperacion.Text), int.Parse(txtPrioridadPago.Text), int.Parse(txtPrioridadDevolucion.Text), estado);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formProducto.Visible = false;
            tablaProductos.Visible = true;
            LimpiarFormulario();
            ListarProductos();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Valide la información ingresada');", true);
            buscador.Visible = false;
        }


     
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        int? mesesGracia = 0;
        int? estado = 0;

        if (txtMesesGraciaProducto.Text == string.Empty)
            mesesGracia = null;
        else
            mesesGracia = Convert.ToInt32(txtMesesGraciaProducto.Text);
        if (ddlEstadoProducto.SelectedValue == string.Empty)
            estado = null;
        else
            estado = Convert.ToInt32(ddlEstadoProducto.SelectedValue);

        try
        {
            AdministrarProducto.ModificarProducto(Convert.ToInt32(txtProductoID.Text), Convert.ToInt32(ddlCompania.SelectedValue), txtProductoNombre.Text, mesesGracia, int.Parse(txtCumulo.Text), int.Parse(txtMesesRecuperacion.Text), int.Parse(txtPrioridadPago.Text), int.Parse(txtPrioridadDevolucion.Text), estado);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formProducto.Visible = false;
            tablaProductos.Visible = true;
            LimpiarFormulario();
            ListarProductos();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Valide la información ingresada');", true);
            buscador.Visible = false;
        }

    }

    private void LimpiarFormulario()
    {
        ddlCompania.SelectedValue = string.Empty;
        txtProductoID.Text = string.Empty;
        txtProductoNombre.Text = string.Empty;
        txtMesesGraciaProducto.Text = string.Empty;
        ddlEstadoProducto.SelectedValue = string.Empty;

    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Presentacion7/AdministrarProducto.aspx");
    }


    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int id = 0;
        string compania = "";
        string producto = "";
        string estado = "";

        if (txtBuscarId.Text != "")
        {
            id = int.Parse(txtBuscarId.Text);
        }

        if (txtBuscarCompania.Text != "")
        {
            compania = txtBuscarCompania.Text;
        }

        if (txtBuscarProducto.Text != "")
        {
            producto = txtBuscarProducto.Text;
        }

        if (txtBuscarEstado.Text != "")
        {
            estado = txtBuscarEstado.Text;
        }

        DataTable dt = AdministrarProducto.BuscarProducto(id, compania, producto, estado);
        grvAdminProducto.DataSource = dt;
        grvAdminProducto.DataBind();

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Presentacion7/AdministrarProducto.aspx");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================
}