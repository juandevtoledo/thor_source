using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_AsignacionPagaduria : System.Web.UI.Page
{
    //Declaracion de variables utilizadas
    DataTable dtLocalidades = new DataTable();
    DataTable dtPagaduria = new DataTable();
    DataTable dtConvenio = new DataTable();
    DataTable dtCertificados = new DataTable();
    DataTable dtCertificado = new DataTable();
    DataTable dtProducto = new DataTable();
    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    public  List<string> listCertificados = new List<string>();
    string cer_Id = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }

        if (!IsPostBack)
        {
            //Carga los certificados que no tienen asignada una pagaduria
            grvCertificados_Cargar();
            
            //Carga localidades
            dtLocalidades = AdministrarDevolucionDePrima.ConsultarLocalidades();
            ddlLocalidad.DataTextField = "dep_Nombre";
            ddlLocalidad.DataValueField = "dep_Id";
            ddlLocalidad.DataSource = dtLocalidades;
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("", ""));

            //Carga productos
            dtProducto = objPrecargueProduccion.ProductoPorCompaniaPrecargue(1);
            ddlProducto.DataTextField = "pro_Nombre";
            ddlProducto.DataValueField = "pro_Id";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("", ""));

            ddlPagaduria.Enabled = false;
            ddlConvenio.Enabled = false;
            btnAsignar.Enabled = false;

            divPagaduria.Visible = false;
        }

    }

    //Carga las pagadurias cuando selecciona una localidad
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvCertificados_Cargar();
        if (ddlLocalidad.SelectedValue.ToString() != "")
        {
            dtPagaduria = objAdministrarCertificados.ConsultarPagaduriaPorLocalidad(int.Parse(ddlLocalidad.SelectedValue.ToString()));
            ddlPagaduria.DataValueField = "paga_Id";
            ddlPagaduria.DataTextField = "paga_Nombre";
            ddlPagaduria.DataSource = dtPagaduria;
            ddlPagaduria.DataBind();
            ddlPagaduria.Items.Insert(0, new ListItem("", ""));

            if (ddlProducto.SelectedValue.ToString() != "")
            {
                ddlPagaduria.Enabled = true;
                if (dtCertificados.Rows.Count != 0)
                {
                    divPagaduria.Visible = true;
                }
            }
        }
        else
        {
            ddlPagaduria.Enabled = false;
            ddlConvenio.Enabled = false;
            divPagaduria.Visible = false;
        }
    }

    //Cuando se selecciona un producto se habilita la seccion de pagaduria
    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvCertificados_Cargar();
        if (ddlProducto.SelectedValue.ToString() != "")
        {
            if (ddlLocalidad.SelectedValue.ToString() != "")
            {
                ddlPagaduria.Enabled = true;

                if(dtCertificados.Rows.Count != 0)
                {
                    divPagaduria.Visible = true;
                } 
            }  
        }
        else
        {
            ddlPagaduria.Enabled = false;
            ddlConvenio.Enabled = false;
            divPagaduria.Visible = false;
        }
    }

    //Carga los convenios cuando selecciona una pagaduria
    protected void ddlPagaduria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPagaduria.SelectedValue.ToString() != "")
        {
            int producto = (ddlProducto.SelectedValue.ToString() != "")? int.Parse(ddlProducto.SelectedValue.ToString()) : 1 ;
            dtConvenio = objAdministrarCertificados.consultarConvenios(producto, int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlPagaduria.SelectedValue.ToString()));
            ddlConvenio.DataTextField = "con_Nombre";
            ddlConvenio.DataValueField = "con_Id";
            ddlConvenio.DataSource = dtConvenio;
            ddlConvenio.DataBind();
            ddlConvenio.Items.Insert(0, new ListItem("", ""));

            ddlConvenio.Enabled = true;
        }
        else
        {
            ddlConvenio.Enabled = false;
        }
    }

    protected void ddlConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPagaduria.SelectedValue.ToString() != "" && ddlConvenio.SelectedValue.ToString() != "")
        {
            btnAsignar.Enabled = true;
        }
    }

    //Carga los certificados que no tienen asiganada una pagaduria
    protected void grvCertificados_Cargar()
    {
        int localidad = (ddlLocalidad.SelectedValue.ToString() != "") ? int.Parse(ddlLocalidad.SelectedValue.ToString()) : 0;
        int producto = (ddlProducto.SelectedValue.ToString() != "") ? int.Parse(ddlProducto.SelectedValue.ToString()) : 0;
        dtCertificados = objAdministrarCertificados.ConsultarCertificadosSinPagaduria(localidad,producto);
        grvCertificados.DataSource = dtCertificados;
        grvCertificados.DataBind();
    }

    //Se asigna la pagaduria seleccionada al certificado
    //Se crea la novedad del certificado
    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        if (ddlPagaduria.SelectedValue.ToString() != "" && ddlConvenio.SelectedValue.ToString() != "" && listCertificados.Count != 0)
        {
            //Recorrer el GridView para identificar las filas que fueron seleccionadas
            foreach (string Id in listCertificados)
            {
                objAdministrarCertificados.ActualizarNewCertificadoPagaduria(Id, int.Parse(ddlPagaduria.SelectedValue.ToString()), int.Parse(ddlConvenio.SelectedValue.ToString()));

                DAOAdministrarCertificado objDAOAdministrarCertificados = new DAOAdministrarCertificado();

                dtCertificado = objDAOAdministrarCertificados.spConsultarCertificado(double.Parse(Id));

                Session["dtEncabezadoCertificado"] = dtCertificado;

                if(dtCertificado.Rows.Count != 0)
                {
                    DataTable dtNovedades = new DataTable();

                    DataColumn columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "producto";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "tercero";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "certificado";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "convenio";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "mes";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "anio";
                    dtNovedades.Columns.Add(columns);

                    columns = new DataColumn();
                    columns.DataType = System.Type.GetType("System.String");
                    columns.AllowDBNull = true;
                    columns.ColumnName = "prima";
                    dtNovedades.Columns.Add(columns);

                    DataRow producto = dtNovedades.NewRow();
                    producto["producto"] = ddlProducto.SelectedValue.ToString();
                    producto["tercero"] = dtCertificado.Rows[0]["ter_Id"].ToString();
                    producto["certificado"] = Id;
                    producto["convenio"] = ddlConvenio.SelectedValue.ToString();
                    producto["mes"] = dtCertificado.Rows[0]["MesProduccion"].ToString();
                    producto["anio"] = dtCertificado.Rows[0]["cer_AnoProduccion"].ToString();
                    producto["prima"] = dtCertificado.Rows[0]["cer_PrimaTotal"].ToString();
                    dtNovedades.Rows.Add(producto);

                    DataTable dtArchivo = new DataTable();
                    dtArchivo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtNovedades.Rows[0]["producto"].ToString()), int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));

                    DataTable dtArchivoPagaduria = new DataTable();
                    dtArchivoPagaduria = objAdministrarCertificados.ConsultarArchivoPagaduriaPorId(int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()));

                    Session["dtArchivo"] = dtArchivo;

                    DataTable dtPeriodicidad = new DataTable();
                    dtPeriodicidad = objAdministrarCertificados.ConsultarPeriodicidadPorConvenio(int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));

                    double primaCertificado = 0;
                    primaCertificado = double.Parse(dtNovedades.Rows[0]["prima"].ToString());

                    Session["dtNovedades"] = dtNovedades;

                    int periodicidad = 0;
                    periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

                    double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);

                    CalcularNovedades(dtPeriodicidad, dtArchivoPagaduria,ddlPagaduria.SelectedItem.Text);
                }   
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Debe seleccionar" + "');", true);
        }
        grvCertificados_Cargar();
    }

    //Guarda los certificados seleccionados
    protected void chkSeleccionar_OnCheckedChanged(object sender, EventArgs e)
    {
        listCertificados = new List<string>();

        foreach (GridViewRow row in grvCertificados.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionar") as CheckBox;
            //Solo se ingresa aca cuando la fila que se recorre esta seleccionada
            if (check.Checked)
            {
                //Almacenar el id del pago de las filas seleccionadas
                cer_Id = row.Cells[1].Text.ToString();
                listCertificados.Add(cer_Id);
            }
        }
    }

    //Calcula el valor de la novedad del certificado
    protected  double CalcularValorNovedadCertificado(double primaCertificado, int periodicidad)
    {
        double valorTotal = 0;
        if (periodicidad == 10)
        {
            valorTotal = primaCertificado * 6;
        }
        if (periodicidad == 14)
        {
            valorTotal = primaCertificado * 12;
        }
        else
        {
            valorTotal = primaCertificado;
        }
        return valorTotal;
    }

    //protected void CalcularNovedades(DataTable dtPeriodicidad, DataTable dtArchivoPagaduria, string pagaduriaAsignar)
    //{
    //    DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
    //    AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
    //    DataTable dtArchivo = (DataTable)Session["dtArchivo"];
    //    DataTable dtNovedades = (DataTable)Session["dtNovedades"];
    //    //////////////////////////////Inicia operaciones para novedades///////////////////////////////////////////// 
    //    DataTable dtNovedadActual = new DataTable();
    //    dtNovedadActual = objAdministrarCertificados.ConsultarNovedadActual(int.Parse(dtNovedades.Rows[0]["tercero"].ToString()), int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()), 0);

    //    if (dtNovedadActual.Rows.Count > 0)
    //    {
    //        if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
    //        {
    //            if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R")
    //            {
    //                dtNovedadActual.Clear();
    //            }
    //        }
    //        if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
    //        {
    //            if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() != "R")
    //            {
    //                dtNovedadActual.Rows.RemoveAt(0);
    //            }
    //            if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() == "R")
    //            {
    //                dtNovedadActual.Clear();
    //            }
    //        }
    //    }
    //    int cedula = 0;
    //    string tipoNovedad = "";
    //    string tipoNovedad2 = "";
    //    double valor2 = 0;
    //    double valor = 0;
    //    int estado = 0;
    //    int pagaduria = 0;
    //    int convenio = 0;
    //    int archivo = 0;
    //    int enviada = 0;
    //    double novedadAnterior = 0;

    //    cedula = int.Parse(dtNovedades.Rows[0]["tercero"].ToString());
    //    convenio = int.Parse(dtNovedades.Rows[0]["convenio"].ToString());
    //    pagaduria = int.Parse(objAdministrarCertificados.consultarConvenioPorPagaduria(double.Parse(dtEncabezadoCertificado.Rows[0]["cer_Id"].ToString())).Rows[0]["paga_Id"].ToString());
    //    archivo = int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString());
    //    estado = 1;
    //    enviada = 0;

    //    /////////////////////////////// Variables para calcular el valor que se debe enviar a la novedad ///////////////
    //    double primaCertificado = 0;
    //    primaCertificado = int.Parse(dtNovedades.Rows[0]["prima"].ToString());

    //    int periodicidad = 0;
    //    periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

    //    double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);
    //    ///////////////////////////////FINALIZA Variables para calcular el valor que se debe enviar a la novedad ///////////////

    //    if (dtNovedadActual.Rows.Count == 0)
    //    {
    //        tipoNovedad = "I";
    //        ///////////////////////Cuando esta persona no tiene novedad anterior /////////////////////
    //        if (tipoNovedad == "I")
    //        {
    //            tipoNovedad = "I";

    //            valor = valorTotal;
    //        }
    //        /////////////////////  FINALIZA Cuando esta persona no tiene novedad anterior/////////////////////////
    //    }
    //    else
    //    {
    //        novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString());
    //        //////////////////////// cuando es ingreso, modificacion y retiro ////////////////////////////////
    //        if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
    //        {
    //            //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
    //            if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
    //            {
    //                valor = valorTotal + novedadAnterior;
    //            }
    //            ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////

    //            //////////////////////// cuando la novedad actual ya esta enviada ////////////////////////////////

    //            if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
    //            {
    //                tipoNovedad = "M";

    //                //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
    //                if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
    //                {
    //                    valor = valorTotal;
    //                }
    //                ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

    //                ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
    //                if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
    //                {
    //                    valor = valorTotal - novedadAnterior;
    //                }
    //                /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
    //            }
    //            ////////////////////////FINALIZA cuando la novedad actual ya esta enviada ////////////////////////////////
    //        }
    //        ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////

    //        //////////////////////// cuando es ingreso y retiro ////////////////////////////////
    //        if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
    //        {
    //            //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
    //            if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
    //            {
    //                valor = valorTotal + novedadAnterior;
    //            }
    //            ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
    //            if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
    //            {
    //                tipoNovedad = "I";
    //                valor = valorTotal + novedadAnterior;

    //                tipoNovedad2 = "R";
    //                valor2 = novedadAnterior;
    //            }
    //            ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
    //        }
    //        ////////////////////////FINALIZA cuando es ingreso y retiro ////////////////////////////////
    //    }
    //    //////////////////////////////Finaliza operaciones para novedades/////////////////////////////////////////////
    //    DataTable dtMesYAnio = CalcularMesYAnio();

    //    if (dtNovedadActual.Rows.Count > 0)
    //    {
    //        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0" || (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1" && dtNovedadActual.Rows[0]["Estado"].ToString() == "1"))
    //        {
    //            AdministrarNovedades.ActualizarNovedades(int.Parse(dtNovedadActual.Rows[0]["nov_Id"].ToString()), dtNovedadActual.Rows[0]["TipoNovedad"].ToString(), int.Parse(valor.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
    //        }
    //        else
    //        {
    //            if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1" && dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
    //            {
    //                AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));

    //                AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad2, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor2.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
    //            }
    //            if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
    //            {
    //                AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
    //            }
    //            if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "2")
    //            {

    //            }
    //        }
    //    }
    //    else
    //    {
    //        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
    //    }
    //}


    //Calcula la novedad del certificado
    protected void CalcularNovedades(DataTable dtPeriodicidad, DataTable dtArchivoPagaduria,string pagaduriaAsignar)
    {
        try
        {
            DataTable dtEncabezadoCertificado = (DataTable)Session["dtEncabezadoCertificado"];
            //AdministrarCertificados objAdministrarCertificados = new AdministrarCertificados();
            DataTable dtArchivo = (DataTable)Session["dtArchivo"];
            DataTable dtNovedades = (DataTable)Session["dtNovedades"];
            //////////////////////////////Inicia operaciones para novedades///////////////////////////////////////////// 
            DataTable dtNovedadActual = new DataTable();
            dtNovedadActual = objAdministrarCertificados.ConsultarNovedadActual(int.Parse(dtNovedades.Rows[0]["tercero"].ToString()), int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()), 0);

            if (dtNovedadActual.Rows.Count > 0)
            {
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                {
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R")
                    {
                        dtNovedadActual.Clear();
                    }
                }
                if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                {
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() != "R")
                    {
                        dtNovedadActual.Rows.RemoveAt(0);
                    }
                    if (dtNovedadActual.Rows[0]["TipoNovedad"].ToString() == "R" && dtNovedadActual.Rows[1]["TipoNovedad"].ToString() == "R")
                    {
                        dtNovedadActual.Clear();
                    }
                }
            }
            int cedula = 0;
            string tipoNovedad = "";
            string tipoNovedad2 = "";
            double valor2 = 0;
            double valor = 0;
            int estado = 0;
            int pagaduria = 0;
            int convenio = 0;
            int archivo = 0;
            int enviada = 0;
            double novedadAnterior = 0;

            cedula = int.Parse(dtNovedades.Rows[0]["tercero"].ToString());
            convenio = int.Parse(dtNovedades.Rows[0]["convenio"].ToString());
            pagaduria = int.Parse(objAdministrarCertificados.consultarConvenioPorPagaduria(double.Parse(Session["cerIdPagaduria"].ToString())).Rows[0]["paga_Id"].ToString());
            archivo = int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString());
            estado = 1;
            enviada = 0;

            /////////////////////////////// Variables para calcular el valor que se debe enviar a la novedad ///////////////
            double primaCertificado = 0;
            primaCertificado = int.Parse(dtNovedades.Rows[0]["prima"].ToString());

            int periodicidad = 0;
            periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

            double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);
            ///////////////////////////////FINALIZA Variables para calcular el valor que se debe enviar a la novedad ///////////////

            if (dtNovedadActual.Rows.Count == 0)
            {
                tipoNovedad = "I";
                ///////////////////////Cuando esta persona no tiene novedad anterior /////////////////////
                if (tipoNovedad == "I")
                {
                    tipoNovedad = "I";

                    valor = valorTotal;
                }
                /////////////////////  FINALIZA Cuando esta persona no tiene novedad anterior/////////////////////////
            }
            else
            {

                DataTable dtProducto = new DataTable();
                dtProducto = objAdministrarCertificados.ConsultarProductoParaNovedad(double.Parse(dtNovedades.Rows[0]["tercero"].ToString()), int.Parse(dtNovedades.Rows[0]["producto"].ToString()));
                if (int.Parse(dtProducto.Rows.Count.ToString()) == 0)
                {
                    novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString());
                    //valorTotal = valorTotal + novedadAnterior;
                    //////////////////////// cuando es ingreso, modificacion y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////

                        //////////////////////// cuando la novedad actual ya esta enviada ////////////////////////////////

                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "M";

                            //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
                            {
                                valor = valorTotal;
                            }
                            ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

                            ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
                            {
                                valor = valorTotal - novedadAnterior;
                            }
                            /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
                        }
                        ////////////////////////FINALIZA cuando la novedad actual ya esta enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////

                    //////////////////////// cuando es ingreso y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "I";
                            valor = valorTotal + novedadAnterior;

                            tipoNovedad2 = "R";
                            valor2 = novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso y retiro ////////////////////////////////
                }
                else
                {
                    novedadAnterior = int.Parse(dtNovedadActual.Rows[0]["Valor"].ToString()) - int.Parse(dtProducto.Rows[0]["Prima"].ToString());
                    //valorTotal = valorTotal + novedadAnterior;
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////

                        //////////////////////// cuando la novedad actual ya esta enviada ////////////////////////////////

                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "M";

                            //////////////////////// cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "0")
                            {
                                valor = valorTotal;
                            }
                            ////////////////////////FINALIZA cuando el valor que se desea ingresar es solo la novedad ////////////////////////////////

                            ///////////////// cuando el valor que se desea ingresar es la vovedad anterior mas la actual ////////////////////////
                            if (dtArchivoPagaduria.Rows[0]["arcpag_Valor"].ToString() == "1")
                            {
                                valor = valorTotal - novedadAnterior;
                            }
                            /////////////FINALIZA cuando el valor que se desea ingresar es la vovedad anterior mas la actual /////////////////
                        }
                        ////////////////////////FINALIZA cuando la novedad actual ya esta enviada ////////////////////////////////
                    }
                    ////////////////////////FINALIZA cuando es ingreso, modificacion y retiro ////////////////////////////////

                    //////////////////////// cuando es ingreso y retiro ////////////////////////////////
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1")
                    {
                        //////////////////////// cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0")
                        {
                            valor = valorTotal + novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                        if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                        {
                            tipoNovedad = "I";
                            valor = valorTotal + novedadAnterior;

                            tipoNovedad2 = "R";
                            valor2 = novedadAnterior;
                        }
                        ////////////////////////FINALIZA cuando la novedad aun no sido enviada ////////////////////////////////
                    }
                }
            }
            //////////////////////////////Finaliza operaciones para novedades/////////////////////////////////////////////
            DataTable dtMesYAnio = CalcularMesYAnio();

            if (dtNovedadActual.Rows.Count > 0)
            {
                if (dtNovedadActual.Rows[0]["Enviada"].ToString() == "0" || (dtNovedadActual.Rows[0]["Enviada"].ToString() == "1" && dtNovedadActual.Rows[0]["Estado"].ToString() == "1"))
                {
                    AdministrarNovedades.ActualizarNovedades(int.Parse(dtNovedadActual.Rows[0]["nov_Id"].ToString()), dtNovedadActual.Rows[0]["TipoNovedad"].ToString(), int.Parse(valor.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                }
                else
                {
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "1" && dtNovedadActual.Rows[0]["Enviada"].ToString() == "1")
                    {
                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));

                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad2, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor2.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                    }
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "0")
                    {
                        AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
                    }
                    if (dtArchivoPagaduria.Rows[0]["arcpag_TipoReporte"].ToString() == "2")
                    {

                    }
                }
            }
            else
            {
                AdministrarNovedades.InsertarNovedades(int.Parse(cedula.ToString()), tipoNovedad, int.Parse(estado.ToString()), int.Parse(pagaduria.ToString()), int.Parse(convenio.ToString()), int.Parse(archivo.ToString()), int.Parse(valor.ToString()), int.Parse(enviada.ToString()), int.Parse(dtMesYAnio.Rows[0]["mes"].ToString()), int.Parse(dtMesYAnio.Rows[0]["anio"].ToString()));
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + "SURGIO UN ERROR AL CALCULAR LA NOVEDAD" + "');", true);
        }
    }
    

    //Calcula el mes y año de la novedad
    protected DataTable CalcularMesYAnio()
    {
        int mesNovedad = 0;
        int anioNovedad = 0;

        DataTable dtNovedades = (DataTable)Session["dtNovedades"];

        mesNovedad = int.Parse(dtNovedades.Rows[0]["mes"].ToString()) + 1;
        anioNovedad = int.Parse(dtNovedades.Rows[0]["anio"].ToString());

        if (mesNovedad == 13)
        {
            anioNovedad = anioNovedad + 1;
            mesNovedad = 1;
        }

        DataTable dtArchivo = (DataTable)Session["dtArchivo"];

        DataTable dtMesYAnioNovedades = new DataTable();
        dtMesYAnioNovedades = AdministrarNovedades.ConsultarMesYAnioNovedad(mesNovedad, anioNovedad, int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()));

        if (dtMesYAnioNovedades.Rows.Count > 0)
        {
            if (dtMesYAnioNovedades.Rows[0]["enviada"].ToString() == "1")
            {
                mesNovedad = mesNovedad + 1;
                if (mesNovedad == 13)
                {
                    anioNovedad = anioNovedad + 1;
                    mesNovedad = 1;
                }
            }
        }

        DataTable dtMesYAnio = new DataTable();

        DataColumn columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "mes";
        dtMesYAnio.Columns.Add(columns);

        columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "anio";
        dtMesYAnio.Columns.Add(columns);

        DataRow fecha = dtMesYAnio.NewRow();

        fecha["mes"] = mesNovedad;
        fecha["anio"] = anioNovedad;
        dtMesYAnio.Rows.Add(fecha);

        return dtMesYAnio;
    }

    //Confirma la pagaduria con que venia el certificado
    protected void grvCertificados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow row = grvCertificados.Rows[(index)];

        if (e.CommandName == "confirmar_Click")
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('ALERTA');", true);

            string Id = row.Cells[1].Text;
            string pagaduriaAsignar = row.Cells[7].Text;
            int pagaduria = int.Parse(row.Cells[6].Text);
            int convenio = int.Parse(row.Cells[8].Text);

            objAdministrarCertificados.ActualizarNewCertificadoPagaduria(Id, pagaduria, convenio);

            DAOAdministrarCertificado objDAOAdministrarCertificados = new DAOAdministrarCertificado();

            dtCertificado = objDAOAdministrarCertificados.spConsultarCertificado(double.Parse(Id));

            Session["dtEncabezadoCertificado"] = dtCertificado;

            if (dtCertificado.Rows.Count != 0)
            {
                DataTable dtNovedades = new DataTable();

                DataColumn columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "producto";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "tercero";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "certificado";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "convenio";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "mes";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "anio";
                dtNovedades.Columns.Add(columns);

                columns = new DataColumn();
                columns.DataType = System.Type.GetType("System.String");
                columns.AllowDBNull = true;
                columns.ColumnName = "prima";
                dtNovedades.Columns.Add(columns);

                DataRow producto = dtNovedades.NewRow();
                producto["producto"] = dtCertificado.Rows[0]["pro_Id"].ToString();
                producto["tercero"] = dtCertificado.Rows[0]["ter_Id"].ToString();
                producto["certificado"] = Id;
                producto["convenio"] = convenio;
                producto["mes"] = dtCertificado.Rows[0]["MesProduccion"].ToString();
                producto["anio"] = dtCertificado.Rows[0]["cer_AnoProduccion"].ToString();
                producto["prima"] = dtCertificado.Rows[0]["cer_PrimaTotal"].ToString();
                dtNovedades.Rows.Add(producto);

                DataTable dtArchivo = new DataTable();
                dtArchivo = objAdministrarCertificados.ConsultarIdArchivo(int.Parse(dtNovedades.Rows[0]["producto"].ToString()), int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));

                DataTable dtArchivoPagaduria = new DataTable();
                dtArchivoPagaduria = objAdministrarCertificados.ConsultarArchivoPagaduriaPorId(int.Parse(dtArchivo.Rows[0]["arcpag_Id"].ToString()));

                Session["dtArchivo"] = dtArchivo;

                DataTable dtPeriodicidad = new DataTable();
                dtPeriodicidad = objAdministrarCertificados.ConsultarPeriodicidadPorConvenio(int.Parse(dtNovedades.Rows[0]["convenio"].ToString()));

                double primaCertificado = 0;
                primaCertificado = double.Parse(dtNovedades.Rows[0]["prima"].ToString());

                Session["dtNovedades"] = dtNovedades;

                int periodicidad = 0;
                periodicidad = int.Parse(dtPeriodicidad.Rows[0]["con_PeriodicidadPago"].ToString());

                double valorTotal = CalcularValorNovedadCertificado(primaCertificado, periodicidad);

                CalcularNovedades(dtPeriodicidad, dtArchivoPagaduria,pagaduriaAsignar);
            }
            grvCertificados_Cargar();
        }
    }

    protected void grvCertificados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dtBound = (DataTable)grvCertificados.DataSource;
            string var = dtBound.Rows[e.Row.DataItemIndex][6].ToString();

            if(var == "PAGADURIA ARCHIVO PLANO")
            {
                e.Row.Cells[0].FindControl("btnConfirmar").Visible = false;
            }
            grvCertificados.HeaderRow.Cells[6].Visible = false;
            grvCertificados.HeaderRow.Cells[8].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[0].Wrap = false;
        }
    }
}