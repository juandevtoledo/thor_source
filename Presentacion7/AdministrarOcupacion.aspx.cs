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
            botonAtras.Visible = false;
        }
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

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminOcupacion.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long ocupacionIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarOcupacion.ConsultarOcupacion(ocupacionIdentificador);
                grvConsultarOcupacion.DataSource = dt;
                grvConsultarOcupacion.DataBind();

                //Muestra y oculta los controles necesarios
                tablaOcupaciones.Visible = false;
                tablaOcupacion.Visible = true;
                botonAtras.Visible = true;
            }

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
                grvConsultarOcupacion.DataSource = dt;
                grvConsultarOcupacion.DataBind();

                //Muestra y oculta los controles necesarios
                formOcupacion.Visible = true;
                tablaOcupaciones.Visible = false;
                tablaOcupacion.Visible = false;
                botonAtras.Visible = true;
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
        formOcupacion.Visible = true;
        tablaOcupaciones.Visible = false;
        tablaOcupacion.Visible = false;
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
        tablaOcupaciones.Visible = true;
        tablaOcupacion.Visible = false;
        formOcupacion.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarOcupaciones();
    }
}
