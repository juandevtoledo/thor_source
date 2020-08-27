using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

/// <summary>
/// Descripción breve de LeerArchivoPlano
/// </summary>
public class LeerArchivoPlanoNuevo
{
    //Constantes
    public static int momento = 3;
    public static int compania = 1;
    public static int estadoCargue = 5;
    public static int TomadorIdPoliza = 0;
    public static int polizaTipo = 0;
    public static int casosEspeciales = 0;
    public static string estadoNegocio = "PRODUCCION NUEVA";
    public static int periodoPago = 1;
    public static int soporteFisico = 1;
    public static string consecutivo = "0";
    public static string pagaduriaTemp = "661";
    public static string convenioTemp = "781";
    public static string plantelTemp = "24522";
    public static int caudev_Id = 0;
    public static int tipdev_Id = 0;
    public static int cer_Migracion = 0;

    
    //Variables del archivo
    //Variables del certificado
    public static int Cagencia;
    public static int CtipoDocumento;
    public static string CcedulaAsegurado;
    public static DateTime CfechaExpedicion;
    public static DateTime CfechaProduccion; 
    public static DateTime CinicioVigencia;
    public static int CcodigoAsesor;
    public static int Ccompania;
    public static int CcodigoProducto;
    public static int Cproducto;
    public static string CnumeroPolizaCertificado;
    public static int Canualidad;
    public static string CnumeroEndoso;
    public static double CprimaCertificado;
    public static DateTime CfechaOrigenAsegurado;
    public static DateTime CfechaVencimiento;
    public static string CnitPlantelEducativo;
    public static string CnombrePlantel;
    public static string CpolizaGR;
    public static string CcodigoPagaduria;
    public static string CnombrePagaduria;

    //Variables del asegurado
    public static string Acedula;
    public static int Aperentesco;
    public static int AtipoDocumento;
    public static string Asexo;
    public static string Aapellidos;
    public static string Anombre;
    public static int AestadoCivil;
    public static DateTime AfechaNacimiento;
    public static int Adepartamento;
    public static int Aciudad;
    public static string Adireccion;
    public static string AtelefonoResidencia;
    public static string AtelefonoOficina;
    public static string Acelular;
    public static string Acorreo;

    //Variables de los amparos
    public static int AmpCodigo;
    public static string AmpNombre;
    public static double AmpValorAsegurado;
    public static double AmpTasa;
    public static double AmpPrima;

    //Variables de los beneficiarios
    public static int BtipoDocumento;
    public static string Bdocumento;
    public static string Bapellidos;
    public static string Bnombres;
    public static int Bedad;
    public static double Bporcentaje;
    public static string Bparentesco;
    public static int BidParentesco;

    public static FrameworkEntidades entidades = new FrameworkEntidades();
    public static FrameworkEntidades cnx = new FrameworkEntidades();

    public static int sumaExito = 0;
    public static int sumaError = 0;
    public static int sumaTodos = 0;


