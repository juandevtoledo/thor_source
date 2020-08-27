using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Control_AdministrarCuentaBancaria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ListarCuentasBancarias();
            formCuentaBancaria.Visible = false;
            botonAtras.Visible = false;

        }



    }

    protected void ListarCuentasBancarias()
    {
        DataTable dt = new DataTable();
        dt = AdministrarCuentaBancaria.ListarCuentasBancarias();
        grvAdminCuentaBancaria.DataSource = dt;
        grvAdminCuentaBancaria.DataBind();
    }

    protected void grvAdminCuentaBancaria_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdminCuentaBancaria.PageIndex = e.NewPageIndex;
        ListarCuentasBancarias();
    }

    protected void grvAdminCuentaBancaria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((grvAdminCuentaBancaria.Rows.Count < grvAdminCuentaBancaria.PageSize) && (grvAdminCuentaBancaria.Rows.Count + grvAdminCuentaBancaria.PageSize * grvAdminCuentaBancaria.PageIndex < ((DataTable)(grvAdminCuentaBancaria.DataSource)).Rows.Count))

        //    e.Row.Cells[2].Visible = true;
    }


    protected void grvAdminCuentaBancaria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = null;

        if (e.CommandName == "Consultar_Click" || e.CommandName == "Modificar_Click" || e.CommandName == "Eliminar_Click")
            row = grvAdminCuentaBancaria.Rows[(index)];



        if (e.CommandName == "Consultar_Click")
        {
            //DB: Comentado
            int cuentaBancariaID = int.Parse(row.Cells[1].Text);


            DataTable dt = new DataTable();
            dt = AdministrarCuentaBancaria.ConsultarCuentaBancaria(cuentaBancariaID);


            tablaCuentasBancarias.Visible = false;
            tablaCuentaBancaria.Visible = true;
            botonAtras.Visible = true;
            grvConsultarCompania.DataSource = dt;
            grvConsultarCompania.DataBind();
        }

        if (e.CommandName == "Modificar_Click")
        {
            int cuentaBancariaID = int.Parse(row.Cells[1].Text);
            txtCuentaBancariaID.Text = cuentaBancariaID.ToString();

            DataTable dt = new DataTable();
            dt = AdministrarCuentaBancaria.ConsultarCuentaBancariaModificar(cuentaBancariaID);
            if (dt.Rows.Count > 0)
            {
                txtCuentaBancariaNumero.Text = dt.Rows[0]["cueBan_Numero"].ToString();

            }

            formCuentaBancaria.Visible = true;
            tablaCuentasBancarias.Visible = false;
            tablaCuentaBancaria.Visible = false;
            botonAtras.Visible = true;
            botonGuardar.Visible = true;
            botonInsertar.Visible = false;
            grvConsultarCompania.DataSource = dt;
            grvConsultarCompania.DataBind();
        }

        if (e.CommandName == "Eliminar_Click")
        {
            int cuentaBancariaID = int.Parse(row.Cells[1].Text);

            DataTable dt = new DataTable();
            try
            {
                dt = AdministrarCuentaBancaria.EliminarCuentaBancaria(cuentaBancariaID);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se eliminó de manera exitosa.');", true);
                ListarCuentasBancarias();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
            }
        }


    }


    public void btnAdicionar_Click(object sender, EventArgs e)
    {
        formCuentaBancaria.Visible = true;
        tablaCuentasBancarias.Visible = false;
        tablaCuentaBancaria.Visible = false;
        botonGuardar.Visible = false;
        botonInsertar.Visible = true;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {

        try
        {

            AdministrarCuentaBancaria.InsertarCuentaBancaria(Convert.ToInt64(txtCuentaBancariaNumero.Text));
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se adicionó de manera exitosa.');", true);
            formCuentaBancaria.Visible = false;
            tablaCuentasBancarias.Visible = true;
            LimpiarFormulario();
            ListarCuentasBancarias();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        try
        {
            AdministrarCuentaBancaria.ModificarCuentaBancaria(Convert.ToInt64(txtCuentaBancariaID.Text), Convert.ToInt64(txtCuentaBancariaNumero.Text));
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('El registro se actualizó de manera exitosa.');", true);
            formCuentaBancaria.Visible = false;
            tablaCuentasBancarias.Visible = true;
            LimpiarFormulario();
            ListarCuentasBancarias();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ocurrió un error, contacte al administrador para mas información.');", true);
        }

    }

    private void LimpiarFormulario()
    {
        txtCuentaBancariaNumero.Text = string.Empty;
        txtCuentaBancariaID.Text = string.Empty;
 
    }
    public void btnSalir_Click(object sender, EventArgs e)
    {
        tablaCuentasBancarias.Visible = true;
        tablaCuentaBancaria.Visible = false;
        formCuentaBancaria.Visible = false;
        botonAtras.Visible = false;

        LimpiarFormulario();
        ListarCuentasBancarias();
    }
}