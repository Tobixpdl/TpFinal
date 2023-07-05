using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            if (this.Session["activeUser"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {

            txtUsername.CssClass = "inputs";
            txtMail.CssClass = "inputs";
            txtDNI.CssClass = "inputs";
            TextBox1.CssClass = "inputs";
            txtNombres.CssClass = "inputs";
            txtApellidos.CssClass = "inputs";
            TextBox1.CssClass = "inputs";
            txtPassword.CssClass = "inputs";

            Regex rex = new Regex(@"^[a-zA-Z\s]+$");

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
                txtDNI.CssClass = "wrongInput";
                lblWrongDNI.Visible = true;
            }
            newUser.telefono = txtTelefono.Text;
            newUser.mail = txtMail.Text;

            if (string.IsNullOrEmpty(newUser.usuario))
            {
                lblMissing.Visible = true;
                lblWrongUser.Text = "Debe ingresar un usuario";
                lblWrongUser.Visible = true;
                txtUsername.CssClass = "wrongInput";
                canCreateUser = false;
            }

            if (string.IsNullOrEmpty(newUser.nombre) || !rex.IsMatch(newUser.nombre))
            {
                txtNombres.CssClass = "wrongInput";
                canCreateUser = false;
                lblWrongName.Visible = true;
            }

            if (string.IsNullOrEmpty(newUser.apellido) || !rex.IsMatch(newUser.apellido))
            {
                txtApellidos.CssClass = "wrongInput";
                canCreateUser = false;
                lblWrongApellido.Visible = true;
            }

            if (string.IsNullOrEmpty(newUser.mail))
            {
                lblWrongMail.Visible = true;
                txtMail.CssClass = "wrongInput";
                canCreateUser = false;
            }

            if (string.IsNullOrEmpty(newUser.password) || newUser.password != TextBox1.Text)
            {
                txtPassword.CssClass = "wrongInput";
                TextBox1.CssClass = "wrongInput";
                canCreateUser = false;
                lblWrongPass2.Visible = true;
            }

            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                lblWrongDNI.Text = "Debes ingresar un DNI";
                lblWrongDNI.Visible = true;
            }

            foreach (Usuario existingUser in ListaUsuarios)
            {
                if (existingUser.usuario == newUser.usuario && !string.IsNullOrEmpty(newUser.usuario))
                {
                    lblWrongUser.Text = "Este usuario ya existe";
                    lblWrongUser.Visible = true;
                    txtUsername.CssClass = "wrongInput";
                    canCreateUser = false;
                }
                if (existingUser.dni == newUser.dni)
                {
                    lblDNI.Visible = true;
                    canCreateUser = false;
                    txtDNI.CssClass = "wrongInput";
                }
                if (existingUser.mail == newUser.mail && !string.IsNullOrEmpty(newUser.mail))
                {
                    lblWrongMail.Visible = true;
                    canCreateUser = false;
                    txtMail.CssClass = "wrongInput";
                }
            }

            if (newUser.password != TextBox1.Text)
            {
                lblWrongPass2.Visible = true;
                canCreateUser = false;
                TextBox1.CssClass = "wrongInput";
            }

                //CREACION DEL USUARIO
                if (canCreateUser)
                {
                negocioU.AgregarUsuario(newUser);
                lblIsUserCreated.Text = "Usuario creado";
                lblIsUserCreated.Visible = true;
                Session.Add("activeUser", txtUsername.Text);
                NegocioUsuario negocio=new NegocioUsuario();
                Session.Add("idUsuario", negocio.ListarXUsuario(txtUsername.Text).Id);
                Response.Redirect("Mi_Perfil.aspx", false);
                }
            else
            {
                lblIsUserCreated.Text = "No fue posible crear el usuario";
                lblIsUserCreated.Visible = true;
            }

        }

        private void LabelsVisibility(string t)
        {
            if (t == "false")
            {
                lblMissing.Visible = false;
                lblWrongMail.Visible = false;
                lblWrongPass2.Visible = false;
                lblWrongTelefono.Visible = false;
                lblWrongUser.Visible = false;
                lblIsUserCreated.Visible = false;
                lblWrongApellido.Visible = false;
                lblWrongName.Visible = false;
                lblWrongDNI.Visible = false;
            }
            else
            {
                lblMissing.Visible = true;
                lblWrongMail.Visible = true;
                lblWrongPass2.Visible = true;
                lblWrongTelefono.Visible = true;
                lblWrongUser.Visible = true;
                lblIsUserCreated.Visible = true;
                lblWrongApellido.Visible = true;
                lblWrongName.Visible = true;
                lblWrongDNI.Visible = true;
            }
        }


        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}