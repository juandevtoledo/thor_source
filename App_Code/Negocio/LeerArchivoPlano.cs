using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LeerArchivoPlano
/// </summary>
public class LeerArchivoPlano
{
    //Constantes del certificado
    public static int mom_Id = 3;
    public static int com_Id = 1;
    public static int estcar_Id = 5;
    public static int casesp_Id = 0;
    public static string cer_EstadoNegocio = "PRODUCCION NUEVA";
    public static int perPag_Id = 1;
    public static int cer_SoporteFisico = 1;
    public static string cer_Consecutivo = "0";
    public static int paga_IdN = 661;
    public static int con_IdN = 787;
    public static int pla_IdN = 24522;
    public static int age_IdN = 23;
    public static int caudev_Id = 0;
    public static int tipdev_Id = 0;
    public static int migracion = 0;
    public static int dep_IdN = 8;
    public static int ciu_IdN = 337;
    public static int ocu_IdN = 61;
    public static DateTime cer_FechaRecibido = DateTime.Today;
    public static int tipoMovimientoN = 1;
    public static DateTime cer_FechaDigitacion = DateTime.Today;
    public static int tipoMovimiento2 = 0 ;
    public static int tipoMovimiento3 = 63;

    public static int sumaExito = 0;
    public static int sumaError = 0;
    public static int sumaTodos = 0;

    public static string men_CerId = "";

