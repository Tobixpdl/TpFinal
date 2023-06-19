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
    public partial class Perfiles : System.Web.UI.Page
    {
        public List<Publicacion> carritoActual { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }
        public List<Publicacion> Lista1 { get; set; }
        public List<Publicacion> Lista2 { get; set; }
        public List<Publicacion> Lista3 { get; set; }
        public int contador { get; set; }

        public int UsuarioActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            NegocioUsuario usuarios = new NegocioUsuario();
            ListaUsuarios = usuarios.Listar();
            contador = ListaUsuarios.Count();
            Session.Add("idUsuario", 0);
            carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();
            if (contador>=3)
            {
                for (int x = 0; x < 3; x++)
                {
                    NegocioPublicacion negocio = new NegocioPublicacion();
                    switch (x)
                    {
                        case 0:
                            Lista1 = negocio.ListarXUsuario(x);
                            lblNombre1.Text = ListaUsuarios[x].nombre + " " + ListaUsuarios[x].apellido;
                            break;
                        case 1:
                            Lista2 = negocio.ListarXUsuario(x);
                            lblNombre2.Text = ListaUsuarios[x].nombre+" "+ ListaUsuarios[x].apellido;
                            break;
                        case 2:
                            Lista3 = negocio.ListarXUsuario(x);
                            lblNombre3.Text = ListaUsuarios[x].nombre + " " + ListaUsuarios[x].apellido;

                            break;
                    }

                }
                if (!IsPostBack)
                {
                    
                    rprCards1.DataSource = Lista1;
                    rprCards1.DataBind();
                    rprCards2.DataSource = Lista2;
                    rprCards2.DataBind();
                    rprCards3.DataSource = Lista3;
                    rprCards3.DataBind();
                    UsuarioActual = 0;

                }
            }else if(contador==0)
            {



            }
            else if(contador==1)
            {

                    NegocioPublicacion negocio = new NegocioPublicacion();

                            Lista1 = negocio.ListarXUsuario(0);
                            lblNombre1.Text = ListaUsuarios[0].nombre + " " + ListaUsuarios[0].apellido;

                if (!IsPostBack)
                {

                    rprCards1.DataSource = Lista1;
                    rprCards1.DataBind();
                    UsuarioActual = 0;

                }
            }
            else if(contador==2)
            {
                for (int x = 0; x < 2; x++)
                {
                    NegocioPublicacion negocio = new NegocioPublicacion();
                    switch (x)
                    {
                        case 0:
                            Lista1 = negocio.ListarXUsuario(x);
                            lblNombre1.Text = ListaUsuarios[x].nombre + " " + ListaUsuarios[x].apellido;
                            break;
                        case 1:
                            Lista2 = negocio.ListarXUsuario(x);
                            lblNombre2.Text = ListaUsuarios[x].nombre + " " + ListaUsuarios[x].apellido;
                            break;
                    }

                }
                if (!IsPostBack)
                {

                    rprCards1.DataSource = Lista1;
                    rprCards1.DataBind();
                    rprCards2.DataSource = Lista2;
                    rprCards2.DataBind();
                    UsuarioActual = 0;

                }

            }
            }

            protected void btnPublicaciones_Click(object sender, EventArgs e)
        {
            //Session.Add("idUsuario", carritoActual);
            Response.Redirect("Publicaciones.aspx", false);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Session.Add("idUsuario", carritoActual);
            Response.Redirect("Publicaciones.aspx", false);
        }
    }
}

