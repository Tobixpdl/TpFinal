<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApplication1.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="contacto">
                
                  <h3 class="card-title"><%:usuario.usuario%></h3>
                  <h5 class="card-desc">Nombre: <%:usuario.nombre %></h5>
                  <h5 class="card-precio">Telefono: <%:usuario.telefono %></h5>
                   <h5 class="card-cat">Email : <%:usuario.mail %></h5>                 
                 

                 
                  <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Volver" CssClass="btn btn-primary me-md-2" />
             
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















