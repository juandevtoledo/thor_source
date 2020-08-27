<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarPagaduria.aspx.cs" Inherits="Presentacion_ConsultarPagaduria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title> Consultar Pagaduria </title>    

    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
   
                
        <asp:ScriptManager runat="server"   > </asp:ScriptManager>    

        
            <div class="panel panel-default" style="font-size:0.9em">
            
            
                <div class="panel-heading panel-primary">

                    <div class="row container " id="tituloPagina"  >        


                            <div class="col-md-10">
                                <h3 class="panel-title"> <strong> DETALLE PAGADURIAS </strong> 
                                    <br />
                                    <small> <em>&nbsp;  <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label> </em> </small>  
                                </h3>                                    
                            </div>

                            <div class="col-md-2">

                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info" 
                                    CausesValidation="false" formnovalidate="form1"
                                    Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/Pagadurias.aspx" >
                                    <span class="glyphicon glyphicon-hand-left"></span>
                                    <strong> &nbsp;Volver Pagadurias </strong>
                                </asp:LinkButton>

                            </div>


                    </div>                    

                </div>
            
                
                <br />



                <div class="panel-body">
                    


                    <div class="row container " id="encFormPag"  >        
                    
                        <div class="col-md-12">
                    
                            <div class="row container " id="titFormPag"   >                                        
                               
                            <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                            
                                <asp:Panel ID="pnlFormPag" runat="server" Width="100%" >                    
                                
                                    <div class="row container text-center " id="titFormPag1"   >        
                                    <br>

                                    <div class="col-md-1   " >                                               
                                        </div>

                                        <div class="col-md-4 text-left  " >                                               
                                                                    
                                            <h2 class="panel-title"> 
                                                <strong> 
                                                                                                        
                                                        <a data-toggle="collapse" 
                                                            data-target="#colFormPag" >
                                                                         
                                                            <span class="glyphicon glyphicon-collapse-down "></span>
                                                            Formulario Registro Pagaduría

                                                        </a>
                                                    </strong> 
                                                </h2>
                                        
                                            <br>
                                        </div>

                                        <div class="col-md-7  " >                                              
                                        </div>

                                </div>

                                </asp:Panel>

                            </div>


                        </div>
                    

                        <br />
                    
                        <asp:Panel ID="pnlEncabezado" runat="server" Enabled="false" >

                                <div class="panel-collapse collapse in" id="colFormPag" >                                         
    
                                    <div class="panel-body">
                            
                                        <div id="seccionPagadurias">

                                            <div class="row container " id="filaMsj" >
                        
                                                <div class="col-md-12">
                        
                                                <small>
                                                    <b> Al momento de Diligenciar el Formulario debe tener en cuenta lo siguiente: </b>                                     
                                                    <ul>
                                                        <li>   Los campos marcados con <span style="color:red"> * </span> son de obligatorio diligenciamiento  </li>
                                                        <li>   Ingrese numeros de telefono en formato númerico, sin caracteres alfábeticos. </li>                                          
                                                    </ul>
                                                </small>

                                                <asp:Label ID="lblMsj" runat="server" > </asp:Label>

                                            </div>
                    
                                            </div>

                                            <br />
                
                                            <div class="row container " id="encPagador"  >        

                                                <div class="col-md-12">
                                                    <h4> Pagaduria </h4>
                                                        <hr />
                                                </div>

                                            </div>
                        
                                            <div class="row container " id="Pagador"  >   
                        
                                
                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label30" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label31" runat="server"> Estado </asp:Label>
                                    
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlEstadoPagaduria" runat="server">                                        
                                                                <asp:ListItem Text="Activo" Value="1" > </asp:ListItem>
                                                                <asp:ListItem Text="Inactivo" Value="0" > </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>   
                            
                                                    <div class="col-md-3 form-group">

                                                            <asp:Label Font-Bold="true" ID="Label1" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" ID="lblDepartamento" runat="server" > Departamento</asp:Label>
                                      
                                                            <asp:DropDownList ID="ddlDepartamento" runat="server"  
                                                                CssClass="form-control input-sm" placesholder="" AutoPostBack="true" 
                                                                OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" >
                                                            </asp:DropDownList>
   

                                                        </div>

                                                    <div class="col-md-3 form-group">

                                                            <asp:Label Font-Bold="true" ID="Label2" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" ID="labCiudad" runat="server" > Ciudad </asp:Label>
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlCiudad" runat="server">
                                                            </asp:DropDownList>


                                                        </div>

                                                    <div class="col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label3" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" ID="labActivEcon" runat="server" > Actividad Económica </asp:Label>
                                       
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlActivEcon" runat="server"></asp:DropDownList>

                                                        </div>

                                                    <div class="col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label4" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="lab" runat="server"> Identificación </asp:Label>
                                        
                                        
                                                            <asp:TextBox type="text" runat="server" id="txtIdentificacion" cssClass="form-control input-sm" placeholder="Identificador Pagaduría "
                                                                    required="required" MaxLength="30" ></asp:TextBox>

                                        

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label5" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labNombre" runat="server"> Nombre </asp:Label>
                                                                                           
                                                            <asp:TextBox type="text" runat="server" id="txtNombrePagaduria" cssClass="form-control input-sm" placeholder="Razón Social o Nombre Pagador" 
                                                                required="required" MaxLength="200" ></asp:TextBox>

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label6" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labDireccion" runat="server"> Dirección </asp:Label>
                                                                                    
                                                            <asp:TextBox type="text" runat="server" id="txtDireccion" cssClass="form-control input-sm" placeholder="Dirección Pagador"
                                                                required="required" MaxLength="200" ></asp:TextBox>
                                                                                      

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label7" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="lblTelefono" runat="server"> Telefono </asp:Label>
                                        
                                                
                                                            <asp:TextBox runat="server" id="txtTelefono" cssClass="form-control input-sm" 
                                                                placeholder="Telefono Pagador" onKeyPress="return esInteger(event)"
                                                                required="required" MaxLength="10"  >
                                                            </asp:TextBox>

                                        

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label11" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="lblVisacion" runat="server"> Visación </asp:Label>
                                    
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlVisacion" runat="server">                                        
                                                                <asp:ListItem Text="Si" Value="1" > </asp:ListItem>
                                                                <asp:ListItem Text="No" Value="0" > </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                    <div class=" col-md-3 form-group">                                        
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labNumEmp" runat="server"> Número Empleados </asp:Label>
                                        

                                                            <asp:TextBox runat="server" id="txtNumEmpl" cssClass="form-control input-sm" 
                                                                placeholder="Número Empleados"  onKeyPress="return esInteger(event); "
                                                                    TextMode="Number" MaxLength="5"
                                                                    step="1" min="1" max="50000"  >
                                                            </asp:TextBox>

                                        

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label9" runat="server" ForeColor="Red" > * </asp:Label>
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labPorcPart" runat="server"> % Participación </asp:Label>
                                        
                                        
                                                            <asp:TextBox runat="server" id="txtPorcPart" cssClass="form-control input-sm" 
                                                                placeholder="% Participación" TextMode="Number" 
                                                                step="1" min="1" max="100"
                                                                    MaxLength="6" > </asp:TextBox>

                                        

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                        
                                                            <asp:Label Font-Bold="true" ID="Label10" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labTitFecEntregaNov" runat="server"> Entrega Novedades </asp:Label>
                                    
                                        
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlFecEntregaNov" runat="server"></asp:DropDownList>

                                       

                                                        </div>

                                                    <div class=" col-md-3 form-group">
                                        
                                                            <asp:Label Font-Bold="true" ID="Label17" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label12" runat="server"> Email Pagaduria  </asp:Label>
                                        
                                                            <asp:TextBox runat="server" id="txtEmail" cssClass="form-control input-sm" 
                                                                placeholder="Email en formato @abc.com" ValidationGroup="addForm" TextMode="Email"
                                                                MaxLength="200"  ></asp:TextBox>

                                        

                                                        </div>                 

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label13" runat="server"> Pagina Web  </asp:Label>
                                                            <asp:TextBox type="" runat="server" id="txtWeb" cssClass="form-control input-sm" placeholder="Web Pagaduria"
                                                                MaxLength="200" TextMode="Url" ></asp:TextBox>
                                                        </div>                                


                                                        <!-- DATOS CONTACTO -->

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label18" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labContacto" runat="server"> Contacto </asp:Label>
                                                                                       
                                                            <asp:TextBox type="text" runat="server" id="txtContacto" cssClass="form-control input-sm" placeholder="Digite Nombre Completo"
                                                                MaxLength="150" required="required" ></asp:TextBox>


                                                        </div>                 

                                                    <div class=" col-md-3 form-group">
                                        
                                                            <asp:Label Font-Bold="true" ID="Label19" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labEmailContacto" runat="server"> Email Contacto  </asp:Label>
                                        
                                                            <asp:TextBox type="" runat="server" id="txtEmailContacto" cssClass="form-control input-sm" 
                                                                placeholder="Email en formato @abc.com " required="required"
                                                                MaxLength="150" ></asp:TextBox>

                                        
                                                        </div>                 

                                                    <div class=" col-md-3 form-group">
                                        
                                                            <asp:Label Font-Bold="true" ID="Label20" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labTelContacto" runat="server"> Teléfono Contacto  </asp:Label>
                                        
                                                
                                                            <asp:TextBox runat="server" id="txtTelContacto" onKeyPress="return esInteger(event)" 
                                                                cssClass="form-control input-sm" placeholder="Solo digite números"
                                                                MaxLength="10" required="required" ></asp:TextBox>
                                                                                 

                                                        </div>                 

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label Font-Bold="true" ID="Label21" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="labCelContacto" runat="server"> Celular Contacto  </asp:Label>
                                        
                                                
                                                            <asp:TextBox runat="server" id="txtCelContacto" cssClass="form-control input-sm" placeholder="Solo digite números"
                                                                onKeyPress="return esInteger(event)" MaxLength="15"
                                                                required="required" ></asp:TextBox>

                                        

                                                        </div>                 

                                                    <div class=" col-md-3 form-group">
                                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label15" runat="server"> Cumpleaños Contacto  </asp:Label>
                                                            <asp:TextBox type="date" runat="server" id="txtFecCumpleContacto" cssClass="form-control input-sm" ></asp:TextBox>
                                                        </div>

                            
                    
                                                </div>

                                                
                                            <br />

                                            <div class="row container "  id="secciónResponsables" >        

                                                <div class="col-md-12" >
                            
                                                    <div class="row container " id="encResponsable" >        
                                
                                                        <div class="col-md-6" >
                                        
                                                            <div class="col-md-12">
                                                                <h4> Responsable Pago </h4>
                                                                <hr />
                                                            </div>

                                    
                                                            <div class=" col-md-6 form-group">
                                                                <asp:Label Font-Bold="true" ID="Label22" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                <asp:Label cssClass="labels" Font-Bold="true" id="labNomRespPago" runat="server"> Nombre </asp:Label>
                                                                                                
                                                                <asp:TextBox type="text" runat="server" id="txtNomRespPago" cssClass="form-control input-sm" placeholder="Nombre Responsable Pago"
                                                                    MaxLength="150" required="required" ></asp:TextBox>

                                            
                                                            </div>                 

                                                            <div class=" col-md-6 form-group">
                                                                <asp:Label Font-Bold="true" ID="Label23" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                <asp:Label cssClass="labels" Font-Bold="true" id="labEmailRespPago" runat="server"> Email </asp:Label>
                                            
                                            
                                                                <asp:TextBox type="email" runat="server" id="txtEmailRespPago" cssClass="form-control input-sm" 
                                                                    placeholder="Email Responsable Pago"
                                                                    MaxLength="150" required="required" ></asp:TextBox>

                                                            </div>                 

                                                            <div class=" col-md-6 form-group">
                                            
                                                                <asp:Label Font-Bold="true" ID="Label24" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                <asp:Label cssClass="labels" Font-Bold="true" id="labTelRespPago" runat="server"> Teléfono  </asp:Label>
                                            
                                                
                                                                <asp:TextBox runat="server" id="txtTelRespPago"  onKeyPress="return esInteger(event)"
                                                                    cssClass="form-control input-sm" placeholder="Telefono Responsable Pago"
                                                                        MaxLength="10" required="required" ></asp:TextBox>

                                        
                                                            </div>                 

                                                            <div class=" col-md-6 form-group">
                                                                <asp:Label Font-Bold="true" ID="Label25" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                <asp:Label cssClass="labels" Font-Bold="true" id="labCelRespPago" runat="server"> Celular  </asp:Label>
                                            
                                                                <asp:TextBox runat="server" id="txtCelRespPago" onKeyPress="return esInteger(event)"
                                                                    cssClass="form-control input-sm" placeholder="Celular Responsable Pago"
                                                                    required="required" MaxLength="15" ></asp:TextBox>

                                            
                                                            </div>                 

                                                            <div class=" col-md-6 form-group">
                                                                <asp:Label cssClass="labels" Font-Bold="true" id="Label16" runat="server"> Fecha Cumpleaños  </asp:Label>
                                                                <asp:TextBox type="date" runat="server" id="txtFecCumpleRespPago"
                                                                        cssClass="form-control input-sm" ></asp:TextBox>
                                                            </div>
                                        
                                                            <div class=" col-md-6 form-group" > </div>

                                 
                                                        </div>                                    
                                    
                                                        <div class="col-md-6">                                        


                                                                <div class="col-md-12">
                                                                    <h4> Responsable Legal </h4>
                                                                        <hr />
                                                                </div>
                                              
                        
                                                                <div class=" col-md-6 form-group">
                                                                    <asp:Label Font-Bold="true" ID="Label26" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                    <asp:Label cssClass="labels" Font-Bold="true" id="labNomRespLegal" runat="server"> Nombre </asp:Label>
                                            
                                                                    <asp:TextBox type="text" runat="server" id="txtRespLegal" cssClass="form-control input-sm" 
                                                                        placeholder="Nombre Responsable Legal"
                                                                        MaxLength="150" ></asp:TextBox>

                                                                </div>                 


                                                                <div class=" col-md-6 form-group">
                                                                    <asp:Label Font-Bold="true" ID="Label27" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                    <asp:Label cssClass="labels" Font-Bold="true" id="labEmailRespLegal" runat="server"> Email   </asp:Label>
                                            
                                            
                                                                    <asp:TextBox type="" runat="server" id="txtEmailRespLegal" 
                                                                        cssClass="form-control input-sm" placeholder="Email Responsable Legal"
                                                                        MaxLength="150" ></asp:TextBox>
                                                                                        

                                                                </div>     
                                                   

                                                                <div class=" col-md-6 form-group  ">
                                                                    <asp:Label Font-Bold="true" ID="Label28" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblTelRespLeg" runat="server"> Teléfono </asp:Label>
                                            
                                                        
                                                                    <asp:TextBox runat="server" id="txtTelRespLeg" onKeyPress="return esInteger(event)"
                                                                        cssClass="form-control input-sm" placeholder="Teléfono Responsable Legal" 
                                                                        MaxLength="10" ></asp:TextBox>                                            

                                                                </div>                
                                

                                                                <div class=" col-md-6 form-group ">
                                            
                                                                    <asp:Label Font-Bold="true" ID="Label29" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblCelRespLegal" runat="server"> Celular </asp:Label>
                                                                                                    

                                                                    <asp:TextBox runat="server" id="txtCelRespLegal" onKeyPress="return esInteger(event)"
                                                                        cssClass="form-control input-sm" placeholder="Celular Responsable Legal"
                                                                        MaxLength="15" ></asp:TextBox>

                                            
                                                                </div>  
                                
                                        
                                                                <div class=" col-md-6 form-group">
                                                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label14" runat="server"> Fecha Cumpleaños  </asp:Label>
                                                                    <asp:TextBox type="date" runat="server" id="txtFecCumpleRespLegal" cssClass="form-control input-sm" ></asp:TextBox>
                                                                </div>                            
                                    
                                        
                                                                <div class=" col-md-6 form-group">                                            
                                                                </div>    

                                
                                                        </div>
                    
                                                    </div>

                                                </div>
                            
                                            </div>
                                
                                
                                            <br />
                          
                                        </div>
                    
                                    </div>
                       
                                </div>

                        </asp:Panel>

                        </div>
                     
                    </div>

                    
                    

                    <!-- LOCALIDADES POR PAGADURIA  -->


                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                    

                            <div class="row container " id="filaLocalidadesPorPagaduria"  >        
                    
                                <div class="col-md-12">

                                    <asp:Panel ID="pnlLocalidadesPagaduria" runat="server" Width="100%" >                    

                                        <div class="row container text-center " id="titLocPag"   >                                        
                               
                                           <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                            

                                               <div class="row container text-center " id="titLocPag1"   >        
                                                  <br>

                                                    <div class="col-md-1   " >                                               
                                                        </div>

                                                       <div class="col-md-3 text-left  " >                                               
                                                                    
                                                            <h2 class="panel-title"> 
                                                                <strong> 

                                                                     <a data-toggle="collapse" 
                                                                         data-target="#colLocalidades" >
                                                                         
                                                                         <span class="glyphicon glyphicon-collapse-down "></span>
                                                                         Localidades Por Pagaduría

                                                                     </a>
                                                                 </strong> 
                                                                </h2>
                                                        <br>
                                                        </div>

                                                        <div class="col-md-8  " >                                              
                                                        </div>

                                                </div>


                                           </div>


                                        </div>


                                        <div class="panel-collapse collapse in" id="colLocalidades" >                                         

                                            <div class="panel-body">

                                                <div class="row container " id="verLocalidadesPorConvenio"   >        
                
                                                    <!-- tabla para cosultar todas las pagadurias -->
                                        
                                                    <br />
                                                    <div class="col-xs-12">

                                                    <asp:CheckBoxList ID="chkLocalidadesPagaduria" runat="server"
                                                        Enabled="false"
                                                        CellPadding="5" CellSpacing="5" Font-Size="0.9em" Width="100%" 
                                                        RepeatColumns="10" RepeatDirection="Vertical" TextAlign="Right" >
                                                    </asp:CheckBoxList>

                                                </div>

                    

                                              </div>

                                            </div>


                                        </div>
                                        
                                        
                                        <br />

                                    </asp:Panel>

                                </div>
                
                            </div>
    
                    
                        </ContentTemplate>
                        
                    </asp:UpdatePanel>



                    <!-- Archivos SOPORTE PAGADURIA -->

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>


                            <div class="row container " id="filaArchivosSoportePagaduria"  >        
                    
                                <div class="col-md-12">

                                    <a name="archSopPag" > </a>

                                    <asp:Panel ID="pnlArchivosSoportePagaduria" runat="server" Width="100%" >                    

                                        
                                                 <div class="row container text-center " id="titArcSopPagCont"   >                                        
                               
                                                       <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                            

                                                           <div class="row container text-center " id="titArcSopPagCont1"   >        
                                                              <br>
                                                                    <div class="col-md-1 " ></div>
                                                                   <div class="col-md-3 text-left  ">
                                                                       

                                                                       <h2 class="panel-title"> 
                                                                        <strong> 

                                                                                <a data-toggle="collapse" 
                                                                                    data-target="#colArchSop" >
                                                                         
                                                                                    <span class="glyphicon glyphicon-collapse-down "></span> &nbsp;Archivos Soporte Pagaduría

                                                                                </a>
                                                                            </strong> 
                                                                        </h2>

                                                                        <br>

                                                                    </div>                                             
                                                                    
                                                                   <div class="col-md-8 text-right"  > 
                                                                        
                                                                    </div>    

                                                            </div>


                                                       </div>


                                                    </div>


                                        <br>
                                       

                                        <div class="panel-collapse collapse in" id="colArchSop" >                                         

                                            <div class="panel-body">

                                                <div class="row container " id="verArchivosSoporte"   >        
                
                                        
                                                    <div class="col-xs-12   ">
                                            
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
                                                                                CssClass="btn btn-success btn-xs" 
                                                                                NavigateUrl='<%# Eval("soppaga_Url") %>'>                                                    
                                                                                <span class="glyphicon glyphicon-file "> </span>                                                                                                                       
                                                                             </asp:HyperLink>
    
                                                                        
                                                                    </ItemTemplate>                                        
                                                                </asp:TemplateField>
                                        
                                                                <asp:BoundField DataField="soppaga_Nombre" HeaderText="Nombre Soporte" />
                                                                <asp:BoundField DataField="soppaga_Url" HeaderText="Url Soporte" />

                                                        
                                                            </Columns>
                
                                                     </asp:GridView>

                                                    </div> 
                
                
                                                </div>
                                            </div>


                                        </div>

                                    </asp:Panel>

                                </div>
                    
                            </div>


                   	    </ContentTemplate>
                        
                    </asp:UpdatePanel>

                    

                    
                    
                    
                    <!-- CONVENIOS -->


                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>


                            <div class="row container " id="filaConvenios"  >        
                    
                                <div class="col-md-12">

                                    
                                    <a name="irConvenios" ></a>

                                    
                                    <asp:Panel ID="pnlConvenios" runat="server">

                                        
                                         <div class="row container text-center " id="titFilaConv1"   >                                        
                               
                                                <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                            
                                                    <br />

                                                     <div class="row container text-center " id="titFilaConv2"   >                                        
                                                           
                                                         <div class="col-md-1 " ></div>

                                                           <div class="col-md-3 text-left  ">

                                                               <h2 class="panel-title"> 
                                                                       <strong> 

                                                                                <a data-toggle="collapse" 
                                                                                    data-target="#colConv" >
                                                                         
                                                                                    <span class="glyphicon glyphicon-collapse-down "></span> &nbsp;Convenios

                                                                                </a>
                                                                            </strong> 
                                                                        </h2>

                               
                                                            </div>

                                                           <div class="col-md-8 text-right"  > 
                                   
                                                               
                                                            </div>    
 
                                                     </div>

                                                    <br />

                                                   </div>
                                             </div>
                                        
                                        <br>
                                        
                                        
                                        <div class="panel-collapse collapse in" id="colConv" >                                         

                                            <div class="panel-body">


                                                <div class="row container text-center " id="titFilaConv"  >                                        
                                                                            
                                                <div class=" col-xs-1 form-group">                    
                                                    <asp:TextBox type="number" runat="server" id="txtFiltroIdConv" cssClass="form-control input-sm" 
                                                        placeholder="Id" step="1" min="1" max="999999" ></asp:TextBox>
                                                </div>

                                                <div class="col-xs-3 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroCodConv" cssClass="form-control input-sm" 
                                                        placeholder="Codigo Convenio" ></asp:TextBox>
                                                </div>

                                               <div class="col-xs-3 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroNombreConv" 
                                                        cssClass="form-control input-sm" 
                                                        placeholder="Nombre Convenio"  ></asp:TextBox>
                                                </div>
                                        
                    
                                                <div class="col-xs-3 form-group">                                            

                                                    <div class="input-group">
                                                        <asp:LinkButton ID="lnkBtnBuscarConv" runat="server" 
                                                            CssClass="btn btn-primary btn-sm" 
                                                            Text="Buscar" OnClick="lnkBtnBuscarConv_Click">
                                                            <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                                <div class="col-xs-2 form-group">                    
                                                </div>
   

                                            </div>


                                                <div class="row container " id="verConvenios"   >        
                
                                                    <!-- tabla para cosultar todas las pagadurias -->
                                        

                                                    <div class="col-xs-12   ">
                                            
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

                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >                                            
                                                                    <ItemTemplate>
                                                
                                                                        <asp:linkButton CssClass="btn btn-success glyphicon glyphicon glyphicon-search btn-xs" 
                                                                            id="botonConsultar" runat="server"  
                                                                            CommandName="Select"  data-toggle="tooltip" title="Consultar">

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

                                            
                                             </div>


                                        </div>

                                    </asp:Panel>


                                </div>
                        
                            </div>


                    </ContentTemplate>
                        <Triggers>
            
                            <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarConv" eventname="Click" />

                        </Triggers>
                    </asp:UpdatePanel>

                    



                     <!-- ARCHIVOS NOVEDADES -->

                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>


                            <div class="row container " id="filaArchivosNovedades"  >        
                    
                                    <div class="col-md-12">

                                        <a name="irConfigArchNov" > </a>

                                        <asp:Panel ID="pnlArchivosNovedades" runat="server">

                                            
                                        <div class="row container text-center " id="titFilaArchNov1"   >                                        
                               
                                                <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                            
                                                    <br />

                                                     <div class="row container text-center " id="titFilaArchNov2"   >                                        
                                                           
                                                         
                                                         <div class="col-md-1 " ></div>

                                                           <div class="col-md-5 text-left  ">
                                                                
                                                                 <h2 class="panel-title"> 
                                                                    <strong> 

                                                                            <a data-toggle="collapse" 
                                                                                data-target="#colConfArchNov" >
                                                                         
                                                                                <span class="glyphicon glyphicon-collapse-down "></span> 
                                                                                            &nbsp;Configuración Archivo Novedades
                                                                            </a>
                                                                        </strong> 
                                                                    </h2>
                               
                                                            </div>

                                                           <div class="col-md-6 text-right"  >                                    

                                                            </div>    
 
                                                     </div>

                                                    <br />

                                                   </div>

                                             </div>
                                        
                                            <br>    
                                            
                                            
                                            <div class="panel-collapse collapse in" id="colConfArchNov" >                                         

                                                <div class="panel-body">

                                                    <div class="row container text-center " id="contFilaArchNov"  >                                                                       
                                    
                                                        <div class="col-xs-1 form-group">                    
                                                            <asp:TextBox type="number" runat="server" id="txtIdArchNov" CssClass="form-control input-sm"
                                                                placeholder="Id" step="1" min="1" max="999999" ></asp:TextBox>
                                                        </div>

                                                       <div class="col-xs-3 form-group">                    
                                                            <asp:TextBox type="" runat="server" id="txtNomArchNov" CssClass="form-control input-sm"
                                                                placeholder="Nombre Archivo"  ></asp:TextBox>
                                                        </div>

                                                        <div class="col-xs-3 form-group">                    
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlTipoArchivo" runat="server">
                                                                <asp:ListItem Text="Seleccione Tipo Archivo" Value="-1" > </asp:ListItem>
                                                                <asp:ListItem Text="Novedades" Value="0" > </asp:ListItem>
                                                                <asp:ListItem Text="Cuenta de Cobro" Value="1" > </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="col-xs-3 form-group">                    
                                                            <asp:DropDownList CssClass="form-control input-sm" ID="ddlTipoReporte" runat="server">
                                                                <asp:ListItem Text="Seleccione Tipo Reporte" Value="-1" > </asp:ListItem>
                                                                <asp:ListItem Text="Ingreso, Retiro, Modificación" Value="0" > </asp:ListItem>
                                                                <asp:ListItem Text="Ingreso y retiro" Value="1" > </asp:ListItem>
                                                                <asp:ListItem Text="Solo Vigentes" Value="2" > </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                    
                                                        <div class="col-xs-2 form-group">                                            

                                                            <div class="input-group">
                                                                <asp:LinkButton ID="lnkBtnBuscarArchNov" runat="server" 
                                                                    CssClass="btn btn-primary btn-sm" 
                                                                    Text="Buscar" OnClick="lnkBtnBuscarArchNov_Click">
                                                                    <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                                </asp:LinkButton>
                                                            </div>

                                                        </div>

   
                                                    </div>
                                    
                                                    <div class="row container " id="verArchNov"   >        
                
                                                    <!-- tabla para cosultar todas las pagadurias -->
                                        

                                                    <div class="col-xs-12   ">
                                            
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

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" >                                            
                                                                        <ItemTemplate>
                                                
                                                                            <asp:linkButton CssClass="btn btn-success glyphicon glyphicon glyphicon-search btn-xs " 
                                                                                    id="botonConsultar" runat="server"  
                                                                                    CommandName="Select"  data-toggle="tooltip" title="Consultar"></asp:linkButton>                                                

                                                                          
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


                                                </div>

                                            </div>

                                        </asp:Panel>


                                    </div>
                        
                                </div>


                        </ContentTemplate>
                        <Triggers>
            
                            <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarArchNov" eventname="Click" />

                        </Triggers>
                    </asp:UpdatePanel>


                </div>

        
             </div>
    
    </asp:Content>
