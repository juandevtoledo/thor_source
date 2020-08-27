using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// En esta clase se encuentran las funciones para diferentes usos.
/// </summary>
public class Funciones
{
	public Funciones()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    //Función para calcular edad
    public static int Edad(DateTime fechaNacimiento)
    {
        ////Obtengo la diferencia en años.
        //int edad = DateTime.Now.Year - fechaNacimiento.Year;

        ////Obtengo la fecha de cumpleaños de este año.
        //DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);

        ////Le resto un año si la fecha actual es anterior 
        ////al día de nacimiento.
        //if (DateTime.Now.CompareTo(nacimientoAhora) > 0)
        //{
        //    edad--;
        //}
        //DateTime nacimiento = new DateTime(2000, 1, 25); //Fecha de nacimiento
        int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
        return edad;
    }

    public static int FechaIngresoAsegurado(DateTime fechaExpedicion, DateTime fechaNacimiento)
    {
        int edad = fechaExpedicion.AddTicks(-fechaNacimiento.Ticks).Year - 1;
        return edad;
    }

    //Metodo que exporta a excel un datatable, con el nombre asigando
    public static void generarExcel(Page pg, DataTable dt, String filename)
    {
        string attachment = "attachment; filename=" + filename + ".xls";

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }
        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";
            }
            pg.Response.Write("\n");
        }
        pg.Response.End();
    }

    // Generar excel cuenta de cobro
    public static void generarExcelCuentaCobro(Page pg, DataTable dt, DataTable dtd, String filename)
    {
        string attachment = "attachment; filename=" + filename + ".xls";

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }
        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";
            }
            pg.Response.Write("\n");
        }

        pg.Response.Write("\n");
        pg.Response.Write("\n");
        string tabd = string.Empty;

        foreach (DataColumn dtdcol in dtd.Columns)
        {
            pg.Response.Write(tabd + dtdcol.ColumnName);
            tabd = "\t";
        }
        pg.Response.Write("\n");
        foreach (DataRow dtdr in dtd.Rows)
        {
            tabd = "";
            for (int j = 0; j < dtd.Columns.Count; j++)
            {
                pg.Response.Write(tabd + Convert.ToString(dtdr[j]));
                tabd = "\t";
            }
            pg.Response.Write("\n");
        }
        pg.Response.End();
    }


    //Función para validar campo vacio /JC
    public static string validarCampoVacio(string valor)
    {
        string mensaje;

        if (valor == "")
        {
            mensaje = "El campo no puede estar vacio";
        }
        else
        {
            mensaje = "";
        }
        return mensaje;
    }


    //Función para calcular meses mora en pagos
    public static int calcularMora(DateTime ultimaVigencia)
    {
        int añosMora;
        int mesesMora;
        DateTime fechaActual = DateTime.Now;
        DateTime vigencia = ultimaVigencia;
        añosMora = fechaActual.Year - vigencia.Year;
        mesesMora = fechaActual.Month - vigencia.Month;
        return mesesMora;
    }


    public void ocultarBotones(MasterPage Master, DataTable dtlistPermisos)
    {
        foreach (DataRow row in dtlistPermisos.Rows)
        {
            ContentPlaceHolder mpContentPlaceHolder;
            GridView grid;
            Button btn;
            //LinkButton link;
            mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

            if (mpContentPlaceHolder != null)
            {
                btn = (Button)mpContentPlaceHolder.FindControl(row["id"].ToString());
                if(btn != null)
                {
                    btn.Visible = false;
                }
                
                grid = (GridView)mpContentPlaceHolder.FindControl(row["idPadre"].ToString());

                if(grid != null)
                {
                    foreach (GridViewRow key in grid.Rows)
                    {
                        LinkButton link = (LinkButton)key.FindControl(row["id"].ToString());
                        if (link != null)
                        {
                            link.Visible = false;
                        }
                        
                    }
                }
                
                
            }
        }
    }



    public static void generarExcelSolicitudCheque(Page pg, DataTable dt, String filename, DateTime fecha)
    {
        string attachment = "attachment; filename=" + filename + ".xls";

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        pg.Response.Write("SOLICITUD DE CHEQUES PARA PAGO SEGUROS BOLIVAR");
        pg.Response.Write("\n");
        pg.Response.Write(fecha);
        pg.Response.Write("\n");
        pg.Response.Write("\n");        
        pg.Response.Write("\n");
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }
        int valorTotal = 0;
        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }
            valorTotal = valorTotal + int.Parse(dr["Valor"].ToString());
            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");
        pg.Response.Write("TOTAL");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write(Convert.ToString(valorTotal));
        pg.Response.End();
    }


    public static void generarExcelPago(Page pg, DataSet ds, String filename)
    {
         string attachment = "attachment; filename=" + filename + ".xls";

        DataTable dt;

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        pg.Response.Write("PAGO COMPAÑIA");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");

        dt = (DataTable)ds.Tables["FacturacionesPago"];
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        int valorTotal = 0;
        int valorParaComision = 0;
        double valorComision = 0;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }
            valorTotal = valorTotal + int.Parse(dr["Valor Total"].ToString());
            valorParaComision = valorParaComision + int.Parse(dr["valor Para Comision"].ToString());
            valorComision = valorComision + double.Parse(dr["Total Comision"].ToString());

            pg.Response.Write("\n");
        }


        pg.Response.Write("\n");
        pg.Response.Write("TOTALES");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");  
		pg.Response.Write("\t");
        pg.Response.Write(Convert.ToString(valorTotal));
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");     
        pg.Response.Write(Convert.ToString(valorParaComision));
        pg.Response.Write("\t");
        pg.Response.Write("\t"); 
        pg.Response.Write(Convert.ToString(valorComision));
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("LIBRANZAS");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables["LibranzasPago"];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }


        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("SOPORTES TALON");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables["SoportesPago"];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");

        pg.Response.End();
    }

    public static void generarDetallesPago(Page pg, DataSet ds, String filename)
    {
        string attachment = "attachment; filename=" + filename + ".xls";

        DataTable dt;

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        pg.Response.Write("DETALLES APLICACIONES PMI");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");

        DataTable dtDetallesPago = (DataTable)ds.Tables["DetallesPago"];
        DataTable dtNovedadesPago = (DataTable)ds.Tables["NovedadesPago"];
        foreach (DataColumn dtcol in dtDetallesPago.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dtDetallesPago.Rows)
        {
            if (dr["Producto"].ToString() == "710")
            {
                tab = "";
                for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                {
                    
                    pg.Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                }
                pg.Response.Write("\n");
            }

           
        }


        pg.Response.Write("\n");        
        pg.Response.Write("NOVEDADES PMI");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        //dt = (DataTable)ds.Tables["NovedadesPago"];
        tab = "";
        foreach (DataColumn dtcol in dtNovedadesPago.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dtNovedadesPago.Rows)
        {
            if (dr["Producto"].ToString() == "EDUCADORES")
            {
                tab = "";
                for (int j = 0; j < dtNovedadesPago.Columns.Count; j++)
                {
                    
                    pg.Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";

                }
                pg.Response.Write("\n");
            }

            
        }
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("DETALLES APLICACIONES PLUS");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        tab = "";
        //dt = (DataTable)ds.Tables["DetallesPago"];
        foreach (DataColumn dtcol in dtDetallesPago.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dtDetallesPago.Rows)
        {
            if (dr["Producto"].ToString() == "799")
            {
                tab = "";
                for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                {
                    
                    pg.Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                }
                pg.Response.Write("\n");
            }

            
        }


        pg.Response.Write("\n");
        pg.Response.Write("NOVEDADES PLUS");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        //dt = (DataTable)ds.Tables["NovedadesPago"];
        tab = "";
        foreach (DataColumn dtcol in dtNovedadesPago.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dtNovedadesPago.Rows)
        {
            if (dr["Producto"].ToString() == "EDUCADORES PLUS")
            {
                tab = "";
                for (int j = 0; j < dtNovedadesPago.Columns.Count; j++)
                {
                    
                    pg.Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";

                }
                pg.Response.Write("\n");
            }

            
        }


        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("DETALLES APLICACIONES PLAN CRECIENTE");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        tab = "";
        //dt = (DataTable)ds.Tables["DetallesPago"];
        foreach (DataColumn dtcol in dtDetallesPago.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dtDetallesPago.Rows)
        {
            if (dr["Producto"].ToString() == "700")
            {
                tab = "";
                for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                {

                    pg.Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                }
                pg.Response.Write("\n");
            }


        }
		
		
		
		if(filename == "Detalles - Novedades FIDUCIAS")
        {
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("DETALLES APLICACIONES KARISEGUROS");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            tab = "";
            //dt = (DataTable)ds.Tables["DetallesPago"];
            foreach (DataColumn dtcol in dtDetallesPago.Columns)
            {
                pg.Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
            }

            pg.Response.Write("\n");
            foreach (DataRow dr in dtDetallesPago.Rows)
            {
                if (dr["Producto"].ToString() == "711")
                {
                    tab = "";
                    for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                    {

                        pg.Response.Write(tab + Convert.ToString(dr[j]));
                        tab = "\t";
                    }
                    pg.Response.Write("\n");
                }


            }

            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("DETALLES APLICACIONES CRUZ VILLEGAS");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            tab = "";
            //dt = (DataTable)ds.Tables["DetallesPago"];
            foreach (DataColumn dtcol in dtDetallesPago.Columns)
            {
                pg.Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
            }

            pg.Response.Write("\n");
            foreach (DataRow dr in dtDetallesPago.Rows)
            {
                if (dr["Producto"].ToString() == "712")
                {
                    tab = "";
                    for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                    {

                        pg.Response.Write(tab + Convert.ToString(dr[j]));
                        tab = "\t";
                    }
                    pg.Response.Write("\n");
                }


            }



            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("DETALLES APLICACIONES OLARTE LUNA");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            pg.Response.Write("\n");
            tab = "";
            //dt = (DataTable)ds.Tables["DetallesPago"];
            foreach (DataColumn dtcol in dtDetallesPago.Columns)
            {
                pg.Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
            }

            pg.Response.Write("\n");
            foreach (DataRow dr in dtDetallesPago.Rows)
            {
                if (dr["Producto"].ToString() == "713")
                {
                    tab = "";
                    for (int j = 0; j < dtDetallesPago.Columns.Count; j++)
                    {

                        pg.Response.Write(tab + Convert.ToString(dr[j]));
                        tab = "\t";
                    }
                    pg.Response.Write("\n");
                }


            }



        }
        		
		
		pg.Response.Write("\n");

        pg.Response.End();
    }

    public static void generarExcelPagoCompañia(Page pg, DataSet ds, String filename)
    {
        string attachment = "attachment; filename=" + filename + ".xls";

        DataTable dt;

        pg.Response.ClearContent();
        pg.Response.HeaderEncoding = System.Text.Encoding.Default;
        pg.Response.ContentEncoding = System.Text.Encoding.Default;
        pg.Response.AddHeader("content-disposition", attachment);
        pg.Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        pg.Response.Write("PAGO COMPAÑIA");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");

        dt = (DataTable)ds.Tables[0];
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        int valorTotal = 0;
        int valorParaComision = 0;
        double valorComision = 0;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }
            //valorTotal = valorTotal + int.Parse(dr["Valor Total"].ToString());
            //valorParaComision = valorParaComision + int.Parse(dr["valor Para Comision"].ToString());
            //valorComision = valorComision + double.Parse(dr["Total Comision"].ToString());

            pg.Response.Write("\n");
        }


        pg.Response.Write("\n");
        pg.Response.Write("TOTALES");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write(Convert.ToString(valorTotal));
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        //pg.Response.Write(Convert.ToString(valorParaComision));
        pg.Response.Write("\t");
        pg.Response.Write("\t");
        //pg.Response.Write(Convert.ToString(valorComision));
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        
        pg.Response.Write("TOTALES GR");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables[1];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }


        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("COMISIONES");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables[2];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        /*dt = (DataTable)ds.Tables[3];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");*/


        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("TRANSFERENCIAS");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables[4];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";

            }

            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");

        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("\n");
        pg.Response.Write("RECIBOS DE CAJA");
        pg.Response.Write("\n");
        dt = (DataTable)ds.Tables[3];
        tab = "";
        foreach (DataColumn dtcol in dt.Columns)
        {
            pg.Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }

        pg.Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                pg.Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";
            }

            pg.Response.Write("\n");
        }
        pg.Response.Write("\n");

        pg.Response.End();
    }

}