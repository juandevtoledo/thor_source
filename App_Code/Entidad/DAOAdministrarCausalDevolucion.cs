using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para las causales de devoluciones
/// </summary>
public class DAOAdministrarCausalDevolucion
{
    /// <summary>
    /// Lista todas las causales de devolución del sistema
    /// </summary>
    /// <returns>Tabla con todas las causales de devolución</returns>
    public static DataTable sp_ListarNewCausalesDevoluciones()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewCausalesDevoluciones", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una causal de devolución
    /// </summary>
    /// <param name="causalDevolucionNombre">Nombre causal devolución</param>
    /// <param name="tipoDevolucionIdentificador">Tipo causal devolución</param>
    public static void sp_InsertarNewCausalDevolucion(string causalDevolucionNombre, long? tipoDevolucionIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCausalDevolucion", FrameworkEntidades.cnx);
        if (causalDevolucionNombre != null)
            cmd.Parameters.Add(new SqlParameter("@caudev_Nombre", causalDevolucionNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@caudev_Nombre", DBNull.Value));
        if (tipoDevolucionIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", tipoDevolucionIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de causal de devolución</returns>
    public static DataTable sp_ConsultarNewCausalDevolucion(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCausalDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", causalDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una causal de devolución por su ID para ser modificado
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de causal de devolución para ser modificado</returns>
    public static DataTable sp_ConsultarNewCausalDevolucionModificar(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCausalDevolucionModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", causalDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <param name="causalDevolucionNombre">Nuevo nombre causal devolución</param>
    /// <param name="tipoDevolucionIdentificador">Nuevo tipo causal devolución</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewCausalDevolucion(long causalDevolucionIdentificador, string causalDevolucionNombre, long? tipoDevolucionIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewCausalDevolucion", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@caudev_Id", causalDevolucionIdentificador));
            if (causalDevolucionNombre != null)
                cmd.Parameters.Add(new SqlParameter("@caudev_Nombre", causalDevolucionNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@caudev_Nombre", DBNull.Value));
            if (tipoDevolucionIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@tipdev_Id", tipoDevolucionIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@tipdev_Id", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la causal de devolución" : "OK";
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
    /// Elimina la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewCausalDevolucion(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewCausalDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", causalDevolucionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
