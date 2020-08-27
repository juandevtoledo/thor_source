using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para las causales de devoluciones
/// </summary>
public class AdministrarCausalDevolucion
{
    /// <summary>
    /// Lista todas las causales de devolución del sistema
    /// </summary>
    /// <returns>Tabla con todas las causales de devolución</returns>
    public static DataTable ListarCausalesDevoluciones()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCausalDevolucion.sp_ListarNewCausalesDevoluciones();
        return dt;
    }

    /// <summary>
    /// Inserta la información de una causal de devolución
    /// </summary>
    /// <param name="causalDevolucionNombre">Nombre causal devolución</param>
    /// <param name="tipoDevolucionIdentificador">Tipo causal devolución</param>
    public static void InsertarCausalDevolucion(string causalDevolucionNombre, long? tipoDevolucionIdentificador)
    {
        DAOAdministrarCausalDevolucion.sp_InsertarNewCausalDevolucion(causalDevolucionNombre, tipoDevolucionIdentificador);
    }

    /// <summary>
    /// Consulta la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de causal de devolución</returns>
    public static DataTable ConsultarCausalDevolucion(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCausalDevolucion.sp_ConsultarNewCausalDevolucion(causalDevolucionIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una causal de devolución por su ID para ser modificado
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de causal de devolución para ser modificado</returns>
    public static DataTable ConsultarCausalDevolucionModificar(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCausalDevolucion.sp_ConsultarNewCausalDevolucionModificar(causalDevolucionIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <param name="causalDevolucionNombre">Nuevo nombre causal devolución</param>
    /// <param name="tipoDevolucionIdentificador">Nuevo tipo causal devolución</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarCausalDevolucion(long causalDevolucionIdentificador, string causalDevolucionNombre, long? tipoDevolucionIdentificador)
    {
        DAOAdministrarCausalDevolucion.sp_ActualizarNewCausalDevolucion(causalDevolucionIdentificador, causalDevolucionNombre, tipoDevolucionIdentificador);
    }

    /// <summary>
    /// Elimina la información de una causal de devolución por su ID
    /// </summary>
    /// <param name="causalDevolucionIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarCausalDevolucion(long causalDevolucionIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCausalDevolucion.sp_EliminarNewCausalDevolucion(causalDevolucionIdentificador);
        return dt;
    }
}
