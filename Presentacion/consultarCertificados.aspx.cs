using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_consultarCertificados : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int perfil = int.Parse(Session["Perfil"].ToString());
        int cedula = int.Parse(Session["Cedula"].ToString());

        DataTable dtlistPermisos = (DataTable)Session["dtPermisos"];


        ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        Funciones objFunciones = new Funciones();
        objFunciones.ocultarBotones(Master, dtlistPermisos);
}

    public PrecargueProduccion precargue = new PrecargueProduccion();
    protected void cargarResumenCertificado()
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        // Líneas para cargar el resumen
        DataTable dt = new DataTable();
        dt = objAdministrarCertificados.consultarResumenCertificado(int.Parse(Session["ssDocumento"].ToString()));

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["Parentesco"].ToString() == "")
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                    else
                    {
                        row["Parentesco"] = "CONYUGE";
                    }
                }
                else
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                }
            }
            grvResumenProducto.DataSource = dt;
            grvResumenProducto.DataBind();
            grvResumenProducto.HeaderRow.Cells[10].Visible = false;
            foreach (GridViewRow row in grvResumenProducto.Rows)
                row.Cells[10].Visible = false;
        }
        else
        {
            ddlCompania.Enabled = false;
            ddlProducto.Enabled = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            cargarResumenCertificado();

            lblNombreSession.Text = Session["Nombre"].ToString() + " " + Session["Apellido"].ToString();
            lblDocumentoSession.Text = Session["ssDocumento"].ToString();
        
            DataTable dt = new DataTable();
            dt = precargue.CargarCompania();
            ddlCompania.DataTextField = "com_Nombre";
            ddlCompania.DataValueField = "com_Id";
            ddlCompania.DataSource = dt;
            ddlCompania.DataBind();
            ddlCompania.Items.Insert(0, new ListItem("", ""));

            divObservaciones.Visible = false;
        }
    }

    protected void CargarProducto(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlCompania.Text != "")
        {
            DataTable dt = new DataTable();
            int com_Id = int.Parse(ddlCompania.SelectedValue.ToString());
            dt = precargue.CargarProducto(com_Id);
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dt;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));

            DataTable dtCompania = new DataTable();
            dtCompania = objAdministrarCertificados.consultarResumenCertificadoPorCompania(int.Parse(ddlCompania.SelectedValue.ToString()), int.Parse(Session["ssDocumento"].ToString()));

            foreach (DataRow row in dtCompania.Rows)
            {
                if (row["Parentesco"].ToString() == "")
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                    else
                    {
                        row["Parentesco"] = "CONYUGE";
                    }
                }
                else
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                }
            }
            grvResumenProducto.DataSource = dtCompania;
            grvResumenProducto.DataBind();
            grvResumenProducto.HeaderRow.Cells[10].Visible = false;
            foreach (GridViewRow row in grvResumenProducto.Rows)
                row.Cells[10].Visible = false;
        }
        else
        {
            ddlProducto.Items.Clear();
            cargarResumenCertificado();
        }
    }

    protected void grvResumenProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         int index = Convert.ToInt32(e.CommandArgument);
         AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
         PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
         GridViewRow row = grvResumenProducto.Rows[index];
         Session["cer_Id"] = row.Cells[1].Text;
         // Verificar que necesite ser digitado
         DataTable dtEstadoCertificado = objAdministrarCertificados.ConsultarCertificadoPrecargadoPorDigitar(int.Parse(Session["cer_Id"].ToString()));
         if (dtEstadoCertificado.Rows[0]["mom_Id"].ToString() == "2")
         {   
             DataTable dtPro_Id = new DataTable();

             dtPro_Id = objAdministrarCertificados.consultarProIdPorNombre(row.Cells[8].Text, row.Cells[7].Text);

             DataTable dt = new DataTable();
             dt = objPrecargueProduccion.ConsultarConsecutivoCert(int.Parse(Session["ter_Id"].ToString()), int.Parse(dtPro_Id.Rows[0]["pro_Id"].ToString()));

             if (dt.Rows.Count > 0)
             {

                 Session["operacionCertificado"] = "modificar";
             }
             else
             {
                 Session["operacionCertificado"] = "ingresar";
             }
             Session["ter_Id"] = Session["ter_Id"].ToString();//tercero
             Session["Producto"] = row.Cells[8].Text;
             Session["cer_Id"] = row.Cells[1].Text;
             Session["pro_Id"] = dtPro_Id.Rows[0]["pro_Id"].ToString();
             Session["numeroCertificado"] = row.Cells[3].Text;//poliza
             Session["flag"] = "2";
             Session["Siguiente"] = false;
             //Response.Redirect("AdministrarTercero.aspx");
         }

         if (e.CommandName == "Consultar_Click")
         {
             try
             {
                 Session["cer_Id"] = row.Cells[1].Text;
                 if (row.Cells[6].Text == "FECHA INGRESO CONVERSION")
                 {
                     ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "No se puede consultar este certificado ya que solo es una referencia para Conversión" + "');", true);
                 }
                 else
                 {
                     if (row.Cells[5].Text != "0")
                     {
                         Response.RedirectToRoute("resumenCertificado");
                     }
                     else
                     {
                         ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "El certificado no se puede observar, porque aún está en proceso de digitación" + "');", true);
                     }
                 }
             }
             catch
             {
                 ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Solo pueden consultarse certificados vigentes o en Producción Nueva" + "');", true);
             }
         
         }
         if (e.CommandName == "Observacion_Click")
         {
             DataTable dtCertificado = new DataTable();

             DataColumn columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "ID";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Certificado";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Fecha Expedición";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Inicio Vigencia";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Prima";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Estado Negocio";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Compañia";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Producto";
             dtCertificado.Columns.Add(columns);

             columns = new DataColumn();
             columns.DataType = System.Type.GetType("System.String");
             columns.AllowDBNull = true;
             columns.ColumnName = "Parentesco";
             dtCertificado.Columns.Add(columns);

             DataRow producto = dtCertificado.NewRow();
             producto["ID"] = row.Cells[1].Text;
             producto["Certificado"] = row.Cells[2].Text;
             producto["Fecha Expedición"] = row.Cells[3].Text;
             producto["Inicio Vigencia"] = row.Cells[4].Text;
             producto["Prima"] = row.Cells[5].Text;
             producto["Estado Negocio"] = row.Cells[6].Text;
             producto["Compañia"] = row.Cells[7].Text;
             producto["Producto"] = row.Cells[8].Text;
             producto["Parentesco"] = row.Cells[9].Text;
             dtCertificado.Rows.Add(producto);

             grvResumenProducto.DataSource = dtCertificado;
             grvResumenProducto.DataBind();
             
             divObservaciones.Visible = true;
             string ter_IdO = lblDocumentoSession.Text;
             string cer_IdO = row.Cells[1].Text;
             Session["ter_Id"] = ter_IdO;
             Session["cer_Id"] = cer_IdO;

             DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_IdO.ToString(), cer_IdO);
             grvObservaciones.DataSource = observaciones;
             grvObservaciones.DataBind();
         }
    }

    protected void btnGuardarObservacion_Click(object sender, EventArgs e)
    {
        int ter_Id = (int) int.Parse(Session["ter_Id"].ToString());
        string usuarioObs = (string)Session["usuario"];
        DataTable dtMenu = (DataTable)Session["menuSistema"];
        string menu = dtMenu.Rows[5]["men_id"].ToString();
        string cer_IdO = Session["cer_Id"].ToString();

        if (txtObservacion.Text != "")
            AdministrarCartaRetiro.GuardarObservacion(txtObservacion.Text, usuarioObs, int.Parse(menu), ter_Id, int.Parse(cer_IdO));
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Por favor ingrese una observación" + "');", true);

        DataTable observaciones = GestionarTercero.ConsultarObservaciones(ter_Id.ToString(), cer_IdO.ToString());
        grvObservaciones.DataSource = observaciones;
        grvObservaciones.DataBind();
    }

    protected void ddlProductoSeleccionar(object sender, EventArgs e)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        if (ddlProducto.Text != "")
        {
            DataTable dtProducto = new DataTable();
            dtProducto = objAdministrarCertificados.consultarResumenCertificadoPorProducto(int.Parse(ddlProducto.SelectedValue.ToString()), int.Parse(Session["ssDocumento"].ToString()), int.Parse(ddlCompania.SelectedValue.ToString()));

            foreach (DataRow row in dtProducto.Rows)
            {
                if (row["Parentesco"].ToString() == "")
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                    else
                    {
                        row["Parentesco"] = "CONYUGE";
                    }
                }
                else
                {
                    if (row["ter_Id"].ToString() == Session["ssDocumento"].ToString())
                    {
                        row["Parentesco"] = "PRINCIPAL";
                    }
                }
            }
            grvResumenProducto.DataSource = dtProducto;
            grvResumenProducto.DataBind();
            grvResumenProducto.HeaderRow.Cells[10].Visible = false;
            foreach (GridViewRow row in grvResumenProducto.Rows)
                row.Cells[10].Visible = false;
        }
        else
        {
            CargarProducto(sender, e);
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        divObservaciones.Visible = false;
        cargarResumenCertificado();
    }
}