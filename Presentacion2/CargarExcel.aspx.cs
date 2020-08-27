using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;

public partial class Presentacion2_CargarExcel : System.Web.UI.Page
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

    public Pagos objPago = new Pagos();
    public PrecargueProduccion precargue = new PrecargueProduccion();
    DataTable dtCompañia = new DataTable(), dtProducto = new DataTable(), dtPagaduria = new DataTable(), dtConvenio = new DataTable(); //Se declaran los dt

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        
        if(!IsPostBack)
        {
            //Carga el ddlCompañia
            dtCompañia = precargue.CargarCompania();
            ddlCompañia.DataTextField = "com_Nombre";
            ddlCompañia.DataValueField = "com_Id";
            ddlCompañia.DataSource = dtCompañia;
            ddlCompañia.DataBind();


            //Carga el ddlProducto según seleccion del ddlCompañia
            string compañia = ddlCompañia.SelectedValue.ToString();
            dtProducto = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompañia.SelectedValue.ToString()));
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            //ddlProducto.Items.Insert(0, new ListItem("", ""));


            //Carga el ddlPagaduria
            dtPagaduria = objPago.ConsultarPagadurias();
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            //ddlPagaduria.Items.Insert(0, new ListItem("", ""));

            ////Carga el ddlConvenio según seleccion del ddlPagaduria
            //string pagaduria = ddlPagaduria.SelectedValue.ToString();
            //dtConvenio = Pagos.Convenios(int.Parse(ddlPagaduria.SelectedValue.ToString()));
            //ddlConvenio.DataTextField = "con_Nombre";
            //ddlConvenio.DataValueField = "con_Id";
            //ddlConvenio.DataSource = dtConvenio;
            //ddlConvenio.DataBind();
            ////ddlConvenio.Items.Insert(0, new ListItem("", ""));
        }

    }
    
    
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Carga el ddlProducto según seleccion del ddlCompañia
        string compañia = ddlCompañia.SelectedValue.ToString();
        dtProducto = precargue.ProductoPorCompaniaPrecargue(int.Parse(ddlCompañia.SelectedValue.ToString()));
        ddlProducto.DataTextField = "pro_Nombre";
        ddlProducto.DataValueField = "pro_Id";
        ddlProducto.DataSource = dtProducto;
        ddlProducto.DataBind();
        //ddlProducto.Items.Insert(0, new ListItem("", ""));
    }


    ////Metodo para cargar una tabla con los datos de un excel - JC
    //protected void btnCargarDatos_Click(object sender, EventArgs e)
    //{
    //    if (FileUpload1.HasFile)
    //    {
    //        string ruta = string.Concat((Server.MapPath("~/temp/"+FileUpload1.FileName)));
    //        FileUpload1.PostedFile.SaveAs(ruta);
    //        OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;");
    //        OleDbCommand cmd = new OleDbCommand("Select * from [Hoja1$]", OleDbcon);
    //        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);

    //        OleDbcon.Open();
    //        DbDataReader dr = cmd.ExecuteReader();
    //        //string con_str = @"Data Source=.;Initial Catalog=RelampagoX_Pruebas;Integrated security=True";
    //        string con_str = @"Data Source=.;Initial Catalog = RelampagoX_Pruebas; User ID = usrTG; Password = usrTG";

    //        SqlBulkCopy bulkInsert = new SqlBulkCopy(con_str);
    //        bulkInsert.DestinationTableName = "tbl_studentdetails";
    //        bulkInsert.WriteToServer(dr);
    //        OleDbcon.Close();
    //        Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))),File.Delete);
    //        lbl1.ForeColor = Color.Green;
    //        lbl1.Text = "Carga de datos realizada correctamente";
    //    }
    //    else
    //    {
    //        lbl1.ForeColor = Color.Red;
    //        lbl1.Text = "Por favor seleccione un archivo";
    //    }
    //}


    //Metodo para cargar un datatable con los datos de un excel - JC
    protected void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string ruta = string.Concat((Server.MapPath("~/temp/" + FileUpload1.FileName)));
            FileUpload1.PostedFile.SaveAs(ruta);
            OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;");
            OleDbCommand cmd = new OleDbCommand("Select * from [Hoja1$]", OleDbcon);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);

            OleDbcon.Open();
            DbDataReader dr = cmd.ExecuteReader();

            DataTable dtExcel = new DataTable();
            dtExcel.Load (dr);
            grvExcel.DataSource = dtExcel;
            grvExcel.DataBind();

            OleDbcon.Close();
            Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
            lbl1.ForeColor = Color.Green;
            lbl1.Text = "Los datos fueron cargados correctamente!";
        }
        else
        {
            lbl1.ForeColor = Color.Red;
            lbl1.Text = "Por favor seleccione un archivo";
        }
    }

}