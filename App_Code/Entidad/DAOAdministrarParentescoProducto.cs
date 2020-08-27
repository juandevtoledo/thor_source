using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los parentescos por productos
/// </summary>
public class DAOAdministrarParentescoProducto
{
    /// <summary>
    /// Lista todos los parentescos por productos del sistema
    /// </summary>
    /// <returns>Tabla con todos los parentescos por productos</returns>
    public static DataTable sp_ListarNewParentescosPorProductos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewParentescosPorProductos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un parentesco por  producto
    /// </summary>
    /// <param name="parentescoIdentificador">Parentesco</param>
    /// <param name="productorIdentificador">Producto</param>
    public static void sp_InsertarNewParentescoPorProducto(long parentescoIdentificador, long productorIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewParentescoPorProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@par_Id", parentescoIdentificador));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", productorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco por producto</returns>
    public static DataTable sp_ConsultarNewParentescoPorProducto(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewParentescoPorProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parpro_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un parentesco por  producto por su ID para ser modificado
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco por producto para ser modificado</returns>
    public static DataTable sp_ConsultarNewParentescoPorProductoModificar(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewParentescoPorProductoModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parpro_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <param name="parentescoIdentificador">Nuevo parentesco</param>
    /// <param name="productorIdentificador">Nuevo producto</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewParentescoPorProducto(long parentescoProductoIdentificador, long parentescoIdentificador, long productorIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewParentescoPorProducto", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@parpro_Id", parentescoProductoIdentificador));
            cmd.Parameters.Add(new SqlParameter("@par_Id", parentescoIdentificador));
            cmd.Parameters.Add(new SqlParameter("@pro_Id", productorIdentificador));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el parentesco por producto" : "OK";
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

    /// <summary>
    /// Elimina la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewParentescoPorProducto(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewParentescoPorProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parpro_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
