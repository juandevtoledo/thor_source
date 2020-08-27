<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReciboCaja.aspx.cs" Inherits="Presentacion2_ReciboCaja" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="panel-heading panel-primary">
            <div class="row container " id="tituloPagina"  >        
                    <div class="col-md-7">
                        <h3 class="panel-title"> <strong> IMPRESION RECIBO </strong> 
                            <br />
                            <small> <em>&nbsp;  <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label> </em> </small>  
                        </h3>                                    
                    </div>
                    <div class="col-md-1"> </div>
                    <div class="col-md-1" >
                        <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info" 
                            CausesValidation="false" formnovalidate="form1"
                            Text="Volver a Recibos" PostBackUrl="~/Presentacion2/Conciliacion.aspx#irConvenios" >
                            <span class="glyphicon glyphicon-th-list "></span>
                            <strong> &nbsp; Recibos </strong>
                        </asp:LinkButton>
                    </div>
               <div class="col-md-1"> </div>
            </div>                    
         </div> 
         <div class="col-md-1"></div>
         <div class="col-md-10">
            <rsweb:ReportViewer ID="rvReporte" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" SizeToReportContent="True">
            </rsweb:ReportViewer>
         </div>
    </div>
    </form>
</body>
</html>
