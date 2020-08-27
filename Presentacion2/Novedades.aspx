<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Novedades.aspx.cs" Inherits="Presentacion2_FrmNovedades" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="novedades" />
            </div>
        </div><!--row-->
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>
                    Novedades
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row impre">
            <asp:UpdatePanel ID="udpSeleccionables" runat="server">
                <ContentTemplate>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                        <asp:Label ID="lblLocalidad" Font-Bold="true"   CssClass="labels"  runat="server" Text="Localidad"></asp:Label>
                        <asp:DropDownList ID="ddlLocalidad" CssClass="ddl" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                         <asp:Label ID="lblPagaduria" Font-Bold="true"  CssClass="labels" runat="server" Text="Pagaduria"></asp:Label>
                         <asp:DropDownList ID="ddlPagaduria"  CssClass="ddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPagaduria_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-12 col-sm-12">
                        <asp:Label ID="lblArchivo" Font-Bold="true"  CssClass="labels" runat="server" Text="Archivo"></asp:Label>
                        <asp:DropDownList ID="ddlArchivo" CssClass="ddl" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="ddlArchivo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                        <asp:Label ID="lblMes" Font-Bold="true"  CssClass="labels" runat="server" Text="Mes"></asp:Label>
                        <asp:DropDownList ID="ddlMes" CssClass="ddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                        <asp:Label ID="Label2" Font-Bold="true"  CssClass="labels" runat="server" Text="Año" ></asp:Label>
                        <asp:DropDownList ID="ddlAnio" CssClass="ddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="divider"></div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Mes</a></li>
                    <li><a data-toggle="tab" href="#tab-2">Pendientes por aplicar</a></li>
                    <li><a data-toggle="tab" href="#tab-3">Sin aplicar</a></li>
                    <li><a data-toggle="tab" href="#tab-4">Aplicadas</a></li>
                    <li><a data-toggle="tab" href="#tab-5">Histórico</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade">
                        <h3 class="impre">Mes</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="udpMes" runat="server">
                            <ContentTemplate>
                            <div class="row impre" id="listaNovedadesMes" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvMes" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:CheckBox ID="chkEnviarNovedad" runat="server" Text=" Enviar novedades definitivas" OnCheckedChanged="chkEnviarNovedad_CheckedChanged" AutoPostBack="true" /> 
                                    <div class="divider-mini"></div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:Button ID="btnEnviarNovedades" CssClass="btn btn-success" OnClientClick="return confirm('Esta seguro de enviar novedades posiblemente como definitivas?')" runat="server" Text="Enviar novedades" OnClick="btnEnviarNovedad_Click" />
                                    <asp:Button ID="btnExportarMes" CssClass="btn btn-primary"  runat="server" Text="Exportar a excel" OnClick="btnExportarMes_Click" />
                                </div>         
                            </div>
                            <div class="row impre" id="noNovedadesMes" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="alert alert-warning" role="alert">
                                        No hay novedades en esta pagaduria
                                    </div>
                                </div>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarMes"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-1-->
                    <div id="tab-2" class="tab-pane fade">
                        <h3 class="impre">Pendientes por aplicar</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="udpPendientePorAplicar" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="pendientesPorAplicar">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                         <asp:GridView ID="grvPendientePorAplicar" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvPendientePorAplicar_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  data-placement="right"  CommandName="SinAplicar_Click"  CssClass="btn btn-default btn-sm botonDevolucion btn-back" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="row" runat="server" id="formPendientesPorAplicar">
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <asp:Label ID="lblIdNovedad" runat="server" Text="Id Novedad" CssClass="labels"></asp:Label>
                                                    <asp:TextBox ID="txtIdNovedad" CssClass="form-control"  runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqTxtIdNovedad" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtIdNovedad"  ValidationGroup="grpValidacionNovedad" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <asp:Label ID="lblObservaciones" runat="server" Text="Causal" CssClass="labels"></asp:Label>
                                                    <asp:DropDownList ID="ddlSinAplicar" CssClass="form-control"  runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqddlSinAplicar" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="ddlSinAplicar"  ValidationGroup="grpValidacionNovedad" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <asp:Button ID="btnEnviarSinAplicar" CssClass="btn btn-success" runat="server" Text="Enviar novedad sin aplicar" OnClientClick="return confirm('Esta seguro de enviar este registro a novedad sin aplicar?')" ValidationGroup="grpValidacionNovedad" OnClick="btnEnviarSinAplicar_Click" />
                                        <asp:Button ID="btnExportarPendientes" CssClass="btn btn-primary" runat="server" Text="Exportar a excel" OnClick="btnExportarPendientes_Click" />    
                                    </div>
                                </div>
                                <div class="row impre" id="noPendientesPorAplicar" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="alert alert-warning" role="alert">
                                            No hay pendientes por aplicar
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarPendientes"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-2-->
                    <div id="tab-3" class="tab-pane fade">
                        <h3 class="impre">Novedades sin aplicar</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="udpSinAplicar" runat="server">
                            <ContentTemplate>
                            <div class="row" id="novadadesSinAplicar" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvSinAplicar" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:Button ID="btnExportarSinAplicar" CssClass="btn btn-primary " runat="server" Text="Exportar a excel" OnClick="btnExportarSinAplicar_Click" />
                                </div>
                            </div>
                            <div class="row impre" id="noNovadadesSinAplicar" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="alert alert-warning" role="alert">
                                        No hay novedades sin aplicar
                                    </div>
                                </div>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarSinAplicar"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-3-->
                    <div id="tab-4" class="tab-pane fade ">
                        <h3 class="impre">Aplicadas</h3>
                        <div class="title-divider impre"></div>
                         <asp:UpdatePanel ID="udpAplicadas" runat="server">
                            <ContentTemplate>
                                <div class="row" id="novadadesAplicadas" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvAplicadas" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:Button ID="btnExportarAplicadas" CssClass="btn btn-primary" runat="server" Text="Exportar a excel" OnClick="btnExportarAplicadas_Click" />
                                    </div>
                                </div>
                                <div class="row impre" id="noNovadadesAplicadas" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="alert alert-warning" role="alert">
                                            No hay novedades aplicadas
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarAplicadas"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-4-->
                    <div id="tab-5" class="tab-pane fade">
                        <h3 class="impre">Historico</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="udpHistorico" runat="server">
                            <ContentTemplate>
                            <div class="row impre" id="Div1" runat="server">
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <asp:Label ID="Label3" Font-Bold="true"  CssClass="labels" runat="server" Text="Estado" ></asp:Label>
                                    <asp:DropDownList ID="ddlEstadoHistorico" CssClass="ddl" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlEstadoHistorico_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row impre" id="novadadesHistorico" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <asp:GridView ID="grvHistorico" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnExportarHistorico" CssClass="btn btn-primary" runat="server" Text="Exportar a excel" OnClick="btnExportarHistorico_Click" />
                                </div>
                            </div>
                            <div class="row impre" id="noNovadadesHistorico" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="alert alert-warning" role="alert">
                                        No hay historico
                                    </div>
                                </div>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarHistorico"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-5-->
                </div>
            </div>
        </div><!--row-->
    </div><!--container-form-->
    <asp:UpdatePanel ID="udpProgres" runat="server">
        <ContentTemplate>
             <asp:UpdateProgress ID="uppProgress" runat="server"  OnLoad="Page_Load">
                            <ProgressTemplate>
                               <div class="contenedor-loader">
                                    <div class='loader'>
                                        <h6><p style="text-align:center"><b>Realizando tu consulta, por favor espera...<br /></b></p></h6>
                                    </div>
                               </div>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
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

