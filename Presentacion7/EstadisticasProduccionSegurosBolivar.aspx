﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EstadisticasProduccionSegurosBolivar.aspx.cs" Inherits="Presentacion_Reportes_EstadisticasProduccionSegurosBolivar" %>
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
            <h3>Estadísticas de Producción Seguros Bolivar</h3>
            <div class="title-divider"></div>
        </div>
    </div>

    <!-- RePORTE -->
    <div class="col-md-8" runat="server" id="formReporte">
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaInicioProduccion" runat="server">Fecha Inicio Producción</asp:Label>
            <asp:TextBox type="text" placeholder="Fecha Inicio Producción" runat="server" ID="txtFechaInicioProduccion" CssClass="form-control" MaxLength="10"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labFechaFinProduccion" runat="server">Fecha Fin Producción</asp:Label>
            <asp:TextBox type="text" placeholder="Fecha Fin Producción" runat="server" ID="txtFechaFinProduccion" CssClass="form-control" MaxLength="10"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="labCompaniaIdentificador" runat="server">Compañía</asp:Label>
            <asp:ListBox ID="lbxCompania" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
        <div class="col-md-3 form-group">
            <asp:Label CssClass="labels" Font-Bold="true" ID="lblConsolidar" runat="server">Consolidar por</asp:Label>
            <asp:ListBox ID="lbxConsolidar" runat="server" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="false"></asp:ListBox>
        </div>
    </div>
    <div class="col-md-1">
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
            $("input[id$='txtFechaInicioProduccion']").datepicker({
                onSelect: function (dateText) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, month, 1));
                    $(this).blur();
                }
            });
            $("input[id$='txtFechaFinProduccion']").datepicker({
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