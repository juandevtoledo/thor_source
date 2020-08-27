using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para los parentescos por productos
/// </summary>
public class AdministrarParentescoProducto
{
    /// <summary>
    /// Lista todos los parentescos por productos del sistema
    /// </summary>
    /// <returns>Tabla con todos los parentescos por productos</returns>
    public static DataTable ListarParentescosProductos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoProducto.sp_ListarNewParentescosPorProductos();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un parentesco por  producto
    /// </summary>
    /// <param name="parentescoIdentificador">Parentesco</param>
    /// <param name="productorIdentificador">Producto</param>
    public static void InsertarParentescoProducto(long parentescoIdentificador, long productorIdentificador)
    {
        DAOAdministrarParentescoProducto.sp_InsertarNewParentescoPorProducto(parentescoIdentificador, productorIdentificador);
    }

    /// <summary>
    /// Consulta la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco por producto</returns>
    public static DataTable ConsultarParentescoProducto(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoProducto.sp_ConsultarNewParentescoPorProducto(parentescoProductoIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un parentesco por  producto por su ID para ser modificado
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de parentesco por producto para ser modificado</returns>
    public static DataTable ConsultarParentescoProductoModificar(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoProducto.sp_ConsultarNewParentescoPorProductoModificar(parentescoProductoIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <param name="parentescoIdentificador">Nuevo parentesco</param>
    /// <param name="productorIdentificador">Nuevo producto</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarParentescoProducto(long parentescoProductoIdentificador, long parentescoIdentificador, long productorIdentificador)
    {
        DAOAdministrarParentescoProducto.sp_ActualizarNewParentescoPorProducto(parentescoProductoIdentificador, parentescoIdentificador, productorIdentificador);
    }

    /// <summary>
    /// Elimina la información de un parentesco por  producto por su ID
    /// </summary>
    /// <param name="parentescoProductoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarParentescoProducto(long parentescoProductoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarParentescoProducto.sp_EliminarNewParentescoPorProducto(parentescoProductoIdentificador);
        return dt;
    }
}
