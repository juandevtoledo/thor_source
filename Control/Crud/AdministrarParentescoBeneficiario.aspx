<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarParentescoBeneficiario.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarParentescoBeneficiario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Administrar Parentesco Beneficiario</h3>
    <br />
    <div class="row margenFormularios" runat="server" id="tablaParentescoBeneficiarios">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="botonAdicionar" OnClick="btnAdicionar_Click" Text="Adicionar"></asp:Button>

        </div>

        <!--tabla para consultar todos los parentescos beneficiarios-->
        <div class="col-md-10">
            <asp:GridView ID="grvAdminParentescoBeneficiario" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminParentescoBeneficiario_RowCommand" OnRowDataBound="grvAdminParentescoBeneficiario_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminParentescoBeneficiario_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success glyphicon glyphicon glyphicon-search" ID="botonConsultar" runat="server" CommandName="Consultar_Click" data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success glyphicon glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove" ID="botonEliminar" runat="server" CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <!--tabla para consultar un parentesco beneficiario-->
    <div class="row margenFormularios" runat="server" id="tablaParentescoBeneficiario">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="grvConsultarParentescoBeneficiario" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20">
            </asp:GridView>
        </div>
    </div>
    <!-- Registrar un parentesco beneficiario -->
    <div class="col-md-1"></div>
    <div class="col-md-8" runat="server" id="formParentescoBeneficiario">
        <asp:TextBox type="text" runat="server" ID="txtParentescoProductoIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labParentescoIdentificador" runat="server">Parentesco</asp:Label>
            <asp:requiredfieldvalidator id="rfvParentescoIdentificador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlParentesco" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
            <asp:DropDownList runat="server" ID="ddlParentesco" CssClass="form-control"></asp:DropDownList>
            
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labProductorIdentificador" runat="server">Producto</asp:Label>
            <asp:requiredfieldvalidator id="rfvProductorIdentificador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlProducto" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control"></asp:DropDownList>
            
        </div>
        <div class="col-md-10 form-group">
            <asp:Button type="submit" ID="botonGuardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
            <asp:Button type="submit" ID="botonInsertar" CssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" Text="Guardar"></asp:Button>
            <asp:Button type="submit" ID="BotonCancelar" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
    </div>
    <!--formulario-->

    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>
