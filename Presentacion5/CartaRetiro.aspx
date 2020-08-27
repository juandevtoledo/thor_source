<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CartaRetiro.aspx.cs" Inherits="Presentacion5_CartaRetiro" %>     
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="container-form">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h2>Gestión de desistimientos</h2>
            <div class="title-divider"></div>
        </div>
    </div><!--row-->
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <input id="confirm_section" type="hidden" name="name" value="carta_retiro" />
        </div>
    </div><!--row-->
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <ul class="nav nav-tabs impre">
                <li><a data-toggle="tab" href="#tab-1">Consultar Asegurados</a></li><!--active-->
                <li><a data-toggle="tab" href="#tab-2">Digitar Retiros</a></li>
                <li><a data-toggle="tab" href="#tab-3">Listado Retiros</a></li>
                <li><a data-toggle="tab" href="#tab-4">Seguimiento Retiros</a></li>
                <li><a data-toggle="tab" href="#tab-5">Gestionar Retiros</a></li>
                <li><a data-toggle="tab" href="#tab-6">Informe Retiros</a></li>
            </ul>
            <div class="tab-content">
                <div id="tab-1" class="tab-pane fade"><!--in active-->
                    <h3 class="impre">Consultar clientes</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="alert alert-info">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    Ingrese el número de cédula del asegurado a retirar
                            </div>
                        </div> 
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="txtCedula" runat="server" Text="Documento"></asp:Label>
                                <asp:TextBox Type="number" runat="server" ID="txtDocumento" CssClass="form-control" placeholder="Ingresar Documento"></asp:TextBox>
                            </div>        
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">  
                            <asp:Button ID="btnBuscarTercero" CssClass="btn btn-primary btnBuscarTercero btn-only" runat="server" Text="Buscar" OnClick="btnBuscarTercero_Click" />
                        </div>
                    </div><!--row-->
                    <div class="row" id="grvTercero" runat="server">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <h4 class="impre">Información Tercero</h4>
                            <div class="title-divider impre"></div>
                            <asp:GridView ID="grvListTercero" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvListTercero_RowCommand">
                                <Columns >
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-eye-open btnListaSop"  runat="server" id="btnConsultar"  CommandName="Consultar_Click"   data-toggle="tooltip" title="Consultar"></asp:linkButton>
                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil btnListaSop"  runat="server" id="btnEditarTercero"  CommandName="EditarTercero_Click"   data-toggle="tooltip" title="Editar"></asp:linkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns> 
                            </asp:GridView>
                        </div>
                    </div><!--row-->
                    <div class="row">
                        <div class="col-md-12" id="grvCertificados" runat="server">
                            <h4 class="impre">Certificados por asegurado</h4>
                            <div class="title-divider impre"></div>
                            <asp:GridView ID="grvDigitarRetiro" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvDigitarRetiro_RowCommand">
                                <Columns >
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-plus btnListaret"  runat="server" id="btnConsultar"  CommandName="Digitar_Click"   data-toggle="tooltip" title="Digitar Retiro"></asp:linkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns> 
                            </asp:GridView> 
                        </div>
                    </div><!--row--> 
                </div><!--#tab-1-->
                <div id="tab-2" class="tab-pane fade">
                    <h3 class="impre">Información del Asegurado</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">    
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblId" cssClass="labels" Font-Bold="true" Text="Id"></asp:Label>
                                <asp:TextBox ID="txtIdCertificado" Enabled="false" EnableViewStateMac="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>       
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCedula1" cssClass="labels" Font-Bold="true" Text="Cédula"></asp:Label>
                                <asp:TextBox ID="txtCedulaCertificado" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>      
                        </div>      
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCertificado" cssClass="labels" Font-Bold="true" Text="Certificado"></asp:Label>
                                <asp:TextBox ID="txtCertificado" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblLocalidad" cssClass="labels" Font-Bold="true" Text="Departamento"></asp:Label>
                                <asp:TextBox ID="txtDepartamento" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>  
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblValorAseguradoPrincipal" cssClass="labels" Font-Bold="true" Text="Valor Asegurado Principal"></asp:Label>
                                <asp:TextBox ID="txtValorPpal" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblValorAseguradoConyuge" cssClass="labels" Font-Bold="true" Text="Valor Asegurado Conyuge"></asp:Label>
                                <asp:TextBox ID="txtValorConyuge" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblPrima" cssClass="labels" Font-Bold="true" Text="Valor Prima"></asp:Label>
                                <asp:TextBox ID="txtPrima" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblPagaduria" cssClass="labels" Font-Bold="true" Text="Pagaduría"></asp:Label>
                                <asp:TextBox ID="txtPagaduria" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtPagaId" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblProductoCertificado" cssClass="labels" Font-Bold="true" Text="Producto"></asp:Label>
                                <asp:TextBox ID="txtProducto" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="reqtxtFechaDesde" cssClass="labels" Font-Bold="true" Text="Fecha Radicación Torres Guarín"></asp:Label>
                                <asp:TextBox ID="txtFechaTg"   type="date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblFechaRadicacion" cssClass="labels" Font-Bold="true" Text="Fecha Radicación Casa Matríz"></asp:Label>
                                <asp:TextBox ID="txtFechaCasaMatriz"   type="date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblFechaRad" cssClass="labels" Font-Bold="true" Text="Fecha Radicación Compañía"></asp:Label>
                                <asp:TextBox ID="txtFechaCompania"   type="date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCompania" cssClass="labels" Font-Bold="true" Text="Compañía"></asp:Label>
                                <asp:DropDownList ID="ddlCompania"   CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblOrigen" cssClass="labels" Font-Bold="true" Text="Origen Oficio"></asp:Label>
                                <asp:DropDownList ID="ddlOrigen" CssClass="ddl" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="form-group">
                                <asp:Label  ID="lblObservacion" cssClass="labels" runat="server" Font-Bold="true" Text="Observaciones"></asp:Label>
                                <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtProId" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtUsuario" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtIdCartaRetiro" Visible="false" runat="server"></asp:TextBox>
                            </div> 
                        </div> 
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnGuardar" CssClass="btn btn-primary botonGuardarRetiro" runat="server" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar" UseSubmitBehavior="false"/>
                                <asp:Button ID="btnActualizar" CssClass="btn btn-primary botonGuardarRetiro" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar" UseSubmitBehavior="false"/>                                                                                                
                                <asp:Button ID="btnCancelar" CssClass="btn btn-primary botoncancelarRetiro" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>  
                          </div>
                        </div>
                    </div><!--row-->
                </div><!--#tab-2-->
                <div id="tab-3" class="tab-pane fade">
                    <h3 class="impre">Cartas de retiro por gestionar</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblDocumentoCarta" runat="server" Text="Documento"></asp:Label>
                                <asp:TextBox Type="number" runat="server" ID="txtCedulaRetiro" CssClass="form-control" placeholder="Ingresar Documento"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                                <div class="form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblCertificadoCarta" runat="server" Text="Certificado"></asp:Label>
                                    <asp:TextBox Type="number" runat="server" ID="txtCertificadoRetiro" CssClass="form-control" placeholder="Ingresar certificado"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblFechaDig" runat="server" Text="Fecha digitación"></asp:Label>
                                <asp:TextBox Type="date" runat="server" ID="txtFechaRetiro" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-12 col-sm-12">
                            <div class="form-group">
                                <asp:Button ID="btnBuscarRetiro" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="botonBuscarRetiro_Click" />
                                <asp:Button ID="btnLimpiar" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" OnClick="botonLimpiarRetiro_Click"/>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                             <asp:GridView ID="grvGestionRetiro"  CssClass="table table-bordered table-hover table-striped table-res" runat="server" OnRowCommand="grvGestionarRetiro_RowCommand" OnRowDataBound="grvGestionRetiro_RowDataBound" AllowPaging="True" PageSize="50"  OnPageIndexChanging="grvGestionRetiro_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderStyle CssClass="btnContainer"/>
                                        <ItemTemplate >
                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-earphone btnGestionar"  runat="server" id="btnConsultar"  CommandName="Gestionar_Click"   data-toggle="tooltip" title="Gestionar Retiro"></asp:linkButton>
                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-hand-up btnRecuperar"  runat="server" id="btnRecuperar"  CommandName="Recuperar_Click"   data-toggle="tooltip" title="Recuperar Retiro"></asp:linkButton>
                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-warning btn-xs glyphicon glyphicon-comment btnVer"  runat="server" id="btnVer"  CommandName="Ver_Click"   data-toggle="tooltip" title="Crear Observación"></asp:linkButton>
                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-info btn-xs glyphicon glyphicon-pencil btnEditar" runat="server"  id="btnEditar" CommandName="Editar_Click"   data-toggle="tooltip" title="Editar Retiro" OnClientClick="return confirm('Está seguro que desea editar este retiro?')"></asp:linkButton>
                                            <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-danger btn-xs glyphicon glyphicon-trash btnEliminar" runat="server" id="btnEliminar"  CommandName="Eliminar_Click"   data-toggle="tooltip" title="Eliminar Retiro" OnClientClick="return confirm('Está seguro que desea eliminar este retiro?')" ></asp:linkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns> 
                                 <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div><!--row-->
                </div><!--#tab-3-->
                <div id="tab-4" class="tab-pane fade">
                    <h3 class="impre">Seguimiento Retiros</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12" >
                            <div class="form-group">
                                <h5 class="impre nomargen"><asp:Label ID="lblNombreAsegurado" runat="server" cssClass="labels" Text=""></asp:Label></h5>
                                <h5 class="impre nomargen"><asp:Label ID="lblCedula" runat="server" cssClass="labels" Text=""></asp:Label></h5>
                                <h5 class="impre nomargen"><asp:Label ID="lblPoliza" runat="server" cssClass="labels" Text=""></asp:Label></h5>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-12 col-sm-12">
                            <asp:GridView ID="grvObservaciones"  CssClass="table table-bordered table-hover table-striped table-res" runat="server">
                            </asp:GridView>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label ID="lblSeguimiento" cssClass="labels" Visible="true" Font-Bold="true"  runat="server" Text="Observación"></asp:Label>
                                <asp:TextBox ID="txtSeguimiento" runat="server" TextMode="MultiLine" Columns="250" Rows="5" Visible="true"  CssClass="form-control" placeholder="Seguimiento realizado"></asp:TextBox>
                                <asp:Button ID="btnGuardarObs" CssClass="btn btn-primary btn-only" runat="server" OnClick="GuardarObs_Click" Text="Guardar" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar" UseSubmitBehavior="false"/>                                             
                                <asp:button ID="btnRegresar" CssClass="btn btn-danger btn-only" runat="server"  OnClick="Regresar_Click" text="Regresar"></asp:button>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtIdCartaObs" Enabled="false" Visible="true" CssClass="form-control btn-only" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtCedulaObs" Enabled="false" Visible="true" CssClass="form-control btn-only" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtMenuObs" Enabled="false" Visible="true" CssClass="form-control btn-only" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtUsuarioObs" Enabled="false" Visible="true" CssClass="form-control btn-only" runat="server"></asp:TextBox>
                            </div> 
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            
                        </div>
                    </div><!--row-->
                </div><!--#tab-4--> 
                <div id="tab-5" class="tab-pane fade">
                    <h3 class="impre">Gestión de retiros</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">    
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCedulaGestion" cssClass="labels" Font-Bold="true" Text="Cédula"></asp:Label>
                                <asp:TextBox ID="txtCedulaGes" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>      
                        </div>      
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCertificadoGestion" cssClass="labels" Font-Bold="true" Text="Certificado"></asp:Label>
                                <asp:TextBox ID="txtCertificadoGes" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblProductoGestion" cssClass="labels" Font-Bold="true" Text="Producto"></asp:Label>
                                <asp:TextBox ID="txtProGes" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblPrimaGestion" cssClass="labels" Font-Bold="true" Text="Valor Prima"></asp:Label>
                                <asp:TextBox ID="txtPrimaGes" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblValorP" cssClass="labels" Font-Bold="true" Text="Valor Asegurado Principal"></asp:Label>
                                <asp:TextBox ID="txtPrincipal" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblValorC" cssClass="labels" Font-Bold="true" Text="Valor Asegurado Conyuge"></asp:Label>
                                <asp:TextBox ID="txtConyuge" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblTipoGes" cssClass="labels" Font-Bold="true" Text="Tipo de Gestión"></asp:Label>
                                <asp:DropDownList ID="ddlTipoGestion" Enabled="true" CssClass="ddl" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblAsesorGestion" cssClass="labels" Font-Bold="true" Text="Nombre Asesor"></asp:Label>
                                <asp:DropDownList ID="ddlAsesor" Enabled="true" CssClass="ddl" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtDepAsesor" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblFechaGes" cssClass="labels" Font-Bold="true" Text="Fecha Contacto"></asp:Label>
                                <asp:TextBox ID="txtFechaGestion"  type="date"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblHora" cssClass="labels" Font-Bold="true" Text="Hora de contacto"></asp:Label>
                                <asp:TextBox ID="txtHora"   type="time" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblFechaCarta" cssClass="labels" Font-Bold="true" Text="Fecha Carta Retiro"></asp:Label>
                                <asp:TextBox ID="txtFechaCarta"  type="date" Enabled="false"   CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblFechaVig" cssClass="labels" Font-Bold="true" Text="Fecha Vigencia"></asp:Label>
                                <asp:TextBox ID="txtFechaVigencia"  Enabled="false"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCausal" cssClass="labels" Font-Bold="true" Text="Causal retiro"></asp:Label>
                                <asp:DropDownList ID="ddlCausalRetiro" Enabled="true" CssClass="ddl" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblObservaciones" cssClass="labels" Font-Bold="true" Text="Observaciones"></asp:Label>
                                <asp:TextBox ID="txtObservacionGes" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="input-group btn-only">
                                 <asp:CheckBox ID="chkLlamada" runat="server" text=" Llamada Efectiva"/>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblIdCarta" cssClass="labels" Font-Bold="true" Text=""></asp:Label>
                                <asp:TextBox ID="txtIdCarta" Visible="false" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>      
                        </div> 
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <asp:Button ID="btnGuardarGestion" CssClass="btn btn-primary botonGuardarGestion" runat="server" Text="Guardar" OnClick="btnGuardarGestion_Click" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar" UseSubmitBehavior="false"/>                                             
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <asp:Button ID="btnRecuperar" CssClass="btn btn-primary botonGuardarGestion" runat="server" Text="Recuperar" OnClick="btnGuardarRecuperacion_Click" OnClientClick="clickOnce(this, 'Procesando...')" ValidationGroup="Procesar" UseSubmitBehavior="false"/>
                        </div>                                                   
                    </div><!--row-->
                </div><!--#tab-5-->
                <div id="tab-6" class="tab-pane fade">
                    <h3 class="impre">Informes de retiros</h3>
                    <div class="title-divider impre"></div>
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblTipoInforme" runat="server" Text="Tipo Informe"></asp:Label>
                                <asp:DropDownList ID="ddlTipoInforme" CssClass="form-control" style="text-align:center" runat="server" OnSelectedIndexChanged ="ddlTipoInforme_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
                                <asp:TextBox Type="number" runat="server" ID="txtDocumento2" CssClass="form-control" placeholder="Ingresar Documento"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblLocalidad1" runat="server" Text="Localidad"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblCompañía" runat="server" Text="Compañía"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlCompañia" CssClass="form-control"  OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblTipoGestion" runat="server" Text="Tipo Gestión"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlGestion" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblOrigenOficio" runat="server" Text="Origen oficio"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlOrigenOficio" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblFechaDesde" runat="server" Text="Fecha desde"></asp:Label>
                                <asp:TextBox Type="date" runat="server" ID="txtFechaDesde" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaDesde"  ValidationGroup="grpValidacionFechas" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12">
                            <div class="form-group">
                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblFechaHasta" runat="server" Text="Fecha hasta"></asp:Label>
                                <asp:TextBox Type="date" runat="server" ID="txtFechaHasta" CssClass="form-control" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqtxt" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtFechaHasta"  ValidationGroup="grpValidacionFechas" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-6 col-sm-12">
                            <div class="form-group text-center">
                                <asp:Button ID="btnBuscarInforme" CssClass="btn btn-primary botonBuscarRetiro" runat="server" Text="Buscar" OnClick="btnBuscarInforme_Click" ValidationGroup="grpValidacionFechas" />
                                <asp:Button ID="btnLimpiarInforme" CssClass="btn btn-success botonLimpiarInforme" runat="server" Text="Limpiar" OnClick="btnLimpiarInforme_Click" />
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <asp:GridView ID="grvInformeRetiros"  CssClass="table table-bordered table-hover table-striped table-res" runat="server"  OnRowDataBound="grvInformeRetiros_RowDataBound" AllowPaging="True" PageSize="50"  OnPageIndexChanging="grvInformeRetiros_PageIndexChanging">
                                <PagerStyle CssClass="pagination-ys"/>
                            </asp:GridView>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="form-group text-center">
                                <asp:Button ID="btnDescargar" CssClass="btn btn-danger btn-only text-center" runat="server"  Text="Descargar" OnClick="btnDescargarExcel_Click"/>
                            </div>
                        </div>
                    </div><!--row-->
                </div><!--#tab-6-->    
           </div>
        </div>
    </div>
</div>
   <script type="text/javascript">
       function clickOnce(btn, msg) {
           btn.value = msg;
           btn.disabled = true;
           return true;
       }
</script>


</asp:Content> 


 