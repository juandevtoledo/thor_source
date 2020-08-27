<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdjuntarSoportesDevolucion.aspx.cs" Inherits="Presentacion3_AdjuntarSoportesDevolucion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>    
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">

        var host = window.location.host;
        var protocol = window.location.protocol;
        var GB_ROOT_DIR = protocol + "//" + host + "/greybox/";
        
        function VerDevolucion()
      {         
        parent.document.location.href = protocol + "//" + host + "/Presentacion4/DevolucionDePrima2.aspx";        
        parent.parent.GB_hide();
      }    

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <div class="row container " id="ArchivosSporte">
                <div class="col-md-12 ">
                    <br />
                    <asp:TextBox runat="server" ID="txtNomSoporte"
                        class="form-control  " type="text"
                        placeholder="Nombre Soporte"  >
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                            ControlToValidate="txtNomSoporte" ErrorMessage=" [ Diligencie campo ]" ForeColor="Red" 
                                            EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" ValidationGroup="addForm" > 
                                        </asp:RequiredFieldValidator>         
                </div>
                <div class="col-md-12  ">
                    <br /><br />
                    <asp:FileUpload ID="fuCargarArchivosSoporte" runat="server" />                      
                </div>
                <div class="col-md-12 input-sm text-center">
                    <br /><br /><br />
                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary btn-sm "
                        OnClick="btnGuardarArchivo_Click" Text="Guardar" ValidationGroup="addForm" >
                              <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Subir Archivo
                    </asp:LinkButton>
                </div>
                <div class="col-md-12 input-sm text-center">
                <br /><br /><br /><br />
                    <asp:Label ID="lblMsjCarga" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
