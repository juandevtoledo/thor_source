using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_CRUDS_AdministrarAsesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarAsesores();
            formAsesor.Visible = false;
            botonAtras.Visible = false;

            listas();

            titleAcciones.Visible = true;
            buscador.Visible = true;
            divProductos.Visible = false;
            titleAsignarLocalidad.Visible = false;
            titleAsignarProductos.Visible = false;
            titleConsultar.Visible = false;
            titleModificar.Visible = false;
            titleAdicionar.Visible = false;
            divLocalidades.Visible = false;
        }
        
        
    }

    protected void listas()
    {
        DataTable dtDepartamentos = new DataTable();
        dtDepartamentos = AdministrarDepartamento.mostrarDepartamento();
        ddlDepartamento.DataTextField = "dep_Nombre";
        ddlDepartamento.DataValueField = "dep_Id";
        ddlDepartamento.DataSource = dtDepartamentos;
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("SELECCIONE", ""));

        DataTable dtLocalidad = new DataTable();
        dtLocalidad = AdministrarDepartamento.mostrarDepartamento();
        ddlLocalidad.DataTextField = "dep_Nombre";
        ddlLocalidad.DataValueField = "dep_Id";
        ddlLocalidad.DataSource = dtLocalidad;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Insert(0, new ListItem("SELECCIONE", ""));

        DataTable dtCompanias = new DataTable();
        dtCompanias = AdministrarCompania.ListarCompanias();
        ddlCompania.DataTextField = "com_Nombre";
        ddlCompania.DataValueField = "com_Id";
        ddlCompania.DataSource = dtCompanias;
        ddlCompania.DataBind();
        ddlCompania.Items.Insert(0, new ListItem("SELECCIONE", ""));

        DataTable dtCompañia = new DataTable();
        dtCompañia = AdministrarCompania.ListarCompanias();
        ddlCompañia.DataTextField = "com_Nombre";
        ddlCompañia.DataValueField = "com_Id";
        ddlCompañia.DataSource = dtCompañia;
        ddlCompañia.DataBind();
        ddlCompañia.Items.Insert(0, new ListItem("SELECCIONE", ""));
    }

    /// <summary>
    /// Lista todos los asesores en el gridview de administración
    /// </summary>
    protected void ListarAsesores()
    {
        DataTable dt = new DataTable();
        dt = AdministrarAsesor.ListarAsesores();
        grvAdminAsesor.DataSource = dt;
        grvAdminAsesor.DataBind();
    }

    protected void grvAdminAsesor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminAsesor.PageIndex = e.NewPageIndex;
        ListarAsesores();
    }

    protected void grvAdminAsesor_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvAdminAsesor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        listas();
        //try
        //{
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = null;

            if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "AsignarProducto_Click" || e.CommandName == "AsignarLocalidad_Click" || e.CommandName == "Eliminar_Click")
                row = grvAdminAsesor.Rows[(index)];

            if (e.CommandName == "Consultar_Click")
            {
                long asesorIdentificador = long.Parse(row.Cells[1].Text);

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAsesor.ConsultarAsesor(asesorIdentificador);
                grvConsultarAsesor.DataSource = dt;
                grvConsultarAsesor.DataBind();

                //Muestra y oculta los controles necesarios
                
                titleConsultar.Visible = true;
                titleAcciones.Visible = false;
                buscador.Visible = false;
                titleModificar.Visible = false;
                titleAdicionar.Visible = false;
                titleAsignarLocalidad.Visible = false;
                titleAsignarProductos.Visible = false;
                divProductos.Visible = false;
                tablaAsesores.Visible = false;
                tablaAsesor.Visible = true;
                botonAtras.Visible = true;
            }

            if (e.CommandName == "Modificar_Click")
            {
                long asesorIdentificador = long.Parse(row.Cells[1].Text);
                txtAsesorIdentificador.Text = asesorIdentificador.ToString();

                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAsesor.ConsultarAsesorModificar(asesorIdentificador);
                if (dt.Rows.Count > 0)
                {
                    txtAsesorCodigo.Text = dt.Rows[0]["ase_Codigo"].ToString();
                    txtAsesorApellidos.Text = dt.Rows[0]["ase_Apellidos"].ToString();
                    txtAsesorNombres.Text = dt.Rows[0]["ase_Nombres"].ToString();
                    ddlDepartamento.SelectedValue = dt.Rows[0]["dep_Id"].ToString();
                    ddlCompania.SelectedValue = dt.Rows[0]["com_Id"].ToString();
                    ddlAsesorFuncionario.SelectedValue = dt.Rows[0]["ase_Funcionario"].ToString();
                }
                grvConsultarAsesor.DataSource = dt;
                grvConsultarAsesor.DataBind();

                //Muestra y oculta los controles necesarios

                titleModificar.Visible = true;
                titleConsultar.Visible = false;
                buscador.Visible = false;
                titleAcciones.Visible = false;
                titleAdicionar.Visible = false;
                titleAsignarLocalidad.Visible = false;
                titleAsignarProductos.Visible = false;
                divProductos.Visible = false;
                formAsesor.Visible = true;
                tablaAsesores.Visible = false;
                tablaAsesor.Visible = false;
                botonAtras.Visible = true;
                botonGuardar.Visible = true;
                botonInsertar.Visible = false;
            }

            if (e.CommandName == "AsignarProducto_Click")
            {
                Session["ase_Id"] = 0;
                long asesorIdentificador = long.Parse(row.Cells[1].Text);
                Session["ase_Id"] = asesorIdentificador;
                

                lblAsesor.Text = "ASESOR :  " + row.Cells[2].Text;
                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAsesor.ConsultarProductoAsesor(asesorIdentificador);
                listProductos.DataSource = dt;
                listProductos.DataBind();

                //Muestra y oculta los controles necesarios

                titleAsignarProductos.Visible = true;
                divProductos.Visible = true;
                buscador.Visible = false;
                titleModificar.Visible = false;
                titleConsultar.Visible = false;
                titleAcciones.Visible = false;
                titleAdicionar.Visible = false;
                titleAsignarLocalidad.Visible = false;
                divLocalidades.Visible = false;
                tablaAsesores.Visible = false;
                tablaAsesor.Visible = false;
                
            }

            if (e.CommandName == "AsignarLocalidad_Click")
            {
                Session["ase_Id"] = 0;
                long asesorIdentificador = long.Parse(row.Cells[1].Text);
                Session["ase_Id"] = asesorIdentificador;

                lblAsesorlocali.Text = "ASESOR :  " + row.Cells[2].Text;
                //Consulta y muestra la información
                DataTable dt = new DataTable();
                dt = AdministrarAsesor.ConsultarLocalidadesAsesor(asesorIdentificador);
                listLocalidades.DataSource = dt;
                listLocalidades.DataBind();

                //Muestra y oculta los controles necesarios

                titleAsignarLocalidad.Visible = true;
                divLocalidades.Visible = true;
                buscador.Visible = false;
                titleModificar.Visible = false;
                titleConsultar.Visible = false;
                titleAcciones.Visible = false;
                titleAdicionar.Visible = false;
                titleAsignarProductos.Visible = false;

                tablaAsesores.Visible = false;
                tablaAsesor.Visible = false;
            }

            if (e.CommandName == "Eliminar_Click")
            {
                long asesorIdentificador = long.Parse(row.Cells[1].Text);

                DataTable dt = new DataTable();
                dt = AdministrarAsesor.EliminarAsesor(asesorIdentificador);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarAsesores();
            }
        }
        //catch (Exception ex)
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para más información.');", true);
        //}
    //}

    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        //Muestra y oculta los controles necesarios
        titleAdicionar.Visible = true;
        titleAcciones.Visible = false;
        buscador.Visible = false;
        formAsesor.Visible = true;
        tablaAsesores.Visible = false;
        tablaAsesor.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            long? asesorCodigo = null;
            string asesorApellidos = null;
            string asesorNombres = null;
            long? departamentoIdentificador = null;
            long? compañiaIdentificador = null;
            string asesorActivo = null;
            string asesorFuncionario = null;
            if (txtAsesorCodigo.Text != "")
                asesorCodigo = long.Parse(txtAsesorCodigo.Text);
            if (txtAsesorApellidos.Text != "")
                asesorApellidos = txtAsesorApellidos.Text;
            if (txtAsesorNombres.Text != "")
                asesorNombres = txtAsesorNombres.Text;
            if (ddlDepartamento.SelectedValue != "")
                departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlCompania.SelectedValue != "")
                compañiaIdentificador = long.Parse(ddlCompania.SelectedValue);
            if (ddlAsesorActivo.SelectedValue != "")
                asesorActivo = ddlAsesorActivo.SelectedValue;
            if (ddlAsesorFuncionario.SelectedValue != "")
                asesorFuncionario = ddlAsesorFuncionario.SelectedValue;

            AdministrarAsesor.InsertarAsesor(asesorCodigo, asesorApellidos, asesorNombres, departamentoIdentificador, compañiaIdentificador, asesorActivo, asesorFuncionario);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            formAsesor.Visible = false;
            tablaAsesores.Visible = true;

            LimpiarFormulario();
            ListarAsesores();
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
            long? asesorCodigo = null;
            string asesorApellidos = null;
            string asesorNombres = null;
            long? departamentoIdentificador = null;
            long? compañiaIdentificador = null;
            string asesorActivo = null;
            string asesorFuncionario = null;
            if (txtAsesorCodigo.Text != "")
                asesorCodigo = long.Parse(txtAsesorCodigo.Text);
            if (txtAsesorApellidos.Text != "")
                asesorApellidos = txtAsesorApellidos.Text;
            if (txtAsesorNombres.Text != "")
                asesorNombres = txtAsesorNombres.Text;
            if (ddlDepartamento.SelectedValue != "")
                departamentoIdentificador = long.Parse(ddlDepartamento.SelectedValue);
            if (ddlCompania.SelectedValue != "")
                compañiaIdentificador = long.Parse(ddlCompania.SelectedValue);
            if (ddlAsesorActivo.SelectedValue != "")
                asesorActivo = ddlAsesorActivo.SelectedValue;
            if (ddlAsesorFuncionario.SelectedValue != "")
                asesorFuncionario = ddlAsesorFuncionario.SelectedValue;

            AdministrarAsesor.ModificarAsesor(long.Parse(txtAsesorIdentificador.Text), asesorCodigo, asesorApellidos, asesorNombres, departamentoIdentificador, compañiaIdentificador, asesorActivo, asesorFuncionario);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);

            //Muestra y oculta los controles necesarios
            titleAcciones.Visible = true;
            buscador.Visible = false;
            titleModificar.Visible = false;
            formAsesor.Visible = false;
            tablaAsesores.Visible = true;

            LimpiarFormulario();
            ListarAsesores();
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
        txtAsesorCodigo.Text = string.Empty;
        txtAsesorApellidos.Text = string.Empty;
        txtAsesorNombres.Text = string.Empty;
        ddlDepartamento.SelectedValue = string.Empty;
        ddlCompania.SelectedValue = string.Empty;
        ddlAsesorActivo.SelectedValue = string.Empty;
        ddlAsesorFuncionario.SelectedValue = string.Empty;
        txtAsesorIdentificador.Text = string.Empty;
    }

    public void btnSalir_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarAsesor.aspx");
        Response.RedirectToRoute("gestionAsesores");
    }

    //Asignar productos por asesor

    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtProducto = new DataTable();
        dtProducto = AdministrarAsesor.ConsultarProductosCompañia(int.Parse(ddlCompañia.SelectedValue));
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataSource = dtProducto;
        ddlProducto.DataBind();
        ddlProducto.Items.Insert(0, new ListItem("Seleccione", ""));
    }

    protected void btnAsignarPro_Click(object sender, EventArgs e)
    {
        if (ddlCompañia.Text != "" && ddlProducto.Text != "")
        {
            int registros = AdministrarAsesor.AsignarProductoAsesor(int.Parse(Session["ase_Id"].ToString()), int.Parse(ddlProducto.SelectedValue.ToString()));

            if (registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Producto asignado" + "');window.location.replace('/Presentacion7/AdministrarAsesor.aspx')", true);
                AdministrarAsesor.ConsultarAsesor(int.Parse(Session["ase_Id"].ToString()));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El producto ya existe para este asesor.');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    protected void listProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "btnEliminarPro_Click")
        {
            int pro_Id = int.Parse(e.CommandArgument.ToString());
            AdministrarAsesor.EliminarProductoAsesor(int.Parse(Session["ase_Id"].ToString()), pro_Id);
            //Response.Redirect("../Presentacion7/AdministrarAsesor.aspx");
            Response.RedirectToRoute("gestionAsesores");


        }
    }

    //Asignar productos por asesor

    // Asignar localidades por asesor

    protected void btnAsignarlocali_Click(object sender, EventArgs e)  
    {
        int asesor = int.Parse(Session["ase_Id"].ToString());

        if (ddlLocalidad.Text != "")
        {
            int registros = AdministrarAsesor.AsignarLocalidadAsesor(asesor, int.Parse(ddlLocalidad.SelectedValue.ToString()));

            if (registros > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Localidad asignada" + "');window.location.replace('/Presentacion7/AdministrarAsesor.aspx')", true);
                AdministrarAsesor.ConsultarAsesor(int.Parse(Session["ase_Id"].ToString()));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('La localidad ya existe para este asesor.');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Faltan campos por LLenar');", true);
        }
    }

    protected void listLocalidades_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "btnEliminarLocali_Click")
        {
            int pro_Id = int.Parse(e.CommandArgument.ToString());
            AdministrarAsesor.EliminarLocalidadAsesor(int.Parse(Session["ase_Id"].ToString()), pro_Id);
            //Response.Redirect("../Presentacion7/AdministrarAsesor.aspx");
            Response.RedirectToRoute("gestionAsesores");

        }
    }

    // Asignar localidades por asesor

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int codigo = 0;
        string nombre = "";
        string localidad = "";
        string estado = "";

        if (txtBuscarCodigo.Text != "")
        {
            codigo = int.Parse(txtBuscarCodigo.Text);
        }

        if (txtBuscarNombre.Text != "")
        {
            nombre = txtBuscarNombre.Text;
        }

        if (txtBuscarLocalidad.Text != "")
        {
            localidad = txtBuscarLocalidad.Text;
        }

        if (txtBuscarEstado.Text != "")
        {
            estado = txtBuscarEstado.Text;
        }

        DataTable dt = AdministrarAsesor.BuscarAsesor(codigo, nombre, localidad, estado);
        grvAdminAsesor.DataSource = dt;
        grvAdminAsesor.DataBind();

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Presentacion7/AdministrarAsesor.aspx");
        Response.RedirectToRoute("gestionAsesores");
    }

    //======================================================================
    //======================== B U S C A D O R =============================
    //======================================================================
    
}