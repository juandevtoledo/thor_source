using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DAOAdministrarPagadurias
/// </summary>
public class DAOAdministrarPagadurias
{

    static CreateLogFiles_CxBD textLog;

	
    public DAOAdministrarPagadurias()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public static DataTable sp_consultarPagadurias(int? idPaga, string numIdPaga, string nombrePaga)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarPagadurias", FrameworkEntidades.cnx);

            /*if(idPaga != -1)
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));*/

            if (idPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));

            if (String.IsNullOrEmpty(numIdPaga))
                cmd.Parameters.Add(new SqlParameter("@numIdPaga", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@numIdPaga", numIdPaga));

            if (String.IsNullOrEmpty(nombrePaga))
                cmd.Parameters.Add(new SqlParameter("@nombrePaga", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nombrePaga", nombrePaga));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static DataTable sp_MostrarDepartamento(int? idDepto, string nomDepto)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_MostrarDepartamento", FrameworkEntidades.cnx);

        //if (idDepto.HasValue)
        //    cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
        //else
        //    cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));

        //if (String.IsNullOrEmpty(nomDepto))
        //    cmd.Parameters.Add(new SqlParameter("@nomDepto", DBNull.Value));
        //else
        //    cmd.Parameters.Add(new SqlParameter("@nomDepto", nomDepto));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }


    public static DataTable sp_MostrarCiudad(int? idCiud, string nomCiudad, int? idDepto)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_MostrarCiudades", FrameworkEntidades.cnx);

        if (idCiud.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idCiudad", idCiud));            
        else
            cmd.Parameters.Add(new SqlParameter("@idCiudad", DBNull.Value));
            

        if (String.IsNullOrEmpty(nomCiudad))
            cmd.Parameters.Add(new SqlParameter("@nomCiudad", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomCiudad", nomCiudad));

        if (idDepto.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
        else
            cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }


    public static DataTable sp_ConsultarActividadEconomica(int? idActEcon, string nomActEcon)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarActividadEconomica", FrameworkEntidades.cnx);

            if (idActEcon.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idActEcon", idActEcon));                
            else
                cmd.Parameters.Add(new SqlParameter("@idActEcon", DBNull.Value));

            if (String.IsNullOrEmpty(nomActEcon))
                cmd.Parameters.Add(new SqlParameter("@nomActEcon", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomActEcon", nomActEcon));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;
        }        
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }

    public static DataTable sp_ConsultarFechaEntregaNovedades(int? idFecEntNov, string tipoFecEntNov)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarFechaEntregaNovedades", FrameworkEntidades.cnx);

            if (idFecEntNov.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idFecEntNov", idFecEntNov));
            else
                cmd.Parameters.Add(new SqlParameter("@idFecEntNov", DBNull.Value));

            if (String.IsNullOrEmpty(tipoFecEntNov))
                cmd.Parameters.Add(new SqlParameter("@tipoFecEntNov", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@tipoFecEntNov", tipoFecEntNov));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;
        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static int sp_RegistrarPagaduria(
                                                string paga_Id,
                                                string ciu_Id,
                                                string dep_Id,
                                                string act_Id,
                                                string paga_Identificacion,
                                                string paga_Nombre,
                                                string paga_Direccion,
                                                string paga_Telefono,
                                                string paga_Visacion,
                                                string paga_NumeroEmpleados,
                                                string paga_PorcentajeParticipacion,
                                                string paga_FechaEntregaNovedades,
                                                string paga_ResponsablePago,
                                                string paga_ResponsablePagoCorreo,
                                                string paga_ResponsablePagoTelefono,
                                                string paga_ResponsablePagoCelular,
                                                string paga_Contacto,
                                                string paga_ContactoCorreo,
                                                string paga_ContactoTelefono,
                                                string paga_ContactoCelular,
                                                string paga_ResponsableLegal,
                                                string paga_ResponsableLegalCorreo,
                                                string paga_ResponsableLegalTelefono,
                                                string paga_ResponsableLegalCelular,
                                                string paga_Correo,
                                                string paga_Web,
				                                string paga_ResponsablePagoFechaCumple,
				                                string paga_ContactoFechaCumple,
				                                string paga_ResponsableLegalFechaCumple,
                                                string paga_EstadoPagaduria
                                            )
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarPagaduria", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(paga_Id))
                cmd.Parameters.Add(new SqlParameter("@paga_Id", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@paga_Id", int.Parse(paga_Id)));
            
            cmd.Parameters.Add(new SqlParameter("@ciu_Id", int.Parse(ciu_Id)));
            cmd.Parameters.Add(new SqlParameter("@dep_Id", int.Parse(dep_Id)));
            cmd.Parameters.Add(new SqlParameter("@act_Id", int.Parse(act_Id)));
            cmd.Parameters.Add(new SqlParameter("@paga_Identificacion", paga_Identificacion));
            cmd.Parameters.Add(new SqlParameter("@paga_Nombre", paga_Nombre));
            cmd.Parameters.Add(new SqlParameter("@paga_Direccion", paga_Direccion));
            cmd.Parameters.Add(new SqlParameter("@paga_Telefono", paga_Telefono));
            cmd.Parameters.Add(new SqlParameter("@paga_Visacion", double.Parse(paga_Visacion)));

            if (String.IsNullOrEmpty(paga_NumeroEmpleados))
                cmd.Parameters.Add(new SqlParameter("@paga_NumeroEmpleados", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@paga_NumeroEmpleados", int.Parse(paga_NumeroEmpleados)));
            
            
            cmd.Parameters.Add(new SqlParameter("@paga_PorcentajeParticipacion", double.Parse(paga_PorcentajeParticipacion)));
            cmd.Parameters.Add(new SqlParameter("@paga_FechaEntregaNovedades", paga_FechaEntregaNovedades));
            cmd.Parameters.Add(new SqlParameter("@paga_Correo", paga_Correo));
            cmd.Parameters.Add(new SqlParameter("@paga_Web", paga_Web));
            cmd.Parameters.Add(new SqlParameter("@paga_EstadoPagaduria", int.Parse(paga_EstadoPagaduria)));

            cmd.Parameters.Add(new SqlParameter("@paga_ResponsablePago", paga_ResponsablePago));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsablePagoCorreo", paga_ResponsablePagoCorreo));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsablePagoTelefono", double.Parse(paga_ResponsablePagoTelefono)));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsablePagoCelular", double.Parse(paga_ResponsablePagoCelular)));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsablePagoFechaCumple", paga_ResponsablePagoFechaCumple));

            cmd.Parameters.Add(new SqlParameter("@paga_Contacto", paga_Contacto));
            cmd.Parameters.Add(new SqlParameter("@paga_ContactoCorreo", paga_ContactoCorreo));
            cmd.Parameters.Add(new SqlParameter("@paga_ContactoTelefono", double.Parse(paga_ContactoTelefono)));
            cmd.Parameters.Add(new SqlParameter("@paga_ContactoCelular", double.Parse(paga_ContactoCelular)));
            cmd.Parameters.Add(new SqlParameter("@paga_ContactoFechaCumple", paga_ContactoFechaCumple));

            cmd.Parameters.Add(new SqlParameter("@paga_ResponsableLegal", paga_ResponsableLegal));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsableLegalCorreo", paga_ResponsableLegalCorreo));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsableLegalTelefono", double.Parse(paga_ResponsableLegalTelefono)));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsableLegalCelular", double.Parse(paga_ResponsableLegalCelular)));
            cmd.Parameters.Add(new SqlParameter("@paga_ResponsableLegalFechaCumple", paga_ResponsableLegalFechaCumple));

    

            //ocm.Parameters.Add("RESULT", OracleType.Number).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new SqlParameter("@resIdPaga", SqlDbType.Int)).Direction = ParameterDirection.Output;
            

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int idPaga = Int32.Parse(cmd.Parameters["@resIdPaga"].Value.ToString());

            return idPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }


    public static string sp_EliminarPagaduria( int paga_Id )
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarPagadurias", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@paga_Id", paga_Id));
            cmd.Parameters.Add(new SqlParameter("@resDelPag", SqlDbType.VarChar,200)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDelPag"].Value.ToString();

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }


    public static DataTable sp_consultarArchivosSoportePagadurias( int? idSopPaga, string nomSopPaga, int? idPaga)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarArchivosSoportePagadurias", FrameworkEntidades.cnx);


            if (idSopPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idSopPaga", idSopPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopPaga", DBNull.Value));

            if (String.IsNullOrEmpty(nomSopPaga))
                cmd.Parameters.Add(new SqlParameter("@nomSopPaga", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomSopPaga", nomSopPaga));

            if (idPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static int sp_RegistrarArchivosSoportePagaduria( string idSopPaga, string idPaga, 
                                                            string nomSopPaga, string urlSopPag )
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarArchivosSoportePagadurias", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idSopPaga))
                cmd.Parameters.Add(new SqlParameter("@idSopPaga", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopPaga", int.Parse(idSopPaga)));

            cmd.Parameters.Add(new SqlParameter("@idPaga", int.Parse(idPaga)));
            cmd.Parameters.Add(new SqlParameter("@nomSopPaga", nomSopPaga));
            cmd.Parameters.Add(new SqlParameter("@urlSopPaga", urlSopPag));            
            
            cmd.Parameters.Add(new SqlParameter("@resIdSopPaga", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopPaga = Int32.Parse(cmd.Parameters["@resIdSopPaga"].Value.ToString());

            return resIdSopPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static string sp_EliminarArchivosSoportePagaduria(int idSopPag)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarArchivosSoportePagadurias", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idSopPaga", idSopPag));
            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDel"].Value.ToString();

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }


    public static DataTable sp_consultarLocalidadesPorPagadurias(int? idDepto, int? idPaga, int idTipo)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarLocalidadesPorPagaduria", FrameworkEntidades.cnx);


            if (idDepto.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));

            if (idPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));

            cmd.Parameters.Add(new SqlParameter("@idTipo", idTipo));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static int sp_RegistrarLocalidadesPorPagaduria(string idDepto, string idPaga)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarLocalidadesPorPagaduria", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idDepto))
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", int.Parse(idDepto)));

            if (String.IsNullOrEmpty(idPaga))
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));
            else            
                cmd.Parameters.Add(new SqlParameter("@idPaga", int.Parse(idPaga)));


            cmd.Parameters.Add(new SqlParameter("@resIdAdd", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopPaga = Int32.Parse(cmd.Parameters["@resIdAdd"].Value.ToString());

            return resIdSopPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static int sp_EliminarLocalidadesPorPagaduria( int? idDepto, int? idPaga, int idTipDel )
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarLocalidadesPorPagaduria", FrameworkEntidades.cnx);

            if(idDepto.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));

            if (idPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));

            
            cmd.Parameters.Add(new SqlParameter("@idTipoDel", idTipDel));

            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resDel = Int32.Parse(cmd.Parameters["@resDel"].Value.ToString());

            return resDel;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }




    public static DataTable sp_consultarConvenios(int? idConv, string codConv, string nomConv, int? idPaga)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarConvenios", FrameworkEntidades.cnx);


            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));

            if (String.IsNullOrEmpty(codConv))
                cmd.Parameters.Add(new SqlParameter("@codConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@codConv", codConv));

            if (String.IsNullOrEmpty(nomConv))
                cmd.Parameters.Add(new SqlParameter("@nomConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomConv", nomConv));

            if (idPaga.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idPaga", idPaga));
            else
                cmd.Parameters.Add(new SqlParameter("@idPaga", DBNull.Value));

            /*textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD("Params: " + idConv + " - " + codConv + " - " + nomConv + " - " + idPaga );*/

            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static int sp_RegistrarConvenio(string idConv, string idPaga,
                                            string codConv, string nomConv, string resAprob, 
                                            string fecAprob, string perPago, string Observ, string estado)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarConvenios", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idConv))
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", int.Parse(idConv)));

            cmd.Parameters.Add(new SqlParameter("@idPaga", int.Parse(idPaga)));
            cmd.Parameters.Add(new SqlParameter("@codConv", codConv));
            cmd.Parameters.Add(new SqlParameter("@nomConv", nomConv));
            cmd.Parameters.Add(new SqlParameter("@resAprobConv", resAprob));
            cmd.Parameters.Add(new SqlParameter("@fecAprobConv", fecAprob));
            cmd.Parameters.Add(new SqlParameter("@perPagoConv", perPago));
            cmd.Parameters.Add(new SqlParameter("@observConv", Observ));
            cmd.Parameters.Add(new SqlParameter("@estadoConv", int.Parse(estado)));

            cmd.Parameters.Add(new SqlParameter("@resIdConv", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopPaga = Int32.Parse(cmd.Parameters["@resIdConv"].Value.ToString());

            return resIdSopPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static string sp_EliminarConvenio(int idConv)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarConvenio", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idConv", idConv));            
            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDel"].Value.ToString();

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }


    public static DataTable sp_consultarLocalidadesPorConvenio(int? idDepto, int? idConv)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarLocalidadesPorConvenio", FrameworkEntidades.cnx);


            if (idDepto.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));

            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }

    public static int sp_RegistrarLocalidadesPorConvenio(string idDepto, string idConv)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarLocalidadesPorConvenio", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idDepto))
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", int.Parse(idDepto)));

            if (String.IsNullOrEmpty(idConv))
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", int.Parse(idConv)));


            cmd.Parameters.Add(new SqlParameter("@resIdAdd", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopPaga = Int32.Parse(cmd.Parameters["@resIdAdd"].Value.ToString());

            return resIdSopPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }


    public static int sp_EliminarLocalidadesPorConvenio(int? idDepto, int? idConv, int idTipDel)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarLocalidadesPorConvenio", FrameworkEntidades.cnx);

            if (idDepto.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idDepto", idDepto));
            else
                cmd.Parameters.Add(new SqlParameter("@idDepto", DBNull.Value));

            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));


            cmd.Parameters.Add(new SqlParameter("@idTipoDel", idTipDel));

            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resDel = Int32.Parse(cmd.Parameters["@resDel"].Value.ToString());

            return resDel;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }


    public static DataTable sp_consultarArchivosSoporteConvenio(int? idSopConv, string nomSopConv, int? idConv)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarArchivosSoporteConvenio", FrameworkEntidades.cnx);


            if (idSopConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idSopConv", idSopConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopConv", DBNull.Value));

            if (String.IsNullOrEmpty(nomSopConv))
                cmd.Parameters.Add(new SqlParameter("@nomSopConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomSopConv", nomSopConv));

            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));


            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }


    public static int sp_RegistrarArchivosSoporteConvenio(string idSopConv, string idConv,
                                                            string nomSopConv, string urlSopConv)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarArchivosSoporteConvenios", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idSopConv))
                cmd.Parameters.Add(new SqlParameter("@idSopConv", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idSopConv", int.Parse(idSopConv)));

            cmd.Parameters.Add(new SqlParameter("@idConv", int.Parse(idConv)));
            cmd.Parameters.Add(new SqlParameter("@nomSopConv", nomSopConv));
            cmd.Parameters.Add(new SqlParameter("@urlSopConv", urlSopConv));

            cmd.Parameters.Add(new SqlParameter("@resIdSopConv", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopConv = Int32.Parse(cmd.Parameters["@resIdSopConv"].Value.ToString());

            return resIdSopConv;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static string sp_EliminarArchivosSoporteConvenio(int idSopConv)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarArchivosSoporteConvenio", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idSopConv", idSopConv));
            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDel"].Value.ToString();

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }


    public static DataTable sp_ConsultarCompañias(int? idComp, string nomComp)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarCompañias", FrameworkEntidades.cnx);

        if (idComp.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
        else
            cmd.Parameters.Add(new SqlParameter("@idComp", DBNull.Value));

        if (String.IsNullOrEmpty(nomComp))
            cmd.Parameters.Add(new SqlParameter("@nomComp", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomComp", nomComp));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }


    public static DataTable sp_ConsultarProductos(int? idProd, string nomProd, int? estProd, int? idComp)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarProductos", FrameworkEntidades.cnx);

        if (idProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
        else
            cmd.Parameters.Add(new SqlParameter("@idProd", DBNull.Value));

        if (String.IsNullOrEmpty(nomProd))
            cmd.Parameters.Add(new SqlParameter("@nomProd", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomProd", nomProd));

        if (estProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@estProd", estProd));
        else
            cmd.Parameters.Add(new SqlParameter("@estProd", DBNull.Value));


        if (idComp.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
        else
            cmd.Parameters.Add(new SqlParameter("@idComp", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }



    public static DataTable sp_ConsultarProductosPorCompañia(int? idProd, string nomProd, int? estProd, int? idComp, 
                                                                string nomComp, int? idConv)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarProductosPorCompañia", FrameworkEntidades.cnx);

        if (idProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
        else
            cmd.Parameters.Add(new SqlParameter("@idProd", DBNull.Value));

        if (String.IsNullOrEmpty(nomProd))
            cmd.Parameters.Add(new SqlParameter("@nomProd", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomProd", nomProd));

        if (estProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@estProd", estProd));
        else
            cmd.Parameters.Add(new SqlParameter("@estProd", DBNull.Value));


        if (idComp.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
        else
            cmd.Parameters.Add(new SqlParameter("@idComp", DBNull.Value));

        if (String.IsNullOrEmpty(nomComp))
            cmd.Parameters.Add(new SqlParameter("@nomComp", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomComp", nomComp));


        if (idConv.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
        else
            cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }


    public static DataTable sp_ConsultarProductosPorConvenio(   int? idProd, string nomProd, int? estProd, 
                                                                int? idComp, string nomComp,
                                                                int? idConv )
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarProductosPorConvenio", FrameworkEntidades.cnx);

        if (idProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
        else
            cmd.Parameters.Add(new SqlParameter("@idProd", DBNull.Value));

        if (String.IsNullOrEmpty(nomProd))
            cmd.Parameters.Add(new SqlParameter("@nomProd", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomProd", nomProd));

        if (estProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@estProd", estProd));
        else
            cmd.Parameters.Add(new SqlParameter("@estProd", DBNull.Value));


        if (idComp.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
        else
            cmd.Parameters.Add(new SqlParameter("@idComp", DBNull.Value));

        if (String.IsNullOrEmpty(nomComp))
            cmd.Parameters.Add(new SqlParameter("@nomComp", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomComp", nomComp));


        if (idConv.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
        else
            cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }



    public static int sp_RegistrarProductosConvenio(string idConv, string idComp, string idProd)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarProductosConvenio", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idConv", int.Parse(idConv)));
            cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            cmd.Parameters.Add(new SqlParameter("@resIdProdConv", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdProdConv = Int32.Parse(cmd.Parameters["@resIdProdConv"].Value.ToString());

            return resIdProdConv;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }


    public static int sp_EliminarProductosConvenio(int? idConv, int? idComp)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("[sp_modpaga_EliminarProductosConvenio]", FrameworkEntidades.cnx);

            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));

            if (idComp.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idComp", idComp));
            else
                cmd.Parameters.Add(new SqlParameter("@idComp", DBNull.Value));


            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resDel = Int32.Parse(cmd.Parameters["@resDel"].Value.ToString());

            return resDel;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static DataTable sp_consultarArchivoNovedades(int? idArchPag, int? idPag, string nomArch, string tipArch, string tipRep)
    {

        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();

            SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarArchivosNovedades", FrameworkEntidades.cnx);


            if (idArchPag.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idArchPag", idArchPag));
            else
                cmd.Parameters.Add(new SqlParameter("@idArchPag", DBNull.Value));

            if (idPag.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pagId", idPag));
            else
                cmd.Parameters.Add(new SqlParameter("@pagId", DBNull.Value));
            
            
            if (String.IsNullOrEmpty(nomArch))
                cmd.Parameters.Add(new SqlParameter("@nomArch", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@nomArch", nomArch));

            if (String.IsNullOrEmpty(tipArch))
                cmd.Parameters.Add(new SqlParameter("@tipArch", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@tipArch", tipArch));


            if (String.IsNullOrEmpty(tipRep))
                cmd.Parameters.Add(new SqlParameter("@tipRep", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@tipRep", tipRep));
            

            /*textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD("Params: " + idConv + " - " + codConv + " - " + nomConv + " - " + idPaga );*/

            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            FrameworkEntidades.cnx.Close();

            return dt;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return null;
        }

    }



    public static int sp_RegistrarArchivoNovedades(string idArchPag, string idPaga, string nomArchPag, string tipArch, string tipRep,
                                            string valor, string retiros, int cueBan_Id)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarArchivosNovedades", FrameworkEntidades.cnx);


            if (String.IsNullOrEmpty(idArchPag))
                cmd.Parameters.Add(new SqlParameter("@idArchPag", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@idArchPag", int.Parse(idArchPag)));

            cmd.Parameters.Add(new SqlParameter("@idPag", int.Parse(idPaga)));
            cmd.Parameters.Add(new SqlParameter("@nomArchPag", nomArchPag));
            cmd.Parameters.Add(new SqlParameter("@tipArchivo", tipArch));
            cmd.Parameters.Add(new SqlParameter("@tipReporte", tipRep));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));
            cmd.Parameters.Add(new SqlParameter("@retiros", retiros));
            cmd.Parameters.Add(new SqlParameter("@resIdArchPag", SqlDbType.Int)).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@cueBan_Id", cueBan_Id));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdSopPaga = Int32.Parse(cmd.Parameters["@resIdArchPag"].Value.ToString());

            return resIdSopPaga;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }



    public static string sp_EliminarArchivoNovedades(int idArchNov)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarArchivoNovedades", FrameworkEntidades.cnx);

            cmd.Parameters.Add(new SqlParameter("@idArchNov", idArchNov));
            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            return cmd.Parameters["@resDel"].Value.ToString();

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return "Ha Ocurrido un error durante su petición actual. Por favor intentelo nuevamente";
        }

    }





    public static DataTable sp_ConsultarConveniosArchivosNovedades(int? idProd, string nomProd, string nomComp,
                                                                int? idConv, string codConv, string nomConv, 
                                                                int? idArchNov)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarConveniosArchivosNovedades", FrameworkEntidades.cnx);

        if (idProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
        else
            cmd.Parameters.Add(new SqlParameter("@idProd", DBNull.Value));

        if (String.IsNullOrEmpty(nomProd))
            cmd.Parameters.Add(new SqlParameter("@nomProd", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomProd", nomProd));
        

        if (String.IsNullOrEmpty(nomComp))
            cmd.Parameters.Add(new SqlParameter("@nomComp", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomComp", nomComp));


        if (idConv.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
        else
            cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));
        

        if (String.IsNullOrEmpty(codConv))
            cmd.Parameters.Add(new SqlParameter("@codConv", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@codConv", codConv));


        if (String.IsNullOrEmpty(nomConv))
            cmd.Parameters.Add(new SqlParameter("@nomConv", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomConv", nomConv));


        if (idArchNov.HasValue)
            cmd.Parameters.Add(new SqlParameter("@arcPagId", idArchNov));
        else
            cmd.Parameters.Add(new SqlParameter("@arcPagId", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }



    public static DataTable sp_ConsultarProductosConfigArchivosNovedades(int? idProd, string nomProd, string nomComp,
                                                                int? idConv, int? idArchNov)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
        FrameworkEntidades.cnx.Open();

        SqlCommand cmd = new SqlCommand("sp_modpaga_ConsultarProductosConfigArchivosNovedades", FrameworkEntidades.cnx);

        if (idProd.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));
        else
            cmd.Parameters.Add(new SqlParameter("@idProd", DBNull.Value));

        if (String.IsNullOrEmpty(nomProd))
            cmd.Parameters.Add(new SqlParameter("@nomProd", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomProd", nomProd));


        if (String.IsNullOrEmpty(nomComp))
            cmd.Parameters.Add(new SqlParameter("@nomComp", DBNull.Value));
        else
            cmd.Parameters.Add(new SqlParameter("@nomComp", nomComp));


        if (idConv.HasValue)
            cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
        else
            cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));

        
        if (idArchNov.HasValue)
            cmd.Parameters.Add(new SqlParameter("@arcPagId", idArchNov));
        else
            cmd.Parameters.Add(new SqlParameter("@arcPagId", DBNull.Value));


        cmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        FrameworkEntidades.cnx.Close();

        return dt;

    }



    public static int sp_RegistrarProductosConfigArchivosNovedades(string idArchPag, string idConv, string idProd)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_RegistrarProductosConfigArchivosNovedades", FrameworkEntidades.cnx);


            cmd.Parameters.Add(new SqlParameter("@idArchPag", idArchPag));
            cmd.Parameters.Add(new SqlParameter("@idConv", int.Parse(idConv)));            
            cmd.Parameters.Add(new SqlParameter("@idProd", idProd));

            cmd.Parameters.Add(new SqlParameter("@resIdArchPag", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resIdProdConv = Int32.Parse(cmd.Parameters["@resIdArchPag"].Value.ToString());

            return resIdProdConv;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }


    public static int sp_EliminarProductosConfigArchivosNovedades(int? idConv, int? idArchNov)
    {

        try
        {

            FrameworkEntidades.cnx = new SqlConnection(FrameworkEntidades.Conexion("ConexionBD"));
            FrameworkEntidades.cnx.Open();
            SqlCommand cmd = new SqlCommand("sp_modpaga_EliminarProductosConfigArchivosNovedades", FrameworkEntidades.cnx);

            if (idConv.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idConv", idConv));
            else
                cmd.Parameters.Add(new SqlParameter("@idConv", DBNull.Value));

            if (idArchNov.HasValue)
                cmd.Parameters.Add(new SqlParameter("@idArchNov", idArchNov));
            else
                cmd.Parameters.Add(new SqlParameter("@idArchNov", DBNull.Value));


            cmd.Parameters.Add(new SqlParameter("@resDel", SqlDbType.Int)).Direction = ParameterDirection.Output;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            FrameworkEntidades.cnx.Close();

            int resDel = Int32.Parse(cmd.Parameters["@resDel"].Value.ToString());

            return resDel;

        }
        catch (Exception ex)
        {
            textLog = new CreateLogFiles_CxBD();
            textLog.AddlogCxBD(ex.ToString());
            return -1;
        }

    }






}