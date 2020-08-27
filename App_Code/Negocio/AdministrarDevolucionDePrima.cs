using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System;

/// <summary>
/// Descripción breve de AdministrarDevolucionDePrima
/// </summary>
public class AdministrarDevolucionDePrima
{
    //Consultar las posibles devoluciones en aplicacion pagos, listando por documentos y productos 
	public static DataTable ConsultarDevolucionDePrimaDocumento(double ter_Id,int pro_Id)
    {
        DataTable dtConsultarDevolucionDePrima = new DataTable();
        dtConsultarDevolucionDePrima = DAODevolucionDePrima.ConsultarDevolucionDePrimaDocumento(ter_Id, pro_Id);
        return dtConsultarDevolucionDePrima;
    }

    //Consultar compañias con su respectivo Id para listarlo en un ddl
    public static DataTable ConsultarCompaniaGeneral()
    {
        DataTable dtConsultarCompaniaGeneral = new DataTable();
        dtConsultarCompaniaGeneral = DAODevolucionDePrima.ConsultarCompaniaGeneral();
        return dtConsultarCompaniaGeneral;
    }

    //Consultar los productos por la conpañia enviada
    public static DataTable ConsultarProductoPorCompania(int com_Id)
    {
        DataTable dtConsultarProductoPorCompania = new DataTable();
        dtConsultarProductoPorCompania = DAODevolucionDePrima.ConsultarProductoPorCompania(com_Id);
        return dtConsultarProductoPorCompania;
    }

    //Crear la devolucion de prima en primer momento Uniendo las aplicaciones quese detectaron como devolucion
    public static DataTable InsertarDevolucionDePrimaMomento1(double ter_Id, int pro_Id, int dep_Id, double nov_Valor,double devEstado, double espId)
    {
        DataTable dtInsertarDevolucionDePrimaMomento1 = new DataTable();
        dtInsertarDevolucionDePrimaMomento1 = DAODevolucionDePrima.InsertarDevolucionDePrimaMomento1(ter_Id, pro_Id, dep_Id, nov_Valor, devEstado, espId);
        return dtInsertarDevolucionDePrimaMomento1;
    }

    //Consultar la localidad del tercero
    public static int ConsultarLocalidadPorCedula(double ter_Id)
    { 
       int  dep_Id = DAODevolucionDePrima.ConsultarLocalidadPorCedula(ter_Id);
       return dep_Id;
    }

