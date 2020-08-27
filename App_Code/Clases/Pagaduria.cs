using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Pagaduria
/// </summary>
public class Pagaduria
{
    public  FrameworkEntidades entidades = new FrameworkEntidades();
    //PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    public UsuarioControl usuarioSistema = new UsuarioControl();
    protected string codigo;
    public string Codidog { get; set; }

    protected string nombre;
    public string Nombre { get; set; }

    protected string idDepartamento;
    public string IdDepartamento { get; set; }

    protected string idCiudad;
    public string IdCiudad { get; set; }

    protected string direccion;
    public string Direccion { get; set; }

    protected string telefono;
    public string Telefono { get; set; }

    protected string idProducto;
    public string IdProducto { get; set; }

    protected string nit;
    public string Nit { get; set; }

    public DataTable ConsultarPagadurias()
    {
        DataTable dt = new DataTable();
        string[] nombreCampos = new string[9] { "paga_Id", "paga_Nombre", "dep_Id", "ciu_Id", "paga_CodigoAnterior", "paga_Direccion", "paga_Telefono", "paga_PorcentajeParticipacion", "paga_Identificacion" };
        dt = entidades.Consultar("Pagaduria", nombreCampos, "dep_Id", usuarioSistema.IdDepartamento);
        return dt;
    }
}