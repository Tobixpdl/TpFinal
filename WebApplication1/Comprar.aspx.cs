﻿using dominio;
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

            TotalLiteral.Text = listaDeCompras.Precio.ToString();
            txtMail.Text = usuarioCompra.mail;
            txtNombre.Text = usuarioCompra.nombre;
            txtStock.Text = "1";
            TxtDni.Text = Convert.ToInt32(usuarioCompra.dni).ToString();
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
            DateTime fechaActual = DateTime.Now;
            DateTime fechaFinal = fechaActual.AddDays(14);
            venta.DNIComprador = Convert.ToInt32(usuarioCompra.dni);
            venta.DNIVendedor = Convert.ToInt32(usuarioVenta.dni);
            venta.Usuario = usuarioCompra.usuario;
            venta.Titulo = listaDeCompras.Titulo;
            venta.FechaCompra = fechaActual.ToString();
            venta.FechaCompra = fechaFinal.ToString();
            
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

            negocio.agregarVenta(venta);

        }
    }
}