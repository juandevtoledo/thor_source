using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Departamento
/// </summary>
public class AdministrarDepartamento
{
    public static DataTable mostrarDepartamento()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarDepartamento.sp_MostrarDepartamento();
        return dt;
    }
}