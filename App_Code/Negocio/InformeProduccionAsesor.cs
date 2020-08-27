using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
/// <summary>
/// Descripción breve de InformeProduccionAsesor
/// </summary>
public class InformeProduccionAsesor
{
	public InformeProduccionAsesor()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public static DataTable ConsultarInformeProduccionAsesor(DateTime fecha, int localidad)
    {
        DataTable dtInforme = new DataTable();
        dtInforme = DAOInformeProduccionAsesor.sp_ConsultarInformeProduccion(fecha, localidad);
        return dtInforme;
    }
}