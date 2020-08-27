<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetallePagaduria.aspx.cs" Inherits="Presentacion_DetallePagaduria" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Detalle Pagaduria </title>
    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        var host = window.location.host;
        var protocol = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";
        //Center greybox window
        function OpenCenterWindow() {
            var caption = "Adjuntar Archivo Soporte Pagaduria";
            var url = protocol + "//" + host + "/Presentacion4/AdjuntarArchivosSoportePagaduria.aspx";
            //alert(url);
            return GB_showCenter(caption, url, 350, 550)
        }
        //Center grybox window with callback on close
        function OpenCenterWindowCallBack() {
            var caption = "Adjuntar Archivo Soporte Pagaduria";
            var url = protocol + "//" + host + "/Presentacion4/AdjuntarArchivosSoportePagaduria.aspx";
            return GB_showCenter(caption, url, 350, 550, callback_fn)
        }
        //Callback function
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/DetallePagaduria.aspx#archSopPag";
        }
        //Full screen greybox popup window
        function OpenFullScreenWindow() {
            var caption = "Adjuntar Archivo Soporte Pagaduria";
            var url = protocol + "//" + host + "/Presentacion4/AdjuntarArchivosSoportePagaduria.aspx";
            return GB_showFullScreen(caption, url, callback_fn)
        }
        //Greybox Image popup window
        function OpenImage(url) {
            var caption = "Adjuntar Archivo";
            return GB_showImage(caption, url, callback_fn)
        }
        //Greybox Image gallery popup window
        function OpenImageSet() {
            var image_set = [{ 'caption': 'Flower', 'url': '../Images/Chrysanthemum.jpg' },
                            { 'caption': 'Desert', 'url': '../Images/Desert.jpg' },
                            { 'caption': 'Tulip', 'url': '../Images/Tulips.jpg' }];
            return GB_showImageSet(image_set, 1);
        }
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">     
    <asp:ScriptManager runat="server"></asp:ScriptManager>   
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="detalle_pagaduria" />
            </div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Detalle pagadurias
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info pull-right" 
                        CausesValidation="false" formnovalidate="form1" OnClick="LinkButton2_Click"
                        Text="Volver a Pagadurias">
                        <%--<span class="glyphicon glyphicon-hand-left"></span>--%>
                        <strong> Pagadurias </strong>
                    </asp:LinkButton>
                </h2>
                <div class="title-divider"></div>
                <div class="alert alert-info" role="alert">
                    <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label>
                </div>
            </div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Registro Pagaduría</a></li>
                    <li><a data-toggle="tab" href="#tab-2">Localidades Por Pagaduría</a></li>
                    <li><a data-toggle="tab" href="#tab-3">Archivos Soporte Pagaduría</a></li>
                    <li><a data-toggle="tab" href="#tab-4">Convenios</a></li>
                    <li><a data-toggle="tab" href="#tab-5">Configuración Archivo Novedades</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade">
                        <asp:Panel ID="pnlFormPag" runat="server" Width="100%" >  
                            <h3 class="impre">Registro Pagaduría</h3>
                            <div class="title-divider impre"></div>
                            <div class="alert alert-warning">
                                <strong>Al momento de Diligenciar el Formulario debe tener en cuenta lo siguiente: </strong>                                     
                                <ul>
                                    <li>   Los campos marcados con <span style="color:red"> * </span> son de obligatorio diligenciamiento  </li>
                                    <li>   Ingrese numeros de telefono en formato númerico, sin caracteres alfábeticos. </li>                                          
                                </ul>
                            </div>
                        </asp:Panel>
                        <asp:Label ID="lblMsj" runat="server" > </asp:Label>
                        <div class="row" id="encPagador"  >        
                            <div class="col-md-12">
                                <h4> Pagaduria </h4>
                                <div class="title-divider impre"></div>
                            </div>
                        </div>
                        <div class="row" id="Pagador"  >
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label30" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="Label31" runat="server"> Estado </asp:Label>
                                    
                                <asp:DropDownList CssClass="form-control " ID="ddlEstadoPagaduria" runat="server">                                        
                                    <asp:ListItem Text="Activo" Value="1" > </asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="0" > </asp:ListItem>
                                </asp:DropDownList>
                            </div>  
                            <div class="col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label1" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblDepartamento" runat="server" > Departamento</asp:Label>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" 
                                        ErrorMessage=" [ Seleccione ]" ForeColor="Red"
                                        ControlToValidate="ddlDepartamento" 
                                        EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" 
                                        ValidationGroup="addForm"
                                        ClientValidationFunction="ValidarListaSeleccion">
                                </asp:CustomValidator>
                                <asp:DropDownList ID="ddlDepartamento" runat="server"  
                                    CssClass="form-control " placesholder="" AutoPostBack="true" 
                                    OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 form-group">
                                    <asp:Label Font-Bold="true" ID="Label2" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" ID="labCiudad" runat="server" > Ciudad </asp:Label>
                                    <asp:DropDownList CssClass="form-control " ID="ddlCiudad" runat="server">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                            ErrorMessage=" [ Seleccione ]" ForeColor="Red"
                                            ControlToValidate="ddlCiudad" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" 
                                            ValidationGroup="addForm"
                                            ClientValidationFunction="ValidarListaSeleccion">
                                    </asp:CustomValidator>  
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label3" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" ID="labActivEcon" runat="server" > Actividad Económica </asp:Label>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" 
                                        ErrorMessage=" [ Seleccione ]" ForeColor="Red"
                                        ControlToValidate="ddlActivEcon" 
                                        EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" 
                                        ValidationGroup="addForm"
                                        ClientValidationFunction="ValidarListaSeleccion">
                                </asp:CustomValidator>
                                <asp:DropDownList CssClass="form-control " ID="ddlActivEcon" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label4" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="lab" runat="server"> Identificación </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                    ControlToValidate="txtIdentificacion" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>         
                                        
                                <asp:TextBox type="text" runat="server" id="txtIdentificacion" cssClass="form-control " placeholder="Identificador Pagaduría "
                                            required="required" MaxLength="30" ></asp:TextBox>

                            </div>
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label5" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="labNombre" runat="server"> Nombre </asp:Label>

                                <asp:RequiredFieldValidator ID="rfvNombrePagaduria" runat="server" 
                                    ControlToValidate="txtNombrePagaduria" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>  

                                <asp:TextBox type="text" runat="server" id="txtNombrePagaduria" cssClass="form-control " placeholder="Razón Social o Nombre Pagador" 
                                    required="required" MaxLength="200" ></asp:TextBox>
                            </div>
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label6" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="labDireccion" runat="server"> Dirección </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtDireccion" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Static" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>  
                                        
                                <asp:TextBox type="text" runat="server" id="txtDireccion" cssClass="form-control " placeholder="Dirección Pagador"
                                    required="required" MaxLength="200" ></asp:TextBox>

                            </div>
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label7" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="lblTelefono" runat="server"> Telefono </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtTelefono" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>      
                                        
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage=" [ Dato No Valido ]" 
                                        ControlToValidate="txtTelefono" ForeColor="Red" 
                                        EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" 
                                        ValidationGroup="addForm"
                                        ClientValidationFunction="ValidarTelefono">
                                    </asp:CustomValidator>  

                                <asp:TextBox runat="server" id="txtTelefono" cssClass="form-control " 
                                    placeholder="Telefono Pagador" onKeyPress="return esInteger(event)"
                                    required="required" MaxLength="10"  >
                                </asp:TextBox>

                            </div>

                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label11" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="lblVisacion" runat="server"> Visación </asp:Label>
                                    
                                <asp:DropDownList CssClass="form-control " ID="ddlVisacion" runat="server">                                        
                                    <asp:ListItem Text="Si" Value="1" > </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" > </asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class=" col-md-3 form-group">                                        
                                <asp:Label cssClass="labels" Font-Bold="true" id="labNumEmp" runat="server"> Número Empleados </asp:Label>
                                        
                                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                    Type="Integer" MinimumValue="0" MaximumValue="999999"
                                    ControlToValidate="txtNumEmpl" ForeColor="Red" 
                                    ErrorMessage="[ Dato No Valido ]"
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" >
                                </asp:RangeValidator>
                                        

                                <asp:TextBox runat="server" id="txtNumEmpl" cssClass="form-control " 
                                    placeholder="Número Empleados"  onKeyPress="return esInteger(event); "
                                        TextMode="Number" MaxLength="5"
                                        step="1" min="1" max="50000"  >
                                </asp:TextBox>

                            </div>

                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label9" runat="server" ForeColor="Red" > * </asp:Label>
                                <asp:Label cssClass="labels" Font-Bold="true" id="labPorcPart" runat="server"> % Participación </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtPorcPart" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>    
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                    ControlToValidate="txtPorcPart" ForeColor="Red" 
                                    ErrorMessage="[ Dato No Valido ]"
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                    ValidationExpression="^100$|^\d{0,2}(\.\d{1,3})? *%?$" >
                                </asp:RegularExpressionValidator>
                                        
                                <asp:TextBox runat="server" id="txtPorcPart" cssClass="form-control " 
                                    placeholder="% Participación" TextMode="Number" 
                                    step="1" min="1" max="100"
                                        MaxLength="6" > </asp:TextBox>

                            </div>

                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label10" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="labTitFecEntregaNov" runat="server"> Entrega Novedades </asp:Label>
                                    
                                <asp:CustomValidator ID="CustomValidator3" runat="server" 
                                    ErrorMessage=" [ Seleccione ]" ForeColor="Red"
                                    ControlToValidate="ddlFecEntregaNov" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" 
                                    ValidationGroup="addForm"
                                    ClientValidationFunction="ValidarListaSeleccion">
                                </asp:CustomValidator>
                                <asp:DropDownList CssClass="form-control " ID="ddlFecEntregaNov" runat="server"></asp:DropDownList>

                            </div>

                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label17" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="Label12" runat="server"> Email Pagaduria  </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator> 
                                        
                                <asp:RegularExpressionValidator ID="REVtxtEmail" runat="server" 
                                            ForeColor="Red"
                                        ErrorMessage=" [ Dato No Valido ]" ControlToValidate="txtEmail" 
                                        ValidationExpression="\S+@\S+\.\S+" EnableClientScript="true" Display="Dynamic" 
                                        SetFocusOnError="true" ValidationGroup="addForm">
                                </asp:RegularExpressionValidator>        
                                        
                                <asp:TextBox runat="server" id="txtEmail" cssClass="form-control " 
                                        placeholder="Email en formato @abc.com" ValidationGroup="addForm" TextMode="Email"
                                        MaxLength="200"  ></asp:TextBox>
                            </div>                 

                            <div class=" col-md-3 form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" id="Label13" runat="server"> Pagina Web  </asp:Label>
                                <asp:TextBox type="" runat="server" id="txtWeb" cssClass="form-control " placeholder="Web Pagaduria"
                                    MaxLength="200" TextMode="Url" ></asp:TextBox>
                            </div>   

                            <!-- DATOS CONTACTO -->
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label18" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="labContacto" runat="server"> Contacto </asp:Label>       
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                    ControlToValidate="txtContacto" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>      
                                <asp:TextBox type="text" runat="server" id="txtContacto" cssClass="form-control " placeholder="Digite Nombre Completo"
                                        MaxLength="150" required="required" ></asp:TextBox>
                            </div>                 

                            <div class=" col-md-3 form-group">
                    
                                <asp:Label Font-Bold="true" ID="Label19" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="labEmailContacto" runat="server"> Email Contacto  </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtEmailContacto" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>   

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ErrorMessage=" [ Dato No Valido ] " ForeColor="Red" ControlToValidate="txtEmailContacto" 
                                        ValidationExpression="\S+@\S+\.\S+" EnableClientScript="true" Display="Dynamic" 
                                        SetFocusOnError="true" ValidationGroup="addForm">
                                </asp:RegularExpressionValidator>        
                                        
                                <asp:TextBox type="email" runat="server" id="txtEmailContacto" cssClass="form-control " 
                                        placeholder="Email en formato @abc.com " required="required"
                                        MaxLength="150" ></asp:TextBox>

                                        
                            </div>     
                            <div class=" col-md-3 form-group">
                                        
                                <asp:Label Font-Bold="true" ID="Label20" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="labTelContacto" runat="server"> Teléfono Contacto  </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" required="required"
                                    ControlToValidate="txtTelContacto" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>      
                                <asp:CustomValidator ID="CustomValidator7" runat="server" 
                                        ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" 
                                        ControlToValidate="txtTelContacto" 
                                        EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                        ClientValidationFunction="ValidarTelefono">
                                </asp:CustomValidator>  
                                <asp:TextBox runat="server" id="txtTelContacto" onKeyPress="return esInteger(event)" 
                                        cssClass="form-control " placeholder="Solo digite números"
                                        MaxLength="10" required="required" ></asp:TextBox>
                            </div>   
                            <div class=" col-md-3 form-group">
                                <asp:Label Font-Bold="true" ID="Label21" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                <asp:Label cssClass="labels" Font-Bold="true" id="labCelContacto" runat="server"> Celular Contacto  </asp:Label>
                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" required="required"
                                    ControlToValidate="txtCelContacto" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                    EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                </asp:RequiredFieldValidator>   
                                        
                                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" 
                                        ControlToValidate="txtCelContacto" 
                                        EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                        ClientValidationFunction="ValidarCelular">
                                    </asp:CustomValidator>  

                                <asp:TextBox runat="server" id="txtCelContacto" cssClass="form-control " placeholder="Solo digite números"
                                        onKeyPress="return esInteger(event)" MaxLength="15"
                                        required="required" ></asp:TextBox>
                            </div>                 

                            <div class=" col-md-3 form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" id="Label15" runat="server"> Cumpleaños Contacto  </asp:Label>
                                <asp:TextBox type="date" runat="server" id="txtFecCumpleContacto" cssClass="form-control " ></asp:TextBox>
                            </div>
                        </div>
                        <div class="title-divider impre"></div>
                        <div class="row" id="encResponsable" > 
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4> Responsable Pago </h4>
                                        <div class="title-divider impre"></div>
                                    </div>
                                    <div class=" col-md-6 form-group">
                                        <asp:Label Font-Bold="true" ID="Label22" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labNomRespPago" runat="server"> Nombre </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" required="required"
                                            ControlToValidate="txtNomRespPago" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>   
                                            
                                        <asp:TextBox type="text" runat="server" id="txtNomRespPago" cssClass="form-control " placeholder="Nombre Responsable Pago"
                                            MaxLength="150" required="required" ></asp:TextBox>
                                    </div>                 

                                    <div class=" col-md-6 form-group">
                                        <asp:Label Font-Bold="true" ID="Label23" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labEmailRespPago" runat="server"> Email </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" required="required"
                                            ControlToValidate="txtEmailRespPago" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>   
                                            
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" ControlToValidate="txtEmailRespPago" 
                                            ValidationExpression="\S+@\S+\.\S+" EnableClientScript="true" Display="Dynamic" 
                                            SetFocusOnError="true" ValidationGroup="addForm">
                                        </asp:RegularExpressionValidator>


                                        <asp:TextBox type="email" runat="server" id="txtEmailRespPago" cssClass="form-control " 
                                            placeholder="Email Responsable Pago"
                                            MaxLength="150" required="required" ></asp:TextBox>

                                    </div>                 

                                    <div class=" col-md-6 form-group">
                                        
                                        <asp:Label Font-Bold="true" ID="Label24" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labTelRespPago" runat="server"> Teléfono  </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" required="required"
                                            ControlToValidate="txtTelRespPago" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>   
                                        
                                        <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" 
                                            ControlToValidate="txtTelRespPago" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                            ClientValidationFunction="ValidarTelefono">
                                        </asp:CustomValidator>  
                                            
                                                
                                        <asp:TextBox runat="server" id="txtTelRespPago"  onKeyPress="return esInteger(event)"
                                            cssClass="form-control " placeholder="Telefono Responsable Pago"
                                                MaxLength="10" required="required" ></asp:TextBox>
                                    </div>                 

                                    <div class=" col-md-6 form-group">
                                        <asp:Label Font-Bold="true" ID="Label25" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labCelRespPago" runat="server"> Celular  </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" required="required"
                                            ControlToValidate="txtCelRespPago" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>   
                                            
                                        <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" 
                                            ControlToValidate="txtCelRespPago" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                            ClientValidationFunction="ValidarCelular">
                                        </asp:CustomValidator>  

                                        <asp:TextBox runat="server" id="txtCelRespPago" onKeyPress="return esInteger(event)"
                                            cssClass="form-control " placeholder="Celular Responsable Pago"
                                            required="required" MaxLength="15" ></asp:TextBox>
                                    </div>                 

                                    <div class=" col-md-6 form-group">
                                        <asp:Label cssClass="labels" Font-Bold="true" id="Label16" runat="server"> Fecha Cumpleaños  </asp:Label>
                                        <asp:TextBox type="date" runat="server" id="txtFecCumpleRespPago"
                                                cssClass="form-control " ></asp:TextBox>
                                    </div>
                                </div>
                            </div>    
                            <div class="col-md-6">  
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4> Responsable Legal </h4>
                                        <div class="title-divider impre"></div>
                                    </div>
                                    <div class=" col-md-6 form-group">
                                        <asp:Label Font-Bold="true" ID="Label26" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labNomRespLegal" runat="server"> Nombre </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" required="required"
                                            ControlToValidate="txtRespLegal" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  
                                            
                                        <asp:TextBox type="text" runat="server" id="txtRespLegal" cssClass="form-control " 
                                            placeholder="Nombre Responsable Legal"
                                            MaxLength="150" ></asp:TextBox>

                                    </div>   
                                    <div class=" col-md-6 form-group">
                                        <asp:Label Font-Bold="true" ID="Label27" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="labEmailRespLegal" runat="server"> Email   </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" required="required"
                                            ControlToValidate="txtEmailRespLegal" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>   

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" ControlToValidate="txtEmailRespLegal" 
                                            ValidationExpression="\S+@\S+\.\S+" EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm">
                                        </asp:RegularExpressionValidator>
                                            
                                        <asp:TextBox type="email" runat="server" id="txtEmailRespLegal" 
                                            cssClass="form-control " placeholder="Email Responsable Legal"
                                            MaxLength="150" ></asp:TextBox>
                                    </div>     
                                                   

                                    <div class=" col-md-6 form-group  ">
                                        <asp:Label Font-Bold="true" ID="Label28" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="lblTelRespLeg" runat="server"> Teléfono </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" required="required"
                                            ControlToValidate="txtTelRespLeg" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  
                                            
                                        <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" ControlToValidate="txtTelRespLeg" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                            ClientValidationFunction="ValidarTelefono">
                                        </asp:CustomValidator>  

                                        <asp:TextBox runat="server" id="txtTelRespLeg" onKeyPress="return esInteger(event)"
                                            cssClass="form-control " placeholder="Teléfono Responsable Legal" 
                                            MaxLength="10" ></asp:TextBox>       
                                    </div>   
                                    <div class=" col-md-6 form-group ">
                                            
                                        <asp:Label Font-Bold="true" ID="Label29" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                        <asp:Label cssClass="labels" Font-Bold="true" id="lblCelRespLegal" runat="server"> Celular </asp:Label>
                                            
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" required="required"
                                            ControlToValidate="txtCelRespLegal" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  
                                            
                                        <asp:CustomValidator ID="CustomValidator12" runat="server" ErrorMessage=" [ Dato No Valido ]" ForeColor="Red" 
                                            ControlToValidate="txtCelRespLegal" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"
                                            ClientValidationFunction="ValidarCelular">
                                        </asp:CustomValidator>  

                                        <asp:TextBox runat="server" id="txtCelRespLegal" onKeyPress="return esInteger(event)"
                                            cssClass="form-control " placeholder="Celular Responsable Legal"
                                            MaxLength="15" ></asp:TextBox>
                                    </div>  
                                    <div class=" col-md-6 form-group">
                                        <asp:Label cssClass="labels" Font-Bold="true" id="Label14" runat="server"> Fecha Cumpleaños  </asp:Label>
                                        <asp:TextBox type="date" runat="server" id="txtFecCumpleRespLegal" cssClass="form-control " ></asp:TextBox>
                                    </div> 
                                </div>       
                            </div>
                        </div>
                        <div class="row" id="filaBtnOpcionesPagaduria"  >
                            <div class="col-md-12 form-group text-left ">
                                <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info " 
                                    CausesValidation="false" formnovalidate="form1"
                                    Text="Volver a Pagadurias" OnClick="lnkBtnBuscar_Click">
                                    <span class="glyphicon glyphicon-hand-left "></span> Volver Pagadurias
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger  "
                                    CausesValidation="false" formnovalidate="form1"  
                                    OnClientClick="if (!confirm('Esta seguro de Eliminar la Pagaduria?')) return false;"                                   
                                    OnClick="btnEliminar_Click" >
                                    <span class="glyphicon glyphicon-floppy-remove"></span> Eliminar Pagaduria
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary "
                                        OnClick="btnGuardar_Click" text="Guardar"
                                        ValidationGroup="addForm" CausesValidation="true" >
                                    <span class="glyphicon glyphicon-floppy-save"></span> Guardar Pagaduria
                                </asp:LinkButton>
                            </div>
                        </div><!--row-->
                    </div><!--#tab-1-->
                    <div id="tab-2" class="tab-pane fade">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                                <!-- LOCALIDADES POR PAGADURIA  -->
                                <h3 class="impre">Localidades Por Pagaduría</h3>
                                <div class="title-divider impre"></div>
                                <div class="row">
                                    <asp:Panel ID="pnlLocalidadesPagaduria" runat="server" Width="100%" >
                                        <div id="verLocalidadesPorConvenio"   >        
                
                                            <!-- tabla para cosultar todas las pagadurias -->
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                                <asp:CheckBoxList ID="chkLocalidadesPagaduria" runat="server"
                                                        CellPadding="5" CellSpacing="5" Font-Size="0.9em" Width="100%" 
                                                    RepeatColumns="10" RepeatDirection="Vertical" TextAlign="Right" >
                                                </asp:CheckBoxList>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left form-group" >
                                                <asp:LinkButton ID="lnkGuardarLocalidadesPag" runat="server" 
                                                        CssClass="btn btn-primary "
                                                        OnClick="GuardarLocalidadesPagaduria_Click" text="Guardar Localidades" >
                                                        <span class="glyphicon glyphicon-floppy-save"></span> Guardar Localidades
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger controlid="lnkGuardarLocalidadesPag" eventname="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-2-->
                    <div id="tab-3" class="tab-pane fade">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <a name="archSopPag"></a>
                            <div id="filaArchivosSoportePagaduria">  
                                <asp:Panel ID="pnlArchivosSoportePagaduria" runat="server" Width="100%" > 
                                <!-- Archivos SOPORTE PAGADURIA -->
                                <h3 class="impre">Archivos Soporte Pagaduría
                                    <asp:LinkButton ID="botonAdicionar" runat="server" CssClass="btn btn-info btn-xs pull-right"                                     
                                            text="" OnClick="btnAddArchivos_Click"  >
                                        <span class="glyphicon glyphicon-paperclip"></span>
                                        <strong> Adjuntar Archivos Soporte </strong>
                                    </asp:LinkButton>
                                </h3>
                                <div class="title-divider impre"></div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="grvArchivosSoporte" runat="server" Font-Size="0.9em" 
                                            DataKeyNames="soppaga_Id"
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
                                                            title="Ver Archivo"
                                                            data-toggle="tooltip" 
                                                            CssClass="btn btn-success btn-xs" 
                                                            NavigateUrl='<%# Eval("soppaga_Url") %>'>                                                    
                                                            <span class="glyphicon glyphicon-file "> </span>                                                                                                                       
                                                            </asp:HyperLink>  
                                                        <asp:linkButton CommandName="Select"  
                                                            CssClass="btn btn-danger btn-xs"  
                                                            id="botonEliminar" runat="server" 
                                                            OnClientClick="if (!confirm('Esta seguro de Eliminar el Archivo Soporte ?')) return false;"                                                                                      
                                                            data-toggle="tooltip" 
                                                            title="Eliminar">
                                                                <span class="glyphicon glyphicon-trash "></span>
                                                        </asp:linkButton>  
                                                    </ItemTemplate>                                        
                                                </asp:TemplateField>
                                        
                                                <asp:BoundField DataField="soppaga_Nombre" HeaderText="Nombre Soporte" />
                                                <asp:BoundField DataField="soppaga_Url" HeaderText="Url Soporte" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                </asp:Panel>
                                </div>
                   	    </ContentTemplate>
                        </asp:UpdatePanel>
                    </div><!--#tab-3-->
                    <div id="tab-4" class="tab-pane fade">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <!-- CONVENIOS  -->
                            <h3 class="impre">Convenios
                                <asp:LinkButton ID="btnAddConvenios" runat="server" CssClass="btn btn-info btn-xs pull-right"                                     
                                        text="" OnClick="btnAddConvenios_Click"  >
                                    <span class="glyphicon glyphicon-plus"></span>
                                    <strong> Adicionar Convenios </strong>
                                </asp:LinkButton>
                            </h3>
                            <div class="title-divider impre"></div> 
                            <a name="irConvenios" ></a>
                            <div id="filaConvenios"> 
                                <asp:Panel ID="pnlConvenios" runat="server"> 
                                    <div class="row " id="titFilaConv"  >                          
                                        <div class=" col-xs-1 form-group">                    
                                            <asp:TextBox type="number" runat="server" id="txtFiltroIdConv" cssClass="form-control " 
                                                placeholder="Id" step="1" min="1" max="999999" ></asp:TextBox>
                                        </div>
                                        <div class="col-xs-3 form-group">                    
                                            <asp:TextBox type="" runat="server" id="txtFiltroCodConv" cssClass="form-control " 
                                                placeholder="Codigo Convenio" ></asp:TextBox>
                                        </div>
                                        <div class="col-xs-3 form-group">                    
                                            <asp:TextBox type="" runat="server" id="txtFiltroNombreConv" 
                                                cssClass="form-control " 
                                                placeholder="Nombre Convenio"  ></asp:TextBox>
                                        </div>
                                        <div class="col-xs-3 form-group">
                                            <div class="input-group">
                                                <asp:LinkButton ID="lnkBtnBuscarConv" runat="server" 
                                                    CssClass="btn btn-primary " 
                                                    Text="Buscar" OnClick="lnkBtnBuscarConv_Click">
                                                    <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="verConvenios"> 
                                        <!-- tabla para cosultar todas las pagadurias -->
                                        <div class="col-lg-12">
                                            
                                                <asp:GridView ID="grvConvenios" runat="server" Font-Size="0.9em" 
                                                DataKeyNames="con_Id"
                                                CssClass="table table-bordered table-hover table-striped" 
                                                AutoGenerateColumns="false" 
                                                AllowPaging="True" PageSize="5" 
                                                OnRowCommand="grvConvenios_RowCommand" 
                                                OnPageIndexChanging="grvConvenios_PageIndexChanging"
                                                OnSelectedIndexChanged="grvConvenios_SelectedIndexChanged" >
                    
                                                <EmptyDataTemplate>
                                                    <div class="alert alert-warning" role="alert">                                                                 
                                                        <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Convenios !!! 
                                                    </div>
                                                </EmptyDataTemplate>

                                                <Columns>   
                                                    <asp:TemplateField>                                            
                                                        <ItemTemplate>
                                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                                CssClass="btn btn-success glyphicon glyphicon glyphicon-search btn-xs" 
                                                                id="botonConsultar" runat="server" Visible="false"  
                                                                CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">

                                                            </asp:linkButton> 
                                                            <asp:linkButton CssClass="btn btn-success glyphicon glyphicon glyphicon-edit btn-xs" 
                                                                id="botonEditar" runat="server"  
                                                                CommandName="Select"  data-toggle="tooltip" title="Editar">

                                                            </asp:linkButton>  
                                                            <asp:linkButton id="botonEliminar" runat="server" 
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' 
                                                                    OnClientClick="if (!confirm('Esta seguro de Eliminar el Convenio ?')) return false;" 
                                                                    CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove btn-xs "  
                                                                    CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar">

                                                            </asp:linkButton>
                                                        </ItemTemplate>   
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="con_Id" HeaderText="Id" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="con_Codigo" HeaderText="Codigo Convenio"  />
                                                    <asp:BoundField DataField="con_Nombre" HeaderText="Nombre Convenio"  />
                                                    <asp:BoundField DataField="con_ResponsableAprobacion" HeaderText="Responsable Aprobación"  />
                                                    <asp:BoundField DataField="con_FechaAprobacion" HeaderText="Fecha Aprobación"  />
                                                    <asp:BoundField DataField="con_PeriodicidadPago" HeaderText="Periodicidad Pago"  />
                                                    <asp:BoundField DataField="Estado_Format" HeaderText="Periodicidad Pago"  />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                 </asp:Panel>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarConv" eventname="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-4-->
                    <div id="tab-5" class="tab-pane fade">
                        <!-- ARCHIVOS NOVEDADES -->
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <h3 class="impre">Convenios
                                <asp:LinkButton ID="btnAddConfigNov" runat="server" CssClass="btn btn-info btn-xs pull-right"                                     
                                        text="" OnClick="btnAddConfigNov_Click"  >
                                    <span class="glyphicon glyphicon-plus"></span>
                                    <strong> Configurar Novedades  </strong>
                                </asp:LinkButton>
                            </h3>
                            <div class="title-divider impre"></div> 
                                <div id="filaArchivosNovedades">  
                                    <a name="irConfigArchNov"></a>
                                    <asp:Panel ID="pnlArchivosNovedades" runat="server">   
                                        <div class="row" id="contFilaArchNov"  >  
                                            <div class="col-xs-1 form-group">                    
                                                <asp:TextBox type="number" runat="server" id="txtIdArchNov" CssClass="form-control "
                                                    placeholder="Id" step="1" min="1" max="999999" ></asp:TextBox>
                                            </div>
                                            <div class="col-xs-3 form-group">                    
                                                <asp:TextBox type="" runat="server" id="txtNomArchNov" CssClass="form-control "
                                                    placeholder="Nombre Archivo"  ></asp:TextBox>
                                            </div>
                                            <div class="col-xs-3 form-group">                    
                                                <asp:DropDownList CssClass="form-control " ID="ddlTipoArchivo" runat="server">
                                                    <asp:ListItem Text="Seleccione Tipo Archivo" Value="-1" > </asp:ListItem>
                                                    <asp:ListItem Text="Novedades" Value="0" > </asp:ListItem>
                                                    <asp:ListItem Text="Cuenta de Cobro" Value="1" > </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-xs-3 form-group">                    
                                                <asp:DropDownList CssClass="form-control " ID="ddlTipoReporte" runat="server">
                                                    <asp:ListItem Text="Seleccione Tipo Reporte" Value="-1" > </asp:ListItem>
                                                    <asp:ListItem Text="Ingreso, Retiro, Modificación" Value="0" > </asp:ListItem>
                                                    <asp:ListItem Text="Ingreso y retiro" Value="1" > </asp:ListItem>
                                                    <asp:ListItem Text="Solo Vigentes" Value="2" > </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-xs-2 form-group">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="lnkBtnBuscarArchNov" runat="server" 
                                                        CssClass="btn btn-primary " 
                                                        Text="Buscar" OnClick="lnkBtnBuscarArchNov_Click">
                                                        <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="verArchNov">
                                            <!-- tabla para cosultar todas las pagadurias -->
                                            <div class="col-lg-12   ">
                                            
                                                <asp:GridView ID="grvArchivosNovedades" runat="server" Font-Size="0.9em" 
                                                    DataKeyNames="arcpag_Id"
                                                    CssClass="table table-bordered table-hover table-striped" 
                                                    AutoGenerateColumns="false" 
                                                    AllowPaging="True" PageSize="5" 
                                                    OnRowCommand="grvArchivosNovedades_RowCommand" 
                                                    OnPageIndexChanging="grvArchivosNovedades_PageIndexChanging"
                                                    OnSelectedIndexChanged="grvArchivosNovedades_SelectedIndexChanged" >
                    
                                                    <EmptyDataTemplate>
                                                        <div class="alert alert-warning" role="alert">                                                                 
                                                            <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Archivos de Novedades !!! 
                                                        </div>
                                                    </EmptyDataTemplate>

                                                    <Columns>                                                

                                                        <asp:TemplateField>                                            
                                                            <ItemTemplate>   
                                                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  
                                                                    CssClass="btn btn-success glyphicon glyphicon glyphicon-search btn-xs" 
                                                                    id="botonConsultar" runat="server" Visible="false"  
                                                                    CommandName="Consultar_Click"  data-toggle="tooltip" title="Consultar">

                                                                </asp:linkButton>  
                                                                <asp:linkButton CssClass="btn btn-success glyphicon glyphicon glyphicon-edit btn-xs " 
                                                                        id="botonEditar" runat="server"  
                                                                        CommandName="Select"  data-toggle="tooltip" title="Editar"></asp:linkButton>                                                

                                                                <asp:linkButton id="botonEliminar" runat="server" 
                                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' 
                                                                        OnClientClick="if (!confirm('Esta seguro de Eliminar la configuración de Archivo de Novedades ?')) return false;" 
                                                                        CssClass="btn btn-danger glyphicon glyphicon glyphicon-remove btn-xs "  
                                                                        CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar">

                                                                </asp:linkButton>  
                                                            </ItemTemplate>   
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="arcpag_Id" HeaderText="Id" Visible="true" ItemStyle-HorizontalAlign="Center" />                                                         
                                                            <asp:BoundField DataField="arcPag_Nombre" HeaderText="Nombre Archivo"  />
                                                            <asp:BoundField DataField="tipoArchivo_Format" HeaderText="Tipo Archivo"  />
                                                            <asp:BoundField DataField="tipoReporte_Format" HeaderText="Tipo Reporte"  />
                                                            <asp:BoundField DataField="valor_Format" HeaderText="Valor"  />
                                                            <asp:BoundField DataField="valor_Retiros" HeaderText="Retiros"  />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div> 
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarArchNov" eventname="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-5-->
                </div>
            </div>
        </div><!--row-->
    </div><!--container-form-->
</asp:Content>
