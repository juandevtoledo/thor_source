<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfigurarArchivosNovedades.aspx.cs" Inherits="Presentacion_ConfigurarArchivosNovedades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Configurar Archivos Novedades </title>
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
            var caption = "Configurar Archivos Novedades: Adicionar Convenios y Productos";
            var url = protocol + "//" + host + "/Presentacion4/AdicionarConveniosArchivosNovedades.aspx";
            //alert(url);
            return GB_showCenter(caption, url, 600, 800)
        }

        //Center grybox window with callback on close
        function OpenCenterWindowCallBack() {
            var caption = "Configurar Archivos Novedades: Adicionar Convenios y Productos";
            var url = protocol + "//" + host + "/Presentacion4/AdicionarConveniosArchivosNovedades.aspx";
            return GB_showCenter(caption, url, 600, 800, callback_fn)
        }



        //Callback function
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/ConfigurarArchivosNovedades.aspx#prodConv";
        }
        //Full screen greybox popup window
        function OpenFullScreenWindow() {
            var caption = "Configurar Archivos Novedades: Adicionar Convenios y Productos";
            var url = protocol + "//" + host + "/Presentacion4/AdicionarConveniosArchivosNovedades.aspx";
            return GB_showFullScreen(caption, url, callback_fn)
        }
        //Greybox Image popup window
        function OpenImage(url) {
            var caption = "Configurar Archivos Novedades: Adicionar Convenios y Productos";
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
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager> 
    <!--///////////////////////////////////////-->
    <div class="container-form">
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="archivoNovedades" />
            </div>
        </div><!--row-->
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>
                    Configurar archivo de novedades
                    <span class="btn-group pull-right btns-title" role="group">
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary " 
                            CausesValidation="false" formnovalidate="form1"
                            Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/Pagadurias.aspx" >
                            <span class="glyphicon glyphicon-hand-left"></span> Pagadurias
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkBtnBuscar" runat="server" CssClass="btn btn-info"                                      
                            CausesValidation="false" formnovalidate="form1"
                            Text="Volver a Pagadurias" PostBackUrl="~/Presentacion4/DetallePagaduria.aspx#irConfigArchNov" >
                            <span class="glyphicon glyphicon-th-list "></span> Detalle Pagaduria
                        </asp:LinkButton>
                    </span>
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><strong>Datos</strong></h3>
            </div>
            <div class="panel-body">
                <asp:Label ID="lblAccion" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Registro de configuración</a></li>
                    <li><a data-toggle="tab" href="#tab-2">Productos convenios</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade">
                        <h3 class="impre">Configurar archivo</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                            <ContentTemplate>
                                <div class="row impre">
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label Font-Bold="true" ID="Label1" runat="server" ForeColor="Red" > * </asp:Label>
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label2" runat="server"> Nombre Archivo </asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="txtNombreArch" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                                EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm"> 
                                            </asp:RequiredFieldValidator>  
                                            <asp:TextBox type="text" runat="server" id="txtNombreArch" cssClass="form-control" placeholder="Nombre Archivo" required="required" MaxLength="150"></asp:TextBox>
                                        </div>   
                                    </div>   
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label Font-Bold="true" ID="Label10" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                            <asp:Label cssClass="labels" Font-Bold="true" id="labPerPago" runat="server"> Tipo Archivo </asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlTipoArchivo" runat="server">
                                                <asp:ListItem Text="Novedades" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cuenta de Cobro" Value="1"></asp:ListItem>
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label Font-Bold="true" ID="Label3" runat="server" ForeColor="Red" > * </asp:Label>                                    
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label4" runat="server"> Tipo Reporte </asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlTipoReporte" runat="server">                                                
                                                <asp:ListItem Text="Ingreso, Retiro, Modificación" Value="0" > </asp:ListItem>
                                                <asp:ListItem Text="Ingreso y retiro" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Solo Vigentes" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label Font-Bold="true" ID="Label7" runat="server" ForeColor="Red" > * </asp:Label>
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label8" runat="server"> Valor </asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlValor" runat="server">                                        
                                                <asp:ListItem Text="Valor Total" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Novedad (diferencia)" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label Font-Bold="true" ID="Label5" runat="server" ForeColor="Red" > * </asp:Label>
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label6" runat="server"> Retiros </asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlRetiro" runat="server">                                        
                                                <asp:ListItem Text="Valor en 0" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Valor Total" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <h4 class="impre">Cuenta bancaria</h4>
                                        <div class="title-divider impre"></div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label11" runat="server">Compañia</asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlCompania" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label9" runat="server">Banco</asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlBanco" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBanco_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label cssClass="labels" Font-Bold="true" id="Label12" runat="server">Cuenta bancaria</asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlCuentaBancaria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCuentaBancaria_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 ">
                                        <div class="form-group">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary"
                                                OnClick="btnGuardar_Click" text="Guardar"
                                                ValidationGroup="addForm" CausesValidation="true" >
                                                <span class="glyphicon glyphicon-floppy-save"></span> Guardar Configuración
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger "
                                                CausesValidation="false" formnovalidate="form1"   
                                                OnClientClick="if (!confirm('Esta seguro de Eliminar la Configuración de Archivos de Novedades ?')) return false;"                                  
                                                OnClick="btnEliminar_Click" >
                                                <span class="glyphicon glyphicon-floppy-remove"></span> Eliminar Configuración
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div id="tab-2" class="tab-pane fade">
                        <h3 class="impre">Productos Convenio
                            <asp:LinkButton ID="btnAddConveniosProductos" runat="server" CssClass="btn btn-info pull-right btn-sm"                                     
                                    text="" OnClick="btnAddConveniosProductos_Click"  >
                                <span class="glyphicon glyphicon-briefcase"></span>
                                Administrar Productos
                            </asp:LinkButton>
                        </h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row impre">
                                    <div class="col-lg-4 col-md-6 col-sm-12">                    
                                        <div class="form-group">                    
                                            <asp:TextBox type="" runat="server" id="txtFiltroCodConv" cssClass="form-control" placeholder="Codigo Convenio"  ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="form-group">                    
                                            <asp:TextBox type="" runat="server" id="txtFiltroNomConv" cssClass="form-control" placeholder="Nombre Convenio"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="form-group">                    
                                            <asp:TextBox type="number" runat="server" id="txtFiltroIdProd" cssClass="form-control" placeholder="Id Producto" step="1" min="1" max="999999" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="form-group">                    
                                            <asp:TextBox type="" runat="server" id="txtFiltroNombreProd" cssClass="form-control" placeholder="Nombre Producto"  ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12"> 
                                        <div class="form-group">                   
                                            <asp:TextBox type="" runat="server" id="txtFiltroNombreComp" cssClass="form-control" placeholder="Nombre Compañia"  ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="input-group">
                                            <asp:LinkButton ID="lnkBtnBuscarConvArchNov" runat="server" 
                                                CssClass="btn btn-primary" 
                                                Text="Buscar" OnClick="lnkBtnBuscarConvArchNov_Click">
                                                <span class="glyphicon glyphicon-search"></span> Buscar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvProductosConveniosArchNov" runat="server" Font-Size="0.9em" 
                                                    DataKeyNames="pro_Id"
                                                    CssClass="table table-bordered table-hover table-striped" 
                                                    AutoGenerateColumns="false" 
                                                    AllowPaging="True" PageSize="5"                                                                                                         
                                                    OnPageIndexChanging="grvProductosConvenioArchNov_PageIndexChanging"    
                                                 >
                                                    <EmptyDataTemplate>
                                                        <div class="alert alert-warning" role="alert">                                                                 
                                                            <span class="glyphicon glyphicon-alert  "></span>No se han encontrado Convenios y Productos !!! 
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
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger controlid="lnkBtnBuscarConvArchNov" eventname="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div><!--row-->
    </div>
    <!--///////////////////////////////////////-->
</asp:Content>

