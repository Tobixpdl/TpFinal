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
        public Usuario user;
        public List<Categoria> categorias ;
        public Categoria catAux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            idUsuario = Session["idUsuario"] != null ? (int)Session["idUsuario"] : idUsuario = 0;
            user = Session["user"] !=null ? (Usuario)Session["user"]:negocioUsuario.ListarXUsuario(idUsuario);
            imgPublicacion.ImageUrl = Session["url"] != null ? (string)Session["url"] : "https://t4.ftcdn.net/jpg/02/51/95/53/360_F_251955356_FAQH0U1y1TZw3ZcdPGybwUkH90a3VAhb.jpg";

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
            NegocioImagen negocioImagen = new NegocioImagen();
            Publicacion aux = new Publicacion();
            aux.Titulo = txtTitulo.Text;
            aux.Descripcion = txtDescripcion.Text;
            aux.Precio = txtDescripcion.Text.Count() != 0 ? decimal.Parse(txtPrecio.Text) : 0;
            //aux.Precio = decimal.Parse(txtPrecio.Text) ;
            aux.Stock = txtPrecio.Text.Count() != 0 ? int.Parse(txtPrecio.Text) : 0;
            //aux.Stock = int.Parse(txtstock.Text);
            /*Categoria cat = new Categoria();
            cat.Id = 1;
            cat.Nombre = "ROPA";*/
            catAux.Id = (int.Parse(ddlCategorias.SelectedValue));

            catAux.Nombre = ddlCategorias.SelectedItem.Value;
            aux.Categoria = catAux;

            negocioImagen.CrearImagen(imgPublicacion.ImageUrl, negocioPublicacion.GetLastPublicacion());
            
           

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

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./Images/");

                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id+".jpg");
                string finalRuta = "~"+ ruta + "perfil-" + user.Id + ".jpg";

                Session.Add("url", finalRuta);
                Response.Redirect("Crear.aspx",false);

                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}