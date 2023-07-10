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
            
            NegocioComentarios nc = new NegocioComentarios();
            Mensajes = nc.Listar(IdVenta);

            dgvComentarios.DataSource = Mensajes;
            dgvComentarios.DataBind();
            origen = Request.QueryString["PaginaOrigen"];
            

            if(!IsPostBack)
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
                    Response.Redirect("Contacto.aspx?UsuarioReceptor="+usuarioReceptor.usuario+"&Id="+IdVenta+"&UsuarioEmisor="+usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
                   
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
            
            negocioComentarios.newComent(IdVenta,usuarioEmisor.usuario,usuarioReceptor.usuario,tbMensaje.Text,5);
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
            NegocioUsuario negocioUsuario = new NegocioUsuario();

            NegocioVentas nventas = new NegocioVentas();

            
            if (rbEntregado.Checked)
            {
                if(venta.metodo == "Transferencia Bancaria")
                {
                    if(string.IsNullOrEmpty(venta.urlImagen) || venta.urlImagen != "null")
                    {
                        negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Venta Concluida", 10);
                        nventas.ME(IdVenta, 2);
                        Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
                    }
                    else
                    {
                        lblWrongTitulo.Visible = true;
                    }

                }else
                {
                    negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario, "Venta Concluida", 10);
                    nventas.ME(IdVenta, 2);
                    Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
                }
                
            }
            if (rbEnProceso.Checked)
            {
                negocioComentarios.newComent(IdVenta, usuarioEmisor.usuario, usuarioReceptor.usuario,"Sigo en la espera del producto", 1);
                nventas.ME(IdVenta, 1);
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            if (rbReclamo.Checked)
            {
                negocioComentarios.newComent(IdVenta,"Admin", usuarioReceptor.usuario, "Alguien de Administracion se pondra en contacto con los participantes de esta venta y llegaremos a una pronta solucion para ambas partes." +
                    "Pueden contactarnos enviando un mail a ayuda.buyeverything@gmail.com o por mensaje telefonico al +549112537-2242", 1);
                nventas.ME(IdVenta, 3);
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
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);

            }
        }

        protected void btnEnviar2_Click(object sender, EventArgs e)
        {
            if (tbFinal.Text != "")
            {
                int puntaje = 10;

                NegocioComentarios negocioComentarios = new NegocioComentarios();
                NegocioUsuario negocioUsuario = new NegocioUsuario();
               if(rbTiempoM.Checked==true)
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
                Response.Redirect("Contacto.aspx?UsuarioReceptor=" + usuarioReceptor.usuario + "&Id=" + IdVenta + "&UsuarioEmisor=" + usuarioEmisor.usuario + "&PaginaOrigen=" + origen, false);
            }
            else
            {
                lbtex2.Visible = true;
            }
        }
    }


}