<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CargarExcel.aspx.cs" Inherits="Presentacion2_CargarExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">
        <div class="col-md-4"></div>
            <div class="col-md-4">
                <h3>Cargar Pagos</h3>
            </div>
        <div class="col-md-4"></div>
    </div>
        <hr />
    <asp:Label ID="lblCompañia" runat="server" Text="Compañia"></asp:Label><br />
    <asp:DropDownList ID="ddlCompañia" runat="server" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label><br />
    <asp:DropDownList ID="ddlProducto" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad"></asp:Label><br />
    <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblPagaduria" runat="server" Text="Pagaduria"></asp:Label><br />
    <asp:DropDownList ID="ddlPagaduria" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblConvenio" runat="server" Text="Convenio"></asp:Label><br />
    <asp:DropDownList ID="ddlConvenio" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblAño" runat="server" Text="Año de"></asp:Label><br />
    <asp:DropDownList ID="ddlAño" runat="server"></asp:DropDownList><br />
    <asp:Label ID="lblMes" runat="server" Text="Mes de"></asp:Label><br />
    <asp:DropDownList ID="ddlMes" runat="server"></asp:DropDownList>
    <hr />
    

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <hr />
    <asp:Button ID="btnCargarDatos" runat="server" Text="Cargar datos" OnClick="btnCargarDatos_Click" />
    <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
    <hr />
    <asp:GridView ID="grvExcel" runat="server"></asp:GridView>
</asp:Content>