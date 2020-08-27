<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" enableEventValidation="false" CodeFile="DevolucionDeProduccion.aspx.cs" Inherits="Presentacion_DevolucionDeProduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3><center>Devolución de Producción</center></h3>
    <hr />
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
                <div class="col-md-12 margenFormularios">
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
                                                <asp:TextBox runat="server" type="date" ID="txtHasta" CssClass="form-control" placeholder="DD/MM/AAAA" AutoPostBack="true" OnTextChanged="CargarBusquedaFechaDevolucion"></asp:TextBox>
                                            </div>
                                          </div>                               
                                <div class="col-md-1"></div>              
                            </div>
                            <div class="row">
                                <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Cedula</label>
                                            <asp:TextBox type="number" runat="server" ID="txtcedulaProduccion" CssClass="form-control" placeholder="Ingrese el numero de documento" OnTextChanged="CargarBusquedaTerceroDevolucion" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Numero Certificado</label>
                                            <asp:TextBox type="number" runat="server" ID="txtnumeroCertificadoProduccion" CssClass="form-control" placeholder="Ingrese el numero del certificado" OnTextChanged="CargarBusquedaPolizaDevolucion" ></asp:TextBox>
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
                    <hr />
                    </div>
                 </div>
                      <div class="row">
                           <div class="col-md-1"></div>
                                    <div class="col-md-10 divTablaDevolucionDeProduccion">
                                         <asp:GridView ID="grvDevolucionDeProduccion" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowCommand="grvDevolucionDeProduccion_RowCommand" AllowPaging="True" PageSize="20" OnPageIndexChanging="grvDevolucionDeProduccion_PageIndexChanging">
                                             <Columns>
                                                 <asp:TemplateField>
                                                     <ItemTemplate>
                                                         <asp:Button runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" data-placement="right" title="Enviar a Devolución" ID="btnDevolver" CommandName="devolver_Click" OnClientClick="return confirm('Esta seguro de enviar este registro como una devolucion?')" CssClass="btn btn-danger botonDevolucion" />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField>
                                                     <ItemTemplate>
                                                         <asp:Button runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' data-toggle="tooltip" data-placement="right" title="Recuperar registro" CommandName="recuperar_Click" ID="btnPrueba" OnClientClick="return confirm('Desea realmente recuperar este certificado?')" CssClass="btn btn-primary botonRecuperar" />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                             </Columns>
                                             <PagerStyle Font-Overline="True" Font-Size="Small" />
                                         </asp:GridView>
                                    </div>
                            <div class="col-md-1"></div>
                         </div>
                         <div class="row impre">
                             <div class="col-md-5"></div>
                              <div class="col-md-2">
                                <center><input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" /></center>
                            </div>
                             <div class="col-md-5"></div>
                         </div>
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>

