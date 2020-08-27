using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para Las polizas por localidades
/// </summary>
public class AdministrarPolizaLocalidad
{
    /// <summary>
    /// Lista todas las polizas por localidades del sistema
    /// </summary>
    /// <returns>Tabla con todas las polizas por localidades</returns>
    public static DataTable ListarPolizasLocalidades()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPolizaLocalidad.sp_ListarNewPolizasLocalidades();
        return dt;
    }

    /// <summary>
    /// Inserta la información de una poliza por localidad
    /// </summary>
    /// <param name="PolizaIdentificador">Poliza</param>
    /// <param name="DepartamentoIdentificador">Departamento</param>
    public static void InsertarPolizaLocalidad(long PolizaIdentificador, long DepartamentoIdentificador)
    {
        DAOAdministrarPolizaLocalidad.sp_InsertarNewPolizaLocalidad(PolizaIdentificador, DepartamentoIdentificador);
    }

    /// <summary>
    /// Consulta la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza localidad</returns>
    public static DataTable ConsultarPolizaLocalidad(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPolizaLocalidad.sp_ConsultarNewPolizaLocalidad(PolizaLocalidadIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una poliza por localidad por su ID para ser modificado
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de poliza localidad para ser modificado</returns>
    public static DataTable ConsultarPolizaLocalidadModificar(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPolizaLocalidad.sp_ConsultarNewPolizaLocalidadModificar(PolizaLocalidadIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <param name="PolizaIdentificador">Nuevo poliza</param>
    /// <param name="DepartamentoIdentificador">Nuevo departamento</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarPolizaLocalidad(long PolizaLocalidadIdentificador, long PolizaIdentificador, long DepartamentoIdentificador)
    {
        DAOAdministrarPolizaLocalidad.sp_ActualizarNewPolizaLocalidad(PolizaLocalidadIdentificador, PolizaIdentificador, DepartamentoIdentificador);
    }

    /// <summary>
    /// Elimina la información de una poliza por localidad por su ID
    /// </summary>
    /// <param name="PolizaLocalidadIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarPolizaLocalidad(long PolizaLocalidadIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarPolizaLocalidad.sp_EliminarNewPolizaLocalidad(PolizaLocalidadIdentificador);
        return dt;
    }
}
