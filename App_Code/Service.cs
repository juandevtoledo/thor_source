using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "Service" en el código, en svc y en el archivo de configuración a la vez.
public class Service : IService
{
	public void DoWork()
	{
	}

    //public DataTable ConsultarNovedades()
    //{
    //    DataTable dtHistorico = AdministrarSoportesBancarios.PruebaWebService();
    //    return dtHistorico;
    //}
}
