using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


/// <summary>
/// Descripción breve de InformeProduccion
/// </summary>
public class InformeProduccion
{
	
    public static DataTable ConsultarLocalidadPorAgencia(string age_Id)
    {
        DataTable dtLocalidad = new DataTable();
        dtLocalidad = DAOInformeProduccion.sp_ConsultarLocalidadPorAgencia(age_Id);
        return dtLocalidad;
    }

    public static DataTable ConsultarAsesorPorLocalidad(string dep_Id)
    {
        DataTable dtAsesor = new DataTable();
        dtAsesor = DAOInformeProduccion.sp_ConsultarAsesorPorlocalidad(dep_Id);
        return dtAsesor;
    }

    public static DataTable ConsultarMes()
    {
        DataTable dtMes = new DataTable();
        dtMes = DAOInformeProduccion.sp_ConsultarMes();
        return dtMes;
    }

    public static DataTable ConsultarAnio()
    {
        DataTable dtAnio = new DataTable();
        dtAnio = DAOInformeProduccion.sp_ConsultarAnio();
        return dtAnio;
    }

    public static DataTable ConsultarPagaduriaPorLocalidad(string dep_Id)
    {
        DataTable dtAnio = new DataTable();
        dtAnio = DAOInformeProduccion.sp_ConsultarPagaduriaPorLocalidad(dep_Id);
        return dtAnio;
    }

    public static DataTable ConsultarConvenioPorPagaduria(string paga_Id)
    {
        DataTable dtconvenio = new DataTable();
        dtconvenio = DAOInformeProduccion.sp_ConsultarConvenioPorPagaduria(paga_Id);
        return dtconvenio;
    }

    public static DataTable ConsultarInformeProduccion(int agencia, int localidad, int asesor, int estadoNegocio, int anio, int mes, int compania, int producto, int pagaduria, int convenio, DateTime fechaDesde, DateTime fechaHasta)
    {
        DataTable dtInforme = new DataTable();
        dtInforme = DAOInformeProduccion.sp_ConsultarInformeProduccion(agencia, localidad, asesor, estadoNegocio, anio, mes, compania, producto, pagaduria, convenio, fechaDesde, fechaHasta);
        return dtInforme;
    }

    public static DataTable ConsularEstadoNegocio()
    {
        DataTable dtInforme = new DataTable();
        dtInforme = DAOInformeProduccion.sp_ConsultarEstadoNegocio();
        return dtInforme;
    }
}