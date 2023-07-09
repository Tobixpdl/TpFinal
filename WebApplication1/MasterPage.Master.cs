using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           if (this.Session["activeUser"] != null && this.Session["listaDeCompras"] != null)
           {
               lblCompra.Text = ((List<Publicacion>)this.Session["listaDeCompras"]).Count.ToString();
           }
           else
           {
               lblCompra.Visible = false;
           }

        }
        protected void salirbtn_OnClick(object sender, EventArgs e)
        {
            //this.Session["activeUser"] = null;
            //this.Session["idUsuario"] = null;
            Session.Clear();
            liLogin.Visible = true;
            liMiPerfil.Visible = false;
            salirbtn.Visible = false;
            Response.Redirect("Login.aspx", false);
        }

    }
}