    //insertar las aplicaciones que se unieron para una devolucion, funciona como tabla intermedia
    public static DataTable InsetarAplicacionPagoDevolucion(int aplPago_Id, int dev_Id)
    {
        DataTable dtspInsetarAplicacionPagoDevolucion  = new DataTable();
        dtspInsetarAplicacionPagoDevolucion = DAODevolucionDePrima.InsetarAplicacionPagoDevolucion(aplPago_Id, dev_Id);
        return dtspInsetarAplicacionPagoDevolucion;
    }
    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidad(double ter_Id, double dep_Id, int dev_Estado)
    {
        DataTable dtspConsultarDevolucionPorDocumentoLocalidad = new DataTable();
        dtspConsultarDevolucionPorDocumentoLocalidad = DAODevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidad(ter_Id, dep_Id, dev_Estado);
        return dtspConsultarDevolucionPorDocumentoLocalidad;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadAceptada(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dtspConsultarDevolucionPorDocumentoLocalidad = new DataTable();
        dtspConsultarDevolucionPorDocumentoLocalidad = DAODevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadAceptada(ter_Id, dep_Id, dev_Estado);
        return dtspConsultarDevolucionPorDocumentoLocalidad;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadConfirmacion(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dtspConsultarDevolucionPorDocumentoLocalidad = new DataTable();
        dtspConsultarDevolucionPorDocumentoLocalidad = DAODevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion(ter_Id, dep_Id, dev_Estado);
        return dtspConsultarDevolucionPorDocumentoLocalidad;
    }

    //Consultar devolución ya existente por documento,localidad y estado
    public static DataTable ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(double ter_Id, int dep_Id, int dev_Estado)
    {
        DataTable dtspConsultarDevolucionPorDocumentoLocalidad = new DataTable();
        dtspConsultarDevolucionPorDocumentoLocalidad = DAODevolucionDePrima.ConsultarDevolucionPorDocumentoLocalidadConfirmacion2(ter_Id, dep_Id, dev_Estado);
        return dtspConsultarDevolucionPorDocumentoLocalidad;
    }


    //Consultar localidades con id y nombre para listar en ddl
    public static DataTable ConsultarLocalidad()
    {
        DataTable dtConsultarLocalidad = new DataTable();
        dtConsultarLocalidad = DAODevolucionDePrima.ConsultarLocalidad();
        return dtConsultarLocalidad;
    }

    //Consultar los bancos con el Id y el nombre del banco para listar en ddl
    public static DataTable ConsultarNewBanco()
    {
        DataTable dtConsultarNewBanco = new DataTable();
        dtConsultarNewBanco = DAODevolucionDePrima.ConsultarNewBanco();
        return dtConsultarNewBanco;
    }

    //Consultar los tipos de cuenta por Id y Nombre para listar el ddl
    public static DataTable ConsultarTipoCuenta()
    {
        DataTable dtConsultarTipoCuenta = new DataTable();
        dtConsultarTipoCuenta = DAODevolucionDePrima.ConsultarTipoCuenta();
        return dtConsultarTipoCuenta;
    }

    //Insertar la informacion faltante en la devolucion para completarla y continuar con el debido proceso
    public static DataTable InsertarDevolucionMomento2(int dev_Id, int ban_Id, int tipcue_Id, double numeroCuenta, int dev_Estado
    ,string dev_nombreTitular, double dev_cedulaTitular, int caudev_Id, int espId, int bandera)
    {
        DataTable dtInsertarDevolucionMomento2 = new DataTable();
        dtInsertarDevolucionMomento2 = DAODevolucionDePrima.InsertarDevolucionMomento2(dev_Id, ban_Id, tipcue_Id, numeroCuenta, dev_Estado, dev_nombreTitular, dev_cedulaTitular, caudev_Id,espId,bandera);
        return dtInsertarDevolucionMomento2;
    }

    //Consultar Devoluciones por el estado ingresado
    public static DataTable ConsultarDevolucionConfirmacion(int dev_Estado)
    {
        DataTable dtConsultarDevolucionConfirmacion = new DataTable();
        dtConsultarDevolucionConfirmacion = DAODevolucionDePrima.ConsultarDevolucionConfirmacion(dev_Estado);
        return dtConsultarDevolucionConfirmacion;
    }

    //Consultar Devoluciones por el estado ingresado
    public static DataTable ConsultarDevolucionAceptada(int dev_Estado)
    {
        DataTable dtConsultarDevolucionAceptada= new DataTable();
        dtConsultarDevolucionAceptada = DAODevolucionDePrima.ConsultarDevolucionAceptada(dev_Estado);
        return dtConsultarDevolucionAceptada;
    }

    //Actualizar el estado de la devolucion dependiendo de si es confirmada o rechazada, en caso de ser chazada se envia
    // el causal de la devolución
    public static DataTable ActualizarEstadoDevolucionRechazadaAceptada(int dev_Id, int dev_Estado, int rech_Id)
    {
        DataTable dtActualizarEstadoDevolucionRechazadaAceptada = new DataTable();
        dtActualizarEstadoDevolucionRechazadaAceptada = DAODevolucionDePrima.ActualizarEstadoDevolucionRechazadaAceptada(dev_Id, dev_Estado, rech_Id);
        return dtActualizarEstadoDevolucionRechazadaAceptada;
    }

    //Actualiza el numero de movimiento y fecha de transferencia
    public static int ActualizarDevolucionNumeroFechaTransferencia(int dev_Id,int numeroMovimiento, DateTime fechaTranferencia)
    {
        int r = DAODevolucionDePrima.ActualizarDevolucionNumeroFechaTransferencia(dev_Id,numeroMovimiento, fechaTranferencia);
        return r;
    }

    //Listar los causales de las devolucion de prima con id y nombre
    public static DataTable ConsultarCausalDevolucionPrima()
    {
        DataTable dtConsultarCausalDevolucionPrima = new DataTable();
        dtConsultarCausalDevolucionPrima = DAODevolucionDePrima.ConsultarCausalDevolucionPrima();
        return dtConsultarCausalDevolucionPrima;
    }

    //Listar los causales de las devolucion de prima con id y nombre
    public static DataTable ConsultarCausalRechazoDevolucionPrima()
    {
        DataTable dtConsultarCausalDevolucionPrima = new DataTable();
        dtConsultarCausalDevolucionPrima = DAODevolucionDePrima.ConsultarCausalRechazoDevolucionPrima();
        return dtConsultarCausalDevolucionPrima;
    }

    //Metodo que retorna una tabala con las aplicaciones de Pago asociadas a una devolucion de Prima
    //09/12/2016
    public static DataTable ConsultarAplicacionesDevolucion(int idDev)
    {
        DataTable dtConsultarAplicacionesDevolucion = new DataTable();
        dtConsultarAplicacionesDevolucion = DAODevolucionDePrima.ConsultarAplicacionesDevolucionPrima(idDev);
        return dtConsultarAplicacionesDevolucion;
    }

    //Metodo para registrar la relacion del soporte con el id y la ubicacion en el servidor
    //09/12/2016
    public static int RegistrarArchivosDevoluciones(string idSopDev, string idDev,
    string nomSopDev, string urlSopDev)
    {
        int resIdSopDev = DAODevolucionDePrima.RegistrarArchivosSoporteConvenio(idSopDev, idDev,nomSopDev, urlSopDev);
        return resIdSopDev;
    }

    //Metodo que retorna una tabla con los Archivos Adjuntos asociados a una devolucion.
    //09/12/2016
    public static DataTable ConsultarArchivosSoporteDevolucion(int? idSopDev, string nomSopDev, int? idDev)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarArchivosSoporteDevolucion(idSopDev, nomSopDev, idDev);
        return dt;
    }

    //Metodo que elimina los Soportes Adjuntos a una Devolucion de Prima
    //09/12/2016
    public static string EliminarArchivoSoporteDevolucion(int idSopDev)
    {
        string resIdSopDev = DAODevolucionDePrima.EliminarArchivosSoporteDevolucion(idSopDev);
        return resIdSopDev;
    }

    //Consultar devoluciones de prima para informe devolucion de primas
    public static DataTable ConsultarDevolucionPrimaSeleccionable(int dep_Id, int mes, DateTime dev_FechaDesde, DateTime dev_FechaHasta, int com_Id, int pro_Id, int forpag_Id, int caudev_Id, int dev_Estado, int rech_Id)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarDevolucionPrimaSeleccionable(dep_Id,mes,dev_FechaDesde,dev_FechaHasta,com_Id,pro_Id,forpag_Id,caudev_Id,dev_Estado,rech_Id);
        return dt;
    }

