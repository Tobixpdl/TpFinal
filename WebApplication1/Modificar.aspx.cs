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
    public partial class Modificar : System.Web.UI.Page
    {
        public Publicacion target;
        public List<Categoria> categorias;
        public Categoria catAux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();
            
            target = negocio.GetPublicacion(int.Parse(Request.QueryString["Id"].ToString()));

            categorias = new List<Categoria>();
            NegocioCategoria negocioCat = new NegocioCategoria();
            categorias = negocioCat.Listar();
            catAux = new Categoria();

            if (!IsPostBack)
            {
               
                catAux = new Categoria();
                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Nombre";

                ddlCategorias.DataBind();

                txtTitulo.Text=target.Titulo;
                txtDescripcion.Text=target.Descripcion;
                txtstock.Text=target.Stock.ToString();
                txtPrecio.Text = target.Precio.ToString();
                ddlCategorias.SelectedIndex = target.Categoria.Id;
                Image img = (Image)imgPublicacion;
              

                img.ImageUrl = target.imagenes[0].Url;

            }





        }
        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

            catAux.Id = (int.Parse(ddlCategorias.SelectedValue));

            catAux.Nombre = ddlCategorias.SelectedItem.Value;

            //this.Session.Add("categoria", cat);



            //Response.Redirect("Crear.aspx", false);
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (url.HasFile)
            {
                 
                try
                {
                    string ruta = Server.MapPath("./Images/");

                    //FileURL.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    url.PostedFile.SaveAs(ruta + System.IO.Path.GetFileName(url.PostedFile.FileName));
                    string finalRuta = "~/Images/" + System.IO.Path.GetFileName(url.PostedFile.FileName);

                    Image img = (Image)imgPublicacion;
                    img.ImageUrl = finalRuta;


                    /* Session.Add("url", finalRuta);
                     Response.Redirect("Crear.aspx", false);*/
                }
                catch (Exception)
                {

                    throw;
                }
            }






        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicaciones.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
            NegocioImagen negocioImagen = new NegocioImagen();
            Publicacion aux = new Publicacion();
            aux.Id = target.Id;
            aux.Titulo = txtTitulo.Text;
            aux.Descripcion = txtDescripcion.Text;
            aux.Precio = txtPrecio.Text.Count() != 0 ? decimal.Parse(txtPrecio.Text) : 0;
            //aux.Precio = decimal.Parse(txtPrecio.Text) ;
            aux.Stock = txtstock.Text.Count() != 0 ? long.Parse(txtstock.Text) : 0;
            //aux.Stock = int.Parse(txtstock.Text);
            /*Categoria cat = new Categoria();
            cat.Id = 1;
            cat.Nombre = "ROPA";*/
            catAux.Id = (int.Parse(ddlCategorias.SelectedValue));

            catAux.Nombre = ddlCategorias.SelectedItem.Value;
            aux.Categoria = catAux;
            negocioPublicacion.ModificarPublicacion(aux);
           
            negocioImagen.ModificarImagen(imgPublicacion.ImageUrl, aux.Id);





            Response.Redirect("Publicaciones.aspx", false);
        }
    }
}