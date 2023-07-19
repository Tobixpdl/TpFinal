using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Contacto : System.Web.UI.Page
    {
        public Usuario usuarioReceptor;
        public Usuario usuarioEmisor;
        public Venta venta;
        public int IdVenta;
        public string UrlImagen;
        public List<Comentario> Mensajes;
        public string origen;
        EmailService mail = new EmailService();
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        Usuario duenoPublicacion = new Usuario();
        public bool solicitud;
        public string solicitante;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Session["activeUser"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            string emisor = Request.QueryString["UsuarioEmisor"];
            string receptor = Request.QueryString["UsuarioReceptor"];
   
            IdVenta = int.Parse(Request.QueryString["Id"]);
            NegocioUsuario negocio = new NegocioUsuario();
            NegocioVentas negocioVenta = new NegocioVentas();
            usuarioEmisor = negocio.ListarXUsuario(emisor);
            usuarioReceptor = negocio.ListarXUsuario(receptor);
            venta = negocioVenta.RV(IdVenta);
            duenoPublicacion = negocioUsuario.ListarXUsuario(venta.UsuarioVendedor);

            NegocioComentarios nc = new NegocioComentarios();
            Mensajes = nc.Listar(IdVenta);
            solicitud = venta.solicitud;
            solicitante = venta.solicitante;
            dgvComentarios.DataSource = Mensajes;
            dgvComentarios.DataBind();
            origen = Request.QueryString["PaginaOrigen"];


            if (!IsPostBack)
            {
                rbAtencionB.Checked = true;
                rbCalidadB.Checked = true;
                rbTiempoB.Checked = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(origen + ".aspx", false);
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
                    Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);

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
            if (tbMensaje.Text != "")
            {

                NegocioComentarios negocioComentarios = new NegocioComentarios();


                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, tbMensaje.Text, 5);
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            else
            {
                lbText1.Visible = true;
            }

        }


        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            NegocioComentarios negocioComentarios = new NegocioComentarios();

            NegocioVentas nventas = new NegocioVentas();


            if (rbEntregado.Checked)
            {
                if (venta.metodo == "Transferencia Bancaria")
                {
                    if (string.IsNullOrEmpty(venta.urlImagen) || venta.urlImagen != "null")
                    {
                        solicitud = true;
                     
                        solicitante = usuarioEmisor.usuario;
                        nventas.modificarSolicitante(IdVenta, solicitante, solicitud);
                        negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Ha solicitado concluir la venta", 5);
                     

                        Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
                    }
                    else
                    {
                        lblWrongTitulo.Visible = true;
                    }

                }
                else
                {
                    solicitud = true;

                    solicitante = usuarioEmisor.usuario;
                    nventas.modificarSolicitante(IdVenta, solicitante, solicitud);
                    negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Ha solicitado concluir la venta", 5);
                
                    Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
                }

                if (lblWrongTitulo.Visible == false)
                {


                    mail.armarCorreo(duenoPublicacion.mail, "Venta concluida!", "Hola " + duenoPublicacion.usuario + "! "
                        + " Tu producto: " + venta.Titulo + ", fue vendido!", true);
                    mail.enviarEmail();
                }

            }
            if (rbEnProceso.Checked)
            {
                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Sigo en la espera del producto", 1);
                nventas.ME(IdVenta, 1);
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            if (rbReclamo.Checked)
            {
                negocioComentarios.newComent(IdVenta, "Admin", usuarioReceptor.usuario, "Alguien de Administracion se pondra en contacto con los participantes de esta venta y llegaremos a una pronta solución para ambas partes." +
                    "Pueden contactarnos enviando un mail a ayuda.buyeverything@gmail.com o por mensaje telefonico al +549112537-2242", 1);
                nventas.ME(IdVenta, 3);

                mail.armarCorreo(duenoPublicacion.mail, "Un cliente esta reclamando!", "La venta de tu producto: " + venta.Titulo + ", esta en proceso de reclamo.", true);
                mail.enviarEmail();

                mail.armarCorreo(usuarioReceptor.usuario, "Reclamo de " + venta.Titulo, "Haz decidido reclamar por el producto: " + venta.Titulo + ", desde BuyEverything estamos a tu disposición siempre, dinos cual fue tu problema!.", true);
                mail.enviarEmail();

                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            if (rbCancelar.Checked)
            {
                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Voy a Cancelar la Venta", 1);
                nventas.ME(IdVenta, 4);

                NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
                Publicacion publicacion = new Publicacion();
                publicacion = negocioPublicacion.SeleccionarXTitulo(venta.Titulo);
                publicacion.Stock += venta.Cantidad;
                negocioPublicacion.ModificarPublicacion(publicacion);

                mail.armarCorreo(duenoPublicacion.mail, "Una venta fue cancelada!", "La venta de tu producto: " + venta.Titulo + ", fue cancelada.", true);
                mail.enviarEmail();

                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);

            }
        }

        protected void btnEnviar2_Click(object sender, EventArgs e)
        {
            if (tbFinal.Text != "")
            {
                int puntaje = 10;

                NegocioComentarios negocioComentarios = new NegocioComentarios();
                if (rbTiempoM.Checked == true)
                {
                    puntaje -= 3;
                }
                if (rbAtencionM.Checked == true)
                {
                    puntaje -= 3;
                }
                if (rbCalidadM.Checked == true)
                {
                    puntaje -= 3;
                }

                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, tbFinal.Text, puntaje);
                NegocioVentas negocioVentas = new NegocioVentas();
                negocioVentas.finalizarVenta(IdVenta);

                string body = "Por la venta del producto: " + venta.Titulo + ", " + usuarioEmisor.usuario + " te dió un rating de " + puntaje;

                if (puntaje == 10)
                {
                    body += " puntos! Es la perfección, sigue asi!";
                }
                else if (puntaje > 6)
                {
                    body += " puntos! Muy bien hecho!";
                }
                else
                {
                    body += " puntos. Quizás deberias mejorar algunos aspectos en tus ventas.";
                }

                mail.armarCorreo(duenoPublicacion.mail, "Un cliente te ha puntuado!", body, true);
                mail.enviarEmail();

                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            else
            {
                lbtex2.Visible = true;
            }
        }
        protected void btnConfirmarSolicitud_Click(object sender, EventArgs e)
        {
            if (rbConfirmar.Checked == true)
            {
                NegocioComentarios negocioComentarios = new NegocioComentarios();
                NegocioVentas negocioVentas = new NegocioVentas();
                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Venta Concluida", 10);
                negocioVentas.ME(IdVenta, 2);
            }
            if (rbDenegar.Checked == true)
            {
                NegocioComentarios negocioComentarios = new NegocioComentarios();
              
                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Solicitud rechazada, venta en proceso", 10);
                solicitud = false;

                NegocioVentas negocioVentas = new NegocioVentas();
                solicitante = usuarioEmisor.usuario;
                negocioVentas.modificarSolicitante(IdVenta, "null", solicitud);
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
        }
    }
}