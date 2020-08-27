<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PagosOtrasCompañias.aspx.cs" Inherits="Presentacion6_PagosOtrasCompañias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            parent.document.location.href = protocol + "//" + host + "/Presentacion6/PagosOtrasCompañias.aspx";
        }

        
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager> 
   
         <h3>Pagos a Compañias</h3>
         <br />

        <div id="tabs">
            <ul>
                <li><a data-toggle="tab" href="#tabs1"> Recibos de Caja</a></li>
                <li><a data-toggle="tab" href="#tabs2" >Generar Pago</a></li>
                <!--<li><a data-toggle="tab" href="#tabs3" >Solicitudes de Cheques</a></li>-->
                <!--<li><a data-toggle="tab" href="#tabs4" >Facturaciones</a></li>-->
                <!--<li><a data-toggle="tab" href="#tabs5" >Pago Compañia</a></li>-->
                <li><a data-toggle="tab" href="#tabs3" >Historico Pagos</a></li>
                <li><a data-toggle="tab" href="#tabs4" >Cargue Pago Compañia</a></li>
                <li><a data-toggle="tab" href="#tabs5" >Archivo Produccion Aplicada</a></li>
           </ul>




            <div id="tabs1">
                <div class="row">
                    <fieldset>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                        <ContentTemplate>
                            
                            <div class="col-md-12">
                                <legend>Recibos de Caja</legend>
                                    <div class="col-lg-7">
                                        <asp:Label ID="lblFechaInicio" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Inicio"></asp:Label>
                                        <asp:TextBox ID="txtFechaInicioRecibos" runat="server" TextMode="Date"></asp:TextBox>                                            
                                        
                                        <asp:Label ID="lblFechaFin" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Fin"></asp:Label>
                                        <asp:TextBox ID="txtFechaFinRecibos" runat="server" TextMode="Date"></asp:TextBox>

                                         <asp:Button ID="btnConsultarRecibos" runat="server" Text="Consultar" cssclass="btn btn-primary"  />
                                                                       
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



            <div id="tabs2" >
                <div class="row">
                    <div class="col-md-12 ">  
                        <fieldset>
                            <legend>Pago</legend>                    
                                <div class="col-md-12">
                                     <asp:UpdatePanel ID="udpPago" runat="server">
                                            <ContentTemplate>
                                                <div class="row">                     
                                                    <div class="col-md-5">
                                                        <label>Fecha Fin</label>
                                                        <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtFechaFinPago" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqFechaFinPago" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaFinPago"  ValidationGroup="grpValidacionPagoCia" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <label>Vigencia</label>
                                                        <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtVigencia" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqVigencia" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtVigencia"  ValidationGroup="grpValidacionPagoCia" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <label>Compañía</label>
                                                        <asp:DropDownList AutoPostBack="true"  ID="ddlCompania" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged"></asp:DropDownList>
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
                                    <asp:UpdatePanel runat="server" ID="udpPagoProducto"><ContentTemplate>
                                        <div class="col-md-12" runat="server">

                                            <asp:Button ID="btnRealizarPagoCompania"  cssclass="btn btn-primary" runat="server" Text="Generar" OnClick="btnRealizarPagoCompania_Click" ValidationGroup="grpValidacionPagoCia"/>                                                                                    
                                        </div>
                                    <br />
                                    <br />
                                        <div runat="server" id ="pagoCompañia">
                                            <legend>Pago Producto</legend>
                                            <asp:GridView ID="grvPagoProducto" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <legend>Totales Gr</legend>
                                            <asp:GridView ID="grvTotalGr" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <asp:Button ID="btnDetallesPago" runat="server" cssclass="btn btn-primary" Text="Detalles Aplicaciones" OnClick="btnDetallesPago_Click"  />
                                            <legend>Comisiones</legend>
                                            <asp:GridView ID="grvComision" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <asp:GridView ID="grvComision2" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <legend>Transferencias</legend>
                                            <asp:GridView ID="grvTransferencias" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <legend>Recibos de Caja</legend>
                                            <asp:GridView ID="grvRecibosPago" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <legend>Valores Directos</legend>
                                            <asp:GridView ID="grvValorDirectoCompañia" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                        </div>
                                    
                                    </ContentTemplate></asp:UpdatePanel>
                                    <asp:UpdateProgress ID="uppPagoProducto" runat="server" AssociatedUpdatePanelID="udpPagoProducto" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                                </div>
                                    
                                    <div runat="server" id="exportar">
                                        <asp:Button ID="btnExportarExcel" runat="server" cssclass="btn btn-primary" Text="Exportar a Excel" OnClick="btnExportarExcel_Click"  />
                                        <asp:Button ID="btnPagoDefinitivo" runat="server" cssclass="btn btn-primary" Text="Pago Definitivo" OnClick="btnPagoDefinitivo_Click"   />

                                    </div>
                                    
                                                                         
                        </fieldset>             
                    </div>
                </div>                
            </div>

            <div id="tabs3">
                 <div class="row">
                    <asp:UpdatePanel runat="server" ID="udpHistoricoPago">
                        <ContentTemplate>  
                            <div class="col-md-12" id="historicoPagos" runat="server">
                                <fieldset>
                                 <legend>Historico Pagos</legend>
                                    <div class="col-lg-7">
                                        <asp:Label ID="lblCompañiaHistorico" runat="server" CssClass="labels" Font-Bold="true" Text="Compañia"></asp:Label>
                                        <asp:DropDownList ID="ddlCompañiaHistorico" AutoPostBack="true" runat="server" CssClass="ddl"  ViewStateMode="Enabled" OnSelectedIndexChanged="ddlCompañiaHistorico_SelectedIndexChanged" ></asp:DropDownList>
                                        <asp:Label ID="lblProductoHistorico" runat="server" CssClass="labels" Font-Bold="true" Text="Producto"></asp:Label>
                                        <asp:DropDownList ID="ddlProductoHistorico" AutoPostBack="true" runat="server" CssClass="ddl"  ViewStateMode="Enabled" ></asp:DropDownList>
                                    
                                            <asp:Label ID="lblFehcaInicioHistorico" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Inicio"></asp:Label>
                                            <asp:TextBox ID="txtFechaInicioHistorico" runat="server" TextMode="Date"></asp:TextBox>
                                            
                                        
                                            <asp:Label ID="lblFechaFinHistorico" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Fin"></asp:Label>
                                            <asp:TextBox ID="txtFechaFinHistorico" runat="server" TextMode="Date"></asp:TextBox>
                                            
                                        
                                            <br />
                                            <asp:Button ID="btnConsultarPagos" runat="server" Text="Consultar" cssclass="btn btn-primary" OnClick="btnConsultarPagos_Click"  />
                                         </div>
                                    <div class="col-md-8">
                                        <asp:GridView ID="grvHistoricoPagosCias" runat="server" CssClass="table table-bordered table-hover table-striped" OnRowCommand="grvHistoricoPagosCias_RowCommand" >
                                            <Columns>
                                            <asp:TemplateField>                                            
                                                <ItemTemplate>                                                
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                       CssClass="btn btn-primary glyphicon glyphicon glyphicon-eye-open btnListaSop btn-xs" 
                                                        id="btnConsultarPago" runat="server"  
                                                        CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">
                                                    </asp:linkButton> 
                                                
                                                                                
                                            
                                                </ItemTemplate>                                        
                                             </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>


                                    <div class="col-md-12" runat="server" id="pagoProductoConsulta">
                                        <legend>Pago Producto</legend>
                                        <asp:GridView ID="grvHistoricoPagoProducto" runat="server" CssClass="table table-bordered table-hover table-striped" visible="False">
                                        </asp:GridView>
                                        <legend>Totales Gr</legend>
                                            <asp:GridView ID="grvHistoricoTotalGr" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                        <asp:Button ID="btnDetallesHistorico" runat="server" cssclass="btn btn-primary" Text="Detalles Aplicaciones" OnClick="btnDetallesHistorico_Click"  />
                                        <legend>Comisiones</legend>
                                            <asp:GridView ID="grvHistoricoComision" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <asp:GridView ID="grvHistoricoComision2" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                            <legend>Transferencias</legend>
                                            <asp:GridView ID="grvHistoricoTransferencias" visible="False"  runat="server" CssClass="table table-bordered table-hover table-striped">                                        
                                            </asp:GridView>
                                        <legend>Recibos de Caja</legend>
                                        <asp:GridView ID="grvHistoricoRecibosPago" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        <legend>Valores Directos</legend>
                                        <asp:GridView ID="grvHistoricoValorDirectoCompañia" runat="server" CssClass="table table-bordered table-hover table-striped">
                                        </asp:GridView>
                                        
                                        
                                    </div>


                                    


                            </fieldset></div>                           
                              
                            
                            
                            
                              
                        </ContentTemplate>

                    </asp:UpdatePanel>
                     <asp:UpdateProgress ID="uppHistoricoPago" runat="server" AssociatedUpdatePanelID="udpHistoricoPago" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                     <asp:Button ID="btnExportarExcelPagoHiastorico" runat="server" Text="Exportar Pago" cssclass="btn btn-primary" OnClick="btnExportarExcelPagoHiastorico_Click"   />
                    

                 </div>

            </div>


            <div id="tabs4">
                 <div class="row">
                    <asp:UpdatePanel runat="server" ID="udpCarguePagoCompañia">
                        <ContentTemplate> 
                            <div class="col-md-12" id="cargueCompañiaPago" runat="server" style="overflow:scroll">
                                <fieldset>
                                    <legend>Cargue Pago Compañia</legend>
                                    <div class="col-md-5">
                                        <label>Compañía</label>
                                        <asp:DropDownList AutoPostBack="true"  ID="ddlCompañiaCarguePago" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCompañiaCarguePago_SelectedIndexChanged" ></asp:DropDownList>
                                    </div>
                
                                     <div class="col-md-5" id="Div3" runat="server" visible="true">
                                        <label>Producto</label>
                                        <asp:DropDownList ID="ddlProductoCarguePago" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-5">
                                            <label>Vigencia</label>
                                            <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtVigenciaCarguePago" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtVigenciaCarguePago"  ValidationGroup="grpCarguePago" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Button ID="btnGenerarCarguePago" runat="server" Text="Generar Cargue Pago" cssclass="btn btn-primary" OnClick="btnGenerarCarguePago_Click"    />
                                    </div>
                                    <br />
                                    
                                    <div runat="server" id="carguePago" >
                                    </div>
                                    
                            
                                    <legend>Cargue Pago</legend>
                                    <asp:GridView ID="grvCarguePago" runat="server" CssClass="table table-bordered table-hover table-striped" visible="False">
                                    </asp:GridView>
                                    
                            
                                
                            </fieldset>
                            </div>

                        </ContentTemplate>

                    </asp:UpdatePanel>
                     <asp:UpdateProgress ID="uppCarguePagoCompañia" runat="server" AssociatedUpdatePanelID="udpCarguePagoCompañia" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                     
                         <asp:Button ID="btnExportarExcelCarguePago" runat="server" Text="Exportar" cssclass="btn btn-primary" OnClick="btnExportarExcelCarguePago_Click"  />
                   
                     
                     

                 </div>

            </div>





            <div id="tabs5">
                 <div class="row">
                    <asp:UpdatePanel runat="server" ID="udpArchivoCargue">
                        <ContentTemplate> 
                            <div class="col-md-12" id="cargue" runat="server" style="overflow:scroll">
                                <fieldset>
                                    <legend>Archivo Cargue</legend>
                                    <div class="col-md-5">
                                        <label>Compañía</label>
                                        <asp:DropDownList AutoPostBack="true"  ID="ddlCompañiaCargue" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCompañiaCargue_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                
                                     <div class="col-md-5" id="Div2" runat="server" visible="true">
                                        <label>Producto</label>
                                        <asp:DropDownList ID="ddlProductoCargue" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-5">
                                            <label>Vigencia</label>
                                            <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtVigenciaCargue" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtVigenciaCargue"  ValidationGroup="grpProduccionAplicada" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Button ID="btnGenerarArchivoCargue" runat="server" Text="Generar Produccion Aplicada" cssclass="btn btn-primary" OnClick="btnGenerarArchivoCargue_Click"   />
                                    </div>
                                    <br />
                                    
                                    <div runat="server" id="tablaCargue" >
                                        <legend>Cargue</legend>
                                        <asp:GridView ID="grvArchivoCargue" runat="server" CssClass="table table-bordered table-hover table-striped" visible="False">
                                        </asp:GridView>
                                    </div>
                                    
                            </div>
                                </fieldset>

                            </div>

                        </ContentTemplate>

                    </asp:UpdatePanel>
                     <asp:UpdateProgress ID="uppArchivoCargue" runat="server" AssociatedUpdatePanelID="udpArchivoCargue" OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                     <fieldset>
                         <div runat="server" id="botonExcelCargue">
                         <asp:Button ID="btnExportarArchivoCargue" runat="server" Text="Exportar" cssclass="btn btn-primary" OnClick="btnExportarArchivoCargue_Click"  />
                     </div>
                     </fieldset>
                     
                     

                 </div>

            </div>
                
           




        </div>
</asp:Content>

