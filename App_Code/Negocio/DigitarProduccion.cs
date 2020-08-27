using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de DigitarProduccion
/// </summary>
public class DigitarProduccion
{
    public  FrameworkEntidades entidades = new FrameworkEntidades();
    public FrameworkEntidades FrameworkEntidades = new FrameworkEntidades();
    public DAODigitarProduccion objDigitarProduccion = new DAODigitarProduccion();
    public UsuarioControl objUsuarioSistema = new UsuarioControl();
    public Pagaduria objPagaduria = new Pagaduria();
    public Asesor objAsesor = new Asesor();
    public Compania objCompania = new Compania();
    public Producto objProducto = new Producto();
    public Certificado objCertificado = new Certificado();
    public Agencia objAgencia = new Agencia();
    
    public DataTable TraerCertificado()
    {
        DataTable dt = new DataTable();
        dt = FrameworkEntidades.SPConsultarCertificadoGeneralMom2();
        return dt;

    }

    public int ActualizarEstado(int cer_Id, int estcar_Id, int mom_Id, int cer_PrimaTotal, int tipdev_Id, int caudev_Id, string cer_Observaciones)
    {
        return FrameworkEntidades.SPActualizarEstado(cer_Id, estcar_Id, mom_Id, cer_PrimaTotal, tipdev_Id, caudev_Id, cer_Observaciones);
    }

    public DataTable cargarTipoDevolucion()
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarTipoDevolucion();
        return dt;
    }

    public DataTable consultarTerceroPreCargue(int ter_Id)
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.SPConsultarTerceroPreCargue(ter_Id);
        return dt;
    }

    public DataTable cargarCausalDevolucion(int tipo)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarCausalDevolucionPorTipo(tipo);
        return dt;
    }

    public DataTable CargarBusquedaAgencia(int age_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoAgencia(age_Id, mom_Id);
        return dt;
    }
    public DataTable CargarBusquedaAgenciaDevolucion(int age_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoAgenciaDevolucion(age_Id);
        return dt;
    }

    

    public  DataTable CargarBusquedaTercero(int ter_Id,int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoTercero(ter_Id,mom_Id);
        return dt;
    }

    public DataTable CargarBusquedaPoliza(int cer_certificado, int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoPoliza(cer_certificado,mom_Id);
        return dt;
    }

    public DataTable CargarProductoPorCertificado(int cer_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarProductoPorCertificado(cer_Id);
        return dt;
    }

    public DataTable CargarBusquedaFecha(DateTime fecha_Inicial, DateTime fecha_final, int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoFecha(fecha_Inicial, fecha_final, mom_Id);
        return dt;
    }

    public DataTable CargarBusquedaFechaDevolucion(DateTime fecha_Inicial, DateTime fecha_final)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoFechaDevolucion(fecha_Inicial, fecha_final);
        return dt;
    }

    public DataTable CargarBusquedaTerceroDevolucion(int ter_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoTerceroDevolucion(ter_Id);
        return dt;
    }

    public DataTable CargarBusquedaPolizaDevolucion(int cer_certificado)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCertificadoPolizaDevolucion(cer_certificado);
        return dt;
    }

    public DataTable cargarAgenciaDdl()
    {
        DataTable dt = new DataTable();
        dt = entidades.SPConsultarAgenciaDdl();
        return dt;
    }

    public DataTable ConsultarCertificadoDevoluciones()
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.SPConsultarCertificadoDevoluciones();
        return dt;
    }
    public DataTable ActualizarTidevRecuperable(int cer_Id, int estcar_Id)
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.SPActualizarTidevRecuperable(cer_Id, estcar_Id);
        return dt;
    }
    public  DataTable ActualizarEstcarDevolucion(int cer_Id, int estcar_Id)
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.SPActualizarEstcarDevolucion(cer_Id, estcar_Id);
        return dt;
    }
    public DataTable ConsultarCertificadoActaTransferencial(int mom_Id,int estcar_Id, int estcar2_Id)
    {
        DataTable dt = new DataTable();
        dt = objDigitarProduccion.SPConsultarCertificadoActaTransferencial(mom_Id, estcar_Id, estcar2_Id);
        return dt;
    }
    public int ActualizarMomento(int cer_Id, int mom_Id)
    {

        return objDigitarProduccion.SPActualizarMomento(cer_Id, mom_Id);

    }
    public DataTable ConsultarTipoDevolucionPlus()
    {

        return objDigitarProduccion.SpConsultarTipoDevolucionPlus();
    }

    public DataTable CargarBusquedaCompañia(int compañia, int momId)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaCompañía(compañia, momId);
        return dt;
    }

    public DataTable ListarCompania()
    {
        DataTable dt = new DataTable();
        dt = entidades.ListarCompania();
        return dt;
    }

    public DataTable ListarProducto(int com_id)
    {
        DataTable dt = new DataTable();
        dt = entidades.ListarProducto(com_id);
        return dt;
    }

    public DataTable CargarBusquedaProducto(int pro_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.SPBusquedaProducto(pro_Id, mom_Id);
        return dt;
    }

    public DataTable CargarTercero(int ter_Id, int mom_Id)
    {
        DataTable dt = new DataTable();
        dt = entidades.CargarTercero(ter_Id, mom_Id);
        return dt;
    }
}