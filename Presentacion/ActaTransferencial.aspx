<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ActaTransferencial.aspx.cs" Inherits="Presentacion_ActaTransferencial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="../Scripts/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center><h3>Acta transferencial</h3></center>
         <div class="row">
              <div class="row">
            <div class="col-md-12 margenFormularios">
                <div class="container">
                    <br />
                    <a href="#seccion" class="btn btn-primary btnNensajeAlerta impre" data-toggle="collapse"><strong><ins>Sobre Nosotros</ins></strong></a>
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
             <div class="col-md-12 impre">
               <fieldset>
                <div class="row">
                  <div class="col-md-1"></div>
                    <div class="col-md-3">
                      <label>Agencia</label>
                         <asp:DropDownList ID="ddlagenciaProduccion"  CssClass="ddl impre" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CargarBusquedaAgencia">                          
                         </asp:DropDownList>                
                      </div>
                      <div class="col-md-3">
                        <div class="form-group ">
                          <label for="dp1">Desde</label>
                          <asp:TextBox runat="server" type="date" ID="txtDesde" CssClass="form-control impre" placeholder="DD/MM/AAAA" ></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-3">
                          <div class="form-group">
                            <label for="dp">Hasta</label>
                            <asp:TextBox runat="server" type="date" ID="txtHasta" CssClass="form-control impre" placeholder="DD/MM/AAAA" AutoPostBack="true" OnTextChanged="CargarBusquedaFecha"></asp:TextBox>
                          </div>
                      </div>                               
                      <div class="col-md-1"></div>              
                 </div>
                 <div class="row">
                       <div class="col-md-1"></div>
                       <div class="col-md-3">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Cedula</label>
                            <asp:TextBox type="number" MaxLength="5" runat="server" ID="txtcedulaProduccion" CssClass="form-control impre" placeholder="Ingrese el numero de documento" OnTextChanged="CargarBusquedaTercero" ></asp:TextBox>
                          </div>
                       </div>
                       <div class="col-md-3">
                         <div class="form-group">
                            <label for="exampleInputEmail1">Numero Certificado</label>
                            <asp:TextBox type="number"  runat="server" ID="txtnumeroCertificadoProduccion" CssClass="form-control impre" placeholder="Ingrese el numero del certificado" OnTextChanged="CargarBusquedaPoliza" ></asp:TextBox>
                              
                         </div>
                       </div>
                     <br />
                       <div class="col-md-1">
                            <center><asp:Button ID="btnBusquedaPlanilla" CssClass="btn btn-primary btnBusqueda impre" runat="server" Text="BUSCAR" OnClick="btnBusquedaPlanilla_Click" /></center>
                       </div>
                        <div class="col-md-3">
                            <center><asp:Button ID="btnLimpiar" CssClass="btn btn-default btnBusqueda impre" runat="server" Text="LIMPIAR" OnClick="btnLimpiar_Click" /></center>
                         </div>
                       <div class="col-md-1"></div>
                  </div>
                  </fieldset>
                   <hr />
             </div>
        </div>
        <div class="row">
            <div class="col-md-12 margenFormularios">
               <asp:GridView ID="grvActaTransferencial" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDataBound="grvActaTransferencial_RowDataBound" PageSize="20" AllowPaging="True" OnPageIndexChanging="grvActaTransferencial_PageIndexChanging">
                   <Columns>
                     <asp:TemplateField HeaderText="&lt;font size='4' color='red'&gt;&lt;span class='glyphicon glyphicon-saved' aria-hidden='true'&gt;&lt;/span&gt;&lt;/font&gt;">
                        <ItemTemplate>
                           <asp:CheckBox ID="chkSeleccionar" runat="server" />
                        </ItemTemplate>
                     </asp:TemplateField >  
                   </Columns>
               </asp:GridView>
             </div>
        </div>        
        <br /><br />                
        <div class="row">
            <div class="col-md-4"></div>
                <div class="col-md-2">
                  <center><asp:Button ID="btnEnviar" runat="server"  CssClass="btn btn-primary btnBusqueda impre" Text="ENVIAR" OnClientClick="return confirm('Esta seguro de enviar estos registros a confirmacion de digitación?')"  OnClick="btnEnviar_Click" /></center>
                </div>
                <div class="col-md-2">
                    <center><input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" /></center>
                </div>
            <div class="col-md-4"></div>
        </div>
        <script src="../Scripts/jquery-1.11.2.min.js"></script>
        <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>

