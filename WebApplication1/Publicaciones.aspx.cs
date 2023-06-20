using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Publicaciones : System.Web.UI.Page
    {

        public List<Publicacion> listaDePublicaciones;
        public int contador { get; set; }
        public int idUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            listaDePublicaciones = new List<Publicacion>();
            NegocioPublicacion negocio= new NegocioPublicacion();
           
                idUsuario = Session["idUsuario"]!=null? (int)Session["idUsuario"] : idUsuario = 0; 
            
        

 
            
           
           
            listaDePublicaciones = negocio.ListarXUsuario(idUsuario);
            contador = listaDePublicaciones.Count;
            dgvArticulos.DataSource = listaDePublicaciones;
            dgvArticulos.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);

        }

      
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx", false);
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
                if (e.CommandName == "Erase")
                {
                NegocioPublicacion negocio = new NegocioPublicacion();
                NegocioImagen negocioImg = new NegocioImagen();
               
                int index = Convert.ToInt32(e.CommandArgument);
                negocioImg.EliminarImagen(listaDePublicaciones[index].Id);
                negocio.EliminarPublicacion(listaDePublicaciones[index].Id);
                Response.Redirect("Publicaciones.aspx", false);

            }/*
                else
                if (e.CommandName == "Erase")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                listaDePublicaciones[index].Cantidad++;
                    Response.Redirect("Carrito.aspx", false);
                }*/

            
        }
    }
}