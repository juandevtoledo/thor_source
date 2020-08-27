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
/// Summary description for DAOPagos
/// </summary>
public class DAOPagos
{
    public SqlConnection cnx;

    public string Conexion(string conexion)
    {
        return ConfigurationManager.ConnectionStrings[conexion].ConnectionString;
    }

    //Consultar tercero por cédula
    public DataTable ConsultarPagadurias()
    {
        DataTable dtPagadurias = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarPagadurias", cnx);
            //cmd.Parameters.Add(new SqlParameter("@ter_Id", AdministrarTercero.asegurado.NumeroDocumento));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtPagadurias);
        }
        catch (Exception ex)
        {
            dtPagadurias = null;
        }
        cnx.Close();
        return dtPagadurias;
    }


    //Consultar convenios por pagaduria
    public DataTable ConsultarConveniosPorPagaduria(int paga_Id)
    {
        DataTable dtConvenios = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarConveniosPorPagaduria", cnx);
            cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtConvenios);
        }
        catch (Exception ex)
        {
            dtConvenios = null;
        }
        cnx.Close();
        return dtConvenios;
    }


    //Consultar certificadosConciliacion por convenio
    public DataTable ConsultarCertificadosConciliacion(int cer_Convenio)
    {
        DataTable dtCertificadosConciliacion = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadosConciliacion", cnx);
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtCertificadosConciliacion);
        }
        catch (Exception ex)
        {
            dtCertificadosConciliacion = null;
        }
        cnx.Close();
        return dtCertificadosConciliacion;
    }


    //Consultar certificados segun pagos ya conciliados (excel2)
    public DataTable ConsultarCertificadosPorPagos(int ter_Id, int cer_Convenio)
    {
        DataTable dtCertificadosPorPagos = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadosPorPagos", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtCertificadosPorPagos);
        }
        catch (Exception ex)
        {
            dtCertificadosPorPagos = null;
        }
        cnx.Close();
        return dtCertificadosPorPagos;
    }


    //Consultar mora en pagos
    public DataTable ConsultarMorasEnPagos(int pro_Id, int ter_Id, int con_Id)
    {
        DataTable dtMorasEnPagos = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarMorasEnPagos", cnx);
            cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtMorasEnPagos);
        }
        catch (Exception ex)
        {
            dtMorasEnPagos = null;
        }
        cnx.Close();
        return dtMorasEnPagos;
    }


    //Consultar la prioridad de pago por producto
    public DataTable ConsultarPrioridadPagoPorProducto(int pro_Id)
    {
        DataTable dtPrioridadPago = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarPrioridadPagoPorProducto", cnx);
            cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtPrioridadPago);
        }
        catch (Exception ex)
        {
            dtPrioridadPago = null;
        }
        cnx.Close();
        return dtPrioridadPago;
    }


    //sp_ConsultarProductoParaPago
    public DataTable ConsultarProductoParaPago(double ter_Id, int cer_Convenio)
    {
        DataTable dtProductoParaPago = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionPago", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtProductoParaPago);
        }
        catch (Exception ex)
        {
            dtProductoParaPago = null;
        }
        cnx.Close();
        return dtProductoParaPago;
    }

    //sp_ConsultarProductoParaPago
    public DataTable ConsultarProductoParaPagoReversion(double ter_Id, int cer_Convenio, double pro_Id)
    {
        DataTable dtProductoParaPago = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionPagoReversion", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.Parameters.Add(new SqlParameter("@pro_Id2", pro_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dtProductoParaPago);
        }
        catch (Exception ex)
        {
            dtProductoParaPago = null;
        }
        cnx.Close();
        return dtProductoParaPago;
    }

    //sp_ConsultarProductoParaPago
    public string ConsultarProductoParaDevolucionDePrima(double terId, int cer_Convenio)
    {
        DataTable dtProductoParaPago = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        string proId;
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarProductoParaDevolucionDePrima", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
            cmd.Parameters.Add(new SqlParameter("@con_Id", cer_Convenio));
            SqlParameter parameter = new SqlParameter("@pro_Id", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            proId = parameter.Value.ToString();
        }
        catch (Exception ex)
        {
            proId = null;
        }
       
        cnx.Close();
        return proId;
    }

    public DataTable ConsultarNombreUsuarioPorCedula(double cedula)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNombreUuario", cnx);
        cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public double ConsularPorcentajeParticipacion(int paga_Id)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_ConsultarPorcentajeParticipacion", cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        double registros = double.Parse(cmd.ExecuteScalar().ToString());
        cnx.Close();
        return registros;
    }

    public DataTable ConsultarSoporteBancarioParaPago(int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSoporteBancarioParaPago", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    public int IngresarAplicacionPagoCliente(double terId, int idPago, int idProducto, DateTime fecha, int dev_Id, double valor, int convenio, double aplPagoReversion, double pagoRecibo,double cer_Id)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAplicacionPago", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
        cmd.Parameters.Add(new SqlParameter("@id_Pago", idPago));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", idProducto));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.Parameters.Add(new SqlParameter("@valor", valor));
        cmd.Parameters.Add(new SqlParameter("@convenio", convenio));
        cmd.Parameters.Add(new SqlParameter("@aplPago_Reversion", aplPagoReversion));
        cmd.Parameters.Add(new SqlParameter("@pago_Recibo", pagoRecibo));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
        return registros;
    }

    public  int InsertarAplicacionPagoParaDevolucion(double terId, int idPago, string idProducto, double valor, int dev_Id, int convenio, double aplPagoReversion)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAplicacionPagoParaDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
        cmd.Parameters.Add(new SqlParameter("@id_Pago", idPago));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", idProducto));
        cmd.Parameters.Add(new SqlParameter("@valor", valor));
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.Parameters.Add(new SqlParameter("@convenio", convenio));
        cmd.Parameters.Add(new SqlParameter("@aplPago_Reversion", aplPagoReversion));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
        return registros;
    }

    public int ConsultarIdAplicacionPago(double ter_Id, int con_Id)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdAplicacionPago", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        int idAplPago = Convert.ToInt32(cmd.ExecuteScalar());
        cnx.Close();
        return idAplPago;
    }

    //método para insertarRecibos
    public void InsertarRecibo(int convenio)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_insertarRecibo", cnx);
        cmd.Parameters.Add(new SqlParameter("@conven", convenio));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
    }


    public DataTable ConsultarIdPago()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarIdPago", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarNovedadesAplicadas(double ter_Id, int con_Id,int proId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarNovedadesAplicadas", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@proId", proId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarConveniosConciliacion(int paga_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConveniosConciliacion", cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarRecibos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecibos", cnx);
        //cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarRecibosConSeleccionables(int paga_Id, int age_Id, int con_Id, int com_Id, int pro_Id, string rec_Numero,string rec_Identificacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecibosConSeleccionables", cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@rec_Numero", rec_Numero));
        cmd.Parameters.Add(new SqlParameter("@rec_Identificacion", rec_Identificacion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarCompaniasGenerales()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCompaniasGenerales", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public void CrearRecibosCaja(int age_Id, int con_Id, int rec_Oficina,int rec_Identificacion, string cedulaCreador)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearRecibosCaja", cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@CONVENIO", con_Id));
        cmd.Parameters.Add(new SqlParameter("@rec_Oficina", rec_Oficina));
        cmd.Parameters.Add(new SqlParameter("@rec_Identificacion", rec_Identificacion));
        cmd.Parameters.Add(new SqlParameter("@nombreCreador", cedulaCreador));
        //cmd.Parameters.Add(new SqlParameter("@user", AdministrarCertificados.usuarioSistema.NombreUsuario));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
    }

    public DataTable ConsultarPagoPorOficina(double ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagoPorOficina", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarConvenioPagoOficina(double ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenioPagoOficina", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable InformeAplicacionPagos(int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeAplicacionPagos", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    // Consultar El historial de pagos por cliente para pagos por oficina
    public DataTable InformeAplicacionPagosPorOficina(int con_Id, double ter_Id,int proId,int comId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeAplicacionPagosPorOficina", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", proId));
        cmd.Parameters.Add(new SqlParameter("@com_Id", comId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    public DataTable InformeAplicacionPagosBusqueda(int con_Id,DateTime fecha_Inicial,DateTime fecha_Final, int com_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeAplicacionPagosBusqueda", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@fecha_Inicial", fecha_Inicial.Date));
        cmd.Parameters.Add(new SqlParameter("@fecha_Final", fecha_Final.Date));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarCompaniaEnConciliacion(int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCompaniaEnConciliacion", cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarRecaudoEsperado()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecaudoEsperado", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
    public DataTable ConsultarMesProduccionActual(int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMesProduccionActual", cnx);
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public int ConsultarAplicacionPagoParaRecaudoEsperado(int ter_Id, int pro_Id,DateTime Vigencia, int PrimaRecaudo)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionPagoParaRecaudoEsperado", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@Vigencia", Vigencia));
        cmd.Parameters.Add(new SqlParameter("@PrimaRecaudo", PrimaRecaudo));
        SqlParameter parameter = new SqlParameter("@resultado", SqlDbType.Int);
        parameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parameter);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        int resultado = int.Parse(parameter.Value.ToString());
        cnx.Close();
        return resultado;
    }

    public DataTable ConsultarSopIdSoporteBancario(int sopdet_Id, int bandera)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSopIdSoporteBancario", cnx);
        cmd.Parameters.Add(new SqlParameter("@sopdet_Id", sopdet_Id));
        cmd.Parameters.Add(new SqlParameter("@bandera", bandera));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    
    public DataTable ConsultarReciboParaSoporte(int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarReciboParaSoporte", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }


    public void InsertarNewSoportePorRecibo(int rec_Id, int sopdet_Id)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewDetalleSoporteRecibo", cnx);
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));
        cmd.Parameters.Add(new SqlParameter("@sopdet_Id", sopdet_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
    }


    public DataTable ConsultarCertificadoReversion(int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoReversionManual", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

        public DataTable ConsultarCertificadoReversionConsulta(int con_Id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            cnx = new SqlConnection(Conexion("ConexionBD"));
            cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoReversionManualConsulta", cnx);
            cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnx.Close();
            return dt;
        }

    
    public DataTable ConsultarUltimoPagoParaReversion(double ter_Id, DateTime fecha, double pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUltimoPagoParaReversion", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarInformacionAnteriorPagosReversion(double ter_Id, DateTime fecha, double pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarInformacionAnteriorPagosReversion", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarEstadoNegocioDevolucion(string estadoNegocio,  double cerId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstadoNegocioDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", estadoNegocio));
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cerId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
    public DataTable ActualizarDepIdParaReversion(double aplPagoId, double devId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarDevIdParaReversion", cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPagoId));
        cmd.Parameters.Add(new SqlParameter("@dev_Id", devId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarInformacionAnteriorPagosReversionPagoId(double ter_Id, DateTime fecha, double pro_Id,double pago_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarInformacionAnteriorPagosReversionPagoId", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@pago_Id", pago_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarReversionYBorradoDeAplicacion( double aplPagoId,double bandera)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarReversionYBorradoDeAplicacion", cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPagoId));
        cmd.Parameters.Add(new SqlParameter("@bandera", bandera));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
    public DataTable ConsultarCertificado(double cer_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cer_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarFechaYMarcarReestructuracion(double con_Id,  double valCon_Reestructuracion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarFechaYMarcarReestructuracion", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@valCon_Reestructuracion", valCon_Reestructuracion));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarConveniosReversionManual()
    {
       DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConveniosReversionManual", cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    //Metodo que trae el recibo para ser impreso, recibe como parametro el id del recibo
    public DataTable ConsultarReciboImprimir(int rec_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarReciboCajaImprimir", cnx);
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    //Metodo que trae la vigencia y valor de las aplicaciones  del recibo para ser impreso, recibe como parametro el id del recibo, se usa para pago individual
    public DataTable ConsultarAplicacionesReciboImprimir(int rec_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionesReciboCajaImprimir", cnx);
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarSoportePagosPorOficina(double terId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSoportePagosPorOficina", cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Identificacion", terId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable CrearDetalleSoporteBancario(double sopId, double sopdetValor, double sopdetTipo, double pagoId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearDetalleSoporteBancario", cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sopId));
        cmd.Parameters.Add(new SqlParameter("@sopdet_Valor", sopdetValor));
        cmd.Parameters.Add(new SqlParameter("@sopdet_tipo", sopdetTipo));
        cmd.Parameters.Add(new SqlParameter("@pago_Id", pagoId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarEstadoSoporteBancario(double sopId, double estId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstadoSoporteBancario", cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sopId));
        cmd.Parameters.Add(new SqlParameter("@est_Id", estId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarValorAplicadoSoporteBancario(double sopId, double sop_ValorAplicar)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarValorAplicadoSoporteBancario", cnx);
        cmd.Parameters.Add(new SqlParameter("@sop_Id", sopId));
        cmd.Parameters.Add(new SqlParameter("@sop_ValorAplicar", sop_ValorAplicar));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ActualizarValorYObservacionDevolucion(double aplPagoId,double aplPagoValorDevolucion, string aplPagoObservacionesDevolucion, int aplPagoEstDevolucion, int devId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarValorYObservacionDevolucion", cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPagoId));
        cmd.Parameters.Add(new SqlParameter("@aplPago_ValorDevolucion", aplPagoValorDevolucion));
        cmd.Parameters.Add(new SqlParameter("@aplPago_ObservacionesDevolucion", aplPagoObservacionesDevolucion));
        cmd.Parameters.Add(new SqlParameter("@AplPagoEstadoDevolucion", aplPagoEstDevolucion));
        cmd.Parameters.Add(new SqlParameter("@dev_Id", devId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarProductosConvenio(double conId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductosConvenio", cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", conId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarCompaniaPorCertificado(double comId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCompaniaPorCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", comId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

  public DataTable IngresarPagoCliente(double terId, double pagoValor, DateTime fecha, int convenio, double pagoMes, double pagoAnio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarPago", cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", terId));
        cmd.Parameters.Add(new SqlParameter("@pago_Valor", pagoValor));
        cmd.Parameters.Add(new SqlParameter("@pago_Fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@con_Id", convenio));
        cmd.Parameters.Add(new SqlParameter("@pago_Mes", pagoMes));
        cmd.Parameters.Add(new SqlParameter("@pago_Año", pagoAnio));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public void ActualizarConvenioCertificado(double cerId, double cerConvenio)
    {
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarConvenioCertificado", cnx);
        cmd.Parameters.Add(new SqlParameter("@cer_Id", cerId));
        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cerConvenio));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 5000000;
        int registros = cmd.ExecuteNonQuery();
        cnx.Close();
    }

    public DataTable ConsultarAplicacionesMayoresFechaVigencia(DateTime fecha, double terId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionesMayoresFechaVigencia", cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@terId", terId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    public DataTable ConsultarValorAgrupadoDePago(DateTime fecha, double terId,double proId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarValorAgrupadoDePago", cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@terId", terId));
        cmd.Parameters.Add(new SqlParameter("@proId", proId));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    //Consulta novedades de retiro
    public DataTable ConsultarNovedadesRetiro(int paga_Id,int con_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNovedadesRetiro", cnx);
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }

    //Consultar causa de cedula no cincidente
    public DataTable spConsultarCausasCedulasNoCoincidentes(string ter_Id, int con_Id, int opcion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarCausasCedulasNoCoincidentes", cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", con_Id));
            cmd.Parameters.Add(new SqlParameter("@opcion", opcion));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            dt = null;
        }
        cnx.Close();
        return dt;
    }
    //Metodo que consulta de la base de datos la agencia para el usuario
    public DataTable ConsultarAgenciasUsuario(string usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        cnx = new SqlConnection(Conexion("ConexionBD"));
        cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgenciasUsuario", cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cnx.Close();
        return dt;
    }
}