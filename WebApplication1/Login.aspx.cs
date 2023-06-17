using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ListaUsuarios = negocio.Listar();
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
                bool isregistered = false;
                for (int i = 0; i < ListaUsuarios.Count; i++)
                {
                    if (ListaUsuarios[i].usuario == txtUsername.Text &&
                      ListaUsuarios[i].password == txtPassword.Text)
                    {
                        isregistered = true;
                        string message = "Ingresaste con éxito!";
                        lblMessage.Text = message;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                if (!isregistered)
                {
                    string message = "El usuario ingresado es incorrecto";
                    lblMessage.Text = message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }


            
        }
    }
}