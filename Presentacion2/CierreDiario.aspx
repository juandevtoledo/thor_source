<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CierreDiario.aspx.cs" Inherits="Presentacion2_CierreDiario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager> 
    
<div class="container-form">

            <div class="tab-content">
                 <h2 class="impre">Cierre Diario</h2>
                    <div class="title-divider impre"></div>
            <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">                        
                        <asp:Label ID="lblAgencia" runat="server" CssClass="labels" Font-Bold="true" Text="Agencia"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="ddlAgencia" runat="server"></asp:DropDownList>
                    </div> 
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">
                        <asp:Label ID="lblCompañia" runat="server" CssClass="labels" Font-Bold="true" Text="Compañía"></asp:Label>
                        <asp:DropDownList CssClass="form-control"  ID="ddlCompañia" runat="server" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">
                        <asp:Label ID="lblProducto" runat="server" CssClass="labels" Font-Bold="true" Text="Producto"></asp:Label>
                        <asp:DropDownList CssClass="form-control"  ID="ddlProducto" runat="server"></asp:DropDownList>
                    </div>                              
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">
                        <asp:Label ID="lblFechaInicio" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Inicio"></asp:Label>
                        <asp:TextBox ID="txtFechaInicioRecibos"  CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqFechaInicioRecibos" runat="server" ControlToValidate="txtFechaInicioRecibos" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpFechasCierre"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">
                        <asp:Label ID="lblFechaFin" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Fin"></asp:Label>
                        <asp:TextBox ID="txtFechaFinRecibos"  CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqFechaFinRecibos" runat="server" ControlToValidate="txtFechaFinRecibos" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpFechasCierre"></asp:RequiredFieldValidator>
                    </div>   
                    <div class="col-lg-2 col-md-2 col-sm-2 form-group">
                        <asp:Button ID="btnConsultarRecibos" runat="server" Text="Buscar" cssclass="btn btn-primary btn-only" OnClick="btnConsultarRecibos_Click" ValidationGroup="grpFechasCierre" />
                        <asp:Button ID="btnExportarExcelCierre" runat="server" cssclass="btn btn-success btn-only" Text="Descargar" OnClick="btnExportarExcelCierre_Click"/>
                    </div>  
            </div>  
            <div class="row">             
                <div class="col-lg-12 col-md-12 col-sm-12" id="recibosCaja" runat="server">
                    <asp:GridView ID="grvRecibosCaja" runat="server" CssClass="table table-bordered table-hover table-striped" OnRowDataBound="grvRecibosCaja_RowDataBound" AllowPaging="True" PageSize="30"  OnPageIndexChanging="grvRecibosCaja_PageIndexChanging" >
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>   
        </div> 
    </div>                     
</asp:Content>

