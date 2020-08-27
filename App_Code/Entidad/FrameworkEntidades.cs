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
/// Descripción breve de FrameworkEntidades
/// </summary>
public class FrameworkEntidades
{
    public static SqlConnection cnx;
    public  SqlConnection cnxPrueba;

    public static String Conexion(String conexion)
    {
        return ConfigurationManager.ConnectionStrings[conexion].ConnectionString;
    }
    //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    //PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    public int Insertar(string tabla, List<string> valores)
    {
        int result = 0;
        DataTable dt = new DataTable();
        string consulta = "INSERT INTO " + tabla + " VALUES ( ";
        foreach (string valor in valores)
        {
            consulta += valor + ", ";
        }
        consulta = consulta.Remove(consulta.Length - 2);        
        consulta += "); ";
        
        cnx = new SqlConnection(Conexion("ConexionBD"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        result = cmd.ExecuteNonQuery();        
        cnx.Close();
        return result;
    }


    public int Actualizar(string tabla, string[] nombresCampos, List<string> valores, string condicion, string condicionValor)
    {
        int result = 0;
        DataTable dt = new DataTable();
        string consulta = "UPDATE " + tabla + " SET ";
        int posicion = 0;
        foreach (string valor in valores)
        {
            consulta += nombresCampos[posicion] + " = " + valor + ", ";
            posicion++;   
        }
        consulta = consulta.Remove(consulta.Length - 2);
        consulta += " WHERE " + condicion + " = " + condicionValor;
        consulta += "; ";


        cnx = new SqlConnection(Conexion("ConexionBD"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        result = cmd.ExecuteNonQuery();
        cnx.Close();
        return result;
    }

    public int Eliminar(string tabla, string condicion, string valor)
    {
        int result = 0;
        DataTable dt = new DataTable();
        string consulta = "DELETE FROM " + tabla + " WHERE ";
        consulta += condicion + " = " + valor;                
        consulta += "; ";

        cnx = new SqlConnection(Conexion("ConexionBD"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        result = cmd.ExecuteNonQuery();
        cnx.Close();
        return result;
    }


    public  DataTable SPProductoPorCompaniaPrecargue(int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ProductoPorCompaniaPrecargue", cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Viviana - Consultar usuario para login e informacion basica 
    public static DataTable ConsultarUsuarioSistema(string usuario)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioSistema", cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public static DataTable ConsultarUsuarioLogin(string usuario, string contrasenia)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioLogin", cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@contraseña", contrasenia));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public DataTable Consultar(string tabla, string[] nombresCampos, string condicion, string condicionValor)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        string consulta = "SELECT ";
        for (int i = 0; i < nombresCampos.Length; i++)
        {
            consulta += nombresCampos[i] + ", ";
        }
        consulta = consulta.Remove(consulta.Length - 2);
        consulta += " FROM " + tabla + " WHERE " + condicion + " = " + condicionValor + ";";

        cnx = new SqlConnection(Conexion("ConexionBD"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        da = new SqlDataAdapter(consulta, cnx);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
    public DataTable ConsultarSinCondicion(string tabla, string[] nombresCampos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        string consulta = "SELECT ";
        for (int i = 0; i < nombresCampos.Length; i++)
        {
            consulta += nombresCampos[i] + ", ";
        }
        consulta = consulta.Remove(consulta.Length - 2);
        consulta += " FROM " + tabla + ";";

        cnx = new SqlConnection(Conexion("ConexionBD"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        da = new SqlDataAdapter(consulta, cnx);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    public static DataTable ConsultarUsuarioSistema(string usuario, string contrasenia)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioSistema", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@contraseña", contrasenia));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    public DataTable ConsultarAgencia(string departamento)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        consulta = "SELECT TOP 1 ciu_Nombre FROM Ciudad WHERE dep_Id = " + departamento;
        da = new SqlDataAdapter(consulta, cnx);
        da.Fill(dt);
        return dt;
    }
    //sebastian
    public DataTable SPConsultarAgencia(string nombreUsuario)
    {
        DataTable dt1 = new DataTable(); 
        dt1 = SPConsultarCiudadUsuarioSistema(nombreUsuario);
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgencia", cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id",dt1.Rows[0]["age_Id"]));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //sebastian
    public DataTable SPConsultarCiudadUsuarioSistema(string nombreUsuario)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCiudadUsuarioSistema", cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario",nombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //sebastian
    public DataTable SPConsultarCertificado()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCertificado", cnx);
        //cmd.Parameters.Add(new SqlParameter("@cer_Id", ConsultarCertificado.certificado.NumeroCertificado));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //sebastian
    public DataTable SPConsultarCertificadoPorAgencia(int age_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoPorAgencia", cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id",age_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //sebastian
    public  DataTable SPConsultarCertificadoGeneralMom2()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoGeneralMom2", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //sebastian
    public  int SPEliminarRegistroPrecargue(int cer_Id)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarRegistroPrecargue", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
        return registros;
        
    }
    //sebastian
    public int SPActualizarMomento(int cer_Id, int mom_Id)
    {

        //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarMomento", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int resultado = cmd.ExecuteNonQuery();
        cnx.Close();
        return resultado;
    }
    //sebastian 
    public int SPActualizarEstado(int cer_Id, int estcar_Id, int mom_Id, int cer_PrimaTotal, int tipdev_Id, int caudev_Id, string cer_Observaciones)
    {
        //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstado", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
        cmd.Parameters.Add(new SqlParameter("tipdev_Id", tipdev_Id));
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", caudev_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", cer_Observaciones));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int resultado = cmd.ExecuteNonQuery();
        cnx.Close();
        return resultado;
    }

    //Sebastian
    public DataTable SPConsultarAgenciaDdl()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgenciaDdl", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Sebastian
    public DataTable SPBusquedaCertificadoAgencia(int age_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoAgencia", cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //Sebastian
    public DataTable SPBusquedaCertificadoAgenciaDevolucion(int age_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoAgenciaDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //Sebastian
    public DataTable SPBusquedaCertificadoTercero(int ter_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoTercero", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Sebastian
    public DataTable SPBusquedaCertificadoFecha(DateTime fecha_Inicial, DateTime fecha_final, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoFecha", cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha_Inicial", fecha_Inicial));
        cmd.Parameters.Add(new SqlParameter("@fecha_final", fecha_final));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Sebastian
    public DataTable SPBusquedaCertificadoPoliza(int cer_certificado,int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoPoliza", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_certificado", cer_certificado));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }



    //Sebastian   28/08/2015
    public DataTable SPBusquedaCertificadoTerceroDevolucion(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoTerceroDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Sebastian 28/08/2015
    public DataTable SPBusquedaCertificadoFechaDevolucion(DateTime fecha_Inicial, DateTime fecha_final)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoFechaDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha_Inicial", fecha_Inicial));
        cmd.Parameters.Add(new SqlParameter("@fecha_final", fecha_final));
        cmd.CommandType = CommandType.StoredProcedure;

        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //Sebastian 28/08/2015
    public DataTable SPBusquedaCertificadoPolizaDevolucion(int cer_certificado)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCertificadoPolizaDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_certificado", cer_certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }










    //Sebastian
    public DataTable SPConsultarProductoPorCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductoPorCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //cristian
    public  DataTable SPConsultarTipoDevolucion()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarTipoDevolucion", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //cristian
    public DataTable SPConsultarEstadoCargue()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewEstadoCargue", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    //cristian
    public static DataTable SPConsultarVigencia(int producto)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarVigencia", cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
    public DataTable SPConsultarCausalDevolucionPorTipo(int tipo)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarCausalDevolucionPorTipo", cnx);
        cmd.Parameters.Add(new SqlParameter("@tipDev_Id", tipo));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public void SPInsertarCertificado(int mesProduccion, int migracion, int consecutivo, int cer_IdAnterior, Certificado certificado)
    {
        DataTable dt, dtAgencia = new DataTable();
       // dtAgencia = SPConsultarCodigoAgencia();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificado", cnx);
        //cmd.Parameters.Add(new SqlParameter("@cer_Id", PrecargueProduccion.certificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@age_Id", certificado.Agencia));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", certificado.Cedula));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", certificado.FechaExpedicion));
        cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", certificado.Vigencia));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", certificado.NombreAsesor));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", certificado.Pagaduria));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", certificado.FechaRecibido));

        if (certificado.NumeroPlanillaRecibo == "" || certificado.NumeroPlanillaRecibo == null)
            cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", certificado.NumeroPlanillaRecibo));

        cmd.Parameters.Add(new SqlParameter("@com_Id", certificado.Compania));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", certificado.Producto));
        cmd.Parameters.Add(new SqlParameter("@cer_SoporteFisico", certificado.SoporteFisico));

        if (certificado.AnexoConversion == "" || certificado.AnexoConversion == null)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", DBNull.Value));
	    cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
        }            
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", certificado.AnexoConversion));
            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 2));
        }

