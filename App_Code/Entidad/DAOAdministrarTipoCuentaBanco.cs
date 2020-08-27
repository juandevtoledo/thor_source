using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para Las tipos cuenta por banco
/// </summary>
public class DAOAdministrarTipoCuentaBanco
{
    /// <summary>
    /// Lista todas las tipos cuentas por bancos del sistema
    /// </summary>
    /// <returns>Tabla con todas las tipos cuentas por bancos</returns>
    public static DataTable sp_ListarNewTiposCuentasBancos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewTiposCuentasBancos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo cuenta por banco
    /// </summary>
    /// <param name="bancoIdentificador">Banco</param>
    /// <param name="tipoCuentaIdentificador">TipoCuenta</param>
    public static void sp_InsertarNewTipoCuentaBanco(long? bancoIdentificador, long? tipoCuentaIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTipoCuentaBanco", FrameworkEntidades.cnx);
        if (bancoIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@ban_Id", DBNull.Value));
        if (tipoCuentaIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@TipCue_Id", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo cuenta por banco</returns>
    public static DataTable sp_ConsultarNewTipoCuentaBanco(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoCuentaBanco", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tibCueBan_Id", TipoCuentaBancoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo cuenta por banco por su ID para ser modificado
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo cuenta por banco para ser modificado</returns>
    public static DataTable sp_ConsultarNewTipoCuentaBancoModificar(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoCuentaBancoModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tibCueBan_Id", TipoCuentaBancoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <param name="bancoIdentificador">Nuevo banco</param>
    /// <param name="tipoCuentaIdentificador">Nuevo tipocuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewTipoCuentaBanco(long TipoCuentaBancoIdentificador, long? bancoIdentificador, long? tipoCuentaIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewTipoCuentaBanco", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tibCueBan_Id", TipoCuentaBancoIdentificador));
            if (bancoIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@ban_Id", DBNull.Value));
            if (tipoCuentaIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@TipCue_Id", tipoCuentaIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@TipCue_Id", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el tipo cuenta por banco" : "OK";
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
    /// Elimina la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewTipoCuentaBanco(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTipoCuentaBanco", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tibCueBan_Id", TipoCuentaBancoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
