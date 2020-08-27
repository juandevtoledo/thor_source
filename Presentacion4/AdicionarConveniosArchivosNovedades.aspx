<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdicionarConveniosArchivosNovedades.aspx.cs"
    Inherits="Presentacion_AdicionarConveniosArchivosNovedades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>:::.... Adicionar Convenios Archivos Novedades ....::: </title>

   
     <script src="/Scripts/jsValidacionesCamposTG.js" ></script>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <script type="text/javascript">

        var host = window.location.host;
        var protocol = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";

        function VerConfigArchivosNovedades()
        {         
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/ConfigurarArchivosNovedades.aspx";
            parent.parent.GB_hide();
        }

        function VerDetallePagaduria() {
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/DetallePagaduria.aspx";
            parent.parent.GB_hide();
        }

        function VerPagadurias() {
            parent.document.location.href = protocol + "//" + host + "/Presentacion4/Pagadurias.aspx";
            parent.parent.GB_hide();
        }

        function SelectAll(Checkbox) {

          var GridVwHeaderChckbox = document.getElementById("<%=grvProductosConvenios.ClientID %>");

          //alert("val: " + GridVwHeaderChckbox.rows.length);
          //alert("val: " + GridVwHeaderChckbox.rows[i].cells[5].textContent);

          for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
              GridVwHeaderChckbox.rows[i].cells[5].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
          }

      }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div >

            


                        <div class="row container text-center " id="titLocProd"  >        
                                
                               
                                <div class="col-md-12   ">
                                    <hr />
                                </div>

                                <div class="col-md-12 text-left ">

                                    <h2 class="panel-title"> <strong> Adicionar Productos Convenio </strong> 
                                    </h2>
                               
                                </div>


                                <div "col-md-12" >                                    
                                    <hr />
                                </div>     

                            </div>

                            


                                   <div class="row container " id="addProductosPorConvenio"   >        
                
                                            <!-- tabla para cosultar todas las pagadurias -->
                                        
                                            <div class="col-xs-12">
                                                
                                                <asp:Label cssClass="labels" Font-Bold="true" ID="lblConvenios" runat="server" > Convenios: </asp:Label>
                                               <br /><br />
                                                <asp:DropDownList ID="ddlConvenios" runat="server"  
                                                   CssClass="form-control input-sm" placesholder="" AutoPostBack="true" 
                                                   OnSelectedIndexChanged="ddlConvenios_SelectedIndexChanged" >
                                               </asp:DropDownList>
                                            </div>

                                            <div class="col-xs-12">

                                                <br />

                                                   <asp:GridView ID="grvProductosConvenios" runat="server" Font-Size="0.9em" 
                                                    DataKeyNames="pro_Id"
                                                    CssClass="table table-bordered table-hover table-striped" 
                                                    AutoGenerateColumns="false" 
                                                    AllowPaging="True" 
                                                     >
                    
                                                   <EmptyDataTemplate>
                                                        <div class="alert alert-warning" role="alert">                                                                 
                                                            <span class="glyphicon glyphicon-alert  "></span> &nbsp; No se han encontrado Productos !!! 
                                                        </div>
                                                    </EmptyDataTemplate>

                                                    <Columns>                                                

                                                        <asp:BoundField DataField="com_Nombre" HeaderText="Compañia" HeaderStyle-VerticalAlign="Middle" />
                                                        
                                                        <asp:TemplateField HeaderText="Id Prod" InsertVisible="False"
                                                             HeaderStyle-VerticalAlign="Middle" >                                           
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIdProd" runat="server" Text='<%# Bind("pro_Id") %>'></asp:Label>
                                                                </ItemTemplate>                                                            
                                                         </asp:TemplateField>  
                                                        
                                                        <asp:BoundField DataField="pro_Nombre" HeaderText="Producto" HeaderStyle-VerticalAlign="Middle" />
                                                        <asp:BoundField DataField="pro_MesesGracia" HeaderText="Meses Gracia" 
                                                            HeaderStyle-VerticalAlign="Middle"  />
                                                        <asp:BoundField DataField="estProd_Format" HeaderText="Estado" HeaderStyle-VerticalAlign="Middle" />
                                                        

                                                        <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" 
                                                             ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" >                  
                                                            
                                                            <HeaderTemplate>                                                                
                                                                <center>
                                                                    <asp:CheckBox ID="chkHeader" runat="server" ToolTip="Seleccionar Todos" 
                                                                        onclick="SelectAll(this);"/>
                                                                    </center>
                                                            </HeaderTemplate>                          

                                                            <ItemTemplate >
                                                                                                                                              
                                                                <asp:CheckBox ID="chkEstSol" runat="server" ToolTip="Seleccionar Producto" 
                                                                    Checked='<%# DeterminarSeleccion(Eval("estSelProd")) %>'  />                                                                                                                  
                                                                        
                                                            </ItemTemplate>                                        
                                                        </asp:TemplateField>

                                                        
                                                    </Columns>
                
                                                </asp:GridView>


                                            </div>

                                        <div class="col-xs-12 text-center" >

                                            <br /><br />

                                            <asp:LinkButton ID="btnFinalizar" runat="server" 
                                                    CssClass="btn btn-success btn-sm"
                                                    OnClick="btnFinalizar_Click" text="Finalizar" >
                                                    <span class="glyphicon glyphicon-log-out"></span>&nbsp;Finalizar Adición
                                            </asp:LinkButton>

                                            &nbsp;&nbsp;&nbsp;

                                            <asp:LinkButton ID="btnGuardarProductosConvenios" runat="server" 
                                                    CssClass="btn btn-primary btn-sm"
                                                    OnClick="GuardarProductosConvenios_Click" text="Guardar Productos" >
                                                    <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Guardar Productos Compañia
                                            </asp:LinkButton>

                                        </div>

                                    </div>

             


        </div>
    </form>
</body>
</html>
