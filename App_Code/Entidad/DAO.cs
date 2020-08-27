using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de DAO
/// </summary>
public class DAO
{
    public static FrameworkEntidades entidades = new FrameworkEntidades();

	public static string ConsultarDepartamento(string departamento)
	{
        DataTable dt = new DataTable();
        DataRow dr;
        string[] nombreCampos = new string[2] { "dep_Id", "dep_Nombre" };
        dt = entidades.Consultar("Departamento", nombreCampos, "dep_Id", departamento);
        dr = dt.Rows[0];
        return dr["dep_Nombre"].ToString();                
	}

    //public static string ConsultarAgencia(string departamento)
    //{
    //    DataTable dt = new DataTable();
    //    DataRow dr;
    //    string[] nombreCampos = new string[2] { "dep_Id", "dep_Nombre" };
    //    dt = entidades.ConsultarAgencia(departamento);
    //    dr = dt.Rows[0];
    //    return dr["ciu_Nombre"].ToString();
    //}
}