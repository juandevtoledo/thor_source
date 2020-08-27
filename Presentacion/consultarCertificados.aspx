<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="consultarCertificados.aspx.cs" Inherits="Presentacion_consultarCertificados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Consultar certificados</h2>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row btn-only">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Font-Bold="true"  CssClass="labels" ></asp:Label>
                <asp:Label ID="lblNombreSession" runat="server" Text="Label" Font-Bold="true"  CssClass="labels"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:Label ID="lblDocumento" runat="server" Text="Documento:" Font-Bold="true"  CssClass="labels"></asp:Label>
                <asp:Label ID="lblDocumentoSession" runat="server" Text="Label" Font-Bold="true"  CssClass="labels"></asp:Label>
            </div>
        </div>
        <div class="row btn-only">
            <div class="col-lg-4 col-md-4 col-sm-4">
                <asp:Label ID="lblCompania" runat="server" Font-Bold="true"  CssClass="labels" Text="Compañía"></asp:Label>
                <asp:DropDownList ID="ddlCompania" CssClass="ddl" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="CargarProducto"></asp:DropDownList>
            </div>   
            <div class="col-lg-4 col-md-4 col-sm-4">
                <asp:Label ID="lblProducto" runat="server" Font-Bold="true"  CssClass="labels" Text="Producto"></asp:Label>
                <asp:DropDownList ID="ddlProducto" AutoPostBack="true" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlProductoSeleccionar"></asp:DropDownList>
            </div>
        </div>      
        <div class="row btn-only">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvResumenProducto" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvResumenProducto_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:linkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" data-placement="right" title="Consultar Certificado" CommandName="Consultar_Click"  CssClass="btn btn-primary btn-xs glyphicon glyphicon-search btnListaSop" ID="btno" />
                                <asp:linkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-warning btn-xs glyphicon glyphicon-comment btnListaSop" id="btnObservacion"  CommandName="Observacion_Click" data-toggle="tooltip" title="Observaciónes"></asp:linkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>  
        <div class="row" id="divObservaciones" runat="server">
             <div class="col-lg-12 col-md-12 col-sm-12">
                <h4>Observaciones Certificado</h4>
                <div class="title-divider"></div>
            </div>
            <div class="col-lg-7 col-md-7 col-sm-7">
                <asp:GridView ID="grvObservaciones" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True"  PageSize="35">
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>  
            <div class="col-lg-7 col-md-7 col-sm-7">
                <asp:Label runat="server" ID="lblObservacion" cssClass="labels" Font-Bold="true" Text="Observación"></asp:Label>
                <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTextObservacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtObservacion" ForeColor="Red" SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                <asp:Button ID="btnGuardarObservacion" CssClass="btn btn-primary  btn-only" runat="server" Text="Guardar" OnClick="btnGuardarObservacion_Click" ValidationGroup="g"/>
                <asp:Button ID="btnRegresar" CssClass="btn btn-warning  btn-only" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
            </div>
        </div> 
    </div>
        <script src="../scripts/jquery-1.11.2.min.js"></script>
        <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>


