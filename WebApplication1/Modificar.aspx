<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="WebApplication1.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Volver" />  
     <div class="container2">
         <div class="mp">

         <div class="col-12">

              <div class="row">

                  <div class="col-8">

                       <div class="mb-3">
                    <div class="tl">
                    Modifiar

                      </div>
              
              <div class="mb-3">
                         <asp:Label runat="server" ID="lblTitulo" PlaceHolder="¿Qué vas a vender?" Text="Título:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtTitulo"  Width="600" ></asp:TextBox> 
                 <asp:Label runat="server" style="color:red" > (*)</asp:Label>  
                    </div>
                            <div class="mb-3">
                                 <asp:Label ID="lblWrongTitulo" runat="server" Text="Completar Campo" style="color:red"></asp:Label>
                                 <asp:Label runat="server" ID="lblDesc" Text="Descripción:" PlaceHolder="¿Qué características tiene?"></asp:Label>
                 
                                </div>
               <div class="mb-3">
                   
                    <asp:TextBox runat="server" ID="txtDescripcion"  Height="100" MaxLength="500" TextMode="MultiLine" Width="500"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                       <asp:label runat="server" id="lblstock"  placeholder="¿cuántos hay?" text="Cantidad:"></asp:label>
                    <asp:textbox runat="server" id="txtstock" type="number" CssClass="stockBox" min="1" ></asp:textbox>  <asp:Label runat="server" style="color:red" > (*)</asp:Label>
                            <asp:Label ID="lblWrongStock" runat="server" Text="Completar Campo" style="color:red"></asp:Label>
                         </div>
               <div class="mb-3">
                    <asp:Label runat="server" ID="lblPrecio" Text="Precio: $" PlaceHolder="¿A qué precio lo vendes?"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPrecio" TextMode="Number" ></asp:TextBox>
                        <asp:Label ID="lblWrongPrecio" runat="server" Text="Completar Campo" style="color:red"></asp:Label>
                         </div>

           <asp:UpdatePanel runat="server">
             <ContentTemplate> 
                  <div class="mb-3">
 
                   <asp:Label runat="server" ID="lblCat" Text="¿A qué Categoria pertenece?" ></asp:Label>
     <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="btn btn-danger dropdown-toggle dropdown-toggle-split" style="background:#b200ff"
         AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
     
         </asp:DropDownList>
          </div>
        </ContentTemplate>
    </asp:UpdatePanel>

                 </div>
                         <div class="mb-3">
                    <asp:Button runat="server" ID="btnModificar" Text="Modificar Publicacíon" OnClick="btnModificar_Click"></asp:Button>

               </div> 
                              <asp:Label runat="server" style="color:red" > Campo Obligatorio(*)</asp:Label>
            </div>
                    <div class="col-4" >
   <div class="tl">
                    Imagenes

                      </div>
                        
          


                <div class="mb-3">
  
     <label for="formFile" class="form-label">Subi tu imagen!</label>
     <asp:FileUpload runat="server" ID="url" class="form-control"  />
  
 <asp:Button runat="server" ID="btnUpload" Text="Cargar Imagen" OnClick="btnUpload_Click"></asp:Button>
              
                       
</div>
                            <asp:Label ID="lblWrongImg" runat="server" Text="No has seleccionado ninguna imagen"  style="color:red"></asp:Label>
               <asp:Label ID="lblWrongFormato" runat="server" Text="Formato Invalido"  style="color:red"></asp:Label>    
                        <asp:Image ID="imgPublicacion" runat="server" 
                           CssClass="img-fluid mb-3"
                            
                           />

                        

                          
            </div>    

                                        
                                

            
          
           
                
              
           

              </div>




         </div>
         </div>
            

            </div>

      <style>
        body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
   

}
    </style>
</asp:Content>
