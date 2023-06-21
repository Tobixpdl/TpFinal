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

            if (!IsPostBack)
            {
                if (this.Session["activeUser"] != null)
                {
                    liLogin.Visible = false;
                    liMiPerfil.Visible = true;

                }
                else
                {
                    liLogin.Visible = true;
                    liMiPerfil.Visible = false;

                }
            }
            else
            {
                if (this.Session["activeUser"] != null)
                {
                    liLogin.Visible = false;
                    liMiPerfil.Visible = true;

                }
                else
                {
                    liLogin.Visible = true;
                    liMiPerfil.Visible = false;

                }
            }

        }
    }
}