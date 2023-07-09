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
                Session.Add("selectedUser", Creador);

                List<Image> img = new List<Image>
                {
                    imgPublicacion,
                    imgP2,
                    imgP3,
                    imgP4
                };

                for (int i = 0; i < img.Count; i++)
                {
                    if (i < artADetallar.imagenes.Count && artADetallar.imagenes[i].Url != null)
                    {
                        img[i].ImageUrl = artADetallar.imagenes[i].Url;
                    }
                    if (img[i].ImageUrl == "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930")
                    {
                        img[i].Visible = false;
                    }
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