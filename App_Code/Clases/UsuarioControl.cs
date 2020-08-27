using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de UsuarioControl
/// </summary>
public class UsuarioControl
{
    public  FrameworkEntidades entidades = new FrameworkEntidades();
    //PrecargueProduccion objPrecargueProduccion = new PrecargueProduccion();
    protected string identificador;
    public string Identificador { get; set; }

    protected string nombreUsuario;
    public string NombreUsuario { get; set; }

    protected string primerNombre;
    public string PrimerNombre { get; set; }

    protected string segundoNombre;
    public string SegundoNombre { get; set; }

    protected string primerApellido;
    public string PrimerApellido { get; set; }

    protected string segundoApellido;
    public string SegundoApellido { get; set; }

    protected string cargo;
    public string Cargo { get; set; }

    protected string idDepartamento;
    public string IdDepartamento { get; set; }

    protected string departamento;
    public string Departamento { get; set; }

    protected string ciudad;
    public string Ciudad { get; set; }

    protected string estado;
    public string Estado { get; set; }

	public void ConsultarUsuarioControl()
	{
        DataTable dt = new DataTable();
        DataRow dr;
        string[] nombreCampos = new string[15] { "con_Id", "con_Usuario", "con_PrimerNombre", "con_SegundoNombre", "con_PrimerApellido", "con_SegundoApellido", "con_Cargo", "dep_Id", "ciu_Id", "con_Password", "rol_Id", "con_Estado", "con_Empresa", "con_EnLinea", "con_Vencimiento" };
        string nombreUsuario = " '" + NombreUsuario + "' ";
        //dt = entidades.Consultar("NewControl", nombreCampos, "con_Usuario", nombreUsuario);
        dr = dt.NewRow();
        try
        {
            dr = dt.Rows[0];
            //Definir TipoDocumento en Base de Datos            
            //Identificador = dr["con_Id"].ToString();
            //PrimerNombre = dr["con_PrimerNombre"].ToString();
            //SegundoNombre = dr["con_SegundoNombre"].ToString();
            //PrimerApellido = dr["con_PrimerApellido"].ToString();
            //SegundoApellido = dr["con_SegundoApellido"].ToString();
            //Cargo = dr["con_Cargo"].ToString();
            //IdDepartamento = dr["dep_Id"].ToString();
            //Departamento = entidades.ConsultarAgencia((dr["dep_Id"].ToString())).Rows[0]["ciu_Nombre"].ToString();
            //Ciudad = dr["ciu_Id"].ToString();
            //Estado = dr["con_Estado"].ToString();            
        }
        catch (Exception e)
        {
            
        }        
	}    
}