    public static DataTable InsertarArchivo(List<string[]> tabla)
    {
        string mensaje = "";
        string[] temp = new String[30];
        string tempTerId = string.Empty;
        int conyuge = 0;
        int otro = 0;
        string ter_Id = string.Empty;
        string sexo = string.Empty;
        string par_Id = string.Empty;
        int prod_Id = 0;
        int sumaPrima = 0;
        int valorAsegurado = 0;

        sumaExito = 0;
        sumaError = 0;
        sumaTodos = 0;

        DataTable dtResumen = new DataTable();
        dtResumen.Columns.Add("ID");
        dtResumen.Columns.Add("Certificado");
        dtResumen.Columns.Add("Asegurado");
        dtResumen.Columns.Add("Amparos");
        dtResumen.Columns.Add("Beneficiarios");
        dtResumen.Columns.Add("Conyuge");
        dtResumen.Columns.Add("OtroAsegurado");

        DataRow row = dtResumen.NewRow();

        int sumaAmparosInsertados = 0;
        int sumaAmparosYaEstan = 0;
        int sumaAmparosNo = 0;
              
        for (int i = 0; i < tabla.Count; i++ )
        {
            if (tabla[i][0] == "1")
            {
                temp = tabla[i];
                conyuge = 0;
                otro = 0;
                row["Amparos"] = "Amparos Insertados: " + sumaAmparosInsertados.ToString() + "</br>" + "Amparos Existentes: " + sumaAmparosYaEstan.ToString() + "</br>" + "Amparos No Insertados: " + sumaAmparosNo.ToString() + "</br>";
                sumaAmparosInsertados = 0;
                sumaAmparosYaEstan = 0;
                sumaAmparosNo = 0;
                sumaPrima = 0;
                if(i > 0)
                {
                    dtResumen.Rows.Add(row);
                    row = dtResumen.NewRow();
                } 
            }
            else
            {
                if (tabla[i][0] == "2")
                {
                    mensaje = InsertarAsegurado(tabla[i]);
                    row["Asegurado"] = row["Asegurado"] + mensaje + "</br>";
                    ter_Id = tabla[i][1];
                    sexo = tabla[i][4];
                    if(tabla[i-1][0] == "1")
                    {
                        mensaje = InsertarCertificado(tabla[i - 1]);
                        if(mensaje == "EL CERTIFICADO YA EXISTE")
                        {
                            row["ID"] = "2";
                            sumaError += 1;
                        }
                        else
                        {
                            if (mensaje == "LA POLIZA NO EXISTE")
                            {
                                row["ID"] = "2";
                                sumaError += 1;
                            }
                            else
                            {
                                row["ID"] = "1";
                                sumaExito += 1;
                            }
                        }
                        row["Certificado"] = mensaje;
                        par_Id = "1";
                        prod_Id = int.Parse(tabla[i-1][9]);
                    }
                    else
                    {
                        if(tabla[i][2] == "1")
                        {
                            conyuge = 1;
                            par_Id = "2";
                            mensaje = ActualizarConyuge(temp[10],tabla[i][1]);
                            row["Conyuge"] = mensaje;

                        }
                        else
                        {
                            otro = 1;
                            par_Id = "3";
                        }
                    }
                }
                else
                {
                    if(tabla[i][0] == "3")
                    {
                        if(otro == 0)
                        {
                            if (InsertarAmparo(tabla[i], ter_Id, par_Id, prod_Id, temp[10], temp[3]) == 1)
                            {
                                sumaAmparosInsertados += 1;
                            }
                            else
                            {
                                if (InsertarAmparo(tabla[i], ter_Id, par_Id, prod_Id, temp[10], temp[3]) == 2)
                                {
                                    sumaAmparosYaEstan += 1;
                                }
                                else
                                {
                                    sumaAmparosYaEstan += 1;
                                }
                            }
                            if (tabla[i][1].Contains("663"))
                            {
                                valorAsegurado = int.Parse(tabla[i][3].ToString());
                            }
                            sumaPrima += (tabla[i][5] == string.Empty) ? 0 : int.Parse(tabla[i][5]);
                        }
                        else
                        {
                            mensaje = InsertarOtroAsegurado(tabla[i],ter_Id,par_Id,prod_Id,temp[10],temp[3],temp[18],sexo);
                            row["OtroAsegurado"] =row["OtroAsegurado"] + mensaje+"</br>";
                        }
                    }
                    else
                    {
                        if(tabla[i][0] == "4")
                        {
                            if (tabla[i][3] != "DE LEY" && tabla[i][4] != "LOS")
                            {
                                mensaje = InsertarBeneficiario(tabla[i], ter_Id, prod_Id, int.Parse(par_Id), temp[10], temp[3]);
                                row["Beneficiarios"] = row["Beneficiarios"] + mensaje + "</br>";
                            }
                        }
                    }
                }
            }
        }
        row["Amparos"] = "Amparos Insertados: " + sumaAmparosInsertados.ToString() + "</br>" + "Amparos Existentes: " + sumaAmparosYaEstan.ToString() + "</br>" + "Amparos No Insertados: " + sumaAmparosNo.ToString() + "</br>";
        dtResumen.Rows.Add(row);
        row = dtResumen.NewRow();
        return dtResumen;
    }