    //Recorre el archivo e inserta la informacion
    public static DataTable InsertarArchivo(List<string[]> tabla)
    {
        sumaExito = 0;
        sumaError = 0;
        sumaTodos = 0;
        
        string[] certificado = new string[40];
        string cer_Id = "0";
        string pol_Numero = "0";
        string ter_Id = string.Empty;
        string sexo = string.Empty;
        int par_Id = 3;
        bool existe = false;
        bool otroAsegurado = false;
        List<string[]> matrizAmparos = new List<string[]>();
        List<string[]> matrizBeneficiario = new List<string[]>();
        int divide = 1;
        DateTime fechaInicio;
        DateTime fechaFin;
        DateTime fechaExpedicion = DateTime.Today;

        string mensajeC = "0";
        string mensajeT = string.Empty;
        string mensajeA = string.Empty;
        string mensajeB = string.Empty;
        string mensajeCon = string.Empty;
        string mensajeO = string.Empty;

        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Certificado");
        dt.Columns.Add("Asegurado");
        dt.Columns.Add("Amparos");
        dt.Columns.Add("Beneficiarios");
        dt.Columns.Add("Conyuge");
        dt.Columns.Add("OtroAsegurado");
        DataRow row = dt.NewRow();

        for (int i = 0; i < tabla.Count; i++)
        {
            if (tabla[i][0].ToString() == "1")
            {
                if(i > 0)
                {
                    row["ID"] = (mensajeC == "0" || cer_Id == "1") ? "2" : "1";
                    row["Certificado"] = (mensajeC == "0") ? "Ya existe cer_Id: " + men_CerId : (mensajeC == "1") ? "La poliza no existe" : "Se inserto cer_Id : " + mensajeC;
                    row["Asegurado"] = mensajeT;
                    row["Amparos"] = mensajeA;
                    row["Beneficiarios"] = mensajeB;
                    row["Conyuge"] = mensajeCon;
                    row["OtroAsegurado"] = mensajeO;
                    mensajeT = string.Empty;
                    mensajeA = string.Empty;
                    mensajeB = string.Empty;
                    mensajeC = string.Empty;
                    mensajeO = string.Empty;
                    mensajeCon = string.Empty;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                }
                certificado = tabla[i];
                fechaInicio = Convert.ToDateTime(certificado[5].ToString());
                fechaFin = Convert.ToDateTime(certificado[15].ToString());
                divide = (fechaFin.Month - fechaInicio.Month) + 12 * (fechaFin.Year - fechaInicio.Year);    
            }
            else
            {
                if (tabla[i][0].ToString() == "2")
                {
                    mensajeT = (mensajeT == string.Empty) ? InsertarTercero(tabla[i]) : mensajeT + "</br>" + InsertarTercero(tabla[i]);
                    ter_Id = tabla[i][1].ToString();
                    sexo = tabla[i][4].ToString();
                    par_Id = (tabla[i][2] == "0") ? 1 : ((tabla[i][2] == "1") ? 2 : 3);
                    if(tabla[i-1][0] == "1")
                    {
                        mensajeC = cer_Id = InsertarCertificado(certificado,divide);
                        if (cer_Id == "0" || cer_Id == "1")
                        {
                            sumaError += 1;
                        }
                        else
                        {
                            sumaExito += 1;
                        }
                        sumaTodos += 1;
                        pol_Numero = tabla[i - 1][18].ToString();
                        fechaExpedicion = DateTime.Parse(tabla[i - 1][4].ToString());
                    }
                    if (tabla[i][2] == "1" && existe == false)
                    {
                        mensajeCon = ActualizarConyuge(cer_Id, tabla[i][1]);
                        otroAsegurado = false;
                    }
                    else
                    {
                        if (tabla[i][2] == "0")
                        {
                            otroAsegurado = false;
                        }
                        else
                        {
                            otroAsegurado = true;
                        }
                    }
                    existe = (cer_Id == "0" || cer_Id == "1") ? true : false;
                }
                else
                {
                    if (tabla[i][0].ToString() == "3" && existe == false)
                    {
                        matrizAmparos.Add(tabla[i]);
                        if(i+1 < tabla.Count)
                        {
                            if(tabla[i+1][0] != "3")
                            {
                                if(otroAsegurado)
                                {
                                    mensajeO = (mensajeO == string.Empty) ? InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo,divide,fechaExpedicion) : mensajeO + "</br>" + InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo,divide,fechaExpedicion);
                                }
                                else
                                {
                                    mensajeA = (mensajeA == string.Empty) ? InsertarAmparos(matrizAmparos, cer_Id, ter_Id, par_Id,divide) : mensajeA + "</br>" + InsertarAmparos(matrizAmparos, cer_Id, ter_Id, par_Id,divide);
                                }
                                matrizAmparos.Clear();
                            }
                        }
                        else
                        {
                            if (otroAsegurado)
                            {
                                mensajeO = (mensajeO == string.Empty) ? InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide,fechaExpedicion) : mensajeO + "</br>" + InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide,fechaExpedicion);
                            }
                            else
                            {
                                mensajeA = (mensajeA == string.Empty) ? InsertarAmparos(matrizAmparos, cer_Id, ter_Id, par_Id, divide) : mensajeA + "</br>" + InsertarAmparos(matrizAmparos, cer_Id, ter_Id, par_Id, divide);
                            }
                            matrizAmparos.Clear();
                        }
                    }
                    else
                    {
                        if (tabla[i][0].ToString() == "4" && existe == false)
                        {
                            matrizBeneficiario.Add(tabla[i]);
                            if (i + 1 < tabla.Count)
                            {
                                if (tabla[i + 1][0] != "4")
                                {
                                    mensajeB = (mensajeB == string.Empty) ? InsertarBeneficiarios(matrizBeneficiario, cer_Id, ter_Id, par_Id) : mensajeB + "</br>" + InsertarBeneficiarios(matrizBeneficiario, cer_Id, ter_Id, par_Id);
                                    matrizBeneficiario.Clear();
                                }
                            }
                            else
                            {
                                mensajeB = (mensajeB == string.Empty) ? InsertarBeneficiarios(matrizBeneficiario, cer_Id, ter_Id, par_Id) : mensajeB + "</br>" + InsertarBeneficiarios(matrizBeneficiario, cer_Id, ter_Id, par_Id);
                                matrizBeneficiario.Clear();
                            }
                        }
                    }
                }
            }
        }
        row["ID"] = (mensajeC == "0" || cer_Id == "1") ? "2" : "1";
        row["Certificado"] = (mensajeC == "0") ? "Ya existe cer_Id: "+ men_CerId : (mensajeC == "1") ? "La poliza no existe" : "Se inserto cer_Id: "+cer_Id;
        row["Asegurado"] = mensajeT;
        row["Amparos"] = mensajeA;
        row["Beneficiarios"] = mensajeB;
        row["Conyuge"] = mensajeCon;
        row["OtroAsegurado"] = mensajeO;
        dt.Rows.Add(row);
        row = dt.NewRow();
        return dt;
    }

    //Inserta o actualiza el tercero
    //Devuelve inserto = Inserto:ter_id, actualizo = Actualizo:ter_id, error = Error:ter_id
    public static string InsertarTercero(string[] vector)
    {
        string respuesta = "Error";
        int registros;
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();

        //Variables del tercero
        string ter_Id;
        int par_Id;
        int ter_TipoDocumento;
        string ter_Sexo;
        string ter_Apellidos;
        string ter_Nombres;
        int ter_EstadoCivil;
        DateTime ter_FechaNacimiento;
        int ciu_Codazzi;
        int dep_Codazzi;
        string ter_Direccion;
        string ter_TelefonoResidencia;
        string ter_TelefonoOficina;
        string ter_Celular;
        string ter_Correo;
        int ocu_Id;

        //Se toman los datos del archivo plano
        ter_Id = vector[1].ToString();
        par_Id = (vector[2].ToString() == string.Empty) ? 0 : int.Parse(vector[2].ToString());
        ter_TipoDocumento = ConversionTipoDocumento(vector[3].ToString());
        ter_Sexo = ConversionSexo(vector[4].ToString());
        ter_Apellidos = vector[5].ToString();
        ter_Nombres = vector[6].ToString();
        ter_EstadoCivil = ConversionEstadoCivil(vector[7].ToString());
        ter_FechaNacimiento = (vector[8] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[8].ToString());
        ciu_Codazzi = (vector[9] == string.Empty) ? 0 : int.Parse(vector[9].ToString());
        dep_Codazzi = (vector[10] == string.Empty) ? 0 : int.Parse(vector[10].ToString());
        ter_Direccion = vector[11].ToString();
        ter_TelefonoResidencia = vector[12].ToString();
        ter_TelefonoOficina = vector[13].ToString();
        ter_Celular = vector[14].ToString();
        ter_Correo = vector[15].ToString();
        ocu_Id = (par_Id == 0) ? 6 : ocu_IdN;

        //Se consulta si el tercero ya existe en la base de datos
        DataTable dtTercero = objAdministrarCertificado.sp_ConsultarNewTerceroPorTerId(ter_Id);

        //Se consulta el departamento y la ciudad
        DataTable dtDepartamento = new DataTable();
        if (dep_Codazzi != 0 && ciu_Codazzi != 0)
        {
            dtDepartamento = objAdministrarCertificado.sp_ConsultarDepartamentoCiudad(ciu_Codazzi);
            if (dtDepartamento.Rows.Count > 0)
            {
                dep_Codazzi = int.Parse(dtDepartamento.Rows[0]["dep_Id"].ToString());
                ciu_Codazzi = int.Parse(dtDepartamento.Rows[0]["ciu_Id"].ToString());
            }
            else
            {
                dep_Codazzi = dep_IdN;
                ciu_Codazzi = ciu_IdN;
            }
        }
        else
        {
            dep_Codazzi = dep_IdN;
            ciu_Codazzi = ciu_IdN;
        }

        //Si existe se actualiza el tercero,sino esxiste se comprueba que esten los datos obligatorios si estan se inserta el tercero
        //sino retorna error

        if (dtTercero.Rows.Count > 0)
        { 
            registros = objAdministrarCertificado.sp_ActualizarNewTerceroPorTerId(ter_Id,par_Id,ter_TipoDocumento,ter_Sexo,ter_Apellidos,ter_Nombres,ter_EstadoCivil,ter_FechaNacimiento,dep_Codazzi,ciu_Codazzi,ter_Direccion,ter_TelefonoResidencia,ter_TelefonoOficina,ter_Celular,ter_Correo,dtTercero);
            respuesta = (registros != 0) ? "Actualizo:" + ter_Nombres + " " + ter_Apellidos + " CC: " + ter_Id : "Error:" + ter_Nombres + " " + ter_Apellidos + " CC: " + ter_Id;
        }
        else
        {
            if (ter_Id == string.Empty || ter_TipoDocumento == 0)
            {
                respuesta = "Error:" + ter_Nombres + " " + ter_Apellidos + " CC: " + ter_Id;
            }
            else
            {
                registros = objAdministrarCertificado.sp_InsertarNewTercero(ter_Id,par_Id,ter_TipoDocumento,ter_Sexo,ter_Apellidos,ter_Nombres,ter_EstadoCivil,ter_FechaNacimiento,dep_Codazzi,ciu_Codazzi,ter_Direccion,ter_TelefonoResidencia,ter_TelefonoOficina,ter_Celular,ter_Correo,ocu_Id);
                respuesta = (registros != 0) ? "Inserto:" + ter_Nombres + " " + ter_Apellidos + " CC: " + ter_Id : "Error:" + ter_Nombres + " " + ter_Apellidos + " CC: " + ter_Id;
            }
        }
        return respuesta;
    }

    //Inserta certificado
    //Devuelve ya existe = 0, no existe poliza = 1, error = 0, se inserto = cer_Id
    public static string InsertarCertificado(string[] vector, int div)
    {
        string respuesta = "0";
        int registros;
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado(); 

        //Variables del certificado
        int agencia;
        int tipoDocumento;
        string ter_Id;
        DateTime cer_FechaExpedicion;
        DateTime cer_FechaProduccion;
        DateTime cer_VigenciaDesde;
        int ase_Codigo;
        int compania;
        int producto;
        int pro_Id;
        string cer_Certificado;
        int cer_Anualidad;
        int cer_Endoso;
        double cer_PrimaTotal;
        DateTime cer_FechaOrigenAnualidad;
        DateTime cer_FechaVencimientoAnualidad;
        string pla_Nit;
        string pla_Nombre;
        string pol_Numero;
        string paga_Identificacion;
        string paga_Nombre;
        int ase_Id;
        int paga_Id;
        int con_Id;
        int pla_Id;
        int age_Id;
        int cer_AnoProduccion;
        int MesProduccion;
        string MesProduccionLetras;
        DateTime VigenciaHasta;
        string pol_Id;
        int dep_Id = dep_IdN;

        agencia = (vector[1] == string.Empty) ? 0 : int.Parse(vector[1].ToString());
        tipoDocumento = ConversionTipoDocumento(vector[2].ToString());
        ter_Id = vector[3].ToString();
        cer_FechaExpedicion = (vector[4] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[4].ToString());
        cer_FechaProduccion = (cer_FechaExpedicion.Day < 21) ? cer_FechaExpedicion : cer_FechaExpedicion.AddMonths(1);
        cer_VigenciaDesde = (vector[5] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[5].ToString());
        ase_Codigo = (vector[6] == string.Empty) ? 0 : int.Parse(vector[6].ToString());
        compania = (vector[7] == string.Empty) ? 0 : int.Parse(vector[7].ToString());
        producto = (vector[8] == string.Empty) ? 0 : int.Parse(vector[8].ToString());
        pro_Id = (vector[9] == string.Empty) ? 0 : int.Parse(vector[9].ToString());
        cer_Certificado = (vector[10] == string.Empty) ? "0" : vector[10].ToString();
        cer_Anualidad = (vector[11] == string.Empty) ? 0 : int.Parse(vector[11].ToString());
        cer_Endoso = (vector[12] == string.Empty) ? 0 : int.Parse(vector[12].ToString());
        cer_PrimaTotal = (vector[13] == string.Empty) ? 0 : double.Parse(vector[13].ToString());
        cer_PrimaTotal = cer_PrimaTotal / div; 
        cer_FechaOrigenAnualidad = (vector[14] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[14].ToString());
        cer_FechaVencimientoAnualidad = (vector[15] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[15].ToString());
        pla_Nit = vector[16].ToString();
        pla_Nombre = vector[17].ToString();
        pol_Numero = vector[18].ToString();
        paga_Identificacion = vector[19].ToString();
        paga_Nombre = vector[20].ToString();
        cer_AnoProduccion = cer_FechaProduccion.Year;
        MesProduccion = cer_FechaProduccion.Month;
        DateTimeFormatInfo temMesLetras = new CultureInfo("es-ES", false).DateTimeFormat;
        MesProduccionLetras = temMesLetras.GetMonthName(cer_FechaProduccion.Month).ToUpper();
        VigenciaHasta =  cer_VigenciaDesde.AddYears(1);

        men_CerId = cer_Certificado;

        //Consulta certificado por tercero y producto
        DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(ter_Id, pro_Id, cer_Certificado);

        if(dtCertificado.Rows.Count != 0)
        {
            respuesta = "0";
            men_CerId = dtCertificado.Rows[0]["cer_Id"].ToString();
        }
        else
        {
            //Consulta poliza por el numero pol_numero
            DataTable dtPoliza = objAdministrarCertificado.sp_ConsultarNewPolizaPorGR(pol_Numero);
            if(dtPoliza.Rows.Count == 0)
            {
                respuesta = "1";
            }
            else
            {
                pol_Id = dtPoliza.Rows[0]["pol_Id"].ToString();
                //Consulta la Localidad por la poliza GR
                DataTable dtLocalidad = objAdministrarCertificado.sp_ConsultarLocalidadPorGR(pol_Numero);
                if(dtLocalidad.Rows.Count != 0)
                {
                    dep_Id = int.Parse(dtLocalidad.Rows[0]["dep_Id"].ToString());
                }
                //Consulta asesor por el codigo ase_Codigo
                DataTable dtAsesor = objAdministrarCertificado.sp_ConsultarNewAsesorPorCodigo(ase_Codigo);
                if(dtAsesor.Rows.Count == 0)
                {
                    objAdministrarCertificado.sp_InsertarAsesor(ase_Codigo, "PENDIENTE", "X ASIGNAR", dtLocalidad.Rows[0]["dep_Id"].ToString(), com_Id, "SI", "NO");
                    dtAsesor = objAdministrarCertificado.sp_ConsultarNewAsesorPorCodigo(ase_Codigo);
                }
                ase_Id = int.Parse(dtAsesor.Rows[0]["ase_Id"].ToString());
                paga_Id = paga_IdN;
                con_Id = con_IdN;
                
                //Consulta plantel por nombre
                DataTable dtPlantel = new DataTable();
                if (pla_Nombre != string.Empty)
                {
                    dtPlantel = objAdministrarCertificado.sp_ConsultarPlantel(pla_Nombre);
                }
                if (dtPlantel.Rows.Count != 0)
                {
                    pla_Id = int.Parse(dtPlantel.Rows[0]["pla_Id"].ToString());
                }
                else
                {
                    pla_Id = pla_IdN;
                }
                //Consulta la agencia por la poliza GR
                DataTable dtAgencia = objAdministrarCertificado.sp_ConsultarAgenciaPorGR(pol_Numero);
                if(dtAgencia.Rows.Count != 0)
                {
                    age_Id = int.Parse(dtAgencia.Rows[0]["age_Id"].ToString());
                }
                else
                {
                    age_Id = age_IdN;
                }
                //Se inserta el certificado
                registros = objAdministrarCertificado.sp_InsertarCertificado(age_Id, ter_Id, cer_FechaExpedicion, cer_VigenciaDesde, ase_Id, paga_Id, cer_FechaRecibido, com_Id, pro_Id, cer_SoporteFisico, cer_Endoso, estcar_Id, tipdev_Id, caudev_Id, cer_PrimaTotal, cer_Consecutivo, cer_Certificado, cer_AnoProduccion, con_Id, cer_EstadoNegocio, dep_Id, MesProduccion, MesProduccionLetras, tipoMovimientoN, VigenciaHasta, pla_Id, pol_Id, mom_Id, casesp_Id, cer_FechaDigitacion, perPag_Id,migracion);

                //Consulta certificado por tercero y producto
                dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(ter_Id, pro_Id, cer_Certificado);
                
                if (registros != 0)
                    respuesta = dtCertificado.Rows[0]["cer_Id"].ToString();
            }
        }
        return respuesta;
    }

    //Inserta los amparos del certificado
    public static string InsertarAmparos(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id, int div)
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();

        //Variables a insertar en la tabla NewExtraPrima
        double ext_ValorAsegurado = 0;
        double ext_ValorPrima = 0;

        //Variables de los amparos
        int amp_Id;
        string amp_Nombre;
        double ampcer_ValorAsegurado;
        double ampcer_Tasa;
        double ampcer_Prima;
        string temp;
        double ampcer_TasaCalculada;

        string respuestaF = "CC: "+ter_Id+";" ;

        for (int i = 0; i < matriz.Count; i++ )
        {
            amp_Id = ConversionCodigoAmparo(matriz[i][1].ToString());
            amp_Nombre = matriz[i][2];
            ampcer_ValorAsegurado = (matriz[i][3] == string.Empty) ? 0 : double.Parse(matriz[i][3].ToString());
            if (matriz[i][4].ToString() == string.Empty)
            {
                temp = "0";
            }
            else
            {
                if (matriz[i][4][0] == ',' || matriz[i][4][0] == '.')
                {
                    temp = "0" + matriz[i][4].ToString();
                }
                else
                {
                    temp = matriz[i][4].ToString();
                }
            }
            ampcer_Tasa = double.Parse(temp.Replace(",", "."));
            ampcer_Prima = (matriz[i][5] == string.Empty) ? 0 : double.Parse(matriz[i][5].ToString());
            ampcer_Prima = ampcer_Prima / div;
            ampcer_TasaCalculada = Math.Round(ampcer_Prima * 1000000 / ampcer_ValorAsegurado,0);

            //Consulta  Amparos del certificado
            DataTable dtAmparo = new DataTable();
            dtAmparo = objAdministrarCertificado.sp_ConsultarAmparos(cer_Id, ter_Id, par_Id.ToString(), amp_Id);
            if (dtAmparo.Rows.Count > 0)
            {
                respuestaF = respuestaF + "/NO/" + amp_Nombre + ";";
            }
            else
            {
                objAdministrarCertificado.sp_InsertarAmparosCertificado(cer_Id, ter_Id, par_Id.ToString(), amp_Nombre, ampcer_ValorAsegurado,ampcer_Prima, ampcer_TasaCalculada, amp_Id);
                respuestaF = respuestaF + "/SI/" + amp_Nombre + ";";    
            }

            if (amp_Id == 1)
            {
                ext_ValorAsegurado = ampcer_ValorAsegurado;
            }
            else
            {
                if(par_Id > 2 && amp_Id == 5 )
                {
                    ext_ValorAsegurado = ampcer_ValorAsegurado;
                }
            }
            ext_ValorPrima += ampcer_Prima;
        }
        //Consulta extra prima
        AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
        objAdministrarCertificados.CrearExtraPrima(int.Parse(cer_Id), int.Parse(cer_Id), ext_ValorAsegurado, 0, ext_ValorPrima, par_Id);

        return respuestaF;
    }

    //Insertar beneficiarios
    public static string InsertarBeneficiarios(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id)
    {
        int respuesta = 0;
        double suma = 0;
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();

        //Variables de los beneficiarios
        int ben_TipoDocumento;
        string ben_Identificacion;
        string ben_Apellidos;
        string ben_Nombres;
        int ben_Edad;
        double ben_Porcentaje;
        string ben_Parentesco;
        int ben_IdParentesco;

        string respuestaF = "CC: " + ter_Id + ";";

        for (int i = 0; i < matriz.Count; i++)
        {
            ben_TipoDocumento = ConversionTipoDocumento(matriz[i][1]);
            ben_Identificacion = matriz[i][2].ToString();
            ben_Apellidos = matriz[i][3];
            ben_Nombres = matriz[i][4];
            ben_Edad = (matriz[i][5] == string.Empty) ? 0 : int.Parse(matriz[i][5]);
            ben_Porcentaje = (matriz[i][6] == string.Empty) ? 0 : double.Parse(matriz[i][6]);
            ben_Parentesco = matriz[i][7];
            ben_IdParentesco = ConversionParentesco(matriz[i][8]);

            //Consulta la suma de los porcentajes del beneficiario
            DataTable dtBeneficiario = objAdministrarCertificado.sp_ConsultarAmparosSuma(cer_Id, ter_Id);

            if (dtBeneficiario.Rows.Count != 0)
            {
                suma = (dtBeneficiario.Rows[0]["sumaPorcentajes"].ToString() == string.Empty) ? 0 : double.Parse(dtBeneficiario.Rows[0]["sumaPorcentajes"].ToString());
            }

            if ((suma + ben_Porcentaje) <= 100)
            {
                objAdministrarCertificado.sp_InsertarBeneficiario(ben_Identificacion, ben_Apellidos, ben_Nombres, ben_Edad, ben_Porcentaje, ben_Parentesco, cer_Id, ter_Id, par_Id);
                respuesta += 1;
                respuestaF = respuestaF + "/SI/" + ben_Nombres +" "+ ben_Apellidos + ";";
            }
            else
            {
                respuestaF = respuestaF + "/NO/" + ben_Nombres + " " + ben_Apellidos + ";";
            }
        }
        
        return respuestaF;
    }

    //Insertar otro asegurado
    public static string InsertarOtroAsegurado(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id, string pol_Numero, string sexo,int div, DateTime fechaExpedicion)
    {
        string respuesta = "Error";
        respuesta = InsertarAmparos(matriz, cer_Id, ter_Id, par_Id, div);
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        double ext_ValorPrima = 0;

        //Variables de los amparos
        int amp_Id;
        string amp_Nombre;
        double ampcer_ValorAsegurado=0;
        double ampcer_Tasa;
        double ampcer_Prima=0;
        string temp;
        double ampcer_TasaCalculada;

        for (int i = 0; i < matriz.Count; i++)
        {
            if (matriz[i][1].ToString() == "663" || matriz[i][1].ToString() == "681")
            {
                amp_Id = ConversionCodigoAmparo(matriz[i][1].ToString());
                amp_Nombre = matriz[i][2];
                ampcer_ValorAsegurado = (matriz[i][3] == string.Empty) ? 0 : double.Parse(matriz[i][3].ToString());
                if (matriz[i][4].ToString() == string.Empty)
                {
                    temp = "0";
                }
                else
                {
                    if (matriz[i][4][0] == ',' || matriz[i][4][0] == '.')
                    {
                        temp = "0" + matriz[i][4].ToString();
                    }
                    else
                    {
                        temp = matriz[i][4].ToString();
                    }
                }
                ampcer_Tasa = double.Parse(temp.Replace(",", "."));
                ampcer_TasaCalculada = Math.Round(ampcer_Prima * 1000000 / ampcer_ValorAsegurado, 0);
            }
            ampcer_Prima = (matriz[i][5] == string.Empty) ? 0 : double.Parse(matriz[i][5].ToString());
            ampcer_Prima = ampcer_Prima / div;
            ext_ValorPrima += ampcer_Prima;
        }
        if (matriz.Count != 0)
        {
            //Consulta  Amparos del certificado
            DataTable dtPlanPoliza = new DataTable();
            dtPlanPoliza = objAdministrarCertificado.sp_ConsultarPlanPoliza(pol_Numero, ter_Id, ampcer_ValorAsegurado, sexo,fechaExpedicion);

            //Consulta  otro asegurado
            DataTable dtOtroAsegurado = new DataTable();

            if (dtPlanPoliza.Rows.Count > 0)
            {
                dtOtroAsegurado = objAdministrarCertificado.sp_ConsultarOtroAsegurado(cer_Id, ter_Id);
                if (dtOtroAsegurado.Rows.Count == 0)
                {
                    objAdministrarCertificado.sp_InsertarOtroAseguradoSimple(cer_Id, ter_Id, par_Id.ToString(), dtPlanPoliza, ext_ValorPrima);
                    objAdministrarCertificado.sp_ActualizarTipoMovimiento3(cer_Id, tipoMovimiento3);
                    respuesta = "/SI/" + respuesta;
                }
            }
            else
            {
                respuesta = "/NO/" + respuesta;
            }
        }
        return respuesta;
    }

    //Actualiza los datos del conyuge en el certificado
    public static string ActualizarConyuge(string cer_Id, string IdConyuge)
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        string respuesta = "/NO/" + "CC: " + IdConyuge; 

        int registros = objAdministrarCertificado.sp_ActualizarNewCertificadoDatosConyuge(cer_Id, IdConyuge);

        if (registros > 0)
            respuesta = "/SI/"+"CC: "+IdConyuge;

        
        return respuesta;
    }
    
    public static int ConversionTipoDocumento(string tipo)
    {
        int res;

        if (tipo.Contains("CC"))
            res = 1;
        else
            if (tipo.Contains("CE"))
                res = 3;
            else
                if (tipo.Contains("TI"))
                    res = 2;
                else
                    if (tipo.Contains("RC"))
                        res = 6;
                    else
                        res = (tipo == string.Empty) ? 0 : int.Parse(tipo);
        return res;
    }

    public static int ConversionParentesco(string tipo)
    {
        int res;

        if (tipo == "1" || tipo == "2")
            res = 2;
        else
            if (tipo == "3")
                res = 3;
            else
                if (tipo == "4")
                    res = 5;
                else
                    res = 17;
        return res;
    }

    public static string ConversionSexo(string tipo)
    {
        string res;

        if (tipo == "F")
            res = "FEMENINO";
        else
            if (tipo == "M")
                res = "MASCULINO";
            else
                res = tipo;
        return res;
    }

    public static int ConversionEstadoCivil(string tipo)
    {
        int res;

        if (tipo == "3")
            res = 6;
        else
            if (tipo == "5")
                res = 3;
            else
                if (tipo == "6")
                    res = 5;
                else
                    res = (tipo == string.Empty) ? 7 : int.Parse(tipo);
        return res;
    }

    public static int ConversionCodigoAmparo(string tipo)
    {
        int res;

        if (tipo.Contains("663"))
            res = 1;
        else
            if (tipo.Contains("664"))
                res = 2;
            else
                if (tipo.Contains("665"))
                    res = 3;
                else
                    if (tipo.Contains("666"))
                        res = 6;
                    else
                        if (tipo.Contains("680"))
                            res = 4;
                        else
                            if (tipo.Contains("681"))
                                res = 5;
                            else
                                if (tipo.Contains("670"))
                                    res = 8;
                                else
                                    if (tipo.Contains("671"))
                                        res = 7;
                                    else
                                        if (tipo.Contains("698"))
                                            res = 6;
                                        else
                                            res = (tipo == string.Empty) ? 0 : 0;
        return res;
    }

}