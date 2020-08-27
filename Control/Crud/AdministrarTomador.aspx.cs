using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarTomador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarTomadores();
            formTomador.Visible = false;
            botonAtras.Visible = false;
        }
    }

    /// <summary>
    /// Lista todos los tomadores en el gridview de administración
    /// </summary>
    protected void ListarTomadores()
    {
        DataTable dt = new DataTable();
        dt = AdministrarTomador.ListarTomadores();
        grvAdminTomador.DataSource = dt;
        grvAdminTomador.DataBind();
    }

    protected void grvAdminTomador_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminTomador.PageIndex = e.NewPageIndex;
        ListarTomadores();
    }

    protected void grvAdminTomador_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminTomador_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminTomador.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long tomadorIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTomador.ConsultarTomador(tomadorIdentificador);
                grvConsultarTomador.DataSource = dt;
                grvConsultarTomador.DataBind();

                //Muestra y oculta los controles necesarios
                tablaTomadores.Visible = false;
                tablaTomador.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long tomadorIdentificador = long.Parse(row.Cells[1].Text);
                txtTomadorIdentificador.Text = tomadorIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarTomador.ConsultarTomadorModificar(tomadorIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtTomadorIdentificacion.Text = dt.Rows[0]["tom_Identificacion"].ToString();
                    txtTomadorNombre.Text = dt.Rows[0]["tom_Nombre"].ToString();
                    txtTomadorDireccion.Text = dt.Rows[0]["tom_Direccion"].ToString();
                    txtTomadorTelefono.Text = dt.Rows[0]["tom_Telefono"].ToString();
                    txtTomadorRepresentanteLegal.Text = dt.Rows[0]["tom_RepresentanteLegal"].ToString();
                }
                grvConsultarTomador.DataSource = dt;
                grvConsultarTomador.DataBind();

                //Muestra y oculta los controles necesarios
                formTomador.Visible = true;
                tablaTomadores.Visible = false;
                tablaTomador.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long tomadorIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarTomador.EliminarTomador(tomadorIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarTomadores();
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
        formTomador.Visible = true;
        tablaTomadores.Visible = false;
        tablaTomador.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long tomadorIdentificacion;
            string tomadorNombre;
            string tomadorDireccion = null;
            string tomadorTelefono = null;
            string tomadorRepresentanteLegal = null;
            tomadorIdentificacion = long.Parse(txtTomadorIdentificacion.Text);
            tomadorNombre = txtTomadorNombre.Text;
            if (txtTomadorDireccion.Text != "")
                tomadorDireccion = txtTomadorDireccion.Text;
            if (txtTomadorTelefono.Text != "")
                tomadorTelefono = txtTomadorTelefono.Text;
            if (txtTomadorRepresentanteLegal.Text != "")
                tomadorRepresentanteLegal = txtTomadorRepresentanteLegal.Text;

            AdministrarTomador.InsertarTomador(tomadorIdentificacion, tomadorNombre, tomadorDireccion, tomadorTelefono, tomadorRepresentanteLegal);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTomador.Visible = false;
            tablaTomadores.Visible = true;

            LimpiarFormulario();
            ListarTomadores();
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
            long tomadorIdentificacion;
            string tomadorNombre;
            string tomadorDireccion = null;
            string tomadorTelefono = null;
            string tomadorRepresentanteLegal = null;
            tomadorIdentificacion = long.Parse(txtTomadorIdentificacion.Text);
            tomadorNombre = txtTomadorNombre.Text;
            if (txtTomadorDireccion.Text != "")
                tomadorDireccion = txtTomadorDireccion.Text;
            if (txtTomadorTelefono.Text != "")
                tomadorTelefono = txtTomadorTelefono.Text;
            if (txtTomadorRepresentanteLegal.Text != "")
                tomadorRepresentanteLegal = txtTomadorRepresentanteLegal.Text;

            AdministrarTomador.ModificarTomador(long.Parse(txtTomadorIdentificador.Text), tomadorIdentificacion, tomadorNombre, tomadorDireccion, tomadorTelefono, tomadorRepresentanteLegal);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formTomador.Visible = false;
            tablaTomadores.Visible = true;

            LimpiarFormulario();
            ListarTomadores();
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
        txtTomadorIdentificacion.Text = string.Empty;
        txtTomadorNombre.Text = string.Empty;
        txtTomadorDireccion.Text = string.Empty;
        txtTomadorTelefono.Text = string.Empty;
        txtTomadorRepresentanteLegal.Text = string.Empty;
        txtTomadorIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaTomadores.Visible = true;
        tablaTomador.Visible = false;
        formTomador.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarTomadores();
    }
}
