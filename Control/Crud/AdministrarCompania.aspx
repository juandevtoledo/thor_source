<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarCompania.aspx.cs" Inherits="Control_AdministrarCompania" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .limit
        {
            max-width: 1100px !important;
            margin : 0 auto;
        }
    </style>

    <div class="container-form">
        <div class="row" id="titleAcciones" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Administrar compañías
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

    <div class="row limit" runat="server" id="tablaCompanias">
        <!--tabla para cosultar todas la compañias-->
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:GridView ID="grvAdminCompania" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminCompania_RowCommand" OnRowDataBound="grvAdminCompania_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminCompania_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" ID="botonConsultar" runat="server" CommandName="Consultar_Click" data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                            <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" ID="botonEliminar" runat="server" CommandName="Eliminar_Click" OnClientClick="return confirm('Esta seguro que desea eliminar esta compañía?')" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>
    <!--tabla para cosultar compañia individual-->
    <div class="row" id="titleConsultar" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h3>Consultar compañía</h3>
            <div class="title-divider"></div>
        </div>
    </div>
    <div class="row limit" runat="server" id="tablaCompania">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:GridView ID="grvConsultarCompania" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20"></asp:GridView>
        </div>
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
    </div>
    <!-- Registrar una compañia -->
    <div class="row" id="titleAdicionar" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h3>Adicionar compañía</h3>
            <div class="title-divider"></div>
        </div>
    </div>
    <div class="row" id="titleModificar" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h3>Modificar compañía</h3>
            <div class="title-divider"></div>
        </div>
    </div>
    <div class="row limit" runat="server" id="formCompania">
        <div class="col-lg-12 col-md-12 col-sm-12 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCompaniaNombre" runat="server">Nombre Compañía</asp:Label>
            <asp:requiredfieldvalidator id="rfvNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtCompaniaNombre" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]" ></asp:requiredfieldvalidator>
            <asp:TextBox type="text" runat="server" ID="txtCompaniaID" Visible="false" CssClass="form-control"></asp:TextBox>
            <asp:TextBox type="text" runat="server" ID="txtCompaniaNombre" CssClass="form-control" placeholder="Nombre Compañía" MaxLength="50"></asp:TextBox>
            
        </div>
        <div class="col-lg-12 col-md-12 col-sm-12 form-group">
            <asp:Button type="submit" ID="botonGuardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
            <asp:Button type="submit" ID="botonInsertar" CssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" Text="Guardar"></asp:Button>
            <asp:Button type="submit" ID="BotonCancelar" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
        </div>
    </div>
    </div>
    <!--formulario-->

    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

