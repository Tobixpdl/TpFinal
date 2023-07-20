using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class NegocioVentas
    {
        public List<Venta> ListarTodo()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO, USUARIOVENDEDOR,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo,URLIMAGEN,estado FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " );
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(10);
                    v.UsuarioComprador = (string)datos.Lector["USUARIO"];
                    v.UsuarioVendedor = (string)datos.Lector["USUARIOVENDEDOR"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.finalizada = (bool)datos.Lector["estado"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();
                    if (datos.Lector["URLIMAGEN"].ToString() == "")
                    {
                        v.urlImagen = (string)datos.Lector["URLIMAGEN"];
                    }
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
                    if (datos.Lector["METODO"] != null)
                    {
                        char letra = Convert.ToChar(datos.Lector["METODO"]);
                        switch (letra)
                        {
                            case 'e':
                                v.metodo = "Efectivo";
                                break;
                            case 't':
                                v.metodo = "Transferencia Bancaria";
                                break;

                        }

                    }


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


        public List<Venta> Listar(long dni)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO, USUARIOVENDEDOR,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo,URLIMAGEN,estado FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " +
                    "where DNIVENDEDOR=@dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(10);
                    v.UsuarioComprador = (string)datos.Lector["USUARIO"];
                    v.UsuarioVendedor = (string)datos.Lector["USUARIOVENDEDOR"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();
                    v.urlImagen = (string)datos.Lector["URLIMAGEN"] != "null" ? (string)datos.Lector["URLIMAGEN"] : "null";
                    v.finalizada = (bool)datos.Lector["estado"];
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
                    if (datos.Lector["METODO"] != null)
                    {
                        char letra = Convert.ToChar(datos.Lector["METODO"]);
                        switch (letra)
                        {
                            case 'e':
                                v.metodo = "Efectivo";
                                break;
                            case 't':
                                v.metodo = "Transferencia Bancaria";
                                break;

                        }

                    }


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
        public void AC(int id,string url)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(" update  VENTAS set URLIMAGEN=@url WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@url", url);
                datos.ejecutarLectura();
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
        public Venta RV(int n)
        {
            Venta aux = new Venta();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(" SELECT v.ID,DNICOMPRADOR,USUARIO, USUARIOVENDEDOR,TITULO,FECHACOMPRA,FECHAENTREGA,e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo,URLIMAGEN,estado,solicitante,solicitud FROM VENTAS V inner join Estados e  on v.IDESTADO = e.ID where V.ID = @id");
                datos.setearParametro("@id", n);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    aux.Id = datos.Lector.GetInt32(0);
                
                    aux.DNIComprador = datos.Lector.GetInt32(1);
                    aux.DNIVendedor = datos.Lector.GetInt32(10);
                    aux.UsuarioComprador = (string)datos.Lector["USUARIO"];
                    aux.UsuarioVendedor = (string)datos.Lector["USUARIOVENDEDOR"];
                    aux.Titulo = (string)datos.Lector["TITULO"];
                    aux.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();
                    aux.finalizada = (bool)datos.Lector["estado"];
                    aux.solicitud = (bool)datos.Lector["solicitud"];
                    aux.solicitud = (bool)datos.Lector["solicitud"];
                    aux.solicitante = (string)datos.Lector["solicitante"];

                    if (datos.Lector["FECHAENTREGA"].ToString() == "")
                    {
                        aux.FechaEntrega = "No Entregado";
                    }
                    else
                    {
                        aux.FechaEntrega = (datos.Lector["FECHAENTREGA"]).ToString();
                    }
                    aux.urlImagen = (string)datos.Lector["URLIMAGEN"] != "null" ? (string)datos.Lector["URLIMAGEN"] : "null";
                     
                    

                    aux.Estado = (string)datos.Lector["DESCRIPCION"];
                    aux.Cantidad = (int)datos.Lector["CANTIDAD"];
                    aux.PrecioFinal = (decimal)datos.Lector["PRECIOFINAL"];
                    if (datos.Lector["METODO"] != null)
                    {
                        char letra = Convert.ToChar(datos.Lector["METODO"]);
                        switch (letra)
                        {
                            case 'e':
                                aux.metodo = "Efectivo";
                                break;
                            case 't':
                                aux.metodo = "Transferencia Bancaria";
                                break;

                        }
                    }


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
            return aux;

        }

        public void ME(int id,int e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               if(e==2)
                {

                        datos.setearConsulta(" update ventas set idestado=@e,FECHAENTREGA=GETDATE() where id=@id");
                }else
                {

                datos.setearConsulta(" update ventas set idestado=@e where id=@id");

                }
                 
                datos.setearParametro("@id", id);
                datos.setearParametro("@e", e);
                datos.ejecutarLectura();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void modificarSolicitante(int id, string solicitante,bool solicitud)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               

                    datos.setearConsulta(" update ventas set solicitante=@solicitante,solicitud=@solicitud where id=@id");
                
               

                   

                

                datos.setearParametro("@id", id);
                datos.setearParametro("@solicitud", solicitud);
                datos.setearParametro("@solicitante", solicitante);
                datos.ejecutarLectura();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void finalizarVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               

                    datos.setearConsulta(" update ventas set estado=1 where id=@id");
                
              

                datos.setearParametro("@id", id);
               
                datos.ejecutarLectura();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void agregarVenta(Venta v)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT into Ventas(dnivendedor,dnicomprador,usuario,usuariovendedor,titulo,fechacompra, fechaentrega,idestado,cantidad,preciofinal,metodo,URLIMAGEN,estado,solicitante,solicitud)" +
                " values ('" + v.DNIVendedor + "','" + v.DNIComprador + "','" + v.UsuarioComprador + "','" + v.UsuarioVendedor + "','" + v.Titulo + "',getdate(),null,'1','" + v.Cantidad + "','" + v.PrecioFinal + "','" + v.metodo + "','null',0,'null',0)");

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
                datos.setearConsulta(" select v.ID,DNICOMPRADOR,USUARIO, USUARIOVENDEDOR,TITULO,FECHACOMPRA,FECHAENTREGA," +
                    "e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo,URLIMAGEN,estado FROM VENTAS V\r\ninner join Estados e  on v.IDESTADO=e.ID " +
                    "where DNICOMPRADOR=@dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(10);
                    v.UsuarioComprador = (string)datos.Lector["USUARIO"];
                    v.UsuarioVendedor = (string)datos.Lector["USUARIOVENDEDOR"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();
                    v.urlImagen = (string)datos.Lector["URLIMAGEN"] != null ? (string)datos.Lector["URLIMAGEN"].ToString() : "null";
                    v.finalizada = (bool)datos.Lector["estado"];
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
                    if (datos.Lector["METODO"] != null)
                    {
                        char letra = Convert.ToChar(datos.Lector["METODO"]);
                        switch (letra)
                        {
                            case 'e':
                                v.metodo = "Efectivo";
                                break;
                            case 't':
                                v.metodo = "Transferencia Bancaria";
                                break;

                        }

                    }

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

        public List<Venta> listarXEstado(string estado)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select v.ID,DNICOMPRADOR,USUARIO, USUARIOVENDEDOR,TITULO,FECHACOMPRA,FECHAENTREGA,\r\n e.DESCRIPCION,CANTIDAD,PRECIOFINAL,DNIVENDEDOR,metodo,URLIMAGEN,estado" +
                    " FROM VENTAS V inner join Estados e  on v.IDESTADO=e.ID \r\n  where e.DESCRIPCION = @estado");
                datos.setearParametro("@estado", estado);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = datos.Lector.GetInt32(0);

                    v.DNIComprador = datos.Lector.GetInt32(1);
                    v.DNIVendedor = datos.Lector.GetInt32(10);
                    v.UsuarioComprador = (string)datos.Lector["USUARIO"];
                    v.UsuarioVendedor = (string)datos.Lector["USUARIOVENDEDOR"];
                    v.Titulo = (string)datos.Lector["TITULO"];
                    v.FechaCompra = (datos.Lector["FECHACOMPRA"]).ToString();
                    v.urlImagen = (string)datos.Lector["URLIMAGEN"] != null ? (string)datos.Lector["URLIMAGEN"].ToString() : "null";
                    v.finalizada = (bool)datos.Lector["estado"];
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
                    if (datos.Lector["METODO"] != null)
                    {
                        char letra = Convert.ToChar(datos.Lector["METODO"]);
                        switch (letra)
                        {
                            case 'e':
                                v.metodo = "Efectivo";
                                break;
                            case 't':
                                v.metodo = "Transferencia Bancaria";
                                break;

                        }

                    }

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


