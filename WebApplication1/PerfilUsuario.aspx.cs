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

        NegocioUsuario negocioUser = new NegocioUsuario();
        NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
        public List<Publicacion> carritoActual { get; set; }
        public Usuario usuario { get; set; }
        public Usuario SelectedUser { get; set; }

        public string SelecUser;


        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos = negocioPublicacion.Listar();
            ListaArticulosFeatured = negocioPublicacion.listarFeatured();
            SelecUser = Request.QueryString["User"];
            if (SelecUser != null)
            {
             SelectedUser = negocioUser.ListarXUsuario(SelecUser);
            }

            if (this.Session["selectedUser"] != null)
            {
                string selUser = this.Session["selectedUser"].ToString();
                SelectedUser = negocioUser.ListarXUsuario(selUser);

                Tel.Text = SelectedUser.telefono;
                EMail.Text = SelectedUser.mail;
                UsuarioNombre.Text = SelectedUser.usuario;

                List<Publicacion> publicaciones = negocioPublicacion.ListarXUsuario(SelectedUser.Id);
                ListaArticulos = publicaciones;

                carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();

                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string valor = ((Button)sender).CommandArgument;

            var aux = buscarArticulo(valor);
            var lugar = 0;
            if (ContainsArticulo(valor, ref lugar))
            {
                carritoActual[lugar].Cantidad++;

            }
            else
            {
                carritoActual.Add(buscarArticulo(valor));
            }


            this.Session.Add("listaDeCompras", carritoActual);

            Response.Redirect("Default.aspx", false);

        }
        public bool ContainsArticulo(string id, ref int index)
        {
            bool aux = false;
            int val = 0;
            bool numero = int.TryParse(id, out val);
            for (int i = 0; i < carritoActual.Count; i++)
            {
                if (carritoActual[i].Id == val)
                {
                    aux = true;
                    index = i;
                    return aux;
                }
            }
            return aux;
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
    