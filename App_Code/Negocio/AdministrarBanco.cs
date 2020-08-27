using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarBanco
{
    public static DataTable ListarBancos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarBanco.sp_ListarNewBancos();
        return dt;
    }
    public static void InsertarBanco(string nombreBanco)
    {

        DAOAdministrarBanco.sp_InsertarNewBanco(nombreBanco);
    }
    public static DataTable ConsultarBanco(int bancoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarBanco.sp_ConsultarNewBanco(bancoID);
        return dt;
    }
    public static DataTable ConsultarBancoModificar(int bancoID)
    {
        DataTable dt = new DataTable();
        //sp_ConsultarCompaniaModificar
        dt = DAOAdministrarBanco.sp_ConsultarNewBancoModificar(bancoID);
        return dt;
    }
    public static void ModificarBanco(int bancoID, string nombreBanco)
    {
        DAOAdministrarBanco.sp_ActualizarNewBanco(bancoID, nombreBanco);
    }
    public static DataTable EliminarBanco(int bancoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarBanco.sp_EliminarNewBanco(bancoID);
        return dt;
    }
}