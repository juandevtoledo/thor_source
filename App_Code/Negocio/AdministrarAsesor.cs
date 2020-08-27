using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los asesores
/// </summary>
public class AdministrarAsesor
{
    /// <summary>
    /// Lista todos los asesores del sistema
    /// </summary>
    /// <returns>Tabla con todos los asesores</returns>
    public static DataTable ListarAsesores()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ListarNewAsesores();
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
    public static void InsertarAsesor(long? asesorCodigo, string asesorApellidos, string asesorNombres, long? departamentoIdentificador, long? compañiaIdentificador, string asesorActivo, string asesorFuncionario)
    {
        DAOAdministrarAsesor.sp_InsertarNewAsesor(asesorCodigo, asesorApellidos, asesorNombres, departamentoIdentificador, compañiaIdentificador, asesorActivo, asesorFuncionario);
    }

    /// <summary>
    /// Consulta la información de un asesor por su ID
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de asesor</returns>
    public static DataTable ConsultarAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ConsultarNewAsesor(asesorIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un asesor por su ID para ser modificado
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de asesor para ser modificado</returns>
    public static DataTable ConsultarAsesorModificar(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ConsultarNewAsesorModificar(asesorIdentificador);
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
    public static void ModificarAsesor(long asesorIdentificador, long? asesorCodigo, string asesorApellidos, string asesorNombres, long? departamentoIdentificador, long? compañiaIdentificador, string asesorActivo, string asesorFuncionario)
    {
        DAOAdministrarAsesor.sp_ActualizarNewAsesor(asesorIdentificador, asesorCodigo, asesorApellidos, asesorNombres, departamentoIdentificador, compañiaIdentificador, asesorActivo, asesorFuncionario);
    }

    /// <summary>
    /// Elimina la información de un asesor por su ID
    /// </summary>
    /// <param name="asesorIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_EliminarNewAsesor(asesorIdentificador);
        return dt;
    }

    public static DataTable ConsultarProductoAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ConsultarNewProductoAsesor(asesorIdentificador);
        return dt;
    }

    public static DataTable ConsultarProductosCompañia(int com_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ConsultarProductosCompañia(com_Id);
        return dt;
    }

    public static int AsignarProductoAsesor(int ase_Id, int pro_Id)
    {
        return DAOAdministrarAsesor.sp_AsignarProductoAsesor(ase_Id, pro_Id);
    }

    public static int EliminarProductoAsesor(int ase_Id, int pro_Id)
    {
        return DAOAdministrarAsesor.sp_EliminarProductoAsesor(ase_Id, pro_Id);
    }

    public static DataTable ConsultarLocalidadesAsesor(long asesorIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAsesor.sp_ConsultarLocalidadesAsesor(asesorIdentificador);
        return dt;
    }

    public static int AsignarLocalidadAsesor(int ase_Id, int dep_Id)
    {
        return DAOAdministrarAsesor.sp_AsignarLocalidadAsesor(ase_Id, dep_Id);
    }


    public static int EliminarLocalidadAsesor(int ase_Id, int dep_Id)
    {
        return DAOAdministrarAsesor.sp_EliminarLocalidadAsesor(ase_Id, dep_Id);
    }

    public static DataTable BuscarAsesor(int codigo, string nombre, string localidad, string estado)
    {
        DataTable dtBuscar = new DataTable();
        dtBuscar = DAOAdministrarAsesor.sp_BuscarNewAsesor(codigo, nombre, localidad, estado);
        return dtBuscar;
    }
}