    //Funcion para guardar tercero en la base de datos
    #region INSERTAR ASEGURADO
    public static string InsertarAsegurado(string[] vector)
     {
         DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
         string mensaje = "";

         //Se toman los datos del archivo plano
         Acedula = vector[1].ToString();
         Aperentesco = (vector[2].ToString() == string.Empty) ? 0 : int.Parse(vector[2].ToString());
         AtipoDocumento = ConversionTipoDocumento(vector[3].ToString());
         Asexo = ConversionSexo(vector[4].ToString());
         Aapellidos = vector[5].ToString();
         Anombre = vector[6].ToString();
         AestadoCivil = ConversionEstadoCivil(vector[7].ToString());
         AfechaNacimiento = (vector[8] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[8].ToString());
         Adepartamento = (vector[10] == string.Empty) ? 0 : int.Parse(vector[10].ToString());
         Aciudad = (vector[9] == string.Empty) ? 0 : int.Parse(vector[9].ToString());
         Adireccion = vector[11].ToString();
         AtelefonoResidencia = vector[12].ToString();
         AtelefonoOficina = vector[13].ToString();
         Acelular = vector[14].ToString();
         Acorreo = vector[15].ToString();

         //Se consulta si el tercero ya existe en la base de datos
         DataTable dtTercero = objAdministrarCertificado.sp_ConsultarNewTerceroPorTerId(Acedula);

         //Se consulta el departamento y la ciudad
         DataTable dtDepartamento = new DataTable();
         if(Adepartamento != 0 && Aciudad !=0 )
         {
             dtDepartamento = objAdministrarCertificado.sp_ConsultarDepartamentoCiudad(Aciudad);
             if(dtDepartamento.Rows.Count > 0)
             {
                Adepartamento = int.Parse(dtDepartamento.Rows[0]["dep_Id"].ToString());
                Aciudad = int.Parse(dtDepartamento.Rows[0]["ciu_Id"].ToString());
             }
             else
             {
                 Adepartamento = 8;
                 Aciudad = 337;
             }
         }
         else
         {
             Adepartamento = 8;
             Aciudad = 337;
         }

         /*Si existe se actualiza el usuario, 
           sino esxiste se comprueba que esten los datos obligatorios si estan se inserta el tercero
           sino se informa que faltan datos*/

         if(dtTercero.Rows.Count > 0)
         {
             int registros = objAdministrarCertificado.sp_ActualizarNewTerceroPorTerId(Acedula, Aperentesco, AtipoDocumento, Asexo, Aapellidos,
                                                                                   Anombre,AestadoCivil,AfechaNacimiento,Adepartamento,
                                                                                   Aciudad,Adireccion,AtelefonoResidencia,AtelefonoOficina,
                                                                                   Acelular,Acorreo,dtTercero);

             mensaje = (registros > 0) ? "SE ACTUALIZO TERCERO" + Acedula : "NO SE PUDO ACTUALIZAR" + Acedula;

         }
         else
         {
             if(Acedula == string.Empty || AtipoDocumento == 0  )
             {
                 mensaje = "FALTA INFORMACION PARA INSERTAR TERCERO" + Acedula;
             }
                 else
                 {
                     int registros = objAdministrarCertificado.sp_InsertarNewTercero(Acedula, Aperentesco, AtipoDocumento, Asexo, Aapellidos,
                                                                                    Anombre, AestadoCivil, AfechaNacimiento, Adepartamento,
                                                                                    Aciudad, Adireccion, AtelefonoResidencia, AtelefonoOficina,
                                                                                    Acelular, Acorreo,6);

                     mensaje = (registros > 0) ? "SE INSERTO TERCERO" + Acedula : "NO SE PUDO INSERTAR" + Acedula;
                }
         }
                
         return mensaje;
     }
    #endregion

