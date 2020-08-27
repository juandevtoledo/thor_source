using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Certificado
/// </summary>
public class Certificado
{
    public static FrameworkEntidades entidades = new FrameworkEntidades();

    protected string numeroCertificado;
    public string NumeroCertificado { get; set; }

    protected string cedula;
    public string Cedula { get; set; }

    protected string nombre;
    public string Nombre { get; set; }

    protected string apellido;
    public string Apellido { get; set; }

    protected DateTime fechaExpedicion;
    public DateTime FechaExpedicion { get; set; }

    protected DateTime vigencia;
    public DateTime Vigencia { get; set; }

    protected string cedulaAsesor;
    public string CedulaAsesor { get; set; }

    protected string nombreAsesor;
    public string NombreAsesor { get; set; }

    protected string periodoPagoNombre;
    public string PeriodoPagoNombre { get; set; }

    protected string convenioNombre;
    public string ConvenioNombre { get; set; }

    protected string pagaduria;
    public string Pagaduria { get; set; }

    protected string convenio;
    public string Convenio { get; set; }

    protected string peso;
    public string Peso { get; set; }

    protected string estatura;
    public string Estatura { get; set; }

    //cristian
    protected string hojaServicioPrincipal;
    public string HojaServicioPrincipal { get; set; }

    //cristian
    protected string hojaServicioConyuge;
    public string HojaServicioConyuge { get; set; }

    //cristian
    protected string hojaServicioOtrosAsegurados;
    public string HojaServicioOtrosAsegurados { get; set; }

    //critian
    protected int ciudad;
    public int Ciudad { get; set; }

    //critian
    protected int causalDevolucion;
    public int CausalDevolucion { get; set; }

    //critian
    protected int grupoDevolucion;
    public int GrupoDevolucion { get; set; }

    //critian
    protected int prima;
    public int Prima { get; set; }

    //critian
    protected string observacion;
    public string Observacion { get; set; }

    protected DateTime fechaDigitacion;
    public DateTime FechaDigitacion { get; set; }

    protected DateTime fechaRecibido;
    public DateTime FechaRecibido { get; set; }

    protected string numeroPlanillaRecibo;
    public string NumeroPlanillaRecibo { get; set; }

    protected string compania;
    public string Compania { get; set; }

    protected string producto;
    public string Producto { get; set; }

    protected string agencia;
    public string Agencia { get; set; }

    protected string estado;
    public string Estado { get; set; }

    protected string numeroFolios;
    public string NumeroFolios { get; set; }

    protected string hojaServicio1;
    public string HojaServicio1 { get; set; }

    protected string hojaServicio2;
    public string HojaServicio2 { get; set; }

    protected string hojaServicio3;
    public string HojaServicio3 { get; set; }

    protected string anexoConversion;
    public string AnexoConversion { get; set; }

    protected string designacionBeneficiarios;
    public string DesignacionBeneficiarios { get; set; }

    protected string periodoPago;
    public string PeriodoPago { get; set; }

    protected string numeroPoliza;
    public string NumeroPoliza { get; set; }

    protected string localidad;
    public string Localidad { get; set; }

    protected string edad;
    public string Edad { get; set; }

    protected string plan;
    public string Plan { get; set; }

    //Sebastian
    protected int consecutivo;
    public int Consecutivo { get; set; }

    //sebastian
    protected string conyuge;
    public string Conyuge { get; set; }

    //sebastian
    protected string declaracion;
    public string Declaracion { get; set; }

    //sebastian 
    protected string declaracionEnfe;
    public string DeclaracionEnfe { get; set; }

    //sebastian
    protected string estaturaprincipal;
    public string EstaturaPrincipal { get; set; }

    //sebastian
    protected string extraPrima;
    public string ExtraPrima { get; set; }

    //sebastian 
    protected int idConyuge;
    public int IdConyuge { get; set; }

    //sebastian
    protected string movimiento;
    public string Movimiento { get; set; }

    //sebastian
    protected string pesoPrincipal;
    public string PesoPrincipal { get; set; }

    //sebastian 
    protected int tipoMovimiento;
    public int TipoMovimiento { get; set; }

    //sebastian 
    protected int momento;
    public int Momento { get; set; }

    protected string plantel;
    public string Plantel { get; set; }

    protected int soporteFisico;
    public int SoporteFisico { get; set; }

    protected string migracion;
    public string Migracion { get; set; }


    //public void InsertarCertificado(int mesProduccion, int migracion, int consecutivo, int cer_IdAnterior)
    //{
    //    entidades.SPInsertarCertificado(mesProduccion, migracion, consecutivo, cer_IdAnterior);
    //}
    //public void ConsultarCertificado()
    //{
    //    entidades.SPConsultarCertificado();
    //}
}

