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
        public List<Venta> listaCompras = new List<Venta>();
        public int contador { get; set; }
        public int idUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["idUsuario"] != null)
            {
                idUsuario = (int)Session["idUsuario"];
                ContarItems(ref listaCompras);

                dvgCompras.DataSource = listaCompras;
                dvgCompras.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        public void ContarItems(ref List<Venta> list)
        {
            list = new List<Venta>();
            NegocioVentas negocio = new NegocioVentas();
            NegocioUsuario nu = new NegocioUsuario();

            list = negocio.ListarCompras((nu.ListarXUsuario(idUsuario)).dni);

            contador = list.Count;
        }

        protected void dvgCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}