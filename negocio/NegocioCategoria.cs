using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioCategoria
    {
        public List<Categoria> Listar ()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Nombre from CATEGORIAS ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = datos.Lector.GetInt32(0);
                    categoria.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(categoria);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public void AgregarCategoria(Categoria cat)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into CATEGORIAS values ('"+cat.Nombre + "')");
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
