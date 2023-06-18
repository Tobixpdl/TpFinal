﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioImagen
    {
        public List<Imagen> Listar(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            /*
            if (datos.Lector != null && datos.Lector.HasRows)
            {
                if (!datos.Lector.IsDBNull(0)) // Verifica si la primera columna no es nula
                {
                    aux.Url_Imagen = (string)datos.Lector["URL_IMAGEN"];
                }
            }
            else
            {
                aux.Url_Imagen = ("https://www.google.com/imgres?imgurl=http%3A%2F%2Fwww.carsaludable.com.ar%2Fwp-content%2Fuploads%2F2014%2F03%2Fdefault-placeholder.png&tbnid=A0pMe2lq2NT_jM&vet=12ahUKEwiswrnshMn_AhXAppUCHfC-CgYQMygEegUIARDoAQ..i&imgrefurl=http%3A%2F%2Fwww.carsaludable.com.ar%2Fdefault-placeholder%2F&docid=iZpYfY_1jgLREM&w=1500&h=1500&q=default%20image&ved=2ahUKEwiswrnshMn_AhXAppUCHfC-CgYQMygEegUIARDoAQ");
            }
            lista.Add(aux);*/
            try
            {
                datos.setearConsulta("SELECT G.ID,G.IDARTICULO,G.IMAGENURL AS IMAGEN from IMAGENES G, ARTICULOS A WHERE G.IDARTICULO=A.ID AND A.ID=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = datos.Lector.GetInt32(0);
                    imagen.Url = (string)datos.Lector["IMAGEN"];
                    imagen.IdArticulo = datos.Lector.GetInt32(1);
                  
                    lista.Add(imagen);
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
