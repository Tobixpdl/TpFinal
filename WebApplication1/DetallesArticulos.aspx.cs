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
    public partial class DetallesArticulos : System.Web.UI.Page
    {
        public List<Publicacion> artADetallar { get; set; }
        public Publicacion art { get; set; }

        public List<Imagen> listaImagenes { get; set; }
        public Imagen imagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            artADetallar = negocio.ListarXTitulo(Request.QueryString["Titulo"].ToString());

            art = artADetallar.FirstOrDefault();
            Image img = (Image)imgPublicacion;


            img.ImageUrl = art.imagenes[0].Url;

        }

        protected void Btn_volver_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx", false);

            
        }
    }
}