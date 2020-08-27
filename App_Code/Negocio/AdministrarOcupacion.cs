using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para las ocupaciones
/// </summary>
public class AdministrarOcupacion
{
    /// <summary>
    /// Lista todas las ocupaciones del sistema
    /// </summary>
    /// <returns>Tabla con todas las ocupaciones</returns>
    public static DataTable ListarOcupaciones()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarOcupacion.sp_ListarOcupaciones();
        return dt;
    }

    /// <summary>
    /// Inserta la información de una ocupación
    /// </summary>
    /// <param name="ocupacionNombre">Nombre de ocupación</param>
    public static void InsertarOcupacion(string ocupacionNombre)
    {
        DAOAdministrarOcupacion.sp_InsertarOcupacion(ocupacionNombre);
    }

    /// <summary>
    /// Consulta la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de ocupación</returns>
    public static DataTable ConsultarOcupacion(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarOcupacion.sp_ConsultarOcupacion(ocupacionIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una ocupación por su ID para ser modificado
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de ocupación para ser modificado</returns>
    public static DataTable ConsultarOcupacionModificar(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarOcupacion.sp_ConsultarOcupacionModificar(ocupacionIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <param name="ocupacionNombre">Nuevo nombre de ocupación</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarOcupacion(long ocupacionIdentificador, string ocupacionNombre)
    {
        DAOAdministrarOcupacion.sp_ActualizarOcupacion(ocupacionIdentificador, ocupacionNombre);
    }

    /// <summary>
    /// Elimina la información de una ocupación por su ID
    /// </summary>
    /// <param name="ocupacionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarOcupacion(long ocupacionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarOcupacion.sp_EliminarOcupacion(ocupacionIdentificador);
        return dt;
    }

    public static DataTable BuscarOcupacion(int id, string nombre)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarOcupacion.sp_BuscarOcupacion(id, nombre);
        return dt;
    }
}
