using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para las cuentas bancarias por bancos por tipos de cuentas
/// </summary>
public class AdministrarCuentaBancoTipoCuenta
{
    /// <summary>
    /// Lista todas las cuentas bancarias por bancos por tipos de cuentas del sistema
    /// </summary>
    /// <returns>Tabla con todas las cuentas bancarias por bancos por tipos de cuentas</returns>
    public static DataTable ListarCuentasBancosTiposCuentas()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancoTipoCuenta.sp_ListarNewCuentasBancariasPorBancosTiposCuentas();
        return dt;
    }

    /// <summary>
    /// Inserta la información de una cuenta bancaria por banco por tipo de cuenta
    /// </summary>
    /// <param name="bancoIdentifcador">Banco</param>
    /// <param name="tipoCuentaIdentificador">Tipo Cuenta</param>
    /// <param name="cuentaBancariaIdentificador">Cuenta</param>
    public static void InsertarCuentaBancoTipoCuenta(long bancoIdentifcador, long tipoCuentaIdentificador, long cuentaBancariaIdentificador)
    {
        DAOAdministrarCuentaBancoTipoCuenta.sp_InsertarNewCuentaBancariaPorBancoTipoCuenta(bancoIdentifcador, tipoCuentaIdentificador, cuentaBancariaIdentificador);
    }

    /// <summary>
    /// Consulta la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de cuenta bancaria por banco por tipo de cuenta</returns>
    public static DataTable ConsultarCuentaBancoTipoCuenta(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancoTipoCuenta.sp_ConsultarNewCuentaBancariaPorBancoTipoCuenta(cuentaBancoTipoIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de una cuenta bancaria por banco por tipo de cuenta por su ID para ser modificado
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de cuenta bancaria por banco por tipo de cuenta para ser modificado</returns>
    public static DataTable ConsultarCuentaBancoTipoCuentaModificar(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancoTipoCuenta.sp_ConsultarNewCuentaBancariaPorBancoTipoCuentaModificar(cuentaBancoTipoIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <param name="bancoIdentifcador">Nuevo banco</param>
    /// <param name="tipoCuentaIdentificador">Nuevo tipo cuenta</param>
    /// <param name="cuentaBancariaIdentificador">Nuevo cuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarCuentaBancoTipoCuenta(long cuentaBancoTipoIdentificador, long bancoIdentifcador, long tipoCuentaIdentificador, long cuentaBancariaIdentificador)
    {
        DAOAdministrarCuentaBancoTipoCuenta.sp_ActualizarNewCuentaBancariaPorBancoTipoCuenta(cuentaBancoTipoIdentificador, bancoIdentifcador, tipoCuentaIdentificador, cuentaBancariaIdentificador);
    }

    /// <summary>
    /// Elimina la información de una cuenta bancaria por banco por tipo de cuenta por su ID
    /// </summary>
    /// <param name="cuentaBancoTipoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarCuentaBancoTipoCuenta(long cuentaBancoTipoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarCuentaBancoTipoCuenta.sp_EliminarNewCuentaBancariaPorBancoTipoCuenta(cuentaBancoTipoIdentificador);
        return dt;
    }
}
