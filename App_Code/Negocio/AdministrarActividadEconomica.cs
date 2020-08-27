using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarActividadEconomica
{
    public static DataTable ListarActividadesEconomicas()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarActividadEconomica.sp_ListarNewActividadesEconomicas();
        return dt;
    }
    public static void InsertarActividadEconomica(string nombreActividadEconomica)
    {

        DAOAdministrarActividadEconomica.sp_InsertarNewActividadEconomica(nombreActividadEconomica);
    }
    public static DataTable ConsultarActividadEconomica(int actividadEconomicaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarActividadEconomica.sp_ConsultarNewActividadEconomica(actividadEconomicaID);
        return dt;
    }
    public static DataTable ConsultarActividadEconomicaModificar(int actividadEconomicaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarActividadEconomica.sp_ConsultarNewActividadEconomicaModificar(actividadEconomicaID);
        return dt;
    }
    public static void ModificarActividadEconomica(int actividadEconomicaID, string nombreActividadEconomica)
    {
        DAOAdministrarActividadEconomica.sp_ActualizarNewActividadEconomica(actividadEconomicaID, nombreActividadEconomica);
    }
    public static DataTable EliminarActividadEconomica(int actividadEconomicaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarActividadEconomica.sp_EliminarNewActividadEconomica(actividadEconomicaID);
        return dt;
    }
}