using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para Los parentescos beneficiarios
/// </summary>
public class AdministrarParentescoBeneficiario
{
    /// <summary>
    /// Lista todos los parentescos beneficiarios del sistema
    /// </summary>
    /// <returns>Tabla con todos los parentescos beneficiarios</returns>
    public static DataTable ListarParentescoBeneficiarios()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoBeneficiario.sp_ListarNewParentescosBeneficiarios();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un parentesco beneficiario
    /// </summary>
    /// <param name="parentescoIdentificador">Parentesco</param>
    /// <param name="productorIdentificador">Producto</param>
    public static void InsertarParentescoBeneficiario(long parentescoIdentificador, long productorIdentificador)
    {
        DAOAdministrarParentescoBeneficiario.sp_InsertarNewParentescoBeneficiario(parentescoIdentificador, productorIdentificador);
    }

    /// <summary>
    /// Consulta la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco beneficiario</returns>
    public static DataTable ConsultarParentescoBeneficiario(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoBeneficiario.sp_ConsultarNewParentescoBeneficiario(parentescoProductoIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un parentesco beneficiario por su ID para ser modificado
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco beneficiario para ser modificado</returns>
    public static DataTable ConsultarParentescoBeneficiarioModificar(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoBeneficiario.sp_ConsultarNewParentescoBeneficiarioModificar(parentescoProductoIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <param name="parentescoIdentificador">Nuevo parentesco</param>
    /// <param name="productorIdentificador">Nuevo producto</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarParentescoBeneficiario(long parentescoProductoIdentificador, long parentescoIdentificador, long productorIdentificador)
    {
        DAOAdministrarParentescoBeneficiario.sp_ActualizarNewParentescoBeneficiario(parentescoProductoIdentificador, parentescoIdentificador, productorIdentificador);
    }

    /// <summary>
    /// Elimina la información de un parentesco beneficiario por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarParentescoBeneficiario(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoBeneficiario.sp_EliminarNewParentescoBeneficiario(parentescoProductoIdentificador);
        return dt;
    }
}
