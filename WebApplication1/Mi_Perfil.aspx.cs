﻿using dominio;
using negocio;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Mi_Perfil : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set;}
        public List<Usuario> ListaUsuariosCheck { get; set; }
        public NegocioUsuario negocioU = new NegocioUsuario();
        public Usuario usuarioActivo { get; set; }
        public Usuario lastUser {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["activeUser"] != null)
            {
                string usuarioSession = Session["activeUser"].ToString();
                ListaUsuarios = negocioU.Listar();

                for (int i = 0; i < ListaUsuarios.Count; i++)
                {
                    if (ListaUsuarios[i].usuario == usuarioSession)
                    {
                        usuarioActivo = ListaUsuarios[i];
                    }
                }

                if (!IsPostBack)
                {
                    txtUsername.Text = usuarioActivo.usuario;
                    txtPassword.Text = usuarioActivo.password;
                    txtMail.Text = usuarioActivo.mail;
                    txtTelefono.Text = usuarioActivo.telefono;
                }

                LabelsVisibility("false");
                btnYes.Visible = false;
                btnNo.Visible = false;
                lblUserBorrado.Visible = false;

                SetControlEnabled(txtUsername, false);
                SetControlEnabled(txtPassword, false);
                SetControlEnabled(txtMail, false);
                SetControlEnabled(txtTelefono, false);
            }
            else
            {
                Response.Redirect("Default.aspx", false);

            }

        }

        protected void BtnChange_Click(object sender, EventArgs e)
        {
            NegocioComentarios negocioComentarios =new NegocioComentarios();
            txtUsername.CssClass = " ";
            txtPassword.CssClass = " ";
            txtTelefono.CssClass = " ";
            txtMail.CssClass = " ";

            lastUser = negocioU.ListarXUsuario(Session["activeUser"].ToString());
            ListaUsuariosCheck = negocioU.Listar();
            bool canChange = true;
            Usuario newUser = negocioU.ListarXUsuario(Session["activeUser"].ToString());
            newUser.usuario = txtUsername.Text;
            newUser.password = txtPassword.Text;
            newUser.telefono = txtTelefono.Text;
            newUser.mail = txtMail.Text;

           //CHEQUEARRRRRRR
           //
           //
           //
           //
           //
            if (lastUser.mail != newUser.mail) 
            {
                for (int i = 0; i < ListaUsuariosCheck.Count; i++)
                {
                    if (ListaUsuariosCheck[i].mail == newUser.mail)
                    {
                        lblWrongMail.Visible = true;
                        canChange = false;
                        break;
                    }
                }
            }
            if(lastUser.usuario != newUser.usuario)
            {
                for (int i = 0; i < ListaUsuariosCheck.Count; i++)
                {
                    if (ListaUsuariosCheck[i].usuario == newUser.usuario)
                    {
                        lblWrongUser.Visible = true;
                        canChange = false;
                    }
                }
            }
            //
            //
            //
            //
            //

            if (canChange)
            {
                negocioU.ModificarUsuario(newUser, lastUser);
                negocioComentarios.changeUserName(lastUser.usuario, newUser.usuario,1);
                negocioComentarios.changeUserName(lastUser.usuario, newUser.usuario, 2);
                lblChangeUser.Text = "Usuario editado exitosamente";
                lblChangeUser.Visible = true;
                Session["activeUser"] = txtUsername.Text;
            }
            else
            {
                lblChangeUser.Text = "No fue posible editar el usuario";
                lblChangeUser.Visible = true;
            }

        }

        private void LabelsVisibility(string t)
        {
            if (t == "false")
            {
                lblWrongMail.Visible = false;
                lblWrongTelefono.Visible = false;
                lblWrongUser.Visible = false;
                lblChangeUser.Visible = false;
                //lblSeguroBorrar.Visible = false;
            }
            else
            {
                lblWrongMail.Visible = true;
                lblWrongTelefono.Visible = true;
                lblWrongUser.Visible = true;
                lblChangeUser.Visible = true;
                //lblSeguroBorrar.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SetControlEnabled(txtUsername, true);
            //txtUsername.CssClass = "active";
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            SetControlEnabled(txtPassword, true);
            //txtPassword.CssClass = "active";
        }

        protected void btnChangeMail_Click(object sender, EventArgs e)
        {
            SetControlEnabled(txtMail, true);
            //txtMail.CssClass = "active";
        }

        protected void btnChangePhone_Click(object sender, EventArgs e)
        {
            SetControlEnabled(txtTelefono, true);
            //txtTelefono.CssClass = "active";
        }
        private void SetControlEnabled(Control control, bool enabled)
        {
            if (control is TextBox textBox)
            {
                textBox.Enabled = enabled;
            }
        }

        protected void btnEliminarUser_Click(object sender, EventArgs e)
        {
            //lblSeguroBorrar.Visible = true;
            btnYes.Visible = true;
            btnNo.Visible = true;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            negocioU.eliminarUsuario(usuarioActivo.Id);
            eliminarOpciones();
            this.Session["activeUser"] = null;
        }

        private void eliminarOpciones()
        {
            lblUsername.Visible = false;
            lblPassword.Visible = false;
            lblTelefono.Visible = false;
            lblMail.Visible = false;

            txtUsername.Visible = false;
            txtPassword.Visible = false;
            txtTelefono.Visible = false;
            txtMail.Visible = false;

            btnChangeMail.Visible = false;
            btnChangePass.Visible = false;
            BtnChangeUser.Visible = false;
            btnChangePhone.Visible = false;

            BtnChange.Visible = false;
            btnEliminarUser.Visible = false;

            lblUserBorrado.Visible = true;

        }

    }
}