    //Inserta el certificado
    #region INSERTAR CERTIFICADO
    public static string InsertarCertificado(string[] vector)
    {
         DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();  
         string mensaje = "";

         Cagencia = (vector[1] == string.Empty)? 0 : int.Parse(vector[1].ToString());
         CtipoDocumento = ConversionTipoDocumento(vector[2].ToString());
         CcedulaAsegurado = vector[3].ToString();
         CfechaExpedicion = (vector[4] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[4].ToString());
         CfechaProduccion = (CfechaExpedicion.Day < 21 ) ? CfechaExpedicion :  CfechaExpedicion.AddMonths(1);
         CinicioVigencia = (vector[5] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[5].ToString());
         CcodigoAsesor = (vector[6] == string.Empty)? 0 : int.Parse(vector[6].ToString());
         Ccompania = (vector[7] == string.Empty) ? 0 : int.Parse(vector[7].ToString());
         CcodigoProducto = (vector[8] == string.Empty ) ? 0 : int.Parse(vector[8].ToString());
         Cproducto = (vector[9] == string.Empty) ? 0 : int.Parse(vector[9].ToString());
         CnumeroPolizaCertificado = (vector[10] == string.Empty) ? vector[10].ToString() : vector[10].ToString();
         Canualidad = (vector[11] == string.Empty) ? 0 : int.Parse(vector[11].ToString());
         CnumeroEndoso = vector[12].ToString();
         CprimaCertificado = (vector[13] == string.Empty) ? 0 : double.Parse(vector[13].ToString());
         CfechaOrigenAsegurado = (vector[14] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[14].ToString());
         CfechaVencimiento = (vector[15] == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(vector[15].ToString());
         CnitPlantelEducativo = vector[16].ToString();
         CnombrePlantel = vector[17].ToString();
         CpolizaGR = vector[18].ToString();
         CcodigoPagaduria = vector[19].ToString();
         CnombrePagaduria = vector[20].ToString();

         //Consulta asesor por el codigo ase_Codigo
         DataTable dtAsesor = objAdministrarCertificado.sp_ConsultarNewAsesorPorCodigo(CcodigoAsesor);

         //Consulta poliza por el numero pol_numero
         DataTable dtPoliza = objAdministrarCertificado.sp_ConsultarNewPolizaPorGR(CpolizaGR);

        //Consulta plantel por nombre
         DataTable dtPlantel = new DataTable();
         if(CnombrePlantel != string.Empty)
         {
             dtPlantel = objAdministrarCertificado.sp_ConsultarPlantel(CnombrePlantel); 
         }   

         //Consulta certificado por tercero y producto AQUI VOY
         DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(CcedulaAsegurado, Cproducto, CnumeroPolizaCertificado);

         //Consulta la agencia por la poliza GR
         DataTable dtAgencia = objAdministrarCertificado.sp_ConsultarAgenciaPorGR(CpolizaGR);

        //Consulta la Localidad por la poliza GR
         DataTable dtLocalidad = objAdministrarCertificado.sp_ConsultarLocalidadPorGR(CpolizaGR);

         //Consulta la pagaduria por el codigo
         DataTable dtPagaduria = new DataTable();
         if(CcodigoPagaduria != string.Empty)
         {
             dtPagaduria = objAdministrarCertificado.sp_ConsultarPagaduriaIdentificacion(CcodigoPagaduria);
         }

         //Consulta convenio por pagaduria y nombre
         DataTable dtConvenio = new DataTable();

         if (dtCertificado.Rows.Count > 0)
         {
             mensaje = "EL CERTIFICADO YA EXISTE";
         }
         else
         {
             if (dtPoliza.Rows.Count <= 0)
             {
                 mensaje = "LA POLIZA NO EXISTE";
             }
             else
             {
                    FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
                    FrameworkEntidades.cnx.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarNewCertificadoSimple", FrameworkEntidades.cnx);
                    cmd.Parameters.Add(new SqlParameter("@age_Id", dtAgencia.Rows[0]["age_Id"]));
                    cmd.Parameters.Add(new SqlParameter("@ter_Id", CcedulaAsegurado));
                    cmd.Parameters.Add(new SqlParameter("@cer_FechaExpedicion", CfechaExpedicion));
                    cmd.Parameters.Add(new SqlParameter("@cer_VigenciaDesde", CinicioVigencia));
                    if (dtAsesor.Rows.Count > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ase_Id", dtAsesor.Rows[0]["ase_Id"]));                        
                    }
                    else
                    {
                        objAdministrarCertificado.sp_InsertarAsesor(CcodigoAsesor, "PENDIENTE", "X ASIGNAR", dtLocalidad.Rows[0]["dep_Id"].ToString(), 1, "SI", "NO");
                        dtAsesor = objAdministrarCertificado.sp_ConsultarNewAsesorPorCodigo(CcodigoAsesor);
                        cmd.Parameters.Add(new SqlParameter("@ase_Id", dtAsesor.Rows[0]["ase_Id"]));
                    }
                    if(dtPagaduria.Rows.Count > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@paga_Id", dtPagaduria.Rows[0]["paga_Id"]));
                        dtConvenio = objAdministrarCertificado.sp_ConsultarConvenioPagaduria(dtPagaduria.Rows[0]["paga_Id"].ToString(), Cproducto);

                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@paga_Id", pagaduriaTemp));
                    }
                    cmd.Parameters.Add(new SqlParameter("@cer_FechaRecibido", DateTime.Today));
                    //cmd.Parameters.Add(new SqlParameter("@cer_PlanillaBolivar", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@com_Id", compania));
                    cmd.Parameters.Add(new SqlParameter("@pro_Id", Cproducto));
                    cmd.Parameters.Add(new SqlParameter("@cer_SoporteFisico", soporteFisico));
                    //cmd.Parameters.Add(new SqlParameter("@cer_AnexoConversion", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@casesp_Id", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio1", CnumeroEndoso));
                    //cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio2", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_HojaServicio3", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@estcar_Id", estadoCargue));
                    //cmd.Parameters.Add(new SqlParameter("@cer_NumeroFolios", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_PrimaTotal", CprimaCertificado));
                    cmd.Parameters.Add(new SqlParameter("@tipdev_Id", tipdev_Id));
                    cmd.Parameters.Add(new SqlParameter("@caudev_Id", caudev_Id));
                    //cmd.Parameters.Add(new SqlParameter("@cer_Observaciones", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_Consecutivo", consecutivo));
                    cmd.Parameters.Add(new SqlParameter("@cer_Certificado", CnumeroPolizaCertificado));
                    //cmd.Parameters.Add(new SqlParameter("@conyuge", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_AnoProduccion", CfechaProduccion.Year));
                    //cmd.Parameters.Add(new SqlParameter("@cer_CausalConyuge", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_CausalRetiro", DBNull.Value));

                    if(dtConvenio.Rows.Count > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", dtConvenio.Rows[0]["con_Id"] ));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@cer_Convenio", convenioTemp));
                    }
                    //cmd.Parameters.Add(new SqlParameter("@cer_Declaracion", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_DeclaracionEnfe", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_EstadoCartera", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_EstadoDescuento", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@cer_EstadoNegocio", estadoNegocio));
                    //cmd.Parameters.Add(new SqlParameter("@cer_EstadoSalud", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_EstaturaConyuge", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_EstaturaPrincipal", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@cer_Extr", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@IdConyuge", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@Jubilado", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Localidad", dtLocalidad.Rows[0]["dep_Id"]));
                    cmd.Parameters.Add(new SqlParameter("@MesProduccion", CfechaProduccion.Month));
                    DateTimeFormatInfo temMesLetras = new CultureInfo("es-ES", false).DateTimeFormat;
                    cmd.Parameters.Add(new SqlParameter("@MesProduccionLetras", temMesLetras.GetMonthName(CfechaProduccion.Month).ToUpper()));
                    //cmd.Parameters.Add(new SqlParameter("@Movimiento", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@PesoConyuge", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@PesoPrincipal", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@TasaExt", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@Tipo", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", 1));
                    //cmd.Parameters.Add(new SqlParameter("@InicioVigenciaAnterior", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@ValorTotalAnterior", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@VigenciaHasta", CinicioVigencia.AddYears(1)));
                    //cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroConyuge", DBNull.Value));
                    //cmd.Parameters.Add(new SqlParameter("@VigenciaRetiroPrincipal", DBNull.Value));

                    //plantel
                    if (dtPlantel.Rows.Count > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@pla_Id", dtPlantel.Rows[0]["pla_Id"]));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@pla_Id", plantelTemp ));
                    }

