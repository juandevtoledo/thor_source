<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Conciliacion.aspx.cs" Inherits="Presentacion2_FrmConciliacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
      <script src="/Scripts/jquery-1.11.2.min.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="spmAjax" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager>
    <style>
        .limit
        {
            width: 1000px;
        }
        .titulo{
            width: 367px;
        }
    </style>
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Conciliación de Pagadurías</h2>
                <div class="title-divider"></div>
            </div>
        </div>

        <div class="row">
            <div class="modal fade" id="miventana" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" id="modal2">
                        <div class="modal-header">
                            <h4>Certificados</h4>
                            <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="cerrarModal2" runat="server" CssClass="close" Text="&times;" data-dismiss="modal" aria-hidden="true"/>
                                </ContentTemplate>
                            </asp:UpdatePanel>                                              
                        </div>
                        <div class="modal-body"> 
                            <div class="col-md-10">
                                <div class="row">
                                    <fieldset>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-10">
                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvCertifacados" CssClass="table table-bordered table-hover table-striped" runat="server">                                                  
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>                                                
                                    </fieldset>
                                </div>
                            </div>                                                                                                                             
                        </div>
                        <div class="modal-footer">
                            <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnCerarExtraPrima1" CssClass="btn btn-success" data-dismiss="modal" runat="server" Text="Cerrar" />        
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>                    
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-3">
                <asp:UpdatePanel ID="udpAgencia" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAgencia" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Agencia"></asp:Label>
                        <asp:DropDownList ID="ddlAgencia" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlAgencia_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <asp:UpdatePanel ID="udpLocalidad" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLocalidad" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Localidad"></asp:Label>
                        <asp:DropDownList ID="ddlLocalidad" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <asp:UpdatePanel ID="udpPagaduria" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPagaduria" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Pagaduria"></asp:Label>
                        <asp:DropDownList ID="ddlPagaduria" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
                <asp:UpdatePanel ID="udpConvenio" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblConvenio" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Convenio"></asp:Label>
                        <asp:DropDownList ID="ddlConvenio" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlConvenio_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="conciliacion" />
            </div>
        </div><!--row-->
        <div class="row btn-only">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Soportes Bancarios</a></li><!--active-->
                    <li><a data-toggle="tab" href="#tab-2">Recibos de Caja</a></li>
                    <li><a data-toggle="tab" href="#tab-3">Pagos por Oficina</a></li>
                    <li><a data-toggle="tab" href="#tab-4">Informes de Aplicación</a></li>
                </ul>    
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade"><!--in active-->    
                        <h3>Soporte Bancario</h3>
                        <div class="row btn-only">
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <asp:FileUpload CssClass="form-control" ID="fupCargarClientes" runat="server"/>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <asp:Button ID="btnCargarDatos"  CssClass="btn btn-success" runat="server" Text="Cargar"  OnClick="btnCargarDatos_Click" />
                                <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="grvExcel" runat="server"></asp:GridView>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpTotalListado" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblTotalListado" runat="server" Font-Bold="true"  CssClass="labels" Text="Valor en Listado"></asp:Label>
                                        <asp:TextBox ID="txtTotalListado" cssClass="form-control" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpSoportes" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSoportes" runat="server" Font-Bold="true"  CssClass="labels" Text="Valor en Soportes"></asp:Label>
                                        <asp:TextBox ID="txtSoportes" cssClass="form-control" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpParticipacion" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblParticipo" runat="server" Font-Bold="true"  CssClass="labels" Text="% Participación"></asp:Label>
                                        <asp:TextBox ID="txtParticipo" cssClass="form-control" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-8 col-md-8 col-sm-8 btn-only">
                                <asp:UpdatePanel ID="udpSoportesPagaudria" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvSoportesPagaduria" CssClass="table table-bordered table-hover table-striped " runat="server" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSeleccionar" AutoPostBack="true" runat="server" CommandName="Digitar_Click" OnCheckedChanged="chkSeleccionar_OnCheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        
                        <div class="row">
                            <h3 runat="server" id ="legend">Cédulas No Coincidentes</h3>
                            <div class="col-lg-8 col-md-8 col-sm-8 btn-only">
                                <asp:UpdatePanel ID="udpCedulasNoCoincidentes" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvCedulasNoCoincidentes" CssClass="table table-bordered table-hover table-striped" runat="server" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true"
                                            OnRowDeleting="rowDeletingEvent"
                                            OnRowCancelingEdit="rowCancelEditEvent"
                                            OnRowEditing="rowEditingEvent"
                                            OnRowUpdating="rowUpdatetingEvent"
                                            DataKeysNames="codigoCategoria" OnRowCommand="grvCedulasNoCoincidentes_RowCommand" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <ItemTemplate>
                                                        <center>
                                                        <div class="glyphicon">
                                                            <asp:linkButton runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="modal" CommandName="ConsultarCertificado_Click"  CssClass= "btn btn-success btn-xs glyphicon-search btn-Listasop"  data-target="#miventana"/> 
                                                        </div>
                                                        </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 btn-only"></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:UpdatePanel ID="udpConfirmarCedulasNoConcidentes" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ChkConciliarCedulasNoConcidentes" runat="server" Text="Enviar Cedulas No Coincidentes" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                           <div class="col-lg-6 col-md-6 col-sm-6 btn-only">
                                <asp:UpdatePanel ID="udpConciliar" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnConciliar" cssClass="btn btn-danger" runat="server" Text="Conciliar" OnClick="btnConciliar_Click"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="uppConciliar" runat="server" AssociatedUpdatePanelID="udpConciliar" OnLoad="Page_Load" >
                                    <ProgressTemplate>
                                        <div class="contenedor-loader">
                                            <div class='loader'>
                                            <h6><p style="text-align:center"><b>Aplicando pagos, por favor espere...<br /></b></p></h6>
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 btn-only"></div>
                        </div>
                    </div>
                    
                    <div id="tab-2" class="tab-pane fade"><!--in active-->    
                        <h3>Recibo de caja</h3>
                        <div class="row btn-only">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpRecibo" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblNumeroRecibo" Font-Bold="true"  CssClass="labels" runat="server" Text="Recibo"></asp:Label>
                                        <asp:TextBox ID="txtRecibo" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpCedula" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCedula" Font-Bold="true"  CssClass="labels" runat="server" Text="Cedula/Nit"></asp:Label>
                                        <asp:TextBox ID="txtCedula" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpBuscar" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpCompania" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCompañia" Font-Bold="true"  CssClass="labels" runat="server" Text="Compañia"></asp:Label>
                                        <asp:DropDownList ID="ddlCompañia" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpProducto" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblProducto" Font-Bold="true"  CssClass="labels" runat="server" Text="Producto"></asp:Label>
                                        <asp:DropDownList ID="ddlProducto" CssClass="ddl" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged1"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpReciboSeleccionable" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRecibo" Font-Bold="true"  CssClass="labels" runat="server" Text="Recibo"></asp:Label>
                                        <asp:DropDownList ID="ddlRecibo" CssClass="ddl" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlRecibo_SelectedIndexChanged1"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:Panel ID="panRecibos" runat="server" ScrollBars="Horizontal" >
                                    <asp:UpdatePanel ID="udpConsultarRecibos" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvConsultarRecibos" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" OnPageIndexChanging="grvConsultarRecibos_PageIndexChanging" PageSize="35">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="chkSeleccionarRecibos"   AutoPostBack="true" runat="server" CommandName="Digitar_Click" OnCheckedChanged="chkSeleccionarRecibos_OnCheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="pagination-ys" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:UpdatePanel ID="udpImprimirRecibo" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnImprimirRecibo" runat="server" Text="Imprimir" class="btn btn-primary" OnClick="btnImprimirRecibo_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div id="tab-3" class="tab-pane fade">
                        <h3>Pagos por Oficina</h3>
                        <div class="row btn-only">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpDocumentoPago" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblDocumentoPago" Font-Bold="true"  CssClass="labels" runat="server" Text="Documento"></asp:Label>
                                        <asp:TextBox ID="txtConsultarPagoOficina" CssClass="form-control" runat="server"></asp:TextBox> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:UpdatePanel ID="udpSeeleccionConvenio" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblConvenioPago" runat="server"  Font-Bold="true"  CssClass="labels" Text="Convenio"></asp:Label>
                                        <asp:DropDownList ID="ddlConvenioPago" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <asp:UpdatePanel ID="udpSaldo" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSaldo" runat="server"  Font-Bold="true"  CssClass="labels" Text="Saldo"></asp:Label>
                                        <asp:TextBox ID="txtSaldoConciliar" CssClass="form-control" runat="server"></asp:TextBox> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <asp:UpdatePanel ID="updValorAplicar" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblValorAplicar" runat="server"  Font-Bold="true"  CssClass="labels" Text="Valor Aplicar"></asp:Label>
                                        <asp:TextBox ID="txtValorAplicar" AutoPostBack="true" CssClass="form-control" runat="server" OnTextChanged="txtValorAplicar_TextChanged"></asp:TextBox> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                             <div class="col-lg-12 col-md-12 col-sm-12 btn-only">
                                <asp:UpdatePanel ID="udpBuscarPagoOficina" runat="server" >
                                    <ContentTemplate>
                                        <asp:Button ID="btnBuscarPagoOficina" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscarPagoOficina_Click"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:UpdatePanel ID="udpSoporteOficina" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvSoporteBancarioPagoOficina" Caption="Soporte bancario" CssClass="table table-bordered table-hover table-striped " runat="server" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSeleccionar" AutoPostBack="true" runat="server"  OnCheckedChanged="chkSeleccionarPagosOficina_OnCheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <asp:UpdatePanel ID="udpProductosVigentes" runat="server">
                                <ContentTemplate>
                                    <div class="col-lg-12 col-md-12 col-sm-12" id="titCerti" runat="server">
                                        <strong>Certificados</strong>
                                        <asp:GridView ID="grvTablaPagosOficina"  CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                    </div>
                                    <div class="row"  id="contPagos" runat="server">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="col-lg-6 col-md-6 col-sm-6">
                                                <asp:UpdatePanel ID="udpCompaniaOficina" runat="server">
                                                    <ContentTemplate>
                                                            <asp:Label ID="lblCompaniaOficina" runat="server"  Font-Bold="true"  Text="Compañia"></asp:Label>
                                                            <asp:DropDownList ID="ddlCompaniaOficina" AutoPostBack="true" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlCompaniaOficina_SelectedIndexChanged"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:UpdatePanel ID="udpProductoOficina" runat="server">
                                                    <ContentTemplate>
                                                            <asp:Label ID="lblProductoOficina" runat="server"  Font-Bold="true"  Text="Producto"></asp:Label>
                                                            <asp:DropDownList ID="ddlProductoOficina" AutoPostBack="true" CssClass="ddl" runat="server" placeHolder="Producto" OnSelectedIndexChanged="ddlProductoOficina_SelectedIndexChanged" ></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12" >
                                            <asp:UpdatePanel ID="udpHistorialPagosPorOficina" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="panPagosPorOficina" runat="server" ScrollBars="Horizontal"> 
                                                        <div class="col-lg-12 col-md-12 col-sm-12" id="titHistorial" runat="server">
                                                            <strong>Historial pagos</strong>                                                       
                                                            <asp:GridView ID="grvTablaHistorialPagosPorOficina" Caption="" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="grvTablaHistorialPagosPorOficina_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarDevolucion" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CommandName="devolverAplicaciones_Click" AutoPostBack="true"  runat="server"  OnCheckedChanged="chkSeleccionarDevolucion_OnCheckedChanged" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="pagination-ys" />
                                                            </asp:GridView>
                                                        </div>
                                                        </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 btn-only">
                                        <asp:UpdatePanel ID="udpMarca" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rbtlMarca" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtlMarca_SelectedIndexChanged">
                                                    <asp:ListItem Value="1" Text="Devolución parcial"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Devolución completa"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row btn-only">
                                        <div class="col-lg-12 col-md-12 col-sm-12 btn-only">
                                        <asp:UpdatePanel ID="udpDevolucion" runat="server">
                                            <ContentTemplate>
                                                <div class="col-lg-4 col-md-4 col-sm-4">
                                                    <asp:Label ID="lblValorDevolución" runat="server"  Font-Bold="true"  CssClass="labels" Text="Valor Devolución"></asp:Label>
                                                    <asp:TextBox ID="txtValorDevolucion" CssClass="form-control" runat="server"></asp:TextBox> 
                                                </div>
                                                <div class="col-lg-4 col-md-4 col-sm-4">
                                                    <asp:Label ID="lblObservacionesDevolcion" runat="server"  Font-Bold="true"  CssClass="labels" Text="Observaciones Devolución"></asp:Label>
                                                    <asp:TextBox ID="txtObservacionesDevolcion"  CssClass="form-control" runat="server"></asp:TextBox> 
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="udpTipoTramite" runat="server">
                                            <ContentTemplate>
                                                <div class="col-lg-4 col-md-4 col-sm-4">
                                                    <asp:Label ID="lblEstadoDevolucion" runat="server"  Font-Bold="true"  CssClass="labels" Text="Estado Devolución"></asp:Label>
                                                    <asp:DropDownList ID="ddlEstadoDevolucion" AutoPostBack="true" CssClass="ddl" runat="server">
                                                        <asp:ListItem Value="1" Text="Tramitar por Torres Guarín"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Tramitado por la compañía"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>   
                                        <asp:UpdatePanel ID="udpGuardarDevolucion" runat="server">
                                            <ContentTemplate>
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <asp:Button ID="btnGuardarAplicacionesDevolucion" CssClass="btn btn-primary" runat="server" Text="Guardar devolución" OnClick="btnGuardarAplicacionesDevolucion_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel> 
                                    </div>      
                                        </div>                      
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:UpdatePanel ID="udpAplicarPagosPorOficina" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnConciliarPagoOficina" CssClass="btn btn-danger " runat="server" Text="Conciliar" OnClick="btnConciliarPagoOficina_Click"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:UpdateProgress ID="uppAplicarPagosPorOficina" runat="server" AssociatedUpdatePanelID="udpAplicarPagosPorOficina" OnLoad="Page_Load" >
                                    <ProgressTemplate>
                                        <div class="contenedor-loader">
                                            <div class='loader'>
                                                <h6><p style="text-align:center"><b>Aplicando pagos, por favor espera...<br /></b></p></h6>
                                            </div>    
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                
                    <div id="tab-4" class="tab-pane fade"><!--in active-->   
                        <h3 class="impre">Informes de aplicación</h3>
                        <div class="row btn-only">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <asp:UpdatePanel ID="udpAnioDescuento" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblanioDescuento" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Fecha desde"></asp:Label>
                                        <asp:TextBox Type="Date" ID="txtAnioDescuento" CssClass="form-control" placeholder="DD/MM/AAAA" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <asp:UpdatePanel ID="udpMesDescuento" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMesDescuento" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Fecha hasta"></asp:Label>
                                        <asp:TextBox Type="Date" ID="txtMesDescuento" AutoPostBack="true" CssClass="form-control" placeholder="DD/MM/AAAA" runat="server" OnTextChanged="txtMesDescuento_TextChanged"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <asp:UpdatePanel ID="udpCompaniaPago" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCompania" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Compañía"></asp:Label>
                                        <asp:DropDownList ID="ddlCompaniaPago" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCompaniaPago_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <asp:UpdatePanel ID="udpProductoPago" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblProductoPago" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Producto"></asp:Label>
                                        <asp:DropDownList ID="ddlProductoPago" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlProductoPago_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:Panel ID="panInforme" runat="server" ScrollBars="Horizontal" >
                                    <asp:UpdatePanel ID="udpInformePago" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvInformePagos" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="30" OnPageIndexChanging="grvInformePagos_PageIndexChanging">
                                                <PagerStyle CssClass="pagination-ys" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="row btn-only">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <asp:Button ID="btnExportarInformePagos" CssClass="btn btn-success " runat="server" Text="Descargar" OnClick="btnExportarInformePagos_Click" />
                            </div>
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
                                <h6><p style="text-align:center"><b>Realizando la consulta, por favor espere...<br /></b></p></h6>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

     <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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
        function clickOnce(btn, msg) {
            btn.value = msg;
            btn.disabled = true;
            return true;
        }
    </script>
           
</asp:Content>



