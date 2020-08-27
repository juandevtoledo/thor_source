<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ResumenProduccionNueva.aspx.cs" Inherits="Presentacion_ResumenProduccionNueva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Planilla Pre Cargue</h2>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblAgencia" cssClass="labels" Font-Bold="true" runat="server" Text="Agencia"></asp:Label>
                <asp:DropDownList ID="ddlAgencia" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>

            </div>  
            <div class="col-md-3">
                <asp:Label ID="Label1" cssClass="labels" Font-Bold="true" runat="server" Text="Cédula"></asp:Label>
                <asp:TextBox type="number" runat="server" ID="txtcedula1" CssClass="form-control" placeholder="Documento"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label2" cssClass="labels" Font-Bold="true" runat="server" Text="Certificado"></asp:Label>
                <asp:TextBox type="number" runat="server" ID="txtCerti1" CssClass="form-control" placeholder="Certificado"></asp:TextBox>
            </div> 
           <div class="col-md-3 btn-only">
                <asp:Button ID="btnBusquedaPlanilla" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBusquedaPlanilla_Click" />
                <asp:Button ID="btnLimpiar" CssClass="btn btn-success" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>  
        </div>  
        <div class="row btn-only">
            <div class="col-md-12">
                <asp:GridView ID="grvPreCargue"  CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" OnPageIndexChanging="grvPreCargue_PageIndexChanging" PageSize="20" OnRowDataBound="grvPreCargue_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccionar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField >                                                  
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:linkButton CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-trash btnEliminar" runat="server" data-toggle="tooltip" data-placement="right" title="Eliminar este registro" OnClientClick="return confirm('¿Está seguro de eliminar este registro?')" Text=""  OnClick="btnEliminar_Click" ></asp:linkButton>
                            </ItemTemplate>
                        </asp:TemplateField >  
                    </Columns> 
                <PagerStyle CssClass="pagination-ys" />                        
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:button ID="btnEnviar" cssClass="btn btn-primary" OnClientClick="return confirm('¿Está seguro de enviar estos registros a digitación?')" runat="server" Text="Enviar a Digitación" OnClick="btnEnviar_Click"></asp:button>
                <asp:button runat="server" Cssclass="btn btn-success" id="btnImprimir" OnClick="btnDescargarExcel_Click" text="Descargar" /></div>
        </div>                 
        </div>                 
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

