﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteClientesProductos.aspx.cs" Inherits="Presentacion_Reportes_ReporteClientesProductos" %>
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
             <h3>Reporte Clientes Productos</h3>
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
            <asp:ListBox ID="lbxProducto" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCedulas" runat="server">Cédulas</asp:Label>
            <asp:TextBox type="text" placeholder="Cédulas separadas por coma o por enter" runat="server" ID="txtCedulas" CssClass="form-control" TextMode="MultiLine" Height="82px"></asp:TextBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaInicio" runat="server">Fecha Inicio</asp:Label>
            <asp:TextBox type="text" placeholder="Fecha Inicio" runat="server" ID="txtFechaInicio" CssClass="form-control" MaxLength="10"></asp:TextBox>
        </div>
        <div class="col-md-4 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaFin" runat="server">Fecha Fin</asp:Label>
            <asp:TextBox type="text" placeholder="Fecha Fin" runat="server" ID="txtFechaFin" CssClass="form-control" MaxLength="10"></asp:TextBox>
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
        $("input[id$='txtFechaInicio']").datepicker();
        $("input[id$='txtFechaFin']").datepicker();
});
</script>
</asp:Content>