using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdministrarCompania
/// </summary>
public class DAOAdministrarBanco
{
    public static DataTable sp_ListarNewBancos()
    {
        DataTable dt = new DataTable();
        try
        {
            
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarNewBancos", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();
        }
        catch (Exception ex)
        { }

        return dt;
    }
    public static void sp_InsertarNewBanco(string nombreBanco)
    {
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertarNewBanco", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ban_Nombre", nombreBanco));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
        }
        catch (Exception ex)
        { }
        
    }

    public static DataTable sp_ConsultarNewBanco(int bancoID)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ConsultarNewBanco", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoID));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();
        }
        catch (Exception ex)
        { }
        return dt; 
    }
    public static DataTable sp_ConsultarNewBancoModificar(int bancoID)
    {
        DataTable dt = new DataTable();
        try
        {

            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ConsultarNewBancoModificar", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoID));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();
        }
        catch (Exception ex)
        { }
       
        return dt;
    }
    public static string sp_ActualizarNewBanco(int bancoID, string nombreBanco)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewBanco", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoID));
            cmd.Parameters.Add(new SqlParameter("@ban_Nombre", nombreBanco));

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
    public static DataTable sp_EliminarNewBanco(int bancoID)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_EliminarNewBanco", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoID));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();
        }
        catch (Exception ex)
        { }
        return dt;
        
       
    }
}