using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para Las polizas por localidades
/// </summary>
public class DAOAdministrarPolizaLocalidad
{
    /// <summary>
    /// Lista todas las polizas por localidades del sistema
    /// </summary>
    /// <returns>Tabla con todas las polizas por localidades</returns>
    public static DataTable sp_ListarNewPolizasLocalidades()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewPolizasLocalidades", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una poliza por localidad
    /// </summary>
    /// <param name="PolizaIdentificador">Poliza</param>
    /// <param name="DepartamentoIdentificador">Departamento</param>
    public static void sp_InsertarNewPolizaLocalidad(long PolizaIdentificador, long DepartamentoIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewPolizaLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", PolizaIdentificador));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", DepartamentoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza localidad</returns>
    public static DataTable sp_ConsultarNewPolizaLocalidad(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewPolizaLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@polLoc_Id", PolizaLocalidadIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una poliza por localidad por su ID para ser modificado
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza localidad para ser modificado</returns>
    public static DataTable sp_ConsultarNewPolizaLocalidadModificar(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewPolizaLocalidadModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@polLoc_Id", PolizaLocalidadIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <param name="PolizaIdentificador">Nuevo poliza</param>
    /// <param name="DepartamentoIdentificador">Nuevo departamento</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewPolizaLocalidad(long PolizaLocalidadIdentificador, long PolizaIdentificador, long DepartamentoIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewPolizaLocalidad", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@polLoc_Id", PolizaLocalidadIdentificador));
            cmd.Parameters.Add(new SqlParameter("@pol_Id", PolizaIdentificador));
            cmd.Parameters.Add(new SqlParameter("@dep_Id", DepartamentoIdentificador));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la poliza localidad" : "OK";
        }
        catch (Exception ex)
        {
            rpta = ex.Message;
        }
        finally
        {
            if (FrameworkEntidades.cnx.State == ConnectionState.Open) FrameworkEntidades.cnx.Close();
        }
        FrameworkEntidades.cnx.Close();
        return rpta;
    }

    /// <summary>
    /// Elimina la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewPolizaLocalidad(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewPolizaLocalidad", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@polLoc_Id", PolizaLocalidadIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
