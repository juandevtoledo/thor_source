<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CambioClave.aspx.cs" Inherits="Cuenta_FrmCambioClave" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="container-form"> 
        <div class="row impre">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>
                    Cambio de clave
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-4 col-md-6 col-sm-12">
                <asp:Label ID="Label1" Font-Bold="true"  CssClass="labels" runat="server" Text="Clave anterior"></asp:Label>
                <asp:TextBox ID="txtClaveAnterior" type="password" runat="server" CssClass="form-control" />
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <asp:Label ID="Label2" Font-Bold="true"  CssClass="labels" runat="server" Text="Nueva clave"></asp:Label>
                <asp:TextBox ID="txtClaveNueva" type="password" runat="server" CssClass="form-control txtClaveNueva" />
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <asp:Label ID="Label3" Font-Bold="true"  CssClass="labels" runat="server" Text="Nueva clave confimación"></asp:Label>
                <asp:TextBox ID="txtClaveNuevaConfirmacion" type="password" runat="server" CssClass="form-control" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <span class="alertaClave"></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Button ID="btnCambiarClave" CssClass="btn btn-primary btn-only"  runat="server" Text="Cambiar clave" OnClick="btnCambiarClave_Click"/>
            </div>
        </div>
    </div><!--container-form-->
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCambiarClave"/>
        </Triggers>
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
      
            $('.txtClaveNueva').bind('keyup', function () {
                var clave = $(this).val();
                console.log(clave)
                if (clave.length > 8) {
                    $('.alertaClave').text('Clave segura');
                }
                else {
                    $('.alertaClave').text('La clave es muy corta');
                }
            })
        }
    </script>
</asp:Content>


