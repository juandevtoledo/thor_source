<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarAsesor.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarAsesor" %>

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
            max-width: 1200px;
            margin : 0 auto;
        }

        .list-limit
        {
            max-width: 428px;
        }
        .list-limitLocal
        {
            max-width: 500px;
        }
    </style>

    <div class="container-form">

        <div class="row" id="titleAcciones" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Administrar asesores
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row limit" id="buscador" runat ="server">
                <div class="col col-lg-1 col-md-1 col-sm-1 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarCodigo" runat="server">Código</asp:Label>
                    <asp:TextBox type="" runat="server" id="txtBuscarCodigo" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="LblBuscarNombre" runat="server" >Nombre</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarNombre" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarLocalidad" runat="server" >Localidad</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarLocalidad" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarEstado" runat="server" >Activo</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarEstado" cssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>

        <div class="row limit" runat="server" id="tablaAsesores">

            <!--tabla para consultar todos los asesores-->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvAdminAsesor" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminAsesor_RowCommand" OnRowDataBound="grvAdminAsesor_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminAsesor_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-search"  ID="btnConsultar" runat="server" CommandName="Consultar_Click" data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="btnModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-warning btn-xs glyphicon glyphicon-plus" ID="btnAsignarProducto" runat="server" CommandName="AsignarProducto_Click" data-toggle="tooltip" title="Asignar producto"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-info btn-xs glyphicon glyphicon-ok" ID="btnAsignarLocalidad" runat="server" CommandName="AsignarLocalidad_Click" data-toggle="tooltip" title="Asignar localidad"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove"  ID="btnEliminar" OnClientClick="return confirm('Esta seguro que desea eliminar este asesor?')" runat="server" CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
        <!--tabla para consultar un asesor-->
        <div class="row"  id="titleConsultar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Consultar asesor</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row" runat="server" id="tablaAsesor">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvConsultarAsesor" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20"></asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
        <!-- Registrar un asesor -->
        <div class="row"  id="titleModificar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Modificar asesor</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row"  id="titleAdicionar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Adicionar asesor</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="formAsesor">
            <asp:TextBox type="text" runat="server" ID="txtAsesorIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
            <div class="col-lg-6 col-md-6 col-sm-6  form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAsesorNombres" runat="server">Nombres Asesor</asp:Label>
                <asp:requiredfieldvalidator id="rfvAsesorNombres" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtAsesorNombres" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
                <asp:TextBox type="text" placeholder="Nombres Asesor" runat="server" ID="txtAsesorNombres" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAsesorApellidos" runat="server">Apellidos Asesor</asp:Label>
                <asp:requiredfieldvalidator id="rfvAsesorApellidos" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtAsesorApellidos" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
                <asp:TextBox type="text" placeholder="Apellidos Asesor" runat="server" ID="txtAsesorApellidos" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6  form-group">
                <asp:Label CssClass="labels" Font-old="true" ID="labAsesorCodigo" runat="server">Código Asesor</asp:Label>
                <asp:RegularExpressionValidator ID="revAsesorCodigo" runat="server" ControlToValidate="txtAsesorCodigo" Display="Dynamic" ErrorMessage="[ Este campo sólo permite números ]" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:TextBox type="text" placeholder="Código Asesor" runat="server" ID="txtAsesorCodigo" CssClass="form-control" MaxLength="12"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labDepartamentoIdentificador" runat="server">Departamento</asp:Label>
                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labCompañiaIdentificador" runat="server">Compañía</asp:Label>
                <asp:DropDownList runat="server" ID="ddlCompania" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAsesorActivo" runat="server">Estado Asesor</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlAsesorActivo" runat="server">
                    <asp:ListItem Value="">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="SI">ACTIVO</asp:ListItem>
                    <asp:ListItem Value="NO">CANCELADO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAsesorFuncionario" runat="server">Es Funcionario</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlAsesorFuncionario" runat="server">
                    <asp:ListItem Value="">SELECCIONE</asp:ListItem>
                    <asp:ListItem Value="SI">SI</asp:ListItem>
                    <asp:ListItem Value="NO">NO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Button type="submit" ID="botonGuardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="botonInsertar" CssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="BotonCancelar" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
        <!--formulario-->

        <!--Asignar productos-->
        <div class="row" id="titleAsignarProductos" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Asignar productos</h3>
                <div class="title-divider"></div>
            </div>
         </div>

        <div class="row limit" id="divProductos" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h4><asp:Label ID="lblAsesor" runat="server" cssClass="labels" Text=""></asp:Label></h4>
                <div class="title-space"></div>
            </div>
            <div class="col col-lg-5 col col-md-5 col col-sm-5 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="lblCompañia" runat="server">Compañía</asp:Label>
                <asp:DropDownList ID="ddlCompañia" CssClass="ddl2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col col-lg-5 col col-md-5 col col-sm-5 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" ID="lblProducto" runat="server" >Producto:</asp:Label>
                <asp:DropDownList ID="ddlProducto" CssClass="ddl2" runat="server"></asp:DropDownList>
            </div>
            <div class="col col-lg-2 col col-md-2 col col-sm-2 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="Label1"  runat="server" ></asp:Label><br />
                <asp:LinkButton type="submit" id="btnAsignarPro" cssClass="btn btn-primary" runat="server"  OnClick="btnAsignarPro_Click"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
            </div>
            <div class="col col-lg-12 col col-md-12 col col-sm-12">
                <asp:ListView runat="server" id="listProductos" OnItemCommand="listProductos_ItemCommand">
                    <ItemTemplate>
                        <div class="panel panel-default list-limit">
                            <div class="panel-body">
                                <asp:Label Text='<%# Bind("Producto") %>' ID="lblProdcuto" runat="server" />
                                <asp:LinkButton CommandArgument='<%# Bind("pro_Id") %>' id="btnEliminarProducto"  cssClass="btn btn-danger glyphicon glyphicon glyphicon-remove pull-right btn-xs" runat="server" CommandName="btnEliminarPro_Click" OnClientClick="return confirm('Esta seguro que desea eliminar este producto?')"  />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="col col-lg-12 col col-md-12 col col-sm-12">
                <asp:button type="submit" id="btnSalirAsignacion" cssClass="btn btn-danger" runat="server"  OnClick="btnSalir_Click" text="Salir"></asp:button>
            </div>
        </div>
        <!--Asignar productos-->

        <!--Asignar localidades-->
        <div class="row"  id="titleAsignarLocalidad" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Asignar localidades</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" id="divLocalidades" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h4><asp:Label ID="lblAsesorlocali" runat="server" cssClass="labels" Text=""></asp:Label></h4>
                <div class="title-space"></div>
            </div>
            <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" ID="lblLocalidad" runat="server" >Localidad:</asp:Label>
                <asp:DropDownList ID="ddlLocalidad" CssClass="ddl2" runat="server"></asp:DropDownList>
            </div>
            <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="Label5"  runat="server" ></asp:Label><br />
                <asp:LinkButton type="submit" id="btnAsignarlocali" cssClass="btn btn-primary" runat="server"  OnClick="btnAsignarlocali_Click"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
            </div>
            <div class="col col-lg-12 col col-md-12 col col-sm-12">
                <asp:ListView runat="server" id="listLocalidades" OnItemCommand="listLocalidades_ItemCommand">
                    <ItemTemplate>
                        <div class="panel panel-default list-limitLocal">
                            <div class="panel-body">
                                <asp:Label Text='<%# Bind("dep_Nombre") %>' ID="lblNombre" runat="server" />
                                <asp:LinkButton CommandArgument='<%# Bind("dep_Id") %>' id="btnEliminarLocali"  cssClass="btn btn-danger glyphicon glyphicon glyphicon-remove pull-right btn-xs" runat="server" CommandName="btnEliminarLocali_Click" OnClientClick="return confirm('Esta seguro que desea eliminar este botón?')"  />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="col col-lg-12 col col-md-12 col col-sm-12">
                <asp:button type="submit" id="Button1" cssClass="btn btn-danger" runat="server"  OnClick="btnSalir_Click" text="Salir"></asp:button>
            </div>
        </div>

        <!--Asignar localidades-->

    </div>
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>