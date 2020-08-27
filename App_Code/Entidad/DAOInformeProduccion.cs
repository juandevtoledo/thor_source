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
/// Descripción breve de DAOInformeProduccion
/// </summary>
public class DAOInformeProduccion
{
    public static DataTable sp_ConsultarLocalidadPorAgencia(string age_Id)
	{
		DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadPorAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
	}

    public static DataTable sp_ConsultarAsesorPorlocalidad(string dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAsesorPorLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarMes()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMes", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarAnio()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAnio", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarPagaduriaPorLocalidad(string dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagaduriaPorLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarConvenioPorPagaduria(string paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarconveniosPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarInformeProduccion(int agencia, int localidad, int asesor, int estadoNegocio, int anio, int mes, int compania, int producto, int pagaduria, int convenio, DateTime fechaDesde, DateTime fechaHasta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeProduccion", FrameworkEntidades.cnx);

        if (agencia > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@age_Id", agencia));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@age_Id", DBNull.Value));
        }

        if (localidad > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", DBNull.Value));
        }

        if (asesor > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Id", asesor));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Id", DBNull.Value));
        }

        if (estadoNegocio > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@estado", estadoNegocio));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@estado", DBNull.Value));
        }

        if (anio > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@año", anio));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@año", DBNull.Value));
        }

        if (mes > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@mes", DBNull.Value));
        }

        if (compania > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@com_Id", compania));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@com_Id", DBNull.Value));
        }

        if (producto > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", DBNull.Value));
        }

        if (pagaduria > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@paga_Id", pagaduria));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@paga_Id", DBNull.Value));
        }

        if (convenio > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@con_Id", convenio));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@con_Id", DBNull.Value));
        }

        if (fechaDesde == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaexpDesde", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaexpDesde", fechaDesde));
        }

        if (fechaHasta == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaexpHasta", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaexpHasta", fechaHasta));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarEstadoNegocio()
    {
        
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoNegocio", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

 
}