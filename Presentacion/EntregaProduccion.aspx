<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  EnableEventValidation="false"  AutoEventWireup="true" CodeFile="EntregaProduccion.aspx.cs" Inherits="Presentacion_EntregaProduccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<script src="../Scripts/jquery-1.11.2.min.js"></script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="container-form">
      <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2>Digitación de producción</h2>
            <div class="title-divider"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <label>Agencia</label>
            <asp:DropDownList ID="ddlagenciaProduccion" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CargarBusquedaAgencia"></asp:DropDownList>                
        </div>
        <div class="col-md-2">
            <label>Compañía</label>
            <asp:DropDownList ID="ddlCompa" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CargarBusquedaCompañia"></asp:DropDownList>                
        </div>
        <div class="col-md-2">
            <label for="dp1">Producto</label>
            <asp:DropDownList runat="server" type="date" ID="ddlProducto" AutoPostBack="true" OnSelectedIndexChanged="CargarBusquedaProducto" CssClass="form-control" ></asp:DropDownList>
        </div>
        <div class="col-md-2">
                <label for="exampleInputEmail1">Cédula</label>
                <asp:TextBox type="number" runat="server" ID="txtcedulaProduccion" CssClass="form-control" placeholder="Documento" OnTextChanged="CargarBusquedaTercero" ></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label for="exampleInputEmail1">Número Certificado</label>
            <asp:TextBox type="number" runat="server" ID="txtnumeroCertificadoProduccion" CssClass="form-control" placeholder="Certificado" OnTextChanged="CargarBusquedaPoliza" ></asp:TextBox>
        </div>
        <div class="col-md-2 btn-only">
            <asp:Button ID="btnBusquedaPlanilla" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBusquedaPlanilla_Click" />
            <asp:Button ID="btnLimpiar" CssClass="btn btn-success" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </div>
    </div>
    <div class="row btn-only">
        <div class="col-md-12">
            <asp:GridView ID="grvEntregaProduccion" CssClass="table table-bordered table-hover table-striped"  runat="server" OnRowCommand="grvEntregaProduccion_RowCommand" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvEntregaProduccion_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:linkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" title="Digitar Certificado" CommandName="Digitar_Click"  id="btnDigitar" CssClass="btn btn-success btn-xs glyphicon glyphicon-thumbs-up" />
                            <asp:linkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" title="Enviar a Devolución" CommandName="Devolucion_Click"  CssClass="btn btn-danger btn-xs glyphicon glyphicon-thumbs-down" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                 <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>
    <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblPolizaDevolucion" runat="server" Text="Póliza"  cssClass="labels" Font-Bold="true" ></asp:Label>
                <asp:TextBox ID="txtNumeroPolizaDevolucion" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqtxtNumeroPolizaDevolucion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNumeroPolizaDevolucion"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblCedulaProduccion" runat="server" Text="Cédula"  cssClass="labels" Font-Bold="true" ></asp:Label>
                <asp:TextBox ID="txtCedulaDevolucion" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqtxtCedulaDevolucion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtCedulaDevolucion"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblPrima" runat="server" Text="Prima Total" cssClass="labels" Font-Bold="true" ></asp:Label>
                <asp:TextBox ID="txtPrima" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqtxtPrima" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPrima"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblTipoDevolucion" runat="server" Text="Tipo Devolución" cssClass="labels" Font-Bold="true" ></asp:Label>
                <asp:DropDownList ID="ddlTipoDevolucion" AutoPostBack="true" OnSelectedIndexChanged="cargarCausales" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqddlTipoDevolucion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlTipoDevolucion"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
        </div>
    <div class="row btn-only">
        <div class="col-md-6">
            <asp:Label ID="lblCausalDevolucion" runat="server" Text="Causal Devolución" cssClass="labels" Font-Bold="true" ></asp:Label>
            <asp:DropDownList ID="ddlCausalDevolucion" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqddlCausalDevolucion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlCausalDevolucion"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"  cssClass="labels" Font-Bold="true" ></asp:Label>
            <asp:TextBox  ID="txtObservaciones" CssClass="form-control" runat="server"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="reqtxtObservaciones" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtObservaciones"  ValidationGroup="grpValidacionPlanillaDevolucion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div> 
    <div class="row btn-only">
            <asp:Button ID="btnRecetear" CssClass="btn btn-sucess" runat="server" Text="Limpiar" onClick="LimpiarDevolucion_Click" />
                <div class="col-md-1">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>       
                            <asp:Button ID="btnConfirmar" cssclass="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Confimar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content" id="contenedor">
                            <div class="modal-header"><h4>CONFIRMACIÓN</h4></></div>
                            <div class="modal-body">      
                                <h5>¿Está seguro de enviar este registro como devolución?</h5>                                                                                                                          
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCerrarmodal" CssClass="btn btn-danger" data-dismiss="modal" runat="server" Text="Cerrar" />  
                                <asp:Button ID="btnConfirmarDevolucion" CssClass="btn btn-primary" runat="server" Text="Confirmar" OnClick="EnviarDevolucion_Click" ValidationGroup="grpValidacionPlanillaDevolucion" />      
                            </div>                    
                        </div>
                    </div>
                </div>
            </div>
        </div> 
        <div class="row btn-only">
            <div class="col-md-1">
            <asp:Button type="button" runat="server" class="btn btn-success" id="btnImprimir" Text="Descargar" OnClick="btnDescargarExcel_Click" />
            </div>  
        </div>  
    </div>  
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>


