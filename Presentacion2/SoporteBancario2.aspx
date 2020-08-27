<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SoporteBancario2.aspx.cs" Inherits="Presentacion2_SoporteBancario2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>  
    <style>
        .limit {
            width: 1200px;
        }
    </style>
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="soporte_bancario" />
            </div>
        </div><!--row-->
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>
                    Soporte Bancario
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Cargar archivo de soportes</a></li>
                    <li><a data-toggle="tab" href="#tab-2">Listado de soportes</a></li>
                    <li><a data-toggle="tab" href="#tab-3">Ingresar soporte manual</a></li>
                    <li><a data-toggle="tab" href="#tab-4">Distribuir soportes</a></li>
                    <li><a data-toggle="tab" href="#tab-5">Informe general</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade">
                        <h3 class="impre">Cargar archivo</h3>
                        <div class="title-divider impre"></div>
                        <div class="row">
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
                                <asp:Label runat="server" ID="lblCargar" cssClass="labels" Font-Bold="true" Text="Cargar Soporte:"></asp:Label>
                                <asp:FileUpload ID="fupSoportes" runat="server"  CssClass="form-control"  /> 
                                <asp:Label ID="lbl1" runat="server" cssClass="labels" Text=""></asp:Label>
                            </div>
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
                                <asp:Label runat="server" ID="lblNomSoporte" cssClass="labels" Font-Bold="true" Text="Nombre Soporte:"></asp:Label>
                                <asp:TextBox ID="txtNomSoporte" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col col-lg-2 col-md-12 col-sm-2 form-group">
                                <asp:Button ID="btnCargarDatos" CssClass="btn btn-primary btn-only" runat="server" Text="Cargar"  OnClick="btnCargarDatos_Click" />      
                            </div>
                        </div>
                    </div><!--#tab-1-->
                    <div id="tab-2" class="tab-pane fade">
                        <div id="acciones" runat="server">
                            <div class="row" id="titleAcciones" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h3>Administrar soportes</h3>
                                    <div class="title-divider"></div>
                                </div>
                            </div>
                            <div class="row" id="buscador" runat ="server">
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarBanco" runat="server">Banco</asp:Label>
                                    <asp:TextBox type="" runat="server" id="txtBuscarBanco" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="LblBuscarCuenta" runat="server" >Cuenta</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarCuenta" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarFecha" runat="server" >Fecha movimiento</asp:Label>
                                    <asp:TextBox ID="txtBuscarFecha" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarRecibido" runat="server" >Recibido por</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarRecibido" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarEstado" runat="server" >Estado</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarEstado" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <div class="form-group">
                                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                        <asp:Button ID="btnLimpiarBuscador" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                                    </div>
                                </div>
                            </div>
                            <div runat="server" id="tablaEncabezado">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvListSop" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvListSop_RowCommand" OnRowDataBound="grvListSop_RowDataBound" AllowPaging="True" PageSize="15" OnPageIndexChanging="grvListSop_PageIndexChanging">
                                            <Columns >
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-primary btn-xs glyphicon glyphicon-search" runat="server" id="btnConsultar"  CommandName="Consultar_Click"   data-toggle="tooltip" title="Consultar"></asp:LinkButton>
                                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil"  id="btnModificarEnc" runat="server"  CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:linkButton> 
                                                        <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" OnClientClick="return confirm('Esta seguro que desea eliminar este soporte?')"  runat="server" id="btnEliminar"  CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar" AutoPostBack="true"></asp:LinkButton> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns> 
                                            <PagerStyle CssClass="pagination-ys" />
                                        </asp:GridView> 
                                    </div>  
                                </div>
                            </div>
                        </div>
                        <div id="formEditarEncabezado" Visible="true" runat="server">
                            <div class="row" id="Div1" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h3>Modificar encabezado</h3>
                                    <div class="title-divider"></div>
                                </div>
                            </div>
                            <div class="row"> 
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:Label ID="lblTituloBancoEdit" runat="server" cssClass="labels" Text=""></asp:Label><br />
                                    <asp:Label ID="lblTituloCuentaEdit" runat="server" cssClass="labels" Text=""></asp:Label><br />
                                    <asp:Label ID="lblTituloTipoCuentaEdit" runat="server" cssClass="labels" Text=""></asp:Label><br /><br />
                                </div>
                            </div>
                            <div class="row">  
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblCompaniaEdit" cssClass="labels" Text="Compañía"></asp:Label>
                                    <asp:DropDownList ID="ddlCompaniaEdit" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCompaniaEdit_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblBancoEdit" cssClass="labels" Text="Banco"></asp:Label>
                                    <asp:DropDownList ID="ddlBancoEdit" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBanco_SelectedIndexChanged"></asp:DropDownList>
                                </div> 
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblTipoCuentaEdit" cssClass="labels" Text="Tipo cuenta"></asp:Label>
                                    <asp:DropDownList ID="ddlTipoCuentaEdit" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCuenta_SelectedIndexChanged"></asp:DropDownList>
                                </div> 
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblCuentaEdit" cssClass="labels" Text="N° Cuenta"></asp:Label>
                                    <asp:DropDownList ID="ddlCuentaEdit" CssClass="form-control" runat="server" ></asp:DropDownList>
                                </div> 
                                <asp:TextBox  runat="server" type="number" ID="txtEncSop_Id" Visible="false" CssClass="form-control"></asp:TextBox>
                                <div class="col col-lg-12 col-md-12 col-sm-12">
                                    <asp:Button ID="btnModificarEnc" CssClass="btn btn-primary " runat="server" Text="Modificar" OnClick="btnModificarEnc_Click"/>
                                    <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-danger btnListaRegresar" Text="Regresar" OnClick="btnAtras_Click" /> 
                                </div>
                                 
                            </div>
                        </div>
                        <div id="formEditarSoporte" runat="server">
                            <div class="row" id="Div3" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h3>Modificar soporte</h3>
                                    <div class="title-divider"></div>
                                </div>
                            </div>
                            <div class="row"> 
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblTipoDocEdit" cssClass="labels"  Text="Tipo de documento"></asp:Label>
                                    <asp:DropDownList ID="ddlTipoDocEdit" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>   
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label runat="server" ID="lblIdentificacionEdit" cssClass="labels"  Text="Identificación"></asp:Label>
                                    <asp:TextBox  runat="server" type="number" ID="txtIdentificacionEdit" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label runat="server" ID="lblReferenciaEdit" cssClass="labels" Text="No. Referencia"></asp:Label>
                                    <asp:TextBox ID="txtReferenciaEdit" Type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>  
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label runat="server" ID="lblTalonEdit" cssClass="labels" Text="N° Talón"></asp:Label>
                                    <asp:TextBox ID="txtTalonEdit" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label runat="server" ID="lblvalorEdit" cssClass="labels" Text="Valor"></asp:Label>
                                    <asp:TextBox ID="txtValorEdit" Type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtValorNumEdit" Visible="true" Type="text" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                </div>
                                <asp:TextBox  runat="server" type="number" ID="txtSop_Id" Visible="false" CssClass="form-control"></asp:TextBox>   
                                <div class="col col-lg-12 col-md-12 col-sm-12">
                                    <asp:Button ID="btnModificarSop" CssClass="btn btn-primary " runat="server" Text="Modificar" OnClick="btnModificarSop_Click"/>
                                    <asp:Button runat="server" ID="btnRegresarSop" CssClass="btn btn-danger btnListaRegresar" Text="Regresar" OnClick="btnAtras_Click" />
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="tablaSoporte">
                            <div class="row" id="titleConsultar" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h3>Consultar soportes</h3>
                                    <div class="title-divider"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:Label ID="lblTituloBanco" runat="server" cssClass="labels" Text=""></asp:Label><br />
                                    <asp:Label ID="lblTituloCuenta" runat="server" cssClass="labels" Text=""></asp:Label><br />
                                    <asp:Label ID="lblTituloTipoCuenta" runat="server" cssClass="labels" Text=""></asp:Label><br />
                                    <asp:Label ID="lblFechaCongnacion" runat="server" cssClass="labels" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row btn-only" id="buscadorDetalle" runat ="server">
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarFormaPago" runat="server">Forma de pago</asp:Label>
                                    <asp:TextBox type="" runat="server" id="txtBuscarFormaPago" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarIdentificacion" runat="server" >Identificación</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarIdentificacion" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarReferencia" runat="server" >Referencia</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarReferencia" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <asp:Label cssClass="labels" Font-Bold="true" id="lblBuscarEstDetalle" runat="server" >Estado</asp:Label>
                                    <asp:TextBox type="text" runat="server" id="txtBuscarEstDetalle" cssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                    <div class="form-group">
                                        <asp:Button ID="btnBuscarDetalle" CssClass="btn btn-primary btn-only" runat="server" Text="Buscar" OnClick="btnBuscarDetalle_Click" />
                                        <asp:Button ID="btnLimpiarCampos" CssClass="btn btn-success btn-only" runat="server" Text="Limpiar"  OnClick="btnLimpiarCampos_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvConsutarSop" CssClass="table table-bordered table-hover table-striped" runat="server"  OnRowCommand="grvConsutarSop_RowCommand">
                                        <Columns >
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-success btn-xs glyphicon glyphicon-pencil"  id="btnModificar" runat="server"  CommandName="Modificar_Click" data-toggle="tooltip" title="Modificar"></asp:linkButton> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns> 
                                        <PagerStyle CssClass="pagination-ys" />
                                    </asp:GridView>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12" runat="server" id="divBtns">
                                    <asp:Label ID="lblValorToral" runat="server" cssClass="labels" Text=""></asp:Label><br /><br />
                                    <asp:Button runat="server" ID="btnAprobar" CssClass="btn btn-primary" Text="Aprobar" OnClick="btnAprobar_Click"/>
                                    <asp:Button runat="server" ID="btnRechazar" CssClass="btn btn-primary" Text="Rechazar" OnClick="btnRechazar_Click"/>
                                    <asp:Button runat="server" ID="btnAplicarPagos" CssClass="btn btn-primary" Text="Aplicar Pagos" OnClick="btnAplicarPagos_Click"/>
                                    <asp:Button runat="server" ID="btnAtras" CssClass="btn btn-danger btnListaRegresar" Text="Regresar" OnClick="btnAtras_Click" /> 
                                </div>   
                            </div> 
                            <div class="row" id="formMotivo" runat="server">
                                <div class="col col-lg-12 col-md-12 col-sm-12">
                                    <asp:Label ID="lblMotivo" runat="server" cssClass="labels" Text="Motivo rechazo"></asp:Label><br /><br />
                                    <asp:TextBox id="textAreaMotivo" TextMode="multiline" Columns="50" Rows="3" runat="server" />
                                    <asp:TextBox id="txtCedula" Visible="false" runat="server" />
                                </div>
                                <div class="col col-lg-12 col-md-12 col-sm-12">
                                    <asp:Button runat="server" ID="btnGuardarMotivo" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardarMotivo_Click"/>
                                </div>
                            </div>            
                        </div>
                    </div><!--#tab-2-->
                    <div id="tab-3" class="tab-pane fade">
                        <div class="row" id="titleModificar" runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <h3 class="impre">Ingresar soporte manual</h3>
                                <div class="title-divider impre"></div>
                            </div>
                        </div>
                        <div class="row">  
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblTipoDoc" cssClass="labels"  Text="Tipo de documento"></asp:Label>
                                <asp:DropDownList ID="ddlTipoDoc" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDoc_SelectedIndexChanged"></asp:DropDownList>
                            </div>    
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblIdentificacion" cssClass="labels"  Text="Identificación"></asp:Label>
                                <asp:TextBox  runat="server" type="number" ID="txtIdentificacion" CssClass="form-control"></asp:TextBox>
                            </div> 
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblLocalidadUno" cssClass="labels" Text="Localidad"></asp:Label>
                                <asp:DropDownList ID="ddlLocalidadUno" CssClass="ddl2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPagaduriaUnoAUno_SelectedIndexChanged"></asp:DropDownList>
                            </div>     
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblPagaduriaUno" cssClass="labels" Text="Pagaduría"></asp:Label>
                                <asp:DropDownList ID="ddlPagaduriaUno" CssClass="ddl2" runat="server"></asp:DropDownList>
                            </div>      
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblFormaDePago" cssClass="labels" Text="Forma de pago"></asp:Label>
                                <asp:DropDownList ID="ddlFormaDePago" CssClass="ddl2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFormaDePago_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblSucursal" cssClass="labels" Text="Sucursal"></asp:Label>
                                <asp:TextBox  runat="server" ID="txtSucursal" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblNoCheque" cssClass="labels" Text="Referencia"></asp:Label>
                                <asp:TextBox ID="txtNoCheque" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblTransferido" cssClass="labels" Text="Recibido por"></asp:Label>
                                <asp:DropDownList ID="ddlRecibido" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRecibido_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblCompania" cssClass="labels" Text="Compañía"></asp:Label>
                                <asp:DropDownList ID="ddlCompania" CssClass="ddl2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblBanco" cssClass="labels" Text="Banco"></asp:Label>
                                <asp:DropDownList ID="ddlBanco" CssClass="ddl2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBanco_SelectedIndexChanged"></asp:DropDownList>
                            </div> 
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblNoCuenta" cssClass="labels" Text="N° Cuenta"></asp:Label>
                                <asp:DropDownList ID="ddlNoCuenta" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblFecha" type="date" cssClass="labels" Text="Fecha"></asp:Label>
                                <asp:TextBox  runat="server" type="date" ID="txtFecha" CssClass="form-control"></asp:TextBox>
                            </div>     
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblNoTalón" cssClass="labels" Text="N° Talón"></asp:Label>
                                <asp:TextBox ID="txtNoTalon" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col col-lg-3 col-md-3 col-sm-3 form-group">
                                <asp:Label runat="server" ID="lblValor" cssClass="labels" Text="Valor"></asp:Label>
                                <asp:TextBox ID="txtValor" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>   
                            <div class="col col-lg-12 col-md-12 col-sm-12">
                                <asp:Button ID="btnGuardar" CssClass="btn btn-primary " runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                            </div>
                        </div>
                    </div><!--#tab-3-->
                    <div id="tab-4" class="tab-pane fade">
                        <div class="row" id="titleDistribuir" runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <h3 class="impre">Distribuir soportes</h3>
                                <div class="title-divider impre"></div>
                            </div>
                        </div>
                        <div class="row limit">
                            <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                                <asp:Label runat="server" ID="lblLocalidad" cssClass="labels" Font-Bold="true" Text="Localidad"></asp:Label>
                                <asp:DropDownList ID="ddlLocalidad" AutoPostBack="true" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-6 col-md-6 col-sm-6 form-group">
                                <asp:Label runat="server" ID="lblPagaduria" cssClass="labels" Font-Bold="true" Text="Pagaduria"></asp:Label>
                                <asp:DropDownList ID="ddlPagaduria" AutoPostBack="true"  CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged"></asp:DropDownList>
                            </div>      
                        </div>
                        <div runat="server" id="tblDistri">              
                            <div class="row"  >
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvSopPaga" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvSopPaga_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-success btn-xs glyphicon glyphicon-transfer"  runat="server" data-toggle="tooltip" title="Distribuir" id="btnDistribuir" CommandName="btnDistribuir_Click"></asp:linkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns> 
                                    </asp:GridView>
                                </div>    
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvlistaDetalle" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="row" runat="server" id="distribucion">
                            <div class="col col-lg-6 col-md-6 col-sm-6">
                                <h4><asp:Label ID="lblNumeroSop" runat="server"></asp:Label></h4>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblConvenios" cssClass="labels" Font-Bold="true" Text="Convenios"></asp:Label>
                                            <asp:DropDownList ID="ddlConvenios"  CssClass="ddl" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblValorDistri" cssClass="labels" Font-Bold="true" Text="Valor $"></asp:Label>
                                            <asp:TextBox ID="txtValorDistri" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtSop" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                    <asp:Button ID="btnGuardarDetalle" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarDetalle_Click" />
                                </div>
                            </div>
                            <div class="col col-lg-6 col-md-6 col-sm-6">
                                <h4><asp:Label ID="Label3" runat="server"></asp:Label>Detalle de distribución</h4>
                                <asp:GridView ID="grvDetallesSop" CssClass="table table-bordered table-hover table-striped" runat="server"  OnRowCommand="grvDetallesSop_RowCommand">
                                    <Columns  >
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  CssClass="btn btn-danger btn-xs glyphicon glyphicon-remove" OnClientClick="return confirm('Esta seguro que desea eliminar este soporte?')"  runat="server" id="btnEliminar"  CommandName="Eliminar_Click" data-toggle="tooltip" title="Eliminar"></asp:LinkButton>       
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns> 
                                </asp:GridView>
                            </div>
                        </div>          
                    </div><!--#tab-4-->
                    <div id="tab-5" class="tab-pane fade">
                        <div class="row" id="titleInforme" runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <h3 class="impre">Informe general</h3>
                                <div class="title-divider impre"></div>
                            </div>
                        </div>  
                        <div class="row">
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblTipoDocumentoInforme" cssClass="labels" Font-Bold="true" Text="Tipo documento"></asp:Label>
                                <asp:DropDownList ID="ddlTipoDocumentoInforme" AutoPostBack="true"  CssClass="ddl" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblBancoInfome" cssClass="labels" Font-Bold="true" Text="Banco"></asp:Label>
                                <asp:DropDownList ID="ddlBancoInforme" AutoPostBack="true"  CssClass="ddl" runat="server"></asp:DropDownList>
                            </div> 
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblRecibidoInforme" cssClass="labels" Font-Bold="true" Text="Recibido Por"></asp:Label>
                                <asp:DropDownList ID="ddlRecibidoInforme" CssClass="ddl" runat="server"></asp:DropDownList>
                            </div> 
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblEstado" cssClass="labels" Font-Bold="true" Text="Estado"></asp:Label>
                                <asp:DropDownList ID="ddlEstado"  CssClass="ddl" runat="server"></asp:DropDownList>
                            </div> 
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblFechaMovDesde" cssClass="labels" Font-Bold="true" Text="Fecha movimiento desde"></asp:Label>
                                <asp:TextBox ID="txtFechaMovDesde" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div> 
                            <div class="col col-lg-4 col-md-4 col-sm-4 form-group">
                                <asp:Label runat="server" ID="lblFechaMovHasta" cssClass="labels" Font-Bold="true" Text="Fecha movimiento hasta"></asp:Label>
                                <asp:TextBox ID="txtFechaMovHasta" Type="date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div> 
                            <div class="col col-lg-12 col-md-12 col-sm-12 form-group">
                                <asp:Button ID="btnDescargar" CssClass="btn btn-primary" runat="server" Text="Descargar" OnClick="btnDescargar_Click" />
                                <asp:Button ID="btnLimpiarInforme" CssClass="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnLimpiarInforme_Click" />
                            </div>
                        </div>     
                    </div><!--#tab-5-->
                </div>
            </div>
        </div><!--row-->
    </div><!--container-form-->
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

        function endReq(sender, args) {
            $(".ddl").select2({
                placeholder: "Seleccione",
                allowClear: true
            });
            $(".ddl2").select2({
                placeholder: "Seleccione",
                allowClear: true
            });
            $(".ddl3").select2({
                placeholder: "Seleccione",
                allowClear: true
            });
            $('[data-toggle="tooltip"]').tooltip();
            $("#tabs").tabs();
        }
    </script>
</asp:Content>