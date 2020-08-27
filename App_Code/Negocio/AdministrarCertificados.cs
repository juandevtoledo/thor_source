using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Descripción breve de AdministrarCertificados
/// </summary>
public class AdministrarCertificados
{
    //public static Certificado certificado = new Certificado();
    //public static Certificado certificadoPre = new Certificado();
    //public static Certificado certificadoBusqueda = new Certificado();
    //public static Asegurado aseguradoPre = new Asegurado();
    //public static Asegurado aseguradoBusqueda = new Asegurado();
    //public static Certificado completarCertificado = new Certificado();
    //public static Conyuge conyuge = new Conyuge();
    //public static UsuarioControl usuarioSistema = new UsuarioControl();

    public Certificado objCertificado = new Certificado();
    public Certificado objCertificadoPre = new Certificado();
    public Certificado objCertificadoBusqueda = new Certificado();
    public Asegurado objAseguradoPre = new Asegurado();
    public Asegurado objAseguradoBusqueda = new Asegurado();
    public Certificado objCompletarCertificado = new Certificado();
    public Conyuge objConyuge = new Conyuge();
    public UsuarioControl objUsuarioSistema = new UsuarioControl();

    public DataTable ConsultarAsesorDepartamento(int departamento)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.AsesorPorLocalidad(departamento);
        return dt;
    }

    public DataTable ConsultarAgencia()
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.ConsultarAgencia();
        return dt;
    }

    public string ConsultarTerceroCertificado(double ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        string mensaje = "";
        dt = objdministrarCertificado.ConsultarTerceroCertificado(ter_Id);
        if (dt.Rows.Count > 0)
        {
            objAseguradoBusqueda.Nombres = dt.Rows[0]["ter_Nombres"].ToString();
            objAseguradoBusqueda.NumeroDocumento = dt.Rows[0]["ter_Id"].ToString();
            objAseguradoBusqueda.Apellidos = dt.Rows[0]["ter_Apellidos"].ToString();
            objAseguradoBusqueda.FechaNacimiento = Convert.ToDateTime(dt.Rows[0]["ter_FechaNacimiento"].ToString());
            mensaje = "REGISTRO ENCONTRADO EXITOSAMENTE";
        }
        else
        {
            mensaje = "ESTA CEDULA NO EXISTE";
        }
        return mensaje;
    }

    public DataTable ConsultarOcupacionCertificado(int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarOcupacionCertificado(ter_Id);
        return dt;
    }
   

    public DataTable ConsultarLocalidadPorAgencia(int dep_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.sp_ConsultarLocalidadPorAgencia(dep_Id);
        return dt;
    }

    public void ConsultaYAlmacenarExtraPrima(DataTable dtCrearExtraPrimaPresentacion)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtCrearExtraPrima = new DataTable();
        dtCrearExtraPrima = dtCrearExtraPrimaPresentacion;

        DataTable dtConsultaYAlmacenarExtraPrima = new DataTable();
        dtConsultaYAlmacenarExtraPrima = objdministrarCertificado.spConsultarExtraPrima(int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdAntiguo"].ToString()));

           this.CrearExtraPrima(int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdNuevo"].ToString()),
           int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdNuevo"].ToString()), double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorAseguradoP"].ToString()),
           double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaP"].ToString()), double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaP"].ToString()),
           int.Parse(dtCrearExtraPrima.Rows[0]["par_IdP"].ToString()));

        if (int.Parse(dtCrearExtraPrima.Rows[0]["bandera"].ToString()) == 1)
        {
           this.CrearExtraPrima(int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdNuevo"].ToString()),
           int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdNuevo"].ToString()), double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorAseguradoC"].ToString()),
           double.Parse(dtCrearExtraPrima.Rows[0]["ext_ValorExtraPrimaC"].ToString()), double.Parse(dtCrearExtraPrima.Rows[0]["extValorPrimaC"].ToString()),
           int.Parse(dtCrearExtraPrima.Rows[0]["par_IdC"].ToString()));
        }

        if(dtConsultaYAlmacenarExtraPrima.Rows.Count > 0)
        {
            foreach (DataRow dt in dtConsultaYAlmacenarExtraPrima.Rows)
            {
                this.CrearExtraPrima(int.Parse(dtCrearExtraPrima.Rows[0]["cer_IdNuevo"].ToString()),
                int.Parse(dt["cer_IdAntiguo"].ToString()), double.Parse(dt["ext_ValorAsegurado"].ToString()),
                double.Parse(dt["ext_ValorExtraPrima"].ToString()), double.Parse(dt["ext_ValorPrima"].ToString()),
                int.Parse(dt["par_Id"].ToString()));
            }
        }
    }

    public double ReestructurarPrimasPorEdad(DataTable dtReestructurarPrimasPorEdad)
    {
        DataTable dtReestructurar = dtReestructurarPrimasPorEdad;
        double total = 0;
        foreach(DataRow dt in dtReestructurar.Rows)
        {
            total += double.Parse(dt["Prima"].ToString());
        }

        return total;
    }

    public List<int> CalcularTipoMovimiento(int cerId_A,int cerId_N,int plapol_IdA,int plapol_IdN)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtValorCertificadoAnterior = new DataTable();

        dtValorCertificadoAnterior = objdministrarCertificado.spConsultarValorAseguradoCertificado(cerId_A, plapol_IdA);
        
       

         DataTable dtValorCertificadoNuevo = new DataTable();

         dtValorCertificadoNuevo = objdministrarCertificado.spConsultarValorAseguradoCertificado(cerId_N, plapol_IdN);
         

        int tipoMovimiento = 0;
        int tipoMovimiento2 = 0;
        int tipoMovimiento3= 0;
        int reexpedicion = 0;

        /////////////////////////////// Valores de certificado asegurado principal /////////////////////////////////
        double valorAnteriorPrincipal = 0;
        if (dtValorCertificadoAnterior.Rows.Count > 0)
        {
            valorAnteriorPrincipal = double.Parse(dtValorCertificadoAnterior.Rows[0]["ValorAseguradoP"].ToString());
        }

        double valorNuevoPrincipal = double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoP"].ToString());

        /////////////////////////////// Valores de prima certificado ////////////////////////////////////////////
        double primaValorAnterior = 0;
        if(dtValorCertificadoAnterior.Rows.Count > 0)
        {
            primaValorAnterior = double.Parse(dtValorCertificadoAnterior.Rows[0]["Prima"].ToString());
        }
        double primaValorNuevo = double.Parse(dtValorCertificadoNuevo.Rows[0]["Prima"].ToString());

        ///////////////////////////// Cedular de certificado anterior y nuevo ///////////////////////////////////
        double cedulaAnterior = 0;
        double cedulaNueva = double.Parse(dtValorCertificadoNuevo.Rows[0]["Tercero"].ToString());
        if (dtValorCertificadoAnterior.Rows.Count > 0 && dtValorCertificadoAnterior.Rows[0]["Tercero"].ToString() != "")
        {
            cedulaAnterior = double.Parse(dtValorCertificadoAnterior.Rows[0]["Tercero"].ToString());
        }
        else
        {
            cedulaAnterior = cedulaNueva;
        }
        ////////////////////////////// Valores de certificado asegurado conyuge /////////////////////////////////
        double valorAnteriorConyuge = 0;
        if (dtValorCertificadoAnterior.Rows.Count > 0 && dtValorCertificadoAnterior.Rows[0]["ValorAseguradoC"].ToString() != "")
        {
            valorAnteriorConyuge = double.Parse(dtValorCertificadoAnterior.Rows[0]["ValorAseguradoC"].ToString());
        }
        double valorNuevoConyuge = double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoC"].ToString());

        /////////////////////////////  Valores de certificado Otro asegurado //////////////////////////////////
        double valorAnteriorOtroAsegurado = 0;
        double valorNuevoOtroAsegurado = 0;
        if (dtValorCertificadoAnterior.Rows.Count > 0 && dtValorCertificadoAnterior.Rows[0]["ValorAseguradoO"].ToString() != "")
        {
            valorAnteriorOtroAsegurado = double.Parse(dtValorCertificadoAnterior.Rows[0]["ValorAseguradoO"].ToString());
        }

        if (double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoO"].ToString()) != 0)
        {
            valorNuevoOtroAsegurado = double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoO"].ToString());
        }
        /////////////////////////////Condicionales Asegurado Principal /////////////////////////////////////////////
        if(valorAnteriorPrincipal == 0 && valorNuevoPrincipal != 0)
        {
            tipoMovimiento = 53;
            reexpedicion = 1;
        }
        else
        {
            if ((valorAnteriorPrincipal - valorNuevoPrincipal) < 0)
            {
                tipoMovimiento = 54;
                reexpedicion = 1;
            }
        }

           
        if ((valorAnteriorPrincipal - valorNuevoPrincipal) > 0)
        {
            tipoMovimiento = 55;
            reexpedicion = 1;
        }

        if ((valorAnteriorPrincipal - valorNuevoPrincipal) == 0)
        {
             tipoMovimiento = 56;

            
        }
           

        /////////////////////////////Condicionales Asegurado Conyuge /////////////////////////////////////////////
        if (valorAnteriorConyuge == 0 && valorNuevoConyuge != 0)
        {
            tipoMovimiento2 = 57;
            reexpedicion = 1;
        }


        if ((valorAnteriorConyuge - valorNuevoConyuge) < 0 && (valorAnteriorConyuge != 0 && valorNuevoConyuge != 0) && cedulaNueva == cedulaAnterior)
        {
            tipoMovimiento2 = 58;
            reexpedicion = 1;
        }

        if ((valorAnteriorConyuge - valorNuevoConyuge) > 0 && (valorAnteriorConyuge != 0 && valorNuevoConyuge != 0) && cedulaNueva == cedulaAnterior)
        {
             tipoMovimiento2 = 59;
             reexpedicion = 1;
        }

        if ((valorAnteriorConyuge - valorNuevoConyuge) == 0 && (valorAnteriorConyuge != 0 || valorNuevoConyuge != 0) && cedulaNueva == cedulaAnterior)
        {
             tipoMovimiento2 = 60;
        }

        if (valorAnteriorConyuge != 0 && valorNuevoConyuge == 0)
        {
             tipoMovimiento2 = 61;
             reexpedicion = 1;
        }

        if (cedulaAnterior != cedulaNueva && (cedulaAnterior != 0 && cedulaNueva != 0))
        {
            // Corrección vigencia
            tipoMovimiento2 = 62;
            reexpedicion = 1;
        }
   

        /////////////////////////////Condicionales Otros asegurados /////////////////////////////////////////////
        if (double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoO"].ToString()) != 0)
        {
            if (valorAnteriorOtroAsegurado == 0 && valorNuevoOtroAsegurado != 0)
            {
                tipoMovimiento3 = 63;
                reexpedicion = 1;
            }
        }
        if (dtValorCertificadoAnterior.Rows.Count > 0)
        {
            if (double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoO"].ToString()) != 0 || double.Parse(dtValorCertificadoAnterior.Rows[0]["ValorAseguradoO"].ToString()) != 0)
            {
                if (valorAnteriorOtroAsegurado != valorNuevoOtroAsegurado && (valorAnteriorOtroAsegurado != 0 && valorNuevoOtroAsegurado != 0))
                {
                    tipoMovimiento3 = 64;
                    reexpedicion = 1;
                }
            }
        }

        if (dtValorCertificadoAnterior.Rows.Count > 0)
        {
            if (valorNuevoOtroAsegurado == 0 && valorAnteriorOtroAsegurado != 0)
            {
                tipoMovimiento3 = 65;
                reexpedicion = 1;
            }
        }

        if (dtValorCertificadoAnterior.Rows.Count > 0)
        {
            if (double.Parse(dtValorCertificadoNuevo.Rows[0]["ValorAseguradoO"].ToString()) != 0 || double.Parse(dtValorCertificadoAnterior.Rows[0]["ValorAseguradoO"].ToString()) != 0)
            {
                if ((valorAnteriorOtroAsegurado - valorNuevoOtroAsegurado) == 0 && (valorAnteriorOtroAsegurado != 0 && valorNuevoOtroAsegurado != 0))
                {
                    tipoMovimiento3 = 66;
                }
            }
        }


        if(reexpedicion == 0 && primaValorAnterior != primaValorNuevo)
        {
            tipoMovimiento = 67;
            reexpedicion = 1;
        }
        
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCasespIdNewCertificado(cerId_N);
        
        if(int.Parse(dt.Rows[0]["casesp_Id"].ToString()) == 4)
        {
            tipoMovimiento = 56;
        }
        if (int.Parse(dt.Rows[0]["casesp_Id"].ToString()) == 5)
        {
            tipoMovimiento2 = 60;
        }
        if (int.Parse(dt.Rows[0]["casesp_Id"].ToString()) == 6)
        {
            tipoMovimiento = 69;
            tipoMovimiento2 = 70;
        }

        List<int> listaMovimientos = new List<int>();
        listaMovimientos.Add(tipoMovimiento);
        listaMovimientos.Add(tipoMovimiento2);
        listaMovimientos.Add(tipoMovimiento3);
        listaMovimientos.Add(reexpedicion);

        return listaMovimientos;

    }

    public double CalcularIndiceDeMasaCorporal(double peso, double estatura)
    {
        double indiceCorporal = 0;
        double estaturas = 0;
        double division = 0;
        estaturas = estatura   / 100;
        division = estaturas * estaturas;
        indiceCorporal = peso / division;


        return indiceCorporal;
    }
    public List<int> ConsultarPlapolIdCertificado(int cerId_A,int cerId_N)
    {
        int plapolId_A = 0;
        int plapolId_N = 0;
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtConsultarPlapolIdAntiguo = new DataTable();
        dtConsultarPlapolIdAntiguo = objdministrarCertificado.spConsultarPlapolIdCertificado(cerId_A);
        if(dtConsultarPlapolIdAntiguo.Rows.Count > 0)
        {
            plapolId_A = int.Parse(dtConsultarPlapolIdAntiguo.Rows[0]["plapol_Id"].ToString());
        }
        


        DataTable dtConsultarPlapolIdNuevo = new DataTable();
        dtConsultarPlapolIdNuevo = objdministrarCertificado.spConsultarPlapolIdCertificado(cerId_N);
        if (dtConsultarPlapolIdNuevo.Rows.Count > 0)
        {
            plapolId_N = int.Parse(dtConsultarPlapolIdNuevo.Rows[0]["plapol_Id"].ToString());
        }

        List<int> listaPlapolId = new List<int>();
        listaPlapolId.Add(plapolId_A);
        listaPlapolId.Add(plapolId_N);

        return listaPlapolId;

    }

    public DataTable ActualizarTipoMovimientoCertificado(int cer_Id, int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarTipoMovimientoCertificado(cer_Id, TipoMovimiento, TipoMovimiento2, TipoMovimiento3);
        return dt;
    }

    public DataTable ConsultarPagaduriaPorLocalidad(int dep_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.SPConsultarPagaduriaPorLocalidad(dep_Id);
        return dt;
    }

    public DataTable ConsultarIdArchivo(int pro_Id, int con_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarIdArchivo(pro_Id, con_Id);
        return dt;
    }

    public DataTable ConsultarNovedadActual(int ter_Id, int arcpag_Id,int retiro)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarNovedadActual(ter_Id, arcpag_Id, retiro);
        return dt;
    }


    public  DataTable ConsultarArchivoPagaduriaPorId(int arcpag_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarArchivoPagaduriaPorId(arcpag_Id);
        return dt;
    }

    public DataTable ConsultarPeriodicidadPorConvenio(int con_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarPeridiocidadPorConvenio(con_Id);
        return dt;
    }

    public DataTable ConsultarLocalidadesCertificado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarLocalidadesCertificado(cer_Id);
        return dt;
    }

    public DataTable ConsultarLocalidad()
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarLocalidad();
        return dt;
    }

    public DataTable ConsultarPlantel(int dep_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarPlantel(dep_Id);
        return dt;
    }


    public DataTable ActualizarCertificadoAnterior(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarCertificadoAnterior(cer_Id);
        return dt;
    }

    public DataTable ConsultarEstadoNegocioPorCerId(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarEstadoNegocioPorCerId(cer_Id);
        return dt;
    }

    public DataTable consultarResumenCertificado(int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarResumenCertificado(ter_Id);
        return dt;
    }

    public DataTable ConsultarTasaPlanesPoliza(int plapol_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarTasaPlanesPoliza(plapol_Id);
        return dt;
    }

    public void ActualizarNewCertificado(int cer_Id, double cer_PrimaTotal, string cer_Consecutivo,
         string cer_Convenio, string cer_Declaracion, string cer_DeclaracionEnfe, string cer_EstadoNegocio, string cer_EstaturaConyuge,
         string cer_EstaturaPrincipal, string cer_Extr, double IdConyuge, string Movimiento, string PesoConyuge, string PesoPrincipal,
         int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3, int localidad, int pla_Id, int pol_Id, int mom_Id, int cer_CertificadoRecuperado, DateTime cer_FechaDigitacion, int perPag_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarNewCertificado(cer_Id, cer_PrimaTotal, cer_Consecutivo, cer_Convenio,
            cer_Declaracion, cer_DeclaracionEnfe, cer_EstadoNegocio, cer_EstaturaConyuge, cer_EstaturaPrincipal, cer_Extr, IdConyuge,
            Movimiento, PesoConyuge, PesoPrincipal, TipoMovimiento, TipoMovimiento2, TipoMovimiento3, localidad, pla_Id, pol_Id, mom_Id, cer_CertificadoRecuperado, cer_FechaDigitacion, perPag_Id);

    }

    public void ActualizarNewCertificadoConPagaduria(int cer_Id, int cer_PrimaTotal, string cer_Consecutivo,
         string cer_Convenio, string cer_Declaracion, string cer_DeclaracionEnfe, string cer_EstadoNegocio, string cer_EstaturaConyuge,
         string cer_EstaturaPrincipal, string cer_Extr, double IdConyuge, string Movimiento, string PesoConyuge, string PesoPrincipal,
         int TipoMovimiento, int TipoMovimiento2, int TipoMovimiento3, int localidad, int pla_Id, int pol_Id, int mom_Id, int cer_CertificadoRecuperado, DateTime cer_FechaDigitacion, int perPag_Id,int paga_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarNewCertificadoConPagaduria(cer_Id, cer_PrimaTotal, cer_Consecutivo, cer_Convenio,
            cer_Declaracion, cer_DeclaracionEnfe, cer_EstadoNegocio, cer_EstaturaConyuge, cer_EstaturaPrincipal, cer_Extr, IdConyuge,
            Movimiento, PesoConyuge, PesoPrincipal, TipoMovimiento, TipoMovimiento2, TipoMovimiento3, localidad, pla_Id, pol_Id, mom_Id, cer_CertificadoRecuperado, cer_FechaDigitacion, perPag_Id,paga_Id);

    }

    public void ActualizarNewCertificadoPreCargado(int cer_Id, int cer_HojaServicio1, int cer_HojaServicio2, int cer_HojaServicio3, int cer_AnexoConversion)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarNewCertificadoPreCargado(cer_Id, cer_HojaServicio1, cer_HojaServicio2, cer_HojaServicio3, cer_AnexoConversion);

    }

     //Ingresar otros asegurados - Sebastian
    public void IngresarOtrosAsegurados(DataTable dtTemp, int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spInsertarOtroAsegurado(dtTemp, cer_Id);
    }

    public DataTable ConsultarPeriodosPago()
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.ConsultarPeriodosPago();
        return dt;
    }

    public DataTable consultarResumenCertificadoPorCompania(int com_Id,int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarResumenCertificadoPorCompania(com_Id, ter_Id);
        return dt;
    }

    public DataTable consultarResumenCertificadoPorProducto(int pro_Id, int ter_Id, int com_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarResumenCertificadoPorProducto(pro_Id, ter_Id, com_Id);
        return dt;
    }

    public DataTable ConsultarLocalidades()
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.ConsultarLocalidades();
        return dt;
    }

    public void CompletarCertificadoPreCargado(DateTime fechaExpedicion, DateTime fechaVigencia, DateTime fechaDigitacion, string numeroCertificado, string asesor, string periodoPago, string poliza, string localidad, string agencia, string prima, string cedula, string nombres, string apellidos, string edad, string plan, string pagaduria, string convenio, string peso, string estatura)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objCertificado.FechaExpedicion = fechaExpedicion;
        objCertificado.Vigencia = fechaVigencia;
        objCertificado.FechaDigitacion = fechaDigitacion;
        objCertificado.NumeroCertificado = numeroCertificado;
        objCertificado.NombreAsesor = asesor;
        objCertificado.PeriodoPago = periodoPago;
        objCertificado.NumeroPoliza = poliza;
        objCertificado.Localidad = localidad;
        objCertificado.Agencia = agencia;
        objCertificado.Prima = int.Parse(prima);
        objCertificado.Cedula = cedula;
        objCertificado.Nombre = nombres;
        objCertificado.Apellido = apellidos;
        objCertificado.Edad = edad;
        objCertificado.Plan = plan;
        objCertificado.Pagaduria = pagaduria;
        objCertificado.Convenio = convenio;
        objCertificado.Peso = peso;
        objCertificado.Estatura = estatura;
        objdministrarCertificado.IngresarCertificado();
    }
    public void insertarBeneficiario(List<Asegurado> beneficiario, int cer_Id, int ter_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        //DAOAdministrarCertificado.spInsertarBeneficiario(ben_identificacion, ben_apellidos, ben_Nombres, ben_Edad, ben_Porcentaje, ben_Parentesco);
        objdministrarCertificado.spInsertarBeneficiario(beneficiario, cer_Id, ter_Id, par_Id);
    }

    public void insertarBeneficiario(DataTable dtBeneficiario, int cer_Id, int ter_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        //DAOAdministrarCertificado.spInsertarBeneficiario(ben_identificacion, ben_apellidos, ben_Nombres, ben_Edad, ben_Porcentaje, ben_Parentesco);
        objdministrarCertificado.spInsertarCertificadoBeneficiario(dtBeneficiario, cer_Id, ter_Id, par_Id);
    }

    public DataTable ConsultarBeneficiarioModificacion(int cer_Id, double ter_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarBeneficiarioModificacion(cer_Id, ter_Id, par_Id);
        return dt;
    }

  
    //sebastian consultar Convenios
    public DataTable consultarConvenios(int pro_Id, int dep_Id, int paga_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarConvenios(pro_Id, dep_Id, paga_Id);
        return dt;
    }

    public DataTable consultarDepartamentoPorCiudad(string ciu_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarDepartamentoPorCiudad(ciu_Id);
        return dt;
    }
    //sebastian
    public DataTable consultarConvenioPorPagaduria(double cerId)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtPagaId = new DataTable();
        dtPagaId = objdministrarCertificado.spConsultarConvenioPorPagaduria(cerId);
        return dtPagaId;
    }

    /*Cristian Ingresar conyuge*/
    public void ConyugeCertificadoPreCargado(string numeroDocumento, string nombres, string apellidos, string edad, string plan, string peso, string estatura)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objConyuge.NumeroDocumento = numeroDocumento;
        objConyuge.Nombres = nombres;
        objConyuge.Apellidos = apellidos;
        objConyuge.Edad = edad;
        objConyuge.Plan = plan;
        objConyuge.Peso = peso;
        objConyuge.Estatura = estatura;
        objdministrarCertificado.IngresarCertificadoConyuge();
    }

    public void certificadoPrecargado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoPrecargado(cer_Id);

        objCertificadoPre.Agencia = dt.Rows[0]["age_Nombre"].ToString();
        objCertificadoPre.FechaExpedicion = Convert.ToDateTime(dt.Rows[0]["cer_FechaExpedicion"].ToString());
        objCertificadoPre.Vigencia = DateTime.Parse(dt.Rows[0]["cer_VigenciaDesde"].ToString());
        objCertificadoPre.NumeroCertificado = dt.Rows[0]["cer_Certificado"].ToString();
        objCertificadoPre.NombreAsesor = dt.Rows[0]["ase_Nombres"].ToString() + " " + dt.Rows[0]["ase_Apellidos"].ToString();
        objAseguradoPre.Nombres = dt.Rows[0]["ter_Nombres"].ToString();
        objAseguradoPre.Apellidos = dt.Rows[0]["ter_Apellidos"].ToString();
        objAseguradoPre.NumeroDocumento = dt.Rows[0]["ter_Id"].ToString();
        objCertificadoPre.Pagaduria = dt.Rows[0]["paga_Nombre"].ToString();
        objCertificadoPre.Producto = dt.Rows[0]["pro_Id"].ToString();
        objCertificadoPre.Compania = dt.Rows[0]["com_Id"].ToString();
        objCertificadoPre.HojaServicio1 = dt.Rows[0]["cer_HojaServicio1"].ToString();
        objCertificadoPre.HojaServicio2 = dt.Rows[0]["cer_HojaServicio2"].ToString();
        objCertificadoPre.HojaServicio3 = dt.Rows[0]["cer_HojaServicio3"].ToString();
        objCertificadoPre.AnexoConversion = dt.Rows[0]["cer_AnexoConversion"].ToString();
        objCertificadoPre.Migracion = dt.Rows[0]["cer_Migracion"].ToString();
        objCertificadoPre.Consecutivo = int.Parse(dt.Rows[0]["cer_Consecutivo"].ToString());
        objCertificadoPre.Declaracion = dt.Rows[0]["cer_Declaracion"].ToString();
        objCertificadoPre.DeclaracionEnfe = dt.Rows[0]["cer_DeclaracionEnfe"].ToString();
        objCertificadoPre.Plantel = dt.Rows[0]["pla_Nombre"].ToString();
    }

    public void certificadoPrecargadoResumen(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoPrecargadoResumen(cer_Id);

        objCertificadoPre.Agencia = dt.Rows[0]["age_Nombre"].ToString();
        objCertificadoPre.FechaExpedicion = Convert.ToDateTime(dt.Rows[0]["cer_FechaExpedicion"].ToString());
        objCertificadoPre.Vigencia = DateTime.Parse(dt.Rows[0]["cer_VigenciaDesde"].ToString());
        objCertificadoPre.NumeroCertificado = dt.Rows[0]["cer_Certificado"].ToString();
        objCertificadoPre.NombreAsesor = dt.Rows[0]["ase_Nombres"].ToString() + " " + dt.Rows[0]["ase_Apellidos"].ToString();
        objCertificadoPre.PeriodoPagoNombre = dt.Rows[0]["perpago_Nombre"].ToString();
        objCertificadoPre.ConvenioNombre = dt.Rows[0]["con_Nombre"].ToString();
        objAseguradoPre.Nombres = dt.Rows[0]["ter_Nombres"].ToString();
        objAseguradoPre.Apellidos = dt.Rows[0]["ter_Apellidos"].ToString();
        objAseguradoPre.NumeroDocumento = dt.Rows[0]["ter_Id"].ToString();
        objCertificadoPre.Pagaduria = dt.Rows[0]["paga_Nombre"].ToString();
        objCertificadoPre.Producto = dt.Rows[0]["pro_Id"].ToString();
        objCertificadoPre.Compania = dt.Rows[0]["com_Id"].ToString();
        objCertificadoPre.FechaDigitacion = Convert.ToDateTime(dt.Rows[0]["cer_FechaDigitacion"].ToString());
        objCertificadoPre.Localidad = dt.Rows[0]["dep_Nombre"].ToString();
        objCertificadoPre.NumeroPoliza = dt.Rows[0]["pol_Numero"].ToString();
        objCertificadoPre.Declaracion = dt.Rows[0]["cer_Declaracion"].ToString();
        objCertificadoPre.DeclaracionEnfe = dt.Rows[0]["cer_DeclaracionEnfe"].ToString();
        objCertificadoPre.Prima = int.Parse(dt.Rows[0]["cer_PrimaTotal"].ToString());
        objCertificadoPre.PesoPrincipal = dt.Rows[0]["PesoPrincipal"].ToString();
        objCertificadoPre.EstaturaPrincipal = dt.Rows[0]["cer_EstaturaPrincipal"].ToString();
        objCertificadoPre.Peso = dt.Rows[0]["PesoConyuge"].ToString();
        objCertificadoPre.Estatura = dt.Rows[0]["cer_EstaturaConyuge"].ToString();
        objCertificadoPre.Declaracion = dt.Rows[0]["cer_Declaracion"].ToString();
        objCertificadoPre.DeclaracionEnfe = dt.Rows[0]["cer_DeclaracionEnfe"].ToString();
        objCertificadoPre.HojaServicio1 = dt.Rows[0]["cer_HojaServicio1"].ToString();
        objCertificadoPre.HojaServicio2 = dt.Rows[0]["cer_HojaServicio2"].ToString();
        objCertificadoPre.HojaServicio3 = dt.Rows[0]["cer_HojaServicio3"].ToString();
        objCertificadoPre.AnexoConversion = dt.Rows[0]["cer_AnexoConversion"].ToString();
        objCertificadoPre.Plantel = dt.Rows[0]["pla_Nombre"].ToString();
        
    }

    public void certificadoResumen(int cer_Id)
    {
       

    }

    public DataTable spConsultarPolizaPorProudcto(int dep_Id,int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarPolizaPorProudcto(dep_Id,pro_Id);
        return dt;
    }
    public DataTable consultarPlanPorPoliza(int pol_Id, int par_Id, int edad)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spPlanPorPoliza(pol_Id, par_Id, edad);
        return dt;
    }

    public DataTable consultarPlanPorPolizaPermanencia(int pol_Id, int par_Id, int edad)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spPlanPorPolizaPermanencia(pol_Id, par_Id, edad);
        return dt;
    }
    //################################################
    public DataTable consultarAmparosPorPlan(int plapol_Id, int edad, int valorLibre, int ocupacion)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarTablaAmparos(plapol_Id, edad, valorLibre, ocupacion);
        return dt;
    }

    public DataTable consultarAmparosPorPlanPermanencia(int plapol_Id, int edad, int valorLibre, int cer_Id, int genero, int ocupacion, int cer_IdAntiguo, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarTablaAmparosPermanencia(plapol_Id, edad, valorLibre, cer_Id, genero, ocupacion, cer_IdAntiguo, par_Id);
        return dt;
    }

    public DataTable consultarAmparosPorPlanModificacion(int cer_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarTablaAmparosModificacion(cer_Id, par_Id);
        return dt;
    }

    public DataTable consultarAmparosPorPlanModificacionBusqueda(int cer_Id, int par_Id,double terId)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarTablaAmparosModificacionBusqueda(cer_Id, par_Id,terId);
        return dt;
    }

    //25/08/20015 sebastian
    public DataTable consultarOtroAseguradoModificacion(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarOtroAseguradoModificacion(cer_Id);
        return dt;
    }

    public int ConsultarIdCertificado(int ter_Id, int pro_Id, string cer_EstadoNegocio, string cer_EstadoNegocio2)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        int cer_Id = objdministrarCertificado.spConsultarIdCertificado(ter_Id, pro_Id, cer_EstadoNegocio, cer_EstadoNegocio2);
        return cer_Id;

    }

    public int ConsultarIdCertificadoNuevo(int ter_Id, int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        int cer_Id = objdministrarCertificado.spConsultarIdCertificadoNuevo(ter_Id, pro_Id);
        return cer_Id;

    }

    public DataTable sp_ConsultarIdCertificadoValorAsegurado(int ter_Id, int pro_Id, string cer_EstadoNegocio, string cer_EstadoNegocio2)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtCer_Id = new DataTable();
        dtCer_Id = objdministrarCertificado.sp_ConsultarIdCertificadoValorAsegurado(ter_Id, pro_Id, cer_EstadoNegocio, cer_EstadoNegocio2);
        return dtCer_Id;

    }

    public void insertarAmparos(DataTable dt, int cer_Id, int cedula, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spInsertarAmparos(dt, cer_Id, cedula, par_Id);
    }

    public void InsertarAmparosExtraPrima(DataTable dt, int cer_Id, int cedula, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spInsertarAmparosExtraPrima(dt, cer_Id, cedula, par_Id);
    }

    public DataTable consultarParentesco(int producto)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarParentesco(producto);
        return dt;
    }

    public DataTable consultarAmparosPrincipal(int cer_Id, int ter_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarAmparosPrincipal(cer_Id, ter_Id, par_Id);
        return dt;
    }

    //Juan Camilo /27/07/2015
    public DataTable consultarCertificadoExistente(int ter_Id, int dep_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoExistente(ter_Id, dep_Id);
        return dt;
    }

    //Juan Camilo /27/07/2015
    public DataTable consultarProIdPorNombre(string pro_Nombre, string com_Nombre)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarProIdPorNombre(pro_Nombre, com_Nombre);
        return dt;
    }

    //Juan Camilo /05/08/2015
    public DataTable consultarCertificadoFull(int cer_Certificado)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoFull(cer_Certificado);
        return dt;
    }

    public DataTable consultarCertificadoResumen(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoResumen(cer_Id);
        return dt;
    }

    public DataTable consultarCertificadoFullCedula(double cedula, int producto)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoFullCedula(cedula, producto);
        return dt;
    }

    public DataTable consultarCertificadoFullCedulaNuevo(double cedula, int producto)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoFullPorCedulaNuevo(cedula, producto);
        return dt;
    }

    //Juan Camilo /05/08/2015
    public DataTable consultarNumeroPolizaPorId(int pol_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarNumeroPolizaPorId(pol_Id);
        return dt;
    }

    public DataTable consultarNumeroPolizaPorNumero(double pol_Numero)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarNumeroPolizaPorNumero(pol_Numero);
        return dt;
    }

    //Juan Camilo /05/08/2015
    public DataTable consultarNewTerceroPorCedula(int ter_Id, int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarNewTerceroPorCedula(ter_Id, pro_Id);
        return dt;
    }

    public DataTable consultarNewTerceroPorCedulaResumen(int ter_Id, int pro_Id, int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarNewTerceroPorCedularResumen(ter_Id, pro_Id, cer_Id);
        return dt;
    }

    //Juan Camilo /12/08/2015
    public string actualizarNewCertificadoModificacion(int cer_Id, string cer_Declaracion, string cer_DeclaracionEnfe, int localidad, string PesoPrincipal, string cer_EstaturaPrincipal, string PesoConyuge, string cer_EstaturaConyuge)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        string rpta = objdministrarCertificado.SPActualizarNewCertificadoModificacion(cer_Id, cer_Declaracion, cer_DeclaracionEnfe, localidad, PesoPrincipal, cer_EstaturaPrincipal, PesoConyuge, cer_EstaturaConyuge);
        return rpta;
    }

    //Juan Camilo /21/08/2015
    public DataTable consultarOtroAsegurado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarOtroAsegurado(cer_Id);
        return dt;
    }

    public DataTable consultarOtroAseguradoIndex(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarOtroAseguradoIndex(cer_Id);
        return dt;
    }


    //Juan Camilo /31/08/2015
    public DataTable consultarPlanesValorLibre(int valorLibre)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarPlanesValorLibre(valorLibre);
        return dt;
    }

    public DataTable ConsultarAmparoBasicoAnterior(int cer_Id, int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarAmparoBasicoAnterior(cer_Id, ter_Id);
        return dt;
    }


    //JC 22-09-2015
    public DataTable spConsultarEncabezadoCertificado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarEncabezadoCertificado(cer_Id);
        return dt;
    }

    public DataTable spConsultarEncabezadoCertificadoResumen(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarEncabezadoCertificadoResumen(cer_Id);
        return dt;
    }

    //Cumulos
    public DataTable spConsultarCumulo(int producto)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCumulo(producto);
        return dt;
    }

    //Cumulos

    public double spConsultarValoresAsegurado(int producto, int tercero)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        double valorAsegurado = objdministrarCertificado.spConsultarValoresAsegurados(producto, tercero);
        return valorAsegurado;
    }

    public DateTime CertificadoRecuperado(DataTable dtCertificado, int producto)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DateTime fechaMaximaRecuperacion = new DateTime();
        DateTime fechaRetiro = DateTime.Parse(dtCertificado.Rows[0]["VigenciaRetiroPrincipal"].ToString());
        DataTable dtFechaMaximaRec = objdministrarCertificado.spMesesRecuperacion(producto);
        int mesesMaximosRecuperacion = int.Parse(dtFechaMaximaRec.Rows[0]["MesesRecuperacion"].ToString());
        fechaMaximaRecuperacion = DateTime.Parse(dtFechaMaximaRec.Rows[0]["VigenciaRetiroPrincipal"].ToString());
        fechaMaximaRecuperacion = fechaMaximaRecuperacion.AddMonths(mesesMaximosRecuperacion);
        return fechaMaximaRecuperacion;
    }

    public DataTable ConsultarCertificadoPrecargadoPorDigitar(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoPrecargadoPorDigitar(cer_Id);
        return dt;
    }

    public void EliminarCertificado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spEliminarCertificado(cer_Id);
    }

    public DataTable ConsultarPlanPrincipal(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dtPlanPrincipal = new DataTable();
        dtPlanPrincipal = objdministrarCertificado.sp_ConsultarPlanPrincipalConyuge(cer_Id);
        return dtPlanPrincipal;
    }

    public  DateTime CalcularFechaVigencia(string mesProduccion, string anoProduccion)
    {
        //int numeroMes = NumeroMes(mesProduccion);
        DateTime fecha = DateTime.Parse("01/" + mesProduccion + "/" + anoProduccion);
        fecha = fecha.AddMonths(1);
        return fecha;
    }

    public DataTable ConsultarFechaExpedicionCertificadoAnterior(int ter_Id, int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spConsultarFechaExpedicionCertificadoAnterior(ter_Id, pro_Id);
        return objdministrarCertificado.spConsultarFechaExpedicionCertificadoAnterior(ter_Id, pro_Id); 

    }

    public void ActualizarFechaVigencia(int cer_Id, DateTime fechaVigencia)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spActualizarFechaVigencia(cer_Id, fechaVigencia);
    }

    public int NumeroMes(string mesProduccion)
    {
        int numeroMes = 0;
        switch (mesProduccion)
        {
            case "enero":
                numeroMes = 1;
                break;
            case "febrero":
                numeroMes = 2;
                break;
            case "marzo":
                numeroMes = 3;
                break;
            case "abril":
                numeroMes = 4;
                break;
            case "mayo":
                numeroMes = 5;
                break;
            case "junio":
                numeroMes = 6;
                break;
            case "julio":
                numeroMes = 7;
                break;
            case "agosto":
                numeroMes = 8;
                break;
            case "septiembre":
                numeroMes = 9;
                break;
            case "octubre":
                numeroMes = 10;
                break;
            case "noviembre":
                numeroMes = 11;
                break;
            case "diciembre":
                numeroMes = 12;
                break;
        }            
        return numeroMes;
    }

    public DataTable ConsultarCertificadoAnteriorPMI(int ter_Id, int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoAnteriorPMI(ter_Id, pro_Id);
        return dt;
    }

    public void spInsertarCasoEspecialPreCargue(int casesp_Id, int ter_Id, int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spInsertarCasoEspecialPreCargue(casesp_Id, ter_Id, pro_Id);
    
    }

  
    public DataTable ConsultarCasespIdNewCertificado(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCasespIdNewCertificado(cer_Id);
        return dt;
    }

    public DataTable ConsultarFechaFrontera(int age_Id,int pro_Id, DateTime expedicion)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarFechaFrontera(age_Id, pro_Id, expedicion);
        return dt;

    }
    public DataTable ConsultarInformacionFechaFrontera(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarInformacionFechaFrontera(cer_Id);
        return dt;
    }

    // SE CARGAN LOS CERTIFICADOS VIGENTES
    public DataTable ConsultarCertificadosVigentes(int producto, int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable certificadosVigentes = objdministrarCertificado.spConsultarCertificadosVigentesPorProducto(producto, ter_Id);
        return certificadosVigentes;
    }

    // SE CARGAN LOS CERTIFICADOS ANTERIORES
    public DataTable ConsultarCertificadosAnteriores(int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable certificadoAnterior = objdministrarCertificado.spConsultarCertificadoAnterior(cer_Id);
        return certificadoAnterior;
    }

    //Viviana 
    //consultar certificado liberty para asignacion de numero de certificado

    public DataTable ConsultarCertificadoLiberty(string ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadoLiberty(ter_Id);
        return dt;
    }

    //Viviana
    //Asignar nuevo numero de certificado a vigilantes liberty
    public DataTable AsignarCertificado(int cer_Id, int certificado)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spAsignarCertificadoLiberty(cer_Id, certificado);
        return dt;
    }

    //Consultar caso especial para habilitar campo prima
    //public static DataTable HabilitarCampoPrima(string txtCedulaPrincipal, string txtCertificado)
    //{
    //    DataTable dt = new DataTable();
    //    dt = DAOAdministrarCertificado.spHabilitarCampoPrima(txtCedulaPrincipal, txtCertificado);
    //    return dt;
    //}  

    public DataTable consultarParentescoBeneficiario(int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spconsultarParentescoBeneficiario(pro_Id);
        return dt;
    }

    //METODO PARA ENLAZAR LA CAPA DE PRESENTACION CON LA CAPA DE DATOS LA PRIMERA FILA DE LA TABLA BENEFICIARIOS
    public DataTable ConsultarBeneficiarioUnico()
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarBeneficiarioUnico();
        return dt;
    }

    //Metodo para crear la extra prima
    public void CrearExtraPrima(int cer_IdNuevo, int cer_IdAntiguo, double ext_ValorAsegurado, double ext_ValorExtraPrima,
         double ext_ValorPrima, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spCrearExtraPrima(cer_IdNuevo, cer_IdAntiguo, ext_ValorAsegurado, ext_ValorExtraPrima, ext_ValorPrima, par_Id);
    }

    //consultar valor asegurado de la extra prima
    public DataTable ConsultarValorAseguradoExtraPrima(int cer_IdAntiguo, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarValorAseguradoExtraPrima(cer_IdAntiguo, par_Id);
        return dt;
    }

    //consultar el historial general de la extra prima
    public DataTable ConsultarHistorialExtraPrima(int cer_IdAntiguo, int par_Id, int bandera)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarHistorialExtraPrima(cer_IdAntiguo, par_Id, bandera);
        return dt;
    }

    //consultar el historial especifico de cada uno de los certificados anteriores
    public DataSet ConsultarHistirialPorcentajeExtraPrimado(int cer_Id, int par_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataSet ds = new DataSet();
        ds = objdministrarCertificado.spConsultarHistirialPorcentajeExtraPrimado(cer_Id, par_Id);
        return ds;
    }
    public DataTable ConsultarLocalidadesAgencia(string usuario)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.ConsultarLocalidadesAgencia(usuario);
        return dt;
    }
    public DataTable ActualizarEstadoNegocioDevolucion(string cer_EstadoNegocio, int cer_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spActualizarEstadoNegocioDevolucion(cer_EstadoNegocio, cer_Id);
        return dt;
    }

    public DataTable ConsultarCasoEspecialPreCargue(int cer_Certificado, int pro_Id, int ter_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCasoEspecialPreCargue(cer_Certificado, pro_Id, ter_Id);
        return dt;
    }

    public DataTable ConsultarCompaniaPorCertificado(double comId)
    {
        DAOPagos objPagos = new DAOPagos();
        DataTable dtConsultarCompaniaPorCertificado = new DataTable();
        dtConsultarCompaniaPorCertificado = objPagos.ConsultarCompaniaPorCertificado(comId);
        return dtConsultarCompaniaPorCertificado;
    }

    public DataTable ConsultarCertificadosSinPagaduria(int dep_Id,int pro_Id)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarCertificadosSinPagaduria(dep_Id,pro_Id);
        return dt;
    }

    public void ActualizarNewCertificadoPagaduria(string cer_Id, int paga_Id, int cer_Convenio)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        objdministrarCertificado.spActualizarNewCertificadoPagaduria(cer_Id,paga_Id,cer_Convenio);

    }

    public DataTable ConsultarProductoParaNovedad(double terId, int proId)
    {
        DAOAdministrarCertificado objdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objdministrarCertificado.spConsultarProductoParaNovedad(terId, proId);
        return dt;
    }



}