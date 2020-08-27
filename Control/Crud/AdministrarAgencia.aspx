<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarAgencia.aspx.cs" Inherits="Presentacion_CRUDS_AdministrarAgencia" %>

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
                <h3>Administrar agencias
                    <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                </h3>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row limit" id="buscador" runat ="server">
            <div class="col col-lg-1 col-md-1 col-sm-1 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarCodigo" runat="server">Id</asp:Label>
                <asp:TextBox type="" runat="server" id="txtBuscarCodigo" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="LblBuscarNombre" runat="server" >Nombre</asp:Label>
                <asp:TextBox type="text" runat="server" id="txtBuscarNombre" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarDireccion" runat="server" >Dirección</asp:Label>
                <asp:TextBox type="text" runat="server" id="txtBuscarDireccion" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarTelefono" runat="server" >Teléfono</asp:Label>
                <asp:TextBox type="text" runat="server" id="txtBuscarTelefono" cssClass="form-control"></asp:TextBox>
            </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                <div class="form-group">
                    <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" OnClick="btnBuscar_Click" runat="server" Text="Buscar"  />
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" OnClick="btnLimpiar_Click" runat="server" Text="Limpiar"  />
                </div>
            </div>
        </div>

        <div class="row limit" runat="server" id="tablaAgencias">
        <!--tabla para consultar todas las agencias-->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvAdminAgencia" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminAgencia_RowCommand" OnRowDataBound="grvAdminAgencia_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminAgencia_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" ID="botonConsultar" runat="server" CommandName="Consultar_Click" data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" ID="botonModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-info btn-xs glyphicon glyphicon-ok" ID="btnAsignarLocalidad" runat="server" CommandName="AsignarLocalidad_Click" data-toggle="tooltip" title="Asignar localidad"></asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove"  ID="botonEliminar" runat="server" CommandName="Eliminar_Click"  OnClientClick="return confirm('Esta seguro que desea eliminar esta agencia?')" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>

         <div class="row"  id="titleConsultar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Consultar agencia</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <!--tabla para consultar una agencia-->
        <div class="row limit" runat="server" id="tablaAgencia">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvConsultarAgencia" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20"> </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Button type="submit" class="btn btn-danger" runat="server" ID="botonAtras" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
        <!-- Registrar una agencia -->
        <div class="row"  id="titleModificar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Modificar agencia</h3>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row"  id="titleAdicionar" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Adicionar agencia</h3>
                <div class="title-divider"></div>
            </div>
        </div>
        <div class="row limit" runat="server" id="formAgencia">
            
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAgenciaNombre" runat="server">Nombre Agencia</asp:Label>
                <asp:requiredfieldvalidator id="rfvAgenciaNombre" runat="server" ToolTip="Ver error al final de la página" Display="Dynamic" ControlToValidate="txtAgenciaNombre" ForeColor="Red" ErrorMessage="[ Diligencie el campo ]"></asp:requiredfieldvalidator>
                <asp:TextBox type="text" placeholder="Nombre Agencia" runat="server" ID="txtAgenciaNombre" CssClass="form-control" MaxLength="50"></asp:TextBox>
                <asp:TextBox type="text" runat="server" ID="txtAgenciaIdentificador" Visible="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAgenciaDireccion" runat="server">Dirección Agencia</asp:Label>
                <asp:TextBox type="text" placeholder="Dirección Agencia" runat="server" ID="txtAgenciaDireccion" CssClass="form-control" MaxLength="200"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAgenciaTelefono" runat="server">Teléfono Agencia</asp:Label>
                <asp:TextBox type="text" placeholder="Teléfono Agencia" runat="server" ID="txtAgenciaTelefono" CssClass="form-control" MaxLength="200"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAgenciaEmail" runat="server">Email Agencia</asp:Label>
                <asp:RegularExpressionValidator ID="revAgenciaEmail" runat="server" ControlToValidate="txtAgenciaEmail" ErrorMessage="[Dato no válido]" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox type="text" placeholder="Email Agencia" runat="server" ID="txtAgenciaEmail" CssClass="form-control" MaxLength="200"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labAgenciaDirector" runat="server">Director Agencia</asp:Label>
                <asp:TextBox type="text" placeholder="Director Agencia" runat="server" ID="txtAgenciaDirector" CssClass="form-control" MaxLength="200"></asp:TextBox>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labDepartamentoIdentificador" runat="server">Departamento</asp:Label>
                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 form-group">
                <asp:Label CssClass="labels" Font-Bold="true" ID="labCiudadIdentificador" runat="server">Ciudad</asp:Label>
                <asp:DropDownList runat="server" ID="ddlCiudad" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 form-group">
                <asp:Button type="submit" ID="btnGuardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="btnInsertar" CssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" Text="Guardar"></asp:Button>
                <asp:Button type="submit" ID="btnSalir" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="btnSalir_Click" Text="Atrás"></asp:Button>
            </div>
        </div>
    <!--formulario-->

         <!--Asignar productos-->
        <div class="row" id="titleAsignarLocalidades" runat ="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Asignar localidades</h3>
                <div class="title-divider"></div>
            </div>
         </div>

        <div class="row limit" id="divLocalidades" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h4><asp:Label ID="lblAgencia" runat="server" cssClass="labels" Text=""></asp:Label></h4>
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
                <asp:ListView runat="server" id="listLocalidades" OnItemCommand="listLocalidades_ItemCommand" >
                    <ItemTemplate>
                        <div class="panel panel-default list-limitLocal">
                            <div class="panel-body">
                                <asp:Label Text='<%# Bind("dep_Nombre") %>' ID="lblProdcuto" runat="server" />
                                <asp:LinkButton CommandArgument='<%# Bind("dep_Id") %>' id="btnEliminarLocalidad"  cssClass="btn btn-danger glyphicon glyphicon glyphicon-remove pull-right btn-xs" runat="server" CommandName="btnEliminarLocalidad_Click" OnClientClick="return confirm('Esta seguro que desea eliminar esta localidad?')"  />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="col col-lg-12 col col-md-12 col col-sm-12">
                <asp:button type="submit" id="btnSalirAsignacion" cssClass="btn btn-danger" runat="server"  OnClick="btnSalir_Click" text="Salir"></asp:button>
            </div>
        </div>
   </div>

    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>