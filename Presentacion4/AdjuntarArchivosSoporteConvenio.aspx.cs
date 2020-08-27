using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Presentacion_AdjuntarArchivosSoporteConvenio : System.Web.UI.Page
{

    
    string url, jScript;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.RedirectToRoute("thor");
        }
        try
        {

            if (Session["idConvPaga"] == null)
            {
                MensajeFormV2("No se ha podido identificar el Convenio al cual se le quiere adjuntar el soporte. " +
                                "Por favor Intentelo Nuevamente");
            }
        
        }
        catch (Exception ex)
        {
            MensajeFormV2("Ha Ocurrido un problema con su petición");
        }

    }


    protected void btnGuardarArchivo_Click(object sender, EventArgs e)
    {

        string url = "";
        string rutaBase = "~/Presentacion4/SoportesConvenios/";
        string nombreArchivo = "";
        lblMsjCarga.Text = "";
        bool yaExiste = false;

        try
        {


            if (fuCargarArchivosSoporte.HasFile)
            {

                if (Session["idConvPaga"] == null)
                {
                    MensajeFormV2("No se ha podido identificar el convenio al cual se le quiere adjuntar el soporte. " +
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

                        RegistrarSoporteConvenio(rutaBase + nombreArchivo);

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

    public void RegistrarSoporteConvenio(string urlSoporte)
    {

        try
        {

            int resSop = AdministrarPagadurias.RegistrarArchivosSoporteConvenio(null, Session["idConvPaga"].ToString(),
                    txtNomSoporte.Text, urlSoporte);

            if (resSop >= 0)
            {
                lblMsjCarga.Text += "<br> - Proceso de Asocio al Convenio: Ok ";
                MensajeFormV2(" - El Archivo Soporte ha sido adjuntado correctamente al Convenio");
            }
            else
            {
                lblMsjCarga.Text += "<br> - Proceso de Asocio al Convenio: Error ";
                MensajeFormV2(" - No se ha podido asociar el archivo al Convenio. Por favor Intentelo Nuevamente");
            }


        }
        catch (Exception ex)
        {
            MensajeFormV2("Ha Ocurrido un problema con su petición");
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
        if (totKB > 1 && totKB < 3000)
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

        jScript = "alert('" + msg + "'); VerConvenio();";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onclick", jScript, true);

    }



}