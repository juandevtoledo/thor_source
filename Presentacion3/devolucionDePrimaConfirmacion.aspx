<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="devolucionDePrimaConfirmacion.aspx.cs" Inherits="Presentacion3_devolucionDePrimaConfirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    < <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
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
             parent.document.location.href = protocol + "//" + host + "/Presentacion3/DevolucionDePrimaConfirmacion.aspx";
         }

    </script>
     <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
     <center>
         <div class="impre">
             <h3>Confirmación contable</h3>
         </div>
   </center>
    <br />
   <div class="row">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
             <div class="col-md-3">
                 <asp:Label ID="lblNumeroDocumento" Font-Bold="true"   CssClass="labels" runat="server" Text="Numero Documento"></asp:Label>
                 <asp:TextBox type="number" ID="txtCedula" CssClass="form-control" runat="server" ></asp:TextBox>
             </div>
              <div class="col-md-3">
                 <asp:Label ID="lblLocalidad" Font-Bold="true"   CssClass="labels" runat="server" Text="Localidad"></asp:Label>
                   <asp:DropDownList ID="ddlLocalidad" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" ></asp:DropDownList>
             </div>
              <br />
              <div class="col-md-2">
                 <asp:Button ID="btnBuscar" cssClass="btn btn-primary btnDp" runat="server" Text="Buscar" OnClick="btnBuscar_Click"   />
             </div>
          </ContentTemplate>
       </asp:UpdatePanel>
   </div>
    <hr />
    <div class="row">
         <div class="col-md-12">
               <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" >
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                     <asp:GridView ID="grvDevolucionDePrimaConfirmacion" CssClass="table table-bordered table-hover table-striped"  runat="server" OnRowCommand="grvDevolucionDePrimaConfirmacion_RowCommand" AllowPaging="true" PageSize="5" OnPageIndexChanging="grvDevolucionDePrimaConfirmacion_PageIndexChanging">
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                       <asp:LinkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" data-placement="right" OnClientClick="return confirm(Desea enviar esta devolución como aceptada?')" title="Aceptar Devolucion" CommandName="ConfirmarDevolucion_Click"  CssClass="btn btn-primary 
                                           glyphicon glyphicon-ok" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                       <asp:LinkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" data-placement="right"  title="Rechazar Devolución" CommandName="RechazarDevolucion_Click"  CssClass="btn btn-danger
                                           glyphicon glyphicon-exclamation-sign" />
                                  </ItemTemplate>
                              </asp:TemplateField>
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
            </asp:Panel>
           </div>
      </div>

    <div class="row col-md-3">
        <div class="col-md-12" id="divExtraPrima">
            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnConsultarAplicaciones" cssclass="btn btn-primary btnDp" data-toggle="modal" data-target="#miventana3" runat="server" Text="Consultar Aplicaiones" Visible="false"/>
                </ContentTemplate>
            </asp:UpdatePanel>
                                            
            <div class="modal fade" id="miventana3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
                <div class="modal-dialog">
                    <div class="modal-content" id="modal2">
                    <div class="modal-header">
                        <center>
                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <center><asp:Label ID="lblDetalleAplicacion" runat="server" CssClass="h4" Text="Detalle aplicación pagos"></asp:Label></center>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </center>
                        <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true" />
                            </ContentTemplate>
                        </asp:UpdatePanel>                                              
                    </div>
                    <div class="modal-body">     
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdAplicacionesPagosDevolucion" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <center><asp:Label ID="lblSoportes" runat="server" CssClass="h4" Text="Soportes para devolución"></asp:Label></center>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
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
                        <asp:UpdatePanel ID="UpdatePanel54" runat="server">
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
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <div class="row" id="divMovimiento" runat="server">
                <div class="col-md-3">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblNumeroMovimiento" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Numero Movimiento"></asp:Label>
                            <asp:TextBox ID="txtNumeroMovimiento" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:TextBox>
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label> 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-3">
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblFechaTransferencia" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Fecha Transferencia"></asp:Label>
                            <asp:TextBox runat="server" type="date" ID="txtFechaTransferencia" CssClass="form-control" placeholder="DD/MM/AAAA" AutoPostBack="true"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-3"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-5">
             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblCausalRechazo" runat="server"  Font-Bold="true"   CssClass="labels" Text="Causal Rechazo"></asp:Label>
                    <center>
                        <asp:DropDownList ID="ddlCausalRechazoDevolucionPrima" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-4"></div>
    </div>
    <br />
    <div class ="row">
        <div class="col-md-3"></div>
        <div class="col-md-3">
           <asp:UpdatePanel ID="UpdatePanel4" runat="server">
               <ContentTemplate>
                 <center>
                      <asp:Button ID="btnEnviarDevolucion" runat="server" CssClass="btn btn-primary btnDp" OnClientClick="return confirm('Desea enviar esta devolución como rechazada?')" Text="Enviar Devolución Rechazada" OnClick="btnEnviarDevolucion_Click" />
                 </center>
               </ContentTemplate>
          </asp:UpdatePanel>
        </div>
        <div class="col-md-2">
           <center>
               <asp:Button ID="btnExportarExcelDp" cssClass="btn btn-primary" runat="server" Text="Exportar a excel" OnClick="btnExportarExcelDp_Click"  />
           </center>
        </div>
        <div class="col-md-4"></div>
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

