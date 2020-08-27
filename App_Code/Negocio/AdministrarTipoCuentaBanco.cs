using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Clase de negocio para Las tipos cuenta por banco
/// </summary>
public class AdministrarTipoCuentaBanco
{
    /// <summary>
    /// Lista todas las tipos cuentas por bancos del sistema
    /// </summary>
    /// <returns>Tabla con todas las tipos cuentas por bancos</returns>
    public static DataTable ListarTiposCuentasBancos()
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuentaBanco.sp_ListarNewTiposCuentasBancos();
        return dt;
    }

    /// <summary>
    /// Inserta la información de un tipo cuenta por banco
    /// </summary>
    /// <param name="bancoIdentificador">Banco</param>
    /// <param name="tipoCuentaIdentificador">TipoCuenta</param>
    public static void InsertarTipoCuentaBanco(long? bancoIdentificador, long? tipoCuentaIdentificador)
    {
        DAOAdministrarTipoCuentaBanco.sp_InsertarNewTipoCuentaBanco(bancoIdentificador, tipoCuentaIdentificador);
    }

    /// <summary>
    /// Consulta la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo cuenta por banco</returns>
    public static DataTable ConsultarTipoCuentaBanco(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuentaBanco.sp_ConsultarNewTipoCuentaBanco(TipoCuentaBancoIdentificador);
        return dt;
    }

    /// <summary>
    /// Consulta la información de un tipo cuenta por banco por su ID para ser modificado
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el registro de tipo cuenta por banco para ser modificado</returns>
    public static DataTable ConsultarTipoCuentaBancoModificar(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuentaBanco.sp_ConsultarNewTipoCuentaBancoModificar(TipoCuentaBancoIdentificador);
        return dt;
    }

    /// <summary>
    /// Actualiza la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <param name="bancoIdentificador">Nuevo banco</param>
    /// <param name="tipoCuentaIdentificador">Nuevo tipocuenta</param>
    /// <returns>Resultado de la actualización</returns>
    public static void ModificarTipoCuentaBanco(long TipoCuentaBancoIdentificador, long? bancoIdentificador, long? tipoCuentaIdentificador)
    {
        DAOAdministrarTipoCuentaBanco.sp_ActualizarNewTipoCuentaBanco(TipoCuentaBancoIdentificador, bancoIdentificador, tipoCuentaIdentificador);
    }

    /// <summary>
    /// Elimina la información de un tipo cuenta por banco por su ID
    /// </summary>
    /// <param name="TipoCuentaBancoIdentificador">ID a buscar</param>
    /// <returns>Tabla con el resultado de la eliminación</returns>
    public static DataTable EliminarTipoCuentaBanco(long TipoCuentaBancoIdentificador)
    {
        DataTable dt = new DataTable();
        dt = DAOAdministrarTipoCuentaBanco.sp_EliminarNewTipoCuentaBanco(TipoCuentaBancoIdentificador);
        return dt;
    }
}
