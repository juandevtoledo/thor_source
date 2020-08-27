<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CuentasCobro.aspx.cs" Inherits="Presentacion2_FrmCuentasCobro" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="container-form">
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <input id="confirm_section" type="hidden" name="name" value="novedades" />
            </div>
        </div><!--row-->
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>
                    Cuentas de cobro
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row impre">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="divider"></div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <ul class="nav nav-tabs impre">
                    <li><a data-toggle="tab" href="#tab-1">Por generar</a></li>
                    <li><a data-toggle="tab" href="#tab-2">Generadas</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane fade">
                        <h3 class="impre">Cuenta de cobro para generar</h3>
                        <div class="title-divider impre"></div>
                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                            <ContentTemplate>
                                <div class="row impre" id="nocuentacobrodatos" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="alert alert-warning" role="alert">
                                            No se ha seleccionado ninguna pagaduría
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="datosCuentaCobro" runat="server">
                                    <div class="col-md-12">
                                        <asp:GridView ID="grvMesCuentaDeCobroDatos" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                        <div class="divider-mini"></div>
                                    </div>
                                </div>
                                <div class="row impre">
                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                        <asp:Button ID="btnGuardarCuentasCobro" CssClass="btn btn-success" OnClientClick="return confirm('¿Esta seguro que desea guardar la cuenta de cobro?')" runat="server" Text="Guardar" OnClick="btnGuardarCuentasCobro_Click" />
                                        <input type="button" runat="server" class="btn btn-primary" id="btnImprimirCuentaDeCobro" onclick="window.print();" value="Imprimir tabla" />
                                        <asp:Button ID="btnExportarExcelAnt" CssClass="btn btn-primary"  runat="server" Text="Exportar a excel" OnClick="btnExportarExcelAnt_Click"/>
                                    </div>     
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarExcelAnt"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div><!--#tab-1-->

                    <div id="tab-2" class="tab-pane fade">
                        <h3 class="impre"> Consultar por mes y año</h3>
                        <div class="title-divider impre"></div>
                        <div class="row impre">
                            <div class="col-lg-3 col-md-4 col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMes" Font-Bold="true"  CssClass="labels" runat="server" Text="Mes"></asp:Label>
                                        <asp:DropDownList ID="ddlMes" CssClass="ddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-3 col-md-4 col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblAnio" Font-Bold="true"  CssClass="labels" runat="server" Text="Año" ></asp:Label>
                                        <asp:DropDownList ID="ddlAnio" CssClass="ddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-6 col-md-4 col-sm-12" id="searchCuentasCobro" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                <asp:Label ID="Label1" Font-Bold="true"  CssClass="labels" runat="server" Text="Numero cuenta cobro"></asp:Label>
                                                <asp:TextBox ID="txtConsultarCuentaCobro" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-12">
                                                <asp:Button ID="btnConsultarCuentaCobro" Text="Consultar" runat="server" CssClass="btn btn-primary btn-only" OnClick="btnConsultarCuentaCobro_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                            <ContentTemplate>
                                <div class="row impre" id="nocuentascobro" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="alert alert-warning" role="alert">
                                            No hay cuentas de cobro generadas.
                                        </div>
                                    </div>
                                </div>
                                <div class="row impre" id="listaCuentasCobro" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <h4>
                                            Cuentas generadas
                                        </h4>
                                        <div class="title-divider"></div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvListaCuentaCobro" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" OnPageIndexChanging="grvListaCuentaCobro_PageIndexChanging" PageSize="35" OnRowCommand="grvListaCuentaCobro_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Acciones">
                                                    <HeaderStyle CssClass="btnContainer" />
                                                    <ItemTemplate>
                                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-xs btn-primary glyphicon glyphicon-search"  runat="server" ID="btnConsultarCuentaCobro"  CommandName="ConsultarCuentaCobro_Click"></asp:linkButton>
                                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-xs btn-success glyphicon glyphicon-print"  runat="server" ID="btnImprimirCuentaCobro"  CommandName="ImprimirCuentaCobro_Click"></asp:linkButton>
                                                        <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-xs btn-danger glyphicon glyphicon-trash"  runat="server" ID="btnEliminarCuentaCobro" OnClientClick="return confirm('¿Esta seguro que desea eliminar esta cuenta de cobro?')" CommandName="EliminarCuentaCobro_Click"></asp:linkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="pagination-ys" />
                                        </asp:GridView>
                                    </div>
                                </div> 
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                            <ContentTemplate>
                                <div class="row impre" id="listaCuentasCobroDatos" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <h4>
                                            Datos cuenta de cobro: <asp:Label Text="" runat="server" ID="lblCuentaCobroId" />
                                        </h4>
                                        <div class="title-divider"></div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvCuentaCobro" CssClass="table table-bordered table-hover table-striped" runat="server">
                                        </asp:GridView>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <asp:GridView ID="grvListaCuentaCobroDatos" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" OnPageIndexChanging="grvListaCuentaCobroDatos_PageIndexChanging" PageSize="35">
                                            <PagerStyle CssClass="pagination-ys" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <asp:Button ID="btnExportarExcel" CssClass="btn btn-primary"  runat="server" Text="Exportar a excel" OnClick="btnExportarExcel_Click"/>
                                        </div>
                                    </div>  
                                </div> 
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportarExcel"/>
                            </Triggers>
                        </asp:UpdatePanel>
                        
                    </div><!--#tab-2-->
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

