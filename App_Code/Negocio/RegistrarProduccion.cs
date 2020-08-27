using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de RegistrarProduccion
/// </summary>
public class RegistrarProduccion
{
    public DAODigitarProduccion objDigitarProduccion = new DAODigitarProduccion();
    Asegurado objAsegurado = new Asegurado();
	// Buscar si cliente existe
    public void ExisteCliente(double documento)
    {
        objAsegurado.ConsultarAsegurado();
        DataTable dtTercero = new DataTable();
        dtTercero = objDigitarProduccion.SPConsultarTerceroPreCargue(documento);
        try
        { 
            if (dtTercero.Rows[0]["ter_Nombres"].ToString() != "")
                objAsegurado.NumeroIdentificacion = documento.ToString();
        }
        catch(Exception ex)
        {
            objAsegurado.NumeroIdentificacion = "-1";
        }                  

    }

    public void ActualizarCliente()
    {
        objAsegurado.ActualizarAsegurado();

    }

    public void RegistrarCliente()
    {
        objAsegurado.InsertarAsegurado();
    }

    public void EliminarCliente()
    {
        objAsegurado.EliminarAsegurado();
    }
}