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
            liMiPerfil.Visible = false;
            liMiPerfil2.Visible = false;
            liMiPerfil3.Visible = false;
            salirbtn.Visible = false;

            if (!IsPostBack)
            {
                if (this.Session["activeUser"] != null)
                {
                    liLogin.Visible = false;
                    liMiPerfil.Visible = true;
                    liMiPerfil2.Visible = true;
                    liMiPerfil3.Visible = true;
                    salirbtn.Visible = true;

                }
                else
                {
                    liLogin.Visible = true;
                    liMiPerfil.Visible = false;
                    liMiPerfil2.Visible = false;
                    liMiPerfil3.Visible = false;
                    salirbtn.Visible = false;

                }
            }
            else
            {
                if (this.Session["activeUser"] != null)
                {
                    liLogin.Visible = false;
                    liMiPerfil.Visible = true;
                    salirbtn.Visible = true;

                }
                else
                {
                    liLogin.Visible = true;
                    liMiPerfil.Visible = false;
                    salirbtn.Visible = false;

                }
            }

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