using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;



public partial class Presentacion_ConsultarPagaduria : System.Web.UI.Page
{
    
    DataTable dt, dtTemp;
    string url, jScript;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        try
        {

            if (!IsPostBack)
            {

                CargarControles();

                if (Session["idPaga"] != null)
                    CargarDatosPagaduria(Convert.ToInt32(Session["idPaga"].ToString()));

            }

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un problema con su petición", null);
        }

    }


    public void CargarControles()
    {

        try
        {

            Session["idConvPaga"] = null;
            Session["idArchNov"] = null;


            if (Session["idPaga"] != null)
            {
                lblAccion.Text = "Administrar Pagaduria Id. " + Session["idPaga"].ToString();                
            }
            else
                lblAccion.Text = "Registrar Nueva Pagaduria";


            //Listar Departamento
            dt = AdministrarPagadurias.mostrarDepartamento(null, null);
            ddlDepartamento.DataTextField = "dep_Nombre"; // Cargamos lo que aparece en el ddl
            ddlDepartamento.DataValueField = "dep_Id"; // Cargamos lo que vale por debajo
            ddlDepartamento.DataSource = dt;
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione Departamento", "0"));

            //Listar Actividad Económica
            dt = AdministrarPagadurias.ConsultarActividadEconomica(null, null);
            ddlActivEcon.DataTextField = "act_Nombre";
            ddlActivEcon.DataValueField = "act_id";
            ddlActivEcon.DataSource = dt;
            ddlActivEcon.DataBind();
            ddlActivEcon.Items.Insert(0, new ListItem("Seleccione Actividad Económica", "0"));

            //Listar Fecha Entrega Novedades
            dt = AdministrarPagadurias.ConsultarFechaEntregaNovedades(null, null);
            ddlFecEntregaNov.DataTextField = "tipo_fechaEntregaNov";
            ddlFecEntregaNov.DataValueField = "id_fechaEntregaNov";
            ddlFecEntregaNov.DataSource = dt;
            ddlFecEntregaNov.DataBind();
            ddlFecEntregaNov.Items.Insert(0, new ListItem("Seleccione Fecha Entrega Novedades", "0"));

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición",null);
        }

    }

    
    public void CargarDatosPagaduria(int? idPag)
    {

        try
        {

            

            dt = AdministrarPagadurias.ConsultarPagadurias(idPag, null, null);

            if (dt.Rows.Count > 0)
            {

                //lblMsj.Text = "<br><br> val IDPAG: " + idPag.ToString();

                ddlDepartamento.ClearSelection();
                ddlDepartamento.Items.FindByValue(dt.Rows[0]["dep_Id"].ToString()).Selected = true;

                dtTemp = AdministrarPagadurias.mostrarCiudades(null, null, Convert.ToInt32(dt.Rows[0]["dep_Id"].ToString()));
                //Response.Write("count: " + dtTemp.Rows.Count.ToString());

                ddlEstadoPagaduria.ClearSelection();
                ddlEstadoPagaduria.Items.FindByValue(dt.Rows[0]["paga_EstadoPagaduria"].ToString()).Selected = true;

                ddlCiudad.DataValueField = "ciu_id";
                ddlCiudad.DataTextField = "ciu_Nombre";
                ddlCiudad.DataSource = dtTemp;
                ddlCiudad.DataBind();
                
                ddlCiudad.ClearSelection();                
                ddlCiudad.Items.FindByValue(dt.Rows[0]["ciu_Id"].ToString()).Selected = true;

                ddlActivEcon.ClearSelection();
                ddlActivEcon.Items.FindByValue(dt.Rows[0]["act_id"].ToString()).Selected = true;
            
                txtIdentificacion.Text = dt.Rows[0]["paga_Identificacion"].ToString();
                txtNombrePagaduria.Text = dt.Rows[0]["paga_Nombre"].ToString();
                txtDireccion.Text = dt.Rows[0]["paga_Direccion"].ToString();
                txtTelefono.Text = dt.Rows[0]["paga_Telefono"].ToString();
                lblAccion.Text += ": &nbsp;&nbsp;&nbsp;" + dt.Rows[0]["paga_Nombre"].ToString() + 
                    " [ " + dt.Rows[0]["paga_Identificacion"].ToString() + " ]";   

                ddlVisacion.ClearSelection();
                ddlVisacion.Items.FindByValue(dt.Rows[0]["paga_Visacion"].ToString()).Selected = true;

                txtNumEmpl.Text = dt.Rows[0]["paga_NumeroEmpleados"].ToString();
                txtPorcPart.Text = dt.Rows[0]["paga_PorcentajeParticipacion"].ToString().Replace(",",".");

                ddlFecEntregaNov.ClearSelection();
                ddlFecEntregaNov.Items.FindByValue(dt.Rows[0]["paga_FechaEntregaNovedades"].ToString()).Selected = true;

                txtEmail.Text = dt.Rows[0]["paga_Correo"].ToString();
                txtWeb.Text = dt.Rows[0]["paga_Web"].ToString();                
                

                txtNomRespPago.Text = dt.Rows[0]["paga_ResponsablePago"].ToString();
                txtEmailRespPago.Text = dt.Rows[0]["paga_ResponsablePagoCorreo"].ToString();
                txtTelRespPago.Text = dt.Rows[0]["paga_ResponsablePagoTelefono"].ToString();
                txtCelRespPago.Text = dt.Rows[0]["paga_ResponsablePagoCelular"].ToString();                
                txtFecCumpleRespPago.Text = dt.Rows[0]["paga_ResponsablePagoFechaCumple"].ToString();
                                

                if (!String.IsNullOrEmpty(dt.Rows[0]["paga_ResponsablePagoFechaCumple"].ToString()))
                {
                    DateTime fechaCumpleRespPago = Convert.ToDateTime(dt.Rows[0]["paga_ResponsablePagoFechaCumple"].ToString());
                    txtFecCumpleRespPago.Text = fechaCumpleRespPago.ToString("yyyy-MM-dd");
                }


                txtContacto.Text = dt.Rows[0]["paga_Contacto"].ToString();
                txtEmailContacto.Text = dt.Rows[0]["paga_ContactoCorreo"].ToString();
                txtTelContacto.Text = dt.Rows[0]["paga_ContactoTelefono"].ToString();
                txtCelContacto.Text = dt.Rows[0]["paga_ContactoCelular"].ToString();
                txtFecCumpleContacto.Text = dt.Rows[0]["paga_ContactoFechaCumple"].ToString();

                if (!String.IsNullOrEmpty(dt.Rows[0]["paga_ContactoFechaCumple"].ToString()))
                {
                    DateTime fechaCumpleContacto = Convert.ToDateTime(dt.Rows[0]["paga_ContactoFechaCumple"].ToString());                    
                    txtFecCumpleContacto.Text = fechaCumpleContacto.ToString("yyyy-MM-dd");                    
                }
                
                
                txtRespLegal.Text = dt.Rows[0]["paga_ResponsableLegal"].ToString();
                txtEmailRespLegal.Text = dt.Rows[0]["paga_ResponsableLegalCorreo"].ToString();
                txtTelRespLeg.Text = dt.Rows[0]["paga_ResponsableLegalTelefono"].ToString();
                txtCelRespLegal.Text = dt.Rows[0]["paga_ResponsableLegalCelular"].ToString();
                txtFecCumpleRespLegal.Text = dt.Rows[0]["paga_ResponsableLegalFechaCumple"].ToString();

                if (!String.IsNullOrEmpty(dt.Rows[0]["paga_ResponsableLegalFechaCumple"].ToString()))
                {                    
                    DateTime fechaCumpleRespLegal = Convert.ToDateTime(dt.Rows[0]["paga_ResponsableLegalFechaCumple"].ToString());
                    txtFecCumpleRespLegal.Text = fechaCumpleRespLegal.ToString("yyyy-MM-dd");
                }


                pnlArchivosSoportePagaduria.Visible = true;
                CargarArchivosSoportePagaduria(null, null, idPag);

                pnlLocalidadesPagaduria.Visible = true;
                CargarLocalidadesPorPagaduria(null,idPag);

                pnlConvenios.Visible = true;
                CargarConvenios(null,null,null,idPag);

                pnlArchivosNovedades.Visible = true;
                CargarArchivosNovedades(null, idPag, null, null, null);                


            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }


    }

    
    
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            int idDeptoSel = Convert.ToInt32(ddlDepartamento.SelectedValue);

            if (idDeptoSel > 0)
            {
                dt = AdministrarPagadurias.mostrarCiudades(null, null, idDeptoSel);
                ddlCiudad.DataTextField = "ciu_Nombre"; // Cargamos lo que aparece en el ddl
                ddlCiudad.DataValueField = "ciu_Id"; // Cargamos lo que vale por debajo
                ddlCiudad.DataSource = dt;
                ddlCiudad.DataBind();
                ddlCiudad.Items.Insert(0, new ListItem("Seleccione Municipio", "0"));
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

         

    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        try
        {

            int resIdPag = -1;
            string keyIdPaga = null;

            if (Session["idPaga"] != null)
            {
                keyIdPaga = Session["idPaga"].ToString();
            }

            //Guardar Pagaduria
            resIdPag = 
                AdministrarPagadurias.RegistrarPagaduria(keyIdPaga,
                ddlCiudad.SelectedValue, ddlDepartamento.SelectedValue, ddlActivEcon.SelectedValue,
                txtIdentificacion.Text, txtNombrePagaduria.Text, txtDireccion.Text, txtTelefono.Text, ddlVisacion.SelectedValue,
                txtNumEmpl.Text, txtPorcPart.Text.Replace(".", ","), ddlFecEntregaNov.SelectedValue,
                txtNomRespPago.Text, txtEmailRespPago.Text, txtTelRespPago.Text, txtCelRespPago.Text,
                txtContacto.Text, txtEmailContacto.Text, txtTelContacto.Text, txtCelContacto.Text,
                txtRespLegal.Text, txtEmailRespLegal.Text, txtTelRespLeg.Text, txtCelRespPago.Text,
                txtEmail.Text, txtWeb.Text,
                txtFecCumpleRespPago.Text, txtFecCumpleContacto.Text, txtFecCumpleRespLegal.Text,
                ddlEstadoPagaduria.SelectedValue
                );

            if (resIdPag > 0)
            {
                Session["idPaga"] = resIdPag;
                //MensajeForm("Datos Almacenados Correctamente", "DetallePagaduria.aspx");
                MensajeForm("Datos Almacenados Correctamente", "~/gestion/pagadurias/detalle");
            }
            else
            {
                MensajeForm("No se han podido Almacenados los datos. Por favor Intentelo Nuevamente", null);
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            string resDelPag = "";

            if (Session["idPaga"] != null)
                resDelPag = AdministrarPagadurias.EliminarPagaduria(Int32.Parse(Session["idPaga"].ToString()));
            else
                resDelPag = "No se puede eliminar la pagaduria: No ha sido posible identificar la pagaduria a Eliminar";

            //MensajeForm(resDelPag, "Pagadurias.aspx");
            MensajeForm(resDelPag, "~/gestion/pagadurias/detalle");

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }



    public void CargarLocalidadesPorPagaduria(int? idDepto, int? idPaga)
    {

        try
        {

            dtTemp = AdministrarPagadurias.mostrarDepartamento(null, null);
            chkLocalidadesPagaduria.DataValueField = "dep_Id";
            chkLocalidadesPagaduria.DataTextField = "dep_nombre";
            chkLocalidadesPagaduria.DataSource = dtTemp;
            chkLocalidadesPagaduria.DataBind();

            dtTemp = AdministrarPagadurias.ConsultarLocalidadesPorPagaduria(null, idPaga, 1);

            int i = 0;
            foreach (ListItem li in chkLocalidadesPagaduria.Items)
            {


                foreach (DataRow drLoc in dtTemp.Rows)
                {

                    if (drLoc["dep_Id"].ToString().Equals(li.Value))
                        chkLocalidadesPagaduria.Items[i].Selected = true;
                }

                i++;
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }


    protected void GuardarLocalidadesPagaduria_Click(object sender, EventArgs e)
    {

        try
        {

            int resDel = -1, resAdd = 1;
            bool ok = true;


            if (Session["idPaga"] != null)
            {

                int idPaga = Int32.Parse(Session["idPaga"].ToString());
                resDel = AdministrarPagadurias.EliminarLocalidadesPorPagaduria(null, idPaga, 0);
                //lblMsj.Text += chkLocalidadesPagaduria.Items[i].Value + " - " + chkLocalidadesPagaduria.Items[i].Text + ";";

                if (resDel > 0)
                {

                    for (int i = 0; i < chkLocalidadesPagaduria.Items.Count; i++)
                    {

                        if (chkLocalidadesPagaduria.Items[i].Selected)
                        {
                            resAdd = AdministrarPagadurias.RegistrarLocalidadesPorPagaduria(chkLocalidadesPagaduria.Items[i].Value,
                                                                                            idPaga.ToString());

                            if (resAdd < 0)
                                ok = false;

                        }
                    }


                    if (ok)
                    {
                        //MensajeForm("Todas las localidades se han agregado exitosamente","DetallePagaduria.aspx");
                        MensajeForm("Todas las localidades se han agregado exitosamente", null);
                        CargarLocalidadesPorPagaduria(null, idPaga);
                    }
                    else
                    {
                        //MensajeForm("Solo se han agregado parcialmente las localidades. Favor revise e intentelo nuevamente", "DetallePagaduria.aspx");
                        MensajeForm("Solo se han agregado parcialmente las localidades. Favor revise e intentelo nuevamente", "~/gestion/pagadurias/detalle");
                    }


                }
                else
                {
                    MensajeForm("Error al limpiar las localidades. Favor Intentelo Nuevamente ", null);
                }
            }
            else
            {
                //MensajeForm("No se ha podido identificar la pagaduria a la que se le quiere agregar las localidades ", "Pagadurias.aspx");
                MensajeForm("No se ha podido identificar la pagaduria a la que se le quiere agregar las localidades ", "~/gestion/pagadurias");
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }
    

    public void CargarArchivosSoportePagaduria(int? idSopPaga, string nomSopPag, int? idPaga)
    {
        try
        {

            dtTemp = AdministrarPagadurias.ConsultarArchivosSoportePagadurias(idSopPaga, nomSopPag, idPaga);
            grvArchivosSoporte.DataSource = dtTemp;
            grvArchivosSoporte.DataBind();
        
        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }

    protected void btnAddArchivos_Click(object sender, EventArgs e)
    {

        MostrarModal();

    }

    public void MostrarModal()
    {
        jScript = "OpenCenterWindowCallBack();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
    
    }


    protected void grvArchivosSoporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        
            if (Session["idPaga"] != null)
            {
                grvArchivosSoporte.PageIndex = e.NewPageIndex;
                CargarArchivosSoportePagaduria(null, null, Convert.ToInt32(Session["idPaga"].ToString()));
            }
            else
                MensajeForm("No se ha podido identificar la Pagaduria", "~/gestion/pagadurias");
        
        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }
    
    protected void grvArchivosSoporte_SelectedIndexChanged(object sender, EventArgs e)
    {


        try
        {
            string rutaArchivo = Server.MapPath(grvArchivosSoporte.SelectedRow.Cells[2].Text);
            string msjDel = "";

            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
            else
            {
                //MensajeForm("El archivo no existe", "DetallePagaduria.aspx");
                msjDel = "Archivo no Encontrado.";
            }

            string resDel = AdministrarPagadurias.EliminarArchivoSoportePagaduria(Convert.ToInt32(grvArchivosSoporte.SelectedValue));
            MensajeForm(msjDel + " " + resDel, "~/gestion/pagadurias/detalle#archSopPag");


        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }



    public void CargarConvenios(int? idConv, string codConv, string nomConv, int? idPaga)
    {

        try
        {

            dtTemp = AdministrarPagadurias.ConsultarConvenios(idConv, codConv, nomConv, idPaga);
            grvConvenios.DataSource = dtTemp;
            grvConvenios.DataBind();
        }        
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }
    
    }

    protected void btnAddConvenios_Click(object sender, EventArgs e)
    {

        //Response.Redirect("ConveniosPagaduria.aspx", false);
        Response.RedirectToRoute("conveniosPagaduria");

    }

    protected void lnkBtnBuscarConv_Click(object sender, EventArgs e)
    {

        try
        {

            int? filtroIdConv;

            if (String.IsNullOrEmpty(txtFiltroIdConv.Text))
                filtroIdConv = null;
            else
                filtroIdConv = Convert.ToInt32(txtFiltroIdConv.Text);


            if (Session["idPaga"] != null)
                CargarConvenios(filtroIdConv, txtFiltroCodConv.Text, txtFiltroNombreConv.Text,
                            Convert.ToInt32(Session["idPaga"].ToString()));
            else
            {
                //MensajeForm("No se ha podido identificar la Pagaduria", "Pagadurias.aspx");
                MensajeForm("No se ha podido identificar la Pagaduria", "~/gestion/pagadurias");
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }


    }

    
    protected void grvConvenios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {

            if (Session["idPaga"] != null)
            {
                grvConvenios.PageIndex = e.NewPageIndex;
                CargarConvenios(null, null, null, Convert.ToInt32(Session["idPaga"].ToString()));
            }
            else
            {
                //MensajeForm("No se ha podido identificar la Pagaduria", "Pagadurias.aspx");
                MensajeForm("No se ha podido identificar la Pagaduria", "~/gestion/pagadurias");
            }
        
        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString());
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }

    protected void grvConvenios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index;            

            if (e.CommandName == "Eliminar_Click")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = grvConvenios.Rows[(index)];

                string resDelPag = "";
                resDelPag = AdministrarPagadurias.EliminarConvenios(Int32.Parse(row.Cells[1].Text));
                //MensajeForm(resDelPag, "DetallePagaduria.aspx#irConvenios");
                MensajeForm(resDelPag, "~/gestion/pagadurias/detalle#irConvenios");

            }


        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }

    protected void grvConvenios_SelectedIndexChanged(object sender, EventArgs e)
    {

        //lblMsj.Text = grvConvenios.SelectedValue.ToString();
        Session["idConvPaga"] = grvConvenios.SelectedValue;
        //Response.Redirect("ConsultarConveniosPagaduria.aspx",false);
        Response.RedirectToRoute("consultarConveniosPagaduria");
    }





    public void CargarArchivosNovedades(int? idArchPag, int? idPag, string nomArch, string tipArch, string tipRep)
    {

        try
        {

            dtTemp = AdministrarPagadurias.ConsultarArchivoNovedades(idArchPag, idPag, nomArch, tipArch, tipRep);
            grvArchivosNovedades.DataSource = dtTemp;
            grvArchivosNovedades.DataBind();
        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }


    }

    protected void btnAddConfigNov_Click(object sender, EventArgs e)
    {

        //Response.Redirect("ConfigurarArchivosNovedades.aspx", false);
        Response.RedirectToRoute("configurarArchivosNovedades");

    }

    protected void lnkBtnBuscarArchNov_Click(object sender, EventArgs e)
    {

        try
        {

            int? filtroIdArchNov;
            string tipRep = null, tipArch = null;

            if (String.IsNullOrEmpty(txtIdArchNov.Text))
                filtroIdArchNov = null;
            else
                filtroIdArchNov = Convert.ToInt32(txtIdArchNov.Text);


            if (!ddlTipoArchivo.SelectedValue.Equals("-1"))
                tipArch = ddlTipoArchivo.SelectedValue;

            if (!ddlTipoReporte.SelectedValue.Equals("-1"))
                tipRep = ddlTipoReporte.SelectedValue;


            if (Session["idPaga"] != null)
                CargarArchivosNovedades(filtroIdArchNov, Convert.ToInt32(Session["idPaga"].ToString()), txtNomArchNov.Text,
                    tipArch, tipRep);
            else
            {
                //MensajeForm("No se ha podido identificar la Pagaduria", "Pagadurias.aspx");
                MensajeForm("No se ha podido identificar la Pagaduria", "~/gestion/pagadurias");
            }
               

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }


    protected void grvArchivosNovedades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {

            if (Session["idPaga"] != null)
            {
                grvArchivosNovedades.PageIndex = e.NewPageIndex;
                CargarArchivosNovedades(null, Convert.ToInt32(Session["idPaga"].ToString()), null, null, null);
            }
            else
            {
                //MensajeForm("No se ha podido identificar la Pagaduria", "Pagadurias.aspx");
                MensajeForm("No se ha podido identificar la Pagaduria", "~/gestion/pagadurias");
            }

        }
        catch (Exception ex)
        {
            MensajeForm("Ha Ocurrido un Problema con su petición", null);
        }

    }

    protected void grvArchivosNovedades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index;

            if (e.CommandName == "Eliminar_Click")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = grvArchivosNovedades.Rows[(index)];

                string resDelPag = "";
                resDelPag = AdministrarPagadurias.EliminarArchivoNovedades(Int32.Parse(row.Cells[1].Text));
                //MensajeForm(resDelPag, "DetallePagaduria.aspx#irConfigArchNov");
                MensajeForm(resDelPag, "~/gestion/pagadurias/detalle#irConfigArchNov");

            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }

    protected void grvArchivosNovedades_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Session["idArchNov"] = grvArchivosNovedades.SelectedValue;
        //Response.Redirect("ConsultarConfigArchivosNovedades.aspx", false);
        Response.RedirectToRoute("consultarConfigArchivosNovedades");
    }
 





    public void MensajeForm(string msg, string url)
    {
        if (url != null)
        {
            jScript = "alert('" + msg + "');location.href='" + url + "';";
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "onclick", jScript, true);
        }
        else
        {
            jScript = "alert('" + msg + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);
        }


    }


}