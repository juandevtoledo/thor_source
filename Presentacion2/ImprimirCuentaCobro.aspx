<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImprimirCuentaCobro.aspx.cs" Inherits="Presentacion2_ImprimirCuentaCobro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> <link rel="stylesheet" href="/Content/EstilosIndex.css" /></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        #ctl00_ContentPlaceHolder1_rvCuentaCobro_fixedTable{
            width: 100%;
        }
    </style>
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 imprimir-oculto">
                <h2>
                    Imprimir cuenta cobro
                    <asp:LinkButton ID="btnRegresar" CssClass="btn btn-success pull-right" Text="Regresar" runat="server" onclick="btnRegresar_Click"/>
                    <a class="btn btn-primary btn-imprimir btn-floating" onclick="window.print();"><span aria-hidden="true" class="glyphicon glyphicon-print"></span></a>
                </h2>
                <div class="title-divider"></div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 ">
                <div class="imprimir-container impreVisible imprimir-visible cuenta-cobro">
                    <div class="wrapper">
                        <figure class="logo-imprimir">
                            <img runat="server" src="~/Imagenes/logo_torres.png" />
                        </figure>
                        <div class="cuenta-cobro-nit"><strong>890803304 - 1</strong></div>
                        <div><asp:Label ID="lblAgencia" runat="server" CssClass="text-uppercase" Text="Agencia"></asp:Label>, <asp:Label ID="lblFechaInicial" runat="server" Text="Fecha"></asp:Label></div>
                        <div class="encabezados">
                            <div>TG <asp:Label ID="lblConsecutivo" Text="text" runat="server" /></div>
                            <div><asp:Label CssClass="text-uppercase" ID="lblPagaduriaCarta" runat="server"></asp:Label></div>
                            <div>Dirección: <asp:Label CssClass="text-uppercase" ID="lblDireccion" runat="server"></asp:Label></div>
                            <div>Teléfono: <asp:Label CssClass="text-uppercase" ID="lblTelefono" runat="server"></asp:Label></div>
                        </div>
                        <div class="saludo"><h5>Cordial Saludo,</h5> </div>
                        <div>
                            <h4 class="text-center"><strong>TORRES GUARÍN Y CÍA LTDA. ASESORES DE SEGUROS</strong></h4>
                            <div class="text-center comunicado">
                                Se permite comunicar que: <br /><br />
                                <asp:Label ID="lblPagaduriaCarta2" CssClass="text-uppercase" runat="server" Text="lblPagaduriaCarta2"></asp:Label>
                            </div>
                        </div>
                        <div class="text-justify contenido">
                            <p class="cuentacont">
                                Debe transferir o consignar por concepto de primas recaudadas correspondientes al
                                seguro de Vida Grupo tomado mediante la Intermediaria de Seguros Torres Guarín y Cía. Ltda. Asesores de Seguros,
                                dentro de los primeros 10 días de cada mes, con el fin de mantener activa la póliza de
                                cada uno de sus asegurados. La consignación ó transferencia debe hacerse a la cuenta
                                <asp:Label id="lblCuentaBancariaTipo" Text="______________" runat="server" /> No. <asp:Label id="lblCuentaBancariaNumero" Text="______________" runat="server" /> de <asp:Label id="lblCuentaBancariaBanco" Text="______________" runat="server" />, <asp:Label ID="lblCuentaBancariaPertenece" runat="server"></asp:Label> 
                                relación y el detalle del pago:
                            </p>
                        </div>
                        <div class="row mes-descuento">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">Descuento del mes de: <asp:Label ID="lblMesDescuento" Text="mes" runat="server" /> de <asp:Label ID="lblAnioDescuento" Text="año" runat="server" /></div><div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">Vigencia del Mes de: <asp:Label ID="lblMesVigencia" Text="mes" runat="server" /> de <asp:Label ID="lblAnioVigencia" Text="mes" runat="server" /></div>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grvMesCuentaDeCobro" CssClass="table table-bordered table-hover table-striped table-cuentaCobro" runat="server"></asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div>
                            <div class="text-right">TOTAL: $<asp:Label ID="totalCuentaCobro" Text="text" runat="server" /></div>
                        </div>
                        <div class="cordialmente">
                            <h5>Cordialmente,</h5>
                        </div>
                        <div class="firma">
                            <div>_____________________________</div>
                            <div class="director">
                                <asp:Label ID="lblNombreDirector" Text="text" runat="server" />
                            </div>
                            <div>
                                 <asp:Label ID="lblCargo" Text="text" runat="server" />
                            </div>
                            <div>Torres Guarín y Cía. Ltda Asesores de Seguros</div>
                        </div>
                        <!--<div>
                            <h4 class="text-center"><asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate><asp:Label ID="lblInformacionPieCarta" runat="server"></asp:Label></ContentTemplate></asp:UpdatePanel></h4>
                            <h4 class="text-center"><asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate><asp:Label ID="lblCorreoPieCarta" runat="server"></asp:Label></ContentTemplate></asp:UpdatePanel></h4>
                        </div>-->
                    </div>
                    <div class="footer text-center">
                        <div>
                            <asp:Label ID="lblNombreAgencia" runat="server" /> , <asp:Label ID="lblDireccionAgencia" runat="server" /> Teléfono: <asp:Label ID="lblTelefonAgencia" runat="server" /></div>
                        <div>Correo electrónico: <asp:Label ID="lblEmailAgencia" runat="server" /> Línea Amable 018000916926</div>
                    </div>
                </div>
            </div>
        </div><!--row-->
    </div><!--container-form-->
</asp:Content>


