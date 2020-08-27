using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Compania
/// </summary>
public class AdministrarCuentaBancaria
{
    public static DataTable ListarCuentasBancarias()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancaria.sp_ListarNewCuentasBancarias();
        return dt;
    }
    public static void InsertarCuentaBancaria(long numeroCuentaBancaria)
    {

        DAOAdministrarCuentaBancaria.sp_InsertarNewCuentaBancaria(numeroCuentaBancaria);
    }
    public static DataTable ConsultarCuentaBancaria(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancaria.sp_ConsultarNewCuentaBancaria(cuentaBancariaID);
        return dt;
    }
    public static DataTable ConsultarCuentaBancariaModificar(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();
        //sp_ConsultarCompaniaModificar
        dt = DAOAdministrarCuentaBancaria.sp_ConsultarNewCuentaBancariaModificar(cuentaBancariaID);
        return dt;
    }
    public static void ModificarCuentaBancaria(long cuentaBancariaID, long numeroCuentaBancaria)
    {
        DAOAdministrarCuentaBancaria.sp_ActualizarNewCuentaBancaria(cuentaBancariaID, numeroCuentaBancaria);
    }
    public static DataTable EliminarCuentaBancaria(int cuentaBancariaID)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancaria.sp_EliminarNewCuentaBancaria(cuentaBancariaID);
        return dt;
    }
}