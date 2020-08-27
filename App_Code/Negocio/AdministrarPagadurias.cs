using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de AdministrarPagadurias
/// </summary>
public class AdministrarPagadurias
{


    public static DataTable ConsultarPagadurias(int? idPaga, string numIdPaga, string nombrePaga)
    {
        
        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarPagadurias(idPaga, numIdPaga, nombrePaga);
        return dt;

    }


    public static DataTable mostrarDepartamento(int? idDepto, string nomDepto)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_MostrarDepartamento(idDepto, nomDepto);
        return dt;
    }


    public static DataTable mostrarCiudades(int? idCiud, string nomCiud, int? idDepto)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_MostrarCiudad(idCiud, nomCiud, idDepto);
        return dt;
    }


    public static DataTable ConsultarActividadEconomica(int? idActEcon, string nomActEcon)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_ConsultarActividadEconomica(idActEcon, nomActEcon);
        return dt;

    }

    public static DataTable ConsultarFechaEntregaNovedades(int? idFecEntNov, string tipoFecEntNov)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_ConsultarFechaEntregaNovedades(idFecEntNov, tipoFecEntNov);
        return dt;

    }


    public static int RegistrarPagaduria(
                                            string paga_Id,
                                            string ciu_Id,
                                            string dep_Id,
                                            string act_Id,
                                            string paga_Identificacion,
                                            string paga_Nombre,
                                            string paga_Direccion,
                                            string paga_Telefono,
                                            string paga_Visacion,
                                            string paga_NumeroEmpleados,
                                            string paga_PorcentajeParticipacion,
                                            string paga_FechaEntregaNovedades,
                                            string paga_ResponsablePago,
                                            string paga_ResponsablePagoCorreo,
                                            string paga_ResponsablePagoTelefono,
                                            string paga_ResponsablePagoCelular,
                                            string paga_Contacto,
                                            string paga_ContactoCorreo,
                                            string paga_ContactoTelefono,
                                            string paga_ContactoCelular,
                                            string paga_ResponsableLegal,
                                            string paga_ResponsableLegalCorreo,
                                            string paga_ResponsableLegalTelefono,
                                            string paga_ResponsableLegalCelular,
                                            string paga_Correo,
                                            string paga_Web,
                                            string paga_ResponsablePagoFechaCumple,
                                            string paga_ContactoFechaCumple,
                                            string paga_ResponsableLegalFechaCumple,
                                            string paga_EstadoPagaduria
                                         )
    {
        
        int idPaga = DAOAdministrarPagadurias.sp_RegistrarPagaduria(
                                                                        paga_Id,
                                                                        ciu_Id,
                                                                        dep_Id,
                                                                        act_Id,
                                                                        paga_Identificacion,
                                                                        paga_Nombre,
                                                                        paga_Direccion,
                                                                        paga_Telefono,
                                                                        paga_Visacion,
                                                                        paga_NumeroEmpleados,
                                                                        paga_PorcentajeParticipacion,
                                                                        paga_FechaEntregaNovedades,
                                                                        paga_ResponsablePago,
                                                                        paga_ResponsablePagoCorreo,
                                                                        paga_ResponsablePagoTelefono,
                                                                        paga_ResponsablePagoCelular,
                                                                        paga_Contacto,
                                                                        paga_ContactoCorreo,
                                                                        paga_ContactoTelefono,
                                                                        paga_ContactoCelular,
                                                                        paga_ResponsableLegal,
                                                                        paga_ResponsableLegalCorreo,
                                                                        paga_ResponsableLegalTelefono,
                                                                        paga_ResponsableLegalCelular,
                                                                        paga_Correo, 
                                                                        paga_Web,
                                                                        paga_ResponsablePagoFechaCumple,
                                                                        paga_ContactoFechaCumple,
                                                                        paga_ResponsableLegalFechaCumple,
                                                                        @paga_EstadoPagaduria
                                                                   );
        return idPaga;

    }



    public static string EliminarPagaduria(int paga_Id)
    {

        string idPaga = DAOAdministrarPagadurias.sp_EliminarPagaduria(paga_Id);
        return idPaga;
    }
    
    
    public static DataTable ConsultarArchivosSoportePagadurias(int? idSopPaga, string nomSopPaga, int? idPaga)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarArchivosSoportePagadurias(idSopPaga, nomSopPaga, idPaga);
        return dt;

    }


    public static int RegistrarArchivosSoportePagaduria(string idSopPaga, string idPaga,
                                            string nomSopPaga, string urlSopPag)
    {

        int resIdSopPag = DAOAdministrarPagadurias.sp_RegistrarArchivosSoportePagaduria(idSopPaga, idPaga,
                                            nomSopPaga, urlSopPag);        
        return resIdSopPag;

    }


    public static string EliminarArchivoSoportePagaduria(int idSopPag)
    {

        string resIdSopPag = DAOAdministrarPagadurias.sp_EliminarArchivosSoportePagaduria(idSopPag);
        return resIdSopPag;

    }


    public static DataTable ConsultarLocalidadesPorPagaduria(int? idDepto, int? idPaga, int idTipo)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarLocalidadesPorPagadurias(idDepto, idPaga, idTipo);
        return dt;

    }

    public static int RegistrarLocalidadesPorPagaduria(string idDepto, string idPaga)
    {

        int resAdd = DAOAdministrarPagadurias.sp_RegistrarLocalidadesPorPagaduria(idDepto, idPaga);
        return resAdd;

    }

    public static int EliminarLocalidadesPorPagaduria(int? idDepto, int? idPaga, int idTipDel)
    {

        int resDel = DAOAdministrarPagadurias.sp_EliminarLocalidadesPorPagaduria(idDepto, idPaga, idTipDel);
        return resDel;

    }


    public static DataTable ConsultarConvenios(int? idConv, string codConv, string nomConv, int? idPaga)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarConvenios(idConv, codConv, nomConv, idPaga);
        return dt;

    }


    public static int RegistrarConvenio(string idConv, string idPaga,
                                            string codConv, string nomConv, string resAprob,
                                            string fecAprob, string perPago, string Observ, string estado)
    {
        int resAdd = DAOAdministrarPagadurias.sp_RegistrarConvenio(idConv, idPaga, codConv, nomConv, resAprob, fecAprob,
            perPago, Observ, estado);
        return resAdd;
    }   

    public static string EliminarConvenios(int idConv)
    {

        string resDel = DAOAdministrarPagadurias.sp_EliminarConvenio(idConv);
        return resDel;

    }



    public static DataTable consultarLocalidadesPorConvenio(int? idDepto, int? idConv)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarLocalidadesPorConvenio(idDepto, idConv);
        return dt;

    }

    public static int RegistrarLocalidadesPorConvenio(string idDepto, string idConv)
    {

        int resAdd = DAOAdministrarPagadurias.sp_RegistrarLocalidadesPorConvenio(idDepto, idConv);
        return resAdd;

    }

    public static int EliminarLocalidadesPorConvenio(int? idDepto, int? idConv, int idTipDel)
    {

        int resDel = DAOAdministrarPagadurias.sp_EliminarLocalidadesPorConvenio(idDepto, idConv, idTipDel);
        return resDel;

    }



    public static DataTable ConsultarArchivosSoporteConvenio(int? idSopConv, string nomSopConv, int? idConv)
    {

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarArchivosSoporteConvenio(idSopConv, nomSopConv, idConv);
        return dt;

    }


    public static int RegistrarArchivosSoporteConvenio(string idSopConv, string idConv,
                                            string nomSopConv, string urlSopConv)
    {

        int resIdSopConv = DAOAdministrarPagadurias.sp_RegistrarArchivosSoporteConvenio(idSopConv, idConv,
                                            nomSopConv, urlSopConv);
        return resIdSopConv;

    }


    public static string EliminarArchivoSoporteConvenio(int idSopConv)
    {

        string resIdSopConv = DAOAdministrarPagadurias.sp_EliminarArchivosSoporteConvenio(idSopConv);
        return resIdSopConv;

    }


    public static DataTable ConsultarCompañias(int? idComp, string nomComp)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarCompañias(idComp, nomComp);
        return dt;
    }

    public static DataTable ConsultarProductos(int? idProd, string nomProd, int? estProd, int? idComp)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarProductos(idProd, nomProd, estProd, idComp);
        return dt;
    }

    public static DataTable ConsultarProductosPorCompañia(int? idProd, string nomProd, int? estProd,
                                                            int? idComp, string nomComp, int? idConv)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarProductosPorCompañia(idProd, nomProd, estProd, idComp, nomComp, idConv);
        return dt;
    }

    public static DataTable ConsultarProductosPorConvenio(  int? idProd, string nomProd, int? estProd, 
                                                            int? idComp, string nomComp,
                                                            int? idConv )
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarProductosPorConvenio(idProd, nomProd, estProd, idComp, nomComp, idConv);
        return dt;
    }

    public static int RegistrarProductosConvenio(string idConv, string idComp, string idProd)
    {

        int resIdProdConv = DAOAdministrarPagadurias.sp_RegistrarProductosConvenio(idConv, idComp, idProd);
        return resIdProdConv;


    }


    public static int EliminarProductosConvenio(int? idConv, int? idComp)
    {

        int resDelProdConv = DAOAdministrarPagadurias.sp_EliminarProductosConvenio(idConv, idComp);
        return resDelProdConv;

    }




    public static DataTable ConsultarArchivoNovedades(int? idArchPag, int? idPag, string nomArch, string tipArch, string tipRep)
    {	

        DataTable dt = new DataTable();
        dt = DAOAdministrarPagadurias.sp_consultarArchivoNovedades(idArchPag, idPag, nomArch, tipArch, tipRep);
        return dt;

    }


    public static int RegistrarArchivoNovedades(string idArchPag, string idPaga, string nomArchPag, string tipArch, string tipRep,
                                            string valor, string retiros, int cueBan_Id)
    {
        int resAdd = DAOAdministrarPagadurias.sp_RegistrarArchivoNovedades(idArchPag, idPaga, nomArchPag, tipArch, tipRep,
                                             valor, retiros, cueBan_Id);
        return resAdd;
    }


    public static string EliminarArchivoNovedades(int idArchNov)
    {

        string resDel = DAOAdministrarPagadurias.sp_EliminarArchivoNovedades(idArchNov);
        return resDel;

    }


    public static DataTable ConsultarConveniosArchivosNovedades(int? idProd, string nomProd, string nomComp,
                                                                int? idConv, string codConv, string nomConv,
                                                                int? idArchNov)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarConveniosArchivosNovedades(idProd, nomProd, nomComp,
                                                                    idConv, codConv, nomConv, idArchNov);
        return dt;
    }


    public static DataTable ConsultarProductosConfigArchivosNovedades(int? idProd, string nomProd, string nomComp,
                                                                int? idConv, int? idArchNov)
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = DAOAdministrarPagadurias.sp_ConsultarProductosConfigArchivosNovedades(idProd, nomProd, nomComp,
                                                                    idConv, idArchNov);
        return dt;
    }


    public static int RegistrarProductosConfigArchivosNovedades(string idArchNov, string idConv, string idProd)
    {

        int resIdArchNov = DAOAdministrarPagadurias.sp_RegistrarProductosConfigArchivosNovedades(idArchNov, idConv, idProd);
        return resIdArchNov;


    }


    public static int EliminarProductosConfigArchivosNovedades(int? idConv, int? idArchNov)
    {

        int resDelArchNov = DAOAdministrarPagadurias.sp_EliminarProductosConfigArchivosNovedades(idConv, idArchNov);
        return resDelArchNov;

    }




}