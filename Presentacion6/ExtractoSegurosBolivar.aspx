<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExtractoSegurosBolivar.aspx.cs" Inherits="Presentacion6_ExtractoSegurosBolivar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <h3 class="impre">Cargar archivo</h3>
                        <div class="title-divider impre"></div>
                        <div class="row">
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
                                <asp:Label runat="server" ID="lblCargar" cssClass="labels" Font-Bold="true" Text="Cargar Extracto:"></asp:Label>
                                <asp:FileUpload ID="fileUpload" runat="server"  CssClass="form-control"  /> 
                                <asp:Label ID="lbl1" runat="server" cssClass="labels" Text=""></asp:Label>
                            </div>
                         
                            <div class="col col-lg-2 col-md-12 col-sm-2 form-group">
                                <asp:Button ID="btnCargarDatos" CssClass="btn btn-primary btn-only" runat="server" Text="Cargar" OnClick="btnCargarDatos_Click"  />      
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
    <div class="col col-lg-2 col-md-12 col-sm-2 form-group">
                                <asp:Button ID="btnGuardarExtracto" CssClass="btn btn-primary btn-only" runat="server" Text="Guardar Extracto" OnClick="btnGuardarExtracto_Click"   />      
                            </div>
</asp:Content>

