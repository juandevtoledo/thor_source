<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConveniosPagaduria.aspx.cs" Inherits="Presentacion_ConveniosPagaduria" MasterPageFile="~/MasterPage.master" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Convenios Pagaduria </title>
    
    <script src="/Scripts/jsValidacionesCamposTG.js" ></script>

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
            var caption = "Adicionar Productos Convenio";
            //var url = "/Presentacion4/AdjuntarArchivosSoporteConvenio.aspx";
            var url = protocol + "//" + host + "/Presentacion4/AdicionarProductosConvenio.aspx";
            //alert(url);
            return GB_showCenter(caption, url, 600, 800)
        }
        //Center grybox window with callback on close
        function OpenCenterWindowCallBack() {
            var caption = "Adjuntar Archivo Soporte Convenio";
            var url = protocol + "//" + host + "/Presentacion4/AdjuntarArchivosSoporteConvenio.aspx";
            return GB_showCenter(caption, url, 350, 550, callback_fn)
        }

        //Center grybox window with callback on close
        function OpenCenterWindowCallBackV2() {
            var caption = "Adicionar Productos Convenio";
            var url = protocol + "//" + host + "/Presentacion4/AdicionarProductosConvenio.aspx";            
            return GB_showCenter(caption, url, 600, 800, callback_fn)
        }


        //Callback function
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/ConveniosPagaduria.aspx"; //#archSopConv";
        }
        //Full screen greybox popup window
        function OpenFullScreenWindow() {
            var caption = "Adjuntar Archivo Soporte";
            var url = protocol + "//" + host + "/Presentacion4/AdjuntarArchivosSoporteConvenio.aspx";
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
        <div class="panel panel-default" style="font-size:0.9em">
    
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            

            <div class="panel-heading panel-primary">

                    <div class="row container " id="tituloPagina"  >        


                            <div class="col-md-7">
                                <h3 class="panel-title"> <strong> CONVENIO PAGADURIA </strong> 
                                    <br />
                                    <small> <em>&nbsp;  <asp:Label ID="lblAccion" runat="server" Text="Label"> </asp:Label> </em> </small>  
                                </h3>                                    
                            </div>

                        <div class="col-md-1"> </div>

                            <div class="col-md-1" >

                                <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info" 
                                            CausesValidation="false" formnovalidate="form1"
                                            Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/DetallePagaduria.aspx#irConvenios" >
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
                                                                data-target="#colFormConv" >
                                                                         
                                                                <span class="glyphicon glyphicon-collapse-down "></span>
                                                                Formulario Registro Convenio

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


                        <!-- DATOS PRINCIPALES CONVENIO -->

                            <div class="panel-collapse collapse in" id="colFormConv" >                                         
    
                                <div class="panel-body">
                  
                  
                                    <div class="row container " id="encConvenio"  >        

                                        <div class="col-md-12">
                                            <h4> Datos Convenio </h4>
                                                <hr />
                                        </div>

                                    </div>

                                    <div class="row container form-group " id="Convenio"  >   
                        
                            
                            <asp:Label ID="lblMsj" runat="server" ></asp:Label>
                            <br />


                                <div class=" col-md-4 form-group">
                                    <asp:Label Font-Bold="true" ID="Label30" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label31" runat="server"> Codigo Convenio </asp:Label>
                                    
                                    <asp:RequiredFieldValidator ID="rfvNombrePagaduria" runat="server" 
                                            ControlToValidate="txtConvCodigo" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  

                                     

                                    <asp:TextBox type="text" runat="server" id="txtConvCodigo" cssClass="form-control input-sm" 
                                        placeholder="Código Convenio" 
                                        required="required" MaxLength="50" ></asp:TextBox>    

                                            
                                </div>   

                            
                                <div class=" col-md-4 form-group">
                                    <asp:Label Font-Bold="true" ID="Label1" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label2" runat="server"> Nombre Convenio </asp:Label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtConvNombre" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  

                                    <asp:TextBox type="text" runat="server" id="txtConvNombre" cssClass="form-control input-sm" 
                                        placeholder="Nombre Convenio" 
                                        required="required" MaxLength="150" ></asp:TextBox>    

                                            
                                </div>   

                             
                                <div class=" col-md-4 form-group">
                                    <asp:Label Font-Bold="true" ID="Label3" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label4" runat="server"> Responsable Aprobación </asp:Label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtConvRespAprob" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  

                                    <asp:TextBox type="text" runat="server" id="txtConvRespAprob" cssClass="form-control input-sm" 
                                        placeholder="Responsable Aprobación" 
                                        required="required" MaxLength="150" ></asp:TextBox>    

                                            
                                </div>   


                                <div class=" col-md-4 form-group">
                                    <asp:Label Font-Bold="true" ID="Label5" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label6" runat="server"> Fecha Aprobación </asp:Label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtFecAprob" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>  

                                    <asp:TextBox runat="server" id="txtFecAprob" type="date"
                                                 cssClass="form-control input-sm" ></asp:TextBox>

                                            
                                </div>   


                                <div class=" col-md-4 form-group">
                                        
                                    <asp:Label Font-Bold="true" ID="Label10" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                    <asp:Label cssClass="labels" Font-Bold="true" id="labPerPago" runat="server"> Periodicidad Pago </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlPeriodicidad" runat="server">                                        
                                        <asp:ListItem Text="Mensual" Value="1" > </asp:ListItem>
                                        <asp:ListItem Text="Bimestral" Value="2" > </asp:ListItem>
                                        <asp:ListItem Text="Trimestral" Value="3" > </asp:ListItem>
                                        <asp:ListItem Text="Semestral" Value="4" > </asp:ListItem>
                                        <asp:ListItem Text="Anual" Value="5" > </asp:ListItem>
                                        <asp:ListItem Text="Prorrateo" Value="6" > </asp:ListItem>
                                        <asp:ListItem Text="Catorcenal" Value="7" > </asp:ListItem>
                                    </asp:DropDownList>
                                        
                                </div>
                        
                                <div class=" col-md-4 form-group " >
                                    <asp:Label Font-Bold="true" ID="Label7" runat="server" ForeColor="Red" > * </asp:Label>
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label8" runat="server"> Estado </asp:Label>
                                    
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlEstado" runat="server">                                        
                                        <asp:ListItem Text="Activo" Value="1" > </asp:ListItem>
                                        <asp:ListItem Text="Inactivo" Value="0" > </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                                                
                                <br /><br /><br /><br /><br /><br />
                            
                                <div class=" col-md-12 form-group">
                                    
                                    <asp:Label cssClass="labels" Font-Bold="true" id="Label11" runat="server"> Observaciones </asp:Label>

                                    <asp:TextBox type="text" runat="server" id="txtObservaciones" cssClass="form-control input-sm" 
                                        placeholder="Observaciones Convenio" TextMode="MultiLine" Rows="5" 
                                        required="required" MaxLength="1000" ></asp:TextBox>    

                                            
                                </div>        
                                

                
                                <div class="row container " id="filaBtnOpcionesConvenio"  >        

                                    <div class="col-md-12 form-group text-center ">
                              
                                        <br />
                                        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm "
                                            CausesValidation="false" formnovalidate="form1"                                    
                                            OnClientClick="if (!confirm('Esta seguro de Eliminar el convenio ?')) return false;" 
                                            OnClick="btnEliminar_Click" >
                                            <span class="glyphicon glyphicon-floppy-remove"></span>&nbsp;
                                            <strong> Eliminar Convenio </strong>
                                        </asp:LinkButton>
                                

                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-sm"
                                                OnClick="btnGuardar_Click" text="Guardar"
                                                ValidationGroup="addForm" CausesValidation="true" >
                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp; 
                                                <strong>  Guardar Convenio </strong>
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="btnImprimirConvenio" runat="server" CssClass="btn btn-primary btn-sm"
                                                OnClick="btnImprimirConvenio_Click" text="Imprimir"
                                                ValidationGroup="addForm" CausesValidation="true" >
                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp; 
                                                <strong>  Imprimir Convenio </strong>
                                        </asp:LinkButton>

                                         <asp:LinkButton ID="btnImprimirCartaBienvenida" runat="server" CssClass="btn btn-primary btn-sm"
                                                OnClick="btnImprimirCartaBienvenida_Click" text="Imprimir"
                                                ValidationGroup="addForm" CausesValidation="true" >
                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp; 
                                                <strong>  Imprimir Carta Bienvenida </strong>
                                        </asp:LinkButton>

                                
                                
                       
                                   </div>

                            
                        
                        </div>

                    </div>

                               
                                </div>
                            
                            </div>

                        <br />

                        
                        <!-- LOCALIDADES POR CONVENIO  -->

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>

                                <div class="row container " id="filaLocalidadesPorConvenio"  >        
                    
                                    <div class="col-md-12">
                                

                                        <asp:Panel ID="pnlLocalidadesConvenio" runat="server" Width="100%" >                    

                                            <div class="row container text-center " id="titLocPag"  >        
                                

                                                <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                               
                                                    <br>

                                                    <div class="col-md-1   " >                                               
                                                    </div>

                                                    <div class="col-md-4 text-left  " >                                               
                                                                    
                                                    <h2 class="panel-title"> 
                                                        <strong> 
                                                                                                        
                                                                <a data-toggle="collapse" 
                                                                    data-target="#colLocConv" >
                                                                         
                                                                    <span class="glyphicon glyphicon-collapse-down "></span>
                                                                    Localidades por Convenio

                                                                </a>
                                                            </strong> 
                                                        </h2>
                                        
                                                            <br>
                                                        </div>

                                                            <div class="col-md-7  " >                                              
                                                            </div>

                                                    </div>
                                               
                                                </div>
                                               
                                            

                                            <br />


                                            <div class="panel-collapse collapse in" id="colLocConv" >                                         
    
                                                <div class="panel-body">                  

                                                    <div class="row container " id="verLocalidadesPorConvenio"   >        
                
                                                    <!-- tabla para cosultar todas las pagadurias -->
                                        

                                                    <div class="col-xs-12">

                                                        <asp:CheckBoxList ID="chkLocalidadesConvenio" runat="server"
                                                             CellPadding="5" CellSpacing="5" Font-Size="0.9em" Width="100%" 
                                                            RepeatColumns="10" RepeatDirection="Vertical" TextAlign="Right" >
                                                        </asp:CheckBoxList>

                                                    </div>

                                                <div class="col-xs-12 text-center" >

                                                    <br /><br />

                                                    <asp:LinkButton ID="lnkGuardarLocalidadesConv" runat="server" 
                                                            CssClass="btn btn-primary btn-sm"
                                                            OnClick="GuardarLocalidadesConvenio_Click" text="Guardar Localidades" >
                                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Guardar Localidades
                                                    </asp:LinkButton>

                                                </div>

                                            </div>


                                                </div>

                                            </div>

                                            <br />

                                        </asp:Panel>

                                    </div>
                
                                </div>

                             </ContentTemplate>
                        <Triggers>
            
                            <asp:AsyncPostBackTrigger controlid="lnkGuardarLocalidadesConv" eventname="Click" />

                        </Triggers>
                    </asp:UpdatePanel>



                  
                        
                  <!-- ARCHIVOS SOPORTE CONVENIO -->

                  <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>

                                <div class="row container " id="filaArchivosSoporteConvenio"  >        
                    
                                        <div class="col-md-12">

                                            <a name="archSopConv" > </a>

                                            <asp:Panel ID="pnlArchivosSoporteConvenio" runat="server" Width="100%" >                    

                                                <div class="row container text-center " id="titArcSopConvCont"  >                                        
                                               
                                                     <div class="col-md-12  "  style="background-color:#f9f9f9" >
                                               
                                                    <br>   
                                                    
                                                        <div class="row container text-center " id="titArcSopConvCont1"  >        

                                                               <div class="col-md-1  "> </div>

                                                               <div class="col-md-3 text-left  ">

                                                                    <h2 class="panel-title"> 
                                                                        <strong> 
                                                                                                        
                                                                                <a data-toggle="collapse" 
                                                                                    data-target="#colArchSopConv" >
                                                                         
                                                                                    <span class="glyphicon glyphicon-collapse-down "></span>
                                                                                    Archivos Soporte Convenio

                                                                                </a>
                                                                            </strong> 
                                                                        </h2>
                               
                                                                </div>

                                                               <div class="col-md-8 text-right"  > 

                                   
                                                                    <asp:LinkButton ID="botonAdicionar" runat="server" CssClass="btn btn-info btn-xs"                                     
                                                                            text="" OnClick="btnAddArchivos_Click"  >
                                                                        <span class="glyphicon glyphicon-paperclip"></span>
                                                                        <strong> &nbsp;Adjuntar Archivos Soporte </strong>
                                                                    </asp:LinkButton>

                                                                </div>    

                                                         </div>

                                                    <br />

                                                    </div>


                                                 </div>

                                                <br />

                                            
                                                <div class="panel-collapse collapse in" id="colArchSopConv" >                                         
    
                                                    <div class="panel-body">                        
                                                
                                                        <div class="row container " id="verArchivosSoporte"   >        
                
                                     
                                                    <div class="col-xs-12   ">
                                            
                                                         <asp:GridView ID="grvArchivosSoporte" runat="server" Font-Size="0.9em" 
                                                                DataKeyNames="sopcon_Id"
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
                                                                                    NavigateUrl='<%# Eval("sopcon_Url") %>'>                                                    
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
                                        
                                                                    <asp:BoundField DataField="sopcon_Nombre" HeaderText="Nombre Soporte" />
                                                                    <asp:BoundField DataField="sopcon_Url" HeaderText="Url Soporte" />

                                                        
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

      
                  <br />

                  <!-- PRODUCTOS POR CONVENIO  -->

                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>


                        <div class="row container " id="filaProductosPorCompañia"  >        
                    
                            <div class="col-md-12">



                                <asp:Panel ID="pnlProductosConvenio" runat="server" Width="100%" >                    

                                    <div class="row container text-center " id="titLocProd"  >        
                                

                                        <div class="col-md-12  "  style="background-color:#f9f9f9" >
                               
                                            <br />

                                            <div class="row container text-center " id="titLocProd1"  >        

                                                    <div class="col-md-1 text-left "> </div>

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
                                   
                                                        <asp:LinkButton ID="btnAddProductos" runat="server" CssClass="btn btn-info btn-xs"                                     
                                                                text="" OnClick="btnAddProductos_Click"  >
                                                            <span class="glyphicon glyphicon-briefcase"></span>
                                                            <strong> &nbsp;Administrar Productos </strong>
                                                        </asp:LinkButton>

                                                    </div>    
                            
                                                </div>

                                                <br />

                                            </div>

                                    </div>

                                    
                                    <div class="panel-collapse collapse in" id="colProdConv" >                                         
    
                                        <div class="panel-body">  

                                            <div class="row container " id="verProductosConvenio"   >        

                                                    <br /><br />

                                                   <div class="col-xs-3 form-group">                    
                                                        <asp:TextBox type="" runat="server" id="txtFiltroNombreComp" cssClass="form-control" 
                                                            placeholder="Nombre Compañia"  ></asp:TextBox>
                                                    </div>

                                                    <div class=" col-xs-2 form-group">                    
                                                        <asp:TextBox type="number" runat="server" id="txtFiltroIdProd" cssClass="form-control" 
                                                            placeholder="Id Producto" step="1" min="1" max="999999" ></asp:TextBox>
                                                    </div>

                                                    <div class="col-xs-3 form-group">                    
                                                        <asp:TextBox type="" runat="server" id="txtFiltroNombreProd" cssClass="form-control" 
                                                            placeholder="Nombre Producto"  ></asp:TextBox>
                                                    </div>
                    
                                                    <div class="col-xs-2 form-group">                                            

                                                        <div class="input-group">
                                                            <asp:LinkButton ID="lnkBtnBuscarProd" runat="server" 
                                                                CssClass="btn btn-primary btn-sm" 
                                                                Text="Buscar" OnClick="lnkBtnBuscarProd_Click">
                                                                <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>

                                        
                                                    <div class="col-xs-2 form-group">                    
                                                        <asp:TextBox type="number" runat="server" id="txtFiltroIdComp" cssClass="form-control" Visible="false" 
                                                            placeholder="Id Compañia" step="1" min="1" max="999999" ></asp:TextBox>
                                                    </div>

                                                    <br /><br /><br />

                                                    <div class="col-xs-12">

                                                        <asp:GridView ID="grvProductosConvenio" runat="server" Font-Size="0.9em" 
                                                                DataKeyNames="pro_Id"
                                                                CssClass="table table-bordered table-hover table-striped" 
                                                                AutoGenerateColumns="false" 
                                                                AllowPaging="True" PageSize="5"                                                                                                         
                                                                OnPageIndexChanging="grvProductosConvenio_PageIndexChanging"    
                                                             >
                    
                                                               <EmptyDataTemplate>
                                                                    <div class="alert alert-warning" role="alert">                                                                 
                                                                        <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Productos !!! 
                                                                    </div>
                                                                </EmptyDataTemplate>

                                                                <Columns>                                                

                                                                    <asp:BoundField DataField="com_Nombre" HeaderText="Compañia" />
                                                                    <asp:BoundField DataField="pro_Id" HeaderText="Id Prod" />                                                        
                                                                    <asp:BoundField DataField="pro_Nombre" HeaderText="Producto" />                                                        
                                                                    <asp:BoundField DataField="pro_MesesGracia" HeaderText="Meses Gracia" />
                                                                    <asp:BoundField DataField="estProd_Format" HeaderText="Estado" />
                                                        
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
            
                            <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarProd" eventname="Click" />

                        </Triggers>
                    </asp:UpdatePanel>    

                        


                                  
            
            
               </div>
                  
                   <br />


           

        </div>
</asp:Content>
