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
/// Descripción breve de DAOAdministrarCertificado
/// </summary>
public class DAOAdministrarCertificado
{
    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    public DataTable AsesorPorLocalidad(int departamento)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNombreAsesorPorDepartamento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", departamento));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable ConsultarAgencia()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgenciaDdl", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable sp_ConsultarLocalidadPorAgencia(int age_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadPorAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable SPConsultarPagaduriaPorLocalidad(int dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagaduriaPorLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable spConsultarResumenCertificado(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarResumenCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarTasaPlanesPoliza(int plapol_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTasaPlanesPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@plapol_Id", plapol_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spActualizarCertificadoAnterior(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarCertificadoAnterior", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarEstadoNegocioPorCerId(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoNegocioPorCerId", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarIdArchivo(int pro_Id, int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdArchivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarNovedadActual(int ter_Id, int arcpag_Id, int retiro)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadActual", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.Parameters.Add(new SqlParameter("@retiro", retiro));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable spConsultarArchivoPagaduriaPorId(int arcpag_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarArchivoPagaduriaPorId", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@arcpag_Id", arcpag_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarPeridiocidadPorConvenio(int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPeriodicidadPorConvenio", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable ConsultarTerceroCertificado(double ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTerceroCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;

    }

    public DataTable spConsultarPolizaPorProudcto(int dep_Id,int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_PolizasPorProductoYLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarConvenios(int pro_Id, int dep_Id, int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenios", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarOcupacionCertificado(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOcupacionCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable spConsultarAmparosPrincipal(int cer_Id, int ter_Id, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosPrincipal", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public void spInsertarOtroAsegurado(DataTable dtTemp, int cer_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        foreach (DataRow row in dtTemp.Rows)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarOtroAsegurado", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
            cmd.Parameters.Add(new SqlParameter("@ter_Id", row["Cedula"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@par_Id", row["Parentesco"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@plapol_Id", row["Plan"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@otroase_prima", row["Prima"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            cmd.CommandType = CommandType.StoredProcedure;
            double registros = cmd.ExecuteNonQuery();
        }
        FrameworkEntidades.cnx.Close();
    }

    public DataTable spConsultarDepartamentoPorCiudad(string ciu_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDepartamentoPorCiudad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", ciu_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarConvenioPorPagaduria(double cerId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenioPorPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cerId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //25/08/20015 sebastian
    public DataTable spConsultarOtroAseguradoModificacion(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOtroAseguradoModificacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    //############################
    public DataTable spConsultarTablaAmparos(int plapol_Id, int edad, int valorLibre, int ocupacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosPorPlan", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@plapol_Id", plapol_Id));
        cmd.Parameters.Add(new SqlParameter("@amppla_EdadMax", edad));
        cmd.Parameters.Add(new SqlParameter("@valorlibre", valorLibre));
        cmd.Parameters.Add(new SqlParameter("@ocupacion", ocupacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

 public DataTable spConsultarTablaAmparosPermanencia(int plapol_Id, int edad, int valorLibre, int cer_Id, int genero, int ocupacion, int cer_IdAnterior, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosPorPlanPermanencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@plapol_Id", plapol_Id));
        cmd.Parameters.Add(new SqlParameter("@amppla_EdadMax", edad));
        cmd.Parameters.Add(new SqlParameter("@valorlibre", valorLibre));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@genero", genero));
        cmd.Parameters.Add(new SqlParameter("@ocupacion", ocupacion));
        cmd.Parameters.Add(new SqlParameter("@cer_IdAnterior", cer_IdAnterior));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarTablaAmparosModificacion(int cer_Id, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosPorPlanModificacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarTablaAmparosModificacionBusqueda(int cer_Id, int par_Id,double terId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosPorPlanModificacionBusqueda", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spPlanPorPoliza(int pol_id, int par_Id,int edad)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_PlanPorPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@edad", edad));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spPlanPorPolizaPermanencia(int pol_id, int par_Id, int edad)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_PlanPorPolizaPermanencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@edad", edad));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable ConsultarPeriodosPago()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPeriodosDePago", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable ConsultarLocalidades()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDepartamentos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public int IngresarCertificado()
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", objAdministrarCertificados.objCertificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@age_Id", objAdministrarCertificados.objCertificado.Agencia));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", objAdministrarCertificados.objCertificado.Cedula));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", objAdministrarCertificados.objCertificado.FechaExpedicion));
        cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", objAdministrarCertificados.objCertificado.Vigencia));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", objAdministrarCertificados.objCertificado.NombreAsesor));
        //cmd.Parameters.Add(new SqlParameter("@paga_Id", AdministrarCertificados.certificado.Pagaduria));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", 4));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", objAdministrarCertificados.objCertificado.FechaDigitacion));
        //cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", AdministrarCertificados.certificado.NumeroPlanillaRecibo));
        //cmd.Parameters.Add(new SqlParameter("@com_Id", AdministrarCertificados.certificado.Compania));
        //cmd.Parameters.Add(new SqlParameter("@pro_Id", AdministrarCertificados.certificado.Producto));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstadoDescuento", AdministrarCertificados.certificado.Estado));
        //cmd.Parameters.Add(new SqlParameter("@cer_NumeroFolios", AdministrarCertificados.certificado.NumeroFolios));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public int IngresarCertificadoConyuge()
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AdicionarConyugeCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", objAdministrarCertificados.objCertificado.NumeroCertificado));
        cmd.Parameters.Add(new SqlParameter("@IdConyuge", objAdministrarCertificados.objConyuge.NumeroDocumento));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    //Sebastian
    public int spInsertarBeneficiario(List<Asegurado> beneficiario,int cer_Id,int ter_Id,int par_Id)
    {
        int registros = 0, flag = 0;
        foreach(Asegurado row in beneficiario)
        {
            if (row.Apellidos != "")
            {
                FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
                FrameworkEntidades.cnx.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertarBeneficiario", FrameworkEntidades.cnx);
                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
                cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
                cmd.Parameters.Add(new SqlParameter("@ben_identificacion", row.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@ben_apellidos", row.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@ben_Nombres", row.Nombres));
                cmd.Parameters.Add(new SqlParameter("@ben_Edad", row.Edad));
                cmd.Parameters.Add(new SqlParameter("@ben_Porcentaje", row.Porcentaje));
                cmd.Parameters.Add(new SqlParameter("@ben_Parentesco", row.Parentesco));
                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                cmd.CommandType = CommandType.StoredProcedure;
                registros = cmd.ExecuteNonQuery();
                FrameworkEntidades.cnx.Close();
            }
            flag++;
            
        }
        return registros;
    }
    
    public int spInsertarAmparos(DataTable dt,int cer_Id,int cedula, int par_Id)
    {
        int registros = 0;
        foreach(DataRow row in dt.Rows)
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertarAmparos", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Id",cer_Id));
            cmd.Parameters.Add(new SqlParameter("@ter_Id",cedula));
            cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Nombre", row["Amparo"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@ampcer_ValAsegurado", double.Parse(row["Valor Asegurado"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Prima", double.Parse(row["Prima"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Tasa", double.Parse(row["Tasa"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@amp_Id", double.Parse(row["amp_Id"].ToString())));
            if (row["Tasa"].ToString() == "")
            {
                cmd.Parameters.Add(new SqlParameter("@tasa_ExtraPrima", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@tasa_ExtraPrima", double.Parse(row["Tasa"].ToString())));
            }
            //cmd.Parameters.Add(new SqlParameter("@tasa_ExtraPrima", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            cmd.CommandType = CommandType.StoredProcedure;
            registros = cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
        }
        return registros;
    }

    public int spInsertarAmparosExtraPrima(DataTable dt, int cer_Id, int cedula, int par_Id)
    {
        int registros = 0;
        foreach (DataRow row in dt.Rows)
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertarAmparosExtraPrima", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
            cmd.Parameters.Add(new SqlParameter("@ter_Id", cedula));
            cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Nombre", row["Amparo"].ToString()));
            cmd.Parameters.Add(new SqlParameter("@ampcer_ValAsegurado", double.Parse(row["Valor Asegurado"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Prima", double.Parse(row["Prima"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@ampcer_Tasa", double.Parse(row["Tasa"].ToString())));
            cmd.Parameters.Add(new SqlParameter("@ampcer_PorcentajeExtraPrima", double.Parse(row["Porcentaje"].ToString())));
            //cmd.Parameters.Add(new SqlParameter("@tasa_ExtraPrima", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            cmd.CommandType = CommandType.StoredProcedure;
            registros = cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
        }
        return registros;
    }

    //sebastian
    public int spConsultarIdCertificado(int ter_Id, int pro_Id, string cer_EstadoNegocio,string cer_EstadoNegocio2)
    {
        int idCert = 0;
      
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
                FrameworkEntidades.cnx.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultarIdCertificado", FrameworkEntidades.cnx);
                cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
                cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
                SqlParameter parameter = new SqlParameter("@cer_Temp", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                if (cer_EstadoNegocio == "VIGENTE")
                {
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", DBNull.Value));
                }
                if (cer_EstadoNegocio2 == "PRODUCCION NUEVA")
                {
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio2", cer_EstadoNegocio2));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio2", DBNull.Value));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                idCert = int.Parse(parameter.Value.ToString());
                FrameworkEntidades.cnx.Close();
                return idCert;
      
    }

    //sebastian
    public int spConsultarIdCertificadoNuevo(int ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdCertificadoNuevo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        SqlParameter parameter = new SqlParameter("@cer_Temp", SqlDbType.Int);
        parameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parameter);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        int idCert = int.Parse(parameter.Value.ToString());
        FrameworkEntidades.cnx.Close();
        return idCert;

    }

    //sebastian
    public DataTable spConsultarParentesco(int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarParentesco", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    public DataTable sp_ConsultarIdCertificadoValorAsegurado(int ter_Id, int pro_Id, string cer_EstadoNegocio, string cer_EstadoNegocio2)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdCertificadoValorAsegurado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio2", cer_EstadoNegocio2));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    public DataTable spConsultarLocalidadesCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadesCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    public DataTable spConsultarPlantel(int dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlantel", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //sebastian
    public DataTable spConsultarBeneficiarioModificacion(int cer_Id,double ter_Id, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarResumenCertificadoPorCompania(int com_Id,int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarResumenCertificadoPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarResumenCertificadoPorProducto(int pro_Id, int ter_Id, int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarResumenCertificadoPorProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable spConsultarCertificadoPrecargado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoPrecargado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoPrecargadoResumen(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoResumen", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoResumen(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoResumen", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Método consultarCertificadoExistente /Juan Camilo 27_07_2015
    public DataTable spConsultarCertificadoExistente(int ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoExistente", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Método consultarProIdPorNombre /Juan Camilo 27_07_2015
    public DataTable spConsultarProIdPorNombre(string pro_Nombre, string com_Nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProIdPorNombre", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Nombre", pro_Nombre));
        cmd.Parameters.Add(new SqlParameter("@com_Nombre", com_Nombre));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spActualizarNewCertificadoPreCargado(int cer_Id, int cer_HojaServicio1, int cer_HojaServicio2, int cer_HojaServicio3, int cer_AnexoConversion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoPreCargado", FrameworkEntidades.cnx);
        if (cer_AnexoConversion == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", DBNull.Value));
        }
        else
        {
             cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", cer_AnexoConversion));
        }
        if (cer_HojaServicio1 == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", DBNull.Value));
        }
        else
        {
             cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", cer_HojaServicio1));
        }
          if (cer_HojaServicio2 == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", DBNull.Value));
        }
        else
        {
             cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", cer_HojaServicio2));
        }
          if (cer_HojaServicio3 == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", DBNull.Value));
        }
        else
        {
             cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", cer_HojaServicio3));
        }

         cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
      
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable ConsultarCasoEspecial(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCasoEspecial", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

     //sebastian
    public DataTable spActualizarNewCertificado(int cer_Id, double cer_PrimaTotal, string cer_Consecutivo,
        string cer_Convenio, string cer_Declaracion, string cer_DeclaracionEnfe, string cer_EstadoNegocio, string cer_EstaturaConyuge,
        string cer_EstaturaPrincipal, string cer_Extr, double IdConyuge, string Movimiento, string PesoConyuge, string PesoPrincipal,
        int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3, int localidad, int pla_Id, int pol_Id, int mom_Id, int cer_CertificadoRecuperado, DateTime cer_FechaDigitacion, int perPag_Id)
    {
        string casoEspecial;

        DataTable dtCasoEspecial = ConsultarCasoEspecial(cer_Id);
        if (dtCasoEspecial.Rows.Count != 0)
        {
            casoEspecial = dtCasoEspecial.Rows[0]["casesp_Id"].ToString();
        }
        else
        {
            casoEspecial = "7";
        }

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificado", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
            if (cer_EstaturaConyuge == "")
            {
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
            }
            if (cer_EstaturaPrincipal == "")
            {
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
            }
            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
            if (IdConyuge == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
            }
            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
            if (PesoConyuge == "")
            {
                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
            }
            if (PesoPrincipal == "")
            {
                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
            }
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
            if (cer_CertificadoRecuperado == 0)
            {
                if (casoEspecial == "")
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                else
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
            }
            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        //}
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    public DataTable spActualizarNewCertificadoConPagaduria(int cer_Id, int cer_PrimaTotal, string cer_Consecutivo,
        string cer_Convenio, string cer_Declaracion, string cer_DeclaracionEnfe, string cer_EstadoNegocio, string cer_EstaturaConyuge,
        string cer_EstaturaPrincipal, string cer_Extr, double IdConyuge, string Movimiento, string PesoConyuge, string PesoPrincipal,
        int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3, int localidad, int pla_Id, int pol_Id, int mom_Id, int cer_CertificadoRecuperado, DateTime cer_FechaDigitacion, int perPag_Id,int paga_Id)
    {
        string casoEspecial = "";

        DataTable dtCasoEspecial = ConsultarCasoEspecial(cer_Id);
     
        if (dtCasoEspecial.Rows.Count != 0)
        {
            casoEspecial = dtCasoEspecial.Rows[0]["casesp_Id"].ToString();
        }
        if (casoEspecial == "")
        {
            casoEspecial = "0";
        }
        else
        {
            casoEspecial = "7";
        }

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoConPagaduria", FrameworkEntidades.cnx);
        // cmd.Parameters.Add(new SqlParameter("@perPag_Id", 4));

        if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "" && IdConyuge == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
            cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
            if (cer_CertificadoRecuperado == 0)
            {
                if (casoEspecial == "")
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                else
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
            }
            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba")); ;
        }
        else
        {
            if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "")
            {
                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                if (cer_CertificadoRecuperado == 0)
                {
                    if (casoEspecial == "")
                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                    else
                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                }
                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            }
            else
            {
                if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaConyuge == "" && IdConyuge == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                    if (cer_CertificadoRecuperado == 0)
                    {
                        if (casoEspecial == "")
                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                        else
                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                    }
                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                }
                else
                {
                    if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaPrincipal == "" && IdConyuge == 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                        if (cer_CertificadoRecuperado == 0)
                        {
                            if (casoEspecial == "")
                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                            else
                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                        }
                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                    }
                    else
                    {
                        if (PesoConyuge == "" && cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "" && IdConyuge == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                            if (cer_CertificadoRecuperado == 0)
                            {
                                if (casoEspecial == "")
                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                else
                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                            }
                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                        }
                        else
                        {
                            if (PesoPrincipal == "" && cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "" && IdConyuge == 0)
                            {
                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                if (cer_CertificadoRecuperado == 0)
                                {
                                    if (casoEspecial == "")
                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                    else
                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                }
                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                            }
                            else
                            {
                                if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaConyuge == "")
                                {
                                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                    if (cer_CertificadoRecuperado == 0)
                                    {
                                        if (casoEspecial == "")
                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                        else
                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                    }
                                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                }
                                else
                                {
                                    if (PesoConyuge == "" && PesoPrincipal == "" && cer_EstaturaPrincipal == "")
                                    {
                                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                        if (cer_CertificadoRecuperado == 0)
                                        {
                                            if (casoEspecial == "")
                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                            else
                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                        }
                                        else
                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                    }
                                    else
                                    {
                                        if (PesoConyuge == "" && PesoPrincipal == "" && IdConyuge == 0)
                                        {
                                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                            if (cer_CertificadoRecuperado == 0)
                                            {
                                                if (casoEspecial == "")
                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                else
                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                            }
                                            else
                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                        }
                                        else
                                        {
                                            if (PesoPrincipal == "" && cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "")
                                            {
                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                if (cer_CertificadoRecuperado == 0)
                                                {
                                                    if (casoEspecial == "")
                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                    else
                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                }
                                                else
                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                            }
                                            else
                                            {
                                                if (PesoPrincipal == "" && cer_EstaturaConyuge == "" && IdConyuge == 0)
                                                {
                                                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                    if (cer_CertificadoRecuperado == 0)
                                                    {
                                                        if (casoEspecial == "")
                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                        else
                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                    }
                                                    else
                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                }
                                                else
                                                {
                                                    if (cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "" && IdConyuge == 0)
                                                    {
                                                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                        if (cer_CertificadoRecuperado == 0)
                                                        {
                                                            if (casoEspecial == "")
                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                            else
                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                        }
                                                        else
                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                    }
                                                    else
                                                    {
                                                        if (PesoConyuge == "" && PesoPrincipal == "")
                                                        {
                                                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                            if (cer_CertificadoRecuperado == 0)
                                                            {
                                                                if (casoEspecial == "")
                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                else
                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                            }
                                                            else
                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                        }
                                                        else
                                                        {
                                                            if (PesoConyuge == "" && cer_EstaturaConyuge == "")
                                                            {
                                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                if (cer_CertificadoRecuperado == 0)
                                                                {
                                                                    if (casoEspecial == "")
                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                    else
                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                }
                                                                else
                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                            }
                                                            else
                                                            {
                                                                if (PesoConyuge == "" && cer_EstaturaPrincipal == "")
                                                                {
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                                                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                    if (cer_CertificadoRecuperado == 0)
                                                                    {
                                                                        if (casoEspecial == "")
                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                        else
                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                    }
                                                                    else
                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                                }
                                                                else
                                                                {
                                                                    if (PesoConyuge == "" && IdConyuge == 0)
                                                                    {
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                                                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                        if (cer_CertificadoRecuperado == 0)
                                                                        {
                                                                            if (casoEspecial == "")
                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                            else
                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                        }
                                                                        else
                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                    }
                                                                    else
                                                                    {
                                                                        if (PesoPrincipal == "" && cer_EstaturaConyuge == "")
                                                                        {
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                            if (cer_CertificadoRecuperado == 0)
                                                                            {
                                                                                if (casoEspecial == "")
                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                else
                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                            }
                                                                            else
                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                                        }
                                                                        else
                                                                        {
                                                                            if (PesoPrincipal == "" && cer_EstaturaPrincipal == "")
                                                                            {
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                if (cer_CertificadoRecuperado == 0)
                                                                                {
                                                                                    if (casoEspecial == "")
                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                    else
                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                }
                                                                                else
                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                            }
                                                                            else
                                                                            {
                                                                                if (cer_EstaturaConyuge == "" && cer_EstaturaPrincipal == "")
                                                                                {

                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                    if (cer_CertificadoRecuperado == 0)
                                                                                    {
                                                                                        if (casoEspecial == "")
                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                        else
                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                    }
                                                                                    else
                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                }
                                                                                else
                                                                                {
                                                                                    if (cer_EstaturaConyuge == "" && IdConyuge == 0)
                                                                                    {

                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                                                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                        if (cer_CertificadoRecuperado == 0)
                                                                                        {
                                                                                            if (casoEspecial == "")
                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                            else
                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                        }
                                                                                        else
                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (cer_EstaturaPrincipal == "" && IdConyuge == 0)
                                                                                        {

                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                                                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                            if (cer_CertificadoRecuperado == 0)
                                                                                            {
                                                                                                if (casoEspecial == "")
                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                else
                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                            }
                                                                                            else
                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (PesoConyuge == "")
                                                                                            {

                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                if (cer_CertificadoRecuperado == 0)
                                                                                                {
                                                                                                    if (casoEspecial == "")
                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                    else
                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                }
                                                                                                else
                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (PesoPrincipal == "")
                                                                                                {

                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                    if (cer_CertificadoRecuperado == 0)
                                                                                                    {
                                                                                                        if (casoEspecial == "")
                                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                        else
                                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                    }
                                                                                                    else
                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                    cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (cer_EstaturaConyuge == "")
                                                                                                    {

                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                        if (cer_CertificadoRecuperado == 0)
                                                                                                        {
                                                                                                            if (casoEspecial == "")
                                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                            else
                                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                        }
                                                                                                        else
                                                                                                            cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (cer_EstaturaPrincipal == "")
                                                                                                        {

                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                            if (cer_CertificadoRecuperado == 0)
                                                                                                            {
                                                                                                                if (casoEspecial == "")
                                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                                else
                                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                            }
                                                                                                            else
                                                                                                                cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (IdConyuge == 0)
                                                                                                            {

                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                                if (cer_CertificadoRecuperado == 0)
                                                                                                                {
                                                                                                                    if (casoEspecial == "")
                                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                                    else
                                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                                }
                                                                                                                else
                                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));

                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_Extr", cer_Extr));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@Movimiento", Movimiento));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
                                                                                                                if (cer_CertificadoRecuperado == 0)
                                                                                                                {
                                                                                                                    if (casoEspecial == "")
                                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", 3));
                                                                                                                    else
                                                                                                                        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casoEspecial));
                                                                                                                }
                                                                                                                else
                                                                                                                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", cer_CertificadoRecuperado));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
                                                                                                                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Juan Camilo /05/08/2015
    public DataTable spConsultarCertificadoFull(int cer_Certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoFull", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoFullCedula(double cedula, int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoFullPorCedula", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter", cedula));
        cmd.Parameters.Add(new SqlParameter("@pro", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoFullPorCedulaNuevo(double cedula, int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoFullPorCedulaNuevo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter", cedula));
        cmd.Parameters.Add(new SqlParameter("@pro", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Juan Camiolo /06/08/2015 - Consulta numero de poliza por id
    public DataTable spConsultarNumeroPolizaPorId(int pol_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNumeroPolizaPorId", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarNumeroPolizaPorNumero(double pol_Numero)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPolIdPolizaPorNumero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Juan Camilo /06/08/2015 - Consulta tercero por cedula
    public DataTable spConsultarNewTerceroPorCedula(int ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewConyuge", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Juan Camilo /06/08/2015 - Consulta tercero por cedula
    public DataTable spConsultarNewTerceroPorCedularResumen(int ter_Id, int pro_Id, int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewConyugeResumen", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    
    //Actualizar certificado modificacion - Juan Camilo /12/08/2015
    public string SPActualizarNewCertificadoModificacion(int cer_Id, string cer_Declaracion, string cer_DeclaracionEnfe, int localidad, string PesoPrincipal, string cer_EstaturaPrincipal, string PesoConyuge, string cer_EstaturaConyuge)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoModificacion", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", cer_Declaracion));
            cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", cer_DeclaracionEnfe));
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
            cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", PesoPrincipal));
            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", cer_EstaturaPrincipal));
            cmd.Parameters.Add(new SqlParameter("@PesoConyuge", PesoConyuge));
            cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", cer_EstaturaConyuge));
            cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
            cmd.CommandType = CommandType.StoredProcedure;
            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "REGISTRO ACTUALIZADO CON ÉXITO" : "NO SE ACTUALIZO EL REGISTRO";
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


    //Juan Camilo /21/08/2015 - Consulta otroasegurado por cer_Id
    public DataTable spConsultarOtroAsegurado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOtroAsegurado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarOtroAseguradoIndex(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOtroAseguradoIndex", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public int spInsertarCertificadoBeneficiario(DataTable dtBeneficiario, int cer_Id, int ter_Id, int par_Id)
    {
        int registros = 0, flag = 0;
        foreach (DataRow row in dtBeneficiario.Rows)
        {
            if (row["Apellidos"] != "")
            {
                FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
                FrameworkEntidades.cnx.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertarBeneficiario", FrameworkEntidades.cnx);
                //cmd.Parameters.Add(new SqlParameter("@ben_Id", cer_Id));
                cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
                cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
                cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
                if (row["NumeroDocumento"].ToString() == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@ben_identificacion", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ben_identificacion", row["NumeroDocumento"].ToString()));
                }
                cmd.Parameters.Add(new SqlParameter("@ben_apellidos", row["Apellidos"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@ben_Nombres", row["Nombres"].ToString()));
                if (row["Edad"].ToString() == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@ben_Edad", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ben_Edad", row["Edad"].ToString()));
                }
                cmd.Parameters.Add(new SqlParameter("@ben_Porcentaje", row["Porcentaje"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@ben_Parentesco", row["Parentesco"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
                cmd.CommandType = CommandType.StoredProcedure;
                registros = cmd.ExecuteNonQuery();
                FrameworkEntidades.cnx.Close();
            }
            flag++;

        }
        return registros;
    }


    //Juan Camilo 31/08/2015
    public DataTable spConsultarPlanesValorLibre(int valorLibre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlanesValorLibre", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@valorLibre", valorLibre));
        cmd.Parameters.Add(new SqlParameter("@pol_Id", 5));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarAmparoBasicoAnterior(int cer_Id, int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarValorAmparoBasicoAnterior", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //JC - 22-09-2015
    public DataTable spConsultarEncabezadoCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEncabezadoCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

 

    public DataTable spConsultarEncabezadoCertificadoResumen(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEncabezadoCertificadoResumen", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Cumulos
    public DataTable spConsultarCumulo(int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarValorCumulo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public double spConsultarValoresAsegurados(int producto, int tercero)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCumulo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", tercero));
        SqlParameter parameter = new SqlParameter("@valorTotal", SqlDbType.Money);
        parameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parameter);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        double valorAsegurado = double.Parse(parameter.Value.ToString());
        FrameworkEntidades.cnx.Close();
        return valorAsegurado;
    }

    public DataTable spMesesRecuperacion(int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMesesRecuperacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));                        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoPrecargadoPorDigitar(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoPrecargadoPorDigitar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public void spEliminarCertificado(int cer_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@user", "prueba"));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();        
    }



    public DataTable spConsultarValorAseguradoCertificado(int cer_Id, int plapol_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarValorAseguradoCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@plapol_Id", plapol_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarPlapolIdCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlapolIdCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spActualizarTipoMovimientoCertificado(int cer_Id, int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarTipoMovimientoCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento2", TipoMovimiento2));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadoAnteriorPMI(int ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoAnteriorPMI", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }



    public DataTable sp_ConsultarPlanPrincipalConyuge(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlanPrincipalConyuge", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Actualiza Fecha de Vigencia cuando es Reexpedición
    public void spActualizarFechaVigencia(int cer_Id, DateTime fechaVigencia)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarVigencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Vigencia", fechaVigencia));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public DataTable spConsultarFechaExpedicionCertificadoAnterior(int ter_Id,int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarFechaExpedicionCertificadoAnterior", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
  
    public int spInsertarCasoEspecialPreCargue(int casesp_Id, int ter_Id, int pro_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarCasoEspecialPreCargue", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casesp_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public DataTable spConsultarFechaFrontera(int age_Id, int pro_Id, DateTime expedicion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarFechaFrontera", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@expedicion", expedicion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarInformacionFechaFrontera(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarInformacionFechaFrontera", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian

    public DataTable spConsultarCasespIdNewCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCasespIdNewCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
  


    public DataTable spConsultarMesProduccionActual(int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMesProduccionActual", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));      
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public DataTable spConsultarCertificadosVigentesPorProducto(int producto, int ter_Id)

    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoExistente", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", producto));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Viviana 
    //Consulta certificado de vigilantes liberty para asignacion de nuevo numero certificado
    public DataTable spConsultarCertificadoLiberty(string ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoLiberty", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable spConsultarCertificadoAnterior(int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoAnterior", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Viviana
    //Asignar nuevo numero certificado para vigilantes liberty
    public DataTable spAsignarCertificadoLiberty(int cer_Id, int certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarCertificadoLiberty", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@certificado", certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

   
    //Viviana ?????????????????????????
    //Consultar caso especial y producto del certificado para habilitar campo de la prima 
    //public static DataTable spHabilitarCampoPrima(string cedulaPrincipal, string certificado)
    //{
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
    //    FrameworkEntidades.cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_AsignarCertificadoLiberty", FrameworkEntidades.cnx);
    //    cmd.Parameters.Add(new SqlParameter("@cedula", cedulaPrincipal));
    //    cmd.Parameters.Add(new SqlParameter("@certificado", certificado));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    da = new SqlDataAdapter(cmd);
    //    da.Fill(dt);
    //    FrameworkEntidades.cnx.Close();
    //    return dt;
    //}

    public DataTable spconsultarParentescoBeneficiario(int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarParentescoBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sebastian
    //PROCEDIMIENTO QUE ME TRAE LA PRIMERA FILA PARA LA TABLA BENEFICIARIOS
    public DataTable spConsultarBeneficiarioUnico()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarBeneficiarioUnico", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spCrearExtraPrima(int cer_IdNuevo, int cer_IdAntiguo, double ext_ValorAsegurado, double ext_ValorExtraPrima,
         double ext_ValorPrima, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearExtraPrima", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_IdNuevo", cer_IdNuevo));
        cmd.Parameters.Add(new SqlParameter("@cer_IdAntiguo", cer_IdAntiguo));
        cmd.Parameters.Add(new SqlParameter("@ext_ValorAsegurado", ext_ValorAsegurado));
        cmd.Parameters.Add(new SqlParameter("@ext_ValorExtraPrima", ext_ValorExtraPrima));
        cmd.Parameters.Add(new SqlParameter("@ext_ValorPrima", ext_ValorPrima));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarExtraPrima(int cer_IdAntiguo)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarExtraPrima", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_IdAntiguo", cer_IdAntiguo));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //consultar valor asegurado de la extra prima
    public DataTable spConsultarValorAseguradoExtraPrima(int cer_IdAntiguo, int par_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarValorAseguradoExtraPrima", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_IdAntiguo", cer_IdAntiguo));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //consultar el historial general de la extra prima
    public DataTable spConsultarHistorialExtraPrima(int cer_IdAntiguo, int par_Id, int bandera)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarHistorialExtraPrima", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_IdAntiguo", cer_IdAntiguo));
        cmd.Parameters.Add(new SqlParameter("@bandera", bandera));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //consultar el historial especifico de cada uno de los certificados anteriores
    public DataSet spConsultarHistirialPorcentajeExtraPrimado(int cer_Id, int par_Id)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarHistirialPorcentajeExtraPrimado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        FrameworkEntidades.cnx.Close();
        return ds;
    }

    public DataTable ConsultarLocalidadesAgencia(string usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadesAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spActualizarEstadoNegocioDevolucion(string cer_EstadoNegocio, int cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstadoNegocioDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCasoEspecialPreCargue(int cer_Certificado, int pro_Id, int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCasoEspecialPreCargue", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Bryam funciones para insertar archivo plano

    //Consulta tercero por documento
    public DataTable sp_ConsultarNewTerceroPorTerId(string ter_Id)
    {
         DataTable dt = new DataTable();
         SqlDataAdapter da = new SqlDataAdapter();
         FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
         FrameworkEntidades.cnx.Open();
         SqlCommand cmd= new SqlCommand("sp_ConsultarNewTerceroPorTerId", FrameworkEntidades.cnx);
         cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
         cmd.CommandType = CommandType.StoredProcedure;
         da = new SqlDataAdapter(cmd);
         da.Fill(dt);
         FrameworkEntidades.cnx.Close();
         return dt;
    }

    //Actualiza un tercero
    public int sp_ActualizarNewTerceroPorTerId(string Acedula,int Aperentesco,int AtipoDocumento,string Asexo,string Aapellidos,
    string Anombre,int AestadoCivil,DateTime AfechaNacimiento,int Adepartamento, int Aciudad,string Adireccion,
    string AtelefonoResidencia,string AtelefonoOficina,string Acelular,string Acorreo,DataTable dt)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", Acedula));
        cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", (AtipoDocumento == 0) ? dt.Rows[0]["ter_TipoDocumento"] : AtipoDocumento));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", (Anombre == string.Empty) ? dt.Rows[0]["ter_Nombres"] : Anombre));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", (Aapellidos == string.Empty) ? dt.Rows[0]["ter_Apellidos"] : Aapellidos));
        cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", (AfechaNacimiento == DateTime.MinValue) ? dt.Rows[0]["ter_FechaNacimiento"] : AfechaNacimiento));
        cmd.Parameters.Add(new SqlParameter("@ter_correo", (Acorreo == string.Empty) ? dt.Rows[0]["ter_correo"] : Acorreo));
        cmd.Parameters.Add(new SqlParameter("@ter_sexo", (Asexo == string.Empty) ? dt.Rows[0]["ter_sexo"] : Asexo));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", (Adepartamento == 0) ? dt.Rows[0]["dep_Id"] : Adepartamento));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", (Aciudad == 0) ? dt.Rows[0]["ciu_Id"] : Aciudad));
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", dt.Rows[0]["ocu_Id"]));
        cmd.Parameters.Add(new SqlParameter("@ter_Celular", (Acelular == string.Empty) ? dt.Rows[0]["ter_Celular"] : Acelular));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", (AtelefonoResidencia == null) ? dt.Rows[0]["ter_TelefonoResidencia"] : AtelefonoResidencia));
        cmd.Parameters.Add(new SqlParameter("@ter_Direccion", (Adireccion == string.Empty) ? dt.Rows[0]["ter_Direccion"] : Adireccion));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", (AtelefonoOficina == string.Empty) ? dt.Rows[0]["ter_TelefonoOficina"] : AtelefonoOficina));
        cmd.Parameters.Add(new SqlParameter("@ter_EstadoCivil", (AestadoCivil == 7) ? dt.Rows[0]["ter_EstadoCivil"] : AestadoCivil));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", (dt.Rows[0]["ter_HabeasData"] == DBNull.Value) ? 1 : dt.Rows[0]["ter_HabeasData"]));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Inserta un tercero
    public int sp_InsertarNewTercero(string Acedula, int Aperentesco, int AtipoDocumento, string Asexo, string Aapellidos,
    string Anombre, int AestadoCivil, DateTime AfechaNacimiento, int Adepartamento,
    int Aciudad, string Adireccion, string AtelefonoResidencia, string AtelefonoOficina,
    string Acelular, string Acorreo,int ocu_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTerceroCompleto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", Acedula));
        cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", AtipoDocumento));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", Anombre));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", Aapellidos));
        if (AfechaNacimiento == DateTime.MinValue)
            cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", AfechaNacimiento));
        cmd.Parameters.Add(new SqlParameter("@ter_correo", Acorreo));
        cmd.Parameters.Add(new SqlParameter("@ter_sexo", Asexo));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", Adepartamento));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", Aciudad));
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ocu_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Celular", Acelular));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", AtelefonoResidencia));
        cmd.Parameters.Add(new SqlParameter("@ter_Direccion", Adireccion));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", AtelefonoOficina));
        cmd.Parameters.Add(new SqlParameter("@ter_EstadoCivil", AestadoCivil));
        cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", 1));
        //cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Consulta asesor por codigo
    public DataTable sp_ConsultarNewAsesorPorCodigo(int ase_Codigo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAsesorPorCodigo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Codigo", ase_Codigo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Inserta un asesor
    public int sp_InsertarAsesor(int ase_Codigo,string ase_Apellidos,string ase_Nombre,string dep_Id,int com_Id,string ase_Activo,string ase_Funcionario)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Codigo", ase_Codigo));
        cmd.Parameters.Add(new SqlParameter("@ase_Apellidos", ase_Apellidos));
        cmd.Parameters.Add(new SqlParameter("@ase_Nombres", ase_Nombre));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@ase_Activo", ase_Activo));
        cmd.Parameters.Add(new SqlParameter("@ase_Funcionario", ase_Funcionario));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Consulta poliza por gr pol_Numero
    public DataTable sp_ConsultarNewPolizaPorGR(string pol_Numero)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPolIdPolizaPorNumero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta plantel
    public DataTable sp_ConsultarPlantel(string pla_Nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlantelPorNombre", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pla_Nombre", pla_Nombre));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta certificado
    public DataTable sp_ConsultarNewCertificadoPorTerceroProducto(string ter_Id,int pro_Id,string cer_Certificado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCertificadoConsecutivo", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Insertar plantel
    public int sp_InsertarPlantel(string pla_Nombre,int dep_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarPlantel", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pla_Nombre", pla_Nombre));
        //pendiente por codazi
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();        

        return registros;
    }

    //Consulta la agencia age_Id por GR
    public DataTable sp_ConsultarAgenciaPorGR(string pol_Numero)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgenciaPorGR", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta la localidad dep_Id por GR
    public DataTable sp_ConsultarLocalidadPorGR(string pol_Numero)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadPorGR", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Insertar inserta un amparo al certificado
    public int sp_InsertarAmparosCertificado(string cer_Id, string ter_Id, string par_Id, string ampcer_Nombre, double ampcer_ValAsegurado,
                                         double ampcer_Prima, double ampcer_Tasa,int amp_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAmparosCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id ));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@ampcer_Nombre", ampcer_Nombre));
        cmd.Parameters.Add(new SqlParameter("@ampcer_ValAsegurado", ampcer_ValAsegurado));
        cmd.Parameters.Add(new SqlParameter("@ampcer_Prima", ampcer_Prima));
        cmd.Parameters.Add(new SqlParameter("@ampcer_Tasa", ampcer_Tasa));
        cmd.Parameters.Add(new SqlParameter("@tasa_ExtraPrima", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@amp_Id", amp_Id));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Insertar un beneficiario
    public int sp_InsertarBeneficiario(string ben_Identificacion,string ben_Apellidos,string ben_Nombres,int ben_Edad,
                                              double ben_Porcentaje,string ben_Parentesco,string cer_Id,string ter_Id,int par_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ben_Identificacion", (ben_Identificacion == string.Empty) ? "1" : ben_Identificacion ));
        cmd.Parameters.Add(new SqlParameter("@ben_Apellidos", ben_Apellidos));
        cmd.Parameters.Add(new SqlParameter("@ben_Nombres", ben_Nombres));
        cmd.Parameters.Add(new SqlParameter("@ben_Edad", ben_Edad));
        cmd.Parameters.Add(new SqlParameter("@ben_Porcentaje", ben_Porcentaje));
        cmd.Parameters.Add(new SqlParameter("@ben_Parentesco", ben_Parentesco));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id ));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Consulta los amparos de un tercero
    public DataTable sp_ConsultarAmparos(string cer_Id, string ter_Id, string par_Id, int amp_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAmparosCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@amp_Id", amp_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta los beneficiarios
    public DataTable sp_ConsultarAmparosSuma(string cer_Id, string ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewBeneficiarioPorcentaje", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Actualizar certificado datos del conyuge
    public int sp_ActualizarNewCertificadoDatosConyuge(string cer_Id, string IdConyuge)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoConyuge", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@IdConyuge", IdConyuge));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Insertar otro asegurado
    public int sp_InsertarOtroAsegurado(string cer_Id, string ter_Id,string par_Id,string pol_Numero,double valAsegurado,int prod_Id,string terPrincipal)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarOtroAseguradoCompleto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@terPrincipal", terPrincipal));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.Parameters.Add(new SqlParameter("@valAsegurado", valAsegurado));
        cmd.Parameters.Add(new SqlParameter("@prod_Id", prod_Id));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    public DataTable sp_ConsultarPlanPoliza(string pol_Numero, string terPrincipal,double valAsegurado,string sexo,DateTime cer_FechaExpedicion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlanPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", pol_Numero));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terPrincipal));
        cmd.Parameters.Add(new SqlParameter("@valAsegurado", valAsegurado));
        cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", cer_FechaExpedicion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Insertar otro asegurado
    public int sp_InsertarOtroAseguradoSimple(string cer_Id, string ter_Id, string par_Id,DataTable dtplanPoliza,double otroase_Prima)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarOtroAsegurado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@par_Id", par_Id));
        cmd.Parameters.Add(new SqlParameter("@plapol_Id", dtplanPoliza.Rows[0]["plapol_Id"] ));
        cmd.Parameters.Add(new SqlParameter("@otroase_Prima", otroase_Prima));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Actualizar tipo de movimiento 3
    public int sp_ActualizarTipoMovimiento3(string cer_Id, int TipoMovimiento3)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoTipoMovimiento3", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id ));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento3", TipoMovimiento3));
        //cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Consulta si ya esta el asegurado
    public DataTable sp_ConsultarOtroAsegurado(string cer_Id, string ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOtroAseguradoExiste", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta una pagaduria por identificacion
    public DataTable sp_ConsultarPagaduriaIdentificacion(string paga_Identificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagaduriaPorIdentificacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Identificacion", paga_Identificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta una pagaduria por identificacion
    public DataTable sp_ConsultarConvenioPagaduria(string paga_Id,int prod_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenioPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@prod_Id", prod_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta el dep_id y ciu_id por codigo codazzi de la ciudad
    public DataTable sp_ConsultarDepartamentoCiudad(int ciu_Codazzi)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDepartamentoCiudad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ciu_Codazzi", ciu_Codazzi));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public int sp_InsertarCertificado(int age_Id, string ter_Id, DateTime cer_FechaExpedicion, DateTime cer_VigenciaDesde,int ase_Id,
    int paga_Id, DateTime cer_FechaRecibido, int com_Id, int pro_Id, int cer_SoporteFisico, int cer_HojaServicio1,
    int estcar_Id,int tipdev_Id,int caudev_Id, double cer_PrimaTotal, string cer_Consecutivo, string cer_Certificado, int cer_AnoProduccion,
    int cer_Convenio, string cer_EstadoNegocio, int Localidad, int MesProduccion, string MesProduccionLetras,
    int TipoMovimiento, DateTime VigenciaHasta, int pla_Id, string pol_Id, int mom_Id, int casesp_Id,
    DateTime cer_FechaDigitacion, int perPag_Id, int migracion)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificadoSimple", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", cer_FechaExpedicion));
        cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", cer_VigenciaDesde));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", cer_FechaRecibido));
        //cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_SoporteFisico", cer_SoporteFisico));
        //cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", cer_HojaServicio1));
        //cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        //cmd.Parameters.Add(new SqlParameter("@cer_NumeroFolios", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
        cmd.Parameters.Add(new SqlParameter("@tipdev_Id", tipdev_Id));
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", caudev_Id));
        //cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", cer_Consecutivo));
        cmd.Parameters.Add(new SqlParameter("@cer_Certificado", cer_Certificado));
        //cmd.Parameters.Add(new SqlParameter("@conyuge", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_AnoProduccion", cer_AnoProduccion));
        //cmd.Parameters.Add(new SqlParameter("@cer_CausalConyuge", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_CausalRetiro", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
        //cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstadoCartera", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstadoDescuento", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstadoSalud", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@cer_Extr", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@Jubilado", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@Localidad", Localidad));
        cmd.Parameters.Add(new SqlParameter("@MesProduccion", MesProduccion));
        cmd.Parameters.Add(new SqlParameter("@MesProduccionLetras", MesProduccionLetras));
        //cmd.Parameters.Add(new SqlParameter("@Movimiento", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@TasaExt", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@Tipo", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
        //cmd.Parameters.Add(new SqlParameter("@InicioVigenciaAnterior", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@ValorTotalAnterior", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@VigenciaHasta", VigenciaHasta));
        //cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroConyuge", DBNull.Value));
        //cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroPrincipal", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@casesp_Id", casesp_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
        cmd.Parameters.Add(new SqlParameter("@perPag_Id", perPag_Id));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@cer_Migracion", migracion));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        
        return registros;
    }


    public DataTable spConsultarCompaniaPorCertificado(double comId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCompaniaPorCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", comId));
         cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    public DataTable spConsultarLocalidad()
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

    //Actualizar tipo de movimiento 3
    public int spActualizarNewCertificadoPagaduria(string cer_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("spActualizarNewCertificadoPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        //cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    public DataTable spDuplicarCertificado(string cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificadoDuplicado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public int sp_ActualizarCertificado(string cer_Id, int age_Id, DateTime cer_FechaExpedicion, DateTime cer_VigenciaDesde, int ase_Id, int paga_Id, 
                                        DateTime cer_FechaRecibido, int pro_Id, int cer_HojaServicio1, int cer_HojaServicio2, 
                                        int cer_HojaServicio3, int estcar_Id, double cer_PrimaTotal, int cer_Convenio, 
                                        string cer_EstadoNegocio, int Localidad, int TipoMovimiento,DateTime InicioVigenciaAnterior, 
                                        DateTime VigenciaHasta, int pla_Id, string pol_Id, int mom_Id, DateTime cer_FechaDigitacion)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoPlano", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", cer_FechaExpedicion));
        cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", cer_VigenciaDesde));
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", cer_FechaRecibido));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", cer_HojaServicio1));
        cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", cer_HojaServicio2));
        cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", cer_HojaServicio3));
        cmd.Parameters.Add(new SqlParameter("@estcar_Id", estcar_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", cer_PrimaTotal));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", cer_EstadoNegocio));
        cmd.Parameters.Add(new SqlParameter("@Localidad", Localidad));
        cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", TipoMovimiento));
        cmd.Parameters.Add(new SqlParameter("@InicioVigenciaAnterior", InicioVigenciaAnterior));
        cmd.Parameters.Add(new SqlParameter("@VigenciaHasta", VigenciaHasta));
        cmd.Parameters.Add(new SqlParameter("@pla_Id", pla_Id));
        cmd.Parameters.Add(new SqlParameter("@pol_Id", pol_Id));
        cmd.Parameters.Add(new SqlParameter("@mom_Id", mom_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", cer_FechaDigitacion));
        cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    public DataTable spConsultarCertificado(double cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificado", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public DataTable spConsultarCertificadosSinPagaduria(int dep_Id,int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadosSinPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Actualiza la pagaduria y convenio del certificado
    public int spActualizarNewCertificadoPagaduria(string cer_Id,int paga_Id,int cer_Convenio)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNewCertificadoPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    public DataTable spConsultarProductoParaNovedad(double terId, int proId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductoParaNovedad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", proId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}