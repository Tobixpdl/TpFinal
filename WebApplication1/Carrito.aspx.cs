using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Carrito : System.Web.UI.Page
    {

        public List<Publicacion> listaDeCompras;
        public int contador { get; set; }
        public int cantidad = 1;
        public decimal precioPorCantidad = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            listaDeCompras = new List<Publicacion>();
            listaDeCompras = (List<Publicacion>)Session["listaDeCompras"];


            contador = listaDeCompras != null ? listaDeCompras.Count : 0;


            if (contador != 0)
            {

                decimal acum = 0;
                //int envio = new Random().Next(800, 1800);

                foreach (var item in listaDeCompras)
                {
                    acum += item.Precio * item.Cantidad;

                }
                rprCards.DataSource = listaDeCompras;
                rprCards.DataBind();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);

        }

        protected void btnErase_Click(object sender, EventArgs e)
        {
            this.Session.Add("listaDeCompras", null);
            Response.Redirect("Carrito.aspx", false);
        }
        protected decimal CastPriceType(object oItem)
        {
            decimal precio = (decimal)DataBinder.Eval(oItem, "Precio") * (int)DataBinder.Eval(oItem, "Cantidad");

            // rest of your code
            return precio;
        }
        protected string ReturnCant(object oItem)
        {
            string cantidad = (DataBinder.Eval(oItem, "Cantidad")).ToString();

            // rest of your code
            return cantidad;
        }

        protected void rprCards_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Minus")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (listaDeCompras[index].Cantidad <= 1)
                {
                    listaDeCompras.RemoveAt(index);
                }
                else
                {
                    listaDeCompras[index].Cantidad--;
                }

                Response.Redirect("Carrito.aspx", false);
            }
            else
            if (e.CommandName == "Plus")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                listaDeCompras[index].Cantidad++;
                Response.Redirect("Carrito.aspx", false);
            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
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