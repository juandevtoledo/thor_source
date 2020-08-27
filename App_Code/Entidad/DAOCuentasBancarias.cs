using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOCuentasBancarias
/// </summary>
public class DAOCuentasBancarias
{
	public DAOCuentasBancarias()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    
    // Retorna la lista de terceros desde la base de datos
    public static DataTable spConsultarCompaniaGeneral()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarCompaniaGeneral", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    internal static DataTable spConsultarBancosPorCompania(int com_Id, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarBancosPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipBan_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    internal static DataTable spConsultarCuentasPorBancoCompania(int ban_Id, int com_Id, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarCuentasPorBancoCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", ban_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipBan_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    internal static DataTable spConsultarCuentasPorArchivo(int archivoId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarCuentasPorArchivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@archivoId", archivoId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    internal static DataTable spConsultarTipoCuentaBancaria(int cuentaBancaria)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarTipoCuentaBancaria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cuentaBancaria", cuentaBancaria));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_consultarTipoCuentaParaEditar(int bancoEdit, int compañiaEdit, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarTipoCuentaParaEditar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoEdit));
        cmd.Parameters.Add(new SqlParameter("@com_Id", compañiaEdit));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipBan_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_consultarCuentasParaEditar(int bancoEdit, int compañiaEdit, int tipBan_Id, int tipoCuentaEdit)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarCuentasParaEditar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", bancoEdit));
        cmd.Parameters.Add(new SqlParameter("@com_Id", compañiaEdit));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipBan_Id));
        cmd.Parameters.Add(new SqlParameter("@tipCue_Id", tipoCuentaEdit));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}