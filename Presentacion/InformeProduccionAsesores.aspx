<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeProduccionAsesores.aspx.cs" Inherits="Presentacion_InformeProduccionAsesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Informe de producción asesores</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4">
                <label><asp:CheckBox ID="chkPorAsesor" runat="server" />Informe por asesor</label>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <label><asp:CheckBox ID="chkNomina" runat="server" />Informe de nómina</label>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <label><asp:CheckBox ID="chkgeneral" runat="server" />Informe balance general</label>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                <asp:Label runat="server" ID="lblFechaProduccion" cssClass="labels" Font-Bold="true" Text="Fecha de producción"></asp:Label>
                <asp:TextBox ID="txtFechaProduccion" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
            </div> 
            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                <asp:Label runat="server" ID="lblAgencia" cssClass="labels" Font-Bold="true" Text="Agencia"></asp:Label>
                <asp:DropDownList ID="ddlAgencia" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlAgencia_SelectedIndexChanged"></asp:DropDownList>
            </div>  
            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                <asp:Label runat="server" ID="lblLocalidad" cssClass="labels" Font-Bold="true" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="ddlLocalidad" CssClass="ddl" runat="server" ></asp:DropDownList>
            </div>  
            <div class="col col-lg-12 col-md-12 col-sm-12">
                <asp:Button ID="btnDescargar" CssClass="btn btn-primary " runat="server" Text="Descargar" OnClick="btnDescargar_Click"/>
                <asp:Button ID="btnLimpiar" CssClass="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>
        </div>
    </div>
</asp:Content>