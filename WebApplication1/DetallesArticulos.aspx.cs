using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication1
{
    public partial class DetallesArticulos : System.Web.UI.Page
    {
        public Publicacion artADetallar { get; set; }

        public NegocioImagen negocioImg = new NegocioImagen();
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            artADetallar = negocio.ListarXId(Request.QueryString["Id"].ToString());
           

           
            Image img = (Image)imgPublicacion;


            img.ImageUrl = artADetallar.imagenes[0].Url;
        }

        protected void Btn_volver_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx", false);
        }
    }
}