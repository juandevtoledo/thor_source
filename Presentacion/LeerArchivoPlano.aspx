<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LeerArchivoPlano.aspx.cs" Inherits="Presentacion_LeerArchivoPlano" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.2.min.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="impre">
        <h2>Cargue Archivo Plano</h2>
    </div>
    <div class="title-divider"></div>
    <div class="row">
        <div class="col-md-12 margenFormularios">
            <fieldset>
                <div class="row">
                    <div class="col-md-4"> 
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                    </div>
                    <div class="input-switch col-md-2">
                        <asp:CheckBox ID="chkOpcion" runat="server" Checked="true" />
                    </div>
                    <div class ="col-md-2">
                        <asp:Button ID="btnLeer" CssClass="btn btn-primary" runat="server" OnClick="btnLeer_Click" Text="Cargar" OnClientClick="return confirm('Esta seguro de cargar este archivo plano en la base de datos?')" />
                    </div>                           
                 </div>
            </fieldset>
            <br />
            <div id ="resumen" runat="server">
                <h3>Resumen</h3>
                <div class="title-divider"></div>
                <div class="row">
                    <div class="col-md-4">
                        <h5>Certificados Ingresado:
                            <asp:Label runat="server" ID="total"></asp:Label>
                        </h5>
                    </div>
                    <br />
                </div>
                <div class="row col-md-12 ">
                    <asp:LinkButton class="btn btn-success" type="button" id="btnExito" runat="server" OnClick =" btnExito_Click">
                        Exito <span class="badge" runat="server" id="spnExito"/>
                    </asp:LinkButton>
                            
                    <asp:LinkButton class="btn btn-danger" type="button" id="btnError" runat="server" OnClick="btnError_Click">
                        Error <span class="badge" runat="server" id="spnError"/>
                    </asp:LinkButton>
                    
                    <asp:LinkButton class="btn btn-primary" type="button" id="btnLimpiar" runat="server" OnClick="btnLimpiar_Click">
                        Todos <span class="badge" runat="server" id="spnTodos"/>
                    </asp:LinkButton>
                </div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-md-12">                   
                        <asp:GridView ID="grvResumenPlano" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-striped" runat="server" OnRowDataBound="grvResumenPlano_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="E" SortExpression="E">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Certificado" SortExpression="Certificado">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Certificado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asegurado" SortExpression="Asegurado">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Asegurado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amparos" SortExpression="Amparo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Amparos") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Beneficiario" SortExpression="Beneficiario"> 
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Beneficiarios") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Conyuge" SortExpression="Conyuge">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Conyuge") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Otro Asegurado" SortExpression="Otro Asegurado">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("OtroAsegurado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>                                                      
                        </asp:GridView>                                                                                          
                    </div>
                </div>
                <div class="row impre">
                        <div class="col-md-5"></div>
                          <div class="col-md-2">
                              <center><input type="button" runat="server" class="btn btn-primary btnBusqueda impre" id="btnImprimir" onclick="window.print();" value="IMPRIMIR" /></center>
                          </div>
                        <div class="col-md-5"></div>
                </div>             
                </div> 
            </div>    
        </div>
    <script type="text/javascript">
        
    </script>
    <script src="../scripts/jquery-1.11.2.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</asp:Content>