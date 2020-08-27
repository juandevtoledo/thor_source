<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecaudoEsperado.aspx.cs" Inherits="Presentacion2_RecaudoEsperado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>Recaudo Esperado</center>
    <br />
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
             <asp:GridView ID="grvRecaudoEsperado" CssClass="table table-bordered table-hover table-striped" runat="server" PageSize="50" AllowPaging="True" OnPageIndexChanging="grvRecaudoEsperado_PageIndexChanging" >
             </asp:GridView>
        </div>
        <div class="col-md-1"></div>
    </div>
</asp:Content>

