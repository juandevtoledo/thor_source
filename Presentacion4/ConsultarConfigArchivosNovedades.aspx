<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarConfigArchivosNovedades.aspx.cs" Inherits="Presentacion_ConsultarConfigArchivosNovedades" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Consultar Configuración Archivos Novedades </title>
    

    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>

    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <div class="panel panel-default" style="font-size:0.9em">
    

            <div class="panel-heading panel-primary">

                    <div class="row container " id="tituloPagina"  >                              

                            <div class="col-md-7">
                                <h3 class="panel-title"> <strong> CONSULTAR CONFIGURACIÓN ARCHIVOS NOVEDADES </strong> 
                                    <br />
                                    <small> <em>&nbsp;  <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label> </em> </small>  
                                </h3>                                    
                            </div>

                        <div class="col-md-1"> </div>

                            <div class="col-md-1" >

                                <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info"                                      
                                            CausesValidation="false" formnovalidate="form1"
                                            Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/ConsultarPagaduria.aspx#irConfigArchNov" >
                                            <span class="glyphicon glyphicon-th-list "></span>
                                                <strong> &nbsp; Detalle Pagaduria </strong>
                                        </asp:LinkButton>

                            </div>

                            <div class="col-md-1"> </div>

                            <div class="col-md-1">


                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info" 
                                    CausesValidation="false" formnovalidate="form1"
                                    Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/Pagadurias.aspx" >
                                    <span class="glyphicon glyphicon-hand-left"></span>
                                    <strong> &nbsp; Pagadurias </strong>
                                </asp:LinkButton>

                            </div>


                    </div>                    

            </div> 
                  
              
            <div class="panel-body">


                     <br />
                  
                        <div class="row container " id="encFormConv"  >        
                    
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
                                                                data-target="#colFormConfArchNov" >
                                                                         
                                                                <span class="glyphicon glyphicon-collapse-down "></span>
                                                                Formulario Registro Configuración

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
                    
                            </div>               
            
                        </div>

                
                    <br />
                  <!-- DATOS PRINCIPALES CONFIGURACIN ARCHIVO -->


                <asp:Panel ID="pnlDatosConfigArch" runat="server" Enabled="false" >

                  <div class="panel-collapse collapse in" id="colFormConfArchNov" >                                         
    
                        <div class="panel-body">

                            <div class="row container " id="encConvenio"  >        

                            <div class="col-md-12">
                                <h4> Configurar Archivo </h4>
                                    <hr />
                            </div>

                        </div>

                            <div class="row container form-group " id="Convenio"  >   
                        
                            
                            <asp:Label ID="lblMsj" runat="server" ></asp:Label>
                            <br />
                            
                            <div class="row container " id="filaFormAchNov"  >        

                                <div class=" col-md-4 form-group">
                                    <asp:Label Font-Bold="true" ID="Label1" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label2" runat="server"> Nombre Archivo </asp:Label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtNombreArch" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  

                                    <asp:TextBox type="text" runat="server" id="txtNombreArch" cssClass="form-control input-sm" 
                                        placeholder="Nombre Archivo" 
                                        required="required" MaxLength="150" ></asp:TextBox>    

                                            
                                </div>   
                             
                                
                                <div class=" col-md-4 form-group">
                                        
                                    <asp:Label Font-Bold="true" ID="Label10" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                    <asp:Label cssClass="labels" Font-Bold="true" id="labPerPago" runat="server"> Tipo Archivo </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlTipoArchivo" runat="server">
                                        <asp:ListItem Text="Novedades" Value="0" > </asp:ListItem>
                                        <asp:ListItem Text="Cuenta de Cobro" Value="1" > </asp:ListItem>
                                    </asp:DropDownList>
                                        
                                </div>


                                <div class=" col-md-4 form-group">
                                        
                                    <asp:Label Font-Bold="true" ID="Label3" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label4" runat="server"> Tipo Reporte </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlTipoReporte" runat="server">                                                
                                        <asp:ListItem Text="Ingreso, Retiro, Modificación" Value="0" > </asp:ListItem>
                                        <asp:ListItem Text="Ingreso y retiro" Value="1" > </asp:ListItem>
                                        <asp:ListItem Text="Solo Vigentes" Value="2" > </asp:ListItem>
                                    </asp:DropDownList>
                                        
                                </div>

                        
                                <div class=" col-md-4 form-group " >
                                    
                                    <asp:Label Font-Bold="true" ID="Label7" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label8" runat="server"> Valor </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlValor" runat="server">                                        
                                        <asp:ListItem Text="Valor Total" Value="0" > </asp:ListItem>
                                        <asp:ListItem Text="Novedad (diferencia)" Value="1" > </asp:ListItem>
                                    </asp:DropDownList>

                                </div>


                                <div class=" col-md-4 form-group " >
                                    
                                    <asp:Label Font-Bold="true" ID="Label5" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label6" runat="server"> Retiros </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlRetiro" runat="server">                                        
                                        <asp:ListItem Text="Valor en 0" Value="0" > </asp:ListItem>
                                        <asp:ListItem Text="Valor Total" Value="1" > </asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                                 
                                <div class=" col-md-4 form-group ">
                                </div>               
                                
                             </div>


                            </div>

                        </div>

                    </div>
                    
                </asp:Panel>

                  <!-- PRODUCTOS POR CONVENIO  -->

                   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                                                          
                         <div class="row container " id="filaProductosPorConvenio"  >        
                    
                            <div class="col-md-12">

                             
                                <a name="prodConv" > </a>
                                
                                
                                   <asp:Panel ID="pnlProductosConvenio" runat="server" Width="100%" >                    


                                        <div class="row container text-center " id="titLocProd"  >        
                                
                                            <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                       
                                                <br />

                                                <div class="row container text-center " id="titLocProd1"  >        

                                                      <div class="col-md-1 text-left " > </div>

                                                      <div class="col-md-3 text-left ">

                                                            <h2 class="panel-title"> 
                                                                <strong> 
                                                                                                        
                                                                    <a data-toggle="collapse" 
                                                                        data-target="#colProdConv" >
                                                                         
                                                                        <span class="glyphicon glyphicon-collapse-down "></span>
                                                                            Productos Convenio

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

                                       <br />

                                    <div class="panel-collapse collapse in" id="colProdConv" >                                         
    
                                        <div class="panel-body">
                                       
                                            <div class="row container " id="verConveniosArchNov"   >        
                                        
                                        
                                                <div class="col-xs-2 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroCodConv" cssClass="form-control input-sm" 
                                                        placeholder="Codigo Convenio"  ></asp:TextBox>
                                                </div>

                                                <div class="col-xs-3 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroNomConv" cssClass="form-control input-sm" 
                                                        placeholder="Nombre Convenio"  ></asp:TextBox>
                                                </div>
                                       
                                                <div class=" col-xs-1 form-group">                    
                                                    <asp:TextBox type="number" runat="server" id="txtFiltroIdProd" cssClass="form-control input-sm" 
                                                        placeholder="Id Producto" step="1" min="1" max="999999" ></asp:TextBox>
                                                </div>

                                                <div class="col-xs-2 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroNombreProd" cssClass="form-control input-sm "  
                                                        placeholder="Nombre Producto"  ></asp:TextBox>
                                                </div>

                                                <div class="col-xs-2 form-group">                    
                                                    <asp:TextBox type="" runat="server" id="txtFiltroNombreComp" cssClass="form-control input-sm" 
                                                        placeholder="Nombre Compañia"  ></asp:TextBox>
                                                </div>

                    
                                                <div class="col-xs-2 form-group">                                            

                                                    <div class="input-group">
                                                        <asp:LinkButton ID="lnkBtnBuscarConvArchNov" runat="server" 
                                                            CssClass="btn btn-primary btn-sm" 
                                                            Text="Buscar" OnClick="lnkBtnBuscarConvArchNov_Click">
                                                            <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>


                                        <br /><br /><br />

                                        <div class="col-xs-12">

                                            <asp:GridView ID="grvProductosConveniosArchNov" runat="server" Font-Size="0.9em" 
                                                    DataKeyNames="pro_Id"
                                                    CssClass="table table-bordered table-hover table-striped" 
                                                    AutoGenerateColumns="false" 
                                                    AllowPaging="True" PageSize="5"                                                                                                         
                                                    OnPageIndexChanging="grvProductosConvenioArchNov_PageIndexChanging"    
                                                 >
                    
                                                   <EmptyDataTemplate>
                                                        <div class="alert alert-warning" role="alert">                                                                 
                                                            <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Convenios y Productos !!! 
                                                        </div>
                                                    </EmptyDataTemplate>

                                                    <Columns>                                                

                                                        <asp:BoundField DataField="con_Codigo" HeaderText="Codigo Convenio" />
                                                        <asp:BoundField DataField="con_Nombre" HeaderText="Convenio" />                                                        
                                                        <asp:BoundField DataField="estConv_Format" HeaderText="Estado Convenio" />
                                                        
                                                        <asp:BoundField DataField="com_Nombre" HeaderText="Compañia" />
                                                        <asp:BoundField DataField="pro_Id" HeaderText="Id Producto" />
                                                        <asp:BoundField DataField="pro_Nombre" HeaderText="Producto" />                                                        
                                                        <asp:BoundField DataField="pro_MesesGracia" HeaderText="Meses Gracia" />
                                                        <asp:BoundField DataField="estProd_Format" HeaderText="Estado Producto" />
                                                        
                                                        
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
            
                            <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarConvArchNov" eventname="Click" />

                        </Triggers>
                    </asp:UpdatePanel>
                        


                                  
            </div>   
            
            
             <br />


        </div>
    </asp:Content>
