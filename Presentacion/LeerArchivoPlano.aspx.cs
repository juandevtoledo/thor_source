using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_LeerArchivoPlano : System.Web.UI.Page
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

    public static DataTable dt = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            resumen.Visible = false;            
        }
    }

    //Carga el archivo plano, chequea la extension de archivo plano y dependiendo del checkbox que seleccione el usuario envia el archivo como nuevos o modificaciones
    protected void btnLeer_Click(object sender, EventArgs e)
    {
        List<string[]> datosArchivo = new List<string[]>();

        if (FileUpload1.HasFile)
        {
            if (ChecarExtension(FileUpload1.FileName))
            {
                using (StreamReader readFile = new StreamReader(FileUpload1.FileContent, System.Text.Encoding.Default))
                {
                    string line;
                    string[] row;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(';');
                        datosArchivo.Add(row);
                    }
                }
                if(chkOpcion.Checked)
                {                    
                    dt = LeerArchivoPlano.InsertarArchivo(datosArchivo);
                }
                else
                {
                    dt = LeerArchivoPlanoNovedades.InsertarArchivoNovedades(datosArchivo);
                }                              
                grvResumenPlano.DataSource = dt;
                grvResumenPlano.DataBind();
                spnExito.InnerText = LeerArchivoPlano.sumaExito.ToString();
                spnError.InnerText = LeerArchivoPlano.sumaError.ToString();
                spnTodos.InnerText = LeerArchivoPlano.sumaTodos.ToString();
                total.Text = LeerArchivoPlano.sumaExito.ToString();
                resumen.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "CARGA EXITOSA" + "');", true);
              
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "ERROR AL SUBIR EL ARCHIVO - VERIFIQUE LA EXTENSION" + "');", true);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Seleccione UN ARCHIVO" + "');", true);
        }
        

    }
    //Verifica que el archivo sea de extension .csv
    protected bool ChecarExtension(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".csv":
                return true;
            default:
                return false;
        }
    }
    
    //Filtra los certificados de ingreso exitosos
    protected void btnExito_Click(object sender, EventArgs e)
    {
        DataRow[] foundrows;

        DataTable dtNuevo = new DataTable();
        dtNuevo.Columns.Add("ID");
        dtNuevo.Columns.Add("Certificado");
        dtNuevo.Columns.Add("Asegurado");
        dtNuevo.Columns.Add("Amparos");
        dtNuevo.Columns.Add("Beneficiarios");
        dtNuevo.Columns.Add("Conyuge");
        dtNuevo.Columns.Add("OtroAsegurado");
      
        if(dt.Rows.Count > 0)
        {
            foundrows = dt.Select("ID = '1'");
            for (int i = 0; i < foundrows.Length; i++)
                dtNuevo.Rows.Add(foundrows[i].ItemArray);

            grvResumenPlano.DataSource = dtNuevo;
            grvResumenPlano.DataBind();
        }

    }

    //Filtra los certificados erroneos
    protected void btnError_Click(object sender, EventArgs e)
    {
        DataRow[] foundrows;

        DataTable dtNuevo = new DataTable();
        dtNuevo.Columns.Add("ID");
        dtNuevo.Columns.Add("Certificado");
        dtNuevo.Columns.Add("Asegurado");
        dtNuevo.Columns.Add("Amparos");
        dtNuevo.Columns.Add("Beneficiarios");
        dtNuevo.Columns.Add("Conyuge");
        dtNuevo.Columns.Add("OtroAsegurado");

        if (dt.Rows.Count > 0)
        {
            foundrows = dt.Select("ID = '2'");
            for (int i = 0; i < foundrows.Length; i++)
                dtNuevo.Rows.Add(foundrows[i].ItemArray);

            grvResumenPlano.DataSource = dtNuevo;
            grvResumenPlano.DataBind();
        }
    }
    
    //Limpia los filtros
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {   
        grvResumenPlano.DataSource = dt;
        grvResumenPlano.DataBind();
    }

    //Funcion que cambia numeros por iconos para una mejor impresion
    protected void grvResumenPlano_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataTable dtBound = (DataTable)grvResumenPlano.DataSource;
            string var = dtBound.Rows[e.Row.DataItemIndex][0].ToString();
            
            if (var == "2")
            {
                e.Row.Cells[0].Text = "<span class='label label-danger'><span class='glyphicon glyphicon-remove'/></span>";
            }
            else
            {
                if (var == "1")
                {
                    e.Row.Cells[0].Text = "<span class='label label-success'><span class='glyphicon glyphicon-ok'/></span>";
                }
            }

            string varTercero = dtBound.Rows[e.Row.DataItemIndex][2].ToString();
            e.Row.Cells[2].Text = varTercero.Replace("Inserto:", "<span class='glyphicon glyphicon-ok' aria-hidden='true'/>").Replace("Error:", "<span class='glyphicon glyphicon-remove' aria-hidden='true'/>").Replace("Actualizo:", "<span class='glyphicon glyphicon-pencil' aria-hidden='true'/>"); 

            string varAmparo = dtBound.Rows[e.Row.DataItemIndex][3].ToString();
            e.Row.Cells[3].Text = varAmparo.Replace("/SI/", "<span class='glyphicon glyphicon-ok' aria-hidden='true'/>").Replace("/NO/", "<span class='glyphicon glyphicon-remove' aria-hidden='true'/>").Replace(";", "</br>");

            string varBeneficiario = dtBound.Rows[e.Row.DataItemIndex][4].ToString();
            e.Row.Cells[4].Text = varBeneficiario.Replace("/SI/", "<span class='glyphicon glyphicon-ok' aria-hidden='true'/>").Replace("/NO/", "<span class='glyphicon glyphicon-remove' aria-hidden='true'/>").Replace(";", "</br>");

            string varConyuge = dtBound.Rows[e.Row.DataItemIndex][5].ToString();
            e.Row.Cells[5].Text = varConyuge.Replace("/SI/", "<span class='glyphicon glyphicon-ok' aria-hidden='true'/>").Replace("/NO/", "<span class='glyphicon glyphicon-remove' aria-hidden='true'/>").Replace(";", "</br>");

            string varOtroAsegurado = dtBound.Rows[e.Row.DataItemIndex][6].ToString();
            e.Row.Cells[6].Text = varOtroAsegurado.Replace("/SI/", "<span class='glyphicon glyphicon-ok' aria-hidden='true'/>").Replace("/NO/", "<span class='glyphicon glyphicon-remove' aria-hidden='true'/>").Replace(";", "</br>");

        }

    }
}