using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


/// <summary>
/// Descripción breve de Control
/// </summary>
public class Control
{
    public Control()
    {

    }

    public static DataTable ListarRestriccionesUsuario(int perfil, int cedula)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarRestriccionesUsuario(perfil, cedula);
        return dt;
    }

    public static DataTable ListarUsuarios()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarUsuarios();
        return dt;
    }

    public static DataTable MostrarAgencia(int dep_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.MostrarAgencia(dep_Id);
        return dt;
    }

    //Consultar usuario para modificar
    public static DataTable ConsultarUsuarioModificar(int usuario)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarUsuarioModificar(usuario);
        return dt;
    }

    public static int InsertarUsuario(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int dep_Id,
        int ciu_Id, int age_Id, int car_Id, int niv_Id, string usuario, string contrasena, int est_Id)
    {

        return DAOControl.InsertarUsuario(cedula, primerNombre, segundoNombre, primerApellido, segundoApellido, dep_Id,
         ciu_Id, age_Id, car_Id, niv_Id, usuario, contrasena, est_Id);
    }

    public static int ModificarUsuario(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int dep_Id,
        int ciu_Id, int age_Id, int car_Id, int niv_Id, string usuario, string contrasena, int est_Id)
    {
        return DAOControl.ModificarUsuario(cedula, primerNombre, segundoNombre, primerApellido, segundoApellido, dep_Id,
        ciu_Id, age_Id, car_Id, niv_Id, usuario, contrasena, est_Id);
    }

    public static DataTable EliminarUsuario(int usuario)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.EliminarUsuario(usuario);
        return dt;
    }

    public static DataTable ConsultarUsuario(int usuario)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarUsuario(usuario);
        return dt;
    }

    //consultar submenu
    public static DataTable ConsultarSubmenu(string perfil, string cedula)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarSubmenu(perfil, cedula);
        return dt;
    }
    // conusltar menu
    public static DataTable ConsultarMenu()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarMenu();
        return dt;
    }

    public static DataTable MostrarDependencia()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.MostrarDependencia();
        return dt;
    }

    public static DataTable ListarMenu()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarMenu();
        return dt;
    }

    public static DataTable EliminarMenu(int menu)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.EliminarMenu(menu);
        return dt;
    }

    public static void InsertarMenu(string txtNombre, string ddlDependencia, string txtEnlace, string txtAlias, string txtRuta)
    {
        DAOControl.InsertarMenu(txtNombre, ddlDependencia, txtEnlace, txtAlias, txtRuta);
    }

    public static DataTable ConsultarMenu(int menu)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarMenu(menu);
        return dt;
    }

    public static void ModificarMenu(string txtmen_Id, string txtNombre, string ddlDependencia, string txtEnlace, string txtAlias, string txtRuta)
    {
        DAOControl.ModificarMenu(txtmen_Id, txtNombre, ddlDependencia, txtEnlace, txtAlias, txtRuta);
    }

    public static DataTable ConsultarBtnMenu(int men_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarBtnMenu(men_Id);
        return dt;
    }

    public static int AsignarBtnMenu(int men_Id, string txtNombreBtn, string txtIdBtn, string txtIdPadre)
    {
       return DAOControl.AsignarBtnMenu(men_Id, txtNombreBtn, txtIdBtn, txtIdPadre);       
    }

    public static void EliminarBoton(int btn_Id)
    {
        DAOControl.EliminarBoton(btn_Id); 
    }

    public static DataTable ListarFormularioAsignados()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarFormularioAsignados();
        return dt;
    }

    public static DataTable ListarBotonesFormulario(string men_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarBotonesFormulario(men_Id);
        return dt;
    }
    
    public static DataTable ListarBotonesUsuario(int cedula, string men_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarBotonesUsuario(cedula, men_Id);
        return dt;
    }

    public static int EliminarBotonUsuario(int con_Id, int menBtn_Id)
    {
        return DAOControl.EliminarBotonUsuario(con_Id, menBtn_Id);
    }

    public static int AsignarPermisoUsuario(int per_Id, string men_Id, string btn_Id)
    {
       return DAOControl.AsignarPermisoUsuario(per_Id, men_Id, btn_Id);
    }

    public static DataTable ListarCargos()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarCargos();
        return dt;
    }

    public static DataTable ListarNieles()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarNieles();
        return dt;
    }

    public static DataTable ListarEstados()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ListarEstados();
        return dt;
    }

    public static DataTable ConsultarCiudad(double dep_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarCiudad(dep_Id);
        return dt;
    }

    public static DataTable ConsultarRutas()
    {
        DataTable dt = new DataTable();
        dt = DAOControl.ConsultarRutas();
        return dt;
    }


    public static int VerificarClave(string usuario, string claveAnt)
    {
        return DAOControl.VerificarClave(usuario, claveAnt);
    }

    /// Encripta una cadena
    public static string Encriptar(string _cadenaAencriptar)
    {
        string result = string.Empty;
        byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
        result = Convert.ToBase64String(encryted);
        return result;
    }

    /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
    public static string DesEncriptar(string _cadenaAdesencriptar)
    {
        string result = string.Empty;
        byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
        //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        result = System.Text.Encoding.Unicode.GetString(decryted);
        return result;
    }

    public static int CambiarClave(string usuario, string claveEncripNue)
    {
        return DAOControl.CambiarClave(usuario, claveEncripNue);
    }
}
