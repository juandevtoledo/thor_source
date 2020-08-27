using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ciudad
/// </summary>
public class AdministrarCiudad
{
    public static DataTable mostrarCiudades(int? idCiud, string nomCiud, int? idDepto)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarCiudad.sp_MostrarCiudad(idCiud, nomCiud, idDepto);
        return dt;
    }
}