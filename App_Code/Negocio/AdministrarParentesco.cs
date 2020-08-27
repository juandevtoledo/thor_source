using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarParentesco
{
    public static DataTable ListarParentescos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentesco.sp_ListarNewParentescos();
        return dt;
    }
    public static void InsertarParentesco(string nombreParentesco)
    {

        DAOAdministrarParentesco.sp_InsertarNewParentesco(nombreParentesco);
    }
    public static DataTable ConsultarParentesco(int parentescoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentesco.sp_ConsultarNewParentesco(parentescoID);
        return dt;
    }
    public static DataTable ConsultarParentescoModificar(int parentescoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentesco.sp_ConsultarNewParentescoModificar(parentescoID);
        return dt;
    }
    public static void ModificarParentesco(int parentescoID, string nombreParentesco)
    {
        DAOAdministrarParentesco.sp_ActualizarNewParentesco(parentescoID, nombreParentesco);
    }
    public static DataTable EliminarParentesco(int parentescoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentesco.sp_EliminarNewParentesco(parentescoID);
        return dt;
    }

    public static DataTable BuscarParentesco(int id, string nombre)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentesco.sp_BuscarParentesco(id, nombre);
        return dt;
    }
}