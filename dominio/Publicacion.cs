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
     
        public Categoria Categoria { get; set; }
        public long Stock { get; set; }
        public int Cantidad { get; set; } = 1;
        public int Id_Usuario { get; set; }

    }
}
