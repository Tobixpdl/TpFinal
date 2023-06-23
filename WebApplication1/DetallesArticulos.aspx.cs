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
        public Publicacion artADetallar { get; set; }

        public NegocioImagen negocioImg = new NegocioImagen();
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            artADetallar = negocio.ListarXId(Request.QueryString["Id"].ToString());
        }

        protected void Btn_volver_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx", false);
        }
    }
}