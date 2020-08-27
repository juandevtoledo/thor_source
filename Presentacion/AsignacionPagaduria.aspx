<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AsignacionPagaduria.aspx.cs" Inherits="Presentacion_AsignacionPagaduria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="impre">
        <h3>Asignacion de Pagaduria</h3>
    </div>
    <div class="title-divider"></div>
     <div class="row margenFormularios impre">
         <div class="row">
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
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblProducto" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Producto"></asp:Label>
                        <asp:DropDownList ID="ddlProducto" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-6"></div>
         </div>
         <div class="row impre">
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvCertificados" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20" OnRowCommand="grvCertificados_RowCommand" OnRowDataBound="grvCertificados_RowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccionar"  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' AutoPostBack="true" runat="server" OnCheckedChanged="chkSeleccionar_OnCheckedChanged" />
                                        <asp:linkButton ID="btnConfirmar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' runat="server" CssClass="btn btn-success btn-xs glyphicon glyphicon-ok btnListaSop" CommandName="confirmar_Click"   data-toggle="tooltip" title="Confirmar"></asp:linkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
         </div>
         <div class="title-divider"></div>
         <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div class="row" id="divPagaduria" runat="server">
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblPagaduria" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Pagaduria"></asp:Label>
                            <asp:DropDownList ID="ddlPagaduria" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>  
                    </div>
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblConvenio" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Convenio"></asp:Label>
                            <asp:DropDownList ID="ddlConvenio" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlConvenio_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>    
                    </div>
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnAsignar" cssClass="btn btn-primary btn-only" runat="server" Text="Asignar" OnClick="btnAsignar_Click"  />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
             <div class="col-md-3"></div>
            </div>
           </ContentTemplate>
        </asp:UpdatePanel>  
    </div>
    <hr />

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
