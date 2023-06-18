﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using System.Windows.Forms.VisualStyles;
using dominio;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;

namespace negocio
{
    public class NegocioPublicacion
    {
        public List<Publicacion> Listar()
        {
            List<Publicacion> lista = new List<Publicacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select p.id, p.titulo, p.precio, p.DESCRIPCION, p.URL_IMAGEN, c.NOMBRE as categoria, p.STOCK, p.ID_USUARIO from PUBLICACIONES p, CATEGORIAS c where p.categoria=c.ID");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = (string)datos.Lector["titulo"];
                    aux.Precio = (decimal)datos.Lector["precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.Stock = datos.Lector.GetInt32(6);
                    aux.Stock = (long)datos.Lector["STOCK"];
                    aux.Id_Usuario = (int)datos.Lector["ID_USUARIO"];

                   aux.Categoria = (string)datos.Lector["categoria"];
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
        public List<Publicacion> ListarXUsuario(int id)
        {
            List<Publicacion> lista = new List<Publicacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select p.id, p.titulo, p.precio, p.DESCRIPCION, p.URL_IMAGEN, c.NOMBRE as categoria, p.STOCK, p.ID_USUARIO from PUBLICACIONES p, CATEGORIAS c where p.categoria=c.ID AND p.ID_USUARIO=@id");


                datos.setearParametro("@id", id);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.Stock = datos.Lector.GetInt32(6);
                    aux.Stock = (long)datos.Lector["STOCK"];
                    aux.Id_Usuario = (int)datos.Lector["ID_USUARIO"];

                    aux.Categoria = (string)datos.Lector["categoria"];
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
        /*
             public List<Publicacion> ListarConSP()
             {
                 List<Publicacion> lista = new List<Publicacion>();
                 AccesoDatos datos = new AccesoDatos();
                 NegocioImagen misImagens = new NegocioImagen();

                 try
                 {
                     //string consulta = "Select a.Id, a.Codigo, Nombre,a.Descripcion,a.IdMarca,a.IdCategoria,c.DESCRIPCION as Categoria,m.DESCRIPCION as Marca,Precio from ARTICULOS a , categorias c, marcas m where a.idcategoria=c.ID and a.idMarca=m.id ";

                     // datos.setearConsulta(consulta);
                     datos.setearProcedimiento("storedListar");
                     datos.ejecutarLectura();

                     while (datos.Lector.Read())
                     {
                         Publicacion aux = new Publicacion();
                         aux.Id = datos.Lector.GetInt32(0);
                         aux.Codigo = (string)datos.Lector["Codigo"];
                         aux.Nombre = (string)datos.Lector["Nombre"];
                         aux.Descripcion = (string)datos.Lector["Descripcion"];
                         aux.Categoria = new Categoria();
                         aux.Categoria.Id = datos.Lector.GetInt32(5);
                         aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                         aux.Marca = new Marca();
                         aux.Marca.Id = datos.Lector.GetInt32(4);
                         aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                         aux.Precio = (decimal)datos.Lector["Precio"];
                         aux.Imagenes = misImagens.Listar(datos.Lector.GetInt32(0));
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

        
             public List<Publicacion> ListarXNombre(string nombre)
             {
                 List<Publicacion> lista = new List<Publicacion>();
                 AccesoDatos datos = new AccesoDatos();
                 NegocioImagen misImagens = new NegocioImagen();

                 try
                 {
                     datos.setearConsulta("Select a.Id, Codigo, Nombre,a.Descripcion,a.IdMarca,idcategoria,c.DESCRIPCION as Categoria,m.DESCRIPCION as Marca,Precio from ARTICULOS a , categorias c, marcas m where a.idcategoria=c.ID and a.idMarca=m.id");

                     datos.ejecutarLectura();
                     while (datos.Lector.Read())
                     {
                         Publicacion aux = new Publicacion();
                         string nnombre = (string)datos.Lector["Nombre"];
                         if (nnombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) > -1)
                         {
                             aux.Id = datos.Lector.GetInt32(0);
                             aux.Codigo = (string)datos.Lector["Codigo"];
                             aux.Nombre = (string)datos.Lector["Nombre"];
                             aux.Descripcion = (string)datos.Lector["Descripcion"];
                             aux.Categoria = new Categoria();
                             aux.Categoria.Id = datos.Lector.GetInt32(5);
                             aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                             aux.Marca = new Marca();
                             aux.Marca.Id = datos.Lector.GetInt32(4);
                             aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                             aux.Precio = (decimal)datos.Lector["Precio"];
                             aux.Imagenes = misImagens.Listar(datos.Lector.GetInt32(0));
                             lista.Add(aux);
                         }
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
        
             public List<Publicacion> ListarXMarca(int id)
             {
                 List<Publicacion> lista = new List<Publicacion>();
                 SqlConnection conexion = new SqlConnection();
                 SqlCommand comando = new SqlCommand();
                 SqlDataReader lector;

                 try
                 {
                     conexion.ConnectionString = "server=Tobi\\SQLEXPRESST; database=CATALOGO_P3_DB; integrated security=true";
                     comando.CommandType = System.Data.CommandType.Text;
                     comando.CommandText = "Select A.Id, Codigo, Nombre,Descripcion,IdMarca,IdCategoria,Precio, ImagenUrl  from ARTICULOS A, IMAGENES I  WHERE A.Id=I.IdArticulo and A.Nombre=nombre";
                     comando.Connection = conexion;
                     conexion.Open();
                     lector = comando.ExecuteReader();
                     while (lector.Read())
                     {
                         Publicacion aux = new Publicacion();
                         id = lector.GetInt32(0);
                         /* if (id == aux.IdMarca)
                          {
                              aux.Id = lector.GetInt32(0);
                              aux.Codigo = (string)lector["Codigo"];
                              aux.Nombre = (string)lector["Nombre"];
                              aux.Descripcion = (string)lector["Descripcion"];
                              aux.IdMarca = lector.GetInt32(4);
                              //aux.IdCategoria = lector.GetInt32(5);
                              aux.Precio = lector.GetDecimal(6);
                              //aux.UrlImagen = (string)lector["ImagenUrl"];
                              if (lista.Count == 0)
                              {
                                  lista.Add(aux);

                              }
                              else

                          if (lista.Last().Id == aux.Id)
                              {

                                  lista.Remove(aux);
                              }
                              else
                              {
                                  lista.Add(aux);
                              }
                          }


                     }
                     conexion.Close();
                     return lista;
                 }
                 catch (Exception)
                 {

                     throw;
                 }

             }

             public void AgregarArticulo(Publicacion agregar)
             {
                 AccesoDatos datos = new AccesoDatos();
                 try
                 {
                     datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)" +
                         " values ('" + agregar.Codigo + "','" + agregar.Nombre + "','" + agregar.Descripcion + "',@IdMarca,@IdCategoria,'" + agregar.Precio + "')");
                     datos.setearParametro("@IdMarca", agregar.Marca.Id);
                     datos.setearParametro("@IdCategoria", agregar.Categoria.Id);
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



             public void ModificarArticulo(Publicacion modificado)
             {
                 AccesoDatos datos = new AccesoDatos();


                 try
                 {
                     datos.setearConsulta("update Articulos set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, IdMarca=@idmarca, IdCategoria=@idcategoria, Precio=@precio  where Id=@id");
                     datos.setearParametro("@id", modificado.Id);
                     datos.setearParametro("@codigo", modificado.Codigo);
                     datos.setearParametro("@nombre", modificado.Nombre);
                     datos.setearParametro("@descripcion", modificado.Descripcion);
                     datos.setearParametro("@idmarca", modificado.Marca.Id);
                     datos.setearParametro("@idcategoria", modificado.Categoria.Id);
                     datos.setearParametro("@precio", modificado.Precio);
                     datos.EjecutarAccion();
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
             public void Eliminar(int id)
             {
                 try
                 {
                     AccesoDatos datos = new AccesoDatos();
                     datos.setearConsulta("delete from Articulos where Id=@id");
                     datos.setearParametro("@id", id);
                     datos.ejecutarAccion();

                 }
                 catch (Exception)
                 {

                     throw;
                 }

             }
             public void EliminarImg(int img)
             {
                 AccesoDatos datos = new AccesoDatos();


                 try
                 {

                     datos.setearConsulta("delete from imagenes where id=@numero");
                     datos.setearParametro("@numero", img);
                     datos.ejecutarAccion();

                 }
                 catch (Exception)
                 {

                     throw;
                 }

             }
             public void agregarImagenUrl(int id, string url)
             {
                 AccesoDatos datos = new AccesoDatos();

                 try
                 {

                     datos.setearConsulta("insert into Imagenes (IDARTICULO,IMAGENURL) values (@idArticulo,@url)");
                     datos.setearParametro("@idarticulo", id);
                     datos.setearParametro("@url", url);
                     datos.ejecutarAccion();

                 }
                 catch (Exception)
                 {

                     throw;
                 }

             }

             public List<Publicacion> Filtrar(string campo, string criterio, string filtro)
             {
                 List<Publicacion> lista = new List<Publicacion>();
                 AccesoDatos datos = new AccesoDatos();
                 NegocioImagen misImagens = new NegocioImagen();

                 try
                 {
                     string consulta = "Select a.Id, a.Codigo, Nombre,a.Descripcion,a.IdMarca,a.IdCategoria,c.DESCRIPCION as Categoria,m.DESCRIPCION as Marca,Precio from ARTICULOS a , categorias c, marcas m where a.idcategoria=c.ID and a.idMarca=m.id and ";

                     if (campo == "Id")
                     {
                         switch (criterio)
                         {
                             case "Mayor a":
                                 consulta += "a.Id > " + filtro;
                                 break;

                             case "Menor a":
                                 consulta += "a.Id < " + filtro;
                                 break;

                             case "Igual a":
                                 consulta += "a.Id = " + filtro;
                                 break;

                         }
                     }
                     else if (campo == "Precio")
                         {
                             switch (criterio)
                             {
                                 case "Mayor a":
                                     consulta += "Precio > " + filtro;
                                     break;

                                 case "Menor a":
                                     consulta += "Precio< " + filtro;
                                     break;

                                 case "Igual a":
                                     consulta += "Precio = " + filtro;
                                     break;

                             }
                         }

                         else if (campo == "Nombre")
                     {
                         switch (criterio)
                         {
                             case "Comienza con":
                                 consulta += "Nombre like '" + filtro + "%' ";
                                 break;

                             case "Termina con":
                                 consulta += "Nombre like '%" + filtro + "' ";
                                 break;

                             case "Contiene":
                                 consulta += "Nombre like '%" + filtro + "%' ";
                                 break;

                         }
                     }
                     else if (campo == "Descripción")
                     {
                         switch (criterio)
                         {
                             case "Comienza con":
                                 consulta += "a.Descripcion like '" + filtro + "%' ";
                                 break;

                             case "Termina con":
                                 consulta += "a.Descripcion like '%" + filtro + "' ";
                                 break;

                             case "Contiene":
                                 consulta += "a.Descripcion like '%" + filtro + "%' ";
                                 break;

                         }
                     }

                     datos.setearConsulta(consulta);
                     datos.ejecutarLectura();


                     while (datos.Lector.Read())
                     {
                         Publicacion aux = new Publicacion();
                         aux.Id = datos.Lector.GetInt32(0);
                         aux.Codigo = (string)datos.Lector["Codigo"];
                         aux.Nombre = (string)datos.Lector["Nombre"];
                         aux.Descripcion = (string)datos.Lector["Descripcion"];
                         aux.Categoria = new Categoria();
                         aux.Categoria.Id = datos.Lector.GetInt32(5);
                         aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                         aux.Marca = new Marca();
                         aux.Marca.Id = datos.Lector.GetInt32(4);
                         aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                         aux.Precio = (decimal)datos.Lector["Precio"];
                         aux.Imagenes = misImagens.Listar(datos.Lector.GetInt32(0));
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
     */
    }
}
