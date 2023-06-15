using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Publicacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Url_Imagen { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public int Id_Usuario { get; set; }

    }
}
