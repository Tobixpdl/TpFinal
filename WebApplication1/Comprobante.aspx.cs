using dominio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Comprobante : System.Web.UI.Page
    {
        public string url;
        public string emisor;
        public string receptor;
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = (Request.QueryString["Url"]);
            emisor = (Request.QueryString["UsuarioEmisor"]);
            receptor = (Request.QueryString["UsuarioReceptor"]);
            id = int.Parse(Request.QueryString["Id"]);
            Image img = (Image)imgPublicacion;
            //img.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930";
            img.ImageUrl = url;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contacto.aspx?UsuarioReceptor=" + receptor + "&Id="+id+ "&UsuarioEmisor="+ emisor, false);
         


        }
    }
}