<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReestructurarConciliacion.aspx.cs" Inherits="Presentacion2_ReestructurarConciliacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
      <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="900000"></asp:ScriptManager>
    <center>
        <h3 class="impre">Reestructurar Conciliación</h3>
    </center>
        <fieldset>
                 <div class="row">
                     <div class="col-md-3">
                         <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                             <ContentTemplate>
                                 <asp:Label ID="lblAgencia" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Agencia"></asp:Label>
                                 <asp:DropDownList ID="ddlAgencia" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlAgencia_SelectedIndexChanged" AutoPostBack="true">
                                     <asp:ListItem Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                     </div>
                     <div class="col-md-3">
                         <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                             <ContentTemplate>
                                 <asp:Label ID="lblLocalidad" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Localidad"></asp:Label>
                                 <asp:DropDownList ID="ddlLocalidad" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true">
                                 </asp:DropDownList>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                     </div>
                     <div class="col-md-3">
                          <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                             <ContentTemplate>
                                 <asp:Label ID="lblPagaduria" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Pagaduria"></asp:Label>
                                 <asp:DropDownList ID="ddlPagaduria" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged" AutoPostBack="true">
                                 </asp:DropDownList>
                            </ContentTemplate>
                         </asp:UpdatePanel>
                     </div>
                      <div class="col-md-3">
                           <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                             <ContentTemplate>
                                 <asp:Label ID="lblConvenio" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Convenio"></asp:Label>
                                 <asp:DropDownList ID="ddlConvenio" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlConvenio_SelectedIndexChanged" AutoPostBack="true">
                                 </asp:DropDownList>
                            </ContentTemplate>
                          </asp:UpdatePanel>
                     </div>
                 </div>
            <br />
            <div class=" row">
                <div class="col-md-5"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnReestructurar" runat="server" Text="Reestructurar" CssClass="btn btn-primary" OnClick="btnReestructurar_Click"  />
                </div>
                <div class="col-md-5"></div>
            </div>
            <br />
           <div class="panel-group" id="accordion" role="tablist">
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="heading1">
                            <h4 class="panel-title">
                                 <a href="#collapse1" data-toggle="collapse" data-parent="#accordion">
                                    Consultar convenios pendientes por reestructuración
                                 </a>
                            </h4>
                        </div>
                        <div id="collapse1" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="row">
                                <div class="col-md-12">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <h4 runat="server" id="h4Convenios">Convenios pendientes por reversión</h4>
                                            <asp:GridView ID="grvConveniosReestructuracion" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvConveniosReestructuracion_RowCommand">
                                                <Columns>
                                                      <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                                                          <ItemTemplate>
                                                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary glyphicon glyphicon glyphicon-search" ID="btnConsultarAplicacion"  runat="server" data-toggle="tooltip"  CommandName="Consultar_Click" data-placement="right" title="ConsultarAplicación por convenio"  ></asp:linkButton>
                                                                </ItemTemplate>
                                                      </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                 <h4 runat="server" id="h5CertificadosConvenios">Certificados con posible reversión:</h4> <asp:Label ID="lblNombreConvenio" runat="server"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:GridView ID="grvAplicacionesPorConvenio" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                </asp:GridView>
                                            </ContentTemplate>
                                     </asp:UpdatePanel>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
              
            <br />
            <br /> 
           </fieldset>
    <asp:UpdatePanel ID="udpProgres" runat="server">
        <ContentTemplate>
             <asp:UpdateProgress ID="uppProgress" runat="server"  OnLoad="Page_Load">
                            <ProgressTemplate>
                               <div class="contenedor-loader">
                                    <div class='loader'>
                                        <h6><p style="text-align:center"><b>Realizando tu consulta, por favor espera...<br /></b></p></h6>
                                    </div>
                               </div>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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







