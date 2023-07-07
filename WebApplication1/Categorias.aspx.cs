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
    public partial class Categorias : System.Web.UI.Page
    {
        public List<Categoria> listaCategorias { get; set; }

        public NegocioCategoria NegocioCategoria = new NegocioCategoria();
        public int contador { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAviso.Visible = false;
            txtNuevaCategoria.Visible = false;
            btnAddedCategoria.Visible = false;

            listaCategorias = NegocioCategoria.Listar();

            dgvCategorias.DataSource = listaCategorias;
            dgvCategorias.DataBind();
        }

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<Publicacion> lp = (List<Publicacion>)this.Session["todosLosArticulos"];
            bool borra = true;

            if (e.CommandName == "Erase")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                contador = NegocioCategoria.Listar().Count;

                foreach (Publicacion p in lp)
                {
                    if (listaCategorias[index].Id == p.Categoria.Id)
                    {
                        borra = false;
                        break;
                    }
                }

                if (contador > 0 && borra)
                {
                    NegocioCategoria.EliminarCategoria(listaCategorias[index].Id);
                    Response.Redirect("Categorias.aspx");
                }
                else
                {
                    lblAviso.Visible = true;
                }
                


            }
        }

        protected void btnAddCategoria_Click(object sender, EventArgs e)
        {
            txtNuevaCategoria.Visible = true;
            btnAddedCategoria.Visible = true;
        }

        protected void btnAddedCategoria_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNuevaCategoria.Text))
            {
                NegocioCategoria.AgregarCategoria(txtNuevaCategoria.Text);
                Response.Redirect("Categorias.aspx");
            }
        }
    }
}