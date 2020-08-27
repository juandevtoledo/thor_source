using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los tipos de devoluciones
/// </summary>
public class AdministrarTipoDevolucion
{
    /// <summary>
    /// Lista todos los tipos de devoluciones del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de devoluciones</returns>
    public static DataTable ListarTiposDevoluciones()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDevolucion.sp_ListarNewTiposDevoluciones();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de devolución
    /// </summary>
    /// <param name="tipoDevolucionNombre">Nombre tipo devolución</param>
    /// <param name="tipoDevolucionRecuperable">Tipo devolución es recuperable</param>
    public static void InsertarTipoDevolucion(string tipoDevolucionNombre, int? tipoDevolucionRecuperable)
    {
        DAOAdministrarTipoDevolucion.sp_InsertarNewTipoDevolucion(tipoDevolucionNombre, tipoDevolucionRecuperable);
    }

    /// <summary>
    /// Consulta la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de devolución</returns>
    public static DataTable ConsultarTipoDevolucion(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDevolucion.sp_ConsultarNewTipoDevolucion(tipoDevolucionIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de devolución por su ID para ser modificado
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de devolución para ser modificado</returns>
    public static DataTable ConsultarTipoDevolucionModificar(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDevolucion.sp_ConsultarNewTipoDevolucionModificar(tipoDevolucionIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <param name="tipoDevolucionNombre">Nuevo nombre tipo devolución</param>
    /// <param name="tipoDevolucionRecuperable">Nuevo tipo devolución es recuperable</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarTipoDevolucion(long tipoDevolucionIdentificador, string tipoDevolucionNombre, int? tipoDevolucionRecuperable)
    {
        DAOAdministrarTipoDevolucion.sp_ActualizarNewTipoDevolucion(tipoDevolucionIdentificador, tipoDevolucionNombre, tipoDevolucionRecuperable);
    }

    /// <summary>
    /// Elimina la información de un tipo de devolución por su ID
    /// </summary>
    /// <param name="tipoDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarTipoDevolucion(long tipoDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDevolucion.sp_EliminarNewTipoDevolucion(tipoDevolucionIdentificador);
        return dt;
    }
}
