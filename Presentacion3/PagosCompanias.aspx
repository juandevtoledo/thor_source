<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PagosCompanias.aspx.cs" Inherits="Presentacion3_PagosCompanias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Content/EstilosIndex.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = "~/Presentacion6/greybox/";
        //Center grybox window with callback on close
        function OpenCenterWindowCallBack() {
            var caption = "Detalles Solicitud de Cheques";
            var url = "~/Presentacion6/DetallesSolicitudCheques.aspx";
            return GB_showCenter(caption, url, 550, 1100, callback_fn)
        }        
        function callback_fn() {
            //alert('callback function');
            //parent.document.location = parent.document.location;            
            parent.document.location.href = "~/Presentacion6/PagosCompañias.aspx";
        }

        function OpenCenterWindowCallBack2() {
            var caption = "Soporte Devolucion";
            var url = "~/Presentacion3/AdjuntarSoportesDevolucion.aspx";
            return GB_showCenter(caption, url, 550, 1100, callback_fn)
        }
        

    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
         <h3>Pagos a las Compañías</h3>
         <br />

        <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Realizar Solicitud de Cheques, Facturación y Pagos</a></li>
            <li><a href="#tabs-2">Ingresar Número de Talón</a></li>
            <li><a href="#tabs-3">Distribuir Soportes Por Pagadurías</a></li>
       </ul>
        
       <div id="tabs-1">
            <div class="row">
                <div class="col-md-12 ">  
                    <fieldset>
                        <legend>Solicitud de Cheques, Facturación y Pagos</legend>                    
                            <div class="col-md-5">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="row">                     
                                                <div class="col-md-12">
                                                    <label>Fecha Fin</label>
                                                    <asp:TextBox AutoPostBack="true" runat="server" type="date" ID="txtFechaFinPago" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqFechaFinPago" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaFinPago"  ValidationGroup="grpValidacionPreCargue" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-12">
                                                    <label>Compañía</label>
                                                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" ID="ddlCompania" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="col-md-12" id="proceso" runat="server" visible="false">
                                                    <label>Proceso</label>
                                                    <asp:DropDownList ID="ddlProceso" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="SolicitudCheque" Value="1" Enabled="true"></asp:ListItem>
                                                        <asp:ListItem Text="Facturación" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Pago" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-12" id="producto" runat="server" visible="true">
                                                    <label>Producto</label>
                                                    <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="col-md-12" id="localidad" runat="server" visible="false">
                                                    <label>Localidad</label>
                                                    <asp:DropDownList ID="ddlLocalidad" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>                                                
                                            </div>
                                            <div>
                    
                                            </div>
                                        </ContentTemplate>
                                     </asp:UpdatePanel>
                                <br /><br />
                                    <div class="col-md-12" runat="server">
                                        <asp:Button ID="btnRealizarPagoCompania" OnClick="btnRealizarPagoCompania_Click" cssclass="btn btn-primary" runat="server" Text="Generar"/>                                                                                    
                                    </div>
                                <br />
                                <br />
                                <asp:GridView ID="grvFacturacion" visible="False" OnRowCommand="grvFacturacion_RowCommand" runat="server" CssClass="table table-bordered table-hover table-striped">
                                    <Columns>
                                        <asp:ButtonField Text="Ver Detalle" />
                                    </Columns>
                                </asp:GridView>

                                <asp:Panel ID="panSoportes" runat="server">                                    
                                </asp:Panel>

                                <asp:Button ID="btnExportarFacturacion" OnClick="btnExportarFacturacion_Click" runat="server" Text="Exportar" />

                            </div>                                                
                    </fieldset>             
                </div>
            </div>                
                </div>






        <div id="tabs-2">
            <div class="row">
                <div class="col-md-12">  
                            <fieldset>
                                <legend>Ingresar el número de talón</legend> 
                                <asp:GridView ID="grvTalones" OnRowEditing="grvTalones_RowEditing" OnRowUpdating="grvTalones_RowUpdating" OnRowCancelingEdit="grvTalones_RowCancelingEdit" runat="server" CssClass="table table-bordered table-hover table-striped">
                                    <Columns>
                                            <asp:CommandField EditText="Editar" ShowEditButton="true" />                                                                                                        
                                    </Columns>
                                </asp:GridView>
                                <br /><br />
                                    <div class="col-md-12" runat="server">
                                        <asp:Button ID="btnGuardarTalones" OnClick="btnGuardarTalones_Click" cssclass="btn btn-primary" runat="server" Text="Guardar Talones"/>                                                                                    
                                    </div>
                            </fieldset>
                </div>
            </div>
        </div>

        <div id="tabs-3">
            <div class="row">
                <div class="col-md-12"> 
                            <fieldset>
                                <legend>Ingresar tronador y facturación</legend> 
                                <asp:GridView ID="grvtronador" OnRowEditing="grvtronador_RowEditing" OnRowUpdating="grvtronador_RowUpdating" OnRowCancelingEdit="grvtronador_RowCancelingEdit" runat="server" CssClass="table table-bordered table-hover table-striped">
                                    <Columns>
                                            <asp:CommandField EditText="Editar" ShowEditButton="true" />                                                                                                        
                                    </Columns>
                                </asp:GridView>
                                <br /><br />
                                    <div class="col-md-12" runat="server">
                                        <asp:Button ID="btnGuardarTronador" OnClick="btnGuardarTronador_Click" cssclass="btn btn-primary" runat="server" Text="Guardar Talones"/>                                                                                    
                                    </div>
                            </fieldset>    
                    
                    
                       
                </div>
            </div>
         </div>

            
                
      </div>



         
</asp:Content>

