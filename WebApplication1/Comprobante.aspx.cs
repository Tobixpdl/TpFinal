using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Comprobante : System.Web.UI.Page
    {
        public string url;
        public string name;
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = (Request.QueryString["Url"]);
            name = (Request.QueryString["Usuario"]);
            id = int.Parse(Request.QueryString["Id"]);
            Image img = (Image)imgPublicacion;
            //img.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930";
            img.ImageUrl = url;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contacto.aspx?Usuario="+name+"&Id="+id, false);
            
        }
    }
}