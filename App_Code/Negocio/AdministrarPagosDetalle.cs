using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de AdministrarPagosDetalle
/// </summary>
public class AdministrarPagosDetalle
{
    public static DataTable ConsultarAplicaciones(DataTable dtFacturacion, int index, int solicitudCheques)
    {
        DataTable aplicaciones = DAOAdministrarPagosDetalle.ConsultarAplicacionesSolicitudCheques(dtFacturacion.Rows[index]["IdentificadorSoporte"].ToString(), solicitudCheques);
        return aplicaciones;
    }
}