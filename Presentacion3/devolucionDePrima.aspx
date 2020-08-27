<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="devolucionDePrima.aspx.cs" Inherits="Presentacion3_devolucionDePrima" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="spmAjax" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2>Identificar devolución</h2>
            <div class="title-divider"></div>
        </div>
    </div>
             <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="alert alert-info">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            Ingrese el número de cédula para validar las posibles devoluciones
                    </div>
                 </div>
            </div>

            <div class="row">
                  <div class="col-lg-3 col-md-6 col-sm-12">
                     <asp:Label ID="lblNumeroDocumento" Font-Bold="true"   CssClass="labels" runat="server" Text="Documento" placeholder="Ingresar Documento"></asp:Label>
                     <asp:TextBox type="number" ID="txtCedula" CssClass="form-control" runat="server" ></asp:TextBox>
                 </div>
                  <div class="col-lg-3 col-md-6 col-sm-12">
                    <asp:Button ID="btnBuscar" cssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                 </div>
             </div>

             <div class="row btn-only">
                     <div class="col-lg-4 col-md-4 col-sm-4">
                        <asp:Label ID="lblCpmpania" Font-Bold="true"  CssClass="labels" runat="server" Text="Compañía"></asp:Label>
                        <asp:DropDownList ID="ddlCompania" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <asp:Label ID="lblProducto" Font-Bold="true"   CssClass="labels" runat="server" Text="Producto"></asp:Label>
                        <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged"></asp:DropDownList>
                     </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <asp:Label ID="lblConvenio" Font-Bold="true"   CssClass="labels" runat="server" Text="Convenio"></asp:Label>
                        <asp:DropDownList ID="ddlConvenio" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConvenio_SelectedIndexChanged"></asp:DropDownList>
                    </div>
            </div>
  <div class="row btn-only">
        <div class="col-lg-12 col-md-12 col-sm-12">
           <asp:GridView ID="grvDevolucionesDePrima" CssClass="table table-bordered table-hover table-striped" runat="server">
                    <Columns>
                       <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccionar"  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' AutoPostBack="true" runat="server" CommandName="Digitar_Click" OnCheckedChanged="chkSeleccionar_OnCheckedChanged" />
                            </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3">
                <asp:Label ID="lblValorDevolucion" Font-Bold="true"   CssClass="labels" runat="server" Text="Valor Devolucion"></asp:Label>
                <asp:TextBox  ID="txtValorDevolucion" CssClass="form-control" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="row btn-only">
        <div class="col-lg-4 col-md-4 col-sm-4">
            <asp:Button ID="btnRealizarAplicacion" cssClass="btn btn-primary" OnClientClick="return confirm('¿Está seguro de enviar estos registros como una devolución?')" runat="server" Text="Devolver" OnClick="btnRealizarAplicacion_Click"/>
            <asp:Button ID="btnGuardarDevolucion" cssClass="btn btn-primary" OnClientClick="return confirm('¿Está seguro de enviar estos registros como una devolución?')" runat="server" Text="Guardar Devolucion" OnClick="btnGuardarDevolucion_Click"  />
            <asp:Button ID="btnExportarExcelDp" cssClass="btn btn-success" runat="server" Text="Descargar" OnClick="btnExportarExcelDp_Click"  />
        </div>
    </div>
<div class="col-lg-12 col-md-12 col-sm-12">  
    <asp:UpdatePanel ID="udpProgres" runat="server">
        <ContentTemplate>
             <asp:UpdateProgress ID="uppProgress" runat="server"  OnLoad="Page_Load">
                            <ProgressTemplate>
                               <div class="contenedor-loader">
                                    <div class='loader'>
                                        <h6><p style="text-align:center"><b>Realizando la consulta, por favor espere...</b></p></h6>
                                    </div>
                                </div>
</div>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


