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
/// Descripción breve de DAOAdministrarNovedades
/// </summary>
public class DAOAdministrarNovedades
{
    public static DataTable InsertarNovedades(int cedula, string tipoNovedad, int estado, int pagaduria, int convenio, int archivo, int valor, int enviada, int mes, int anio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNovedades", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        cmd.Parameters.Add(new SqlParameter("@tipoNovedad", tipoNovedad));
        cmd.Parameters.Add(new SqlParameter("@estado", estado));
        cmd.Parameters.Add(new SqlParameter("@pagaduria", pagaduria));
        cmd.Parameters.Add(new SqlParameter("@convenio", convenio));
        cmd.Parameters.Add(new SqlParameter("@archivo", archivo));
        cmd.Parameters.Add(new SqlParameter("@valor", valor));
        cmd.Parameters.Add(new SqlParameter("@enviada", enviada));
        cmd.Parameters.Add(new SqlParameter("@mes", mes));
        cmd.Parameters.Add(new SqlParameter("@anio", anio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ActualizarNovedades(int nov_Id, string nov_TipoNovedad, int nov_Valor, int mes, int anio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNovedades", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@nov_Id", nov_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_TipoNovedad", nov_TipoNovedad));
        cmd.Parameters.Add(new SqlParameter("@nov_Valor", nov_Valor));
        cmd.Parameters.Add(new SqlParameter("@nov_Mes", mes));
        cmd.Parameters.Add(new SqlParameter("@nov_Anio", anio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static DataTable ActualizarDePendienteASinAplicar(int nov_Id, int nov_Estado, string nov_Observaciones)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarDePendienteASinAplicar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@nov_Id", nov_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Observaciones", nov_Observaciones));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable LocalidadesAgencia(int age_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_LocalidadesAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

   

    public static DataTable ConsultarInformacionPagaduria(int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarInformacionPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarInformacionAgenciaNovedades(int age_Id, int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarInformacionAgenciaNovedades", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarTipoArchivoNovedades(int arcpag_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTipoArchivoNovedades", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarFechaAplicacionNovedades()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarFechaAplicacionNovedades", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarEstadoNovedades()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoNovedades", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarMesNovedadesSinEnviar()
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

    public static DataTable ConsultarMes()
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

    public static DataTable ConsultarAnio()
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

    public static DataTable ConsultarCausales()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCausales", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarAnioNovedadesSinEnviar()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAnioNovedadesSinEnviar", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarMesYAnioNovedad(int nov_Mes, int nov_Anio, int nov_Archivo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMesYAnioNovedad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@nov_Mes", nov_Mes));
        cmd.Parameters.Add(new SqlParameter("@nov_Anio", nov_Anio));
        cmd.Parameters.Add(new SqlParameter("@nov_Archivo", nov_Archivo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarPagaduriaLocalidad(int dep_Id)
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

    public static DataTable ConsultarArchivoPagaduria(int paga_Id, string tipo_archivo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarArchivoPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@tipo_Archivo", tipo_archivo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorLocalidad(int dep_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesHistorico(int dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesHistorico", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesHistoricoPagaduria(int dep_Id, int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesHistoricoPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesHistoricoArchivo(int dep_Id, int paga_Id, int arcpag_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesHistoricoArchivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarNovedadAEnviar(DataTable dtNovedad)
    {
        foreach (DataRow dr in dtNovedad.Rows)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNovedadAEnviar", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@nov_Enviada", dr["Enviada"]));
            cmd.Parameters.Add(new SqlParameter("@nov_Id", dr["Id"]));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();            
        }
    }



    public static DataTable ConsultarNovedadesPorPagaduria(int dep_Id, int paga_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorArchivo(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorArchivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnio(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado,int nov_Mes, int nov_Anio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorMesYAnio", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Mes", nov_Mes));
        cmd.Parameters.Add(new SqlParameter("@nov_Anio", nov_Anio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedades(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, int enviada, int nov_Mes, int nov_Anio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedades", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Enviada", enviada));
        cmd.Parameters.Add(new SqlParameter("@nov_Mes", nov_Mes));
        cmd.Parameters.Add(new SqlParameter("@nov_Anio", nov_Anio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnioAplicadas(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorMesYAnioAplicadas", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion", nov_FechaAplicacion));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion2", nov_FechaAplicacion2));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnioHistorico(int dep_Id, int paga_Id, int arcpag_Id, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorMesYAnioHistorico", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion", nov_FechaAplicacion));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion2", nov_FechaAplicacion2));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorEstadoHistorico(int dep_Id, int paga_Id, int arcpag_Id, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2, int nov_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorEstadoHistorico", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion", nov_FechaAplicacion));
        cmd.Parameters.Add(new SqlParameter("@nov_FechaAplicacion2", nov_FechaAplicacion2));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorLocalidadEnviada(int dep_Id, int nov_Estado, int nov_Enviada)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorLocalidadEnviada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Enviada", nov_Enviada));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static DataTable ConsultarNovedadesPorPagaduriaEnviada(int dep_Id, int paga_Id, int nov_Estado, int nov_Enviada)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorPagaduriaEnviada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Enviada", nov_Enviada));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesPorArchivoEnviada(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, int nov_Enviada)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesPorArchivoEnviada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Enviada", nov_Enviada));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarRegistroCuentaDeCobro(int arcpag_Id, int dep_Id, int paga_Id, int nov_Estado, int nov_Enviada)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRegistroCuentaDeCobro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Enviada", nov_Enviada));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadesSinAplicar(string cedula, int convenio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadSinEnviar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@con_Id", convenio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static int GuardarCuentasCobro(DataTable dt, string cueCob_Archivo)
    {
        int registros = 0;
        foreach (DataRow dtDatos in dt.Rows)
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_GuardarCuentasCobro", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", dtDatos[0].ToString()));
            cmd.Parameters.Add(new SqlParameter("@cueCobDat_Poliza", dtDatos[3].ToString()));
            cmd.Parameters.Add(new SqlParameter("@cueCobDat_Descuento", dtDatos[4].ToString()));
            cmd.Parameters.Add(new SqlParameter("@cueCob_Archivo", cueCob_Archivo));
            cmd.CommandType = CommandType.StoredProcedure;
            registros += cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
        }
        return registros;
    }

    public static DataTable ConsultarCuentasCobro(string mes, string anio, string cueCobId, string cueCob_Archivo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCuentasCobro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@mes", mes));
        cmd.Parameters.Add(new SqlParameter("@anio", anio));
        cmd.Parameters.Add(new SqlParameter("@cueCob_Id", cueCobId));
        cmd.Parameters.Add(new SqlParameter("@cueCob_Archivo", cueCob_Archivo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarCuentaCobro(int cueCob_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCuentaCobro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueCob_Id", cueCob_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int VerificarCuentaCobro(string cueCob_Archivo)
    {
        int registros = 0;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_VerificarCuentaCobro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueCob_Archivo", cueCob_Archivo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        foreach (DataRow dtDatos in dt.Rows)
        {
            registros = int.Parse(dtDatos[0].ToString());
        }
        return registros;
    }

    public static int EliminarCuentaCobro(int cueCob_Id, int archivo)
    {
        int registros = 0;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarCuentaCobro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cueCob_Id", cueCob_Id));
        cmd.Parameters.Add(new SqlParameter("@archivo", archivo));
        cmd.CommandType = CommandType.StoredProcedure;
        registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    public static DataTable ConsultarCertificadoPorPagaduriaArchivo(string ter_Id, string arcpag_Id, string nov_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoPorPagaduriaArchivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Id", nov_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNovedadPorTercero(string ter_Id, string arcpag_Id,string nov_Estado, string nov_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadPorTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Estado", nov_Estado));
        cmd.Parameters.Add(new SqlParameter("@nov_Id", nov_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}