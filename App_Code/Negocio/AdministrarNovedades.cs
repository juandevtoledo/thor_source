using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descripción breve de AdministrarNovedades
/// </summary>
public class AdministrarNovedades
{
    public static DataTable InsertarNovedades(int cedula, string tipoNovedad, int estado, int pagaduria, int convenio, int archivo, int valor, int enviada, int mes, int anio)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.InsertarNovedades(cedula, tipoNovedad, estado, pagaduria, convenio, archivo, valor, enviada, mes, anio);
        return dt;
    }

    public static DataTable ActualizarNovedades(int nov_Id, string nov_TipoNovedad, int nov_Valor, int mes, int anio)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ActualizarNovedades(nov_Id, nov_TipoNovedad, nov_Valor,mes,anio);
        return dt;
    }

    public static DataTable ActualizarDePendienteASinAplicar(int nov_Id, int nov_Estado, string nov_Observaciones)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ActualizarDePendienteASinAplicar(nov_Id, nov_Estado, nov_Observaciones);
        return dt;
    }

    public static DataTable LocalidadesAgencia(int age_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.LocalidadesAgencia(age_Id);
        return dt;
    }

    public static DataTable ConsultarRegistroCuentaDeCobro(int arcpag_Id, int dep_Id, int paga_Id, int nov_Estado, int nov_Enviada)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarRegistroCuentaDeCobro(arcpag_Id,dep_Id,paga_Id,nov_Estado,nov_Enviada);
        return dt;
    }

    public static DataTable ConsultarInformacionPagaduria(int paga_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarInformacionPagaduria(paga_Id);
        return dt;
    }

    public static DataTable ConsultarInformacionAgenciaNovedades(int age_Id, int paga_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarInformacionAgenciaNovedades(age_Id, paga_Id);
        return dt;
    }

    public static DataTable ConsultarTipoArchivoNovedades(int arcpag_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarTipoArchivoNovedades(arcpag_Id);
        return dt;
    }

    public static DataTable ConsultarFechaAplicacionNovedades()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarFechaAplicacionNovedades();
        return dt;
    }

    public static DataTable ConsultarMesNovedadesSinEnviar()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarMes();
        return dt;
    }

    public static DataTable ConsultarMes()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarMes();
        return dt;
    }

    public static DataTable ConsultarAnioNovedadesSinEnviar()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarAnioNovedadesSinEnviar();
        return dt;
    }

    public static DataTable ConsultarAnio()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarAnio();
        return dt;
    }

    public static DataTable ConsultarCausales()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarCausales();
        return dt;
    }

    public static DataTable ConsultarMesYAnioNovedad(int nov_Mes, int nov_Anio, int nov_Archivo)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarMesYAnioNovedad(nov_Mes, nov_Anio, nov_Archivo);
        return dt;
    }

    public static DataTable ConsultarNovedadesLocalidades(int dep_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorLocalidad(dep_Id, nov_Estado);
        return dt;
    }

    public static DataTable ConsultarPagaduriaLocalidad(int dep_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarPagaduriaLocalidad(dep_Id);
        return dt;
    }

    public static DataTable ConsultarArchivoPagaduria(int paga_Id, string tipo_archivo)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarArchivoPagaduria(paga_Id, tipo_archivo);
        return dt;
    }

    public static DataTable ConsultarNovedadesPagaduria(int dep_Id, int paga_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorPagaduria(dep_Id, paga_Id, nov_Estado);
        return dt;
    }

    public static DataTable ConsultarNovedadesArchivo(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorArchivo(dep_Id, paga_Id, arcpag_Id, nov_Estado);
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnio(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, int nov_Mes, int nov_Anio)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorMesYAnio(dep_Id, paga_Id, arcpag_Id, nov_Estado, nov_Mes, nov_Anio);
        return dt;
    }

    // Diego
    public static DataTable ConsultarNovedades(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, int enviada, int nov_Mes, int nov_Anio)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedades(dep_Id, paga_Id, arcpag_Id, nov_Estado, enviada, nov_Mes, nov_Anio);
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnioAplicadas(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorMesYAnioAplicadas(dep_Id, paga_Id, arcpag_Id, nov_Estado, nov_FechaAplicacion, nov_FechaAplicacion2);
        return dt;
    }

    public static DataTable ConsultarNovedadesPorMesYAnioHistorico(int dep_Id, int paga_Id, int arcpag_Id, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorMesYAnioHistorico(dep_Id, paga_Id, arcpag_Id, nov_FechaAplicacion, nov_FechaAplicacion2);
        return dt;
    }

    public static DataTable ConsultarNovedadesPorEstadoHistorico(int dep_Id, int paga_Id, int arcpag_Id, DateTime nov_FechaAplicacion, DateTime nov_FechaAplicacion2, int nov_Estado)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorEstadoHistorico(dep_Id, paga_Id, arcpag_Id, nov_FechaAplicacion, nov_FechaAplicacion2, nov_Estado);
        return dt;
    }

    public static DataTable ConsultarNovedadesLocalidadesEnviada(int dep_Id, int nov_Estado, int Enviada)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorLocalidadEnviada(dep_Id, nov_Estado,Enviada);
        return dt;
    }

    public static DataTable ConsultarNovedadesPagaduriaEnviada(int dep_Id, int paga_Id, int nov_Estado, int Enviada)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorPagaduriaEnviada(dep_Id, paga_Id, nov_Estado, Enviada);
        return dt;
    }

    public static DataTable ConsultarNovedadesArchivoEnviada(int dep_Id, int paga_Id, int arcpag_Id, int nov_Estado, int Enviada)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesPorArchivoEnviada(dep_Id, paga_Id, arcpag_Id, nov_Estado,Enviada);
        return dt;
    }

    public static void ActualizarNovedadAEnviar(DataTable dtNovedad)
    {       
        DAOAdministrarNovedades.ActualizarNovedadAEnviar(dtNovedad);        
    }

    public static DataTable ConsultarNovedadesHistorico(int dep_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesHistorico(dep_Id);
        return dt;
    }

    public static DataTable ConsultarNovedadesHistoricoPagaduria(int dep_Id, int paga_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesHistoricoPagaduria(dep_Id, paga_Id);
        return dt;
    }

    public static DataTable ConsultarNovedadesHistoricoArchivo(int dep_Id, int paga_Id, int arcpag_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarNovedadesHistoricoArchivo(dep_Id, paga_Id, arcpag_Id);
        return dt;
    }
    public static DataTable ConsultarEstadoNovedades()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarNovedades.ConsultarEstadoNovedades();
        return dt;
    }

    // Consultar Novedades Sin Aplicar para volver a calcularlas
    public static DataTable ConsultarNovedadesSinAplicar(string cedula, int convenio)
    {
        DataTable dt = DAOAdministrarNovedades.ConsultarNovedadesSinAplicar(cedula, convenio);
        return dt;
    }

    // Guardar cuentas de cobro
    public static int GuardarCuentasCobro(DataTable dtNovedadArchivoCuentaCobro, string cueCob_Archivo)
    {
        int reg = DAOAdministrarNovedades.GuardarCuentasCobro(dtNovedadArchivoCuentaCobro, cueCob_Archivo);
        return reg;
    }

    public static DataTable ConsultarCuentasCobro(string mes, string anio, int cueCobId, string cueCob_Archivo)
    {
        string cueCobIdS = cueCobId.ToString();
        DataTable dt = DAOAdministrarNovedades.ConsultarCuentasCobro(mes, anio, cueCobIdS, cueCob_Archivo);
        return dt;
    }

    public static DataTable ConsultarCuentaCobro(int cueCob_Id)
    {
        DataTable dt = DAOAdministrarNovedades.ConsultarCuentaCobro(cueCob_Id);
        return dt;
    }

    public static int VerificarCuentasCobro(string cueCob_Archivo)
    {
        int cue = DAOAdministrarNovedades.VerificarCuentaCobro(cueCob_Archivo);
        return cue;
    }

    public static int EliminarCuentasCobro(int cueCob_Id, int archivo)
    {
        int reg = DAOAdministrarNovedades.EliminarCuentaCobro(cueCob_Id, archivo);
        return reg;
    }

    public static DataTable ConsultarCertificadoPorPagaduriaArchivo(string ter_Id,string arcpag_Id,string nov_Id)
    {
        DataTable dt = DAOAdministrarNovedades.ConsultarCertificadoPorPagaduriaArchivo(ter_Id,arcpag_Id,nov_Id);
        return dt;
    }

    public static DataTable ConsultarNovedadPorTercero(string ter_Id,string arcpag_Id,string nov_Estado,string nov_Id)
    {
        DataTable dt = DAOAdministrarNovedades.ConsultarNovedadPorTercero(ter_Id,arcpag_Id,nov_Estado,nov_Id);
        return dt;
    }

}