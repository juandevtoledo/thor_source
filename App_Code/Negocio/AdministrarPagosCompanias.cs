using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

/// <summary>
/// Descripción breve de AdministrarPagosCompanias
/// </summary>
public class AdministrarPagosCompanias
{
    
    

    #region PAGOS OTRAS COMPAÑIAS

    //Metodo que calcula y realiza el pago para el producto, vigencia y corte de recibos seleccionados
    public DataSet CalcularPagoProducto(DateTime fecha, int producto, DateTime vigencia)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataSet dsPagoOtraCia = objDaoAdminPagosCia.CalcularPagoProducto(fecha, producto, vigencia);
        return dsPagoOtraCia;
    }

    //Metodo que consultas todos los detalles asociados a un pago para el producto, la fecha de corete y vigencia seleccionada
    public DataTable ConsultarDetallesPagosCias(DateTime fecha, int producto, DateTime vigencia)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtDetallesPagosCias = objDaoAdminPagosCia.ConsultarDetallesPagosCias(fecha, producto,vigencia);
        return dtDetallesPagosCias;
    }

    //Metodo que crea el pago para el producto y en la fecha indicada, marca las aplicaciones respectivas para no volver a ser usadas.
    public DataTable CrearPagoOtrasCias(DateTime fecha, int producto, DateTime vigencia)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtRegistros = objDaoAdminPagosCia.CrearPagoOtrasCias(fecha, producto, vigencia);
        return dtRegistros;
    }

    //Metodo que consulta los pagos de un prodcuto para el rango de fechas seleccionado
    public DataTable ConsultarHistoricoProductoPagosCias(DateTime fechaInicio, DateTime fechaFin, int producto)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtHistoricoProductoPagosCias = objDaoAdminPagosCia.ConsultarHistoricoProductoPagosCias(fechaInicio,fechaFin, producto);
        return dtHistoricoProductoPagosCias;
    }

    //Metodo que devuelve el pago seleccionado, retorna un Dataset con 5 tablas con los items respectivos del pago
    public DataSet ConsultarPagoProducto(int pagId)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataSet dsPagoOtraCia = objDaoAdminPagosCia.ConsultarPagoProducto(pagId);
        return dsPagoOtraCia;
    }

    //Metodo que genera el cargue en el gridview con los clientes produccion nueva del producto y vigencia seleccionada con referencia al pago de la misma vigencia
    public DataTable ConsultarProduccionAplicada(int producto, DateTime vigencia)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtConsultarProduccionAplicada = objDaoAdminPagosCia.ConsultarProduccionAplicada(producto, vigencia);
        return dtConsultarProduccionAplicada;
    }

    //Metodo que devuele las aplicaciones asociadas a un pago enviado a la compañia
    public DataTable ConsultarDetallesPagosCiasEnviado(int pagoId)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtConsultarDetallesPagosCiasEnviado = objDaoAdminPagosCia.ConsultarDetallesPagosCiasEnviado(pagoId);
        return dtConsultarDetallesPagosCiasEnviado;
    }

    //Metodo que genera el cargue asociado al pago, del producto y vigencia seleccionado
    public DataTable ConsultarArchivoCarguePagoCompañia(int producto, DateTime vigencia)
    {
        DAOAdministrarPagosCompanias objDaoAdminPagosCia = new DAOAdministrarPagosCompanias();
        DataTable dtConsultarArchivoCarguePagoCompañia = objDaoAdminPagosCia.ConsultarArchivoCarguePagoCompañia(producto, vigencia);
        return dtConsultarArchivoCarguePagoCompañia;
    }

    #endregion
}