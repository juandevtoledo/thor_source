using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarOcupacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            ListarOcupaciones();
            formOcupacion.Visible = false;
        }

        buscador.Visible = true;
        titleAcciones.Visible = true;
        titleModificar.Visible = false;
        titleAdicionar.Visible = false;

    }

    /// <summary>
    /// Lista todas las ocupaciones en el gridview de administración
    /// </summary>
    protected void ListarOcupaciones()
    {
        DataTable dt = new DataTable();
        dt = AdministrarOcupacion.ListarOcupaciones();
        grvAdminOcupacion.DataSource = dt;
        grvAdminOcupacion.DataBind();
    }

    protected void grvAdminOcupacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminOcupacion.PageIndex = e.NewPageIndex;
        ListarOcupaciones();
    }

    protected void grvAdminOcupacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminOcupacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminOcupacion.Rows[(index)];

            if (e.CommandName == "Modificar_Click")
            {
                long ocupacionIdentificador = long.Parse(row.Cells[1].Text);
                txtOcupacionIdentificador.Text = ocupacionIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarOcupacion.ConsultarOcupacionModificar(ocupacionIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtOcupacionNombre.Text = dt.Rows[0]["ocu_Nombre"].ToString();
                }
    

                //Muestra y oculta los controles necesarios
                titleModificar.Visible = true;
                buscador.Visible = false;
                titleAcciones.Visible = false;
                titleAdicionar.Visible = false;
                formOcupacion.Visible = true;
                tablaOcupaciones.Visible = false;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long ocupacionIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarOcupacion.EliminarOcupacion(ocupacionIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarOcupaciones();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        //Muestra y oculta los controles necesarios
        titleModificar.Visible = false;
        buscador.Visible = false;
        titleAcciones.Visible = false;
        titleAdicionar.Visible = true;

        formOcupacion.Visible = true;
        tablaOcupaciones.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string ocupacionNombre = null;
            if (txtOcupacionNombre.Text != "")
                ocupacionNombre = txtOcupacionNombre.Text;

            AdministrarOcupacion.InsertarOcupacion(ocupacionNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formOcupacion.Visible = false;
            tablaOcupaciones.Visible = true;

            LimpiarFormulario();
            ListarOcupaciones();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            string ocupacionNombre = null;
            if (txtOcupacionNombre.Text != "")
                ocupacionNombre = txtOcupacionNombre.Text;

            AdministrarOcupacion.ModificarOcupacion(long.Parse(txtOcupacionIdentificador.Text), ocupacionNombre);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formOcupacion.Visible = false;
            tablaOcupaciones.Visible = true;

            LimpiarFormulario();
            ListarOcupaciones();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        }
    }

    /// <summary>
    /// Limpia el formulario de adición/modificación
    /// </summary>
    private void LimpiarFormulario()
    {
        txtOcupacionNombre.Text = string.Empty;
        txtOcupacionIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarOcupacion.aspx");
        Response.RedirectToRoute("gestionOcupaciones");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int id = 0;
        string nombre = "";

        if (txtBuscarId.Text != "")
        {
            id = int.Parse(txtBuscarId.Text);
        }

        if (txtBuscarNombre.Text != "")
        {
            nombre = txtBuscarNombre.Text;
        }

        DataTable dt = AdministrarOcupacion.BuscarOcupacion(id, nombre);
        grvAdminOcupacion.DataSource = dt;
        grvAdminOcupacion.DataBind();

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarOcupacion.aspx");
        Response.RedirectToRoute("gestionOcupaciones");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

}
