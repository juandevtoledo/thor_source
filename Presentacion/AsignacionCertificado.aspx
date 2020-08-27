<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AsignacionCertificado.aspx.cs" Inherits="Presentacion_AsignacionCertificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .limite{
            max-width: 1200px !important;
            margin : 0 auto;
        }
        .title-space{
            margin-top: 20px !important;
            margin-bottom: 20px !important;
        }
        .panel-body {
            padding: 10px;
        }
        .activar{
            font: 12px verdana;
            color: #f60632;
        }
    </style>
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Asignación certificado Liberty vigilantes</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row" runat="server" id="bucador">
            <div class="col-lg-6 col-md-6 col-sm-6" >
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
                <asp:TextBox Type="number" runat="server" ID="txtDocumento" CssClass="form-control" placeholder="Ingresar Documento"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 btn-only">
                <asp:Button CssClass="btn btn-primary" runat="server" Text="Buscar"  OnClick="btnBuscar_Click" />
            </div>
        </div>
        <div class="row"  id="formMostrar" runat="Server">
            <div class="col-lg-3 col-md-3 col-sm-3  form-group">
                <asp:Label ID="lblNumeroCertificado" runat="server" Font-Bold="true" CssClass="labels" Text="Numero Certificado"></asp:Label>
                <asp:TextBox runat="server" ID="txtCertificado" CssClass="form-control" placeholder="Ingresar Certificado"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCerId" Visible="false"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3  form-group">
                <asp:Label ID="lblCompania" runat="server" Font-Bold="true" CssClass="labels" Text="Compañia"></asp:Label>
                <asp:TextBox Enabled="false" runat="server" ID="txtCompania" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3  form-group">
                <asp:Label ID="lblProducto" runat="server" Font-Bold="true" CssClass="labels" Text="Producto"></asp:Label>
                <asp:TextBox runat="server" Enabled="false" ID="txtProducto" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblFechaExpedicion" runat="server" Font-Bold="true" CssClass="labels" Text="Fecha Expedición"></asp:Label>
                <asp:TextBox Enabled="false" runat="server" type="date" ID="txtFechaExpedicionCertificado" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblFechaVigencia" runat="server" Text="Fecha Vigencia" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" runat="server" Type="date" ID="txtFechaVigenciaCertificado" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblFechaDigitacion" runat="server" Font-Bold="true" CssClass="labels" Text="Fecha Digitación"></asp:Label>
                <asp:TextBox Enabled="false" runat="server" Type="date" ID="txtFechaDigitacionCertificado" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblNombreAsesor" runat="server" Text="Nombre Asesor" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox  Enabled="false" ID="txtNombreAsesor" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" ID="txtLocalidadCertificado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblPoliza" runat="server" Font-Bold="true" CssClass="labels" Text="Poliza"></asp:Label>
                <asp:TextBox  Enabled="false" ID="txtPoliza" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblAgencia" runat="server" Text="Agencia" Font-Bold="true" CssClass="labels DigitarCertificadoAgencia"></asp:Label>
                <asp:TextBox Enabled="false" ID="txtAgencia" CssClass="form-control DigitarCertificadoAgencia" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblMesProduccion" runat="server" Text="Mes Produccion" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" ID="txtMesProduccion" CssClass="form-control" runat="server" placeholder="DD/MM/AAAA"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblEstadoNegocio" runat="server" Text="Estado Negocio" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" ID="txtEstadoNegocio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblDeclaracionAsegurabilidad" runat="server" Text="Declaración asegurabilidad" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" type="number" ID="txtDeclaracionAsegurado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblPrima" runat="server" Text="Prima" Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" runat="server" ID="txtPrima" CssClass="form-control" placeholder=""></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label ID="lblTipoMovimiento" runat="server" Text="Tipo Movimiento"  Font-Bold="true" CssClass="labels"></asp:Label>
                <asp:TextBox Enabled="false" ID="txtTipoMovimiento"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:button type="submit" id="botonAsignar" cssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" text="Guardar"></asp:button>
                <asp:button type="submit" id="botonAtras" cssClass="btn btn-danger" runat="server" OnClick="btnAtras_Click" text="Atras"></asp:button>
            </div>
        </div>
    </div>

    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

