<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarTercero.aspx.cs" Inherits="Presentacion_frmAdministrarTercero" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-form">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="alert alert-warning" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    Por favor verifique la informacion suministrada y actualizarla en caso de que sea necesario antes de continuar con la operacion a realizar
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2>Buscar Tercero
                    <asp:button type="submit" class="btn btn-success botonBuscarUsuario text-inherit pull-right" runat="server" id="botonNuevoRegistro" onclick="botonNuevoRegistro_Click" text="Nuevo"></asp:button>
                </h2>
                <div class="title-divider"></div>
            </div>
        </div><!--row-->
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                <div class="form-group">
                    <asp:TextBox Type="number" runat="server" ID="txtDocumento" CssClass="form-control" placeholder="Ingresar Documento"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-3 col-xs-12">
                <div class="form-group">
                    <asp:TextBox Type="text" runat="server" ID="TextBox1" CssClass="form-control" placeholder="Ingresar Nombres"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-3 col-xs-12">
                <div class="form-group">
                    <asp:TextBox Type="text" runat="server" ID="TextBox2" CssClass="form-control" placeholder="Ingresar Apellidos"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-2 col-md-4 col-sm-2 col-xs-12">
                <div class="form-group">
                    <asp:button type="submit" CssClass="btn btn-primary botonBuscarUsuario pull-right" runat="server" id="botonBuscarTercero" onclick="botonBuscarTercero_Click" text="Buscar"></asp:button>
                </div>
            </div>
        </div><!--row-->
        <div class="row">
            <!-- Lista de terceros -->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Lista de terceros</h3>
                <div class="title-divider"></div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
            
            </div>
            <!-- Información del tercero -->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Información Tercero</h3>
                <div class="title-divider"></div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblNombres" runat="server" Text="Nombres *"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Enabled="False" pattern="[a-z A-Z]*" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqtxtNombre" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombre"  ValidationGroup="grpValidacionTercero" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblApellidos" runat="server" Text="Apellidos *"></asp:Label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" Enabled="False" pattern="[a-z A-Z]*" ></asp:TextBox>                   
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento *"></asp:Label>
                    <asp:TextBox runat="server" Type="date" ID="txtNacimiento" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblEdad" runat="server" Text="Edad"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEdad" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblTipoDocumento" runat="server" Text="Tipo Documento *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlTipoDocumentoTercero" runat="server" Enabled="False" ></asp:DropDownList>                                                                              
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblNumeroIdentificacion" runat="server" Text="Número Identificación *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtIdentificacion" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
             <div class="col-md-4">
                    <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblDepartamento" runat="server" Text="Departamento *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Enabled="False" ></asp:DropDownList>
                    </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblCiudad" runat="server" Text="Ciudad *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlCiudad" runat="server" Enabled="False" ></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblEmail" runat="server" Text="Correo Electronico"></asp:Label>
                    <asp:TextBox runat="server" type="email" ID="txtCorreo" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblCelular" runat="server" Text="Celular *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtCelular"  CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblTelefono1" runat="server" Text="Telefono 1 *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtTelefono1" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblTelefono2" runat="server" Text="Telefono 2 *"></asp:Label>
                    <asp:TextBox type="number"  runat="server" ID="txtTelefono2" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblDireccion" runat="server" Text="Dirección *"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblSexo" runat="server" Text="Genero *"></asp:Label>
                    <div class="form-group"> 
                        <asp:DropDownList CssClass="form-control" ID="ddlGeneroTercero" runat="server" Enabled="False" >
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>MASCULINO</asp:ListItem>
                            <asp:ListItem>FEMENINO</asp:ListItem>
                        </asp:DropDownList>                                       
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblEstadoCivil" runat="server" Text="Estado Civil *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlEstadoCivilTercero" runat="server" Enabled="False" ></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label cssClass="labels" Font-Bold="true" ID="lblOcupacion" runat="server" Text="Ocupación *"></asp:Label>
                    <asp:DropDownList CssClass="ddl2" ID="ddlOcupacionTercero" runat="server" Enabled="False" ></asp:DropDownList> 
                </div>
            </div>   
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" Text="Habeas Data *" ID="lblHabeas" CssClass="labels" Font-Bold="true" ></asp:Label>
                    <asp:DropDownList CssClass="ddl2" ID="ddlHabeasData" runat="server" Enabled="False" >
                        <asp:ListItem Value="1"> Si </asp:ListItem>
                        <asp:ListItem Value="0"> No </asp:ListItem>
                    </asp:DropDownList> 
                </div>
            </div>  
            <div class="col-md-12">
                <asp:Button ID="botonProductosTercero" cssClass="btn btn-primary botonTercero" runat="server" Text="RESUMEN" Visible="False" OnClick="botonProductosTercero_Click" />
                <asp:Button ID="botonRegistrarTercero" cssClass="btn btn-primary botonTercero" runat="server" Text="REGISTRAR" OnClick="botonRegistrarTercero_Click" Visible="False" ValidationGroup="grpValidacionCertificado" />
                <!--<asp:Button ID="botonEliminarTercero" cssClass="btn btn-primary botonTercero" runat="server" Text="ELIMINAR" OnClick="botonEliminarTercero_Click" Visible="False" />-->
                <asp:Button ID="botonGuardarTercero" cssClass="btn btn-primary botonTercero" runat="server" Text="GUARDAR" Visible="False" OnClick="botonGuardarTercero_Click" />
                <asp:Button ID="botonCancelarTercero" cssClass="btn btn-primary botonTercero" runat="server" Text="CANCELAR" Visible="False" OnClick="botonCancelarTercero_Click" />
                <asp:Button Enabled="true" ID="botonEditarTercero" cssClass="btn btn-success botonTercero" runat="server" Text="EDITAR" OnClick="botonEditarTercero_Click" Visible="False" />
                <asp:Button ID="PasarCertificado" CssClass="btn btn-primary botonTercero" runat="server"  OnClientClick="localStorage.setItem('accIndex', 0);" Text="SIGUIENTE" OnClick="PasarCertificado_Click" Visible="False" ValidationGroup="grpValidacionTercero" />
                <asp:Button ID="btnObservacion" cssClass="btn btn-warning" runat="server" Visible="false" Text="OBSERVACIONES" OnClick="btnObservacion_Click" />
            </div>
            <div class="row margenFormularios" id="divObservaciones" runat="server">
                <div class="col-lg-12 col-md-11 col-sm-12">
                    <h4>Observaciones</h4>
                    <div class="title-divider"></div>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <asp:GridView ID="grvObservaciones" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True"  PageSize="35">
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <div class="col-md-1"></div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="col-md-2"></div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" ID="lblObservacion" cssClass="labels" Font-Bold="true" Text="Observaciones"></asp:Label>
                        <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqTextObservacion" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtObservacion" ForeColor="Red" SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnGuardarObservacion" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarObservacion_Click" ValidationGroup="g"/>
                        <asp:Button ID="btnRegresar" CssClass="btn btn-warning" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                    </div>
                </div>
            </div>    
        </div><!--row-->
    </div>
</asp:Content>

