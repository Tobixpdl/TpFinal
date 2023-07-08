using dominio;
using System;
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


    }
}
