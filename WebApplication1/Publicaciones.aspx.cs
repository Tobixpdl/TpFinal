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

            if (this.Session["idUsuario"] != null)
            {

                idUsuario = (int)Session["idUsuario"];


                ContarItems(ref listaDePublicaciones);


                dgvPublicaciones.DataSource = listaDePublicaciones;
                dgvPublicaciones.DataBind();
            }
            else
            {
                idUsuario =0;

                Response.Redirect("Default.aspx", false);

            }


        }
        public void ContarItems(ref List<Publicacion> list)
        {
            list = new List<Publicacion>();
            NegocioPublicacion negocio = new NegocioPublicacion();

            list = negocio.ListarXUsuario(idUsuario);
            contador = list.Count;
        }
        public int GetIndex(int id)
        {
            for (int i = 0; i < listaDePublicaciones.Count; i++)
            {
                if (listaDePublicaciones[i].Id==id)
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

        protected void dgvPublicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
         
           
                if (e.CommandName == "Erase")
                {
                int index = Convert.ToInt32(e.CommandArgument);

                string message = "Seguro que quieres eliminar?";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("return confirm('");

                sb.Append(message);

                sb.Append("');");

                ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
               

                NegocioPublicacion negocio = new NegocioPublicacion();
                NegocioImagen negocioImg = new NegocioImagen();
                ContarItems(ref listaDePublicaciones);
                index = GetIndex(Convert.ToInt32(e.CommandArgument)); 
              if(contador>0)
                {
                    negocioImg.EliminarImagen(listaDePublicaciones[index].Id);
                    negocio.EliminarPublicacion(listaDePublicaciones[index].Id);
                }else
                {
                    listaDePublicaciones = new List<Publicacion>();
                }
                   
               
                

              
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