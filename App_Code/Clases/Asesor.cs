using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Asesor
/// </summary>
public class Asesor
{
    public  FrameworkEntidades entidades = new FrameworkEntidades();
    public UsuarioControl usuarioSistema = new UsuarioControl();
    //PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    protected int codigo;
    public int Codigo { get; set; }

    protected string apellidos;
    public string Apellidos { get; set; }
    
    protected string nombres;
    public string Nombres { get; set; }

    protected List<int> localidad = new List<int>();
    public List<int> Localidad { get; set; }


    //public Agencia agencia;


    public int InsertarAsesor(Asesor asesor)
    {
        int result = 0;
        List<string> valores = new List<string>();
        valores.Add(asesor.codigo.ToString());
        valores.Add("'" + asesor.apellidos + "'");
        valores.Add("'" + asesor.nombres + "'");
        //valores.Add(asesor.localidad.ToString());
        valores.Add(asesor.localidad.First().ToString());
        // Sigue la compañía del asesor como campo obligatorio se coloca 1 pero se debe evaluar
        valores.Add("'1'");
        valores.Add("''");
        valores.Add("''");
        result = entidades.Insertar("Asesor", valores);
        return result;
    }

    public int ActualizarAsesor(Asesor asesor)
    {
        string[] nombreCampos = new string[7] { "ase_Id", "ase_Apellidos", "ase_Nombres", "dep_Id", "com_Id", "ase_Activo", "ase_Funcionario" };
        int result = 0;
        List<string> valores = new List<string>();
        valores.Add(asesor.codigo.ToString());
        valores.Add("'" + asesor.apellidos + "'");
        valores.Add("'" + asesor.nombres + "'");
        //valores.Add(asesor.localidad.ToString());
        valores.Add(asesor.localidad.First().ToString());
        // Sigue la compañía del asesor como campo obligatorio se coloca 1 pero se debe evaluar
        valores.Add("'1'");
        valores.Add("''");
        valores.Add("''");
        result = entidades.Actualizar("Asesor", nombreCampos, valores, "ase_Id", asesor.codigo.ToString());
        return result;
    }

    public int EliminarAsesor(Asesor asesor)
    {
        int result = 0;
        result = entidades.Eliminar("Asesor", "ase_Id", asesor.Codigo.ToString());
        return result;
    }

    public DataTable ConsultarAsesor()
    {
        DataTable dt = new DataTable();
        string[] nombreCampos = new string[7] { "ase_Id", "ase_Apellidos", "ase_Nombres", "dep_Id", "com_Id", "ase_Activo", "ase_Funcionario" };
        dt = entidades.Consultar("Asesor", nombreCampos, "dep_Id", usuarioSistema.IdDepartamento);
        return dt;
    }

    public DataTable ConsultarAsesor(int dep_Id, int pro_Id)
    {
        //DataTable dt = new DataTable();
        //string[] nombreCampos = new string[7] { "ase_Id", "ase_Apellidos", "ase_Nombres", "dep_Id", "com_Id", "ase_Activo", "ase_Funcionario" };
        //dt = entidades.Consultar("Asesor", nombreCampos, "dep_Id", PrecargueProduccion.usuarioSistema.IdDepartamento);
        //return dt;

        // Utilizando procedimiento almacenado 
        DataTable dt = new DataTable();
        dt = entidades.spConsultarAsesorPorDepartamento(dep_Id, pro_Id);
        return dt;
    }
}