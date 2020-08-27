<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarUsuario.aspx.cs" Inherits="Control_AdministrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .limite{
            max-width: 1200px !important;
            margin : 0 auto;
        }
        .title-space{
            margin-top: 20px !important;
            margin-bottom: 20px !important;
        }
        .panel-body {
            padding: 10px;
        }
        .activar{
            font: 12px verdana;
            color: #f60632;
        }
    </style>
    <div class="container-form">

        <div runat="server" id="divAcciones">
            <div class="row">
               <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Administrar Usuarios
                         <asp:button  type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar"  OnClick="btnAdicionar_Click" text="Adicionar"></asp:button>
                    </h3>
                    <div class="title-divider"></div>
                </div>
            </div>

             <div class="row limite">
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarCedula" runat="server">Cédula</asp:Label>
                    <asp:TextBox type="" runat="server" id="txtBuscarCedula" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarNombre" runat="server" >Nombres o apellidos</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarNombre" cssClass="form-control"></asp:TextBox>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarUsuario" runat="server" >Usuario</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtBuscarUsuario" cssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            
            <div class="row limite">
                <div class="col-lg-12 col-md-12 col-sm-12">
                        <asp:GridView ID="grvAdminUsuario" CssClass="table table-bordered table-hover table-striped"  runat="server" OnRowCommand="grvAdminUsuario_RowCommand" OnRowDataBound="grvAdminUsuario_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvAdminUsuario_PageIndexChanging" >
                        <Columns>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" id="btnConsultar" runat="server"  CommandName="Consultar_Click"   data-toggle="tooltip" title="Consultar"></asp:linkButton>
                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil"  id="btnModificar" runat="server"  CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:linkButton>
                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-warning btn-xs glyphicon glyphicon-ok"  id="btnAsignar" runat="server"  CommandName="Asignar_Click" data-toggle="tooltip" title="Asignar perfil"></asp:linkButton>
                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove"  id="btnEliminar" runat="server"  CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar" OnClientClick="return confirm('Esta seguro que desea eliminar este usuario?')"></asp:linkButton>                             
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div> 
            </div>
        </div>
        <div runat="server" id="divConsultar">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Consultar Usuario</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row limite" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                     <asp:GridView ID="grvConsultarUsuario" CssClass="table table-bordered table-hover table-striped"  runat="server"  AllowPaging="True" PageSize="20"  ></asp:GridView>
               </div>  
               <div class="col-lg-12 col-md-12 col-sm-12"> 
                    <asp:button  type="submit" class="btn btn-danger" runat="server" id="btnAtras"  OnClick="btnSalir_Click" text="Atrás"></asp:button>
               </div>    
            </div>
        </div>

        <div runat="server" id="divAdicionar">
           <%-- Se utiliza el mismo formulario para adicionar y modificar pero diferente titulo y boton para guardar--%>
            <div class="row" id="titleAdicionar" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Adicionar usuario</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row" id="titleModificar" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Modificar usuario</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
           
            <div class="row limite">
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblCedula" runat="server">Cédula</asp:Label>
                    <asp:TextBox type="number" runat="server" id="txtCedula" cssClass="form-control" placeholder="Ingresar Documento" ></asp:TextBox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblPrimerNombre" runat="server" >Primer Nombre</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtPrimerNombre" cssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblSegundoNombre" runat="server" >Segundo Nombre</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtSegundoNombre" cssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblPrimerApellido" runat="server" >Primer Apellido</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtPrimerApellido" cssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels"  id="lblSegundoApellido" runat="server" >Segundo Apellido</asp:Label>
                    <asp:textbox type="text" runat="server" id="txtSegundoApellido" cssClass="form-control" placeholder="Segundo Apellido"></asp:textbox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" id="lblDepartamento" runat="server" >Departamento</asp:Label>
                    <asp:DropDownList CssClass="ddl" placesholder="" AutoPostBack="true" ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" id="lblCiudad" runat="server" >Ciudad</asp:Label>
                    <asp:DropDownList CssClass="form-control" id="ddlCiudad" runat="server"  ></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblAgencia" runat="server" >Agencia</asp:Label>
                    <asp:DropDownList CssClass="form-control" id="ddlAgencia" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblCargo" runat="server" >Cargo</asp:Label>
                    <asp:DropDownList CssClass="form-control" id="ddlCargo" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblNivel" runat="server" >Nivel</asp:Label>
                    <asp:DropDownList CssClass="form-control" id="ddlNivel" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblUsuario" runat="server">Usuario</asp:Label>
                    <asp:TextBox type="text" runat="server" id="txtUsuario" cssClass="form-control" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="LabContrasena" runat="server" >Contraseña</asp:Label>
                    <asp:textbox type="text" runat="server" id="txtContrasena" cssClass="form-control" placeholder="Contraseña"></asp:textbox>
                </div>
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblEstado" runat="server" >Estado</asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-12 col-md-12 col-sm-12 form-group">
                    <asp:button type="submit" id="btnModificar"  CssClass="btn btn-primary" runat="server" OnClick="btnModificar_Click" text="Guardar"></asp:button>
                    <asp:button type="submit" id="btnGuardar" cssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" text="Guardar"></asp:button>
                    <asp:button type="submit" id="btnSalir" CssClass="btn btn-danger"  runat="server" OnClick="btnSalir_Click"  text="Atrás"></asp:button>
                </div>
            </div>
        </div>
        
        
                
        <div runat="server" id="divPermisos">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Asignar permisos</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <strong><asp:Label ID="lblConUsuario" runat="server" cssClass="labels" Text=""></asp:Label></strong>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <strong><asp:Label ID="lblNombre" runat="server" cssClass="labels" Text=""></asp:Label></strong> 
                    <div class="title-space"></div> 
                </div>
            </div>
            <div class="row limite">
                <div class="col-lg-5 col-md-5 col-sm-5">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblFormulario" runat="server" >Formulario</asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlFormulario" runat="server" OnSelectedIndexChanged="ddlFormulario_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:textbox type="text" runat="server" id="txtPerId" Visible="false"></asp:textbox>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblBotones" runat="server" >Boton restringido</asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBotones" runat="server"></asp:DropDownList>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <asp:Label cssClass="labels" Font-Bold="true" id="Label1"  runat="server" ></asp:Label><br />
                    <asp:LinkButton type="submit" id="btnAsignar" cssClass="btn btn-primary" runat="server" text="" OnClick="btnAsignar_Click"><span class="glyphicon glyphicon-plus" ></span></asp:LinkButton>
                </div>
            </div>
            <div class="title-space"></div> 
            
            <div class="row limite">
                <div class="col col-lg-5 col col-md-5 col col-sm-5">
                    <asp:ListView runat="server" id="ltv" OnItemCommand="listView_OnItemCommand" >
                        <ItemTemplate>
                            <div class="panel panel-default">
                              <div class="panel-body">
                                <asp:Label Text='<%# Bind("btn_Nombre") %>' ID="lblNombre" runat="server" />
                                  <asp:LinkButton CommandArgument='<%# Bind("menBtn_Id") %>' id="btnEliminarBtn"  cssClass="btn btn-danger glyphicon glyphicon glyphicon-remove pull-right btn-xs" runat="server" CommandName="btnEliminar_Click" OnClientClick="return confirm('Esta seguro que desea eliminar este botón?')"  />
                              </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12"> 
                    <asp:button  type="submit" class="btn btn-danger" runat="server" id="Button1"  OnClick="btnSalir_Click" text="Atrás"></asp:button>
               </div> 
            </div>
        </div>
    </div>
     <script src="../scripts/jquery-1.11.2.min.js"></script>
     <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>



