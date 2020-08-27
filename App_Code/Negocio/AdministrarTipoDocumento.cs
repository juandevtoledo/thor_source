using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los tipos de documentos
/// </summary>
public class AdministrarTipoDocumento
{
    /// <summary>
    /// Lista todos los tipos de documentos del sistema
    /// </summary>
    /// <returns>Tabla con todos los tipos de documentos</returns>
    public static DataTable ListarTiposDocumentos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDocumento.sp_ListarNewTiposDocumentos();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo de documento
    /// </summary>
    /// <param name="tipoDocumentoNombre">Nombre de tipo de documento</param>
    public static void InsertarTipoDocumento(string tipoDocumentoNombre)
    {
        DAOAdministrarTipoDocumento.sp_InsertarNewTipoDocumento(tipoDocumentoNombre);
    }

    /// <summary>
    /// Consulta la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de documento</returns>
    public static DataTable ConsultarTipoDocumento(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDocumento.sp_ConsultarNewTipoDocumento(tipoDocumentoIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo de documento por su ID para ser modificado
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo de documento para ser modificado</returns>
    public static DataTable ConsultarTipoDocumentoModificar(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDocumento.sp_ConsultarNewTipoDocumentoModificar(tipoDocumentoIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <param name="tipoDocumentoNombre">Nuevo nombre de tipo de documento</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarTipoDocumento(long tipoDocumentoIdentificador, string tipoDocumentoNombre)
    {
        DAOAdministrarTipoDocumento.sp_ActualizarNewTipoDocumento(tipoDocumentoIdentificador, tipoDocumentoNombre);
    }

    /// <summary>
    /// Elimina la información de un tipo de documento por su ID
    /// </summary>
    /// <param name="tipoDocumentoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarTipoDocumento(long tipoDocumentoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoDocumento.sp_EliminarNewTipoDocumento(tipoDocumentoIdentificador);
        return dt;
    }
}
