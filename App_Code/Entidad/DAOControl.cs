using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOControl
/// </summary>
public class DAOControl
{
    //==========================================================
    //======================== USUARIO =========================
    //==========================================================

    // Lista las restricciones de los usuarios
    public static DataTable ListarRestriccionesUsuario(int perfil, int cedula)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarRestriccionesUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@perfil", perfil));
        cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Lista todo los usuarios del sistema
    public static DataTable ListarUsuarios()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //=============== BUSCADOR USUARIO ===============

    // Buscar usuario por cédula
    public static DataTable BuscarPorCedula(int con_Id)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarUsuarioCedula", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Buscar usuario por nombre
    public static DataTable BuscarPorNombre(string nombre)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarUsuarioNombre", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Buscar usuario por usuario
    public static DataTable BuscarPorUsuario(string usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarUsuarioUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //=============== BUSCADOR USUARIO ===============

    // LLena ddl de agencia por departamento
    public static DataTable MostrarAgencia(int dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarAgenciaPorDepto", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Consultar usuario seleccionado 
    public static DataTable ConsultarUsuario(int usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    
    public static DataTable ConsultarUsuarioModificar(int usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioModificar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Guarda el nuevo usuario en la bd 
    public static int InsertarUsuario(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int dep_Id,
        int ciu_Id, int age_Id, int car_Id,  int niv_Id, string usuario, string contrasena, int est_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_Insertarusuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", cedula));
        cmd.Parameters.Add(new SqlParameter("@con_PrimerNombre", primerNombre.ToUpper()));
        cmd.Parameters.Add(new SqlParameter("@con_SegundoNombre", segundoNombre.ToUpper()));
        cmd.Parameters.Add(new SqlParameter("@con_PrimerApellido", primerApellido.ToUpper()));
        cmd.Parameters.Add(new SqlParameter("@con_SegundoApellido", segundoApellido.ToUpper()));
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.Parameters.Add(new SqlParameter("@ciu_Id", ciu_Id));
        cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
        cmd.Parameters.Add(new SqlParameter("@car_Id", car_Id));
        cmd.Parameters.Add(new SqlParameter("@niv_Id", niv_Id));
        cmd.Parameters.Add(new SqlParameter("@con_Usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@con_Password", contrasena));
        cmd.Parameters.Add(new SqlParameter("@est_Id", est_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
      }

    public static int ModificarUsuario(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int dep_Id,
        int ciu_Id, int age_Id, int car_Id, int niv_Id, string usuario, string contrasena, int est_Id)
    {
            FrameworkEntidades.cnx = new SqlConnection( FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario",  FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@con_Id", cedula));
            cmd.Parameters.Add(new SqlParameter("@con_PrimerNombre", primerNombre.ToUpper()));
            cmd.Parameters.Add(new SqlParameter("@con_SegundoNombre", segundoNombre.ToUpper()));
            cmd.Parameters.Add(new SqlParameter("@con_PrimerApellido", primerApellido.ToUpper()));
            cmd.Parameters.Add(new SqlParameter("@con_SegundoApellido", segundoApellido.ToUpper()));
            cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
            cmd.Parameters.Add(new SqlParameter("@ciu_Id", ciu_Id));
            cmd.Parameters.Add(new SqlParameter("@age_Id", age_Id));
            cmd.Parameters.Add(new SqlParameter("@car_Id", car_Id));
            cmd.Parameters.Add(new SqlParameter("@niv_Id", niv_Id));
            cmd.Parameters.Add(new SqlParameter("@con_Usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@con_Password", contrasena));
            cmd.Parameters.Add(new SqlParameter("@est_Id", est_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            int registros = cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();
            return registros;    
    }

    // Elimina el usuario seleccionado
    public static DataTable EliminarUsuario(int usuario)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", usuario));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Consulta los submenus al que tiene permiso el usuario que inicio la sesión
    public static DataTable ConsultarSubmenu(string perfil, string cedula)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        //string consulta;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSubmenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@perfil", perfil));
        cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Consulta los menus al que tiene permiso el usuario que inicio la sesión
    public static DataTable ConsultarMenu()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMenuPorDependencia", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable MostrarDependencia()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarDependenciaDdl", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Lista los formularios creados en el modulo menú
    public static DataTable ListarFormularioAsignados()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarFormularioAsignados", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Lista los botones que se le asignaron al formulario para la asignacon de permisos
    public static DataTable ListarBotonesFormulario(string men_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarBotonesFormulario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Lista los botones  que tiene asignado el usuario
    public static DataTable ListarBotonesUsuario(int cedula, string men_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarBotonesUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Elimina los botones que el usuario tiene asignado 
    public static int EliminarBotonUsuario(int con_Id, int menBtn_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarBotonUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@con_Id", con_Id));
        cmd.Parameters.Add(new SqlParameter("@menBtn_Id", menBtn_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    
    }

    // Guarda el permiso asginado al usuario 
    public static int AsignarPermisoUsuario(int per_Id, string men_Id, string btn_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarPermisoUsuario", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@per_Id", per_Id));
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.Parameters.Add(new SqlParameter("@btn_Id", btn_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    //  Llena ddl con el listado de los cargos 
    public static DataTable ListarCargos()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarCargos", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Llena ddl con la lista de los niveles 
    public static DataTable ListarNieles()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarNiveles", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // llena ddl con la lista de los estados  de usuario
    public static DataTable ListarEstados()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarEstadoControlUsuarios", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarCiudad(double dep_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarCiudadPorDepartamento", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dep_Id", dep_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //==========================================================
    //======================== USUARIO =========================
    //==========================================================


    //==========================================================
    //========================== MENU ==========================
    //==========================================================

    public static DataTable ListarMenu()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ListarMenu", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //=============== BUSCADOR MENU ===============

    public static DataTable BuscarPorMenu(string menu)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarMenuMenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@menu", menu));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable BuscarPordependencia(string dependencia)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_BuscarMenuDependencia", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@dependencia", dependencia));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    //=============== BUSCADOR MENU ===============

    public static void InsertarMenu(string txtNombre, string ddlDependencia, string txtEnlace, string txtAlias, string txtRuta)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertarMenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Nombre", txtNombre));
        cmd.Parameters.Add(new SqlParameter("@men_Dependencia", ddlDependencia));
        cmd.Parameters.Add(new SqlParameter("@men_Enlace", txtEnlace));
        cmd.Parameters.Add(new SqlParameter("@men_Alias", txtAlias));
        cmd.Parameters.Add(new SqlParameter("@men_Ruta", txtRuta));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        FrameworkEntidades.cnx.Close();
    }

    public static DataTable ConsultarMenu(int menu)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarMenuEditar", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Id", menu));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static string ModificarMenu(string txtmen_Id, string txtNombre, string ddlDependencia, string txtEnlace, string txtAlias, string txtRuta)
    {
        string rpta = "";
        try
        {
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_ActualizarMenu", FrameworkEntidades.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@men_Id", txtmen_Id));
            cmd.Parameters.Add(new SqlParameter("@men_Nombre", txtNombre));
            cmd.Parameters.Add(new SqlParameter("@men_Dependencia", ddlDependencia));
            cmd.Parameters.Add(new SqlParameter("@men_Enlace", txtEnlace));
            cmd.Parameters.Add(new SqlParameter("@men_Alias", txtAlias));
            cmd.Parameters.Add(new SqlParameter("@men_Ruta", txtRuta));

            //Se ejecuta el comando
            rpta = cmd.ExecuteNonQuery() == 1 ? "No se actualizo el usuario" : "OK";
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

    public static DataTable EliminarMenu(int menu)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarMenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Id", menu));
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    public static DataTable ConsultarBotones(string perfil, string cedula)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarSubmenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@per_Id", perfil));
        cmd.Parameters.Add(new SqlParameter("@con_Id", cedula));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Consulta los botones que tiene el menu o formulario seleccionado
    public static DataTable ConsultarBtnMenu(int men_Id)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarBtnMenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    // Guardea la asignacion del boton al menu o formulario seleccionado
    public static int AsignarBtnMenu(int men_Id, string txtNombreBtn, string txtIdBtn, string txtIdPadre)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_AsignarBtnMenu", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@men_Id", men_Id));
        cmd.Parameters.Add(new SqlParameter("@btn_Nombre", txtNombreBtn));
        cmd.Parameters.Add(new SqlParameter("@btn_IdNombre", txtIdBtn));
        cmd.Parameters.Add(new SqlParameter("@btn_IdPadre", txtIdPadre));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        cmd.ExecuteReader();
        FrameworkEntidades.cnx.Close();
        return registros;
    }

    // Elimina el boton seleccionado
    public static void EliminarBoton(int btn_Id)
    {
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_EliminarBoton", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@btn_Id", btn_Id));
        cmd.CommandType = CommandType.StoredProcedure;
        int registros = cmd.ExecuteNonQuery();
        cmd.ExecuteReader();
        FrameworkEntidades.cnx.Close();
    }

    //==========================================================
    //========================== MENU ==========================
    //==========================================================  

    public static DataTable ConsultarRutas()
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_ConsultarRutas", FrameworkEntidades.cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        return dt;
    }

    internal static int VerificarClave(string usuario, string claveAnt)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_VerificarClave", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@clave", claveAnt));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        int dato = 0;
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            dato = int.Parse(row["con_Id"].ToString());
        }
        return dato;
    }

    internal static int CambiarClave(string usuario, string claveEncripNue)
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();
        SqlCommand cmd = new SqlCommand("sp_CambiarClave", FrameworkEntidades.cnx);
        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
        cmd.Parameters.Add(new SqlParameter("@clave", claveEncripNue));
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        FrameworkEntidades.cnx.Close();
        int dato = 0;
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            dato = int.Parse(row["con_Id"].ToString());
        }
        return dato;
    }
}