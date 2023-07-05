using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioVentas
    {
        public List<Venta> Listar(long dni)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " +
                    "where DNIVENDEDOR=@dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(9);
                    v.Usuario = (string)datos.Lector["USUARIO"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();

                    if (datos.Lector["FECHAENTREGA"].ToString() == "")
                    {
                        v.FechaEntrega = "No Entregado";
                    }
                    else
                    {
                        v.FechaEntrega = (datos.Lector["FECHAENTREGA"]).ToString();
                    }

                    v.Estado = (string)datos.Lector["DESCRIPCION"];
                    v.Cantidad = (int)datos.Lector["CANTIDAD"];
                    v.PrecioFinal = (decimal)datos.Lector["PRECIOFINAL"];
                    v.metodo = Convert.ToChar(datos.Lector["METODO"]); 

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
                datos.setearConsulta("INSERT into Ventas(dnivendedor,dnicomprador,usuario,titulo,fechacompra, fechaentrega,idestado,cantidad,preciofinal,metodo )" +
                " values ('" + v.DNIVendedor + "','" + v.DNIComprador + "','" + v.Usuario + "','" + v.Titulo + "',getdate(),null,'1','" + v.Cantidad + "','" + v.PrecioFinal + "','" + v.metodo + "')");

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

        public List<Venta> ListarCompras(long dni)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR, metodo FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " +
                    "where DNICOMPRADOR=@dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(9);
                    v.Usuario = (string)datos.Lector["USUARIO"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();

                    if (datos.Lector["FECHAENTREGA"].ToString() == "")
                    {
                        v.FechaEntrega = "No Entregado";
                    }
                    else
                    {
                        v.FechaEntrega = (datos.Lector["FECHAENTREGA"]).ToString();
                    }

                    v.Estado = (string)datos.Lector["DESCRIPCION"];
                    v.Cantidad = (int)datos.Lector["CANTIDAD"];
                    v.PrecioFinal = (decimal)datos.Lector["PRECIOFINAL"];
                    v.metodo = Convert.ToChar(datos.Lector["METODO"]);

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
    }


}


