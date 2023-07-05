using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }    
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public string Mensaje { get; set; }
        public int Reputacion { get; set; }
        public string Fecha { get; set; }


    }
}
