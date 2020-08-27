using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarPlantel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarPlanteles();
            formPlantel.Visible = false;
            botonAtras.Visible = false;

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
    /// Lista todos los planteles en el gridview de administración
    /// </summary>
    protected void ListarPlanteles()
    {
        DataTable dt = new DataTable();
        dt = AdministrarPlantel.ListarPlanteles();
        grvAdminPlantel.DataSource = dt;
        grvAdminPlantel.DataBind();
    }

    protected void grvAdminPlantel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminPlantel.PageIndex = e.NewPageIndex;
        ListarPlanteles();
    }

    protected void grvAdminPlantel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminPlantel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminPlantel.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long plantelidentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPlantel.ConsultarPlantel(plantelidentificador);
                grvConsultarPlantel.DataSource = dt;
                grvConsultarPlantel.DataBind();

                //Muestra y oculta los controles necesarios
                tablaPlanteles.Visible = false;
                tablaPlantel.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long plantelidentificador = long.Parse(row.Cells[1].Text);
                txtPlantelidentificador.Text = plantelidentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarPlantel.ConsultarPlantelModificar(plantelidentificador);
                if (dt.Rows.Count > 0)
                {
                    txtPlantelNombre.Text = dt.Rows[0]["pla_Nombre"].ToString();
                    ddlDepartamento.SelectedValue = dt.Rows[0]["dep_Id"].ToString();
                }
                grvConsultarPlantel.DataSource = dt;
                grvConsultarPlantel.DataBind();

                //Muestra y oculta los controles necesarios
                formPlantel.Visible = true;
                tablaPlanteles.Visible = false;
                tablaPlantel.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long plantelidentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarPlantel.EliminarPlantel(plantelidentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarPlanteles();
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
        formPlantel.Visible = true;
        tablaPlanteles.Visible = false;
        tablaPlantel.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string plantelNombre = null;
            long departamentoIdentificador;
            if (txtPlantelNombre.Text != "")
                plantelNombre = txtPlantelNombre.Text;
            departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);

            AdministrarPlantel.InsertarPlantel(plantelNombre, departamentoIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPlantel.Visible = false;
            tablaPlanteles.Visible = true;

            LimpiarFormulario();
            ListarPlanteles();
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
            string plantelNombre = null;
            long departamentoIdentificador;
            if (txtPlantelNombre.Text != "")
                plantelNombre = txtPlantelNombre.Text;
            departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);

            AdministrarPlantel.ModificarPlantel(long.Parse(txtPlantelidentificador.Text), plantelNombre, departamentoIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formPlantel.Visible = false;
            tablaPlanteles.Visible = true;

            LimpiarFormulario();
            ListarPlanteles();
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
        txtPlantelNombre.Text = string.Empty;
        ddlDepartamento.SelectedValue = string.Empty;
        txtPlantelidentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaPlanteles.Visible = true;
        tablaPlantel.Visible = false;
        formPlantel.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarPlanteles();
    }
}
