using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de AdministrarPagosBolivar
/// </summary>
public class AdministrarPagosBolivar
{
       

    

    #region PAGOS_SEGUROSBOLIVAR

    #region SOLICITUD DE CHEQUES

    //Metodo para realizar las solicitud de cheque en la fecha indicada
    public DataTable CrearSolicitudCheques (DateTime fecha)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtSolicitudCheque = objDaoAdminPagosBol.CrearSolicitudCheques(fecha);
        //int idSolicitud = objDaoAdminPagosBol.InsertarSolicitudheque(fecha);        
        //int registros = objDaoAdminPagosBol.AsignarIdSolicitudAplicaciones(idSolicitud, fecha);
        return dtSolicitudCheque;
    }

    ////Metodo que devuelve el registro de solicitud de Cheques creada en una fecha determinada, se usa para identificar la actual
    //public DataTable ConsultarSolicitudCheque(DateTime fecha)
    //{
    //    DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
    //    DataTable dtSolicitudCheque = objDaoAdminPagosBol.ConsultarSolicitudCheques(fecha);
    //    return dtSolicitudCheque;
    //}


    //Metodo que devuelve el detalle de las solicitud para la localidad indicada
    public DataTable ConsultarDetallesSolicitudCheques(int localidad, int idSolicitud)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtSolicitudCheque = objDaoAdminPagosBol.ConsultarDetallesSolicitudCheques(localidad, idSolicitud);
        return dtSolicitudCheque;
    }

    //Metodo que consulta las Solicitudes de Cheques en el sistema filtradas por fecha y/o numero de Talon o Simasol
    public DataTable ConsultarSolicitudesCheques(DateTime fecha, int numeroTalon)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtSolicitudCheque = objDaoAdminPagosBol.ConsultarSolicitudesCheques(fecha, numeroTalon);
        return dtSolicitudCheque;
    }

    //Metodo que muestra una solicitu de cheques ya creada y guardada
    public DataTable ConsultarSolicitudChequeCreada(int idSolicitud)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtSolicitudCheque = objDaoAdminPagosBol.ConsultarSolicitudChequeCreada(idSolicitud);
        return dtSolicitudCheque;
    }

    //Metodo que actualiza el numero y la fecha del Talon o Simasol de una solicitud Creada.
    public int ActualizarTalonSolicitudCheque(int idSolicitud, int numeroTalonSimasol, DateTime fecha)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        int registros = objDaoAdminPagosBol.ActualizarTalonSolicitudCheque(idSolicitud, numeroTalonSimasol, fecha);
        return registros;
    }

    //Metodo para insertar el numero de talon y la fecha a una solicitud de cheques en el sistema
    public int InsertarTalonSolicitudCheque(int idSolicitud, int numeroTalonSimasol, DateTime fecha, int valorTalonSimasol)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        int registros = objDaoAdminPagosBol.InsertarTalonSolicitudCheque(idSolicitud, numeroTalonSimasol, fecha,valorTalonSimasol);
        return registros;
    }


    public DataTable ConsultarTalonesSolicitudCheque(int idSolicitud)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();

        //int registros = objDaoAdminPagosBol.InsertarTalonSolicitudCheque(idSolicitud, numeroTalonSimasol, fecha, valorTalonSimasol);
        //return registros;

        DataTable dtTalonesSolicitudCheque = objDaoAdminPagosBol.ConsultarTalonesSolicitudCheque(idSolicitud);
        return dtTalonesSolicitudCheque;
    }

    #endregion SOLICITUD DE CHEQUES


    #region FACTURACION

    //Metodo que crea las facturaciones 724 en las solicitudes de cheques, actualiza las aplicaciones correspondientes y retorna las facturaciones
    public DataTable CrearFacturacionesPMI724(DateTime fecha)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtFacturaciones = objDaoAdminPagosBol.CrearFacturacionesPMI724(fecha);
        return dtFacturaciones;
    }


    public DataTable ConsultarFacturaciones(DateTime fechaCorte, DateTime fechaCreacion, int numeroTronador, int localidad, int producto)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtFacturaciones = objDaoAdminPagosBol.ConsultarFacturaciones(fechaCorte, fechaCreacion, numeroTronador,localidad,producto);
        return dtFacturaciones;
    }

    //Metodo que crea en la BD las facturaciones para el pago:
    //1. Producto 710-799 En Solicitudes de Cheques
    //2. Producto 710-799 con pago directo a la compañia
    //3. Producto 724 con pago directo a la compañia
    public DataTable CrearFacturacionesPago(DateTime fecha)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtFacturacionesPago = objDaoAdminPagosBol.CrearFacturacionesPago(fecha);
        return dtFacturacionesPago;
    }

    //Metodo que actualiza el numero de Factura y Tronador de una facturacion
    public int ActualizarTronadorFacturaFacturacion(int idFacturacion, int numeroTronador, int numeroFactura, DateTime fechaFactura)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        int registros = objDaoAdminPagosBol.ActualizarTronadorFacturaFacturacion(idFacturacion, numeroTronador, numeroFactura, fechaFactura);
        return registros;
    }

     //Metodo que consulta en la BD las aplicaciones asociadas a un id de Facturacion
    public DataTable ConsultarDetallesFacturacion(int idFacturacion)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtFacturacionesPago = objDaoAdminPagosBol.ConsultarDetallesFacturacion(idFacturacion);
        return dtFacturacionesPago;
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
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataSet dsPagoLocalidad = objDaoAdminPagosBol.CalcularPagoLocalidad(idLocalidad);
        return dsPagoLocalidad;
    }

    ////Metodo que actualiza la fecha de envio de las facturaciones asociadas a un pago de localidad
    //public int ActualizarFechaEnvioFacturacionLocalidad(int idLocalidad)
    //{
    //    DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
    //    int registros = objDaoAdminPagosBol.ActualizarFechaEnvioFacturacionLocalidad(idLocalidad);
    //    return registros;
    //}


    //Metodo que crea el pago para la localidad y compañia correspondiente 
    //actualiza la fecha de envio de las facturaciones y soportes asociadas a un pago de localidad
    //actualiza las aplicaciones con el id del pago correspondiente
    public int CrearPagoLocalidad(int idLocalidad, int compañia)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        int registros = objDaoAdminPagosBol.CrearPagoLocalidad(idLocalidad, compañia);
        return registros;
    }


    public DataTable ConsultarLocalidadesPago()
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtLocalidadesPago = objDaoAdminPagosBol.ConsultarLocalidadesPago();
        return dtLocalidadesPago;
    }

    //Metodo que consulta los pagos enviados filtrados por localidad entre fechas
    public DataTable ConsultarHistoricoPagos(int idLocalidad, DateTime fechaInicio, DateTime fechaFin)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtLocalidadesPago = objDaoAdminPagosBol.ConsultarHistoricoPagos(idLocalidad, fechaInicio, fechaFin);
        return dtLocalidadesPago;

    }


    //Metodo que consulta un pago enviado por el id 
    public DataSet ConsultarPagoLocalidad(int idPago)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataSet dsPagoLocalidad = objDaoAdminPagosBol.ConsultarPagoLocalidad(idPago);
        return dsPagoLocalidad;
    }

    //Metodo que consulta los recibos de caja en una fecha indicada
    public DataTable ConsultarRecibosCaja(DateTime fechaInicio, DateTime fechaFin, int agencia, int producto, int compañia)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dRecibosCaja = objDaoAdminPagosBol.ConsultarRecibosCaja(fechaInicio, fechaFin, agencia,producto,compañia);
        return dRecibosCaja;
    }
    
    #endregion PAGO

    #region COMISIONES

    //Metodo que consulta las comisiones enviadas en los pagos por Torres Guarin a la compañia segun los filtros respectivos de producto, localidad, fecha de Envio y Numero de Poliza(GR)
    public DataTable ConsultarComisionesSegurosBolivar(int producto, int localidad, DateTime fechaEnvio, int poliza)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtComisionesSegurosBolivar = objDaoAdminPagosBol.ConsultarComisionesSegurosBolivar(producto,localidad,fechaEnvio,poliza);        
        return dtComisionesSegurosBolivar;
    }


    //Metodo que realiza la insercion de un registro del extracto de seguros bolivar
    public int InsertarRegistroExtracto(int ramo, int producto, int op, double poliza, int fa, int al, string cliente, int valorPrima, int valorRecaudo, int participacion, int valorComision, DateTime fechaPago, string localidad)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        int registros = objDaoAdminPagosBol.InsertarRegistroExtracto(ramo,  producto,  op,  poliza,  fa,  al,  cliente,  valorPrima,  valorRecaudo,  participacion,  valorComision,  fechaPago,  localidad);        
        return registros;
    }

    //Metodo que consulta los gr de Seguros Bolivar
    public DataTable ConsultarPolizasBolivar()
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtPolizasBolivar = objDaoAdminPagosBol.ConsultarPolizasBolivar();
        return dtPolizasBolivar;
    }

    //Evento que consulta las comisiones pagadas por la compañia segun los extractos cargados por los filtros respectivos de producto, localidad, fecha de pago y Numero de Poliza(GR) y los retorna en un dt
     public DataTable ConsultarConsolidadoExtractoBolivar(int producto, string localidad, DateTime fechaPago, int poliza)
    {
        DAOAdministraPagosBolivar objDaoAdminPagosBol = new DAOAdministraPagosBolivar();
        DataTable dtConsolidadoExtractoBolivar = objDaoAdminPagosBol.ConsultarConsolidadoExtractoBolivar(producto, localidad, fechaPago, poliza);
        return dtConsolidadoExtractoBolivar;
    }
    #endregion COMISIONES

    #endregion
}