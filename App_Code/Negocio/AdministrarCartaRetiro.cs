using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de AdministrarCartaRetiro
/// </summary>
public class AdministrarCartaRetiro
{
    public static DataTable MostrarTercero(int ter_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.MostrarTercero(ter_Id);
        return dt;
    }

    public static DataTable MostrarCertificado(int ter_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.MostrarCertificado(ter_Id);
        return dt;
    }


    public static DataTable ListarCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarCertificado(cer_Id);
        return dt;
    }
    
    public static DataTable ListarOrigenOficio()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarOrigenOficio();
        return dt;
    }

    public static DataTable ListarCompania()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarCompania();
        return dt;
    }

    public static void InsertarCartaRetiro(int cedula, double certificado, int pagaduria, int compania, int producto, DateTime fechaTg, 
        DateTime fechaCasaMatriz, DateTime fechaCompania, string origen, string observacion, string usuario)
    {
        DAOAdministrarCartaRetiro.InsertarCartaRetiro(cedula, certificado, pagaduria, compania, producto, fechaTg, fechaCasaMatriz, 
            fechaCompania, origen, observacion, usuario);
    }

    public static DataTable ListarRetiro()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarRetiro();
        return dt;
    }

    public static DataTable ListarCausal()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarCausal();
        return dt;
    }

    public static DataTable ListarAsesor(int dep_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarAsesor(dep_Id);
        return dt;
    }

    public static DataTable ListarTipoGestion()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarTipoGestion();
        return dt;
    }

    public static void InsertarGestionRetiro(int cedula, double certificado, int producto, DateTime fechaGestion, string horaGestion, 
        int asesor, string observacion, DateTime fechaCarta, int tipoGestion, DateTime fechaVigenciaRetiro, int causalRetiro, int idCarta, 
        int llamadaEfectiva)
    {
        DAOAdministrarCartaRetiro.InsertarGestionRetiro(cedula, certificado, producto, fechaGestion, horaGestion, asesor, observacion, 
            fechaCarta, tipoGestion, fechaVigenciaRetiro, causalRetiro, idCarta, llamadaEfectiva);
    }

    public static DataTable CalcularVigencia(double certificado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ConsultarVigencia(certificado);
        return dt;
    }

    public static DataTable ValidarExistente(int cedula, string certificado)
    {
        return DAOAdministrarCartaRetiro.ValidarExistente(cedula, certificado);

    }

    public static DataTable ValidarGestionExistente(int cedula, double certificado, int idCarta)
    {
        return DAOAdministrarCartaRetiro.ValidarGestionExistente(cedula, certificado, idCarta);
    }

    public static DataTable ValidarRecuperacionExistente(int cedula, double certificado)
    {
        return DAOAdministrarCartaRetiro.ValidarRecuperacionExistente(cedula, certificado);
    }

    public static DataTable ConsultarConyuge(int cer_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ConsultarConyuge(cer_Id);
        return dt;
    }

    public static void ActualizarMovimiento(int cer_Id)
    {
        DAOAdministrarCartaRetiro.ActualizarMovimiento(cer_Id);
    }

    public static void ActualizarMesProduccion(int ter_Id, double cer_Certificado, int idCarta)
    {
        DAOAdministrarCartaRetiro.ActualizarMesProduccion(ter_Id, cer_Certificado, idCarta);
    }

    public static void ActualizarRecuperacionRetiro(int ter_Id, double cer_Certificado, DateTime fecha_Recuperacion, string hora_Recuperacion, 
        int ase_Id, string observacion_Rec, int tipo_Gestion)
    {
        DAOAdministrarCartaRetiro.ActualizarRecuperacionRetiro(ter_Id, cer_Certificado, fecha_Recuperacion, hora_Recuperacion, ase_Id, 
            observacion_Rec, tipo_Gestion);
    }

    public static void InsertarNovedad(int ter_Id, int cer_Id)
    {
        DAOAdministrarCartaRetiro.InsertarNovedad(ter_Id, cer_Id);
    }
    
    public static DataTable ValidarProduccionNueva(int ter_Id, int pro_id)
    {
        return DAOAdministrarCartaRetiro.ValidarProduccionNueva(ter_Id, pro_id);
    }

    public static void InsertarNovedadRecuperacion(int ter_Id, double cer_Id)
    {
        DAOAdministrarCartaRetiro.InsertarNovedadRecuperacion(ter_Id, cer_Id);
    }

    public static DataTable BuscarRetiro(int ter_Id, double cer_Certificado, DateTime fecha)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.BuscarRetiro(ter_Id, cer_Certificado, fecha);
        return dt;
    }

    public static void ActualizarMovimientoRecuperacion(int ter_Id, double cer_Certificado)
    {
        DAOAdministrarCartaRetiro.ActualizarMovimientoRecuperacion(ter_Id, cer_Certificado);
    }

   public static void EliminarRetiro(int IdCarta, int ter_Id, double cer_Certificado)
    {
        DAOAdministrarCartaRetiro.EliminarRetiro(IdCarta, ter_Id, cer_Certificado);
    }

    public static DataTable EditarRetiro(int cer_Id, int idCartaRetiro)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.EditarRetiro(cer_Id, idCartaRetiro);
        return dt;
    }

    public static void ActualizarCartaRetiro(int idCarta, int compania, DateTime fechaTg, DateTime fechaCasaMatriz, DateTime fechaCompania, string origen, string observacion)
    {
        DAOAdministrarCartaRetiro.ActualizarCartaRetiro(idCarta, compania, fechaTg, fechaCasaMatriz, fechaCompania, origen, observacion);
    }

   public static DataTable ListarObservaciones(int idCarta)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarObservaciones(idCarta);
        return dt;
    }

    public static void GuardarObservacion(string observacion, string usuario, int men_Id, int ter_Id, int idCarta)
    {
        DAOAdministrarCartaRetiro.GuardarObservacion(observacion, usuario, men_Id, ter_Id, idCarta);
    }

    public static DataTable ListarProductosCompania(int com_Id )
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarProductosCompania(com_Id);
        return dt;
    }

    public static DataTable ListarLocalidad()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarLocalidad();
        return dt;
    }

    public static DataTable InformeRetiros(int cedula, int localidad, int com_Id, int pro_Id, int tipoGestion, int origen, DateTime fechaInicio, DateTime fechaFin, int informe)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.InformeRetiros(cedula, localidad, com_Id, pro_Id, tipoGestion, origen, fechaInicio, fechaFin, informe);
        return dt;
    }

    public static DataTable ListarTipoInforme()
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ListarTipoInforme();
        return dt;
    }

    public static void ActualizarVigenciaRetiro(int idCarta)
    {
        DAOAdministrarCartaRetiro.ActualizarVigenciaRetiro(idCarta);
    }

    public static void ActualizarVigenciaCer(int idCarta, double idCertificado)
    {
        DAOAdministrarCartaRetiro.ActualizarVigenciaCer(idCarta, idCertificado);
    }

    public static DataTable ConsultarIdCarta(int ter_Id, double cer_Certificado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCartaRetiro.ConsultarIdCarta(ter_Id, cer_Certificado);
        return dt;
    }
}