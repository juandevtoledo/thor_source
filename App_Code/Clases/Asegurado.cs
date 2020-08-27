using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de Asegurado
/// </summary>
public class Asegurado : Tercero
{
    //public static Asegurado asegurado = new Asegurado();
    //public static Departamento departamento = new Departamento();

    public static FrameworkEntidades entidades = new FrameworkEntidades();   

    protected string parentesco;
    public string Parentesco { get; set; }
    protected List<Beneficiario> beneficiarios;
    public int Beneficiarios { get; set; }
    //protected List<Pagaduria> Pagadurias;
    //public List<Pagaduria> { get; set; }
    protected Plan plan;
    public Plan Plan { get; set; }    
    //protected Factura Factura;
    //public Factura factura { get; set; }
    protected double prima;
    public double Prima { get; set; }


    public int InsertarAsegurado()
    {        
        int result = 0;
        List<string> valores = new List<string>();
        valores.Add(NumeroIdentificacion);
        valores.Add("'" + Apellidos + "'");
        valores.Add("'" + Nombres + "'");
        valores.Add("'" + Sexo + "'");
        // En la tabla la posición para EstadoCivil permite null
        valores.Add("''");
        valores.Add("'" + FechaNacimiento.ToString() + "'");
        valores.Add(Ocupacion.ToString());
        valores.Add(Departamento.ToString());
        valores.Add(Ciudad.ToString());
        valores.Add("'" + Direccion + "'");
        valores.Add("'" + Telefono1 + "'");
        valores.Add("'" + Telefono2 + "'");
        valores.Add("'" + Celular + "'");
        valores.Add("'" + CorreoElectronico + "'");
        // En la tabla la posición para Usuario, Password, Habeas Data (solo numericos) permiten null
        valores.Add("''");
        valores.Add("''");
        valores.Add("1");
        
        result = entidades.Insertar("Tercero", valores);
        return result;
    }


    public int ActualizarAsegurado()
    {
        string[] nombreCampos = new string[17] {"ter_Id", "ter_Apellidos", "ter_Nombres", "ter_Sexo", "ter_EstadoCivil", "ter_FechaNacimiento", "ocu_Id", "dep_Id", "ciu_Id", "ter_Direccion", "ter_TelefonoResidencia", "ter_TelefonoOficina", "ter_Celular", "ter_Correo", "ter_Usuario", "ter_Password", "ter_HabeasData"};
        int result = 0;
        List<string> valores = new List<string>();
        valores.Add(NumeroIdentificacion);
        valores.Add("'" + Apellidos + "'");
        valores.Add("'" + Nombres + "'");
        valores.Add("'" + Sexo + "'");
        // En la tabla la posición para EstadoCivil permite null
        valores.Add("''");
        valores.Add("'" + FechaNacimiento.Date.ToString("d") + "'");
        valores.Add(Ocupacion.ToString());
        valores.Add(Departamento.ToString());
        valores.Add(Ciudad.ToString());
        valores.Add("'" + Direccion + "'");
        valores.Add("'" + Telefono1 + "'");
        valores.Add("'" + Telefono2 + "'");
        valores.Add("'" + Celular + "'");
        valores.Add("'" + CorreoElectronico + "'");
        // En la tabla la posición para Usuario, Password, Habeas Data (solo numericos) permiten null
        valores.Add("''");
        valores.Add("''");
        valores.Add("1");

        result = entidades.Actualizar("Tercero", nombreCampos, valores, "ter_id", NumeroIdentificacion);
        return result;
    }


    public int EliminarAsegurado()
    {
        int result = 0;        
        result = entidades.Eliminar("Tercero", "ter_id", NumeroIdentificacion);
        return result;
    }


    //public Asegurado ConsultarAsegurado(Asegurado asegurado)
    public void ConsultarAsegurado()
    {
        //DataTable dt = new DataTable();
        //DataRow dr;
        //string[] nombreCampos = new string[17] { "ter_Id", "ter_Apellidos", "ter_Nombres", "ter_Sexo", "ter_EstadoCivil", "ter_FechaNacimiento", "ocu_Id", "dep_Id", "ciu_Id", "ter_Direccion", "ter_TelefonoResidencia", "ter_TelefonoOficina", "ter_Celular", "ter_Correo", "ter_Usuario", "ter_Password", "ter_HabeasData" };
        ////dt = entidades.Consultar("NewTercero", nombreCampos, "ter_id", NumeroIdentificacion);
        ////dr = dt.NewRow();
        //try 
        //{
        //    dr = dt.Rows[0];
        //    //Definir TipoDocumento en Base de Datos            
        //    TipoDocumento = 1;
        //    NumeroIdentificacion = dr["ter_Id"].ToString();
        //    Nombres = dr["ter_Nombres"].ToString();
        //    Apellidos = dr["ter_Apellidos"].ToString();
        //    Departamento = int.Parse(dr["dep_Id"].ToString());
        //    Ciudad = int.Parse(dr["ciu_Id"].ToString());
        //    Direccion = dr["ter_Direccion"].ToString();
        //    FechaNacimiento = Convert.ToDateTime(dr["ter_FechaNacimiento"].ToString());
        //    Telefono1 = dr["ter_TelefonoResidencia"].ToString();
        //    Telefono2 = dr["ter_TelefonoOficina"].ToString();
        //    Celular = dr["ter_Celular"].ToString();
        //    CorreoElectronico = dr["ter_Correo"].ToString();
        //    Ocupacion = int.Parse(dr["ocu_Id"].ToString());
        //    Sexo = dr["ter_Sexo"].ToString();
        //    //asegurado.LugarTrabajo = lugartrabajo
        //    Edad = CalcularEdad(FechaNacimiento);
        //}
        //catch (Exception e)
        //{
        //    NumeroIdentificacion = "-1";                        
        //}           
    }


