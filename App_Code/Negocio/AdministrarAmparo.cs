using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarAmparo
{
    public static DataTable ListarAmparos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAmparo.sp_ListarAmparos();
        return dt;
    }
    public static void InsertarAmparo(string nombreAmparo)
    {

        DAOAdministrarAmparo.sp_InsertarAmparo(nombreAmparo);
    }
    public static DataTable ConsultarAmparo(int amparoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAmparo.sp_ConsultarAmparo(amparoID);
        return dt;
    }
    public static DataTable ConsultarAmparoModificar(int amparoID)
    {
        DataTable dt = new DataTable();
        //sp_ConsultarCompaniaModificar
        dt = DAOAdministrarAmparo.sp_ConsultarAmparoModificar(amparoID);
        return dt;
    }
    public static void ModificarAmparo(int amparoID, string nombreAmparo)
    {
        DAOAdministrarAmparo.sp_ActualizarAmparo(amparoID, nombreAmparo);
    }
    public static DataTable EliminarAmparo(int amparoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAmparo.sp_EliminarAmparo(amparoID);
        return dt;
    }
}