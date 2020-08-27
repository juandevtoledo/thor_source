<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProduccionNueva.aspx.cs" Inherits="Presentacion_ProduccionNueva" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="container-form">
    <div class="row">
        <div class="col-md-12">
            <h2>Pre cargue</h2>
            <div class="title-divider"></div>
        </div>    
    </div>
    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
        <ContentTemplate>       
            <div class="row checkbox_fields">
                <div class="col-md-12">
                    <h3>Información Preliminar</h3>
                    <div class="divider-mini"></div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <label><asp:CheckBox ID="chkSiniestroP"  runat="server" />Siniestro Principal</label>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <label><asp:CheckBox ID="chkSiniestroC"  runat="server" />Siniestro Conyuge</label>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <label><asp:CheckBox ID="chkVariosVigentes" AutoPostBack="true" OnCheckedChanged="chkVariosVigentes_CheckedChanged" runat="server" />Varios Vigentes</label>                                        
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <label><asp:CheckBox id="chkCambioInter" runat="server" AutoPostBack="True"  OnCheckedChanged="Check_Clicked" />Cambio Intermediario</label>
                </div>
                <div class="col-md-12 col-sm-12">
                    <div class="divider-mini"></div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>       
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Cédula</label>
                        <asp:TextBox type="number" runat="server" OnTextChanged="ConsultarClienteExiste" AutoPostBack="true"  ID="txtCedulaProduccion" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtCedula" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtCedulaProduccion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Nombre</label>
                        <asp:TextBox Enabled="false" runat="server" Type="text" ID="txtNombreProduccion" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtNombreProduccion"  runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombreProduccion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> 
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Apellido</label>
                        <asp:TextBox Enabled="false" runat="server" AutoPostBack="true" Type="text" ID="txtApellidoProduccion" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtxtApellidoProduccion"  runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtApellidoProduccion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> 
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Agencia</label>
                        <asp:TextBox Enabled="false" runat="server" type="text" ID="txtAgenciaProduccion" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
           <ContentTemplate>       
                <div class="row"> 
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Fecha Expedición</label>
                            <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtFechaExpedicionProduccion" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqFechaExpedicion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaExpedicionProduccion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Compañía</label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="CargarProducto" ID="ddlCompania" CssClass="form-control" runat="server">                                                    
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12" id="productoProduccion">
                        <div class="form-group">
                            <label>Producto</label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ValidarProducto" ID="ddlProducto" CssClass="form-control" runat="server">                                                    
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlProducto" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlProducto"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                            <label>Vigencia:</label>
                            <asp:TextBox ID="txtVigencia" Enabled="false" cssClass="form-control" runat="server"></asp:TextBox>                                      
                        </div>     
                    </div>     
                </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
           <ContentTemplate>       
                <div class="row">
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Localidad</label>
                            <asp:DropDownList AutoPostBack="true" ID="ddlLocalidad" OnSelectedIndexChanged="pagaduriaPorLocalidad" CssClass="ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqDdlLocalidad" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlLocalidad"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> 
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Código/Cédula Asesor</label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="RecalcularNombreAsesor" ID="ddlCedulaAsesor" CssClass="ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlCedulaAsesor" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlCedulaAsesor"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Nombre Asesor</label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="RecalcularCedulaAsesor" ID="ddlNombreAsesor" CssClass="ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlNombreAsesor" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlNombreAsesor"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Certificados Disponibles</label>
                            <asp:DropDownList ID="ddlCertificadosDisponibles" runat="server" CssClass="ddl"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>No.Certificado</label>
                            <asp:TextBox type="number" ID="txtNumeroCertificado" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtNumeroCertificado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNumeroCertificado"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>       
            <div class="row">
                <div class="col-md-4">                                   
                    <asp:RadioButtonList Visible="false" ID="rblSura" runat="server">
                        <asp:ListItem>Ajuste de Prima</asp:ListItem>
                        <asp:ListItem>Designación de Beneficiarios</asp:ListItem>
                        <asp:ListItem>Nuevo Certificado</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-md-4">
                    <asp:RadioButtonList OnSelectedIndexChanged="HojasServicio"  AutoPostBack="true" ID="rbtNuevoCertificado" runat="server">
                        <asp:ListItem Selected="True">Anexo Conversion</asp:ListItem>
                        <asp:ListItem>Hoja de Servicio</asp:ListItem>
                    </asp:RadioButtonList>
                </div>  
                <div class="col-md-4">
                    <asp:RadioButtonList Visible="false" ID="rblBeneficiarosMapfre" runat="server">
                        <asp:ListItem>Designacion beneficiarios</asp:ListItem>
                        <asp:ListItem>Solicitud(estudio Ingresos)</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:RadioButtonList>
                </div> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
          <ContentTemplate>       
                <div class="row">
                    <div class="col-md-12">
                        <div class="divider"></div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <label>Pagaduría:</label>
                            <asp:DropDownList AutoPostBack="true"  ID="ddlPagaduria" CssClass=" ddl" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlPagaduria" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPagaduria"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblFechaRecibido" cssClass="labels" Font-Bold="true" Text="Fecha Recibido"></asp:Label>
                            <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtFechaRecibido" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqFechaRecibido" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaRecibido"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div runat="server" visible="false" id="planillaBolivar" class="col-lg-3 col-md-6 col-sm-12"> 
                        <div class="form-group">                                                           
                            <asp:Label runat="server" ID="labPlanillaBolivar" cssClass="labels" Font-Bold="true" Text="#.Planilla Bolívar"></asp:Label>
                            <asp:TextBox  type="number" ID="txtPlanillaBolivar" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtPlanillaBolivar" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPlanillaBolivar"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div runat="server" visible="false" class="col-lg-3 col-md-6 col-sm-12" id="conversion">
                        <div class="form-group">
                            <asp:Label Visible="false" runat="server" ID="labAnexoConversionProduccion" ssClass="labels" Font-Bold="true" Text="Anexo conversión"></asp:Label>                                                
                            <asp:TextBox Visible="false" runat="server" type="text" ID="txtAnexoConversionProduccion" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqAnexoConversion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtAnexoConversionProduccion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                         
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-12">
                        <div class="form-group">
                            <asp:Label Visible="true" runat="server" ID="Label1" cssClass="labels" Font-Bold="true" Text="Certificados Vigentes"></asp:Label>                                                                                          
                            <asp:DropDownList AutoPostBack="true"  ID="ddlCertificadosVigentes" CssClass=" ddl" runat="server">                                                        
                            </asp:DropDownList>                                       
                        </div>
                    </div>
                </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>       
            <div class="row"> 
                <div class="col-md-12">
                    <h3 visible="false" runat="server" id="legInformacionHojaServicio">Hojas de servicio</h3>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" Visible="false" ID="labHojaServicioPrincipal" CssClass="labels" Font-Bold="true" Text="Hoja de servicio Principal"></asp:Label>                                            
                        <asp:TextBox Visible="false" runat="server" type="number" ID="txtHojaServicioPrincipal" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtHojaServicioPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHojaServicioPrincipal"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" Visible="false" ID="labHojaServicioConyuge" CssClass="labels" Font-Bold="true" Text="Hoja de servicio Conyuge"></asp:Label>                                            
                        <asp:TextBox Visible="false" runat="server" type="number" ID="txtHojaServicioConyuge" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtHojaServicioConyuge" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHojaServicioConyuge"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">   
                    <div class="form-group">                                         
                        <asp:Label runat="server" Visible="false" ID="labHojaServicioOtrosAsegurados" CssClass="labels" Font-Bold="true" Text="Hoja de servicio Otros Asegurados"></asp:Label>
                        <asp:TextBox Visible="false" runat="server" type="number" ID="txtHojaServicioOtrosAsegurados" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtHojaServicioOtrosAsegurados" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHojaServicioOtrosAsegurados"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
         <ContentTemplate>       
            <div class="row">
                <div class="col-md-12">
                    <h3>Tipo de envío</h3>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:DropDownList ID="ddlEstado" AutoPostBack="true" OnSelectedIndexChanged="Devolucion" CssClass="form-control" runat="server"></asp:DropDownList>  
                        <asp:RequiredFieldValidator ID="reqddlEstado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlEstado"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>No.Folios</label>
                        <asp:TextBox type="number" runat="server"  ID="txtFolio" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtxtFolio" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFolio"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>          
                </div>          
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>       
            <div class="row">
                <div id="prima" visible="false" runat="server" class="col-md-12">
                    <h3>Devolución</h3>
                    <div>
                        <div class="form-group">
                            <label>Valor prima total:</label>
                            <asp:TextBox type="number" ID="txtPrimaTotal" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtPrimaTotal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPrimaTotal"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div runat="server" visible="false" id="devolucion">   
                            <div class="form-group">
                            <asp:Label ID="lblTipoDevolucion" runat="server" Text="Tipo Devolución" Font-Bold="true"  CssClass="labels" ></asp:Label>                                           
                            <asp:DropDownList ID="ddlGrupoDevolucion" cssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CargarCausalDevolucion" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div runat="server" visible="false" id="devolucionCausal">
                        <div class="form-group">
                            <asp:Label ID="lblCausalDevolucion" runat="server" Text="Causal Devolución" Font-Bold="true"  CssClass="labels" ></asp:Label> 
                            <asp:DropDownList ID="ddlCausalDevolucion" cssClass="form-control" runat="server"></asp:DropDownList> 
                            <asp:RequiredFieldValidator ID="reqddlCausal"  runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlCausalDevolucion"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                                  
                        </div>
                    </div>
                    <div runat="server" visible="false" id="observaciones" class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" Font-Bold="true"  CssClass="labels posicionObser"  ></asp:Label>
                            <asp:TextBox ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator ID="reqtxtObservaciones"  runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtObservaciones"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator> 
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col-lg-3 col-md-6 col-sm-12">
           <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>       
                     <div class="form-group">
                        <asp:Button ID="btnPrecargue" cssclass="btn btn-primary btnBusqueda" runat="server" data-toggle="modal" data-target="#myModal" Text="GUARDAR" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" id="contenedor">
                        <div class="modal-header">
                            <h4>CONFIRMACIÓN</h4>                                      
                        </div>
                        <div class="modal-body">      
                            <h5>¿Desea realmente guardar este pre cargue?</h5>                                                                                                                        
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>       
                                <div class="modal-footer">
                                    <asp:Button ID="btnCerrarmodal" CssClass="btn btn-danger" data-dismiss="modal" runat="server" Text="CERRAR" />  
                                    <asp:Button OnClick="CrearCertificado" ID="Button1" CssClass="btn btn-primary btnBusqueda"  runat="server" Text="CONFIRMAR" ValidationGroup="grpValidacionPreCargue" />
                                </div>   
                            </ContentTemplate>
                         </asp:UpdatePanel>                 
                    </div>
                </div>
            </div>
        </div>
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
</div><!--container-->
<script src="../Scripts/jquery-1.11.2.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script> 
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
