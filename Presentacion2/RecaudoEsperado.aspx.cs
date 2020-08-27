using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion2_RecaudoEsperado : System.Web.UI.Page
{
    public Pagos objPago = new Pagos();
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {

            DataTable dtRecaudoEsperado = new DataTable();
            dtRecaudoEsperado = objPago.CargarDigitacion();
            grvRecaudoEsperado.DataSource = dtRecaudoEsperado;
            grvRecaudoEsperado.DataBind();
        }
    }
    protected void grvRecaudoEsperado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRecaudoEsperado.PageIndex = e.NewPageIndex;
        objPago.CargarDigitacion();
    }
}