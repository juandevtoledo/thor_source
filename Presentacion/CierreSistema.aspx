<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CierreSistema.aspx.cs" Inherits="Presentacion_CierreSistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="../Content/bootstrap.min.css" rel="stylesheet" />
      <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .limite{
            max-width: 1200px !important;
            margin : 0 auto;
        }
    </style>

    <div class="container-form">
        <div runat="server" id="divAcciones">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Administrar cierre sistema
                             <asp:button type="submit" class="btn btn-primary text-inherit pull-right" runat="server" id="btnAdicionar" OnClick="btnAdicionar_Click"  text="Adicionar"></asp:button>
                        </h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row limite">
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarBanco" runat="server">Compañía</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlBuscarCompañia" runat="server" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="LblBuscarCuenta" runat="server" >Producto</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlBuscarProducto" runat="server" ></asp:DropDownList>
                </div>
                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarFecha" runat="server" >Agencia</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlBuscarAgencia" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarEstado" runat="server" >Estado</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlBuscarEstado" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar"/>
                        <asp:Button ID="btnLimpiarBuscador" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" />
                    </div>
                </div>
            </div>
   
            <div class="row limite">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:GridView ID="grvCierreSistema" CssClass="table table-bordered table-hover table-striped"  runat="server" OnRowCommand="grvCierreSistema_RowCommand" OnRowDataBound="grvCierreSistema_RowDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvCierreSistema_PageIndexChanging" >
                        <Columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-danger glyphicon  glyphicon-ban-circle" id="botonCerrar" runat="server"  CommandName="Cerrar_Click"   data-toggle="tooltip" title="Cerrar Sistema"></asp:linkButton>
                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-success glyphicon glyphicon glyphicon-ok"  id="botonAbrir" runat="server"  CommandName="Abrir_Click" data-toggle="tooltip" title="Abrir Sistema"></asp:linkButton>
                                 </ItemTemplate>
                              </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>     
            </div>
        </div>

        <div runat="server" id="divAdicionar">
            <%-- Se utiliza el mismo formulario para adicionar y modificar pero diferente titulo y boton para guardar--%>
            <div class="row" id="titleAdicionar" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h3>Adicionar cierre sistema</h3>
                    <div class="title-divider"></div>
                </div>
            </div>
            <div class="row limite">
                <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblCompañia" placeholder="Compañia" runat="server" >Compañia</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlCompania" runat="server" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="col col-lg-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblProducto" runat="server" >Producto</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlProducto" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblAgencia" runat="server" >Agencia</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlAgencia" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblMes" runat="server" >Mes Producción</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlMes" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblAnio" runat="server" >Año Producción</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlAnio" runat="server"></asp:DropDownList>
                </div>
                <div class="col col-lg-6 form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" id="lblEstado" runat="server" >Estado</asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" id="ddlEstado" runat="server"></asp:DropDownList>
                </div>
                <div class="clear"></div>
                <div class="col col-lg-8">
                    <asp:button type="submit" id="botonInsertar" cssClass="btn btn-primary" runat="server" OnClick="btnInsertar_Click" text="Guardar"></asp:button>
                    <asp:button type="submit" id="botonAtras" cssClass="btn btn-danger" runat="server" OnClick="btnAtras_Click" text="Atras"></asp:button>
                </div>
            </div><!--formulario-->   
        </div>
    </div>

     <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>

