using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOCierreSistema
/// </summary>
public class DAOCierreSistema
{


    public static DataTable SPListarCierres()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCierreSistema", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable spConsultarEstadoCierreSistema()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoCierreSistema", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarProductoPorCompania(int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductoPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable spListarAgencias()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarAgencias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void InsertarCierreSistema(string compania, string producto, string agencia, string mes, string anio, string estado)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarCierreSistema", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", compania));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.Parameters.Add(new SqlParameter("@age_Id", agencia));
        cmd.Parameters.Add(new SqlParameter("@mes", mes));
        cmd.Parameters.Add(new SqlParameter("@anio", anio));
        cmd.Parameters.Add(new SqlParameter("@estado", estado));       
        cmd.CommandType = CommandType.StoredProcedure;
        //int fila = 
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();        
    }


    public static void CerrarCierreSistema(int cierre)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CerrarCierreSistema", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cie_Id", cierre));
        cmd.CommandType = CommandType.StoredProcedure;
        //int fila = 
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();   
    }

    public static void AbrirCierreSistema(int cierre, int producto, int agencia, int mes, int anio)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AbrirCierreSistema", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cie_Id",   cierre));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.Parameters.Add(new SqlParameter("@age_Id",  agencia));
        cmd.Parameters.Add(new SqlParameter("@mes",         mes));
        cmd.Parameters.Add(new SqlParameter("@anio",       anio));
 
        cmd.CommandType = CommandType.StoredProcedure;
        //int fila = 
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close(); 
    }

    public static DataTable ListarAgencias()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarAgencias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}