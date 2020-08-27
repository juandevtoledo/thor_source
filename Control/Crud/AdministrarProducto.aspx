<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarProducto.aspx.cs" Inherits="Control_AdministrarProducto" %>

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
            max-width: 1150px !important;
            margin : 0 auto;
        }
    </style>

    <div class="container-form">
        <div class="row" id="titleAcciones" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Administrar productos
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

         <div class="row" id="buscador" runat ="server">
                <div class="col col-lg-1 col-md-1 col-sm-1 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarId" runat="server">Id</asp:Label>
                    <asp:TextBox type="" runat="server" id="txtBuscarId" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="LblBuscarCompania" runat="server" >Compañía</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarCompania" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarProducto" runat="server" >Producto</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarProducto" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarEstado" runat="server" >Estado</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarEstado" cssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>

        <div class="row" runat="server" id="tablaProductos">
            <!--tabla para cosultar todas los productos-->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvAdminProducto" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminProducto_RowCommand" OnRowDataBound="grvAdminProducto_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminProducto_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" ID="botonEliminar" runat="server" OnClientClick="return confirm('Esta seguro que desea eliminar este producto?')" CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>

        <!-- Registrar una compañia -->
        <div class="row" id="titleAdicionar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Adicionar producto</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row" id="titleModificar" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Modificar producto</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="formProducto">
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblCompania" runat="server">Compañia</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="ddlCompania" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:DropDownList CssClass="form-control" ID="ddlCompania" runat="server"></asp:DropDownList>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblProducto" runat="server">Nombre Producto</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtProductoNombre" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtProductoID" Visible="false" CssClass="form-control"></asp:TextBox>
                <asp:TextBox type="text" runat="server" ID="txtProductoNombre" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblMesesGraciasProducto" runat="server">Meses Gracia</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtMesesGraciaProducto" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtMesesGraciaProducto" CssClass="form-control" MaxLength="12"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblCumulo" runat="server">Cumulo</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtMesesGraciaProducto" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtCumulo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblMesesRecuperacion" runat="server">Meses de Recuperación</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtMesesRecuperacion" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtMesesRecuperacion" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblPrioridadPago" runat="server">Prioridad pago</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtPrioridadPago" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtPrioridadPago" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblPrioridadDevolucion" runat="server">Prioridad devolución</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtPrioridadPago" ForeColor="Red" ErrorMessage="[ Seleccione el campo ]"></asp:RequiredFieldValidator>
                <asp:TextBox type="text" runat="server" ID="txtPrioridadDevolucion" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblEstadoProducto" runat="server">Estado Producto</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlEstadoProducto" runat="server">
                    <asp:ListItem Value="">Seleccione</asp:ListItem>
                    <asp:ListItem Value="1">ACTIVO</asp:ListItem>
                    <asp:ListItem Value="0">INACTIVO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
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

