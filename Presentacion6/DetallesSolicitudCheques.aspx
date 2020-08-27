<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetallesSolicitudCheques.aspx.cs" Inherits="Presentacion6_DetallesSolicitudCheques" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
      <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
            
        var host        = window.location.host;
        var protocol    = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";

        function Volver()
        {         
            parent.document.location.href = protocol + "//" + host + "/Presentacion6/PagosCompañiasAseguradoras.aspx#tabs2";
            parent.parent.GB_hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server"><ContentTemplate>
            <div>
                <asp:Label ID="lblId" runat="server" Text="" Font-Bold="true"  CssClass="labels"></asp:Label>
                <asp:GridView ID="grvDetallesSolicitudCheque" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvDetallesSolicitudCheque_PageIndexChanging">
                </asp:GridView>
                <asp:GridView ID="grvDetallesFacturacion" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvDetallesSolicitudCheque_PageIndexChanging">
                </asp:GridView>
                <asp:GridView ID="grvDetallesPagosCias" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvDetallesSolicitudCheque_PageIndexChanging">
                </asp:GridView>
                
    </div>
        </ContentTemplate></asp:UpdatePanel>
    
        <p>
            <asp:Button ID="btnExportarExcel" OnClick="btnExportarExcel_Click" cssclass="btn btn-primary" runat="server" Text="Exportar a Excel"/>                                                                                    
        </p>
    </form>
</body>
</html>
