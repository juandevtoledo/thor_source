<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarCertificado.aspx.cs" Inherits="Presentacion_ModificarCertificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--validadores-->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <center><h3>Digitar Certificado</h3></center>
    
    <div id="tabs">
                 <ul>
                    <li><a href="#tabs-1" onclick="validarTabs();" class="tab-pane fade in active">Certificado</a></li>
                    <li><a href="#tabs-2"  onclick="validarTabs();">Principal</a></li>
                    <li><a href="#tabs-3"  onclick="validarTabs();">Conyuge</a></li>
                     <li><a href="#tabs-4"  onclick="validarTabs();">Otros Asegurados</a></li>
                  </ul>
       <div class="row">
            <div id="tabs-1">
                    <div class="col-md-12">
                            <fieldset>
                                <legend>Digitar Certificado</legend>   
                                 <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>                          
                                       <div class="row">
                                                    <div class="col-md-3">                                          
                                                      <div class="form-group">
                                                          <asp:Label ID="lblCompania" runat="server" Font-Bold="true"  CssClass="labels" Text="Compañia"></asp:Label>
                                                          <asp:TextBox Enabled="false" runat="server" ID="txtCompania" CssClass="form-control" ></asp:TextBox>
                                                      </div>                                             
                                                    </div>
                                                    <div class="col-md-3">                                          
                                                      <div class="form-group">
                                                          <asp:Label ID="lblProducto" runat="server" Font-Bold="true"  CssClass="labels" Text="Producto"></asp:Label>
                                                          <asp:DropDownList ID="ddlProducto"  Enabled="false"  runat="server" CssClass="form-control">
                                                          </asp:DropDownList>
                                                      </div>                                             
                                                    </div>
                                                   <div class="col-md-3">                                          
                                                      <div class="form-group">
                                                          <asp:Label ID="lblFechaExpedicion" runat="server" Font-Bold="true"  CssClass="labels" Text="Fecha Expedición"></asp:Label>
                                                          <asp:TextBox runat="server" type="date" ID="txtFechaExpedicionCertificado" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox>
                                                      </div>                                             
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                          <asp:Label ID="lblFechaVigencia" runat="server"  Text="Fecha Vigencia" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                          <asp:TextBox runat="server" Type="date" ID="txtFechaVigenciaCertificado" CssClass="form-control" placeholder="DD/MM/AAAA" ></asp:TextBox>
                                                        </div>      
                                                    </div>
                                        </div>
                                         </ContentTemplate>
                               </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                           <div class="row">
                                               <div class="col-md-3">
                                                         <div class="form-group">
                                                           <asp:Label ID="lblFechaDigitacion" runat="server" Font-Bold="true"  CssClass="labels" Text="Fecha Digitación"></asp:Label>
                                                              <asp:TextBox Enabled="false" runat="server"  ID="txtFechaDigitacionCertificado" CssClass="form-control"  ></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="reqFechaDigitacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaDigitacionCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                         </div>      
                                                    </div>
                                                   <div class="col-md-3">
                                                        <div class="form-group">
                                                            <asp:Label ID="lblNumeroCertificado" runat="server" Font-Bold="true"  CssClass="labels" Text="Numero Certificado"></asp:Label>
                                                            <asp:TextBox runat="server" ID="txtCertificado" CssClass="form-control" placeholder="Ingresar Certificado"></asp:TextBox>
                                                         </div>                   
                                                   </div>
                                               <div class="col-md-3">
                                                    <div class="form-group">
                                                      <asp:Label ID="lblNombreAsesor" runat="server" Text="Nombre Asesor" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:TextBox ID="txtNombreAsesor" CssClass="form-control" runat="server"></asp:TextBox>                                
                                                     </div>
                                               </div>
                                               <div class="col-md-3">
                                                     <div class="form-group">
                                                          <asp:Label ID="lblPeriodoDePago" runat="server" Text="Periodo de pago" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                            <asp:DropDownList CssClass="ddl" ID="ddlperiodoPagoCertificado" runat="server"></asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="reqddlperiodoPagoCertificado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlperiodoPagoCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </div>                                  
                                           </div>
                                        </div>
                                      </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                 <div class="form-group">
                                                     <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                     <asp:DropDownList  CssClass="ddl" ID="ddlLocalidadCertificado" AutoPostBack="true" OnSelectedIndexChanged="consultarPolizaPorProducto" OnClientClick="localStorage.setItem('accIndex', 0);" runat="server">
                                                     </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="reqddlLocalidadCertificado" runat="server" ErrorMessage="* obligatorio" ControlToValidate="ddlLocalidadCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                      <asp:RequiredFieldValidator ID="reqddlLocalidadCertificadoFase1" runat="server" ErrorMessage="* obligatorio" ControlToValidate="ddlLocalidadCertificado"  ValidationGroup="grpValidacionCertificadoFase1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                 </div>    
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="form-group">
                                                   <asp:Label ID="lblPoliza" runat="server" Font-Bold="true"  CssClass="labels" Text="Poliza"></asp:Label>
                                                    <asp:DropDownList ID="ddlPoliza" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="consultarPlanPorPoliza" OnClientClick="localStorage.setItem('accIndex', 0);" runat="server">
                                                    </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="reqPoliza" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPoliza"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                               </div>     
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                     <asp:Label ID="lblAgencia" runat="server" Text="Agencia" Font-Bold="true"  CssClass="labels DigitarCertificadoAgencia"></asp:Label>
                                                      <asp:TextBox ID="txtAgencia"  CssClass="form-control DigitarCertificadoAgencia" runat="server"></asp:TextBox>                      
                                                 </div>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblMesProduccion" runat="server" Text="Mes Produccion" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:TextBox Enabled="false" ID="txtmesProduccion" CssClass="form-control" runat="server" placeholder="DD/MM/AAAA"></asp:TextBox>
                                            </div>
                                        </div>
                                      </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Label ID="lblEstadoNegocio" runat="server" Text="Estado Negocio" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:TextBox  ID="txtEstadoNegocio" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblDeclaracionAsegurabilidad" runat="server" Text="Declaración asegurabilidad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:TextBox type="number" ID="txtDeclaracionAsegurado" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqtxtDeclaracionAsegurado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDeclaracionAsegurado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblDeclaracionEG" runat="server" Text="Declaración EG" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:TextBox type="number" ID="txtDeclaracionEG" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqDeclaracionEG" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDeclaracionEG"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-3">
                                      
                                            </div>
                                        </div>
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                  <div class="form-group">
                                                  <asp:Label ID="lblHServicio1" runat="server" Text="Hoja.Servicio 1" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                  <asp:TextBox runat="server" ID="txtHServicio1" CssClass="form-control" placeholder=""></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="ReqtxtHServicio1" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHServicio1"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                               </div>
                                            </div>
                                            <div class="col-md-3">
                                               <div class="form-group">
                                                  <asp:Label ID="lblHServicio2" runat="server" Text="Hoja.Servicio 2" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                  <asp:TextBox runat="server" ID="txtHServicio2" CssClass="form-control" placeholder=""></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtHServicio2" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHServicio2"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                               </div>
                                            </div>
                                            <div class="col-md-3">
                                               <div class="form-group">
                                                  <asp:Label ID="lblHServicio3" runat="server" Text="Hoja.Servicio 3" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                  <asp:TextBox runat="server" ID="txtHServicio3" CssClass="form-control" placeholder=""></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="reqtxtHServicio3" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHServicio3"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                               </div>
                                            </div>
                                            <div class="col-md-3">
                                               <div class="form-group">
                                                  <asp:Label ID="lblAnexoConversion" runat="server" Text="Anexo Conversión" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                  <asp:TextBox runat="server" ID="txtAnexoConversion" CssClass="form-control" placeholder=""></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="reqtxtAnexoConversion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtAnexoConversion"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                               </div>
                                            </div>
                                        </div>
                                     </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                 <asp:Label ID="lblTipoMovimiento" runat="server" Text="Tipo Movimiento" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                <asp:TextBox  Enabled="false" ID="txtTipoMovimiento" TextMode="MultiLine" CssClass="form-control" runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                      </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-2"></div>
                                            <div class="col-md-3">
                                                 <asp:Button ID="btnCambiosPreCargue" CssClass="btn btn-primary" runat="server" Text="CAMBIOS DATOS PRECARGUE" OnClick="btnCambiosPreCargue_Click"></asp:Button>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Button ID="btnGuardarCambios" CssClass="btn btn-primary" runat="server" Text="GUARDAR CAMBIOS" OnClick="btnGuardarCambios_Click" ValidationGroup="grpValidacionCertificadoPreCargado"></asp:Button>
                                            </div>
                                            <div class="col-md-2">
                                                  <asp:Button ID="btnValidarCertificado" CssClass="btn btn-primary btnValidarCertificado" runat="server" Text="VALIDAR" OnClick="btnValidarCertificado_Click"></asp:Button>
                                            </div>
                                            <div class="col-md-1">
                                                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                         <asp:ImageButton ID="btnSiguienteCertificado"  CssClass="btn btn-default btnAtrasSiguiente" OnClientClick="$('#tabs').tabs('enable',1);  $('#tabs').tabs({ active: [1] }); $('#tabs').tabs({ disabled: [0, 2, 3] }); localStorage.setItem('accIndex', 1);" runat="server"   ImageUrl="~/Imagenes/Siguiente.png" ></asp:ImageButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                     </ContentTemplate>
                                </asp:UpdatePanel>
                        </fieldset>
                        </div>
                    </div>
                     <div  id="tabs-2">
                            <fieldset>
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                   <ContentTemplate>
                                      <legend runat="server" id="legAseguradoPrincipal">Asegurado Principal</legend>
                                     </ContentTemplate>
                                </asp:UpdatePanel>
                                 <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                    <ContentTemplate>
                                            <div class="row">
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                            <asp:Label  runat="server" Text="Cedula" ID="labCedula" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server" ID="txtCedulaPrincipal" CssClass="form-control" value=""></asp:TextBox>
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                            <asp:Label  runat="server" Text="Nombres" ID="labNombre" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server" ID="txtNombrePrincipal" CssClass="form-control" value="" ></asp:TextBox>
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                            <asp:Label  runat="server" Text="Apellidos" ID="labApellidos" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                <asp:TextBox runat="server" ID="txtApellidoPrincipal" CssClass="form-control" value="" ></asp:TextBox>
                                                         </div>
                                                    </div>
                                                 <div class="col-md-3">
                                                        <div class="form-group">
                                                           <asp:Label runat="server" Text="Edad" ID="labEdad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                           <asp:TextBox runat="server" ID="txtEdadPrincipal"  CssClass="form-control" value="" ></asp:TextBox>
                                                        </div>
                                                  </div>
                                                <div class="col-md-1"></div>  
                                            </div>
                                          </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                       <ContentTemplate>
                                            <div class="row">                                   
                                                 <div class="col-md-3">
                                                      <div class="form-group">
                                                       <asp:Label ID="lblPrimaPrincipal" runat="server" Text="Prima principal" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                              <ContentTemplate>
                                                                <asp:TextBox ID="txtPrimaPrincipal" CssClass="form-control" OnTextChanged="txtPrimaPrincipal_TextChanged" runat="server"></asp:TextBox>   
                                                              </ContentTemplate>
                                                          </asp:UpdatePanel>
                                                      </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label  runat="server" Text="Pagaduría" ID="labPagaduria" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:TextBox ID="txtPagaduriaPrincipal" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlPagaduriaPrincipal" AutoPostBack="true" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlPagaduriaPrincipal_SelectedIndexChanged" OnClientClick="localStorage.setItem('accIndex', 2);">
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>                                        
                                                    <asp:RequiredFieldValidator ID="reqddlPagaduriaPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPagaduriaPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>     
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label  runat="server" Text="Convenio" ID="labConvenio" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:DropDownList ID="ddlConvenioPrincipal" AutoPostBack="true" runat="server" CssClass="ddl">
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>       
                                                    <asp:RequiredFieldValidator ID="reqddlConvenioPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlConvenioPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                      
                                                
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label  runat="server" Text="Plan" ID="labPlan1" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:DropDownList ID="ddlPlanPrincipal" AutoPostBack="true" OnSelectedIndexChanged="ConsultarAmparosPlan"  runat="server" CssClass="ddl">
                                                            <asp:ListItem></asp:ListItem>
                                                        </asp:DropDownList>         
                                                     <asp:RequiredFieldValidator ID="ReqddlPlanPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPlanPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                              
                                                </div>
                                          </div>
                                       </ContentTemplate>
                                  </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                     <asp:Label ID="lblExtraPrimaPrincipal" runat="server" Text="Extra Prima"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                           <asp:TextBox ID="txtExtraPrimaPrincipal" CssClass="form-control" runat="server"></asp:TextBox>   
                                                        </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lblOcupacionPrincipal" runat="server" Text="Ocupacion"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:DropDownList Enabled="false" ID="ddlOcupacionPrincipal" runat="server" CssClass="form-control" >

                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="labPeso" runat="server"  Text="Peso" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:TextBox type="number" runat="server" ID="txtpesoPrincipal" CssClass="form-control" placeholder="Ingresar Peso" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPesoPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtpesoPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-3">                                            
                                                    <asp:Label ID="labEstatura" runat="server" Text="Estatura" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:TextBox type="number"  runat="server" ID="txtestaturaPrincipal" CssClass="form-control" placeholder="Ingresar Estatura" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtestaturaPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtestaturaPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                        </div>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                              <div class="col-md-3">
                                                  <asp:Label  runat="server" Text="lblPlantel" ID="lblPlantel" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                    <asp:DropDownList  ID="ddlPlantel" runat="server" CssClass="ddl" >
                                                    </asp:DropDownList>
                                             </div>
                                             <div class="col-md-3">
                                                <asp:Label  runat="server" Text="Plan" ID="labPlan" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                  <asp:TextBox type="number" runat="server" ID="txtPlanPrincipal" CssClass="form-control" AutoPostBack="true" value="" OnTextChanged="txtPlanPrincipal_TextChanged" OnClientClick="localStorage.setItem('accIndex', 1);" ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="reqtxtPlanPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPlanPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                      </ContentTemplate>
                                  </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-12">
                                        
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 runat="server" id="amparosPrincipal">Amparos Asegurado Principal</h4>
                                            
                                                    <asp:GridView ID="grvAmparoPrincipal" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDeleting="grvAmparoPrincipal_RowDeleting">
                                                      <Columns>
                                                          <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True"  />
                                                      </Columns>                                                   
                                                   </asp:GridView>                                                                                          
                                             </div>
                                            <br />
                                            </div>
                                         </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                                <div class="col-md-12">
                                                    <h4>Beneficiario Principal</h4>                                            
                                                       <asp:GridView ID="grvBeneficiarioPrincipal" CssClass="table table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False" OnRowCommand="grvBeneficiarioPrincipal_RowCommand" ShowFooter="True" OnRowDeleting="grvBeneficiarioPrincipal_RowDeleting1" OnDataBound="grvBeneficiarioPrincipal_OnDataBound" >
                                                           <Columns>
                                                               <asp:TemplateField HeaderText="nombre" SortExpression="Nombre">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nombres") %>' MaxLength="40" ></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox ID="txtNewNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNombreBeneficiarioOtros" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewNombre"  ValidationGroup="grpValidacionBeneficiarioPrincipal" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombres") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="apellidos" SortExpression="Apellidos">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Apellidos") %>' MaxLength="40" ></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox ID="txtNewApellido" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewApellidoBeneficiarioOtros" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewApellido"  ValidationGroup="grpValidacionBeneficiarioPrincipal" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Identificación" SortExpression="Cedula">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox  type="number" ID="txtNewCedula" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewCedula" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewCedula"  ValidationGroup="grpValidacionBeneficiarioPrincipal" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="edad" SortExpression="Edad">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Edad") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox type="number"  ID="txtNewEdad" runat="server" CssClass="form-control" MaxLength="2"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewEdad" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewEdad"  ValidationGroup="grpValidacionBeneficiarioPrincipal" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                           
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("Edad") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="porcentaje" SortExpression="Porcentaje">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Porcentaje") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox type="number" ID="txtNewPorcentaje" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="txtNewPorcentajeBeneficiarioOtros" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewPorcentaje"  ValidationGroup="grpValidacionBeneficiarioPrincipal" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("Porcentaje") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="parentesco" SortExpression="Parentesco">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:DropDownList ID="txtNewParentesco" runat="server" CssClass="form-control" Width="130px">
                                                                  
                                                                       </asp:DropDownList>
                                                                       <asp:LinkButton ID="LinkButton1" runat="server" CommandName="addNew" OnClientClick="localStorage.setItem('accIndex', 1);" ValidationGroup="grpValidacionBeneficiarioPrincipal">Agregar</asp:LinkButton>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="True"  >
                                                               <ControlStyle CssClass="btn btn-danger" />
                                                               </asp:CommandField>
                                                           </Columns>
                                                      </asp:GridView>
                                                 </div> 
                                         </div>
                                     </ContentTemplate>
                              </asp:UpdatePanel>
                            </fieldset>
                         <div class="row">
                                    <div class="col-md-12" id="divExtraPrima">
                                          <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnExtraPrima" cssclass="btn btn-primary  btn-xs" data-toggle="modal" data-target="#miventana3" runat="server" Text="Extra Prima" />
                                                </ContentTemplate>
                                          </asp:UpdatePanel>
                                            <div class="modal fade" id="miventana3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                <div class="modal-dialog">
                                                    <div class="modal-content" id="modal2">
                                                       <div class="modal-header">
                                                              <center><h4>Extra Prima</h4></center>
                                                           <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                               <ContentTemplate>
                                                                 <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true"/>   
                                                               </ContentTemplate>
                                                            </asp:UpdatePanel>                                       
                                                        </div>
                                                        <div class="modal-body">      
                                                              <div class="row">
                                                                <div class="col-md-1"></div>
                                                                     <div class="col-md-10">
                                                                        <div class="row">
                                                                            <fieldset>
                                                                                    <div class="col-md-1"></div>
                                                                                        
                                                                                    <div class="row">
                                                                                        <div class="col-md-12">
                                                                                            <fieldset>
                                                                                                <legend>Asignar valor de Extra Primas</legend>                                                                                                
                                                                                                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                       <ContentTemplate>                                                
                                                                                                          <asp:GridView ID="grvAmparoExtraPrima" OnRowUpdating="grvAmparoExtraPrima_RowUpdating" OnRowCancelingEdit="grvAmparoExtraPrima_RowCancelingEdit" OnRowEditing="grvAmparoExtraPrima_RowEditing" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDeleting="grvAmparoPrincipal_RowDeleting">
                                                                                                            <Columns>
                                                                                                                <asp:CommandField EditText="Editar" ShowEditButton="true" />                                                                                                        
                                                                                                            </Columns>
                                                                                                          </asp:GridView>
                                                                                                       </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                <br />   
                                                                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                                                      <ContentTemplate>                                                                                    
                                                                                                         <asp:GridView ID="grvHistorialExtraPrima" CssClass="table table-bordered table-hover table-striped" runat="server">

                                                                                                         </asp:GridView>
                                                                                                      </ContentTemplate>
                                                                                                 </asp:UpdatePanel>
                                                                                                <br />
                                                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                                   <ContentTemplate>
                                                                                                     <div class="row">
                                                                                                        <div class="col-md-3">
                                                                                                             <asp:Label ID="lblPrimaPrincipalExtraprima" runat="server" Font-Bold="true"  CssClass="labels" Text="Prima"></asp:Label>  
                                                                                                             <asp:TextBox ID="txtPrimaPrincipalExtraprima" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1"></div>
                                                                                                        <div class="col-md-3">
                                                                                                            <asp:Label ID="lblPrincipalExtraprima" runat="server" Font-Bold="true"  CssClass="labels" Text="Extra Prima"></asp:Label>
                                                                                                            <asp:TextBox ID="txtPrincipalExtraprima" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    </ContentTemplate>
                                                                                                 </asp:UpdatePanel>
                                                                                                <br />
                                                                                            </fieldset>
                                                                                            <br />
                                                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                                               <ContentTemplate> 
                                                                                                <asp:GridView ID="grvConsultarHistirialPorcentajeExtraPrimado" CssClass="table table-bordered table-hover table-striped" runat="server">

                                                                                                </asp:GridView>
                                                                                              </ContentTemplate>
                                                                                           </asp:UpdatePanel>
                                                                                        </div>
                                                                                    </div>
                                                                            </fieldset>
                                                                        </div>
                                                                     </div>
                                                                 <div class="col-md-1"></div>  
                                                            </div>                                                                                                                              
                                                       </div>
                                                    <div class="modal-footer">
                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                 <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                <ContentTemplate> 
                                                                      <asp:Button ID="Button4" cssClass="btn btn-default" runat="server" Text="RESTAURAR" OnClick="btnX_Click" />
                                                                </ContentTemplate>
                                                          </asp:UpdatePanel> 
                                                            </div>
                                                            <div class="col-md-8"></div>
                                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                 <ContentTemplate>
                                                                    <div class="col-md-2">
                                                                         <asp:Button ID="btnCerarExtraPrima1" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="CERRAR" />
                                                                    </div>
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
                            <div class="row">
                                <div class="col-md-1">
                                     <asp:ImageButton ID="btnAtrasPrincipal"  CssClass="btn btn-default btnAtrasSiguiente" OnClick="btnAtrasPrincipal_Click" OnClientClick="localStorage.setItem('accIndex', 0);$('#tabs').tabs({ active: 0 });"  runat="server" ImageUrl="~/Imagenes/Atras.png" />
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-10">
                                            <center>
                                                <asp:Button ID="btnValidarPrincipal" CssClass="btn btn-primary"  OnClientClick="localStorage.setItem('accIndex', 1);" runat="server" Text="VALIDAR" OnClick="btnValidarPrincipal_Click"></asp:Button>
                                            </center>
                                        </div>
                                      </ContentTemplate>
                                 </asp:UpdatePanel>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="btnSiguientePrincipal"  CssClass="btn btn-default btnAtrasSiguiente" OnClientClick="localStorage.setItem('accIndex', 2); $('#tabs').tabs({ active: 2 });" onclick="btnSiguientePrincipal_Click"  runat="server" ImageUrl="~/Imagenes/Siguiente.png" />
                                    
                                </div>
                            </div>
                         </div>
                 <div id="tabs-3">
                            <fieldset>
                                <legend>Asegurado Conyuge</legend>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                        <div class="col-md-5">
                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                <ContentTemplate>
                                                     <div class="form-group">
                                                         <asp:Label ID="lblDocumentoConyuge" runat="server" Text="Documento" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                         <asp:TextBox type="number"  runat="server" ID="txtDocumentoConyugue" CssClass="form-control" placeholder="Ingresar Documento Conyugue" >
                                                         </asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="reqDocumentoConyuge" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDocumentoConyugue"  ValidationGroup="grpValidacionConyugeBusqueda" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                     </div>
                                                </ContentTemplate>
                                             </asp:UpdatePanel>
                                        </div>
                                            <div class="col-md-2" id="divConsultarConyuge">  
                                                <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                                    <ContentTemplate> 
                                                     <asp:Button ID="boton1" cssClass="btn btn-primary DigitarbtnBuscar" AutoPostBack="true" OnClick="ConsultarTerceroCertificado" OnClientClick="localStorage.setItem('accIndex', 2);" runat="server" Text="BUSCAR" ValidationGroup="grpValidacionConyugeBusqueda" />      
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>                                           
                                            </div>
                                         <div class="col-md-1" id="divInsertarConyuge">  
                                             <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                                                 <ContentTemplate> 
                                                    <asp:Button ID="Button1" runat="server" class="btn btn-danger DigitarbtnRegistrar" data-toggle="modal" data-target=".bs-example-modal-lg" Text="INSERTAR" />
                                                  </ContentTemplate>
                                              </asp:UpdatePanel>
                                            <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                                              <div class="modal-dialog modal-lg">
                                                <div class="modal-content" id="modalContentTerceroConyuge">
                                                  <center><h4>Registrar Conyuge</h4></center>
                                                    <hr />
                                                    <div class="row">
                                                                <div class="col-md-12" id="divRegistrarConyuge">
                                                                    <fieldset>
                                                                            <div class="row">
                                                                                <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                 <asp:Label ID="lblNombreTercero" runat="server" Text="Nombre*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox  runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                                                                                                     <asp:RequiredFieldValidator ID="reqtxtNombre" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombre"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblApellidoTercero" runat="server" Text="Apellidos*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqTxtApellido" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtApellido"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                     </ContentTemplate>
                                                                                 </asp:UpdatePanel>
                                                                                 <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                                                                                     <ContentTemplate>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblFechaNacimientoTercero" runat="server" Text="Fecha Nacimiento*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                 <asp:TextBox runat="server" type="date" ID="txtNacimiento" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqTxtNacimiento" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNacimiento"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                     </ContentTemplate>
                                                                                 </asp:UpdatePanel>
                                                                             </div>
                                                                        <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="row">
                                                                                    <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblEdadTercero" runat="server" Text="Edad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox Enabled="false" runat="server" ID="txtEdad" CssClass="form-control"></asp:TextBox>
                                                                                             </div>
                                                                                        </div>
                                                                                     <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                   <div class="form-group"> 
                                                                                                       <asp:DropDownList CssClass="form-control" ID="ddlTipoDocumentoTercero" runat="server">
                                                                                                       </asp:DropDownList>                                                                   
                                                                                                       <asp:RequiredFieldValidator ID="redddlTipoDocumento" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlTipoDocumentoTercero"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>           
                                                                                                   </div>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblNumeroIdentificacion" runat="server" Text="Numero Identificación*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox type="number"  runat="server" ID="txtIdentificacion" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtIdentificacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtIdentificacion"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>   
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                           <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                                                                                 <ContentTemplate>
                                                                                    <div class="row">
                                                                                         <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                                      <ContentTemplate>
                                                                                                        <asp:Label ID="lblDepartamentoTercero" runat="server" Text="Departamento*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                        <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" OnClientClick="localStorage.setItem('accIndex', 2);">
                                                                                                        </asp:DropDownList>
                                                                                                       <asp:RequiredFieldValidator ID="reqddlDepartamento" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlDepartamento"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                 <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                         <asp:Label ID="lblCiudadTercero" runat="server" Text="Ciudad*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                         <asp:DropDownList CssClass="form-control" ID="ddlCiudad" runat="server">
                                                                                                         </asp:DropDownList>
                                                                                                         <asp:RequiredFieldValidator ID="reqddlCiudad" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlCiudad"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblCorreoTercero" runat="server" Text="Correo*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox type="email"  runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                                                                                             </div>
                                                                                        </div> 
                                                                                    </div>
                                                                                 </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                           <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                                                                                 <ContentTemplate>
                                                                                    <div class="row">
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblCelularTercero" runat="server" Text="Celular" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox type="number" runat="server" ID="txtCelular"  CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtCelular" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtCelular"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblTelefonoUnoTercero" runat="server" Text="Telefono 1" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                   <asp:TextBox type="number"  runat="server" ID="txtTelefono1" CssClass="form-control"></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtTelefono1" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono1"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <asp:Label ID="lblTelefonoDosTercero" runat="server" Text="Telefono 2" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                    <asp:TextBox type="number" runat="server" ID="txtTelefono2" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtTelefono2" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono2"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                    </div>
                                                                                 </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                                 <ContentTemplate>
                                                                                     <div class="row">
                                                                                            <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                        <asp:Label ID="lblDireccionTercero" runat="server" Text="Direccion*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                        <asp:TextBox   runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
                                                                                                     <asp:RequiredFieldValidator ID="reqtxtDireccion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDireccion"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                 </div>
                                                                                            </div>
                                                                                         <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                        <asp:Label ID="lblSexoTercero" runat="server" Text="Sexo*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                        <div class="form-group"> 
                                                                                                            <asp:DropDownList CssClass="form-control" ID="ddlGeneroTercero" runat="server" >
                                                                                                               <asp:ListItem>Seleccione el genero</asp:ListItem>
                                                                                                               <asp:ListItem>MASCULINO</asp:ListItem>
                                                                                                               <asp:ListItem>FEMENINO</asp:ListItem>
                                                                                                           </asp:DropDownList>    
                                                                                                            <asp:RequiredFieldValidator ID="reqddlGeneroTercero" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlGeneroTercero"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                   
                                                                                                        </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                         <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                       <div class="form-group">
                                                                                                        <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                            <div class="form-group"> 
                                                                                                                <asp:DropDownList CssClass="form-control" ID="ddlEstadoCivilTercero" runat="server">
                                                                                                               </asp:DropDownList>
                                                                                                                <asp:RequiredFieldValidator ID="reqddlEstadoCivilTercero" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlEstadoCivilTercero"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                             </div>
                                                                                                         </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                         </div>
                                                                                     </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                                                                                     <ContentTemplate>
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                 <div class="form-group">
                                                                                                        <asp:Label ID="lblOcupacionTercero" runat="server" Text="Ocupación" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                        <div class="form-group">  
                                                                                                             <asp:DropDownList CssClass="form-control" ID="ddlOcupacionTercero" runat="server">
                                                                                                             </asp:DropDownList> 
                                                                                                            <asp:RequiredFieldValidator ID="reqddlOcupacionTercero" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlOcupacionTercero"  ValidationGroup="grpValidacionAseguradoConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                 <div class="form-group">
                                                                                                        <asp:Label ID="lblEmpresaPlantelTercero" runat="server" Text="Empresa/Plantel*" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                                                        <asp:TextBox runat="server" Enabled="false" ID="txtTrabajo" CssClass="form-control"></asp:TextBox>
                                                                                                 </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                        <hr />
                                                                    </fieldset>
                                                                    <br />
                                                                    <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                         <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-md-5"></div>
                                                                                    <div class="col-md-2">
                                                                                          <asp:Button ID="botonRegistrarTercero" cssClass="btn btn-primary" runat="server" Text="REGISTRAR" OnClick="botonRegistrarTercero_Click" ValidationGroup="grpValidacionAseguradoConyuge"/>
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
                                    <div class="col-md-4"></div>
                                 </div>
                                 <hr />
                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                    <ContentTemplate>
                                            <div class="row">
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                             <asp:Label ID="lblCedulaConyuge" runat="server" Text="Cedula Conyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server"  ID="txtCedulaConyuge" CssClass="form-control" placeholder="Ingresar Cedula" ></asp:TextBox>
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                             <asp:Label ID="lblNombreConyuge" runat="server" Text="Nombre Conyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server"  ID="txtNombreConyuge" CssClass="form-control" placeholder="Ingresar Nombres" ></asp:TextBox>
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                         <div class="form-group">
                                                             <asp:Label ID="lblApellidoConyuge" runat="server" Text="Apellido Conyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server"  ID="txtApellidoConyuge" CssClass="form-control" placeholder="Ingresar Apellidos" ></asp:TextBox>
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <asp:Label ID="lblEdadConyuge" runat="server" Text="Edad" Font-Bold="true" CssClass="labels"></asp:Label>
                                                             <asp:TextBox runat="server"  ID="txtEdadConyuge" CssClass="form-control" placeholder="Ingresar Edad"></asp:TextBox>
                                                        </div>
                                                    </div>                   
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                  <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                      <ContentTemplate>
                                        <div class="row">
                                                 <div class="col-md-3">
                                                        <asp:Label ID="lblPrimaConyuge" runat="server" Text="Prima" Font-Bold="true" CssClass="labels"></asp:Label>
                                                <asp:TextBox ID="txtPrimaConyuge" CssClass="form-control" OnTextChanged="txtPrimaConyuge_TextChanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lblPlan2" runat="server" Text="Plan" Font-Bold="true" CssClass="labels"></asp:Label>
                                                        <asp:DropDownList  ID="ddlPlanConyuge"  CssClass="ddl"  AutoPostBack="true" OnSelectedIndexChanged="ConsultarAmparosPlanConyuge" OnClientClick="localStorage.setItem('accIndex', 2);" runat="server">                                                    
                                                        </asp:DropDownList> 
                                                     <asp:RequiredFieldValidator ID="reqddlPlanConyuge" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPlanConyuge"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                     
                                                 </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lblPesoConyuge" runat="server" Text="Peso" Font-Bold="true" CssClass="labels"></asp:Label>
                                                        <asp:TextBox type="number" runat="server"  ID="txtPeso" CssClass="form-control" placeholder="Ingresar Peso" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="reqtxtPeso" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPeso"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lblEstaturaConyuge" runat="server" Text="Estatura" Font-Bold="true" CssClass="labels"></asp:Label>
                                                        <asp:TextBox type="number"  runat="server"  ID="txtEstatura" CssClass="form-control" placeholder="Ingresar Estatura" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="reqtxtEstatura" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtEstatura"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                 <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                   <asp:Label ID="lblPlan" runat="server" Text="Plan" Font-Bold="true" CssClass="labels"></asp:Label>
                                                   <asp:TextBox type="number" runat="server"  ID="txtPlanConyuge"   CssClass="form-control" AutoPostBack="true" placeholder="Ingresar Plan" OnTextChanged="txtPlanConyuge_TextChanged" OnClientClick="localStorage.setItem('accIndex', 2);" ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtPlanConyuge" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPlanConyuge"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                     <asp:Label ID="lblExtraPrimaConyuge" runat="server" Text="Extra Prima"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                           <asp:TextBox ID="txtExtraPrimaConyuge" CssClass="form-control" runat="server"></asp:TextBox>   
                                                        </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                 <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                                <div class="col-md-12">
                                                     <h4 runat="server" id="amparosConyuge">Amparos Asegurado Conyuge</h4>
                                                      <asp:GridView ID="grvAmparoConyuge" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDeleting="grvAmparoConyuge_RowDeleting">
                                                          <Columns>
                                                              <asp:CommandField ShowDeleteButton="True" />
                                                          </Columns>

                                                    </asp:GridView>
                                               </div>
                                          </div>
                                        </ContentTemplate>
                                   </asp:UpdatePanel>
                                   <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                      <ContentTemplate>
                                        <div class="row">
                                                <div class="col-md-12">
                                                    <h4 runat="server" id="beneficiariosConyuge">Beneficiarios Conyuge</h4>
                                                      <asp:GridView Enabled="true" Visible="true" ID="grvBeneficiarioConyuge" CssClass="table table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False"  OnRowCommand="grvBeneficiarioConyuge_RowCommand" ShowFooter="true" OnRowDeleting="grvBeneficiarioConyuge_RowDeleting" OnDataBound="grvBeneficiarioConyuge_OnDataBound">
                                                            <Columns>
                                                               <asp:TemplateField HeaderText="nombre" SortExpression="Nombre">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nombres") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox ID="txtNewNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewNombreBeneficiario" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewNombre"  ValidationGroup="grpValidacionbeneficiarioConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombres") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="apellidos" SortExpression="Apellidos">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Apellidos") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox ID="txtNewApellido" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewApellidoBeneficiario" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewApellido"  ValidationGroup="grpValidacionbeneficiarioConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Identificación" SortExpression="Cedula">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cedula") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox type="number"  ID="txtNewCedula" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewCedula" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewCedula"  ValidationGroup="grpValidacionbeneficiarioConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="edad" SortExpression="Edad">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Edad") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox type="number"  ID="txtNewEdad" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewEdad" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewEdad"  ValidationGroup="grpValidacionbeneficiarioConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("Edad") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="porcentaje" SortExpression="Porcentaje">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Porcentaje") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:TextBox type="number" ID="txtNewPorcentaje" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="reqtxtNewPorcentajeBeneficiario" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNewPorcentaje"  ValidationGroup="grpValidacionbeneficiarioConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("Porcentaje") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="parentesco" SortExpression="Parentesco">
                                                                   <EditItemTemplate>
                                                                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:TextBox>
                                                                   </EditItemTemplate>
                                                                   <FooterTemplate>
                                                                       <asp:DropDownList ID="ddlNewParentesco" runat="server" CssClass="form-control" Width="130px">
                                                                 
                                                                       </asp:DropDownList>
                                                                       <asp:LinkButton ID="LinkButton2" runat="server" CommandName="addNew"  OnClientClick="localStorage.setItem('accIndex', 2);" ValidationGroup="grpValidacionbeneficiarioConyuge">Agregar</asp:LinkButton>
                                                                   </FooterTemplate>
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="True">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                                </asp:CommandField>
                                                           </Columns>
                                                       </asp:GridView>
                                                </div>
                                            </div>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                           <div class="row">
                                                 <div class="col-md-1">
                                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                          <ContentTemplate>
                                                                <asp:Button ID="btnExtraPrima2"  cssclass="btn btn-primary btn-xs btnXs" data-toggle="modal" data-target="#miventana2" runat="server" Text="Extra Prima" />
                                                              </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="modal fade" id="miventana2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                            <div class="modal-dialog">
                                                                <div class="modal-content" id="modal3">
                                                                   <div class="modal-header">
                                                                           <center><h4>Extra Prima</h4></center>
                                                                       <asp:Button ID="cerrarModal3" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true"/>                                          
                                                                    </div>
                                                                    <div class="modal-body">      
                                                                          <div class="row">
                                                                              <div class="col-md-1"></div>
                                                                                 <div class="col-md-10">
                                                                                    <div class="row">
                                                                                        <fieldset>                                                              
                                                                                            <div class="col-md-1"></div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-12">
                                                                                                        <fieldset>
                                                                                                            <legend>Historico de valores asegurados para las extra primas</legend>
                                                                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                                                   <ContentTemplate>   
                                                                                                                         <asp:GridView ID="grvExtraPrimaConyuge" OnRowUpdating="grvExtraPrimaConyuge_RowUpdating" OnRowCancelingEdit="grvExtraPrimaConyuge_RowCancelingEdit" OnRowEditing="grvExtraPrimaConyuge_RowEditing" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                                                                                         <Columns>
                                                                                                                           <asp:CommandField EditText="Editar" ShowEditButton="true" />                                                                                                        
                                                                                                                         </Columns>
                                                                                                                     </asp:GridView>  
                                                                                                                   </ContentTemplate>
                                                                                                               </asp:UpdatePanel>
                                                                                                            <br /> 
                                                                                                            <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                                                                 <ContentTemplate>
                                                                                                                      <asp:GridView ID="grvHistorialExtraPrimaConyuge" CssClass="table table-bordered table-hover table-striped" runat="server">

                                                                                                                     </asp:GridView>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                            <br />
                                                                                                            <br />
                                                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                                                <ContentTemplate> 
                                                                                                                     <div class="row">
                                                                                                                        <div class="col-md-3">
                                                                                                                             <asp:Label ID="lblPrimaPrincipalExtraprimaConyuge" runat="server" Font-Bold="true"  CssClass="labels" Text="Prima"></asp:Label>  
                                                                                                                             <asp:TextBox ID="txtPrimaPrincipalExtraprimaConyuge" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                                        </div>
                                                                                                                        <div class="col-md-1"></div>
                                                                                                                        <div class="col-md-3">
                                                                                                                            <asp:Label ID="lblPrincipalExtraprimaConyuge" runat="server" Font-Bold="true"  CssClass="labels" Text="Extra Prima"></asp:Label>
                                                                                                                            <asp:TextBox ID="txtPrincipalExtraprimaConyuge" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                 </ContentTemplate>
                                                                                                              </asp:UpdatePanel>
                                                                                                            <br />
                                                                                                        </fieldset>
                                                                                                        <br />
                                                                                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                                                           <ContentTemplate> 
                                                                                                            <asp:GridView ID="grvConsultarHistirialPorcentajeExtraPrimadoConyuge" CssClass="table table-bordered table-hover table-striped" runat="server">

                                                                                                            </asp:GridView>
                                                                                                          </ContentTemplate>
                                                                                                       </asp:UpdatePanel>
                                                                                                    </div>
                                                                                                </div>
                                                                                        </fieldset>
                                                                                    </div>
                                                                                     <div class="col-md-1"></div>
                                                                              </div> 
                                                                        </div> 
                                                                        <br />                                                                    
                                                                    </div>
                                                                <div class="modal-footer">
                                                                    <div class="row">
                                                                        <div class="col-md-2">
                                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                                <ContentTemplate> 
                                                                                      <asp:Button ID="btnX2" cssClass="btn btn-default" runat="server" Text="RESTAURAR" OnClick="btnX2_Click" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-8"></div>
                                                                        <div class="col-md-2">
                                                                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                                <ContentTemplate>
                                                                                     <asp:Button ID="btnCerarExtraPrima2" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="CERRAR" />   
                                                                                 </ContentTemplate>
                                                                             </asp:UpdatePanel>     
                                                                        </div>
                                                                    </div>
                                                                </div>                    
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <center>
                                                       <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                          <ContentTemplate>
                                                             <asp:Button  runat="server" ID="btnLimpiar" CssClass="btn btn-primary btn-xs btnXs" OnClick="limpiarConyuge_Click"  OnClientClick="localStorage.setItem('accIndex', 2);" Text="Limpiar"/>
                                                          </ContentTemplate>
                                                       </asp:UpdatePanel>
                                                    </center>
                                                </div>
                                            </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1">
                                        <asp:ImageButton ID="btnAtrasConyuge"  CssClass="btn btn-default btnAtrasSiguiente"  OnClientClick="localStorage.setItem('accIndex', 1); $('#tabs').tabs({ active: 1 });" OnClick="btnAtrasConyuge_Click" runat="server" ImageUrl="~/Imagenes/Atras.png" />
                                    </div>
                                    <div class="col-md-10">
                                        <center>
                                          <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                              <ContentTemplate>
                                                <asp:Button ID="btnValidarConyuge" CssClass="btn btn-primary" runat="server"  OnClientClick="localStorage.setItem('accIndex', 2);" Text="VALIDAR" OnClick="btnValidarConyuge_Click"></asp:Button>
                                              </ContentTemplate>
                                         </asp:UpdatePanel>
                                        </center>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:ImageButton ID="btnSiguienteConyuge"  CssClass="btn btn-default btnAtrasSiguiente" OnClientClick="localStorage.setItem('accIndex', 3); $('#tabs').tabs({ active: 3 });" runat="server" ImageUrl="~/Imagenes/Siguiente.png" />
                                    </div>
                                </div>
                            </fieldset>
                     </div>
                     <div id="tabs-4">
                            <fieldset>
                                <legend>Otros Asegurados</legend>
                               <div class="row">
                                    <div class="col-md-1"></div>
                                         <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-md-5">
                                                             <div class="form-group">
                                                                 <asp:Label ID="lblDocumentoOtros" runat="server" Text="Documento" Font-Bold="true" CssClass="labels"></asp:Label>
                                                                <asp:TextBox  runat="server" ID="txtDocumentoOtros" CssClass="form-control" placeholder="Ingresar Documento Otros" ></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="reqtxtDocumentoOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDocumentoOtros"  ValidationGroup="grpValidacionOtroAsegurado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                             </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="col-md-2" id="divConsultarOtros">  
                                              <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                                                   <ContentTemplate>
                                                        <asp:Button ID="boton3" CssClass="btn btn-primary DigitarbtnBuscar" runat="server" OnClick="ConsultarTerceroCertificadoOtroAsegurado" OnClientClick="localStorage.setItem('accIndex', 3);"  Text="BUSCAR" ValidationGroup="grpValidacionOtroAsegurado" />
                                                  </ContentTemplate>
                                              </asp:UpdatePanel>
                                            </div>
                                             <div class="col-md-1" id="divInsertarOtros">  
                                                <!-- Small modal -->
                                                <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Button2" runat="server" Text="INSERTAR" class="btn btn-danger DigitarbtnRegistrar" data-toggle="modal" data-target=".bs-example-modal-sm" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                                                  <div class="modal-dialog modal-sm">
                                                    <div class="modal-content" id="modalContentTerceroOtros">
                                                     <center><h4>Registrar Otros Asegurados</h4></center>
                                                    <hr />
                                                    <div class="row">
                                                                <div class="col-md-12" id="divRegistrarOtro">
                                                                    <fieldset>
                                                                            <div class="row">
                                                                              <asp:UpdatePanel ID="UpdatePanel69" runat="server">
                                                                                  <ContentTemplate>
                                                                                       <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Nombres *</label>
                                                                                                    <asp:TextBox runat="server" ID="txtNombreOtros" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtNombreOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombreOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                                                                             </div>
                                                                                        </div>
                                                                                      </ContentTemplate>
                                                                                 </asp:UpdatePanel>
                                                                                <asp:UpdatePanel ID="UpdatePanel70" runat="server">
                                                                                    <ContentTemplate>
                                                                                         <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Apellidos *</label>
                                                                                                    <asp:TextBox runat="server" ID="txtApellidoOtros" CssClass="form-control"  ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtApellidoOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtApellidoOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Fecha Nacimiento *</label>
                                                                                                 <asp:TextBox runat="server" type="date" ID="txtNacimientoOtros" CssClass="form-control" placeholder="DD/MM/AAAA" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtFechaNacimientoOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNacimientoOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                             </div>
                                                                             <asp:UpdatePanel ID="UpdatePanel72" runat="server">
                                                                                 <ContentTemplate>
                                                                                    <div class="row">
                                                                                         <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Edad *</label>
                                                                                                    <asp:TextBox enabled="false" runat="server" ID="txtEdadOtros" CssClass="form-control" ></asp:TextBox>
                                                                                             </div>
                                                                                        </div>
                                                                                       <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Tipo Documento *</label>
                                                                                                   <div class="form-group"> 
                                                                                                       <asp:DropDownList CssClass="form-control" ID="ddlTipoDocumentoOtros" runat="server" >
                                                                                                       </asp:DropDownList>     
                                                                                                       <asp:RequiredFieldValidator ID="reqddlTipoDocumentoOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlTipoDocumentoOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                                                         
                                                                                                   </div>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Numero Identificación *</label>
                                                                                                    <asp:TextBox  type="number" runat="server" ID="txtIdentificacionOtros" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqIdentificacionOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtIdentificacionOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                                                                             </div>
                                                                                        </div>
                                                                                    </div>
                                                                                 </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <asp:UpdatePanel ID="UpdatePanel73" runat="server">
                                                                                 <ContentTemplate>
                                                                                    <div class="row">
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Departamento *</label>
                                                                                                    <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" ID="ddlDepartamentoOtros" runat="server" OnSelectedIndexChanged="ddlDepartamentoOtros_SelectedIndexChanged" OnClientClick="localStorage.setItem('accIndex', 3);" >
                                                                                                            </asp:DropDownList>
                                                                                                            <asp:RequiredFieldValidator ID="reqddlDepartamentoOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlDepartamentoOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                         <div class="form-group">
                                                                                              <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                         <label for="exampleInputEmail1">Ciudad *</label>
                                                                                                         <asp:DropDownList CssClass="form-control" ID="ddlCiudadOtros" runat="server" >
                                                                                                          </asp:DropDownList>
                                                                                                          <asp:RequiredFieldValidator ID="reqddlCiudadOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlCiudadOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                      </ContentTemplate>
                                                                                               </asp:UpdatePanel>
                                                                                             </div>
                                                                                          </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Correo Electronico</label>
                                                                                                    <asp:TextBox type="email"  runat="server" ID="txtCorreoOtros" CssClass="form-control"></asp:TextBox>
                                                                                             </div>
                                                                                        </div>
                                                                                      </div>
                                                                                    </ContentTemplate>
                                                                              </asp:UpdatePanel>
                                                                             <asp:UpdatePanel ID="UpdatePanel74" runat="server">
                                                                                <ContentTemplate>
                                                                                      <div class="row">
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Celular *</label>
                                                                                                    <asp:TextBox type="number"  runat="server" ID="txtCelularOtros"  CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtCelularOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtCelularOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Telefono 1 *</label>
                                                                                                   <asp:TextBox type="number"  runat="server" ID="txtTelefono1Otros" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtTelefono1Otros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono1Otros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                          <div class="col-md-4">
                                                                                             <div class="form-group">
                                                                                                    <label for="exampleInputEmail1">Telefono 2 *</label>
                                                                                                    <asp:TextBox type="number" runat="server" ID="txtTelefono2Otros" CssClass="form-control" ></asp:TextBox>
                                                                                                 <asp:RequiredFieldValidator ID="reqtxtTelefono2Otros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtTelefono2Otros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                             </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                             <asp:UpdatePanel ID="UpdatePanel75" runat="server">
                                                                                <ContentTemplate>
                                                                                     <div class="row">
                                                                                            <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                        <label for="exampleInputEmail1">Direccion *</label>
                                                                                                        <asp:TextBox runat="server" ID="txtDireccionOtros" CssClass="form-control" ></asp:TextBox>
                                                                                                     <asp:RequiredFieldValidator ID="reqtxtDireccionOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDireccionOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                 </div>
                                                                                            </div>
                                                                                         <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                        <label for="exampleInputEmail1">Sexo *</label>
                                                                                                        <div class="form-group"> 
                                                                                                            <asp:DropDownList CssClass="form-control" ID="ddlGeneroTerceroOtros" runat="server" >
                                                                                                               <asp:ListItem>Seleccione el genero</asp:ListItem>
                                                                                                               <asp:ListItem>MASCULINO</asp:ListItem>
                                                                                                               <asp:ListItem>FEMENINO</asp:ListItem>
                                                                                                           </asp:DropDownList>               
                                                                                                            <asp:RequiredFieldValidator ID="reqddlGeneroTerceroOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlGeneroTerceroOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                        
                                                                                                        </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                            <div class="col-md-4">
                                                                                                 <div class="form-group">
                                                                                                       <div class="form-group">
                                                                                                        <label for="exampleInputEmail1">Estado civil *</label>
                                                                                                            <div class="form-group"> 
                                                                                                                <asp:DropDownList CssClass="form-control" ID="ddlEstadoCivilOtros" runat="server" >
                                                                                                               </asp:DropDownList>
                                                                                                                <asp:RequiredFieldValidator ID="reqddlEstadoCivilOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlEstadoCivilOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                                             </div>
                                                                                                         </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                         </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                              <asp:UpdatePanel ID="UpdatePanel76" runat="server">
                                                                                   <ContentTemplate>
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                 <div class="form-group">
                                                                                                        <label for="exampleInputEmail1">Ocupacion *</label>
                                                                                                        <div class="form-group">  
                                                                                                             <asp:DropDownList CssClass="form-control" ID="ddlOcupacionOtros" runat="server" >
                                                                                                             </asp:DropDownList> 
                                                                                                            <asp:RequiredFieldValidator ID="reqddlOcupacionOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlOcupacionOtros"  ValidationGroup="grpValidacionOtros" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                                                                                        </div>
                                                                                                 </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                 <div class="form-group">
                                                                                                        <label for="exampleInputEmail1">Empresa o plantel *</label>
                                                                                                        <asp:TextBox runat="server" Enabled="false" ID="TextBox18" CssClass="form-control"></asp:TextBox>
                                                                                                 </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        <hr />
                                                                    </fieldset>
                                                                    <br />
                                                                    <asp:UpdatePanel ID="UpdatePanel77" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-md-5"></div>
                                                                                    <div class="col-md-2">
                                                                                          <asp:Button ID="Button5" cssClass="btn btn-primary" runat="server" Text="REGISTRAR" OnClick="botonRegistrarTerceroOtros_Click" ValidationGroup="grpValidacionOtros"  />
                                                                                    </div>
                                                                                   <div class="col-md-3"></div>            
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
                                    <div class="col-md-4"></div>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                      <ContentTemplate>
                                        <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <asp:Label ID="lblCedulaOtro" runat="server" Text="Cedula"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtCedulaOtro" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <asp:Label ID="lblNombreOtro" runat="server" Text="Nombre"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtNombreOtro" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <asp:Label ID="lblApellidoOtro" runat="server" Text="Apellidos"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtApellidoOtro" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                       <asp:Label ID="lblEdad" runat="server" Text="Edad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtEdadOtro" CssClass="form-control" placeholder="Ingresar Edad" ></asp:TextBox>
                                                     </div>
                                                </div>
                                            </div>
                                          </ContentTemplate>
                                    </asp:UpdatePanel>
                                   <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                        <ContentTemplate>
                                             <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecla Nacimiento"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                            <asp:TextBox runat="server" Type="date" ID="txtFechaNacimiento" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                       <asp:Label ID="lblparentesco" runat="server" Text="Parentesco"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                            <asp:DropDownList ID="ddlParentesoOtro" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="consultarPlaPorParentesco" OnClientClick="localStorage.setItem('accIndex', 3);" runat="server">
                                                            </asp:DropDownList>         
                                                         <asp:RequiredFieldValidator ID="reqddlParentesco" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlParentesoOtro"  ValidationGroup="grpValidacionOtroAseguradoBusqueda" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                         
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblPlanOtros" runat="server" Text="Plan"  Font-Bold="true"  CssClass="labels"></asp:Label>
                                                                <asp:DropDownList ID="ddlPlanOtros" CssClass="ddl"  runat="server">
                                                                </asp:DropDownList>
                                                                 <asp:RequiredFieldValidator ID="reqddlPlanOtros" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPlanOtros"  ValidationGroup="grpValidacionOtroAseguradoBusqueda" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblPrimaOtros" runat="server" Text="Prima" Font-Bold="true"  CssClass="labels" ></asp:Label>
                                                        <asp:TextBox ID="txtPrimaOtros" Visible="true" cssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                      <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">     
                                                <center>   
                                                      <asp:Button ID="btnAdicionarOtrosAsegurados" CssClass="btn btn-primary" runat="server" Text="ADICIONAR" OnClick="btnAdicionarOtrosAsegurados_Click" OnClientClick="localStorage.setItem('accIndex', 3);"  ValidationGroup="grpValidacionOtroAseguradoBusqueda"></asp:Button>  
                                                      <asp:Button ID="btnConsultarPlanOtrosAsegurados" runat="server" OnClick="ConsultarAmparosPlanOtros" Text="CONSULTAR" OnClientClick="localStorage.setItem('accIndex', 3);"  cssclass="btn btn-primary" />                                                      
                                                </center>                                                                             
                                            </div>
                                       </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-2"></div>
                                               <div class="col-md-9">
                                                  <asp:GridView ID="grvAmparoOtro" Visible="true" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                
                                                   </asp:GridView>
                                                   <asp:Button ID="Button3" Visible="false" runat="server" OnClick="ConsultarAmparosPlanOtros" Text="Button" />
                                                   <asp:GridView ID="grvOtrosAsegurados" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDeleting="grvOtrosAsegurados_RowDeleting">
                                                       <Columns>
                                                           <asp:CommandField ShowDeleteButton="True" />
                                                       </Columns>
                                                   </asp:GridView>
                                               </div>
                                            <div class="col-md-1"></div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </fieldset>
                                     <br />
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:ImageButton ID="btnAtrasOtroAsegurado"  CssClass="btn btn-default btnAtrasSiguiente" OnClick="btnAtrasOtroAsegurado_Click" OnClientClick="localStorage.setItem('accIndex', 2); $('#tabs').tabs({ active: 2 });" runat="server" ImageUrl="~/Imagenes/Atras.png" />
                                        </div>
                                         <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-8">
                                                      <center>
                                                    <asp:Button ID="btnValidarOtroAsegurado" CssClass="btn btn-primary" runat="server"  OnClientClick="localStorage.setItem('accIndex', 3);" Text="VALIDAR" OnClick="btnValidarOtroAsegurado_Click"></asp:Button>
                                                </center>
                                                </div>
                                            </ContentTemplate>
                                         </asp:UpdatePanel>
                                        <div class="col-md-2">
                                        </div>
                                   </div>
                                 </div>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-6">
                                                  <div class="form-group">
                                                     <asp:Label ID="lblPrima" runat="server" Text="Prima" Font-Bold="true"  CssClass="labels"></asp:Label>
                                                      <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                                                          <ContentTemplate>
                                                              <asp:TextBox runat="server" ID="txtPrima" CssClass="form-control" placeholder="" ></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                 </div>
                                            </div>
                                            <div class="col-md-3"></div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                 <div class="row">
                                             <div class="col-md-12">
                                                <center>
                                                     <div class="row">
                                                        <div class="col-md-4"></div>
                                                        <div class="col-md-3">
                                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnCertificadoModal" cssClass="btn btn-primary" runat="server" data-toggle="modal" data-target="#myModal" Text="GUARDAR DATOS DEL CERTIFICADO"></asp:Button>
                                                                    </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                                        <div class="modal-dialog">
                                                                            <div class="modal-content" id="contenedor">
                                                                               <div class="modal-header">
                                                                                      <center><h4>CONFIRMACIÓN</h4></center>                                         
                                                                                </div>
                                                                                <div class="modal-body">      
                                                                                      <center><h5>Desea guardar este certificado?</h5></center>                                                                                                                             
                                                                               </div>
                                                                                <div class="modal-footer">
                                                                                    <asp:UpdatePanel ID="UpdatePanel78" runat="server">
                                                                                         <ContentTemplate>
                                                                                            <asp:Button ID="btnCerrarmodal" CssClass="btn btn-danger" data-dismiss="modal" runat="server" Text="CERRAR" />  
                                                                                            <asp:Button ID="btnCertificado" cssClass="btn btn-primary" runat="server" Text="CONFIRMAR" ValidationGroup="grpValidacionCertificado"  OnClick="bntGuardarCertificado_Click" ></asp:Button>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </div>                    
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                
                                                        </div>
                                                        <div class="col-md-5"></div>
                                                </div>  
                                                </center>
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
        <script type="text/javascript">
            $(document).ready(function () {


                selectedItem = localStorage.getItem("accIndex");


                if (!selectedItem) {
                    $('#tabs').tabs({ selected: 1 });
                } else {
                    $('#tabs').tabs({ active: selectedItem });
                }

                validarTabs();

                /*var tabs = $("#tabs").tabs({
                    activate: function (event, ui) {
                        localStorage.setItem("accIndex", $(this).tabs("option", "active"))
                    },
                    active: parseInt(localStorage.getItem("accIndex"))
                    
                });*/
                //localStorage.removeItem("accIndex");
                //$("#tabs").tabs({ disabled: [1, 2, 3, 4] });
            });

            function getIndex() {
                return $("ul li.ui-state-active").index();
            }

            function validarTabs() {
                if (getIndex() == 0) {
                    $('#tabs').tabs({ disabled: [1, 2, 3] });
                    $('#tabs').tabs({ enabled: [0] });
                    //document.getElementById('<%= btnLimpiar.ClientID%>').click();

                }
                if (getIndex() == 1) {
                    $('#tabs').tabs({ disabled: [0, 2, 3] });
                    $('#tabs').tabs({ enabled: [1] });
                    //document.getElementById('<%= btnLimpiar.ClientID%>').click();
                }
                if (getIndex() == 2) {
                    $('#tabs').tabs({ disabled: [0, 1, 3] });
                    $('#tabs').tabs({ enabled: [2] });
                }
                if (getIndex() == 3) {
                    $('#tabs').tabs({ disabled: [0, 1, 2] });
                    $('#tabs').tabs({ enabled: [3] });
                }
            }
    </script>

</asp:Content>

