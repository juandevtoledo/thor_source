using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAODepartamento
/// </summary>
public class DAOAdministrarDepartamento
{
    public static DataTable sp_MostrarDepartamento()
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarDepartamento", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }
}