using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Beneficiario
/// </summary>
public class Beneficiario
{
    protected string nombre;
    public string Nombre { get; set; }

    protected string apellido;
    public string Apellido { get; set; }

    protected int parentesco;
    public int Parentesco { get; set; }

    protected double porcentaje;
    protected double Porcentaje { get; set; }

    public void InsertarBeneficiario(Beneficiario beneficiario)
    {
        // Crear tabla
    }

}

