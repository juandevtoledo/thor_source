using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para las agencias
/// </summary>
public class DAOAdministrarAgencia
{
    /// <summary>
    /// Lista todas las agencias del sistema
    /// </summary>
    /// <returns>Tabla con todas las agencias</returns>
    public static DataTable sp_ListarNewAgencias()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewAgencias", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de una agencia
    /// </summary>
    /// <param name="agenciaNombre">Nombre Agencia</param>
    /// <param name="agenciaDireccion">Dirección Agencia</param>
    /// <param name="agenciaTelefono">Teléfono Agencia</param>
    /// <param name="agenciaEmail">Email Agencia</param>
    /// <param name="agenciaDirector">Director Agencia</param>
    /// <param name="departamentoIdentificador">Departamento</param>
    /// <param name="ciudadIdentificador">Ciudad</param>
    public static void sp_InsertarNewAgencia(string agenciaNombre, string agenciaDireccion, string agenciaTelefono, string agenciaEmail, string agenciaDirector, long? departamentoIdentificador, long? ciudadIdentificador)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Nombre", agenciaNombre));
        if (agenciaDireccion != null)
            cmd.Parameters.Add(new SqlParameter("@age_Direccion", agenciaDireccion));
        else
            cmd.Parameters.Add(new SqlParameter("@age_Direccion", DBNull.Value));
        if (agenciaTelefono != null)
            cmd.Parameters.Add(new SqlParameter("@age_Telefono", agenciaTelefono));
        else
            cmd.Parameters.Add(new SqlParameter("@age_Telefono", DBNull.Value));
        if (agenciaEmail != null)
            cmd.Parameters.Add(new SqlParameter("@age_Email", agenciaEmail));
        else
            cmd.Parameters.Add(new SqlParameter("@age_Email", DBNull.Value));
        if (agenciaDirector != null)
            cmd.Parameters.Add(new SqlParameter("@age_Director", agenciaDirector));
        else
            cmd.Parameters.Add(new SqlParameter("@age_Director", DBNull.Value));
        if (departamentoIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@dep_Id", DBNull.Value));
        if (ciudadIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@ciu_Id", ciudadIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@ciu_Id", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de una agencia por su ID
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de agencia</returns>
    public static DataTable sp_ConsultarNewAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", agenciaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de una agencia por su ID para ser modificado
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de agencia para ser modificado</returns>
    public static DataTable sp_ConsultarNewAgenciaModificar(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewAgenciaModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", agenciaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de una agencia por su ID
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <param name="agenciaNombre">Nuevo nombre agencia</param>
    /// <param name="agenciaDireccion">Nuevo dirección agencia</param>
    /// <param name="agenciaTelefono">Nuevo teléfono agencia</param>
    /// <param name="agenciaEmail">Nuevo email agencia</param>
    /// <param name="agenciaDirector">Nuevo director agencia</param>
    /// <param name="departamentoIdentificador">Nuevo departamento</param>
    /// <param name="ciudadIdentificador">Nuevo ciudad</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewAgencia(long agenciaIdentificador, string agenciaNombre, string agenciaDireccion, string agenciaTelefono, string agenciaEmail, string agenciaDirector, long? departamentoIdentificador, long? ciudadIdentificador)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewAgencia", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@age_Id", agenciaIdentificador));
            cmd.Parameters.Add(new SqlParameter("@age_Nombre", agenciaNombre));
            if (agenciaDireccion != null)
                cmd.Parameters.Add(new SqlParameter("@age_Direccion", agenciaDireccion));
            else
                cmd.Parameters.Add(new SqlParameter("@age_Direccion", DBNull.Value));
            if (agenciaTelefono != null)
                cmd.Parameters.Add(new SqlParameter("@age_Telefono", agenciaTelefono));
            else
                cmd.Parameters.Add(new SqlParameter("@age_Telefono", DBNull.Value));
            if (agenciaEmail != null)
                cmd.Parameters.Add(new SqlParameter("@age_Email", agenciaEmail));
            else
                cmd.Parameters.Add(new SqlParameter("@age_Email", DBNull.Value));
            if (agenciaDirector != null)
                cmd.Parameters.Add(new SqlParameter("@age_Director", agenciaDirector));
            else
                cmd.Parameters.Add(new SqlParameter("@age_Director", DBNull.Value));
            if (departamentoIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@dep_Id", DBNull.Value));
            if (ciudadIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@ciu_Id", ciudadIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@ciu_Id", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo la agencia" : "OK";
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
    /// Elimina la información de una agencia por su ID
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", agenciaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    public static DataTable sp_ConsultarLocalidadesAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadPorAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", agenciaIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    public static int sp_AsignarLocalidadAgencia(int age_Id, int dep_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarLocalidadAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static int sp_EliminarLocalidadAgencia(int age_Id, int dep_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarLocalidadAgencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static DataTable sp_BuscarAgencia(int codigo, string nombre, string direccion, string telefono)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarAgencia", FrameworkEntidades.cnx);

        if (codigo > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@age_Id", codigo));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@age_Id", DBNull.Value));
        }

        if (nombre != "")
        {
            cmd.Parameters.Add(new SqlParameter("@age_Nombre", nombre));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@age_Nombre", DBNull.Value));
        }

        if (direccion != "")
        {
            cmd.Parameters.Add(new SqlParameter("@age_Direccion", direccion));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@age_Direccion", DBNull.Value));
        }

        if (telefono != "")
        {
            cmd.Parameters.Add(new SqlParameter("@age_Telefono", telefono));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@age_Telefono", DBNull.Value));
        }


        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}