using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarPolizaLocalidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarPolizasLocalidades();
            formPolizaLocalidad.Visible = false;
            botonAtras.Visible = false;

            DataTable dtPolizas = new DataTable();
            dtPolizas = AdministrarPoliza.ListarPolizas();
            ddlPoliza.DataTextField = "NUMERO";
            ddlPoliza.DataValueField = "ID";
            ddlPoliza.DataSource = dtPolizas;
            ddlPoliza.DataBind();
            ddlPoliza.Items.Insert(0, new ListItem("Seleccione", ""));
            DataTable dtDepartamentos = new DataTable();
            dtDepartamentos = AdministrarDepartamento.mostrarDepartamento();
            ddlDepartamento.DataTextField = "dep_Nombre";
            ddlDepartamento.DataValueField = "dep_Id";
            ddlDepartamento.DataSource = dtDepartamentos;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", ""));
        }
    }

    /// <summary>
    /// Lista todas las polizas por localidades en el gridview de administración
    /// </summary>
    protected void ListarPolizasLocalidades()
    {
        DataTable dt = new DataTable();
        dt = AdministrarPolizaLocalidad.ListarPolizasLocalidades();
        grvAdminPolizaLocalidad.DataSource = dt;
        grvAdminPolizaLocalidad.DataBind();
    }

    protected void grvAdminPolizaLocalidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminPolizaLocalidad.PageIndex = e.NewPageIndex;
        ListarPolizasLocalidades();
    }

    protected void grvAdminPolizaLocalidad_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminPolizaLocalidad_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminPolizaLocalidad.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPolizaLocalidad.ConsultarPolizaLocalidad(PolizaLocalidadIdentificador);
                grvConsultarPolizaLocalidad.DataSource = dt;
                grvConsultarPolizaLocalidad.DataBind();

                //Muestra y oculta los controles necesarios
                tablaPolizasLocalidades.Visible = false;
                tablaPolizaLocalidad.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);
                txtPolizaLocalidadIdentificador.Text = PolizaLocalidadIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPolizaLocalidad.ConsultarPolizaLocalidadModificar(PolizaLocalidadIdentificador);
                if (dt.Rows.Count > 0)
                {
                    ddlPoliza.SelectedValue = dt.Rows[0]["pol_Id"].ToString();
                    ddlDepartamento.SelectedValue = dt.Rows[0]["dep_Id"].ToString();
                }
                grvConsultarPolizaLocalidad.DataSource = dt;
                grvConsultarPolizaLocalidad.DataBind();

                //Muestra y oculta los controles necesarios
                formPolizaLocalidad.Visible = true;
                tablaPolizasLocalidades.Visible = false;
                tablaPolizaLocalidad.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long PolizaLocalidadIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarPolizaLocalidad.EliminarPolizaLocalidad(PolizaLocalidadIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarPolizasLocalidades();
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
        formPolizaLocalidad.Visible = true;
        tablaPolizasLocalidades.Visible = false;
        tablaPolizaLocalidad.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long PolizaIdentificador;
            long DepartamentoIdentificador;
            PolizaIdentificador = long.Parse(ddlPoliza.SelectedValue);
            DepartamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);

            AdministrarPolizaLocalidad.InsertarPolizaLocalidad(PolizaIdentificador, DepartamentoIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPolizaLocalidad.Visible = false;
            tablaPolizasLocalidades.Visible = true;

            LimpiarFormulario();
            ListarPolizasLocalidades();
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
            long PolizaIdentificador;
            long DepartamentoIdentificador;
            PolizaIdentificador = long.Parse(ddlPoliza.SelectedValue);
            DepartamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);

            AdministrarPolizaLocalidad.ModificarPolizaLocalidad(long.Parse(txtPolizaLocalidadIdentificador.Text), PolizaIdentificador, DepartamentoIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPolizaLocalidad.Visible = false;
            tablaPolizasLocalidades.Visible = true;

            LimpiarFormulario();
            ListarPolizasLocalidades();
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
        ddlPoliza.SelectedValue = string.Empty;
        ddlDepartamento.SelectedValue = string.Empty;
        txtPolizaLocalidadIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaPolizasLocalidades.Visible = true;
        tablaPolizaLocalidad.Visible = false;
        formPolizaLocalidad.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarPolizasLocalidades();
    }
}
