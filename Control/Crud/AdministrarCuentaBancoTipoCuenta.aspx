<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarCuentaBancoTipoCuenta.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarCuentaBancoTipoCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Administrar Cuenta Banco Tipo Cuenta</h3>
    <br />
    <div class="row margenFormularios" runat="server" id="tablaCuentasBancosTiposCuentas">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="botonAdicionar" OnClick="btnAdicionar_Click" Text="Adicionar"></asp:Button>

        </div>

        <!--tabla para consultar todas las cuentas bancarias por bancos por tipos de cuentas-->
        <div class="col-md-10">
            <asp:GridView ID="grvAdminCuentaBancoTipoCuenta" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminCuentaBancoTipoCuenta_RowCommand" OnRowDataBound="grvAdminCuentaBancoTipoCuenta_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminCuentaBancoTipoCuenta_PageIndexChanging">
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
    <!--tabla para consultar una cuenta bancaria por banco por tipo de cuenta-->
    <div class="row margenFormularios" runat="server" id="tablaCuentaBancoTipoCuenta">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="grvConsultarCuentaBancoTipoCuenta" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20">
            </asp:GridView>
        </div>
    </div>
    <!-- Registrar una cuenta bancaria por banco por tipo de cuenta -->
    <div class="col-md-1"></div>
    <div class="col-md-8" runat="server" id="formCuentaBancoTipoCuenta">
        <asp:TextBox type="text" runat="server" ID="txtCuentaBancoTipoIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labBancoIdentifcador" runat="server">Banco</asp:Label>
            <asp:requiredfieldvalidator id="rfvBancoIdentifcador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlBanco" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
            <asp:DropDownList runat="server" ID="ddlBanco" CssClass="form-control"></asp:DropDownList>
            
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTipoCuentaIdentificador" runat="server">Tipo Cuenta</asp:Label>
            <asp:requiredfieldvalidator id="rfvTipoCuentaIdentificador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlTipoCuenta" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
            <asp:DropDownList runat="server" ID="ddlTipoCuenta" CssClass="form-control"></asp:DropDownList>
            
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCuentaBancariaIdentificador" runat="server">Cuenta</asp:Label>
            <asp:requiredfieldvalidator id="rfvCuentaBancariaIdentificador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlCuenta"  ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
            <asp:DropDownList runat="server" ID="ddlCuenta" CssClass="form-control"></asp:DropDownList>
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
