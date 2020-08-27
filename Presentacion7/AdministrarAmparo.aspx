<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarAmparo.aspx.cs" Inherits="Control_AdministrarAmparo" %>

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
                <h3>Administrar amparos
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row limit" runat="server" id="tablaAmparos">
            <!--tabla para cosultar todas los amparos-->
        
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvAdminAmparo" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminAmparo_RowCommand" OnRowDataBound="grvAdminAmparo_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminAmparo_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" ID="botonConsultar" runat="server" CommandName="Consultar_Click" data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" ID="botonEliminar" runat="server" CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
        <!--tabla para cosultar amparos individual-->
        <div class="row" id="titleConsultar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Consultar amparo</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="tablaAmparo">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvConsultarAmparo" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20"></asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
        <!-- Registrar un amparo -->
        <div class="row" id="titleAdicionar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Adicionar amparo</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row" id="titleModificar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Modificar amparo</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="formAmparo">
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAmparoNombre" runat="server">Nombre Amparo</asp:Label>
                <asp:requiredfieldvalidator id="rfvNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtAmparoNombre" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
                <asp:TextBox type="text" runat="server" ID="txtAmparoID" Visible="false" CssClass="form-control"></asp:TextBox>
                <asp:TextBox type="text" runat="server" ID="txtAmparoNombre" CssClass="form-control" placeholder="Amparo" MaxLength="200"></asp:TextBox>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Button type="submit" ID="botonGuardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="botonInsertar" CssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="BotonCancelar" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
        <!--formulario-->
    </div>

    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

