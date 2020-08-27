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
/// Descripción breve de DAOAdministrarPagosDetalle
/// </summary>
public class DAOAdministrarPagosDetalle
{
	public static DataTable ConsultarAplicacionesSolicitudCheques(string departamento, int solicitudCheques)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAplicacionesSolicitudCheques", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@solcheId", solicitudCheques));
        cmd.Parameters.Add(new SqlParameter("@departamento", departamento));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}