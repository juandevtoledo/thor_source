using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdministrarCompania
/// </summary>
public class DAOAdministrarProducto
{
    public static DataTable sp_ListarNewProductos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewProductos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();


        return dt;
    }
    public static void sp_InsertarNewProducto(int companiaID, string nombreProducto, int? mesesGraciaProducto, int cumulo, int mesRecuperacion, int prioridadPago, int prioridadDevolucion, int? estadoProducto)
    {

        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", companiaID));
        cmd.Parameters.Add(new SqlParameter("@pro_Nombre", nombreProducto));
        if (mesesGraciaProducto != null)
            cmd.Parameters.Add(new SqlParameter("@pro_MesesGracia", mesesGraciaProducto));
        else
            cmd.Parameters.Add(new SqlParameter("@pro_MesesGracia", DBNull.Value));
        if (estadoProducto != null)
            cmd.Parameters.Add(new SqlParameter("@pro_Estado", estadoProducto));
        else
            cmd.Parameters.Add(new SqlParameter("@pro_Estado", DBNull.Value));

        cmd.Parameters.Add(new SqlParameter("@cumulo", cumulo));
        cmd.Parameters.Add(new SqlParameter("@mesesRecuperacion", mesRecuperacion));
        cmd.Parameters.Add(new SqlParameter("@prioridadPago", prioridadPago));
        cmd.Parameters.Add(new SqlParameter("@PrioridadDevolucion", prioridadDevolucion));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();


    }

    public static DataTable sp_ConsultarNewProductoModificar(int productoID)
    {
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewProductoModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", productoID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();


        return dt;
    }
    public static string sp_ActualizarNewProducto(int productoID, int companiaID, string nombreProducto, int? mesesGraciaProducto, int cumulo, int mesRecuperacion, int prioridadPago, int prioridadDevolucion, int? estadoProducto)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewProducto", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pro_Id", productoID));
            cmd.Parameters.Add(new SqlParameter("@com_Id", companiaID));
            cmd.Parameters.Add(new SqlParameter("@pro_Nombre", nombreProducto));
            if (mesesGraciaProducto != null)
                cmd.Parameters.Add(new SqlParameter("@pro_MesesGracia", mesesGraciaProducto));
            else
                cmd.Parameters.Add(new SqlParameter("@pro_MesesGracia", DBNull.Value));
            if (estadoProducto != null)
                cmd.Parameters.Add(new SqlParameter("@pro_Estado", estadoProducto));
            else
                cmd.Parameters.Add(new SqlParameter("@pro_Estado", DBNull.Value));

            cmd.Parameters.Add(new SqlParameter("@cumulo", cumulo));
            cmd.Parameters.Add(new SqlParameter("@mesesRecuperacion", mesRecuperacion));
            cmd.Parameters.Add(new SqlParameter("@prioridadPago", prioridadPago));
            cmd.Parameters.Add(new SqlParameter("@PrioridadDevolucion", prioridadDevolucion));


            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la compañia" : "OK";
        }
        catch (Exception ex)
        {
            rpta = ex.Message;
        }
        finally
        {
            if (FrameworkEntidades.cnx.State == ConnectionState.Open) FrameworkEntidades.cnx.Close();
        }
        FrameworkEntidades.cnx.Close();
        return rpta;
    }
    public static DataTable sp_EliminarNewProducto(int productoID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", productoID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;


    }

    public static DataTable sp_BuscarNewProducto(int id, string compania, string producto, string estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarNewProducto", FrameworkEntidades.cnx);

        if (id > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", id));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", DBNull.Value));
        }

        if (compania != "")
        {
            cmd.Parameters.Add(new SqlParameter("@com_Nombre", compania));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@com_Nombre", DBNull.Value));
        }

        if (producto != "")
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Nombre", producto));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Nombre", DBNull.Value));
        }

        if (estado != "")
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Estado", estado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Estado", DBNull.Value));
        }


        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}