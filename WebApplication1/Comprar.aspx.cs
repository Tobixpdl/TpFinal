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
    public partial class Comprar : System.Web.UI.Page
    {

        public List<Publicacion> listaDeCompras;
        protected void Page_Load(object sender, EventArgs e)
        {
            listaDeCompras =(List<Publicacion>)Session["listaDeCompras"];

            RepeaterProductos.DataSource = listaDeCompras;
            RepeaterProductos.DataBind();

            decimal total = 0;

            for(int i=0; i<listaDeCompras.Count; i++)
            {
                total += listaDeCompras[i].Precio;
            }

            TotalLiteral.Text = total.ToString();
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

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            //Session para agregar los articulos comprados
            //Mandar a la base de datos el estado de la compra (en espera de confirmacion)
            
        }
    }
}