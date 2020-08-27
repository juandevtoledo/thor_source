using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarProducto
{
    public static DataTable ListarProductos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarProducto.sp_ListarNewProductos();
        return dt;
    }
    public static void InsertarProducto(int companiaID, string nombreProducto, int? mesesGraciaProducto, int cumulo, int mesRecuperacion, int prioridadPago, int prioridadDevolucion,  int? estadoProducto)
    {

        DAOAdministrarProducto.sp_InsertarNewProducto(companiaID, nombreProducto, mesesGraciaProducto, cumulo, mesRecuperacion, prioridadPago, prioridadDevolucion, estadoProducto);
    }
 
    public static DataTable ConsultarProductoModificar(int productoID)
    {
        DataTable dt = new DataTable();
        //sp_ConsultarCompaniaModificar
        dt = DAOAdministrarProducto.sp_ConsultarNewProductoModificar(productoID);
        return dt;
    }
    public static void ModificarProducto(int productoID, int companiaID, string nombreProducto, int? mesesGraciaProducto, int cumulo, int mesRecuperacion, int prioridadPago, int prioridadDevolucion, int? estadoProducto)
    {
        DAOAdministrarProducto.sp_ActualizarNewProducto( productoID, companiaID,  nombreProducto, mesesGraciaProducto, cumulo, mesRecuperacion, prioridadPago, prioridadDevolucion, estadoProducto);
    }
    public static DataTable EliminarProducto(int productoID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarProducto.sp_EliminarNewProducto(productoID);
        return dt;
    }


    public static DataTable BuscarProducto(int id, string compania, string producto, string estado)
    {
        DataTable dtBuscar = new DataTable();
        dtBuscar = DAOAdministrarProducto.sp_BuscarNewProducto(id, compania, producto, estado);
        return dtBuscar;
    }
}