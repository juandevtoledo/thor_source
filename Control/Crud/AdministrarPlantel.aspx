﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarPlantel.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarPlantel" %>

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
            max-width: 1000px !important;
            margin : 0 auto;
        }
    </style>

    <div class="container-form">
        <div class="row" id="titleAcciones" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Administrar plantel
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row limit" id="buscador" runat ="server">
            <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarId" runat="server">Id</asp:Label>
                <asp:TextBox type="" runat="server" id="txtBuscarId" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarNombre" runat="server" >Nombre</asp:Label>
                <asp:TextBox type="text" runat="server" id="txtBuscarNombre" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="Label1" runat="server" >Departamento</asp:Label>
                <asp:TextBox type="text" runat="server" id="TextBox1" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <div class="form-group">
                    <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server"  Text="Buscar" />
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar"  />
                </div>
            </div>
        </div>
        <div class="row limit" runat="server" id="tablaPlanteles">
            <!--tabla para consultar todos los planteles-->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvAdminPlantel" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminPlantel_RowCommand" OnRowDataBound="grvAdminPlantel_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminPlantel_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" ID="botonEliminar" runat="server" OnClientClick="return confirm('Esta seguro que desea eliminar este plantel?')" CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
        <!-- Registrar un plantel -->
        <div class="row" id="titleAdicionar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Adicionar plantel</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row" id="titleModificar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Modificar plantel</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="formPlantel">
            <asp:TextBox type="text" runat="server" ID="txtPlantelidentificador" Visible="false" CssClass="form-control"></asp:TextBox>
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labPlantelNombre" runat="server">Plantel</asp:Label>
                <asp:requiredfieldvalidator id="rfvNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtPlantelNombre" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
                <asp:TextBox type="text" placeholder="Plantel" runat="server" ID="txtPlantelNombre" CssClass="form-control" MaxLength="50"></asp:TextBox>   
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labDepartamentoIdentificador" runat="server">Departamento</asp:Label>
                <asp:requiredfieldvalidator id="rfvDepartamentoIdentificador" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlDepartamento" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:requiredfieldvalidator>
                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control"></asp:DropDownList>   
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
