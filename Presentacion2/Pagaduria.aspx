<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pagaduria.aspx.cs" Inherits="Presentacion2_frmPagaduria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
      <script src="/Scripts/jquery-1.11.2.min.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="tabs">
   <ul>
        <li><a href="#tabs-1">Pagaduria</a></li>
        <li><a href="#tabs-2">Convenio</a></li>
        <li><a href="#tabs-3">Configuración novedades</a></li>
       </ul>
    <div id="tabs-1">
        <div class="row">
        <div class="col-md-4"></div>
            <div class="col-md-4">
                <h3>Novedades</h3>
            </div>
        <div class="col-md-4"></div>
      </div>
        <hr />
    <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Pagaduria</legend>
                        <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label>Identificación</label>
                                            <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server" placeholder="Numero Identificacion" ></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Nombre</label>
                                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Ingrese Nombre"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Departamento</label>
                                            <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                         <div class="col-md-4">
                                            <label>Ciudad</label>
                                            <asp:DropDownList ID="ddlCiudad" CssClass="form-control" runat="server">

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Dirección</label>
                                            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" placeholder="Ingrese su Dirección" ></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Telefono</label>
                                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" placeholder="Ingrese su numero de telefono"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblActividadEconomica" runat="server" Font-Bold="true"  CssClass="labels" Text="Actividad economica"></asp:Label>
                                    <asp:TextBox ID="txtActividadEconomica" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                     <label>Numero Empleados</label>
                                     <asp:TextBox ID="txtEmpleado" CssClass="form-control" runat="server" placeholder="Ingrese el numero de empleados"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                     <asp:Label ID="lblParticipacion" runat="server" Font-Bold="true"  CssClass="labels" Text="%.Participación"></asp:Label>
                                    <asp:TextBox ID="txtParticipacion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <asp:Label ID="lblVisación" runat="server" Font-Bold="true"  CssClass="labels" Text="Visacion:"></asp:Label>
                                    <asp:CheckBox ID="chkVisacionSi" runat="server" Text="Si" />
                                    <asp:CheckBox ID="chkVisacionNo" runat="server" Text="No" />
                                </div>
                                <div class="col-md-7"></div>
                            </div>
                </fieldset>
                <fieldset>
                    <legend>Información</legend>
                        <div class="row">
                            <div class="col-md-5">
                                <div class="row">
                                            <div class="row">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <label>Responsable del pago</label>
                                                    <asp:TextBox ID="txtResponsablePago" CssClass="form-control" runat="server" placeholder="responsable de pago"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3"></div>
                                            </div>
                                    <br />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label>Correo</label>
                                                    <asp:TextBox ID="txtCorreo1" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Telefono</label>
                                                    <asp:TextBox ID="txtTelefono1" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Celular</label>
                                                    <asp:TextBox ID="txtCelular1" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-6">
                                         <div class="row">
                                         <div class="row">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <label>Contacto</label>
                                                    <asp:TextBox ID="txtContacto" CssClass="form-control" runat="server" placeholder="Contacto"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3"></div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label>Correo</label>
                                                    <asp:TextBox ID="txtCorreo2" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Telefono</label>
                                                    <asp:TextBox ID="txtTelefono2" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Celular</label>
                                                    <asp:TextBox ID="txtCelular2" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                             </div>
                                        </div>
                                    </div>
                                </div>
                             <br /><br />
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-8">
                                        <div class="row">
                                         <div class="row">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <label>Responsable Legal</label>
                                                    <asp:TextBox ID="txtResponsableLegal" CssClass="form-control" runat="server" placeholder="Responsable legal"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3"></div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label>Correo</label>
                                                    <asp:TextBox ID="txtCorreo3" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Telefono</label>
                                                    <asp:TextBox ID="txtTelefono3" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Celular</label>
                                                    <asp:TextBox ID="txtCelular" CssClass="form-control" runat="server" ></asp:TextBox>
                                                </div>
                                             </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                             <br />
                            <div class="row">
                                <div class="col-md-5"></div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="GUARDAR" />
                                </div>
                                <div class="col-md-5"></div>
                            </div>   
                   </fieldset>
                <fieldset>
                    <br />
                        <div class="row">
                            <div class="col-md-3">
                                <label>#.Identificacion</label>
                                <asp:TextBox ID="txtIdentificacion" cssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombre2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1" id="divbtnBuscar">
                                <asp:Button ID="btnBuscar" CssClass="btn btn-success" runat="server" Text="BUSCAR" />
                            </div>
                        </div>
                        <hr />
                    <asp:GridView ID="grvPagaduria" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                    <hr />
                </fieldset>
          </div>
    </div>
   </div>
    <div id="tabs-2">
       <div class="row">
        <div class="col-md-4"></div>
            <div class="col-md-4">
                <h3>Novedades</h3>
            </div>
        <div class="col-md-4"></div>
      </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Convenio</legend>
                <div class="row">
                    <div class="col-md-4">
                         <asp:Label ID="lblCodigo" runat="server" Font-Bold="true"  CssClass="labels" Text="Codigo"></asp:Label>
                                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblResponsableAprovacion" runat="server" Font-Bold="true"  CssClass="labels" Text="Responsable aporbación"></asp:Label>
                                    <asp:TextBox ID="txtResponsableAprovacion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblFechaAprovacion" runat="server" Font-Bold="true"  CssClass="labels" Text="Fecha aprobación"></asp:Label>
                                    <asp:TextBox ID="txtFechaAprovacion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-1">
                        <asp:CheckBox ID="chkMensual" runat="server"  Text="Mes"/>
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkBimestral" runat="server" Text="Bimestral"/>
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkTrimestral" runat="server" Text="Trimestral" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkSemestral" runat="server" Text="Semestral" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkAnual" runat="server" Text="Catorcenal" />
                    </div>
                    <div class="col-md-2">
                        <asp:CheckBox ID="chkProrrateo" runat="server" Text="Prorrateo" />
                    </div>
                    <div class="col-md-1">
                        <asp:CheckBox ID="chkCatorcenal" runat="server" Text="Anual" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnAceptar" CssClass="btn btn-primary" Text="ACEPTAR" runat="server" />
                    </div>
                </div>
              </fieldset>
            </div>
        </div>
    </div>
    <div id="tabs-3">
         <div class="row">
        <div class="col-md-4"></div>
            <div class="col-md-4">
                <h3>Novedades</h3>
            </div>
        <div class="col-md-4"></div>
      </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <fieldset>
                        <legend>Configuración novedades</legend>
                        <center><h3>Generar reportes</h3></center>
                        <div class="col-md-3">
                            <h4>Tipo archivo</h4>
                            <asp:CheckBox ID="chkNovedades" runat="server" Text="Novedades" />
                            <br />
                            <asp:CheckBox ID="chkCuentaCobro" runat="server" Text="Cuenta cobro" />
                        </div>
                         <div class="col-md-2">
                            <h4>Opción 1</h4>
                            <asp:CheckBox ID="chkPorConvenio" runat="server" Text="por convenio" />
                            <br />
                            <asp:CheckBox ID="chkPorPagaduria" runat="server" Text="Por pagaduria" />
                        </div>
                         <div class="col-md-2">
                            <h4>Producto</h4>
                            <asp:CheckBox ID="chkPorProducto" runat="server" Text="Por producto" />
                            <br />
                            <asp:CheckBox ID="chkTodosLosProductos" runat="server" Text="Todos los productos" />
                        </div>
                         <div class="col-md-3">
                            <h4>Tipo reporte</h4>
                            <asp:CheckBox ID="chkIngresoModificacionRetiro" runat="server" Text="Ingreso-Modificación-Retiro"/>
                            <br />
                            <asp:CheckBox ID="chkIngresoRetiro" runat="server" Text="Ingreso-Retiro" />
                             <br />
                            <asp:CheckBox ID="chkClientesTotalesVigentes" runat="server" Text="Clientes totales (Vigentes)" />
                        </div>
                         <div class="col-md-2">
                            <h4>Valor a reportar</h4>
                            <asp:CheckBox ID="chkValorTotal" runat="server" Text="Valor total" />
                            <br />
                            <asp:CheckBox ID="chkSoloNovedad" runat="server" Text="Solo novedad" />
                             <br />
                            <asp:CheckBox ID="chkRetiro" runat="server" Text="Retiro" />
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</div>
 <script src="../scripts/jquery-1.11.2.min.js"></script>
 <script src="../scripts/bootstrap.min.js"></script>
 <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
  </script>
</asp:Content>

