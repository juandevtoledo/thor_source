using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AdministrarCierreSistema
/// </summary>
public class AdministrarCierreSistema
{
	
    public static DataTable ListarCierres()
    {
        DataTable dt = new DataTable();
        dt = DAOCierreSistema.SPListarCierres();
        return dt;

    }

    public static void InsertarCierreSistema(string compania, string producto, string agencia, string mes, string anio, string estado)
    {
        DataTable dt = new DataTable();
        dt = DAOCierreSistema.spListarAgencias();
   
        //return dt;
        
        if (agencia == "todo")
        {
            foreach (DataRow row in dt.Rows)
            {
                DAOCierreSistema.InsertarCierreSistema(compania, producto, row["age_Id"].ToString(), mes, anio, estado);
            }
        }
        else{
             DAOCierreSistema.InsertarCierreSistema(compania, producto, agencia, mes, anio, estado);
        }
       
        
    }

    public static void CerrarCierreSistema(int cierre)
    {
        DAOCierreSistema.CerrarCierreSistema(cierre);
    }

    public static void AbrirCierreSistema(int cierre, int producto, int agencia, int mes, int anio)
    {
        DAOCierreSistema.AbrirCierreSistema(cierre, producto, agencia, mes, anio);
    }
}