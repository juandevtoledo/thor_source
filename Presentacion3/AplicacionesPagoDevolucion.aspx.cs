using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Presentacion3_AplicacionesPagoDevolucion : System.Web.UI.Page
{

  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        if (!IsPostBack)
        {
            if (Session["idDevolucion"] != null)
            {
                Session["Bandera"] = 1;
                //Si hay una devolucion de prima seleccionada en la variable de session, se llena el Grid con las Aplicaciones que encuentre asociada
                grdAplicacionesPagosDevolucion.DataSource = AdministrarDevolucionDePrima.ConsultarAplicacionesDevolucion(Convert.ToInt32(Session["idDevolucion"].ToString()));
                grdAplicacionesPagosDevolucion.DataBind();
                //Session["idDevolucion"] = null;

                DataTable dtTemp = new DataTable();
                dtTemp = AdministrarDevolucionDePrima.ConsultarArchivosSoporteDevolucion(null, null, Convert.ToInt32(Session["idDevolucion"].ToString()));
                grvArchivosSoporte.DataSource = dtTemp;
                grvArchivosSoporte.DataBind();

                lblSoportes.Visible = false;
                lblDetalleAplicacion.Visible = false;

                if (dtTemp.Rows.Count > 0)
                {
                    lblSoportes.Visible = true;
                }
                if (grdAplicacionesPagosDevolucion.Rows.Count > 0)
                {
                    lblDetalleAplicacion.Visible = true;
                }
            }

        }
    }
}