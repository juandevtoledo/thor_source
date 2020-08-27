<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteGeneralPagos.aspx.cs" Inherits="Presentacion_Reportes_ReporteGeneralPagos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../scripts/jquery-1.10.2.min.js"></script>
    <script src="../../scripts/bootstrap.min.js"></script>
	<script src="../../scripts/jquery.ui.core.js"></script>
	<script src="../../scripts/jquery.ui.widget.js"></script>
	<script src="../../scripts/jquery.ui.datepicker.js"></script>
	<script src="../../scripts/jquery.ui.datepicker-es.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/jquery.ui.all.css" rel="stylesheet" />
    <link href="../../Content/jquery.ui.datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
             <h3>Reporte General de Pagos</h3>
            <div class="title-divider"></div>
        </div>
    </div>
    
    <!-- RePORTE -->
    <div class="col-md-8" runat="server" id="formReporte">
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCompaniaIdentificador" runat="server">Compañía</asp:Label>
            <asp:ListBox ID="lbxCompania" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lbxCompania_SelectedIndexChanged"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labProductoIdentificador" runat="server">Producto</asp:Label>
            <asp:ListBox ID="lbxProducto" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="lbxProducto_SelectedIndexChanged"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labPagaduriasIdentificador" runat="server">Pagaduría</asp:Label>
            <asp:ListBox ID="lbxPagadurias" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labEstadoNegocioIdentificador" runat="server">Estado Negocio</asp:Label>
            <asp:ListBox ID="lbxEstadoNegocio" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labLocalidadIdentificador" runat="server">Localidad</asp:Label>
            <asp:ListBox ID="lbxLocalidad" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labConvenioIdentificador" runat="server">Convenio</asp:Label>
            <asp:ListBox ID="lbxConvenio" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labDepartamentoIdentificador" runat="server">Departamento</asp:Label>
            <asp:ListBox ID="lbxDepartamento" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="lbxDepartamento_SelectedIndexChanged"></asp:ListBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCiudadIdentificador" runat="server">Ciudad</asp:Label>
            <asp:ListBox ID="lbxCiudad" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaInicioVigencia" runat="server">Inicio Año y Mes Vigencia</asp:Label>
            <asp:TextBox type="text" placeholder="Inicio Año y Mes Vigencia" runat="server" ID="txtFechaInicioVigencia" CssClass="form-control" MaxLength="10"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaFinVigencia" runat="server">Fin Año y Mes Vigencia</asp:Label>
            <asp:TextBox type="text" placeholder="Fin Año y Mes Vigencia" runat="server" ID="txtFechaFinVigencia" CssClass="form-control" MaxLength="10"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-1">
        <br />
        <br />
        <br />
        <asp:Button type="submit" ID="btnGenerarReporte" CssClass="btn btn-primary" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click"></asp:Button>

    </div>
    <div class="col-md-10">
        <rsweb:ReportViewer ID="rvReporte" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        </rsweb:ReportViewer>
    </div>
    <!--formulario-->

    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFechaInicioVigencia']").datepicker({
                onSelect: function (dateText) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, month, 1));
                    $(this).blur();
                }
            });
            $("input[id$='txtFechaFinVigencia']").datepicker({
                onSelect: function (dateText) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, month, 1));
                    $(this).blur();
                }
            });
        });
</script>
</asp:Content>