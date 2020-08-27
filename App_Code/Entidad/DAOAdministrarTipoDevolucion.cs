using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los tipos de devoluciones
/// </summary>
public class DAOAdministrarTipoDevolucion
{
    /// <summary>
    /// Lista todos los tipos de devoluciones del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de devoluciones</returns>
    public static DataTable sp_ListarNewTiposDevoluciones()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewTiposDevoluciones", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de devolución
    /// </summary>
    /// <param name="tipoDevolucionNombre">Nombre tipo devolución</param>
    /// <param name="tipoDevolucionRecuperable">Tipo devolución es recuperable</param>
    public static void sp_InsertarNewTipoDevolucion(string tipoDevolucionNombre, int? tipoDevolucionRecuperable)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTipoDevolucion", FrameworkEntidades.cnx);
        if (tipoDevolucionNombre != null)
            cmd.Parameters.Add(new SqlParameter("@Tipdev_Nombre", tipoDevolucionNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@Tipdev_Nombre", DBNull.Value));
        if (tipoDevolucionRecuperable != null)
            cmd.Parameters.Add(new SqlParameter("@Tipdev_Recuperable", tipoDevolucionRecuperable));
        else
            cmd.Parameters.Add(new SqlParameter("@Tipdev_Recuperable", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de devolución</returns>
    public static DataTable sp_ConsultarNewTipoDevolucion(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@Tipdev_Id", tipoDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de devolución por su ID para ser modificado
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de devolución para ser modificado</returns>
    public static DataTable sp_ConsultarNewTipoDevolucionModificar(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoDevolucionModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@Tipdev_Id", tipoDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <param name="tipoDevolucionNombre">Nuevo nombre tipo devolución</param>
    /// <param name="tipoDevolucionRecuperable">Nuevo tipo devolución es recuperable</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewTipoDevolucion(long tipoDevolucionIdentificador, string tipoDevolucionNombre, int? tipoDevolucionRecuperable)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewTipoDevolucion", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Tipdev_Id", tipoDevolucionIdentificador));
            if (tipoDevolucionNombre != null)
                cmd.Parameters.Add(new SqlParameter("@Tipdev_Nombre", tipoDevolucionNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@Tipdev_Nombre", DBNull.Value));
            if (tipoDevolucionRecuperable != null)
                cmd.Parameters.Add(new SqlParameter("@Tipdev_Recuperable", tipoDevolucionRecuperable));
            else
                cmd.Parameters.Add(new SqlParameter("@Tipdev_Recuperable", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el tipo de devolución" : "OK";
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
    /// Elimina la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewTipoDevolucion(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTipoDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@Tipdev_Id", tipoDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
