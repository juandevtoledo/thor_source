using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Tercero
/// </summary>
public abstract class Tercero
{
    
    protected int tipoDocumento;
    public int TipoDocumento { get; set; }

    protected string tipoDocumentoNombre;
    public string TipoDocumentoNombre { get; set; }

    protected string numeroDocumento;
    public string NumeroDocumento { get; set; }
    
    protected string numeroIdentificacion;
    public string NumeroIdentificacion { get; set; }

    protected string nombreDocumento;
    public string NombreDocumento { get; set; }
        
    protected string nombres;
    public string Nombres { get; set; }

    protected string apellidos;
    public string Apellidos { get; set; }

    protected DateTime fechaNacimiento;
    public DateTime FechaNacimiento { get; set; }
    
    protected string correoElectronico;
    public string CorreoElectronico { get; set; }

    protected string sexo;
    public string Sexo { get; set; }

    protected int departamento;
    public int Departamento { get; set; }

    protected string departamentoNombre;
    public string DepartamentoNombre { get; set; }

    protected int ciudad;
    public int Ciudad { get; set; }

    protected string ciudadNombre;
    public string CiudadNombre { get; set; }

    protected int ocupacion;
    public int Ocupacion { get; set; }

    protected string ocupacionNombre;
    public string OcupacionNombre { get; set; }

    protected string celular;
    public string Celular { get; set; }
    
    protected string telefono1;
    public string Telefono1 { get; set; }

    protected string direccion;
    public string Direccion { get; set; }
    
    protected string telefono2;
    public string Telefono2 { get; set; }

    protected int estadoCivil;
    public int EstadoCivil { get; set; }

    protected string estadoCivilNombre;
    public string EstadoCivilNombre { get; set; }

    protected int lugarTrabajo;
    public int LugarTrabajo { get; set; }

    protected int edad;
    public int Edad { get; set; }

    protected int porcentaje;
    public int Porcentaje { get; set; }

    protected string parentesco;
    public string Parentesco { get; set; }

    protected string mensaje;
    public string Mensaje { get; set; }

    protected int habeasData;
    public int HabeasData { get; set; }
            
}