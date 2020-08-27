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
/// Descripción breve de DAOAdministrarCartaRetiro
/// 
/// Contiene la conexión a la base de datos y cada uno de los procedimientos almacenados que se utilizan para el desarrollo de todas 
/// las funciones del módulo, incluidos los paramétros que se envian al motor de base de datos para cada caso particular. Los procedimientos 
/// se encuentran documentados en la base de datos, dando claridad de su funcionalidad. 
/// </summary>
public class DAOAdministrarCartaRetiro
{
    public static DataTable MostrarTercero(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTerceroRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    
    public static DataTable MostrarCertificado(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCertificadoRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCertificadoRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarOrigenOficio()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarOrigenOficio", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void InsertarCartaRetiro(int cedula, double certificado, int pagaduria, int compania, int producto, DateTime fechaTg, DateTime fechaCasaMatriz, DateTime fechaCompania, string origen, string observacion, string usuario)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarCartaRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@certificado", certificado));
        cmd.Parameters.Add(new SqlParameter("@pagaduria", pagaduria));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.Parameters.Add(new SqlParameter("@fechaTg", fechaTg));
        cmd.Parameters.Add(new SqlParameter("@fechaCasaMatriz", fechaCasaMatriz));
        cmd.Parameters.Add(new SqlParameter("@fechaCompania", fechaCompania));
        cmd.Parameters.Add(new SqlParameter("@com_Id", compania));
        cmd.Parameters.Add(new SqlParameter("@origen", origen));
        cmd.Parameters.Add(new SqlParameter("@observacion", observacion));
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }
    
    public static DataTable ListarCompania()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCompanias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarRetiro()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarRetiro", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable GestionarRetiro(int idCarta, int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GestionarRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@IdCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarCausal()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCausal", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarAsesor(int dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarTipoGestion()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarTipoGestion", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void InsertarGestionRetiro(int cedula, double certificado, int producto, DateTime fechaGestion, string horaGestion, int asesor, string observacion, DateTime fechaCarta, int tipoGestion, DateTime fechaVigenciaRetiro, int causalRetiro, int idCarta, int llamadaEfectiva)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarGestionRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@certificado", certificado));
        cmd.Parameters.Add(new SqlParameter("@producto", producto));
        cmd.Parameters.Add(new SqlParameter("@fechaGestion", fechaGestion));
        cmd.Parameters.Add(new SqlParameter("@horaGestion", horaGestion));
        cmd.Parameters.Add(new SqlParameter("@asesor", asesor));
        cmd.Parameters.Add(new SqlParameter("@observacion", observacion));
        cmd.Parameters.Add(new SqlParameter("@fechaCarta", fechaCarta));
        cmd.Parameters.Add(new SqlParameter("@tipoGestion", tipoGestion));
        cmd.Parameters.Add(new SqlParameter("@fechaVigRetiro", fechaVigenciaRetiro));
        cmd.Parameters.Add(new SqlParameter("@causalRetiro", causalRetiro));
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.Parameters.Add(new SqlParameter("@llamadaEfectiva", llamadaEfectiva));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable ConsultarVigencia(double certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarVigenciaRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    } 

    public static DataTable ValidarExistente(int ter_Id, string cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarExistente", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@certificado", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ValidarRecuperacionExistente(int ter_Id, double cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecuperacionExistente", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@certificado", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ValidarGestionExistente(int cedula, double certificado, int idCarta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarGestionExistente", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@certificado", certificado));
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarConyuge(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConyuge", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarMovimiento(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarMovimientoRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();       
    }

    public static void ActualizarMesProduccion(int ter_Id, double cer_Certificado, int idCarta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarMesProduccion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();       
    }

    public static DataTable RecuperarRetiro(int idCarta, int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_RecuperarRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarRecuperacionRetiro(int ter_Id, double cer_Certificado, DateTime fecha_Recuperacion, string hora_Recuperacion, int ase_Id, string observacion_Rec, int tipo_Gestion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarRecuperacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.Parameters.Add(new SqlParameter("@fecha_Recuperacion", fecha_Recuperacion));
        cmd.Parameters.Add(new SqlParameter("@hora_Recuperacion", hora_Recuperacion));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@observacion_Rec", observacion_Rec));
        cmd.Parameters.Add(new SqlParameter("@tipo_Gestion", tipo_Gestion));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static void InsertarNovedad(int ter_Id, int cer_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNovedadRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }    

    public static DataTable ValidarProduccionNueva(int ter_Id, int pro_id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProduccionNueva", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void InsertarNovedadRecuperacion(int ter_Id, double cer_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNovedadRecuperacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable BuscarRetiro(int ter_Id, double cer_Certificado, DateTime fecha)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarRetiro", FrameworkEntidades.cnx);

        if (ter_Id > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ter_Id", DBNull.Value));
        }

        if (cer_Certificado > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Certificado", DBNull.Value));
        }

        if (fecha == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaDigitacion", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaDigitacion", fecha));
        }
        cmd.CommandTimeout = 100000;
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarMovimientoRecuperacion(int ter_Id, double cer_Certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarMovimientoRecuperacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static void EliminarRetiro(int IdCarta, int ter_Id, double cer_Certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@IdCarta", IdCarta));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();        
    }

    public static DataTable EditarRetiro(int cer_Id, int idCartaRetiro)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EditarRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@idCartaRetiro", idCartaRetiro));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarCartaRetiro(int idCarta, int compania, DateTime fechaTg, DateTime fechaCasaMatriz, DateTime fechaCompania, string origen, string observacion)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarCartaRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.Parameters.Add(new SqlParameter("@fechaTg", fechaTg));
        cmd.Parameters.Add(new SqlParameter("@fechaCasaMatriz", fechaCasaMatriz));
        cmd.Parameters.Add(new SqlParameter("@fechaCompania", fechaCompania));
        cmd.Parameters.Add(new SqlParameter("@com_Id", compania));
        cmd.Parameters.Add(new SqlParameter("@origen", origen));
        cmd.Parameters.Add(new SqlParameter("@observacion", observacion));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }
    
    public static DataTable ListarObservaciones(int idCarta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarObservaciones", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void GuardarObservacion(string observacion, string usuario, int men_Id, int ter_Id, int idCarta)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GuardarObservacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@observacion", observacion));
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable ListarProductosCompania(int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductoPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id",com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;       
    }

    public static DataTable ListarLocalidad()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidad", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable InformeRetiros(int cedula, int localidad, int com_Id, int pro_Id, int tipoGestion, int origen, DateTime fechaInicio, DateTime fechaFin, int informe)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeRetiros", FrameworkEntidades.cnx);

        if (cedula > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cedula", DBNull.Value));
        }
        if (localidad > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", DBNull.Value));
        }
        if (com_Id > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@com_Id", DBNull.Value));
        }
        if (pro_Id > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@pro_Id", DBNull.Value));
        }
        if (tipoGestion > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@tipoGestion", tipoGestion));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@tipoGestion", DBNull.Value));
        }
        if (origen > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@origen", origen));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@origen", DBNull.Value));
        }
        if (fechaInicio == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        }
        if (fechaFin == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaFin", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        }
        if (informe > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@informe", informe));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@informe", DBNull.Value));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;  
    }

    public static DataTable ListarTipoInforme()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarTipoInforme", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarVigenciaRetiro(int idCarta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarVigenciaRetiro", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();        
    }

    public static DataTable EditarTercero(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EditarTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static void ActualizarVigenciaCer(int idCarta, double idCertificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarVigenciaCer", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idCarta", idCarta));
        cmd.Parameters.Add(new SqlParameter("@idCertificado", idCertificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();        
    }

    public static DataTable ConsultarIdCarta(int ter_Id, double cer_Certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdCarta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}