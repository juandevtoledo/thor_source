using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para las polizas
/// </summary>
public class DAOAdministrarPoliza
{
    /// <summary>
    /// Lista todas las polizas del sistema
    /// </summary>
    /// <returns>Tabla con todas las polizas</returns>
    public static DataTable sp_ListarNewPolizas()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewPolizas", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una poliza
    /// </summary>
    /// <param name="PolizaNumero"></param>
    /// <param name="ProductoIdentificador">Producto</param>
    /// <param name="TomadorIdentificador">Tomador</param>
    /// <param name="PolizaTipo"></param>
    public static void sp_InsertarNewPoliza(long polizaNumero, long? ProductoIdentificador, long? TomadorIdentificador, long? PolizaTipo)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Numero", polizaNumero));
        if (ProductoIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@pro_Id", ProductoIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@pro_Id", DBNull.Value));
        if (TomadorIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@tom_Id", TomadorIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@tom_Id", DBNull.Value));
        if (PolizaTipo != null)
            cmd.Parameters.Add(new SqlParameter("@pol_Tipo", PolizaTipo));
        else
            cmd.Parameters.Add(new SqlParameter("@pol_Tipo", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza</returns>
    public static DataTable sp_ConsultarNewPoliza(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", polizaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una poliza por su ID para ser modificado
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza para ser modificado</returns>
    public static DataTable sp_ConsultarNewPolizaModificar(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewPolizaModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", polizaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <param name="polizaNumero">Nuevo </param>
    /// <param name="ProductoIdentificador">Nuevo producto</param>
    /// <param name="TomadorIdentificador">Nuevo tomador</param>
    /// <param name="PolizaTipo">Nuevo </param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewPoliza(long polizaIdentificador, long polizaNumero, long? ProductoIdentificador, long? TomadorIdentificador, long? PolizaTipo)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewPoliza", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pol_Id", polizaIdentificador));
            cmd.Parameters.Add(new SqlParameter("@pol_Numero", polizaNumero));
            if (ProductoIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@pro_Id", ProductoIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@pro_Id", DBNull.Value));
            if (TomadorIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@tom_Id", TomadorIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@tom_Id", DBNull.Value));
            if (PolizaTipo != null)
                cmd.Parameters.Add(new SqlParameter("@pol_Tipo", PolizaTipo));
            else
                cmd.Parameters.Add(new SqlParameter("@pol_Tipo", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la poliza" : "OK";
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
    /// Elimina la información de una poliza por su ID
    /// </summary>
    /// <param name="polizaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewPoliza(long polizaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewPoliza", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pol_Id", polizaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
