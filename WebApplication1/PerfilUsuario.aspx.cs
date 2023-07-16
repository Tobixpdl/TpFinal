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
        public List<Comentario> ListaComentariosFinales { get; set; }
        NegocioUsuario negocioUser = new NegocioUsuario();
        NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
        NegocioComentarios negocioComentarios = new NegocioComentarios();
        public List<Publicacion> carritoActual { get; set; }
        public List<Comentario> listComentarios { get; set; }
        public Usuario usuario { get; set; }
        public Usuario SelectedUser { get; set; }
        public int cantidadDeCompradores;
        public string SelecUser;

        public Usuario user = new Usuario();

        public float reputacion;
        public int compradores;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            SelectedUser = negocioUser.ListarXUsuario(Request.QueryString["User"]);

            UsuarioNombre.Text = SelectedUser.usuario;

            List<Publicacion> publicaciones = negocioPublicacion.ListarXCategoriaSinCero(SelectedUser.Id);
            ListaArticulos = publicaciones;

            listComentarios = negocioComentarios.ListarPorUsuario(Request.QueryString["User"]);

            ListaComentariosFinales = negocioComentarios.listarUltimos(Request.QueryString["User"]);

            calcularReputacion();
            cantidadVentas();
              carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();

            if (this.Session["activeUser"] != null)
            {
                string nusuario = this.Session["activeUser"].ToString();
                user.usuario = nusuario;
                user = negocioUser.ListarXUsuario(nusuario);
                carritoActual = negocioPublicacion.listarFavoritos((int)this.Session["idUsuario"]);
                this.Session.Add("listaDeCompras", carritoActual);
            }

            if (!IsPostBack)
            {
               
                rprComentarios.DataSource = ListaComentariosFinales;
                rprComentarios.DataBind();
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
            //reputacion = negocioComentarios.getRep(SelectedUser.usuario, ref compradores);
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
                    negocioPublicacion.AgregarFavoritos(aux, (int)this.Session["idUsuario"]);
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
        public void calcularReputacion()
        {
            cantidadDeCompradores = ListaComentariosFinales.Count();
            var sumatoria = 0;
            for (int i = 0;i<ListaComentariosFinales.Count();i++)
            {
                sumatoria += ListaComentariosFinales[i].Reputacion;

            }
            if(cantidadDeCompradores!=0)
            {
                reputacion = sumatoria / cantidadDeCompradores;
            }else
            {
                reputacion = sumatoria;
            }
            
        }
        public int cantidadVentas()
        {
            cantidadDeCompradores = ListaComentariosFinales.Count();
            var sumatoria = 0;
            for (int i = 0; i < ListaComentariosFinales.Count(); i++)
            {
                sumatoria += ListaComentariosFinales[i].Reputacion;

            }
            if (cantidadDeCompradores != 0)
            {
                return 0;
            }
            else
            {
               return cantidadDeCompradores;
            }

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
            var imagenes = negocioPublicacion.ListarXId(id).imagenes;

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
    