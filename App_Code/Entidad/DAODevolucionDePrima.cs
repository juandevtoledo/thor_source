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
/// Descripción breve de DAODevolucionDePrima
/// </summary>
public class DAODevolucionDePrima
{
    //Consultar las posibles devoluciones en aplicacion pagos, listando por documentos y productos 
    public static DataTable ConsultarDevolucionDePrimaDocumento(double ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionDePrimaDocumento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar compañias con su respectivo Id para listarlo en un ddl
    public static DataTable ConsultarCompaniaGeneral()
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

    //Consultar los productos por la conpañia enviada
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

    //Crear la devolucion de prima en primer momento Uniendo las aplicaciones quese detectaron como devolucion
    public static DataTable InsertarDevolucionDePrimaMomento1(double ter_Id, int pro_Id, int dep_Id, double nov_Valor,double devEstado, double espId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarDevolucionDePrimaMomento1", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@nov_Valor", nov_Valor));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", devEstado));
        if (espId == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@esp_Id", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@esp_Id", espId));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar la localidad del tercero
    public static int ConsultarLocalidadPorCedula(double ter_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadPorCedula", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        SqlParameter parameter = new SqlParameter("@dep_Id", SqlDbType.Int);
        parameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parameter);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        int dep_Id = int.Parse(parameter.Value.ToString());
        FrameworkEntidades.cnx.Close();
        return dep_Id;

    }

    //insertar las aplicaciones que se unieron para una devolucion, funciona como tabla intermedia 
    public static DataTable InsetarAplicacionPagoDevolucion(int aplPago_Id, int dev_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarAplicacionPagoDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPago_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidad(double ter_Id, double dep_Id, int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionPorDocumentoLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadAceptada(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionPorDocumentoLocalidadAceptada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionPorDocumentoLocalidadConfirmacion2", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionPorDocumentoLocalidadConfirmacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar localidades con id y nombre para listar en ddl
    public static DataTable ConsultarLocalidad()
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

    //Consultar los bancos con el Id y el nombre del banco para listar en ddl
    public static DataTable ConsultarNewBanco()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewBanco", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar los tipos de cuenta por Id y Nombre para listar el ddl
    public static DataTable ConsultarTipoCuenta()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTipoCuenta", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Insertar la informacion faltante en la devolucion para completarla y continuar con el debido proceso
    public static DataTable InsertarDevolucionMomento2(int dev_Id, int ban_Id, int tipcue_Id, double numeroCuenta, int dev_Estado
        , string dev_nombreTitular, double dev_cedulaTitular, int caudev_Id,int espId, int bandera)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarDevolucionMomento2", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.Parameters.Add(new SqlParameter("@ban_Id", ban_Id));
        cmd.Parameters.Add(new SqlParameter("@tipcue_Id", tipcue_Id));
        cmd.Parameters.Add(new SqlParameter("@numeroCuenta", numeroCuenta));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.Parameters.Add(new SqlParameter("@dev_nombreTitular", dev_nombreTitular));
        cmd.Parameters.Add(new SqlParameter("@dev_cedulaTitular", dev_cedulaTitular));
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", caudev_Id));
        cmd.Parameters.Add(new SqlParameter("@esp_Id", espId));
        cmd.Parameters.Add(new SqlParameter("@bandera", bandera));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar Devoluciones por el estado ingresado
    public static DataTable ConsultarDevolucionConfirmacion(int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionConfirmacion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar Devoluciones por el estado ingresado
    public static DataTable ConsultarDevolucionAceptada(int dev_Estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionAceptada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Actualizar el estado de la devolucion dependiendo de si es confirmada o rechazada, en caso de ser chazada se envia
    // el causal de la devolución
    public static DataTable ActualizarEstadoDevolucionRechazadaAceptada(int dev_Id, int dev_Estado, int rech_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarEstadoDevolucionRechazadaAceptada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.Parameters.Add(new SqlParameter("@rech_Id", rech_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int ActualizarDevolucionNumeroFechaTransferencia(int dev_Id,int numeroMovimiento, DateTime fechaTranferencia)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarDevolucionNumeroFechaTransferencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Id", dev_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_numeroMovimiento", numeroMovimiento));
        cmd.Parameters.Add(new SqlParameter("@dev_fechaTransferencia", fechaTranferencia));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Listar los causales de las devolucion de prima con id y nombre 
    public static DataTable ConsultarCausalDevolucionPrima()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCausalDevolucionPrima", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Listar los rechazos de las devoluciones de prima con id y nombre 
    public static DataTable ConsultarCausalRechazoDevolucionPrima()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCausalRechazoDevolucionPrima", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Metodo que retorna una tabla con las Aplicaciones de Pago asociadas a una devolucion de Prima
    //09/12/2016
    public static DataTable ConsultarAplicacionesDevolucionPrima(int idDev)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionesDevolucion", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dev_Id", idDev));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Metodo para registrar la relacion del soporte con el id y la ubicacion en el servidor
    //09/12/2016
    public static int RegistrarArchivosSoporteConvenio(string idSopDev, string idDev,
                                            string nomSopDev, string urlSopDev)
    {
        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_RegistrarArchivosSoporteDevolucion", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idSopDev))
                cmd.Parameters.Add(new SqlParameter("@idSopDev", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopDev", int.Parse(idSopDev)));

            cmd.Parameters.Add(new SqlParameter("@idDev", int.Parse(idDev)));
            cmd.Parameters.Add(new SqlParameter("@nomSopDev", nomSopDev));
            cmd.Parameters.Add(new SqlParameter("@urlSopDev", urlSopDev));

            cmd.Parameters.Add(new SqlParameter("@resIdSopDev", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopConv = Int32.Parse(cmd.Parameters["@resIdSopDev"].Value.ToString());

            return resIdSopConv;

        }
        catch (Exception ex)
        {
            //textLog = new CreateLogFiles_CxBD();
            //textLog.AddlogCxBD(ex.ToString());
            return -1;
        }
    }



    //Metodo para consultar los Soportes subidos a una devolucion de Prima
    //09/12/2016
    public static DataTable ConsultarArchivosSoporteDevolucion(int? idSopDev, string nomSopDev, int? idDev)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_ConsultarArchivosSoporteDevolucion", FrameworkEntidades.cnx);


            if (idSopDev.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idSopDev", idSopDev));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopDev", DBNull.Value));

            if (String.IsNullOrEmpty(nomSopDev))
                cmd.Parameters.Add(new SqlParameter("@nomSopDev", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomSopDev", nomSopDev));

            if (idDev.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idDev", idDev));
            else
                cmd.Parameters.Add(new SqlParameter("@idDev", DBNull.Value));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            //textLog = new CreateLogFiles_CxBD();
            //textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }



    //Metodo para eliminar un soporte adjunto asociado a una devolucion
    //09/12/2016
    public static string EliminarArchivosSoporteDevolucion(int idSopDev)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_EliminarArchivosSoporteDevolucion", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idSopDev", idSopDev));
            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDel"].Value.ToString();

        }
        catch (Exception ex)
        {
            //textLog = new CreateLogFiles_CxBD();
            //textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }

    //Consultar devoluciones de prima para informe devolucion de primas
    public static DataTable ConsultarDevolucionPrimaSeleccionable(int dep_Id, int mes, DateTime dev_FechaDesde, DateTime dev_FechaHasta, int com_Id, int pro_Id,int forpag_Id,int caudev_Id,int dev_Estado,int rech_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDevolucionesPrimaConSeleccionables", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@mes", mes));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaDesde", dev_FechaDesde));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaHasta", dev_FechaHasta));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@forpag_Id", forpag_Id));
        cmd.Parameters.Add(new SqlParameter("@caudev_Id", caudev_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_Estado", dev_Estado));
        cmd.Parameters.Add(new SqlParameter("@rech_Id", rech_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar aplicaciones para informe 
    public static DataTable ConsultarAplicacionSeleccionable(int dep_Id, int paga_Id, int con_Id, int rec_Id, int com_Id, int pro_Id, DateTime dev_FechaDesde, DateTime dev_FechaHasta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionesConSeleccionables", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaDesde", dev_FechaDesde));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaHasta", dev_FechaHasta));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar recibos para informe 
    public static DataTable ConsultarRecibosSeleccionable(int dep_Id, int paga_Id, int con_Id, string rec_Id, int com_Id, int pro_Id, DateTime dev_FechaDesde, DateTime dev_FechaHasta)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecibosConSeleccionablesInforme", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaDesde", dev_FechaDesde));
        cmd.Parameters.Add(new SqlParameter("@dev_FechaHasta", dev_FechaHasta));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consultar resumen de un recibo para informe 
    public static DataTable ConsultarReciboResumen(int rec_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarReciboResumen", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@rec_Id", rec_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta aplicacion de pago por id aplPago_Id
    public static DataTable ConsultarAplicacionPagoPorId(int aplPago_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionPagoADevolver", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPago_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Elimina una aplicacion pago por id aplPago_Id
    public static int EliminarAplicacionPagoPorId(int aplPago_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarAplicacionPago", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@aplPago_Id", aplPago_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();

        return registros;
    }

    //Consulta los convenios que tiene un certificado por producto
    public static DataTable ConsultarConvenioProducto(double ter_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenioProducto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //sp_ConsultarProductoParaPago
    public static DataTable ConsultarProductoParaPagoPorProducto(double ter_Id, int cer_Convenio, int pro_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        try
        {
            SqlCommand cmd = new SqlCommand("sp_consultarAplicacionPagoProducto", FrameworkEntidades.cnx);
            cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
            cmd.Parameters.Add(new SqlParameter("@cer_Convenio", cer_Convenio));
            cmd.Parameters.Add(new SqlParameter("@pro_Id2", pro_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            dt = null;
        }
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Consulta certificado por convenio
    public static DataTable ConsultarCertificadoPorConvenio(string ter_Id, string con_Nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCertificadoPorConvenio", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Nombre", con_Nombre));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    //Consulta convenio
    public static DataTable ConsultarConvenioNombre(string con_Nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConvenioNombre", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Nombre", con_Nombre));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}


