<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApplication1.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Volver" CssClass="btn btn-primary me-md-2" />
    <div class="contacto">
                
                  <h3 class="card-title"><%:usuario.usuario%></h3>
                  <h5 class="card-desc">Nombre: <%:usuario.nombre %></h5>
                  <h5 class="card-precio">Telefono: <%:usuario.telefono %></h5>
                   <h5 class="card-cat">Email : <%:usuario.mail %></h5>                 
                 

                 
                 
             
          </div>   
     <div class="Venta">
                
                  <h3 class="card-title"><%:venta.Titulo%></h3>
                  <h5 class="card-desc">Estado: <%:venta.Estado %></h5>
                  <h5 class="card-precio">Cantidad: <%:venta.Cantidad %></h5>
                   <h5 class="card-cat">Precio : <%:venta.PrecioFinal %></h5> 
                   <h5 class="card-cat">Metodo de Pago : <%:venta.metodo %></h5>  
                 

                 
                 
             
          </div>  
    <%if (venta.Estado == "En proceso" ||venta.Estado == "En reclamo"  )
        {  %>
    <div class="Estado">
         <label for="formFile" class="form-label">Actualizar estado de la Venta</label>
         <div class="radio-group">
             <asp:RadioButton ID="rbEnProceso" runat="server" Text="Aun no lo tengo" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbEntregado" runat="server" Text="El producto ya llegó!" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbReclamo" runat="server" Text="Tuve un problema con la venta." TextAlign="Right" GroupName="opcion" />
             <asp:RadioButton ID="rbCancelar" runat="server" Text="Quiero Cancelar la venta." TextAlign="Right" GroupName="opcion" />
              <asp:Button runat="server" ID="btnConfirmar" Text="Aplicar Cambio" OnClick="btnConfirmar_Click"></asp:Button>
                </div>    

    </div>
    <%} %>
       <div class="Mensajes">

        <asp:GridView ID="dgvComentarios" runat="server" OnRowCommand="dgvComentarios_RowCommand" CssClass="table " DataKeyNames="Id" AutoGenerateColumns="false">
             <Columns>  

                 <asp:BoundField  HeaderText="" DataField="Remitente" />
                  <asp:BoundField  HeaderText="Mensaje" DataField="Mensaje" />
                 <asp:BoundField  HeaderText="Fecha" DataField="Fecha" />
                
             </Columns>



        </asp:GridView>
 <%if (venta.Estado == "En proceso" ||venta.Estado == "En reclamo"  )
        {  %>
           <div>

           <div class="input-group mb-3">
  
               <asp:TextBox ID="tbMensaje" runat="server"></asp:TextBox>
               <asp:Button cssclas="btn btn-outline-secondary" runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>
           </div>
</div>
             <%} %>

    </div>
    <%if (venta.metodo != "Efectivo")
 
        {  %>

     <div class="Comprobante">
                
                    <label for="formFile" class="form-label">Subí el comprobante!</label>
        
   
          </div>  
         <%if (venta.urlImagen == "")
             {%>

      <asp:FileUpload runat="server" ID="FileUpload1" class="form-control"  />
  
 <asp:Button runat="server" ID="Button1" Text="Subir Archivo" OnClick="btnUpload_Click"></asp:Button>
     <div><%} else
{  %>
 <a class="nav-linkT" href="Comprobante.aspx?Usuario=<%:usuario.usuario%>&Id=<%:venta.Id%>&Url=<%:venta.urlImagen%>" id="lblUrl">Archivo</a>

         </div>
     <%} %>
    <%} %>
















        <style>


body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
   

}
    </style>
</asp:Content>















