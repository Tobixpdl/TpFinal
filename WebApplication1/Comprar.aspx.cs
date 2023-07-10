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

        public Publicacion listaDeCompras;
        public Usuario usuarioCompra;
        public Usuario usuarioVenta;
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            string id = Request.QueryString["Id"];
            listaDeCompras = negocio.ListarXId(id);
            usuarioCompra = negocioUsuario.ListarXUsuario(Session["activeUser"].ToString());
            usuarioVenta = negocioUsuario.ListarXUsuario(listaDeCompras.Id_Usuario);



            if (!IsPostBack)
            {
                TotalLiteral.Text = listaDeCompras.Precio.ToString();
                txtMail.Text = usuarioCompra.mail;
                txtNombre.Text = usuarioCompra.nombre;
                txtStock.Text = "1";
                rbEfectivo.Checked = true;
                TxtDni.Text = usuarioCompra.dni.ToString();
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

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            //Session para agregar los articulos comprados
            //Mandar a la base de datos el estado de la compra (en espera de confirmacion)
            NegocioVentas negocio = new NegocioVentas();
            Venta venta = new Venta();
            venta.DNIComprador = Convert.ToInt32(usuarioCompra.dni);
            venta.DNIVendedor = Convert.ToInt32(usuarioVenta.dni);
            venta.UsuarioComprador = usuarioCompra.usuario;
            venta.UsuarioVendedor = usuarioVenta.usuario;
            venta.Titulo = listaDeCompras.Titulo;
            venta.FechaCompra = DateTime.Now.ToString();
            venta.FechaEntrega = "no entregado";
            venta.finalizada = false;
            string texto = txtStock.Text;
            int cantidad;
            if (int.TryParse(texto, out cantidad))
            {
                venta.Cantidad = cantidad;
            }
            else
            {
                venta.Cantidad = 1;
            }

            venta.PrecioFinal = listaDeCompras.Precio * cantidad;


            if (rbEfectivo.Checked)
            {
                venta.metodo = "e";
            }
            else
            {
                venta.metodo = "t";
            }


            negocio.agregarVenta(venta);
            Publicacion publicacion = new Publicacion();
            NegocioPublicacion negocioP = new NegocioPublicacion();
            string id = Request.QueryString["Id"];
            int vOut = Convert.ToInt32(id);
            publicacion = negocioP.GetPublicacion(vOut);
            publicacion.Stock-=venta.Cantidad;
            negocioP.ModificarPublicacion(publicacion);
            Response.Redirect("MisCompras.aspx",false);

        }

        protected void txtStock_TextChanged(object sender, EventArgs e)
        {
            decimal cantidad = 0;
            if (decimal.TryParse(txtStock.Text, out cantidad))
            {
                decimal precioTotal = cantidad * listaDeCompras.Precio;
                TotalLiteral.Text = precioTotal.ToString();
            }

        }
    }
}