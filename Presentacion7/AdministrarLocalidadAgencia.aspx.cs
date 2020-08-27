using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarLocalidadAgencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarLocalidadesAgencias();
            formLocalidadAgencia.Visible = false;
            botonAtras.Visible = false;

            DataTable dtDepartamentos = new DataTable();
            dtDepartamentos = AdministrarDepartamento.mostrarDepartamento();
            ddlDepartamento.DataTextField = "dep_nombre";
            ddlDepartamento.DataValueField = "dep_id";
            ddlDepartamento.DataSource = dtDepartamentos;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtAgencias = new DataTable();
            dtAgencias = AdministrarAgencia.ListarAgencias();
            ddlAgencia.DataTextField = "NOMBRE";
            ddlAgencia.DataValueField = "ID";
            ddlAgencia.DataSource = dtAgencias;
            ddlAgencia.DataBind();
            ddlAgencia.Items.Insert(0, new ListItem("Seleccione", ""));
        }
    }

    /// <summary>
    /// Lista todas las localidades por agencia en el gridview de administración
    /// </summary>
    protected void ListarLocalidadesAgencias()
    {
        DataTable dt = new DataTable();
        dt = AdministrarLocalidadAgencia.ListarLocalidadesAgencias();
        grvAdminLocalidadAgencia.DataSource = dt;
        grvAdminLocalidadAgencia.DataBind();
    }

    protected void grvAdminLocalidadAgencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminLocalidadAgencia.PageIndex = e.NewPageIndex;
        ListarLocalidadesAgencias();
    }

    protected void grvAdminLocalidadAgencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminLocalidadAgencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminLocalidadAgencia.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarLocalidadAgencia.ConsultarLocalidadAgencia(PolizaLocalidadIdentificador);
                grvConsultarLocalidadAgencia.DataSource = dt;
                grvConsultarLocalidadAgencia.DataBind();

                //Muestra y oculta los controles necesarios
                tablaLocalidadesAgencias.Visible = false;
                tablaLocalidadAgencia.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);
                txtPolizaLocalidadIdentificador.Text = PolizaLocalidadIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarLocalidadAgencia.ConsultarLocalidadAgenciaModificar(PolizaLocalidadIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlDepartamento.SelectedValue = dt.Rows[0]["dep_Id"].ToString();
                    ddlAgencia.SelectedValue = dt.Rows[0]["age_Id"].ToString();
                }
                grvConsultarLocalidadAgencia.DataSource = dt;
                grvConsultarLocalidadAgencia.DataBind();

                //Muestra y oculta los controles necesarios
                formLocalidadAgencia.Visible = true;
                tablaLocalidadesAgencias.Visible = false;
                tablaLocalidadAgencia.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarLocalidadAgencia.EliminarLocalidadAgencia(PolizaLocalidadIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarLocalidadesAgencias();
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
        formLocalidadAgencia.Visible = true;
        tablaLocalidadesAgencias.Visible = false;
        tablaLocalidadAgencia.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long DepartamentoIdentificador;
            long? AgenciaIdentificador = null;
            DepartamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlAgencia.SelectedValue != "")
                AgenciaIdentificador = long.Parse(ddlAgencia.SelectedValue);

            AdministrarLocalidadAgencia.InsertarLocalidadAgencia(DepartamentoIdentificador, AgenciaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formLocalidadAgencia.Visible = false;
            tablaLocalidadesAgencias.Visible = true;

            LimpiarFormulario();
            ListarLocalidadesAgencias();
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
            long DepartamentoIdentificador;
            long? AgenciaIdentificador = null;
            DepartamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlAgencia.SelectedValue != "")
                AgenciaIdentificador = long.Parse(ddlAgencia.SelectedValue);

            AdministrarLocalidadAgencia.ModificarLocalidadAgencia(long.Parse(txtPolizaLocalidadIdentificador.Text), DepartamentoIdentificador, AgenciaIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formLocalidadAgencia.Visible = false;
            tablaLocalidadesAgencias.Visible = true;

            LimpiarFormulario();
            ListarLocalidadesAgencias();
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
        ddlDepartamento.SelectedValue = string.Empty;
        ddlAgencia.SelectedValue = string.Empty;
        txtPolizaLocalidadIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaLocalidadesAgencias.Visible = true;
        tablaLocalidadAgencia.Visible = false;
        formLocalidadAgencia.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarLocalidadesAgencias();
    }
}
