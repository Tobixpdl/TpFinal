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

            if (this.Session["activeUser"] != null && this.Session["activeUser"].ToString() == "usuario0")
            {
                list = negocio.ListarTodo();
            }
            else
            {
                list = negocio.Listar((nu.ListarXUsuario(idUsuario)).dni);
            }
           
            contador = list.Count;
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvVentas_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void dgvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvVentas.PageIndex = e.NewPageIndex;
            dgvVentas.DataBind();
        }
    }
}