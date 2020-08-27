<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarTomador.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarTomador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Administrar Tomador</h3>
    <br />
    <div class="row margenFormularios" runat="server" id="tablaTomadores">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-primary" runat="server" ID="botonAdicionar" OnClick="btnAdicionar_Click" Text="Adicionar"></asp:Button>

        </div>

        <!--tabla para consultar todos los tomadores-->
        <div class="col-md-10">
            <asp:GridView ID="grvAdminTomador" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminTomador_RowCommand" OnRowDataBound="grvAdminTomador_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminTomador_PageIndexChanging">
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
    <!--tabla para consultar un tomador-->
    <div class="row margenFormularios" runat="server" id="tablaTomador">
        <div class="col-md-1">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="grvConsultarTomador" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20">
            </asp:GridView>
        </div>
    </div>
    <!-- Registrar un tomador -->
    <div class="col-md-1"></div>
    <div class="col-md-8" runat="server" id="formTomador">
        <asp:TextBox type="text" runat="server" ID="txtTomadorIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorIdentificacion" runat="server">Identificación</asp:Label>
            <asp:requiredfieldvalidator id="rfvTomadorIdentificacion" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtTomadorIdentificacion" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
            <asp:RegularExpressionValidator ID="revTomadorIdentificacion" ControlToValidate="txtTomadorIdentificacion" runat="server" ForeColor="Red" ErrorMessage="[ Este campo sólo permite números ]" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <asp:TextBox type="text" runat="server" ID="txtTomadorIdentificacion" CssClass="form-control" placeholder="Identificación Tomador" MaxLength="18"></asp:TextBox>      
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorNombre" runat="server">Nombre Tomador</asp:Label>
            <asp:requiredfieldvalidator id="rfvTomadorNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtTomadorNombre" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
            <asp:TextBox type="text" runat="server" ID="txtTomadorNombre" CssClass="form-control" placeholder="Nombre Tomador" MaxLength="50"></asp:TextBox>
            
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorDireccion" runat="server">Dirección Tomador</asp:Label>
            <asp:TextBox type="text" runat="server" ID="txtTomadorDireccion" CssClass="form-control" placeholder="Dirección Tomador" MaxLength="50"></asp:TextBox>
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorTelefono" runat="server">Teléfono Tomador</asp:Label>
            <asp:TextBox type="text" runat="server" ID="txtTomadorTelefono" CssClass="form-control" placeholder="Teléfono Tomador" MaxLength="50"></asp:TextBox>
        </div>
        <div class="col-md-6 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labTomadorRepresentanteLegal" runat="server">Representante Legal</asp:Label>
            <asp:TextBox type="text" runat="server" ID="txtTomadorRepresentanteLegal" CssClass="form-control" placeholder="Representante Legal" MaxLength="50"></asp:TextBox>
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
