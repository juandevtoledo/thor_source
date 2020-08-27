using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los tipos de cuentas
/// </summary>
public class DAOAdministrarTipoCuenta
{
    /// <summary>
    /// Lista todos los tipos de cuentas del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de cuentas</returns>
    public static DataTable sp_ListarNewTiposCuentas()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewTiposCuentas", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de cuenta
    /// </summary>
    /// <param name="tipoCuentaNombre">Nombre de tipo de cuenta</param>
    public static void sp_InsertarNewTipoCuenta(string tipoCuentaNombre)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTipoCuenta", FrameworkEntidades.cnx);
        if (tipoCuentaNombre != null)
            cmd.Parameters.Add(new SqlParameter("@TipCue_Nombre", tipoCuentaNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@TipCue_Nombre", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de cuenta</returns>
    public static DataTable sp_ConsultarNewTipoCuenta(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de cuenta por su ID para ser modificado
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de cuenta para ser modificado</returns>
    public static DataTable sp_ConsultarNewTipoCuentaModificar(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoCuentaModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <param name="tipoCuentaNombre">Nuevo nombre de tipo de cuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewTipoCuenta(long tipoCuentaIdentificacion, string tipoCuentaNombre)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewTipoCuenta", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificacion));
            if (tipoCuentaNombre != null)
                cmd.Parameters.Add(new SqlParameter("@TipCue_Nombre", tipoCuentaNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@TipCue_Nombre", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el tipo de cuenta" : "OK";
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
    /// Elimina la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewTipoCuenta(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
