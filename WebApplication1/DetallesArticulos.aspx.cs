using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication1
{
    public partial class DetallesArticulos : System.Web.UI.Page
    {
        public Publicacion artADetallar { get; set; }
        public Usuario userDetalle { get; set; }
        
        public NegocioImagen negocioImg = new NegocioImagen();
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            string id = Request.QueryString["Id"];

            NegocioUsuario negocioUser = new NegocioUsuario();
            if (!string.IsNullOrEmpty(id))
            {
                artADetallar = negocio.ListarXId(id);
                userDetalle = negocioUser.ListarXUsuario(artADetallar.Id_Usuario);
                string Creador = userDetalle.usuario;
                this.Session.Add("selectedUser", Creador);

                if (artADetallar != null && artADetallar.imagenes != null && artADetallar.imagenes.Count > 0)
                {
                    Image img = (Image)imgPublicacion;
                    img.ImageUrl = artADetallar.imagenes[0].Url;
                    img.Visible = true; 
                }
                else
                {
                    imgPublicacion.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
                imgPublicacion.Visible = false; 
            }
        }


        protected void Btn_volver_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx", false);
        }
    }
}