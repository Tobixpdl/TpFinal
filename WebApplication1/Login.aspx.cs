﻿using dominio;
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
        public int idUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ListaUsuarios = negocio.Listar();

            if (this.Session["activeUser"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
                bool isregistered = false;
                bool badPass = false;
                bool badUser = false;
                
                for (int i = 0; i < ListaUsuarios.Count; i++)
                {
                    if (ListaUsuarios[i].usuario == txtUsername.Text &&
                        ListaUsuarios[i].password == txtPassword.Text)
                    {
                        isregistered = true;
                        string message = "Ingresaste con éxito!";
                        lblMessage.Text = message;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        idUsuario = ListaUsuarios[i].Id;
                        Session.Add("idUsuario", idUsuario);
                    break;
                    }
                    else if(ListaUsuarios[i].usuario == txtUsername.Text &&
                            ListaUsuarios[i].password != txtPassword.Text)
                    {
                        badPass = true;
                    }
                    else if (ListaUsuarios[i].usuario != txtUsername.Text)
                    {
                        badUser = true;
                    }
                }

                if (isregistered) 
                {
                    Session.Add("activeUser", txtUsername.Text);
                    
                  
                    Response.Redirect("Default.aspx",false);

                }
                else  if (badUser)
                {
                    string message = "Usuario incorrecto";
                    lblMessage.Text = message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else if (badPass)
                {
                    string message = "Contraseña incorrecta";
                    lblMessage.Text = message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }


            
        }
    }
}