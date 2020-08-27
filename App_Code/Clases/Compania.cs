using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class Compania
{
    public static FrameworkEntidades entidades = new FrameworkEntidades();

    protected string idCompania;
    public string IDCompania { get; set; }

    protected string nombreCompania;
    public string NombreCompania { get; set; }

    public DataTable ConsultarCompanias()
    {
        DataTable dt = new DataTable();
        string[] nombreCampos = new string[2] { "com_Id", "com_Nombre" };
        dt = entidades.ConsultarSinCondicion("Compañia", nombreCampos);
        return dt;
    }
}