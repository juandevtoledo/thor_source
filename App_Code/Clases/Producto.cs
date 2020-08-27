using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Producto
/// </summary>
public class Producto
{
    public static FrameworkEntidades entidades = new FrameworkEntidades();

    protected string idProducto;
    public string IdProducto { get; set; }

    protected string idCompania;
    public string IdCompania { get; set; }

    protected string nombre;
    public string Nombre { get; set; }

//    public DataTable ConsultarProducto(int com_Id)
//    {
//        DataTable dt = new DataTable();
//        dt = PrecargueProduccion.ProductoPorCompaniaPrecargue(com_Id);
//        return dt;
//    }
}