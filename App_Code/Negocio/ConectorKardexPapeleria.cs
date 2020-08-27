using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;

/// <summary>
/// Descripción breve de ConectorKardexPapeleria
/// </summary>
public class ConectorKardexPapeleria
{
    #region CrearArchivoEnviarInformacion

    // Método Main de la clase, agrega una a una las líneas del archivo
	public static void ActualizarPolizaUtilizada(double numeroCertificado)
    {
        DataTable certificado = DAOConKardexPapeleria.ConsultarCertificadoDigitado(numeroCertificado);
        DataTable archivo = CrearEstructuraDataTable();
        archivo = CrearEncabezadoArchivo(archivo);
        archivo = CrearSegundaLinea(archivo, certificado);
        archivo = CrearTerceraLinea(archivo, certificado);
        archivo = CrearCuartaLinea(archivo, certificado);
        archivo = UltimaLinea(archivo);
        CrearArchivo(archivo);
    }

    // Última línea que cierra el archivo, tiene valores fijos
    public static DataTable UltimaLinea(DataTable archivo)
    {
        DataRow ultimaLinea = archivo.NewRow();
        // Son 5 líneas en total por eso se colocan las líneas
        ultimaLinea["CertificadosUtilizados"] = "0000005";
        ultimaLinea["CertificadosUtilizados"] += "99990001";
        ultimaLinea["CertificadosUtilizados"] += "001";
        archivo.Rows.Add(ultimaLinea);
        return archivo;
    }

    // Cuarta Línea que contiene la información del número de Póliza que se debe deshabilitar del sistema Apolo
    public static DataTable CrearCuartaLinea(DataTable archivo, DataTable certificado)
    {
        DataRow cuartaLinea = archivo.NewRow();
        string primerCampo, segundoCampo, tercerCampo, cuartoCampo, quintoCampo, sextoCampo, septimoCampo, octavoCampo,
            novenoCampo, decimoCampo, decimoPrimerCampo, decimoSegundoCampo;

        primerCampo = "0000004";
        segundoCampo = "0479";
        tercerCampo = "00";
        cuartoCampo = "01";
        quintoCampo = "001";
        int agencia = int.Parse(certificado.Rows[0]["age_Id"].ToString());
        sextoCampo = DAOConKardexPapeleria.ConsultarCentroOperaciones(agencia).Rows[0]["cenOpe_id"].ToString();
        septimoCampo = "SAP";
        octavoCampo = "00000001";
        novenoCampo = "0000000001";
        // Aquí va el código de la póliza que se tiene en SIESA y que se desea dar salida en ese sistema (En Tor es la póliza
        // que se acaba de digitar)
        decimoCampo = "TEMPORALSEDEBECORREGIR";
        decimoPrimerCampo = "        ";
        decimoSegundoCampo = "                                                                                                                                                                                                                                                               \r\n"; // 255
        cuartaLinea["CertificadosUtilizados"] = primerCampo + segundoCampo + tercerCampo + cuartoCampo + quintoCampo +
            sextoCampo + septimoCampo + octavoCampo + novenoCampo + decimoCampo + decimoPrimerCampo + decimoSegundoCampo;
        archivo.Rows.Add(cuartaLinea);
        return archivo;
    }