    //Consultar aplicaiones pago para informe 
    public static DataTable ConsultarAplicacionSeleccionable(int dep_Id, int paga_Id, int con_Id, int rec_Id, int com_Id, int pro_Id, DateTime dev_FechaDesde, DateTime dev_FechaHasta)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarAplicacionSeleccionable(dep_Id, paga_Id,con_Id,rec_Id,com_Id,pro_Id, dev_FechaDesde, dev_FechaHasta);
        return dt;
    }

    //Consultar recibos para informe 
    public static DataTable ConsultarRecibosSeleccionable(int dep_Id, int paga_Id, int con_Id, string rec_Id, int com_Id, int pro_Id, DateTime dev_FechaDesde, DateTime dev_FechaHasta)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarRecibosSeleccionable(dep_Id, paga_Id, con_Id, rec_Id, com_Id, pro_Id, dev_FechaDesde, dev_FechaHasta);
        return dt;
    }

    //Consultar resumen de un recibo para informe 
    public static DataTable ConsultarReciboResumen(int rec_Id)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarReciboResumen(rec_Id);
        return dt;
    }

    //Consultar las localidades
    public static DataTable ConsultarLocalidades()
    {
        DataTable dt = new DataTable();
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        dt = objdministrarCertificado.ConsultarLocalidades();
        return dt;
    }

    //Consulta aplicacion de pago por id aplPago_Id
    public static DataTable ConsultarAplicacionPagoPorId(int aplPago_Id)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarAplicacionPagoPorId(aplPago_Id);
        return dt;
    }

    //Elimina una aplicacion pago por id aplPago_Id
    public static int EliminarAplicacionPagoPorId(int aplPago_Id)
    {
        int registros = DAODevolucionDePrima.EliminarAplicacionPagoPorId(aplPago_Id) ;
        return registros;
    }

    //Consulta aplicacion de pago por id aplPago_Id
    public static DataTable ConsultarConvenioProducto(double ter_Id,int pro_Id)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarConvenioProducto(ter_Id,pro_Id);
        return dt;
    }

    //Consulta el producto a pagar 
    public static DataTable ConsultarProductoParaPagoPorProducto(double ter_Id, int cer_Convenio, int pro_Id)
    {
        DataTable dt = new DataTable();
        dt =DAODevolucionDePrima.ConsultarProductoParaPagoPorProducto(ter_Id,cer_Convenio, pro_Id);
        return dt;
    }

    public static DataTable ActualizarReversionYBorradoDeAplicacion(double aplPagoId, double bandera)
    {
        DataTable dt = new DataTable();
        DAOPagos objPagos = new DAOPagos();
        dt = objPagos.ActualizarReversionYBorradoDeAplicacion(aplPagoId,bandera);
        return dt;
    }

    //Consulta certificado por convenio
    public static DataTable ConsultarCertificadoPorConvenio(string ter_Id, string con_Nombre)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarCertificadoPorConvenio(ter_Id, con_Nombre);
        return dt;
    }

    //Consulta convenio por nombre
    public static DataTable ConsultarConvenioNombre(string con_Nombre)
    {
        DataTable dt = new DataTable();
        dt = DAODevolucionDePrima.ConsultarConvenioNombre(con_Nombre);
        return dt;
    }
}