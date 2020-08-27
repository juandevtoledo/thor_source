<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="devolucionDePrimaAceptada.aspx.cs" Inherits="Presentacion3_devolucionDePrimaAceptada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Content/EstilosIndex.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
     <script type="text/javascript">
          var host = window.location.host;
        var protocol = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";
         //Center grybox window with callback on close
         function OpenCenterWindowCallBack() {
             var caption = "Aplicaciones de Pago para Devolucion";
             var url = protocol + "//" + host + "/Presentacion3/AplicacionesPagoDevolucion.aspx";
             return GB_showCenter(caption, url, 470, 1100, callback_fn)
         }
         function callback_fn() {
             //alert('callback function');
             //parent.document.location = parent.document.location;            
             parent.document.location.href = protocol + "//" + host + "/Presentacion3/DevolucionDePrimaAceptada.aspx";
         }

    </script>
     <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="spmAjax" runat="server"></asp:ScriptManager> 
     <center>
         <div class="impre">
             <h3>Devoluciones tramitadas</h3>
         </div>
   </center>
    <br />
   <div class="row">
       <asp:UpdatePanel ID="udpConsultarDevolucion" runat="server">
          <ContentTemplate>
             <div class="col-md-3">
                 <asp:Label ID="lblNumeroDocumento" Font-Bold="true"   CssClass="labels" runat="server" Text="Numero Documento"></asp:Label>
                 <asp:TextBox type="number" ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
             </div>
              <div class="col-md-3">
                 <asp:Label ID="lblLocalidad" Font-Bold="true"   CssClass="labels" runat="server" Text="Localidad"></asp:Label>
                   <asp:DropDownList ID="ddlLocalidad" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
             </div>
              <br />
              <div class="col-md-2">
                 <asp:Button ID="btnBuscar" cssClass="btn btn-primary btnDp" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
             </div>
          </ContentTemplate>
       </asp:UpdatePanel>
   </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="udpDevolucionDePrima" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grvDevolucionesDePrimaAceptada" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvDevolucionesDePrimaAceptada_RowCommand" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvDevolucionesDePrimaAceptada_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                             <ItemTemplate>
                                 <div class="glyphicon">
                                    <i class="glyphicon glyphicon-search form-control-feedback" style="color:white;font-size: 15px;"></i>
                                    <asp:Button runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="modal" CommandName="Consultar_Click"  CssClass="btn btn-success glyphicon glyphicon-search"  data-target="#miventana3"/> 
                                </div>   
                             </ItemTemplate>
                        </asp:TemplateField>
                   </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>

    <div class="row col-md-3">
        <div class="col-md-12" id="divExtraPrima">
            <asp:UpdatePanel ID="udpConsultarAplicacion" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnConsultarAplicaciones" cssclass="btn btn-primary btnDp" data-toggle="modal" data-target="#miventana3" runat="server" Text="Consultar Aplicaiones" Visible="false"/>
                </ContentTemplate>
            </asp:UpdatePanel>
                                            
            <div class="modal fade" id="miventana3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
                <div class="modal-dialog">
                    <div class="modal-content" id="modal2">
                    <div class="modal-header">
                        <center>
                            <asp:UpdatePanel ID="udpDetalleAplicacion" runat="server">
                                    <ContentTemplate>
                                        <center><asp:Label ID="lblDetalleAplicacion" runat="server" CssClass="h4" Text="Detalle aplicación pagos"></asp:Label></center>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </center>
                        <asp:UpdatePanel ID="udpCerrar" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true" />
                            </ContentTemplate>
                        </asp:UpdatePanel>                                              
                    </div>
                    <div class="modal-body">     
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="udpAplicacionesPagos" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdAplicacionesPagosDevolucion" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <asp:UpdatePanel ID="udpSoportes" runat="server">
                                    <ContentTemplate>
                                        <center><asp:Label ID="lblSoportes" runat="server" CssClass="h4" Text="Soportes para devolución"></asp:Label></center>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="udpArchivos" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvArchivosSoporteM" runat="server" Font-Size="0.9em" DataKeyNames="sopdev_Id" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" AllowPaging="True" PageSize="5">
                                            <EmptyDataTemplate>
                                                <div class="alert alert-warning" role="alert">                                                                 
                                                    <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Archivos Soporte !!! 
                                                </div>
                                            </EmptyDataTemplate>
                                            <Columns>                                                
                                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" >                                            
                                                    <ItemTemplate >         
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" CssClass="btn btn-success btn-xs" NavigateUrl='<%# Eval("sopdev_Url") %>'>                                                    
                                                                <span class="glyphicon glyphicon-file "> </span>                                                                                                                       
                                                            </asp:HyperLink>                                                         
                                                    </ItemTemplate>                                        
                                                </asp:TemplateField>   
                                                <asp:BoundField DataField="sopdev_Nombre" HeaderText="Nombre Soporte" />
                                                <asp:BoundField DataField="sopdev_Url" HeaderText="Url Soporte" />                       
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1"></div>
                        </div>                                                                                                                  
                    </div>
                    <div class="modal-footer">
                        <asp:UpdatePanel ID="udpCerrarVentana" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnCerar" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="CERRAR" />        
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>                    
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-5"></div>
        <div class="col-md-2">
           <center>
                <asp:Button ID="btnExportarExcelDp" cssClass="btn btn-primary" runat="server" Text="Exportar a excel" OnClick="btnExportarExcelDp_Click"  />
           </center>
        </div>
        <div class="col-md-5"></div>
    </div>
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
</asp:Content>

