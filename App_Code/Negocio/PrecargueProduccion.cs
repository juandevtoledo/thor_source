using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de PrecargueProduccion
/// </summary>
public class PrecargueProduccion
{
    public FrameworkEntidades entidades = new FrameworkEntidades();

    public  UsuarioControl usuarioSistema = new UsuarioControl();
    public  Pagaduria pagaduria = new Pagaduria();
    public  Asesor asesor = new Asesor();
    public  Compania compania = new Compania();
    public  Producto producto = new Producto();
    public  Certificado certificado = new Certificado();
    public  Agencia agencia = new Agencia();
    //FrameworkEntidades objFrameworkEntidades = new FrameworkEntidades();

    public void CargarAgencia(string usuario)
    {
        usuarioSistema.NombreUsuario = usuario;
        usuarioSistema.ConsultarUsuarioControl();
    }

    public DataTable ConsultarAgencia(string nombreUsuario)
    {
        DataTable dt = new DataTable();
        dt = Agencia.ConsultarAgencia(nombreUsuario);
        return dt;
    }


    public DataTable CargarPagadurias()
    {
        DataTable dt = new DataTable();
        dt = pagaduria.ConsultarPagadurias();
        return dt;
    }

    public static DataTable ConsultarUsuario(string usuario)
    {
        DataTable dt = new DataTable();
        dt = FrameworkEntidades.ConsultarUsuarioSistema(usuario);
        return dt;
    }

    public DataTable CargarAsesor(int dep_Id, int pro_Id)
    {
        DataTable dt = new DataTable();
        dt = asesor.ConsultarAsesor(dep_Id, pro_Id);        
        return dt;
    }

    public DataTable CargarCompania()
    {
        DataTable dt = new DataTable();
        dt = compania.ConsultarCompanias();
        return dt;
    }

    public DataTable CargarProducto(int com_Id)
    {
        DataTable dt = new DataTable();
        dt = ProductoPorCompaniaPrecargue(com_Id);
        return dt;
    }

