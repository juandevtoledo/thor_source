<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PolizasArchivadas.aspx.cs" Inherits="Presentacion_PolizasArchivadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="..content/bootstrap.min.css" rel="stylesheet" />
    <script src="..scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h3>Polizás archivadas</h3></center>
      <div class="row impre">
           <div class="row">
            <div class="col-md-12 margenFormularios">
                <div class="container">
                    <br />
                    <a href="#seccion" class="btn btn-primary btnNensajeAlerta" data-toggle="collapse"><strong><ins>Sobre Nosotros</ins></strong></a>
                    <div class="collapse" id="seccion">
                        <br />
                        <div class="well">
                            <br />
                            <p>Somos una empresa asesora
                          de seguros fundada en 1976 en la bella ciudad de Manizales,
                          ofrecemos seguridad a nuestros clientes y sus familias, contamos con un excelente
                          soporte humano y logístico. El amor a la vida, al trabajo y el respeto,
                          nos han forjado un sentido claro de pertenencia.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
          <br /><br />
                <div class="col-md-12">
                     <fieldset>
                            <div class="row">
                                <div class="col-md-1"></div>
                                  <div class="col-md-3">
                                      <label>Agencia</label>
                                      <asp:DropDownList ID="ddlagenciaProduccion" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CargarBusquedaAgencia">
                                       
                                      </asp:DropDownList>                
                                  </div>
                                          <div class="col-md-3">
                                             <div class="form-group">
                                                <label for="dp1">Desde</label>
                                                <asp:TextBox runat="server" type="date" ID="txtDesde" CssClass="form-control" placeholder="DD/MM/AAAA" ></asp:TextBox>
                                             </div>
                                          </div>
                                          <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="dp">Hasta</label>
                                                <asp:TextBox runat="server" type="date" ID="txtHasta" CssClass="form-control" placeholder="DD/MM/AAAA" AutoPostBack="true" OnTextChanged="CargarBusquedaFecha"></asp:TextBox>
                                            </div>
                                          </div>                               
                                <div class="col-md-2"></div>              
                            </div>
                            <div class="row">
                                <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Cedula</label>
                                            <asp:TextBox type="number" runat="server" ID="txtcedulaProduccion" CssClass="form-control" placeholder="Ingrese el numero de documento" OnTextChanged="CargarBusquedaTercero" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Numero Certificado</label>
                                            <asp:TextBox type="number" runat="server" ID="txtnumeroCertificadoProduccion" CssClass="form-control" placeholder="Ingrese el numero del certificado" OnTextChanged="CargarBusquedaPoliza" ></asp:TextBox>
                                        </div>
                                    </div>
                                <br />
                                <div class="col-md-1">
                                    <center><asp:Button ID="btnBusquedaPlanilla" CssClass="btn btn-primary btnBusqueda" runat="server" Text="BUSCAR" OnClick="btnBusquedaPlanilla_Click" /></center>
                                </div>
                                <div class="col-md-3">
                                     <center><asp:Button ID="btnLimpiar" CssClass="btn btn-default btnBusqueda" runat="server" Text="LIMPIAR" OnClick="btnLimpiar_Click" /></center>
                                 </div>
                                <div class="col-md-1"></div>
                            </div>
                         </fieldset>
                     </div>
                    </div>
                      <div class="row">
                         <div class="col-md-12 margenFormularios">
                            <hr />
                            <asp:GridView ID="grvPolizasArchivadas" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvPolizasArchivadas_PageIndexChanging">
                            </asp:GridView>
                         </div>
                      </div>
                    <br /> <br />
                     <div class="row impre">
                        <div class="col-md-5"></div>
                          <div class="col-md-2">
                              <center><input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" /></center>
                          </div>
                        <div class="col-md-5"></div>
                     </div>
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="..content/materialize/js/materialize.js"></script>
    <script src="..content/materialize/js/materialize.min.js"></script>
</asp:Content>

