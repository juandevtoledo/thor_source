using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdministrarCompania
/// </summary>
public class DAOAdministrarAmparo
{
    public static DataTable sp_ListarAmparos()
    {
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarAmparos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static void sp_InsertarAmparo(string nombreAmparo)
    {

        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAmparo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@amp_Nombre", nombreAmparo));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable sp_ConsultarAmparo(int AmparoID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@amp_Id", AmparoID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static DataTable sp_ConsultarAmparoModificar(int AmparoID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparoModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@amp_Id", AmparoID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public static string sp_ActualizarAmparo(int AmparoID, string nombreAmparo)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarAmparo", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@amp_Id", AmparoID));
            cmd.Parameters.Add(new SqlParameter("@amp_Nombre", nombreAmparo));

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
    public static DataTable sp_EliminarAmparo(int AmparoID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarAmparo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@amp_Id", AmparoID));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;


    }
}