                    cmd.Parameters.Add(new SqlParameter("@pol_Id", dtPoliza.Rows[0]["pol_Id"]));
                    cmd.Parameters.Add(new SqlParameter("@mom_Id", momento));
                    cmd.Parameters.Add(new SqlParameter("@casesp_Id", casosEspeciales));
                    cmd.Parameters.Add(new SqlParameter("@cer_FechaDigitacion", DateTime.Today));
                    cmd.Parameters.Add(new SqlParameter("@perPag_Id", periodoPago));
                    cmd.Parameters.Add(new SqlParameter("@cer_Migracion", cer_Migracion));
                    cmd.Parameters.Add(new SqlParameter("@user", DBNull.Value));
                    cmd.CommandType = CommandType.StoredProcedure;
                    int filas = cmd.ExecuteNonQuery();

                    FrameworkEntidades.cnx.Close();

                    mensaje = "SE INSERTO EL CERTIFICADO";
                }
             }
         sumaTodos += 1;

         return mensaje;
    }
    #endregion

    //Inserta amparo
    # region INSERTAR AMPARO
    public static int InsertarAmparo(string[] vector, string ter_Id, string par_Id, int pro_Id, string cer_Certificado,string terPrincipal)
    {
        int mensaje;
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        AmpCodigo =  ConversionCodigoAmparo(vector[1].ToString());
        AmpNombre = vector[2];
        AmpValorAsegurado = (vector[3] == string.Empty)? 0 : double.Parse(vector[3].ToString());
        string temp;
        if (vector[4].ToString() == string.Empty)
            temp = "0";
        else
            temp = vector[4].ToString();
        AmpTasa = double.Parse(temp.Replace(".","") );
        //AmpTasa = AmpTasa / 12;
        //AmpTasa = (vector[4].ToString() == string.Empty) ? 0 : double.Parse(vector[4].ToString());
        AmpPrima = (vector[5] == string.Empty)? 0 : double.Parse(vector[5].ToString());
        //AmpPrima = AmpPrima / 12;

        //Consulta  NewCertificado por el ter_Id
        DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(terPrincipal, pro_Id, cer_Certificado);

        //Consulta  Amparos del certificado
        DataTable dtAmparo = new DataTable();
         
        if(dtCertificado.Rows.Count > 0)
        {
            dtAmparo = objAdministrarCertificado.sp_ConsultarAmparos(dtCertificado.Rows[0]["cer_Id"].ToString(), ter_Id, par_Id, AmpCodigo);
            if(dtAmparo.Rows.Count > 0) 
            {
                mensaje = 2;   
            }
            else
            {
                objAdministrarCertificado.sp_InsertarAmparosCertificado(dtCertificado.Rows[0]["cer_Id"].ToString(), ter_Id, par_Id, AmpNombre, AmpValorAsegurado,
                                                                    AmpPrima, AmpTasa, AmpCodigo);
                mensaje = 1;
                if(AmpCodigo == 1)
                {
                    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
                    objAdministrarCertificados.CrearExtraPrima(int.Parse(dtCertificado.Rows[0]["cer_Id"].ToString()),int.Parse(dtCertificado.Rows[0]["cer_Id"].ToString()),AmpValorAsegurado,0,double.Parse(dtCertificado.Rows[0]["cer_PrimaTotal"].ToString()),1);
                }
            } 
        }
        else
        {
            mensaje = 0;
        }
               
        return mensaje;
    }
    #endregion

    //Inserta un beneficiario
    #region INSERTA BENEFICIARIO
    public static string InsertarBeneficiario(string[] vector, string ter_Id, int prod_Id, int par_Id, string cer_Certificado, string terPrincipal)
    {
        string mensaje = "";
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        BtipoDocumento = ConversionTipoDocumento(vector[1]);
        Bdocumento = vector[2].ToString() ;
        Bapellidos = vector[3];
        Bnombres = vector[4];
        Bedad = (vector[5] == string.Empty)? 0 : int.Parse(vector[5]);
        Bporcentaje = double.Parse(vector[6]);
        Bparentesco = vector[7];

        if (vector[8] == "1" || vector[8] == "2")
            BidParentesco = 2;
        else
            if (vector[8] == "3")
                BidParentesco = 3;
            else
                if(vector[8] == "4")
                    BidParentesco = 5;
                else
                    BidParentesco = 17;

        //Consulta  NewCertificado por el ter_Id
        DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(terPrincipal, prod_Id, cer_Certificado);

        //Consulta un beneficiario
        DataTable dtBeneficiario = objAdministrarCertificado.sp_ConsultarAmparosSuma(dtCertificado.Rows[0]["cer_Id"].ToString(), ter_Id);

        double suma = 0;

        if (dtCertificado.Rows.Count > 0)
        {
            suma = (dtBeneficiario.Rows[0]["sumaPorcentajes"].ToString() == string.Empty) ? 0 : double.Parse(dtBeneficiario.Rows[0]["sumaPorcentajes"].ToString());
            if ((suma + Bporcentaje) <= 100)
            {
                objAdministrarCertificado.sp_InsertarBeneficiario(Bdocumento, Bapellidos, Bnombres, Bedad, Bporcentaje, Bparentesco, dtCertificado.Rows[0]["cer_Id"].ToString(),
                                                               ter_Id, par_Id);
                mensaje = "SI " + Bnombres;
            }
            else
            {
                mensaje = "NO " + Bnombres;
            }  
        }
        else
        {
            mensaje = "NO "+ Bnombres;
        }
        return mensaje;
    }
    #endregion

    //Inserta otro asegurado
    #region INSERTA OTROASEGURADO
    public static string InsertarOtroAsegurado(string[] vector, string ter_Id,string par_Id,int prod_Id,string cer_Certificado,string terPrincipal,string polizaGR, string sexo)
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        string mensaje = "";

        AmpCodigo = ConversionCodigoAmparo(vector[1].ToString());
        AmpNombre = vector[2];
        AmpValorAsegurado = (vector[3] == string.Empty) ? 0 : double.Parse(vector[3].ToString());
        string temp;
        if (vector[4].ToString() == string.Empty)
            temp = "0";
        else
            temp = vector[4].ToString();
        AmpTasa = double.Parse(temp.Replace(".", ""));
        //AmpTasa = AmpTasa / 12;
        //AmpTasa = (vector[4].ToString() == string.Empty) ? 0 : double.Parse(vector[4].ToString());
        AmpPrima = (vector[5] == string.Empty) ? 0 : double.Parse(vector[5].ToString());
        //AmpPrima = AmpPrima / 12;

        //Consulta  NewCertificado por el ter_Id
        DataTable dtCertificado = objAdministrarCertificado.sp_ConsultarNewCertificadoPorTerceroProducto(terPrincipal, prod_Id, cer_Certificado);

        //Consulta  Amparos del certificado
        DataTable dtPlanPoliza = new DataTable();

        //Consulta  otro asegurado
        DataTable dtOtroAsegurado = new DataTable();

        if (dtCertificado.Rows.Count > 0)
        {
            dtPlanPoliza = objAdministrarCertificado.sp_ConsultarPlanPoliza(polizaGR, ter_Id, AmpValorAsegurado, sexo,DateTime.Today);

            dtOtroAsegurado = objAdministrarCertificado.sp_ConsultarOtroAsegurado(dtCertificado.Rows[0]["cer_Id"].ToString(), ter_Id);
            
            if(dtPlanPoliza.Rows.Count > 0)
            {
                if (dtOtroAsegurado.Rows.Count > 0)
                {
                    mensaje = "YA EXISTE EL OTRO ASEGURADO";
                }
                else
                {
                    int registros = objAdministrarCertificado.sp_InsertarOtroAseguradoSimple(dtCertificado.Rows[0]["cer_Id"].ToString(), ter_Id, par_Id, dtPlanPoliza, AmpPrima);
                    objAdministrarCertificado.sp_ActualizarTipoMovimiento3(dtCertificado.Rows[0]["cer_Id"].ToString(), 63);
                    mensaje = "SE INSERTO OTRO ASEGURADO";
                }
            }
            else
            {
                mensaje = "NO EXISTE EL PLAN POLIZA";
            }
            
        }
        else
        {
            mensaje = "NO EXISTE EL CERTIFICADOA";
        }

        return mensaje;
    }
    #endregion

    //Actualiza los datos del conyuge en el certificado
    #region ACTUALIZA CONYUGE
    public static string ActualizarConyuge(string cer_Certificado, string IdConyuge)
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        string mensaje = "";

        int registros = objAdministrarCertificado.sp_ActualizarNewCertificadoDatosConyuge(cer_Certificado, IdConyuge);

        if (registros > 0)
            mensaje = "SE ACTUALIZO CONYUGE";
        else
            mensaje = "NO SE ACTUALIZO CONYUGE";


        return mensaje;
    }
    #endregion

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