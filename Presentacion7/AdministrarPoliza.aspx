<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarPoliza.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarPoliza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Administrar Póliza</h3>
    <br />
    <div class="row margenFormularios" runat="server" id="tablaPolizas">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="botonAdicionar" OnClick="btnAdicionar_Click" Text="Adicionar"></asp:Button>

        </div>

        <!--tabla para consultar todas las polizas-->
        <div class="col-md-10">
            <asp:GridView ID="grvAdminPoliza" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminPoliza_RowCommand" OnRowDataBound="grvAdminPoliza_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminPoliza_PageIndexChanging">
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
    <!--tabla para consultar una poliza-->
    <div class="row margenFormularios" runat="server" id="tablaPoliza">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="grvConsultarPoliza" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20">
            </asp:GridView>
        </div>
    </div>
    <!-- Registrar una poliza -->
    <div class="col-md-1"></div>
    <div class="col-md-8" runat="server" id="formPoliza">
        <asp:TextBox type="text" runat="server" ID="txtPolizaIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labpolizaNumero" runat="server">Número Póliza</asp:Label>
            <asp:RequiredFieldValidator ID="rfvpolizaNumero" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtPolizaNumero" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" ControlToValidate="txtPolizaNumero" runat="server" ForeColor="Red" ErrorMessage="[ Este campo sólo permite números ]" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <asp:TextBox type="text" placeholder="" runat="server" ID="txtPolizaNumero" CssClass="form-control" MaxLength="18"></asp:TextBox>

        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labProductoIdentificador" runat="server">Producto</asp:Label>
            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorIdentificador" runat="server">Tomador</asp:Label>
            <asp:DropDownList runat="server" ID="ddlTomador" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labPolizaTipo" runat="server">Tipo Póliza</asp:Label>
            <asp:RegularExpressionValidator  ID="revPolizaTipo" ControlToValidate="txtPolizaTipo" runat="server" ForeColor="Red" ErrorMessage="[ Este campo sólo permite números ]" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <asp:TextBox type="text" placeholder="" runat="server" ID="txtPolizaTipo" CssClass="form-control" MaxLength="18"></asp:TextBox>
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
