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
    }
}