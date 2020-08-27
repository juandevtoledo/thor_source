using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


/// <summary>
/// Descripción breve de CreateLogFiles_CxBD
/// </summary>
/// 



public class CreateLogFiles_CxBD
{


    private string sLogFormat;


	public CreateLogFiles_CxBD()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
        sLogFormat = DateTime.Now.ToString() + " " + " ==> ";

	}

    // este metodo escribe en el archivo de log la exepcion generada 
    public void AddlogCxBD(string logMsg)
    {
        StreamWriter sw = new StreamWriter(HttpContext.Current.Request.PhysicalApplicationPath + "/Logs/cxBD.log", true);
        sw.WriteLine(sLogFormat + logMsg);
        sw.Flush();
        sw.Close();
    }



}


