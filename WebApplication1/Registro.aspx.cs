using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }
        public NegocioUsuario negocioU = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuarios = negocioU.Listar();
            LabelsVisibility("false");
            
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            bool canCreateUser = true;
            Usuario newUser = new Usuario();
            newUser.usuario = txtUsername.Text;
            newUser.nombre = txtNombres.Text;
            newUser.apellido = txtApellidos.Text;
            newUser.password = txtPassword.Text;
            if (int.TryParse(txtDNI.Text, out int numero))
            {
                newUser.dni = numero;
            }
            else
            {
                newUser.dni = 0;
            }
            newUser.telefono = txtTelefono.Text;
            newUser.mail = txtMail.Text;

            for (int i=0; i<ListaUsuarios.Count; i++)
            {
                if (ListaUsuarios[i].usuario == newUser.usuario)
                {
                    lblWrongUser.Visible = true;
                    txtUsername.CssClass = "wrongInput";
                    canCreateUser = false;
                }
                if (ListaUsuarios[i].dni == newUser.dni)
                {
                    lblDNI.Visible = true;
                    canCreateUser = false;
                    txtDNI.CssClass = "wrongInput";
                }
                if (ListaUsuarios[i].mail == newUser.mail)
                {
                    lblWrongMail.Visible = true;
                    canCreateUser = false;
                    txtMail.CssClass = "wrongInput";
                }
            }
            if(newUser.dni <10000000)
            {
                lblDNI.Visible = true;
                canCreateUser = false;
                txtDNI.CssClass = "wrongInput";
            }
            if(newUser.password != TextBox1.Text)
            {
                lblWrongPass2.Visible = true;
                canCreateUser = false;
                TextBox1.CssClass = "wrongInput";
            }

            if(canCreateUser)
            {
                negocioU.AgregarUsuario(newUser);
                lblIsUserCreated.Text = "Usuario creado";
                lblIsUserCreated.Visible = true;
            }
            else
            {
                lblIsUserCreated.Text = "No fue posible crear el usuario";
                lblIsUserCreated.Visible = true;
            }

        }

        private void LabelsVisibility(string t)
        {
            if(t == "false")
            {
                lblWrongDNI.Visible = false;
                lblWrongMail.Visible = false;
                lblWrongPass2.Visible = false;
                lblWrongTelefono.Visible = false;
                lblWrongUser.Visible = false;
                lblIsUserCreated.Visible = false;
            }
            else
            {
                lblWrongDNI.Visible = true;
                lblWrongMail.Visible = true;
                lblWrongPass2.Visible = true;
                lblWrongTelefono.Visible = true;
                lblWrongUser.Visible = true;
                lblIsUserCreated.Visible = true;
            }
        }


        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}