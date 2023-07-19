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
    <li class="list-group-item">Titulo: <%:venta.Titulo%></li>
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

                
    <%if (solicitud==false)
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
    <%}else if(venta.solicitante!=usuarioEmisor.usuario &&venta.Estado!="Entregada")
            {%>
     <div class="mp">
          <div class="card-header" style="background:#5d11f8;color: #ffffff;">     
         <label for="formFile" class="form-label">Han solicitado concluir la venta!</label>
              <ul class="list-group list-group-flush">

                   <li class="list-group-item">
                        <div class="radio-group">
             <asp:RadioButton ID="rbConfirmar" runat="server" Text="Si, quiero confirmar la compra" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbDenegar" runat="server" Text="No, aun no quiero confirmar la compra" TextAlign="Right" GroupName="opcion" />
                    
                            </div> 

                   </li>
    <li class="list-group-item">

         <asp:Button cssclass="btn btn-primary me-md-2" runat="server" ID="btnConfirmarSolicitud" Text="Aceptar" OnClick="btnConfirmarSolicitud_Click"></asp:Button>
    </li>

              </ul>
   
  </div>
           
             

    </div>
    
    
    
    <%}%>
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


 <%if (venta.Estado == "En proceso" || venta.Estado == "En reclamo")
     {  %>
           <div>

           <div class="input-group mb-3">
  
               <asp:TextBox ID="tbMensaje" runat="server" Height="100" MaxLength="500" TextMode="MultiLine" Width="1600" ></asp:TextBox>
               <asp:Button cssclass="btn btn-success" runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>
           <asp:Label ID="lbText1" runat="server" Text="Campo Obligatorio" style="color:red" Visible="false"></asp:Label>
           </div>
</div>
             <%}%>

    </div>
           <%if (venta.finalizada == false) { %>

         


           <%if (venta.UsuarioComprador == usuarioEmisor.usuario )
               {  %>


        
           
 <%if (venta.Estado == "Entregada" ||venta.Estado == "Cancelada"  )
        {  %>
           <div class="Comentario Final">
               <div class="card-header" style="background:#4800ff;color: #ffffff;">
                 <label for="formFile" class="form-label " style="-webkit-text-stroke: 0.1px black;">Comentario Final</label>
                   <div class="campos" style="background:#ffffff;color:#000000">


                 <ul class="list-group list-group-flush"> 
                      <li class="list-group-item">             <asp:Label Text="¿Como fue tu experiencia en esta compra?" runat="server" />                          </li>
                    
                       <li class="list-group-item">
                        <div class="radio-group">

                            <div class="container text-center">

                                 <div class="row">
    <div class="col">
        <div class="row">
         <div class="col">
        <label>Atencion:</label>
        </div>
            <div class="col">
                <div class="col">

        <asp:RadioButton ID="rbAtencionB" runat="server" Text="Buena" TextAlign="Right" GroupName="opcion1" />
                </div>
                <div class="col">
                 <asp:RadioButton ID="rbAtencionM" runat="server" Text="Mala" TextAlign="Right" GroupName="opcion1" />
                    </div>
                 </div>
        </div>
    </div>
    <div class="col">
         <div class="row">
             <div class="col">

        <label>Tiempo:</label>
             </div>
              <div class="col">

 <div class="col">

     <asp:RadioButton ID="rbTiempoB" runat="server" Text="Buena" TextAlign="Right" GroupName="opcion2" />

 </div>
                   <div class="col">

     <asp:RadioButton ID="rbTiempoM" runat="server" Text="Mala" TextAlign="Right" GroupName="opcion2" />

 </div>



              </div>
     
    </div>
         </div>
   <div class="col">
        <div class="row">
         <div class="col">
        <label>Calidad:</label>
        </div>
            <div class="col">
                <div class="col">

        <asp:RadioButton ID="rbCalidadB" runat="server" Text="Buena" TextAlign="Right" GroupName="opcion3" />
                </div>
                <div class="col">
                 <asp:RadioButton ID="rbCalidadM" runat="server" Text="Mala" TextAlign="Right" GroupName="opcion3" />
                    </div>
                 </div>
        </div>
    </div>


  </div>

                            </div>


          
                    
                   
             
                </div> 

                   </li>
                 </ul>  
                   </div> 
                   
                   
                   
                   
                   <div class="input-group mb-3">
  
               <asp:TextBox ID="tbFinal" runat="server" Height="100" MaxLength="500" TextMode="MultiLine" Width="1643" ></asp:TextBox>
               <asp:Button cssclass="btn btn-success" runat="server" ID="btnEnviar2" Text="Enviar" OnClick="btnEnviar2_Click"></asp:Button>
               <asp:Label ID="lbtex2" runat="server" Text="Campo Obligatorio" style="color:red" Visible="false"></asp:Label>

                   </div>
           </div>

                   <%} %>
   <%} %>
                 <% }%>

    <%if (venta.metodo != "Efectivo"  )

        {

%>  <div class="Comprobante">
     <div class="card-header" style="background:#ff6a00;color: #ffffff;">
                 <label for="formFile" class="form-label " style="-webkit-text-stroke: 0.1px black;">Subí el comprobante!</label>

            </div>
               <%if (venta.Estado == "En proceso" ||venta.Estado == "En reclamo"  )
                {

                    %>


                          <asp:FileUpload runat="server" ID="FileUpload1" class="form-control"  />

 <asp:Button CssClass="btn btn-warning" runat="server" ID="Button1" Text="Subir Archivo" OnClick="btnUpload_Click"></asp:Button>



               <%

                } %>
         <%-- <label for="formFile" class="form-label">No hay archivos adjuntados</label>--%>


          </div>


     <div>
         <%if ( venta.urlImagen != "null")
             { %>

  <a class="nav-linkT" href="Comprobante.aspx?UsuarioEmisor=<%:usuarioEmisor.usuario%>&Id=<%:venta.Id%>&Url=<%:venta.urlImagen%>&UsuarioReceptor=<%:usuarioReceptor.usuario%>&PaginaOrigen=<%:origen%>" id="lblUrl">Archivo</a>

<%} %>
           <asp:Label ID="lblWrongTitulo" runat="server" Text="Usted no subio el comprobante aun" style="color:red" Visible="false"></asp:Label>

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












