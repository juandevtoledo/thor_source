<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarMenu.aspx.cs" Inherits="Control_AdministrarMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div runat="server" id="divAcciones">
            <div class="row">
               <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>
                        Administrar Menú
                        <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                    </h3>
                    <div class="title-divider"></div>
                </div>
            </div>

            <div class="row limit">
                <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarMenu" runat="server">Menú</asp:Label>
                    <asp:TextBox type="" runat="server" id="txtBuscarMenu" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarDependencia" runat="server" >Dependencia</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarDependencia" cssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary botonBuscarRetiro btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-success botonLimpiarRetiro btn-only" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>

            <div class="row limit">            
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:GridView ID="grvAdminMenu" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvAdminMenu_RowCommand" OnRowDataBound="grvAdminMenu_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminMenu_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-pencil" ID="btnModificar" runat="server" CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:LinkButton>
                                    <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-success btn-xs glyphicon glyphicon-ok" ID="btnAsignar" runat="server" CommandName="Asignar_Click" data-toggle="tooltip" title="Asignar"></asp:LinkButton>
                                    <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" ID="btnEliminar" runat="server" CommandName="Eliminar_Click" OnClientClick="return confirm('Esta seguro que desea eliminar este menú?')" data-toggle="tooltip" title="Eliminar" ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </div>

        
        <!--formulario para insertar menu-->
        <div runat="server" id="divFormulario">
            <div class="row" id="titleAdicionar" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Adicionar menu</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row" id="titleModificar" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Modificar menu</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row limit">
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels"  Font-Bold="true" id="labNombre" runat="server">Menu</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtNombre" cssClass="form-control" placeholder="Ingrese el nombre" ></asp:TextBox>
                    <asp:TextBox type="text" runat="server" id="txtmen_Id" Visible="false"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblDependencia" runat="server" >Dependencia</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" ID="ddlDependencia" runat="server" ></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblEnlnace" runat="server" >Enlace</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtEnlace" cssClass="form-control" placeholder="Ingrese el enlace"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" runat="server" >Alias</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtAlias" cssClass="form-control" placeholder="Ingrese el alias para el menu"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col col-md-6 col col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" runat="server" >Ruta</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtRuta" cssClass="form-control" placeholder="Ingrese la ruta que quiere que aparezca"></asp:TextBox>
                </div>
                <div class="col col-lg-12 col col-md-12 col col-sm-12">
                    <asp:button type="submit" id="btnInsertar" cssClass="btn btn-primary" runat="server"  OnClick="btnInsertar_Click" text="Guardar"></asp:button>
                    <asp:button type="submit" id="btnGuardar" cssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" text="Guardar"></asp:button>
                    <asp:button type="submit" id="btnSalir" cssClass="btn btn-danger" runat="server"  OnClick="btnSalir_Click" text="Salir"></asp:button>
                </div>
            </div><!--formulario-->
        </div>


        <!--formulario para asignar botones a un formulario-->
        <div runat="server" id="divAsignar">
            <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Asignar botones</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row limit" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h4><asp:Label ID="lblMenu" runat="server" cssClass="labels" Text=""></asp:Label></h4>
                    <div class="title-space"></div>
                </div>
                <div class="col col-lg-3 col col-md-3 col col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblNombreBtn" runat="server" >Nombre botón:</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtNombreBtn" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col col-md-3 col col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblIdBtn" runat="server" >Id botón:</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtIdBtn" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col col-md-3 col col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblIdPadre" runat="server" >Id padre:</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtIdPadre" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col col-md-3 col col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" runat="server" ></asp:Label><br />
                    <asp:LinkButton type="submit" id="btnAsignarBtn" cssClass="btn btn-primary" runat="server"  OnClick="btnAsignarBtn_Click" text=""><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                </div>
                <div class="col col-lg-12 col col-md-12 col col-sm-12">
                    <asp:ListView runat="server" id="ltv" OnItemCommand="listView_OnItemCommand">
                        <ItemTemplate>
                            <div class="panel panel-default list-limit">
                              <div class="panel-body">
                                  <asp:Label Text='<%# Bind("btn_Nombre") %>' ID="lblNombre" runat="server" />
                                  <asp:LinkButton CommandArgument='<%# Bind("btn_Id") %>' id="btnEliminarBtn"  cssClass="btn btn-danger glyphicon glyphicon glyphicon-remove pull-right btn-xs" runat="server" CommandName="EliminarBtn_Click" OnClientClick="return confirm('Esta seguro que desea eliminar este botón?')"  />
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
    </div>

   

     <script src="../scripts/jquery-1.11.2.min.js"></script>
     <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

