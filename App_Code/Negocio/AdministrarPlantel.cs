using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los planteles
/// </summary>
public class AdministrarPlantel
{
    /// <summary>
    /// Lista todos los planteles del sistema
    /// </summary>
    /// <returns>Tabla con todos los planteles</returns>
    public static DataTable ListarPlanteles()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPlantel.sp_ListarPlanteles();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un plantel
    /// </summary>
    /// <param name="plantelNombre">Plantel</param>
    /// <param name="departamentoIdentificador">Departamento</param>
    public static void InsertarPlantel(string plantelNombre, long departamentoIdentificador)
    {
        DAOAdministrarPlantel.sp_InsertarPlantel(plantelNombre, departamentoIdentificador);
    }

    /// <summary>
    /// Consulta la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de plantel</returns>
    public static DataTable ConsultarPlantel(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPlantel.sp_ConsultarPlantel(plantelidentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un plantel por su ID para ser modificado
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de plantel para ser modificado</returns>
    public static DataTable ConsultarPlantelModificar(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPlantel.sp_ConsultarPlantelModificar(plantelidentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <param name="plantelNombre">Nuevo plantel</param>
    /// <param name="departamentoIdentificador">Nuevo departamento</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarPlantel(long plantelidentificador, string plantelNombre, long departamentoIdentificador)
    {
        DAOAdministrarPlantel.sp_ActualizarPlantel(plantelidentificador, plantelNombre, departamentoIdentificador);
    }

    /// <summary>
    /// Elimina la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarPlantel(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPlantel.sp_EliminarPlantel(plantelidentificador);
        return dt;
    }
}
