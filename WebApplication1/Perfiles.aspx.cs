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
    public partial class Perfiles : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }

        NegocioUsuario usuarios = new NegocioUsuario();

        public List<Publicacion> ListaPublicaciones { get; set; }

        NegocioPublicacion negocio = new NegocioPublicacion();

        public int UsuarioActual { get; set; }

        public NegocioImagen negocioImg = new NegocioImagen();

        public string creador;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                rptUsuarios.ItemDataBound += rptUsuarios_ItemDataBound;


                ListaUsuarios = usuarios.Listar();
                rptUsuarios.DataSource = ListaUsuarios;
                rptUsuarios.DataBind();

            }
      


        }


        protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rprCards = (Repeater)e.Item.FindControl("rprCards");

                Usuario usuario = (Usuario)e.Item.DataItem;
                creador = usuario.usuario;

                rprCards.DataSource = negocio.ListarXUsuario(usuario.Id);
                rprCards.DataBind();
            }
        }



        protected void btnPublicaciones_Click(object sender, EventArgs e)
        {
            //Session.Add("idUsuario", carritoActual);
            Response.Redirect("Publicaciones.aspx", false);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Session.Add("idUsuario", carritoActual);
            Response.Redirect("Publicaciones.aspx", false);
        }
        protected void imgPublicacion_PreRender(object sender, EventArgs e)
        {
        }

        protected string ReturnUrl(object oItem)
        {
            string id = (DataBinder.Eval(oItem, "Id")).ToString();
            NegocioPublicacion negocio = new NegocioPublicacion();
            var imagenes = negocio.ListarXId(id).imagenes;

            if (imagenes != null && imagenes.Count > 0)
            {
                return imagenes[0].Url;
            }
            return string.Empty;
        }

    }

}

