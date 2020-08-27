using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;


/// <summary>
/// Summary description for Pagos
/// </summary>
public class Pagos
{
    public   DataTable ConsultarPagadurias()
    {
        DAOPagos objPagos = new DAOPagos();

        DataTable dtPagadurias = new DataTable();
        dtPagadurias = objPagos.ConsultarPagadurias();
        return dtPagadurias;
    }


    public  DataTable ConsultarCertificadosConciliacion(int cer_Convenio)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtCertificadosConciliacion = new DataTable();
        dtCertificadosConciliacion = objPagos.ConsultarCertificadosConciliacion(cer_Convenio);
        return dtCertificadosConciliacion;
    }


    public  DataTable ConsultarCertificadosPorPagos(int ter_Id, int cer_Convenio)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtCertificadosPorPagos = new DataTable();
        dtCertificadosPorPagos = objPagos.ConsultarCertificadosPorPagos(ter_Id, cer_Convenio);
        return dtCertificadosPorPagos;
    }

    public  DataTable ConsultarSoporteBancarioParaPago(int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarSoporteBancarioParaPago = new DataTable();
        dtConsultarSoporteBancarioParaPago = objPagos.ConsultarSoporteBancarioParaPago(con_Id);
        return dtConsultarSoporteBancarioParaPago;

    }

    public  DataTable ConsultarMorasEnPagos(int pro_Id, int ter_Id, int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtMorasEnPagos = new DataTable();
        dtMorasEnPagos = objPagos.ConsultarMorasEnPagos(pro_Id, ter_Id, con_Id);
        return dtMorasEnPagos;
    }


    public  DataTable ConsultarPrioridadPagoPorProducto(int pro_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtPrioridadPago = new DataTable();
        dtPrioridadPago = objPagos.ConsultarPrioridadPagoPorProducto(pro_Id);
        return dtPrioridadPago;
    }

    public  DataTable ConsultarProductoParaPago(double ter_Id, int cer_Convenio)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtProductoParaPago = new DataTable();
        dtProductoParaPago = objPagos.ConsultarProductoParaPago(ter_Id, cer_Convenio);
        return dtProductoParaPago;
    }

    public  string ConsultarProductoParaDevolucionDePrima(double terId, int cer_Convenio)
    {
        DAOPagos objPagos = new DAOPagos();
        string proId;
        proId = objPagos.ConsultarProductoParaDevolucionDePrima(terId, cer_Convenio);
        return proId;
    }

    public DataTable ConsultarNombreUsuarioPorCedula(double cedula)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtDocumento = new DataTable();
        dtDocumento = objPagos.ConsultarNombreUsuarioPorCedula(cedula);
        return dtDocumento;
    }

    public  DataTable IngresarPagoCliente(double terId, double pagoValor, DateTime fecha, int convenio, double pagoMes, double pagoAnio)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtIdPago = new DataTable();
        dtIdPago = objPagos.IngresarPagoCliente(terId, pagoValor, fecha, convenio, pagoMes, pagoAnio);
        return dtIdPago;
    }

    public  double ConsularPorcentajeParticipacion(int paga_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        double porcentajeParticipacion = objPagos.ConsularPorcentajeParticipacion(paga_Id);
        return porcentajeParticipacion;
    }

    public  void IngresarAplicacionPagoCliente(double terId, int idPago, int idProducto, DateTime fecha, int dev_Id, double valor, int convenio, double aplPagoReversion, double pagoRecibo, double cer_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        objPagos.IngresarAplicacionPagoCliente(terId, idPago, idProducto, fecha, dev_Id, valor, convenio, aplPagoReversion, pagoRecibo,cer_Id);        
    }

    public  void InsertarAplicacionPagoParaDevolucion(double terId, int idPago, string idProducto,double valor, int dev_Id, int convenio, double aplPagoReversion)
    {
        DAOPagos objPagos = new DAOPagos();
        objPagos.InsertarAplicacionPagoParaDevolucion(terId, idPago, idProducto, valor, dev_Id, convenio, aplPagoReversion);
    }

    public  int ConsultarIdAplicacionPago(double ter_Id, int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        int idApliPago;
        idApliPago = objPagos.ConsultarIdAplicacionPago(ter_Id, con_Id);
        return idApliPago;
    }

    public  void InsertarRecibo(int convenio)
    {
        DAOPagos objPagos = new DAOPagos();
        objPagos.InsertarRecibo(convenio);
    }

    public  DataTable ConsultarIdPago()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarIdPago = new DataTable();
        dtConsultarIdPago = objPagos.ConsultarIdPago();
        return dtConsultarIdPago;
    }

    public  DataTable ActualizarNovedadesAplicadas(double ter_Id, int con_Id,int proId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarNovedadesAplicadas = new DataTable();
        dtActualizarNovedadesAplicadas = objPagos.ActualizarNovedadesAplicadas(ter_Id, con_Id,proId);
        return dtActualizarNovedadesAplicadas;
    }

    public  DataTable ConsultarConveniosConciliacion(int paga_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarConveniosConciliacion = new DataTable();
        dtConsultarConveniosConciliacion = objPagos.ConsultarConveniosConciliacion(paga_Id);
        return dtConsultarConveniosConciliacion;
    }

    public  DataTable ConsultarRecibos()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarRecibo = new DataTable();
        dtConsultarRecibo = objPagos.ConsultarRecibos();
        return dtConsultarRecibo;
    }

    public  DataTable ConsultarCompaniasGenerales()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCompaniasGenerales = new DataTable();
        dtConsultarCompaniasGenerales = objPagos.ConsultarCompaniasGenerales();
        return dtConsultarCompaniasGenerales;
    }

    public DataTable ConsultarRecibosConSeleccionables(int paga_Id, int age_Id, int con_Id, int com_Id, int pro_Id, string rec_Numero, string rec_Identificacion)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarRecibosConSeleccionables = new DataTable();
        dtConsultarRecibosConSeleccionables = objPagos.ConsultarRecibosConSeleccionables(paga_Id, age_Id, con_Id, com_Id, pro_Id,rec_Numero,rec_Identificacion);
        return dtConsultarRecibosConSeleccionables;
    }


    public  void CrearRecibosCaja(int age_Id, int con_Id, int rec_Oficina, int rec_Identificacion,string cedulaCreador)
    {
        DAOPagos objPagos = new DAOPagos();
        objPagos.CrearRecibosCaja(age_Id, con_Id, rec_Oficina, rec_Identificacion, cedulaCreador);
    }

    public  DataTable ConsultarPagoPorOficina(double ter_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarPagoPorOficina = new DataTable();
        dtConsultarPagoPorOficina = objPagos.ConsultarPagoPorOficina(ter_Id);
        return dtConsultarPagoPorOficina;
    }

    public  DataTable ConsultarConvenioPagoOficina(double ter_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarConvenioPagoOficina = new DataTable();
        dtConsultarConvenioPagoOficina = objPagos.ConsultarConvenioPagoOficina(ter_Id);
        return dtConsultarConvenioPagoOficina;
    }

    public  DataTable InformeAplicacionPagos(int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtInformeAplicacionPagos = new DataTable();
        dtInformeAplicacionPagos = objPagos.InformeAplicacionPagos(con_Id);
        return dtInformeAplicacionPagos;
    }

    //capa de negocio que me trae el historial de pagos por cliente
    public  DataTable InformeAplicacionPagosPorOficina(int con_Id, double ter_Id,int proId, int comId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtInformeAplicacionPagos = new DataTable();
        dtInformeAplicacionPagos = objPagos.InformeAplicacionPagosPorOficina(con_Id, ter_Id, proId, comId);
        return dtInformeAplicacionPagos;
    }

    public  DataTable InformeAplicacionPagosBusqueda(int con_Id, DateTime fecha_Inicial, DateTime fecha_Final, int com_Id, int pro_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtInformeAplicacionPagosBusqueda = new DataTable();
        dtInformeAplicacionPagosBusqueda = objPagos.InformeAplicacionPagosBusqueda(con_Id, fecha_Inicial, fecha_Final, com_Id, pro_Id);
        return dtInformeAplicacionPagosBusqueda;
    }

    public  DataTable ConsultarCompaniaEnConciliacion(int com_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCompaniaEnConciliacion = new DataTable();
        dtConsultarCompaniaEnConciliacion = objPagos.ConsultarCompaniaEnConciliacion(com_Id);
        return dtConsultarCompaniaEnConciliacion;
    }
  
    public  DataTable ConsultarRecaudoEsperado()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarRecaudoEsperado();
        return dt;

    }
    public  DataTable ConsultarMesProduccionActual(int pro_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarMesProduccionActual(pro_Id);
        return dt;

    }

    public DataTable CargarDigitacion()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtRecaudo = new DataTable();
        dtRecaudo = this.ConsultarRecaudoEsperado();
        DataTable dtRecaudoEsperado = new DataTable();
        DataColumn columns = new DataColumn();

        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "Vigencia";
        dtRecaudoEsperado.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "Prima";
        dtRecaudoEsperado.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "Cedula";
        dtRecaudoEsperado.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "Convenio";
        dtRecaudoEsperado.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "Pagaduria";
        dtRecaudoEsperado.Columns.Add(columns);

        foreach (DataRow row in dtRecaudo.Rows)
        {
            int mesProduccionActual = 0;
            int mesProduccionCertificado = 0;

            DataTable dtDiaFrontera = new DataTable();
            dtDiaFrontera = this.ConsultarMesProduccionActual(int.Parse(row["Producto"].ToString()));

            int mesResta = int.Parse(dtDiaFrontera.Rows[0]["mes_Vigencia"].ToString()) - 1;

            DateTime mesVigencia;
            mesVigencia = DateTime.Today;
            mesVigencia = mesVigencia.AddMonths(mesResta);
            if (row["Estado"].ToString() == "PRODUCCION NUEVA")
            {

                mesProduccionActual = DateTime.Now.Month;


                if (int.Parse(row["mes"].ToString()) + 1 == 13)
                {
                    mesProduccionCertificado = 1;
                }

                if (int.Parse(row["mes"].ToString()) + 1 <= 12)
                {
                    mesProduccionCertificado = int.Parse(row["mes"].ToString() + 1);
                }


                if (mesProduccionCertificado == mesProduccionActual)
                {

                    int resultado = objPagos.ConsultarAplicacionPagoParaRecaudoEsperado(int.Parse(row["Cedula"].ToString()),
                        int.Parse(dtRecaudo.Rows[0]["Producto"].ToString()), mesVigencia, int.Parse(row["Prima"].ToString()));
                    
                    if(resultado != 0)
                    {
                        DataRow recaudo = dtRecaudoEsperado.NewRow();
                        //recaudo["Vigencia"] = row["Vigencia"].ToString();
                        recaudo["Vigencia"] = mesVigencia;
                        recaudo["Prima"] = resultado;
                        recaudo["Cedula"] = row["Cedula"].ToString();
                        recaudo["Convenio"] = row["Convenio"].ToString();
                        recaudo["Pagaduria"] = row["Pagaduria"].ToString();
                        dtRecaudoEsperado.Rows.Add(recaudo);
                    }
                }

            }
            else
            {

                DataRow recaudo = dtRecaudoEsperado.NewRow();
                recaudo["Vigencia"] = row["Vigencia"].ToString();
                recaudo["Prima"] = row["Prima"].ToString();
                recaudo["Cedula"] = row["Cedula"].ToString();
                recaudo["Convenio"] = row["Convenio"].ToString();
                recaudo["Pagaduria"] = row["Pagaduria"].ToString();
                dtRecaudoEsperado.Rows.Add(recaudo);
            }
        }
        return dtRecaudoEsperado;
    }

    public DataTable ConsultarSopIdSoporteBancario(int sopdet_Id, int bandera)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarSopIdSoporteBancario(sopdet_Id, bandera);
        return dt;
    }

    public  DataTable ConsultarReciboParaSoporte(int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarReciboParaSoporte(con_Id);
        return dt;
    }

    public  void InsertarNewSoportePorRecibo(int rec_Id, int sopdet_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        objPagos.InsertarNewSoportePorRecibo(rec_Id, sopdet_Id);
    }


    //Metodo que trae el recibo para ser impreso, recibe como parametro el id del recibo
    public  DataTable ConsultarReciboImprimir(int rec_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarReciboImprimir(rec_Id);
        return dt;
    }

    //Metodo que trae la vigencia y valor de las aplicaciones  del recibo para ser impreso, recibe como parametro el id del recibo, se usa para pago individual
    public  DataTable ConsultarAplicacionesReciboImprimir(int rec_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.ConsultarAplicacionesReciboImprimir(rec_Id);
        return dt;
    }
    public  DataTable ConsultarCertificadoReversion(int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCertificadoReversion = new DataTable();
        dtConsultarCertificadoReversion = objPagos.ConsultarCertificadoReversion(con_Id);
        return dtConsultarCertificadoReversion;

    }

    public DataTable ConsultarCertificadoReversionConsulta(int con_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCertificadoReversion = new DataTable();
        dtConsultarCertificadoReversion = objPagos.ConsultarCertificadoReversionConsulta(con_Id);
        return dtConsultarCertificadoReversion;

    }

    public  DataTable ConsultarUltimoPagoParaReversion(double ter_Id, DateTime fecha,double pro_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarUltimoPagoParaReversion = new DataTable();
        dtConsultarUltimoPagoParaReversion = objPagos.ConsultarUltimoPagoParaReversion(ter_Id, fecha, pro_Id);
        return dtConsultarUltimoPagoParaReversion;

    }

    public  DataTable ConsultarInformacionAnteriorPagosReversion(double ter_Id, DateTime fecha, double pro_Id)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarInformacionAnteriorPagosReversion = new DataTable();
        dtConsultarInformacionAnteriorPagosReversion = objPagos.ConsultarInformacionAnteriorPagosReversion(ter_Id, fecha, pro_Id);
        return dtConsultarInformacionAnteriorPagosReversion;
    }

    public  void RealizarReversion(DataTable dtInformacionCertificado)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarInformacionAnteriorPagosReversion = new DataTable();
        DataTable dtBorradoDeDatos = new DataTable();
        //Consultar las aplicaciones de los clientes que van para reversion, las cuales son mayores al inicio de vigencia del certificado
        dtConsultarInformacionAnteriorPagosReversion = ConsultarInformacionAnteriorPagosReversion(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), DateTime.Parse(dtInformacionCertificado.Rows[0]["cer_VigenciaDesde"].ToString()), double.Parse(dtInformacionCertificado.Rows[0]["Producto"].ToString()));

        DataTable dtCertificadoAnterior = new DataTable();

        //Pregunta si el certificado que se esta recorriendo ya posee un certificado anterior
        if (dtInformacionCertificado.Rows[0]["cer_IdAnterior"].ToString() != "")
        {
            //Consulta el certificado con el cer_Id que se envie como parametro
            dtCertificadoAnterior = objPagos.ConsultarCertificado(double.Parse(dtInformacionCertificado.Rows[0]["cer_IdAnterior"].ToString()));
        }

        //Actualiza el estado de negocio del certificado recorrido a "NO APLICO"
        objPagos.ActualizarEstadoNegocioDevolucion("NO APLICO", double.Parse(dtInformacionCertificado.Rows[0]["cer_Id"].ToString()));
        
        //------------------------------------
        //Actualiza la novedad a no aplico nov_Estado = 0
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        AdministrarNovedades objAdministrarNovedades = new AdministrarNovedades();
        DataTable dtArchivo = new DataTable();
        dtArchivo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtInformacionCertificado.Rows[0]["Producto"].ToString()), int.Parse(dtInformacionCertificado.Rows[0]["convenio"].ToString()));
        DataTable dtNovedadActual = new DataTable();
        dtNovedadActual = objAdministrarCertificados.ConsultarNovedadActual(int.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()), 0);
        if (dtNovedadActual.Rows.Count != 0)
        {
            AdministrarNovedades.ActualizarDePendienteASinAplicar(int.Parse(dtNovedadActual.Rows[0]["nov_Id"].ToString()), 0, "1");
        }
        //-------------------------------------

        //Pregunta si el certificado que se esta recorriendo ya posee un certificado anterior
        if(dtInformacionCertificado.Rows[0]["cer_IdAnterior"].ToString() != "")
        {
            //Si posee un certificado anterior se pasara a "VIGENTE", con el fin de que este vuelva a activarse, ya que el actual se actualizo a "NO APLICO"
            objPagos.ActualizarEstadoNegocioDevolucion("VIGENTE", double.Parse(dtInformacionCertificado.Rows[0]["cer_IdAnterior"].ToString()));
            //Crea novedad
            //SI TENIA CERTIFICADO ANTERIOR DUPLICAR LA ULTIMA NOVEDAD APLICADA Y PONER EN DEV_ESTADO=1 Y ENVIADA=0
            if (dtNovedadActual.Rows.Count != 0)
            {
                DataTable dtNovedadAnterior = AdministrarNovedades.ConsultarNovedadPorTercero("0", "0", "0", dtNovedadActual.Rows[0]["nov_Id"].ToString());
                AdministrarNovedades.InsertarNovedades(int.Parse(dtNovedadActual.Rows[0]["Cedula"].ToString()), dtNovedadActual.Rows[0]["TipoNovedad"].ToString(), 1, int.Parse(dtNovedadActual.Rows[0]["Pagaduria"].ToString()), int.Parse(dtNovedadActual.Rows[0]["Convenio"].ToString()), int.Parse(dtNovedadActual.Rows[0]["Archivo"].ToString()), int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString()), 0, int.Parse(dtNovedadAnterior.Rows[0]["nov_Mes"].ToString()), int.Parse(dtNovedadAnterior.Rows[0]["nov_Anio"].ToString()));
            }
        }
        else
        {
            //Crea novedad de retiro
            //SI NO TIENE CERTIFICADO ANTERIOR CREAR UNA NOVEDAD DE RETIRO
            if (dtNovedadActual.Rows.Count != 0)
            {
                DataTable dtNovedadAnterior = AdministrarNovedades.ConsultarNovedadPorTercero("0", "0", "0", dtNovedadActual.Rows[0]["nov_Id"].ToString());
                AdministrarNovedades.InsertarNovedades(int.Parse(dtNovedadAnterior.Rows[0]["ter_Id"].ToString()), "R", 1, int.Parse(dtNovedadAnterior.Rows[0]["paga_Id"].ToString()), int.Parse(dtNovedadAnterior.Rows[0]["con_Id"].ToString()), int.Parse(dtNovedadAnterior.Rows[0]["arcpag_Id"].ToString()), 0, 0, int.Parse(dtNovedadAnterior.Rows[0]["nov_Mes"].ToString()), int.Parse(dtNovedadAnterior.Rows[0]["nov_Anio"].ToString()));
            }

        }

        /*Pregunta si el tipo movimiento es un ingreso y si es diferente de coversión, todo esto con el fin de*/
        if(int.Parse(dtInformacionCertificado.Rows[0]["TipoMovimiento"].ToString()) == 53 && int.Parse(dtInformacionCertificado.Rows[0]["casesp_Id"].ToString()) != 2)
        {
           //Pregunta si el certificado nuevo ya tenia algun pago
            if(dtConsultarInformacionAnteriorPagosReversion.Rows.Count > 0)
            {
                    //Recorre el foreach para actualizar las aplicaciones realizadas a devolución de prima
                    foreach(DataRow dt in dtConsultarInformacionAnteriorPagosReversion.Rows)
                    {
                        //Actualizar aplicaciones a devolución segun su pago_Id enviado como parametro
                        objPagos.ActualizarDepIdParaReversion(double.Parse(dt["aplPago_Id"].ToString()), 1);
                    }
            }
        }
        else
        {
            //Recorre el dt con los pagos que van para reversión
            foreach (DataRow dt in dtConsultarInformacionAnteriorPagosReversion.Rows)
            {
                //Actualiza las aplicaciones necesarias al estado reversión
                objPagos.ActualizarReversionYBorradoDeAplicacion(double.Parse(dt["aplPago_Id"].ToString()), 0);
            }

            int recorre = 0;
            //Recorre el dt con todos los pagos mayores al inicio de vigencia
            foreach(DataRow dt in dtConsultarInformacionAnteriorPagosReversion.Rows)
            {
                //if (recorre == 0)
                //{
                    //Consulta las aplicaciones que hay por cada uno de los pagos mayores al inicio de vigencia
                    DataTable dtConsultarInformacionAnteriorPagosReversionPagoId = new DataTable();
                    dtConsultarInformacionAnteriorPagosReversionPagoId = objPagos.ConsultarInformacionAnteriorPagosReversionPagoId(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), DateTime.Parse(dtInformacionCertificado.Rows[0]["cer_VigenciaDesde"].ToString()), double.Parse(dtInformacionCertificado.Rows[0]["Producto"].ToString()), double.Parse(dt["pago_Id"].ToString()));

                    /*Llena dt con la misma informacion de dtConsultarInformacionAnteriorPagosReversionPagoId, todo esto con el fin de realizar
                     una funcionalidad diferente */
                    dtBorradoDeDatos = dtConsultarInformacionAnteriorPagosReversionPagoId;

                    //Crea variable y la iguala a 0
                    double pagos = 0;

                    //Recorre el dt con cada unas de las aplicaciones realizadas por pago
                    foreach (DataRow dt2 in dtConsultarInformacionAnteriorPagosReversionPagoId.Rows)
                    {
                        //Suma los valores de estas aplicaciones
                        pagos += int.Parse(dt2["aplPago_Valor"].ToString());
                    }
                    try
                    {
                        //Recorre el while siempre y cuando el pago aun tenga un valor mayor a 0
                        while (pagos > 0)
                        {

                            DataTable dtProductoARealizarPago = new DataTable();
                            double valorAplicar = 0;
                            //Pregunta si ya posee un certificado anterior
                            if (dtCertificadoAnterior.Rows.Count > 0)
                            {
                                //Consulta el producto al cual se le debe hacer la reversión y se le envia el producto de su certificado anterior
                                objPagos.ActualizarConvenioCertificado(double.Parse(dtInformacionCertificado.Rows[0]["cer_IdAnterior"].ToString()), double.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()));
                                dtProductoARealizarPago = objPagos.ConsultarProductoParaPagoReversion(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()), double.Parse(dtCertificadoAnterior.Rows[0]["pro_Id"].ToString()));
                            }
                            else
                            {
                                //Consulta el producto al cual se le debe hacer la reversión y se le envia el producto de su certificado actual
                                dtProductoARealizarPago = objPagos.ConsultarProductoParaPagoReversion(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()), double.Parse(dtInformacionCertificado.Rows[0]["Producto"].ToString()));
                            }
                            if (double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()) > 0)
                            {
                                //Asigna en una variable el valor que se debe aplicar, traido desde dtProductoARealizarPago
                                valorAplicar = double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                                //pregunta si el pago es menor a lo que se le debe pagar, en caso de ser asi el valor a aplicar es igual a la variable pago
                                if (pagos < double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString()))
                                {
                                    valorAplicar = pagos;
                                }
                                //Pregunta si el certificado que se esta recorriendo es un caso de conversion
                                if (int.Parse(dtInformacionCertificado.Rows[0]["casesp_Id"].ToString()) == 2)
                                {
                                    //Ingresa la aplicacion y le asigna a esta el mismo rec_Id del certificado anterior
                                    this.IngresarAplicacionPagoCliente(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dt["pago_Id"].ToString()), int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()),
                                    Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar, int.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()), 1, double.Parse(dtConsultarInformacionAnteriorPagosReversionPagoId.Rows[0]["pago_Recibo"].ToString()), double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString()));
                                }
                                else
                                {
                                    //Ingresa la aplicacion y le asigna a esta el rec_Id calculado por el sistema
                                    this.IngresarAplicacionPagoCliente(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dt["pago_Id"].ToString()), int.Parse(dtProductoARealizarPago.Rows[0]["pro_Id"].ToString()),
                                    Convert.ToDateTime(dtProductoARealizarPago.Rows[0]["VIGENCIA APLICAR"].ToString()), 0, valorAplicar, int.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()), 0, double.Parse(dtConsultarInformacionAnteriorPagosReversionPagoId.Rows[0]["pago_Recibo"].ToString()), double.Parse(dtProductoARealizarPago.Rows[0]["CER_ID"].ToString()));
                                }

                                //Le resta a la variable pago, el valor que se aplico anteriormente
                                pagos -= double.Parse(dtProductoARealizarPago.Rows[0]["VALOR APLICAR"].ToString());
                            }
                            else
                            {
                                valorAplicar = pagos;

                                //Ingresa la aplicacion y le asigna a esta el rec_Id calculado por el sistema
                                this.IngresarAplicacionPagoCliente(double.Parse(dtInformacionCertificado.Rows[0]["Cedula"].ToString()), int.Parse(dt["pago_Id"].ToString()), int.Parse(dtInformacionCertificado.Rows[0]["Producto"].ToString()),
                                 DateTime.Today, 1, valorAplicar, int.Parse(dtInformacionCertificado.Rows[0]["Convenio"].ToString()), 0, double.Parse(dtConsultarInformacionAnteriorPagosReversionPagoId.Rows[0]["pago_Recibo"].ToString()), double.Parse(dtInformacionCertificado.Rows[0]["cer_Id"].ToString()));

                                //Le resta a la variable pago, el valor que se aplico anteriormente
                                pagos -= valorAplicar;
                            }
                        }
                    }
                    catch
                    {

                    }

                    /*Recorre el dtBorradoDeDatos que es igual a dtConsultarInformacionAnteriorPagosReversionPagoId, esto con el fin
                      de eliminar las aplicaciones ya que no son requeridas luego de realizar toda la funcionalidad anterior*/
                  
                        foreach (DataRow dt3 in dtBorradoDeDatos.Rows)
                        {
                            //Borra las aplicaciones correspondientes luego de realizar la funcionalidad anterior
                            objPagos.ActualizarReversionYBorradoDeAplicacion(double.Parse(dt3["aplPago_Id"].ToString()), 1);
                            recorre = 1;
                        }
                //}
            }
        }
    }

    public DataTable ActualizarFechaYMarcarReestructuracion(double con_Id, double valCon_Reestructuracion)
    {
        //Actualizar fecha de reestructuracion de un convenio
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarFechaYMarcarReestructuracion = new DataTable();
        dtActualizarFechaYMarcarReestructuracion = objPagos.ActualizarFechaYMarcarReestructuracion(con_Id, valCon_Reestructuracion);
        return dtActualizarFechaYMarcarReestructuracion;
    }

    public DataTable ConsultarConveniosReversionManual()
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarFechaYMarcarReestructuracion = new DataTable();
        dtActualizarFechaYMarcarReestructuracion = objPagos.ConsultarConveniosReversionManual();
        return dtActualizarFechaYMarcarReestructuracion;
    }

    public DataTable ConsultarSoportePagosPorOficina(double terId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtconsultarSoportePagosPorOficina = new DataTable();
        dtconsultarSoportePagosPorOficina = objPagos.ConsultarSoportePagosPorOficina(terId);
        return dtconsultarSoportePagosPorOficina;
    }

    public DataTable CrearDetalleSoporteBancario(double sopId, double sopdetValor, double sopdetTipo, double pagoId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtCrearDetalleSoporteBancario = new DataTable();
        dtCrearDetalleSoporteBancario = objPagos.CrearDetalleSoporteBancario(sopId, sopdetValor, sopdetTipo, pagoId);
        return dtCrearDetalleSoporteBancario;
    }

    public DataTable ActualizarEstadoSoporteBancario(double sopId, double estId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarEstadoSoporteBancario = new DataTable();
        dtActualizarEstadoSoporteBancario = objPagos.ActualizarEstadoSoporteBancario(sopId,estId);
        return dtActualizarEstadoSoporteBancario;
    }

    public DataTable ActualizarValorAplicadoSoporteBancario(double sopId, double valorAplicado)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarValorAplicadoSoporteBancario = new DataTable();
        dtActualizarValorAplicadoSoporteBancario = objPagos.ActualizarValorAplicadoSoporteBancario(sopId, valorAplicado);
        return dtActualizarValorAplicadoSoporteBancario;
    }

    public DataTable ActualizarValorYObservacionDevolucion(double aplPagoId, double aplPagoValorDevolucion, string aplPagoObservacionesDevolucion, int aplPagoEstDevolucion, int devId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtActualizarValorYObservacionDevolucion = new DataTable();
        dtActualizarValorYObservacionDevolucion = objPagos.ActualizarValorYObservacionDevolucion(aplPagoId, aplPagoValorDevolucion, aplPagoObservacionesDevolucion, aplPagoEstDevolucion, devId);
        return dtActualizarValorYObservacionDevolucion;
    }

    public DataTable ConsultarProductosConvenio(double conId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarProductosConvenio = new DataTable();
        dtConsultarProductosConvenio = objPagos.ConsultarProductosConvenio(conId);
        return dtConsultarProductosConvenio;
    }

    public DataTable ConsultarCompaniaPorCertificado(double comId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCompaniaPorCertificado = new DataTable();
        dtConsultarCompaniaPorCertificado = objPagos.ConsultarCompaniaPorCertificado(comId);
        return dtConsultarCompaniaPorCertificado;
    }

    public DataTable ConsultarAplicacionesMayoresFechaVigencia(DateTime fecha, double terId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarAplicacionesMayoresFechaVigencia = new DataTable();
        dtConsultarAplicacionesMayoresFechaVigencia = objPagos.ConsultarAplicacionesMayoresFechaVigencia(fecha, terId);
        return dtConsultarAplicacionesMayoresFechaVigencia;
    }

    public DataTable ConsultarValorAgrupadoDePago(DateTime fecha, double terId, double proId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarValorAgrupadoDePago = new DataTable();
        dtConsultarValorAgrupadoDePago = objPagos.ConsultarValorAgrupadoDePago(fecha, terId,proId);
        return dtConsultarValorAgrupadoDePago;
    }

    public DataTable spConsultarCausasCedulasNoCoincidentes(string ter_Id, int con_Id, int opcion)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dt = new DataTable();
        dt = objPagos.spConsultarCausasCedulasNoCoincidentes(ter_Id, con_Id, opcion);
        return dt;
    }

    //Metodo que consulta de la base de datos la agencia para el usuario
    public DataTable ConsultarAgenciasUsuario(string usuario)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarAgenciasUsuario = new DataTable();
        dtConsultarAgenciasUsuario = objPagos.ConsultarAgenciasUsuario(usuario);
        return dtConsultarAgenciasUsuario;
    }
}