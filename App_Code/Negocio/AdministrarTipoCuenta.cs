using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los tipos de cuentas
/// </summary>
public class AdministrarTipoCuenta
{
    /// <summary>
    /// Lista todos los tipos de cuentas del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de cuentas</returns>
    public static DataTable ListarTiposCuentas()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuenta.sp_ListarNewTiposCuentas();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de cuenta
    /// </summary>
    /// <param name="tipoCuentaNombre">Nombre de tipo de cuenta</param>
    public static void InsertarTipoCuenta(string tipoCuentaNombre)
    {
        DAOAdministrarTipoCuenta.sp_InsertarNewTipoCuenta(tipoCuentaNombre);
    }

    /// <summary>
    /// Consulta la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de cuenta</returns>
    public static DataTable ConsultarTipoCuenta(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuenta.sp_ConsultarNewTipoCuenta(tipoCuentaIdentificacion);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de cuenta por su ID para ser modificado
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de cuenta para ser modificado</returns>
    public static DataTable ConsultarTipoCuentaModificar(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuenta.sp_ConsultarNewTipoCuentaModificar(tipoCuentaIdentificacion);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <param name="tipoCuentaNombre">Nuevo nombre de tipo de cuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarTipoCuenta(long tipoCuentaIdentificacion, string tipoCuentaNombre)
    {
        DAOAdministrarTipoCuenta.sp_ActualizarNewTipoCuenta(tipoCuentaIdentificacion, tipoCuentaNombre);
    }

    /// <summary>
    /// Elimina la información de un tipo de cuenta por su ID
    /// </summary>
    /// <param name="tipoCuentaIdentificacion">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarTipoCuenta(long tipoCuentaIdentificacion)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuenta.sp_EliminarNewTipoCuenta(tipoCuentaIdentificacion);
        return dt;
    }
}