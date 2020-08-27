using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOCiudad
/// </summary>
public class DAOAdministrarCiudad
{
    public static DataTable sp_MostrarCiudad(int? idCiud, string nomCiudad, int? idDepto)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_MostrarCiudades", FrameworkEntidades.cnx);

        if (idCiud.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idCiudad", idCiud));
        else
            cmd.Parameters.Add(new SqlParameter("@idCiudad", DBNull.Value));


        if (String.IsNullOrEmpty(nomCiudad))
            cmd.Parameters.Add(new SqlParameter("@nomCiudad", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomCiudad", nomCiudad));

        if (idDepto.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
        else
            cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }
}