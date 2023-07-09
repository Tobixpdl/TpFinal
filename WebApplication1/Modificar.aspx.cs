using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public bool isValid, isImgValid;
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioPublicacion negocio = new NegocioPublicacion();

            target = negocio.GetPublicacion(int.Parse(Request.QueryString["Id"].ToString()));

            categorias = new List<Categoria>();
            NegocioCategoria negocioCat = new NegocioCategoria();
            categorias = negocioCat.Listar();
            catAux = new Categoria();
            isValid = Session["validar"] != null ? (bool)Session["validar"] : true;
            isImgValid = Session["vImg"] != null ? (bool)Session["vImg"] : true;
            lblWrongTitulo.Visible = false;
            lblWrongStock.Visible = false;
            lblWrongPrecio.Visible = false;
            lblWrongImg.Visible = false;
            lblWrongFormato.Visible = false;
            if (!IsPostBack)
            {

                catAux = new Categoria();
                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Nombre";

                ddlCategorias.DataBind();

                txtTitulo.Text = target.Titulo;
                txtDescripcion.Text = target.Descripcion;
                txtstock.Text = target.Stock.ToString();
                txtPrecio.Text = target.Precio.ToString();
                ddlCategorias.SelectedIndex = target.Categoria.Id - 1;

                List<Image> img = new List<Image>
                {
                    imgPublicacion,
                    imgP2,
                    imgP3,
                    imgP4
                };

                for (int i = 0; i < img.Count; i++)
                {
                    if (i < target.imagenes.Count && target.imagenes[i].Url != null)
                    {
                        img[i].ImageUrl = target.imagenes[i].Url;
                    }
                }


            }
            if (isValid == false)
            {
                lblWrongTitulo.Visible = true;
                lblWrongStock.Visible = true;
                lblWrongPrecio.Visible = true;
            }

        }


        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

            catAux.Id = (int.Parse(ddlCategorias.SelectedValue));

            catAux.Nombre = ddlCategorias.SelectedItem.Value;

            //this.Session.Add("categoria", cat);



            //Response.Redirect("Crear.aspx", false);
        }

        public void subirIMG(Image p)
        {
            if (url.HasFile)
            {

                try
                {
                    string ruta = Server.MapPath("./Images/");

                    //FileURL.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    url.PostedFile.SaveAs(ruta + System.IO.Path.GetFileName(url.PostedFile.FileName));
                    string finalRuta = "~/Images/" + System.IO.Path.GetFileName(url.PostedFile.FileName);
                    string extension = Path.GetExtension(finalRuta);
                    if (extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg")
                    {
                        Image img = (Image)p;
                        img.ImageUrl = finalRuta;
                    }
                    else
                    {
                        lblWrongFormato.Visible = true;

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                lblWrongImg.Visible = true;
            }

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            subirIMG(imgPublicacion);

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Add("validar", true);
            Response.Redirect("Publicaciones.aspx", false);
        }

        protected void btnUpload2_Click(object sender, EventArgs e)
        {
            subirIMG(imgP2);
        }

        protected void btnUpload3_Click(object sender, EventArgs e)
        {
            subirIMG(imgP3);
        }

        protected void btnUpload4_Click(object sender, EventArgs e)
        {
            subirIMG(imgP4);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            isValid = true;

            if (txtTitulo.Text == "" || txtstock.Text == "" || txtPrecio.Text == "")
            {
                isValid = false;
            }


            if (isValid)
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

                if (imgPublicacion.ImageUrl != null)
                {
                    if (target.imagenes == null || target.imagenes.Count == 0 || target.imagenes[0] == null)
                    {
                        negocioImagen.CrearImagen(imgPublicacion.ImageUrl, aux.Id);
                    }
                    else
                    {
                        negocioImagen.ModificarImagen(imgPublicacion.ImageUrl, target.imagenes[0].Id);
                    }
                }
                if (!string.IsNullOrEmpty(imgP2.ImageUrl))
                {
                    if (target.imagenes == null || target.imagenes.Count <= 1 || target.imagenes[1] == null)
                    {
                        negocioImagen.CrearImagen(imgP2.ImageUrl, aux.Id);
                    }
                    else
                    {
                        negocioImagen.ModificarImagen(imgP2.ImageUrl, target.imagenes[1].Id);
                    }
                }
                if (!string.IsNullOrEmpty(imgP3.ImageUrl))
                {
                    if (target.imagenes == null || target.imagenes.Count <= 2 || target.imagenes[2] == null)
                    {
                        negocioImagen.CrearImagen(imgP3.ImageUrl, aux.Id);
                    }
                    else
                    {
                        negocioImagen.ModificarImagen(imgP3.ImageUrl, target.imagenes[2].Id);
                    }
                }
                if (!string.IsNullOrEmpty(imgP4.ImageUrl))
                {
                    if (target.imagenes == null || target.imagenes.Count <= 3 || target.imagenes[3] == null)
                    {
                        negocioImagen.CrearImagen(imgP4.ImageUrl, aux.Id);
                    }
                    else
                    {
                        negocioImagen.ModificarImagen(imgP4.ImageUrl, target.imagenes[3].Id);
                    }
                }


                Session.Add("validar", true);
                Response.Redirect("Publicaciones.aspx", false);
            }
            else
            {
                this.Session.Add("validar", false);
                Response.Redirect("Modificar.aspx?id=" + target.Id, false);
            }
        }
    }
}