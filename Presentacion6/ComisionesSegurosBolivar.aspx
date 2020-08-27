<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComisionesSegurosBolivar.aspx.cs" Inherits="Presentacion6_ComisionesSegurosBolivar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="spmComisionesSegurosBolivar" runat="server" AsyncPostBackTimeout="9000000"></asp:ScriptManager> 
    <legend>Comisiones Enviadas a Seguros Bolivar</legend>
    <div class="row">
                            <div class="col col-lg-3 col-md-5 col-sm-5 form-group">
                                <asp:Label ID="lblProducto" runat="server" CssClass="labels" Font-Bold="true" Text="PRODUCTO"></asp:Label>
                                        <asp:DropDownList ID="ddlProducto" runat="server"></asp:DropDownList>
                            </div>
                            </div>
                                <div class="row">
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
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
                            <div class="col col-lg-5 col-md-5 col-sm-5 form-group">
                                <asp:Label ID="lblFechaEnvio" runat="server" CssClass="labels" Font-Bold="true" Text="Fecha Envio"></asp:Label>
                                        <asp:TextBox ID="txtFechaEnvio" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                             
                                    </div>
                                <div class="row">
                                
    <div class="col col-lg-2 col-md-12 col-sm-2 form-group">
                                <asp:Button ID="btnConsultarComisiones" CssClass="btn btn-primary btn-only" runat="server" Text="Consultar" OnClick="btnConsultarComisiones_Click"   />      
                            </div>
                                    </div>
                        
    <asp:GridView ID="grvComisionesSegurosBolivar" runat="server" CssClass="table table-bordered table-hover table-striped" AllowPaging="True" OnPageIndexChanging="grvComisionesSegurosBolivar_PageIndexChanging" PageSize="50" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    
                                                </asp:TemplateField>
                                            </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                        </asp:GridView>

    <asp:UpdatePanel runat="server" ID="udpComisionesSegurosBolivar">
        <ContentTemplate>
        <asp:UpdateProgress ID="uppComisionesSegurosBolivar" runat="server"  OnLoad="Page_Load" >
                                        <ProgressTemplate>
                                            <div class="contenedor-loader">
                                                <div class='loader'>
                                                    <h6><p style="text-align:center"><b>Su solicitud se esta procesando, por favor espere...<br /></b></p></h6>
                                                </div>
                                  
                                            </div>
                                         </ProgressTemplate>
                                </asp:UpdateProgress>
                                        
                                    </ContentTemplate>

    </asp:UpdatePanel>
                                    
</asp:Content>

