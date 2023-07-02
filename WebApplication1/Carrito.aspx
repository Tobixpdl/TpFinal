<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApplication1.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
  <div class="row border border-dark-subtle">
  <div class="col-12 " style="background:#0094ff;text-align:center;">
      
   
      <%if (contador == 0)
        {
%>
      <h1>No hay elementos favoritos</h1>
      <asp:Button ID="btnIrADefault" runat="server" OnClick="btnBack_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Continuar Comprando" />  
    <% }
        else
        {  %>
        

             <section class="articulos">
                <div class="mega-main">
                        <div class="main">
                            <h2 class="titleT">Todos los productos</h2>
                            <div class="container-items">
                            <asp:Repeater ID="rprCards" runat="server">
                             <ItemTemplate>
			                            <div class="item">
				                            <figure>
					                             <asp:Image ID="imgPublicacion" runat="server" 
                                                 CssClass="img-" ImageUrl=<%#ReturnUrl(Container.DataItem)%>/>                                                                          
				                            </figure>
				                            <div class="info-product">
                                                <h2 class="info-title"><%#Eval("Titulo")%></h2>
					                            <p class="price">$<%#Eval("Precio")%></p>
                                                <asp:Button ID="btnAdd" runat="server"  CssClass="btn-info" OnClick="btnComprar_Click" type="button" Text="Comprar" 
                                                CommandArgument ='<% #Eval("Id")%>' CommandName="artId" />
                                                <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-info">Ver detalles</a>
                                            </div>
			                           </div>
                              </ItemTemplate>
                            </asp:Repeater>
                          </div>
                         </div>
                    </div>
                </section>

       <asp:UpdatePanel runat="server">
         <ContentTemplate>

              <%--   <h1>Favoritos</h1>
     <div class="row">
               <div class="col-8" style="text-align:center">       
                     <h2></h2>
              
                   <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="dgvArticulos_RowCommand">
               
                       <Columns>                   
                           <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                           <asp:BoundField  HeaderText="Precio" DataField="Precio" />
                           
                             <asp:ButtonField buttontype="Button" 
                                commandname="Minus" 
                                headertext="" 
                                text="-"
                              />

                            <asp:TemplateField HeaderText="Cantidad">
                               <ItemTemplate>                    
                                 <asp:Label runat="server" ID="lblCantidad" ><%#ReturnCant(Container.DataItem)%> </asp:Label>       
                               </ItemTemplate>
                           </asp:TemplateField>
                 
                             <asp:buttonfield buttontype="Button" 
                                commandname="Plus"
                                headertext="" 
                                text="+" 
                             />             

                            <asp:TemplateField HeaderText="Total" >
                               <ItemTemplate>
                                   <asp:Label ID="lblTotal" runat="server"  ><%#CastPriceType(Container.DataItem)%> </asp:Label>
                               </ItemTemplate>
                             </asp:TemplateField>       
                       </Columns>

                        </asp:GridView>
                           <div class="vaciar" >
                               <asp:Button ID="btnErase" runat="server" OnClick="btnErase_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Vaciar Carro" /> 
                           </div>
            
               </div>

               <div class="col-4" >
                     <div>
                         <p>Tienes un cupon de descuento?</p>
                 
                          <div class="input-group mb-3" style="margin-left:80px" >
                          <asp:TextBox runat="server" type="text"  ID="tbCupon"   ></asp:TextBox>
                          <asp:Button runat="server"  type="button" id="btnCheckCupon" Text="Agregar" OnClick="btnCheckCupon_Click"></asp:Button>
                         </div>
                     </div>

                     <asp:ScriptManager runat="server">
                     </asp:ScriptManager>
    
                    <div class="row"style="margin-left:20px">
                        <div class="col-sm-11">
                            <asp:GridView ID="dgvMontos" runat="server" CssClass="table"></asp:GridView>    
                        </div>

                        <div class="col-sm-11" >
                           <p class="resultado"> Total</p>
                           <asp:Label ID="lblTotal" runat="server" ></asp:Label>    
                           <asp:Button runat="server" ID="btnComprar" Text="Comprar" OnClick="btnComprar_Click"></asp:Button>
                        </div>
                   </div>
             </div>
  </div>--%>
             </ContentTemplate>
             </asp:UpdatePanel>
 
    <%} %>

    </div>
  </div>
</div> 


    


 
  

    
</asp:Content>

