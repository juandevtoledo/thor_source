using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
/// <summary>
/// Descripción breve de DAODigitarProduccion
/// </summary>
public class DAODigitarProduccion
{
    
    public  DataTable SPConsultarCertificadoDevoluciones()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoDevoluciones", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public  DataTable SPActualizarTidevRecuperable(int cer_Id,int estcar_Id)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarTidevRecuperable", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public  DataTable SPActualizarEstcarDevolucion(int cer_Id, int estcar_Id)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstcarDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public  DataTable SPConsultarCertificadoActaTransferencial(int mom_Id, int estcar_Id, int estcar2_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoActaTransferencial", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@estcar2_Id", estcar2_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

  
    public  DataTable SPConsultarTerceroPreCargue(double ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTerceroPreCargue", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
         
    }

     public  DataTable SpConsultarTipoDevolucionPlus()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTipoDevolucionPlus", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

     


    public  int SPActualizarMomento(int cer_Id, int mom_Id)
    {
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarMomento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int resultado = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return resultado;
    }


}