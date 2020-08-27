using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestionarTercero
/// </summary>
public class GestionarTercero
{
	public GestionarTercero()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    //
    public static DataTable BuscarTercero(double terId, string terNombres, string terApellidos)
    {
        //int ter_Id = string.IsNullOrEmpty(terId) ? 0 : int.Parse(terId);
      
        string ter_Nombres = string.IsNullOrEmpty(terNombres) ? "" : terNombres;
        string ter_Apellidos = string.IsNullOrEmpty(terApellidos) ? "" : terApellidos;

        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_BuscarTercero(terId, ter_Nombres, ter_Apellidos);
        return dt;
    }

    //
    public static DataTable ConsultarTercero(int ter_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_ConsultarNewTerceroPorCedula(ter_Id);
        return dt;
    }

    //
    public static DataTable ConsultarLocalidades()
    {
        DAOAdministrarCertificado objAdministrarCertificado = new DAOAdministrarCertificado();
        DataTable dt = new DataTable();
        dt = objAdministrarCertificado.ConsultarLocalidades();
        return dt;
    }

    //
    public static DataTable ConsultarCiudadesPorDepartamento(string dep)
    {
        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_ConsultarCiudadPorDepartamento(dep);
        return dt;
    }

    //
    public static DataTable ConsultarTiposDocumentos()
    {
        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_MostrarTipoDocumento();
        return dt;
    }

    public static DataTable ConsultarEstadosCiviles()
    {
        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_ConsultarEstadoCivil();
        return dt;
    }

    public static DataTable ConsultarOcupaciones()
    {
        DataTable dt = new DataTable();
        dt = DAOGestionarTercero.sp_ConsultarOcupacion();
        return dt;
    }

    public static DataTable ConsultarGeneros()
    {
        DataTable dt = new DataTable();

        DataColumn columns = new DataColumn();
        columns.DataType = System.Type.GetType("System.String");
        columns.AllowDBNull = true;
        columns.ColumnName = "generoNombre";
        dt.Columns.Add(columns);

        DataRow item = dt.NewRow();
        item["generoNombre"] = "MASCULINO";
        dt.Rows.Add(item);

        item = dt.NewRow();
        item["generoNombre"] = "FEMENINO";
        dt.Rows.Add(item);

        return dt;
    }

    public static int ModificarTercero(int txtDocumento, int ddlTipoDocumentoTercero, string txtNombre, 
                                        string txtApellido, DateTime txtNacimiento, string txtCorreo, string ddlGeneroTercero,
                                        int ddlDepartamento, int ddlCiudad, string txtCelular, string txtTelefono1,
                                        string txtDireccion, string txtTelefono2, int ddlOcupacionTercero, int ddlEstadoCivilTercero, string usuario, int habeasData)
    {
        int reg = DAOGestionarTercero.sp_EditarNewTercero( txtDocumento, ddlTipoDocumentoTercero, txtNombre, 
                                         txtApellido, txtNacimiento, txtCorreo, ddlGeneroTercero,
                                         ddlDepartamento, ddlCiudad, txtCelular, txtTelefono1,
                                         txtDireccion, txtTelefono2, ddlOcupacionTercero, ddlEstadoCivilTercero, usuario,habeasData);
        return reg;
    }

    public static int InsertarTercero(int txtDocumento, int ddlTipoDocumentoTercero, string txtNombre,
                                        string txtApellido, DateTime txtNacimiento, string txtCorreo, string ddlGeneroTercero,
                                        int ddlDepartamento, int ddlCiudad, string txtCelular, string txtTelefono1,
                                        string txtDireccion, string txtTelefono2, int ddlOcupacionTercero, int ddlEstadoCivilTercero, string usuario,int habeasData)
    {
        int reg = DAOGestionarTercero.sp_InsertarNewTercero(txtDocumento, ddlTipoDocumentoTercero, txtNombre,
                                         txtApellido, txtNacimiento, txtCorreo, ddlGeneroTercero,
                                         ddlDepartamento, ddlCiudad, txtCelular, txtTelefono1,
                                         txtDireccion, txtTelefono2, ddlOcupacionTercero, ddlEstadoCivilTercero, usuario,habeasData);
        return reg;
    }

    public static DataTable ConsultarObservaciones(string ter_Id, string obs_IdObservacionMenu)
    {
        DataTable dt = DAOGestionarTercero.spConsultarObservaciones(ter_Id,obs_IdObservacionMenu);
        return dt;
    }
}