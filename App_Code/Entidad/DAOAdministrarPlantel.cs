using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los planteles
/// </summary>
public class DAOAdministrarPlantel
{
    /// <summary>
    /// Lista todos los planteles del sistema
    /// </summary>
    /// <returns>Tabla con todos los planteles</returns>
    public static DataTable sp_ListarPlanteles()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarPlanteles", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un plantel
    /// </summary>
    /// <param name="plantelNombre">Plantel</param>
    /// <param name="departamentoIdentificador">Departamento</param>
    public static void sp_InsertarPlantel(string plantelNombre, long departamentoIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarPlantel", FrameworkEntidades.cnx);
        if (plantelNombre != null)
            cmd.Parameters.Add(new SqlParameter("@pla_Nombre", plantelNombre));
        else
            cmd.Parameters.Add(new SqlParameter("@pla_Nombre", DBNull.Value));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de plantel</returns>
    public static DataTable sp_ConsultarPlantel(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlantel", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pla_Id", plantelidentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un plantel por su ID para ser modificado
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de plantel para ser modificado</returns>
    public static DataTable sp_ConsultarPlantelModificar(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarPlantelModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pla_Id", plantelidentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <param name="plantelNombre">Nuevo plantel</param>
    /// <param name="departamentoIdentificador">Nuevo departamento</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarPlantel(long plantelidentificador, string plantelNombre, long departamentoIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarPlantel", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pla_Id", plantelidentificador));
            if (plantelNombre != null)
                cmd.Parameters.Add(new SqlParameter("@pla_Nombre", plantelNombre));
            else
                cmd.Parameters.Add(new SqlParameter("@pla_Nombre", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el plantel" : "OK";
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
    /// Elimina la información de un plantel por su ID
    /// </summary>
    /// <param name="plantelidentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarPlantel(long plantelidentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarPlantel", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@pla_Id", plantelidentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }
}
