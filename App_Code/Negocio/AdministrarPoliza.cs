using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para las polizas
/// </summary>
public class AdministrarPoliza
{
    /// <summary>
    /// Lista todas las polizas del sistema
    /// </summary>
    /// <returns>Tabla con todas las polizas</returns>
    public static DataTable ListarPolizas()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPoliza.sp_ListarNewPolizas();
        return dt;
    }

    /// <summary>
    /// Inserta la información de una poliza
    /// </summary>
    /// <param name="polizaNumero"></param>
    /// <param name="ProductoIdentificador">Producto</param>
    /// <param name="TomadorIdentificador">Tomador</param>
    /// <param name="PolizaTipo"></param>
    public static void InsertarPoliza(long polizaNumero, long? ProductoIdentificador, long? TomadorIdentificador, long? PolizaTipo)
    {
        DAOAdministrarPoliza.sp_InsertarNewPoliza(polizaNumero, ProductoIdentificador, TomadorIdentificador, PolizaTipo);
    }

    /// <summary>
    /// Consulta la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza</returns>
    public static DataTable ConsultarPoliza(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPoliza.sp_ConsultarNewPoliza(polizaIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una poliza por su ID para ser modificado
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza para ser modificado</returns>
    public static DataTable ConsultarPolizaModificar(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPoliza.sp_ConsultarNewPolizaModificar(polizaIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <param name="polizaNumero">Nuevo </param>
    /// <param name="ProductoIdentificador">Nuevo producto</param>
    /// <param name="TomadorIdentificador">Nuevo tomador</param>
    /// <param name="PolizaTipo">Nuevo </param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarPoliza(long polizaIdentificador, long polizaNumero, long? ProductoIdentificador, long? TomadorIdentificador, long? PolizaTipo)
    {
        DAOAdministrarPoliza.sp_ActualizarNewPoliza(polizaIdentificador, polizaNumero, ProductoIdentificador, TomadorIdentificador, PolizaTipo);
    }

    /// <summary>
    /// Elimina la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarPoliza(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPoliza.sp_EliminarNewPoliza(polizaIdentificador);
        return dt;
    }
}
