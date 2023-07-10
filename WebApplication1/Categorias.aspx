<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="WebApplication1.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <h1>Todas las categorias</h1>
     <div class="row ">
       <div class="col-12" >
             <h1></h1>
              <div class="cp">
     <asp:GridView ID="dgvCategorias" runat="server" OnRowCommand="dgvCategorias_RowCommand" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" >
               <Columns>

                   <%--<asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />--%>
                    <asp:BoundField  HeaderText="ID" DataField="Id" />
                    <asp:BoundField  HeaderText="Nombre" DataField="Nombre" />
                   <asp:ButtonField  ButtonType="Button"
                    commandname="Erase" 
                    headertext="Acciones" 
                    text="Eliminar"  />
                   
               </Columns>
     </asp:GridView>
                  <div class="labelContainer">
                      <asp:Label ID="lblAviso" runat="server" Text="Hay al menos una publicacion con esta categoria" CssClass="lblCat"></asp:Label>
                  </div>
                  <div class="inputContainer">
                      <asp:Button ID="btnAddCategoria" OnClick="btnAddCategoria_Click" runat="server" CssClass="btnCat" Text="Agregar Categoria" />
                      <asp:TextBox ID="txtNuevaCategoria" runat="server"></asp:TextBox>
                      <asp:Button ID="btnAddedCategoria" OnClick="btnAddedCategoria_Click" CssClass="btnCat" runat="server" Text="Agregar" />
                  </div>
              </div>
       </div>
     </div>
    <style>
        body {
            background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
            background-repeat: no-repeat;
            width: 1920px;
            height: 1080px;
        }

        .row{
            height:80vh;
        }

        .labelContainer {
            text-align: center;
            margin-bottom: 10px;
        }

        .lblCat{
            color: red;
        }

        .btnContent {
            margin-right: 10px;
        }

        .inputContainer {
            display: flex;
            align-items: center;
        }

            .inputContainer .btnCat {
                margin-left: 10px;
            }

    </style>
  
    



</asp:Content>
