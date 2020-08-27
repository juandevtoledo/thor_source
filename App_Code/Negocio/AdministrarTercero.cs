using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de AdministrarTercero
/// </summary>
public class AdministrarTercero
{

    public static Asegurado asegurado = new Asegurado(); //static por no se instancia, se llama

    public static string InsertarTercero(string ter_Id, string ter_TipoDocumento, string ter_Nombres, string ter_Apellidos, DateTime ter_FechaNacimiento, string ter_Correo, string ter_Sexo, string dep_Id, string ciu_Id, string ter_Celular, string ter_TelefonoResidencia, string ter_Direccion, string ter_TelefonoOficina, string ocu_Id, string ter_EstadoCivil,int habeasData) //recibe por argumentos
    {
        asegurado.NumeroIdentificacion = ter_Id;
        if(ter_TipoDocumento != "")
        {
            asegurado.TipoDocumento = int.Parse(ter_TipoDocumento);
        }
        else
        {
            asegurado.TipoDocumento = 0;
        }
        asegurado.Nombres = ter_Nombres;
        asegurado.Apellidos = ter_Apellidos;
        asegurado.FechaNacimiento = Convert.ToDateTime(ter_FechaNacimiento);
        asegurado.CorreoElectronico = ter_Correo;
        asegurado.Sexo = Convert.ToString(ter_Sexo);
        asegurado.Departamento = int.Parse(dep_Id);
        if (ciu_Id != "")
        {
            asegurado.Ciudad = int.Parse(ciu_Id);
        }
        else
        {
            asegurado.Ciudad = 0;
        }
        if (ocu_Id != "")
        {
            asegurado.Ocupacion = int.Parse(ocu_Id);
        }
        else
        {
            asegurado.Ocupacion = 0;
        }
        asegurado.Celular = ter_Celular;
        asegurado.Telefono1 = ter_TelefonoResidencia;
        asegurado.Direccion = ter_Direccion;
        asegurado.Telefono2 = ter_TelefonoOficina;
        if (ter_EstadoCivil != "")
        {
            asegurado.EstadoCivil = int.Parse(ter_EstadoCivil);
        }
        else
        {
            asegurado.EstadoCivil = 0;
        }
        asegurado.HabeasData = habeasData;

        string mensaje = asegurado.sp_InsertarTercero();
        return mensaje;
    }


    public static void ModificarTercero(string ter_Id, string ter_TipoDocumento, string ter_Nombres, string ter_Apellidos, DateTime ter_FechaNacimiento, string ter_Correo, string ter_Sexo, string dep_Id, string ciu_Id, string ter_Celular, string ter_TelefonoResidencia, string ter_Direccion, string ter_TelefonoOficina, string ocu_Id, string ter_EstadoCivil, int habeasData) //recibe por argumentos
    {
        asegurado.NumeroIdentificacion = ter_Id;
        asegurado.TipoDocumento = int.Parse(ter_TipoDocumento);
        asegurado.Nombres = ter_Nombres;
        asegurado.Apellidos = ter_Apellidos;
        asegurado.FechaNacimiento = Convert.ToDateTime(ter_FechaNacimiento);
        asegurado.CorreoElectronico = ter_Correo;
        asegurado.Sexo = Convert.ToString(ter_Sexo);
        asegurado.Departamento = int.Parse(dep_Id);
        asegurado.Ciudad = int.Parse(ciu_Id);
        asegurado.Ocupacion = int.Parse(ocu_Id);
        asegurado.Celular = ter_Celular;
        asegurado.Telefono1 = ter_TelefonoResidencia;
        asegurado.Direccion = ter_Direccion;
        asegurado.Telefono2 = ter_TelefonoOficina;
        asegurado.EstadoCivil = int.Parse(ter_EstadoCivil);
        asegurado.HabeasData = habeasData;

        asegurado.sp_ModificarTercero();
    }


    public static string EliminarTercero(string ter_Id)
    {
        asegurado.NumeroIdentificacion = ter_Id;

        string mensaje = asegurado.sp_EliminarTercero();
        return mensaje;
    }


    public static DataTable MostrarTipoDocumento()
    {
        DataTable dt = new DataTable();
        dt = asegurado.sp_MostrarTipoDocumento();
        return dt;


    }


    public static DataTable MostrarDepartamento()
    {
        DataTable dt = new DataTable();
        dt = asegurado.sp_MostrarDepartamento();
        return dt;
    }


    public static DataTable ConsultarCiudad(string dep_Id)
    {
        asegurado.Departamento = int.Parse(dep_Id);

        DataTable dt = new DataTable();
        dt = asegurado.sp_ConsultarCiudad();
        return dt;
    }


    public static DataTable MostrarOcupacion()
    {
        DataTable dt = new DataTable();
        dt = asegurado.sp_MostrarOcupacion();
        return dt;
    }


    public static DataTable ConsultarEstadoCivil()
    {
        DataTable dt = new DataTable();
        dt = asegurado.sp_ConsultarEstadoCivil();
        return dt;
    }


    public static void MostrarTercero(string ter_Id)
    {
        asegurado.NumeroDocumento = ter_Id;

        asegurado.sp_MostrarTercero();
    }
}