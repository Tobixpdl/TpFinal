<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comprobante.aspx.cs" Inherits="WebApplication1.Comprobante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


         <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Volver" CssClass="btn btn-primary me-md-2" />

       <asp:Image ID="imgPublicacion" runat="server" 
                           CssClass="img-fluid mb-3"   />
           
    
      
<style>

body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
   

}
    </style>
</asp:Content>
