<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeRecibo.aspx.cs" Inherits="Presentacion3_InformeRecibo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h3>Informe Recibo</h3>
            <div class="title-divider"></div>
        </div>
    </div>

         <div class="row">
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblRecibo" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Recibo"></asp:Label>
                        <asp:TextBox ID="txtRecibo" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtRecibo_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLocalidad" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Localidad"></asp:Label>
                        <asp:DropDownList ID="ddlLocalidad" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPagaduria" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Pagaduria"></asp:Label>
                        <asp:DropDownList ID="ddlPagaduria" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblConvenio" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Convenio"></asp:Label>
                        <asp:DropDownList ID="ddlConvenio" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlConvenio_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
         </div>
         <div class="row">
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCompania" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Compañia"></asp:Label>
                        <asp:DropDownList ID="ddlCompania" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblProducto" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Producto"></asp:Label>
                        <asp:DropDownList ID="ddlProducto" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDesde" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Desde"></asp:Label>
                        <asp:TextBox runat="server" type="date" ID="txtDesde" CssClass="form-control" placeholder="DD/MM/AAAA" OnTextChanged="txtDesde_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblHasta" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Hasta"></asp:Label>
                        <asp:TextBox runat="server" type="date" ID="txtHasta" CssClass="form-control" placeholder="DD/MM/AAAA" OnTextChanged ="txtHasta_TextChanged" AutoPostBack="true" ></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </div>  
    <hr />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grvRecibo" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20" OnRowCommand="grvRecibo_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                            <ItemTemplate>
                                <asp:linkButton ID="btnConsultar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' runat="server" CssClass="btn btn-primary btn-xs glyphicon glyphicon glyphicon-search btnListaSop" CommandName="consultar_Click" data-toggle="tooltip"  data-target="#miventana3" title="Consultar" ></asp:linkButton>              
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="miVentana" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" id="modal2">
                <div class="modal-header">
                    <center><h3>Resumen Recibo</h3></center>
                    <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>                                              
                </div>
                <div class="modal-body">  
                    <div class="row">
                        <div class="col-md-12">
                            <fieldset>
                                <legend>Informacion Recbio</legend>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvReciboResumen" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                                                                           
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </fieldset>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                        <fieldset>
                            <legend>Aplicaciones</legend>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>                                                
                                    <asp:GridView ID="grvAplicaciones" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                                                                           
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </fieldset>
                        <br />
                        </div>
                    </div>  
                </div>                                                                                                                              
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnCerarExtraPrima1" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="CERRAR" />        
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div> 
            </div>                   
        </div>
    </div>

    <div class="row">
        <div class="col-md-5"></div>
        <div class="col-md-2">
            <input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" />
        </div>
        <div class="col-md-5"></div>
    </div>

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
        function endReq(sender, args) {
            $(".ddl").select2({
                placeholder: "Seleccione",
                allowClear: true
            });
            $(function () {
                $("#tabs").tabs();
            });
        }
  </script>
</asp:Content>
