using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para las ocupaciones
/// </summary>
public class DAOAdministrarOcupacion
{
    /// <summary>
    /// Lista todas las ocupaciones del sistema
    /// </summary>
    /// <returns>Tabla con todas las ocupaciones</returns>
    public static DataTable sp_ListarOcupaciones()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarOcupaciones", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una ocupación
    /// </summary>
    /// <param name="ocupacionNombre">Nombre de ocupación</param>
    public static void sp_InsertarOcupacion(string ocupacionNombre)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarOcupacion", FrameworkEntidades.cnx);
        if (ocupacionNombre != null)
            cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", ocupacionNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de ocupación</returns>
    public static DataTable sp_ConsultarOcupacion(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOcupacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ocupacionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una ocupación por su ID para ser modificado
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de ocupación para ser modificado</returns>
    public static DataTable sp_ConsultarOcupacionModificar(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOcupacionModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ocupacionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <param name="ocupacionNombre">Nuevo nombre de ocupación</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarOcupacion(long ocupacionIdentificador, string ocupacionNombre)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarOcupacion", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ocu_Id", ocupacionIdentificador));
            if (ocupacionNombre != null)
                cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", ocupacionNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la ocupación" : "OK";
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
    /// Elimina la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarOcupacion(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarOcupacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ocupacionIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    public static DataTable sp_BuscarOcupacion(int id, string nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarOcupacion", FrameworkEntidades.cnx);

        if (id > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@ocu_Id", id));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ocu_Id", DBNull.Value));
        }

        if (nombre != "")
        {
            cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", nombre));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ocu_Nombre", DBNull.Value));
        }
        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}
