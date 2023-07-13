using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioComentarios
    {

        public List<Comentario> Listar(int id)
        {
            List<Comentario> lista = new List<Comentario>();
            AccesoDatos datos = new AccesoDatos();
          

            try
            {
                datos.setearConsulta("select id,idventa,remitente,destinatario,mensaje,reputacion,fecha from comentarios where idventa=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Comentario c = new Comentario();
                    c.Id = datos.Lector.GetInt32(0);
                    c.IdVenta = datos.Lector.GetInt32(1);
                    c.Remitente = (string)datos.Lector["remitente"];
                    c.Destinatario = (string)datos.Lector["destinatario"];
                    c.Mensaje = (string)datos.Lector["mensaje"];
                    c.Reputacion = !datos.Lector.IsDBNull(5) ? datos.Lector.GetInt32(5) : 1;
                    c.Fecha= datos.Lector["fecha"].ToString();
                    lista.Add(c);

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
        public void changeUserName(string old,string newName,int decision)
        {
            AccesoDatos datos = new AccesoDatos();

            if(decision%2==0)
            {

            try
            {
                datos.setearConsulta("UPDATE  comentarios set remitente = @new where remitente=@old");
                datos.setearParametro("@new", newName);
                datos.setearParametro("@old", old);
                datos.ejecutarAccion();
                /*datos.setearConsulta("UPDATE  comentarios set destinatario = @new where remitente=@old");
                datos.setearParametro("@new", newName);
                datos.setearParametro("@old", old);
                datos.ejecutarAccion();*/
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            }else
            {
                try
                {
                   
                    datos.setearConsulta("UPDATE  comentarios set destinatario = @new where destinatario=@old");
                    datos.setearParametro("@new", newName);
                    datos.setearParametro("@old", old);
                    datos.ejecutarAccion();
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
        public List<Comentario> ListarPorUsuario(string Name)
        {
            List<Comentario> lista = new List<Comentario>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select distinct remitente,mensaje,reputacion,fecha from comentarios where destinatario = @name");
                datos.setearParametro("@name", Name);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Comentario c = new Comentario();
              
               
                    c.Remitente = (string)datos.Lector["remitente"];
               
                    c.Mensaje = (string)datos.Lector["mensaje"];
                    c.Reputacion = datos.Lector.GetInt32(2) ;
                    c.Fecha = datos.Lector["fecha"].ToString();
                    lista.Add(c);

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

        public void newComent(int venta,string remitente,string destinatario,string mensaje,int reputacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
           

                    datos.setearConsulta("insert into Comentarios(idventa,REMITENTE,DESTINATARIO,mensaje,reputacion,fecha)\r\nVALUES(@venta,@remitente,@destinatario,@mensaje,@reputacion,GETDATE())");
                
                datos.setearParametro("@venta", venta);
                datos.setearParametro("@remitente", remitente);
                datos.setearParametro("@destinatario", destinatario);
                datos.setearParametro("@mensaje", mensaje);
                
                datos.setearParametro("@reputacion", reputacion);
                datos.ejecutarLectura();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}

        }
        public List<Comentario> listarUltimos(string name) {

            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();
            try
            {
                datos.setearConsulta("  SELECT V.ID AS VentaID, C.MENSAJE, C.REPUTACION,c.remitente\r\nFROM VENTAS V\r\nINNER JOIN (\r\n  SELECT IDVenta, MENSAJE, REPUTACION,remitente, ROW_NUMBER() OVER (PARTITION BY IDVenta ORDER BY fecha DESC) AS rn\r\n  FROM Comentarios where destinatario=@name\r\n) C ON C.IDVenta = V.ID AND C.rn = 1 ");
                datos.setearParametro("@name", name);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario c = new Comentario();
                    Venta venta = new Venta();

                    c.Remitente = (string)datos.Lector["remitente"];

                    c.Mensaje = (string)datos.Lector["MENSAJE"];
                    c.Reputacion = datos.Lector.GetInt32(2);
                    NegocioVentas negocio = new NegocioVentas();

                    venta =negocio.RV((int)datos.Lector["VentaID"]);
                    if(venta.Estado!="En proceso"&& venta.Estado!="En reclamo" && venta.UsuarioComprador!=name)
                    {

                    lista.Add(c);
                    }
                    
                }



            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }



            return lista;
         }









        public float getRep(string name,ref int cantidad)
        {
            var rate=0;
            var sumatoria = 0;
            cantidad = 0;
            AccesoDatos datos=new AccesoDatos();
            try
            {
                datos.setearConsulta(" SELECT V.ID AS VentaID, C.MENSAJE AS UltimoComentario, C.REPUTACION,c.remitente\r\nFROM VENTAS V\r\nINNER JOIN (\r\n  SELECT IDVenta, MENSAJE, REPUTACION,remitente, ROW_NUMBER() OVER (PARTITION BY IDVenta ORDER BY fecha DESC) AS rn\r\n  FROM Comentarios where destinatario=@name\r\n) C ON C.IDVenta = V.ID AND C.rn = 1 ");
                datos.setearParametro("@name", name);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    sumatoria = (int)datos.Lector.GetInt32(0);
                    cantidad = (int)datos.Lector.GetInt32(1);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}

            if (sumatoria != 0 && cantidad != 0)
            {
              rate = sumatoria / cantidad;
            }
            return rate;

        }


    }
}
