using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para las agencias
/// </summary>
public class AdministrarAgencia
{
    /// <summary>
    /// Lista todas las agencias del sistema
    /// </summary>
    /// <returns>Tabla con todas las agencias</returns>
    public static DataTable ListarAgencias()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_ListarNewAgencias();
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
    public static void InsertarAgencia(string agenciaNombre, string agenciaDireccion, string agenciaTelefono, string agenciaEmail, string agenciaDirector, long? departamentoIdentificador, long? ciudadIdentificador)
    {
        DAOAdministrarAgencia.sp_InsertarNewAgencia(agenciaNombre, agenciaDireccion, agenciaTelefono, agenciaEmail, agenciaDirector, departamentoIdentificador, ciudadIdentificador);
    }

    /// <summary>
    /// Consulta la información de una agencia por su ID
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de agencia</returns>
    public static DataTable ConsultarAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_ConsultarNewAgencia(agenciaIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una agencia por su ID para ser modificado
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de agencia para ser modificado</returns>
    public static DataTable ConsultarAgenciaModificar(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_ConsultarNewAgenciaModificar(agenciaIdentificador);
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
    public static void ModificarAgencia(long agenciaIdentificador, string agenciaNombre, string agenciaDireccion, string agenciaTelefono, string agenciaEmail, string agenciaDirector, long? departamentoIdentificador, long? ciudadIdentificador)
    {
        DAOAdministrarAgencia.sp_ActualizarNewAgencia(agenciaIdentificador, agenciaNombre, agenciaDireccion, agenciaTelefono, agenciaEmail, agenciaDirector, departamentoIdentificador, ciudadIdentificador);
    }

    /// <summary>
    /// Elimina la información de una agencia por su ID
    /// </summary>
    /// <param name="agenciaIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_EliminarNewAgencia(agenciaIdentificador);
        return dt;
    }

    public static DataTable ConsultarLocalidadesAgencia(long agenciaIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_ConsultarLocalidadesAgencia(agenciaIdentificador);
        return dt;
    }

    public static int AsignarLocalidadAgencia(int age_Id, int dep_Id)
    {
        return DAOAdministrarAgencia.sp_AsignarLocalidadAgencia(age_Id, dep_Id);
    }

    public static int EliminarLocalidadAgencia(int age_Id, int dep_Id)
    {
        return DAOAdministrarAgencia.sp_EliminarLocalidadAgencia(age_Id, dep_Id);
    }

    public static DataTable BuscarAgencia(int codigo, string nombre, string direccion, string telefono)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarAgencia.sp_BuscarAgencia(codigo, nombre, direccion, telefono);
        return dt;
    }
}