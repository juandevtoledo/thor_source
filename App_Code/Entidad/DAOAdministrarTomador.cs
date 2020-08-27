using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los tomadores
/// </summary>
public class DAOAdministrarTomador
{
    /// <summary>
    /// Lista todos los tomadores del sistema
    /// </summary>
    /// <returns>Tabla con todos los tomadores</returns>
    public static DataTable sp_ListarNewTomadores()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewTomadores", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un tomador
    /// </summary>
    /// <param name="tomadorIdentificacion">Identificación tomador</param>
    /// <param name="tomadorNombre">Nombre tomador</param>
    /// <param name="tomadorDireccion">Dirección tomador</param>
    /// <param name="tomadorTelefono">Teléfono tomador</param>
    /// <param name="tomadorRepresentanteLegal">Representante legal</param>
    public static void sp_InsertarNewTomador(long tomadorIdentificacion, string tomadorNombre, string tomadorDireccion, string tomadorTelefono, string tomadorRepresentanteLegal)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTomador", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tom_Identificacion", tomadorIdentificacion));
        cmd.Parameters.Add(new SqlParameter("@tom_Nombre", tomadorNombre));
        if (tomadorDireccion != null)
            cmd.Parameters.Add(new SqlParameter("@tom_Direccion", tomadorDireccion));
        else
            cmd.Parameters.Add(new SqlParameter("@tom_Direccion", DBNull.Value));
        if (tomadorTelefono != null)
            cmd.Parameters.Add(new SqlParameter("@tom_Telefono", tomadorTelefono));
        else
            cmd.Parameters.Add(new SqlParameter("@tom_Telefono", DBNull.Value));
        if (tomadorRepresentanteLegal != null)
            cmd.Parameters.Add(new SqlParameter("@tom_RepresentanteLegal", tomadorRepresentanteLegal));
        else
            cmd.Parameters.Add(new SqlParameter("@tom_RepresentanteLegal", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tomador</returns>
    public static DataTable sp_ConsultarNewTomador(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTomador", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tom_Id", tomadorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un tomador por su ID para ser modificado
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tomador para ser modificado</returns>
    public static DataTable sp_ConsultarNewTomadorModificar(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTomadorModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tom_Id", tomadorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <param name="tomadorIdentificacion">Nuevo identificación tomador</param>
    /// <param name="tomadorNombre">Nuevo nombre tomador</param>
    /// <param name="tomadorDireccion">Nuevo dirección tomador</param>
    /// <param name="tomadorTelefono">Nuevo teléfono tomador</param>
    /// <param name="tomadorRepresentanteLegal">Nuevo representante legal</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewTomador(long tomadorIdentificador, long tomadorIdentificacion, string tomadorNombre, string tomadorDireccion, string tomadorTelefono, string tomadorRepresentanteLegal)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewTomador", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tom_Id", tomadorIdentificador));
            cmd.Parameters.Add(new SqlParameter("@tom_Identificacion", tomadorIdentificacion));
            cmd.Parameters.Add(new SqlParameter("@tom_Nombre", tomadorNombre));
            if (tomadorDireccion != null)
                cmd.Parameters.Add(new SqlParameter("@tom_Direccion", tomadorDireccion));
            else
                cmd.Parameters.Add(new SqlParameter("@tom_Direccion", DBNull.Value));
            if (tomadorTelefono != null)
                cmd.Parameters.Add(new SqlParameter("@tom_Telefono", tomadorTelefono));
            else
                cmd.Parameters.Add(new SqlParameter("@tom_Telefono", DBNull.Value));
            if (tomadorRepresentanteLegal != null)
                cmd.Parameters.Add(new SqlParameter("@tom_RepresentanteLegal", tomadorRepresentanteLegal));
            else
                cmd.Parameters.Add(new SqlParameter("@tom_RepresentanteLegal", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el tomador" : "OK";
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
    /// Elimina la información de un tomador por su ID
    /// </summary>
    /// <param name="tomadorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewTomador(long tomadorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTomador", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tom_Id", tomadorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
