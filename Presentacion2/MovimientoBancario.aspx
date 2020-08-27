<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MovimientoBancario.aspx.cs" Inherits="Presentacion2_MovimientoBancario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center><h3>Movimiento Bancario</h3></center>
    <div class="row">
        <div class="col-md-12 margenFormularios">
            <div class="row">
            <div class="col-md-12">
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
        <br />
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Información</legend>
                         <div class="col-md-4">
                             <asp:Label runat="server" ID="lblPagaduria" cssClass="labels" Font-Bold="true" Text="Pagaduria"></asp:Label>
                            <asp:DropDownList ID="ddlPagaduria" CssClass="ddl" runat="server">

                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                             <asp:Label runat="server" ID="lblFecha" cssClass="labels" Font-Bold="true" Text="Fecha"></asp:Label>
                             <asp:TextBox type="date" ID="txtFecha" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                </fieldset>
            </div>
        </div>
       <br />
       <div class="row">
           <div class="col-md-12">
             <div class="col-md-1"></div>
               <div class="col-md-10 divTablaEntregaDeProduccion">
                     <asp:GridView ID="grvMovimientoBancario" CssClass="table table-bordered table-hover table-striped" runat="server">
                         <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" CommandArgument='' data-toggle="tooltip" data-placement="right" title="Consultar"  CssClass="btn btn-primary botonDigitar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                      </asp:GridView>
                   </div>
               <div class="col-md-1"></div>
           </div>
       </div>
     </div>
   </div>
</asp:Content>

