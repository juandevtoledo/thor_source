<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImpresionConvenio.aspx.cs" Inherits="Presentacion4_ImpresionConvenio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="panel-heading panel-primary">

                    <div class="row container " id="tituloPagina"  >        


                            <div class="col-md-7">
                                <h3 class="panel-title"> <strong> IMPRESION CONVENIO </strong> 
                                    <br />
                                    <small> <em>&nbsp;  <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label> </em> </small>  
                                </h3>                                    
                            </div>

                        <div class="col-md-1"> </div>

                            <div class="col-md-1" >

                                <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info" 
                                            CausesValidation="false" formnovalidate="form1"
                                            Text="Volver a Convenios" PostBackUrl="~/Presentacion4/ConveniosPagaduria.aspx#irConvenios" >
                                            <span class="glyphicon glyphicon-th-list "></span>
                                                <strong> &nbsp; Convenio </strong>
                                        </asp:LinkButton>

                            </div>

                            <div class="col-md-1"> </div>

                            <div class="col-md-1">


                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info" 
                                    CausesValidation="false" formnovalidate="form1"
                                    Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/Pagadurias.aspx" >
                                    <span class="glyphicon glyphicon-hand-left"></span>
                                    <strong> &nbsp; Pagadurias </strong>
                                </asp:LinkButton>

                            </div>


                    </div>                    

            </div> 
     <div class="col-md-1">
        <br />
         <asp:ListBox ID="lbxPagadurias" runat="server" SelectionMode="Single" AutoPostBack="True" OnSelectedIndexChanged="lbxPagadurias_SelectedIndexChanged"></asp:ListBox>
        <br />   

  
        <br />
         <asp:ListBox ID="lbxConvenio" runat="server" SelectionMode="Single"></asp:ListBox>
        <br />
        <asp:Button type="submit" ID="btnGenerarReporte" CssClass="btn btn-primary" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click"></asp:Button>

    </div>
    <div class="col-md-10">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="600px" Width="800px" HorizontalAlign="Center" >
            <rsweb:ReportViewer ID="rvReporte" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" SizeToReportContent="true" >
            </rsweb:ReportViewer>
        </asp:Panel>
    </div>

</asp:Content>


