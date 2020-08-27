


function esInteger(e)
{
    var charCode;
            
    if (navigator.appName == "Netscape")
        charCode = e.which;
    else
        charCode = e.keyCode;
                
    if ((charCode < 48) || (charCode > 57))
        return false;
    else
        return true;
}

function ValidarNumero(Valor)
{
    if (isNaN(Valor))                 
        return false;
            
    dotpos=Valor.indexOf(".");	
    if (dotpos>0)	            	                
        return false;
    else                    
        return true;
             
}
         
function ValidarTamañoSuperior(Valor,numChar)
{
    if(Valor.length > numChar)
        return true;
    else
        return false;
                           
}  
        
function ValidarListaSeleccion(oSrc, args)
{
    //selectedIndex <= 0
    
    /*if (args.Value <= 0)
        alert("Seleccione Opción");*/

    args.IsValid = (args.Value > 0);                
}         
                 
                
function ValidarDocumento(oSrc, args)
{
            
    //alert(ValidarNumero(args.Value).toString());
        
    if (!ValidarNumero(args.Value))
    {
        args.IsValid = false;                                    
        return;
    }
            
            
    if (!ValidarTamañoSuperior(args.Value,5))
    {
        args.IsValid = false; 
        return;
    }
                    
    args.IsValid = true
            
}   
        
function ValidarTelefono(oSrc, args)
{            
    if (!ValidarNumero(args.Value))
    {
        args.IsValid = false;                                    
        return;
    }            
            
    if (!ValidarTamañoSuperior(args.Value,6))
    {
        args.IsValid = false; 
        return;
    }
                    
    args.IsValid = true
}    
        
function ValidarCelular(oSrc, args)
{            
    if (args.Value.charAt(0) != '3')
    {
        args.IsValid = false;
        return;
    }
            
    if (!ValidarNumero(args.Value))
    {
        args.IsValid = false;                                    
        return;
    }            
            
    if (!ValidarTamañoSuperior(args.Value,9))
    {
        args.IsValid = false; 
        return;
    }
                    
    args.IsValid = true
}
        
        

