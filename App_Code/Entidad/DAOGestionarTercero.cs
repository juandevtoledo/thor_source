using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOGestionarTercero
/// </summary>
public class DAOGestionarTercero
{
    //
	public DAOGestionarTercero()
	{
		
	}

    // Retorna la lista de terceros desde la base de datos
    public static DataTable sp_BuscarTercero(double ter_Id, string ter_Nombres, string ter_Apellidos)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", ter_Nombres));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", ter_Apellidos));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Retorna los datos de new tercero por cedula desde la base de datos
    public static DataTable sp_ConsultarNewTerceroPorCedula(int ter_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarNewTerceroPorCedula", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Retorna las ciudades por departamentos desde la base de datos
    public static DataTable sp_ConsultarCiudadPorDepartamento(string dep)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCiudadPorDepartamento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Retorna los tipos de documentos desde la base de datos
    public static DataTable sp_MostrarTipoDocumento()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_MostrarTipoDocumento", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Retorna los estados civiles desde la base de datos
    public static DataTable sp_ConsultarEstadoCivil()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarEstadoCivil", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Retorna la ocupación desde la base de datos
    public static DataTable sp_ConsultarOcupacion()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarOcupacion", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Actualiza la informacion del tercero en la base de datos
    public static int sp_EditarNewTercero(int txtDocumento, int ddlTipoDocumentoTercero, string txtNombre, string txtApellido, 
                                            DateTime txtNacimiento, string txtCorreo, string ddlGeneroTercero, int ddlDepartamento, 
                                            int ddlCiudad, string txtCelular, string txtTelefono1, string txtDireccion, string txtTelefono2,
                                            int ddlOcupacionTercero, int ddlEstadoCivilTercero, string usuario, int habeasData)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EditarNewTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", txtDocumento));
        cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", ddlTipoDocumentoTercero));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", txtNombre));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", txtApellido));
        cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", txtNacimiento));
        cmd.Parameters.Add(new SqlParameter("@ter_Correo", txtCorreo));
        cmd.Parameters.Add(new SqlParameter("@ter_Sexo", ddlGeneroTercero));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", ddlDepartamento));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", ddlCiudad));
        cmd.Parameters.Add(new SqlParameter("@ter_Celular", txtCelular));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", txtTelefono1));
        cmd.Parameters.Add(new SqlParameter("@ter_Direccion", txtDireccion));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", txtTelefono2));
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ddlOcupacionTercero));
        cmd.Parameters.Add(new SqlParameter("@ter_EstadoCIvil", ddlEstadoCivilTercero));
        cmd.Parameters.Add(new SqlParameter("@user", usuario));
        cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", habeasData));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    // Insertar tercero en la base de datos
    public static int sp_InsertarNewTercero(int txtDocumento, int ddlTipoDocumentoTercero, string txtNombre, string txtApellido,
                                            DateTime txtNacimiento, string txtCorreo, string ddlGeneroTercero, int ddlDepartamento,
                                            int ddlCiudad, string txtCelular, string txtTelefono1, string txtDireccion, string txtTelefono2,
                                            int ddlOcupacionTercero, int ddlEstadoCivilTercero, string usuario,int habeasData)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarNewTercero", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", txtDocumento));
        cmd.Parameters.Add(new SqlParameter("@ter_TipoDocumento", ddlTipoDocumentoTercero));
        cmd.Parameters.Add(new SqlParameter("@ter_Nombres", txtNombre));
        cmd.Parameters.Add(new SqlParameter("@ter_Apellidos", txtApellido));
        cmd.Parameters.Add(new SqlParameter("@ter_FechaNacimiento", txtNacimiento));
        cmd.Parameters.Add(new SqlParameter("@ter_Correo", txtCorreo));
        cmd.Parameters.Add(new SqlParameter("@ter_Sexo", ddlGeneroTercero));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", ddlDepartamento));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", ddlCiudad));
        cmd.Parameters.Add(new SqlParameter("@ter_Celular", txtCelular));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoResidencia", txtTelefono1));
        cmd.Parameters.Add(new SqlParameter("@ter_Direccion", txtDireccion));
        cmd.Parameters.Add(new SqlParameter("@ter_TelefonoOficina", txtTelefono2));
        cmd.Parameters.Add(new SqlParameter("@ocu_Id", ddlOcupacionTercero));
        cmd.Parameters.Add(new SqlParameter("@ter_EstadoCIvil", ddlEstadoCivilTercero));
        cmd.Parameters.Add(new SqlParameter("@user", usuario));
        cmd.Parameters.Add(new SqlParameter("@ter_HabeasData", habeasData));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    // Retorna la ocupación desde la base de datos
    public static DataTable spConsultarObservaciones(string ter_Id, string obs_IdObservacionMenu)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarObservaciones", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@ter_Id", ter_Id));
        cmd.Parameters.Add(new SqlParameter("@obs_IdObservacionMenu", obs_IdObservacionMenu));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }
}