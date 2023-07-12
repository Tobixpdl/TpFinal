using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioUsuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = datos.Lector.GetInt32(0);
                    usuario.usuario = (string)datos.Lector["usuario"];
                    usuario.password = (string)datos.Lector["CONTRASEÑA"];
                    usuario.nombre = (string)datos.Lector["NOMBRES"];
                    usuario.apellido = (string)datos.Lector["APELLIDOS"];
                    usuario.dni = datos.Lector.GetInt64(5);
                    try
                    {
                        usuario.telefono = (string)datos.Lector["TELEFONO"];
                    }
                    catch (Exception)
                    {

                        usuario.telefono = "No tiene";
                    }
                    
                    usuario.mail = (string)datos.Lector["mail"];

                    lista.Add(usuario);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public void AgregarUsuario(Usuario cat)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into USUARIOS(USUARIO,CONTRASEÑA,NOMBRES,APELLIDOS,DNI,TELEFONO,MAIL) values ('" + cat.usuario + "','" + cat.password + "','" + cat.nombre + "','" + cat.apellido + "', '" + cat.dni + "', '" + cat.telefono + "', '" + cat.mail + "')");
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

        public Usuario ListarXUsuario(int id)
        {
            Usuario usuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where id= '"+ id +"'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
            {
                usuario.Id = datos.Lector.GetInt32(0);
                usuario.usuario = (string)datos.Lector["usuario"];
                usuario.password = (string)datos.Lector["CONTRASEÑA"];
                usuario.nombre = (string)datos.Lector["NOMBRES"];
                usuario.apellido = (string)datos.Lector["APELLIDOS"];
                usuario.dni= datos.Lector.GetInt64(5);
                try
                {
                    usuario.telefono = (string)datos.Lector["TELEFONO"];
                }
                catch (Exception)
                {

                    usuario.telefono = "No tiene";
                }

                usuario.mail = (string)datos.Lector["mail"];

            }

        }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public void ModificarUsuario(Usuario modificado)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("update usuarios set usuario=@usuario, contraseña=@password, mail=@mail, telefono=@telefono where Id=@id");
                
                datos.setearParametro("@id", modificado.Id);
                datos.setearParametro("@usuario", modificado.usuario);
                datos.setearParametro("@password", modificado.password);
                datos.setearParametro("@mail", modificado.mail);
                datos.setearParametro("@telefono", modificado.telefono);
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
        public void ModificarUsuario(Usuario modificado, Usuario anterior)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ventas SET usuarioVendedor = @usuario WHERE usuarioVendedor = @lastUser");
                datos.setearParametro("@lastUser", anterior.usuario);
                datos.setearParametro("@usuario", modificado.usuario);
                datos.ejecutarAccion();
                datos.setearConsulta("UPDATE ventas SET usuario = @usuario WHERE usuario = @lastUser");
                datos.ejecutarAccion();
                datos.setearConsulta("UPDATE usuarios SET usuario = @usuario, contraseña = @password, mail = @mail, telefono = @telefono WHERE Id = @id");     
                datos.setearParametro("@id", modificado.Id);
                datos.setearParametro("@password", modificado.password);
                datos.setearParametro("@mail", modificado.mail);
                datos.setearParametro("@telefono", modificado.telefono);
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

            public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where Id_Usuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.setearConsulta("delete FROM Imagenes WHERE idpublicacion IN (SELECT id FROM Publicaciones WHERE id_usuario = @id)");
                datos.ejecutarAccion();
                datos.setearConsulta("delete from publicaciones where ID_USUARIO=@id");
                datos.ejecutarAccion();
                datos.setearConsulta("delete from usuarios where Id=@id");
                datos.ejecutarAccion();

            }
            catch (Exception)
            {
                throw;
            }

        }

        
        public Usuario ListarXUsuario(string usuario)
        {
            Usuario user = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where usuario= '" + usuario + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    user.Id = datos.Lector.GetInt32(0);
                    user.usuario = (string)datos.Lector["usuario"];
                    user.password = (string)datos.Lector["CONTRASEÑA"];
                    user.nombre = (string)datos.Lector["NOMBRES"];
                    user.apellido = (string)datos.Lector["APELLIDOS"];
                    user.dni = datos.Lector.GetInt64(5);
                    try
                    {
                        user.telefono = (string)datos.Lector["TELEFONO"];
                    }
                    catch (Exception)
                    {

                        user.telefono = "No tiene";
                    }

                    user.mail = (string)datos.Lector["mail"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }

       

        public Usuario ListarXDNI(long dni)
        {
            Usuario user = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select id, usuario, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, TELEFONO, mail from USUARIOS where dni = @dni");

                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    user.Id = datos.Lector.GetInt32(0);
                    user.usuario = (string)datos.Lector["usuario"];
                    user.password = (string)datos.Lector["CONTRASEÑA"];
                    user.nombre = (string)datos.Lector["NOMBRES"];
                    user.apellido = (string)datos.Lector["APELLIDOS"];
                    user.dni = datos.Lector.GetInt64(5);
                    try
                    {
                        user.telefono = (string)datos.Lector["TELEFONO"];
                    }
                    catch (Exception)
                    {

                        user.telefono = "No tiene";
                    }

                    user.mail = (string)datos.Lector["mail"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
    }
}









