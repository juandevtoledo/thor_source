<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResumenCertificado.aspx.cs" Inherits="Presentacion_ResumenCertificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
<div class="container-form">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2>Resumen Certificado</h2>
            <div class="title-divider"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <input id="confirm_section" type="hidden" name="name" value="certificado" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <ul class="nav nav-tabs impre">
                <li><a data-toggle="tab" href="#tab-1">Certificado</a></li>
                <li><a data-toggle="tab" href="#tab-2">Principal</a></li>
                <li><a data-toggle="tab" href="#tab-3">Conyuge</a></li>
                <li><a data-toggle="tab" href="#tab-4">Otros Asegurados</a></li>
            </ul>
        </div>
        <div class="tab-content">        
            <div id="tab-1" class="tab-pane fade">
                <div class="col-md-12 btn-only">                        
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
                                    <asp:TextBox runat="server" Enabled="false" ID="txtProducto" CssClass="form-control"></asp:TextBox>
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
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblFechaDigitacion" runat="server" Font-Bold="true"  CssClass="labels" Text="Fecha Digitación"></asp:Label>
                                    <asp:TextBox  runat="server" Type="date" ID="txtFechaDigitacionCertificado" Enabled="true" CssClass="form-control" placeholder="DD/MM/AAAA" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFechaDigitacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaDigitacionCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>      
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblNumeroCertificado" runat="server" Font-Bold="true"  CssClass="labels" Text="Número Certificado"></asp:Label>
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
                                    <asp:DropDownList CssClass="form-control" ID="ddlperiodoPagoCertificado" Enabled="true" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqddlperiodoPagoCertificado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlperiodoPagoCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>                                  
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:DropDownList  CssClass="ddl" Enabled="true" ID="ddlLocalidadCertificado" AutoPostBack="true"  runat="server">                                             </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="reqddlLocalidadCertificado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlLocalidadCertificado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>    
                            <div class="col-md-3">
                                <asp:Label ID="lblPoliza" runat="server" Font-Bold="true"  CssClass="labels" Text="Póliza - GR"></asp:Label>
                                <asp:DropDownList ID="ddlPoliza" Enabled="true" CssClass="ddl" AutoPostBack="true"  runat="server">                                            </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="reqPoliza" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPoliza"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>   
                            <div class="col-md-3">
                                <asp:Label ID="lblAgencia" runat="server" Text="Agencia" Font-Bold="true"  CssClass="labels DigitarCertificadoAgencia"></asp:Label>
                                <asp:TextBox ID="txtAgencia"  CssClass="form-control DigitarCertificadoAgencia" runat="server"></asp:TextBox>                      
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblMesProduccion" runat="server" Text="Mes Producción" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:TextBox Enabled="false" ID="txtmesProduccion" CssClass="form-control" runat="server" placeholder="DD/MM/AAAA"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblEstadoNegocio" runat="server" Text="Estado Negocio" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:TextBox  ID="txtEstadoNegocio" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblDeclaracionAsegurabilidad" runat="server" Text="Declaración asegurabilidad" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:TextBox type="number" ID="txtDeclaracionAsegurado" Enabled="true" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqtxtDeclaracionAsegurado" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDeclaracionAsegurado"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblDeclaracionEG" runat="server" Text="Declaración Eg" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:TextBox type="number" ID="txtDeclaracionEG" Enabled="true" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqDeclaracionEG" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtDeclaracionEG"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblPrima" runat="server" Text="Prima" Font-Bold="true"  CssClass="labels"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtPrima" CssClass="form-control" Enabled="true"  placeholder="" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblHServicio1" runat="server" Text="Hoja Servicio 1" Font-Bold="true"  CssClass="labels"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtHServicio1" CssClass="form-control" placeholder=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtHServicio1" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHServicio1"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblHServicio2" runat="server" Text="Hoja Servicio 2" Font-Bold="true"  CssClass="labels"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtHServicio2" CssClass="form-control" placeholder=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqtxtHServicio2" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtHServicio2"  ValidationGroup="grpValidacionCertificadoPreCargado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblHServicio3" runat="server" Text="Hoja Servicio 3" Font-Bold="true"  CssClass="labels"></asp:Label>
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
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblTipoMovimiento" runat="server" Text="Tipo Movimiento" Font-Bold="true"  CssClass="labels"></asp:Label>
                                <asp:TextBox  Enabled="false" ID="txtTipoMovimiento" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            <div id="tab-2" class="tab-pane fade">
            <div class="col-md-12 btn-only">    
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Cédula" ID="labCedula" Font-Bold="true"  CssClass="labels"></asp:Label>
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
                </div>
                <div class="row">                                   
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label ID="lblPrimaPrincipal" runat="server" Text="Prima principal" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPrimaPrincipal" CssClass="form-control" runat="server"></asp:TextBox>   
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Pagaduría" ID="labPagaduria" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:TextBox ID="txtPagaduriaPrincipal" CssClass="form-control" runat="server"></asp:TextBox>                                  
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Convenio" ID="labConvenio" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:DropDownList ID="ddlConvenioPrincipal" runat="server" CssClass="form-control" Enabled="true"></asp:DropDownList>       
                            <asp:RequiredFieldValidator ID="reqddlConvenioPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlConvenioPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>               
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Plan" ID="labPlan1" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:DropDownList ID="ddlPlanPrincipal" AutoPostBack="true"  runat="server" Enabled="true" CssClass="form-control"></asp:DropDownList>         
                            <asp:RequiredFieldValidator ID="ReqddlPlanPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPlanPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                              
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label ID="lblExtraPrimaPrincipal" runat="server" Text="Extra Prima"  Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtExtraPrimaPrincipal" CssClass="form-control" runat="server"></asp:TextBox>   
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label ID="lblOcupacionPrincipal" runat="server" Text="Ocupación"  Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:DropDownList Enabled="false" ID="ddlOcupacionPrincipal" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label ID="labPeso" runat="server"  Text="Peso" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:TextBox type="number" runat="server" ID="txtpesoPrincipal" Enabled="true" CssClass="form-control" placeholder="Ingresar Peso" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtPesoPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtpesoPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">   
                        <div class="form-group">                                         
                            <asp:Label ID="labEstatura" runat="server" Text="Estatura" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:TextBox type="number"  runat="server" ID="txtestaturaPrincipal" Enabled="true" CssClass="form-control" placeholder="Ingresar Estatura" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtestaturaPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtestaturaPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Plantel" ID="lblPlantel" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:DropDownList  ID="ddlPlantel" runat="server" CssClass="ddl"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label  runat="server" Text="Plan" ID="labPlan" Font-Bold="true"  CssClass="labels"></asp:Label>
                            <asp:TextBox type="number" runat="server" ID="txtPlanPrincipal" Enabled="true" CssClass="form-control" AutoPostBack="true" value=""  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqtxtPlanPrincipal" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPlanPrincipal"  ValidationGroup="grpValidacionCertificado" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Extraprimado" ID="lblExtraprimado" Font-Bold="true" CssClass="labels"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkExtraprimadoPrincipal" CssClass="form-control" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <h4>Amparos Asegurado Principal</h4>                                            
                                <asp:GridView ID="grvAmparoPrincipal" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>                                                                                          
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <h4>Beneficiario Principal</h4>
                        <asp:GridView ID="grvBeneficiarioPrincipal" CssClass="table table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False"  ShowFooter="false" >
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
                                            <asp:ListItem>Padre</asp:ListItem>
                                            <asp:ListItem>Madre</asp:ListItem>
                                            <asp:ListItem>Hijo</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="addNew" ValidationGroup="grpValidacionBeneficiarioPrincipal">Agregar</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div> 
                </div>
                <div class="row btn-only">
                        <div class="col-md-12" id="divExtraPrima">
                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnExtraPrima" cssclass="btn btn-primary" data-toggle="modal" data-target="#miventana3" runat="server" Text="Extra Prima" />
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
                                                                <div class="col-md-10">
                                                                    <asp:GridView ID="GridView9" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <fieldset>
                                                                            <legend>Histórico de valores asegurados para las extra primas</legend>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>                                                
                                                                                    <asp:GridView ID="grvAmparoExtraPrima"    CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <br />                                                                                            
                                                                            <asp:GridView ID="GridView8" CssClass="table table-bordered table-hover table-striped" runat="server">
                                                                            </asp:GridView>
                                                                            <br />
                                                                            <asp:UpdatePanel ID="UpdatePanel53" runat="server">
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
                                            <asp:UpdatePanel ID="UpdatePanel54" runat="server">
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
            </div>
            <div id="tab-3" class="tab-pane fade">
                <div class="col-md-12">
                    <div class="row btn-only">                        
                        <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblCedulaConyuge" runat="server" Text="Cédula Cónyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox runat="server"  ID="txtCedulaConyuge" CssClass="form-control" placeholder="Ingresar Cedula" ></asp:TextBox>
                                </div>
                        </div>
                        <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblNombreConyuge" runat="server" Text="Nombre Cónyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox runat="server"  ID="txtNombreConyuge" CssClass="form-control" placeholder="Ingresar Nombres" ></asp:TextBox>
                                </div>
                        </div>
                        <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblApellidoConyuge" runat="server" Text="Apellido Cónyuge" Font-Bold="true" CssClass="labels"></asp:Label>
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
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="lblPrimaConyuge" runat="server" Text="Prima" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox ID="txtPrimaConyuge" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="lblPlan2" runat="server" Text="Plan" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:DropDownList  ID="ddlPlanConyuge"  CssClass="form-control"  AutoPostBack="true"  runat="server">                                                    
                                </asp:DropDownList> 
                                <asp:RequiredFieldValidator ID="reqddlPlanConyuge" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlPlanConyuge"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>                                     
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="lblPesoConyuge" runat="server" Text="Peso" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox type="number" runat="server"  ID="txtPeso" CssClass="form-control" placeholder="Ingresar Peso" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqtxtPeso" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtPeso"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="lblEstaturaConyuge" runat="server" Text="Estatura" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox type="number"  runat="server"  ID="txtEstatura" CssClass="form-control" placeholder="Ingresar Estatura" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqtxtEstatura" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtEstatura"  ValidationGroup="grpValidacionConyuge" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="lblPlan" runat="server" Text="Plan" Font-Bold="true" CssClass="labels"></asp:Label>
                                <asp:TextBox type="number" runat="server"  ID="txtPlanConyuge"   CssClass="form-control" AutoPostBack="true" placeholder="Ingresar Plan" ></asp:TextBox>
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
                        <div class="col-md-1">
                            <asp:Label runat="server" Text="Extraprimado" ID="lblExtraprimadoConyuge" Font-Bold="true" CssClass="labels"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkExtraprimadoConyuge" CssClass="form-control" AutoPostBack="true" />  
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 runat="server" id="amparosConyuge">Amparos Asegurado Cónyuge</h4>
                                <asp:GridView ID="grvAmparoConyuge" CssClass="table table-bordered table-hover table-striped" runat="server" ></asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 runat="server" id="beneficiariosConyuge">Beneficiarios Cónyuge</h4>
                                <asp:GridView Enabled="true" Visible="true" ID="grvBeneficiarioConyuge" CssClass="table table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False"  ShowFooter="false">
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
                                                    <asp:ListItem>nieto</asp:ListItem>
                                                    <asp:ListItem>padre</asp:ListItem>
                                                    <asp:ListItem>madre</asp:ListItem>
                                                    <asp:ListItem>hijo</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="addNew" ValidationGroup="grpValidacionbeneficiarioConyuge">Agregar</asp:LinkButton>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Parentesco") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnExtraPrima2"  cssclass="btn btn-primary" data-toggle="modal" data-target="#miventana2" runat="server" Text="Extra Prima" />
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
                                                <div class="col-md-10">
                                                    <div class="row">
                                                        <fieldset>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <fieldset>
                                                                            <legend>Historico de valores asegurados para las extra primas</legend>
                                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                <ContentTemplate>  
                                                                                    <asp:GridView ID="grvExtraPrimaConyuge"   CssClass="table table-bordered table-hover table-striped" runat="server">
                                                                                        <Columns>
                                                                                            <asp:CommandField EditText="Editar" ShowEditButton="true" />                                                                                                        
                                                                                        </Columns>
                                                                                        </asp:GridView> 
                                                                                    </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <br />
                                                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:GridView ID="grvHistorialExtraPrimaConyuge" CssClass="table table-bordered table-hover table-striped" runat="server">

                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <br />
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                <ContentTemplate> 
                                                                                    <div class="row">
                                                                                        <div class="col-md-3">
                                                                                            <asp:Label ID="lblPrimaPrincipalExtraprimaConyuge" runat="server" Font-Bold="true"  CssClass="labels" Text="Prima"></asp:Label>  
                                                                                            <asp:TextBox ID="txtPrimaPrincipalExtraprimaConyuge" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                        </div>
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
                                                                                <asp:GridView ID="grvConsultarHistirialPorcentajeExtraPrimadoConyuge" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div> 
                                            <br />                                                                    
                                        </div>
                                        <div class="modal-footer">
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
            </div>
            <div id="tab-4" class="tab-pane fade">
                <div class="col-md-12 btn-only">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="grvAmparoOtro" Visible="true" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                            <asp:Button ID="Button3" Visible="false" runat="server"  Text="Button" />
                            <asp:GridView ID="grvOtrosAsegurados" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                        </div>
                    </div> 
                </div>
            </div>    
        </div>  
   </div>  
<script src="../Scripts/jquery-1.11.2.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script> 
<script type="text/javascript">
    function clickOnce(btn, msg) {
        btn.value = msg;
        btn.disabled = true;
        return true;}
</script>
    <div class="row btn-only btn-only  text-center">
        <asp:Button OnClick="btnCorregir_Click" ID="btnCorregir" cssClass="btn btn-success" OnClientClick="localStorage.setItem('accIndex', 0);" runat="server" Text="CORREGIR" />
    </div>
</div>
</asp:Content>