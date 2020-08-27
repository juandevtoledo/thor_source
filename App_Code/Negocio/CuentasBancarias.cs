using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CuentasBancarias
/// </summary>
public class CuentasBancarias
{
	public CuentasBancarias()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static DataTable ConsultarCompanias()
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.spConsultarCompaniaGeneral();
        return dt;
    }

    public static DataTable ConsultarBancosPorCompania(int com_Id, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.spConsultarBancosPorCompania(com_Id, tipBan_Id);
        return dt;
    }

    public static DataTable ConsultarCuentasPorBancoCompania(int ban_Id, int com_Id, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.spConsultarCuentasPorBancoCompania(ban_Id, com_Id, tipBan_Id);
        return dt;
    }

    public static DataTable ConsultarCuentasPorArchivo(int archivoId)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.spConsultarCuentasPorArchivo(archivoId);
        return dt;
    }

    public static DataTable ConsultarTipoCuentaBancaria(int cuentaBancaria)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.spConsultarTipoCuentaBancaria(cuentaBancaria);
        return dt;
    }

    public static DataTable consultarTipoCuentaParaEditar(int bancoEdit, int compañiaEdit, int tipBan_Id)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.sp_consultarTipoCuentaParaEditar(bancoEdit, compañiaEdit, tipBan_Id);
        return dt;
    }

    public static DataTable consultarCuentasParaEditar(int bancoEdit, int compañiaEdit, int tipBan_Id, int tipoCuentaEdit)
    {
        DataTable dt = new DataTable();
        dt = DAOCuentasBancarias.sp_consultarCuentasParaEditar(bancoEdit, compañiaEdit, tipBan_Id, tipoCuentaEdit);
        return dt;
    }
}