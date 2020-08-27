<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarCuentaBancaria.aspx.cs" Inherits="Control_AdministrarCuentaBancaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Administar Cuenta Bancaria</h3>
    <br />
    <div class="row margenFormularios" runat="server" id="tablaCuentasBancarias">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="botonAdicionar" OnClick="btnAdicionar_Click" Text="Adicionar"></asp:Button>

        </div>

        <div class="col-md-10">
            <asp:GridView ID="grvAdminCuentaBancaria" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminCuentaBancaria_RowCommand" OnRowDataBound="grvAdminCuentaBancaria_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminCuentaBancaria_PageIndexChanging">
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
    <div class="row margenFormularios" runat="server" id="tablaCuentaBancaria">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="grvConsultarCompania" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20">
            </asp:GridView>
        </div>
    </div>
    <div class="col-md-1"></div>
    <div class="col-md-8" runat="server" id="formCuentaBancaria">
        <div class=" col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="lbblcuentaBancaria" runat="server">Número Cuenta</asp:Label>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtCuentaBancariaNumero" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCuentaBancariaNumero" runat="server" ForeColor="Red" ErrorMessage="[ Este campo sólo permite números ]" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <asp:TextBox type="text" runat="server" ID="txtCuentaBancariaID" Visible="false" CssClass="form-control"></asp:TextBox>
            <asp:TextBox type="text" runat="server" ID="txtCuentaBancariaNumero" CssClass="form-control" placeholder="Número Cuenta" MaxLength="18"></asp:TextBox>
            
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

