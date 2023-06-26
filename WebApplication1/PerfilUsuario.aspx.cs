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
        NegocioUsuario negocio = new NegocioUsuario();
        NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
        public List<Publicacion> carritoActual { get; set; }
        string userId = 0.ToString();// Request.QueryString["Id"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    user=negocio.ListarXUsuario(userId);
                    Tel.Text = user.usuario;
                    EMail.Text = user.mail;
                    UsuarioNombre.Text=user.usuario;
                    List < Publicacion> publicaciones = negocioPublicacion.ListarXUsuario(user.Id);

                    Session.Add("idUsuario", 0);
                    ListaArticulos = publicaciones;
                    carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();

                    if (!IsPostBack)
                        {

                            rprCards.DataSource = ListaArticulos;
                            rprCards.DataBind();

                        if (this.Session["activeUser"] != null)
                        {
                            user.usuario = this.Session["activeUser"].ToString();

                        }
                        //}
                        //FiltroAvanzado = false;
                        // ddlCategoria_Llenado(sender, e);
                    }
                    else
                    {

                        if (this.Session["activeUser"] != null)
                        {
                            user.usuario = this.Session["activeUser"].ToString();

                        }

                    }
                    lblCompra.Text = this.Session["listaDeCompras"] != null && ((List<Publicacion>)Session["listaDeCompras"]).Count != 0 ? ((List<Publicacion>)Session["listaDeCompras"]).Count.ToString() : lblCompra.CssClass = "invisible";

                }
                else
                {


                }
                 
                
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
    