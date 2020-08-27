using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reporte
/// </summary>
public class Reporte
{
    /// <summary>
    /// Lista todas las compañías del sistema
    /// </summary>
    /// <returns>Tabla con todas las compañías</returns>
    public static DataTable ListarCompanias()
    {
        DataTable dt = new DataTable();
        dt = DAOReporte.sp_ListarCompanias();
        return dt;
    }

    /// <summary>
    /// Lista todos los departamentos del sistema
    /// </summary>
    /// <returns>Tabla con todos los departamentos</returns>
    public static DataTable mostrarDepartamento()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_MostrarDepartamento();
        return dt;
    }

    /// <summary>
    /// Lista todas las ciudades que coincidan con los Ids de departamentos enviados
    /// </summary>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las ciudades que coincidan con los Ids de departmanetos enviados</returns>
    public static DataTable ListarCiudadesPorFiltros(string idDepartamentos)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ListarCiudadesPorFiltros(idDepartamentos);
        return dt;
    }

    /// <summary>
    /// Lista todas las agencias que coincidan con los filtros enviados
    /// </summary>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las agencias que coincidan con los Ids de departmanetos enviados</returns>
    public static DataTable ListarAgenciasPorFiltros(string idDepartamentos)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ListarAgenciasPorFiltros(idDepartamentos);
        return dt;
    }

    /// <summary>
    /// Lista todos los productos que coincidan con los Ids enviados
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los productos que coincidan con los Ids enviados</returns>
    public static DataTable ListarProductosPorFiltros(string idCompanias)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ListarProductosPorFiltros(idCompanias);
        return dt;
    }

    /// <summary>
    /// Lista todas las pagadurías que coincidan con los filtros enviados
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las pagadurías que coincidan con los filtros enviados</returns>
    public static DataTable ListarPagaduriasPorFiltros(string idCompanias, string idProductos)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ListarPagaduriasPorFiltros(idCompanias, idProductos);
        return dt;
    }

    /// <summary>
    /// Lista todos los estados de negocio de los certificados
    /// </summary>
    /// <returns>Tabla con todos los estados de negocio de los certificados</returns>
    public static DataTable ListarEstadosNegocioCertificados()
    {
        DataTable dt = new DataTable();
        dt = DAOReporte.sp_ListarEstadosNegocioCertificados();
        return dt;
    }

    /// <summary>
    /// Lista todos los diferentes nombres de las pagadurías
    /// </summary>
    /// <returns>Tabla con todos los diferentes nombres de las pagadurías</returns>
    public static DataTable ListarNombrePagadurias()
    {
        DataTable dt = new DataTable();
        dt = DAOReporte.sp_ListarNombrePagadurias();
        return dt;
    }

    /// <summary>
    /// Genera la información de Relación Recibos Expedidos
    /// </summary>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicio">Rango inicial de la fecha del recibo</param>
    /// <param name="fechaFin">Rango final de la fecha del recibo</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarRelacionRecibosExpedidos(string idDepartamentos, string idCompanias, string idProductos, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarRelacionRecibosExpedidos(idDepartamentos, idCompanias, idProductos, fechaInicio, fechaFin);
        return dt;
    }

    /// <summary>
    /// Genera la información de Recibos Costa para Liquidación de Comisiones
    /// </summary>
    /// <param name="fechaInicio">Rango inicial de la fecha del recibo</param>
    /// <param name="fechaFin">Rango final de la fecha del recibo</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarRecibosCostaLiquidacionComisiones(DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarRecibosCostaLiquidacionComisiones(fechaInicio, fechaFin);
        return dt;
    }

    /// <summary>
    /// Genera la información de Reporte clientes productos
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicio">Rango inicial de la fecha de la vigencia</param>
    /// <param name="fechaFin">Rango final de la fecha de la vigencia</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarReporteClientesProductos(string idCompanias, string idProductos, string idCedulas, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarReporteClientesProductos(idCompanias, idProductos, idCedulas, fechaInicio, fechaFin);
        return dt;
    }

    /// <summary>
    /// Genera la información de Solicitud consolidado todos
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicio">Rango inicial de la fecha de la vigencia</param>
    /// <param name="fechaFin">Rango final de la fecha de la vigencia</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarSolicitudConsolidadoTodos(string idCompanias, string idProductos, string idEstadoNegocios, string idCedulas, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarSolicitudConsolidadoTodos(idCompanias, idProductos, idEstadoNegocios, idCedulas, fechaInicio, fechaFin);
        return dt;
    }

    /// <summary>
    /// Genera la información de Reporte Datos Celular Retiros
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioRetiro">Rango inicial de la fecha de retiro</param>
    /// <param name="fechaFinRetiro">Rango final de la fecha de retiro</param>
    /// <param name="fechaInicioVigencia">Rango inicial de la fecha de la vigencia</param>
    /// <param name="fechaFinVigencia">Rango final de la fecha de la vigencia</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarReporteDatosCelularRetiros(string idCompanias, string idProductos, string idEstadoNegocios, DateTime? fechaInicioRetiro, DateTime? fechaFinRetiro, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarReporteDatosCelularRetiros(idCompanias, idProductos, idEstadoNegocios, fechaInicioRetiro, fechaFinRetiro, fechaInicioVigencia, fechaFinVigencia);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Hijos Mayores de Edad
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idLocalidades">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformeHijosMayoresEdad(string idCompanias, string idProductos, string idLocalidades, string idEstadoNegocios)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformeHijosMayoresEdad(idCompanias, idProductos, idLocalidades, idEstadoNegocios);
        return dt;
    }

    /// <summary>
    /// Genera la información de Pagadurias
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarPagadurias(string idCompanias, string idProductos)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarPagadurias(idCompanias, idProductos);
        return dt;
    }

    /// <summary>
    /// Genera la información de Cruce de Facturación Liberty
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarCruceFacturacionLiberty(string idCompanias, string idProductos, string idEstadoNegocios)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarCruceFacturacionLiberty(idCompanias, idProductos, idEstadoNegocios);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Producción y Retiros
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idPagadurias">Nombres de las pagadurías para filtrar separados por coma (ejemplo: ABARROTES GIRALDO,ABC COMPUTADORES). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="anoInicioProduccion">Rango inicial del año de producción del certificado</param>
    /// <param name="anoFinProduccion">Rango final del año de producción del certificado</param>
    /// <param name="fechaInicioVigenciaRetiroPrincipal">Rango inicial de la fecha de vigencia de retiro del principal</param>
    /// <param name="fechaFinVigenciaRetiroPrincipal">Rango final de la fecha de vigencia de retiro del principal</param>
    /// <param name="fechaInicioVigenciaRetiroConyuge">Rango inicial de la fecha de vigencia de retiro del cónyuge</param>
    /// <param name="fechaFinVigenciaRetiroConyuge">Rango final de la fecha de vigencia de retiro del cónyuge</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarInformeProduccionYRetiros(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, long? anoInicioProduccion, long? anoFinProduccion,
        DateTime? fechaInicioVigenciaRetiroPrincipal, DateTime? fechaFinVigenciaRetiroPrincipal, DateTime? fechaInicioVigenciaRetiroConyuge, DateTime? fechaFinVigenciaRetiroConyuge)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformeProduccionYRetiros(idCompanias, idProductos, idPagadurias, idEstadoNegocios, anoInicioProduccion, anoFinProduccion,
        fechaInicioVigenciaRetiroPrincipal, fechaFinVigenciaRetiroPrincipal, fechaInicioVigenciaRetiroConyuge, fechaFinVigenciaRetiroConyuge);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Asegurados con Extraprima Previsora
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idPagadurias">Nombres de las pagadurías para filtrar separados por coma (ejemplo: ABARROTES GIRALDO,ABC COMPUTADORES). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="anoInicioProduccion">Rango inicial del año de producción del certificado</param>
    /// <param name="anoFinProduccion">Rango final del año de producción del certificado</param>
    /// <param name="fechaInicioVigenciaRetiroPrincipal">Rango inicial de la fecha de vigencia de retiro del principal</param>
    /// <param name="fechaFinVigenciaRetiroPrincipal">Rango final de la fecha de vigencia de retiro del principal</param>
    /// <param name="fechaInicioVigenciaRetiroConyuge">Rango inicial de la fecha de vigencia de retiro del cónyuge</param>
    /// <param name="fechaFinVigenciaRetiroConyuge">Rango final de la fecha de vigencia de retiro del cónyuge</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformeAseguradosExtraprimaPrevisora(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, long? anoInicioProduccion, long? anoFinProduccion,
        DateTime? fechaInicioVigenciaRetiroPrincipal, DateTime? fechaFinVigenciaRetiroPrincipal, DateTime? fechaInicioVigenciaRetiroConyuge, DateTime? fechaFinVigenciaRetiroConyuge)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformeAseguradosExtraprimaPrevisora(idCompanias, idProductos, idPagadurias, idEstadoNegocios, anoInicioProduccion, anoFinProduccion,
        fechaInicioVigenciaRetiroPrincipal, fechaFinVigenciaRetiroPrincipal, fechaInicioVigenciaRetiroConyuge, fechaFinVigenciaRetiroConyuge);
        return dt;
    }

    /// <summary>
    /// Genera la información de Ingresos MAFRE – Cámara de comercio
    /// </summary>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarIngresosMAFRECamaraComercio(DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion, string idCedulas)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarIngresosMAFRECamaraComercio(fechaInicioProduccion, fechaFinProduccion, idCedulas);
        return dt;
    }

    /// <summary>
    /// Genera la información de Ingresos MAFRE – Educadores
    /// </summary>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarIngresosMAFREEducadores(DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion, string idCedulas)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarIngresosMAFREEducadores(fechaInicioProduccion, fechaFinProduccion, idCedulas);
        return dt;
    }

    /// <summary>
    /// Genera la información de Información Concurso Bolívar
    /// </summary>
    /// <param name="fechaInicio">Rango inicial de la fecha de expedición</param>
    /// <param name="fechaFin">Rango final de la fecha de expedición</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformacionConcursoBolivar(DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformacionConcursoBolivar(fechaInicio, fechaFin);
        return dt;
    }

    /// <summary>
    /// Lista todos los asesores del sistema
    /// </summary>
    /// <returns>Tabla con todos los asesores</returns>
    public static DataTable ConsultarAsesorDdl()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarAsesorDdl();
        return dt;
    }

    /// <summary>
    /// Lista todas las ciudades del sistema
    /// </summary>
    /// <returns>Tabla con todas las ciudades</returns>
    public static DataTable ConsultarCiudadDdl()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarCiudadDdl();
        return dt;
    }

    /// <summary>
    /// Lista todos los diferentes nombres de los convenios
    /// </summary>
    /// <returns>Tabla con todos los diferentes nombres de los convenios</returns>
    public static DataTable ListarNombreConvenios()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ListarNombreConvenios();
        return dt;
    }

    /// <summary>
    /// Lista todas las agencias del sistema
    /// </summary>
    /// <returns>Tabla con todas las agencias</returns>
    public static DataTable ConsultarAgenciaDdl()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarAgenciaDdl();
        return dt;
    }

    /// <summary>
    /// Genera la información de Reporte General
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idPagadurias">Nombres de las pagadurías para filtrar separados por coma (ejemplo: ABARROTES GIRALDO,ABC COMPUTADORES). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idLocalidades">Ids de localidades para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idAgencias">Ids de agencias para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idConvenios">Nombres de los convenios para filtrar separados por coma (ejemplo: 24 HORAS,A.V.S COLOMBIA). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idAsesores">Ids de asesores para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCertificadoRecuperados">Opciones de certificado recuperado para filtrar separados por coma (ejemplo: 0,1). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarReporteGeneral(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, string idLocalidades,
        string idAgencias, string idConvenios, string idAsesores, string idCertificadoRecuperados, DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarReporteGeneral(idCompanias, idProductos, idPagadurias, idEstadoNegocios, idLocalidades,
            idAgencias, idConvenios, idAsesores, idCertificadoRecuperados, fechaInicioProduccion, fechaFinProduccion);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe de Pólizas de Plus con Cartera por Producto y Estado de Negocio
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioVigencia">Rango inicial de la fecha de vigencia</param>
    /// <param name="fechaFinVigencia">Rango final de la fecha de vigencia</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformePolizasPlusCarteraXProductoEstadoNegocio(string idCompanias, string idProductos, string idEstadoNegocios, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformePolizasPlusCarteraXProductoEstadoNegocio(idCompanias, idProductos, idEstadoNegocios, fechaInicioVigencia, fechaFinVigencia);
        return dt;
    }

    /// <summary>
    /// Genera la información de Reporte General de Pagos
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idPagadurias">Nombres de las pagadurías para filtrar separados por coma (ejemplo: ABARROTES GIRALDO,ABC COMPUTADORES). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idLocalidades">Ids de localidades para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idConvenios">Nombres de los convenios para filtrar separados por coma (ejemplo: 24 HORAS,A.V.S COLOMBIA). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCiudades">Ids de ciudades para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioVigencia">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinVigencia">Rango final de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarReporteGeneralPagos(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, string idLocalidades,
        string idConvenios, string idDepartamentos, string idCiudades, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarReporteGeneralPagos(idCompanias, idProductos, idPagadurias, idEstadoNegocios, idLocalidades,
            idConvenios, idDepartamentos, idCiudades, fechaInicioVigencia, fechaFinVigencia);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Producción Nueva
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idCiudades">Ids de ciudades para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioVigencia">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinVigencia">Rango final de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformeProduccionNueva(string idCompanias, string idProductos, string idEstadoNegocios, 
        string idDepartamentos, string idCiudades, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformeProduccionNueva(idCompanias, idProductos, idEstadoNegocios,
            idDepartamentos, idCiudades, fechaInicioVigencia, fechaFinVigencia);
        return dt;
    }

    /// <summary>
    /// Genera la información de Estadísticas de Producción de Compañías
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idAgencias">Ids de agencias para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="mesProduccion">Mes de producción del certificado</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarEstadisticasProduccionCompañias(string idCompanias, string idProductos, string idAgencias, DateTime? mesProduccion)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarEstadisticasProduccionCompañias(idCompanias, idProductos, idAgencias, mesProduccion);
        return dt;
    }

    /// <summary>
    /// Genera la información de Estadísticas de Producción Seguros Bolívar
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarEstadisticasProduccionSegurosBolivar(string idCompanias, DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarEstadisticasProduccionSegurosBolivar(idCompanias, fechaInicioProduccion, fechaFinProduccion);
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Ejecutivo
    /// </summary>
    /// <param name="anoInicioProduccion">Rango inicial de la año de la fecha de producción</param>
    /// <param name="anoFinProduccion">Rango final del año de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable GenerarInformeEjecutivo(int? anoInicioProduccion, int? anoFinProduccion)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_GenerarInformeEjecutivo(anoInicioProduccion, anoFinProduccion);
        return dt;
    }

    public static DataTable ListarConveniosLocalidad(string idDepartamento)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarConvenios(idDepartamento);
        return dt;
    }

    public static DataTable ListarPagadurias(string idDepartamento)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarPagadurias(idDepartamento);
        return dt;
    }

    public static DataTable ListarConveniosImprimir(string idConvenio)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOReporte.sp_ConsultarConveniosImprimir(idConvenio);
        return dt;
    }
}