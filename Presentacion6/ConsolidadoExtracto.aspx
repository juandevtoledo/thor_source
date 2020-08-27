<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsolidadoExtracto.aspx.cs" Inherits="Presentacion6_ConsolidadoExtracto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <legend>Consolidado Extractos Seguros Bolivar</legend>
    <div class="row">
                            <div class="col col-lg-3 col-md-5 col-sm-5 form-group">
                                <asp:Label ID="lblProducto" runat="server" CssClass="labels" Font-Bold="true" Text="PRODUCTO"></asp:Label>
                                        <asp:DropDownList ID="ddlProducto" runat="server"></asp:DropDownList>
                            </div>
                            </div>
                                <div class="row">
                            <div class="col col-lg-5 col-md-5 col-sm-25 form-group">
                                <asp:Label ID="lblGr" runat="server" CssClass="labels" Font-Bold="true" Text="GR"></asp:Label>
                                        <asp:DropDownList ID="ddlGr" runat="server"  AutoPostBack="true"></asp:DropDownList>
                            </div>
                            </div>
                                <div class="row">
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
                                <asp:Label ID="lblLocalidad" runat="server" CssClass="labels" Font-Bold="true" Text="LOCALIDAD"></asp:Label>
                                        <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                            </div>
</div>
                                <div class="row">
                            <div class="col col-lg-2 col-md-2 col-sm-2 form-group">
                                <asp:Label ID="lblFechaEnvio" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Envio"></asp:Label>
                                        <asp:TextBox ID="txtFechaEnvio" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                             
                                    </div>
                                <div class="row">
                                
    <div class="col col-lg-2 col-md-12 col-sm-2 form-group">
                                <asp:Button ID="btnConsultarConsolidado" CssClass="btn btn-primary btn-only" runat="server" Text="Consultar" OnClick="btnConsultarConsolidado_Click"    />      
                            </div>
                                    </div>
                        
    <asp:GridView ID="grvExtractoSegurosBolivar" runat="server" CssClass="table table-bordered table-hover table-striped" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
</asp:Content>

