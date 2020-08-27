using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion3_PagosCompaniasDetalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int proceso = int.Parse(Session["idProceso"].ToString());
        if (proceso == 3)
        {
            DataTable dtFacturacion = (DataTable)Session["Facturacion"];
            int index = int.Parse(Session["idFacturacion"].ToString());
            ConsultarAplicacionesPago(dtFacturacion, index);
            ArmarArchivoFacturacion(dtFacturacion.Rows[index], dtFacturacion, index);
        }
        else
            if(proceso == 1)
            {
                DataTable dtFacturacion = (DataTable)Session["Facturacion"];
                int index = int.Parse(Session["idFacturacion"].ToString());
                ConsultarAplicacionesSolicitudCheques(dtFacturacion, index);
                //ArmarArchivoFacturacion(dtFacturacion.Rows[index], dtFacturacion, index);
            }
            else
                if (proceso == 2)
                {
                    DataTable dtFacturacion = (DataTable)Session["Facturacion"];
                    int index = int.Parse(Session["idFacturacion"].ToString());
                    ConsultarAplicacionesPago(dtFacturacion, index);
                    ArmarArchivoFacturacionReal(dtFacturacion.Rows[index], dtFacturacion, index);
                }
    }


    public void ArmarArchivoFacturacionReal(DataRow rowfacturacion, DataTable dtFacturacion, int index)
    {
        //DataTable dtResultado = dtFacturacion.Clone();
        DataTable dtResultado = new DataTable();
        DataColumn column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "IdentificadorRecibo";
        column.ColumnName = "IdentificadorRecibo";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "NumeroPoliza";
        column.ColumnName = "NumeroPoliza";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "Detalle";
        column.ColumnName = "Detalle";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "Localidad";
        column.ColumnName = "Localidad";
        dtResultado.Columns.Add(column);

        //DataRow drFacturacionDetalle = dtFacturacion.NewRow();
        DataRow drFacturacionDetalle = dtResultado.NewRow();

        List<List<int>> recibosUtilizados = (List<List<int>>)Session["recibosUtilizados"];

        foreach (List<int> reciboUtilizado in recibosUtilizados)
        {
            DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["NumeroPoliza"].ToString()));
            //DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["polId"].ToString()));
            string idfac = dtIdFacturacion.Rows[0]["pol_Id"].ToString();
            //if (reciboUtilizado[0] == int.Parse(rowfacturacion["IdentificadorRecibo"].ToString()))
            if (reciboUtilizado[0] == int.Parse(idfac))
            {
                DataTable dtSoportesBancarios = DAOAdministraPagosBolivar.ConsultarSoportesBancariosDesdeAplicacionPagos(reciboUtilizado[1]);

                int cont = 0;
                foreach (DataRow drSoporteBancario in dtSoportesBancarios.Rows)
                {
                    DataRow[] existeRecibo = dtResultado.Select("IdentificadorRecibo = '" + drSoporteBancario["rec_Id"].ToString() + "'");
                    if (existeRecibo.Count() == 0)
                    {
                        cont++;
                        drFacturacionDetalle = dtResultado.NewRow();
                        drFacturacionDetalle["IdentificadorRecibo"] = drSoporteBancario["rec_Id"];
                        drFacturacionDetalle["NumeroPoliza"] = drSoporteBancario["rec_Numero"];
                        drFacturacionDetalle["Detalle"] = drSoporteBancario["rec_Valor"];
                        drFacturacionDetalle["Localidad"] = drSoporteBancario["dep_Nombre"];
                        dtResultado.Rows.Add(drFacturacionDetalle);
                    }
                }
            }
        }
        grvRecibos.DataSource = dtResultado;
        grvRecibos.DataBind();
        Session["dtRecibos"] = dtResultado;
    }


    private void ConsultarAplicacionesSolicitudCheques(DataTable dtFacturacion, int index)
    {
        int solicitudCheques = int.Parse(dtFacturacion.Rows[0]["Valor"].ToString());
        DataTable aplicaciones = AdministrarPagosDetalle.ConsultarAplicaciones(dtFacturacion, index, solicitudCheques);
        grvAplicaciones.DataSource = aplicaciones;
        grvAplicaciones.DataBind();
        Session["dtAplicaciones"] = aplicaciones;
    }


    public void ArmarArchivoFacturacion(DataRow rowfacturacion, DataTable dtFacturacion, int index)
    {
        //DataTable dtResultado = dtFacturacion.Clone();
        DataTable dtResultado = new DataTable();
        DataColumn column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "IdentificadorRecibo";
        column.ColumnName = "IdentificadorRecibo";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "NumeroPoliza";
        column.ColumnName = "NumeroPoliza";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "Detalle";
        column.ColumnName = "Detalle";
        dtResultado.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.AllowDBNull = true;
        column.Caption = "Localidad";
        column.ColumnName = "Localidad";
        dtResultado.Columns.Add(column);

        //DataRow drFacturacionDetalle = dtFacturacion.NewRow();
        DataRow drFacturacionDetalle = dtResultado.NewRow();

        List<List<int>> recibosUtilizados = (List<List<int>>)Session["recibosUtilizados"];

        foreach (List<int> reciboUtilizado in recibosUtilizados)
        {
            //DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["NumeroPoliza"].ToString()));
            DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["polId"].ToString()));
            string idfac = dtIdFacturacion.Rows[0]["pol_Id"].ToString();
            //if (reciboUtilizado[0] == int.Parse(rowfacturacion["IdentificadorRecibo"].ToString()))
            if (reciboUtilizado[0] == int.Parse(idfac))
            {
                DataTable dtSoportesBancarios = DAOAdministraPagosBolivar.ConsultarSoportesBancariosDesdeAplicacionPagos(reciboUtilizado[1]);

                int cont = 0;
                foreach (DataRow drSoporteBancario in dtSoportesBancarios.Rows)
                {
                    DataRow[] existeRecibo = dtResultado.Select("IdentificadorRecibo = '" + drSoporteBancario["rec_Id"].ToString() + "'");
                    if (existeRecibo.Count() == 0)
                    {
                        cont++;
                        drFacturacionDetalle = dtResultado.NewRow();
                        drFacturacionDetalle["IdentificadorRecibo"] = drSoporteBancario["rec_Id"];
                        drFacturacionDetalle["NumeroPoliza"] = drSoporteBancario["rec_Numero"];
                        drFacturacionDetalle["Detalle"] = drSoporteBancario["rec_Valor"];
                        drFacturacionDetalle["Localidad"] = drSoporteBancario["dep_Nombre"];
                        dtResultado.Rows.Add(drFacturacionDetalle);
                    }
                }
            }
        }
        grvRecibos.DataSource = dtResultado;
        grvRecibos.DataBind();
        Session["dtRecibos"] = dtResultado;
    }


    public void ConsultarAplicacionesPago(DataTable dtFacturacion, int index)
    {
        DataTable dtAplicaciones = new DataTable();
        try
        {
            dtAplicaciones = DAOAdministraPagosBolivar.ConsultarAplicacionesPorFacturacion(double.Parse(dtFacturacion.Rows[index]["Facturacion"].ToString()));
        }
        catch
        {
            dtAplicaciones = DAOAdministraPagosBolivar.ConsultarAplicacionesPorFacturacion(double.Parse(dtFacturacion.Rows[index]["factId"].ToString()));
        }       
        
        dtAplicaciones = IncluirNovedadesAplicaciones(dtAplicaciones);
        grvAplicaciones.DataSource = dtAplicaciones;
        grvAplicaciones.DataBind();
        Session["dtAplicaciones"] = dtAplicaciones;
    }

    public DataTable IncluirNovedadesAplicaciones(DataTable dtAplicaciones)
    {
        DateTime fechaPago = DateTime.Parse(Session["fechaPago"].ToString());
        dtAplicaciones = DAOAdministraPagosBolivar.ConsultarNovedadesPorAplicaciones(dtAplicaciones, fechaPago);
        return dtAplicaciones;
    }

    //public void ArmarArchivoFacturacion(DataRow rowfacturacion, DataTable dtFacturacion, int index)
    //{
    //    DataTable dtResultado = dtFacturacion.Clone();
    //    DataRow drFacturacionDetalle = dtFacturacion.NewRow();

    //    List<List<int>> recibosUtilizados = (List<List<int>>)Session["recibosUtilizados"];

    //    foreach (List<int> reciboUtilizado in recibosUtilizados)
    //    {
    //        //DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["NumeroPoliza"].ToString()));
    //        DataTable dtIdFacturacion = DAOAdministraPagosBolivar.ConsultarIdFacturacion(long.Parse(rowfacturacion["polId"].ToString()));
    //        string idfac = dtIdFacturacion.Rows[0]["pol_Id"].ToString();
    //        //if (reciboUtilizado[0] == int.Parse(rowfacturacion["IdentificadorRecibo"].ToString()))
    //        if (reciboUtilizado[0] == int.Parse(idfac))
    //        {
    //            DataTable dtSoportesBancarios = DAOAdministraPagosBolivar.ConsultarSoportesBancariosDesdeAplicacionPagos(reciboUtilizado[1]);

    //            int cont = 0;
    //            foreach (DataRow drSoporteBancario in dtSoportesBancarios.Rows)
    //            {
    //                DataRow[] existeRecibo = dtResultado.Select("IdentificadorRecibo = '" + drSoporteBancario["rec_Id"].ToString() + "'");
    //                if (existeRecibo.Count() == 0)
    //                {
    //                    cont++;
    //                    drFacturacionDetalle = dtResultado.NewRow();
    //                    drFacturacionDetalle["IdentificadorRecibo"] = drSoporteBancario["rec_Id"];
    //                    drFacturacionDetalle["NumeroPoliza"] = drSoporteBancario["rec_Numero"];
    //                    drFacturacionDetalle["Detalle"] = drSoporteBancario["rec_Valor"];
    //                    drFacturacionDetalle["Localidad"] = drSoporteBancario["dep_Nombre"];
    //                    dtResultado.Rows.Add(drFacturacionDetalle);
    //                }
    //            }
    //        }
    //    }
    //    grvRecibos.DataSource = dtResultado;
    //    grvRecibos.DataBind();
    //    Session["dtRecibos"] = dtResultado;
    //}

    protected void btnExportarAplicaciones_Click(object sender, EventArgs e)
    {
        DataTable dtAplicaciones = (DataTable)Session["dtAplicaciones"];
        Funciones.generarExcel(Page, dtAplicaciones, "Aplicaciones");
    }

    protected void btnExportarRecibos_Click(object sender, EventArgs e)
    {
        DataTable dtRecibos = (DataTable)Session["dtRecibos"];
        Funciones.generarExcel(Page, dtRecibos, "Recibos");
    }
}