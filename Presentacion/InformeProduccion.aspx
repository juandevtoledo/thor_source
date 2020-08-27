<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeProduccion.aspx.cs" Inherits="Presentacion_InformeProduccion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Informe de producción</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row">
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblAgencia" cssClass="labels" Font-Bold="true" Text="Agencia"></asp:Label>
                <asp:DropDownList ID="ddlAgencia" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlAgencia_SelectedIndexChanged"></asp:DropDownList>
            </div>  
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblLocalidad" cssClass="labels" Font-Bold="true" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="ddlLocalidad" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
            </div>  
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblAsesor" cssClass="labels" Font-Bold="true" Text="Asesor"></asp:Label>
                <asp:DropDownList ID="ddlAsesor" AutoPostBack="true"  CssClass="ddl" runat="server" ></asp:DropDownList>
            </div>  
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblEstadoNegocio" cssClass="labels" Font-Bold="true" Text="Estado Negocio"></asp:Label>
                <asp:DropDownList ID="ddlEstadoNegocio" AutoPostBack="true"  CssClass="ddl" runat="server" ></asp:DropDownList>
            </div>  
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblAnioProduccion" cssClass="labels" Font-Bold="true" Text="Año Producción"></asp:Label>
                <asp:DropDownList ID="ddlAnioProduccion" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlAnioProduccion_SelectedIndexChanged"></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblMesProduccion" cssClass="labels" Font-Bold="true" Text="Mes Producción"></asp:Label>
                <asp:DropDownList ID="ddlMesProduccion" AutoPostBack="true"  CssClass="ddl" runat="server"></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblCompañia" cssClass="labels" Font-Bold="true" Text="Compañía"></asp:Label>
                <asp:DropDownList ID="ddlCompania" AutoPostBack="true"  CssClass="ddl" runat="server"></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblProducto" cssClass="labels" Font-Bold="true" Text="Producto"></asp:Label>
                <asp:DropDownList ID="ddlProducto" AutoPostBack="true"  CssClass="ddl" runat="server" ></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblPagaduria" cssClass="labels" Font-Bold="true" Text="Pagaduría"></asp:Label>
                <asp:DropDownList ID="ddlPagaduria" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged"></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblConvenio" cssClass="labels" Font-Bold="true" Text="Convenio"></asp:Label>
                <asp:DropDownList ID="ddlConvenio" AutoPostBack="true"  CssClass="ddl" runat="server" ></asp:DropDownList>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblFechaExpedicionDesde" cssClass="labels" Font-Bold="true" Text="Fecha de expedición desde"></asp:Label>
                <asp:TextBox ID="txtFechaExpedicionDesde" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
            </div> 
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label runat="server" ID="lblFechaExpedicionHasta" cssClass="labels" Font-Bold="true" Text="Fecha de expedición hasta"></asp:Label>
                <asp:TextBox ID="txtFechaExpedicionHasta" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
            </div> 
            <div class="col col-lg-12 col-md-12 col-sm-12">
                <asp:Button ID="btnDescargar" CssClass="btn btn-primary " runat="server" Text="Descargar" OnClick="btnDescargar_Click" />
                <asp:Button ID="btnLimpiar" CssClass="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>
        </div>
   </div>
</asp:Content>

