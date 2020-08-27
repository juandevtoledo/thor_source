using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarAgencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarAgencias();
            formAgencia.Visible = false;
            botonAtras.Visible = false;
            DataTable dtDepartamentos = new DataTable();
            dtDepartamentos = AdministrarDepartamento.mostrarDepartamento();
            ddlDepartamento.DataTextField = "dep_Nombre";
            ddlDepartamento.DataValueField = "dep_Id";
            ddlDepartamento.DataSource = dtDepartamentos;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", ""));
            ddlCiudad.Items.Insert(0, new ListItem("Seleccione", ""));


            DataTable dtLocalidad = new DataTable();
            dtLocalidad = AdministrarDepartamento.mostrarDepartamento();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidad;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("SELECCIONE", ""));

            
        }
        titleAcciones.Visible = true;
        titleAsignarLocalidades.Visible = false;
        buscador.Visible = true;
        titleConsultar.Visible = false;
        titleModificar.Visible = false;
        titleAdicionar.Visible = false;
        divLocalidades.Visible = false;
    }

    /// <summary>
    /// Lista todas las agencias en el gridview de administración
    /// </summary>
    protected void ListarAgencias()
    {
        DataTable dt = new DataTable();
        dt = AdministrarAgencia.ListarAgencias();
        grvAdminAgencia.DataSource = dt;
        grvAdminAgencia.DataBind();
    }

    protected void grvAdminAgencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminAgencia.PageIndex = e.NewPageIndex;
        ListarAgencias();
    }

    protected void grvAdminAgencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminAgencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //try
        //{
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "AsignarLocalidad_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminAgencia.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long agenciaIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAgencia.ConsultarAgencia(agenciaIdentificador);
                grvConsultarAgencia.DataSource = dt;
                grvConsultarAgencia.DataBind();

                //Muestra y oculta los controles necesarios
                titleConsultar.Visible = true;
                titleAcciones.Visible = false;
                buscador.Visible = false;
                tablaAgencias.Visible = false;
                tablaAgencia.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "AsignarLocalidad_Click")
            {
                Session["age_Id"] = 0;
                long agenciaIdentificador = long.Parse(row.Cells[1].Text);
                Session["age_Id"] = agenciaIdentificador;


                lblAgencia.Text = "AGENCIA :  " + row.Cells[2].Text;
                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAgencia.ConsultarLocalidadesAgencia(agenciaIdentificador);
                listLocalidades.DataSource = dt;
                listLocalidades.DataBind();

                //Muestra y oculta los controles necesarios

                titleAsignarLocalidades.Visible = true;
                titleAcciones.Visible = false;
                buscador.Visible = false;
                titleAsignarLocalidades.Visible = true;
                buscador.Visible = false;
                titleModificar.Visible = false;
                titleConsultar.Visible = false;
                titleAcciones.Visible = false;
                titleAdicionar.Visible = false;
                divLocalidades.Visible = true;
                tablaAgencia.Visible = false;
                tablaAgencias.Visible = false;

            }


            if (e.CommandName == "Modificar_Click")
            {
                long agenciaIdentificador = long.Parse(row.Cells[1].Text);
                txtAgenciaIdentificador.Text = agenciaIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAgencia.ConsultarAgenciaModificar(agenciaIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtAgenciaNombre.Text = dt.Rows[0]["age_Nombre"].ToString();
                    txtAgenciaDireccion.Text = dt.Rows[0]["age_Direccion"].ToString();
                    txtAgenciaTelefono.Text = dt.Rows[0]["age_Telefono"].ToString();
                    txtAgenciaEmail.Text = dt.Rows[0]["age_Email"].ToString();
                    txtAgenciaDirector.Text = dt.Rows[0]["age_Director"].ToString();
                    ddlDepartamento.SelectedValue = dt.Rows[0]["dep_Id"].ToString();
                    int? departamentoIdentificador = -1;
                    if (ddlDepartamento.SelectedValue != "")
                        departamentoIdentificador = int.Parse(ddlDepartamento.SelectedValue);
                    DataTable dtCiudades = new DataTable();
                    dtCiudades = AdministrarCiudad.mostrarCiudades(null, null, departamentoIdentificador);
                    ddlCiudad.DataTextField = "ciu_Nombre";
                    ddlCiudad.DataValueField = "ciu_Id";
                    ddlCiudad.DataSource = dtCiudades;
                    ddlCiudad.DataBind();
                    ddlCiudad.Items.Insert(0, new ListItem("Seleccione", ""));
                    ddlCiudad.SelectedValue = dt.Rows[0]["ciu_Id"].ToString();
                }
                grvConsultarAgencia.DataSource = dt;
                grvConsultarAgencia.DataBind();

                //Muestra y oculta los controles necesarios
                titleModificar.Visible = true;
                titleAcciones.Visible = false;
                buscador.Visible = false;
                formAgencia.Visible = true;
                tablaAgencias.Visible = false;
                tablaAgencia.Visible = false;
                botonAtras.Visible = true;
                btnGuardar.Visible = true;
                btnInsertar.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long agenciaIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarAgencia.EliminarAgencia(agenciaIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarAgencias();
            }
        }
        //catch (Exception ex)
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        //}
    


    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        //Muestra y oculta los controles necesarios
        titleAdicionar.Visible = true;
        titleAcciones.Visible = false;
        buscador.Visible = false;
        formAgencia.Visible = true;
        tablaAgencias.Visible = false;
        tablaAgencia.Visible = false;
        btnGuardar.Visible = false;
        btnInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            string agenciaNombre;
            string agenciaDireccion = null;
            string agenciaTelefono = null;
            string agenciaEmail = null;
            string agenciaDirector = null;
            long? departamentoIdentificador = null;
            long? ciudadIdentificador = null;
            agenciaNombre = txtAgenciaNombre.Text;
            if (txtAgenciaDireccion.Text != "")
                agenciaDireccion = txtAgenciaDireccion.Text;
            if (txtAgenciaTelefono.Text != "")
                agenciaTelefono = txtAgenciaTelefono.Text;
            if (txtAgenciaEmail.Text != "")
                agenciaEmail = txtAgenciaEmail.Text;
            if (txtAgenciaDirector.Text != "")
                agenciaDirector = txtAgenciaDirector.Text;
            if (ddlDepartamento.SelectedValue != "")
                departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlCiudad.SelectedValue != "")
                ciudadIdentificador = long.Parse(ddlCiudad.SelectedValue);

            AdministrarAgencia.InsertarAgencia(agenciaNombre, agenciaDireccion, agenciaTelefono, agenciaEmail, agenciaDirector, departamentoIdentificador, ciudadIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formAgencia.Visible = false;
            tablaAgencias.Visible = true;

            LimpiarFormulario();
            ListarAgencias();
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
            string agenciaNombre;
            string agenciaDireccion = null;
            string agenciaTelefono = null;
            string agenciaEmail = null;
            string agenciaDirector = null;
            long? departamentoIdentificador = null;
            long? ciudadIdentificador = null;
            agenciaNombre = txtAgenciaNombre.Text;
            if (txtAgenciaDireccion.Text != "")
                agenciaDireccion = txtAgenciaDireccion.Text;
            if (txtAgenciaTelefono.Text != "")
                agenciaTelefono = txtAgenciaTelefono.Text;
            if (txtAgenciaEmail.Text != "")
                agenciaEmail = txtAgenciaEmail.Text;
            if (txtAgenciaDirector.Text != "")
                agenciaDirector = txtAgenciaDirector.Text;
            if (ddlDepartamento.SelectedValue != "")
                departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlCiudad.SelectedValue != "")
                ciudadIdentificador = long.Parse(ddlCiudad.SelectedValue);

            AdministrarAgencia.ModificarAgencia(long.Parse(txtAgenciaIdentificador.Text), agenciaNombre, agenciaDireccion, agenciaTelefono, agenciaEmail, agenciaDirector, departamentoIdentificador, ciudadIdentificador);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formAgencia.Visible = false;
            tablaAgencias.Visible = true;

            LimpiarFormulario();
            ListarAgencias();
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
        txtAgenciaNombre.Text = string.Empty;
        txtAgenciaDireccion.Text = string.Empty;
        txtAgenciaTelefono.Text = string.Empty;
        txtAgenciaEmail.Text = string.Empty;
        txtAgenciaDirector.Text = string.Empty;
        ddlDepartamento.SelectedValue = string.Empty;
        ddlCiudad.SelectedValue = string.Empty;
        txtAgenciaIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarAgencia.aspx");
        Response.RedirectToRoute("gestionAgencias");
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int? departamentoIdentificador = -1;
        if(ddlDepartamento.SelectedValue != "")
            departamentoIdentificador = int.Parse(ddlDepartamento.SelectedValue);
        DataTable dtCiudades = new DataTable();
        dtCiudades = AdministrarCiudad.mostrarCiudades(null, null, departamentoIdentificador);
        ddlCiudad.DataTextField = "ciu_Nombre";
        ddlCiudad.DataValueField = "ciu_Id";
        ddlCiudad.DataSource = dtCiudades;
        ddlCiudad.DataBind();
        ddlCiudad.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    protected void btnAsignarlocali_Click(object sender, EventArgs e)
    {
        int agencia = int.Parse(Session["age_Id"].ToString());

        if (ddlLocalidad.Text != "")
        {
            int registros = AdministrarAgencia.AsignarLocalidadAgencia(agencia, int.Parse(ddlLocalidad.SelectedValue.ToString()));

            if (registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Localidad asignada" + "');window.location.replace('/Presentacion7/AdministrarAgencia.aspx')", true);
                //AdministrarAgencia.ConsultarAsesor(int.Parse(Session["ase_Id"].ToString()));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('La localidad ya existe para esta agencia.');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }


    protected void listLocalidades_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "btnEliminarLocalidad_Click")
        {
            int dep_Id = int.Parse(e.CommandArgument.ToString());
            AdministrarAgencia.EliminarLocalidadAgencia(int.Parse(Session["age_Id"].ToString()), dep_Id);
            //Response.Redirect("../Presentacion7/AdministrarAgencia.aspx");
            Response.RedirectToRoute("gestionAgencias");


        }
        
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int codigo = 0;
        string nombre = "";
        string direccion = "";
        string telefono = "";

        if (txtBuscarCodigo.Text != "")
        {
            codigo = int.Parse(txtBuscarCodigo.Text);
        }

        if (txtBuscarNombre.Text != "")
        {
            nombre = txtBuscarNombre.Text;
        }

        if (txtBuscarDireccion.Text != "")
        {
            direccion = txtBuscarDireccion.Text;
        }

        if (txtBuscarTelefono.Text != "")
        {
            telefono = txtBuscarTelefono.Text;
        }

        DataTable dt = AdministrarAgencia.BuscarAgencia(codigo, nombre, direccion, telefono);
        grvAdminAgencia.DataSource = dt;
        grvAdminAgencia.DataBind();

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarAgencia.aspx");
        Response.RedirectToRoute("gestionAgencias");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================


}