        if (certificado.HojaServicioPrincipal == null)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", certificado.HojaServicioPrincipal));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", certificado.HojaServicioConyuge));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", certificado.HojaServicioOtrosAsegurados));
        }

        cmd.Parameters.Add(new SqlParameter("@estcar_Id", certificado.Estado));
        cmd.Parameters.Add(new SqlParameter("@cer_NumeroFolios", certificado.NumeroFolios));
        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", certificado.Prima));

        if (certificado.GrupoDevolucion == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", 2));
            cmd.Parameters.Add(new SqlParameter("@caudev_Id", 2));
            cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", certificado.GrupoDevolucion));
            cmd.Parameters.Add(new SqlParameter("@caudev_Id", certificado.CausalDevolucion));
            cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", certificado.Observacion));
        }

        if (consecutivo == -1)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", "0"));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", consecutivo));
        }

        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", certificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@conyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_AnoProduccion", certificado.FechaExpedicion.AddMonths(-1).Year));
        cmd.Parameters.Add(new SqlParameter("@cer_CausalConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_CausalRetiro", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoCartera", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoDescuento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoSalud", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Extr", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Jubilado", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Localidad", certificado.Localidad));
        cmd.Parameters.Add(new SqlParameter("@MesProduccion", mesProduccion));
        cmd.Parameters.Add(new SqlParameter("@MesProduccionLetras", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Movimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@TasaExt", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Tipo", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@InicioVigenciaAnterior", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ValorTotalAnterior", cer_IdAnterior));
        cmd.Parameters.Add(new SqlParameter("@VigenciaHasta", certificado.Vigencia));
        cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@pla_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@pol_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", 1));
        //cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@user", objAdministrarCertificados.objUsuarioSistema.NombreUsuario));

        cmd.Parameters.Add(new SqlParameter("@cer_Migracion", migracion));

        cmd.CommandType = CommandType.StoredProcedure;
        int filas = cmd.ExecuteNonQuery();
        //dt.Load(dr);
        cnx.Close();
    }

    //public DataTable SPConsultarCodigoAsesor()
    //{
    //    DataTable dt = new DataTable();
    //    SqlDataReader dr;
    //    cnx = new SqlConnection(Conexion("ConexionBD"));
    //    cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_ConsultarCodigoAsesor", cnx);
    //    cmd.Parameters.Add(new SqlParameter("@ase_Codigo", objPrecargueProduccion.certificado.NombreAsesor));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    dr = cmd.ExecuteReader();
    //    dt.Load(dr);
    //    cnx.Close();
    //    return dt;
    //}

    //public DataTable SPConsultarCodigoAgencia()
    //{
    //    DataTable dt = new DataTable();
    //    SqlDataReader dr;
    //    cnx = new SqlConnection(Conexion("ConexionBD"));
    //    cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_ConsultarCodigoAgencia", cnx);
    //    cmd.Parameters.Add(new SqlParameter("@ciu_Id", objPrecargueProduccion.certificado.Agencia));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    dr = cmd.ExecuteReader();
    //    dt.Load(dr);
    //    cnx.Close();
    //    return dt;
    //}

    public  DataTable sp_ConsultarConsecutivoCertificado(int cedula, int producto)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConsecutivoCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public  DataTable sp_ConsultarConsecutivoCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConsecutivoCertificadoPorCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    //public  DataTable Consultar(string clase, List<string> parametros)
    //{
    //    DataTable dt = new DataTable();
    //    string consulta = "Select T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
    //                      "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,PA.paga_Nombre Pagaduria, " +
    //                      "ES.empsur_IdConyuge IdConyuge,ES.empsur_NombresConyuge NombresConyuge,ES.empsur_ApellidosConyuge ApellidosConyuge,ES.empsur_FechaNacimientoConyuge FechaNacConyuge, " +
    //                      "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.empsur_VigenciaDesde InicioVigencia, 'EMPRESARIOS' Compañia,'SURAMERICANA' Producto, ES.empsur_EstadoNegocio EstadoNegocio, CONVERT(CHAR(11), DATEADD(month, 3, MAX(P.fac_InicioVigencia)), 120) AS FechaCancelacion, R.res_ValorTotal Prima " +
    //                      "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=4) " +
    //                      "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=4) " +
    //                      "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
    //                      "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
    //                      "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
    //                      "JOIN EmpresariosSuramericana ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.empsur_Certificado and ES.empsur_EstadoNegocio='CANCELADO POR MORA') " +
    //                      "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +
    //                      "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
    //                      "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
    //                      "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
    //                      "PA.paga_Nombre,ES.empsur_IdConyuge, ES.empsur_NombresConyuge,ES.empsur_ApellidosConyuge, O1.ocu_Nombre, " +
    //                      "ES.empsur_VigenciaDesde, ES.empsur_FechaNacimientoConyuge, ES.empsur_EstadoNegocio, ES.empsur_FechaRetiro ";

    //    cnx = new SqlConnection(Conexion("ConexionBD"));
    //    SqlCommand cmd = new SqlCommand(consulta, cnx);
    //    cnx.Open();
    //    cmd.CommandTimeout = 50000;
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    dt.Load(reader);
    //    cnx.Close();
    //    return dt;
    //}
    //*********************************JUAN CAMILO************************************************************
    //Método insertar tercero. JC
    public string SPInsertarNewTercero()
    {
        string rpta = "";

        try
        {
            cnx = new SqlConnection(Conexion("ConexionBD"));
            cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_InsertarNewTercero", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ter_Id", AdministrarTercero.asegurado.NumeroIdentificacion));
            if (AdministrarTercero.asegurado.TipoDocumento != 0)
            {
                cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", AdministrarTercero.asegurado.TipoDocumento));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", DBNull.Value));

            }
            cmd.Parameters.Add(new SqlParameter("@ter_Nombres", AdministrarTercero.asegurado.Nombres));
            cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", AdministrarTercero.asegurado.Apellidos));
            cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", AdministrarTercero.asegurado.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@ter_Correo", AdministrarTercero.asegurado.CorreoElectronico));
            if (AdministrarTercero.asegurado.Sexo != "")
            {
                cmd.Parameters.Add(new SqlParameter("@ter_Sexo", AdministrarTercero.asegurado.Sexo));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@ter_Sexo", DBNull.Value));

            }
            
            cmd.Parameters.Add(new SqlParameter("@dep_Id", AdministrarTercero.asegurado.Departamento));
            if (AdministrarTercero.asegurado.Ciudad != 0)
            {
                cmd.Parameters.Add(new SqlParameter("@ciu_Id", AdministrarTercero.asegurado.Ciudad));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@ciu_Id", DBNull.Value));

            }
            if (AdministrarTercero.asegurado.Ocupacion != 0)
            {
                cmd.Parameters.Add(new SqlParameter("@ocu_Id", AdministrarTercero.asegurado.Ocupacion));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@ocu_Id", DBNull.Value));

            }
            
            cmd.Parameters.Add(new SqlParameter("@ter_Celular", AdministrarTercero.asegurado.Celular));
            cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", AdministrarTercero.asegurado.Telefono1));
            cmd.Parameters.Add(new SqlParameter("@ter_Direccion", AdministrarTercero.asegurado.Direccion));
            cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", AdministrarTercero.asegurado.Telefono2));
            if (AdministrarTercero.asegurado.EstadoCivil != 0)
            {
                cmd.Parameters.Add(new SqlParameter("@ter_EstadoCivil", AdministrarTercero.asegurado.EstadoCivil));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@ter_EstadoCivil", DBNull.Value));

            }
           
            cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", AdministrarTercero.asegurado.HabeasData));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() != 0 ? "REGISTRO CREADO CON ÉXITO" : "NO SE INGRESO EL REGISTRO";
        }
        catch (Exception ex)
        {
            rpta = ex.Message;
        }
        finally
        {
            if (cnx.State == ConnectionState.Open) cnx.Close();
        }
        cnx.Close();
        return rpta;
    }


    //Método modificar tercero.JC
    public string SPModificarNewTercero()
    {
        string rpta = "";
        try
        {
            cnx = new SqlConnection(Conexion("ConexionBD"));
            cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_EditarNewTercero", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ter_Id", AdministrarTercero.asegurado.NumeroIdentificacion));
            cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", AdministrarTercero.asegurado.TipoDocumento));
            cmd.Parameters.Add(new SqlParameter("@ter_Nombres", AdministrarTercero.asegurado.Nombres));
            cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", AdministrarTercero.asegurado.Apellidos));
            cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", AdministrarTercero.asegurado.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@ter_Correo", AdministrarTercero.asegurado.CorreoElectronico));
            cmd.Parameters.Add(new SqlParameter("@ter_Sexo", AdministrarTercero.asegurado.Sexo));
            cmd.Parameters.Add(new SqlParameter("@dep_Id", AdministrarTercero.asegurado.Departamento));
            cmd.Parameters.Add(new SqlParameter("@ciu_Id", AdministrarTercero.asegurado.Ciudad));
            cmd.Parameters.Add(new SqlParameter("@ocu_Id", AdministrarTercero.asegurado.Ocupacion));
            cmd.Parameters.Add(new SqlParameter("@ter_Celular", AdministrarTercero.asegurado.Celular));
            cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", AdministrarTercero.asegurado.Telefono1));
            cmd.Parameters.Add(new SqlParameter("@ter_Direccion", AdministrarTercero.asegurado.Direccion));
            cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", AdministrarTercero.asegurado.Telefono2));
            cmd.Parameters.Add(new SqlParameter("@ter_EstadoCivil", AdministrarTercero.asegurado.EstadoCivil));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", AdministrarTercero.asegurado.HabeasData));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "NO SE MODIFICO EL REGISTRO" : "OK";
        }
        catch (Exception ex)
        {
            rpta = ex.Message;
        }
        finally
        {
            if (cnx.State == ConnectionState.Open) cnx.Close();
        }
        cnx.Close();
        return rpta;
    }


    //Consultar tercero por cédula
    public DataTable SPMostrarNewTercero()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarNewTerceroPorCedula", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", AdministrarTercero.asegurado.NumeroDocumento));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            dt= null;
        }
        cnx.Close();
        return dt;
    }


    //Método eliminar tercero.JC
    public string SPEliminarNewTercero()
    {
        string mensaje;

        DataTable dt = new DataTable();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTercero", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@ter_Id", AdministrarTercero.asegurado.NumeroIdentificacion));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

      
        int filas = cmd.ExecuteNonQuery();
        if (filas != 0)
        {
            mensaje = "Registro eliminado con éxito";
        }
        else
        {
            mensaje = "No se encontraron registros para eliminar";
        }
        cnx.Close();
        return mensaje;
    }





    //Carga el ddlTipoDocumentoTercero
    public DataTable SPMostrarNewTipoDocumento()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarTipoDocumento", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    //Carga el ddlDepartamento
    public DataTable SPMostrarDepartamento()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarDepartamento", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    //Carga el ddlCiudad
    public DataTable SPConsultarCiudad()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCiudadPorDepartamento", cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", AdministrarTercero.asegurado.Departamento));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    //Carga el ddlOcupacionTercero
    public DataTable SPMostrarOcupacion()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOcupacion", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    //Carga el ddlEstadoCivil
    public DataTable SPConsultarEstadoCivil()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoCivil", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
    //*********************************JUAN CAMILO***********FIN*************************************************

    
    // CRISTIAN   
    public  int spInsertarTerceroNombreApellidoPrecargue(string cedula, string nombre, string apellido)
    {
        //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        int filas;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTercero", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", 1));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", nombre));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", apellido));
        cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_Correo", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_Sexo", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_Celular", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_Direccion", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_EstadoCIvil", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        filas = cmd.ExecuteNonQuery();
        cnx.Close();
        return filas;
    }

    public DataTable spConsultarAsesorPorDepartamento(int dep_Id, int pro_Id)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNombreAsesorPorDepartamento", cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    // Insertar Otros Asegurados - Cristian
    public int sp_InsertarOtrosAsegurados()
    {
        int filas;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarOtroAsegurado", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@otrase_Certificado", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_TerIdentificacion", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Identificacion", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Nombres", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Apellidos", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Edad", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_FechaNacimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Parentesco", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_Plan", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@otrase_ValorAsegurado", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        filas = cmd.ExecuteNonQuery();
        return filas;
    }



    public  void SPInsertarCertificadoModificado(int mesProduccion, int migracion, int consecutivo, int codigoAsesor, string agencia,Certificado certificado)
    {
        //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        //DataTable dt, dtAgencia = new DataTable();
        //dt = SPConsultarCodigoAsesor();
        //dtAgencia = SPConsultarCodigoAgencia();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificado", cnx);
        //cmd.Parameters.Add(new SqlParameter("@cer_Id", PrecargueProduccion.certificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@age_Id", agencia));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", certificado.Cedula));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", certificado.FechaExpedicion));
        cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", certificado.Vigencia));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", codigoAsesor));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", certificado.Pagaduria));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", certificado.FechaRecibido));

        if (certificado.NumeroPlanillaRecibo == "" || certificado.NumeroPlanillaRecibo == null)
            cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", certificado.NumeroPlanillaRecibo));

        cmd.Parameters.Add(new SqlParameter("@com_Id", certificado.Compania));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", certificado.Producto));
        cmd.Parameters.Add(new SqlParameter("@cer_SoporteFisico", certificado.SoporteFisico));

        if (certificado.AnexoConversion == "" || certificado.AnexoConversion == null)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", certificado.AnexoConversion));
            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 2));
        }

        if (certificado.HojaServicioPrincipal == null)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", certificado.HojaServicioPrincipal));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", certificado.HojaServicioConyuge));
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", certificado.HojaServicioOtrosAsegurados));
        }

        cmd.Parameters.Add(new SqlParameter("@estcar_Id", certificado.Estado));
        cmd.Parameters.Add(new SqlParameter("@cer_NumeroFolios", certificado.NumeroFolios));
        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", certificado.Prima));

        if (certificado.GrupoDevolucion == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", 2));
            cmd.Parameters.Add(new SqlParameter("@caudev_Id", 2));
            cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@tipdev_Id", certificado.GrupoDevolucion));
            cmd.Parameters.Add(new SqlParameter("@caudev_Id", certificado.CausalDevolucion));
            cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", certificado.Observacion));
        }

        if (consecutivo == -1)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", 0));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", consecutivo));
        }

        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", certificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@conyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_AnoProduccion", certificado.FechaExpedicion.AddMonths(-1).Year));
        cmd.Parameters.Add(new SqlParameter("@cer_CausalConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_CausalRetiro", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoCartera", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoDescuento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoSalud", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Extr", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Jubilado", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Localidad", certificado.Localidad));
        cmd.Parameters.Add(new SqlParameter("@MesProduccion", mesProduccion));
        cmd.Parameters.Add(new SqlParameter("@MesProduccionLetras", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Movimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@TasaExt", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Tipo", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@InicioVigenciaAnterior", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ValorTotalAnterior", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@VigenciaHasta", certificado.Vigencia));
        cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroConyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@pla_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@pol_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", 1));
        //cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

        cmd.Parameters.Add(new SqlParameter("@cer_Migracion", migracion));

        cmd.CommandType = CommandType.StoredProcedure;
        int filas = cmd.ExecuteNonQuery();
        //dt.Load(dr);
        cnx.Close();
    }

    public DataTable SPBusquedaCompañía(int compañia, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaCompañía", cnx);
        cmd.Parameters.Add(new SqlParameter("@compañia", compañia));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public DataTable ListarCompania()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCompanias", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }



    public DataTable ListarProducto(int com_id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarProducto", cnx);
        cmd.Parameters.Add(new SqlParameter("@com_id", com_id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public DataTable SPBusquedaProducto(int pro_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BusquedaProducto", cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }

    public DataTable CargarTercero(int ter_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CargarTercero", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        cnx.Close();
        return dt;
    }
}