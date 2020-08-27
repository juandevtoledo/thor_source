<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PagosCompañiasAseguradoras.aspx.cs" Inherits="Presentacion6_PagosCompañiasAseguradoras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
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
    <script type="text/javascript">
        var host = window.location.host;
        var protocol = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";
        //Center grybox window with callback on close
        function OpenCenterWindowCallBack() {
            var caption = "Detalles Aplicaciones";
            var url = protocol + "//" + host + "/Presentacion6/DetallesSolicitudCheques.aspx";
            return GB_showCenter(caption, url, 480, 800, callback_fn)
        }        
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = protocol + "//" + host + "/Presentacion6/PagosCompañiasAseguradoras.aspx";
        }

        
    </script>


    
    
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="spm" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager> 
   
         <h3>Pagos a Seguros Bolivar</h3>
         <br />

        <div id="tabs">
        <ul class="nav nav-tabs impre">
            <li><a data-toggle="tab" href="#tabs6"> Recibos de Caja</a></li>
            <li><a data-toggle="tab" href="#tabs1" >Generar Procesos</a></li>
            <li><a data-toggle="tab" href="#tabs2" >Solicitudes de Cheques</a></li>
            <li><a data-toggle="tab" href="#tabs3" >Facturaciones</a></li>
            <li><a data-toggle="tab" href="#tabs4" >Pago Compañia</a></li>
            <li><a data-toggle="tab" href="#tabs5" >Historico Pagos</a></li>
       </ul>
       
           <div id="tabs1" >
                <div class="row">
                    <div class="col-md-12 ">  
                        <fieldset>
                            <legend>Solicitud de Cheques, Facturación y Pagos</legend>                    
                                <div class="col-md-12">
                                     <asp:UpdatePanel ID="udp1" runat="server">
                                            <ContentTemplate>
                                                <div class="row">                     
                                                    <div class="col-md-5">
                                                        <label>Fecha Fin</label>
                                                        <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtFechaFinPago" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqFechaFinPago" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaFinPago"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <label>Compañía</label>
                                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" ID="ddlCompania" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-5" id="proceso" runat="server" visible="false">
                                                        <label>Proceso</label>
                                                        <asp:DropDownList ID="ddlProceso" CssClass="form-control" runat="server">
                                                            <asp:ListItem Text="Seleccione" Value="0" Enabled="true"></asp:ListItem>
                                                            <asp:ListItem Text="SolicitudCheque" Value="1" Enabled="true"></asp:ListItem>
                                                            <asp:ListItem Text="Facturación" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Pago" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-5" id="producto" runat="server" visible="true">
                                                        <label>Producto</label>
                                                        <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-5" id="localidad" runat="server" visible="false">
                                                        <label>Localidad</label>
                                                        <asp:DropDownList ID="ddlLocalidad" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>                                                
                                                </div>
                                           
                                            </ContentTemplate>
                                    </asp:UpdatePanel>
                            
                                    <br /><br />
                                    <asp:UpdatePanel runat="server" ID="udpProcesos"><ContentTemplate>
                                        <div class="col-md-12" runat="server">
                                            <asp:Button ID="btnRealizarPagoCompania" OnClick="btnRealizarPagoCompania_Click" cssclass="btn btn-primary" runat="server" Text="Generar"/>                                                                                    
                                        </div>
                                    <br />
                                    <br />
                                    <asp:GridView ID="grvProcesos" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">
                                        
                                    </asp:GridView>
                                    </ContentTemplate></asp:UpdatePanel>
                                    <asp:UpdateProgress ID="uppProcesos" runat="server" AssociatedUpdatePanelID="udpProcesos" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                                </div>
                                    

                        </fieldset>             
                    </div>
                </div>                
            </div>


            <div id="tabs2" >
                <div class="row">
                    <div class="col-md-12">  
                         <asp:UpdatePanel ID="udpSolicitudes" runat="server">
                            <ContentTemplate>

                                <fieldset>
                                    <div class="col-md-12" runat="server" id="solicitudes">
                                    
                                        <legend>SOLICITUDES DE CHEQUE</legend>
                                        <asp:Label ID="lblFechaSolicitud" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha de Solicitud"></asp:Label>
                                        <asp:TextBox ID="txtFechaSolicitudCheque" runat="server" TextMode="Date"></asp:TextBox>
                                        <asp:Label ID="lblNumeroTalonFiltro" runat="server" CssClass="labels" Font-Bold="true" Text="Numero de Talon/Simasol"></asp:Label>
                                        <asp:TextBox ID="txtNumeroTalonSolicitud" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="btnConsultarSolicitudes" runat="server" cssclass="btn btn-primary" OnClick="btnConsultarSolicitudes_Click" Text="Consultar" />
                                        <asp:GridView ID="grvSolicitudesCheques" runat="server" CssClass="table table-bordered table-hover table-striped" OnRowCommand="grvSolicitudesCheques_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnConsultarSolicitud" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Consultar_Click" CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" data-toggle="tooltip" title="Consultar">
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnEditarSolicitud" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Select" CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" data-toggle="tooltip" title="Editar">
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="botonEliminar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar_Click" CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" data-toggle="tooltip" OnClientClick="if (!confirm('Esta seguro de Eliminar la Pagaduria?')) return false;" title="Eliminar"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br /><br />
                                    <div class="col-md-12" runat="server" id="talon" visible="false">   
                                       
                                        <legend>ASIGNACION TALON/SIMASOL</legend>
                                        <asp:Label ID="lblIdSolicitud" runat="server" CssClass="labels" Font-Bold="true" Text=""></asp:Label>
                                        <br />
                                        <br />
                                        <div class="col-md-12">
                                            <div class="col-lg-3">
                                            <asp:Label ID="lblNumeroTalonAsignacion" runat="server" CssClass="labels" Font-Bold="true" Text="Nro de Talon/Simasol"></asp:Label>
                                            <asp:TextBox ID="txtTalonSimasol" runat="server" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqTalonSimasol" runat="server" ControlToValidate="txtTalonSimasol" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpTalonesSolicitud"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lblValorTalon" runat="server" CssClass="labels" Font-Bold="true" Text="Valor Talon/Simasol"></asp:Label>
                                            <asp:TextBox ID="txtValorTalonSimasol" runat="server" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqValorTalonSImasol" runat="server" ControlToValidate="txtValorTalonSimasol" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpTalonesSolicitud"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label ID="lblFechaTalon" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha de Talon/Simasol"></asp:Label>
                                            <asp:TextBox ID="txtFechaTalonSimasol" runat="server" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqFechaTalonSimasol" runat="server" ControlToValidate="txtFechaTalonSimasol" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpTalonesSolicitud"></asp:RequiredFieldValidator>
                                        </div>
                                         <br /><br />  
										<div class="col-md-10">
                                            <asp:Button ID="btnGuardarTalonSimasol" runat="server" cssclass="btn btn-primary" OnClick="btnGuardarTalonSimasol_Click" Text="Guardar Talon/Simasol" ValidationGroup="grpTalonesSolicitud" />
                                            <asp:Button ID="btnVoverSolicitudes" runat="server" cssclass="btn btn-primary" OnClick="btnVoverSolicitudes_Click" Text="Volver" />
                                        </div>
                                        </div>
                                        <asp:GridView ID="grvTalonesSolicitudCheque" runat="server" CssClass="table table-bordered table-hover table-striped">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnConsultarTalon" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Consultar_Click" CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" data-toggle="tooltip" title="Consultar">
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnEditarTalon" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Select" CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil" data-toggle="tooltip" title="Editar">
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnEliminarTalon" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar_Click" CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" data-toggle="tooltip" OnClientClick="if (!confirm('Esta seguro de Eliminar la Facturacion?')) return false;" title="Eliminar"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                         <asp:UpdateProgress ID="uppSolicitudes" runat="server" AssociatedUpdatePanelID="udpSolicitudes" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row" >
                    <asp:UpdatePanel ID="udpSolicitudes2" runat="server">
                        <ContentTemplate>
                                <div class="col-md-12" id="solche" runat="server" visible="false">
                                        
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Button ID="btnExportarExcel2" runat="server" cssclass="btn btn-primary" Text="Exportar a Excel" OnClick="btnExportarExcel2_Click" />
                </div>
            </div>


            <div id="tabs3" >
                <div class="row">
                    <div class="col-md-12"> 
                        <asp:UpdatePanel runat="server" ID="udpFacturaciones"><ContentTemplate>
                                <fieldset>
                                    <legend>Administracion de Facturaciones</legend> 

                                    <div class="col-md-12" runat="server" id="facturaciones" style="overflow:scroll">
                                        <div class="row">
                                             <div class="col-md-4">
                                                 <div class="form-group">
                                                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:DropDownList ID="ddlLocalidadFacturacion" runat="server"></asp:DropDownList>
                                                 </div>                                               
                                            
                                             </div>  
                                            <div class="col-md-4">
                                                 <div class="form-group">
                                                    <asp:Label ID="lblProdcuto" runat="server" Text="Producto" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:DropDownList ID="ddlProductoFacturacion" runat="server">
                                                        
                                                     </asp:DropDownList>
                                                 </div>                                               
                                            
                                             </div>  
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblFechaCorte" runat="server" Text="Fecha de Corte" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:TextBox ID="txtFechaFacturacion" runat="server" TextMode="Date"></asp:TextBox>
                                                </div>
                                                
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblFechaCreacion" runat="server" Text="Fecha de Creacion" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:TextBox ID="txtFechaCreacionFacturacion" runat="server" TextMode="Date"></asp:TextBox>
                                                </div>
                                                

                                            </div>
                                             <div class="col-md-4">
                                                 <div class="form-group">
                                                     <asp:Label ID="lblNumeroTronadorFiltro" runat="server" Text="Numero de Tronador" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                     <asp:TextBox ID="txtTronador" runat="server" TextMode="Number"></asp:TextBox>
                                                 </div>
                                                 
                                            
                                             </div>
                                        </div>
                                          
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3">
                                            
                                                <asp:Button ID="btnBuscarFacturacion" runat="server" Text="Consultar" cssclass="btn btn-primary" OnClick="btnBuscarFacturacion_Click" />
                                             </div> 
                                        </div>
                                                                                                                             
                                        <div class="col-lg-12">


                                        
                                            <asp:GridView ID="grvFacturacion" runat="server" CssClass="table table-bordered table-hover table-striped" OnRowCommand="grvFacturacion_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>                                            
                                                <ItemTemplate>                                                
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                       CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" 
                                                        id="btnConsultarFacturacion" runat="server"  
                                                        CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">
                                                    </asp:linkButton>                                               
                                                                                                                                                    

                                                                              
                                            
                                                </ItemTemplate>                                        
                                             </asp:TemplateField>
                                            </Columns>
                                    </asp:GridView>
                                            </div>
                                    </div>
                                    <br /><br />
                                    
                                </fieldset>       
                        
                            <div class="col-md-12" runat="server" id="tronadorFacturacion">
                                <fieldset>
                                    <legend>Asigancion de Numero de Facturacion y Tronador</legend>
                                    <asp:Label ID="lblFacturacion" runat="server" Text="" Font-Bold="true"  CssClass="labels"></asp:Label>       
                                            
                                    <div class="col-md-12">
                                        <asp:Label ID="lblNumeroTronador" runat="server" Text="Numero Tronador" Font-Bold="true"  CssClass="labels"></asp:Label>                                            
                                        <asp:TextBox ID="txtNumeroTronador" TextMode="Number" runat="server"></asp:TextBox>                                            
                                        <asp:Label ID="lblNumeroFactura" runat="server" Text="Numero de Factura" Font-Bold="true"  CssClass="labels"></asp:Label>                                            
                                        <asp:TextBox ID="txtNumeroFactura" TextMode="Number" runat="server"></asp:TextBox>                                           
                                            <asp:Label ID="lblFechaFactura" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha de Factura"></asp:Label>
                                            <asp:TextBox ID="txtFechaFactura" runat="server" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqFechaFactura" runat="server" ControlToValidate="txtFechaFactura" ErrorMessage="**Campo Requerido" ForeColor="Red" ValidationGroup="grpDatosFacturaciones"></asp:RequiredFieldValidator>
                                                                                 
                                        <asp:Button ID="btnGuardarTronadorFacturacion" cssclass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarTronadorFacturacion_Click" />

                                    </div>
                                </fieldset>
                            </div>                
                        </ContentTemplate>
                        </asp:UpdatePanel>

                         <asp:UpdateProgress ID="uppFacturaciones" runat="server" AssociatedUpdatePanelID="udpFacturaciones" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>

                        <asp:Button ID="btnExportarExcelFacturaciones" runat="server" cssclass="btn btn-primary" Text="Exportar a Excel" OnClick="btnExportarExcelFacturaciones_Click"  />
                    </div>
                </div>
          </div>

            <div id="tabs4">
                <div class="row">
                    <asp:UpdatePanel runat="server" ID="udpPago">
                        <ContentTemplate>                            
                            <div class="col-md-12" style="overflow:scroll">
                                <fieldset>
                                    <legend>PAGOS COMPAÑIA</legend>
                                    <div class="col-lg-7">
                                        <asp:Button ID="btnValidarPagos" cssclass="btn btn-primary" runat="server" Text="Validar Pagos" OnClick="btnValidarPagos_Click"  />
                                          <br />                                 
                                        <asp:Label ID="lblLocalidadPago" runat="server" Text="LOCALIDAD" CssClass="labels" Font-Bold="true"></asp:Label>
                                        <asp:DropDownList ID="ddlLocalidadPago" AutoPostBack="true" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlLocalidadPago_SelectedIndexChanged" ViewStateMode="Enabled" Enabled="False"></asp:DropDownList>
                                    </div>
                                    
                                    <div class="col-md-12" runat="server" id="pagoLocalidad">
                                        <legend>Facturaciones</legend>
                                        <asp:GridView ID="grvFacturacionesPagos" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Libranzas</legend>
                                        <asp:GridView ID="grvLibranzasPago" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Soportes Bancarios</legend>
                                        <asp:GridView ID="grvSoportesPago" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Detalles Aplicaciones</legend>
                                        <asp:GridView ID="grvDetallesPago" runat="server" AllowPaging="True" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvDetallesPago_PageIndexChanging" PageSize="20" PagerStyle-CssClass="pager">
                                            <PagerSettings PageButtonCount="20"/>
                                        </asp:GridView>
                                        <legend>Novedades</legend>
                                        <asp:GridView ID="grvNovedades" runat="server" AllowPaging="True" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvNovedades_PageIndexChanging" PageSize="30">
                                        </asp:GridView>
                                    </div>       
                                    
                                    
                                    
                                    
                                    
                                    
                                </fieldset></div>                       
                                                        
                                                      
                                                     
                            
                                                      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="uppPago" runat="server" AssociatedUpdatePanelID="udpPago" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                    <asp:Button ID="btnExportarPago" runat="server" Text="Exportar Pago" cssclass="btn btn-primary" OnClick="btnExportarPago_Click"/>
                    <asp:Button ID="btnExportarDetalles" runat="server" Text="Exportar Detalles" cssclass="btn btn-primary" OnClick="btnExportarDetalles_Click"/>
                    <asp:CheckBox ID="chkEnvioDefinitivo" runat="server" Text="Envio Definitivo" />
                </div>
            </div>


            
            <div id="tabs5">
                 <div class="row">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                        <ContentTemplate>  
                            <div class="col-md-12" id="historicoPagos" runat="server">
                                <fieldset>
                                 <legend>Historico Pagos</legend>
                                    <div class="col-lg-7">
                                        <asp:Label ID="lblLocalidadHistorico" runat="server" CssClass="labels" Font-Bold="true" Text="Localidad"></asp:Label>
                                        <asp:DropDownList ID="ddlLocalidadesHistorico" AutoPostBack="true" runat="server" CssClass="ddl"  ViewStateMode="Enabled" ></asp:DropDownList>
                                    
                                            <asp:Label ID="lblFechaInicio" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Inicio"></asp:Label>
                                            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
                                            
                                        
                                            <asp:Label ID="lblFechaFin" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Fin"></asp:Label>
                                            <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date"></asp:TextBox>
                                            
                                        
                                            <br />
                                            <asp:Button ID="btnConsultarPagos" runat="server" Text="Consultar" cssclass="btn btn-primary" OnClick="btnConsultarPagos_Click"  />
                                         </div>
                                    <div class="col-md-8">
                                        <asp:GridView ID="grvHistoricoPagos" runat="server" CssClass="table table-bordered table-hover table-striped" OnRowCommand="grvHistoricoPagos_RowCommand">
                                            <Columns>
                                            <asp:TemplateField>                                            
                                                <ItemTemplate>                                                
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                       CssClass="btn btn-primary glyphicon glyphicon glyphicon-eye-open btnListaSop btn-xs" 
                                                        id="btnConsultarPago" runat="server"  
                                                        CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">
                                                    </asp:linkButton> 
                                                
                                                    <asp:linkButton  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                       CssClass="btn btn-primary glyphicon glyphicon glyphicon-edit btn-xs" 
                                                        id="botonEditar" runat="server"  
                                                        CommandName="Select"  data-toggle="tooltip" title="Editar">
                                                    </asp:linkButton>                                                                                                 

                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                        CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove btn-xs"
                                                         id="botonEliminar" runat="server"  
                                                        CommandName="Eliminar_Click" 
                                                        OnClientClick="if (!confirm('Esta seguro de Eliminar la Facturacion?')) return false;" 
                                                        data-toggle="tooltip" title="Eliminar"></asp:linkButton>                             
                                            
                                                </ItemTemplate>                                        
                                             </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>


                                    <div class="col-md-12" runat="server" id="pagoLocalidadConsulta">
                                        <legend>Facturaciones</legend>
                                        <asp:GridView ID="grvFacturacionesPagoConsulta" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Libranzas</legend>
                                        <asp:GridView ID="grvLibranzasPagoConsulta" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Soportes Bancarios</legend>
                                        <asp:GridView ID="grvSoportesPagoConsulta" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Detalles Aplicaciones</legend>
                                        <asp:GridView ID="grvDetallesPagoConsulta" runat="server" AllowPaging="True" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvDetallesPago_PageIndexChanging" PageSize="20" PagerStyle-CssClass="pager">
                                            <PagerSettings PageButtonCount="20"/>
                                        </asp:GridView>
                                        <legend>Novedades</legend>
                                        <asp:GridView ID="grvNovedadesPagoConsulta" runat="server" AllowPaging="True" CssClass="table table-bordered table-hover table-striped" OnPageIndexChanging="grvNovedades_PageIndexChanging" PageSize="30">
                                        </asp:GridView>
                                    </div>


                            </fieldset>

                            </div>
                            
                              
                        </ContentTemplate>

                    </asp:UpdatePanel>
                     <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel5" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                     <asp:Button ID="btnExportarEcelPagoHiastorico" runat="server" Text="Exportar Pago" cssclass="btn btn-primary" OnClick="btnExportarEcelPagoHiastorico_Click"  />
                    <asp:Button ID="btnExportarDetallesHsitorico" runat="server" Text="Exportar Detalles" cssclass="btn btn-primary" OnClick="btnExportarDetallesHsitorico_Click" />

                 </div>



            </div>



            <div id="tabs6">
                <div class="row">
                    <fieldset>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                        <ContentTemplate>
                            
                            <div class="col-md-12">
                                <legend>Recibos de Caja</legend>
                                    <div class="col-lg-7">
                                        <asp:Label ID="Label15" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Inicio"></asp:Label>
                                        <asp:TextBox ID="txtFechaInicioRecibos" runat="server" TextMode="Date"></asp:TextBox>                                            
                                        
                                        <asp:Label ID="Label16" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Fin"></asp:Label>
                                        <asp:TextBox ID="txtFechaFinRecibos" runat="server" TextMode="Date"></asp:TextBox>

                                         <asp:Button ID="btnConsultarRecibos" runat="server" Text="Consultar" cssclass="btn btn-primary" OnClick="btnConsultarRecibos_Click" />
                                                                       
                                </div>
                               
                            <div class="col-md-12" id="recibosCaja" runat="server">
                                        <asp:GridView ID="grvRecibosCaja" runat="server" CssClass="table table-bordered table-hover table-striped" >
                                            <Columns>
                                            <asp:TemplateField>                                            
                                                <ItemTemplate>                                                
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                       CssClass="btn btn-primary glyphicon glyphicon glyphicon-eye-open btnListaSop btn-xs" 
                                                        id="btnConsultarRecibo" runat="server"  
                                                        CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">
                                                    </asp:linkButton> 
                                                
                                                    <asp:linkButton  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                       CssClass="btn btn-primary glyphicon glyphicon glyphicon-edit btn-xs" 
                                                        id="botonEditar" runat="server"  
                                                        CommandName="Select"  data-toggle="tooltip" title="Editar">
                                                    </asp:linkButton>                                                                                                 

                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                        CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove btn-xs"
                                                         id="botonEliminar" runat="server"  
                                                        CommandName="Eliminar_Click" 
                                                        OnClientClick="if (!confirm('Esta seguro de Eliminar la Facturacion?')) return false;" 
                                                        data-toggle="tooltip" title="Eliminar"></asp:linkButton>                             
                                            
                                                </ItemTemplate>                                        
                                             </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                            </div>
                            
                            
                        </ContentTemplate>
                        
                    </asp:UpdatePanel>

                    </fieldset>
                    
                    
                </div>


            </div>


        </div>
    
    
</asp:Content>

