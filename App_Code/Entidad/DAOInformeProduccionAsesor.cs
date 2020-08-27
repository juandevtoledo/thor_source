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
/// Descripción breve de DAOInformeProduccionAsesor
/// </summary>
public class DAOInformeProduccionAsesor
{
	public DAOInformeProduccionAsesor()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}



    public static DataTable sp_ConsultarInformeProduccion(DateTime fechaProduccion, int localidad)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InformeProduccionAsesores", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@fecha", fechaProduccion));
        cmd.Parameters.Add(new SqlParameter("@localidad", localidad));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}