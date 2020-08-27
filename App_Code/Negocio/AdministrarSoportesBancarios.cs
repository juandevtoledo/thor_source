using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de AdministrarSoportesBancarios
/// </summary>
public class AdministrarSoportesBancarios
{
    // ============== CARGA ARCHIVO EXCEL, APROBACION Y APLICACION DE SOPORTES ============

    // Inserta en la tabla temporal
    public static void InsertarSoporteBancario(string informacionBanco, string formaPago, DateTime fechaMovimiento, string tipoDocumento, long identificacion, double valor, string referencia, string localidad, string txtNomSoporte)
    {
        DAOAdministrarSoporteBancario.InsertarSoporteBancario(informacionBanco, formaPago, fechaMovimiento, tipoDocumento, identificacion, valor, referencia, localidad, txtNomSoporte);
    }

    // Consulta la tabla temporal e inserta en encabezado, soporteBancario, control
    public static int ConsutarTempSoporteBancario()
    {
        return DAOAdministrarSoporteBancario.ConsultarTempSoporteBancario();
    }
    
    // Listar soportes
    public static DataTable ListarSoportes(string usuario)
    {
        DataTable dtListarSop = new DataTable();
        dtListarSop = DAOAdministrarSoporteBancario.ListarSoportes(usuario);
        return dtListarSop;
    }

    // Consultar el detalle soportes bancarios
    public static DataTable ConsultarDetalleSoportes(int encSop_Id)
    {
        DataTable dtconsultarSop = new DataTable();
        dtconsultarSop = DAOAdministrarSoporteBancario.ConsultarDetalleSoportes(encSop_Id);
        return dtconsultarSop;
    }

    // Aprobar soportes bancarios
    public static int AprobarSoporteBancario(int encSop_Id)
    {
        return DAOAdministrarSoporteBancario.AprobarSoporteBancario(encSop_Id); 
    }

    // Rechazar soportes bancarios
    public static int RechazarSoporteBancario(int encSop_Id, string textAreaMotivo, long identificacion)
    {
       return DAOAdministrarSoporteBancario.RechazarSoporteBancario(encSop_Id, textAreaMotivo, identificacion);
    }

    // Aplicar pagos  
    public static int AplicarPagosSoporteBancario(int encSop_Id, int sop_Id, long identificacion, string usuario)
    {
        return DAOAdministrarSoporteBancario.AplicarPagosSoporteBancario(encSop_Id, sop_Id, identificacion, usuario);    
    }

