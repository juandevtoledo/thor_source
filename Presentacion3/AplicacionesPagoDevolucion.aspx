<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AplicacionesPagoDevolucion.aspx.cs" Inherits="Presentacion3_AplicacionesPagoDevolucion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/EstilosIndex.css" />
    <link href="/Content/select2/select2-3.5.4/select2.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col col-md-1"></div>
            <div class="col col-md-10">
                <center><h4><asp:Label ID="lblDetalleAplicacion" runat="server" Font-Bold="true"  CssClass="labels" Text="Detalle aplicación pagos"></asp:Label></h4>
                    <asp:GridView ID="grdAplicacionesPagosDevolucion" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                </center>
            </div>
            <div class="col col-md-1"></div>
        </div>
        <div class="row">
          <div class="col col-md-1"></div>
            <div class="col col-md-10">
                 <center><h4><asp:Label ID="lblSoportes" runat="server" Font-Bold="true"  CssClass="labels" Text="Soportes para devolución"></asp:Label></h4>
                <asp:GridView ID="grvArchivosSoporte" runat="server" Font-Size="0.9em" 
                              DataKeyNames="sopdev_Id"
                             CssClass="table table-bordered table-hover table-striped" 
                             AutoGenerateColumns="false" 
                             AllowPaging="True" PageSize="5">
                            <EmptyDataTemplate>
                                <div class="alert alert-warning" role="alert">                                                                 
                                    <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Archivos Soporte !!! 
                                </div>
                            </EmptyDataTemplate>
                            <Columns>                                                
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-VerticalAlign="Middle"
                                        ItemStyle-HorizontalAlign="Center" >                                            
                                    <ItemTemplate >         
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" 
                                                CssClass="btn btn-success btn-xs" 
                                                NavigateUrl='<%# Eval("sopdev_Url") %>'>                                                    
                                                <span class="glyphicon glyphicon-file "> </span>                                                                                                                       
                                                </asp:HyperLink>                                
                                                                                              
                                    </ItemTemplate>                                        
                                </asp:TemplateField>   
                                <asp:BoundField DataField="sopdev_Nombre" HeaderText="Nombre Soporte" />
                                <asp:BoundField DataField="sopdev_Url" HeaderText="Url Soporte" />                       
                            </Columns>
                 </asp:GridView>
               </center>
            </div>
            <div class="col col-md-1"></div>
        </div>
    </form>
</body>
</html>
