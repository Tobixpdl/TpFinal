using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Publicacion> ListaArticulos { get; set; }
        public List<Publicacion> listaFiltradaPro { get; set; }

        public List<Publicacion> carritoActual { get; set; }
        
        public int UsuarioActual { get; set; }
        public Usuario user=new Usuario();
        public NegocioUsuario negocioUsuario { get; set; }
        public NegocioImagen negocioImg = new NegocioImagen();
        public NegocioPublicacion negocio = new NegocioPublicacion();
        public bool FiltroAvanzado { get; set; }
        public bool FiltroChecked { get; set; }
        public bool FiltroEncontrado { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {   
            FiltroEncontrado= false;
            FiltroAvanzado = false;
            FiltroChecked = false;
            BusquedaNull.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;
            // Generacion de los datos de las CARDS
            negocioUsuario = new NegocioUsuario();
            ListaArticulos = negocio.ListarSinCero();



            Session.Add("todosLosArticulos", ListaArticulos);

            txtBusqueda.Attributes.Add("onkeydown", "return bloquearEnter(event);");
            //


            if (this.Session["activeUser"] != null)
            {
                string nusuario = this.Session["activeUser"].ToString();
                user.usuario =nusuario ;
                user = negocioUsuario.ListarXUsuario(nusuario);
                carritoActual = negocio.listarFavoritos((int)this.Session["idUsuario"]);
                this.Session.Add("listaDeCompras", carritoActual);
            }

            Session.Add("user", user);

            //
            //carritoActual = this.Session["listaDeCompras"] != null ? (List<Publicacion>)Session["listaDeCompras"] : new List<Publicacion>();
            //BusquedaNull.Visible = false;
         

            if (!IsPostBack)
            {

                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();

                CargarCategorias();

                /*/if (this.Session[] == null)
                {/*/
                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUsuario.ListarXUsuario(nusuario);
                }
                //}


                // ddlCategoria_Llenado(sender, e);
            }
            else{


                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUsuario.ListarXUsuario(nusuario);
                }
 
                if (FiltroChecked == true)
                {
                    chBusquedaAvanzada.Checked = true;

                }

            }

            /*/
        else
        {
            if (this.Session[] == null)
            {
                UsuarioActual = 0;
            }
        }/*/
            /*/
            else
            {
                if (!chBusqueda.Checked)
                {
                    ddlMarca.SelectedValue = "";

                }

                lblCompra.CssClass = "count";

            }


        /*/

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button btnAdd = (Button)sender;
            btnAdd.Enabled = false;

            string valor = ((Button)sender).CommandArgument;
            var aux = buscarArticulo(valor);

            if (user.Id != aux.Id_Usuario)
            {
                if (!ContainsArticulo(aux))
                {
                    negocio.AgregarFavoritos(aux, (int)this.Session["idUsuario"]);
                    carritoActual.Add(buscarArticulo(valor));
                }

                
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                string script = "alert('No puede hacer esto.');";
                ClientScript.RegisterStartupScript(this.GetType(), "NoPuedeHacerEsto", script, true);
            }
        }

        public bool ContainsArticulo(Publicacion p)
        {
            foreach (Publicacion pu in carritoActual)
            {
                if(pu.Id == p.Id)
                {
                    return true;
                }
            }

            return false;
        }
        public Publicacion buscarArticulo(string id)
        {
            Publicacion aux = new Publicacion();
            int val = 0;
            bool numero = int.TryParse(id, out val);
            foreach (var item in ListaArticulos)
            {
                if (item.Id == val)
                {
                    aux = item;

                }
            }
            return aux;
        }

        protected void btnCarro_Click(object sender, EventArgs e)
        {
            Session.Add("listaDeCompras", carritoActual);
            Response.Redirect("Carrito.aspx", false);
        }
        protected string ReturnUrl(object oItem)
        {
            string id = (DataBinder.Eval(oItem, "Id")).ToString();
            NegocioPublicacion negocio = new NegocioPublicacion();
            var imagenes = negocio.ListarXId(id).imagenes;

            if (imagenes != null && imagenes.Count > 0)
            {
                return imagenes[0].Url;
            }  
            return string.Empty;
        }

        protected void imgPublicacion_PreRender(object sender, EventArgs e)
        {

            /*

            Image img = (Image)FindControl("imgPublicacion");
            img.ImageUrl = (buscarArticulo(img.ImageUrl)).imagenes[0].Url;*/

            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Publicacion> listaFiltrada = ListaArticulos.FindAll(x => x.Titulo.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
            if (listaFiltrada.Count == 0)
            {
                FiltroAvanzado = false;
                BusquedaNull.Visible = true;
                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();
                updatePanel.Update();
            }
            else if(listaFiltrada.Count == ListaArticulos.Count)
            {
                FiltroAvanzado = false;
                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();
                updatePanel.Update();
            }
            else
            {
                FiltroAvanzado = true;
                rprCards.DataSource = listaFiltrada;
                rprCards.DataBind();
                BusquedaNull.Visible = false;
                updatePanel.Update();
            }

        }
        protected void chBusquedaAvanzada_Checked(object sender, EventArgs e)
        {
            if (chBusquedaAvanzada.Checked==true)
            {
                FiltroChecked = true;

            }
            else
            {
                FiltroChecked = false;
            }

        }
        
        protected void ddlCategorias_IndexChanged(object sender, EventArgs e)
        {

            if(ddlCategorias.SelectedValue == "Seleccione una Categoría")
            {
                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();
                BusquedaNull.Visible = false;
                FiltroChecked = true;


            }
            else
            {
                FiltroChecked = true;

                int selectedIndex = ddlCategorias.SelectedIndex;
                listaFiltradaPro = negocio.ListarXCategoriaSinCero(selectedIndex);

                if (listaFiltradaPro.Count != 0)
                {
                    FiltroChecked = true;
                    rprCards.DataSource = listaFiltradaPro;
                    rprCards.DataBind();
                    FiltroEncontrado = true;
                }
                else
                {
                    FiltroChecked = true;
                    BusquedaNull.Visible = true;
                    rprCards.DataSource = ListaArticulos;
                    rprCards.DataBind();
                }

            }
            

        }
        private void CargarCategorias()
        {
            NegocioCategoria negocioCategoria = new NegocioCategoria();

            List<Categoria> ListaCategorias = negocioCategoria.Listar();

            List<string> cats = new List<string>();

            ddlCategorias.Items.Add("Seleccione una Categoría");

            foreach (Categoria categoria in ListaCategorias)
            {
                ddlCategorias.Items.Add(categoria.Nombre);
            }

        }

    }
}
    