    // Tercera línea del archivo que contiene el tipo de datos que se desea sacar de Apolo
    public static DataTable CrearTerceraLinea(DataTable archivo, DataTable certificado)
    {
        DataRow terceraLinea = archivo.NewRow();
        string primerCampo, segundoCampo, tercerCampo, cuartoCampo, quintoCampo, sextoCampo, septimoCampo, octavoCampo,
            novenoCampo, decimoCampo, decimoPrimerCampo, decimoSegundoCampo, decimoTercerCampo, decimoCuartoCampo,
            decimoQuintoCampo, decimoSextoCampo, decimoSeptimoCampo, decimoOctavoCampo, decimoNovenoCampo, vigesimoPrimerCampo,
            vigesimoSegundoCampo, vigesimoTercerCampo, vigesimoCuartoCampo, vigesimoQuintoCampo, vigesimoSextoCampo,
            vigesimoSeptimoCampo, vigesimoOctavoCampo, vigesimoNovenoCampo, trigesimoPrimerCampo, trigesimoSegundoCampo,
            trigesimoTercerCampo, trigesimoCuartoCampo, trigesimoQuintoCampo, trigesimoSextoCampo, trigesimoSeptimoCampo;
        primerCampo = "0000003";
        segundoCampo = "0470";
        tercerCampo = "00";
        cuartoCampo = "06";
        quintoCampo = "001";        
        // Centro de Operaciones(APOLO) - Agencia(THOR): Se debe consultar en las tablas espejo lo equivalente
        int agencia = int.Parse(certificado.Rows[0]["age_Id"].ToString());
        sextoCampo = DAOConKardexPapeleria.ConsultarCentroOperaciones(agencia).Rows[0]["cenOpe_id"].ToString();
        septimoCampo = "SAP";
        octavoCampo = "00000001";
        novenoCampo = "0000000001";
        decimoCampo = "                                                       "; // 55
        decimoPrimerCampo = "BD004";
        decimoSegundoCampo = "000000000";
        decimoTercerCampo = "               "; // 15
        decimoCuartoCampo = "602";
        decimoQuintoCampo = "10";
        // Centro de Operaciones(APOLO) - Agencia(THOR): Se debe consultar en las tablas espejo lo equivalente
        agencia = int.Parse(certificado.Rows[0]["age_Id"].ToString());
        decimoSextoCampo = DAOConKardexPapeleria.ConsultarCentroOperaciones(agencia).Rows[0]["cenOpe_id"].ToString();
        decimoSeptimoCampo = "  "; // 2
        decimoOctavoCampo = "               "; // 15
        decimoNovenoCampo = "               "; // 15
        vigesimoPrimerCampo = "UNID";
        vigesimoSegundoCampo = "000000000000002.0000"; // Preguntar si se debería colocar 1 porque solo se va a registrar un registro
        vigesimoTercerCampo = "000000000000000.0000";
        vigesimoCuartoCampo = "000000000000000.0000";
        vigesimoQuintoCampo = "                                                                                                                                                                                                                                                               "; // 255
        vigesimoQuintoCampo = "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        "; // 2000
        vigesimoSextoCampo = "                                        "; // 40
        vigesimoSeptimoCampo = "    "; // 4
        vigesimoOctavoCampo = "          "; // 10
        vigesimoNovenoCampo = "               "; // 15
        trigesimoPrimerCampo = "0000355";
        trigesimoSegundoCampo = "                                                  "; // 50
        trigesimoTercerCampo = "                    "; // 20
        trigesimoCuartoCampo = "                    "; // 20
        trigesimoQuintoCampo = "                    "; // 20
        trigesimoSextoCampo = "99";
        trigesimoSeptimoCampo = "00000000\r\n";

        terceraLinea["CertificadosUtilizados"] = primerCampo + segundoCampo + tercerCampo + cuartoCampo + quintoCampo +
            sextoCampo + septimoCampo + octavoCampo + novenoCampo + decimoCampo + decimoPrimerCampo + decimoSegundoCampo +
            decimoTercerCampo + decimoCuartoCampo + decimoQuintoCampo + decimoSextoCampo + decimoSeptimoCampo + decimoOctavoCampo +
            decimoNovenoCampo + vigesimoPrimerCampo + vigesimoSegundoCampo + vigesimoTercerCampo + vigesimoCuartoCampo +
            vigesimoQuintoCampo + vigesimoSextoCampo + vigesimoSeptimoCampo + vigesimoOctavoCampo + vigesimoNovenoCampo +
            trigesimoPrimerCampo + trigesimoSegundoCampo + trigesimoTercerCampo + trigesimoCuartoCampo + trigesimoQuintoCampo +
            trigesimoSextoCampo + trigesimoSeptimoCampo;
        archivo.Rows.Add(terceraLinea);
        return archivo;
    }

