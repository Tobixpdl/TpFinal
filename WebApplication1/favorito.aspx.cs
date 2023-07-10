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
    public partial class favorito : System.Web.UI.Page
    {
        public List<Publicacion> listaDeCompras;
        public NegocioPublicacion np = new NegocioPublicacion();
        public int contador { get; set; }
        public int cantidad = 1;
        public decimal precioPorCantidad = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            listaDeCompras = new List<Publicacion>();
            if (this.Session["idUsuario"] != null)
            {
                listaDeCompras = np.listarFavoritos((int)this.Session["idUsuario"]);
            }

            contador = listaDeCompras != null ? listaDeCompras.Count : 0;

            if (!IsPostBack)
            {
                rprCards.DataSource = listaDeCompras;
                rprCards.DataBind();
            }
            if (contador != 0)
            {
                //rprCards.DataSource = listaDeCompras;
               // rprCards.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (this.Session["activeUser"] != null)
            {
                Response.Redirect("Comprar.aspx", false);
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {   
            Button btnEliminar = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnEliminar.NamingContainer;
            int posicion = item.ItemIndex;

            var aux = listaDeCompras[posicion];
            np.EliminarFavoritos(aux, (int)this.Session["idUsuario"]);

            Response.Redirect("favorito.aspx",false);

        }

        public Publicacion buscarArticulo(string id)
        {
            Publicacion aux = new Publicacion();
            int val = 0;
            bool numero = int.TryParse(id, out val);
            foreach (var item in listaDeCompras)
            {
                if (item.Id == val)
                {
                    aux = item;

                }
            }
            return aux;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",false);
            
        }
    }

}