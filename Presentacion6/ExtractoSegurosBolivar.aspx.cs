using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion6_ExtractoSegurosBolivar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
    }

    //Evento que carga el grid view con los datos subidos en el archivo en excel del extracto de Seguros Bolivar
    protected void btnCargarDatos_Click(object sender, EventArgs e)
    {
        Session["dtExcel"] = null;
        grvExtractoSegurosBolivar.DataSource = LeerExcel();
        grvExtractoSegurosBolivar.DataBind();
    }

    //Metodo que lee un archivo en excel y lo retorna en una tabla y guarda en una variable de Session
    protected DataTable LeerExcel()
    {
        DataTable dtExcel = new DataTable();
        if (fileUpload.HasFile)
        {
            string ruta = string.Concat((Server.MapPath("~/temp/" + fileUpload.FileName)));
            fileUpload.PostedFile.SaveAs(ruta);
            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string conexion;
            //conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=Excel 8.0;";
            conexion = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;";
            OleDbConnection OleDbcon = new OleDbConnection(conexion);
            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("Select * from [Hoja1$]", OleDbcon);

            OleDbcon.Open();
            DbDataReader dr = consulta.ExecuteReader();
            dtExcel.Load(dr);

            OleDbcon.Close();
            Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
        }
        else
        {
            lbl1.ForeColor = Color.Red;
            lbl1.Text = "Por favor seleccione un archivo";
        }
        Session["dtExcel"] = dtExcel;
        return dtExcel;
    }

    //Evento que recorre la tabla con el excel cargado e inserta registro a registro en la base de datos
    protected void btnGuardarExtracto_Click(object sender, EventArgs e)
    {
        AdministrarPagosBolivar objAdminPagosBol = new AdministrarPagosBolivar();
        if (Session["dtExcel"] != null)
        {
            DataTable dtExtracto = (DataTable)Session["dtExcel"];
            dtExtracto.Columns[0].ColumnName = "Ramo";
            dtExtracto.Columns[1].ColumnName = "Producto";
            dtExtracto.Columns[2].ColumnName = "Op";
            dtExtracto.Columns[3].ColumnName = "Poliza";
            dtExtracto.Columns[4].ColumnName = "Fa";
            dtExtracto.Columns[5].ColumnName = "Al";
            dtExtracto.Columns[6].ColumnName = "Cliente";
            dtExtracto.Columns[7].ColumnName = "ValorPrima";
            dtExtracto.Columns[8].ColumnName = "ValorRecaudo";
            dtExtracto.Columns[9].ColumnName = "Participacion";
            dtExtracto.Columns[10].ColumnName = "ValorComision";
            dtExtracto.Columns[11].ColumnName = "FechaPago";
            dtExtracto.Columns[12].ColumnName = "Localidad";
            int registros = 0;
            foreach (DataRow row in dtExtracto.Rows)
            {
                 //registros = registros + objAdminPagosBol.InsertarRegistroExtracto(int.Parse(row["Poliza"].ToString()), int.Parse(row["Localidad"].ToString()), int.Parse(row["Producto"].ToString()), int.Parse(row["Valor"].ToString()), DateTime.Parse(row["FechaPago"].ToString()));
                registros = registros + objAdminPagosBol.InsertarRegistroExtracto(int.Parse(row["Ramo"].ToString()), int.Parse(row["Producto"].ToString()), int.Parse(row["Op"].ToString()), double.Parse(row["Poliza"].ToString()), int.Parse(row["Fa"].ToString()), int.Parse(row["Al"].ToString()), row["Cliente"].ToString(), int.Parse(row["ValorPrima"].ToString()), int.Parse(row["ValorRecaudo"].ToString()), int.Parse(row["Participacion"].ToString()), int.Parse(row["ValorComision"].ToString()), DateTime.Parse(row["FechaPago"].ToString()), row["Localidad"].ToString());
                
            }
            

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Archivo cargado."+ registros+" insertados');", true);
            Session["dtExcel"] = null;
        }
    }
}