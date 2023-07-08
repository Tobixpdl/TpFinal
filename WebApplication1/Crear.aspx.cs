using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
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

        public bool isValid,isImgValid;
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            idUsuario = Session["idUsuario"] != null ? (int)Session["idUsuario"] : idUsuario = 0;
            user = Session["user"] !=null ? (Usuario)Session["user"]:negocioUsuario.ListarXUsuario(idUsuario);
            
            categorias = new List<Categoria>();
            NegocioCategoria negocio = new NegocioCategoria();
            categorias = negocio.Listar();
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
                imgPublicacion.ImageUrl = Session["url"] != null ? (string)Session["url"] :
               "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930";
                catAux = new Categoria();
                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Nombre";
                
                ddlCategorias.DataBind();

            }
            
            if(isValid==false)
            {
                lblWrongTitulo.Visible = true;
                lblWrongStock.Visible = true;
                lblWrongPrecio.Visible = true;
            }

         
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            isValid = true;

            if(txtTitulo.Text =="" || txtstock.Text=="" ||txtPrecio.Text=="")
            {               
                isValid = false;
            }


            if(isValid)
            {

            NegocioPublicacion negocioPublicacion = new NegocioPublicacion();
            NegocioImagen negocioImagen = new NegocioImagen();
            Publicacion aux = new Publicacion();
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
            negocioPublicacion.AgregarPublicacion(aux, idUsuario);
            var id = negocioPublicacion.GetLastPublicacion().Id;
            negocioImagen.CrearImagen(imgPublicacion.ImageUrl,id );
                Session.Add("validar", true);
                Response.Redirect("Publicaciones.aspx", false);
            }else
            {
                this.Session.Add("validar", false);
                Response.Redirect("Crear.aspx", false);
            }
            
           

            


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Add("validar", true);
            Response.Redirect("Default.aspx", false);
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            catAux.Id = (int.Parse(ddlCategorias.SelectedValue)) ;

            catAux.Nombre = ddlCategorias.SelectedItem.Value;
           
            //this.Session.Add("categoria", cat);



            //Response.Redirect("Crear.aspx", false);
        }

    

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(url.HasFile)
            {
                try
                {
                    string ruta = Server.MapPath("./Images/");

                    //FileURL.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    url.PostedFile.SaveAs(ruta + System.IO.Path.GetFileName(url.PostedFile.FileName));
                    string finalRuta = "~/Images/" + System.IO.Path.GetFileName(url.PostedFile.FileName);
                   
                    string extension = Path.GetExtension(finalRuta);
                    if(extension==".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg")
                    {
                    Image img = (Image)imgPublicacion;
                    img.ImageUrl = finalRuta;
                    }
                    else
                    {
                        lblWrongFormato.Visible = true;

                    }

                    /* Session.Add("url", finalRuta);
                     Response.Redirect("Crear.aspx", false);*/
                }
                catch (Exception)
                {

                    throw;
                }
            }else
            {
                lblWrongImg.Visible = true;
            }
           
               
                    


               
        }
    }
}