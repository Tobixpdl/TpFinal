using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Handlers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Ventas : System.Web.UI.Page
    {
        public List<Venta> listaDeVentas;
        public int contador { get; set; }
        public int idUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["idUsuario"] != null)
            {

                idUsuario = (int)Session["idUsuario"];
                ContarItems(ref listaDeVentas);

                dgvVentas.DataSource = listaDeVentas;
                dgvVentas.DataBind();
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

            list = negocio.Listar((nu.ListarXUsuario(idUsuario)).dni);
           
            contador = list.Count;
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}