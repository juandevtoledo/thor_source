using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Agencia
/// </summary>
public class Agencia
{
    //Sebastian

	public static FrameworkEntidades entidades = new FrameworkEntidades();

       protected int ageId;
       public int AgeId {get;set;}

       protected string ageNombre;
       public string AgeNombre {get;set;}

       protected string ageDireccion;
       public string AgeDireccion {get;set;}

       protected string ageTelefono;
       public string AgeTelefono {get;set;}

       protected string ageEmail;
       public string AgeEmail{get;set;}

       protected string ageDirector;
       public string AgeDirector {get;set;}

       protected int depId;
       public int DepId {get;set;}

       protected int ciuId;
       public int CiuId {get;set;}

       public static DataTable ConsultarAgencia(string nombreUsuario)
	        {
                DataTable dt = new DataTable();
                string[] nombreCampos = new string[8] { "age_Id", "age_Nombre", "age_Direccion", "age_Telefono", "age_Email", "age_Director", "dep_Id", "ciu_Id" };
                dt = entidades.SPConsultarAgencia(nombreUsuario);
                return dt;
	        }
}