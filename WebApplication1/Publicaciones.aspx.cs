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
    public partial class Publicaciones : System.Web.UI.Page
    {

        public List<Publicacion> listaDePublicaciones;
        public int contador { get; set; }
        public int idUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["activeUser"] != null && this.Session["activeUser"].ToString() == "usuario0")
            {
                btnCrear.Enabled = false;
            }
            if (this.Session["idUsuario"] != null)
            {

                object datoSession = this.Session["idUsuario"];

                if (datoSession is Usuario)
                {
                    Usuario usuario = (Usuario)this.Session["idUsuario"];
                    idUsuario = usuario.Id;
                }
                else
                {
                    idUsuario = (int)Session["idUsuario"];
                }

                ContarItems(ref listaDePublicaciones);


                dgvPublicaciones.DataSource = listaDePublicaciones;
                dgvPublicaciones.DataBind();
            }
            else
            {
               

                Response.Redirect("Default.aspx", false);

            }


        }
        public void ContarItems(ref List<Publicacion> list)
        {
            list = new List<Publicacion>();
            NegocioPublicacion negocio = new NegocioPublicacion();

            if (this.Session["activeUser"] != null && this.Session["activeUser"].ToString() == "usuario0")
            {
                list = negocio.Listar();
            }
            else
            {
                list = negocio.ListarXUsuario(idUsuario);
            }
                contador = list.Count;
        }
        public int GetIndex(int id)
        {
            for (int i = 0; i < listaDePublicaciones.Count; i++)
            {
                if (listaDePublicaciones[i].Id == id)
                {
                    return i;
                }
            }
            return 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);

        }


        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx", false);
        }
        protected string RUrl(object oItem)
        {
            string id = (DataBinder.Eval(oItem, "Id")).ToString();
            NegocioPublicacion negocio = new NegocioPublicacion();
            var imagenes = negocio.ListarXId(id).imagenes;

            if (imagenes != null && imagenes.Count > 0)
            {
                return imagenes[0].Url;
            }
            return string.Empty;
        }
        protected void dgvPublicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Erase")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                NegocioPublicacion negocio = new NegocioPublicacion();
                NegocioImagen negocioImg = new NegocioImagen();
                ContarItems(ref listaDePublicaciones);
                if (contador > 0)
                {
                    negocioImg.EliminarImagen(listaDePublicaciones[index].Id);
                    negocio.EliminarPublicacion(listaDePublicaciones[index].Id);
                }
                else
                {
                   
                    listaDePublicaciones = new List<Publicacion>();
                }

                Response.Redirect("Publicaciones.aspx");

            }
            else

            if (e.CommandName == "Modify")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Modificar.aspx?id=" + listaDePublicaciones[index].Id.ToString());
            }


        }
    }
}