    //public void CrearNuevoCertificado(string cedula, string nombre, string apellido, string agencia, DateTime fechaExpedicion, string nombreAsesor, string pagaduria, DateTime fechaRecibido, string planillaBolivar, string estado, string numeroFolios)
    //{
    //    certificado.Cedula = cedula;
    //    certificado.Nombre = nombre;
    //    certificado.Apellido = apellido;
    //    certificado.Agencia = agencia;
    //    certificado.FechaExpedicion = fechaExpedicion;
    //    certificado.NombreAsesor = nombreAsesor;
    //    certificado.Pagaduria = pagaduria;
    //    certificado.FechaRecibido = fechaRecibido;
    //    certificado.NumeroPlanillaRecibo = planillaBolivar;
    //    certificado.Estado = estado;
    //    certificado.NumeroFolios = numeroFolios;
    //    certificado.InsertarCertificado();
    //}
    public void ConsultarNewCertificado(DateTime fechaExpedicion, string hojaServicio1, string hojaServicio2, string hojaServicio3, string anexoConvercion, string numeroCertificado, string cedula, DateTime vigencia)
    {
        certificado.FechaExpedicion = fechaExpedicion;
        certificado.HojaServicio1 = hojaServicio1;
        certificado.HojaServicio2 = hojaServicio2;
        certificado.HojaServicio3 = hojaServicio3;
        certificado.AnexoConversion = anexoConvercion;
        certificado.NumeroCertificado = numeroCertificado;
        certificado.Cedula = cedula;
        certificado.Vigencia = vigencia;
        entidades.SPConsultarCertificado();
    }
    public DataTable TraerCertificado(int age_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarCertificadoPorAgencia(age_Id);
        return dt;

    }
    public int EliminarRegistroPrecargue(int cer_Id)
    {
        return entidades.SPEliminarRegistroPrecargue(cer_Id);


    }
    public int ActualizarMomento(int cer_Id, int mom_Id)
    {

        return entidades.SPActualizarMomento(cer_Id, mom_Id);

    }
    //cristian
    public DataTable CargarTipoDevolucion()
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarTipoDevolucion();
        return dt;
    }
    //cristian
    public DataTable CargarEstadoCargue()
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarEstadoCargue();
        return dt;
    }
    //cristian
    public DataTable CargarCausalDevolucion(int tipo)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarCausalDevolucionPorTipo(tipo);
        return dt;
    }
    //cristian
    public static DataTable CalcularVigencia(int producto)
    {
        //FrameworkEntidades objFrameworkEntidades = new FrameworkEntidades();
        DataTable dt = new DataTable();
        dt = FrameworkEntidades.SPConsultarVigencia(producto);
        return dt;
    }
    //cristian
    public void CrearNuevoCertificado(string numeroCertificado, string cedula, string nombre, string apellido, string agencia, DateTime fechaExpedicion, string nombreAsesor, string pagaduria, DateTime fechaRecibido, string planillaBolivar, string estado, string numeroFolios, string compania, string localidad, string producto, string hojaServicioPrincipal, string hojaServicioConyuge, string hojaServicioOtrosAsegurados, int ciudad, int GrupoDevolucion, int causalDevolucion, int prima, string observaciones, string anexoConversion, DateTime vigencia, int soporteFisico, int mesProduccion, int migracion, int consecutivo, int cer_IdAnterior)
    {
        certificado.NumeroCertificado = numeroCertificado;
        certificado.Cedula = cedula;
        certificado.Nombre = nombre;
        certificado.Apellido = apellido;
        certificado.Agencia = agencia;
        certificado.FechaExpedicion = fechaExpedicion;
        certificado.NombreAsesor = nombreAsesor;
        certificado.Pagaduria = pagaduria;
        certificado.FechaRecibido = fechaRecibido;
        certificado.NumeroPlanillaRecibo = planillaBolivar;
        certificado.Estado = estado;
        certificado.NumeroFolios = numeroFolios;
        certificado.Compania = compania;
        certificado.Producto = producto;
        certificado.HojaServicioPrincipal = hojaServicioPrincipal;
        certificado.HojaServicioConyuge = hojaServicioConyuge;
        certificado.HojaServicioOtrosAsegurados = hojaServicioOtrosAsegurados;
        certificado.Ciudad = ciudad;
        certificado.Pagaduria = pagaduria;
        certificado.CausalDevolucion = causalDevolucion;
        certificado.GrupoDevolucion = GrupoDevolucion;
        certificado.Prima = prima;
        certificado.Observacion = observaciones;
        certificado.AnexoConversion = anexoConversion;
        certificado.Vigencia = vigencia;
        certificado.SoporteFisico = soporteFisico;
        certificado.Localidad = localidad;
        entidades.SPInsertarCertificado(mesProduccion, migracion, consecutivo, cer_IdAnterior, certificado);
    }
    public DataTable ProductoPorCompaniaPrecargue(int com_Id)
    {
        FrameworkEntidades objFrameworkEntidades = new FrameworkEntidades();
        DataTable dt = new DataTable();
        dt = objFrameworkEntidades.SPProductoPorCompaniaPrecargue(com_Id);
        return dt;
    }

    public static int InsertarTerceroNombreApellidoPrecargue(string cedula, string nombre, string apellido)
    {
        FrameworkEntidades objFrameworkEntidades = new FrameworkEntidades();
        int filas;
        filas = objFrameworkEntidades.spInsertarTerceroNombreApellidoPrecargue(cedula, nombre, apellido);
        return filas;
    }

    public DataTable ConsultarConsecutivoCert(int cedula, int producto)
    {
        DataTable dt = new DataTable();
        dt = entidades.sp_ConsultarConsecutivoCertificado(cedula, producto);
        return dt;
    }

    public static DataTable ConsultarConsecutivoCert(int cer_Id)
    {
        FrameworkEntidades objFrameworkEntidades = new FrameworkEntidades();
        DataTable dt = new DataTable();
        dt = objFrameworkEntidades.sp_ConsultarConsecutivoCertificado(cer_Id);
        return dt;
    }

    // Para Modificar un certificado se debe crear un nuevo precargue
    public void CrearNuevoCertificadoModificado(string numeroCertificado, string cedula, string nombre, string apellido, string agencia, DateTime fechaExpedicion, int codigoAsesor, string pagaduria, DateTime fechaRecibido, string planillaBolivar, string estado, string numeroFolios, string compania, string localidad, string producto, string hojaServicioPrincipal, string hojaServicioConyuge, string hojaServicioOtrosAsegurados, int ciudad, int GrupoDevolucion, int causalDevolucion, int prima, string observaciones, string anexoConversion, DateTime vigencia, int soporteFisico, int mesProduccion, int migracion, int consecutivo)
    {
        certificado.NumeroCertificado = numeroCertificado;
        certificado.Cedula = cedula;
        certificado.Nombre = nombre;
        certificado.Apellido = apellido;
        certificado.Agencia = agencia;
        certificado.FechaExpedicion = fechaExpedicion;
        certificado.Pagaduria = pagaduria;
        certificado.FechaRecibido = fechaRecibido;
        certificado.NumeroPlanillaRecibo = planillaBolivar;
        certificado.Estado = estado;
        certificado.NumeroFolios = numeroFolios;
        certificado.Compania = compania;
        certificado.Producto = producto;
        certificado.HojaServicioPrincipal = hojaServicioPrincipal;
        certificado.HojaServicioConyuge = hojaServicioConyuge;
        certificado.HojaServicioOtrosAsegurados = hojaServicioOtrosAsegurados;
        certificado.Ciudad = ciudad;
        certificado.Pagaduria = pagaduria;
        certificado.CausalDevolucion = causalDevolucion;
        certificado.GrupoDevolucion = GrupoDevolucion;
        certificado.Prima = prima;
        certificado.Observacion = observaciones;
        certificado.AnexoConversion = anexoConversion;
        certificado.Vigencia = vigencia;
        certificado.SoporteFisico = soporteFisico;
        certificado.Localidad = localidad;
        entidades.SPInsertarCertificadoModificado(mesProduccion, migracion, consecutivo, codigoAsesor, agencia,certificado);
    }

    public DataTable CargarCompanias()
    {
        DataTable dt = new DataTable();
        dt = compania.ConsultarCompanias();
        return dt;
    }
}