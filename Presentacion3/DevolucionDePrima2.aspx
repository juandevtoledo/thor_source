<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DevolucionDePrima2.aspx.cs" Inherits="Presentacion3_DevolucionDePrima2" %>

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
            return GB_showCenter(caption, url, 550, 1100, callback_fn)
        }        
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = protocol + "//" + host + "/Presentacion3/DevolucionDePrima2.aspx";
        }

        function OpenCenterWindowCallBack2() {
            var caption = "Soporte Devolucion";
            var url = protocol + "//" + host + "/Presentacion3/AdjuntarSoportesDevolucion.aspx";
            return GB_showCenter(caption, url, 550, 1100, callback_fn)
        }
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="spmAjax" runat="server"></asp:ScriptManager> 
     <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2>Pendiente por tramitar</h2>
            <div class="title-divider"></div>
        </div>
    </div>
    <br />
   <div class="row">
       <asp:UpdatePanel ID="udpConsultarDevolucion" runat="server">
          <ContentTemplate>
             <div class="col-md-3">
                 <asp:Label ID="lblNumeroDocumento" Font-Bold="true"   CssClass="labels" runat="server" Text="Número Documento"></asp:Label>
                 <asp:TextBox  type="number" ID="txtCedula" CssClass="form-control" runat="server" ></asp:TextBox>
             </div>
          </ContentTemplate>
       </asp:UpdatePanel>
        <asp:UpdatePanel ID="udpLocalidad" runat="server">
          <ContentTemplate>
              <div class="col-md-3">
                 <asp:Label ID="lblLocalidad" Font-Bold="true"   CssClass="labels" runat="server" Text="Localidad"></asp:Label>
                   <asp:DropDownList ID="ddlLocalidad" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
             </div>
              </ContentTemplate>
       </asp:UpdatePanel>
       <div class="col-md-2 btn-only">
            <asp:UpdatePanel ID="udpInsertar" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnBuscar" cssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                    <asp:Button ID="btnInsertar" runat="server" class="btn btn-success" data-toggle="modal" data-target=".bs-example-modal-lg" Text="Insertar" />
                </ContentTemplate>
            </asp:UpdatePanel>
                          <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                              <div class="modal-dialog modal-lg">
                                  <div class="modal-content" id="modalContentTerceroConyuge">
                                      <center><h4>Registrar Persona</h4></center>
                                      <hr />
                                         <div class="row">
                                             <div class="col-md-12" id="divRegistrarConyuge">
                                                 <fieldset>
                                                         <div class="row">
                                                            <div class="col-md-4">
                                                            <asp:UpdatePanel ID="udpNombre" runat="server">
                                                              <ContentTemplate>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblNombreTercero" runat="server" Text="Nombre*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                    <asp:TextBox type="Text"  runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqtxtNombre" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombre"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>
                                                               </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                             </div>
                                                         <div class="col-md-4">
                                                          <asp:UpdatePanel ID="udpApellido" runat="server">
                                                            <ContentTemplate>
                                                                 <div class="form-group">
                                                                       <asp:Label ID="lblApellidoTercero" runat="server" Text="Apellidos*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                       <asp:TextBox type="Text" runat="server" ID="txtApellido" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqTxtApellido" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtApellido"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                 </div>
                                                             </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                         </div>
                                                         <div class="col-md-4">
                                                          <asp:UpdatePanel ID="udpIdentificacion" runat="server">
                                                            <ContentTemplate>
                                                                <div class="form-group">
                                                                       <asp:Label ID="lblNumeroIdentificacion" runat="server" Text="Numero Identificación*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                       <asp:TextBox type="number"  runat="server" ID="txtIdentificacion" CssClass="form-control" ></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtIdentificacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtIdentificacion"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                         </div>
                                                        </div>
                                                            <div class="row">
                                                               <div class="col-md-4">
                                                                   <div class="form-group">
                                                                      <asp:UpdatePanel ID="udpDepartamento" runat="server">
                                                                          <ContentTemplate>
                                                                                 <asp:Label ID="lblDepartamentoTercero" runat="server" Text="Departamento*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                 <asp:DropDownList CssClass="form-control" placesholder="" ID="ddlDepartamento" runat="server" >
                                                                                 </asp:DropDownList>
                                                                                 <asp:RequiredFieldValidator ID="reqddlDepartamento" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlDepartamento"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>    
                                                                   </div>
                                                              </div>
                                                               <div class="col-md-4">
                                                                 <asp:UpdatePanel ID="udpCoreo" runat="server">
                                                                   <ContentTemplate>
                                                                    <div class="form-group">
                                                                         <asp:Label ID="lblCorreoTercero" runat="server" Text="Correo*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                         <asp:TextBox type="email"  runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    </ContentTemplate>
                                                                 </asp:UpdatePanel>
                                                              </div>
                                                              <div class="col-md-4">
                                                                 <asp:UpdatePanel ID="udpCelular" runat="server">
                                                                   <ContentTemplate>
                                                                      <div class="form-group">
                                                                          <asp:Label ID="lblCelularTercero" runat="server" Text="Celular" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                          <asp:TextBox type="number" runat="server" ID="txtCelular"  CssClass="form-control" ></asp:TextBox>
                                                                          <asp:RequiredFieldValidator ID="reqtxtCelular" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtCelular"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                      </div>
                                                                     </ContentTemplate>
                                                                 </asp:UpdatePanel>
                                                               </div>   
                                                            </div>
                                                              <div class="row">
                                                                       <div class="col-md-4">
                                                                         <asp:UpdatePanel ID="udpTelefonoUno" runat="server">
                                                                           <ContentTemplate>
                                                                               <div class="form-group">
                                                                                    <asp:Label ID="lblTelefonoUnoTercero" runat="server" Text="Telefono 1" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                    <asp:TextBox type="number"  runat="server" ID="txtTelefono1" CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="reqtxtTelefono1" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono1"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                               </div>
                                                                           </ContentTemplate>
                                                                       </asp:UpdatePanel>
                                                                       </div>
                                                                       <div class="col-md-4">
                                                                         <asp:UpdatePanel ID="udpTelefonoDos" runat="server">
                                                                           <ContentTemplate>
                                                                                <div class="form-group">
                                                                                   <asp:Label ID="lblTelefonoDosTercero" runat="server" Text="Telefono 2" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                   <asp:TextBox type="number" runat="server" ID="txtTelefono2" CssClass="form-control" ></asp:TextBox>
                                                                                   <asp:RequiredFieldValidator ID="reqtxtTelefono2" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono2"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                             </ContentTemplate>
                                                                       </asp:UpdatePanel> 
                                                                       </div>
                                                                       <div class="col-md-4">
                                                                         <asp:UpdatePanel ID="udpDireccion" runat="server">
                                                                           <ContentTemplate>
                                                                               <div class="form-group">
                                                                                   <asp:Label ID="lblDireccionTercero" runat="server" Text="Direccion*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                   <asp:TextBox type="Text"  runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
                                                                                   <asp:RequiredFieldValidator ID="reqtxtDireccion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDireccion"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                               </div>
                                                                             </ContentTemplate>
                                                                       </asp:UpdatePanel> 
                                                                      </div> 
                                                                </div>           
                                                  <hr />
                                                  </fieldset>
                                                  <br />
                                                 <asp:UpdatePanel ID="udpRegistrar" runat="server">
                                                     <ContentTemplate>
                                                          <div class="row">
                                                              <div class="col-md-5"></div>
                                                              <div class="col-md-2">
                                                                <asp:Button ID="btnInsertarTercero" cssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnInsertar_Click" ValidationGroup="grpValidacionAseguradoConyuge"/>
                                                              </div>  
                                                              <div class="col-md-5"></div>           
                                                          </div>
                                                    </ContentTemplate>
                                              </asp:UpdatePanel>
                                             <hr />
                                      </div>  
                                </div>
                           </div>
                    </div>
              </div>
        </div>  
   </div>
    <hr />
     <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="udpDevolucionPrima" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grvDevolucionesDePrima" CssClass="table table-bordered table-hover table-striped" runat="server">
                    <Columns>
                       <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                            <ItemTemplate>
                                <asp:RadioButton ID="chkSeleccionar"  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' AutoPostBack="true" runat="server" CommandName="Digitar_Click" OnCheckedChanged="chkSeleccionar_OnCheckedChanged" />
                            </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
         <asp:UpdatePanel ID="udpFormaPago" runat="server">
             <ContentTemplate>
                 <div class="col-md-5">
                     <asp:RadioButtonList ID="rbtlMarca" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtlMarca_SelectedIndexChanged">
                         <asp:ListItem Value="1" Text="Pago en efectivo"></asp:ListItem>
                         <asp:ListItem Value="2" Text="Tramitado a compañia"></asp:ListItem>
                         <asp:ListItem Value="3" Text="Tramitar por cuenta bancaria"></asp:ListItem>
                     </asp:RadioButtonList>
                 </div>
             </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row btn-only">
       <asp:UpdatePanel ID="udpIdDevolucion" runat="server">
          <ContentTemplate>
                <div class="col-md-3">
                    <asp:Label ID="lblIdDevolucion" Font-Bold="true"   CssClass="labels" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="txtIdDevolucion" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblBanco" runat="server" Font-Bold="true"   CssClass="labels" Text="Banco"></asp:Label>
                    <asp:DropDownList ID="ddlBanco" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblTipoCuenta" runat="server" Font-Bold="true"   CssClass="labels" Text="Tipo Cuenta"></asp:Label>
                    <asp:DropDownList ID="ddlTipoCuenta" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
              <div class="col-md-3">
                <asp:Label ID="lblNombreTitular" runat="server" Font-Bold="true"   CssClass="labels" Text="Nombre Titular"></asp:Label>
                <asp:TextBox type="Text" ID="txtNombreTitular" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>
         </ContentTemplate>
       </asp:UpdatePanel>
    </div>
    <div class="row btn-only">
      <asp:UpdatePanel ID="updInformacion" runat="server">
         <ContentTemplate>            
            <div class="col-md-3">
                <asp:Label ID="lblCedulaTitular" runat="server" Font-Bold="true"   CssClass="labels" Text="Cedula Titular"></asp:Label>
                <asp:TextBox ID="txtCedulaTitular" Type="number"  CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblNumeroCuenta" runat="server" Font-Bold="true"   CssClass="labels" Text="Numero Cuenta"></asp:Label>
                <asp:TextBox ID="txtNumeroCuenta" Type="number"  CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                        <asp:UpdatePanel ID="udpCausal" runat="server">
                            <ContentTemplate>
                            <asp:Label ID="lblCausalDevolucion" runat="server" Text="Causal Devolución*" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:DropDownList CssClass="form-control" placesholder="" ID="ddlCausalDevolucion" runat="server" >
                            </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </div>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
         <div class="row btn-only ">
             <div class="col-md-2 text-center">
                    <asp:Button ID="btnGuardarDevolucion" CssClass="btn btn-primary" runat="server" Text="Guardar"  OnClientClick="return confirm('Esta seguro de guardar estar devolución?')" OnClick="btnGuardarDevolucion_Click" />
                    <asp:Button ID="btnExportarExcelDp2" CssClass="btn btn-success" runat="server" Text="Descargar"  OnClick="btnExportarExcelDp2_Click" />
             </div>
             <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnConsultarAplicaciones" cssclass="btn btn-primary" data-toggle="modal" data-target="#miventana3" runat="server" Text="Consultar Aplicaciones"/>
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="btn btn-primary" text="Cargar Archivos" OnClick="btnAddArchivos_Click" > </asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
                    <div class="row col-md-12">
                        <div class="col-md-12" id="divExtraPrima">
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
                                        <asp:UpdatePanel ID="udpCerrarModal" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                                              
                                    </div>
                                    <div class="modal-body">     
                                        <div class="row">
                                            <div class="col-md-10">
                                                <asp:UpdatePanel ID="udpAplicacionesPagosDevolucion" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grvdAplicacionesPagosDevolucion" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:UpdatePanel ID="udpSoportes" runat="server">
                                                    <ContentTemplate>
                                                        <center><asp:Label ID="lblSoportes" runat="server" CssClass="h4" Text="Soportes para devolución"></asp:Label></center>
                                                    </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
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
                                        </div>                                                                                                                  
                                    </div>
                                        <div class="modal-footer">
                                            <asp:UpdatePanel ID="udpCerrar" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnCerarExtraPrima1" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="CERRAR" />        
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>                    
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
               </div>
              <br />
    <asp:UpdatePanel ID="udpAdjuntarSoportes" runat="server">
          <ContentTemplate>
               <div class="row">
                  <div class="col-md-12">
                      <center>
                        <asp:Panel ID="panSoporte" runat="server" ScrollBars="Auto" Height="500" Width="80%" HorizontalAlign="Center">
                       
                  <asp:GridView ID="grvArchivosSoporte" runat="server" Font-Size="0.9em" 
                                                                DataKeyNames="sopdev_Id"
                                                                CssClass="table table-bordered table-hover table-striped" 
                                                                AutoGenerateColumns="false" 
                                                                AllowPaging="True" PageSize="5"                                                     
                                                                OnPageIndexChanging="grvArchivosSoporte_PageIndexChanging"
                                                                OnSelectedIndexChanged="grvArchivosSoporte_SelectedIndexChanged" >
                    
                            <EmptyDataTemplate>
                                <div class="alert alert-warning" role="alert">                                                                 
                                    <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Archivos Soporte !!! 
                                </div>
                            </EmptyDataTemplate>

                            <Columns>                                                

                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-VerticalAlign="Middle"
                                        ItemStyle-HorizontalAlign="Center" >                                            
                                    <ItemTemplate >
                                                                   
                                                        
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" 
                                                CssClass="btn btn-success btn-xs" 
                                                NavigateUrl='<%# Eval("sopdev_Url") %>'>                                                    
                                                <span class="glyphicon glyphicon-file "> </span>                                                                                                                       
                                                </asp:HyperLink>

                                                                              
                                            <asp:linkButton CommandName="Select"  
                                                CssClass="btn btn-danger btn-xs"  
                                                id="botonEliminar" runat="server"                                                                                      
                                                data-toggle="tooltip" 
                                                OnClientClick="if (!confirm('Esta seguro de Eliminar el Archivo Soporte ?')) return false;" 
                                                title="Eliminar">
                                                    <span class="glyphicon glyphicon-trash "></span>
                                            </asp:linkButton>                             
                                            
                                                                        
                                    </ItemTemplate>                                        
                                </asp:TemplateField>
                                        
                                <asp:BoundField DataField="sopdev_Nombre" HeaderText="Nombre Soporte" />
                                <asp:BoundField DataField="sopdev_Url" HeaderText="Url Soporte" />

                                                        
                            </Columns>
                
                        </asp:GridView>
                      </asp:Panel>
                      </center>
                  </div>
              </div>
          </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="udpProgres" runat="server">
        <ContentTemplate>
             <asp:UpdateProgress ID="uppProgress" runat="server"  OnLoad="Page_Load">
                            <ProgressTemplate>
                               <div class="contenedor-loader">
                                    <div class='loader'>
                                        <h6><p style="text-align:center"><b>Realizando su consulta, por favor espere...<br /></b></p></h6>
                                    </div>
                               </div>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script src="../Scripts/jquery-1.11.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var tabs = $("#tabs").tabs({
                activate: function (event, ui) {
                    localStorage.setItem("accIndex", $(this).tabs("option", "active"))
                },
                active: parseInt(localStorage.getItem("accIndex"))
            });
        });
    </script> 
</asp:Content>

