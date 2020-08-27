using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DAOAdministraPagosBolivar
/// </summary>
public class DAOAdministraPagosBolivar
{
    
    #region PAGOS_SEGUROSBOLIVAR

    #region SOLICITUD DE CHEQUES
    //Metodo que retorna la tabla con la solicitud de cheques para la fecha enviada
    public DataTable CrearSolicitudCheques(DateTime fecha)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearSolicitudesCheques", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
		cmd.CommandTimeout = 500000;
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;       
        
    }

    //Inserta la solicitud de cheque en la tabla y retorna el id de la solicitud
    public int InsertarSolicitudheque(DateTime fecha)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarSolicitudCheque", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return int.Parse( dt.Rows[0]["IdSolicitud"].ToString());


    }


    //public int AsignarIdSolicitudAplicaciones(int id, DateTime fecha)
    //{        
    //    FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
    //    FrameworkEntidades.cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_AsignarSolicitudAplicaciones", FrameworkEntidades.cnx);
    //    cmd.Parameters.Add(new SqlParameter("@idSolicitud", id));
    //    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    int registros = cmd.ExecuteNonQuery();
    //    FrameworkEntidades.cnx.Close();
    //    return registros;
        
    //}


    //public DataTable ConsultarSolicitudCheques(DateTime fecha)
    //{
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
    //    FrameworkEntidades.cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_ConsultarSolicitudCheques", FrameworkEntidades.cnx);
    //    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    da = new SqlDataAdapter(cmd);
    //    da.Fill(dt);
    //    FrameworkEntidades.cnx.Close();
    //    return dt;


    //}

    //Metodo que devuelve el detalle de las solicitud para la localidad indicada, es una tabla con los recibos de caja asociados
    public DataTable ConsultarDetallesSolicitudCheques(int localidad, int idSolicitud)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDetallesSolicitudCheque", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
        cmd.Parameters.Add(new SqlParameter("@idSolicitud", idSolicitud));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;


    }


    public DataTable ConsultarSolicitudesCheques(DateTime fecha, int numeroTalon)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSolicitudesCheques", FrameworkEntidades.cnx);
        
        if (numeroTalon > 0 )
        {
            cmd.Parameters.Add(new SqlParameter("@numeroTalon", numeroTalon ));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@numeroTalon", DBNull.Value ));
        }
        if (fecha == Convert.ToDateTime ("1/01/0001"))
        {
            cmd.Parameters.Add(new SqlParameter("@fecha", DateTime.Now));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public DataTable ConsultarSolicitudChequeCreada(int idSolicitud)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSolicitudChequeGuardada", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idSolicitud", idSolicitud));        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public int ActualizarTalonSolicitudCheque(int idSolicitud, int numeroTalonSimasol, DateTime fecha)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ActualizarTalonSolicitudCheque", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idSolicitud",idSolicitud));
        cmd.Parameters.Add(new SqlParameter("@numeroTalon",numeroTalonSimasol));
        cmd.Parameters.Add(new SqlParameter("@fecha",fecha));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }



    
    public int InsertarTalonSolicitudCheque(int idSolicitud, int numeroTalonSimasol, DateTime fecha, int valorTalonSimasol)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarTalonSolicitudCheque", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idSolicitud", idSolicitud));
        cmd.Parameters.Add(new SqlParameter("@numeroTalon", numeroTalonSimasol));
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.Parameters.Add(new SqlParameter("@valorTalonSimasol", valorTalonSimasol));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }



    public DataTable ConsultarTalonesSolicitudCheque(int idSolicitud)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarTalonesSolicitudCheque", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idSolicitud", idSolicitud));        
        cmd.CommandType = CommandType.StoredProcedure;

        //int registros = cmd.ExecuteNonQuery();
        //FrameworkEntidades.cnx.Close();
        //return registros;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    #endregion SOLICITUD DE CHEQUES



    #region FACTURACION

    //Metodo que retorna la tabla con las facturaciones para el producto 724 (pagos con vigencias menores a Julio de 2016)
    public DataTable CrearFacturacionesPMI724(DateTime fecha)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearFacturacionesPMI724", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Metodo que consulta en la BD las facturaciones filtradas por fecha de Creacion y/o Numero de Tronador
    public DataTable ConsultarFacturaciones(DateTime fechaCorte, DateTime fechaCreacion, int numeroTronador, int localidad, int producto)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_Consultarfacturaciones", FrameworkEntidades.cnx);

        if (numeroTronador > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@numeroTronador", numeroTronador));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@numeroTronador", DBNull.Value));
        }
        if (fechaCorte == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaCorte", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaCorte", fechaCorte));
        }
        if (fechaCreacion == Convert.ToDateTime("01/01/1900"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaCreacion", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaCreacion", fechaCreacion));
        }
        if (localidad > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@localidad", DBNull.Value));
        }
        if (producto > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@producto", producto));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@producto", DBNull.Value));
        }
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    
    //Metodo que crea en la BD las facturaciones para el pago:
    //1. Producto 710-799 En Solicitudes de Cheques
    //2. Producto 710-799 con pago directo a la compañia
    //3. Producto 724 con pago directo a la compañia
    public DataTable CrearFacturacionesPago(DateTime fecha)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearFacturacionesPago", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 10000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Metodo que actualiza el numero de Factura y Tronador de una facturacion
    public int ActualizarTronadorFacturaFacturacion(int idFacturacion, int numeroTronador, int numeroFactura, DateTime fechaFactura)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("[sp_ActualizarTronadorFacturaFacturacion]", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@idFacturacion", idFacturacion));
        cmd.Parameters.Add(new SqlParameter("@numeroTronador", numeroTronador));
        cmd.Parameters.Add(new SqlParameter("@numeroFactura", numeroFactura));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }


    //Metodo que consulta en la BD las aplicaciones asociadas a un id de Facturacion
    public DataTable ConsultarDetallesFacturacion(int idFacturacion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDetallesFacturacion", FrameworkEntidades.cnx);        
        cmd.Parameters.Add(new SqlParameter("@idFacturacion", idFacturacion));   
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
    #endregion FACTURACION

    #region PAGO


    //Metodo que devuelve en un dataset las tablas para armar el pago por una localidad
    //1.Facturaciones
    //2.Detalles
    //3.Novedades
    //4.Soportes
    public DataSet CalcularPagoLocalidad(int idLocalidad)
    {
        DataSet dsPagoLocalidad = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CalcularPagoLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@localidad", idLocalidad));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dsPagoLocalidad);
        FrameworkEntidades.cnx.Close();
        return dsPagoLocalidad;
    }

    ////Metodo que actualiza la fecha de envio de las facturaciones asociadas a un pago de localidad
    //public int ActualizarFechaEnvioFacturacionLocalidad(int idLocalidad)
    //{
    //    DataSet dsPagoLocalidad = new DataSet();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
    //    FrameworkEntidades.cnx.Open();
    //    SqlCommand cmd = new SqlCommand("sp_ActualizarFechaEnvioPagoLocalidad", FrameworkEntidades.cnx);
    //    cmd.Parameters.Add(new SqlParameter("@localidad", idLocalidad));
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    int registros = cmd.ExecuteNonQuery();
    //    FrameworkEntidades.cnx.Close();
    //    return registros;
    //}

    //Metodo que crea el pago para la localidad y compañia correspondiente 
    //actualiza la fecha de envio de las facturaciones y soportes asociadas a un pago de localidad
    //actualiza las aplicaciones con el id del pago correspondiente
    public int CrearPagoLocalidad(int idLocalidad, int compañia)
    {
        DataSet dsPagoLocalidad = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CrearPagoLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@localidad", idLocalidad));
        cmd.Parameters.Add(new SqlParameter("@compañia", compañia));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }
    

    public DataTable ConsultarLocalidadesPago()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadesPago", FrameworkEntidades.cnx);        
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    //Metodo que consulta los pagos enviados filtrados por localidad entre fechas
    public DataTable ConsultarHistoricoPagos(int idLocalidad, DateTime fechaInicio, DateTime fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarHistoricoPagos", FrameworkEntidades.cnx);
        if (idLocalidad == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@idLocalidad", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@idLocalidad", idLocalidad));
        }
        cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //Metodo que consulta un pago enviado por el id 
    public DataSet ConsultarPagoLocalidad(int idPago)
    {
        DataSet dsPagoLocalidad = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPagoLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pago_id", idPago));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        cmd.CommandTimeout = 500000;
        da.Fill(dsPagoLocalidad);
        FrameworkEntidades.cnx.Close();
        return dsPagoLocalidad;
    }



    //Metodo que consulta los recibos de caja en una fecha indicada
    public DataTable ConsultarRecibosCaja(DateTime fechaInicio, DateTime fechaFin, int agencia, int producto, int compañia)
    {
        DataTable dtRecibosCaja = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRecibosCaja", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.Parameters.Add(new SqlParameter("@agencia", agencia));
        cmd.Parameters.Add(new SqlParameter("@producto", producto));
        cmd.Parameters.Add(new SqlParameter("@compañia", compañia));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dtRecibosCaja);
        FrameworkEntidades.cnx.Close();
        return dtRecibosCaja;
    }

    #endregion PAGO

    #region COMISIONES

    //Metodo que consulta las comisiones enviadas en los pagos por Torres Guarin a la compañia segun los filtros respectivos de producto, localidad, fecha de Envio y Numero de Poliza(GR)
    public DataTable ConsultarComisionesSegurosBolivar(int producto, int localidad, DateTime fechaEnvio, int poliza)
    {
        DataTable dtComisionesSegurosBolivar = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarComisionesSegurosBolivar", FrameworkEntidades.cnx);
        if (producto == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@producto", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@producto", producto));
        }
        if (localidad == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@departamento", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@departamento", localidad));
        }
        if (poliza == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@poliza", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@poliza", poliza));
        }
        if (fechaEnvio == Convert.ToDateTime("01/01/0001"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaEnvio", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaEnvio", fechaEnvio));
        }

        //cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        //cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dtComisionesSegurosBolivar);
        FrameworkEntidades.cnx.Close();
        return dtComisionesSegurosBolivar;
    }

    //Metodo que realiza la insercion de un registro del extracto de seguros bolivar
    public int InsertarRegistroExtracto(int ramo, int producto, int op, double poliza, int fa, int al, string cliente, int valorPrima, int valorRecaudo, int participacion, int valorComision, DateTime fechaPago, string localidad)
    {
        //DataSet dsPagoLocalidad = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarRegistroExtracto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@Ramo", ramo));
        cmd.Parameters.Add(new SqlParameter("@Producto", producto));
        cmd.Parameters.Add(new SqlParameter("@Op", op));
        cmd.Parameters.Add(new SqlParameter("@Poliza", poliza));
        cmd.Parameters.Add(new SqlParameter("@Fa", fa));
        cmd.Parameters.Add(new SqlParameter("@Al", al));
        cmd.Parameters.Add(new SqlParameter("@Cliente", cliente));
        cmd.Parameters.Add(new SqlParameter("@ValorPrima", valorPrima));
        cmd.Parameters.Add(new SqlParameter("@ValorRecaudo", valorRecaudo));
        cmd.Parameters.Add(new SqlParameter("@Participacion", participacion));
        cmd.Parameters.Add(new SqlParameter("@ValorComision", valorComision));
        cmd.Parameters.Add(new SqlParameter("@FechaPago", fechaPago));
        cmd.Parameters.Add(new SqlParameter("@Localidad", localidad));
        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }


    //Metodo que consulta los gr de Seguros Bolivar
    public DataTable ConsultarPolizasBolivar()
    {
        DataTable dtPolizasBolivar = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPolizasPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@compania", 1));
        //cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        //cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dtPolizasBolivar);
        FrameworkEntidades.cnx.Close();
        return dtPolizasBolivar;
    }

    //Evento que consulta las comisiones pagadas por la compañia segun los extractos cargados por los filtros respectivos de producto, localidad, fecha de pago y Numero de Poliza(GR) y los retorna en un dt
    public DataTable ConsultarConsolidadoExtractoBolivar(int producto, string localidad, DateTime fechaPago, int poliza)
    {
        DataTable dtConsolidadoExtractoBolivar = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConsolidadoExtractoBolivar", FrameworkEntidades.cnx);
        if (producto == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@producto", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@producto", producto));
        }
        if (localidad == "")
        {
            cmd.Parameters.Add(new SqlParameter("@departamento", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@departamento", localidad));
        }
        if (poliza == 0)
        {
            cmd.Parameters.Add(new SqlParameter("@poliza", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@poliza", poliza));
        }
        if (fechaPago == Convert.ToDateTime("01/01/0001"))
        {
            cmd.Parameters.Add(new SqlParameter("@fechaPago", DBNull.Value));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@fechaPago", fechaPago));
        }

        //cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
        //cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500000;
        da = new SqlDataAdapter(cmd);
        da.Fill(dtConsolidadoExtractoBolivar);
        FrameworkEntidades.cnx.Close();
        return dtConsolidadoExtractoBolivar;
    }

    #endregion COMISIONES



    #endregion PAGOS_SEGUROSBOLIVAR
}