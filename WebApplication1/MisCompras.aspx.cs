using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MisCompras : System.Web.UI.Page
    {
        public List<Publicacion> listaCompras = new List<Publicacion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioVentas nV = new NegocioVentas();
            
            listaCompras = nV.getCompras(Session["activeUser"].ToString());

            if (!IsPostBack)
            {
                rprCompras.DataSource = listaCompras;
                rprCompras.DataBind();
            }
        }
    }
}