using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de acceso a base de datos para los asesores
/// </summary>
public class DAOAdministrarAsesor
{
    /// <summary>
    /// Lista todos los asesores del sistema
    /// </summary>
    /// <returns>Tabla con todos los asesores</returns>
    public static DataTable sp_ListarNewAsesores()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNewAsesores", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Inserta la información de un asesor
    /// </summary>
    /// <param name="asesorCodigo">Código asesor</param>
    /// <param name="asesorApellidos">Apellidos asesor</param>
    /// <param name="asesorNombres">Nombres asesor</param>
    /// <param name="departamentoIdentificador">Departamento</param>
    /// <param name="compañiaIdentificador">Compañía</param>
    /// <param name="asesorActivo">Asesor activo</param>
    /// <param name="asesorFuncionario">Es funcionario</param>
    public static void sp_InsertarNewAsesor(long? asesorCodigo, string asesorApellidos, string asesorNombres, long? departamentoIdentificador, long? compañiaIdentificador, string asesorActivo, string asesorFuncionario)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewAsesor", FrameworkEntidades.cnx);
        if (asesorCodigo != null)
            cmd.Parameters.Add(new SqlParameter("@ase_Codigo", asesorCodigo));
        else
            cmd.Parameters.Add(new SqlParameter("@ase_Codigo", DBNull.Value));
        if (asesorApellidos != null)
            cmd.Parameters.Add(new SqlParameter("@ase_Apellidos", asesorApellidos));
        else
            cmd.Parameters.Add(new SqlParameter("@ase_Apellidos", DBNull.Value));
        if (asesorNombres != null)
            cmd.Parameters.Add(new SqlParameter("@ase_Nombres", asesorNombres));
        else
            cmd.Parameters.Add(new SqlParameter("@ase_Nombres", DBNull.Value));
        if (departamentoIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@dep_Id", DBNull.Value));
        if (compañiaIdentificador != null)
            cmd.Parameters.Add(new SqlParameter("@com_Id", compañiaIdentificador));
        else
            cmd.Parameters.Add(new SqlParameter("@com_Id", DBNull.Value));
        if (asesorActivo != null)
            cmd.Parameters.Add(new SqlParameter("@ase_Activo", asesorActivo));
        else
            cmd.Parameters.Add(new SqlParameter("@ase_Activo", DBNull.Value));
        if (asesorFuncionario != null)
            cmd.Parameters.Add(new SqlParameter("@ase_Funcionario", asesorFuncionario));
        else
            cmd.Parameters.Add(new SqlParameter("@ase_Funcionario", DBNull.Value));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    /// <summary>
    /// Consulta la información de un asesor por su ID
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de asesor</returns>
    public static DataTable sp_ConsultarNewAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Consulta la información de un asesor por su ID para ser modificado
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de asesor para ser modificado</returns>
    public static DataTable sp_ConsultarNewAsesorModificar(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewAsesorModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    /// <summary>
    /// Actualiza la información de un asesor por su ID
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <param name="asesorCodigo">Nuevo código asesor</param>
    /// <param name="asesorApellidos">Nuevo apellidos asesor</param>
    /// <param name="asesorNombres">Nuevo nombres asesor</param>
    /// <param name="departamentoIdentificador">Nuevo departamento</param>
    /// <param name="compañiaIdentificador">Nuevo compañía</param>
    /// <param name="asesorActivo">Nuevo asesor activo</param>
    /// <param name="asesorFuncionario">Nuevo es funcionario</param>
    /// <returns>Resultado de la actualización</returns>
    public static string sp_ActualizarNewAsesor(long asesorIdentificador, long? asesorCodigo, string asesorApellidos, string asesorNombres, long? departamentoIdentificador, long? compañiaIdentificador, string asesorActivo, string asesorFuncionario)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarNewAsesor", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
            if (asesorCodigo != null)
                cmd.Parameters.Add(new SqlParameter("@ase_Codigo", asesorCodigo));
            else
                cmd.Parameters.Add(new SqlParameter("@ase_Codigo", DBNull.Value));
            if (asesorApellidos != null)
                cmd.Parameters.Add(new SqlParameter("@ase_Apellidos", asesorApellidos));
            else
                cmd.Parameters.Add(new SqlParameter("@ase_Apellidos", DBNull.Value));
            if (asesorNombres != null)
                cmd.Parameters.Add(new SqlParameter("@ase_Nombres", asesorNombres));
            else
                cmd.Parameters.Add(new SqlParameter("@ase_Nombres", DBNull.Value));
            if (departamentoIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@dep_Id", departamentoIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@dep_Id", DBNull.Value));
            if (compañiaIdentificador != null)
                cmd.Parameters.Add(new SqlParameter("@com_Id", compañiaIdentificador));
            else
                cmd.Parameters.Add(new SqlParameter("@com_Id", DBNull.Value));
            if (asesorActivo != null)
                cmd.Parameters.Add(new SqlParameter("@ase_Activo", asesorActivo));
            else
                cmd.Parameters.Add(new SqlParameter("@ase_Activo", DBNull.Value));
            if (asesorFuncionario != null)
                cmd.Parameters.Add(new SqlParameter("@ase_Funcionario", asesorFuncionario));
            else
                cmd.Parameters.Add(new SqlParameter("@ase_Funcionario", DBNull.Value));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el asesor" : "OK";
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
    /// Elimina la información de un asesor por su ID
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable sp_EliminarNewAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarNewAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;
    }

    public static DataTable sp_ConsultarNewProductoAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewProductoAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable sp_ConsultarProductosCompañia(int com_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarProductoPorCompania", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@com_Id", com_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int sp_AsignarProductoAsesor(int ase_Id, int pro_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarProductoAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }
    
    public static int sp_EliminarProductoAsesor(int ase_Id, int pro_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarProductoAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@pro_Id", pro_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static DataTable sp_ConsultarLocalidadesAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarLocalidadesAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", asesorIdentificador));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static int sp_AsignarLocalidadAsesor(int ase_Id, int dep_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarLocalidadAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static int sp_EliminarLocalidadAsesor(int ase_Id, int dep_Id)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarLocalidadAsesor", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ase_Id", ase_Id));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    public static DataTable sp_BuscarNewAsesor(int codigo, string nombre, string localidad, string estado)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarNewAsesor", FrameworkEntidades.cnx);

        if (codigo > 0)
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Codigo", codigo));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Codigo", DBNull.Value));
        }

        if (nombre != "")
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Nombre", nombre));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Nombre", DBNull.Value));
        }

        if (localidad != "")
        {
            cmd.Parameters.Add(new SqlParameter("@ase_localidad", localidad));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ase_localidad", DBNull.Value));
        }

        if (estado != "")
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Estado", estado));
        }
        else
        {
            cmd.Parameters.Add(new SqlParameter("@ase_Estado", DBNull.Value));
        }


        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}
