using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarCompania
{
    public static DataTable ListarCompanias()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCompania.sp_ListarCompanias();
        return dt;
    }
    public static void InsertarCompania(string nombreCompania)
    {
        DAOAdministrarCompania.sp_InsertarCompania(nombreCompania);
    }
    public static DataTable ConsultarCompania(int companiaID)
    {
        DataTable dt = new DataTable();
        //DB: Comentado
        //dt = DAOControl.sp_ConsultarUsuario(usuario);
        dt = DAOAdministrarCompania.sp_ConsultarCompania(companiaID);
        return dt;
    }
    public static DataTable ConsultarCompaniaModificar(int companiaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCompania.sp_ConsultarCompaniaModificar(companiaID);
        return dt;
    }
    public static void ModificarCompania(int companiaID ,string nombreCompania)
    {
        DAOAdministrarCompania.sp_ActualizarCompania(companiaID, nombreCompania);
    }
    public static DataTable EliminarCompania(int companiaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCompania.sp_EliminarCompania(companiaID);
        return dt;
    }
}