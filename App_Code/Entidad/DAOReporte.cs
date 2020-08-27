using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOReporte
/// </summary>
public class DAOReporte
{
    /// <summary>
    /// Lista todas las compañías del sistema
    /// </summary>
    /// <returns>Tabla con todas las compañías</returns>
    public static DataTable sp_ListarCompanias()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCompaniasGenerales", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todos los departamentos del sistema
    /// </summary>
    /// <returns>Tabla con todos los departamentos</returns>
    public static DataTable sp_MostrarDepartamento()
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_MostrarDepartamento", FrameworkEntidades.cnx);

        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }

    /// <summary>
    /// Lista todas las ciudades que coincidan con los Ids de departamentos enviados
    /// </summary>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las ciudades que coincidan con los Ids de departmanetos enviados</returns>
    public static DataTable sp_ListarCiudadesPorFiltros(string idDepartamentos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCiudadesPorFiltros", FrameworkEntidades.cnx);
        if (idDepartamentos != null)
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", idDepartamentos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todas las agencias que coincidan con los filtros enviados
    /// </summary>
    /// <param name="idDepartamentos">Ids de departamentos para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las agencias que coincidan con los Ids de departmanetos enviados</returns>
    public static DataTable sp_ListarAgenciasPorFiltros(string idDepartamentos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarAgenciasPorFiltros", FrameworkEntidades.cnx);
        if (idDepartamentos != null)
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", idDepartamentos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todos los productos que coincidan con los Ids enviados
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los productos que coincidan con los Ids enviados</returns>
    public static DataTable sp_ListarProductosPorFiltros(string idCompanias)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarProductosPorFiltros", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@Ids", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@Ids", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todas las pagadurías que coincidan con los filtros enviados
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con las pagadurías que coincidan con los filtros enviados</returns>
    public static DataTable sp_ListarPagaduriasPorFiltros(string idCompanias, string idProductos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarPagaduriasPorFiltros", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todos los estados de negocio de los certificados
    /// </summary>
    /// <returns>Tabla con todos los estados de negocio de los certificados</returns>
    public static DataTable sp_ListarEstadosNegocioCertificados()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarEstadosNegocioCertificados", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todos los diferentes nombres de las pagadurías
    /// </summary>
    /// <returns>Tabla con todos los diferentes nombres de las pagadurías</returns>
    public static DataTable sp_ListarNombrePagadurias()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNombrePagadurias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Lista todos los asesores del sistema
    /// </summary>
    /// <returns>Tabla con todos los asesores</returns>
    public static DataTable sp_ConsultarAsesorDdl()
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_ConsultarAsesorDdl", FrameworkEntidades.cnx);

        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Lista todas las ciudades del sistema
    /// </summary>
    /// <returns>Tabla con todas las ciudades</returns>
    public static DataTable sp_ConsultarCiudadDdl()
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_ConsultarCiudadDdl", FrameworkEntidades.cnx);

        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Lista todas las agencias del sistema
    /// </summary>
    /// <returns>Tabla con todas las agencias</returns>
    public static DataTable sp_ConsultarAgenciaDdl()
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

    /// <summary>
    /// Lista todos los diferentes nombres de los convenios
    /// </summary>
    /// <returns>Tabla con todos los diferentes nombres de los convenios</returns>
    public static DataTable sp_ListarNombreConvenios()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNombreConvenios", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarRelacionRecibosExpedidos(string idDepartamentos, string idCompanias, string idProductos, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarRelacionRecibosExpedidos", FrameworkEntidades.cnx);
        if (idDepartamentos != null)
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", idDepartamentos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", "ALL"));
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (fechaInicio != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", DBNull.Value));
        if (fechaFin != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFin", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Recibos Costa para Liquidación de Comisiones
    /// </summary>
    /// <param name="fechaInicio">Rango inicial de la fecha del recibo</param>
    /// <param name="fechaFin">Rango final de la fecha del recibo</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarRecibosCostaLiquidacionComisiones(DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarRecibosCostaLiquidacionComisiones", FrameworkEntidades.cnx);
        if (fechaInicio != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", DBNull.Value));
        if (fechaFin != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFin", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarReporteClientesProductos(string idCompanias, string idProductos, string idCedulas, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarReporteClientesProductos", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idCedulas != null)
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", idCedulas));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", "ALL"));
        if (fechaInicio != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", DBNull.Value));
        if (fechaFin != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFin", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarSolicitudConsolidadoTodos(string idCompanias, string idProductos, string idEstadoNegocios, string idCedulas, DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarSolicitudConsolidadoTodos", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (idCedulas != null)
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", idCedulas));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", "ALL"));
        if (fechaInicio != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", DBNull.Value));
        if (fechaFin != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFin", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarReporteDatosCelularRetiros(string idCompanias, string idProductos, string idEstadoNegocios, DateTime? fechaInicioRetiro, DateTime? fechaFinRetiro, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarReporteDatosCelularRetiros", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (fechaInicioRetiro != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioRetiro", fechaInicioRetiro));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioRetiro", DBNull.Value));
        if (fechaFinRetiro != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinRetiro", fechaFinRetiro));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinRetiro", DBNull.Value));
        if (fechaInicioVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", fechaInicioVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", DBNull.Value));
        if (fechaFinVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", fechaFinVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarInformeHijosMayoresEdad(string idCompanias, string idProductos, string idLocalidades, string idEstadoNegocios)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformeHijosMayoresEdad", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idLocalidades != null)
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", idLocalidades));
        else
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Pagadurias
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarPagadurias(string idCompanias, string idProductos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarPagadurias", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Cruce de Facturación Liberty
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idProductos">Nombres de productos para filtrar separados por coma (ejemplo: EDUCADORES,EMPRESARIOS). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="idEstadoNegocios">Nombres de los estados de negocio para filtrar separados por coma (ejemplo: VIGENTE,OTRO). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarCruceFacturacionLiberty(string idCompanias, string idProductos, string idEstadoNegocios)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarCruceFacturacionLiberty", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformeProduccionYRetiros", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idPagadurias != null)
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", idPagadurias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (anoInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", anoInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", DBNull.Value));
        if (anoFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", anoFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", DBNull.Value));
        if (fechaInicioVigenciaRetiroPrincipal != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroPrincipal", fechaInicioVigenciaRetiroPrincipal));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroPrincipal", DBNull.Value));
        if (fechaFinVigenciaRetiroPrincipal != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroPrincipal", fechaFinVigenciaRetiroPrincipal));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroPrincipal", DBNull.Value));
        if (fechaInicioVigenciaRetiroConyuge != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroConyuge", fechaInicioVigenciaRetiroConyuge));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroConyuge", DBNull.Value));
        if (fechaFinVigenciaRetiroConyuge != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroConyuge", fechaFinVigenciaRetiroConyuge));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroConyuge", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarInformeAseguradosExtraprimaPrevisora(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, long? anoInicioProduccion, long? anoFinProduccion,
        DateTime? fechaInicioVigenciaRetiroPrincipal, DateTime? fechaFinVigenciaRetiroPrincipal, DateTime? fechaInicioVigenciaRetiroConyuge, DateTime? fechaFinVigenciaRetiroConyuge)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformeAseguradosExtraprimaPrevisora", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idPagadurias != null)
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", idPagadurias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (anoInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", anoInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", DBNull.Value));
        if (anoFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", anoFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", DBNull.Value));
        if (fechaInicioVigenciaRetiroPrincipal != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroPrincipal", fechaInicioVigenciaRetiroPrincipal));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroPrincipal", DBNull.Value));
        if (fechaFinVigenciaRetiroPrincipal != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroPrincipal", fechaFinVigenciaRetiroPrincipal));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroPrincipal", DBNull.Value));
        if (fechaInicioVigenciaRetiroConyuge != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroConyuge", fechaInicioVigenciaRetiroConyuge));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigenciaRetiroConyuge", DBNull.Value));
        if (fechaFinVigenciaRetiroConyuge != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroConyuge", fechaFinVigenciaRetiroConyuge));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigenciaRetiroConyuge", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Ingresos MAFRE – Cámara de comercio
    /// </summary>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarIngresosMAFRECamaraComercio(DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion, string idCedulas)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarIngresosMAFRECamaraComercio", FrameworkEntidades.cnx);
        if (fechaInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", fechaInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", DBNull.Value));
        if (fechaFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", fechaFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", DBNull.Value));
        if (idCedulas != null)
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", idCedulas));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Ingresos MAFRE – Educadores
    /// </summary>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <param name="idCedulas">Números de cédula para filtrar separados por coma (ejemplo: 30333123,1053771465). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarIngresosMAFREEducadores(DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion, string idCedulas)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarIngresosMAFREEducadores", FrameworkEntidades.cnx);
        if (fechaInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", fechaInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", DBNull.Value));
        if (fechaFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", fechaFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", DBNull.Value));
        if (idCedulas != null)
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", idCedulas));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCedulas", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Información Concurso Bolívar
    /// </summary>
    /// <param name="fechaInicio">Rango inicial de la fecha de expedición</param>
    /// <param name="fechaFin">Rango final de la fecha de expedición</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarInformacionConcursoBolivar(DateTime? fechaInicio, DateTime? fechaFin)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformacionConcursoBolivar", FrameworkEntidades.cnx);
        if (fechaInicio != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", DBNull.Value));
        if (fechaFin != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFin", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarReporteGeneral(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, string idLocalidades,
        string idAgencias, string idConvenios, string idAsesores, string idCertificadoRecuperados, DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarReporteGeneral", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idPagadurias != null)
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", idPagadurias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (idLocalidades != null)
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", idLocalidades));
        else
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", "ALL"));
        if (idAgencias != null)
            cmd.Parameters.Add(new SqlParameter("@IdAgencias", idAgencias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdAgencias", "ALL"));
        if (idConvenios != null)
            cmd.Parameters.Add(new SqlParameter("@IdConvenios", idConvenios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdConvenios", "ALL"));
        if (idAsesores != null)
            cmd.Parameters.Add(new SqlParameter("@IdAsesores", idAsesores));
        else
            cmd.Parameters.Add(new SqlParameter("@IdAsesores", "ALL"));
        if (idCertificadoRecuperados != null)
            cmd.Parameters.Add(new SqlParameter("@IdCertificadoRecuperados", idCertificadoRecuperados));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCertificadoRecuperados", "ALL"));
        if (fechaInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", fechaInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", DBNull.Value));
        if (fechaFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", fechaFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarInformePolizasPlusCarteraXProductoEstadoNegocio(string idCompanias, string idProductos, string idEstadoNegocios, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformePolizasPlusCarteraXProductoEstadoNegocio", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (fechaInicioVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", fechaInicioVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", DBNull.Value));
        if (fechaFinVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", fechaFinVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarReporteGeneralPagos(string idCompanias, string idProductos, string idPagadurias, string idEstadoNegocios, string idLocalidades,
        string idConvenios, string idDepartamentos, string idCiudades, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarReporteGeneralPagos", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idPagadurias != null)
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", idPagadurias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdPagadurias", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (idLocalidades != null)
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", idLocalidades));
        else
            cmd.Parameters.Add(new SqlParameter("@IdLocalidades", "ALL"));
        if (idConvenios != null)
            cmd.Parameters.Add(new SqlParameter("@IdConvenios", idConvenios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdConvenios", "ALL"));
        if (idDepartamentos != null)
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentosPagaduria", idDepartamentos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentosPagaduria", "ALL"));
        if (idCiudades != null)
            cmd.Parameters.Add(new SqlParameter("@IdCiudadesPagaduria", idCiudades));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCiudadesPagaduria", "ALL"));
        if (fechaInicioVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", fechaInicioVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", DBNull.Value));
        if (fechaFinVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", fechaFinVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarInformeProduccionNueva(string idCompanias, string idProductos, string idEstadoNegocios, 
        string idDepartamentos, string idCiudades, DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformeProduccionNueva", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idEstadoNegocios != null)
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", idEstadoNegocios));
        else
            cmd.Parameters.Add(new SqlParameter("@IdEstadoNegocios", "ALL"));
        if (idDepartamentos != null)
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", idDepartamentos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdDepartamentos", "ALL"));
        if (idCiudades != null)
            cmd.Parameters.Add(new SqlParameter("@IdCiudades", idCiudades));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCiudades", "ALL"));
        if (fechaInicioVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", fechaInicioVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioVigencia", DBNull.Value));
        if (fechaFinVigencia != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", fechaFinVigencia));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinVigencia", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
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
    public static DataTable sp_GenerarEstadisticasProduccionCompañias(string idCompanias, string idProductos, string idAgencias, DateTime? mesProduccion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarEstadisticasProduccionCompañias", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (idProductos != null)
            cmd.Parameters.Add(new SqlParameter("@IdProductos", idProductos));
        else
            cmd.Parameters.Add(new SqlParameter("@IdProductos", "ALL"));
        if (idAgencias != null)
            cmd.Parameters.Add(new SqlParameter("@IdAgencias", idAgencias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdAgencias", "ALL"));
        if (mesProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@MesProduccion", mesProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@MesProduccion", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Estadísticas de Producción Seguros Bolívar
    /// </summary>
    /// <param name="idCompanias">Ids de compañías para filtrar separados por coma (ejemplo: 1,2,4). Si dentro de la lista viene la opción ALL se obtendrán todos los registros</param>
    /// <param name="fechaInicioProduccion">Rango inicial de la fecha de producción</param>
    /// <param name="fechaFinProduccion">Rango final de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarEstadisticasProduccionSegurosBolivar(string idCompanias, DateTime? fechaInicioProduccion, DateTime? fechaFinProduccion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarEstadisticasProduccionSegurosBolivar", FrameworkEntidades.cnx);
        if (idCompanias != null)
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", idCompanias));
        else
            cmd.Parameters.Add(new SqlParameter("@IdCompanias", "ALL"));
        if (fechaInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", fechaInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaInicioProduccion", DBNull.Value));
        if (fechaFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", fechaFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@FechaFinProduccion", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    /// <summary>
    /// Genera la información de Informe Ejecutivo
    /// </summary>
    /// <param name="anoInicioProduccion">Rango inicial de la año de la fecha de producción</param>
    /// <param name="anoFinProduccion">Rango final del año de la fecha de producción</param>
    /// <returns>Tabla con los registros encontrados</returns>
    public static DataTable sp_GenerarInformeEjecutivo(int? anoInicioProduccion, int? anoFinProduccion)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_GenerarInformeEjecutivo", FrameworkEntidades.cnx);
        if (anoInicioProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", anoInicioProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoInicioProduccion", DBNull.Value));
        if (anoFinProduccion != null)
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", anoFinProduccion));
        else
            cmd.Parameters.Add(new SqlParameter("@AnoFinProduccion", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


    public static DataTable sp_ConsultarConvenios(string idDep)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("ConsultarConvenios", FrameworkEntidades.cnx);
        if (idDep != null)
            cmd.Parameters.Add(new SqlParameter("@Ids", idDep));
        else
            cmd.Parameters.Add(new SqlParameter("@Ids", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarPagadurias(string idDep)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("ConsultarPagadurias", FrameworkEntidades.cnx);
        if (idDep != null)
            cmd.Parameters.Add(new SqlParameter("@Ids", idDep));
        else
            cmd.Parameters.Add(new SqlParameter("@Ids", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarConveniosImprimir(string idConvenio)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarConveniosImprimir", FrameworkEntidades.cnx);
        if (idConvenio != null)
            cmd.Parameters.Add(new SqlParameter("@Ids", idConvenio));
        else
            cmd.Parameters.Add(new SqlParameter("@Ids", "ALL"));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }


}