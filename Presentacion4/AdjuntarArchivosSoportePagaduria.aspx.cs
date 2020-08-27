using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Presentacion_AdjuntarArchivosSoportePagaduria : System.Web.UI.Page
{
    string host;
    string url, jScript;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        try
        {

            if (Session["idPaga"] == null)
            {
                MensajeFormV2("No se ha podido identificar la pagaduria a la cual se le quiere adjuntar el soporte. " +
                                "Por favor Intentelo Nuevamente");
            }

        }
        catch (Exception ex)
        {
            MensajeFormV2("Ha Ocurrido un problema con su petición");
        }
        Uri uri = HttpContext.Current.Request.Url;
        host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

    }


    protected void btnGuardarArchivo_Click(object sender, EventArgs e)
    {
        string url = "";
        string rutaBase = "~/Presentacion4/SoportesPagaduria/";
        string nombreArchivo = "";
        lblMsjCarga.Text = "";
        bool yaExiste = false;

        try
        {           


            if (fuCargarArchivosSoporte.HasFile)
            {

                if (Session["idPaga"] == null)
                {
                    MensajeFormV2("No se ha podido identificar la pagaduria a la cual se le quiere adjuntar el soporte. " +
                                    "Por favor Intentelo Nuevamente");
                }

                nombreArchivo = fuCargarArchivosSoporte.FileName.Trim();

                if (VerificarExtension(nombreArchivo) && VerificarTamaño(nombreArchivo, fuCargarArchivosSoporte.PostedFile.ContentLength / 1024))
                {
                    
                    yaExiste = false;

                    if (File.Exists(Server.MapPath(rutaBase) + nombreArchivo))
                        yaExiste = true;

                    //lblMsjCarga.Text = nombreArchivo;
                    
                    if (yaExiste)
                        lblMsjCarga.Text += " - No se ha podido adjuntar el archivo. Ya existe un archivo con el nombre " + nombreArchivo;
                    else
                    {                        
                        fuCargarArchivosSoporte.SaveAs(Server.MapPath(rutaBase) + nombreArchivo);
                        lblMsjCarga.Text += "<br> - Archivo: " + nombreArchivo;
                        lblMsjCarga.Text += "<br> - Proceso de carga del archivo al Servidor: Ok ";

                        RegistrarSoportePagaduria(rutaBase + nombreArchivo);
                        
                    }
                }

            }
            else
                lblMsjCarga.Text = " - Debe seleccionar un archivo !!!";

        }
        catch (Exception ex)
        {
            lblMsjCarga.Text += ex.ToString();
        }
        
        

    }

    public void RegistrarSoportePagaduria(string urlSoporte)
    {
    
        int resSop = AdministrarPagadurias.RegistrarArchivosSoportePagaduria(null, Session["idPaga"].ToString(),
                txtNomSoporte.Text, urlSoporte);

        if (resSop >= 0)
        {
            lblMsjCarga.Text += "<br> - Proceso de Asocio a la Pagaduría: Ok ";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('El Archivo Soporte ha sido adjuntado correctamente a la Pagaduria');//window.location.replace('" + host + "/gestion/pagadurias/detalle?tab=tab-4')", true);
            //MensajeFormV2(" - El Archivo Soporte ha sido adjuntado correctamente a la Pagaduria");
        }
        else
        {
            lblMsjCarga.Text += "<br> - Proceso de Asocio a la Pagaduría: Error ";
            MensajeFormV2(" - No se ha podido asociar el archivo a la pagaduria. Por favor Intentelo Nuevamente");
        }
    
    }



    bool VerificarExtension(string fileName)
    {

        string ext = Path.GetExtension(fileName);

        switch (ext.ToLower())
        {
            case ".PDF":
                return true;
                break;
            case ".pdf":
                return true;
                break;
            default:
                lblMsjCarga.Text += "No se ha podido adjuntar el archivo " + fileName + ": El archivo no está en la extensión Requerida (.PDF)";
                return false;
                break;
        }

        return false;

    }

    bool VerificarTamaño(string fileName, long totKB)
    {
        if (totKB > 1 && totKB < 5120)
            return true;
        else
        {
            lblMsjCarga.Text += " - No se pudo adjuntar el archivo " + fileName + ": El archivo tiene un tamaño de " + totKB +
                "KB y supera el tamaño maximo permitido de 3000KB.";
            return false;
        }


    }




    public void MensajeFormV2(string msg)
    {

        jScript = "alert('" + msg + "'); VerDetallePagaduria();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

    }



}