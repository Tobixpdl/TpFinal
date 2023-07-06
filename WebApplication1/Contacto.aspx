<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApplication1.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Volver" CssClass="btn btn-primary me-md-2" />
    
    <div class="mp">


                <div class="row justify-content-around">
    <div class="col-4">
      
         <div class="contacto">
   
  
                
      <div class="card" style="width: 25rem;">
           <div class="card-header" style="background:#174ceb;color: #ffffff;">     
    Medios de Comunicacion
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">Nombre de Usuario: <%:usuarioReceptor.usuario%></li>
    <li class="list-group-item">Nombre real: <%:usuarioReceptor.nombre%></li>
    <li class="list-group-item">Telefono del contacto: <%:usuarioReceptor.telefono%></li>
       <li class="list-group-item">Mail del contacto: <%:usuarioReceptor.mail %></li>
  </ul>
</div>

  </div>




    </div>
    <div class="col-4">
     

         <div class="Venta">
                
          <div class="card" style="width: 25rem;">
           <div class="card-header" style="background:#174ceb;color: #ffffff;">     
    Informacion del Producto
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">Titulo: <%:venta.Titulo%>></li>
    <li class="list-group-item">Cantidad: <%:venta.Cantidad %></li>
    <li class="list-group-item">Precio : <%:venta.PrecioFinal %></li>
       <li class="list-group-item">Estado de la venta: <%:venta.Estado %></li>
       <li class="list-group-item">Metodo de Pago : <%:venta.metodo %></li>
  </ul>
</div>

    </div>
  </div> 

                 
                 
             
          </div>  


    </div>

                
    <%if (venta.Estado == "En proceso" ||venta.Estado == "En reclamo"  )
        {  %>
    <div class="mp">
          <div class="card-header" style="background:#5d11f8;color: #ffffff;">     
         <label for="formFile" class="form-label">Actualizar estado de la Venta</label>
              <ul class="list-group list-group-flush">

                   <li class="list-group-item">
                        <div class="radio-group">
             <asp:RadioButton ID="rbEnProceso" runat="server" Text="Aun no lo tengo" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbEntregado" runat="server" Text="El producto ya llegó!" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbReclamo" runat="server" Text="Tuve un problema con la venta." TextAlign="Right" GroupName="opcion" />
             <asp:RadioButton ID="rbCancelar" runat="server" Text="Quiero Cancelar la venta." TextAlign="Right" GroupName="opcion" />
                </div> 

                   </li>
    <li class="list-group-item">

         <asp:Button cssclass="btn btn-primary me-md-2" runat="server" ID="btnConfirmar" Text="Aplicar Cambio" OnClick="btnConfirmar_Click"></asp:Button>
    </li>

              </ul>
   
  </div>
           
             

    </div>
    <%} %>
       <div class="mp">
            <div class="card-header" style="background:#1cbf0f;color: #ffffff;">
                 <label for="formFile" class="form-label " style="-webkit-text-stroke: 0.1px black;">Sala de Chat</label>


            </div>    

        <asp:GridView ID="dgvComentarios" runat="server" OnRowCommand="dgvComentarios_RowCommand" CssClass="table " DataKeyNames="Id" AutoGenerateColumns="false">
             <Columns>  

                 <asp:BoundField  HeaderText="" DataField="Remitente" />
                  <asp:BoundField  HeaderText="Mensaje" DataField="Mensaje" />
                 <asp:BoundField  HeaderText="Fecha" DataField="Fecha" />
                
             </Columns>



        </asp:GridView>

           <div class="cp"> 


 <%if (venta.Estado == "En proceso" ||venta.Estado == "En reclamo"  )
        {  %>
           <div>

           <div class="input-group mb-3">
  
               <asp:TextBox ID="tbMensaje" runat="server" Height="100" MaxLength="500" TextMode="MultiLine" Width="1600" ></asp:TextBox>
               <asp:Button cssclass="btn btn-success" runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>
           </div>
</div>
             <%} %>

    </div>
    <%if (venta.metodo != "Efectivo")

        {  %>


     <div class="Comprobante">
                    <div class="card-header" style="background:#ff6a00;color: #ffffff;">
                 <label for="formFile" class="form-label " style="-webkit-text-stroke: 0.1px black;">Subí el comprobante!</label>

            </div>    
                          <asp:FileUpload runat="server" ID="FileUpload1" class="form-control"  />
  
 <asp:Button CssClass="btn btn-warning" runat="server" ID="Button1" Text="Subir Archivo" OnClick="btnUpload_Click"></asp:Button>
         <%-- <label for="formFile" class="form-label">No hay archivos adjuntados</label>--%>
                   
        
   
          </div>  


     <div>
         <%if ( venta.urlImagen != "null")
             { %>
         
  <a class="nav-linkT" href="Comprobante.aspx?UsuarioEmisor=<%:usuarioEmisor.usuario%>&Id=<%:venta.Id%>&Url=<%:venta.urlImagen%>&UsuarioReceptor=<%:usuarioReceptor.usuario%>" id="lblUrl">Archivo</a>

<%} %>
         </div>
     <%}
         else
         { %>
    
           <%} %>
 

           </div>















        <style>


body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
   

}
.send{


}
    </style>
</asp:Content>















