﻿using dominio;
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

            txtUsername.CssClass = " ";
            txtMail.CssClass = " ";
            txtDNI.CssClass = " ";
            TextBox1.CssClass = " ";
            txtNombres.CssClass = " ";
            txtApellidos.CssClass = " ";
            TextBox1.CssClass = " ";
            txtPassword.CssClass = " ";

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
            }
            newUser.telefono = txtTelefono.Text;
            newUser.mail = txtMail.Text;

            if (newUser.usuario.Length == 0)
            {
                lblMissing.Visible = true;
                txtUsername.CssClass = "wrongInput";
            }
            if (newUser.nombre.Length == 0)
            {
                txtNombres.CssClass = "wrongInput";
            }
            if (newUser.apellido.Length == 0)
            {
                txtApellidos.CssClass = "wrongInput";
            }
            if (newUser.mail.Length == 0)
            {
                txtMail.CssClass = "wrongInput";
            }
            if (newUser.password.Length == 0)
            {
                txtPassword.CssClass = "wrongInput";
                TextBox1.CssClass = "wrongInput";
            }

            for (int i = 0; i < ListaUsuarios.Count; i++)
            {
                if (ListaUsuarios[i].usuario == newUser.usuario && newUser.usuario.Length != 0)
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
                if (ListaUsuarios[i].mail == newUser.mail && newUser.mail.Length != 0)
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

            if (canCreateUser)
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
            if (t == "false")
            {
                lblMissing.Visible = false;
                lblWrongMail.Visible = false;
                lblWrongPass2.Visible = false;
                lblWrongTelefono.Visible = false;
                lblWrongUser.Visible = false;
                lblIsUserCreated.Visible = false;
            }
            else
            {
                lblMissing.Visible = true;
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