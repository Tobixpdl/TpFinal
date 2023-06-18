using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Crear : System.Web.UI.Page
    {
        public int idUsuario { get; set; }
        public List<Categoria> categorias ;
        public Categoria catAux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            idUsuario = Session["idUsuario"] != null ? (int)Session["idUsuario"] : idUsuario = 0;
        
            
            
            categorias = new List<Categoria>();
            NegocioCategoria negocio = new NegocioCategoria();
            categorias = negocio.Listar();
            catAux = new Categoria();
            if (!IsPostBack)
            {
                catAux=new Categoria();
                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Nombre";
                
                ddlCategorias.DataBind();
            }
            

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            NegocioPublicacion negocioPublicacion = new NegocioPublicacion();   
            Publicacion aux = new Publicacion();
            aux.Titulo=txtTitulo.Text;
            aux.Descripcion = txtDescripcion.Text;
            aux.Precio=txtDescripcion.Text.Count()!=0? decimal.Parse(txtPrecio.Text) : 0;
            //aux.Precio = decimal.Parse(txtPrecio.Text) ;
            aux.Stock = txtPrecio.Text.Count() != 0 ? int.Parse(txtPrecio.Text) : 0;
            //aux.Stock = int.Parse(txtstock.Text);
            /*Categoria cat = new Categoria();
            cat.Id = 1;
            cat.Nombre = "ROPA";*/
            catAux.Id = (int.Parse(ddlCategorias.SelectedValue));

            catAux.Nombre = ddlCategorias.SelectedItem.Value;
            aux.Categoria = catAux;

            
           

            negocioPublicacion.AgregarPublicacion(aux, idUsuario);
            Response.Redirect("Default.aspx", false);

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            catAux.Id = (int.Parse(ddlCategorias.SelectedValue)) ;

            catAux.Nombre = ddlCategorias.SelectedItem.Value;
           
            //this.Session.Add("categoria", cat);



            //Response.Redirect("Crear.aspx", false);
        }
    }
}