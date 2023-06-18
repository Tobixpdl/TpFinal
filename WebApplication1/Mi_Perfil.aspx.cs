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
    public partial class Mi_Perfil : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }
        public NegocioUsuario negocioU = new NegocioUsuario();
        public Usuario usuarioActivo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuarios = negocioU.Listar();

            string usuarioSession = Session["activeUser"].ToString();
            
            for (int i = 0; i < ListaUsuarios.Count; i++)
            {
                if (ListaUsuarios[i].usuario == usuarioSession)
                {
                    usuarioActivo = ListaUsuarios[i];
                }
            }
          
            txtUsername.Text = usuarioActivo.usuario;
            txtPassword.Text = usuarioActivo.password;
            txtMail.Text = usuarioActivo.mail;
            txtTelefono.Text = usuarioActivo.telefono;

            txtUsername.CssClass = "active";

            LabelsVisibility("false");
        }

        protected void BtnChange_Click(object sender, EventArgs e)
        {
            bool canChange = true;
            Usuario newUser = new Usuario();
            newUser.usuario = txtUsername.Text;
            newUser.password = txtPassword.Text;
            newUser.telefono = txtTelefono.Text;
            newUser.mail = txtMail.Text;

            for (int i = 0; i < ListaUsuarios.Count; i++)
            {
                if (ListaUsuarios[i].usuario == newUser.usuario)
                {
                    lblWrongUser.Visible = true;
                    canChange = false;
                }
                if (ListaUsuarios[i].mail == newUser.mail)
                {
                    lblWrongMail.Visible = true;
                    canChange = false;
                }
            }
            //if (newUser.password != TextBox1.Text)
            //{
            //    lblWrongPass2.Visible = true;
            //    canChange = false;
            //}

            if (canChange)
            {
                negocioU.AgregarUsuario(newUser);
                lblChangeUser.Text = "Usuario creado";
                lblChangeUser.Visible = true;
            }
            else
            {
                lblChangeUser.Text = "No fue posible crear el usuario";
                lblChangeUser.Visible = true;
            }
        }

        private void LabelsVisibility(string t)
        {
            if (t == "false")
            {
                lblWrongMail.Visible = false;
                //lblWrongPass2.Visible = false;
                lblWrongTelefono.Visible = false;
                lblWrongUser.Visible = false;
                lblChangeUser.Visible = false;
            }
            else
            {
                lblWrongMail.Visible = true;
                //lblWrongPass2.Visible = true;
                lblWrongTelefono.Visible = true;
                lblWrongUser.Visible = true;
                lblChangeUser.Visible = true;
            }
        }
    }
}