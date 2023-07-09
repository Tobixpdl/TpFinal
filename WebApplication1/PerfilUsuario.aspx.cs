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
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        public List<Publicacion> ListaArticulos { get; set; }
        public List<Publicacion> ListaArticulosFeatured { get; set; }
        public List<Comentario> ListaComentarios { get; set; }
        NegocioUsuario negocioUser = new NegocioUsuario();
        NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
        public List<Publicacion> carritoActual { get; set; }
        public Usuario usuario { get; set; }
        public Usuario SelectedUser { get; set; }
        public int cantidadDeCompradores;
        public string SelecUser;
        public NegocioPublicacion negocio = new NegocioPublicacion();

        public Usuario user = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
          

             
            SelectedUser = negocioUser.ListarXUsuario(Request.QueryString["User"]);

            UsuarioNombre.Text = SelectedUser.usuario;

            List<Publicacion> publicaciones = negocioPublicacion.ListarXUsuarioSinCero(SelectedUser.Id);
            ListaArticulos = publicaciones;

            carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();

            if (this.Session["activeUser"] != null)
            {
                string nusuario = this.Session["activeUser"].ToString();
                user.usuario = nusuario;
                user = negocioUser.ListarXUsuario(nusuario);
                carritoActual = negocio.listarFavoritos((int)this.Session["idUsuario"]);
                this.Session.Add("listaDeCompras", carritoActual);
            }

            if (!IsPostBack)
            {
            rprCards.DataSource = ListaArticulos;
            rprCards.DataBind();
                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUser.ListarXUsuario(nusuario);
                }
            }
            else
            {
                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUser.ListarXUsuario(nusuario);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Button btnAdd = (Button)sender;
            btnAdd.Enabled = false;

            string valor = ((Button)sender).CommandArgument;
            var aux = buscarArticulo(valor);

            if (user.Id != aux.Id_Usuario)
            {
                if (!ContainsArticulo(aux))
                {
                    negocio.AgregarFavoritos(aux, (int)this.Session["idUsuario"]);
                    carritoActual.Add(buscarArticulo(valor));
                }


                
            }
            else
            {
                string script = "alert('No puede hacer esto.');";
                ClientScript.RegisterStartupScript(this.GetType(), "NoPuedeHacerEsto", script, true);
            }


        }
        public bool ContainsArticulo(Publicacion p)
        {
            foreach (Publicacion pu in carritoActual)
            {
                if (pu.Id == p.Id)
                {
                    return true;
                }
            }

            return false;
        }
        public Publicacion buscarArticulo(string id)
        {
            Publicacion aux = new Publicacion();
            int val = 0;
            bool numero = int.TryParse(id, out val);
            foreach (var item in ListaArticulos)
            {
                if (item.Id == val)
                {
                    aux = item;

                }
            }
            return aux;
        }

        protected void btnCarro_Click(object sender, EventArgs e)
        {
            Session.Add("listaDeCompras", carritoActual);
            Response.Redirect("Carrito.aspx", false);

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
        protected void imgPublicacion_PreRender(object sender, EventArgs e)
        {

        }

    }
}
    