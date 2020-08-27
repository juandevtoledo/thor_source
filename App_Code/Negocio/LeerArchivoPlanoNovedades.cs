using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LeerArchivoPlanoNovedades
/// </summary>
public class LeerArchivoPlanoNovedades
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
    public static int tipoMovimiento2 = 0;
    public static int tipoMovimiento3 = 63;

    public static string cer_IdAnterior;

    //Recorre el archivo e inserta la informacion
    public static DataTable InsertarArchivoNovedades(List<string[]> tabla)
    {
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
                if (i > 0)
                {
                    row["ID"] = (mensajeC == "0" || cer_Id == "1") ? "2" : "1";
                    row["Certificado"] = (mensajeC == "0") ? "No existe certificado: " + certificado[13] : (mensajeC == "1") ? "LA POLIZA NO EXISTE" : "SE INSERTO CER_ID : " + mensajeC;
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
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                }
                certificado = tabla[i];
                fechaInicio = Convert.ToDateTime(certificado[7].ToString());
                fechaFin = Convert.ToDateTime(certificado[5].ToString());
                divide = Math.Abs(fechaFin.Month - fechaInicio.Month) + 12 * (fechaFin.Year - fechaInicio.Year);
                divide = (divide < 1)? 1 : divide;
            }
            else
            {
                if (tabla[i][0].ToString() == "2")
                {
                    mensajeT = (mensajeT == string.Empty) ? InsertarTercero(tabla[i]) : mensajeT + "</br>" + InsertarTercero(tabla[i]);
                    ter_Id = tabla[i][1].ToString();
                    sexo = tabla[i][7].ToString();
                    par_Id = (tabla[i][3] == "0") ? 1 : ((tabla[i][3] == "1") ? 2 : 3);
                    if (tabla[i - 1][0] == "1")
                    {
                        mensajeC = cer_Id = InsertarCertificado(certificado, divide);
                        pol_Numero = tabla[i - 1][21].ToString();
                        fechaExpedicion = DateTime.Parse(tabla[i - 1][4].ToString());
                    }
                    if (tabla[i][3] == "1" && existe == false)
                    {
                        mensajeCon = ActualizarConyuge(cer_Id, tabla[i][1]);
                        otroAsegurado = false;
                    }
                    else
                    {
                        if (tabla[i][3] == "0")
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
                        if (i + 1 < tabla.Count)
                        {
                            if (tabla[i + 1][0] != "3")
                            {
                                if (otroAsegurado)
                                {
                                    mensajeO = (mensajeO == string.Empty) ? InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide, fechaExpedicion) : mensajeO + "</br>" + InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide, fechaExpedicion);
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
                            if (otroAsegurado)
                            {
                                mensajeO = (mensajeO == string.Empty) ? InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide, fechaExpedicion) : mensajeO + "</br>" + InsertarOtroAsegurado(matrizAmparos, cer_Id, ter_Id, par_Id, pol_Numero, sexo, divide, fechaExpedicion);
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
        row["Certificado"] = (mensajeC == "0") ? "No existe certificado: " + certificado[13] : (mensajeC == "1") ? "LA POLIZA NO EXISTE" : "SE INSERTO CER_ID: " + cer_Id;
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

        //Variables del asegurado
        string ter_Id;
        string ter_fechaOrigenAsegurado;
        int par_Id;
        int ter_TipoDocumento;
        string ter_Apellidos;
        string ter_Nombres;
        string ter_Sexo;
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
        ter_fechaOrigenAsegurado = vector[2].ToString();
        par_Id = (vector[3].ToString() == string.Empty) ? 0 : int.Parse(vector[3].ToString());
        ter_TipoDocumento = ConversionTipoDocumento(vector[4].ToString());
        ter_Apellidos = vector[5].ToString();
        ter_Nombres = vector[6].ToString();
        ter_Sexo = ConversionSexo(vector[7].ToString());
        ter_EstadoCivil = ConversionEstadoCivil(vector[8].ToString());
        ter_FechaNacimiento = (vector[9] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[9].ToString());
        ciu_Codazzi = (vector[10] == string.Empty) ? 0 : int.Parse(vector[10].ToString());
        dep_Codazzi = (vector[11] == string.Empty) ? 0 : int.Parse(vector[11].ToString());
        ter_Direccion = vector[12].ToString();
        ter_TelefonoResidencia = vector[13].ToString();
        ter_TelefonoOficina = vector[14].ToString();
        ter_Celular = vector[15].ToString();
        ter_Correo = vector[16].ToString();
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
            registros = objAdministrarCertificado.sp_ActualizarNewTerceroPorTerId(ter_Id, par_Id, ter_TipoDocumento, ter_Sexo, ter_Apellidos, ter_Nombres, ter_EstadoCivil, ter_FechaNacimiento, dep_Codazzi, ciu_Codazzi, ter_Direccion, ter_TelefonoResidencia, ter_TelefonoOficina, ter_Celular, ter_Correo, dtTercero);
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
                registros = objAdministrarCertificado.sp_InsertarNewTercero(ter_Id, par_Id, ter_TipoDocumento, ter_Sexo, ter_Apellidos, ter_Nombres, ter_EstadoCivil, ter_FechaNacimiento, dep_Codazzi, ciu_Codazzi, ter_Direccion, ter_TelefonoResidencia, ter_TelefonoOficina, ter_Celular, ter_Correo, ocu_Id);
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
        DateTime cer_FechaVigenciaEndoso;
        DateTime cer_FechaVencimientoEndoso;
        DateTime cer_VigenciaDesde;
        DateTime cer_FechaProduccion;
        int ase_Codigo;
        string ase_Nombre;
        int compania;
        int producto;
        int pro_Id;
        string cer_Certificado;
        int endoso;
        int cer_Endoso;
        int cer_Anualidad;
        int cer_ConsecutivoEndoso;
        double cer_PrimaTotal;
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
        cer_FechaVigenciaEndoso = (vector[5] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[5].ToString());
        cer_FechaVencimientoEndoso = (vector[6] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[6].ToString());
        cer_VigenciaDesde = (vector[7] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[7].ToString());
        cer_FechaProduccion = (cer_FechaExpedicion.Day < 21) ? cer_FechaExpedicion : cer_FechaExpedicion.AddMonths(1);
        ase_Codigo = (vector[8] == string.Empty) ? 0 : int.Parse(vector[8].ToString());
        ase_Nombre = vector[9].ToString();
        compania = (vector[10] == string.Empty) ? 0 : int.Parse(vector[10].ToString());
        producto = (vector[11] == string.Empty) ? 0 : int.Parse(vector[11].ToString());
        pro_Id = (vector[12] == string.Empty) ? 0 : int.Parse(vector[12].ToString());
        cer_Certificado = (vector[13] == string.Empty) ? "0" : vector[13].ToString();
        endoso = (vector[14] == string.Empty) ? 0 : int.Parse(vector[14].ToString());
        cer_Endoso = (vector[15] == string.Empty) ? 0 : int.Parse(vector[15].ToString());
        cer_Anualidad = (vector[16] == string.Empty) ? 0 : int.Parse(vector[16].ToString());
        cer_ConsecutivoEndoso = (vector[17] == string.Empty) ? 0 : int.Parse(vector[17].ToString());
        cer_PrimaTotal = (vector[18] == string.Empty) ? 0 : double.Parse(vector[18].ToString());
        cer_PrimaTotal = cer_PrimaTotal / div;
        pla_Nit = vector[19].ToString();
        pla_Nombre = vector[20].ToString();
        pol_Numero = vector[21].ToString();
        paga_Identificacion = vector[22].ToString();
        paga_Nombre = vector[23].ToString();
        cer_AnoProduccion = cer_FechaProduccion.Year;
        MesProduccion = cer_FechaProduccion.Month;
        DateTimeFormatInfo temMesLetras = new CultureInfo("es-ES", false).DateTimeFormat;
        MesProduccionLetras = temMesLetras.GetMonthName(cer_FechaProduccion.Month).ToUpper();
        VigenciaHasta = cer_VigenciaDesde.AddYears(1);

        //Consulta certificado por tercero y producto
        DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(ter_Id, pro_Id, cer_Certificado);

        if (dtCertificado.Rows.Count != 0)
        {
            DataTable dtCertificadoNuevo = objAdministrarCertificado.spDuplicarCertificado(dtCertificado.Rows[0]["cer_Id"].ToString());
            cer_IdAnterior = dtCertificado.Rows[0]["cer_Id"].ToString(); 
            //Consulta poliza por el numero pol_numero
            DataTable dtPoliza = objAdministrarCertificado.sp_ConsultarNewPolizaPorGR(pol_Numero);
            if (dtPoliza.Rows.Count == 0)
            {
                pol_Id = dtCertificado.Rows[0]["pol_Id"].ToString();
            }
            else
            {
                pol_Id = dtPoliza.Rows[0]["pol_Id"].ToString();
            }
            //Consulta la Localidad por la poliza GR
            DataTable dtLocalidad = objAdministrarCertificado.sp_ConsultarLocalidadPorGR(pol_Numero);
            if (dtLocalidad.Rows.Count != 0)
            {
                dep_Id = int.Parse(dtLocalidad.Rows[0]["dep_Id"].ToString());
            }
            else
            {
                dep_Id = int.Parse(dtCertificado.Rows[0]["Localidad"].ToString());
            }
            //Consulta asesor por el codigo ase_Codigo
            DataTable dtAsesor = objAdministrarCertificado.sp_ConsultarNewAsesorPorCodigo(ase_Codigo);
            if (dtAsesor.Rows.Count == 0)
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
                pla_Id = int.Parse(dtCertificado.Rows[0]["pla_Id"].ToString());
            }
            //Consulta la agencia por la poliza GR
            DataTable dtAgencia = objAdministrarCertificado.sp_ConsultarAgenciaPorGR(pol_Numero);
            if (dtAgencia.Rows.Count != 0)
            {
                age_Id = int.Parse(dtAgencia.Rows[0]["age_Id"].ToString());
            }
            else
            {
                age_Id = int.Parse(dtCertificado.Rows[0]["age_Id"].ToString());
            }
            //Se inserta el certificado
            registros = objAdministrarCertificado.sp_ActualizarCertificado(dtCertificadoNuevo.Rows[0]["cer_Id"].ToString(),age_Id, 
                                        cer_FechaExpedicion, cer_VigenciaDesde, ase_Id, paga_Id,
                                        cer_FechaRecibido, pro_Id, cer_Endoso, 2, 3, estcar_Id,
                                        cer_PrimaTotal, con_Id, cer_EstadoNegocio, dep_Id, tipoMovimientoN, VigenciaHasta, 
                                        VigenciaHasta, pla_Id, pol_Id, mom_Id, cer_FechaDigitacion);
            if (registros != 0)
                respuesta = dtCertificadoNuevo.Rows[0]["cer_Id"].ToString();  
        }
        else
        {
            respuesta = "0";
        }
        return respuesta;
    }

    //Inserta los amparos del certificado
    //Devuelve numero de amparos insertados
    public static string InsertarAmparos(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id, int div)
    {
        string respuestaF = "CC: " + ter_Id + ";";
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

        for (int i = 0; i < matriz.Count; i++)
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
            ampcer_TasaCalculada = Math.Round(ampcer_Prima * 1000000 / ampcer_ValorAsegurado, 0);

            //Consulta  Amparos del certificado
            DataTable dtAmparo = new DataTable();
            DataTable dtAmparoAnterior = new DataTable();
            dtAmparo = objAdministrarCertificado.sp_ConsultarAmparos(cer_Id, ter_Id, par_Id.ToString(), amp_Id);
            if (dtAmparo.Rows.Count > 0)
            {
                respuestaF = respuestaF + "/NO/" + amp_Nombre + ";";
            }
            else
            {
                dtAmparoAnterior = objAdministrarCertificado.sp_ConsultarAmparos(cer_IdAnterior, ter_Id, par_Id.ToString(), amp_Id);
                if(dtAmparoAnterior.Rows.Count != 0)
                {
                    ampcer_Tasa = (ampcer_ValorAsegurado <= 0)? double.Parse(dtAmparoAnterior.Rows[0]["ampcer_Tasa"].ToString()) : ampcer_TasaCalculada;
                }
                objAdministrarCertificado.sp_InsertarAmparosCertificado(cer_Id, ter_Id, par_Id.ToString(), amp_Nombre, ampcer_ValorAsegurado, ampcer_Prima, ampcer_Tasa, amp_Id);
                respuestaF = respuestaF + "/SI/" + amp_Nombre + ";";  
            }

            if (amp_Id == 1)
            {
                ext_ValorAsegurado = ampcer_ValorAsegurado;
            }
            else
            {
                if (par_Id > 2 && amp_Id == 5)
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
    //Devuelve numero de beneficiarios insertados
    public static string InsertarBeneficiarios(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id)
    {
        string respuestaF = "CC: " + ter_Id + ";";
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
                respuestaF = respuestaF + "/SI/" + ben_Nombres + " " + ben_Apellidos + ";";
            }
            else
            {
                respuestaF = respuestaF + "/NO/" + ben_Nombres + " " + ben_Apellidos + ";";
            }
        }
        return respuestaF;
    }

    //Insertar otro asegurado
    //Devuelve inserto = 1, no inserto = 0
    public static string InsertarOtroAsegurado(List<string[]> matriz, string cer_Id, string ter_Id, int par_Id, string pol_Numero, string sexo, int div, DateTime fechaExpedicion)
    {
        string respuesta = "Error";
        respuesta = InsertarAmparos(matriz, cer_Id, ter_Id, par_Id, div);
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        double ext_ValorPrima = 0;

        //Variables de los amparos
        int amp_Id;
        string amp_Nombre;
        double ampcer_ValorAsegurado = 0;
        double ampcer_Tasa;
        double ampcer_Prima = 0;
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
            dtPlanPoliza = objAdministrarCertificado.sp_ConsultarPlanPoliza(pol_Numero, ter_Id, ampcer_ValorAsegurado, sexo, fechaExpedicion);

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
                dtOtroAsegurado = objAdministrarCertificado.sp_ConsultarOtroAsegurado(cer_IdAnterior, ter_Id);
                if(dtOtroAsegurado.Rows.Count != 0)
                {
                    objAdministrarCertificado.sp_InsertarOtroAseguradoSimple(cer_Id, ter_Id, par_Id.ToString(), dtOtroAsegurado, ext_ValorPrima);
                    respuesta = "/SI/" + respuesta;
                }
                else
                {
                    respuesta = "/NO/" + respuesta;
                }  
            }
        }
        return respuesta;
    }

    //Actualiza los datos del conyuge en el certificado
    //Devuelve inserto = 1, no inserto = 0
    public static string ActualizarConyuge(string cer_Id, string IdConyuge)
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        string respuesta = "/NO/" + "CC: " + IdConyuge; 

        int registros = objAdministrarCertificado.sp_ActualizarNewCertificadoDatosConyuge(cer_Id, IdConyuge);

        if (registros > 0)
            respuesta = "/SI/" + "CC: " + IdConyuge;


        return respuesta;
    }
    
    //Conversion del tipo de documento
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