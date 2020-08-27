using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    /// <summary>
    /// Método que deshabilita formatos de exportación en ReportViewer
    /// </summary>
    /// <param name="ReportViewerID">Reporte en el que se desean deshabilitar los formatos de exportación</param>
    /// <param name="nombreFormatos">Lista con los nombres de los formatos a deshabilitar</param>
    public static void DeshabilitarFormatoExportacion(ReportViewer ReportViewerID, string[] nombreFormatos)
    {
        FieldInfo info;

        foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
        {
            if (nombreFormatos.Contains(extension.Name.ToUpper()))
            {
                info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                info.SetValue(extension, false);
            }
        }
    }

    /// <summary>
    /// Método que obtiene los ids seleccionados en un ListBox
    /// </summary>
    /// <returns>Cadena de elementos seleccionados separados por coma</returns>
    public static string ObtenerIdsSeleccionados(ListBox listBox)
    {
        int[] selectedIndexes = listBox.GetSelectedIndices();
        string[] values = new string[selectedIndexes.Length];
        string ids = "";
        for (int i = 0; i < selectedIndexes.Length; i++)
        {
            ids += listBox.Items[selectedIndexes[i]].Value + ",";
        }
        ids.TrimEnd(',');

        if (ids == "")
            ids = "ALL";
        return ids;
    }

    /// <summary>
    /// Método que obtiene los textos seleccionados en un ListBox
    /// </summary>
    /// <returns>Cadena de textos seleccionados separados por coma</returns>
    public static string ObtenerTextosSeleccionados(ListBox listBox)
    {
        int[] selectedIndexes = listBox.GetSelectedIndices();
        string textos = "";
        for (int i = 0; i < selectedIndexes.Length; i++)
        {
            textos += listBox.Items[selectedIndexes[i]].Text + ", ";
        }
        textos = textos.TrimEnd(new char[] { ',', ' ' });
        return textos;
    }
}