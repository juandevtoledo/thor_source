<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestionarTercero.aspx.cs" Inherits="Presentacion_GestionarTercero" %>
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
                <h2>Gestionar Tercero
                    <asp:button type="submit" class="btn btn-success text-inherit pull-right" runat="server" id="btnAdicionar" onclick="btnAdicionar_Click" text="Adicionar"></asp:button>
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
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                <div class="form-group">
                    <asp:TextBox Type="text" runat="server" ID="txtNombres" CssClass="form-control" placeholder="Ingresar Nombres"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                <div class="form-group">
                    <asp:TextBox Type="text" runat="server" ID="txtApellidos" CssClass="form-control" placeholder="Ingresar Apellidos"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                <div class="form-group">
                    <asp:button type="button" CssClass="btn btn-primary botonBuscarUsuario pull-right" runat="server" id="btnBuscar" onclick="btnBuscar_Click" text="Buscar"></asp:button>
                </div>
            </div>
        </div><!--row-->
        <div class="row" id="listaTerceros" runat="server">
            <!-- Lista de terceros -->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Lista de terceros</h3>
                <div class="title-divider"></div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:GridView ID="grvListaTerceros" CssClass="table table-bordered table-hover table-striped" runat="server" AllowPaging="True" OnPageIndexChanging="grvListaTercero_PageIndexChanging" PageSize="35" OnRowCommand="grvListTercero_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-xs btn-primary glyphicon glyphicon-search"  runat="server" ID="botonConsultarTercero"  CommandName="ConsultarTercero_Click"   data-toggle="tooltip" title="Consultar"></asp:linkButton>
                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-xs btn-success glyphicon glyphicon-pencil"  runat="server" ID="botonModificarTercero"  CommandName="ModificarTercero_Click"   data-toggle="tooltip" title="Modificar"></asp:linkButton>
                                <asp:linkButton CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CssClass="btn btn-warning btn-xs glyphicon glyphicon-comment btnVer"  runat="server" id="btnObservacion"  CommandName="Observacion_Click"   data-toggle="tooltip" title="Observaciónes"></asp:linkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div><!--row--> 
        <div class="row" id="divObservaciones" runat="server">
            <div class="col-lg-12 col-md-12 col-sm-12">
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
                    <asp:Button ID="btnRegresarO" CssClass="btn btn-warning" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                </div>
            </div>
        </div>
        <div class="row" id="formTercero" runat="server">
            <!-- Información del tercero -->
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Información Tercero</h3>
                <div class="title-divider"></div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Tipo Documento *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlTipoDocumentoTercero" runat="server" Enabled="False" ></asp:DropDownList>                                                                              
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Número Identificación *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtIdentificacion" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="form-group">
                    <asp:Label Text="Nombres *" runat="server" />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Enabled="False" pattern="[a-z A-Z]*" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqtxtNombre" runat="server" ErrorMessage="** Campo obligatorio" ControlToValidate="txtNombre"  ValidationGroup="grpValidacionTercero" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Apellidos *"></asp:Label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" Enabled="False" pattern="[a-z A-Z]*" ></asp:TextBox>                   
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Fecha Nacimiento *"></asp:Label>
                    <asp:TextBox runat="server" Type="date" ID="txtNacimiento" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Edad"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEdad" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlEstadoCivilTercero" runat="server" Enabled="False" ></asp:DropDownList>
                </div>
            </div>
             <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                    <asp:Label runat="server" Text="Departamento *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" placesholder="" AutoPostBack="true" ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Enabled="False" ></asp:DropDownList>
                    </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Ciudad *"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlCiudad" runat="server" Enabled="False" ></asp:DropDownList>
                </div>
            </div>
             <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" Text="Dirección *"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" Text="Correo Electronico"></asp:Label>
                    <asp:TextBox runat="server" type="email" ID="txtCorreo" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Telefono 1 *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtTelefono1" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Telefono 2 "></asp:Label>
                    <asp:TextBox type="number"  runat="server" ID="txtTelefono2" CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
           <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Celular *"></asp:Label>
                    <asp:TextBox type="number" runat="server" ID="txtCelular"  CssClass="form-control" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label runat="server" Text="Genero *"></asp:Label>
                    <div class="form-group"> 
                        <asp:DropDownList CssClass="form-control" ID="ddlGeneroTercero" runat="server" Enabled="False" ></asp:DropDownList>                                       
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Ocupación *"></asp:Label>
                    <asp:DropDownList CssClass="ddl2" ID="ddlOcupacionTercero" runat="server" Enabled="False" ></asp:DropDownList> 
                </div>
            </div> 
            <div class="col-lg-4 col-md-4 col-sm-12">
                <div class="form-group">
                    <asp:Label runat="server" Text="Habeas Data *"></asp:Label>
                    <asp:DropDownList CssClass="ddl2" ID="ddlHabeasData" runat="server" Enabled="False" >
                        <asp:ListItem Value="1"> Si </asp:ListItem>
                        <asp:ListItem Value="0"> No </asp:ListItem>
                    </asp:DropDownList> 
                </div>
            </div>   
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:Button ID="btnGuardar" cssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnActualizar" cssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                <asp:Button ID="btnResume" cssClass="btn btn-primary" runat="server" Text="Resumen" OnClick="btnResume_Click" />
                
                <asp:Button ID="btnRegresar" cssClass="btn btn-warning pull-right" runat="server" Text="Regresar" OnClick="btnRegresar_Click"  />
            </div> 
        </div><!--row--> 
    </div>
</asp:Content>

