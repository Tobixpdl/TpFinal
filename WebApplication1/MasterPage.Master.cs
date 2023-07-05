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
            lblCompra.Text = this.Session["listaDeCompras"] != null && ((List<Publicacion>)Session["listaDeCompras"]).Count != 0 ? ((List<Publicacion>)Session["listaDeCompras"]).Count.ToString() : lblCompra.CssClass = "invisible";

        }
        protected void salirbtn_OnClick(object sender, EventArgs e)
        {
            if (this.Session["activeUser"] != null)
            {
                this.Session["activeUser"] = null;
                this.Session["idUsuario"] = null;
                liLogin.Visible = true;
                liMiPerfil.Visible = false;
                salirbtn.Visible = false;
                Response.Redirect("Login.aspx", false);

            }
            else
            {
                liLogin.Visible = true;
                liMiPerfil.Visible = false;
                salirbtn.Visible = false;
                Response.Redirect("Login.aspx", false);

            }
        }

            }
}