    // Consulta los convenios de una cedula para aplicar novedades
    public static DataTable ConsultarCovenioCedula(long identificacion)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarSoporteBancario.ConsultarCovenioCedula(identificacion);
        return dt;
    }

    public static DataTable ConsultarBancosSoporteBancarioEditar(int intCompania, int tipoBanco)
    {
        DataTable dtBancosUno = new DataTable();
        dtBancosUno = DAOAdministrarSoporteBancario.ConsultarBancosSoporteBancarioEditar(intCompania, tipoBanco);
        return dtBancosUno;
    }

    // Eliminar soportes bancarios
    public static int EliminarSoporteBancario(int encSop_Id)
    {
        return DAOAdministrarSoporteBancario.EliminarSoporteBancario(encSop_Id);
    }

    // ============== CARGA ARCHIVO EXCEL, APROBACION Y APLICACION DE SOPORTES ============


    // ============== INGRESAR UNO A UNO ============

    public static DataTable ListarTipoDocumento(int cargo)
    {
        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento = DAOAdministrarSoporteBancario.ListarTipoDocumento(cargo);
        return dtTipoDocumento;
    }

    public static DataTable ListarFormaPago(int cargo)
    {
        DataTable dtFormaPago = new DataTable();
        dtFormaPago = DAOAdministrarSoporteBancario.ListarFormaPago(cargo);
        return dtFormaPago;
    }

    public static DataTable ListarTipoSoporteBancario(int formaPago)
    {
        DataTable dtTipSopBan = new DataTable();
        dtTipSopBan = DAOAdministrarSoporteBancario.ListarTipoSoporteBancario(formaPago);
        return dtTipSopBan;
    }

    public static DataTable ConsultarCompanias()
    {
        DataTable dtCompania = new DataTable();
        dtCompania = DAOAdministrarSoporteBancario.ListarCompania();
        return dtCompania;
    }

    public static DataTable ListarBancos(int com_Id, int tipBan_Id)
    {
        DataTable dtBancos = new DataTable();
        dtBancos = DAOAdministrarSoporteBancario.ListarBancos(com_Id, tipBan_Id);
        return dtBancos;
    }

    public static DataTable ConsultarBancosSoporteBancario(int intCompania, int tipoBanco, int formaPago)
    {
        DataTable dtBancosUno = new DataTable();
        dtBancosUno = DAOAdministrarSoporteBancario.ConsultarBancosSoporteBancario(intCompania, tipoBanco, formaPago);
        return dtBancosUno;
    }

    public static DataTable ConsultarTipoCuenta(int ban_Id)
    {
        DataTable dtTipoCuenta = new DataTable();
        dtTipoCuenta = DAOAdministrarSoporteBancario.ConsultarTipoCuenta(ban_Id);
        return dtTipoCuenta;
    }

    public static DataTable ConsultarNumeroCuenta(int ban_Id, int tipCue_Id)
    {
        DataTable dtCuenta = new DataTable();
        dtCuenta = DAOAdministrarSoporteBancario.ConsultarNumeroCuenta(ban_Id, tipCue_Id);
        return dtCuenta;
    }

    public static int InsertarSoporteBancarioUno(int tipoDoc, int identificacion, int pagaduria, int formaPago, string cheque, int Recibido, int compania, int banco, int tipoCuenta, int cuenta,
        DateTime fecha, int talon, int valor, string sucursal, string usuario)
    {
        return DAOAdministrarSoporteBancario.InsertarSoporteBancarioUno(tipoDoc, identificacion, pagaduria, formaPago, cheque, Recibido, compania, banco, tipoCuenta, cuenta, fecha, talon, valor, sucursal, usuario);
    }

    // =========================== DISTRIBUSCION DE SOPORTES ===========================
    public static DataTable ListarLocalidades()
    {
        DataTable dtLocalidades = new DataTable();
        dtLocalidades = DAOAdministrarSoporteBancario.ConsultarLocalidades();
        return dtLocalidades;
    }

    public static DataTable ConsultarPagadurias(int dep_Id)
    {
        DataTable dtPagadurias = new DataTable();
        dtPagadurias = DAOAdministrarSoporteBancario.ConsultarPagadurias(dep_Id);
        return dtPagadurias;
    }

    public static DataTable ConsultarConvenios(int paga_Id)
    {
        DataTable dtConvenios = new DataTable();
        dtConvenios = DAOAdministrarSoporteBancario.ConsultarConvenios(paga_Id);
        return dtConvenios;
    }

    public static DataTable ConsultarSoportesPagaduria(int paga_Id)
    {
        DataTable dtSopPaga = new DataTable();
        dtSopPaga = DAOAdministrarSoporteBancario.ConsultarSoportesPagaduria(paga_Id);
        return dtSopPaga;
    }

    public static int InsertarDetalleSoporte(string con_Id, string valorDistri, string sop_Id)
    {
        return DAOAdministrarSoporteBancario.InsertarDetalleSoporte(con_Id, valorDistri, sop_Id);
    }
    
    public static void CambiarEstadoSoporteBancario(int encSop_Id, int sop_Id, long ter_Id)
    {
        DAOAdministrarSoporteBancario.CambiarEstadoSoporteBancario(encSop_Id, sop_Id, ter_Id);
    }

    public static DataTable ConsultarDistribucionSoporte(int sop_Id)
    {
        DataTable dtDetalleSop = new DataTable();
        dtDetalleSop = DAOAdministrarSoporteBancario.ConsultarDistribucionSoporte(sop_Id);
        return dtDetalleSop;
    }
    
    public static DataTable ListarDetalleTotal(int paga_Id)
    {
        DataTable dtSopPaga = new DataTable();
        dtSopPaga = DAOAdministrarSoporteBancario.ListarDetalleTotal(paga_Id);
        return dtSopPaga;
    }

    public static int EliminarDetalleDistribucion(int detDistri)
    {
        return DAOAdministrarSoporteBancario.EliminarDetalleDistribucion(detDistri);
    }

    // =========================== DISTRIBUSCION DE SOPORTES ===========================
    
    public static DataTable ConsultarEncabezadoSoporte(int encSop_Id)
    {
        DataTable dtEncabezado = new DataTable();
        dtEncabezado = DAOAdministrarSoporteBancario.ConsultarEncabezadoSoporte(encSop_Id);
        return dtEncabezado;
    }

    public static int ModificarEncabezadoSoporteBancario(int banco, int tipoCuenta, int cuenta, int encSop_Id)
    {
        return DAOAdministrarSoporteBancario.ModificarEncabezadoSoporteBancario(banco, tipoCuenta, cuenta, encSop_Id);    
    }

    public static DataTable ConsultarSoporteBancarioEditar(string sop_Id)
    {
        DataTable dtSoporte = new DataTable();
        dtSoporte = DAOAdministrarSoporteBancario.ConsultarSoporteBancarioEditar(sop_Id);
        return dtSoporte;
    }

    public static int ModificarSoporteBancario(int tipDoc, string identificacion, string referencia, int talon, string valor, int sop_Id)
    {
        return DAOAdministrarSoporteBancario.ModificarSoporteBancario(tipDoc, identificacion, referencia, talon, valor, sop_Id);    
    }

    public static DataTable ListarBancos()
    {
        DataTable dtBancos = new DataTable();
        dtBancos = DAOAdministrarSoporteBancario.ListarBancos();
        return dtBancos;
    }

    public static DataTable ListarEstados()
    {
        DataTable dtEstados = new DataTable();
        dtEstados = DAOAdministrarSoporteBancario.ListarEstados();
        return dtEstados;
    }

    public static DataTable ConsultarInformeSoporteBancario(int tipDoc, int banco, int recibido, int estado, DateTime fechaDesde, DateTime fechaHasta)
    {
        DataTable dtInforme = new DataTable();
        dtInforme = DAOAdministrarSoporteBancario.ConsultarInformeSoporteBancario(tipDoc, banco, recibido, estado, fechaDesde, fechaHasta);
        return dtInforme;
    }

    public static DataTable BuscarEncabezadoSoporteBancario(string banco, string cuenta, DateTime fecha, string recibido, string estado)
    {
        DataTable dtBuscar = new DataTable();
        dtBuscar = DAOAdministrarSoporteBancario.BuscarEncabezadoSoporteBancario(banco, cuenta, fecha, recibido, estado);
        return dtBuscar;
    }

    public static DataTable BuscarSoporteBancario(string formaPago, string identificacion, string referencia, string estado, int encSop_Id)
    {
        DataTable dtBuscar = new DataTable();
        dtBuscar = DAOAdministrarSoporteBancario.BuscarSoporteBancario(formaPago, identificacion, referencia, estado, encSop_Id);
        return dtBuscar;
    }





}