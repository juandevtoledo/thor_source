<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformeDevolucion.aspx.cs" Inherits="Presentacion3_InformeDevolucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <h3>Informe Devolución de Prima</h3>
            <div class="title-divider"></div>
        </div>
    </div>

     <div class="row ">
         <div class="row">
             <div class="col-md-1"></div>
             <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLocalidad" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Localidad"></asp:Label>
                        <asp:DropDownList ID="ddlLocalidad" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMes" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Mes"></asp:Label>
                        <asp:DropDownList ID="ddlMes" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="ENERO" Value="1" />
                            <asp:ListItem Text="FEBRERO" Value="2" />
                            <asp:ListItem Text="MARZO" Value="3" />
                            <asp:ListItem Text="ABRIL" Value="4" />
                            <asp:ListItem Text="MAYO" Value="5" />
                            <asp:ListItem Text="JUNIO" Value="6" />
                            <asp:ListItem Text="JULIO" Value="7" />
                            <asp:ListItem Text="AGOSTO" Value="8" />
                            <asp:ListItem Text="SEPTIEMBRE" Value="9" />
                            <asp:ListItem Text="OCTUBRE" Value="10" />
                            <asp:ListItem Text="NOVIEMBRE" Value="11" />
                            <asp:ListItem Text="DICIEMBRE" Value="12" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDesde" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Desde"></asp:Label>
                        <asp:TextBox runat="server" type="date" ID="txtDesde" CssClass="form-control" placeholder="DD/MM/AAAA" OnTextChanged="txtDesde_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblHasta" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Hasta"></asp:Label>
                        <asp:TextBox runat="server" type="date" ID="txtHasta" CssClass="form-control" placeholder="DD/MM/AAAA" OnTextChanged ="txtHasta_TextChanged" AutoPostBack="true" ></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2"></div>
         </div>
         <div class="row">
             <div class="col-md-1"></div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCompania" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Compañia"></asp:Label>
                        <asp:DropDownList ID="ddlCompania" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlCompania_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblProducto" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Producto"></asp:Label>
                        <asp:DropDownList ID="ddlProducto" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblFormaPago" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Forma de Pago"></asp:Label>
                        <asp:DropDownList ID="ddlFormaPago" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlFormaPago_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2"></div>
         </div>
         <div class="row">
             <div class="col-md-1"></div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCausaDevolucion" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Causal de Devolucion"></asp:Label>
                        <asp:DropDownList ID="ddlCausaDevolucion" CssClass="ddl impre" runat="server"  OnSelectedIndexChanged="ddlCausaDevolucion_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblEstado" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Estado"></asp:Label>
                        <asp:DropDownList ID="ddlEstado" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblRechazo" Font-Bold="true"  CssClass="labels impre" runat="server" Text="Rechazo"></asp:Label>
                        <asp:DropDownList ID="ddlRechazo" CssClass="ddl impre" runat="server" OnSelectedIndexChanged="ddlRechazo_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
             <div class="col-md-2">
                
             </div>
         </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grvDevoluciones" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20" >
                    
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5"></div>
        <div class="col-md-2">
            <input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" />
        </div>
        <div class="col-md-5"></div>
    </div>

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
        function endReq(sender, args) {
            $(".ddl").select2({
                placeholder: "Seleccione",
                allowClear: true
            });
            $(function () {
                $("#tabs").tabs();
            });
        }
  </script>
</asp:Content>