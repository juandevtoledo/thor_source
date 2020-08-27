<%@ Application Language="C#" %>

<script runat="server">
    public int run_app = 0;
    
    void Application_Start(object sender, EventArgs e)
    {
        
        //Session["run_app"] = 0;
        //RegisterRoutes(System.Web.Routing.RouteTable.Routes); 
    }

    /*
    void Application_BeginRequest(Object source, EventArgs e)
    {
        HttpApplication app = (HttpApplication)source;
        HttpContext context = app.Context;

        run_app = run_app + 1;
        string host = FirstRequestInitialisation.Initialise(context);
        if (run_app == 1)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes, host); 
        } 
    }

    class FirstRequestInitialisation
    {
        private static string host = null;

        private static Object s_lock = new Object();

        // Initialise only on the first request
        public static string Initialise(HttpContext context)
        {
            if (string.IsNullOrEmpty(host))
            {
                lock (s_lock)
                {
                    if (string.IsNullOrEmpty(host))
                    {
                        Uri uri = HttpContext.Current.Request.Url;
                        //host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                        host = uri.Host + ":" + uri.Port;
                    }
                }
            }

            return host;
        }
    }
    */


    void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        
        routes.MapPageRoute("thor",
        "", "~/login.aspx");

        routes.MapPageRoute("thorlogueado",
        "escritorio", "~/Presentacion/IndexPrincipal.aspx");
        
        routes.MapPageRoute("precargue",
        "gestion/polizas/precargue", "~/Presentacion/ProduccionNueva.aspx");

        routes.MapPageRoute("gestionartercero",
        "gestion/polizas/gestiontercero", "~/Presentacion/GestionarTercero.aspx");

        routes.MapPageRoute("resumenCertificado",
        "gestion/polizas/certificados/resumen", "~/Presentacion/ResumenCertificado.aspx");

        routes.MapPageRoute("modificarCertificado",
        "gestion/polizas/certificados/modificar", "~/Presentacion/ModificarCertificado.aspx");

        routes.MapPageRoute("resumen",
        "gestion/polizas/certificados", "~/Presentacion/consultarCertificados.aspx");

        routes.MapPageRoute("digitarCertificado",
        "gestion/polizas/certificados/digitar", "~/Presentacion/DigitarCertificado.aspx");

        routes.MapPageRoute("cuentaCobro",
        "recaudoypago/cuentascobro", "~/Presentacion2/CuentasCobro.aspx");
        
        routes.MapPageRoute("imprimirCuentaCobro",
        "recaudoypago/cuentascobro/imprimir", "~/Presentacion2/ImprimirCuentaCobro.aspx");
        
        // Soporte bancario
        routes.MapPageRoute("soporteBancario2",
         "recaudoypago/soportebancario", "~/Presentacion2/SoporteBancario2.aspx");
    }
    

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
  {
      Exception ex = Server.GetLastError();
      string error = ex.Message;
        // Código que se ejecuta cuando se produce un error sin procesar
     
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión
        Session["flag"] = "1";
        Session["CedulaDevolucion"] = null;
        Session["IdDevolucion"] = null;
        Session["cedulaTemp"] = null;
    }

    void Session_End(object sender, EventArgs e)
    {
        Session["CedulaDevolucion"] = null;
        Session["IdDevolucion"] = null;
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.

    }

</script>