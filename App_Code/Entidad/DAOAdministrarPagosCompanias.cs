using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de DAOAdministrarPagosCompanias
/// </summary>
public class DAOAdministrarPagosCompanias
{
    

    #region PAGOS OTRAS COMPAÑIAS
    //Metodo que calcula el pago para un producto desde la fecha

    public DataSet CalcularPagoProducto(DateTime fecha, int producto, DateTime vigencia)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CalcularPagoProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 100000;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        FrameworkEntidades.cnx.Close();
        return ds;
    }

    //Metodo que consultas todos los detalles asociados a un pago para el producto y la fecha seleccionada
    public DataTable ConsultarDetallesPagosCias(DateTime fecha, int producto,DateTime vigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDetallesPagosCias", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 20000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Metodo que crea el pago para el producto y en la fecha indicada, marca las aplicaciones respectivas para no volver a ser usadas.
    public DataTable CrearPagoOtrasCias(DateTime fecha, int producto, DateTime vigencia)
    {
        DataSet dsPagoLocalidad = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearPagoOtrasCias", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 100000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Metodo que consultas todos los pagos generados por el producto seleccionado para el rango de fechas seleccionados
    public DataTable ConsultarHistoricoProductoPagosCias(DateTime fechaInicio, DateTime fechaFin, int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarHistoricoProductoPagosCias", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        //cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 20000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Metodo que devuelve el pago seleccionado, retorna un Dataset con 5 tablas con los items respectivos del pago
    public DataSet ConsultarPagoProducto(int pagId)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagoProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pago_Id", pagId));  
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 100000;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        FrameworkEntidades.cnx.Close();
        return ds;
    }

    //Metodo que devuelve los asegurados uno a uno de los negocios nuevos con pago aplicado para el inicio de vigencia
    public DataTable ConsultarProduccionAplicada(int producto, DateTime vigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProduccionAplicada", FrameworkEntidades.cnx);        
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));
        //cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 20000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }



    //Metodo que consultas todos los detalles asociados a un pago ya enviado
    public DataTable ConsultarDetallesPagosCiasEnviado(int pagoId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDetallesPagosCiasEnviado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pago", pagoId));
        //cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 20000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Metodo que devuelve el cargue de clientes por cada asegurado para el pago a la compañia del producto seleccionado y la vigencia

    public DataTable ConsultarArchivoCarguePagoCompañia(int producto, DateTime vigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ArchivoCarguePagoCompañia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@prod", producto));
        cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));
        //cmd.Parameters.Add(new SqlParameter("@vigencia", vigencia));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 20000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    #endregion
}