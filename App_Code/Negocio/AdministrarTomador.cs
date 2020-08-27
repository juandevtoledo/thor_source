using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los tomadores
/// </summary>
public class AdministrarTomador
{
    /// <summary>
    /// Lista todos los tomadores del sistema
    /// </summary>
    /// <returns>Tabla con todos los tomadores</returns>
    public static DataTable ListarTomadores()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTomador.sp_ListarNewTomadores();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un tomador
    /// </summary>
    /// <param name="tomadorIdentificacion">Identificación tomador</param>
    /// <param name="tomadorNombre">Nombre tomador</param>
    /// <param name="tomadorDireccion">Dirección tomador</param>
    /// <param name="tomadorTelefono">Teléfono tomador</param>
    /// <param name="tomadorRepresentanteLegal">Representante legal</param>
    public static void InsertarTomador(long tomadorIdentificacion, string tomadorNombre, string tomadorDireccion, string tomadorTelefono, string tomadorRepresentanteLegal)
    {
        DAOAdministrarTomador.sp_InsertarNewTomador(tomadorIdentificacion, tomadorNombre, tomadorDireccion, tomadorTelefono, tomadorRepresentanteLegal);
    }

    /// <summary>
    /// Consulta la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tomador</returns>
    public static DataTable ConsultarTomador(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTomador.sp_ConsultarNewTomador(tomadorIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un tomador por su ID para ser modificado
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tomador para ser modificado</returns>
    public static DataTable ConsultarTomadorModificar(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTomador.sp_ConsultarNewTomadorModificar(tomadorIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <param name="tomadorIdentificacion">Nuevo identificación tomador</param>
    /// <param name="tomadorNombre">Nuevo nombre tomador</param>
    /// <param name="tomadorDireccion">Nuevo dirección tomador</param>
    /// <param name="tomadorTelefono">Nuevo teléfono tomador</param>
    /// <param name="tomadorRepresentanteLegal">Nuevo representante legal</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarTomador(long tomadorIdentificador, long tomadorIdentificacion, string tomadorNombre, string tomadorDireccion, string tomadorTelefono, string tomadorRepresentanteLegal)
    {
        DAOAdministrarTomador.sp_ActualizarNewTomador(tomadorIdentificador, tomadorIdentificacion, tomadorNombre, tomadorDireccion, tomadorTelefono, tomadorRepresentanteLegal);
    }

    /// <summary>
    /// Elimina la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarTomador(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTomador.sp_EliminarNewTomador(tomadorIdentificador);
        return dt;
    }
}