    // Segunda línea en donde se identifica que se desea realizar una salida (deshabilitar pólizas) en el sistema Apolo
    public static DataTable CrearSegundaLinea(DataTable archivo, DataTable certificado)
    {
    //    DataRow segundaLinea = archivo.NewRow();
    //    string primerCampo, segundoCampo, tercerCampo, cuartoCampo, quintoCampo, sextoCampo, septimoCampo, octavoCampo, 
    //        novenoCampo, decimoCampo, decimoPrimerCampo, decimoSegundoCampo, decimoTercerCampo, decimoCuartoCampo, 
    //        decimoQuintoCampo, decimoSextoCampo, decimoSeptimoCampo, decimoOctavoCampo, decimoNovenoCampo, vigesimoPrimerCampo, 
    //        vigesimoSegundoCampo, vigesimoTercerCampo, vigesimoCuartoCampo, vigesimoQuintoCampo, vigesimoSextoCampo, 
    //        vigesimoSeptimoCampo, vigesimoOctavoCampo, vigesimoNovenoCampo, trigesimoPrimerCampo, trigesimoSegundoCampo,
    //        trigesimoTercerCampo, trigesimoCuartoCampo;
    //    primerCampo = "0000002";
    //    segundoCampo = "0450";
    //    tercerCampo = "00";
    //    cuartoCampo = "02";
    //    quintoCampo = "001";
    //    sextoCampo = "1";
    //    // Centro de Operaciones(APOLO) - Agencia(THOR): Se debe consultar en las tablas espejo lo equivalente
    //    int agencia = int.Parse(certificado.Rows[0]["age_Id"].ToString());
    //    septimoCampo = DAOConKardexPapeleria.ConsultarCentroOperaciones(agencia).Rows[0]["cenOpe_id"].ToString();
    //    octavoCampo = "SAP";
    //    novenoCampo = "00000001";
    //    decimoCampo = "20161010";
    //    decimoPrimerCampo = "890803304";
    //    decimoSegundoCampo = "62";
    //    decimoTercerCampo = "0";
    //    decimoCuartoCampo = "0";
    //    decimoQuintoCampo = "PRUEBAS DE SALIDAS";
    //    decimoSextoCampo = "     "; // 5
    //    decimoSeptimoCampo = "     "; // 5
    //    decimoOctavoCampo = "               "; // 15
    //    decimoNovenoCampo = "   "; // 3
    //    vigesimoPrimerCampo = "   "; // 3
    //    vigesimoSegundoCampo = "00000000";
    //    vigesimoTercerCampo = "          "; // 10
    //    vigesimoCuartoCampo = "               "; // 15
    //    vigesimoQuintoCampo = "   "; // 3
    //    vigesimoSextoCampo = "               "; // 15
    //    vigesimoSeptimoCampo = "                                                  "; // 50
    //    vigesimoOctavoCampo = "               "; // 15
    //    vigesimoNovenoCampo = "                              "; // 30
    //    trigesimoPrimerCampo = "0000000000.0000";
    //    trigesimoSegundoCampo = "000000000000000.0000";
    //    trigesimoTercerCampo = "000000000000000.0000";
    //    trigesimoCuartoCampo = "                                                                                                                                                                                                                                                               \r\n"; // 255
        
    //    segundaLinea["CertificadosUtilizados"] = primerCampo + segundoCampo + tercerCampo + cuartoCampo + quintoCampo + 
    //        sextoCampo + septimoCampo + octavoCampo + novenoCampo + decimoCampo + decimoPrimerCampo + decimoSegundoCampo + 
    //        decimoTercerCampo + decimoCuartoCampo + decimoQuintoCampo + decimoSextoCampo + decimoSeptimoCampo + decimoOctavoCampo +
    //        decimoNovenoCampo + vigesimoPrimerCampo + vigesimoSegundoCampo + vigesimoTercerCampo + vigesimoCuartoCampo + 
    //        vigesimoQuintoCampo + vigesimoSextoCampo + vigesimoSeptimoCampo + vigesimoOctavoCampo + vigesimoNovenoCampo +
    //        trigesimoPrimerCampo + trigesimoSegundoCampo + trigesimoTercerCampo + trigesimoCuartoCampo;
    //    archivo.Rows.Add(segundaLinea);
       return archivo;
    }

    // Línea de encabezado que contiene un valor fijo
    public static DataTable CrearEncabezadoArchivo(DataTable archivo)
    {
        DataRow primeraLinea = archivo.NewRow();
        primeraLinea["CertificadosUtilizados"] = "0000001 00000001 002\r\n";
        archivo.Rows.Add(primeraLinea);
        return archivo;
    }

    // Se crea la estructura del DataTable con una sola columna en donde se ingresará la información que después convertirá en 
    // un archivo
    public static DataTable CrearEstructuraDataTable()
    {
        DataTable archivo = new DataTable();
        DataColumn columna = new DataColumn();
        columna.DataType = System.Type.GetType("System.String");
        columna.AllowDBNull = true;
        columna.Caption = "CertificadosUtilizados";
        columna.ColumnName = "CertificadosUtilizados";
        archivo.Columns.Add(columna);
        return archivo;
    }

    // Permite la exportación del DataTable al archivo
    public static void CrearArchivo(DataTable contenido)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = @"D:\Fondos\Salida.txt";
        //Directory.CreateDirectory(path);
        using (FileStream file = File.Create(path))
        {
            foreach(DataRow linea in contenido.Rows)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(linea[0].ToString());
                file.Write(info, 0, info.Length);                
            }
        }
    }
    #endregion

    #region RecibirInformacion

    public static void ConsultarPolizasDisponibles(int localidad, int asesor)
    {
        // Se deben consultar los códigos equivalentes para localidad y asesor en Apolo
        int bodega = ConsultarEquivalenteLocalidad(localidad);
        int ubicacion = ConsultarEquivalenteAsesor(asesor);
        // Consultar la vista en la base de datos (Mando la bodega y la ubicación y devuelve el conjunto de pólizas disponibles)
        //DataTable 
    }

    public static int ConsultarEquivalenteLocalidad(int localidad)
    {
        DataTable bodegaLocalidad = DAOConKardexPapeleria.ConsultarEquivalenteLocalidadBodega(localidad);
        int bodega = int.Parse(bodegaLocalidad.Rows[0]["bod_Id"].ToString());
        return bodega;
    }

    public static int ConsultarEquivalenteAsesor(int asesor)
    {
        DataTable asesorUbicacion = DAOConKardexPapeleria.ConsultarEquivalenteLocalidadBodega(asesor);
        int ubicacion = int.Parse(asesorUbicacion.Rows[0]["ubi_Id"].ToString());
        return ubicacion;
    }

    #endregion
}