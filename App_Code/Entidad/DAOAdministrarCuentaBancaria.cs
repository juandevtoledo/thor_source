using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdministrarCompania
/// </summary>
public class DAOAdministrarCuentaBancaria
{
    public static DataTable sp_ListarNewCuentasBancarias()
    {
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewCuentasBancarias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static void sp_InsertarNewCuentaBancaria(long numeroCuentaBancaria)
    {

        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCuentaBancaria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueBan_Numero", numeroCuentaBancaria));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

    }

    public static DataTable sp_ConsultarNewCuentaBancaria(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCuentaBancaria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static DataTable sp_ConsultarNewCuentaBancariaModificar(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCuentaBancariaModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static string sp_ActualizarNewCuentaBancaria(long cuentaBancariaID, long numeroCuentaBancaria)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewCuentaBancaria", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaID));
            cmd.Parameters.Add(new SqlParameter("@cueBan_Numero", numeroCuentaBancaria));

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
    public static DataTable sp_EliminarNewCuentaBancaria(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewCuentaBancaria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cuentaBancariaID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;


    }
}