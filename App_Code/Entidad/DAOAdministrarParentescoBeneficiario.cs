using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para Los parentescos beneficiarios
/// </summary>
public class DAOAdministrarParentescoBeneficiario
{
    /// <summary>
    /// Lista todos los parentescos beneficiarios del sistema
    /// </summary>
    /// <returns>Tabla con todos los parentescos beneficiarios</returns>
    public static DataTable sp_ListarNewParentescosBeneficiarios()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewParentescosBeneficiarios", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un parentesco beneficiario
    /// </summary>
    /// <param name="parentescoIdentificador">Parentesco</param>
    /// <param name="productorIdentificador">Producto</param>
    public static void sp_InsertarNewParentescoBeneficiario(long parentescoIdentificador, long productorIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewParentescoBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@par_Id", parentescoIdentificador));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", productorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco beneficiario</returns>
    public static DataTable sp_ConsultarNewParentescoBeneficiario(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewParentescoBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parben_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un parentesco beneficiario por su ID para ser modificado
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco beneficiario para ser modificado</returns>
    public static DataTable sp_ConsultarNewParentescoBeneficiarioModificar(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewParentescoBeneficiarioModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parben_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <param name="parentescoIdentificador">Nuevo parentesco</param>
    /// <param name="productorIdentificador">Nuevo producto</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewParentescoBeneficiario(long parentescoProductoIdentificador, long parentescoIdentificador, long productorIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewParentescoBeneficiario", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@parben_Id", parentescoProductoIdentificador));
            cmd.Parameters.Add(new SqlParameter("@par_Id", parentescoIdentificador));
            cmd.Parameters.Add(new SqlParameter("@pro_Id", productorIdentificador));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el parentesco beneficiario" : "OK";
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
    /// Elimina la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewParentescoBeneficiario(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewParentescoBeneficiario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@parben_Id", parentescoProductoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
