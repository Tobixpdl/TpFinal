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
        public List<Publicacion> carritoActual { get; set; }
        
        public int UsuarioActual { get; set; }
        public Usuario user=new Usuario();
        public NegocioUsuario negocioUsuario { get; set; }
        public NegocioImagen negocioImg = new NegocioImagen();
        public NegocioPublicacion negocio = new NegocioPublicacion();
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generacion de los datos de las CARDS
            negocioUsuario = new NegocioUsuario();
            BusquedaNull.Visible = false;
            ListaArticulos = negocio.Listar();

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

                /*/if (this.Session[] == null)
                {/*/
                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUsuario.ListarXUsuario(nusuario);
                }
                //}
                //FiltroAvanzado = false;
                // ddlCategoria_Llenado(sender, e);
            }
            else{

                if (this.Session["activeUser"] != null)
                {
                    string nusuario = Session["activeUser"].ToString();
                    user.usuario = nusuario;
                    user = negocioUsuario.ListarXUsuario(nusuario);
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
                BusquedaNull.Visible = true;
                rprCards.DataSource = ListaArticulos;
                rprCards.DataBind();
                updatePanel.Update();
            }
            else
            {
                rprCards.DataSource = listaFiltrada;
                rprCards.DataBind();
                BusquedaNull.Visible = false;
                updatePanel.Update();
            }
        }
        /*/


protected void chBusqueda_CheckedChanged(object sender, EventArgs e)
{
FiltroAvanzado = chBusqueda.Checked;
txtBusqueda.Enabled = !FiltroAvanzado;
if (!(string.IsNullOrEmpty(txtBusqueda.Text)))
{
txtBusqueda.Text ="";

}
if (!chBusqueda.Checked)
{
rprCards.DataSource = ListaArticulos;
rprCards.DataBind();
FiltroAvanzado = false;
chMenorPrecio.Enabled = true;
chMayorPrecio.Enabled = true;
ddlCategoria.SelectedIndex = 0;
}
else
{
chMenorPrecio.Enabled = false;
chMayorPrecio.Enabled = false;
}

}

protected void ddlCategoria_Llenado(object sender, EventArgs e)
{
List<string> categorias = new List<string>();
ddlCategoria.Items.Clear();
categorias.Add("");

foreach (Articulo articulo in ListaArticulos)
{

string categoria = articulo.Categoria.Descripcion;

if (!categorias.Contains(categoria))
{
 categorias.Add(categoria);
}
}
ddlCategoria.DataSource = categorias;
ddlCategoria.DataBind();

}

protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
{
List<string> marcas= new List<string>();
ddlMarca.Items.Clear();
marcas.Add("");

foreach (Articulo articulo in ListaArticulos)
{
if (articulo.Categoria.Descripcion == ddlCategoria.SelectedItem.Text)
{
 string marca = articulo.Marca.Descripcion;

 if (!marcas.Contains(marca))
 {
     marcas.Add(marca);
 }
}

} 

ddlMarca.DataSource = marcas;
ddlMarca.DataBind();
Filtro_porCategoria(sender, e);
FiltroAvanzado = true;
txtBusAvanzada.Enabled = false;

}

protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
{
List<Articulo> listaFiltrada = ListaArticulos.FindAll(x => x.Marca.Descripcion.ToUpper().Contains(ddlMarca.SelectedItem.Text.ToUpper()) && x.Categoria.Descripcion.ToUpper().Contains(ddlCategoria.SelectedItem.Text.ToUpper()));

if (listaFiltrada.Count == 0)
{
BusquedaNull.Visible = true;

}
else
{

rprCards.DataSource = listaFiltrada;
rprCards.DataBind();
BusquedaNull.Visible = false;
}
FiltroAvanzado = true;
if (ddlMarca.SelectedValue == "") { 
ddlCategoria_SelectedIndexChanged(sender, e);
}
else
{
txtBusAvanzada.Enabled = true;

}


}
protected void txtBusAvanzada_TextChanged(object sender, EventArgs e)
{
List<Articulo> listaFiltrada = ListaArticulos.FindAll(x => x.Marca.Descripcion.ToUpper().Contains(ddlMarca.SelectedItem.Text.ToUpper()) && x.Categoria.Descripcion.ToUpper().Contains(ddlCategoria.SelectedItem.Text.ToUpper())&& x.Nombre.ToUpper().Contains(txtBusAvanzada.Text.ToUpper()));
if (listaFiltrada.Count == 0)
{
ddlMarca_SelectedIndexChanged(sender, e);
BusquedaNull.Visible = true;
FiltroAvanzado = true;


}
else
{

rprCards.DataSource = listaFiltrada;
rprCards.DataBind();
BusquedaNull.Visible = false;
FiltroAvanzado = true;

}
}

protected void Filtro_porCategoria(object sender, EventArgs e)
{


List<Articulo> listaFiltrada = ListaArticulos.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(ddlCategoria.SelectedItem.Text.ToUpper()));
if (listaFiltrada.Count == 0)
{
BusquedaNull.Visible = true;
rprCards.DataSource = ListaArticulos;
rprCards.DataBind();

}
else
{

rprCards.DataSource = listaFiltrada;
rprCards.DataBind();
BusquedaNull.Visible = false;
}

}
protected void chMenorPrecio_CheckedChanged(object sender, EventArgs e)
{


if(chMenorPrecio.Checked)
{
chBusqueda.Enabled = false;
chMenorPrecio.Enabled = true;
chMayorPrecio.Enabled = false;

List<Articulo> articulo = ListaArticulos;

articulo = articulo.OrderBy(p => p.Precio).ToList();

rprCards.DataSource = articulo;
rprCards.DataBind();

}
else if(!chMayorPrecio.Checked)
{
rprCards.DataSource = ListaArticulos;
rprCards.DataBind();
chMayorPrecio.Enabled = true;
chMenorPrecio.Enabled = true;
chBusqueda.Enabled = true;

}
}
protected void chMayorPrecio_CheckedChanged(object sender, EventArgs e)
{
if (chMayorPrecio.Checked)
{
chBusqueda.Enabled = false;
chMenorPrecio.Enabled = false;
chMayorPrecio.Enabled = true;

List<Articulo> articulo = ListaArticulos;

articulo = articulo.OrderByDescending(p => p.Precio).ToList();

rprCards.DataSource = articulo;
rprCards.DataBind();


}
else if(!chMenorPrecio.Checked)
{
rprCards.DataSource = ListaArticulos;
rprCards.DataBind();
chMayorPrecio.Enabled = true;
chMenorPrecio.Enabled = true;
chBusqueda.Enabled = true;

}
}
/*/
    }
}
    