    public int CalcularEdad(DateTime fechaNacimiento)
    {        
        int edad = DateTime.Now.Year - fechaNacimiento.Year;        
        DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);        
        if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
        {
            edad--;
        }
        return edad;
    }


    
    
    
    
    
    
    
    //**********************************************************************
    //JC
    public string sp_InsertarTercero()
    {
        string mensaje = entidades.SPInsertarNewTercero();
        return mensaje;
    }


    //JC
    public string sp_EliminarTercero()
    {
        string mensaje = entidades.SPEliminarNewTercero();
        return mensaje;
    }


    //Modificar tercero. JC
    public string sp_ModificarTercero()
    {
        string mensaje = entidades.SPModificarNewTercero();
        return mensaje;
    }


    public DataTable sp_MostrarTipoDocumento()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPMostrarNewTipoDocumento();
        return dt;
    }


    public DataTable sp_MostrarDepartamento()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPMostrarDepartamento();
        return dt;
    }


    public DataTable sp_ConsultarCiudad()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPConsultarCiudad();
        return dt;
    }


    public DataTable sp_MostrarOcupacion()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPMostrarOcupacion();
        return dt;
    }


    public DataTable sp_ConsultarEstadoCivil()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPConsultarEstadoCivil();
        return dt;
    }


    public void sp_MostrarTercero()
    {
        DataTable dt = new DataTable(); // datatable para capturar el return de la consulta
        dt = entidades.SPMostrarNewTercero();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["tipDoc_Nombre"].ToString() != "")
                AdministrarTercero.asegurado.TipoDocumentoNombre = dt.Rows[0]["tipDoc_Nombre"].ToString();

            if (dt.Rows[0]["ter_Id"].ToString() != "")
                AdministrarTercero.asegurado.numeroIdentificacion = dt.Rows[0]["ter_Id"].ToString();

            if (dt.Rows[0]["ter_Nombres"].ToString() != "")
                AdministrarTercero.asegurado.Nombres = dt.Rows[0]["ter_Nombres"].ToString();

            if (dt.Rows[0]["ter_Apellidos"].ToString() != "")
                AdministrarTercero.asegurado.Apellidos = dt.Rows[0]["ter_Apellidos"].ToString();

            if (dt.Rows[0]["ter_FechaNacimiento"].ToString() != "")
                //AdministrarTercero.asegurado.FechaNacimiento = Convert.ToDateTime(dt.Rows[0]["ter_FechaNacimiento"]);
                AdministrarTercero.asegurado.FechaNacimiento = DateTime.Parse(dt.Rows[0]["ter_FechaNacimiento"].ToString());           

            if (dt.Rows[0]["ter_Correo"].ToString() != "")
                AdministrarTercero.asegurado.CorreoElectronico = dt.Rows[0]["ter_Correo"].ToString();

            if (dt.Rows[0]["ter_Sexo"].ToString() != "")
                AdministrarTercero.asegurado.Sexo = dt.Rows[0]["ter_Sexo"].ToString();

            if (dt.Rows[0]["dep_Nombre"].ToString() != "")
                AdministrarTercero.asegurado.DepartamentoNombre = dt.Rows[0]["dep_Nombre"].ToString();

            if (dt.Rows[0]["dep_Id"].ToString() != "")
                AdministrarTercero.asegurado.Departamento = int.Parse(dt.Rows[0]["dep_Id"].ToString());

            if (dt.Rows[0]["ciu_Nombre"].ToString() != "")
                AdministrarTercero.asegurado.CiudadNombre = dt.Rows[0]["ciu_Nombre"].ToString();

            if (dt.Rows[0]["ter_Celular"].ToString() != "")
                AdministrarTercero.asegurado.Celular = dt.Rows[0]["ter_Celular"].ToString();

            if (dt.Rows[0]["ter_TelefonoResidencia"].ToString() != "")
                AdministrarTercero.asegurado.Telefono1 = dt.Rows[0]["ter_TelefonoResidencia"].ToString();

            if (dt.Rows[0]["ter_Direccion"].ToString() != "")
                AdministrarTercero.asegurado.Direccion = dt.Rows[0]["ter_Direccion"].ToString();

            if (dt.Rows[0]["ter_TelefonoOficina"].ToString() != "")
                AdministrarTercero.asegurado.Telefono2 = dt.Rows[0]["ter_TelefonoOficina"].ToString();

            if (dt.Rows[0]["ocu_Nombre"].ToString() != "")
                AdministrarTercero.asegurado.OcupacionNombre = dt.Rows[0]["ocu_Nombre"].ToString();

            if (dt.Rows[0]["estCiv_Nombre"].ToString() != "")
                AdministrarTercero.asegurado.EstadoCivilNombre = dt.Rows[0]["estCiv_Nombre"].ToString();
            if (dt.Rows[0]["ter_HabeasData"].ToString() != "")
                AdministrarTercero.asegurado.HabeasData = int.Parse(dt.Rows[0]["ter_HabeasData"].ToString());

            AdministrarTercero.asegurado.Mensaje = "Busqueda exitosa!";
        }
        else
        {
            AdministrarTercero.asegurado.Mensaje = "No existe el documento";
        }
    }
            
}

