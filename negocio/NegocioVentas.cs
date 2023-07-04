using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioVentas
    {
        public List<Venta> Listar(long dni)
        {
            List<Venta> lista = new List<Venta> ();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " +
                    "where DNIVENDEDOR=@dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id= datos.Lector.GetInt32(0);

                    v.DNIComprador= datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(9);
                    v.Usuario = (string)datos.Lector["USUARIO"];
                    v.Titulo= (string)datos.Lector["TITULO"];
                    v.FechaCompra =(DateTime)datos.Lector["FECHACOMPRA"];

                    if(datos.Lector["FECHAENTREGA"].ToString() == "" )
                    {
                        v.FechaEntrega = new DateTime(1, 1, 1, 1, 1, 1);
                    }else
                    {
                        v.FechaEntrega= (DateTime)datos.Lector["FECHAENTREGA"];

                    }



                    v.Estado= (string)datos.Lector["DESCRIPCION"];
                    v.Cantidad= (int)datos.Lector["CANTIDAD"];
                    v.PrecioFinal = (decimal)datos.Lector["PRECIOFINAL"];

                    lista.Add(v);
                }

                

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;

        }

        public void agregarVenta(Venta v)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT into Ventas(dnivendedor,dnicomprador,usuario,titulo,fechacompra, fechaentrega,idestado,cantidad,preciofinal )" +
                " values ('" + v.DNIVendedor+ "','" + v.DNIComprador + "','" + v.Usuario + "','" + v.Titulo + "',@fechacompra,@fechaentrega,'1','" + v.Cantidad + "','" + v.PrecioFinal + "')");

                datos.setearParametro("@fechacompra", v.FechaCompra);
                datos.setearParametro("@fechaentrega", v.FechaEntrega);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Publicacion> getCompras(string comprador)
        {
            List<Publicacion> lista = new List<Publicacion>();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                datos.setearConsulta("select p.*, v.USUARIO as Comprador from publicaciones p \r\ninner join ventas v on v.TITULO = p.TITULO\r\nwhere usuario = @usuario");

                datos.setearParametro("@usuario", comprador);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = (string)datos.Lector["titulo"];
                    aux.Precio = (decimal)datos.Lector["precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Stock = (long)datos.Lector["STOCK"];
                    aux.Id_Usuario = (int)datos.Lector["ID_USUARIO"];
                    aux.imagenes = negocioImagen.Listar(aux.Id);
                    Categoria cat = new Categoria();
                    cat.Id = (int)datos.Lector["idCategoria"];
                    cat.Nombre = (string)datos.Lector["categoria"];
                    aux.Categoria = cat;
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
