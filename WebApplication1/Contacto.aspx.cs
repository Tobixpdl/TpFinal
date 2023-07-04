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
    public partial class Contacto : System.Web.UI.Page
    {
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = Request.QueryString["Usuario"];
            NegocioUsuario negocio = new NegocioUsuario();  
            usuario = negocio.ListarXUsuario(nombre);
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx", false);
        }
    }
}