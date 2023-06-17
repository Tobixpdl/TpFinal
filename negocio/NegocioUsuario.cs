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
                    //usuario.dni= datos.Lector.GetInt32(5);
                    usuario.telefono = (string)datos.Lector["TELEFONO"];
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

    }
}
