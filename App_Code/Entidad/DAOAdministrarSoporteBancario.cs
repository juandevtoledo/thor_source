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
/// Descripción breve de DAOAdministrarSoporteBancario
/// </summary>
/// 

// ============== CARGA ARCHIVO EXCEL, APROBACION Y APLICACION DE SOPORTES ============

public class DAOAdministrarSoporteBancario
{
    // Inserta los soportes que se cargan en el excel en la tabla temporal
    public static int InsertarSoporteBancario(string informacionBanco, string formaPago, DateTime fechaMovimiento, string tipoDocumento, long identificacion, double valor, string referencia, string localidad, string txtNomSoporte)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_TipoDocumento", tipoDocumento));
        cmd.Parameters.Add(new SqlParameter("@sop_Identificacion", identificacion));
        cmd.Parameters.Add(new SqlParameter("@sop_InfoBanco", informacionBanco));
        cmd.Parameters.Add(new SqlParameter("@sop_FormaPago", formaPago));
        cmd.Parameters.Add(new SqlParameter("@sop_FechaM", fechaMovimiento));
        cmd.Parameters.Add(new SqlParameter("@sop_Valor", valor));
        cmd.Parameters.Add(new SqlParameter("@sop_Numero", referencia));
        cmd.Parameters.Add(new SqlParameter("@sop_Localidad", localidad));  
        cmd.Parameters.Add(new SqlParameter("@sop_Nombre", txtNomSoporte));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;

    }

    // Consutar tabla temporal
    public static int ConsultarTempSoporteBancario()
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTemSoporteBancario", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        //return InsertarSoporteBancario2();
        return registros;
    }


    //Viviana 
    //Listar todos los soportes
    public static DataTable ListarSoportes(string usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_listarSoportesBancarios", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Viviana
    // Consultar detalle del soporte
    public static DataTable ConsultarDetalleSoportes(int encSop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDetalleSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Viviana 
    //APROBAR de soportes
    public static int AprobarSoporteBancario(int encSop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AprobarSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    //RECHAZAR de soportes
    public static int RechazarSoporteBancario(int encSop_Id, string textAreaMotivo, long identificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_rechazarSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.Parameters.Add(new SqlParameter("@motivo", textAreaMotivo));
        cmd.Parameters.Add(new SqlParameter("@identificacion", identificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }



    // Insertar Pagos, Aplicaciones y recibos
    public static int AplicarPagosSoporteBancario(int encSop_Id, int sop_Id, long ter_Id, string usuario)
    {
        // Inserta a NewPago
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarPagosSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();

        if (registros > 0)
        {
            // Inserta a NewAplicacionPagos
            cmd = new SqlCommand("sp_InsertarAplicacionPagoSoporteBancario", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
            cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            // Inserta a NewReciboPago
            cmd = new SqlCommand("sp_InsertarReciboPagoSoporteBancario", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
        }

        return registros;
    }

    //consultar convenio cedula para aplicar novedad
    public static DataTable ConsultarCovenioCedula(long identificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCovenioCedula", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", identificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Eliminar Soportes
    public static int EliminarSoporteBancario(int encSop_Id)
    { 
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    // ============== CARGA ARCHIVO EXCEL, APROBACION Y APLICACION DE SOPORTES ============

    // ============== INGRESAR UNO A UNO ============

    public static DataTable ListarTipoDocumento(int cargo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarTipoDocumentoSoporte", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@car_Id", cargo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarFormaPago(int cargo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarFormaPago", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@car_Id", cargo));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static DataTable ListarTipoSoporteBancario(int formaPago)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_listarTipoSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@formaPago", formaPago));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
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
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // PENDIENTE
    public static DataTable ListarBancos(int com_Id, int tipBan_Id)
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

    public static DataTable ConsultarBancosSoporteBancario(int intCompania, int tipoBanco, int formaPago)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarBancosSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", intCompania));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipoBanco));
        cmd.Parameters.Add(new SqlParameter("@formaPago_Id", formaPago));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    

    public static DataTable ConsultarTipoCuenta(int ban_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoCuenta", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", ban_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarNumeroCuenta(int ban_Id, int tipCue_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewCuentaBancaria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", ban_Id));
        cmd.Parameters.Add(new SqlParameter("@tipCue_Id", tipCue_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }



    public static int InsertarSoporteBancarioUno(int tipoDoc, int identificacion, int pagaduria, int formaPago, string cheque, int Recibido, int compania, int banco, int tipoCuenta, int cuenta,
        DateTime fecha, int talon, int valor, string sucursal, string usuario)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarSoporteBancarioUno", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tipoDoc", tipoDoc));
        cmd.Parameters.Add(new SqlParameter("@identificacion", identificacion));
        cmd.Parameters.Add(new SqlParameter("@pagaduria", pagaduria));
        cmd.Parameters.Add(new SqlParameter("@formaPago", formaPago));
        cmd.Parameters.Add(new SqlParameter("@cheque", cheque));
        cmd.Parameters.Add(new SqlParameter("@recibido", Recibido));
        cmd.Parameters.Add(new SqlParameter("@compania", compania));
        cmd.Parameters.Add(new SqlParameter("@banco", banco));
        cmd.Parameters.Add(new SqlParameter("@tipoCuenta", tipoCuenta));
        cmd.Parameters.Add(new SqlParameter("@cuenta", cuenta));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@talon", talon));
        cmd.Parameters.Add(new SqlParameter("@valor", valor));
        cmd.Parameters.Add(new SqlParameter("@sucursal", sucursal));
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
        
    }

    public static DataTable ConsultarLocalidades()
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

    public static DataTable ConsultarPagadurias(int dep_Id)
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



    public static DataTable ConsultarConvenios( int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConveniosSoporte", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        //cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarSoportesPagaduria(int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSoportesPagaduria", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarDetalleTotal(int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarDetalleTotalSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int InsertarDetalleSoporte(string con_Id, string valorDistri, string sop_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarDetalleSoporte", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@valorDistri", valorDistri));
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }



    public static void CambiarEstadoSoporteBancario(int encSop_Id, int sop_Id, long ter_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CambiarEstadoSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable ConsultarDistribucionSoporte(int sop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarDistribucionSoporte", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int EliminarDetalleDistribucion(int detDistri)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_eliminarDetalleDistribucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@detDistri", detDistri));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static DataTable ConsultarEncabezadoSoporte(int encSop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarEncabezadoSoporte", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static DataTable ConsultarBancosSoporteBancarioEditar(int intCompania, int tipoBanco)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarBancosSoporteBancarioEditar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", intCompania));
        cmd.Parameters.Add(new SqlParameter("@tipBan_Id", tipoBanco));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int ModificarEncabezadoSoporteBancario(int banco, int tipoCuenta, int cuenta, int encSop_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ModificarEncabezadoSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ban_Id", banco));
        cmd.Parameters.Add(new SqlParameter("@tipCue_Id", tipoCuenta));
        cmd.Parameters.Add(new SqlParameter("@cue_Id", cuenta));
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static DataTable ConsultarSoporteBancarioEditar(string sop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_consultarSoporteBancarioEditar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int ModificarSoporteBancario(int tipDoc, string identificacion, string referencia, int talon, string valor, int sop_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_modificarSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tipDoc", tipDoc));
        cmd.Parameters.Add(new SqlParameter("@identificacion", identificacion));
        cmd.Parameters.Add(new SqlParameter("@referencia", referencia));
        cmd.Parameters.Add(new SqlParameter("@talon", talon));
        cmd.Parameters.Add(new SqlParameter("@valor", valor));
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sop_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }



    public static DataTable ListarBancos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewBancos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ListarEstados()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarEstados", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarInformeSoporteBancario(int tipDoc, int banco, int recibido, int estado, DateTime fechaDesde, DateTime fechaHasta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeGeneralSoporteBancario", FrameworkEntidades.cnx);

        if (tipDoc > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", tipDoc));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", DBNull.Value));
        }

        if (banco > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@ban_Id", banco));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ban_Id", DBNull.Value));
        }

        if (recibido > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@recibido", recibido));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@recibido", DBNull.Value));
        }

        if (estado > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@est_Id", estado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@est_Id", DBNull.Value));
        }

        if (fechaDesde == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaDesde", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaDesde", fechaDesde));
        }

        if (fechaHasta == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaHasta", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaHasta", fechaHasta));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable BuscarEncabezadoSoporteBancario(string banco, string cuenta, DateTime fecha, string recibido, string estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarEncabezadoSoporteBancario", FrameworkEntidades.cnx);

        if (banco != "")
        {
            cmd.Parameters.Add(new SqlParameter("@banco", banco));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@banco", DBNull.Value));
        }

        if (cuenta != "")
        {
            cmd.Parameters.Add(new SqlParameter("@cuenta", cuenta));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@cuenta", DBNull.Value));
        }

        if (fecha == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fecha", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        }

        if (recibido != "")
        {
            cmd.Parameters.Add(new SqlParameter("@recibido", recibido));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@recibido", DBNull.Value));
        }
        if (estado != "")
        {
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@estado", DBNull.Value));
        }

        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable BuscarSoporteBancario(string formaPago, string identificacion, string referencia, string estado, int encSop_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarSoporteBancario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@encSop_Id", encSop_Id));

        if (formaPago != "")
        {
            cmd.Parameters.Add(new SqlParameter("@formaPago", formaPago));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@formaPago", DBNull.Value));
        }

        if (identificacion != "")
        {
            cmd.Parameters.Add(new SqlParameter("@identificacion", identificacion));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@identificacion", DBNull.Value));
        }

        if (referencia != "")
        {
            cmd.Parameters.Add(new SqlParameter("@referencia", referencia));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@referencia", DBNull.Value));
        }
        if (estado != "")
        {
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@estado", DBNull.Value));
        }

        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}