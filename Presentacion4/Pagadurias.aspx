<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pagadurias.aspx.cs" Inherits="Pagadurias"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Administrar Pagadurías </title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Gestionar Pagadurias
                    <asp:LinkButton ID="botonAdicionar" runat="server" CssClass="btn btn-info pull-right"                                     
                                Text="Adicionar Pagaduria" OnClick="btnAdicionar_Click" >
                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Adicionar
                    </asp:LinkButton>
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row" id="opciones">
            <div class="col-lg-4 col-md-4 col-sm-12">   
                <div class="form-group">             
                    <asp:TextBox type="" runat="server" id="txtNombreFiltro" cssClass="form-control" placeholder="Nombre"  ></asp:TextBox>
                </div>    
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">  
                <div class="form-group">                             
                    <asp:TextBox type="" runat="server" id="txtIdentificadorFiltro" cssClass="form-control" placeholder="Identificación" ></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">                                            
                <div class="form-group"> 
                    <div class="input-group">
                        <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" 
                            OnClick="lnkBtnBuscar_Click">
                            <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>  
        <div class="row" id="verPagadurias">
            <div class="col-lg-12 col-md-12 col-sm-12">   
                <asp:GridView ID="grvAdminPagaduria" runat="server" Font-Size="0.9em" DataKeyNames="paga_Id" 
                    Width="100%"
                    CssClass="table table-bordered table-hover table-striped" 
                    AutoGenerateColumns="false" 
                    AllowPaging="True" PageSize="20" 
                    OnRowCommand="grvAdminPagaduria_RowCommand"                                     
                    OnPageIndexChanging="grvAdminPagaduria_PageIndexChanging"
                    OnSelectedIndexChanged="grvAdminPagaduria_SelectedIndexChanged" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="btnContainer3"/>                                            
                            <ItemTemplate>
                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                    CssClass="btn btn-success glyphicon glyphicon glyphicon-search btn-xs" 
                                    id="botonConsultar" runat="server"  
                                    CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">
                                </asp:linkButton> 
                                <asp:linkButton 
                                    CssClass="btn btn-success glyphicon glyphicon glyphicon-edit btn-xs" 
                                    id="botonEditar" runat="server"  
                                    CommandName="Select"  data-toggle="tooltip" title="Editar">
                                </asp:linkButton>  
                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                    CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove btn-xs"
                                        id="botonEliminar" runat="server"  
                                    CommandName="Eliminar_Click" 
                                    OnClientClick="if (!confirm('Esta seguro de Eliminar la Pagaduria?')) return false;" 
                                    data-toggle="tooltip" title="Eliminar"></asp:linkButton>   
                            </ItemTemplate>                                        
                        </asp:TemplateField>

                        <asp:BoundField DataField="paga_Id" HeaderText="Id" Visible="true" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="paga_Nombre" HeaderText="Nombre Pagaduria"  />
                        <asp:BoundField DataField="paga_Identificacion" HeaderText="Identificación Pagaduria" />
                        <asp:BoundField DataField="act_Nombre" HeaderText="Actividad Económica" />
                        <asp:BoundField DataField="paga_Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="ciu_Nombre" HeaderText="Ciudad" />
                        <asp:BoundField DataField="dep_Nombre" HeaderText="Departamento" />
                        <asp:BoundField DataField="Visacion_Format" HeaderText="Visación" 
                            ItemStyle-HorizontalAlign="Center" Visible="false" />
                        <asp:BoundField DataField="paga_FechaEntregaNovedades" HeaderText="Novedades" ItemStyle-HorizontalAlign="Center" Visible="true" />                                        
                        <asp:BoundField DataField="paga_PorcentajeParticipacion" HeaderText="% " />
                        <asp:BoundField DataField="Estado_Format" HeaderText="Estado " />
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>  
        </div>  
    </div><!--container-form-->
</asp:Content>


