<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="WebApplication1.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Volver" />  
     <div class="container2">   
         <div class="col-12 " style="background:#0094ff;text-align:center;">

              <div class="row">

                  <div class="col-8" style="text-align:center">

                       <div class="mb-3">
                    <h2>Nueva Publicacion</h2>
              
              <div class="mb-3">
                        <asp:Label runat="server" ID="lblTitulo" PlaceHolder="¿Qué vas a vender?" Text="Título:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtTitulo"   ></asp:TextBox>      
                    </div>
                            <div class="mb-3">
                                 <asp:Label runat="server" ID="lblDesc" Text="Descripción:" PlaceHolder="¿Qué características tiene?"></asp:Label>
                 
                                </div>
               <div class="mb-3">
                   
                    <asp:TextBox runat="server" ID="txtDescripcion"  Height="100" MaxLength="500" TextMode="MultiLine" Width="500"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                    <asp:label runat="server" id="lblstock"  placeholder="¿cuántos hay?" text="Cantidad:"></asp:label>
                    <asp:textbox runat="server" id="txtstock" ></asp:textbox>
                         </div>
               <div class="mb-3">
                    <asp:Label runat="server" ID="lblPrecio" Text="Precio: $" PlaceHolder="¿A qué precio lo vendes?"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPrecio" TextMode="Number" ></asp:TextBox>
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
                    <asp:Button runat="server" ID="btnCrear" Text="Crear Publicacíon" OnClick="btnCrear_Click"></asp:Button>
               </div> 
            </div>
                    <div class="col-4" >
    <h1> Imagenes </h1>
                        
                                 <div class="mb-3">
  
                                   <label for="formFile" class="form-label">Default file input example</label>
  <input type="file" id="txtImagen" runat="server" class="form-control" />
                       
</div>
                        
                        <asp:Image ID="imgPublicacion" runat="server" 
                           
                            
                           CssClass="img-fluid" />

                         <div class="mb-3">
                    <asp:Button runat="server" ID="btnSubirImagen" Text="Guardar" OnClick="btnSubirImagen_Click"></asp:Button>
               </div> 

                          
            </div>    

            
          
           
                
              
           

              </div>




         </div>
            

            </div>
  
</asp:Content>


