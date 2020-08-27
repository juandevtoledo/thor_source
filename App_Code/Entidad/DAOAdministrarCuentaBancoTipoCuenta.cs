using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para las cuentas bancarias por bancos por tipos de cuentas
/// </summary>
public class DAOAdministrarCuentaBancoTipoCuenta
{
    /// <summary>
    /// Lista todas las cuentas bancarias por bancos por tipos de cuentas del sistema
    /// </summary>
    /// <returns>Tabla con todas las cuentas bancarias por bancos por tipos de cuentas</returns>
    public static DataTable sp_ListarNewCuentasBancariasPorBancosTiposCuentas()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewCuentasBancariasPorBancosTiposCuentas", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una cuenta bancaria por banco por tipo de cuenta
    /// </summary>
    /// <param name="bancoIdentifcador">Banco</param>
    /// <param name="tipoCuentaIdentificador">Tipo Cuenta</param>
    /// <param name="cuentaBancariaIdentificador">Cuenta</param>
    public static void sp_InsertarNewCuentaBancariaPorBancoTipoCuenta(long bancoIdentifcador, long tipoCuentaIdentificador, long cuentaBancariaIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCuentaBancariaPorBancoTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoIdentifcador));
        cmd.Parameters.Add(new SqlParameter("@tipCue_Id", tipoCuentaIdentificador));
        cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de cuenta bancaria por banco por tipo de cuenta</returns>
    public static DataTable sp_ConsultarNewCuentaBancariaPorBancoTipoCuenta(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCuentaBancariaPorBancoTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@banCueBan_Id", cuentaBancoTipoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una cuenta bancaria por banco por tipo de cuenta por su ID para ser modificado
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de cuenta bancaria por banco por tipo de cuenta para ser modificado</returns>
    public static DataTable sp_ConsultarNewCuentaBancariaPorBancoTipoCuentaModificar(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCuentaBancariaPorBancoTipoCuentaModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@banCueBan_Id", cuentaBancoTipoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <param name="bancoIdentifcador">Nuevo banco</param>
    /// <param name="tipoCuentaIdentificador">Nuevo tipo cuenta</param>
    /// <param name="cuentaBancariaIdentificador">Nuevo cuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewCuentaBancariaPorBancoTipoCuenta(long cuentaBancoTipoIdentificador, long bancoIdentifcador, long tipoCuentaIdentificador, long cuentaBancariaIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewCuentaBancariaPorBancoTipoCuenta", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@banCueBan_Id", cuentaBancoTipoIdentificador));
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoIdentifcador));
            cmd.Parameters.Add(new SqlParameter("@tipCue_Id", tipoCuentaIdentificador));
            cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaIdentificador));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la cuenta bancaria por banco por tipo de cuenta" : "OK";
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
    /// Elimina la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewCuentaBancariaPorBancoTipoCuenta(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewCuentaBancariaPorBancoTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@banCueBan_Id", cuentaBancoTipoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
