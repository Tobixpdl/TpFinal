﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Contacto : System.Web.UI.Page
    {
        public Usuario usuario;
        public Venta venta;
        public int IdVenta;
        public string UrlImagen;
        public List<Comentario> Mensajes;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = Request.QueryString["Usuario"];
            IdVenta = int.Parse(Request.QueryString["Id"]);
            NegocioUsuario negocio = new NegocioUsuario();
            NegocioVentas negocioVenta = new NegocioVentas();
            usuario = negocio.ListarXUsuario(nombre);
            venta = negocioVenta.RV(IdVenta);
            NegocioComentarios nc = new NegocioComentarios();
            Mensajes = nc.Listar(IdVenta);


            
            dgvComentarios.DataSource = Mensajes;
            dgvComentarios.DataBind();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx", false);
        }

   
            protected void btnUpload_Click(object sender, EventArgs e)
            {

       
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string ruta = Server.MapPath("./Images/Receipt/");

                    //FileURL.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    FileUpload1.PostedFile.SaveAs(ruta + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName));
                       UrlImagen = "~/Images/Receipt/" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    NegocioVentas negocio = new NegocioVentas();
                    negocio.AC(IdVenta, UrlImagen);
                    Response.Redirect("Contacto.aspx?Usuario=" + venta.Usuario + "&Id=" + IdVenta, false);

                    /* Image img = (Image)imgPublicacion;
                     img.ImageUrl = finalRuta;*/

                    /* Session.Add("url", finalRuta);
                     Response.Redirect("Crear.aspx", false);*/
                }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

        protected void dgvComentarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(tbMensaje.Text!="")
            {

            NegocioComentarios negocioComentarios = new NegocioComentarios();
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            
            negocioComentarios.newComent(IdVenta,venta.UsuarioVendedor,venta.Usuario,tbMensaje.Text,5);
            Response.Redirect("Contacto.aspx?Usuario=" + venta.Usuario + "&Id=" + IdVenta, false);
            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            NegocioComentarios negocioComentarios = new NegocioComentarios();
            NegocioUsuario negocioUsuario = new NegocioUsuario();

            NegocioVentas nventas = new NegocioVentas();

            
            if (rbEntregado.Checked)
            {
                negocioComentarios.newComent(IdVenta, venta.UsuarioVendedor, venta.Usuario, "Venta Concluida", 10);
                nventas.ME(IdVenta, 2);
                Response.Redirect("Default.aspx", false);
            }
            if (rbEnProceso.Checked)
            {
                negocioComentarios.newComent(IdVenta, venta.UsuarioVendedor, venta.Usuario, "Sigo en la espera del producto", 1);
                nventas.ME(IdVenta, 1);
                Response.Redirect("Contacto.aspx?Usuario=" + venta.Usuario + "&Id=" + IdVenta, false);
            }
            if (rbReclamo.Checked)
            {
                negocioComentarios.newComent(IdVenta, venta.UsuarioVendedor, venta.Usuario, "Hubo un problema", 5);
                nventas.ME(IdVenta, 3);
                Response.Redirect("Contacto.aspx?Usuario=" + venta.Usuario + "&Id=" + IdVenta, false);

            }
            if (rbCancelar.Checked)
            {
                negocioComentarios.newComent(IdVenta, venta.UsuarioVendedor, venta.Usuario, "Voy a Cancelar la Venta", 1);
                nventas.ME(IdVenta, 4);
                Response.Redirect("Contacto.aspx?Usuario=" + venta.Usuario + "&Id=" + IdVenta, false);

            }
        }
    }


}