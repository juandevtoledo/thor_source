using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los tipos de documentos
/// </summary>
public class DAOAdministrarTipoDocumento
{
    /// <summary>
    /// Lista todos los tipos de documentos del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de documentos</returns>
    public static DataTable sp_ListarNewTiposDocumentos()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewTiposDocumentos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de documento
    /// </summary>
    /// <param name="tipoDocumentoNombre">Nombre de tipo de documento</param>
    public static void sp_InsertarNewTipoDocumento(string tipoDocumentoNombre)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTipoDocumento", FrameworkEntidades.cnx);
        if (tipoDocumentoNombre != null)
            cmd.Parameters.Add(new SqlParameter("@tipDoc_Nombre", tipoDocumentoNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@tipDoc_Nombre", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de documento</returns>
    public static DataTable sp_ConsultarNewTipoDocumento(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoDocumento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", tipoDocumentoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de documento por su ID para ser modificado
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de documento para ser modificado</returns>
    public static DataTable sp_ConsultarNewTipoDocumentoModificar(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTipoDocumentoModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", tipoDocumentoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <param name="tipoDocumentoNombre">Nuevo nombre de tipo de documento</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewTipoDocumento(long tipoDocumentoIdentificador, string tipoDocumentoNombre)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewTipoDocumento", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", tipoDocumentoIdentificador));
            if (tipoDocumentoNombre != null)
                cmd.Parameters.Add(new SqlParameter("@tipDoc_Nombre", tipoDocumentoNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@tipDoc_Nombre", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el tipo de documento" : "OK";
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
    /// Elimina la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewTipoDocumento(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewTipoDocumento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@tipDoc_Id", tipoDocumentoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
